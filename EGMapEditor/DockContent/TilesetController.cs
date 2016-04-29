using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DockPanel;
using SFML.Graphics;

namespace EGMapEditor
{
    public partial class TilesetController : DockContent
    {
        public TilesetController()
        {
            InitializeComponent();

            _tempSprite = null;
            _lines = new List<Vertex[]>();
            _grabRect = new RectangleShape
            {
                FillColor = Color.Transparent,
                OutlineColor = Color.Red,
                OutlineThickness = 2
            };

            _getMaxRow = 0;
            _getMaxTilePerRow = 0;
        }

        public void UpdateTilesetDisplay()
        {
            ChangeTileset(MapEditor.Instance.CurrentTileset);
            txtTileset.Text = MapEditor.Instance.CurrentTileset + 1 + "/" + MapEditor.Instance.Tilesets.Count;
            hScrTileset.Maximum = (int)MapEditor.Instance.Tilesets[MapEditor.Instance.CurrentTileset].Size.X - tilesetViewer.Size.Width + 4;
            vScrTileset.Maximum = (int)MapEditor.Instance.Tilesets[MapEditor.Instance.CurrentTileset].Size.Y - tilesetViewer.Size.Height + 4;
            hScrTileset.Value = 0;
            vScrTileset.Value = 0;
        }

        private void vScrTileset_Scroll(object sender, ScrollEventArgs e)
        {
            MoveCamera(hScrTileset.Value, vScrTileset.Value);
        }

        private void hScrTileset_Scroll(object sender, ScrollEventArgs e)
        {
            MoveCamera(hScrTileset.Value, vScrTileset.Value);
        }

        private void btnTSInc_Click(object sender, EventArgs e)
        {
            MapEditor.Instance.CurrentTileset++;
            if (MapEditor.Instance.CurrentTileset >= MapEditor.Instance.Tilesets.Count)
                MapEditor.Instance.CurrentTileset = 0;
            UpdateTilesetDisplay();
        }

        private void btnTSDec_Click(object sender, EventArgs e)
        {
            MapEditor.Instance.CurrentTileset--;
            if (MapEditor.Instance.CurrentTileset < 0)
                MapEditor.Instance.CurrentTileset = MapEditor.Instance.Tilesets.Count - 1;
            UpdateTilesetDisplay();
        }

        private void chkGrid_CheckedChanged(object sender, EventArgs e)
        {
            DrawGrid = chkGrid.Checked;
        }

        #region SFML Control

        private Sprite _tempSprite;
        private readonly List<Vertex[]> _lines;

        private bool _pressedDown;
        private int _downX;
        private int _downY;
        private int _offsetX;
        private int _offsetY;
        private readonly RectangleShape _grabRect;

        public bool DrawGrid { get; set; }

        //Font DEBUGGINGFONT = new SFML.Graphics.Font("arial.ttf");

        private int _getMaxTilePerRow;

        private int _getMaxRow;

        public void ChangeTileset(int t)
        {
            _tempSprite = new Sprite(MapEditor.Instance.Tilesets[t]) { Position = new SFML.System.Vector2f(0, 0) };
            _getMaxTilePerRow = (int)_tempSprite.Texture.Size.X / MapEditor.Instance.TILE_WIDTH;
            _getMaxRow = (int)_tempSprite.Texture.Size.Y / MapEditor.Instance.TILE_HEIGHT;

            _lines.Clear();

            int tempx = MapEditor.Instance.TILE_WIDTH;
            int tempy = MapEditor.Instance.TILE_HEIGHT;

            for (int i = 0; i < _tempSprite.Texture.Size.X / tempx; i++)
                _lines.Add(new[] { new Vertex(new SFML.System.Vector2f(i * tempx, 0)), new Vertex(new SFML.System.Vector2f(i * tempx, _tempSprite.Texture.Size.Y)) });
            for (int i = 0; i < _tempSprite.Texture.Size.Y / tempy; i++)
                _lines.Add(new[] { new Vertex(new SFML.System.Vector2f(0, i * tempy)), new Vertex(new SFML.System.Vector2f(_tempSprite.Texture.Size.X, i * tempy)) });

            MoveCamera(0, 0);
        }

        public void MoveCamera(int offX, int offY)
        {
            _offsetX = offX;
            _offsetY = offY;
            if (tilesetViewer.View != null)
            {
                tilesetViewer.View.Center = new SFML.System.Vector2f(offX + hScrTileset.Size.Width / 2, offY + vScrTileset.Size.Height / 2);
                tilesetViewer_Render();
            }
        }

        #region Events

