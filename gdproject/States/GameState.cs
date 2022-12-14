using gdproject.Input;
using gdproject.States.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace gdproject.States
{
    public class GameState : State
    {
        private Hero _gorilla;
        private Texture2D _background;
        private Rectangle _backgroundRect;
        private Map _map;
        private Score _scoreBoard;


        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            Texture2D gorillaTexture = content.Load<Texture2D>("Giant Gorilla Sprite Sheet");
            _background = content.Load<Texture2D>("gamebackground");

            _gorilla = new Hero(gorillaTexture, new KeyboardReader(), graphicsDevice);

            _backgroundRect = new Rectangle(0, 0, 1500, 800);

            _map = new Map(content.Load<Texture2D>("nature-paltformer-tileset-16x16"));

            _map.Generate(new int[,]
            {
               { 0, 0,0, 0, 0, 0,0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0, 0, 0, 0, 0,0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0,0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0, 0, 0, 0, 0,0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0,0, 0, 0, 0,0, 0, 0, 0, 0, 0, 1, 0, 0, 0,0, 0, 0, 0, 0,1, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0,0, 0, 0, 0,0, 0, 0, 0, 0, 0, 1, 0, 0, 0,0, 0, 0, 0, 0,0, 0, 0, 0, 0, 2, 0, 0, 0},
                { 0, 0,1, 0, 0, 0,0, 0, 0, 0, 0, 0, 1, 0, 0, 0,0, 0, 0, 0, 0,0, 0, 0, 0, 0, 2, 0, 0, 0 },
                { 0, 0,0, 0, 0, 0,0, 0, 0, 0, 0, 0, 1, 0, 0, 0,0, 0, 0, 0, 0,0, 0, 0, 0, 0, 2, 0, 0, 0},
                { 0, 0,0, 0, 0, 0,0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0, 0, 0, 0, 0,0, 0, 0, 0, 2, 2, 2, 0, 0},
                { 0, 0,0, 0, 0, 0,0, 0, 0, 0, 0, 2, 0, 0, 0, 1,0, 0, 0, 1, 1,1, 0, 0, 1, 1, 1, 1, 1, 0},
                { 0, 0,0, 0, 0, 0,0, 0, 0, 0, 0, 0, 1, 1, 1, 1,0, 0, 0, 0, 0,0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0,0, 0, 0, 2,0, 0, 0, 0, 0, 0, 1, 0, 0, 0,0, 0, 0, 0, 0,2, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0,0, 0, 0, 0,0, 0, 1, 1, 1, 1, 1, 0, 0, 0,0, 0, 0, 0, 0,0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 1, 0,0, 0, 0, 0,0, 0, 1, 0, 0, 0, 0, 0, 2, 0,0, 0, 0, 0, 1,1, 1, 0, 0, 0, 0, 0, 0, 0},
                { 1, 1,1, 0, 0, 1,1, 1, 1, 0, 0, 0, 0, 0, 0, 0,0, 0, 0, 0, 0,0, 1, 1, 1, 1, 1, 0, 0, 0},
            }, 50);

            _scoreBoard = new Score(content);   
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_background, _backgroundRect, Color.White);
            _gorilla.Draw(spriteBatch);
            _map.Draw(spriteBatch);
            _scoreBoard.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            _gorilla.Update(gameTime);

            foreach(TerrainElement ele in _map.TerrainElements)
            {
                _gorilla.Collision(ele.HitBox, 1500);
            }

            for (int i = 0; i < _map.Coins.Count; i++)
            {
                if (_map.Coins[i] != null)
                {
                    if (_map.Coins[i].HitBox.Intersects(_gorilla.HitBox))
                    {
                        _map.Coins[i] = null;
                        _scoreBoard.AddPoint();
                    }
                }
            }
        }
    }
}
