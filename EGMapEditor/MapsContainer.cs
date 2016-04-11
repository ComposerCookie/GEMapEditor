using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace EGMapEditor
{
    public partial class MapsContainer : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public MapsContainer()
        {
            InitializeComponent();

            
        }

        public void OpenMap(Map m)
        {
            TabPage tp = new TabPage();
            tp.Text = @m.Name;
            
            MapController mc = new MapController(m);
            mc.Dock = DockStyle.Fill;

            tp.Controls.Add(mc);
            tabMapsController.TabPages.Add(tp);
        }

        private void MapsContainer_Resize(object sender, EventArgs e)
        {
            Thread.Sleep(10);
            tabMapsController.Height = Size.Height - 117;
        }

        private void chkGrid_CheckedChanged(object sender, EventArgs e)
        {
            MapEditor.Instance.DrawGridOnMaps = chkGrid.Checked;
        }
    }
}
