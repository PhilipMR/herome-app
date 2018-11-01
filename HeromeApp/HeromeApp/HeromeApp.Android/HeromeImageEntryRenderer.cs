using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Support.V4.Content;
using HeromeApp;
using HeromeApp.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(HeromeImageEntry), typeof(HeromeImageEntryRenderer))]
namespace HeromeApp.Droid
{
    class HeromeImageEntryRenderer : EntryRenderer
    {
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
				editText.SetCompoundDrawablesWithIntrinsicBounds(GetDrawable(entry, entry.Image), null, null, null);
			}
			editText.CompoundDrawablePadding = 25;
			editText.SetPadding(12, 60, 12, 33);
			editText.Background.SetColorFilter(entry.LineColor.ToAndroid(), PorterDuff.Mode.SrcAtop);
		}

		private BitmapDrawable GetDrawable(HeromeImageEntry entry, string imagePath)
		{
			int resID = Resources.GetIdentifier(imagePath, "drawable", this.Context.PackageName);
			var drawable = ContextCompat.GetDrawable(this.Context, resID);
			var bitmap = Bitmap.CreateScaledBitmap(
				((BitmapDrawable)drawable).Bitmap, 
				entry.ImageWidth * 2, 
				entry.ImageHeight * 2, 
				true
			);
			return new BitmapDrawable(Resources, bitmap);
		}
	}
}