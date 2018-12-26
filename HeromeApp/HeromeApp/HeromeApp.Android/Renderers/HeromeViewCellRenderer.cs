using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Views;
using HeromeApp.Controls;
using HeromeApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(HeromeViewCell), typeof(HeromeViewCellRenderer))]
namespace HeromeApp.Droid.Renderers
{
	public class HeromeViewCellRenderer : ViewCellRenderer
	{
	}
}