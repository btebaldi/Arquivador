using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arquivador.BusinessClasses;

namespace ArquivadorConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            bool _logAtctive = false;
            bool _waitKeyPress = false;

            // Interperto as opcoes de rotina
            GetVariables(args, ref _logAtctive, ref _waitKeyPress);


            try
            {
                // Carrego as origens e exclusoes
                Origin myOrigins = new Origin();
                Exclusion myExclusions = new Exclusion();

                // Carrego a classe responsavel por fazer a escolha de arquivos
                ArchiverChooser chooser = new ArchiverChooser(myOrigins, myExclusions);

                // Carrego a configuracao basica de diretorios
                ArchiverConfiguration config = new ArchiverConfiguration();

                // Carrego a classe responsavel pelo arquivamento.
                Archiver myArchiver = new Archiver(config);


                // Arquivo os itens selecionados
                myArchiver.Archive(chooser.GetProcessedFileSystemInfos());

                // Limpo diretorios antigos
                myArchiver.CleanOldDirectories();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (_logAtctive)
                { System.IO.File.WriteAllText("Log_" + DateTime.Now.ToString("yyyy-MM-dd_hhmmss") + ".txt", ex.Message); }
            }

            if (_waitKeyPress)
            { Console.ReadKey(); }

        }


        private static void GetVariables(string[] args, ref bool _logAtctive, ref bool _waitKeyPress)
        {
            foreach (string arg in args)
            {
                if (arg == "-l")
                { _logAtctive = true; }

                if (arg == "-w")
                { _waitKeyPress = true; }

                if (arg == "-?" || arg == "/?" || arg == "\\?")
                { WriteHelp(); }
            }
        }

        private static void WriteHelp()
        {
            Console.WriteLine("ArquivadorConsole [-l] [-w]   : ");
            Console.WriteLine("-l   : Log active");
            Console.WriteLine("-w   : Wait after run.");
        }

    }
}
