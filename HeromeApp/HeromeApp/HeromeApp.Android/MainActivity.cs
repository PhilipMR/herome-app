using Android.App;
using Android.Content.PM;
using Android.Views;
using Android.OS;
using Xamarin.Facebook;
using Xamarin.Facebook.AppEvents;
using Android.Support.V4.Content;
using Android.Runtime;

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
        private readonly int CameraRequestCode = 50;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            FacebookSdk.SdkInitialize(this.ApplicationContext);
            //AppEventsLogger.ActivateApp(this);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            if (ContextCompat.CheckSelfPermission(this, Android.Manifest.Permission.Camera) != Permission.Granted)
            {
                RequestPermissions(new string[] { Android.Manifest.Permission.Camera }, CameraRequestCode);
            }
            else
            {
                LoadApplication(new App());
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            if (requestCode == CameraRequestCode)
            {
                LoadApplication(new App());
            }
        }
    }
}