using System;
//using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Xml.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
//using ArquivadorHandler;
//using ArquivadorHandler.BusinessClasses;
using System.IO;
using System.Collections.Generic;

namespace ArquivadorUI
{
    public partial class UserInterface : Form
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger("ArquivadorUI.Program.cs");
        private BusinessClass.Config sysConfig = new BusinessClass.Config();

        public UserInterface()
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
                if (System.IO.Directory.Exists(sysConfig.HistoryDir))
                { BusinessClass.ArqWorker.Arquivar(true); }
                else
                {
                    logger.Warn("Invalidy Hystory Directory:" + System.IO.Directory.Exists(sysConfig.HistoryDir));
                    MessageBox.Show("Invalidy Hystory Directory");
                }
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

                sysConfig.HistoryDir = tb_historyDir.Text;
                sysConfig.HistoryDays = Convert.ToInt32(tb_historyTimeDays.Text);

                sysConfig.Save();

                logger.Info("Configuracoes Atualizadas");
                logger.Info("Dir: " + sysConfig.HistoryDir);
                logger.Info("Days: " + sysConfig.HistoryDays);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            LoadSettings();
        }

        private void LoadSettings()
        {
            tb_historyDir.Text = sysConfig.HistoryDir;
            tb_historyTimeDays.Text = sysConfig.HistoryDays.ToString();
        }

        private void LoadOrigins()
        {
            ArquivadorUI.BusinessClass.Origin originHandler = new BusinessClass.Origin();
            List<ArquivadorUI.DataClass.Structure.Origin> myOrigins = originHandler.GetOrigins();

            lstBoxSources.DataSource = myOrigins;
            lstBoxSources.DisplayMember = "Path";
            lstBoxSources.ValueMember = "Id";
        }

        private void LoadExclusions()
        {
            ArquivadorUI.BusinessClass.Exclusion exclusionHandler = new BusinessClass.Exclusion();
            List<ArquivadorUI.DataClass.Structure.Exclusion> myExclusions = exclusionHandler.GetExclusions();

            lstBoxExclusions.DataSource = myExclusions;
            lstBoxExclusions.DisplayMember = "Path";
            lstBoxExclusions.ValueMember = "Id";
        }

        private void addOrigin_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                ArquivadorUI.DataClass.Structure.Origin myOriginStruct = new ArquivadorUI.DataClass.Structure.Origin();
                myOriginStruct.Path = folderBrowserDialog1.SelectedPath;

                ArquivadorUI.BusinessClass.Origin myOriginBussinessClass = new ArquivadorUI.BusinessClass.Origin();

                myOriginBussinessClass.Insert(myOriginStruct);

                logger.Info("Origem Adicionada:" + myOriginStruct.Path);

                LoadOrigins();
            }
        }

        private void addExclsion_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                ArquivadorUI.DataClass.Structure.Exclusion myExclusionStructure = new ArquivadorUI.DataClass.Structure.Exclusion();
                myExclusionStructure.Path = folderBrowserDialog1.SelectedPath;

                ArquivadorUI.BusinessClass.Exclusion myExclusionBussinesClass = new ArquivadorUI.BusinessClass.Exclusion();

                myExclusionBussinesClass.Insert(myExclusionStructure);
                logger.Info("Exclusao adicionada:" + myExclusionStructure.Path);

                LoadExclusions();
            }
        }

        private void delOrigin_Click(object sender, EventArgs e)
        {
            ArquivadorUI.DataClass.Structure.Origin myOriginStructure = new ArquivadorUI.DataClass.Structure.Origin();

            myOriginStructure.Id = Convert.ToInt32(lstBoxSources.SelectedValue);

            ArquivadorUI.BusinessClass.Origin myOriginBussinesClass = new ArquivadorUI.BusinessClass.Origin();

            myOriginBussinesClass.Delete(myOriginStructure);

            logger.Info("Origem Excluida: Id=" + myOriginStructure.Id);

            LoadOrigins();

        }

        private void delExclusion_Click(object sender, EventArgs e)
        {
            ArquivadorUI.DataClass.Structure.Exclusion myExclusionStructure = new ArquivadorUI.DataClass.Structure.Exclusion();

            myExclusionStructure.Id = Convert.ToInt32(lstBoxExclusions.SelectedValue);

            ArquivadorUI.BusinessClass.Exclusion myExclusionBussinesClass = new ArquivadorUI.BusinessClass.Exclusion();

            myExclusionBussinesClass.Delete(myExclusionStructure);

            logger.Info("Exclusao Excluida: Id=" + myExclusionStructure.Id);

            LoadExclusions();
        }

        private void setHistoryDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tb_historyDir.Text = folderBrowserDialog1.SelectedPath;
                try
                {
                    sysConfig.HistoryDir = tb_historyDir.Text;

                    sysConfig.Save();
                    logger.Info("Diretorio Historico Atualizado");
                    logger.Info("Dir: " + sysConfig.HistoryDir);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                LoadSettings();
            }
        }

        private void setHistoryDays_Click(object sender, EventArgs e)
        {
            if (!tb_historyTimeDays.Enabled)
            {
                tb_historyTimeDays.Enabled = true;
                btn_EditDays.Text = "Save";
                tb_historyTimeDays.Focus();
            }
            else
            {
                tb_historyTimeDays.Enabled = false;
                btn_EditDays.Text = "...";

                try
                {
                    sysConfig.HistoryDays = Convert.ToInt32(tb_historyTimeDays.Text);

                    sysConfig.Save();
                    logger.Info("Dias de Historico Atualizado");
                    logger.Info("Days: " + sysConfig.HistoryDays);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                LoadSettings();
            }
        }
    }
}

