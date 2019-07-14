using FormsControls.Base;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HeromeApp.Pages
{
    public partial class LoginPage : AnimationPage
    {
        private enum Mode
        {
            Login,
            Reset
        }
        private Mode _mode = Mode.Login;

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



        private async Task SwitchMode(Mode mode)
        {
            if (mode == _mode) return;
            if (mode == Mode.Login)
            {
                await Task.WhenAll(new[]
                {
                    layoutLogin.FadeTo(1),
                    layoutReset.FadeTo(0)
                });
                layoutLogin.IsEnabled = true;
                layoutReset.IsEnabled = false;
                _mode = Mode.Login;
            }
            else if (mode == Mode.Reset)
            {
                await Task.WhenAll(new[]
                {
                    layoutLogin.FadeTo(0),
                    layoutReset.FadeTo(1)
                });
                layoutLogin.IsEnabled = false;
                layoutReset.IsEnabled = true;
                _mode = Mode.Reset;
            }
            _mode = mode;
        }


        #region Control events
        private void LoginButton_Clicked(object sender, EventArgs e)
        {
			Console.WriteLine("Login button clicked!");

            var slideAnimation = new SlidePageAnimation() { Duration = AnimationDuration.Short, Subtype = AnimationSubtype.FromRight };
            Navigation.PushAsync(new HomePage() { PageAnimation = slideAnimation });


            // NOTE: Should be MoveToPageAndResetNavigation(new HomePage()) like the other buttons.
            //		 We don't clear the navigation stack here right now now because it's useful for debugging.
            //Navigation.PushAsync(new HomePage());
		}

		private void RegisterButton_Clicked(object sender, EventArgs e)
		{
			Console.WriteLine("Register button clicked!");
			MoveToPageAndResetNavigation(new HomePage());
		}

		private void ForgotPassword_Clicked(object sender, EventArgs e)
		{
            SwitchMode(Mode.Reset);
		}

        protected override bool OnBackButtonPressed()
        {
            if (_mode == Mode.Reset)
            {
                SwitchMode(Mode.Login);
                return true;
            }
            return base.OnBackButtonPressed();
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
