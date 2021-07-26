using MapStates.AdventurerDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapStates.TreasureMapDomain
{
    public interface ITreasureMap
    {
        public void update(Adventurer adventurer);
        public Tile GetTileByPosition(Position p);
        public void UpdateTileAtPosition(Position p, Tile t);
        public Adventurer GetAdventureByPosition(Position p);
        public bool IsTileBlocked(Position p);
        public MapState CreateState();
        public void Restore(MapState m);
        public IList<Adventurer> GetAdventurers();
        public IDictionary<Position, Tile> GetTiles();

        public void AddAdventurer(Adventurer adventurer);
        public void AddTile(Tile tile, Position position);
        public void SetDimension(int width, int height);
        public int GetWidth();
        public int GetHeight();





    }
}
