

using Android.Content;
using Android.Hardware;
using Android.Views;
using HeromeApp.Controls;
using HeromeApp.Droid.Renderers;
using Java.Interop;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace HeromeApp.Droid.Renderers
{
    // Disable warnings for obsolete android Camera API.
    // This will need to be replaced in the future with the Camera2 API.
    // seealso: Herome.Droid.Renderers.HeromeCameraPreviewRenderer
#pragma warning disable CS0618 // Type or member is obsolete
    public class CameraPreview : ViewGroup, ISurfaceHolderCallback
    {
        private SurfaceView _surfaceView;
        private ISurfaceHolder _holder;
        private Camera.Size _previewSize;
        private IList<Camera.Size> _supportedPreviewSizes;
        private Camera _camera;
        private IWindowManager _windowManager;

        public bool IsPreviewing { get; set; }

        public Camera Preview
        {
            get { return _camera; }
            set
            {
                _camera = value;
                if (_camera != null)
                {
                    _supportedPreviewSizes = Preview.GetParameters().SupportedPreviewSizes;
                    RequestLayout();
                }
            }
        }

        public CameraPreview(Context context) : base(context)
        {
            _surfaceView = new SurfaceView(context);
            AddView(_surfaceView);

            _windowManager = Context.GetSystemService(Context.WindowService).JavaCast<IWindowManager>();
            IsPreviewing = false;
            _holder = _surfaceView.Holder;
            _holder.AddCallback(this);
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            int width = ResolveSize(SuggestedMinimumWidth, widthMeasureSpec);
            int height = ResolveSize(SuggestedMinimumHeight, heightMeasureSpec);
            SetMeasuredDimension(width, height);

            if (_supportedPreviewSizes != null)
            {
                _previewSize = GetOptimalPreviewSize(_supportedPreviewSizes, width, height);
            }
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            var msw = MeasureSpec.MakeMeasureSpec(r - l, MeasureSpecMode.Exactly);
            var msh = MeasureSpec.MakeMeasureSpec(b - t, MeasureSpecMode.Exactly);

            _surfaceView.Measure(msw, msh);
            _surfaceView.Layout(0, 0, r - l, b - t);
        }

        public void SurfaceCreated(ISurfaceHolder holder)
        {
            Preview?.SetPreviewDisplay(holder);
        }

        public void SurfaceDestroyed(ISurfaceHolder holder)
        {
            Preview?.StopPreview();
        }

        public void SurfaceChanged(ISurfaceHolder holder, Android.Graphics.Format format, int width, int height)
        {
            var parameters = Preview.GetParameters();
            parameters.SetPreviewSize(_previewSize.Width, _previewSize.Height);
            RequestLayout();

            switch (_windowManager.DefaultDisplay.Rotation)
            {
                case SurfaceOrientation.Rotation0:
                    _camera.SetDisplayOrientation(90);
                    break;
                case SurfaceOrientation.Rotation90:
                    _camera.SetDisplayOrientation(0);
                    break;
                case SurfaceOrientation.Rotation270:
                    _camera.SetDisplayOrientation(180);
                    break;
            }

            Preview.SetParameters(parameters);
            Preview.StartPreview();
            IsPreviewing = true;
        }

        Camera.Size GetOptimalPreviewSize(IList<Camera.Size> sizes, int w, int h)
        {
            const double AspectTolerance = 0.1;
            double targetRatio = (double)w / h;

            if (sizes == null)
            {
                return null;
            }

            Camera.Size optimalSize = null;
            double minDiff = double.MaxValue;

            int targetHeight = h;
            foreach (Camera.Size size in sizes)
            {
                double ratio = (double)size.Width / size.Height;

                if (Math.Abs(ratio - targetRatio) > AspectTolerance)
                    continue;
                if (Math.Abs(size.Height - targetHeight) < minDiff)
                {
                    optimalSize = size;
                    minDiff = Math.Abs(size.Height - targetHeight);
                }
            }

            if (optimalSize == null)
            {
                minDiff = double.MaxValue;
                foreach (Camera.Size size in sizes)
                {
                    if (Math.Abs(size.Height - targetHeight) < minDiff)
                    {
                        optimalSize = size;
                        minDiff = Math.Abs(size.Height - targetHeight);
                    }
                }
            }
            return optimalSize;
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete
}