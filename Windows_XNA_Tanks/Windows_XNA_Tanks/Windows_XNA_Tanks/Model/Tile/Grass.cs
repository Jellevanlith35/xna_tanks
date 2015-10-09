using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Windows_XNA_Tanks.Model.Tile
{
    class Grass : Entity
    {
        public Grass(ContentManager content)
        {
            Texture = content.Load<Texture2D>("grass");
        }
    }
}
