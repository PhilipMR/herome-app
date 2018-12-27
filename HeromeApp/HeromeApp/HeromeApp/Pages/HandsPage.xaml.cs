using HeromeApp.Models;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static HeromeApp.Models.HeromeQuestionaireModel;

namespace HeromeApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HandsPage : ContentPage
	{
		public HandsPage ()
		{
			InitializeComponent ();

			List<Question> questions = new List<Question>
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

			List<Result> results = new List<Result>
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
			this.questionaire.BindingContext = new HeromeQuestionaireModel(questions, results, "Meer info over Handen");
		}
	}
}