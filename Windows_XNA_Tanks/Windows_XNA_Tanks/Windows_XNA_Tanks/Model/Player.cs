using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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

        public void Update()
        {

            if (Keyboard.GetState().IsKeyDown(Keys.D)) UsedTank.RotateRight();
            if (Keyboard.GetState().IsKeyDown(Keys.A)) UsedTank.RotateLeft();

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                UsedTank.MoveForward();
            }
            else if (UsedTank.Velocity != Vector2.Zero && !Keyboard.GetState().IsKeyDown(Keys.S)){
                UsedTank.StopMovingForward();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                UsedTank.MoveBackward();
            }
            else if (UsedTank.Velocity != Vector2.Zero && !Keyboard.GetState().IsKeyDown(Keys.W))
            {
                UsedTank.StopMovingBackward();
            }

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
