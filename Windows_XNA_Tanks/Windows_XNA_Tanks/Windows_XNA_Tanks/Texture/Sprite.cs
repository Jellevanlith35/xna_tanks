using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Windows_XNA_Tanks.Texture
{
    class Sprite
    {
        private Texture2D _texture;
        private ContentManager _content;

        public Sprite(ContentManager cm)
        {
            _content = cm;
            this.loadContent();
        }

        public void loadContent(){

            _content.Load<Texture2D>("grass");

        }
    }
}
