using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SFML.Graphics;
using WeifenLuo.WinFormsUI.Docking;

namespace EGMapEditor
{
    public partial class TilesetController : DockContent
    {
        public TilesetController()
        {
            InitializeComponent();

            tempSprite = null;
            lines = new List<Vertex[]>();
            grabRect = new RectangleShape
            {
                FillColor = SFML.Graphics.Color.Transparent,
                OutlineColor = SFML.Graphics.Color.Red,
                OutlineThickness = 2
            };
        }

        public void UpdateTilesetDisplay()
        {
            changeTileset(MapEditor.Instance.CurrentTileset);
            txtTileset.Text = (MapEditor.Instance.CurrentTileset + 1) + "/" + MapEditor.Instance.Tilesets.Count;
            hScrTileset.Maximum = (int)MapEditor.Instance.Tilesets[MapEditor.Instance.CurrentTileset].Size.X - tilesetViewer.Size.Width + 4;
            vScrTileset.Maximum = (int)MapEditor.Instance.Tilesets[MapEditor.Instance.CurrentTileset].Size.Y - tilesetViewer.Size.Height + 4;
            hScrTileset.Value = 0;
            vScrTileset.Value = 0;
        }

        private void vScrTileset_Scroll(object sender, ScrollEventArgs e)
        {
            moveCamera(hScrTileset.Value, vScrTileset.Value);
        }

        private void hScrTileset_Scroll(object sender, ScrollEventArgs e)
        {
            moveCamera(hScrTileset.Value, vScrTileset.Value);
        }

        private void btnTSInc_Click(object sender, System.EventArgs e)
        {
            MapEditor.Instance.CurrentTileset++;
            if (MapEditor.Instance.CurrentTileset >= MapEditor.Instance.Tilesets.Count)
                MapEditor.Instance.CurrentTileset = 0;
            UpdateTilesetDisplay();
        }

        private void btnTSDec_Click(object sender, System.EventArgs e)
        {
            MapEditor.Instance.CurrentTileset--;
            if (MapEditor.Instance.CurrentTileset < 0)
                MapEditor.Instance.CurrentTileset = MapEditor.Instance.Tilesets.Count - 1;
            UpdateTilesetDisplay();
        }

        private void chkGrid_CheckedChanged(object sender, System.EventArgs e)
        {
            DrawGrid = chkGrid.Checked;
        }

        #region SFML Control

        private Sprite tempSprite;
        private List<Vertex[]> lines;

        private bool pressedDown;
        private int downX = 0;
        private int downY = 0;
        private int offsetX = 0;
        private int offsetY = 0;
        private RectangleShape grabRect;

        public bool DrawGrid { get; set; }

        //Font DEBUGGINGFONT = new SFML.Graphics.Font("arial.ttf");

        private int GetMaxTilePerRow => (int)tempSprite.Texture.Size.X / MapEditor.Instance.TILE_WIDTH;

        private int GetMaxRow => (int)tempSprite.Texture.Size.Y / MapEditor.Instance.TILE_HEIGHT;

        public void changeTileset(int t)
        {
            tempSprite = new Sprite(MapEditor.Instance.Tilesets[t]) { Position = new SFML.System.Vector2f(0, 0) };

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
            if (tilesetViewer.View != null)
                tilesetViewer.View.Center = new SFML.System.Vector2f(offX + Size.Width / 2, offY + Size.Height / 2);
        }

        #region Events

        private void tilesetViewer_Resize(object sender, EventArgs e)
        {
            tilesetViewer.RenderSurface.Size = new SFML.System.Vector2u((uint)Size.Width, (uint)Size.Height);
            tilesetViewer.View = new SFML.Graphics.View
            {
                Center = new SFML.System.Vector2f(Size.Width / 2, Size.Height / 2),
                Size = new SFML.System.Vector2f(Size.Width, Size.Height)
            };
        }

        private void tilesetViewer_Render(object sender, EventArgs e)
        {
            if (tempSprite != null)
                tilesetViewer.Draw(tempSprite);

            if (DrawGrid)
                foreach (Vertex[] v in lines)
                    tilesetViewer.RenderSurface.Draw(v, PrimitiveType.Lines); // <- Forgot to method overload on Draw...



            /*for (int y = 0; y < tempSprite.Texture.Size.Y / 32; y++)
            {
                for (int x = 0; x < tempSprite.Texture.Size.X / 32; x++)
                {
                    screen.Draw(new Text("" + (y * GetMaxTilePerRow + x), DEBUGGINGFONT) { Position = new SFML.System.Vector2f(x * 32, y * 32), Color = SFML.Graphics.Color.White, CharacterSize = 10 });
                }
            }*/

            tilesetViewer.Draw(grabRect);
        }

        private void tilesetViewer_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !pressedDown)
            {
                int tempx = MapEditor.Instance.TILE_WIDTH;
                int tempy = MapEditor.Instance.TILE_HEIGHT;
                pressedDown = true;
                downX = e.Location.X / tempx * tempx;
                downY = e.Location.Y / tempy * tempy;
                grabRect.Position = new SFML.System.Vector2f((e.Location.X + offsetX) / tempx * tempx, (e.Location.Y + offsetY) / tempy * tempy);
                grabRect.Size = new SFML.System.Vector2f(tempx, tempy);
            }
        }

        private void tilesetViewer_MouseMove(object sender, MouseEventArgs e)
        {
            if (pressedDown)
            {
                int tempx = MapEditor.Instance.TILE_WIDTH;
                int tempy = MapEditor.Instance.TILE_HEIGHT;
                int extraOffsetX = (e.Location.X - downX) < 0 ? -tempx : tempx;
                int extraOffsetY = (e.Location.Y - downY) < 0 ? -tempy : tempy;
                grabRect.Size = new SFML.System.Vector2f((e.Location.X - downX) / tempx * tempx + extraOffsetX, (e.Location.Y - downY) / tempy * tempy + extraOffsetY);
            }
        }

        private void tilesetViewer_MouseUp(object sender, MouseEventArgs e)
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
                        MapEditor.Instance.SelectingArea.Add(new SelectedTileArea(x, y, (int)(grabRect.Position.Y / tempy + y) * GetMaxTilePerRow + (int)(grabRect.Position.X / tempx + x), MapEditor.Instance.CurrentTileset));
                        //Console.Write((int)(grabRect.Position.Y / tempy + y) * GetMaxTilePerRow + (int)(grabRect.Position.X / tempx + x) + " ");
                    }
                }
            }
        }

        private void tilesetViewer_MouseLeave(object sender, EventArgs e)
        {
            if (pressedDown)
            {

            }

        }
        #endregion
        #endregion
    }
}
