using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace EGMapEditor
{
    public partial class MapController : UserControl
    {
        private MapViewer mapViewer;

        public MapController(Map m)
        {
            InitializeComponent();

            mapViewer = new MapViewer(m);
            mapViewer.Name = "mapViewer";
            mapViewer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left))));
            Controls.Add(mapViewer);

            vScrTileset.Maximum = m.Height * MapEditor.Instance.TILE_HEIGHT;
            hScrTileset.Maximum = m.Width * MapEditor.Instance.TILE_WIDTH;
        }

        private void MapController_Resize(object sender, System.EventArgs e)
        {
            hScrTileset.Width = Size.Width - 22;
            vScrTileset.Height = Size.Height - 22;

            Thread.Sleep(10);

            mapViewer.Width = Size.Width - 22;
            mapViewer.Height = Size.Height - 22;

            Thread.Sleep(10);
        }

        private void vScrTileset_Scroll(object sender, ScrollEventArgs e)
        {
            mapViewer.moveCamera(hScrTileset.Value, vScrTileset.Value);
        }

        private void hScrTileset_Scroll(object sender, ScrollEventArgs e)
        {
            mapViewer.moveCamera(hScrTileset.Value, vScrTileset.Value);
        }

        private void MapController_Load(object sender, EventArgs e)
        {

        }
    }
}
