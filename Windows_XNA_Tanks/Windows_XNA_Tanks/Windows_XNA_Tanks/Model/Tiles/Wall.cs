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
        Texture2D texture;
      
        public Wall(Texture2D texture)
        {
            this.texture = texture;
        }

    }
}
