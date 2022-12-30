using gdproject.Animation;
using gdproject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace gdproject.States.GameObjects.Terrain
{
    public class TerrainElement : IGameObject
    {
        private Texture2D _tileset;
        private AnimationFrame _animationFrame;
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
                    _animationFrame = new AnimationFrame(new Rectangle(0, 0, 3 * tileSize, 3 * tileSize));
                    break;
                case Block.brick:
                    _animationFrame = new AnimationFrame(new Rectangle(3 * tileSize, 2 * tileSize, 3 * tileSize, 3 * tileSize));
                    break;
                case Block.spike:
                    _animationFrame = new AnimationFrame(new Rectangle(2 * tileSize, 7 * tileSize, 3 * tileSize, tileSize));
                    break;
                default:
                    break;
            }

            _destRect = destRect;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_tileset, _destRect, _animationFrame.SourceRectangle, Color.White);
        }
    }
}
