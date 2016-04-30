using System.Windows.Forms.DockPanel;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EGMapEditor
{
    public partial class ProjectExplorer : DockContent
    {
        private readonly List<TreeNode> _networkMaps;
        private readonly List<TreeNode> _localMaps;
        private readonly List<TreeNode> _sessionMaps;


        public ProjectExplorer()
        {
            InitializeComponent();
            _networkMaps = new List<TreeNode>();
            _localMaps = new List<TreeNode>();
            _sessionMaps = new List<TreeNode>();
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
            _networkMaps.Clear();

            trvExplorer.Nodes[0].Nodes.AddRange(_networkMaps.ToArray());
        }

        public void LoadLocalMaps()
        {
            _localMaps.Clear();
        }

        public void LoadSessionMaps()
        {
            _sessionMaps.Clear();
        }
    }
}
