﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Windows_XNA_Tanks.Model
{
    public class Tank : Entity
    {

        private Vector2 _origin;

        private float _rotation;

        private Vector2 _velocity;
        const float maxForwardVelocity = 2f;
        const float maxBackwardVelocity = -1f;
        const float _forwardAcceleration = 0.01f;
        const float _backwardAcceleration = 0.005f;
        float _tangentialVelocity;
        float _friction = 0.5f;

        public Tank(Texture2D texture)
            : base(texture)
        {
        
        }

        #region Methods

        public override void Update()
        {

            Rectangle = new Rectangle((int)Position.X, (int)Position.Y, ENTITY_SIZE, ENTITY_SIZE);
            Position = _velocity + Position;
            _origin = new Vector2(Rectangle.Width / 2, Rectangle.Height / 2);

            if (Keyboard.GetState().IsKeyDown(Keys.D)) _rotation += 0.02f;
            if (Keyboard.GetState().IsKeyDown(Keys.A)) _rotation -= 0.02f;
            
            // Forward moving
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                // Making tank accelerate
                if (_tangentialVelocity < maxForwardVelocity)
                {
                    _tangentialVelocity += _forwardAcceleration;
                }

                _velocity.X = (float)Math.Cos(_rotation) * _tangentialVelocity;
                _velocity.Y = (float)Math.Sin(_rotation) * _tangentialVelocity;
            }
            else if (_velocity != Vector2.Zero && !Keyboard.GetState().IsKeyDown(Keys.S))
            {
                float i = _velocity.X;
                float j = _velocity.Y;
                _tangentialVelocity = 0f;

                // Decrease the speed.
                _velocity.X = i -= _friction * i;
                _velocity.Y = j -= _friction * j;
            }

            // Backward moving
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                // Making tank accelerate
                if (_tangentialVelocity > maxBackwardVelocity)
                {
                    _tangentialVelocity -= _backwardAcceleration;
                }

                _velocity.X = (float)Math.Cos(_rotation) * _tangentialVelocity;
                _velocity.Y = (float)Math.Sin(_rotation) * _tangentialVelocity;
            }
            else if (_velocity != Vector2.Zero && !Keyboard.GetState().IsKeyDown(Keys.W))
            {
                float i = _velocity.X;
                float j = _velocity.Y;
                _tangentialVelocity = 0f;

                // Decrease the speed.
                _velocity.X = i += _friction * i;
                _velocity.Y = j += _friction * j;
            }

            
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(Texture, Position, null, Color.White, _rotation, _origin, 1f, SpriteEffects.None, 0);
        }


        public void createPointandRetangle(Vector2 position)
        {
            Position = position;
            Rectangle = new Rectangle((int)Position.X,(int)Position.Y, ENTITY_SIZE, ENTITY_SIZE);
        }

        #endregion Methods

    }
}
