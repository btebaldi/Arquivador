using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arquivador.DataClass.Structure
{
    public abstract class PathTableStructure
    {
        public SchemaStruct Schema;

        #region "Constructors"
        public PathTableStructure(string ObjectName, string Id, string Path)
        {
            // Inicializacao do Schema
            Schema = new SchemaStruct();
            Schema.ObjectName = ObjectName;
            Schema.Id = Id;
            Schema.Path = Path;

            // Inicializacao das variaveis
            _IdOrigin = 0;
            _Path = "";
        }
        #endregion

        #region "Private fields"
        private int _IdOrigin;
        private string _Path;
        #endregion

        #region "Column Properties"
        public int Id
        {
            get { return _IdOrigin; }
            set { _IdOrigin = value; }
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
