using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Windows_XNA_Tanks_Map_Builder.Model
{
    public class Grid
    {
        private int x;
        private int y;
        public Texture2D[,] Tiles { get; set; }

        public Grid(int x, int y, ContentManager content)
        {
            this.x = x;
            this.y = y;
            Tiles = new Texture2D[x + 1, y + 1];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Tiles[i, j] = content.Load<Texture2D>("Tiles/grid");
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, int tileSize)
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    spriteBatch.Draw(Tiles[i, j], new Rectangle(i * tileSize, j * tileSize, tileSize, tileSize), Color.White);
                }
            }
        }
    }
}
