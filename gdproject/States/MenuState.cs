using gdproject.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace gdproject.States
{
    internal class MenuState : State
    {
        private List<Component> components;
        private Texture2D background;

        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base (game, graphicsDevice, content)
        {
            background = content.Load<Texture2D>("menubackground");
            Texture2D playGameText = content.Load<Texture2D>("playgame");
            Texture2D exitGameText = content.Load<Texture2D>("exit");

            Button playGameButton = new Button(playGameText)
            {
                Position = new Vector2(649, 500)
            };

            playGameButton.Click += playGameButton_Click;

            Button exitGameButton = new Button(exitGameText)
            {
                Position = new Vector2(649, 600)
            };

            exitGameButton.Click += exitGameButton_Click;


            components = new List<Component>()
            {
                playGameButton,
                exitGameButton,
            };

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, new Rectangle(0, 0, 1600, 750), Color.White);
            foreach (var comp in components)
            {
                comp.Draw(gameTime, spriteBatch);
            }
        
        }

    public override void PostUpdate(GameTime gameTime)
        {
            //remove sprites if not needed
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var comp in components)
            {
                comp.Update(gameTime);
            }
        }

        private void exitGameButton_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void playGameButton_Click(object sender, EventArgs e)
        {
            game.ChangeState(new GameState(game, graphicsDevice, content));
        }
    }
}
