using MapStates.AdventurerDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapStates.ActionDomain
{
    public class TurnLeftAction : AdventurerAction
    {
        public object Clone()
        {
            return new TurnLeftAction();
        }

        public void Execute(Adventurer adventurer)
        {
            adventurer.Orientation = adventurer.Orientation.turnLeft();
        }
    }
}
