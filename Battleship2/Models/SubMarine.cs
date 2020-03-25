using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship2.Models
{
    public class SubMarine : Ship
    {
        public override int LengthOfShip()
        {
            return 3;
        }

        public override int Max()
        {
            return 6;
        }

        public override string Label()
        {
            return " S ";
        }


    }
}
