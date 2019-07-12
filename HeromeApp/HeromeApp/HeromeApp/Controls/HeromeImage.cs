using Xamarin.Forms;

namespace HeromeApp.Controls
{
    public class HeromeImage : Image
    {
		#region Constructors
		public HeromeImage()
		{
			// NOTE: In order to draw rounded corners it is required to have a background color set
			this.BackgroundColor = Color.Transparent;
		}
		#endregion

		#region Bindable properties
		public static readonly BindableProperty CornerRadiusProperty =
			BindableProperty.Create(nameof(CornerRadius), typeof(double), typeof(HeromeImage), 0.0);

		public double CornerRadius
		{
			get { return (double)GetValue(CornerRadiusProperty); }
			set { SetValue(CornerRadiusProperty, value); }
		}
		#endregion
	}
}
