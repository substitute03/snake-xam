using SnakeMobile.Enums;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SnakeMobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenuPage : ContentPage
    {
        public MainMenuPage()
        {
            InitializeComponent();

            ControlSchemePicker.ItemsSource = Enum.GetValues(typeof(ControlScheme));
            ControlSchemePicker.SelectedIndex = 0;
        }

        private void PlayButtonButton_Clicked(object sender, EventArgs e)
        {
            if (ControlSchemePicker.SelectedItem != null)
            {
                string selectedPickerItem = ControlSchemePicker.SelectedItem?.ToString();

                ControlScheme selectedControlScheme;
                Enum.TryParse(selectedPickerItem, out selectedControlScheme);

                Navigation.PushModalAsync(new GamePage(selectedControlScheme));
            }
        }
    }
}