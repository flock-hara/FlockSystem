namespace FlockAppC.勤務表
{
    partial class frmShiftHistory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShiftHistory));
            this.Label7 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.rboReg = new System.Windows.Forms.RadioButton();
            this.rboSchedule = new System.Windows.Forms.RadioButton();
            this.btnReDraw = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.Label10 = new System.Windows.Forms.Label();
            this.dtpDate2 = new System.Windows.Forms.DateTimePicker();
            this.dtpDate1 = new System.Windows.Forms.DateTimePicker();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvHistoryList = new System.Windows.Forms.DataGridView();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoryList)).BeginInit();
            this.SuspendLayout();
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label7.Location = new System.Drawing.Point(692, 26);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(60, 17);
            this.Label7.TabIndex = 40;
            this.Label7.Text = "更新状況";
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(758, 22);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(93, 25);
            this.cmbStatus.TabIndex = 39;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.rboReg);
            this.GroupBox1.Controls.Add(this.rboSchedule);
            this.GroupBox1.Location = new System.Drawing.Point(859, 9);
            this.GroupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GroupBox1.Size = new System.Drawing.Size(165, 40);
            this.GroupBox1.TabIndex = 38;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "対象";
            // 
            // rboReg
            // 
            this.rboReg.AutoSize = true;
            this.rboReg.Location = new System.Drawing.Point(86, 14);
            this.rboReg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rboReg.Name = "rboReg";
            this.rboReg.Size = new System.Drawing.Size(65, 21);
            this.rboReg.TabIndex = 1;
            this.rboReg.Text = "登録日";
            this.rboReg.UseVisualStyleBackColor = true;
            this.rboReg.CheckedChanged += new System.EventHandler(this.rboReg_CheckedChanged);
            // 
            // rboSchedule
            // 
            this.rboSchedule.AutoSize = true;
            this.rboSchedule.Checked = true;
            this.rboSchedule.Location = new System.Drawing.Point(19, 15);
            this.rboSchedule.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rboSchedule.Name = "rboSchedule";
            this.rboSchedule.Size = new System.Drawing.Size(65, 21);
            this.rboSchedule.TabIndex = 0;
            this.rboSchedule.TabStop = true;
            this.rboSchedule.Text = "予定日";
            this.rboSchedule.UseVisualStyleBackColor = true;
            this.rboSchedule.CheckedChanged += new System.EventHandler(this.rboSchedule_CheckedChanged);
            // 
            // btnReDraw
            // 
            this.btnReDraw.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnReDraw.Location = new System.Drawing.Point(405, 10);
            this.btnReDraw.Name = "btnReDraw";
            this.btnReDraw.Size = new System.Drawing.Size(110, 40);
            this.btnReDraw.TabIndex = 37;
            this.btnReDraw.Text = "表示";
            this.btnReDraw.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReDraw.UseVisualStyleBackColor = true;
            this.btnReDraw.Visible = false;
            // 
            // btnExcel
            // 
            this.btnExcel.Font = new System.Drawing.Font("メイリオ", 9.75F);
            this.btnExcel.Image = global::FlockAppC.Properties.Resources.エクセル_3_小小;
            this.btnExcel.Location = new System.Drawing.Point(22, 592);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(110, 35);
            this.btnExcel.TabIndex = 36;
            this.btnExcel.Text = "Excel出力";
            this.btnExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Font = new System.Drawing.Font("メイリオ", 9F);
            this.Label10.Location = new System.Drawing.Point(200, 25);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(20, 18);
            this.Label10.TabIndex = 35;
            this.Label10.Text = "～";
            // 
            // dtpDate2
            // 
            this.dtpDate2.CalendarFont = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpDate2.Font = new System.Drawing.Font("游ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpDate2.Location = new System.Drawing.Point(227, 16);
            this.dtpDate2.Name = "dtpDate2";
            this.dtpDate2.Size = new System.Drawing.Size(172, 33);
            this.dtpDate2.TabIndex = 34;
            this.dtpDate2.ValueChanged += new System.EventHandler(this.dtpDate2_ValueChanged);
            // 
            // dtpDate1
            // 
            this.dtpDate1.CalendarFont = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpDate1.Font = new System.Drawing.Font("游ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpDate1.Location = new System.Drawing.Point(22, 16);
            this.dtpDate1.Name = "dtpDate1";
            this.dtpDate1.Size = new System.Drawing.Size(172, 33);
            this.dtpDate1.TabIndex = 33;
            this.dtpDate1.ValueChanged += new System.EventHandler(this.dtpDate1_ValueChanged);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("メイリオ", 9.75F);
            this.btnClose.Image = global::FlockAppC.Properties.Resources.閉じる_小小;
            this.btnClose.Location = new System.Drawing.Point(924, 592);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 35);
            this.btnClose.TabIndex = 32;
            this.btnClose.Text = "閉じる";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvHistoryList
            // 
            this.dgvHistoryList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistoryList.Location = new System.Drawing.Point(22, 55);
            this.dgvHistoryList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvHistoryList.Name = "dgvHistoryList";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistoryList.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHistoryList.RowTemplate.Height = 25;
            this.dgvHistoryList.Size = new System.Drawing.Size(1002, 529);
            this.dgvHistoryList.TabIndex = 31;
            // 
            // cmbUser
            // 
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Location = new System.Drawing.Point(587, 23);
            this.cmbUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(92, 25);
            this.cmbUser.TabIndex = 103;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.Location = new System.Drawing.Point(538, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 17);
            this.label9.TabIndex = 102;
            this.label9.Text = "担当者";
            // 
            // frmShiftHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 635);
            this.Controls.Add(this.cmbUser);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.btnReDraw);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.Label10);
            this.Controls.Add(this.dtpDate2);
            this.Controls.Add(this.dtpDate1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvHistoryList);
            this.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmShiftHistory";
            this.Text = "勤務表シフト変更履歴";
            this.Load += new System.EventHandler(this.frmShiftHistory_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoryList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.ComboBox cmbStatus;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.RadioButton rboReg;
        internal System.Windows.Forms.RadioButton rboSchedule;
        internal System.Windows.Forms.Button btnReDraw;
        internal System.Windows.Forms.Button btnExcel;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.DateTimePicker dtpDate2;
        internal System.Windows.Forms.DateTimePicker dtpDate1;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.DataGridView dgvHistoryList;
        internal System.Windows.Forms.ComboBox cmbUser;
        internal System.Windows.Forms.Label label9;
    }
}