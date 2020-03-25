using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship2.Models
{
    public abstract class Ship
    {
        public abstract int LengthOfShip();

        public abstract int Max();

        public abstract string Label();

    }
}
