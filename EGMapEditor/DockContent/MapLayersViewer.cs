using System;

using System.Linq;
using System.Windows.Forms;

namespace EGMapEditor
{
    public partial class MapLayersViewer : DockContent
    {
        private Map ViewingMap { get; set; }

        public MapLayersViewer()
        {
            InitializeComponent();
        }

        public void ChangeMapData(Map m)
        {
            trvLayers.Nodes.Clear();

            if (m == null)
            {
                trvLayers.Nodes.Add("<No Map loaded>");
                return;
            }

            if (m.Layers.Count == 0)
            {
                trvLayers.Nodes.Add("<Map have no layers>");
                return;
            }

            for (int i = m.Layers.Count - 1; i >= 0; i--)
            {
                trvLayers.Nodes.Add(m.Layers[i].Name);
            }

            trvLayers.SelectedNode = trvLayers.Nodes[trvLayers.Nodes.Count - 1 - MapEditor.Instance.CurrentFocusedMap.CurrentEditLayer];

            ViewingMap = m;
        }

        public int GetSelectedLayerIndex()
        {
            if (ViewingMap != null && trvLayers.SelectedNode != null && trvLayers.SelectedNode.Index < trvLayers.Nodes.Count - 1 && ViewingMap.Layers.Count > 0) { 
                return trvLayers.SelectedNode.Index;
            }
            return -1;
        }

        private void btnAddLayer_Click(object sender, EventArgs e)
        {
            if (ViewingMap == null)
                return;
            ViewingMap.AddLayer("Layer " + (trvLayers.Nodes.Count + 1));
            trvLayers.Nodes.Insert(0, ViewingMap.Layers[ViewingMap.Layers.Count - 1].Name);
        }

        private void btnMoveLayerUp_Click(object sender, EventArgs e)
        {
            if (ViewingMap != null && trvLayers.SelectedNode != null && trvLayers.SelectedNode.Index > 0 && ViewingMap.Layers.Count > 1)
            {
                ViewingMap.LayerShiftUp(ViewingMap.Layers.Count - trvLayers.SelectedNode.Index - 1);

                int index = trvLayers.SelectedNode.Index;
                TreeNode temp3 = trvLayers.SelectedNode;
                trvLayers.Nodes.Remove(trvLayers.SelectedNode);
                trvLayers.Nodes.Insert(index - 1, temp3);

            }
        }

        private void btnMoveLayerDown_Click(object sender, EventArgs e)
        {
            if (ViewingMap != null && trvLayers.SelectedNode != null && trvLayers.SelectedNode.Index < trvLayers.Nodes.Count - 1 && ViewingMap.Layers.Count > 1)
            {
                ViewingMap.LayerShiftDown(ViewingMap.Layers.Count - trvLayers.SelectedNode.Index - 1);

                int index = trvLayers.SelectedNode.Index;
                TreeNode temp3 = trvLayers.SelectedNode;
                trvLayers.Nodes.Remove(trvLayers.SelectedNode);
                trvLayers.Nodes.Insert(index + 1, temp3);
                
            }
        }

        private void btnDeleteLayer_Click(object sender, EventArgs e)
        {
            if (ViewingMap != null && trvLayers.SelectedNode != null && trvLayers.SelectedNode.Index < trvLayers.Nodes.Count - 1 && ViewingMap.Layers.Count > 0)
            {
                ViewingMap.RemoveLayer(ViewingMap.Layers.Count - trvLayers.SelectedNode.Index - 1);
                trvLayers.Nodes.Remove(trvLayers.SelectedNode);
            }
        }

        private void trvLayers_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (ViewingMap != null && trvLayers.SelectedNode != null && trvLayers.SelectedNode.Index < trvLayers.Nodes.Count && ViewingMap.Layers.Count > 0)
            {
                MapEditor.Instance.CurrentFocusedMap.CurrentEditLayer = trvLayers.Nodes.Count - 1 - trvLayers.SelectedNode.Index;
            }
        }
    }
}
