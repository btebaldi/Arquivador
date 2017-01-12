using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquivadorUI.BusinessClass
{
    class Config
    {

        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger("ArquivadorUI.BusinessClass.Config.cs");

        private readonly string _configFilePath = "Resources/SETTINGS.XML";

        public int HistoryDays { get; set; }

        private System.IO.DirectoryInfo _historyDir;
        public string HistoryDir
        {
            get { return _historyDir.FullName; }
            set { _historyDir = new System.IO.DirectoryInfo(value); }
        }


        public Config()
        {
            //HistoryDir = ArquivadorUI.Properties.Settings.Default.HistoryDir;
            //HistoryDays = ArquivadorUI.Properties.Settings.Default.HistoryDays;
            ReadConfigFile(_configFilePath);
        }

        internal void Save()
        {
            //ArquivadorUI.Properties.Settings.Default.HistoryDir = HistoryDir;
            //ArquivadorUI.Properties.Settings.Default.HistoryDays = HistoryDays;
            //ArquivadorUI.Properties.Settings.Default.Save();

            SaveConfiguration(_configFilePath);
        }

        private void ReadConfigFile(string configFilePath)
        {
            HistoryDir = DataLayer.GetXmlNodeText(configFilePath, "Setting/HistoryDirectory");
            HistoryDays = Convert.ToInt32(DataLayer.GetXmlNodeText(configFilePath, "/Setting/HistoryDays"));
        }

        public void Validade()
        {
            if (!_historyDir.Exists)
            {
                logger.Error("This is not a valid history directory. Dir=" + HistoryDir);
                throw new Exception("This is not a valid history directory.");
            }

            if (HistoryDays <= 0)
            {
                logger.Error("The History days can not be less or equal to zero. Days=" + HistoryDays);
                throw new Exception("The History days can not be less or equal to zero");
            }
        }

        private void SaveConfiguration(string configFilePath)
        {
            Validade();

            DataLayer.UpdateXmlNodeText(configFilePath, "/Setting/HistoryDays", HistoryDays.ToString());
            DataLayer.UpdateXmlNodeText(configFilePath, "/Setting/HistoryDirectory", HistoryDir);
        }
    }
}
