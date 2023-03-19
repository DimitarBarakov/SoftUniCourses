using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        private const char WallSymbol = '\u25A0';
        public Wall(int leftx, int topy) : base(leftx, topy)
        {
            InitializeBorder();
        }

        private void SetHorizontalLine(int topY)
        {
            for (int leftx = 0; leftx < this.LeftX; leftx++)
            {
                this.Draw(leftx,topY,WallSymbol);
            }
        }
        private void SetVerticalLine(int leftX)
        {
            for (int topy = 0; topy < this.TopY; topy++)
            {
                this.Draw(leftX, topy, WallSymbol);
            }
        }

        private void InitializeBorder()
        {
            SetHorizontalLine(0);
            SetHorizontalLine(this.TopY);

            SetVerticalLine(0);
            SetVerticalLine(this.LeftX - 1);
        }
    }
}
