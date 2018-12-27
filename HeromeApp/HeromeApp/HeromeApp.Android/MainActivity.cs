using Android.App;
using Android.Content.PM;
using Android.Views;
using Android.OS;
using Xamarin.Facebook;
using Xamarin.Facebook.AppEvents;

namespace HeromeApp.Droid
{
    [Activity(
		Label = "HeromeApp",
		Icon = "@mipmap/icon", 
		Theme = "@style/MainTheme",
		MainLauncher = true, 
		ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, 
		ScreenOrientation = ScreenOrientation.Portrait
	)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(savedInstanceState);

			FacebookSdk.SdkInitialize(this.ApplicationContext);
			//AppEventsLogger.ActivateApp(this);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
    }
}