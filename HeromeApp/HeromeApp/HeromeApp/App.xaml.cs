using FormsControls.Base;
using HeromeApp.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace HeromeApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var fadeAnimation = new FadePageAnimation() { Duration = AnimationDuration.Short };
            //MainPage = new AnimationNavigationPage(new LoginPage() { PageAnimation = fadeAnimation });
            MainPage = new AnimationNavigationPage(new ColorPickerPage() { PageAnimation = fadeAnimation });
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
