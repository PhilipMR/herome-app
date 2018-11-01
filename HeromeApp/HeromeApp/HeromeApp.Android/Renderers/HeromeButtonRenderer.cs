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
		#region Constructors
		public HeromeButtonRenderer(Context context) : base(context)
		{
		}
		#endregion

		#region Renderer overrides
		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
		{
			base.OnElementChanged(e);
			Control.SetPadding(0, 0, 0, 0);
		}
		#endregion
	}
}