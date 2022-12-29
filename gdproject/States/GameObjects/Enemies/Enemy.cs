using gdproject.Interfaces;
using Microsoft.Xna.Framework;

namespace gdproject.States.GameObjects.Enemies
{
    internal abstract class Enemy : Component, IGameObject
    {
        public abstract Rectangle HitBox
        {
            get;
        }
    }
}
