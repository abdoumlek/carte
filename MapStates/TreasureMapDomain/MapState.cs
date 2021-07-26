using MapStates.AdventurerDomain;
using System;
using System.Collections.Generic;

namespace MapStates.TreasureMapDomain
{
    public class MapState
    {

        private static int CurrentIndex = 0;
        #region properties
        public  int Id { get; set; }
        public  IDictionary<Position, Tile> Tiles { get; set; }
        public  IList<Adventurer> Adventurers { get; set; }

        public MapState()
        {
        }
        #endregion

        public MapState(IList<Adventurer> oldAdventurers, IDictionary<Position, Tile> oldTiles)
        {
            Tiles = oldTiles;
            Adventurers = oldAdventurers;
            Id = CurrentIndex;
            CurrentIndex++;
        }

       
    }
}
