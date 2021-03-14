using SnakeMobile.Model;
using SnakeMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static SnakeMobile.ViewModels.GameViewModel;

// Does the GridCell class need to implement an INotifyPropertyChanged? See data-binding-in-xamarinforms -> BethanysPieShopStockApp -> Model -> Pie.cs to see how to implement this.

namespace SnakeMobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamePage : ContentPage
    {
        GameViewModel vm;

        public GamePage()
        {
            InitializeComponent();
            vm = new GameViewModel();

            RenderGameBoard();
            Task.Run(async () => await GameLoop());
        }

        private void RenderGameBoard()
        {
            for (int i = 1; i <= GameBoardSize; i++)
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

            for (int x = 0; x <= GameBoardSize - 1; x++)
            {
                for (int y = 0; y <= GameBoardSize - 1; y++)
                {
                    var boxView = new BoxView();

                    boxView.SetBinding(BoxView.ColorProperty, nameof(
                        Model.Cell.Color), BindingMode.TwoWay, null);

                    int cellIndex = vm.GameBoard.GetCellIndex(x, y);
                    boxView.BindingContext = vm.GameBoard.Cells[cellIndex];

                    GameBoardGrid.Children.Add(boxView, y, x);
                }
            }
        }

        private async Task GameLoop()
        {
            do
            {
                await vm.GameBoard.MoveSnake();

                System.Threading.Thread.Sleep(500);

            } while (vm.GameBoard.Snake.IsOutOfBounds == false);
        }

        private void GamePage_OnSwipedUp(object sender, SwipedEventArgs e)
        {
            vm.GameBoard.Snake.ChangeDirection(Direction.Up);
        }

        private void GamePage_OnSwipedDown(object sender, SwipedEventArgs e)
        {
            vm.GameBoard.Snake.ChangeDirection(Direction.Down);
        }

        private void GamePage_OnSwipedLeft(object sender, SwipedEventArgs e)
        {
            vm.GameBoard.Snake.ChangeDirection(Direction.Left);
        }

        private void GamePage_OnSwipedRight(object sender, SwipedEventArgs e)
        {
            vm.GameBoard.Snake.ChangeDirection(Direction.Right);
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //Task.Run(async () => await GameLoop());

            //DisplayAlert("Game Over", "Better luck next time.", "Cancel");

            //Navigation.PopAsync();
        }
    }
}