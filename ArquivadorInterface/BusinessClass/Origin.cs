using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace ArquivadorUI.BusinessClass
{
    class Origin : DataClass.PathTableDC
    {

        public Origin() : base("TB_ORIGIN.XML")
        {

        }

        public List<DataClass.Structure.Origin> GetOrigins()
        {
            List<DataClass.Structure.Origin> retorno = new List<DataClass.Structure.Origin>();

            DataSet ds = GetPaths();

            retorno = (from dr in ds.Tables["TB_ORIGIN"].AsEnumerable()
                       select new DataClass.Structure.Origin
                       {
                           Id = Convert.ToInt32(dr["IdOrigin"]),
                           Path = Convert.ToString(dr["Path"])
                       }).ToList();

            return retorno;
        }

        public int Insert(DataClass.Structure.Origin item)
        {
            return base.Insert(item);
        }


        public int Delete(DataClass.Structure.Origin item)
        {
            return base.Delete(item);
        }

    }
}

