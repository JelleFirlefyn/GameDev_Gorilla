using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gdproject.States.GameObjects
{
    internal class Score : IGameObject
    {
		private SpriteFont _font;

		private int scorePoints;

		public int ScorePoints
		{
			get { return scorePoints; }
			set 
			{
				if (value > 0)
				{
                    scorePoints = value;
                }
			}
		}

		public Rectangle HitBox { get; set; }

		public Score(ContentManager content)
		{
			_font = content.Load<SpriteFont>("Arial");

        }

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.DrawString(_font, ScorePoints.ToString(), new Vector2(750, 10), Color.Black, 0f, new	Vector2(0,0), 5f, SpriteEffects.None, 0f);
		}

		public void AddPoint()
		{
			ScorePoints++;
		}
	}
}
