using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship2.Models
{
    public class Carrier : Ship
    {
        public override int LengthOfShip()
        {
            return 5;
        }
        public override int Max()
        {
            return 5;
        }

        public override string Label()
        {
            return " C ";
        }

    }
}
