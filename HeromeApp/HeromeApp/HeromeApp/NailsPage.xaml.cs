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
					Options = new List<string>
					{
						"vastzittende nagelriemen",
						"droge nagelriemen",
						"nagelriemvelletjes"
					}
				},
				new Question()
				{
					Caption = "En ik heb ook nog eens last van...",
					Options = new List<string>
					{
						"het weer",
						"iedereen",
						"alles",
						"niks"
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

			this.BindingContext = new QuestionaireViewModel(questions, results);
		}
	}
}