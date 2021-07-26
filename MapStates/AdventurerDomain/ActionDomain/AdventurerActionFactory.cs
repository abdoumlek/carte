using MapStates.ActionDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapStates.AdventurerDomain.ActionDomain
{
    public class AdventurerActionFactory : IAdventurerActionFactory
    {
        public AdventurerAction CreateAction(char c)
        {
            switch (c)
            {
                case 'A': return new AdvanceAction();
                case 'G': return new TurnLeftAction();
                case 'D': return new TurnRightAction();
                default: return null;
            }
        }
    }
}
