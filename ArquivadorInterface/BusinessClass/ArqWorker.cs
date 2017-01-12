using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ArquivadorHandler.BusinessClass;

namespace ArquivadorUI.BusinessClass
{
    class ArqWorker
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger("ArquivadorUI.Program.cs");


        public static void Arquivar(bool rethrowException)
        {
            try
            {
                logger.Info("Iniciado processo de arquivamento.");
                // Carrego as origens
                ArquivadorUI.BusinessClass.Origin originHandler = new BusinessClass.Origin();
                List<DataClass.Structure.Origin> myOrigins = originHandler.GetOrigins();
                logger.Info("Origens carregadas com sucesso.");

                // Carrego as exclusoes
                ArquivadorUI.BusinessClass.Exclusion exclusionHandler = new BusinessClass.Exclusion();
                List<DataClass.Structure.Exclusion> myExclusions = exclusionHandler.GetExclusions();
                logger.Info("Origens exclusoes com sucesso.");


                // Carrego a classe responsavel por fazer a escolha de arquivos
                FileChooser chooser = new FileChooser(myOrigins.ConvertAll(x => (ArquivadorHandler.DataClass.Structure.PathTableStructure)x), myExclusions.ConvertAll(x => (ArquivadorHandler.DataClass.Structure.PathTableStructure)x));
                logger.Info("File chooser inicializado.");

                // Carrego a configuracao basica de diretorios
                ArquivadorUI.BusinessClass.Config sysConfig = new Config();
                logger.Info("configuracao dos systema carregadas com sucesso");
                logger.Info("Dir=" + sysConfig.HistoryDir);
                logger.Info("Days=" + sysConfig.HistoryDays);

                ArquivadorHandler.Config.ArchiverConfig config = new ArquivadorHandler.Config.ArchiverConfig(sysConfig.HistoryDir, sysConfig.HistoryDays);
                logger.Info("configuracao basica de diretorios carregadas com sucesso.");

                // Carrego a classe responsavel pelo arquivamento.
                Archiver myArchiver = new Archiver(config);
                logger.Info("Arquivador iniciado com sucesso.");

                // Arquivo os itens selecionados
                myArchiver.Archive(chooser.GetProcessedFileSystemInfos());
                logger.Info("arquivamento realizado.");

                // Limpo diretorios antigos
                myArchiver.CleanOldDirectories();
                logger.Info("Limpeza de diretorios antigos realizada.");

                logger.Info("Processo de arquivamento Finalizado.");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                if (rethrowException)
                { throw; }
            }

        }
    }
}
