using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.IO;


namespace Arquivador.BusinessClasses
{
    public class Archiver
    {

        ArchiverConfiguration _config;
        private DirectoryInfo _destination;

        public DirectoryInfo Destination
        { get { return _destination; } }

        /// <summary>
        /// Construtor
        /// </summary>
        public Archiver(ArchiverConfiguration config)
        {
            _config = config;
            LoadDestination();
        }

        public void Archive(List<FileSystemInfo> list)
        {
            /*
             * 1. Valido o diretorio destino
             * 2. Retiro o diretorio de destino do proccesso de arquivamento.
             * 3. Crio um subdiretorio para arquivamento.
             * 4. mover arquivos selecionados.
             */

            // Valido o diretorio de destino.
            _config.Validade();

            // Removo o diretorio de destino caso o mesmo exista.
            RemoveHistoricalDirectory(list);

            // Crio o subdiretorio de destino (indexado por data).
            CreateDestination();

            // Movimento os arquivos para o novo destino
            MoveItens(list);
        }

        /// <summary>
        /// remove ocorrencias de diretorio de arquivamento
        /// </summary>
        private void RemoveHistoricalDirectory(List<FileSystemInfo> list)
        {
            // Embora deveria haver apenas um diretorio, busco todos por precaucao
            List<FileSystemInfo> dirList = list.FindAll(FindHistoricalDir);
            foreach (FileSystemInfo dir in dirList)
            { list.Remove(dir); }
        }

        /// <summary>
        /// Procura o diretorio historico
        /// </summary>
        private bool FindHistoricalDir(FileSystemInfo dir)
        {
            bool retorno = false;
            if (dir.FullName == _config.HistoryDirectoryPath)
            { retorno = true; }

            return retorno;
        }

        /// <summary>
        /// Determina o nome do Subdiretorio de destino
        /// </summary>
        private void LoadDestination()
        {
            string path = Path.Combine(_config.HistoryDirectoryPath, DateTime.Now.ToString("yyyy-MM-dd"));
            _destination = new DirectoryInfo(path);
        }

        /// <summary>
        /// Cria o Subdiretorio de destino dos arquivos
        /// </summary>
        private void CreateDestination()
        {
            if (!_destination.Exists)
            { _destination.Create(); }
        }

        /// <summary>
        /// Move os itens da lista para o subdiretorio de destino.
        /// </summary>
        /// <param name="list"></param>
        private void MoveItens(List<FileSystemInfo> list)
        {
            string errorString = "";

            foreach (FileSystemInfo item in list)
            {
                try
                {
                    if (item.GetType() == typeof(FileInfo))
                    {
                        ((FileInfo)item).MoveTo(GetDestinationName(item));
                    }
                    else if (item.GetType() == typeof(DirectoryInfo))
                    {
                        ((DirectoryInfo)item).MoveTo(GetDestinationName(item));
                    }
                    else
                    {
                        throw new Exception("inderterminated file or directory");
                    }
                }
                catch (IOException ex)
                {
                    // ToDo: Error Handler
                    errorString += DateTime.Now.ToString() + Environment.NewLine;
                    errorString += item.FullName + Environment.NewLine;
                    errorString += ex.Message + Environment.NewLine;
                    errorString += Environment.NewLine;
                }
            }

            if (!String.IsNullOrEmpty(errorString))
            { throw new Exception(errorString); }
        }

        /// <summary>
        /// Determina o nome do arquivo no destino. Necessario quando ocorre arquivamento de itens com o mesmo nome.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private string GetDestinationName(FileSystemInfo item)
        {
            string itemNewPath = Path.Combine(Destination.FullName, item.Name);
            int counter = 0;

            while (File.Exists(itemNewPath))
            {
                counter++;
                itemNewPath = Path.Combine(Destination.FullName, item.Name + "(" + counter.ToString() + ")" + item.Extension);
            }

            return itemNewPath;
        }

        /// <summary>
        /// Limpa antigos diretorios arquivados
        /// </summary>
        public void CleanOldDirectories()
        {
            _config.Validade();

            List<DirectoryInfo> dirList = new List<DirectoryInfo>();
            dirList.AddRange(_config.HistoryDirectoryInfo.GetDirectories());

            foreach (DirectoryInfo dir in dirList.FindAll(FindOldDirectories))
            {
                dir.Delete(true);
            }
        }

        /// <summary>
        /// Procura o diretorio historico
        /// </summary>
        private bool FindOldDirectories(DirectoryInfo dir)
        {
            bool retorno = false;
            if (dir.CreationTime.AddDays(_config.HistoryDays) < DateTime.Now)
            { retorno = true; }

            return retorno;
        }
    }
}
