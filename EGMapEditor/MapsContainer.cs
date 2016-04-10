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
    public partial class MapsContainer : UserControl
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
            tabMapsController.Height = Size.Height - 117;
        }
    }
}
