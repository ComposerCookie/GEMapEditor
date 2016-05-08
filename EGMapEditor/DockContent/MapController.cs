using System;
using System.Collections.Generic;
using System.Windows.Forms;

using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace EGMapEditor
{
    public struct PlacedTile
    {
        public int X;
        public int Y;
        public int Layer;
        public int Tileset;
        public int Id;

        public PlacedTile(int x, int y, int l, int t, int id)
        {
            X = x;
            Y = y;
            Layer = l;
            Tileset = t;
            Id = id;
        }
    }

    public partial class MapController : DockContent
    {
        private readonly UndoRedo<List<PlacedTile>> _undoRedoStack;
        private readonly List<PlacedTile> _placedTile;
        private readonly List<int> _undoPreventAddCache;

        private List<int[,]> tileCache;

        public MapController(Map m)
        {
            InitializeComponent();

            m.Tag = this;

            vScrTileset.Maximum = m.Height * MapEditor.Instance.TILE_HEIGHT;
            hScrTileset.Maximum = m.Width * MapEditor.Instance.TILE_WIDTH;

            // MapViewer Initializers
            _tempSprite = new Sprite();
            _lines = new List<Vertex[]>();
            _undoRedoStack = new UndoRedo<List<PlacedTile>>();
            _undoRedoStack.New();
            _undoPreventAddCache = new List<int>();
            _pressedDown = false;

            Map = m;

            tileCache = new List<int[,]>();
            foreach (MapLayer ml in Map.Layers)
            {
                tileCache.Add(new int[Map.Width, Map.Height]);
                CacheToDefault();
                FillCache();
            }

            _lastDownTileX = -1;
            _lastDownTileY = -1;

            _placedTile = new List<PlacedTile>();

            int tempx = MapEditor.Instance.TILE_WIDTH;
            int tempy = MapEditor.Instance.TILE_HEIGHT;

            for (int i = 0; i < m.Width; i++)
                _lines.Add(new[] { new Vertex(new Vector2f(i * tempx, 0)), new Vertex(new Vector2f(i * tempx, Map.Height * tempy)) });
            for (int i = 0; i < m.Height; i++)
                _lines.Add(new[] { new Vertex(new Vector2f(0, i * tempy)), new Vertex(new Vector2f(Map.Width * tempx, i * tempy)) });

            _undoRedoStack.UndoHappened += UndoRedoStack_UndoHappened;
            _undoRedoStack.RedoHappened += UndoRedoStack_RedoHappened;
        }

        public void CacheLayerShiftUp(int index)
        {
            if (index >= tileCache.Count - 1)
                return;

            int[,] temp = tileCache[index];
            tileCache[index] = tileCache[index + 1];
            tileCache[index + 1] = temp;
        }

        public void CacheLayerShiftDown(int index)
        {
            if (index < 1)
                return;

            int[,] temp = tileCache[index];
            tileCache[index] = tileCache[index - 1];
            tileCache[index - 1] = temp;
        }

        public void CacheRemoveLayer(int index)
        {
            tileCache.RemoveAt(index);
        }

        public void CacheAddLayer()
        {
            tileCache.Add(new int[Map.Width, Map.Height]);
            CacheLayerToDefault(tileCache.Count - 1);
        }

        public void ReCreateCache()
        {
            for (int i = 0; i < tileCache.Count; i++)
            {
                tileCache[i] = new int[Map.Width, Map.Height];
                CacheToDefault();
                FillCache();
            }
        }

        public void CacheToDefault()
        {
            for (int i = 0; i < tileCache.Count; i++)
                CacheLayerToDefault(i);
        }

        public void CacheLayerToDefault(int l)
        {
            for (int x = 0; x < Map.Width; x++)
                for (int y = 0; y < Map.Height; y++)
                    tileCache[l][x, y] = -1;
        }

        public void FillCache()
        {
            for (int i = 0; i < tileCache.Count; i++)
                if (i < Map.Layers.Count)
                    foreach (Tile t in Map.Layers[i].Tiles)
                        if (t.X < Map.Width && t.Y < Map.Height)
                            tileCache[i][t.X, t.Y] = Map.Layers[i].Tiles.IndexOf(t);
        }

        public void RefreshCache()
        {
            CacheToDefault();
            FillCache();
        }

        #region SFML Control
        public Map Map { get; set; }
        private Sprite _tempSprite;
        private readonly List<Vertex[]> _lines;
        private bool _pressedDown;

        private int _offsetX;
        private int _offsetY;

        private int _lastDownTileX;
        private int _lastDownTileY;

        public int CurrentEditLayer { get; set; }

        public void MoveCamera(object sender, ScrollEventArgs e)
        {
            var offX = hScrTileset.Value;
            var offY = vScrTileset.Value;
            _offsetX = offX;
            _offsetY = offY;
            mapViewer.View.Center = new Vector2f(offX + Size.Width / 2, offY + Size.Height / 2);
        }

        public void Undo()
        {
            _undoRedoStack.Undo();
        }

        public void Redo()
        {
            _undoRedoStack.Redo();
        }

        private void PlaceTile(int mouseX, int mouseY)
        {
            int tempx = MapEditor.Instance.TILE_WIDTH;
            int tempy = MapEditor.Instance.TILE_HEIGHT;

            int clickedY = (mouseY + _offsetY) / tempy;
            int clickedX = (mouseX + _offsetX) / tempx;

            if (clickedX == _lastDownTileX && clickedY == _lastDownTileY)
                return;

            if (MapEditor.Instance.SelectingArea == null)
                return;

            foreach (SelectedTileArea st in MapEditor.Instance.SelectingArea)
            {
                int rightX = clickedX + st.OffsetX;
                int rightY = clickedY + st.OffsetY;
                int actualLoc = clickedY * Map.Width + st.OffsetY * Map.Width + rightX;

                if (rightX < Map.Width && rightY < Map.Height)
                {
                    if (tileCache[CurrentEditLayer][rightX, rightY] == -1)
                    {
                        tileCache[CurrentEditLayer][rightX, rightY] = Map.Layers[CurrentEditLayer].Tiles.Count;
                        Map.Layers[CurrentEditLayer].Tiles.Add(new Tile(-1, -1, rightX, rightY));
                    }

                    if (!_undoPreventAddCache.Contains(actualLoc))
                    {
                        _placedTile.Add(new PlacedTile(rightX, rightY, CurrentEditLayer,
                            Map.Layers[CurrentEditLayer].Tiles[tileCache[CurrentEditLayer][rightX, rightY]].Tileset,
                            Map.Layers[CurrentEditLayer].Tiles[tileCache[CurrentEditLayer][rightX, rightY]].Id));
                        _undoPreventAddCache.Add(actualLoc);
                    }

                    Map.Layers[CurrentEditLayer].Tiles[tileCache[CurrentEditLayer][rightX, rightY]].Id = st.Id;
                    Map.Layers[CurrentEditLayer].Tiles[tileCache[CurrentEditLayer][rightX, rightY]].Tileset = st.Tileset;
                }
            }

            _lastDownTileX = clickedX;
            _lastDownTileY = clickedY;
        }

        #region Events
        private void mapViewer_Resize(object sender, EventArgs e)
        {
            if (mapViewer.RenderSurface == null) return;
            mapViewer.RenderSurface.Size = new Vector2u((uint)hScrTileset.Size.Width, (uint)vScrTileset.Size.Height);
            mapViewer.View = new SFML.Graphics.View
            {
                Center = new Vector2f(hScrTileset.Size.Width / 2, vScrTileset.Size.Height / 2),
                Size = new Vector2f(hScrTileset.Size.Width, vScrTileset.Size.Height)
            };
        }

        private void mapViewer_Render()
        {
            int tempx = MapEditor.Instance.TILE_WIDTH;
            int tempy = MapEditor.Instance.TILE_HEIGHT;

            for (var l = 0; l < Map.Layers.Count; l++)
            {
                foreach (Tile t in Map.Layers[l].Tiles)
                    if (t.Id >= 0 && t.Tileset >= 0)
                    {
                        _tempSprite = new Sprite(MapEditor.Instance.Tilesets[t.Tileset])
                        {
                            Position = new Vector2f(t.X * tempx, t.Y * tempy),
                            TextureRect = new IntRect(t.Id % (int)(_tempSprite.Texture.Size.X / tempx) * tempx, t.Id / (int)(_tempSprite.Texture.Size.X / tempx) * tempy, tempx, tempy)
                        };
                        mapViewer.Draw(_tempSprite);
                    }
            }

            if (MapEditor.Instance.DrawGridOnMaps)
                foreach (Vertex[] v in _lines)
                    mapViewer.RenderSurface.Draw(v, PrimitiveType.Lines); // Because i forgot to include Draw Overloads.

            if (MapEditor.Instance.CurrentFocusedMap == this)
                foreach (SelectedTileArea st in MapEditor.Instance.SelectingArea)
                {
                    int mouseY = (Mouse.GetPosition(mapViewer.RenderSurface).Y + _offsetY) / tempy;
                    int mouseX = (Mouse.GetPosition(mapViewer.RenderSurface).X + _offsetX) / tempx;

                    _tempSprite = new Sprite(MapEditor.Instance.Tilesets[st.Tileset])
                    {
                        Position = new Vector2f((mouseX + st.OffsetX) * tempx, (mouseY + st.OffsetY) * tempy)
                    };

                    _tempSprite.TextureRect = new IntRect(st.Id % (int)(_tempSprite.Texture.Size.X / tempx) * tempx,
                        st.Id / (int)(_tempSprite.Texture.Size.X / tempx) * tempy, tempx, tempy);


                    var c = _tempSprite.Color;
                    _tempSprite.Color = new Color(c.R, c.G, c.B, 128);
                    mapViewer.Draw(_tempSprite);
                }
        }

        private void mapViewer_MouseDown(object sender, MouseEventArgs e)
        {
            _pressedDown = true;
            PlaceTile(e.Location.X, e.Location.Y);
        }

        private void mapViewer_MouseMove(object sender, MouseEventArgs e)
        {
            if (_pressedDown)
            {
                PlaceTile(e.Location.X, e.Location.Y);
            }
        }

        private void mapViewer_MouseUp(object sender, MouseEventArgs e)
        {
            _pressedDown = false;
            _lastDownTileX = -1;
            _lastDownTileY = -1;

            _undoRedoStack.AddItem(new List<PlacedTile>(_placedTile));
            _placedTile.Clear();
            _undoPreventAddCache.Clear();
        }

        private void mapViewer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ModifierKeys == Keys.ControlKey && e.KeyChar == (char)Keys.C)
            {
                if (_undoRedoStack.CanUndo())
                {
                    _undoRedoStack.Undo();
                }
            }
        }

        private void UndoRedoStack_RedoHappened(object sender, UndoRedoEventArgs e)
        {
            List<PlacedTile> lp = (List<PlacedTile>)e.Item;
            List<PlacedTile> forUndo = new List<PlacedTile>();
            foreach (PlacedTile p in lp)
            {
                if (tileCache[p.Layer][p.X, p.Y] >= 0)
                {
                    forUndo.Add(new PlacedTile(p.X, p.Y, p.Layer, Map.Layers[p.Layer].Tiles[tileCache[p.Layer][p.X, p.Y]].Tileset, Map.Layers[p.Layer].Tiles[tileCache[p.Layer][p.X, p.Y]].Id));
                    Map.Layers[p.Layer].Tiles[tileCache[p.Layer][p.X, p.Y]].Tileset = p.Tileset;
                    Map.Layers[p.Layer].Tiles[tileCache[p.Layer][p.X, p.Y]].Id = p.Id;
                }
            }
            _undoRedoStack.AddToUndo(forUndo);
        }

        private void UndoRedoStack_UndoHappened(object sender, UndoRedoEventArgs e)
        {
            List<PlacedTile> lp = (List<PlacedTile>)e.Item;
            List<PlacedTile> forRedo = new List<PlacedTile>();
            foreach (PlacedTile p in lp)
            {
                if (tileCache[p.Layer][p.X, p.Y] >= 0)
                {
                    forRedo.Add(new PlacedTile(p.X, p.Y, p.Layer, Map.Layers[p.Layer].Tiles[tileCache[p.Layer][p.X, p.Y]].Tileset, Map.Layers[p.Layer].Tiles[tileCache[p.Layer][p.X, p.Y]].Id));
                    Map.Layers[p.Layer].Tiles[tileCache[p.Layer][p.X, p.Y]].Tileset = p.Tileset;
                    Map.Layers[p.Layer].Tiles[tileCache[p.Layer][p.X, p.Y]].Id = p.Id;
                }                    
                
            }

            _undoRedoStack.AddToRedo(forRedo);
        }


        #endregion

        #endregion

        private void MapController_Resize(object sender, EventArgs e)
        {
            vScrTileset.Height = Size.Height - 22;
            hScrTileset.Width = Size.Width - 22;
        }

        private void MapController_Enter(object sender, EventArgs e)
        {
            MapEditor.Instance.CurrentFocusedMap = this;
        }

        private void MapController_FormClosing(object sender, FormClosingEventArgs e)
        {
            MapEditor.Instance.CloseMapController(this);
        }
    }
}
