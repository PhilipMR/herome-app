using System;
using Android.Content;
using Android.Content.PM;
using Android.Hardware;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Herome.Droid.Renderers;
using HeromeApp.Controls;
using HeromeApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(HeromeCameraPreview), typeof(HeromeCameraPreviewRenderer))]
namespace Herome.Droid.Renderers
{
    // Disable warnings for obsolete android Camera API.
    // This will need to be replaced in the future with the Camera2 API.
    // seealso: Herome.Droid.Renderers.CameraPreview
#pragma warning disable CS0618 // Type or member is obsolete
    public class HeromeCameraPreviewRenderer : ViewRenderer<HeromeCameraPreview, CameraPreview>
    {
        private CameraPreview _cameraPreview;

        public HeromeCameraPreviewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<HeromeCameraPreview> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                _cameraPreview = new CameraPreview(Context);
                SetNativeControl(_cameraPreview);
            }

            if (e.OldElement != null)
            {
                // Unsubscribe
                _cameraPreview.Click -= OnCameraPreviewClicked;
            }
            if (e.NewElement != null)
            {
                try
                {
                    _cameraPreview.Preview?.Release();
                    _cameraPreview.Preview = Camera.Open();
                    if (_cameraPreview.Preview != null)
                    {
                        Camera.Parameters parameters = _cameraPreview.Preview.GetParameters();
                        parameters.FocusMode = Camera.Parameters.FocusModeContinuousPicture;
                        _cameraPreview.Preview.SetParameters(parameters);
                    }
                }
                catch (Exception ex)
                {
                    Android.Util.Log.WriteLine(Android.Util.LogPriority.Debug, "HeromeApp", $"Failed to open Camera! {ex.StackTrace}");
                }

                // Subscribe
                _cameraPreview.Click += OnCameraPreviewClicked;
            }
        }

        void OnCameraPreviewClicked(object sender, EventArgs e)
        {
            if (_cameraPreview.IsPreviewing)
            {
                _cameraPreview.Preview.StopPreview();
                _cameraPreview.IsPreviewing = false;
            }
            else
            {
                _cameraPreview.Preview.StartPreview();
                _cameraPreview.IsPreviewing = true;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Control.Preview.Release();
            }
            base.Dispose(disposing);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete
}