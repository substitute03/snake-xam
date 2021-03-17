using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMobile.Model
{
    public class Snake
    {
        public static readonly Color UnitColor = Color.ForestGreen;
        public LinkedList<Cell> Cells { get; set; }
        public Direction CurrentDirection { get; set; } = Direction.Left;
        public bool IsOutOfBounds { get; set; } = false;
        public bool HasCollidedWithSelf { get; set; } = false;

        public Cell Head => Cells.First.Value;
        public Cell Tail => Cells.Last.Value;

        public Snake() 
        {

        }

        public Task Render()
        {
            foreach (var cell in Cells)
            {
                cell.Color = UnitColor;
            }

            return Task.CompletedTask;
        }

        public void MoveTo(Cell cell)
        {
            
        }

        public void ChangeDirection(Direction direction)
        {
            if (!direction.IsOppositeTo(CurrentDirection))
                CurrentDirection = direction;
        }
    }
}
