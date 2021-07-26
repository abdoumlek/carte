using MapStates.ActionDomain;
using MapStates.OrientationDomain;
using MapStates.TreasureMapDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MapStates.FileInterpreterDomain
{
    class FileInterpreter : IFileInterpreter
    {
        private TreasureMapBuilder _builder;
        public FileInterpreter()
        {
            _builder = new TreasureMapBuilder();
        }

        public ITreasureMap CreateMapFromFile(IList<string> fileLines)
        {
            var noComments = RemoveComments(fileLines);
            foreach (string s in noComments)
            {
                InterpreteCommand(s);
            }
            return _builder.GetTreasureMap();
        }

        private void InterpreteCommand(string line)
        {
            if (line.StartsWith("C"))
            {
                string width = ExtractArgument(line, 2);
                string height = ExtractArgument(line, 3);
                if (height != null && width != null)
                    _builder.CreateEmptyMap(int.Parse(width),int.Parse(height));
            }
            else if (line.StartsWith("M"))
            {
                string x = ExtractArgument(line, 2);
                string y = ExtractArgument(line, 3);
                if (x != null && y != null)
                {
                    var position = new Position(int.Parse(x), int.Parse(y));
                    Tile tile = new Mountain();
                    _builder.AddSpecialTile(tile, position);
                }

            }
            else if (line.StartsWith("T"))
            {
                string x = ExtractArgument(line, 2);
                string y = ExtractArgument(line, 3);
                string treasure = ExtractArgument(line, 4);
                {
                    var position = new Position(int.Parse(x), int.Parse(y));
                    Tile tile = new Treasure(int.Parse(treasure));
                    _builder.AddSpecialTile(tile, position);
                }
            }
            else if (line.StartsWith("A"))
            {
                string name = ExtractArgument(line, 2);
                string x = ExtractArgument(line, 3);
                string y = ExtractArgument(line, 4);
                string orientation = ExtractArgument(line, 5);
                string actions = ExtractArgument(line, 6);
                _builder.PlaceAdventurer(int.Parse(x),int.Parse(y),name,orientation.ToLower()[0],actions);
            }

        }

        
        private IList<string> RemoveComments(IList<string> fileLines)
        {
            return fileLines.Where(s => !s.StartsWith("#")).ToList();
        }

        private string ExtractArgument(string line, int position)
        {
            var newLine = Regex.Replace(line, @"\s+", "");
            string[] arguments = newLine.Split('-');
            if (arguments.Length >= position)
            {
                return arguments[position - 1];
            }
            return null;
        }

        public IList<string> CreateFileContentFromMap(ITreasureMap treasureMap)
        {
            IList<string> fileContent = new List<string>();
            fileContent.Add(CreateLine("C",treasureMap.GetWidth().ToString(), treasureMap.GetHeight().ToString()));
            var MountainTiles = treasureMap.GetTiles().Where(kvp => kvp.Value.GetType() == typeof(Mountain));
            var TreasureTiles = treasureMap.GetTiles().Where(kvp => kvp.Value.GetType() == typeof(Treasure));

            foreach (var keyValuePair in MountainTiles)
            {
                    fileContent.Add(CreateLine("M", keyValuePair.Key.X.ToString(), keyValuePair.Key.Y.ToString()));
            }
            foreach (var keyValuePair in TreasureTiles)
            {
                fileContent.Add(CreateLine("T", keyValuePair.Key.X.ToString(), keyValuePair.Key.Y.ToString(), keyValuePair.Value.Treasures.ToString()));
            }
            foreach (var advenutrer in treasureMap.GetAdventurers())
            {
                fileContent.Add(CreateLine("A", advenutrer.Name, advenutrer.Position.X.ToString(), advenutrer.Position.Y.ToString(), ExtractOrientationSymbol(advenutrer.Orientation),advenutrer.Treasures.ToString()));
            }
            return fileContent;

        }
        private string ExtractOrientationSymbol (Orientation orientation)
        {
            if (orientation.GetType() == typeof(NorthOrientation))
                return "N";
            else if (orientation.GetType() == typeof(SouthOrientation))
                return "S";
            else if (orientation.GetType() == typeof(WestOrientation))
                return "O";
            else if (orientation.GetType() == typeof(EastOrientation))
                return "E";
            else throw (new Exception("Unknown Orientation"));
        }
        private string CreateLine(params string[] parameters)
        {
            string message = "";
            for(int i=0; i<parameters.Length; i++)
            {
                message = message + parameters[i] ;
                if (i != parameters.Length - 1)
                    message = message + " - ";
            }
            return message;
        }
    }
}
