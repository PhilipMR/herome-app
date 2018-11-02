using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Support.V4.Content;
using Android.Util;
using HeromeApp.Controls;
using HeromeApp.Droid.Renderers;
using System;
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
			if (e.OldElement != null || e.NewElement == null)
				return;
			Control.SetPadding(0, 0, 0, 0);
		}
		#endregion
	}
}