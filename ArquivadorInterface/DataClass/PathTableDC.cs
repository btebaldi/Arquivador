using System;
using System.Collections.Generic;
using System.Data;
//using System.Text;
//using System.Threading.Tasks;
using System.Linq;
using ArquivadorHandler.DataClass.Structure;
using System.Deployment.Application;

using System.IO;

namespace ArquivadorUI.DataClass
{

    public abstract class PathTableDC
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger("ArquivadorUI.DataClass.PathTable.cs");

        public PathTableDC(string XmlFileName)
        {

            try
            {
                //_tableXmlPath = System.IO.Path.Combine(ApplicationDeployment.CurrentDeployment.DataDirectory, "Resources", XmlFileName);
                _tableXmlPath = System.IO.Path.Combine("Resources", XmlFileName);
            }
            //catch (InvalidDeploymentException ex)
            //{
            //    _tableXmlPath = System.IO.Path.Combine("Resources", XmlFileName);
            //    logger.Error("Erro na aplicacao: " + ex.Message);
            //}
            catch (Exception ex)
            {
                logger.Error("Erro na aplicacao: " + ex.Message);
                throw;
            }

            if (!System.IO.File.Exists(_tableXmlPath))
            {
                logger.Error("Could not read file: " + _tableXmlPath);
                throw new Exception("Could not read file: " + _tableXmlPath);
            }

            _dataSetSchemaPath = @"Resources\SCHEMA.xsd";
        }

        private string _tableXmlPath;
        public string TableXmlPath
        {
            get { return _tableXmlPath; }
            set { _tableXmlPath = value; }
        }

        private string _dataSetSchemaPath;
        public string DataSetSchemaPath
        {
            get { return _dataSetSchemaPath; }
            set { _dataSetSchemaPath = value; }
        }

        //private string _DataSetSchema;
        //public string DataSetSchema
        //{
        //    get { return _DataSetSchema; }
        //    set { _DataSetSchema = value; }
        //}


        #region "Data Retrieval Methods"
        public virtual DataSet GetPaths()
        {
            //return DataLayer.GetDataSet(new System.IO.StringReader(DataSetSchema), TableXmlPath);
            return DataLayer.GetDataSet(DataSetSchemaPath, TableXmlPath);
        }



        //public DataSet GetSinglePath(PathTableStructure item)
        //{
        //    DataTable dtFiltered = (GetPaths().Tables[item.Schema.ObjectName].AsEnumerable().Where(p => p.Field<int>(item.Schema.Id) == item.Id)).CopyToDataTable();

        //    DataSet ds = new DataSet();
        //    ds.Tables.Add(dtFiltered);
        //    ds.Tables[0].TableName = item.Schema.ObjectName;

        //    return ds;
        //}

        //public bool Load(PathTableStructure item)
        //{
        //    DataRow dr;
        //    bool boolRet = false;

        //    //DataTable dtFiltered = (GetPaths().Tables[item.Schema.ObjectName].AsEnumerable().Where(p => p.Field<int>(item.Schema.Id) == item.Id)).CopyToDataTable();
        //    DataTable dtFiltered = (GetPaths().Tables[0].AsEnumerable().Where(p => p.Field<int>(item.Schema.Id) == item.Id)).CopyToDataTable();
        //    if (dtFiltered != null)
        //    {
        //        if (dtFiltered.Rows.Count > 0)
        //        {
        //            boolRet = true;

        //            dr = dtFiltered.Rows[0];

        //            item.Id = Convert.ToInt32(dr[item.Schema.Id]);
        //            item.Path = dr[item.Schema.Path].ToString();
        //        }
        //    }
        //    return boolRet;
        //}

        //public List<PathTableStructure> LoadAll()
        //{
        //    throw new NotImplementedException();
        //}

        #endregion

        #region "Data Modification Methods"
        public virtual void Validate(PathTableStructure item)
        {
            string strMsg = string.Empty;

            if (item.Path.Trim() == string.Empty)
            {
                logger.Error("Path must be filled in");
                logger.Error("itemId=" + item.Id);
                logger.Error("Path=" + item.Path);
                strMsg += "Path must be filled in" + Environment.NewLine;
            }

            if (strMsg != string.Empty)
            {
                //throw new BusinessRuleException(strMsg);
                throw new Exception(strMsg);
            }
        }

        protected int Insert(PathTableStructure item)
        {
            Validate(item);

            int returno = 0;
            DataTable myDt = DataLayer.GetDataSet(DataSetSchemaPath, TableXmlPath).Tables[Path.GetFileNameWithoutExtension(TableXmlPath)];

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

        //public int Update(PathTableStructure item)
        //{
        //    throw new NotImplementedException();
        //}

        protected int Delete(PathTableStructure item)
        {
            int returno = 0;
            DataTable myDt = DataLayer.GetDataSet(DataSetSchemaPath, TableXmlPath).Tables[Path.GetFileNameWithoutExtension(TableXmlPath)];
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