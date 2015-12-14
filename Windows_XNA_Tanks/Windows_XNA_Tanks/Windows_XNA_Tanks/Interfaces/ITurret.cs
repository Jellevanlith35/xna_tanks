using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows_XNA_Tanks.Model;

namespace Windows_XNA_Tanks.Interfaces
{
    public interface ITurret
    {
        Texture2D Texture { get; set; }
        Rectangle Rectangle { get; set; }
        Vector2 PositionOnTank { get; set; }
        float Rotation { get; set; }
        Vector2 Origin { get; set; }
        Tank Tank { get; set; }

        void Shoot();
        void Reload();
        void TurnLeft();
        void TurnRight();
        void Draw(SpriteBatch spritebatch);
        void Update();
    }
}
