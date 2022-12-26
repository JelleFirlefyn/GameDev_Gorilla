using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace gdproject.States.GameObjects
{
    internal class Rock : Component
    {
        private Texture2D _texture;
        private Rectangle _destRect;
        private Rectangle _srcRect;
        private float _rotation;

        public Rectangle DestRect
        {
            get { return _destRect; }
            set { _destRect = value; }
        }


        public Rock(ContentManager content)
        {
            _texture = content.Load<Texture2D>("GameAssets/nature-paltformer-tileset-16x16");

            int tileSize = 16;
            _srcRect = new Rectangle(2 * tileSize, 8 * tileSize, 3 * tileSize, 3 * tileSize);
            _destRect = new Rectangle(700, 400, 50, 50);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _destRect, _srcRect, Color.White, _rotation, new Vector2(25,25), SpriteEffects.None, 0f);
        }

        public override void Update(GameTime gameTime)
        {
            _rotation += 0.1f;
        }
    }
}
