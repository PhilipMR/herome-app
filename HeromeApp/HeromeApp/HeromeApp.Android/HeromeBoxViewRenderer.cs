using Android.Content;
using Android.Graphics;
using Android.Util;
using HeromeApp;
using HeromeApp.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(HeromeBoxView), typeof(HeromeBoxViewRenderer))]
namespace HeromeApp.Droid
{
	class HeromeBoxViewRenderer : BoxRenderer
	{
		private float _cornerRadius;
		private RectF _bounds;
		private Path _path;

		public HeromeBoxViewRenderer(Context context) : base(context)
		{
		}

		protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
		{
			base.OnElementChanged(e);
			if (e.OldElement != null || e.NewElement == null)
				return;
			var boxView = (HeromeBoxView)Element;
			_cornerRadius = TypedValue.ApplyDimension(ComplexUnitType.Dip, (float)boxView.CornerRadius, Context.Resources.DisplayMetrics);
		}

		protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
		{
			base.OnSizeChanged(w, h, oldw, oldh);
			if (w != oldw && h != oldh) {
				_bounds = new RectF(0, 0, w, h);
			}
			_path = new Path();
			_path.Reset();
			_path.AddRoundRect(_bounds, _cornerRadius, _cornerRadius, Path.Direction.Cw);
			_path.Close();
		}

		public override void Draw(Canvas canvas)
		{
			canvas.Save();
			canvas.ClipPath(_path);
			base.Draw(canvas);
			canvas.Restore();
		}
	}
}