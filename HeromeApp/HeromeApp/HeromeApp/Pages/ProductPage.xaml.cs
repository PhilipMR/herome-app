using FormsControls.Base;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HeromeApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProductPage : AnimationPage
	{
		public ProductPage ()
		{
			InitializeComponent ();

            this.imgProduct.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => Device.OpenUri(new System.Uri("https://www.herome.com/online-shop/cuticle-care/cuticle-night-repair/"))),
                NumberOfTapsRequired = 1
            });
        }
	}
}