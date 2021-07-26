using MapStates.AdventurerDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapStates.TreasureMapDomain
{
    public class TreasureMap : ITreasureMap
    {
        #region properties
        public int Id { get; set; }
        public IDictionary<Position, Tile> Tiles { get; set; }
        public IList<Adventurer> Adventurers { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        #endregion

        public TreasureMap()
        {
            Tiles = new Dictionary<Position, Tile>();
            Adventurers = new List<Adventurer>();
        }
        

        #region methods

        public Tile GetTileByPosition(Position p)
        {
            var foundKey = Tiles.Keys.FirstOrDefault(k => k.X == p.X && k.Y == p.Y);
            if (foundKey != null)
            {
                Tiles.TryGetValue(foundKey, out var tile);
                return tile;
            }
            return null;
        }

        public void UpdateTileAtPosition(Position p, Tile t)
        {
            var foundKey = Tiles.Keys.FirstOrDefault(k => k.X == p.X && k.Y == p.Y);
            if (foundKey != null)
            {
                Tiles.Remove(foundKey);
                Tiles.Add(foundKey, t);
            }
        }

        public Adventurer GetAdventureByPosition(Position p)
        {
            var adventurer = Adventurers.FirstOrDefault(k => k.Position.X == p.X && k.Position.Y == p.Y);
            return adventurer;
        }

        public bool IsTileBlocked(Position p)
        {
            var tileOccupiedByAdventurer = GetAdventureByPosition(p);
            Tile tile = GetTileByPosition(p);
            if (tile != null && tileOccupiedByAdventurer == null)
            {
                return tile.IsBlocked;
            }
            return true;
        }

        ///created the state pattern to get a snapshot of the map after each state
        // Memento Pattern
        public MapState CreateState()
        {
            List<Adventurer> oldAdventurers = new List<Adventurer>();
            foreach (Adventurer adventurer in Adventurers)
            {
                Adventurer copy = (Adventurer)adventurer.Clone();
                oldAdventurers.Add(copy);
            }
            Dictionary<Position,Tile> oldTiles = new Dictionary<Position, Tile>();
            foreach (var tile in Tiles)
            {
                oldTiles.Add((Position)tile.Key.Clone(),(Tile)tile.Value.Clone());
            }
            return new MapState(oldAdventurers, oldTiles);
        }

        public void Restore(MapState m)
        {
            Adventurers = m.Adventurers;
            Id = m.Id;
            Tiles = m.Tiles;
        }

        /// <summary>
        /// update adventurer state in the Map Adventurer List (position orientation and treasures) 
        /// based on the new state sent by the adventurer class (Observer pattern)
        /// </summary>
        /// <param name="newAdventurerState"></param>
        public void update(Adventurer newAdventurerState)
        {
            var adventurer = Adventurers.FirstOrDefault(x => x.Id == newAdventurerState.Id);
            if (adventurer != null && !IsTileBlocked(newAdventurerState.Position))
            {
                var tile = GetTileByPosition(newAdventurerState.Position);
                if (  tile.Treasures.HasValue && tile.Treasures  > 0)
                {
                    tile.Treasures--;
                    adventurer.Treasures++;
                }
                adventurer.Position = newAdventurerState.Position;
            }
            adventurer.Orientation = newAdventurerState.Orientation;
        }

        public IList<Adventurer> GetAdventurers()
        {
            return Adventurers;
        }

        public void AddAdventurer(Adventurer adventurer)
        {
            Adventurers.Add(adventurer);
        }

        public void AddTile(Tile tile, Position position)
        {
            Tiles.Add(position, tile);
        }

        public IDictionary<Position, Tile> GetTiles()
        {
            return Tiles;
        }

        public void SetDimension(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int GetWidth()
        {
            return Width;
        }

        public int GetHeight()
        {
            return Height;
        }

        #endregion
    }


}
