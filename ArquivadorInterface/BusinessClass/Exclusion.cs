using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace ArquivadorUI.BusinessClass
{
    class Exclusion : DataClass.PathTableDC
    {

        public Exclusion() : base("TB_EXCLUSION.xml")
        {

        }

        public List<DataClass.Structure.Exclusion> GetExclusions()
        {
            List<DataClass.Structure.Exclusion> retorno = new List<DataClass.Structure.Exclusion>();

            DataSet ds = GetPaths();

            retorno = (from dr in ds.Tables["TB_EXCLUSION"].AsEnumerable()
                       select new DataClass.Structure.Exclusion
                       {
                           Id = Convert.ToInt32(dr["IdExclusion"]),
                           Path = Convert.ToString(dr["Path"])
                       }).ToList();

            return retorno;
        }


        public int Insert(DataClass.Structure.Exclusion item)
        {
            return base.Insert(item);
        }


        public int Delete(DataClass.Structure.Exclusion item)
        {
            return base.Delete(item);
        }

    }
}

