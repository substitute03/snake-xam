using SnakeMobile.Enums;
using SnakeMobile.Model;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

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

        public void MoveUp()
        {
            Game.GameBoard.Snake.ChangeDirection(Direction.Up);
        }

        public void MoveDown()
        {
            Game.GameBoard.Snake.ChangeDirection(Direction.Down);
        }

        public void MoveLeft()
        {
            Game.GameBoard.Snake.ChangeDirection(Direction.Left);
        }

        public void MoveRight()
        {
            Game.GameBoard.Snake.ChangeDirection(Direction.Right);
        }

        public async Task<GameResults> StartGame()
        {
            return await Task.Run(async () => await Game.StartGameLoop());
        }
    }
}
