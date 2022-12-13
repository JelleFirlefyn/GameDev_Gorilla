using gdproject.Input;
using gdproject.States.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace gdproject.States
{
    public class GameState : State
    {
        private Hero gorilla;
        private Texture2D background;
        private Rectangle backgroundRect;
        Map map;


        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            Texture2D gorillaTexture = content.Load<Texture2D>("Giant Gorilla Sprite Sheet");
            background = content.Load<Texture2D>("gamebackground");

            gorilla = new Hero(gorillaTexture, new KeyboardReader(), graphicsDevice);

            backgroundRect = new Rectangle(0, 0, 1500, 800);

            map = new Map(content.Load<Texture2D>("nature-paltformer-tileset-16x16"));

            map.Generate(new bool[,]
            {
                { false, false,false, false, false, false,false, false, false, false, false, false, false, false, false, false,false, false, false, false, false,false, false, false, false, false, false, false, false, false},
                { false, false, false, false, false, false,false, false, false, false, false, false, false, false, false, false,false, false, false, false, false,false, false, false, false, false, false, false, false, false},
                { false, false,false, false, false, false,false, false, false, false, false, false, false, false, false, false,false, false, false, false, false,true, false, false, false, false, false, false, false, false},
                { false, false,false, false, false, false,false, false, false, false, false, false, false, false, false, false,false, false, false, false, false,false, false, false, false, false, false, false, false, false},
                { false, false,true, false, false, false,false, false, false, false, false, false, false, false, false, false,false, false, false, false, false,false, false, false, false, false, false, false, false, false },
                { false, false,false, false, false, false,false, false, false, false, false, false, false, false, false, false,false, false, false, false, false,false, false, false, false, false, false, false, false, false},
                { false, false,false, false, false, false,false, false, false, false, false, false, false, false, false, false,false, false, false, false, false,false, false, false, false, false, false, false, false, false},
                { false, false,false, false, false, false,false, false, false, false, false, false, false, false, false, true,false, false, false, true, true,true, false, false, true, true, true, true, true, false},
                { false, false,false, false, false, false,false, false, false, false, false, false, true, true, true, true,false, false, false, false, false,false, false, false, false, false, false, false, false, false},
                { false, false,false, false, false, false,false, false, false, false, false, false, true, false, false, false,false, false, false, false, false,false, false, false, false, false, false, false, false, false},
                { false, false,false, false, false, false,false, false, true, true, true, true, true, false, false, false,false, false, false, false, false,false, false, false, false, false, false, false, false, false},
                { false, false,false, false, false, false,false, false, true, false, false, false, false, false, false, false,false, false, false, false, false,false, false, false, false, false, false, false, false, false},
                { false, false,false, false, true, true,true, true, true, false, false, false, false, false, false, false,false, false, false, false, false,false, false, false, false, false, false, false, false, false},
            }, 50);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, backgroundRect, Color.White);
            gorilla.Draw(spriteBatch);
            map.Draw(spriteBatch);
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void Update(GameTime gameTime)
        {
            gorilla.Update(gameTime);

            foreach(TerrainElement ele in map.TerrainElements)
            {
                gorilla.Collision(ele.DestRect, 1500);
            }
        }
    }
}
