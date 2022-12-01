using gdproject.Animation;
using gdproject.Input;
using gdproject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gdproject
{
    public class Hero : IGameObject
    {
        Texture2D heroTexture;
        AnimationManager animatie;
        
        private Vector2 position;
        private Vector2 velocity;
        private bool hasJumped;
        private IInputReader inputReader;


        public Hero(Texture2D texture, IInputReader inputReader)
        {
            this.heroTexture = texture;
            this.animatie = new AnimationManager(inputReader);
            this.inputReader = inputReader;
            
            hasJumped = true;  
    }

        public void Update(GameTime gameTime)
        {
            Move();
            animatie.Update(gameTime);
        }

        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(heroTexture, position, animatie.CurrentFrame.SourceRectangle, Color.White);
        }

        private void Move()
        {
            //Bron: https://www.youtube.com/watch?v=ZLxIShw-7ac&t=139s&ab_channel=Oyyou

            position += velocity;
            Movement movement = inputReader.ReadInput();

            if (movement == Movement.right) velocity.X = 3f;
            else if (movement == Movement.left) velocity.X = -3f;
            else velocity.X = 0;

            if (movement == Movement.up && !hasJumped)
            {
                position.Y -= 10f;
                velocity.Y = -15f;
                hasJumped = true;
            }

            if (hasJumped)
            {
                float i = 1;
                velocity.Y += 0.55f * i;
            }
            else
            {
                velocity.Y = 0f;
            }

            if (position.Y + heroTexture.Height >= 1250)
            {
                hasJumped = false;
            }
        }
    }
}
