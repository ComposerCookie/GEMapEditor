using System.Windows.Forms;
using System.Collections.Generic;

namespace EGMapEditor
{
    public partial class ProjectExplorer : DockContent
    {
        private readonly TreeNode _networkMaps;
        private readonly TreeNode _localMaps;
        private readonly TreeNode _sessionMaps;


        public ProjectExplorer()
        {
            InitializeComponent();
            _networkMaps = new TreeNode("Network Maps: ");
            _localMaps = new TreeNode("Local Maps: ");
            _sessionMaps = new TreeNode("Session Maps: ");

            LoadExplorer();
        }

        public void LoadExplorer()
        {
            trvExplorer.Nodes.Clear();
            trvExplorer.Nodes.Add(_networkMaps);
            LoadNetworkMaps();
            trvExplorer.Nodes.Add(_localMaps);
            LoadLocalMaps();
            trvExplorer.Nodes.Add(_sessionMaps);
            LoadSessionMaps();
        }

        public void LoadNetworkMaps()
        {
            _networkMaps.Nodes.Clear();
        }

        public void LoadLocalMaps()
        {
            _localMaps.Nodes.Clear();
        }

        public void LoadSessionMaps()
        {
            _sessionMaps.Nodes.Clear();
            foreach (Map m in MapEditor.Instance.SessionMaps)
            {
                if (m.Tag != null)
                    OpenSessionMap(m.Tag);
            }
        }

        public void OpenSessionMap(MapController mc)
        {
            _sessionMaps.Nodes.Add(new TreeNode() { Text = mc.Map.Name, Tag = mc});
        }

        public void CloseSessionMap(MapController mc)
        {
            for (int i = _sessionMaps.Nodes.Count - 1; i > -1; i--)
            {
                if (_sessionMaps.Nodes[i].Tag == mc)
                    _sessionMaps.Nodes[i].Remove();
            }
        }

        private void trvExplorer_DoubleClick(object sender, System.EventArgs e)
        {
            if (trvExplorer.SelectedNode.Parent == _sessionMaps)
            {
                if (trvExplorer.SelectedNode.Tag != null)
                {
                    MapController mc = (MapController)trvExplorer.SelectedNode.Tag;
                    mc.Focus();
                }
            }
        }
    }
}
