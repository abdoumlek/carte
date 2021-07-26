using MapStates.TreasureMapDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapStates.AdventurerDomain
{
    public interface IAdventurerBuilder
    {
        public void SetOrientation(char orientation);
        public void SetActions(string actions);
        public void SetPostion(int x, int y);
        public void SetName(string name);
        public void AddObserver(ITreasureMap map);
        public Adventurer GetAdventurer();
    }
}
