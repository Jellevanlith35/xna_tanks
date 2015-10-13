using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Windows_XNA_Tanks.Model.Tiles
{
    class Wall : Tile
    {
        public Wall(ContentManager content)
        {
            Texture = content.Load<Texture2D>("tiles/wall");
        }
    }
}
