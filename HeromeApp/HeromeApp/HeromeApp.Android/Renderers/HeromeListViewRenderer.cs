using Android.Content;
using Android.Views;
using HeromeApp.Controls;
using HeromeApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(HeromeListView), typeof(HeromeListViewRenderer))]
namespace HeromeApp.Droid.Renderers
{
	public class HeromeListViewRenderer : ListViewRenderer
	{
		#region Private fields
		private int _position;
		#endregion

		#region Constructors
		public HeromeListViewRenderer(Context context) : base(context)
		{
		}
		#endregion

		#region Renderer overrides
		protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
		{
			base.OnElementChanged(e);
			if (e.OldElement != null || e.NewElement == null)
				return;
			var listView = e.NewElement as HeromeListView;
			Control.VerticalScrollBarEnabled = listView.ScrollingEnabled;
		}

		public override bool DispatchTouchEvent(MotionEvent e)
		{
			if (e.ActionMasked == MotionEventActions.Down)
			{
				// Record the position the list the touch landed on
				_position = this.Control.PointToPosition((int)e.GetX(), (int)e.GetY());
				return base.DispatchTouchEvent(e);
			}

			if (e.ActionMasked == MotionEventActions.Move)
			{
				// Ignore move eents
				return true;
			}

			if (e.ActionMasked == MotionEventActions.Up)
			{
				// Check if we are still within the same view
				if (this.Control.PointToPosition((int)e.GetX(), (int)e.GetY()) == _position)
				{
					base.DispatchTouchEvent(e);
				}
				else
				{
					// Clear pressed state, cancel the action
					Pressed = false;
					Invalidate();
					return true;
				}
			}

			return base.DispatchTouchEvent(e);
		}
		#endregion
	}
}