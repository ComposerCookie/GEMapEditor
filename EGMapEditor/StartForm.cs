using System;
using System.Drawing;
using System.Windows.Forms;

namespace EGMapEditor
{
    public partial class StartForm : Form
    {
        bool connected = false;

        public StartForm()
        {
            InitializeComponent();
        }

        private void rdbtnOnline_CheckedChanged(object sender, EventArgs e)
        {
            btnConnect.Enabled = true;
            if (!connected)
                btnEnter.Enabled = false;
        }

        private void rdbtnOffline_CheckedChanged(object sender, EventArgs e)
        {
            btnConnect.Enabled = false;
            btnEnter.Enabled = true;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (connected)
            {

            }

            Hide();
            if (rdbtnSSize1.Checked)
                MapEditor.Instance.Size = new Size(800, 600);
            else if (rdbtnSSize2.Checked)
                MapEditor.Instance.Size = new Size(1024, 768);
            else if (rdbtnSSize3.Checked)
                MapEditor.Instance.Size = new Size(1366, 768);
            else if (rdbtnSSize4.Checked)
                MapEditor.Instance.Size = new Size(1920, 1080);
            MapEditor.Instance.Show();
        }

        private void StartForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            if (this.DialogResult == DialogResult.Cancel)
            {
                MapEditor.Instance.Close();
            }
        }
    }
}
