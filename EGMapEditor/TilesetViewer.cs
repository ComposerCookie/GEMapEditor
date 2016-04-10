using System;
using System.Windows.Forms;
using System.Collections.Generic;
using SFML.Graphics;

namespace EGMapEditor
{
    public partial class TilesetViewer : UserControl
    {
        private RenderWindow screen;
        private Sprite tempSprite;
        private SFML.Graphics.View view;
        private List<Vertex[]> lines;

        private bool pressedDown;
        private int downX;
        private int downY;
        private int offsetX;
        private int offsetY;
        private RectangleShape grabRect;

        public bool DrawGrid { get; set; }

        private int GetMaxTilePerRow
        {
            get { return (int)tempSprite.Texture.Size.X / MapEditor.Instance.TILE_WIDTH; }
        }

        private int GetMaxRow
        {
            get { return (int)tempSprite.Texture.Size.Y / MapEditor.Instance.TILE_HEIGHT; }
        }

        public TilesetViewer()
        {
            InitializeComponent();
            screen = new RenderWindow(this.Handle);
            view = new SFML.Graphics.View(new FloatRect(0, 0, Size.Width, Size.Height));
            screen.SetView(view);
            offsetX = 0;
            offsetY = 0;
            tempSprite = null;
            lines = new List<Vertex[]>();
            grabRect = new RectangleShape();
            grabRect.FillColor = SFML.Graphics.Color.Transparent;
            grabRect.OutlineColor = SFML.Graphics.Color.Red;
            grabRect.OutlineThickness = 2;

            Application.Idle += Render;
        }

        private void Render(object sender, EventArgs e)
        {
            if (screen != null)
            {
                screen.Clear(SFML.Graphics.Color.Transparent);

                screen.Draw(tempSprite);
                if (DrawGrid)
                    foreach (Vertex[] v in lines)
                        screen.Draw(v, PrimitiveType.Lines);

                screen.Draw(grabRect);

                screen.Display();
            }
        }

        public void changeTileset(int t)
        {
            tempSprite = new Sprite(MapEditor.Instance.Tilesets[t]);
            tempSprite.Position = new SFML.System.Vector2f(0, 0);

            lines.Clear();

            int tempx = MapEditor.Instance.TILE_WIDTH;
            int tempy = MapEditor.Instance.TILE_HEIGHT;

            for (int i = 0; i < tempSprite.Texture.Size.X / tempx; i++)
                lines.Add(new Vertex[] { new Vertex(new SFML.System.Vector2f(i * tempx, 0)), new Vertex(new SFML.System.Vector2f(i * tempx, tempSprite.Texture.Size.Y)) });
            for (int i = 0; i < tempSprite.Texture.Size.Y / tempy; i++)
                lines.Add(new Vertex[] { new Vertex(new SFML.System.Vector2f(0, i * tempy)), new Vertex(new SFML.System.Vector2f(tempSprite.Texture.Size.X, i * tempy)) });

            moveCamera(0, 0);
        }

        public void moveCamera(int offX, int offY)
        {
            offsetX = offX;
            offsetY = offY;
            view.Center = new SFML.System.Vector2f(offX + Size.Width / 2, offY + Size.Height / 2);
            screen.SetView(view);
            Render(null, null);
        }

        private void TilesetViewer_Resize(object sender, EventArgs e)
        {
            screen.Size = new SFML.System.Vector2u((uint)Size.Width, (uint)Size.Height);
            view.Size = new SFML.System.Vector2f(Size.Width, Size.Height);
            view.Center = new SFML.System.Vector2f(Size.Width / 2, Size.Height / 2);
            screen.SetView(view);
        }

        private void TilesetViewer_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !pressedDown)
            {
                int tempx = MapEditor.Instance.TILE_WIDTH;
                int tempy = MapEditor.Instance.TILE_HEIGHT;
                pressedDown = true;
                downX = e.Location.X / tempx * tempx;
                downY = e.Location.Y / tempy * tempy;
                grabRect.Position = new SFML.System.Vector2f(downX + offsetX, downY + offsetY);
                grabRect.Size = new SFML.System.Vector2f(tempx, tempy);
            }
        }

        private void TilesetViewer_MouseMove(object sender, MouseEventArgs e)
        {
            if (pressedDown)
            {
                int tempx = MapEditor.Instance.TILE_WIDTH;
                int tempy = MapEditor.Instance.TILE_HEIGHT;
                int extraOffsetX = (e.Location.X - downX) < 0 ? -tempx : tempx;
                int extraOffsetY = (e.Location.Y - downY) < 0 ? -tempy : tempy;
                grabRect.Size = new SFML.System.Vector2f((e.Location.X - downX) / tempx * tempx + extraOffsetX, (e.Location.Y - downY) /tempy * tempy + extraOffsetY);

                Render(null, null);
            }
        }

        private void TilesetViewer_MouseUp(object sender, MouseEventArgs e)
        {
            if (pressedDown)
            {
                pressedDown = false;
                if (grabRect.Size.X < 0)
                {
                    grabRect.Position = new SFML.System.Vector2f(grabRect.Position.X + grabRect.Size.X, grabRect.Position.Y);
                    grabRect.Size = new SFML.System.Vector2f(-grabRect.Size.X, grabRect.Size.Y);
                }
                if (grabRect.Size.Y < 0)
                {
                    grabRect.Position = new SFML.System.Vector2f(grabRect.Position.X, grabRect.Position.Y + grabRect.Size.Y);
                    grabRect.Size = new SFML.System.Vector2f(grabRect.Size.X, -grabRect.Size.Y);
                }

                int tempx = MapEditor.Instance.TILE_WIDTH;
                int tempy = MapEditor.Instance.TILE_HEIGHT;

                MapEditor.Instance.SelectingArea.Clear();
                for (int y = 0; y < grabRect.Size.Y / MapEditor.Instance.TILE_HEIGHT; y++)
                {
                    for (int x = 0; x < grabRect.Size.X / MapEditor.Instance.TILE_WIDTH; x++)
                    {
                        MapEditor.Instance.SelectingArea.Add(new SelectedTileArea(x, y, (int)(grabRect.Position.Y / tempy + y) * GetMaxTilePerRow + (int)(grabRect.Position.X / tempx + x)));
                    }
                }
            }
        }

        private void TilesetViewer_MouseLeave(object sender, EventArgs e)
        {
            if (pressedDown)
            {

            }
        }
    }
}
