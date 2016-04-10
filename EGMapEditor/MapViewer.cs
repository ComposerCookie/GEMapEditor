using System;
using System.Windows.Forms;
using System.Collections.Generic;
using SFML.Graphics;

namespace EGMapEditor
{
    public partial class MapViewer : UserControl
    {
        private RenderWindow screen;
        private Map map;
        private SFML.Graphics.View view;
        private Sprite tempSprite;

        int offsetX;
        int offsetY;

        public MapViewer(Map m)
        {
            InitializeComponent();

            screen = new RenderWindow(this.Handle);
            view = new SFML.Graphics.View(new FloatRect(0, 0, Size.Width, Size.Height));
            screen.SetView(view);
            tempSprite = new Sprite();

            map = m;

            Application.Idle += Render;
        }

        private void Render(object sender, EventArgs e)
        {
            if (screen != null)
            {
                screen.Clear(SFML.Graphics.Color.Transparent);

                for (int y = 0; y < map.Height; y++)
                {
                    for (int x = 0; x < map.Height; x++)
                    {
                        if (map.tile[y * map.Width + x].tileset >= 0 && map.tile[y * map.Width + x].id >= 0)
                        {
                            tempSprite = new Sprite(MapEditor.Instance.Tilesets[map.tile[y * map.Width + x].tileset]);
                            tempSprite.Position = new SFML.System.Vector2f(x * MapEditor.Instance.TILE_WIDTH, y * MapEditor.Instance.TILE_HEIGHT);
                            tempSprite.TextureRect = new IntRect(map.tile[y * map.Width + x].id % map.Width * MapEditor.Instance.TILE_WIDTH, map.tile[y * map.Width + x].id / map.Width * MapEditor.Instance.TILE_HEIGHT, MapEditor.Instance.TILE_WIDTH, MapEditor.Instance.TILE_HEIGHT);
                            screen.Draw(tempSprite);
                        }
                    }
                }

                screen.Display();
            }
        }

        public void moveCamera(int offX, int offY)
        {
            offsetX = offX;
            offsetY = offY;
            view.Center = new SFML.System.Vector2f(offX + Size.Width / 2, offY + Size.Height / 2);
            screen.SetView(view);
            Render(null, null);
        }

        private void MapViewer_Resize(object sender, EventArgs e)
        {
            screen.Size = new SFML.System.Vector2u((uint)Size.Width, (uint)Size.Height);
            view.Size = new SFML.System.Vector2f(Size.Width, Size.Height);
            view.Center = new SFML.System.Vector2f(Size.Width / 2, Size.Height / 2);
            screen.SetView(view);
        }
    }
}
