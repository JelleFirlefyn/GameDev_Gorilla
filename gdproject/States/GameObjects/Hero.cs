using gdproject.Animation;
using gdproject.Input;
using gdproject.Interfaces;
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
    public class Hero : IGameObject
    {
        Texture2D heroTexture;
        AnimationManager animatie;

        private Vector2 position;
        private Vector2 velocity;
        private Rectangle destRect;
        private SpriteEffects spriteEffect;
        private bool hasJumped;
        private IInputReader inputReader;
        //COLLISION TESTING
        Rectangle hitBox;
        Texture2D blokTexture;


        public Hero(Texture2D texture, IInputReader inputReader, GraphicsDevice graphicsDevice)
        {
            heroTexture = texture;
            animatie = new AnimationManager(inputReader);
            this.inputReader = inputReader;
            position = new Vector2(70f, 646.8f);
            //COLLISION TESTING
            blokTexture = new Texture2D(graphicsDevice, 1, 1);
            blokTexture.SetData(new[] { Color.White });


            hasJumped = true;
        }

        public void Update(GameTime gameTime)
        {
            Move();

            destRect = new Rectangle((int)position.X, (int)position.Y, 100, 100);
            hitBox = new Rectangle((int)position.X + 15, (int)position.Y + 35, 65, 65);

            animatie.Update(gameTime);
        }

        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            //COLLISION TESTING
            spriteBatch.Draw(blokTexture, hitBox, Color.Red);
        
            spriteBatch.Draw(heroTexture, destRect, animatie.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), spriteEffect, 0f);
        }

        private void Move()
        {
            //Bron: https://www.youtube.com/watch?v=ZLxIShw-7ac&t=139s&ab_channel=Oyyou
            //Flip sprite bron: https://stackoverflow.com/questions/6146337/how-to-flip-a-sprite-in-c-sharp

            position += velocity;
            Movement movement = inputReader.ReadInput();

            if(velocity.Y < 10)
            {
                velocity.Y += 0.4f;
            }

            if (movement == Movement.right)
            {
                if (hasJumped) velocity.X = 4.5f;
                else velocity.X = 3f;

                spriteEffect = SpriteEffects.None;
            }
            else if (movement == Movement.left)
            {
                if (hasJumped) velocity.X = -4.5f;
                else velocity.X = -3f;

                spriteEffect = SpriteEffects.FlipHorizontally;
            }
            else velocity.X = 0;

            if (movement == Movement.up && !hasJumped)
            {
                position.Y -= 10f;
                velocity.Y = -16f;
                hasJumped = true;
            }

            if (hasJumped)
            {
                float i = 1;
                velocity.Y += 0.55f * i;
            }

            if (position.Y + heroTexture.Height >= 1260)
            {
                hasJumped = false;
            }
        }

        public void Collision(Rectangle newRect, int screenWidth)
        {
            if (hitBox.TouchTopOf(newRect))
            {
                hitBox.Y = newRect.Y - hitBox.Height;
                velocity.Y = 0f;
                hasJumped = false;
            }

            if (hitBox.TouchLeftOf(newRect))
            {
                position.X = newRect.X - hitBox.Width - 2;
            }

            if (hitBox.TouchRightOf(newRect))
            {
                position.X = newRect.X + hitBox.Width + 2;
            }

            if (hitBox.TouchBottomOf(newRect))
            {
                velocity.Y = 1f;
            }

            if (position.X < 0) position.X = 0;
            if (position.X > screenWidth - hitBox.Width) position.X = screenWidth - hitBox.Width;
            if (position.Y < 0) velocity.Y = 1f;
            if (position.Y > 700 - hitBox.Height) position.Y = 700 - hitBox.Height;
        }
    }
}
