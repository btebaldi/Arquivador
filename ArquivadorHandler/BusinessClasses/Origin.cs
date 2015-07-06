using System;
using Arquivador.DataClass;


namespace Arquivador.BusinessClasses
{
    public class Origin : PathTableDC
    {
        public Origin()
        {
            base.DataSetSchemaPath = "TB_ORIGIN_SCHEMA.XML";
            base.TableXmlPath = "TB_ORIGIN.XML";
        }

    }
}
