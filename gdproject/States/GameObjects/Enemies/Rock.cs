using gdproject.Animation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace gdproject.States.GameObjects.Enemies
{
    internal class Rock : Enemy 
    {
        private Texture2D _texture;
        private Rectangle _destRect;
        private AnimationFrame _animationFrame;
        private float _rotation;
        private static Random rnd = new Random();

        public override Rectangle HitBox
        {
            get
            {
                Rectangle temp = new Rectangle(_destRect.X, _destRect.Y, _destRect.Width - 25, _destRect.Height - 25);
                return temp;
            }
        }

        public bool isFalling { get; set; }


        public Rock(ContentManager content)
        {
            _texture = content.Load<Texture2D>("GameAssets/nature-paltformer-tileset-16x16");

            int tileSize = 16;
            _animationFrame = new AnimationFrame(new Rectangle(2 * tileSize, 8 * tileSize, 3 * tileSize, 3 * tileSize));
            _destRect = new Rectangle(-700, 400, 50, 50);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _destRect, _animationFrame.SourceRectangle, Color.White, _rotation, new Vector2(25, 25), SpriteEffects.None, 0f);
        }

        public override void Update(GameTime gameTime)
        {
            if (isFalling)
            {
                _destRect.Y += 5;
                _rotation += 0.01f;
                _rotation += _rotation * 0.01f;
            }
            else
            {
                _rotation = 0;
            }

            if (_destRect.Y > 1600) isFalling = false;
        }

        public void Spawn(int gorillaPosition)
        {
            if (rnd.Next(0, 100) == 5 && !isFalling)
            {
                _destRect.X = rnd.Next(-10, 10) + gorillaPosition;
                _destRect.Y = -100;
                isFalling = true;
            }
        }
    }
}
