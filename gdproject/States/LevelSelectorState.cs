using gdproject.Animation;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using gdproject.Controls;
using SharpDX.Direct3D9;

namespace gdproject.States
{
    internal class LevelSelectorState : State
    {
        private List<Component> _components;
        private Texture2D _background;
        private int _frameSize = 64;
        private Animatie _danceAnimatie = new Animatie();
        private Animatie _growlAnimatie = new Animatie();
        private Texture2D _gorillaTexture;


        public LevelSelectorState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            _gorillaTexture = content.Load<Texture2D>("GameAssets/Giant Gorilla Sprite Sheet");
            _background = content.Load<Texture2D>("menubackground");
            Texture2D levelOneText = content.Load<Texture2D>("Buttons/level1");
            Texture2D levelTwoText = content.Load<Texture2D>("Buttons/level2");
            Texture2D backButtonText = content.Load<Texture2D>("Buttons/back");

            Button levelOneButton = new Button(levelOneText)
            {
                Position = new Vector2(625, 490)
            };

            levelOneButton.Click += LevelOneButton_Click;

            Button levelTwoButton = new Button(levelTwoText)
            {
                Position = new Vector2(625, 570)
            };

            levelTwoButton.Click += LevelTwoButton_Click;

            Button backButton = new Button(backButtonText)
            {
                Position = new Vector2(625, 650)
            };

            backButton.Click += BackButton_Click;

            _components = new List<Component>()
            {
                levelOneButton,
                levelTwoButton,
                backButton,
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
            spriteBatch.Draw(_gorillaTexture, new Rectangle(1000, 36, 50, 50), _danceAnimatie.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0f);
            spriteBatch.Draw(_gorillaTexture, new Rectangle(300, 590, 150, 150), _growlAnimatie.CurrentFrame.SourceRectangle, Color.White);
            spriteBatch.Draw(_gorillaTexture, new Rectangle(1050, 590, 150, 150), _growlAnimatie.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0f);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var comp in _components)
            {
                comp.Update(gameTime);
            }
            _growlAnimatie.Update(gameTime);
            _danceAnimatie.Update(gameTime);
        }

        private void LevelOneButton_Click(object sender, EventArgs e)
        {
            game.ChangeState(new GameState(game, graphicsDevice, content, 1));
        }

        private void LevelTwoButton_Click(object sender, EventArgs e)
        {
            game.ChangeState(new GameState(game, graphicsDevice, content, 2));
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            game.ChangeState(new MenuState(game, graphicsDevice, content));
        }
    }
}
