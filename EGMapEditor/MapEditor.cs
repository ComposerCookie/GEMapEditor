using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using SFML.Graphics;

namespace EGMapEditor
{
    public struct SelectedTileArea
    {
        int offsetX;
        int offsetY;
        int id;

        public SelectedTileArea(int oX, int oY, int _id)
        {
            offsetX = oX;
            offsetY = oY;
            id = _id;
        }
    }

    public partial class MapEditor : Form
    {
        static private MapEditor _instance;
        public static MapEditor Instance { get { return _instance; } }

        public int TILE_WIDTH { get { return 16; } }
        public int TILE_HEIGHT { get { return 16; } }

        private TilesetController tilesetController;

        private string TilesetPath() { return "/Tileset/"; }
        public List<Texture> Tilesets { get; set; }
        public List<string> TilesetString { get; set; }
        
        public int CurrentTileset { get; set; }

        public List<SelectedTileArea> SelectingArea { get; set; }

        public MapEditor()
        {
            InitializeComponent();

            _instance = this;

            tilesetController = new TilesetController();
            tilesetController.Name = "tilesetController";
            tilesetController.Size = new System.Drawing.Size(380, 400);
            tilesetController.Dock = DockStyle.Left;
            tilesetController.Location = new System.Drawing.Point(30, 30);
            Controls.Add(tilesetController);

            Tilesets = new List<Texture>();
            TilesetString = new List<string>();
            SelectingArea = new List<SelectedTileArea>();

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
            var tPath = TilesetPath();
            if (Directory.Exists(Application.StartupPath +  tPath))
            {
                string[] tempArray = Directory.GetFiles(Application.StartupPath + tPath, "*.png");
                foreach (string s in tempArray)
                {
                    string temp = Path.GetFileName(s);
                    TilesetString.Add(temp);
                    Tilesets.Add(new Texture(s));
                }
                if (Tilesets.Count > 0)
                {
                    CurrentTileset = 0;
                    tilesetController.UpdateTilesetDisplay();
                }
            }
            else
                Directory.CreateDirectory("Tileset");
        }

        private void menuAddTileset_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Title = @"Selected texture to import";
                dialog.Multiselect = true;
                dialog.CheckFileExists = true;
                dialog.CheckPathExists = true;
                dialog.Filter = @"Image Files|*.png;";

                var result = dialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    for (int i = 0; i < dialog.FileNames.Length; i++)
                    {
                        Tilesets.Add(new Texture(dialog.FileNames[i]));
                        TilesetString.Add(dialog.SafeFileNames[i]);
                    }
                    
                    CurrentTileset++;
                    tilesetController.UpdateTilesetDisplay();

                }
            }
        }

        private void menuAddMap_Click(object sender, EventArgs e)
        {
            mapsContainer.OpenMap(new Map());
        }
    }
}
