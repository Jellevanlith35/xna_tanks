using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Windows_XNA_Tanks.Interfaces
{
    interface ITurret
    {
        void Shoot();
        void Reload();
        void TurnLeft();
        void TurnRight();
    }
}
