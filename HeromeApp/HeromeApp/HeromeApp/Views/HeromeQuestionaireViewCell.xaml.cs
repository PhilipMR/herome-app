using System.Runtime.CompilerServices;
using HeromeApp.Controls;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HeromeApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HeromeQuestionaireViewCell : HeromeViewCell
	{
		#region Constants
		private static readonly Color BackgroundColorUnselected = Color.FromHex("#093268");
		private static readonly Color BackgroundColorSelected = Color.FromHex("#6fb9d6");

		private static readonly string AnswerImageUnchecked = "answer_blank";
		private static readonly string AnswerImageChecked = "answer_checked";
		#endregion

		#region Bindable properties
		public static readonly BindableProperty CaptionProperty =
			BindableProperty.Create(nameof(Caption), typeof(string), typeof(HeromeQuestionaireViewCell), string.Empty);

		public string Caption
		{
			get { return (string)GetValue(CaptionProperty); }
			set { SetValue(CaptionProperty, value); }
		}
		#endregion

		#region Private fields
		private bool _isSelected;
		#endregion

		#region Constructors
		public HeromeQuestionaireViewCell ()
		{
			InitializeComponent ();
			boxBackground.BackgroundColor = BackgroundColorUnselected;
		}
		#endregion

		#region HeromeViewCell overrides
		protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			base.OnPropertyChanged(propertyName);
			if(propertyName == "IsSelected")
			{
				_isSelected = !_isSelected;
				Color backgroundColor = _isSelected ? BackgroundColorSelected : BackgroundColorUnselected;
				boxBackground.BackgroundColor = backgroundColor;

				string answerImgSource = _isSelected ? AnswerImageChecked : AnswerImageUnchecked;
				imgAnswer.Source = answerImgSource;
			}
		}
		#endregion
	}
}