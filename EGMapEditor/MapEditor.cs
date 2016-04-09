using System;
using System.IO;
using System.Windows.Forms;
using SFML.Graphics;

namespace EGMapEditor
{
    public partial class MapEditor : Form
    {
        private static MapEditor _instance;

        public static MapEditor Instance => _instance ?? (_instance = new MapEditor());

        private string TilesetPath() { return Application.StartupPath + "/Tileset/"; }
        private Texture[] Tilesets;

        public MapEditor()
        {
            InitializeComponent();
            LoadTilesets();
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

        private void LoadTilesets()
        {
            var i = 1;
            var tPath = TilesetPath();

            while (File.Exists(tPath + i + ".png"))
                i++;

            Tilesets = new Texture[i];
            var maxGfx = (byte)i;

            for (i = 1; i < maxGfx; i++)
                Tilesets[i] = new Texture(tPath + i + ".png");
        }
    }
}
