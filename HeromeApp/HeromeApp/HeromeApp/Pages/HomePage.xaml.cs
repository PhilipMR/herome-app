using HeromeApp.Models;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static HeromeApp.Models.HeromeQuestionaireModel;

namespace HeromeApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		#region Constructors
		public HomePage ()
		{
			InitializeComponent ();
			this.imgNailsPanel.GestureRecognizers.Add(new TapGestureRecognizer
			{
				Command = new Command(() => NailsPanel_Clicked()),
				NumberOfTapsRequired = 1
			});
			this.imgHandsPanel.GestureRecognizers.Add(new TapGestureRecognizer
			{
				Command = new Command(() => HandsPanel_Clicked()),
				NumberOfTapsRequired = 1
			});
			this.imgCuticlesPanel.GestureRecognizers.Add(new TapGestureRecognizer
			{
				Command = new Command(() => CuticlesPanel_Clicked()),
				NumberOfTapsRequired = 1
			});
			this.imgPolishPanel.GestureRecognizers.Add(new TapGestureRecognizer
			{
				Command = new Command(() => PolishPanel_Clicked()),
				NumberOfTapsRequired = 1
			});
		}
		#endregion

		#region Control events
        private HeromeQuestionaireModel CreateDummyQuestionaire()
        {
            var questions = new List<Question>
            {
                new Question()
                {
                    Caption = "Ik heb last van...",
                    Answers = new List<Answer>
                    {
                        new Answer { Caption = "vastzittende nagelriemen" },
                        new Answer { Caption = "droge nagelriemen" },
                        new Answer { Caption = "nagelriemvelletjes" }
                    }
                },
                new Question()
                {
                    Caption = "En ik heb ook nog eens last van...",
                    Answers = new List<Answer>
                    {
                        new Answer { Caption = "het weer" },
                        new Answer { Caption = "alles" },
                        new Answer { Caption = "iedereen" }
                    }
                }
            };

            var results = new List<Result>
            {
                new Result()
                {
                    Options = new List<int>
                    {
                        0, 0
                    },
                    Url = "https://herome.nl/xyz"
                }
            };
            return new HeromeQuestionaireModel(questions, results);
        }

		private void NailsPanel_Clicked()
		{
            var model = CreateDummyQuestionaire();
            var page = new QuestionairePage(model, "Meer info over Nageladvies");
            Navigation.PushAsync(page);
		}

		private void HandsPanel_Clicked()
		{
            var model = CreateDummyQuestionaire();
            var page = new QuestionairePage(model, "Meer info over Handadvies");
            Navigation.PushAsync(page);
        }

		private void CuticlesPanel_Clicked()
        {
            var model = CreateDummyQuestionaire();
            var page = new QuestionairePage(model, "Meer info over Nagelriemadvies");
            Navigation.PushAsync(page);
        }

		private void PolishPanel_Clicked()
        {
            var model = CreateDummyQuestionaire();
            var page = new QuestionairePage(model, "Meer info over Nagellakdvies");
            Navigation.PushAsync(page);
        }
		#endregion
	}
}