using Android.Content;
using HeromeApp.Controls;
using HeromeApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(HeromeButton), typeof(HeromeButtonRenderer))]
namespace HeromeApp.Droid.Renderers
{
	class HeromeButtonRenderer : ButtonRenderer
	{
		public HeromeButtonRenderer(Context context) : base(context)
		{
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
		{
			base.OnElementChanged(e);
			Control.SetPadding(0, 0, 0, 0);
		}
	}
}