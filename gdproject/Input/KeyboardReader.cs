using gdproject.Animation;
using gdproject.Interfaces;
using Microsoft.Xna.Framework.Input;

namespace gdproject.Input
{
    internal class KeyboardReader : IInputReader
    {
        public Movement ReadInput()
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Up))
            {
                return Movement.up;
            }
            if (state.IsKeyDown(Keys.Left))
            {
                return Movement.left;
            }
            if (state.IsKeyDown(Keys.Right))
            {
                return Movement.right;
            }
            if (state.IsKeyDown(Keys.Down))
            {
                return Movement.down;
            }
            if (state.IsKeyDown(Keys.Space))
            {
                return Movement.smash;
            }
            if (state.IsKeyDown(Keys.D))
            {
                return Movement.dance;
            }

            return Movement.still;
        }
    }
}
    