namespace MapStates.OrientationDomain
{
    public class WestOrientation : Orientation
    {
        public Position advance(Position p)
        {
            return new Position() { X = p.X - 1, Y = p.Y };
        }

        public object Clone()
        {
            return new WestOrientation();
        }

        public Orientation turnLeft()
        {
            return new SouthOrientation();
        }

        public Orientation turnRight()
        {
            return new NorthOrientation();
        }
    }
}