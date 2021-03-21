using SnakeMobile.Model;
using SnakeMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SnakeMobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameResultsPage : ContentPage
    {
        private readonly GameResultsViewModel vm;

        public GameResultsPage(GameResults results)
        {
            vm = new GameResultsViewModel(results);
            InitializeComponent();
            BindingContext = vm;
        }

        private void MainMenuButton_OnClicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Navigation.PopModalAsync();
            });
        }
    }
}