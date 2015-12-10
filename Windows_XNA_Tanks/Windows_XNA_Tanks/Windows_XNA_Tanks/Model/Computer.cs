using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Windows_XNA_Tanks.Model
{
    public class Computer
    {
        public Tank Tank { get; set; }

        public Tank GetClosestTank(List<Tank> tanks)
        {
            Dictionary<Tank, float> distances = new Dictionary<Tank, float>();

            foreach(Tank opponent in tanks)
            {
                if(opponent != Tank)
                    distances.Add(opponent, (float)(Math.Pow(Tank.Position.X - opponent.Position.X, 2) + Math.Pow(Tank.Position.Y - opponent.Position.Y, 2)));
            }

            return distances.OrderBy(e => e.Value).LastOrDefault().Key;
        }

        public void AimToClosestTank(List<Tank> tanks)
        {
            Tank closestTank = GetClosestTank(tanks);
            Tank.Rotation = (float)Math.Atan2(closestTank.Position.Y - Tank.Position.Y, closestTank.Position.X - Tank.Position.X);
        }

        public void MoveToClosestTank()
        {
            Tank.Velocity.X = (float)Math.Cos(Tank.Rotation) * Tank.TangentialVelocity;
            Tank.Velocity.Y = (float)Math.Sin(Tank.Rotation) * Tank.TangentialVelocity;
            Tank.Position = Tank.Velocity + Tank.Position;
        }
    }
}


//Vector2 direction = playerPosition - enemyPosition;
//direction.Normalize();