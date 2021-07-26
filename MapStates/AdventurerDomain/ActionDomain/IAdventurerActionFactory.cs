using MapStates.ActionDomain;

namespace MapStates.AdventurerDomain.ActionDomain
{
    public interface IAdventurerActionFactory
    {
        public AdventurerAction CreateAction(char c);
    }
}