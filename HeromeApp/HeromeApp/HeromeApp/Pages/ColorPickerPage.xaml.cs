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

            this.imgSkinType.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => HandleMenuClick(MenuState.Skintype)),
                NumberOfTapsRequired = 1
            });
            this.imgNailLength.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => HandleMenuClick(MenuState.NailLength)),
                NumberOfTapsRequired = 1
            });
            this.imgNailType.GestureRecognizers.Add(new TapGestureRecognizer
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

        private Image GetMenuImage(MenuState menu)
        {
            switch (menu)
            {
                case MenuState.Skintype:    return imgSkinType;
                case MenuState.NailLength:  return imgNailLength;
                case MenuState.NailType:    return imgNailType;
                case MenuState.NailColor:   return imgNailColor;
                default:                    return null;
            }
        }

        private Frame GetMenuFrame(MenuState menu)
        {
            switch(menu)
            {
                case MenuState.Skintype:    return menuSkinType;
                case MenuState.NailLength:  return menuNailLength;
                case MenuState.NailType:    return menuNailType;
                case MenuState.NailColor:   return menuNailColor;
                default:                    return null;
            }
        }

        private async Task AnimateMoveMenuTriangle(MenuState menu)
        {
            var img = GetMenuImage(menu);
            var tx = img.X - menuArrow.X;
            await menuArrow.TranslateTo(tx, menuArrow.TranslationY);
        }

        private async Task OpenMenu(MenuState menu)
        {
            if (_menuState != MenuState.Disabled) return;

            var frame = GetMenuFrame(menu);
            await Task.WhenAll(new[] {
                menuBox.ScaleTo(1),
                AnimateMoveMenuTriangle(menu),
                menuArrow.ScaleTo(1),
                frame.FadeTo(1)
            });     
            frame.IsEnabled = true;

            menuBox.IsEnabled = true;
            _menuState = menu;
        }

        private async Task CloseMenu()
        {
            if (_menuState == MenuState.Disabled) return;

            var frame = GetMenuFrame(_menuState);
            frame.IsEnabled = false;
            menuBox.IsEnabled = false;
            await Task.WhenAll(new[] {
                menuArrow.ScaleTo(0, 50),
                menuBox.ScaleTo(0),
                frame.FadeTo(0)
            });
            _menuState = MenuState.Disabled;
        }

        private async Task ChangeMenu(MenuState menu)
        {
            var oldFrame = GetMenuFrame(_menuState);
            oldFrame.IsEnabled = false;
            var nextFrame = GetMenuFrame(menu);
            nextFrame.IsEnabled = true;

            await Task.WhenAll(new[]
            {
                AnimateMoveMenuTriangle(menu),
                oldFrame.FadeTo(0),
                nextFrame.FadeTo(1)
            });

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
                await ChangeMenu(menu);
            }
        }
	}
}