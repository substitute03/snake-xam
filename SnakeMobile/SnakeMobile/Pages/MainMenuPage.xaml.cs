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
    public partial class MainMenuPage : ContentPage
    {
        public List<String> Difficulties 
        { 
            get => new List<string> 
            {
                "Normal", "Hard", "Insanity" 
            };
        }

        public MainMenuPage()
        {
            InitializeComponent();

            DifficultyPicker.ItemsSource = Difficulties;
            DifficultyPicker.SelectedIndex = 0;
        }

        private void PlayButtonButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new GamePage());
        }
    }
}