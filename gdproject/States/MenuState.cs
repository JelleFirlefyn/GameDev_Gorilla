using gdproject.Animation;
using gdproject.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
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
        private Texture2D texture;

        private Animatie danceAnimatie = new Animatie();
        private int frameSize = 64;

        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base (game, graphicsDevice, content)
        {
            texture = content.Load<Texture2D>("Giant Gorilla Sprite Sheet");
            background = content.Load<Texture2D>("menubackground");
            Texture2D playGameText = content.Load<Texture2D>("playgame");
            Texture2D exitGameText = content.Load<Texture2D>("exit");

            Button playGameButton = new Button(playGameText)
            {
                Position = new Vector2(625, 500)
            };

            playGameButton.Click += playGameButton_Click;

            Button exitGameButton = new Button(exitGameText)
            {
                Position = new Vector2(625, 600)
            };

            exitGameButton.Click += exitGameButton_Click;


            components = new List<Component>()
            {
                playGameButton,
                exitGameButton,
            };

            for (int i = 0; i < 6; i++)
            {
                danceAnimatie.AddFrame(new AnimationFrame(new Rectangle(i * frameSize, frameSize * 9, frameSize, frameSize)));
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, new Rectangle(0, 0, 1500, 800), Color.White);
            foreach (var comp in components)
            {
                comp.Draw(gameTime, spriteBatch);
            }
            spriteBatch.Draw(texture, new Rectangle(625, 150, 250,250),danceAnimatie.CurrentFrame.SourceRectangle, Color.White);
            //spriteBatch.Draw(texture, new Vector2(625, 400),)
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
            danceAnimatie.Update(gameTime);
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
