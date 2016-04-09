using System;
using System.Windows.Forms;
using SFML.Graphics;

namespace EGMapEditor
{
    public partial class TilesetViewer : UserControl
    {
        private RenderWindow target;

        public TilesetViewer()
        {
            InitializeComponent();
            target = new RenderWindow(this.Handle);
            Application.Idle += Render;
        }

        private void Render(object sender, EventArgs e)
        {
            if (target != null)
            {
                target.Clear();

                // Set Camera here.


                // Do Draw work here.


                target.Display();
            }
        }
    }
}
