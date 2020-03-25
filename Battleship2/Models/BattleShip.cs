using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship2.Models
{
    public class BattleShip : Ship
    {
        public override int LengthOfShip()
        {
            return 4;
        }

        public override int Max()
        {
            return 5;
        }

        public override string Label()
        {
            return " B ";
        }

    }
}
