using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ArquivadorHandler.DataClass.Structure;
using System.Data;
using System.IO;

namespace ArquivadorHandler.BusinessClass
{
    /// <summary>
    /// Classe responsavel por fazer a selecao de arquivos.
    /// Dado uma lista de origens e exclusoes o objeto processa uma lsita de arquivos "validos".
    /// </summary>
    public class FileChooser
    {

        private List<PathTableStructure> _origins;
        private List<PathTableStructure> _exclusions;
        private List<FileSystemInfo> _processedOrigins;

        #region "Constructors"
        public FileChooser(List<PathTableStructure> origins, List<PathTableStructure> exclusions)
        {
            _origins = origins;
            _exclusions = exclusions;
        }
        #endregion

        /// <summary>
        /// retorna as origens a serem processadas
        /// </summary>
        /// <returns></returns>
        //public DataSet GetOriginsPaths()
        //{
        //    return _origins.GetPaths();
        //}

        /// <summary>
        /// retorna as exclusoes a serem processadas
        /// </summary>
        /// <returns></returns>
        //public DataSet GetExclusionsPaths()
        //{
        //    return _exclusions.GetPaths();
        //}

        #region "Custom Methods"

        /// <summary>
        /// retorna a lista de arquivos e diretorios "validos"
        /// </summary>
        /// <returns></returns>
        public List<FileSystemInfo> GetProcessedFileSystemInfos()
        {
            ProcessOrigins();
            RemoveExclusions();

            return _processedOrigins;
        }

        /// <summary>
        /// carrega os arquivos de origem
        /// </summary>
        private void ProcessOrigins()
        {
            _processedOrigins = new List<FileSystemInfo>();

            // Eu arquivo o que esta dentro de cada diretorio e nao o diretorio propriamente dito.
            foreach (PathTableStructure item in _origins)
            {
                DirectoryInfo dir = new DirectoryInfo(item.Path);
                if (dir.Exists)
                {
                    _processedOrigins.AddRange(dir.GetDirectories("*.*", SearchOption.TopDirectoryOnly));
                    _processedOrigins.AddRange(dir.GetFiles("*.*", SearchOption.TopDirectoryOnly));
                }
            }
        }


        /// <summary>
        /// Remove diretorios excluidos
        /// </summary>
        private void RemoveExclusions()
        {
            List<FileSystemInfo> listExclusions = _processedOrigins.FindAll(FindExclusions);
            foreach (FileSystemInfo exclusion in listExclusions)
            {
                _processedOrigins.Remove(exclusion);
            }
        }

        /// <summary>
        /// busca que determina se o diretorio é excluido ou nao.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool FindExclusions(FileSystemInfo item)
        {
            bool retorno = false;
            foreach (PathTableStructure excludedItem in _exclusions)
            {
                if (excludedItem.Path == item.FullName)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
        #endregion
    }
}
