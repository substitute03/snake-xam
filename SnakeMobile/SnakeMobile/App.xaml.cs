using SnakeMobile.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SnakeMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Doing async programming, UI stuff should apparently be handled on the main thread. I think this would be on the main thread anyway and not necessarily have to wrap it but doing navigation later, it would complain if you don't wrap future ones in this.
            Device.BeginInvokeOnMainThread(() =>
            {
                MainPage = new NavigationPage(new MainMenuPage());
            });          
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