        private void tilesetViewer_Resize(object sender, EventArgs e)
        {
            if (tilesetViewer.RenderSurface == null) return;
            tilesetViewer.RenderSurface.Size = new SFML.System.Vector2u((uint)hScrTileset.Size.Width, (uint)vScrTileset.Size.Height);
            tilesetViewer.View = new SFML.Graphics.View
            {
                Center = new SFML.System.Vector2f(_offsetX + hScrTileset.Size.Width / 2, _offsetY + vScrTileset.Size.Height / 2),
                Size = new SFML.System.Vector2f(hScrTileset.Size.Width, vScrTileset.Size.Height)
            };
        }

        private void tilesetViewer_Render()
        {
            if (_tempSprite != null)
                tilesetViewer.Draw(_tempSprite);

            if (DrawGrid)
                foreach (Vertex[] v in _lines)
                    tilesetViewer.RenderSurface.Draw(v, PrimitiveType.Lines); // <- Forgot to method overload on Draw...



            /*for (int y = 0; y < _tempSprite.Texture.Size.Y / 32; y++)
            {
                for (int x = 0; x < _tempSprite.Texture.Size.X / 32; x++)
                {
                    screen.Draw(new Text("" + (y * _getMaxTilePerRow + x), DEBUGGINGFONT) { Position = new SFML.System.Vector2f(x * 32, y * 32), Color = SFML.Graphics.Color.White, CharacterSize = 10 });
                }
            }*/

            tilesetViewer.Draw(_grabRect);
        }

        private void tilesetViewer_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !_pressedDown)
            {
                int tempx = MapEditor.Instance.TILE_WIDTH;
                int tempy = MapEditor.Instance.TILE_HEIGHT;
                _pressedDown = true;
                _downX = e.Location.X / tempx * tempx;
                _downY = e.Location.Y / tempy * tempy;
                _grabRect.Position = new SFML.System.Vector2f((e.Location.X + _offsetX) / tempx * tempx, (e.Location.Y + _offsetY) / tempy * tempy);
                _grabRect.Size = new SFML.System.Vector2f(tempx, tempy);
            }
        }

        private void tilesetViewer_MouseMove(object sender, MouseEventArgs e)
        {
            if (_pressedDown)
            {
                int tempx = MapEditor.Instance.TILE_WIDTH;
                int tempy = MapEditor.Instance.TILE_HEIGHT;
                int extraOffsetX = e.Location.X - _downX < 0 ? -tempx : tempx;
                int extraOffsetY = e.Location.Y - _downY < 0 ? -tempy : tempy;
                _grabRect.Size = new SFML.System.Vector2f((e.Location.X - _downX) / tempx * tempx + extraOffsetX, (e.Location.Y - _downY) / tempy * tempy + extraOffsetY);
            }
        }

        private void tilesetViewer_MouseUp(object sender, MouseEventArgs e)
        {
            if (_pressedDown)
            {
                _pressedDown = false;
                if (_grabRect.Size.X < 0)
                {
                    _grabRect.Position = new SFML.System.Vector2f(_grabRect.Position.X + _grabRect.Size.X, _grabRect.Position.Y);
                    _grabRect.Size = new SFML.System.Vector2f(-_grabRect.Size.X, _grabRect.Size.Y);
                }
                if (_grabRect.Size.Y < 0)
                {
                    _grabRect.Position = new SFML.System.Vector2f(_grabRect.Position.X, _grabRect.Position.Y + _grabRect.Size.Y);
                    _grabRect.Size = new SFML.System.Vector2f(_grabRect.Size.X, -_grabRect.Size.Y);
                }

                int tempx = MapEditor.Instance.TILE_WIDTH;
                int tempy = MapEditor.Instance.TILE_HEIGHT;

                MapEditor.Instance.SelectingArea.Clear();
                for (int y = 0; y < _grabRect.Size.Y / MapEditor.Instance.TILE_HEIGHT; y++)
                {
                    for (int x = 0; x < _grabRect.Size.X / MapEditor.Instance.TILE_WIDTH; x++)
                    {
                        MapEditor.Instance.SelectingArea.Add(new SelectedTileArea(x, y, (int)(_grabRect.Position.Y / tempy + y) * _getMaxTilePerRow + (int)(_grabRect.Position.X / tempx + x), MapEditor.Instance.CurrentTileset));
                        //Console.Write((int)(_grabRect.Position.Y / tempy + y) * _getMaxTilePerRow + (int)(_grabRect.Position.X / tempx + x) + " ");
                    }
                }
            }
        }

        private void tilesetViewer_MouseLeave(object sender, EventArgs e)
        {
            if (_pressedDown)
            {

            }

        }
        #endregion

        #endregion

        private void TilesetController_Resize(object sender, EventArgs e)
        {

        }
    }
}
