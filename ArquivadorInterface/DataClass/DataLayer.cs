using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Xml;

namespace ArquivadorUI
{
    public class DataLayer
    {

        //public static XmlNodeList GetXmlNodes(string xmlNodePath)
        //{
        //    XmlDocument xmlDoc = new XmlDocument();
        //    //xmlDoc.Load();
        //    return xmlDoc.SelectNodes(xmlNodePath);
        //}
        /*
              public static string GetInnerText(string xmlNodePath)
              {
                  XmlDocument xmlDoc = new XmlDocument();
                  LoadXMLSettingsFile(xmlDoc, GetSettingsFile());
                  XmlNode xmlNode = xmlDoc.SelectSingleNode(xmlNodePath);
                  return xmlNode.InnerText;
              }

              */

        public static DataSet GetDataSet(string DataSetSchemaPath, string TableXmlPath)
        {
            DataSet ds = new DataSet();
            ds.ReadXmlSchema(DataSetSchemaPath);
            ds.ReadXml(TableXmlPath);
            return ds;
        }

        public static DataSet GetDataSet(TextReader DataSetSchema, string TableXmlPath)
        {
            DataSet ds = new DataSet();
            ds.ReadXmlSchema(DataSetSchema);
            ds.ReadXml(TableXmlPath);
            return ds;
        }

        public static void SaveDataTable(DataTable table, string TableXmlPath)
        {
            table.WriteXml(TableXmlPath);
        }

        public static string GetXmlNodeText(string xmlFile, string xmlNodePath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFile);
            XmlNode xmlNode = xmlDoc.SelectSingleNode(xmlNodePath);
            return xmlNode.InnerText;
        }


