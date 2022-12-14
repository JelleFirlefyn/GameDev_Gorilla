using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

//Bron: https://youtu.be/76Mz7ClJLoE

namespace gdproject.States
{
    public abstract class State 
    {
        protected ContentManager content;
        protected GraphicsDevice graphicsDevice;
        protected Game1 game;


        public State(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
        {
            this.content = content;
            this.graphicsDevice = graphicsDevice;
            this.game = game;
        }

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public abstract void Update(GameTime gameTime);
    }
}
