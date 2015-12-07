using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Windows_XNA_Tanks.Model
{
    class Player
    {
        public List<Tank> tanks;
        public Tank UsedTank { get; set; }

        public Player() 
        {
            tanks = new List<Tank>();
        }

        public void addTanktoPlayersTanks(Tank tank)
        {
            tanks.Add(tank);
        }

        public void removeTankfromPlayersTanks(Tank tank)
        {
            tanks.Remove(tank);
        }


    }
}
