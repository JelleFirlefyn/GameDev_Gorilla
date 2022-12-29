using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gdproject.Interfaces
{
    internal interface IGameObject
    {
        public Rectangle HitBox
        {
            get;
        }

        public void Draw(SpriteBatch spriteBatch);
    }
}
