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

            this.TextureData = new Color[Texture.Width * texture.Height];
            Texture.GetData(TextureData);
        }

        #region Methods

        public abstract void Update();

        public virtual void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(_texture, _rectangle, Color.White);
        }

        static bool IntersectPixel(Rectangle rect1, Color[] data1,
                                   Rectangle rect2, Color[] data2)
        {
            int top = Math.Max(rect1.Top, rect2.Top);
            int bottom = Math.Min(rect1.Bottom, rect2.Bottom);
            int left = Math.Max(rect1.Left, rect2.Left);
            int right = Math.Min(rect1.Right, rect2.Right);

            for (int y = top; y < bottom; y++)
            {
                for (int x = left; x < right; x++)
                {
                    Color colour1 = data1[(x - rect1.Left) + (y - rect1.Top) * rect1.Width];
                    Color colour2 = data2[(x - rect2.Left) + (y - rect2.Top) * rect2.Width];

                    if (colour1.A != 0 && colour2.A != 0)
                        return true;
                }
            }

            return false;
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

        public Color[] TextureData
        {
            get { return _textureData; }
            set { _textureData = value; }
        }

        public Map Map
        {
            get { return _map; }
            set { _map = value; }
        }

        #endregion Properties
    }
}
