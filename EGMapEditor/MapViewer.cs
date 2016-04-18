using System;
using System.Windows.Forms;
using System.Collections.Generic;
using SFML.Graphics;

namespace EGMapEditor
{
    public partial class MapViewer : UserControl
    {
        private RenderWindow screen;
        private Map map;
        private SFML.Graphics.View view;
        private Sprite tempSprite;
        private List<Vertex[]> lines;
        private bool pressedDown;

        private int offsetX;
        private int offsetY;

        public int CurrentEditLayer { get; set; }

        public MapViewer(Map m)
        {
            InitializeComponent();

            screen = new RenderWindow(this.Handle);
            view = new SFML.Graphics.View(new FloatRect(0, 0, Size.Width, Size.Height));
            screen.SetView(view);
            tempSprite = new Sprite();
            lines = new List<Vertex[]>();
            pressedDown = false;

            map = m;

            int tempx = MapEditor.Instance.TILE_WIDTH;
            int tempy = MapEditor.Instance.TILE_HEIGHT;

            for (int i = 0; i < m.Width; i++)
                lines.Add(new Vertex[] { new Vertex(new SFML.System.Vector2f(i * tempx, 0)), new Vertex(new SFML.System.Vector2f(i * tempx, map.Height * tempy)) });
            for (int i = 0; i < m.Height; i++)
                lines.Add(new Vertex[] { new Vertex(new SFML.System.Vector2f(0, i * tempy)), new Vertex(new SFML.System.Vector2f(map.Width * tempx, i * tempy)) });

            Application.Idle += Render;
        }

        private void Render(object sender, EventArgs e)
        {
            if (screen != null)
            {
                screen.Clear(SFML.Graphics.Color.Transparent);

                for (int y = 0; y < map.Height; y++)
                {
                    for (int x = 0; x < map.Height; x++)
                    {
                        if (map.tiles[CurrentEditLayer][y * map.Width + x].tileset >= 0 && map.tiles[CurrentEditLayer][y * map.Width + x].id >= 0)
                        {
                            tempSprite = new Sprite(MapEditor.Instance.Tilesets[map.tiles[CurrentEditLayer][y * map.Width + x].tileset]);
                            tempSprite.Position = new SFML.System.Vector2f(x * MapEditor.Instance.TILE_WIDTH, y * MapEditor.Instance.TILE_HEIGHT);
                            tempSprite.TextureRect = new IntRect(map.tiles[CurrentEditLayer][y * map.Width + x].id % (int)(tempSprite.Texture.Size.X / MapEditor.Instance.TILE_WIDTH) * MapEditor.Instance.TILE_WIDTH, 
                                map.tiles[CurrentEditLayer][y * map.Width + x].id / (int)(tempSprite.Texture.Size.X / MapEditor.Instance.TILE_WIDTH) * MapEditor.Instance.TILE_HEIGHT, 
                                MapEditor.Instance.TILE_WIDTH, 
                                MapEditor.Instance.TILE_HEIGHT);
                            screen.Draw(tempSprite);
                        }
                    }
                }

                if (MapEditor.Instance.DrawGridOnMaps)
                    foreach (Vertex[] v in lines)
                        screen.Draw(v, PrimitiveType.Lines);

                screen.Display();
            }
        }

        public void moveCamera(int offX, int offY)
        {
            offsetX = offX;
            offsetY = offY;
            view.Center = new SFML.System.Vector2f(offX + Size.Width / 2, offY + Size.Height / 2);
            screen.SetView(view);
            Render(null, null);
        }

        private void placeTile(int mouseX, int mouseY)
        {
            int tempx = MapEditor.Instance.TILE_WIDTH;
            int tempy = MapEditor.Instance.TILE_HEIGHT;

            foreach (SelectedTileArea st in MapEditor.Instance.SelectingArea)
            {
                int clickedY = (mouseY + offsetY) / tempy * map.Width;
                int clickedX = (mouseX + offsetX) / tempx;
                if (clickedY + clickedX + st.offsetY * map.Width + st.offsetX < map.tiles[CurrentEditLayer].Length)
                {
                    map.tiles[CurrentEditLayer][clickedY + clickedX + st.offsetY * map.Width + st.offsetX].id = st.id;
                    map.tiles[CurrentEditLayer][clickedY + clickedX + st.offsetY * map.Width + st.offsetX].tilesetName = MapEditor.Instance.TilesetString[st.tileset];
                    map.tiles[CurrentEditLayer][clickedY + clickedX + st.offsetY * map.Width + st.offsetX].tileset = st.tileset;
                }
            }
        }

        private void MapViewer_Resize(object sender, EventArgs e)
        {
            screen.Size = new SFML.System.Vector2u((uint)Size.Width, (uint)Size.Height);
            view.Size = new SFML.System.Vector2f(Size.Width, Size.Height);
            view.Center = new SFML.System.Vector2f(Size.Width / 2, Size.Height / 2);
            screen.SetView(view);
        }

        private void MapViewer_MouseDown(object sender, MouseEventArgs e)
        {
            pressedDown = true;
            placeTile(e.Location.X, e.Location.Y);
        }

        private void MapViewer_MouseMove(object sender, MouseEventArgs e)
        {
            if (pressedDown)
            {
                placeTile(e.Location.X, e.Location.Y);
            }
        }

        private void MapViewer_MouseUp(object sender, MouseEventArgs e)
        {
            pressedDown = false;
        }
    }
}
