using System.Collections.Generic;

namespace EGMapEditor
{
    public struct Tile
    {
        public int id;
        public int tileset;

        public Tile(int _id, int ts)
        {
            id = _id;
            tileset = ts;
        }
    }

    public class Map
    {
        public string Name { get; set; }
        public int Width { get { return 80; } }
        public int Height { get { return 40; } }
        public List<Tile[]> tiles { get; set; }
        public List<string> layerNames { get; set; }

        public Map()
        {
            tiles = new List<Tile[]>();
            layerNames = new List<string>();
            AddLayer();
        }

        public void AddLayer()
        {
            tiles.Add(new Tile[Width * Height]);
            layerNames.Add("Unnamed Layer");
        }

        public void RemoveLayer(int index)
        {
            tiles.RemoveAt(index);
            layerNames.RemoveAt(index);
        }
}
}
