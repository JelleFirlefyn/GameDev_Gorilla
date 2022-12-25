using gdproject.Animation;
using gdproject.Input;
using gdproject.States.GameObjects.Terrain;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gdproject.States.GameObjects
{
    public class Hero : Component
    {
        private Texture2D _heroTexture;
        private AnimationManager _animatie;

        private Vector2 _position;
        private Vector2 _velocity;
        private Rectangle _destRect;
        private SpriteEffects _spriteEffect;
        private bool _hasJumped;
        private IInputReader _inputReader;
        //COLLISION TESTING
        Rectangle hitBox;

        public Rectangle HitBox
        {
            get { return hitBox; }
        }

        Texture2D blokTexture;


        public Hero(Texture2D texture, IInputReader inputReader, GraphicsDevice graphicsDevice)
        {
            _heroTexture = texture;
            _animatie = new AnimationManager(inputReader);
            this._inputReader = inputReader;
            _position = new Vector2(70f, 646.8f);
            //COLLISION TESTING
            blokTexture = new Texture2D(graphicsDevice, 1, 1);
            blokTexture.SetData(new[] { Color.White });


            _hasJumped = true;
        }

        public override void Update(GameTime gameTime)
        {
            Move();

            _destRect = new Rectangle((int)_position.X, (int)_position.Y, 100, 100);
            hitBox = new Rectangle((int)_position.X + 15, (int)_position.Y + 35, 65, 60);

            _animatie.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //COLLISION TESTING
            //spriteBatch.Draw(blokTexture, hitBox, Color.Red);
        
            spriteBatch.Draw(_heroTexture, _destRect, _animatie.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), _spriteEffect, 0f);
        }

        private void Move()
        {
            //Bron: https://www.youtube.com/watch?v=ZLxIShw-7ac&t=139s&ab_channel=Oyyou
            //Flip sprite bron: https://stackoverflow.com/questions/6146337/how-to-flip-a-sprite-in-c-sharp

            _position += _velocity;
            Movement movement = _inputReader.ReadInput();

            if(_velocity.Y < 10)
            {
                _velocity.Y += 0.4f;
            }

            if (movement == Movement.right)
            {
                if (_hasJumped) _velocity.X = 4.5f;
                else _velocity.X = 3f;

                _spriteEffect = SpriteEffects.None;
            }
            else if (movement == Movement.left)
            {
                if (_hasJumped) _velocity.X = -4.5f;
                else _velocity.X = -3f;

                _spriteEffect = SpriteEffects.FlipHorizontally;
            }
            else _velocity.X = 0;

            if (movement == Movement.up && !_hasJumped)
            {
                _position.Y -= 10f;
                _velocity.Y = -16f;
                _hasJumped = true;
            }

            if (_hasJumped)
            {
                float i = 1;
                _velocity.Y += 0.55f * i;
            }

            if (_position.Y + _heroTexture.Height >= 1260)
            {
                _hasJumped = false;
            }
        }

        public void Collision(Rectangle newRect, int screenWidth)
        {
            BlockCollision(newRect);

            ScreenCollision(screenWidth);
        }

        private void BlockCollision(Rectangle newRect)
        {
            if (hitBox.TouchTopOf(newRect))
            {
                hitBox.Y = newRect.Y - hitBox.Height;
                _velocity.Y = 0f;
                _hasJumped = false;
            }

            if (hitBox.TouchLeftOf(newRect))
            {
                _position.X = newRect.X - (int)(newRect.Width * 1.5) - 10;
            }

            if (hitBox.TouchRightOf(newRect))
            {
                _position.X = newRect.X + (int)(newRect.Width * .8);
            }

            if (hitBox.TouchBottomOf(newRect))
            {
                _velocity.Y = 1f;
            }
        }

        private void ScreenCollision(int screenWidth)
        {
            if (_position.X < 0) _position.X = 0;
            if (_position.X > screenWidth - hitBox.Width) _position.X = screenWidth - hitBox.Width;
            if (_position.Y + 90 < 0) _velocity.Y = 1f;
            if (_position.Y > 700 - hitBox.Height) _position.Y = 700 - hitBox.Height;
        }

        public bool SpikeCollision(Rectangle newRect)
        {
            if (hitBox.TouchTopOf(newRect) || hitBox.TouchLeftOf(newRect) || hitBox.TouchRightOf(newRect) || hitBox.TouchBottomOf(newRect))
            {
                return true;
            }
            return false;
        }
    }
}
