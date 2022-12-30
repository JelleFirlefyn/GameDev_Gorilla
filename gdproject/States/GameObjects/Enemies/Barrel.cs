using gdproject.Animation;
using gdproject.States.GameObjects.Terrain;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace gdproject.States.GameObjects.Enemies
{
    internal class Barrel : Enemy
    {
        private Texture2D _texture;
        private Rectangle _destRect;
        private AnimationFrame _animationFrame;
        private int _speed;

        public override Rectangle HitBox
        {
            get
            {
                Rectangle temp = new Rectangle(_destRect.X + 5, _destRect.Y, _destRect.Width - 5, _destRect.Height);
                return temp;
            }
        }

        public Barrel(ContentManager content)
        {
            _texture = content.Load<Texture2D>("GameAssets/nature-paltformer-tileset-16x16");

            int tileSize = 16;
            _animationFrame = new AnimationFrame(new Rectangle(0, 3 * tileSize, 3 * tileSize, 3 * tileSize));
            _destRect = new Rectangle(999, 700, 50, 50);
            _speed = 5;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _destRect, _animationFrame.SourceRectangle, Color.White);
        }

        public override void Update(GameTime gameTime)
        {

            if (_destRect.X < 600 || _destRect.X > 1000)
            {
                _speed *= -1;
            }

            _destRect.X -= _speed;
        }

        public bool SideCollision(Rectangle r)
        {
            if (RectangleCollision.TouchBottomOf(r, HitBox)
                || RectangleCollision.TouchRightOf(r, HitBox)
                || RectangleCollision.TouchLeftOf(r, HitBox)) return true;
            return false;
        }

        public bool TopCollision(Rectangle r)
        {
            if (RectangleCollision.TouchTopOf(r, HitBox)) return true;
            return false;
        }
    }
}
