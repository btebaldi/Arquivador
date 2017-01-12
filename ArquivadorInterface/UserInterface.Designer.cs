namespace ArquivadorUI
{
    partial class UserInterface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInterface));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstBoxSources = new System.Windows.Forms.ListBox();
            this.btn_DelOrigin = new System.Windows.Forms.Button();
            this.btn_DelExclu = new System.Windows.Forms.Button();
            this.btn_AddOrigin = new System.Windows.Forms.Button();
            this.btn_AddExclu = new System.Windows.Forms.Button();
            this.lstBoxExclusions = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_EditDays = new System.Windows.Forms.Button();
            this.btn_browseHistDir = new System.Windows.Forms.Button();
            this.tb_historyTimeDays = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Preview = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Archive = new System.Windows.Forms.Button();
            this.tb_historyDir = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lstBoxSources);
            this.groupBox2.Controls.Add(this.btn_DelOrigin);
            this.groupBox2.Controls.Add(this.btn_DelExclu);
            this.groupBox2.Controls.Add(this.btn_AddOrigin);
            this.groupBox2.Controls.Add(this.btn_AddExclu);
            this.groupBox2.Controls.Add(this.lstBoxExclusions);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(358, 314);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Origins and Exclusions";
            // 
            // lstBoxSources
            // 
            this.lstBoxSources.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lstBoxSources.FormattingEnabled = true;
            this.lstBoxSources.Location = new System.Drawing.Point(6, 48);
            this.lstBoxSources.Name = "lstBoxSources";
            this.lstBoxSources.Size = new System.Drawing.Size(346, 82);
            this.lstBoxSources.TabIndex = 0;
            // 
            // btn_DelOrigin
            // 
            this.btn_DelOrigin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_DelOrigin.Location = new System.Drawing.Point(273, 19);
            this.btn_DelOrigin.Name = "btn_DelOrigin";
            this.btn_DelOrigin.Size = new System.Drawing.Size(75, 23);
            this.btn_DelOrigin.TabIndex = 13;
            this.btn_DelOrigin.Text = "Del";
            this.btn_DelOrigin.UseVisualStyleBackColor = true;
            this.btn_DelOrigin.Click += new System.EventHandler(this.delOrigin_Click);
            // 
            // btn_DelExclu
            // 
            this.btn_DelExclu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_DelExclu.Location = new System.Drawing.Point(273, 187);
            this.btn_DelExclu.Name = "btn_DelExclu";
            this.btn_DelExclu.Size = new System.Drawing.Size(75, 23);
            this.btn_DelExclu.TabIndex = 13;
            this.btn_DelExclu.Text = "Del";
            this.btn_DelExclu.UseVisualStyleBackColor = true;
            this.btn_DelExclu.Click += new System.EventHandler(this.delExclusion_Click);
            // 
            // btn_AddOrigin
            // 
            this.btn_AddOrigin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_AddOrigin.Location = new System.Drawing.Point(192, 19);
            this.btn_AddOrigin.Name = "btn_AddOrigin";
            this.btn_AddOrigin.Size = new System.Drawing.Size(75, 23);
            this.btn_AddOrigin.TabIndex = 13;
            this.btn_AddOrigin.Text = "Add";
            this.btn_AddOrigin.UseVisualStyleBackColor = true;
            this.btn_AddOrigin.Click += new System.EventHandler(this.addOrigin_Click);
            // 
            // btn_AddExclu
            // 
            this.btn_AddExclu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_AddExclu.Location = new System.Drawing.Point(192, 187);
            this.btn_AddExclu.Name = "btn_AddExclu";
            this.btn_AddExclu.Size = new System.Drawing.Size(75, 23);
            this.btn_AddExclu.TabIndex = 13;
            this.btn_AddExclu.Text = "Add";
            this.btn_AddExclu.UseVisualStyleBackColor = true;
            this.btn_AddExclu.Click += new System.EventHandler(this.addExclsion_Click);
            // 
            // lstBoxExclusions
            // 
            this.lstBoxExclusions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lstBoxExclusions.FormattingEnabled = true;
            this.lstBoxExclusions.Location = new System.Drawing.Point(6, 216);
            this.lstBoxExclusions.Name = "lstBoxExclusions";
            this.lstBoxExclusions.Size = new System.Drawing.Size(346, 82);
            this.lstBoxExclusions.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Origin(s)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Exclusion(s)";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btn_EditDays);
            this.groupBox3.Controls.Add(this.btn_browseHistDir);
            this.groupBox3.Controls.Add(this.tb_historyTimeDays);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.tb_historyDir);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(358, 92);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "General Data";
            // 
            // btn_EditDays
            // 
            this.btn_EditDays.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_EditDays.Location = new System.Drawing.Point(280, 49);
            this.btn_EditDays.Name = "btn_EditDays";
            this.btn_EditDays.Size = new System.Drawing.Size(72, 23);
            this.btn_EditDays.TabIndex = 13;
            this.btn_EditDays.Text = "...";
            this.btn_EditDays.UseVisualStyleBackColor = true;
            this.btn_EditDays.Click += new System.EventHandler(this.setHistoryDays_Click);
            // 
            // btn_browseHistDir
            // 
            this.btn_browseHistDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_browseHistDir.Location = new System.Drawing.Point(280, 23);
            this.btn_browseHistDir.Name = "btn_browseHistDir";
            this.btn_browseHistDir.Size = new System.Drawing.Size(72, 23);
            this.btn_browseHistDir.TabIndex = 13;
            this.btn_browseHistDir.Text = "...";
            this.btn_browseHistDir.UseVisualStyleBackColor = true;
            this.btn_browseHistDir.Click += new System.EventHandler(this.setHistoryDir_Click);
            // 
            // tb_historyTimeDays
            // 
            this.tb_historyTimeDays.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_historyTimeDays.Enabled = false;
            this.tb_historyTimeDays.Location = new System.Drawing.Point(135, 51);
            this.tb_historyTimeDays.Name = "tb_historyTimeDays";
            this.tb_historyTimeDays.Size = new System.Drawing.Size(139, 20);
            this.tb_historyTimeDays.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "History Time (days)";
            // 
            // btn_Preview
            // 
            this.btn_Preview.Location = new System.Drawing.Point(12, 430);
            this.btn_Preview.Name = "btn_Preview";
            this.btn_Preview.Size = new System.Drawing.Size(75, 23);
            this.btn_Preview.TabIndex = 0;
            this.btn_Preview.Text = "Preview";
            this.btn_Preview.UseVisualStyleBackColor = true;
            this.btn_Preview.Click += new System.EventHandler(this.previewButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "History Directory";
            // 
            // btn_Archive
            // 
            this.btn_Archive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Archive.Location = new System.Drawing.Point(292, 430);
            this.btn_Archive.Name = "btn_Archive";
            this.btn_Archive.Size = new System.Drawing.Size(75, 23);
            this.btn_Archive.TabIndex = 0;
            this.btn_Archive.Text = "Archive";
            this.btn_Archive.UseVisualStyleBackColor = true;
            this.btn_Archive.Click += new System.EventHandler(this.archive_Click);
            // 
            // tb_historyDir
            // 
            this.tb_historyDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_historyDir.Enabled = false;
            this.tb_historyDir.Location = new System.Drawing.Point(135, 25);
            this.tb_historyDir.Name = "tb_historyDir";
            this.tb_historyDir.Size = new System.Drawing.Size(139, 20);
            this.tb_historyDir.TabIndex = 0;
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 464);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_Archive);
            this.Controls.Add(this.btn_Preview);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserInterface";
            this.Text = "Arquivador";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstBoxSources;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_historyDir;
        private System.Windows.Forms.ListBox lstBoxExclusions;
        private System.Windows.Forms.TextBox tb_historyTimeDays;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Archive;
        private System.Windows.Forms.Button btn_DelExclu;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btn_AddExclu;
        private System.Windows.Forms.Button btn_DelOrigin;
        private System.Windows.Forms.Button btn_AddOrigin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_Preview;
        private System.Windows.Forms.Button btn_browseHistDir;
        private System.Windows.Forms.Button btn_EditDays;
    }
}

