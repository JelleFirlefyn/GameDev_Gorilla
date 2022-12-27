﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gdproject.States.GameObjects
{
    internal class Barrel : Component
    {
        private Texture2D _texture;
        private Rectangle _destRect;
        private Rectangle _srcRect;
        private int _speed;

        public Rectangle HitBox
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
            _srcRect = new Rectangle(0, 3 * tileSize, 3 * tileSize, 3 * tileSize);
            _destRect = new Rectangle(999, 700, 50, 50);
            _speed = 5;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _destRect, _srcRect, Color.White);
        }

        public override void Update(GameTime gameTime)
        {

            if (_destRect.X < 600 || _destRect.X > 1000)
            {
                _speed *= -1;
            }

            _destRect.X -= _speed;
        }

    }
}
