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
        private Color[] _textureData;
        private Map _map;
        

        public Entity(Texture2D texture)
        {
            this.Texture = texture;

            _textureData = new Color[Texture.Width * texture.Height];
            Texture.GetData(_textureData);
        }

        #region Methods

        public abstract void Update();

        public virtual void Draw(SpriteBatch spritebatch)
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

        public Color[] TextureData
        {
            get { return _textureData; }
            set { _textureData = value; }
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

        public Map Map
        {
            get { return _map; }
            set { _map = value; }
        }

        #endregion Properties
    }
}
