using Xamarin.Forms;

namespace HeromeApp.Controls
{
    public class HeromeBoxView : BoxView
    {
		#region Bindable properties
		public static readonly BindableProperty CornerRadiusProperty = 
			BindableProperty.Create(nameof(CornerRadius), typeof(double), typeof(HeromeBoxView), 0.0);

		public double CornerRadius
		{
			get { return (double)GetValue(CornerRadiusProperty); }
			set { SetValue(CornerRadiusProperty, value); }
		}
		#endregion
	}
}
