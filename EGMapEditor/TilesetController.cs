using System;
using System.Windows.Forms;

namespace EGMapEditor
{
    public partial class TilesetController : UserControl
    {
        private TilesetViewer tilesetViewer;

        public TilesetController()
        {
            InitializeComponent();

            tilesetViewer = new TilesetViewer();
            tilesetViewer.Name = "tilesetViewer";
            tilesetViewer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left))));
            Controls.Add(tilesetViewer);
        }

        public void UpdateTilesetDisplay()
        {
            tilesetViewer.changeTileset(MapEditor.Instance.CurrentTileset);
            txtTileset.Text = (MapEditor.Instance.CurrentTileset + 1) + "/" + MapEditor.Instance.Tilesets.Count;
            hScrTileset.Maximum = (int)MapEditor.Instance.Tilesets[MapEditor.Instance.CurrentTileset].Size.X - tilesetViewer.Size.Width + 4;
            vScrTileset.Maximum = (int)MapEditor.Instance.Tilesets[MapEditor.Instance.CurrentTileset].Size.Y - tilesetViewer.Size.Height + 4;
            hScrTileset.Value = 0;
            vScrTileset.Value = 0;
        }

        private void vScrTileset_Scroll(object sender, ScrollEventArgs e)
        {
            tilesetViewer.moveCamera(hScrTileset.Value, vScrTileset.Value);
            //Console.Write(vScrTileset.Value + " ");
        }

        private void hScrTileset_Scroll(object sender, ScrollEventArgs e)
        {
            tilesetViewer.moveCamera(hScrTileset.Value, vScrTileset.Value);
            //Console.Write(hScrTileset.Value + " ");
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

        private void TilesetController_Resize(object sender, System.EventArgs e)
        {
            hScrTileset.Width = Size.Width - 22;
            vScrTileset.Height = Size.Height - 61;
            tilesetViewer.Width = Size.Width - 22;
            tilesetViewer.Height = Size.Height - 61;
        }

        private void chkGrid_CheckedChanged(object sender, System.EventArgs e)
        {
            tilesetViewer.DrawGrid = chkGrid.Checked;
        }

        private void TilesetController_Load(object sender, EventArgs e)
        {

        }
    }
}
