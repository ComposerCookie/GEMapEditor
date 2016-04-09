using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EGMapEditor
{
    public partial class MapEditor : Form
    {
        static readonly MapEditor _instance = new MapEditor();
        public static MapEditor Instance { get { return _instance; } }

        readonly string mapFolderPath = "Maps";

        public MapEditor()
        {
            InitializeComponent();

        }

        private void MapEditor_Load(object sender, EventArgs e)
        {
            
        }

        private void MapEditor_Shown(object sender, EventArgs e)
        {
            this.Hide();
            StartForm startForm = new StartForm();
            startForm.ShowDialog();
        }
    }
}
