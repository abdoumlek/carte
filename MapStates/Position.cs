using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapStates
{
    public class Position : ICloneable
    {
        public Position()
        {
        }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
        #region properties
        public int X { get; set; }
        public int Y { get; set; }

        public object Clone()
        {
            return new Position(X,Y);
        }
        #endregion

    }
}
