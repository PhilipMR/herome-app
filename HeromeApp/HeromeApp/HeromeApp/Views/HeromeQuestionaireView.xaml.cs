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
			var selectedAnswer = e.SelectedItem as HeromeQuestionaireModel.Answer;
			// Wait 1 second...
			await Task.Delay(TimeSpan.FromSeconds(0.1));
			// Go to next question
			var model = this.BindingContext as HeromeQuestionaireModel;
			model.Next();
		}
	}
}