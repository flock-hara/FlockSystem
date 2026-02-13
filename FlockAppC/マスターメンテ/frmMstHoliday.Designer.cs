namespace FlockAppC.マスターメンテ
{
    partial class frmMstHoliday
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMstHoliday));
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Label11 = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.mtxtDay = new System.Windows.Forms.MaskedTextBox();
            this.txtHoliday = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnReg = new System.Windows.Forms.Button();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Panel1.Controls.Add(this.Label11);
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(371, 37);
            this.Panel1.TabIndex = 87;
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label11.Location = new System.Drawing.Point(12, 8);
            this.Label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(191, 20);
            this.Label11.TabIndex = 52;
            this.Label11.Text = "休日設定マスターメンテナンス";
            // 
            // cmbYear
            // 
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(73, 52);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(96, 25);
            this.cmbYear.TabIndex = 93;
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            // 
            // btnCopy
            // 
            this.btnCopy.Image = global::FlockAppC.Properties.Resources.コピー_01;
            this.btnCopy.Location = new System.Drawing.Point(252, 43);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(110, 35);
            this.btnCopy.TabIndex = 100;
            this.btnCopy.Text = "前年コピー";
            this.btnCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(18, 56);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(51, 17);
            this.label26.TabIndex = 101;
            this.label26.Text = "年 選択";
            // 
            // dgvList
            // 
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Location = new System.Drawing.Point(12, 120);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowTemplate.Height = 21;
            this.dgvList.Size = new System.Drawing.Size(347, 502);
            this.dgvList.TabIndex = 102;
            this.dgvList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellClick);
            // 
            // mtxtDay
            // 
            this.mtxtDay.Location = new System.Drawing.Point(16, 85);
            this.mtxtDay.Mask = "0000/00/00";
            this.mtxtDay.Name = "mtxtDay";
            this.mtxtDay.Size = new System.Drawing.Size(96, 28);
            this.mtxtDay.TabIndex = 103;
            this.mtxtDay.ValidatingType = typeof(System.DateTime);
            // 
            // txtHoliday
            // 
            this.txtHoliday.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtHoliday.Location = new System.Drawing.Point(119, 85);
            this.txtHoliday.Margin = new System.Windows.Forms.Padding(4);
            this.txtHoliday.Name = "txtHoliday";
            this.txtHoliday.Size = new System.Drawing.Size(243, 28);
            this.txtHoliday.TabIndex = 104;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.Image = global::FlockAppC.Properties.Resources.閉じる_小小;
            this.btnClose.Location = new System.Drawing.Point(280, 628);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 37);
            this.btnClose.TabIndex = 105;
            this.btnClose.Text = "閉じる";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnDelete.Image = global::FlockAppC.Properties.Resources.削除1_4p;
            this.btnDelete.Location = new System.Drawing.Point(184, 628);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 37);
            this.btnDelete.TabIndex = 108;
            this.btnDelete.Text = "削除";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnNew.Image = global::FlockAppC.Properties.Resources.追加_小小;
            this.btnNew.Location = new System.Drawing.Point(97, 628);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(80, 37);
            this.btnNew.TabIndex = 107;
            this.btnNew.Text = "新規";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnReg
            // 
            this.btnReg.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnReg.Image = global::FlockAppC.Properties.Resources.FD_1_小小;
            this.btnReg.Location = new System.Drawing.Point(10, 628);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(80, 37);
            this.btnReg.TabIndex = 106;
            this.btnReg.Text = "保存";
            this.btnReg.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // frmMstHoliday
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 671);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnReg);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.mtxtDay);
            this.Controls.Add(this.txtHoliday);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.Panel1);
            this.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMstHoliday";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "マスターメンテナンス";
            this.Load += new System.EventHandler(this.frmMstHoliday_Load);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.ComboBox cmbYear;
        internal System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.DataGridView dgvList;
        internal System.Windows.Forms.MaskedTextBox mtxtDay;
        internal System.Windows.Forms.TextBox txtHoliday;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnReg;
    }
}