        public static void UpdateXmlNodeText(string xmlFile, string xmlNodePath, string value)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFile);
            XmlNode xmlNode = xmlDoc.SelectSingleNode(xmlNodePath);
            xmlNode.InnerText = value;
            xmlDoc.Save(xmlFile);
        }


        /*
          private static void LoadXMLSettingsFile(XmlDocument xmlDoc, string settingsFilePath)
            {
                //ToDo: Log
                Console.WriteLine("Loading XML file.");

                try
                { xmlDoc.Load(settingsFilePath); }
                catch (System.IO.FileNotFoundException)
                {
                    //ToDo: Log
                    Console.WriteLine("File Not found, Creating new one.");

                    xmlDoc.LoadXml(@"<settings>
                                        <files>
                                            <file>c:/teste.txt</file>
                                        </files>
                                        <directories>
                                            <dir>c:/example</dir>
                                        </directories>
                                        <history>c:/temp</history>
                                        <historyTime>180</historyTime>
                                        <excludeFiles>
                                            <file>c:/example/teste.txt</file>
                                        </excludeFiles>
                                        <excludeDirectories>
                                            <dir>c:/example/dir1</dir>
                                        </excludeDirectories>
                                    </settings>");
                    xmlDoc.Save(settingsFilePath);
                }
                catch
                {
                    throw;
                }

            }





        */



        /*


        private XmlDocument _xmlDoc = new XmlDocument();
        private string _settingsFile;
        //private DataProvider a = new DataProvider();


        //public DataLayer()
        //{
        //    SetSettingsFile();

        //    LoadSettingsFile();

        //    LoadGetGeneralData();
        //}

        //private void SetSettingsFile()
        //{
        //    FileInfo assemblieFile = new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location);
        //    _settingsFile = Path.Combine(assemblieFile.Directory.FullName, "settings.xml");

        //    // ToDo: Log
        //    Console.WriteLine("using: " + _settingsFile);
        //}

        //        private void LoadSettingsFile()
        //        {
        //            //ToDo: Log
        //            Console.WriteLine("Loading XML file.");

        //            try
        //            { _xmlDoc.Load(_settingsFile); }
        //            catch (System.IO.FileNotFoundException)
        //            {
        //                //ToDo: Log
        //                Console.WriteLine("File Not found, Creating new one.");

        //                _xmlDoc.LoadXml(@"<settings>
        //                                    <files>
        //                                        <file>c:/teste.txt</file>
        //                                    </files>
        //                                    <directories>
        //                                        <dir>c:/example</dir>
        //                                    </directories>
        //                                    <history>c:/temp</history>
        //                                    <zipFile status=""false"">history</zipFile>
        //                                    <excludeFiles>
        //                                        <file>c:/example/teste.txt</file>
        //                                    </excludeFiles>
        //                                    <excludeDirectories>
        //                                        <dir>c:/example/dir1</dir>
        //                                    </excludeDirectories>
        //                                    </generalData>
        //                                </settings>");
        //                _xmlDoc.Save(_settingsFile);
        //            }
        //            catch
        //            {
        //                throw;
        //            }

        //        }

        #region Validation

        #endregion

        #region File And Directory Haddle

        #region Insert

        /// <summary>
        /// Insert single file
        /// </summary>
        /// <param name="file"></param>
        public void InsertFile(FileInfo file)
        {
            XmlNode node = _xmlDoc.CreateNode(XmlNodeType.Element, "file", "");
            node.InnerText = file.ToString();

            XmlNode filesNode = _xmlDoc.SelectSingleNode("/settings/files");
            if (filesNode == null)
            {
                CreateFilesNode();
                filesNode = _xmlDoc.SelectSingleNode("/settings/files");
                filesNode.AppendChild(node);
            }
            else
            {
                filesNode.AppendChild(node);
            }

            _xmlDoc.Save(_settingsFile);
        }

        /// <summary>
        /// Insert List of files
        /// </summary>
        /// <param name="fileList"></param>
        public void InsertFile(List<FileInfo> fileList)
        {
            foreach (FileInfo file in fileList)
            {
                XmlNode node = _xmlDoc.CreateNode(XmlNodeType.Element, "file", "");
                node.InnerText = file.ToString();

                XmlNode filesNode = _xmlDoc.SelectSingleNode("/settings/files");
                if (filesNode == null)
                {
                    CreateFilesNode();
                    filesNode = _xmlDoc.SelectSingleNode("/settings/files");
                    filesNode.AppendChild(node);
                }
                else
                {
                    filesNode.AppendChild(node);
                }
            }

            _xmlDoc.Save(_settingsFile);
        }

        /// <summary>
        /// Insert single directory
        /// </summary>
        /// <param name="file"></param>
        public void InsertDirectory(DirectoryInfo dir)
        {
            XmlNode node = _xmlDoc.CreateNode(XmlNodeType.Element, "dir", "");
            node.InnerText = dir.ToString();

            XmlNode directoriesNode = _xmlDoc.SelectSingleNode("/settings/directories");
            if (directoriesNode == null)
            {
                CreateDirectoriesNode();
                directoriesNode = _xmlDoc.SelectSingleNode("/settings/directories");
                directoriesNode.AppendChild(node);
            }
            else
            {
                directoriesNode.AppendChild(node);
            }

            _xmlDoc.Save(_settingsFile);
        }

        #endregion

        #region Select



        public static DirectoryInfo GetDirectory(string xmlNodePath)
        {
            DirectoryInfo dir = new DirectoryInfo(DataProvider.GetInnerText(xmlNodePath));
            return dir;
        }

        public static FileInfo GetFile(string xmlNodePath)
        {
            FileInfo file = new FileInfo(DataProvider.GetInnerText(xmlNodePath));
            return file;
        }

        public static List<FileInfo> GetFileList(string xmlPath)
        {
            List<FileInfo> fileList = new List<FileInfo>();

            foreach (XmlNode fileNode in DataProvider.GetXmlNode(xmlPath))
            {
                FileInfo file = new FileInfo(fileNode.InnerText);
                fileList.Add(file);
            }
            return fileList;
        }

        public static List<DirectoryInfo> GetDirectoryList(string xmlPath)
        {
            List<DirectoryInfo> dirList = new List<DirectoryInfo>();
            foreach (XmlNode dirNode in DataProvider.GetXmlNode(xmlPath))
            {
                DirectoryInfo dir = new DirectoryInfo(dirNode.InnerText);
                dirList.Add(dir);
            }

            return dirList;
        }

        #endregion

        #region Delete

        /// <summary>
        /// Delete single file
        /// </summary>
        /// <param name="file"></param>
        public void RemoveFile(FileInfo file)
        {
            foreach (XmlNode fileNode in _xmlDoc.SelectNodes("/settings/files/file"))
            {
                if (file.ToString() == fileNode.InnerText)
                {
                    _xmlDoc.SelectSingleNode("/settings/files").RemoveChild(fileNode);
                }
            }
            _xmlDoc.Save(_settingsFile);
        }

        /// <summary>
        /// Delete list of files
        /// </summary>
        /// <param name="fileList"></param>
        public void RemoveFile(List<FileInfo> fileList)
        {
            foreach (FileInfo file in fileList)
            {
                foreach (XmlNode fileNode in _xmlDoc.SelectNodes("/settings/files/file"))
                {
                    if (file.ToString() == fileNode.InnerText)
                    {
                        _xmlDoc.SelectSingleNode("/settings/files").RemoveChild(fileNode);
                    }
                }
            }
            _xmlDoc.Save(_settingsFile);
        }

        // delete list of directories
        /// <summary>
        /// Delete single directory
        /// </summary>
        /// <param name="file"></param>
        public void RemoveDir(DirectoryInfo dir)
        {
            XmlNode root = _xmlDoc.DocumentElement;

            XmlNode node;
            node = root.SelectSingleNode("/settings/directories[dir='" + dir.ToString() + "']");

            root.RemoveChild(node);

            _xmlDoc.Save(_settingsFile);
        }

        /// <summary>
        /// Delete list of files
        /// </summary>
        /// <param name="fileList"></param>
        public void RemoveDir(List<DirectoryInfo> dirList)
        {
            XmlNode root = _xmlDoc.DocumentElement;

            foreach (DirectoryInfo dir in dirList)
            {
                XmlNode node;
                node = root.SelectSingleNode("/settings/directories[dir='" + dir.ToString() + "']");

                root.RemoveChild(node);
            }

            _xmlDoc.Save(_settingsFile);
        }

        #endregion

        #endregion

        ///// <summary>
        ///// Update data
        ///// </summary>
        ///// <param name="fileList"></param>
        //public void UpdateGeneralData(GeneralData generalDataInformation)
        //{
        //    XmlNode historyNode = _xmlDoc.SelectSingleNode("/settings/generalData/history");
        //    XmlNode zipFileNode = _xmlDoc.SelectSingleNode("/settings/generalData/zipFile");
        //    //XmlNode excludeFilesNode = _xmlDoc.SelectSingleNode("/settings/generalData/excludeFiles");
        //    XmlNode excludeDirectoriesNode = _xmlDoc.SelectSingleNode("/settings/generalData/excludeDirectories");

        //    historyNode.InnerText = generalDataInformation.HistoryDirectory.ToString();
        //    zipFileNode.InnerText = generalDataInformation.ZipFileName;
        //    zipFileNode.Attributes["status"].Value = generalDataInformation.ZipStatus.ToString();
        //    //excludeFilesNode.InnerText = generalDataInformation.ExcludeFiles.ToString();


        //    excludeDirectoriesNode.RemoveAll();

        //    foreach (DirectoryInfo dir in generalDataInformation.ExcludeDirectories)
        //    {

        //        XmlNode node = _xmlDoc.CreateNode(XmlNodeType.Element, "dir", "");
        //        node.InnerText = dir.ToString();

        //        excludeDirectoriesNode.AppendChild(node);

        //        //excludeDirectoriesNode.InnerText = generalDataInformation.ExcludeDirectories.ToString();
        //    }

        //    _xmlDoc.Save(_settingsFile);
        //}


        //private void LoadData()
        //{
        //    //ToDo: Log
        //    Console.WriteLine("Loading General Data File.");

        //    _generalData.Source = _xmlDoc.BaseURI;
        //    XmlNode historyNode = _xmlDoc.SelectSingleNode("/settings/history");
        //    //XmlNode zipFileNode = _xmlDoc.SelectSingleNode("/settings/zipFile");
        //    XmlNode excludeFilesNode = _xmlDoc.SelectSingleNode("/settings/excludedFiles");
        //    XmlNode excludeDirectoriesNode = _xmlDoc.SelectSingleNode("/settings/excludedDirectories");

        //    _generalData.HistoryDirectory = new DirectoryInfo(historyNode.InnerText);
        //    _generalData.ZipFileName = zipFileNode.InnerText;
        //    _generalData.ZipStatus = Convert.ToBoolean(zipFileNode.Attributes["status"].Value);
        //    //excludeFilesNode.InnerText = generalDataInformation.ExcludeFiles.ToString();

        //    _generalData.ExcludeDirectories = new List<DirectoryInfo>();

        //    foreach (XmlNode dirNode in _xmlDoc.SelectNodes("/settings/generalData/excludeDirectories/dir"))
        //    {
        //        _generalData.ExcludeDirectories.Add(new DirectoryInfo(dirNode.InnerText));
        //    }

        //    //excludeDirectoriesNode.InnerText = generalDataInformation.ExcludeDirectories.ToString();
        //}

        #region Private

        /// <summary>
        /// Create a File node
        /// </summary>
        private void CreateFilesNode()
        {
            XmlNode newFilesNode = _xmlDoc.CreateNode(XmlNodeType.Element, "files", "");
            XmlNode settingsNode = _xmlDoc.SelectSingleNode("/settings");
            if (settingsNode == null)
            { throw new NotImplementedException(); }
            else
            {
                settingsNode.AppendChild(newFilesNode);
                _xmlDoc.Save(_settingsFile);
            }
        }

        /// <summary>
        /// Create a Directory Node
        /// </summary>
        private void CreateDirectoriesNode()
        {
            XmlNode newFilesNode = _xmlDoc.CreateNode(XmlNodeType.Element, "directories", "");
            XmlNode settingsNode = _xmlDoc.SelectSingleNode("/settings");
            if (settingsNode == null)
            { throw new NotImplementedException(); }
            else
            {
                settingsNode.AppendChild(newFilesNode);
                _xmlDoc.Save(_settingsFile);
            }
        }

        #endregion

        */
    }
}
