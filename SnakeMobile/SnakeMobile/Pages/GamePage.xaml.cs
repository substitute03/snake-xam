using SnakeMobile.Model;
using SnakeMobile.ValueConverters;
using SnakeMobile.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SnakeMobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamePage : ContentPage
    {
        GameViewModel vm;

        public GamePage()
        {
            vm = new GameViewModel();
            InitializeComponent();
            BindingContext = vm;
            RenderGameBoard();
        }

        private void RenderGameBoard()
        {
            for (int i = 1; i <= vm.GameBoardSize; i++)
            {
                GameBoardGrid.RowDefinitions.Add(new RowDefinition
                {
                    Height = 35,
                });
                GameBoardGrid.ColumnDefinitions.Add(new ColumnDefinition
                {
                    Width = new GridLength(1, GridUnitType.Star)
                });
            }

            for (int x = 0; x <= vm.GameBoardSize - 1; x++)
            {
                for (int y = 0; y <= vm.GameBoardSize - 1; y++)
                {
                    var boxView = new BoxView();

                    boxView.SetBinding(BoxView.ColorProperty, nameof(
                        Model.Cell.Color), BindingMode.OneWay, null);

                    int cellIndex = vm.Game.GameBoard.GetCellIndex(x, y);
                    boxView.BindingContext = vm.Game.GameBoard.Cells[cellIndex];

                    GameBoardGrid.Children.Add(boxView, y, x);
                }
            }
        }

        private async Task GameLoop()
        {
            await vm.Game.StartGameLoop();

            HandleGameOver();
        }

        private void GamePage_OnSwipedUp(object sender, SwipedEventArgs e)
        {
            vm.Game.GameBoard.Snake.ChangeDirection(Direction.Up);
        }

        private void GamePage_OnSwipedDown(object sender, SwipedEventArgs e)
        {
            vm.Game.GameBoard.Snake.ChangeDirection(Direction.Down);
        }

        private void GamePage_OnSwipedLeft(object sender, SwipedEventArgs e)
        {
            vm.Game.GameBoard.Snake.ChangeDirection(Direction.Left);
        }

        private void GamePage_OnSwipedRight(object sender, SwipedEventArgs e)
        {
            vm.Game.GameBoard.Snake.ChangeDirection(Direction.Right);
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Task.Run(async () => await GameLoop());
        }

        private void HandleGameOver()
        {
            
            Device.BeginInvokeOnMainThread(() =>
            {
                // Pop the GamePage
                Navigation.PopModalAsync();
                Navigation.PushModalAsync(new GameResultsPage(vm.Game.Score, vm.Game.Duration));
            });
            
        }
    }
}