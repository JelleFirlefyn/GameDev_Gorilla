using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace gdproject.Interfaces
{
    internal interface IGameObject
    {
        public Rectangle HitBox
        {
            get;
        }

        public void Draw(SpriteBatch spriteBatch);
    }
}
