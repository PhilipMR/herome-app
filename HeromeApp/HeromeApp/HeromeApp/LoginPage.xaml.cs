using System;
using Xamarin.Forms;

namespace HeromeApp
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

			this.imgFacebookIcon.GestureRecognizers.Add(new TapGestureRecognizer
			{
				Command = new Command(() => LoginFacebook_Clicked()),
				NumberOfTapsRequired = 1
			});
			this.imgTwitterIcon.GestureRecognizers.Add(new TapGestureRecognizer
			{
				Command = new Command(() => LoginTwitter_Clicked()),
				NumberOfTapsRequired = 1
			});
		}

		private void LoginButton_Clicked(object sender, EventArgs e)
        {
			Console.WriteLine("Login button clicked!");
			Navigation.PushAsync(new HomePage());
		}

		private void RegisterButton_Clicked(object sender, EventArgs e)
		{
			Console.WriteLine("Register button clicked!");
			Navigation.PushAsync(new HomePage());
		}

		private void ForgotPassword_Clicked(object sender, EventArgs e)
		{
			Console.WriteLine("Forgot password button clicked!");
		}

		private void LoginFacebook_Clicked()
		{
			Console.WriteLine("Login with facebook image clicked!");
		}

		private void LoginTwitter_Clicked()
		{
			Console.WriteLine("Login with twitter image clicked!");
		}

		private void SkipLogin_Clicked(object sender, EventArgs e)
		{
			Navigation.PushAsync(new HomePage());
		}
	}
}
