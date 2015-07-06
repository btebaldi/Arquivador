using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arquivador.BusinessClasses
{
    public class ArchiverConfiguration
    {

        #region Variables and Properties
        private DirectoryInfo _historyDirectory;
        private int _historyDays = 180;

        public string HistoryDirectoryPath
        {
            get { return _historyDirectory.FullName; }
            set { _historyDirectory = new DirectoryInfo(value); }
        }
        public DirectoryInfo HistoryDirectoryInfo
        { get { return _historyDirectory; } }
        public int HistoryDays
        {
            get { return _historyDays; }
            set { _historyDays = value; }
        }
        #endregion

        public ArchiverConfiguration()
        {
            HistoryDirectoryPath = DataLayer.GetXmlNodeText("SETTINGS.XML", "Setting/HistoryDirectory");
            HistoryDays = Convert.ToInt32(DataLayer.GetXmlNodeText("SETTINGS.XML", "/Setting/HistoryDays"));
        }

        public void Validade()
        {
            if (!_historyDirectory.Exists)
            { throw new ArchiverConfigurationException("This is not a valid history directory."); }

            if (_historyDays <= 0)
            { throw new ArchiverConfigurationException("The History days can not be less or equal to zero"); }
        }

        public void SaveConfiguration()
        {
            Validade();

            DataLayer.UpdateXmlNodeText("SETTINGS.XML", "/Setting/HistoryDays", HistoryDays.ToString());
            DataLayer.UpdateXmlNodeText("SETTINGS.XML", "/Setting/HistoryDirectory", HistoryDirectoryInfo.FullName);
        }


    }
}
