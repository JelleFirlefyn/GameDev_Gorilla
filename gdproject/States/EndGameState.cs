using gdproject.Animation;
using gdproject.Controls;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace gdproject.States
{
    internal class EndGameState : State
    {
        private List<Component> _components;
        private Texture2D _backgroundGameOver;
        private Texture2D _backgroundVictory;
        private bool _isGameOver;

        public EndGameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, bool isGameOver) : base(game, graphicsDevice, content)
        {
            _backgroundGameOver = content.Load<Texture2D>("Backgrounds/gameoverbackground");
            _backgroundVictory = content.Load<Texture2D>("Backgrounds/victorybackground");
            Texture2D playAgainText = content.Load<Texture2D>("Buttons/playagain");
            Texture2D menuText = content.Load<Texture2D>("Buttons/menu");
            Texture2D exitGameText = content.Load<Texture2D>("Buttons/exit");

            Button playGameButton = new Button(playAgainText)
            {
                Position = new Vector2(625, 490)
            };

            playGameButton.Click += playAgainButton_Click;

            Button menuButton = new Button(menuText)
            {
                Position = new Vector2(625, 570)
            };

            menuButton.Click += menuButton_Click;

            Button exitGameButton = new Button(exitGameText)
            {
                Position = new Vector2(625, 650)
            };

            exitGameButton.Click += exitGameButton_Click;

            _components = new List<Component>()
            {
                playGameButton,
                menuButton,
                exitGameButton,
            };

            _isGameOver = isGameOver;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (_isGameOver) spriteBatch.Draw(_backgroundGameOver, new Rectangle(0, 0, 1500, 800), Color.White);
            else spriteBatch.Draw(_backgroundVictory, new Rectangle(0, 0, 1500, 800), Color.White);

            foreach (var comp in _components)
            {
                comp.Draw(spriteBatch);
            }
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var comp in _components)
            {
                comp.Update(gameTime);
            }
        }

        private void exitGameButton_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            game.ChangeState(new MenuState(game, graphicsDevice, content));
        }

        private void playAgainButton_Click(object sender, EventArgs e)
        {
            game.ChangeState(new GameState(game, graphicsDevice, content, 1));
        }
    }
}
