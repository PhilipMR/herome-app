using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Support.V4.Content;
using HeromeApp;
using HeromeApp.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ImageEntry), typeof(ImageEntryRenderer))]
namespace HeromeApp.Droid
{
    class ImageEntryRenderer : EntryRenderer
    {
		private ImageEntry _element;

		public ImageEntryRenderer(Context context) : base(context)
        {
        }

		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);
			if (e.OldElement != null || e.NewElement == null)
				return;
			_element = (ImageEntry)this.Element;

			var editText = this.Control;
			if (!string.IsNullOrEmpty(_element.Image)) {
				editText.SetCompoundDrawablesWithIntrinsicBounds(GetDrawable(_element.Image), null, null, null);
			}
			editText.CompoundDrawablePadding = 25;
			Control.Background.SetColorFilter(_element.LineColor.ToAndroid(), PorterDuff.Mode.SrcAtop);
		}

		private BitmapDrawable GetDrawable(string imageEntryImage)
		{
			int resID = Resources.GetIdentifier(imageEntryImage, "drawable", this.Context.PackageName);
			var drawable = ContextCompat.GetDrawable(this.Context, resID);
			var bitmap = Bitmap.CreateScaledBitmap(
				((BitmapDrawable)drawable).Bitmap, 
				_element.ImageWidth * 2, 
				_element.ImageHeight * 2, 
				true
			);
			return new BitmapDrawable(Resources, bitmap);
		}
	}
}