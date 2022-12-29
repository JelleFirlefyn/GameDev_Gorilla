using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gdproject.States.GameObjects.Terrain
{
    static class RectangleCollision
    {
        public static bool TouchTopOf(this Rectangle rectOne, Rectangle rectTwo)
        {
            return rectOne.Bottom >= rectTwo.Top - 1 &&
                rectOne.Bottom <= rectTwo.Top + rectTwo.Height / 2 &&
                rectOne.Right >= rectTwo.Left + rectTwo.Width / 5
                && rectOne.Left <= rectTwo.Right - rectTwo.Width / 5;
        }

        public static bool TouchBottomOf(this Rectangle rectOne, Rectangle rectTwo)
        {
            return rectOne.Top <= rectTwo.Bottom + rectTwo.Height / 5 &&
                rectOne.Top >= rectTwo.Bottom - 1 &&
                rectOne.Right >= rectTwo.Left + rectTwo.Width / 5
                && rectOne.Left <= rectTwo.Right - rectTwo.Width / 5;
        }

        public static bool TouchLeftOf(this Rectangle rectOne, Rectangle r2)
        {
            return rectOne.Right <= r2.Right &&
                rectOne.Right >= r2.Left - 5 &&
                rectOne.Top <= r2.Bottom - r2.Width / 4 &&
                rectOne.Bottom >= r2.Top + r2.Width / 4;
        }

        public static bool TouchRightOf(this Rectangle r1, Rectangle r2)
        {
            return r1.Left >= r2.Left &&
                r1.Left <= r2.Right + 5 &&
                r1.Top <= r2.Bottom - r2.Width / 4 &&
                r1.Bottom >= r2.Top + r2.Width / 4;
        }
    }
}
