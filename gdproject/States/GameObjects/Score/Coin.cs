using gdproject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace gdproject.States.GameObjects.Score
{
    internal class Coin : IGameObject
    {
        private Texture2D _tileset;
        private Rectangle _srcRect;
        private Rectangle _destRect;

        public Rectangle HitBox
        {
            get
            {
                Rectangle temp = new Rectangle(_destRect.X + 7, _destRect.Y + 5, _destRect.Width - 13, _destRect.Height - 10);
                return temp;
            }
        }

        public Coin(Rectangle destRect, Texture2D tilesetTexture)
        {
            _tileset = tilesetTexture;
            int tileSize = 16;
            _srcRect = new Rectangle(5 * tileSize, 7 * tileSize, 1 * tileSize, 1 * tileSize);
            _destRect = destRect;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_tileset, _destRect, _srcRect, Color.White);
        }
    }
}
