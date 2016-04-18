using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DockPanel;
using SFML.Graphics;

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
                lines.Add(new Vertex[] { new Vertex(new SFML.System.Vector2f(i * tempx, 0)), new Vertex(new SFML.System.Vector2f(i * tempx, map.Height * tempy)) });
            for (int i = 0; i < m.Height; i++)
                lines.Add(new Vertex[] { new Vertex(new SFML.System.Vector2f(0, i * tempy)), new Vertex(new SFML.System.Vector2f(map.Width * tempx, i * tempy)) });

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
            mapViewer.View.Center = new SFML.System.Vector2f(offX + Size.Width / 2, offY + Size.Height / 2);
        }

        private void placeTile(int mouseX, int mouseY)
        {
            int tempx = MapEditor.Instance.TILE_WIDTH;
            int tempy = MapEditor.Instance.TILE_HEIGHT;

            int clickedY = (mouseY + offsetY) / tempy * map.Width;
            int clickedX = (mouseX + offsetX) / tempx;

            if (clickedX == lastDownTileX && clickedY == lastDownTileY)
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
            mapViewer.RenderSurface.Size = new SFML.System.Vector2u((uint)Size.Width, (uint)Size.Height);
            mapViewer.View = new SFML.Graphics.View
            {
                Center = new SFML.System.Vector2f(Size.Width / 2, Size.Height / 2),
                Size = new SFML.System.Vector2f(Size.Width, Size.Height)
            };
        }

        private void mapViewer_Render()
        {
            for (int l = 0; l < map.tiles.Count; l++)
            {
                for (int y = 0; y < map.Height; y++)
                {
                    for (int x = 0; x < map.Height; x++)
                    {
                        if (map.tiles[l][y * map.Width + x].tileset >= 0 && map.tiles[l][y * map.Width + x].id >= 0)
                        {
                            tempSprite = new Sprite(MapEditor.Instance.Tilesets[map.tiles[l][y * map.Width + x].tileset]);
                            tempSprite.Position = new SFML.System.Vector2f(x * MapEditor.Instance.TILE_WIDTH, y * MapEditor.Instance.TILE_HEIGHT);
                            tempSprite.TextureRect = new IntRect(map.tiles[l][y * map.Width + x].id % (int)(tempSprite.Texture.Size.X / MapEditor.Instance.TILE_WIDTH) * MapEditor.Instance.TILE_WIDTH,
                                map.tiles[l][y * map.Width + x].id / (int)(tempSprite.Texture.Size.X / MapEditor.Instance.TILE_WIDTH) * MapEditor.Instance.TILE_HEIGHT,
                                MapEditor.Instance.TILE_WIDTH,
                                MapEditor.Instance.TILE_HEIGHT);
                            mapViewer.Draw(tempSprite);
                        }
                    }
                }
            }

            if (MapEditor.Instance.DrawGridOnMaps)
                foreach (Vertex[] v in lines)
                    mapViewer.RenderSurface.Draw(v, PrimitiveType.Lines); // Because i forgot to include Draw Overloads.
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


    }
}
