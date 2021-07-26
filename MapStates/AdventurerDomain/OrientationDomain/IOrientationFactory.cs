using MapStates.OrientationDomain;

namespace MapStates.AdventurerDomain.OrientationDomain
{
    public interface IOrientationFactory
    {
        public Orientation CreateOrientation(char c);
    }
}