using System.Collections.Generic;

namespace EGMapEditor
{
    public class Tile
    {
        public int Id { get; set; }
        public int Tileset { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Tile(int id, int ts, int x, int y)
        {
            Id = id;
            Tileset = ts;
            X = x;
            Y = y;
        }
    }

    public class Map
    {
        public string Name { get; set; }
        public string FileName { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public List<MapLayer> Layers { get; set; }
        public MapController Tag { get; set; }

        public Map()
        {
            Name = "New Map";
            Width = 60;
            Height = 40;

            Layers = new List<MapLayer>();
            AddLayer();
        }

        public Map(string name, int width, int height)
        {
            Name = name;
            Width = width;
            Height = height;

            Layers = new List<MapLayer>();
            AddLayer();
        }

        public void AddLayer()
        {
            AddLayer("Layer " + (Layers.Count + 1));
        }

        public void AddLayer(string name)
        {
            Layers.Add(new MapLayer(name));
            if (Tag != null)
                Tag.CacheAddLayer();
        }

        public void RemoveLayer(int index)
        {
            Layers.RemoveAt(index);
            if (Tag != null)
                Tag.CacheRemoveLayer(index);
        }

        public void LayerShiftUp(int index)
        {
            if (index >= Layers.Count - 1)
                return;

            MapLayer temp = Layers[index];
            Layers[index] = Layers[index + 1];
            Layers[index + 1] = temp;

            if (Tag != null)
                Tag.CacheLayerShiftUp(index);
        }

        public void LayerShiftDown(int index)
        {
            if (index < 1)
                return;

            MapLayer temp = Layers[index];
            Layers[index] = Layers[index - 1];
            Layers[index - 1] = temp;

            if (Tag != null)
                Tag.CacheLayerShiftDown(index);
        }
    }
}
