using gdproject.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace gdproject.States
{
    public class GameState : State
    {
        private Hero gorilla;
        private Texture2D background;
        private Rectangle backgroundRect;
        //ENDLESS RUNNER CODE
        //private Rectangle backgroundSecRect;

        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            Texture2D gorillaTexture = content.Load<Texture2D>("Giant Gorilla Sprite Sheet");
            background = content.Load<Texture2D>("gamebackground");

            gorilla = new Hero(gorillaTexture, new KeyboardReader());

            backgroundRect = new Rectangle(0, 0, 1500, 800);
            //ENDLESS RUNNER CODE
            //backgroundSecRect = new Rectangle(1500, 0, 1600, 800);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, backgroundRect, Color.White);

            //ENDLESS RUNNER CODE
            //spriteBatch.Draw(background, backgroundSecRect, Color.White);
            gorilla.Draw(spriteBatch);
        }

        public override void PostUpdate(GameTime gameTime)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            gorilla.Update(gameTime);

            //ENDLESS RUNNER CODE
            //backgroundRect.X -= 5;
            //backgroundSecRect.X -= 5;

            //if (backgroundRect.X < -1500)
            //{
            //    backgroundRect.X = 1500;
            //}

            //if (backgroundSecRect.X < -1500)
            //{
            //    backgroundSecRect.X = 1500;
            //}
        }
    }
}
