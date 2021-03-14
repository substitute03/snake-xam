using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMobile.Model
{
    public class GameBoard
    {
        public ObservableCollection<Cell> Cells { get; set; }
        public Snake Snake { get; set; }
        public Pellet Pellet { get; set; }
        public int Size { get; private set; }
        public int Length => (Size * Size) - 1;
        public bool IsInIllegalState => Snake.IsOutOfBounds || Snake.HasCollidedWithSelf;

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
            Snake = new Snake(Size);
            var cells = new LinkedList<Cell>();

            cells.AddLast(Cells[GetCellIndex(7, 7)]);
            cells.AddLast(Cells[GetCellIndex(7, 8)]);
            cells.AddLast(Cells[GetCellIndex(7, 9)]);

            Snake.Cells = cells;
            Snake.Render();
        }

        public void SpawnPellet()
        {
            Pellet = new Pellet();

            int emptyCellIndex = 
                GenerateEmptyCellIndex();
            
            Pellet.Cell = Cells[emptyCellIndex];
            Pellet.Render();
        }

        private int GenerateEmptyCellIndex()
        {
            int cellIndex;
            do
            {
                Random rng = new Random();
                cellIndex = rng.Next(0, Length);
            }
            while (!Cells[cellIndex].IsEmpty);

            return cellIndex;
        }

        public async Task MoveSnake()
        {
            Direction directionToMove = Snake.CurrentDirection;

            Point moveToPoint = await GetAdjacentCellCoordinates(directionToMove, Snake.Head);

            if (moveToPoint.X == -1 || moveToPoint.X > Size - 1
                || moveToPoint.Y == -1 || moveToPoint.Y > Size - 1)
            {
                Snake.IsOutOfBounds = true;
                return;
            }

            Cell moveToCell = await GetAdjacentCell(directionToMove, Snake.Head);

            Snake.Tail.Color = Cell.UnitColor;
            Snake.Cells.Remove(Snake.Tail);
            Snake.Cells.AddFirst(moveToCell);

            await Snake.Render();
        }

        private Task<Cell> GetAdjacentCell(Direction direction, Cell toCell)
        {
            int x = toCell.PositionX;
            int y = toCell.PositionY;

            if (direction == Direction.Up)
            {
                return Task.FromResult(Cells[GetCellIndex(x - 1, y)]);
            }
            else if (direction == Direction.Down)
            {
                return Task.FromResult(Cells[GetCellIndex(x + 1, y)]);
            }
            else if (direction == Direction.Left)
            {
                return Task.FromResult(Cells[GetCellIndex(x, y - 1)]);
            }
            else
            {
                return Task.FromResult(Cells[GetCellIndex(x, y + 1)]);
            }
        }

        private Task<Point> GetAdjacentCellCoordinates(Direction direction, Cell toCell)
        {
            int x = toCell.PositionX;
            int y = toCell.PositionY;

            if (direction == Direction.Up)
            {
                Cell adjacentCell = Cells[GetCellIndex(x - 1, y)];
                return Task.FromResult(new Point(adjacentCell.PositionX, adjacentCell.PositionY));
            }
            else if (direction == Direction.Down)
            {
                Cell adjascentCell = Cells[GetCellIndex(x + 1, y)];
                return Task.FromResult(new Point(adjascentCell.PositionX, adjascentCell.PositionY));
            }
            else if (direction == Direction.Left)
            {
                Cell adjascentCell = Cells[GetCellIndex(x, y - 1)];
                return Task.FromResult(new Point(adjascentCell.PositionX, adjascentCell.PositionY));
            }
            else
            {
                Cell adjascentCell = Cells[GetCellIndex(x, y + 1)];
                return Task.FromResult(new Point(adjascentCell.PositionX, adjascentCell.PositionY));
            }
        }

        public int GetCellIndex(int positionX, int positionY)
        {
            return Cells
                .IndexOf(Cells
                    .Single(gbc => gbc.PositionX == positionX && gbc.PositionY == positionY));
        }
    }
}
