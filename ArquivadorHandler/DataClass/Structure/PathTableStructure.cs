using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquivadorHandler.DataClass.Structure
{
    public abstract class PathTableStructure
    {
        public SchemaStruct Schema;
        
        #region "Constructors"
        public PathTableStructure()
        {

            Schema = new SchemaStruct();
            Schema.ObjectName = "";
            Schema.Id = "Id";
            Schema.Path = "Path";

            // Inicializacao das variaveis
            _Id = 0;
            _Path = "";
        }
        #endregion

        #region "Private fields"
        private int _Id;
        private string _Path;
        #endregion

        #region "Column Properties"
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public string Path
        {
            get { return _Path; }
            set { _Path = value; }
        }
        #endregion

        #region "Schema Structure to return Object and Column Names"
        [Serializable]
        public struct SchemaStruct
        {
            public string ObjectName;
            public string Id;
            public string Path;
        }
        #endregion

    }
}
