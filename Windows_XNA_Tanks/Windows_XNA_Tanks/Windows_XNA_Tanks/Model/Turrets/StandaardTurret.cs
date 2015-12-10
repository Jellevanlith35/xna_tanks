using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows_XNA_Tanks.Interfaces;

namespace Windows_XNA_Tanks.Model.Turrets
{
    public abstract class StandaardTurret : ITurret
    {

        private Texture2D _texture;
        private Rectangle _rectangle;
        private Vector2 _positionOnTank;
        private float _rotation;
        private Vector2 _origin;

        public void StandaardTurret()
        {
            _rectangle = new Rectangle((int)_positionOnTank.X, (int)_positionOnTank.Y, _texture.Width, _texture.Height);
            _origin = new Vector2(_rectangle.Width / 2, _rectangle.Height / 2);
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(_texture, _positionOnTank, null, Color.White, _rotation, _origin, 1f, SpriteEffects.None, 0);
        }

        public void Shoot()
        {

        }
        public void Reload()
        {

        }
        public void TurnLeft()
        {
            _rotation -= 0.02f;
        }
        public void TurnRight()
        {
            _rotation += 0.02f;
        }

        public Vector2 PositionOnTank
        {
            get { return _positionOnTank; }
            set { _positionOnTank = value; }
        }

        public Texture2D Texture
        {
            get { return _texture; }
            set { _texture = value; }
        }
    }
}
