using Xamarin.Forms;

namespace HeromeApp.Controls
{
    public class HeromeViewCell : ViewCell
    {
		#region Bindable properties
		public static readonly BindableProperty SelectedBackgroundColorProperty =
			BindableProperty.Create(nameof(SelectedBackgroundColor), typeof(Color), typeof(HeromeViewCell), Color.Default);

		public Color SelectedBackgroundColor
		{
			get { return (Color)GetValue(SelectedBackgroundColorProperty); }
			set { SetValue(SelectedBackgroundColorProperty, value); }
		}
		#endregion
	}
}
