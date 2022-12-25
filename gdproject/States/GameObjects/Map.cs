using gdproject.States.GameObjects.Score;
using gdproject.States.GameObjects.Terrain;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace gdproject.States.GameObjects
{
    internal class Map
    {
        private List<TerrainElement> _terrainElements = new List<TerrainElement>();
        public List<TerrainElement> TerrainElements
        {
            get { return _terrainElements; }
        }

        private List<Coin> coins = new List<Coin>();
        public List<Coin> Coins
        {
            get { return coins; }
        }

        private Texture2D tileset;

        public Map(Texture2D tilesetTexture)
        {
            tileset = tilesetTexture;
        }

        public void Generate(int[,] map, int size)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    switch (map[y,x])
                    {
                        case 1:
                            TerrainElements.Add(new TerrainElement(new Rectangle(x * size, y * size, size, size), tileset, Block.brick));
                            break;
                        case 2:
                            TerrainElements.Add(new TerrainElement(new Rectangle(x * size, y * size, size, size), tileset, Block.grass));
                            break;
                        case 3:
                            TerrainElements.Add(new TerrainElement(new Rectangle(x * size, y * size, size, size), tileset, Block.spike));
                            break;
                        case 4:
                            Coins.Add(new Coin(new Rectangle(x * size, y * size, size, size), tileset));
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (TerrainElement elements in TerrainElements)
            {
                elements.Draw(spriteBatch);
            }

            foreach (Coin elements in Coins)
            {
                elements?.Draw(spriteBatch);
            }
        }
    }
}
