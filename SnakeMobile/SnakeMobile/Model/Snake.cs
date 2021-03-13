using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SnakeMobile.Model
{
    public class Snake
    {
        public readonly Color UnitColor = Color.ForestGreen;
        public List<Cell> Cells { get; set; }        
        public Snake(){}
        public Direction CurrentDirection { get; set; } = Direction.Up;

        public void Render()
        {
            foreach (var cell in Cells)
            {
                cell.Color = UnitColor;
            }
        }

        public void ChangeDirection(Direction direction)
        {
            if (!direction.IsOppositeTo(CurrentDirection))
                CurrentDirection = direction;
        }
    }
}
