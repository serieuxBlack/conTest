using System.Windows.Forms;
using System;

namespace ServerApp
{
    internal static class Program
    {
        public static ServerForm ServerForm { get; private set; }

        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ServerForm = new ServerForm();
            Application.Run(ServerForm);
        }
    }
}
