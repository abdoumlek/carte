namespace MapStates.OrientationDomain
{
    public class SouthOrientation : Orientation
    {
        public Position advance(Position p)
        {
            return new Position() { X = p.X , Y = p.Y + 1 };
        }

        public object Clone()
        {
            return new SouthOrientation();
        }

        public Orientation turnLeft()
        {
            return new EastOrientation();
        }

        public Orientation turnRight()
        {
            return new WestOrientation();
        }
    }
}