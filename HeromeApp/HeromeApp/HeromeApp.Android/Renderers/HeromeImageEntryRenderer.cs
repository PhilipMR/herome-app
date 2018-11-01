using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Support.V4.Content;
using HeromeApp.Controls;
using HeromeApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(HeromeImageEntry), typeof(HeromeImageEntryRenderer))]
namespace HeromeApp.Droid.Renderers
{
    class HeromeImageEntryRenderer : EntryRenderer
    {
		/// <summary>
		/// A BitmapDrawable that can be locally offsetted.
		/// </summary>
		private class DisplacedBitmapDrawable : BitmapDrawable
		{
			public int OffsetX { get; set; }
			public int OffsetY { get; set; }

			public DisplacedBitmapDrawable(Resources res, Bitmap bitmap) : base(res, bitmap)
			{
				this.OffsetX = 0;
				this.OffsetY = 0;
			}

			public override void Draw(Canvas canvas)
			{
				canvas.Save();
				canvas.Translate(this.OffsetX, this.OffsetY);
				base.Draw(canvas);
				canvas.Restore();
			}
		}

		public HeromeImageEntryRenderer(Context context) : base(context)
        {
        }

		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);
			if (e.OldElement != null || e.NewElement == null)
				return;
			HeromeImageEntry entry = (HeromeImageEntry)this.Element;
			var editText = this.Control;
			if (!string.IsNullOrEmpty(entry.Image)) {
				var drawable = GetDrawable(entry, entry.Image);
				drawable.OffsetY = CalculateDesiredDrawableOffsetY(editText, drawable, 10);
				editText.SetCompoundDrawablesWithIntrinsicBounds(drawable, null, null, null);
			}
			editText.CompoundDrawablePadding = 40;
			editText.SetPadding(
				editText.PaddingLeft, 
				editText.PaddingTop + 20, 
				editText.PaddingRight, 
				editText.PaddingBottom
			);
			editText.Background.SetColorFilter(entry.LineColor.ToAndroid(), PorterDuff.Mode.SrcAtop);
		}

		private DisplacedBitmapDrawable GetDrawable(HeromeImageEntry entry, string imagePath)
		{
			int resID = Resources.GetIdentifier(imagePath, "drawable", this.Context.PackageName);
			var drawable = ContextCompat.GetDrawable(this.Context, resID);
			var bitmap = Bitmap.CreateScaledBitmap(
				((BitmapDrawable)drawable).Bitmap, 
				entry.ImageWidth * 2, 
				entry.ImageHeight * 2, 
				true
			);
			return new DisplacedBitmapDrawable(Resources, bitmap);
		}

		private int CalculateDesiredDrawableOffsetY(Android.Views.View view, Drawable drawable, int offsetFromBottom)
		{
			Rect viewRect = new Rect();
			view.GetDrawingRect(viewRect);
			var viewBottom = viewRect.Bottom;
			var drawableBottom = drawable.Bounds.Bottom;
			var desiredDrawableBottom = viewBottom - offsetFromBottom;
			return desiredDrawableBottom - drawableBottom;
		}
	}
}