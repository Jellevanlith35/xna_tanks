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
        public const int ENTITY_SIZE = 32;

        private Texture2D _texture;
        private Rectangle _rectangle;
        private Vector2 _position;

        public Entity(Texture2D texture)
        {
            this.Texture = texture;
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

        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public Rectangle Rectangle
        {
            get { return _rectangle; }
            set { _rectangle = value; }
        }


        #endregion Properties
    }
}
