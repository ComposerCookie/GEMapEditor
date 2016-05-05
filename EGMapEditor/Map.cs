using System.Collections.Generic;

namespace EGMapEditor
{
    public struct Tile
    {
        public int Id;
        public int Tileset;

        public Tile(int id, int ts)
        {
            Id = id;
            Tileset = ts;
        }
    }

    public class Map
    {
        public string Name { get; set; }
        public int Width => 80;
        public int Height => 40;
        public List<Tile[]> Tiles { get; set; }
        public List<string> LayerNames { get; set; }
        public MapController Tag { get; set; }

        public Map()
        {
            Name = "New Map";

            Tiles = new List<Tile[]>();
            LayerNames = new List<string>();
            AddLayer();
        }

        public void AddLayer()
        {
            Tiles.Add(new Tile[Width * Height]);
            for (var i = 0; i < Width * Height - 1; i++ )
            {
                Tiles[Tiles.Count - 1][i].Id = -1;
            }
            LayerNames.Add("Unnamed Layer");
        }

        public void AddLayer(string name)
        {
            AddLayer();
            LayerNames[LayerNames.Count - 1] = name;
        }

        public void RemoveLayer(int index)
        {
            Tiles.RemoveAt(index);
            LayerNames.RemoveAt(index);
        }
}
}
