using MapStates.ActionDomain;
using MapStates.AdventurerDomain.ActionDomain;
using MapStates.AdventurerDomain.OrientationDomain;
using MapStates.OrientationDomain;
using MapStates.TreasureMapDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapStates.AdventurerDomain
{
    public class AdventurerBuilder : IAdventurerBuilder
    {
        public Adventurer Adventurer;

        public AdventurerBuilder()
        {
            Adventurer = new Adventurer();
        }

        public void SetPostion(int x, int y)
        {
            Adventurer.Position = new Position(x, y);
        }

        public void SetActions(string actions)
        {
            IAdventurerActionFactory actionFactory = new AdventurerActionFactory();
            var actionsStack = new Stack<AdventurerAction>();

            for (int i = 0; i < actions.Length; i++)
            {
                actionsStack.Push(actionFactory.CreateAction(actions[i]));   
            }
            var ReverseStack = new Stack<AdventurerAction>();
            while (actionsStack.Count != 0)
            {
                ReverseStack.Push(actionsStack.Pop());
            }
            Adventurer.Actions = ReverseStack;
        }

        public void SetOrientation(char orientation)
        {
            IOrientationFactory orientationFactory = new OrientationFactory();
            Orientation o = orientationFactory.CreateOrientation(orientation);
            Adventurer.Orientation = o;
        }

        public Adventurer GetAdventurer()
        {
            return Adventurer;
        }

        public void SetName(string name)
        {
            Adventurer.Name = name;
        }

        public void AddObserver(ITreasureMap map)
        {
            Adventurer.AddObserver(map);
        }
    }
}
