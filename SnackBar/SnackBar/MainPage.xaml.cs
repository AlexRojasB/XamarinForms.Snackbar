using System;
using Xamarin.Forms;

namespace SnackBar
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            SnackB.Message = "I'm a snack bar... I love showing my self.";
            SnackB.IsOpen = !SnackB.IsOpen;
        }
    }
}
