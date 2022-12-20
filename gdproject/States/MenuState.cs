using gdproject.Animation;
using gdproject.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace gdproject.States
{
    internal class MenuState : State
    {
        private List<Component> _components;
        private Texture2D _background;
        private Texture2D _gorillaTexture;

        private Animatie _danceAnimatie = new Animatie();
        private Animatie _growlAnimatie = new Animatie();
        private int _frameSize = 64;

        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base (game, graphicsDevice, content)
        {
            _gorillaTexture = content.Load<Texture2D>("GameAssets/Giant Gorilla Sprite Sheet");
            _background = content.Load<Texture2D>("Backgrounds/menubackground");
            Texture2D playGameText = content.Load<Texture2D>("Buttons/playgame");
            Texture2D levelText = content.Load<Texture2D>("Buttons/level");
            Texture2D exitGameText = content.Load<Texture2D>("Buttons/exit");

            Button playGameButton = new Button(playGameText)
            {
                Position = new Vector2(625, 490)
            };

            playGameButton.Click += playGameButton_Click;

            Button levelButton = new Button(levelText)
            {
                Position = new Vector2(625, 570)
            };

            levelButton.Click += levelButton_Click;

            Button exitGameButton = new Button(exitGameText)
            {
                Position = new Vector2(625, 650)
            };

            exitGameButton.Click += exitGameButton_Click;


            _components = new List<Component>()
            {
                playGameButton,
                levelButton,
                exitGameButton,
            };

            for (int i = 0; i < 6; i++)
            {
                _danceAnimatie.AddFrame(new AnimationFrame(new Rectangle(i * _frameSize, _frameSize * 9, _frameSize, _frameSize)));
            }

            for (int i = 0; i < 4; i++)
            {
                _growlAnimatie.AddFrame(new AnimationFrame(new Rectangle(i * _frameSize, _frameSize * 6, _frameSize, _frameSize)));
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_background, new Rectangle(0, 0, 1500, 800), Color.White);
            foreach (var comp in _components)
            {
                comp.Draw(spriteBatch);
            }
            spriteBatch.Draw(_gorillaTexture, new Rectangle(625, 150, 250,250),_danceAnimatie.CurrentFrame.SourceRectangle, Color.White);
            spriteBatch.Draw(_gorillaTexture, new Rectangle(300, 590, 150, 150), _growlAnimatie.CurrentFrame.SourceRectangle, Color.White);
            spriteBatch.Draw(_gorillaTexture, new Rectangle(1050, 590, 150, 150), _growlAnimatie.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0,0), SpriteEffects.FlipHorizontally, 0f);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var comp in _components)
            {
                comp.Update(gameTime);
            }
            _danceAnimatie.Update(gameTime);
            _growlAnimatie.Update(gameTime);
        }

        private void exitGameButton_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void levelButton_Click(object sender, EventArgs e)
        {
            game.ChangeState(new LevelSelectorState(game, graphicsDevice, content));
        }

        private void playGameButton_Click(object sender, EventArgs e)
        {
            game.ChangeState(new GameState(game, graphicsDevice, content, 1));
        }
    }
}
