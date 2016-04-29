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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SFML.CSFML.Activate();
            Application.Run(new MapEditor());
        }
    }
}
