using FormsControls.Base;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HeromeApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ColorPickerPage : AnimationPage
	{
        private enum MenuState
        {
            Disabled,
            Skintype,
            NailLength,
            NailType,
            NailColor
        }
        private MenuState _menuState = MenuState.Disabled;

        public ColorPickerPage ()
		{
			InitializeComponent ();

            this.imgSkintype.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => HandleMenuClick(MenuState.Skintype)),
                NumberOfTapsRequired = 1
            });
            this.imgLength.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => HandleMenuClick(MenuState.NailLength)),
                NumberOfTapsRequired = 1
            });
            this.imgNailtype.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => HandleMenuClick(MenuState.NailType)),
                NumberOfTapsRequired = 1
            });
            this.imgNailColor.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => HandleMenuClick(MenuState.NailColor)),
                NumberOfTapsRequired = 1
            });
        }

        private async Task OpenMenu(MenuState menu)
        {
            if (_menuState != MenuState.Disabled) return;
            await menuBox.ScaleTo(1);
            menuBox.IsEnabled = true;
            _menuState = menu;
        }

        private async Task CloseMenu()
        {
            if (_menuState == MenuState.Disabled) return;
            await menuBox.ScaleTo(0);
            menuBox.IsEnabled = false;
            _menuState = MenuState.Disabled;
        }

        private async void ChangeMenu(MenuState menu)
        {
            _menuState = menu;
        }

        private async void HandleMenuClick(MenuState menu)
        {
            if (_menuState == menu)
            {
                await CloseMenu();
            } else if (_menuState == MenuState.Disabled)
            {
                await OpenMenu(menu);
            } else
            {
                ChangeMenu(menu);
            }
        }
	}
}