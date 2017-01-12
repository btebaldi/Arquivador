using System;

namespace ArquivadorUI.DataClass.Structure
{
    public class Exclusion : ArquivadorHandler.DataClass.Structure.PathTableStructure
    {

        public Exclusion() : base()
        {
            Schema.ObjectName = "TB_EXCLUSION";
            Schema.Id = "IdExclusion";
            Schema.Path = "Path";
        }

    }
}
