
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ArquivadorHandler.BusinessClass;
using System.IO;


namespace ArquivadorUI
{
    public partial class PreviewFiles : Form
    {

        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger("ArquivadorUI.PreviewFiles.cs");

        public PreviewFiles()
        {
            InitializeComponent();
            LoadPreview();
        }

        private void LoadPreview()
        {
            logger.Info("Iniciado processo de Pre-visualizacao.");

            // Carrego as origens
            ArquivadorUI.BusinessClass.Origin originHandler = new BusinessClass.Origin();
            List<DataClass.Structure.Origin> myOrigins = originHandler.GetOrigins();
            logger.Info("Origens carregadas com sucesso.");

            // Carrego as exclusoes
            ArquivadorUI.BusinessClass.Exclusion exclusionHandler = new BusinessClass.Exclusion();
            List<DataClass.Structure.Exclusion> myExclusions = exclusionHandler.GetExclusions();
            logger.Info("Origens exclusoes com sucesso.");

            // Carrego a classe responsavel por fazer a escolha de arquivos
            FileChooser chooser = new FileChooser(myOrigins.ConvertAll(x => (ArquivadorHandler.DataClass.Structure.PathTableStructure)x), myExclusions.ConvertAll(x => (ArquivadorHandler.DataClass.Structure.PathTableStructure)x));
            logger.Info("File chooser inicializado.");

            // Mostro arquivos a serem arquivados 
            dataGridView1.DataSource = chooser.GetProcessedFileSystemInfos();
            dataGridView1.Columns["CreationTime"].Visible = false;
            dataGridView1.Columns["CreationTimeUtc"].Visible = false;
            dataGridView1.Columns["LastAccessTime"].Visible = false;
            dataGridView1.Columns["LastAccessTimeUtc"].Visible = false;
            dataGridView1.Columns["LastWriteTime"].Visible = false;
            dataGridView1.Columns["LastWriteTimeUtc"].Visible = false;
            dataGridView1.Columns["Attributes"].Visible = false;
            logger.Info("Display das informacoes realizada.");

            logger.Info("Processo de Pre-visualizacao Finalizado.");


        }
    }
}
