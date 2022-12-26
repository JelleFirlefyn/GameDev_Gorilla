﻿using gdproject.Input;
using gdproject.States.GameObjects;
using gdproject.States.GameObjects.Score;
using gdproject.States.GameObjects.Terrain;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace gdproject.States
{
    public class GameState : State
    {
        private Hero _gorilla;
        private Texture2D _background;
        private Rectangle _backgroundRect;
        private Map _map1;
        private Map _map2;
        private Score _scoreBoard;
        private Rock _rock;

        public int CurrentLevel { get; set; }


        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, int level) : base(game, graphicsDevice, content)
        {
            Texture2D gorillaTexture = content.Load<Texture2D>("GameAssets/Giant Gorilla Sprite Sheet");
            _background = content.Load<Texture2D>("Backgrounds/gamebackground");

            _gorilla = new Hero(gorillaTexture, new KeyboardReader(), graphicsDevice);

            _backgroundRect = new Rectangle(0, 0, 1500, 800);

            _map1 = new Map(content.Load<Texture2D>("GameAssets/nature-paltformer-tileset-16x16"));
            _map2 = new Map(content.Load<Texture2D>("GameAssets/nature-paltformer-tileset-16x16"));

            CurrentLevel = level;

            _map1.Generate(new int[,]
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
                { 0, 0, 0, 0, 0, 4, 0, 0, 0, 3, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0},
                { 1, 1, 1, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0},
            }, 50);

            _map2.Generate(new int[,]
           {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 4, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 4, 0, 0, 0},
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 4, 0, 0},
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 0, 0, 1, 1, 1, 1, 1, 0},
                { 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 4, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0},
                { 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0},
                { 1, 1, 1, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
           }, 50);

            _scoreBoard = new Score(content);

            _rock = new Rock(content);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_background, _backgroundRect, Color.White);
            _gorilla.Draw(spriteBatch);
            DrawMap(spriteBatch);
            _scoreBoard.Draw(spriteBatch);
            _rock.Draw(spriteBatch);
        }

        private void DrawMap(SpriteBatch spriteBatch)
        {
            if (CurrentLevel == 1)
            {
                _map1.Draw(spriteBatch);
            }
            if (CurrentLevel == 2)
            {
                _map2.Draw(spriteBatch);
            }
        }

        public override void Update(GameTime gameTime)
        {
            _gorilla.Update(gameTime);
            Map tempMap = UpdateLevel();
            CollisionChecks(tempMap);
            _rock.Update(gameTime);
        }

        private Map UpdateLevel()
        {
            Map tempMap = null;

            if (CurrentLevel == 1)
            {
                tempMap = _map1;

                if (_scoreBoard.LvlScorePoints == 10)
                {
                    CurrentLevel = 2;
                }
            }
            if (CurrentLevel == 2)
            {
                tempMap = _map2;
                if (_scoreBoard.LvlScorePoints == 10 && _scoreBoard.ScorePoints != 10)
                {
                    game.ChangeState(new EndGameState(game, graphicsDevice, content, false));
                }
            }

            return tempMap;
        }

        private void CollisionChecks(Map tempMap)
        {
            foreach (TerrainElement ele in tempMap.TerrainElements)
            {
                if (ele.BlockKind == Block.spike)
                {
                    if (_gorilla.SpikeCollision(ele.HitBox)) game.ChangeState(new EndGameState(game, graphicsDevice, content, true));
                }
                else _gorilla.Collision(ele.HitBox, 1500);
            }

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
    }
}
