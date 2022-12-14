﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gdproject.States.GameObjects
{
    internal class Coin : IGameObject
    {
        private Texture2D _tileset;
        private Rectangle _srcRect;
        private Rectangle _destRect;

        public Rectangle DestRect
        {
            get { return _destRect; }
        }

        public Coin(Rectangle destRect, Texture2D tilesetTexture)
        {
            _tileset = tilesetTexture;
            int tileSize = 16;
            this._srcRect = new Rectangle(5 * tileSize, 7 * tileSize, 1 * tileSize, 1 * tileSize);
            this._destRect = destRect;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_tileset, _destRect, _srcRect, Color.White);
        }
    }
}