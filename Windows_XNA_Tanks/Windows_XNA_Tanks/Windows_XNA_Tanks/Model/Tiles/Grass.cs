using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Windows_XNA_Tanks.Model.Tiles
{
    class Grass : Tile
    {
        public Grass(ContentManager content)
        {
            Texture = content.Load<Texture2D>("tiles/grass");
        }
    }
}
