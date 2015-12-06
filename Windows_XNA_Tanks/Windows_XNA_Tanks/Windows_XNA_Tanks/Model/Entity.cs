using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Windows_XNA_Tanks.Model
{
    public abstract class Entity
    {
        private Texture2D _texture;
        private Point _point;
        private Rectangle _rectangle;

        public Entity(Texture2D texture, Point point)
        {
            this.Texture = texture;
            this.Point = point;
            this.Rectangle = new Rectangle(_point.X, _point.Y, 32, 32);
        }

        #region Methods

        public abstract void Update();

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
