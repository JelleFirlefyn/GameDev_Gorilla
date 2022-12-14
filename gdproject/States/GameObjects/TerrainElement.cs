using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace gdproject.States.GameObjects
{
    public class TerrainElement : IGameObject
    {
        private Texture2D _tileset;
        private Rectangle _srcRect;
        private Rectangle _destRect;

        public Rectangle HitBox
        {
            get { return _destRect; }
        }


        public TerrainElement(Rectangle destRect, Texture2D tilesetTexture)
        {
            _tileset = tilesetTexture;
            int tileSize = 16;
            this._srcRect = new Rectangle(3 * tileSize, 2 * tileSize, 3 * tileSize, 3 * tileSize);
            this._destRect = destRect;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_tileset, _destRect, _srcRect, Color.White);
        }
    }
}
