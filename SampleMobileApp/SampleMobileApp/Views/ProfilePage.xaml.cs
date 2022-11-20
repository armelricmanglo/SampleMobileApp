using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SampleMobileApp.Views
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            // Launch the specified URL in the system browser.
            await Launcher.OpenAsync("https://www.facebook.com");
        }
    }
}