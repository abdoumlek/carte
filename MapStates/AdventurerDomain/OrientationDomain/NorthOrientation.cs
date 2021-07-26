using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapStates.OrientationDomain
{
    public class NorthOrientation : Orientation
    {
        public Position advance(Position p)
        {
            return new Position() { X = p.X , Y = p.Y - 1 };
        }

        public object Clone()
        {
            return new NorthOrientation();
        }

        public Orientation turnLeft()
        {
            return new WestOrientation();
        }

        public Orientation turnRight()
        {
            return new EastOrientation();
        }
    }
}
