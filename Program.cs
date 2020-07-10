using ListinTelefonico.View;
using System.Windows.Forms;

namespace ListinTelefonico
{
    /// <summary>
    /// Clase principal con el método Main para ejecutar el programa
    /// </summary>
    class MainClass
    {
        public static void Main(string[] args)
        {
            var mainForm = new MainWindowCore().MainWindowsView;
            Application.Run(mainForm);
        }
    }
}
