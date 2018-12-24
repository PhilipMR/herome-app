using System;
using Xamarin.Forms;

namespace HeromeApp.Controls
{
    public class HeromeAnswerBox : Grid
    {
		#region Constants
		private static readonly Color BackgroundColorUnselected = Color.FromHex("#093268");
		private static readonly Color BackgroundColorSelected = Color.FromHex("#6fb9d6");
		#endregion


		#region Bindable properties
		public static readonly BindableProperty CaptionProperty =
			BindableProperty.Create(nameof(Caption), typeof(string), typeof(HeromeAnswerBox), string.Empty);

		public string Caption
		{
			get { return (string)GetValue(CaptionProperty); }
			set { SetValue(CaptionProperty, value); _caption.Text = value; }
		}
		#endregion


		#region Private fields
		private readonly HeromeBoxView _background;
		private readonly Image _checkBox;
		private Label _caption;
		private readonly StackLayout _itemStack;
		#endregion


		#region Constructors
		public HeromeAnswerBox()
		{
			this.ColumnDefinitions = new ColumnDefinitionCollection
			{
				new ColumnDefinition() { Width = GridLength.Star }
			};
			this.RowDefinitions = new RowDefinitionCollection
			{
				new RowDefinition() { Height = GridLength.Star }
			};

			// The background layer.
			this._background = new HeromeBoxView
			{
				CornerRadius = 5,
				Color = BackgroundColorUnselected
			};
			this.Children.Add(_background, 0, 0);


			// The front layer (items stack layout).
			this._checkBox = new Image
			{
				Source = "answer_blank",
				Aspect = Aspect.AspectFill,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
			};
			
			//this.GestureRecognizers.Add(new TapGestureRecognizer
			//{
			//	Command = new Command(() => 
			//	{
			//		this._checkBox.Source = "answer_checked";
			//		this._background.Color = BackgroundColorSelected;
			//	}),
			//	NumberOfTapsRequired = 1
			//});
			
			this._caption = new Label
			{
				Text = this.Caption,
				TextColor = Color.White,
				FontFamily = "OpenSans-Regular",
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.CenterAndExpand,
			};
			this._itemStack = new StackLayout
			{	 
				Padding = new Thickness(5),
				Orientation = StackOrientation.Horizontal,
				Children =
				{
					_checkBox,
					_caption
				},
			};
			this.Children.Add(_itemStack, 0, 0);
		}
		#endregion
	}
}
