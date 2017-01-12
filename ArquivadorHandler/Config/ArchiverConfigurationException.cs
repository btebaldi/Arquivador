using System;
using System.Text;

namespace ArquivadorHandler.Config
{
    [Serializable]
    class ArchiverConfigurationException : ApplicationException
    {
        public ArchiverConfigurationException()
            : base()
        { }

        public ArchiverConfigurationException(string msg)
            : base(msg)
        { }

        public ArchiverConfigurationException(string msg, Exception ex)
            : base(msg, ex)
        { }

    }
}