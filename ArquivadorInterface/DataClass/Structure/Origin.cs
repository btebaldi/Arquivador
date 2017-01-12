using System;

namespace ArquivadorUI.DataClass.Structure
{
    public class Origin : ArquivadorHandler.DataClass.Structure.PathTableStructure
    {

        public Origin() : base()
        {
            Schema = new SchemaStruct();
            Schema.ObjectName = "TB_ORIGIN";
            Schema.Id = "IdOrigin";
            Schema.Path = "Path";
        }

    }
}
