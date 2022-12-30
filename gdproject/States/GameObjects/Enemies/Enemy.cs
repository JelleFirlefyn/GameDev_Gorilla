using gdproject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace gdproject.States.GameObjects.Enemies
{
    internal abstract class Enemy : IGameObject, IGameObjectUpdate
    {
        public abstract Rectangle HitBox
        {
            get;
        }

        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract void Update(GameTime gameTime);
    }
}
