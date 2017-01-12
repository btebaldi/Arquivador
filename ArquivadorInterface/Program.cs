using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace ArquivadorUI
{
    static class Program
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger("ArquivadorUI.Program.cs");

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (ProcessCommandLine(args))
            { return; }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MDIParent1());
            Application.Run(new UserInterface());
        }

        static bool ProcessCommandLine(string[] args)
        {

            bool processed = false;
            //Process it, if some has been processed return true, else return false
            if (args.Length > 0)
            {
                logger.Info("Iniciliznado versao Command Line");

                if (args.Contains("-console"))
                {
                    BusinessClass.ArqWorker.Arquivar(false);
                }

                processed = true;
            }

            return processed;
        }
    }
}
