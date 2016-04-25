using System;

using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DockPanel;

namespace EGMapEditor
{
    public partial class MapLayersViewer : DockContent
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

            foreach (string s in m.layerNames.Reverse<string>())
            {
                trvLayers.Nodes.Add(s);
            }

            trvLayers.SelectedNode = trvLayers.Nodes[trvLayers.Nodes.Count - 1 - MapEditor.Instance.CurrentFocusedMap.CurrentEditLayer];

            viewingMap = m;
        }

        public int GetSelectedLayerIndex()
        {
            if (viewingMap != null && trvLayers.SelectedNode != null && trvLayers.SelectedNode.Index < trvLayers.Nodes.Count - 1 && viewingMap.tiles.Count > 0) { 
                return trvLayers.SelectedNode.Index;
            }
            return -1;
        }

        private void btnAddLayer_Click(object sender, EventArgs e)
        {
            if (viewingMap == null)
                return;
            viewingMap.AddLayer("Layer " + trvLayers.Nodes.Count);
            trvLayers.Nodes.Insert(0, viewingMap.layerNames[viewingMap.layerNames.Count - 1]);
        }

        private void btnMoveLayerUp_Click(object sender, EventArgs e)
        {
            if (viewingMap != null && trvLayers.SelectedNode != null && trvLayers.SelectedNode.Index > 0 && viewingMap.tiles.Count > 1)
            {
                Tile[] temp = viewingMap.tiles[viewingMap.tiles.Count - trvLayers.SelectedNode.Index];
                viewingMap.tiles[viewingMap.tiles.Count - trvLayers.SelectedNode.Index] = viewingMap.tiles[viewingMap.tiles.Count - trvLayers.SelectedNode.Index + 1];
                viewingMap.tiles[viewingMap.tiles.Count - trvLayers.SelectedNode.Index - 1] = temp;

                string temp2 = viewingMap.layerNames[viewingMap.tiles.Count - trvLayers.SelectedNode.Index];
                viewingMap.layerNames[viewingMap.tiles.Count - trvLayers.SelectedNode.Index] = viewingMap.layerNames[viewingMap.tiles.Count - trvLayers.SelectedNode.Index + 1];
                viewingMap.layerNames[viewingMap.tiles.Count - trvLayers.SelectedNode.Index - 1] = temp2;

                TreeNode temp3 = trvLayers.SelectedNode;
                trvLayers.Nodes[trvLayers.SelectedNode.Index] = trvLayers.Nodes[trvLayers.SelectedNode.Index - 1];
                trvLayers.Nodes[trvLayers.SelectedNode.Index - 1] = temp3;

            }
        }

        private void btnMoveLayerDown_Click(object sender, EventArgs e)
        {
            if (viewingMap != null && trvLayers.SelectedNode != null && trvLayers.SelectedNode.Index < trvLayers.Nodes.Count - 1 && viewingMap.tiles.Count > 1)
            {
                Tile[] temp = viewingMap.tiles[viewingMap.tiles.Count - trvLayers.SelectedNode.Index];
                viewingMap.tiles[viewingMap.tiles.Count - trvLayers.SelectedNode.Index] = viewingMap.tiles[viewingMap.tiles.Count - trvLayers.SelectedNode.Index - 1];
                viewingMap.tiles[viewingMap.tiles.Count - trvLayers.SelectedNode.Index - 1] = temp;

                string temp2 = viewingMap.layerNames[viewingMap.tiles.Count - trvLayers.SelectedNode.Index];
                viewingMap.layerNames[viewingMap.tiles.Count - trvLayers.SelectedNode.Index] = viewingMap.layerNames[viewingMap.tiles.Count - trvLayers.SelectedNode.Index - 1];
                viewingMap.layerNames[viewingMap.tiles.Count - trvLayers.SelectedNode.Index - 1] = temp2;

                TreeNode temp3 = trvLayers.SelectedNode;
                trvLayers.Nodes[trvLayers.SelectedNode.Index] = trvLayers.Nodes[trvLayers.SelectedNode.Index + 1];
                trvLayers.Nodes[trvLayers.SelectedNode.Index + 1] = temp3;
            }
        }

        private void btnDeleteLayer_Click(object sender, EventArgs e)
        {
            if (viewingMap != null && trvLayers.SelectedNode != null && trvLayers.SelectedNode.Index < trvLayers.Nodes.Count - 1 && viewingMap.tiles.Count > 0)
            {
                viewingMap.tiles.RemoveAt(viewingMap.tiles.Count - trvLayers.SelectedNode.Index);
                viewingMap.layerNames.RemoveAt(viewingMap.tiles.Count - trvLayers.SelectedNode.Index);
                trvLayers.Nodes.Remove(trvLayers.SelectedNode);
            }
        }

        private void trvLayers_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (viewingMap != null && trvLayers.SelectedNode != null && trvLayers.SelectedNode.Index < trvLayers.Nodes.Count && viewingMap.tiles.Count > 0)
            {
                MapEditor.Instance.CurrentFocusedMap.CurrentEditLayer = trvLayers.Nodes.Count - 1 - trvLayers.SelectedNode.Index;
            }
        }
    }
}
