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

        public Map()
        {
           _tanks = new List<Tank>();
        }
        
        public List<Tank> Tanks
        {
            get { return _tanks; }
            set { _tanks = value; }
        }

        public void Drawmap(SpriteBatch spritebatch)
        {

        }
    }
}
