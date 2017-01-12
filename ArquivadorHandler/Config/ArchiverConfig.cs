using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquivadorHandler.Config
{
    public class ArchiverConfig
    {
        private HistoryDirElement _dir;
        private int _days;

        public ArchiverConfig(string HistoryDir, int days)
        {
            _dir = new HistoryDirElement(HistoryDir);
            _days = days;
        }

        public HistoryDirElement Dir
        { get { return _dir; } }

        public int Days
        { get { return _days; } }

        public void Validade()
        {
            DirectoryInfo info = new DirectoryInfo(Dir.Path);
            if (!info.Exists)
            { throw new ArchiverConfigurationException("This is not a valid history directory."); }

            if (Days <= 0)
            { throw new ArchiverConfigurationException("The History days can not be less or equal to zero"); }
        }

    }

    public class HistoryDirElement
    {
        string _path;
        DirectoryInfo _info;

        public DirectoryInfo Info
        { get { return _info; } }

        public String Path
        { get { return _path; } }

        public HistoryDirElement(string path)
        {
            _path = path;
            _info = new DirectoryInfo(_path);
        }
    }
}