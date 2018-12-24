using HeromeApp.Models;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static HeromeApp.Models.QuestionaireViewModel;

namespace HeromeApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NailsPage : ContentPage
	{
		public NailsPage()
		{
			InitializeComponent();

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
						0
					},
					Url = "https://herome.nl/xyz"
				}
			};

			lvAnswers.ItemTapped += LvAnswers_ItemTapped;
			this.BindingContext = new QuestionaireViewModel(questions, results);
		}

		private void LvAnswers_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			QuestionaireViewModel model = this.BindingContext as QuestionaireViewModel;
			model.Next();
		}
	}
}