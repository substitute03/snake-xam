using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using SnakeMobile.Model;

namespace SnakeMobile.ViewModels
{
    public partial class GameViewModel
    {
        public GameBoard GameBoard { get; set; } = new GameBoard();
        public const int GameBoardSize = 12;

        public GameViewModel()
        {
            GameBoard = GameBoard.Create(GameBoardSize);
            GameBoard.SpawnSnake();
            GameBoard.SpawnPellet();
        }
    }
}
