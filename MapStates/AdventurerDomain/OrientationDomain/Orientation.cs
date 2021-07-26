using System;

namespace MapStates.OrientationDomain
{
    public interface Orientation : ICloneable
    {
        public Position advance(Position p);
        public Orientation turnLeft();
        public Orientation turnRight();
    }
}