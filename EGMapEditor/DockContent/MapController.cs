using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DockPanel;

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

        public MapController(Map m)
        {
            InitializeComponent();
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

            int clickedY = (mouseY + _offsetY) / tempy * Map.Width;
            int clickedX = (mouseX + _offsetX) / tempx;

            if (clickedX == _lastDownTileX && clickedY == _lastDownTileY)
                return;

            if (MapEditor.Instance.SelectingArea == null)
                return;

            foreach (SelectedTileArea st in MapEditor.Instance.SelectingArea)
            {
                if (clickedY + clickedX + st.OffsetY * Map.Width + st.OffsetX < Map.Tiles[CurrentEditLayer].Length)
                {
                    int actualLoc = clickedY + st.OffsetY * Map.Width + clickedX + st.OffsetX;
                    if (!_undoPreventAddCache.Contains(actualLoc))
                    {
                        _placedTile.Add(new PlacedTile(clickedX + st.OffsetX, clickedY + st.OffsetY * Map.Width, CurrentEditLayer, Map.Tiles[CurrentEditLayer][actualLoc].Tileset, Map.Tiles[CurrentEditLayer][actualLoc].Id));
                        _undoPreventAddCache.Add(actualLoc);
                    }
                    Map.Tiles[CurrentEditLayer][actualLoc].Id = st.Id;
                    Map.Tiles[CurrentEditLayer][actualLoc].Tileset = st.Tileset;
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

            for (var l = 0; l < Map.Tiles.Count; l++)
            {
                for (var y = 0; y < Map.Height; y++)
                {
                    for (var x = 0; x < Map.Height; x++)
                    {
                        if (Map.Tiles[l][y * Map.Width + x].Tileset >= 0 && Map.Tiles[l][y * Map.Width + x].Id >= 0)
                        {
                            _tempSprite = new Sprite(MapEditor.Instance.Tilesets[Map.Tiles[l][y*Map.Width + x].Tileset])
                            {
                                Position = new Vector2f(x*tempx, y*tempy)
                            };
                            _tempSprite.TextureRect = new IntRect(Map.Tiles[l][y * Map.Width + x].Id % (int)(_tempSprite.Texture.Size.X / tempx) * tempx, 
                                Map.Tiles[l][y * Map.Width + x].Id / (int)(_tempSprite.Texture.Size.X / tempx) * tempy, tempx, tempy);
                            mapViewer.Draw(_tempSprite);
                        }
                    }
                }
            }

            if (MapEditor.Instance.DrawGridOnMaps)
                foreach (Vertex[] v in _lines)
                    mapViewer.RenderSurface.Draw(v, PrimitiveType.Lines); // Because i forgot to include Draw Overloads.

            foreach (SelectedTileArea st in MapEditor.Instance.SelectingArea)
            {
                int mouseY = (Mouse.GetPosition(mapViewer.RenderSurface).Y + _offsetY) / tempy;
                int mouseX = (Mouse.GetPosition(mapViewer.RenderSurface).X + _offsetX) / tempx;

                _tempSprite = new Sprite(MapEditor.Instance.Tilesets[st.Tileset])
                {
                    Position = new Vector2f((mouseX + st.OffsetX)*tempx, (mouseY + st.OffsetY)*tempy)
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
                forUndo.Add(new PlacedTile(p.X, p.Y, p.Layer, Map.Tiles[p.Layer][p.Y + p.X].Tileset, Map.Tiles[p.Layer][p.Y + p.X].Id));
                Map.Tiles[p.Layer][p.Y + p.X].Tileset = p.Tileset;
                Map.Tiles[p.Layer][p.Y + p.X].Id = p.Id;
            }
            _undoRedoStack.AddToUndo(forUndo);
        }

        private void UndoRedoStack_UndoHappened(object sender, UndoRedoEventArgs e)
        {
            List<PlacedTile> lp = (List<PlacedTile>)e.Item;
            List<PlacedTile> forRedo = new List<PlacedTile>();
            foreach (PlacedTile p in lp)
            {
                forRedo.Add(new PlacedTile(p.X, p.Y, p.Layer, Map.Tiles[p.Layer][p.Y + p.X].Tileset, Map.Tiles[p.Layer][p.Y + p.X].Id));
                Map.Tiles[p.Layer][p.Y + p.X].Tileset = p.Tileset;
                Map.Tiles[p.Layer][p.Y + p.X].Id = p.Id;
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
    }
}
