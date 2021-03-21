using SnakeMobile.Enums;
using SnakeMobile.Domain.Model;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using SnakeMobile.Helpers;

namespace SnakeMobile.ViewModels
{
    public partial class GameViewModel
    {
        public readonly int GameBoardSize = 12;
        public Game Game { get; set; } = new Game();
        public ICommand MoveSnakeUp { get; private set; }
        public ICommand MoveSnakeDown { get; private set; }
        public ICommand MoveSnakeLeft { get; private set; }
        public ICommand MoveSnakeRight { get; private set; }
        
        public GameViewModel()
        {
            Game.GameBoard.Create(GameBoardSize);
            Game.GameBoard.SpawnSnake();
            Game.GameBoard.SpawnPellet();

            MoveSnakeUp = new Command(MoveUp);
            MoveSnakeDown = new Command(MoveDown);
            MoveSnakeLeft = new Command(MoveLeft);
            MoveSnakeRight = new Command(MoveRight);
        }

        private void MoveUp()
        {
            Game.GameBoard.Snake.ChangeDirection(Direction.Up);
        }

        private void MoveDown()
        {
            Game.GameBoard.Snake.ChangeDirection(Direction.Down);
        }

        private void MoveLeft()
        {
            Game.GameBoard.Snake.ChangeDirection(Direction.Left);
        }

        private void MoveRight()
        {
            Game.GameBoard.Snake.ChangeDirection(Direction.Right);
        }

        public async Task<GameResults> StartGame()
        {
            var results = await Task.Run(async () => await Game.StartGameLoop());

            AudioHelper.PlayGameOverSound();

            return results;
        }
    }
}
