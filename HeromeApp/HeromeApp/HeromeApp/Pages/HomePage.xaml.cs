using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HeromeApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		#region Constructors
		public HomePage ()
		{
			InitializeComponent ();
			this.imgNailsPanel.GestureRecognizers.Add(new TapGestureRecognizer
			{
				Command = new Command(() => NailsPanel_Clicked()),
				NumberOfTapsRequired = 1
			});
			this.imgHandsPanel.GestureRecognizers.Add(new TapGestureRecognizer
			{
				Command = new Command(() => HandsPanel_Clicked()),
				NumberOfTapsRequired = 1
			});
			this.imgCuticlesPanel.GestureRecognizers.Add(new TapGestureRecognizer
			{
				Command = new Command(() => CuticlesPanel_Clicked()),
				NumberOfTapsRequired = 1
			});
			this.imgPolishPanel.GestureRecognizers.Add(new TapGestureRecognizer
			{
				Command = new Command(() => PolishPanel_Clicked()),
				NumberOfTapsRequired = 1
			});
		}
		#endregion

		#region Control events
		private void NailsPanel_Clicked()
		{
			Navigation.PushAsync(new NailsPage());
		}

		private void HandsPanel_Clicked()
		{
			Navigation.PushAsync(new HandsPage());
		}

		private void CuticlesPanel_Clicked()
		{
			Navigation.PushAsync(new CuticlesPage());
		}

		private void PolishPanel_Clicked()
		{
			Navigation.PushAsync(new PolishPage());
		}
		#endregion
	}
}