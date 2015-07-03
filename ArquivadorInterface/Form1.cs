using System;
//using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Xml.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using Arquivador;
using Arquivador.BusinessClasses;
using System.IO;

namespace ArquivadorInterface
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            try
            {
                LoadOrigins();
                LoadExclusions();
                LoadSettings();
            }
            catch (Exception ex)
            {
                btn_Archive.Enabled = false;
                btn_Preview.Enabled = false;
                MessageBox.Show(ex.Message);
            }
        }

        private void previewButton_Click(object sender, EventArgs e)
        {
            PreviewFiles previewForm = new PreviewFiles();
            previewForm.ShowDialog(this);
        }

        private void archive_Click(object sender, EventArgs e)
        {
            try
            {
                Origin myOrigins = new Origin();
                Exclusion myExclusions = new Exclusion();

                ArchiverChooser chooser = new ArchiverChooser(myOrigins, myExclusions);

                ArchiverConfiguration config = new ArchiverConfiguration();
                Archiver myArchiver = new Archiver(config);

                myArchiver.Archive(chooser.GetProcessedFileSystemInfos());

                myArchiver.CleanOldDirectories();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void saveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                ArchiverConfiguration config = new ArchiverConfiguration();

                config.HistoryDirectoryPath = tb_historyDir.Text;
                config.HistoryDays = Convert.ToInt32(tb_historyTimeDays.Text);

                config.SaveConfiguration();

                LoadSettings();
                btn_Archive.Enabled = true;
                btn_Preview.Enabled = true;
            }
            catch (Exception ex)
            {
                btn_Archive.Enabled = false;
                btn_Preview.Enabled = false;
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadSettings()
        {
            ArchiverConfiguration config = new ArchiverConfiguration();
            tb_historyDir.Text = config.HistoryDirectoryPath;
            tb_historyTimeDays.Text = config.HistoryDays.ToString();
        }

        private void LoadOrigins()
        {
            Arquivador.BusinessClasses.Origin myOrigins = new Arquivador.BusinessClasses.Origin();

            lstBoxSources.DataSource = myOrigins.GetPaths().Tables[0];
            lstBoxSources.DisplayMember = new Arquivador.DataClass.Structure.OriginStructure().Schema.Path;
            lstBoxSources.ValueMember = new Arquivador.DataClass.Structure.OriginStructure().Schema.Id;
        }

        private void LoadExclusions()
        {
            Arquivador.BusinessClasses.Exclusion myExclusions = new Arquivador.BusinessClasses.Exclusion();

            lstBoxExclusions.DataSource = myExclusions.GetPaths().Tables[0];
            lstBoxExclusions.DisplayMember = new Arquivador.DataClass.Structure.ExclusionStructure().Schema.Path;
            lstBoxExclusions.ValueMember = new Arquivador.DataClass.Structure.ExclusionStructure().Schema.Id;

        }

        private void addOrigin_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                Arquivador.DataClass.Structure.OriginStructure myOriginStruct = new Arquivador.DataClass.Structure.OriginStructure();
                myOriginStruct.Path = folderBrowserDialog1.SelectedPath;

                Arquivador.BusinessClasses.Origin myOriginBussinessClass = new Arquivador.BusinessClasses.Origin();

                myOriginBussinessClass.Insert(myOriginStruct);

                LoadOrigins();
            }
        }

        private void addExclsion_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                Arquivador.DataClass.Structure.ExclusionStructure myExclusionStructure = new Arquivador.DataClass.Structure.ExclusionStructure();
                myExclusionStructure.Path = folderBrowserDialog1.SelectedPath;

                Arquivador.BusinessClasses.Exclusion myExclusionBussinesClass = new Arquivador.BusinessClasses.Exclusion();

                myExclusionBussinesClass.Insert(myExclusionStructure);

                LoadExclusions();
            }
        }

        private void delOrigin_Click(object sender, EventArgs e)
        {
            Arquivador.DataClass.Structure.OriginStructure myOriginStructure = new Arquivador.DataClass.Structure.OriginStructure();

            myOriginStructure.Id = Convert.ToInt32(lstBoxSources.SelectedValue);

            Arquivador.BusinessClasses.Origin myOriginBussinesClass = new Arquivador.BusinessClasses.Origin();
            //myOriginBussinesClass.Load(myOriginStructure);

            myOriginBussinesClass.Delete(myOriginStructure);

            LoadOrigins();

        }

        private void delExclusion_Click(object sender, EventArgs e)
        {
            Arquivador.DataClass.Structure.ExclusionStructure myExclusionStructure = new Arquivador.DataClass.Structure.ExclusionStructure();

            myExclusionStructure.Id = Convert.ToInt32(lstBoxExclusions.SelectedValue);

            Arquivador.BusinessClasses.Exclusion myExclusionBussinesClass = new Arquivador.BusinessClasses.Exclusion();
            //myExclusionBussinesClass.Load(myExclusionStructure);

            myExclusionBussinesClass.Delete(myExclusionStructure);

            LoadExclusions();
        }

        private void setHistoryDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tb_historyDir.Text = folderBrowserDialog1.SelectedPath;

                btn_Archive.Enabled = false;
                btn_Preview.Enabled = false;
            }
        }
    }
}
