using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Windows.Forms.DockPanel;
using SFML.Graphics;

namespace EGMapEditor
{
    public struct SelectedTileArea
    {
        public int OffsetX;
        public int OffsetY;
        public int Id;
        public int Tileset;

        public SelectedTileArea(int oX, int oY, int id, int ts)
        {
            OffsetX = oX;
            OffsetY = oY;
            Id = id;
            Tileset = ts;
        }
    }

    public partial class MapEditor : Form
    {
        private static MapEditor _instance;
        public static MapEditor Instance => _instance;

        public int TILE_WIDTH => 16;
        public int TILE_HEIGHT => 16;

        private readonly TilesetController _tilesetController;
        private readonly MapLayersViewer _mapLayerViewer;

        private string TilesetPath() { return "/Tileset/"; }
        public List<Texture> Tilesets { get; set; }
        public List<string> TilesetString { get; set; }

        public int CurrentTileset { get; set; }

        public List<SelectedTileArea> SelectingArea { get; set; }

        public bool DrawGridOnMaps { get; set; }

        public List<Map> ServerLoadedMaps { get; set; }
        public List<Map> LocalLoadedMaps { get; set; }
        public List<Map> SessionMaps { get; set; }

        private MapController _focusedMap;
        public MapController CurrentFocusedMap
        {
            get
            {
                return _focusedMap;
            }
            set
            {
                _focusedMap = value;
                _mapLayerViewer.ChangeMapData(_focusedMap.Map);
            }
        }

        public MapEditor()
        {
            _instance = this;
            InitializeComponent();

            SessionMaps = new List<Map>();

            _tilesetController = new TilesetController
            {
                Name = "_tilesetController",
                Size = new System.Drawing.Size(500, 500)
            };
            _tilesetController.Show(dockSecondary, DockState.Document);

            var projectExplorer = new ProjectExplorer
            {
                Name = "projectExplorer",
                Size = new System.Drawing.Size(500, 500)
            };
            projectExplorer.Show(dockSecondary, DockState.DockTop);

            _mapLayerViewer = new MapLayersViewer
            {
                Name = "mapLayersViewer",
                Size = new System.Drawing.Size(500, 500)
            };
            _mapLayerViewer.Show(dockSecondary, DockState.Document);

            Tilesets = new List<Texture>();
            TilesetString = new List<string>();
            SelectingArea = new List<SelectedTileArea>();

            LoadTilesets();
        }

        public void OpenMap(Map m)
        {
            MapController mc = new MapController(m)
            {
                Dock = DockStyle.Fill
            };
            mc.Show(dockPrimary, DockState.Document);
        }

        private void MapEditor_Shown(object sender, EventArgs e)
        {
            Hide();
            var startForm = new StartForm();
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
                    _tilesetController.UpdateTilesetDisplay();
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
                    
                    CurrentTileset = Tilesets.Count - 1;
                    _tilesetController.UpdateTilesetDisplay();

                }
            }
        }

        private void menuAddMap_Click(object sender, EventArgs e)
        {
            SessionMaps.Add(new Map());
            OpenMap(SessionMaps[SessionMaps.Count - 1]);
            _mapLayerViewer.ChangeMapData(SessionMaps[SessionMaps.Count - 1]);
        }

        private void MapEditor_Resize(object sender, EventArgs e)
        {
            dockPrimary.Height = Size.Height - 20;
            dockSecondary.Height = Size.Height - 20;
        }

        private void menuUndoMap_Click(object sender, EventArgs e)
        {
            CurrentFocusedMap?.Undo();
        }

        private void menuRedoMap_Click(object sender, EventArgs e)
        {
            CurrentFocusedMap?.Redo();
        }
    }
}
