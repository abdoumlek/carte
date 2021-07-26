using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapStates.TreasureMapDomain
{
    public class Mountain : Tile
    {
        public Mountain()
        {
            IsBlocked = true;
        }

        public override object Clone()
        {
            return new Mountain();
        }
    }
}
