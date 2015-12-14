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
        private Tank closestTank;

        public Tank GetClosestTank(List<Tank> tanks)
        {
            Dictionary<Tank, float> distances = new Dictionary<Tank, float>();

            foreach(Tank opponent in tanks)
            {
                if(opponent != Tank)
                    distances.Add(opponent, Vector2.Distance(Tank.Position, opponent.Position));
            }

            return distances.OrderBy(e => e.Value).LastOrDefault().Key;
        }

        public void AimToClosestTank(List<Tank> tanks)
        {
            closestTank = GetClosestTank(tanks);
            Tank.Rotation = (float)Math.Atan2(closestTank.Position.Y - Tank.Position.Y, closestTank.Position.X - Tank.Position.X);

            MoveToClosestTank();
        }

        public void MoveToClosestTank()
        {
            Tank.MoveForward();
            if (Vector2.Distance(Tank.Position, closestTank.Position) <= 100)
                Tank.StopMovingForward();
        }
    }
}
