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


        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            Texture2D gorillaTexture = content.Load<Texture2D>("Giant Gorilla Sprite Sheet");
            _background = content.Load<Texture2D>("gamebackground");

            _gorilla = new Hero(gorillaTexture, new KeyboardReader(), graphicsDevice);

            _backgroundRect = new Rectangle(0, 0, 1500, 800);

            _map = new Map(content.Load<Texture2D>("nature-paltformer-tileset-16x16"));

            _map.Generate(new bool[,]
            {
                { false, false,false, false, false, false,false, false, false, false, false, false, false, false, false, false,false, false, false, false, false,false, false, false, false, false, false, false, false, false},
                { false, false, false, false, false, false,false, false, false, false, false, false, false, false, false, false,false, false, false, false, false,false, false, false, false, false, false, false, false, false},
                { false, false,false, false, false, false,false, false, false, false, false, false, true, false, false, false,false, false, false, false, false,true, false, false, false, false, false, false, false, false},
                { false, false,false, false, false, false,false, false, false, false, false, false, true, false, false, false,false, false, false, false, false,false, false, false, false, false, false, false, false, false},
                { false, false,true, false, false, false,false, false, false, false, false, false, true, false, false, false,false, false, false, false, false,false, false, false, false, false, false, false, false, false },
                { false, false,false, false, false, false,false, false, false, false, false, false, true, false, false, false,false, false, false, false, false,false, false, false, false, false, false, false, false, false},
                { false, false,false, false, false, false,false, false, false, false, false, false, false, false, false, false,false, false, false, false, false,false, false, false, false, false, false, false, false, false},
                { false, false,false, false, false, false,false, false, false, false, false, false, false, false, false, true,false, false, false, true, true,true, false, false, true, true, true, true, true, false},
                { false, false,false, false, false, false,false, false, false, false, false, false, true, true, true, true,false, false, false, false, false,false, false, false, false, false, false, false, false, false},
                { false, false,false, false, false, false,false, false, false, false, false, false, true, false, false, false,false, false, false, false, false,false, false, false, false, false, false, false, false, false},
                { false, false,false, false, false, false,false, false, true, true, true, true, true, false, false, false,false, false, false, false, false,false, false, false, false, false, false, false, false, false},
                { true, false,false, false, false, false,false, false, true, false, false, false, false, false, false, false,false, false, false, false, true,true, true, false, false, false, false, false, false, false},
                { true, true,true, false, false, true,true, true, true, false, false, false, false, false, false, false,false, false, false, false, false,false, true, true, true, true, true, false, false, false},
            }, 50);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_background, _backgroundRect, Color.White);
            _gorilla.Draw(gameTime, spriteBatch);
            _map.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            _gorilla.Update(gameTime);

            foreach(TerrainElement ele in _map.TerrainElements)
            {
                _gorilla.Collision(ele.DestRect, 1500);
            }
        }
    }
}
