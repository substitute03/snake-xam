using SnakeMobile.Model;

namespace SnakeMobile.ViewModels
{
    public partial class GameViewModel
    {
        public readonly int GameBoardSize = 12;
        public Game Game { get; set; } = new Game();

        public GameViewModel()
        {
            Game.GameBoard.Create(GameBoardSize);
            Game.GameBoard.SpawnSnake();
            Game.GameBoard.SpawnPellet();
        }
    }
}
