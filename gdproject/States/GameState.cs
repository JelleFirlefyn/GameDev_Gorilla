using gdproject.Input;
using gdproject.States.GameObjects;
using gdproject.States.GameObjects.Enemies;
using gdproject.States.GameObjects.Score;
using gdproject.States.GameObjects.Terrain;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace gdproject.States
{
    public class GameState : State
    {
        private Hero _gorilla;
        private Texture2D _background;
        private Rectangle _backgroundRect;
        private List<Map> _maps;
        private Score _scoreBoard;
        private Rock _rock;
        private Barrel _barrel;
        private List<Enemy> _enemies;

        public int CurrentLevel { get; set; }


        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, int level) : base(game, graphicsDevice, content)
        {
            Texture2D gorillaTexture = content.Load<Texture2D>("GameAssets/Giant Gorilla Sprite Sheet");
            _gorilla = new Hero(gorillaTexture, new KeyboardReader(), graphicsDevice);

            _background = content.Load<Texture2D>("Backgrounds/gamebackground");
            _backgroundRect = new Rectangle(0, 0, 1500, 800);

            _maps = new List<Map>();
            for (int i = 0; i < 2; i++)
            {
                _maps.Add(new Map(content.Load<Texture2D>("GameAssets/nature-paltformer-tileset-16x16")));
            }
            GenerateMaps();

            CurrentLevel = level;

            _scoreBoard = new Score(content);

            _enemies = new List<Enemy>();
            _enemies.Add(new Rock(content));
            _enemies.Add(new Barrel(content));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_background, _backgroundRect, Color.White);
            DrawMap(spriteBatch);
            _gorilla.Draw(spriteBatch);
            _scoreBoard.Draw(spriteBatch);
            foreach (Enemy enemy in _enemies)
            {
                enemy?.Draw(spriteBatch);    
            }
        }

        private void DrawMap(SpriteBatch spriteBatch)
        {
            if (CurrentLevel == 1)
            {
                _maps[0].Draw(spriteBatch);
            }
            if (CurrentLevel == 2)
            {
                _maps[1].Draw(spriteBatch);
            }
        }

        public override void Update(GameTime gameTime)
        {
            _gorilla.Update(gameTime);
            Map tempMap = UpdateLevel();
            CollisionTerrain(tempMap);
            CollisionCoins(tempMap);
            for (int i = 0; i < _enemies.Count; i++)
            {
                _enemies[i]?.Update(gameTime);
                if (_enemies[i] is Rock)
                {
                    Rock temp = _enemies[i] as Rock;
                    temp.Spawn((int)_gorilla.Position.X);
                    CollisionRock(_enemies[i]);
                }
                else
                {
                    Barrel temp = _enemies[i] as Barrel;
                    if (temp.SideCollision(_gorilla.HitBox))
                    {
                        game.ChangeState(new EndGameState(game, graphicsDevice, content, true));
                    }
                    if (temp.TopCollision(_gorilla.HitBox))
                    {
                        _enemies.RemoveAt(i);
                    }
                }
            }
            
        }

        private Map UpdateLevel()
        {
            Map tempMap = null;

            if (CurrentLevel == 1)
            {
                tempMap = _maps[0];

                if (_scoreBoard.ScorePoints == 10)
                {
                    CurrentLevel = 2;
                }
            }
            if (CurrentLevel == 2)
            {
                tempMap = _maps[1];
                if (_scoreBoard.ScorePoints == 20)
                {
                    game.ChangeState(new EndGameState(game, graphicsDevice, content, false));
                }
            }

            return tempMap;
        }

        private void CollisionTerrain(Map tempMap)
        {
            foreach (TerrainElement ele in tempMap.TerrainElements)
            {
                if (ele.BlockKind == Block.spike)
                {
                    if (_gorilla.SpikeCollision(ele.HitBox)) game.ChangeState(new EndGameState(game, graphicsDevice, content, true));
                }
                else _gorilla.Collision(ele.HitBox, 1500);
            }
        }

        private void CollisionCoins(Map tempMap)
        {
            for (int i = 0; i < tempMap.Coins.Count; i++)
            {
                if (tempMap.Coins[i] != null)
                {
                    if (tempMap.Coins[i].HitBox.Intersects(_gorilla.HitBox))
                    {
                        tempMap.Coins[i] = null;
                        _scoreBoard.AddPoint();
                    }
                }
            }
        }

        private void CollisionRock(Enemy en)
        {
            Rock temp = en as Rock;
            if (temp.HitBox.Intersects(_gorilla.HitBox) && temp.isFalling)
            {
                game.ChangeState(new EndGameState(game, graphicsDevice, content, true));
            }
        }

        private void CollisionBarrel(Enemy en)
        {
            Barrel temp = en as Barrel;
            if (temp != null)
            {
                if (temp.SideCollision(_gorilla.HitBox))
                {
                    game.ChangeState(new EndGameState(game, graphicsDevice, content, true));
                }
                if (temp.TopCollision(_gorilla.HitBox))
                {
                    en = null;
                }
            }

        }

        private void GenerateMaps()
        {
            _maps[0].Generate(new int[,]
            {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0},
                { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 1, 0, 0, 0, 1, 1, 1, 0, 0, 2, 2, 2, 2, 2, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0},
                { 3, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 1, 1, 1, 3, 0, 0, 0, 0, 0, 0},
                { 1, 1, 1, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0},
            }, 50);

            _maps[1].Generate(new int[,]
           {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 4, 0, 0},
                { 3, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 4, 0, 0, 0},
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 0, 0, 1, 1, 1, 1, 1, 0},
                { 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 4, 1, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 4, 0, 0, 0},
                { 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0},
                { 1, 1, 1, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
           }, 50);
        }
    }
}
