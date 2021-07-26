using MapStates.AdventurerDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapStates.TreasureMapDomain
{
    public class TreasureMapBuilder : ITreasureMapBuilder

    {
        public TreasureMapBuilder()
        {
            GameMap = new TreasureMap();
        }

        ITreasureMap GameMap { get; set; }


        public void CreateEmptyMap(int width, int height)
        {
            GameMap.SetDimension(width, height);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    var p = new Position() { X = i, Y = j };
                    Tile t = new Plain();
                    GameMap.AddTile(t, p);
                }
            }
        }
        public void AddSpecialTile(Tile tile, Position position)
        {
            GameMap.UpdateTileAtPosition(position, tile);
        }

        public void PlaceAdventurer(int x, int y , string name, char o, string actions)
        {
            IAdventurerBuilder adventurerBuilder = new AdventurerBuilder();
            adventurerBuilder.SetPostion(x, y);
            adventurerBuilder.SetName(name);
            adventurerBuilder.SetOrientation(o);
            adventurerBuilder.SetActions(actions);
            adventurerBuilder.AddObserver(GameMap);
            GameMap.AddAdventurer(adventurerBuilder.GetAdventurer());
        }

        public ITreasureMap GetTreasureMap()
        {
            return GameMap;
        }

    }
}
