using Xamarin.Forms;

namespace HeromeApp.Controls
{
    public class HeromeListView : ListView
    {
		#region Bindable properties
		public static readonly BindableProperty ScrollingEnabledProperty =
			BindableProperty.Create(nameof(ScrollingEnabled), typeof(bool), typeof(HeromeListView), false);

		public bool ScrollingEnabled
		{
			get { return (bool)GetValue(ScrollingEnabledProperty); }
			set { SetValue(ScrollingEnabledProperty, value); }
		}
		#endregion
	}
}
