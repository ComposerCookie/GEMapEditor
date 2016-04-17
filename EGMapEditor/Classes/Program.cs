using System;
using System.Windows.Forms;

namespace EGMapEditor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SFML.CSFML.Activate();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var startForm = new StartForm();
            startForm.ShowDialog();
            while (startForm.Visible)
                Application.DoEvents();

            startForm.Close();
            Application.Run(MapEditor.Instance);
        }
    }
}
