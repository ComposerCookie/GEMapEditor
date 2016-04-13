using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EGMapEditor
{
    public partial class MapLayersViewer : UserControl
    {
        private Map viewingMap { get; set; }

        public MapLayersViewer()
        {
            InitializeComponent();
        }

        public void ChangeMapData(Map m)
        {
            trvLayers.Nodes.Clear();

            if (m == null)
            {
                trvLayers.Nodes.Add("<No map loaded>");
                return;
            }

            if (m.layerNames.Count == 0)
            {
                trvLayers.Nodes.Add("<Map have no layers>");
                return;
            }

            foreach (string s in m.layerNames)
            {
                trvLayers.Nodes.Add(s);
            }

            viewingMap = m;
        }

        public int GetSelectedLayerIndex()
        {
            return trvLayers.SelectedNode.Index;
        }

        private void btnAddLayer_Click(object sender, EventArgs e)
        {
            viewingMap.AddLayer();
            trvLayers.Nodes.Add(viewingMap.layerNames[viewingMap.layerNames.Count]);
        }
    }
}
