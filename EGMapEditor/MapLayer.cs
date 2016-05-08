using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGMapEditor
{
    public class MapLayer
    {
        public List<Tile> Tiles { get; set; }
        public byte Opacity { get; set; }
        public string Name { get; set; }

        public MapLayer()
        {
            Tiles = new List<Tile>();
            Opacity = 100;
            Name = "New Layer";
        }

        public MapLayer(string name)
        {
            Tiles = new List<Tile>();
            Opacity = 100;
            Name = name;
        }
    }
}
