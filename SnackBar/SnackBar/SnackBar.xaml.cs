using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SnackBar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SnackBar : TemplatedView
	{
        #region Binding Properties
        public static readonly BindableProperty BtnTextColorProperty = BindableProperty.Create(nameof(BtnTextColor), typeof(Color), typeof(SnackBar), default(Color));
        public Color BtnTextColor
        {
            get => (Color)GetValue(BtnTextColorProperty);
            set => SetValue(BtnTextColorProperty, value);
        }

        public static readonly BindableProperty MessageProperty = BindableProperty.Create(nameof(Message), typeof(string), typeof(SnackBar), default(string));
        public string Message
        {
            get => (string)GetValue(MessageProperty);
            set => SetValue(MessageProperty, value);
        }

        public static readonly BindableProperty CloseBtnTextProperty = BindableProperty.Create(nameof(CloseBtnText), typeof(string), typeof(SnackBar), default(string));
        public string CloseBtnText
        {
            get => (string)GetValue(CloseBtnTextProperty);
            set => SetValue(CloseBtnTextProperty, value);
        }

        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSize), typeof(float), typeof(SnackBar), default(float));
        public float FontSize
        {
            get => (float)GetValue(FontSizeProperty); 
            set => SetValue(FontSizeProperty, value); 
        }

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(SnackBar), Color.White);
        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty); 
            set => SetValue(TextColorProperty, value); 
        }

        public static readonly BindableProperty CloseBtnBackgroundColorProperty = BindableProperty.Create(nameof(CloseBtnBackgroundColor), typeof(Color), typeof(SnackBar), Color.Transparent);
        public Color CloseBtnBackgroundColor
        {
            get => (Color)GetValue(CloseBtnBackgroundColorProperty); 
            set => SetValue(CloseBtnBackgroundColorProperty, value); 
        }

        public uint AnimationDuration { get; set; }

        public static readonly BindableProperty IsOpenProperty = BindableProperty.Create(nameof(IsOpen), typeof(bool), typeof(SnackBar), false, propertyChanged: IsOpenChanged);
        public bool IsOpen
        {
            get => (bool)GetValue(IsOpenProperty);
            set => SetValue(IsOpenProperty, value);
        }

        private static void IsOpenChanged(BindableObject bindable, object oldValue, object newValue)
        {
            bool isOpen;
            if (!(bindable is null) && !(newValue is null))
            {
                SnackBar control = (SnackBar)bindable;
                isOpen = (bool)newValue;
                if (control.IsOpen == false)
                {
                    control.Close();
                }
                else
                {
                    control.Open(control.Message);
                }
            }
        }

        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(SnackBar), default(string));
        public string FontFamily
        {
            get => (string)GetValue(FontFamilyProperty); 
            set => SetValue(FontFamilyProperty, value); 
        }
        #endregion

        public SnackBar ()
		{
            IsVisible = false;
            AnimationDuration = 150;
			InitializeComponent ();
		}

        public async void Close()
        {
            await this.TranslateTo(0, 50, AnimationDuration);
            Message = string.Empty;
            IsOpen = IsVisible = false;
        }

        public async void Open(string message)
        {
            IsVisible = true;
            Message = message;
            await this.TranslateTo(0, 0, AnimationDuration);
        }

        private void BtnCloseClicked(object sender, EventArgs e)
        {
            Close();
        }
    }
}