﻿using Xamarin.Forms;

namespace HeromeApp.Controls
{
    public class HeromeImageEntry : Entry
    {
		#region Bindable properties
		public static readonly BindableProperty ImageProperty =
			BindableProperty.Create(nameof(Image), typeof(string), typeof(HeromeImageEntry), string.Empty);

        public static readonly BindableProperty ImageWidthProperty =
            BindableProperty.Create(nameof(ImageWidth), typeof(int), typeof(HeromeImageEntry), 40);

        public static readonly BindableProperty ImageHeightProperty =
			BindableProperty.Create(nameof(ImageHeight), typeof(int), typeof(HeromeImageEntry), 40);

        public static readonly BindableProperty ImageSpacingProperty =
            BindableProperty.Create(nameof(ImageSpacing), typeof(int), typeof(HeromeImageEntry), 0);

        public static readonly BindableProperty LineColorProperty =
        BindableProperty.Create(nameof(LineColor), typeof(Xamarin.Forms.Color), typeof(HeromeImageEntry), Color.White);

        public string Image
        {
            get { return (string)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        public int ImageWidth
        {
            get { return (int)GetValue(ImageWidthProperty); }
            set { SetValue(ImageWidthProperty, value); }
        }

        public int ImageHeight
        {
            get { return (int)GetValue(ImageHeightProperty); }
            set { SetValue(ImageHeightProperty, value); }
        }

        public int ImageSpacing
        {
            get { return (int)GetValue(ImageSpacingProperty); }
            set { SetValue(ImageSpacingProperty, value); }
        }

        public Color LineColor
		{
			get { return (Color)GetValue(LineColorProperty); }
			set { SetValue(LineColorProperty, value); }
		}
		#endregion
	}
}
