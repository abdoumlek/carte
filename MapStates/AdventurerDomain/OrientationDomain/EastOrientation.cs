namespace MapStates.OrientationDomain
{
    public class EastOrientation : Orientation
    {
        public Position advance(Position p)
        {
            return new Position() { X = p.X + 1, Y = p.Y};
        }

        public object Clone()
        {
            return new EastOrientation();
        }

        public Orientation turnLeft()
        {
            return new NorthOrientation();
        }

        public Orientation turnRight()
        {
            return new SouthOrientation();
        }
    }
}