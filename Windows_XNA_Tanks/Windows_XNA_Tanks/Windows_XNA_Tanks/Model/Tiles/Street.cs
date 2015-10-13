using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Windows_XNA_Tanks.Model.Tiles
{
    class Street : Tile
    {
        public Street(ContentManager content)
        {
            Texture = content.Load<Texture2D>("tiles/street");
        }
    }
}
