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

namespace gdproject.States
{
    internal class MenuState : State
    {
        private List<Component> _components;
        private Texture2D _background;
        private Texture2D _texture;

        private Animatie _danceAnimatie = new Animatie();
        private int _frameSize = 64;

        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base (game, graphicsDevice, content)
        {
            _texture = content.Load<Texture2D>("Giant Gorilla Sprite Sheet");
            _background = content.Load<Texture2D>("menubackground");
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


            _components = new List<Component>()
            {
                playGameButton,
                exitGameButton,
            };

            for (int i = 0; i < 6; i++)
            {
                _danceAnimatie.AddFrame(new AnimationFrame(new Rectangle(i * _frameSize, _frameSize * 9, _frameSize, _frameSize)));
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_background, new Rectangle(0, 0, 1500, 800), Color.White);
            foreach (var comp in _components)
            {
                comp.Draw(gameTime, spriteBatch);
            }
            spriteBatch.Draw(_texture, new Rectangle(625, 150, 250,250),_danceAnimatie.CurrentFrame.SourceRectangle, Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var comp in _components)
            {
                comp.Update(gameTime);
            }
            _danceAnimatie.Update(gameTime);
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
