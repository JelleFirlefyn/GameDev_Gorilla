using gdproject.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace gdproject.States
{
    public class GameState : State
    {
        private Hero gorilla;

        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            Texture2D texture = content.Load<Texture2D>("Giant Gorilla Sprite Sheet");

            gorilla = new Hero(texture, new KeyboardReader());
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            gorilla.Draw(spriteBatch);
        }

        public override void PostUpdate(GameTime gameTime)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            gorilla.Update(gameTime);
        }
    }
}
