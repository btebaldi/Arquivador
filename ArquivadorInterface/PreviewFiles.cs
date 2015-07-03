
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Arquivador.BusinessClasses;
using System.IO;


namespace ArquivadorInterface
{
    public partial class PreviewFiles : Form
    {
        public PreviewFiles()
        {
            InitializeComponent();
            LoadPreview();
        }

        private void LoadPreview()
        {
            ArchiverChooser chooser = new ArchiverChooser(new Origin(), new Exclusion());

            dataGridView1.DataSource = chooser.GetProcessedFileSystemInfos();
            dataGridView1.Columns["CreationTime"].Visible = false;
            dataGridView1.Columns["CreationTimeUtc"].Visible = false;
            dataGridView1.Columns["LastAccessTime"].Visible = false;
            dataGridView1.Columns["LastAccessTimeUtc"].Visible = false;
            dataGridView1.Columns["LastWriteTime"].Visible = false;
            dataGridView1.Columns["LastWriteTimeUtc"].Visible = false;
            dataGridView1.Columns["Attributes"].Visible = false;
        }
    }
}
