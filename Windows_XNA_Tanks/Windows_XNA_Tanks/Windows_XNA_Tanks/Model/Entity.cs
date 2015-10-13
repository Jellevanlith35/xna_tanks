using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Windows_XNA_Tanks.Model
{
    abstract class Entity
    {
        private Texture2D _texture;
        private Point _point;
        private Rectangle _rectangle;

        #region Methods

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(_texture, _rectangle, Color.White);
        }
        #endregion Methods

        #region Properties

        public Texture2D Texture
        {            
           get { return _texture; }
           set { _texture = value; }
        }

        public Point Point 
        {
            get { return _point; }
            set { _point = value; }
        }

        public Rectangle Rectangle
        {
            get { return _rectangle; }
            set { _rectangle = value; }
        }


        #endregion Properties
    }
}
