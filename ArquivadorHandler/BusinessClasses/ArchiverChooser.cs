using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Arquivador.DataClass.Structure;
using System.Data;
using System.IO;

namespace Arquivador.BusinessClasses
{
    /// <summary>
    /// Classe responsavel por fazer a selecao de arquivos.
    /// Dado uma lista de origens e exclusoes o objeto processa uma lsita de arquivos "validos".
    /// </summary>
    public class ArchiverChooser
    {

        private Origin _origins;
        private Exclusion _exclusions;
        private List<FileSystemInfo> _processedOrigins;

        #region "Constructors"
        public ArchiverChooser(Origin origins, Exclusion exclusions)
        {
            _origins = origins;
            _exclusions = exclusions;
        }
        #endregion

        /// <summary>
        /// retorna as origens a serem processadas
        /// </summary>
        /// <returns></returns>
        public DataSet GetOriginsPaths()
        {
            return _origins.GetPaths();
        }

        /// <summary>
        /// retorna as exclusoes a serem processadas
        /// </summary>
        /// <returns></returns>
        public DataSet GetExclusionsPaths()
        {
            return _exclusions.GetPaths();
        }

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
            foreach (DataRow dirRow in _origins.GetPaths().Tables[0].Rows)
            {
                DirectoryInfo dir = new DirectoryInfo(dirRow[new OriginStructure().Schema.Path].ToString());
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
            foreach (DataRow exclusionRow in _exclusions.GetPaths().Tables[0].Rows)
            {
                if (exclusionRow[new ExclusionStructure().Schema.Path].ToString() == item.FullName)
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
