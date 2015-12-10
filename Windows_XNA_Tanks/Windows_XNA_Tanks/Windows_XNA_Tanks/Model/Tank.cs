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

        public Vector2 Velocity;

        const float maxForwardVelocity = 2f;
        const float maxBackwardVelocity = -1f;
        const float _forwardAcceleration = 0.01f;
        const float _backwardAcceleration = 0.005f;
        float _tangentialVelocity;
        float _friction = 0.5f;

        public Tank(Texture2D texture)
            : base(texture)
        {
            Rectangle = new Rectangle((int)Position.X, (int)Position.Y, ENTITY_SIZE, ENTITY_SIZE);
            _origin = new Vector2(Rectangle.Width / 2, Rectangle.Height / 2);
        }

        public float Rotation
        {
            get
            {
                return _rotation;
            }
            set
            {
                _rotation = value;
            }
        }

        public float TangentialVelocity
        {
            get
            {
                return _tangentialVelocity;
            }
            set
            {
                _tangentialVelocity = value;
            }
        }

        #region Methods

        public override void Update()
        {
            Position = Velocity + Position;            
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(Texture, Position, null, Color.White, _rotation, _origin, 1f, SpriteEffects.None, 0);
        }

        public void MoveForward()
        {
            // Making tank accelerate forward
            if (_tangentialVelocity < maxForwardVelocity)
            {
                _tangentialVelocity += _forwardAcceleration;
            }

            Velocity.X = (float)Math.Cos(_rotation) * _tangentialVelocity;
            Velocity.Y = (float)Math.Sin(_rotation) * _tangentialVelocity;
        }

        public void StopMovingForward()
        {
            float i = Velocity.X;
            float j = Velocity.Y;
            _tangentialVelocity = 0f;

            // Decrease the speed.
            Velocity.X = i -= _friction * i;
            Velocity.Y = j -= _friction * j;
        }

        public void MoveBackward()
        {
            // Making tank accelerate backward
            if (_tangentialVelocity > maxBackwardVelocity)
            {
                _tangentialVelocity -= _backwardAcceleration;
            }

            Velocity.X = (float)Math.Cos(_rotation) * _tangentialVelocity;
            Velocity.Y = (float)Math.Sin(_rotation) * _tangentialVelocity;
        }

        public void StopMovingBackward()
        {
            float i = Velocity.X;
            float j = Velocity.Y;
            _tangentialVelocity = 0f;

            // Decrease the speed.
            Velocity.X = i += _friction * i;
            Velocity.Y = j += _friction * j;
        }

        public void RotateRight()
        {
            _rotation += 0.02f;
        }
        
        public void RotateLeft()
        {
            _rotation -= 0.02f;
        }



        public void createPointAndRectangle(Vector2 position)
        {
            Position = position;
            Rectangle = new Rectangle((int)Position.X,(int)Position.Y, ENTITY_SIZE, ENTITY_SIZE);
        }

        #endregion Methods

    }
}
