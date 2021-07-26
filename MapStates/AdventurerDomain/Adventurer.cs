using MapStates.ActionDomain;
using MapStates.OrientationDomain;
using MapStates.TreasureMapDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapStates.AdventurerDomain
{
    public class Adventurer : ICloneable
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public Orientation Orientation { get; set; }
        public Position Position { get; set; }
        public Stack<AdventurerAction> Actions { get; set; }
        public int Treasures { get; set; }

        private IList<ITreasureMap> Observers { get; set; }

        public Adventurer()
        {
            Observers = new List<ITreasureMap>();
        }

        public Adventurer(int id, string name, Orientation orientation, Position position, Stack<AdventurerAction> actions, int treasures, IList<ITreasureMap> observers)
        {
            Id = id;
            Name = name;
            Orientation = orientation;
            Position = position;
            Actions = actions;
            Treasures = treasures;
            Observers = observers;
        }

        public void AddObserver(ITreasureMap m)
        {
            Observers.Add(m);
        }
        public void RemoveObserver(ITreasureMap m)
        {
            Observers.Remove(m);
        }
        public void ExecuteAction()
        {
            if (Actions.Count > 0) { 
                var Action = Actions.Pop();
                Adventurer clone = (Adventurer)Clone();
                Action.Execute(clone);
                Notify(clone);
            }
        }

        public void Notify(Adventurer adventurer)
        {
            foreach (var observer in Observers)
            {
                observer.update(adventurer);
            }
        }

        public object Clone()
        {
            var copyOrientation = (Orientation)Orientation.Clone();
            var copyPosition = (Position)Position.Clone();
            var copyActions = new Stack<AdventurerAction>();
            foreach (AdventurerAction action in Actions){
                copyActions.Push((AdventurerAction)action.Clone());
            }

            return new Adventurer(Id, Name, copyOrientation, copyPosition, copyActions, Treasures, Observers);
        }
    }
}
