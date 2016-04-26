using System.Windows.Forms.DockPanel;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EGMapEditor
{
    public partial class ProjectExplorer : DockContent
    {
        private List<TreeNode> networkMaps;
        private List<TreeNode> localMaps;
        private List<TreeNode> sessionMaps;


        public ProjectExplorer()
        {
            InitializeComponent();
            networkMaps = new List<TreeNode>();
            localMaps = new List<TreeNode>();
            sessionMaps = new List<TreeNode>();
        }

        public void LoadExplorer()
        {
            trvExplorer.Nodes.Clear();
            trvExplorer.Nodes.Add("Network Maps: ");
            LoadNetworkMaps();
            trvExplorer.Nodes.Add("Local Maps: ");
            LoadLocalMaps();
            trvExplorer.Nodes.Add("Session Maps: ");
            LoadSessionMaps();
        }

        public void LoadNetworkMaps()
        {
            networkMaps.Clear();

            trvExplorer.Nodes[0].Nodes.AddRange(networkMaps.ToArray());
        }

        public void LoadLocalMaps()
        {
            localMaps.Clear();
        }

        public void LoadSessionMaps()
        {
            sessionMaps.Clear();
        }
    }
}
