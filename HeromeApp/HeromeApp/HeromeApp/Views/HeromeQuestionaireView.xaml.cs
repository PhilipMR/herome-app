using FormsControls.Base;
using HeromeApp.Models;
using HeromeApp.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HeromeApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HeromeQuestionaireView : ContentView
	{
		public HeromeQuestionaireView()
		{
			InitializeComponent ();
			lvAnswers.ItemTapped += LvAnswers_ItemTapped;
        }     

		private async void LvAnswers_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			var model = this.BindingContext as HeromeQuestionaireModel;
			var selectedAnswer = e.Item as HeromeQuestionaireModel.Answer;
			if (model.HasNext())
			{
                await this.FadeTo(0);
				model.Next();
                await this.FadeTo(1);
			}
			else
			{
                var fadeAnimation = new FadePageAnimation() { Duration = AnimationDuration.Short };
                await Navigation.PushAsync(new ProductPage() { PageAnimation = fadeAnimation });
			}
			lvAnswers.SelectedItem = null;
		}
	}
}