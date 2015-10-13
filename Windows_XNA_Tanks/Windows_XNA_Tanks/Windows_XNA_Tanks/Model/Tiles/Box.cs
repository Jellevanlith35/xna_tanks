using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace Windows_XNA_Tanks.Model.Tiles
{
    class Box : Tile
    {
        public Box(ContentManager content)
        {
            Texture = content.Load<Texture2D>("tiles/box");
        }
    }
}
