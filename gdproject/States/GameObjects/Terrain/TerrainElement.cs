using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace gdproject.States.GameObjects.Terrain
{
    public class TerrainElement : IGameObject
    {
        private Texture2D _tileset;
        private Rectangle _srcRect;
        private Rectangle _destRect;

        public Block BlockKind { private set; get; }

        public Rectangle HitBox
        {
            get { return _destRect; }
        }


        public TerrainElement(Rectangle destRect, Texture2D tilesetTexture, Block block)
        {
            _tileset = tilesetTexture;
            int tileSize = 16;

            BlockKind = block;

            switch (block)
            {
                case Block.grass:
                    _srcRect = new Rectangle(0, 0, 3 * tileSize, 3 * tileSize);
                    break;
                case Block.brick:
                    _srcRect = new Rectangle(3 * tileSize, 2 * tileSize, 3 * tileSize, 3 * tileSize);
                    break;
                case Block.spike:
                    _srcRect = new Rectangle(2 * tileSize, 7 * tileSize, 3 * tileSize, tileSize);
                    break;
                default:
                    break;
            }

            _destRect = destRect;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_tileset, _destRect, _srcRect, Color.White);
        }
    }
}
