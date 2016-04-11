using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGMapEditor
{
    public struct Tile
    {
        public int id;
        public string tilesetName;
        public int tileset;

        public Tile(int _id, string name, int ts)
        {
            id = _id;
            tilesetName = name;
            tileset = ts;
        }
    }

    public class Map
    {
        public string Name { get; set; }
        public int Width { get { return 80; } }
        public int Height { get { return 40; } }
        public Tile[] tile { get; set; }

        public Map()
        {
            tile = new Tile[Width * Height];
        }
    }
}
