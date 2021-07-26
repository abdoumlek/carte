using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapStates.TreasureMapDomain
{
    public class MapStateHistory
    {
        public MapStateHistory()
        {
            History = new Stack<MapState>();
        }
        #region properties
        public Stack<MapState> History { get; set; }

        #endregion

        #region methods
        public void Push(MapState m)
        {
            History.Push(m);
        }
        public MapState Pop ()
        {
            return History.Pop();
        }
        #endregion

    }
}
