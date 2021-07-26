using MapStates.TreasureMapDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapStates.FileInterpreterDomain
{
    public interface IFileInterpreter
    {
        public ITreasureMap CreateMapFromFile(IList<string> fileLines);
        public IList<string> CreateFileContentFromMap(ITreasureMap treasureMap);
    }
}
