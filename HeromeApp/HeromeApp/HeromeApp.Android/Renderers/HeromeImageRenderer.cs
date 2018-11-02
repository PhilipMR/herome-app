using Android.Content;
using Android.Graphics;
using Android.Util;
using HeromeApp.Controls;
using HeromeApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(HeromeImage), typeof(HeromeImageRenderer))]
namespace HeromeApp.Droid.Renderers
{
	class HeromeImageRenderer : ImageRenderer
	{
		#region Fields
		private float _cornerRadius;
		private RectF _bounds;
		private Path _path;
		#endregion

		#region Constructors
		public HeromeImageRenderer(Context context) : base(context)
		{
		}
		#endregion

		#region Renderer overrides
		protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
		{
			base.OnElementChanged(e);
			if (e.OldElement != null || e.NewElement == null)
				return;
			var image = (HeromeImage)Element;
			_cornerRadius = TypedValue.ApplyDimension(ComplexUnitType.Dip, (float)image.CornerRadius, Context.Resources.DisplayMetrics);
		}

		protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
		{
			base.OnSizeChanged(w, h, oldw, oldh);
			if (w != oldw && h != oldh)
			{
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
		#endregion
	}
}