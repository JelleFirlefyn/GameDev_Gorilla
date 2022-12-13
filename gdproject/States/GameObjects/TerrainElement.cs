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
    public class TerrainElement
    {
        private Texture2D tileset;
        private Rectangle srcRect;
        private Rectangle destRect;

        public Rectangle DestRect
        {
            get { return destRect; }
        }


        public TerrainElement(Rectangle destRect, Texture2D tilesetTexture)
        {
            tileset = tilesetTexture;
            int tileSize = 16;
            this.srcRect = new Rectangle(3 * tileSize, 2 * tileSize, 3 * tileSize, 3 * tileSize);
            this.destRect = destRect;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tileset, destRect, srcRect, Color.White);
        }

    }
}
