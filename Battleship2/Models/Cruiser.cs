using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship2.Models
{
    public class Cruiser : Ship
    {
        public override int LengthOfShip()
        {
            return 3;
        }

        public override int Max()
        {
            return 4;
        }

        public override string Label()
        {
            return " R ";
        }


    }
}
