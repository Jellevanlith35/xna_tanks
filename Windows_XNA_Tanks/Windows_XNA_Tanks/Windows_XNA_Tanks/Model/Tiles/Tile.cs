using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Windows_XNA_Tanks.Model.Tiles
{
    public abstract class Tile
    {
        public Texture2D _texture;
        private Color[] _textureData;
        public Point _point;
        public Rectangle _rectangle;

        public Tile Left { get; set;}
        public Tile Top { get; set; }
        public Tile Right { get; set; }
        public Tile Bottom { get; set; }

        #region Methods

        public Tile(Texture2D texture, Point point)
        {
            this.Texture = texture;
            _textureData = new Color[Texture.Width * texture.Height];
            Texture.GetData(_textureData);
            this.Point = point;
            this.Rectangle = new Rectangle(_point.X, _point.Y, 32, 32);
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(_texture, _rectangle, Color.White);
        }

        public virtual bool IsSolid()
        {
            return false;
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
