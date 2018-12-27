using HeromeApp.Models;
using HeromeApp.Pages;
using System;
using System.Threading.Tasks;
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
				await Task.Delay(TimeSpan.FromSeconds(0.1));
				model.Next();
			}
			else
			{
				await Navigation.PushAsync(new ProductPage());
			}
			lvAnswers.SelectedItem = null;
		}
	}
}