using MapStates.AdventurerDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapStates.ActionDomain
{
    public class AdvanceAction : AdventurerAction
    {
        public object Clone()
        {
            return new AdvanceAction();
        }

        public void Execute(Adventurer adventurer)
        {
            adventurer.Position = adventurer.Orientation.advance(adventurer.Position);
        }
    }
}
