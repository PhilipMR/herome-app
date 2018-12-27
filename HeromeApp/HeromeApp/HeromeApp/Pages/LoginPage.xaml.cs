using System;
using System.Linq;
using Xamarin.Forms;

namespace HeromeApp.Pages
{
    public partial class LoginPage : ContentPage
    {
		#region Constructors
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
		#endregion

		#region Control events
		private void LoginButton_Clicked(object sender, EventArgs e)
        {
			Console.WriteLine("Login button clicked!");

			// NOTE: Should be MoveToPageAndResetNavigation(new HomePage()) like the other buttons.
			//		 We don't clear the navigation stack here right now now because it's useful for debugging.
			Navigation.PushAsync(new HomePage());
		}

		private void RegisterButton_Clicked(object sender, EventArgs e)
		{
			Console.WriteLine("Register button clicked!");
			MoveToPageAndResetNavigation(new HomePage());
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
			MoveToPageAndResetNavigation(new HomePage());
		}
		#endregion

		#region Private methods
		private void MoveToPageAndResetNavigation(Page nextPage)
		{
			Navigation.PushAsync(nextPage);
			var existingPages = Navigation.NavigationStack.ToList();
			foreach (var page in existingPages)
			{
				if (page == nextPage)
					continue;
				Navigation.RemovePage(page);
			}
		}
		#endregion
	}
}
