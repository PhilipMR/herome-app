using HeromeApp.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HeromeApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionairePage : ContentPage
    {
        private bool _isFading = false;

        public QuestionairePage(HeromeQuestionaireModel model, string footer)
        {
            InitializeComponent();
            this.questionaire.BindingContext = model;
            this.lblFooter.Text = footer;
        }

        private async void GoBack(HeromeQuestionaireModel model)
        {
            _isFading = true;
            await this.questionaire.FadeTo(0);
            model.Previous();
            await this.questionaire.FadeTo(1);
            _isFading = false;
        }

        protected override bool OnBackButtonPressed()
        {
            if (_isFading)
            {
                return true;
            }
            var model = this.questionaire.BindingContext as HeromeQuestionaireModel;
            if (model.HasPrevious())
            {
                GoBack(model);
                return true;
            }
            else
            {
                return base.OnBackButtonPressed();
            }
        }
    }
}