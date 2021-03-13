using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace SnakeMobile.Model
{
    public class GameBoard
    {
        public ObservableCollection<Cell> Cells { get; set; }
        public Snake Snake { get; set; }
        public Pellet Pellet { get; set; }
        public int Size { get; private set; }
        public int Length => (Size * Size) - 1;
        private Random GetRandomNumber = new Random();

        public GameBoard Create(int gameBoardSize)
        {
            Size = gameBoardSize;
            Cells = new ObservableCollection<Cell>();

            for (int x = 0; x <= Size - 1; x++)
            {
                for (int y = 0; y <= Size - 1; y++)
                {
                    Cells.Add(new Cell(x, y));
                }
            }

            return this;
        }

        public void SpawnSnake()
        {
            Snake = new Snake();
            var cells = new List<Cell>();

            cells.AddRange(new List<Cell>
            {
                Cells[GetCellIndex(7, 7)],
                Cells[GetCellIndex(7, 8)],
                Cells[GetCellIndex(7, 9)]
            });

            Snake.Cells = cells;
            Snake.Render();
        }

        public void SpawnPellet()
        {
            Pellet = new Pellet();
            int cellIndex = 0;

            bool end = false;
            while (end == false)
            {
                cellIndex = GenerateRandomCellIndex();

                if (Cells[cellIndex].IsEmpty)
                    end = true;
            }

            Pellet.Cell = Cells[cellIndex];
            Pellet.Render();
        }

        private int GenerateRandomCellIndex()
        {
            Random rng = new Random();
            return rng.Next(0, Length);
        }

        public int GetCellIndex(int positionX, int positionY)
        {
            return Cells
                .IndexOf(Cells
                    .Single(gbc => gbc.PositionX == positionX && gbc.PositionY == positionY));
        }
    }
}
