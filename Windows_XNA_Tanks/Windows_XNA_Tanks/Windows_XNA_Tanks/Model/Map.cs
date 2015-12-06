using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Windows_XNA_Tanks.Model.Tiles;

namespace Windows_XNA_Tanks.Model
{
    class Map
    {

        public int Height { get; set; }
        public int Width { get; set; }
        public Tile Origin { get; set; }
        public List<Point> startPoints;

        public Map()
        {
            startPoints = new List<Point>();
        }
        
        public void Drawmap(SpriteBatch spritebatch)
        {
            Tile outerTile = Origin;

            while (outerTile != null)
            {
                Tile innerTile = outerTile;

                while (innerTile != null)
                {
                    innerTile.Draw(spritebatch);
                    innerTile = innerTile.Right;
                }

                outerTile = outerTile.Bottom;
            }
        }
    }
}
