using HeromeApp.Models;
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
			lvAnswers.ItemSelected += LvAnswers_ItemSelected;
		}

		private async void LvAnswers_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var model = this.BindingContext as HeromeQuestionaireModel;
			var selectedAnswer = e.SelectedItem as HeromeQuestionaireModel.Answer;
			if (model.HasNext())
			{
				//await Task.Delay(TimeSpan.FromSeconds(0.05));
				model.Next();
			} else
			{
				await Navigation.PushAsync(new ProductPage());
			}
		}
	}
}