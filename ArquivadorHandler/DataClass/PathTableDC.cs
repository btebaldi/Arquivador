using System;
using System.Collections.Generic;
using System.Data;
//using System.Text;
//using System.Threading.Tasks;
using System.Linq;
using Arquivador.DataClass.Structure;

namespace Arquivador.DataClass
{

    public abstract class PathTableDC
    {
        private string _TableXmlPath;
        public string TableXmlPath
        {
            get { return _TableXmlPath; }
            set { _TableXmlPath = value; }
        }

        private string _DataSetSchemaPath;
        public string DataSetSchemaPath
        {
            get { return _DataSetSchemaPath; }
            set { _DataSetSchemaPath = value; }
        }

        #region "Data Retrieval Methods"
        public virtual DataSet GetPaths()
        {
            return DataLayer.GetDataSet(DataSetSchemaPath, TableXmlPath); ;
        }

        //public DataSet GetSinglePath(PathTableStructure item)
        //{
        //    DataTable dtFiltered = (GetPaths().Tables[item.Schema.ObjectName].AsEnumerable().Where(p => p.Field<int>(item.Schema.Id) == item.Id)).CopyToDataTable();

        //    DataSet ds = new DataSet();
        //    ds.Tables.Add(dtFiltered);
        //    ds.Tables[0].TableName = item.Schema.ObjectName;

        //    return ds;
        //}

        public bool Load(PathTableStructure item)
        {
            DataRow dr;
            bool boolRet = false;

            //DataTable dtFiltered = (GetPaths().Tables[item.Schema.ObjectName].AsEnumerable().Where(p => p.Field<int>(item.Schema.Id) == item.Id)).CopyToDataTable();
            DataTable dtFiltered = (GetPaths().Tables[0].AsEnumerable().Where(p => p.Field<int>(item.Schema.Id) == item.Id)).CopyToDataTable();
            if (dtFiltered != null)
            {
                if (dtFiltered.Rows.Count > 0)
                {
                    boolRet = true;

                    dr = dtFiltered.Rows[0];

                    item.Id = Convert.ToInt32(dr[item.Schema.Id]);
                    item.Path = dr[item.Schema.Path].ToString();
                }
            }
            return boolRet;
        }

        public List<PathTableStructure> LoadAll()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region "Data Modification Methods"
        public virtual void Validate(PathTableStructure item)
        {
            string strMsg = string.Empty;

            if (item.Path.Trim() == string.Empty)
            {
                strMsg += "Path must be filled in" + Environment.NewLine;
            }

            if (strMsg != string.Empty)
            {
                //throw new BusinessRuleException(strMsg);
                throw new Exception(strMsg);
            }
        }

        public int Insert(PathTableStructure item)
        {
            Validate(item);

            int returno = 0;
            DataTable myDt = DataLayer.GetDataSet(DataSetSchemaPath, TableXmlPath).Tables[0];

            DataRow drr = myDt.NewRow();

            int maxId = 0;
            if (myDt.Rows.Count > 0)
            {
                maxId = (int)myDt.AsEnumerable().Max(row => row[item.Schema.Id]);
            }

            drr[item.Schema.Id] = maxId + 1;
            drr[item.Schema.Path] = item.Path;

            myDt.Rows.Add(drr);

            DataLayer.SaveDataTable(myDt, TableXmlPath);

            return returno;
        }

        public int Update(PathTableStructure item)
        {
            throw new NotImplementedException();
        }

        public int Delete(PathTableStructure item)
        {
            int returno = 0;
            DataTable myDt = DataLayer.GetDataSet(DataSetSchemaPath, TableXmlPath).Tables[0];
            DataRow[] drr = myDt.Select(item.Schema.Id + "=" + item.Id);
            for (int nCount = 0; nCount < drr.Length; nCount++)
            {
                drr[nCount].Delete();
                returno++;
            }

            DataLayer.SaveDataTable(myDt, TableXmlPath);
            return returno;
        }

        #endregion
    }

}