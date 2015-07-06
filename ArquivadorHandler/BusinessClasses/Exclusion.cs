using System;
using Arquivador.DataClass;


namespace Arquivador.BusinessClasses
{
    public class Exclusion : PathTableDC
    {
        public Exclusion()
        {
            base.DataSetSchemaPath = "TB_EXCLUSION_SCHEMA.XML";
            base.TableXmlPath = "TB_EXCLUSION.XML";
        }
    }
}
