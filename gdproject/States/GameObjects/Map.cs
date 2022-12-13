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

        private Texture2D tileset;

        public Map(Texture2D tilesetTexture)
        {
            tileset = tilesetTexture;
        }

        public void Generate(bool[,] map, int size)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    if (map[y,x])
                    {
                        TerrainElements.Add(new TerrainElement(new Rectangle(x * size, y * size, size, size), tileset));
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var elements in TerrainElements)
            {
                elements.Draw(spriteBatch);
            }
        }
    }
}
