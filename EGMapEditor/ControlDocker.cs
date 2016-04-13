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
    public partial class ControlDocker : UserControl
    {
        public ControlDocker()
        {
            InitializeComponent();
        }

        public void AddToBottomDock(UserControl u)
        {
            TabPage p = new TabPage();
            u.Dock = DockStyle.Fill;
            u.Location = new Point(0, 0);

            p.Controls.Add(u);
            u.Tag = p;

            tabDockBottom.TabPages.Add(p);
        }
    }
}
