using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapStates.TreasureMapDomain
{
    public class Plain : Tile
    {
        public Plain()
        {
            IsBlocked = false;
        }

        public override object Clone()
        {
            return new Plain();
        }

    }
}
