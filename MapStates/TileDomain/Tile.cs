using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapStates.TreasureMapDomain
{
    public abstract class Tile : ICloneable
    {
        public bool IsBlocked { get; set; }
        public int? Treasures { get; set; }

        public abstract object Clone();

    }
}
