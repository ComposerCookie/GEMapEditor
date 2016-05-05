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

            if (m.LayerNames.Count == 0)
            {
                trvLayers.Nodes.Add("<Map have no layers>");
                return;
            }

            foreach (string s in m.LayerNames.Reverse<string>())
            {
                trvLayers.Nodes.Add(s);
            }

            trvLayers.SelectedNode = trvLayers.Nodes[trvLayers.Nodes.Count - 1 - MapEditor.Instance.CurrentFocusedMap.CurrentEditLayer];

            ViewingMap = m;
        }

        public int GetSelectedLayerIndex()
        {
            if (ViewingMap != null && trvLayers.SelectedNode != null && trvLayers.SelectedNode.Index < trvLayers.Nodes.Count - 1 && ViewingMap.Tiles.Count > 0) { 
                return trvLayers.SelectedNode.Index;
            }
            return -1;
        }

        private void btnAddLayer_Click(object sender, EventArgs e)
        {
            if (ViewingMap == null)
                return;
            ViewingMap.AddLayer("Layer " + trvLayers.Nodes.Count);
            trvLayers.Nodes.Insert(0, ViewingMap.LayerNames[ViewingMap.LayerNames.Count - 1]);
        }

        private void btnMoveLayerUp_Click(object sender, EventArgs e)
        {
            if (ViewingMap != null && trvLayers.SelectedNode != null && trvLayers.SelectedNode.Index > 0 && ViewingMap.Tiles.Count > 1)
            {
                Tile[] temp = ViewingMap.Tiles[ViewingMap.Tiles.Count - trvLayers.SelectedNode.Index];
                ViewingMap.Tiles[ViewingMap.Tiles.Count - trvLayers.SelectedNode.Index] = ViewingMap.Tiles[ViewingMap.Tiles.Count - trvLayers.SelectedNode.Index + 1];
                ViewingMap.Tiles[ViewingMap.Tiles.Count - trvLayers.SelectedNode.Index - 1] = temp;

                string temp2 = ViewingMap.LayerNames[ViewingMap.Tiles.Count - trvLayers.SelectedNode.Index];
                ViewingMap.LayerNames[ViewingMap.Tiles.Count - trvLayers.SelectedNode.Index] = ViewingMap.LayerNames[ViewingMap.Tiles.Count - trvLayers.SelectedNode.Index + 1];
                ViewingMap.LayerNames[ViewingMap.Tiles.Count - trvLayers.SelectedNode.Index - 1] = temp2;

                TreeNode temp3 = trvLayers.SelectedNode;
                trvLayers.Nodes[trvLayers.SelectedNode.Index] = trvLayers.Nodes[trvLayers.SelectedNode.Index - 1];
                trvLayers.Nodes[trvLayers.SelectedNode.Index - 1] = temp3;

            }
        }

        private void btnMoveLayerDown_Click(object sender, EventArgs e)
        {
            if (ViewingMap != null && trvLayers.SelectedNode != null && trvLayers.SelectedNode.Index < trvLayers.Nodes.Count - 1 && ViewingMap.Tiles.Count > 1)
            {
                Tile[] temp = ViewingMap.Tiles[ViewingMap.Tiles.Count - trvLayers.SelectedNode.Index];
                ViewingMap.Tiles[ViewingMap.Tiles.Count - trvLayers.SelectedNode.Index] = ViewingMap.Tiles[ViewingMap.Tiles.Count - trvLayers.SelectedNode.Index - 1];
                ViewingMap.Tiles[ViewingMap.Tiles.Count - trvLayers.SelectedNode.Index - 1] = temp;

                string temp2 = ViewingMap.LayerNames[ViewingMap.Tiles.Count - trvLayers.SelectedNode.Index];
                ViewingMap.LayerNames[ViewingMap.Tiles.Count - trvLayers.SelectedNode.Index] = ViewingMap.LayerNames[ViewingMap.Tiles.Count - trvLayers.SelectedNode.Index - 1];
                ViewingMap.LayerNames[ViewingMap.Tiles.Count - trvLayers.SelectedNode.Index - 1] = temp2;

                TreeNode temp3 = trvLayers.SelectedNode;
                trvLayers.Nodes[trvLayers.SelectedNode.Index] = trvLayers.Nodes[trvLayers.SelectedNode.Index + 1];
                trvLayers.Nodes[trvLayers.SelectedNode.Index + 1] = temp3;
            }
        }

        private void btnDeleteLayer_Click(object sender, EventArgs e)
        {
            if (ViewingMap != null && trvLayers.SelectedNode != null && trvLayers.SelectedNode.Index < trvLayers.Nodes.Count - 1 && ViewingMap.Tiles.Count > 0)
            {
                ViewingMap.Tiles.RemoveAt(ViewingMap.Tiles.Count - trvLayers.SelectedNode.Index);
                ViewingMap.LayerNames.RemoveAt(ViewingMap.Tiles.Count - trvLayers.SelectedNode.Index);
                trvLayers.Nodes.Remove(trvLayers.SelectedNode);
            }
        }

        private void trvLayers_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (ViewingMap != null && trvLayers.SelectedNode != null && trvLayers.SelectedNode.Index < trvLayers.Nodes.Count && ViewingMap.Tiles.Count > 0)
            {
                MapEditor.Instance.CurrentFocusedMap.CurrentEditLayer = trvLayers.Nodes.Count - 1 - trvLayers.SelectedNode.Index;
            }
        }
    }
}
