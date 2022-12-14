using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gdproject.States.GameObjects
{
    internal interface IGameObject
    {
        public Rectangle DestRect
        {
            get;
        }

        public void Draw(SpriteBatch spriteBatch);
    }
}
