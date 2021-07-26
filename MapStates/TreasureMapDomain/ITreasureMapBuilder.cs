namespace MapStates.TreasureMapDomain
{
    public interface ITreasureMapBuilder
    {
        public ITreasureMap GetTreasureMap();
        public void PlaceAdventurer(int x, int y, string name, char o, string actions);
        public void AddSpecialTile(Tile tile, Position position);
        public void CreateEmptyMap(int width, int height);

    }
}