using System;
using System.Windows.Forms;
using SFML.Graphics;

namespace EGMapEditor
{
    public partial class TilesetViewer : UserControl
    {
        private RenderWindow screen;
        private Sprite tempSprite;
        private SFML.Graphics.View view;

        public TilesetViewer()
        {
            InitializeComponent();
            screen = new RenderWindow(this.Handle);
            view = new SFML.Graphics.View(new FloatRect(0, 0, Size.Width, Size.Height));
            screen.SetView(view);
            tempSprite = null;
            Application.Idle += Render;
        }

        private void Render(object sender, EventArgs e)
        {
            if (screen != null)
            {
                screen.Clear(SFML.Graphics.Color.Yellow);

                screen.Draw(tempSprite);

                screen.Display();
            }
        }

        public void changeTileset(int t)
        {
            tempSprite = new Sprite(MapEditor.Instance.Tilesets[t]);
            tempSprite.Position = new SFML.System.Vector2f(0, 0);
            moveCamera(0, 0);
        }

        public void moveCamera(int offX, int offY)
        {
            view.Center = new SFML.System.Vector2f(offX + Size.Width / 2, offY + Size.Height / 2);
            screen.SetView(view);
            Render(null, null);
        }

        private void TilesetViewer_Resize(object sender, EventArgs e)
        {
            screen.Size = new SFML.System.Vector2u((uint)Size.Width, (uint)Size.Height);
            view.Size = new SFML.System.Vector2f(Size.Width, Size.Height);
            view.Center = new SFML.System.Vector2f(Size.Width / 2, Size.Height / 2);
            screen.SetView(view);
        }
    }
}
