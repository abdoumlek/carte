using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapStates.TreasureMapDomain
{
    public class Treasure : Tile
    {
        public Treasure(int? treasures)
        {
            IsBlocked = false;
            Treasures = treasures;
        }


        public override object Clone()
        {
            return new Treasure(Treasures);
        }
    }
}
