using MapStates.OrientationDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapStates.AdventurerDomain.OrientationDomain
{
    public class OrientationFactory : IOrientationFactory
    {
        public Orientation CreateOrientation(char c)
        {
            switch (c) {
                case 'o': return new WestOrientation();
                case 'e': return new EastOrientation();
                case 's': return new SouthOrientation();
                case 'n': return new NorthOrientation();
                default: return null;
            }
        }
    }
}
