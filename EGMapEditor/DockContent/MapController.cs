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
        public int ID;

        public PlacedTile(int x, int y, int l, int t, int id)
        {
            X = x;
            Y = y;
            Layer = l;
            Tileset = t;
            ID = id;
        }
    }

    public partial class MapController : DockContent
    {
        private UndoRedo<List<PlacedTile>> UndoRedoStack;
        private List<PlacedTile> placedTile;

        public MapController(Map m)
        {
            InitializeComponent();
            vScrTileset.Maximum = m.Height * MapEditor.Instance.TILE_HEIGHT;
            hScrTileset.Maximum = m.Width * MapEditor.Instance.TILE_WIDTH;

            // MapViewer Initializers
            tempSprite = new Sprite();
            lines = new List<Vertex[]>();
            UndoRedoStack = new UndoRedo<List<PlacedTile>>();
            UndoRedoStack.New();
            pressedDown = false;

            map = m;

            lastDownTileX = -1;
            lastDownTileY = -1;

            placedTile = new List<PlacedTile>();

            int tempx = MapEditor.Instance.TILE_WIDTH;
            int tempy = MapEditor.Instance.TILE_HEIGHT;

            for (int i = 0; i < m.Width; i++)
                lines.Add(new Vertex[] { new Vertex(new Vector2f(i * tempx, 0)), new Vertex(new Vector2f(i * tempx, map.Height * tempy)) });
            for (int i = 0; i < m.Height; i++)
                lines.Add(new Vertex[] { new Vertex(new Vector2f(0, i * tempy)), new Vertex(new Vector2f(map.Width * tempx, i * tempy)) });

            UndoRedoStack.UndoHappened += UndoRedoStack_UndoHappened;
            UndoRedoStack.RedoHappened += UndoRedoStack_RedoHappened;
        }

        #region SFML Control
        private Map map;
        private Sprite tempSprite;
        private List<Vertex[]> lines;
        private bool pressedDown;

        private int offsetX = 0;
        private int offsetY = 0;

        private int lastDownTileX;
        private int lastDownTileY;

        public int CurrentEditLayer { get; set; }

        public void moveCamera(object sender, ScrollEventArgs e)
        {
            var offX = hScrTileset.Value;
            var offY = vScrTileset.Value;
            offsetX = offX;
            offsetY = offY;
            mapViewer.View.Center = new Vector2f(offX + Size.Width / 2, offY + Size.Height / 2);
        }

        public void Undo()
        {
            UndoRedoStack.Undo();
        }

        public void Redo()
        {
            UndoRedoStack.Redo();
        }

        private void placeTile(int mouseX, int mouseY)
        {
            int tempx = MapEditor.Instance.TILE_WIDTH;
            int tempy = MapEditor.Instance.TILE_HEIGHT;

            int clickedY = (mouseY + offsetY) / tempy * map.Width;
            int clickedX = (mouseX + offsetX) / tempx;

            if (clickedX == lastDownTileX && clickedY == lastDownTileY)
                return;

            if (MapEditor.Instance.SelectingArea == null)
                return;

            foreach (SelectedTileArea st in MapEditor.Instance.SelectingArea)
            {
                if (clickedY + clickedX + st.offsetY * map.Width + st.offsetX < map.tiles[CurrentEditLayer].Length)
                {
                    map.tiles[CurrentEditLayer][clickedY + st.offsetY * map.Width + clickedX + st.offsetX].id = st.id;
                    map.tiles[CurrentEditLayer][clickedY + st.offsetY * map.Width + clickedX + st.offsetX].tileset = st.tileset;
                    placedTile.Add(new PlacedTile(clickedX + st.offsetX, clickedY + st.offsetY * map.Width, CurrentEditLayer, st.tileset, st.id));
                }
            }

            lastDownTileX = clickedX;
            lastDownTileY = clickedY;
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

            for (int l = 0; l < map.tiles.Count; l++)
            {
                for (int y = 0; y < map.Height; y++)
                {
                    for (int x = 0; x < map.Height; x++)
                    {
                        if (map.tiles[l][y * map.Width + x].tileset >= 0 && map.tiles[l][y * map.Width + x].id >= 0)
                        {
                            tempSprite = new Sprite(MapEditor.Instance.Tilesets[map.tiles[l][y * map.Width + x].tileset]);
                            tempSprite.Position = new Vector2f(x * tempx, y * tempy);
                            tempSprite.TextureRect = new IntRect(map.tiles[l][y * map.Width + x].id % (int)(tempSprite.Texture.Size.X / tempx) * tempx, 
                                map.tiles[l][y * map.Width + x].id / (int)(tempSprite.Texture.Size.X / tempx) * tempy, tempx, tempy);
                            mapViewer.Draw(tempSprite);
                        }
                    }
                }
            }

            if (MapEditor.Instance.DrawGridOnMaps)
                foreach (Vertex[] v in lines)
                    mapViewer.RenderSurface.Draw(v, PrimitiveType.Lines); // Because i forgot to include Draw Overloads.

            foreach (SelectedTileArea st in MapEditor.Instance.SelectingArea)
            {
                int mouseY = (Mouse.GetPosition(mapViewer.RenderSurface).X + offsetY) / tempy;
                int mouseX = (Mouse.GetPosition(mapViewer.RenderSurface).X + offsetX) / tempx;

                tempSprite = new Sprite(MapEditor.Instance.Tilesets[st.tileset]);
                tempSprite.Position = new Vector2f((mouseX + st.offsetX) * tempx, (mouseY + st.offsetY) * tempy);

                tempSprite.TextureRect = new IntRect(st.id % (int)(tempSprite.Texture.Size.X / tempx) * tempx,
                    st.id / (int)(tempSprite.Texture.Size.X / tempx) * tempy, tempx, tempy);
            }
        }

        private void mapViewer_MouseDown(object sender, MouseEventArgs e)
        {
            pressedDown = true;
            placeTile(e.Location.X, e.Location.Y);
        }

        private void mapViewer_MouseMove(object sender, MouseEventArgs e)
        {
            if (pressedDown)
            {
                placeTile(e.Location.X, e.Location.Y);
            }
        }

        private void mapViewer_MouseUp(object sender, MouseEventArgs e)
        {
            pressedDown = false;
            lastDownTileX = -1;
            lastDownTileY = -1;

            UndoRedoStack.AddItem(placedTile);
        }

        private void mapViewer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ModifierKeys == Keys.ControlKey && e.KeyChar == (char)Keys.C)
            {
                if (UndoRedoStack.CanUndo())
                {
                    UndoRedoStack.Undo();
                }
            }
        }

        private void UndoRedoStack_RedoHappened(object sender, UndoRedoEventArgs e)
        {
            List<PlacedTile> lp = (List<PlacedTile>)e.Item;
            foreach(PlacedTile p in lp)
            {
                map.tiles[p.Layer][p.Y * map.Width + p.X].tileset = p.Tileset;
                map.tiles[p.Layer][p.Y * map.Width + p.X].id = p.ID;
            }
        }

        private void UndoRedoStack_UndoHappened(object sender, UndoRedoEventArgs e)
        {
            List<PlacedTile> lp = (List<PlacedTile>)e.Item;
            foreach (PlacedTile p in lp)
            {
                map.tiles[p.Layer][p.Y * map.Width + p.X].tileset = p.Tileset;
                map.tiles[p.Layer][p.Y * map.Width + p.X].id = p.ID;
            }
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
