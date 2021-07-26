using MapStates.AdventurerDomain;
using System;

namespace MapStates.ActionDomain
{
    public interface AdventurerAction : ICloneable
    {
        public void Execute(Adventurer adventurer);
    }
}