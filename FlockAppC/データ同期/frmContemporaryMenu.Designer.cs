namespace FlockAppC.データ同期
{
    partial class frmContemporaryMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmContemporaryMenu));
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDeleteData = new System.Windows.Forms.Button();
            this.btnImportCarRun = new System.Windows.Forms.Button();
            this.btnImportReport = new System.Windows.Forms.Button();
            this.btnExportMaster = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.Panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Panel1.Controls.Add(this.Label4);
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(287, 37);
            this.Panel1.TabIndex = 78;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label4.Location = new System.Drawing.Point(12, 10);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(126, 20);
            this.Label4.TabIndex = 52;
            this.Label4.Text = "データ同期メニュー";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDeleteData);
            this.groupBox1.Controls.Add(this.btnImportCarRun);
            this.groupBox1.Controls.Add(this.btnImportReport);
            this.groupBox1.Controls.Add(this.btnExportMaster);
            this.groupBox1.Location = new System.Drawing.Point(16, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 254);
            this.groupBox1.TabIndex = 80;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "XServer同期";
            // 
            // btnDeleteData
            // 
            this.btnDeleteData.Image = global::FlockAppC.Properties.Resources.削除2_16p;
            this.btnDeleteData.Location = new System.Drawing.Point(11, 195);
            this.btnDeleteData.Name = "btnDeleteData";
            this.btnDeleteData.Size = new System.Drawing.Size(239, 50);
            this.btnDeleteData.TabIndex = 81;
            this.btnDeleteData.Text = "過去データ削除（XServer側）";
            this.btnDeleteData.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnDeleteData.UseVisualStyleBackColor = true;
            this.btnDeleteData.Click += new System.EventHandler(this.BtnDeleteData_Click);
            // 
            // btnImportCarRun
            // 
            this.btnImportCarRun.Image = global::FlockAppC.Properties.Resources.インポート1_小小;
            this.btnImportCarRun.Location = new System.Drawing.Point(11, 139);
            this.btnImportCarRun.Name = "btnImportCarRun";
            this.btnImportCarRun.Size = new System.Drawing.Size(239, 50);
            this.btnImportCarRun.TabIndex = 80;
            this.btnImportCarRun.Text = "走行記録データインポート";
            this.btnImportCarRun.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnImportCarRun.UseVisualStyleBackColor = true;
            this.btnImportCarRun.Click += new System.EventHandler(this.BtnImportCarRun_Click);
            // 
            // btnImportReport
            // 
            this.btnImportReport.Image = global::FlockAppC.Properties.Resources.インポート1_小小;
            this.btnImportReport.Location = new System.Drawing.Point(11, 83);
            this.btnImportReport.Name = "btnImportReport";
            this.btnImportReport.Size = new System.Drawing.Size(239, 50);
            this.btnImportReport.TabIndex = 77;
            this.btnImportReport.Text = "日報データインポート";
            this.btnImportReport.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnImportReport.UseVisualStyleBackColor = true;
            this.btnImportReport.Click += new System.EventHandler(this.BtnImportReport_Click);
            // 
            // btnExportMaster
            // 
            this.btnExportMaster.Image = global::FlockAppC.Properties.Resources.エクスポート小1;
            this.btnExportMaster.Location = new System.Drawing.Point(11, 27);
            this.btnExportMaster.Name = "btnExportMaster";
            this.btnExportMaster.Size = new System.Drawing.Size(239, 50);
            this.btnExportMaster.TabIndex = 76;
            this.btnExportMaster.Text = "マスターデータエクスポート";
            this.btnExportMaster.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnExportMaster.UseVisualStyleBackColor = true;
            this.btnExportMaster.Click += new System.EventHandler(this.BtnExportMaster_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("メイリオ", 9.75F);
            this.btnClose.Image = global::FlockAppC.Properties.Resources.閉じる_小小1;
            this.btnClose.Location = new System.Drawing.Point(180, 322);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 35);
            this.btnClose.TabIndex = 111;
            this.btnClose.Text = " 閉じる";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // frmContemporaryMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 368);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Panel1);
            this.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmContemporaryMenu";
            this.Text = "データ同期";
            this.Load += new System.EventHandler(this.FrmContemporaryMenu_Load);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label Label4;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Button btnDeleteData;
        internal System.Windows.Forms.Button btnImportCarRun;
        internal System.Windows.Forms.Button btnImportReport;
        internal System.Windows.Forms.Button btnExportMaster;
        internal System.Windows.Forms.Button btnClose;
    }
}