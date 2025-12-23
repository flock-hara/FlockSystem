namespace FlockAppC.ScheduleBoard
{
    partial class frmScheduleBoardDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScheduleBoardDetail));
            this.dtpScheduleStartTime = new System.Windows.Forms.DateTimePicker();
            this.cmbScheduleTanto = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.dtpScheduleEndTime = new System.Windows.Forms.DateTimePicker();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReg = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtSchedule = new System.Windows.Forms.TextBox();
            this.dtpSchedule = new System.Windows.Forms.DateTimePicker();
            this.chkReturn = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkStatus = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // dtpScheduleStartTime
            // 
            this.dtpScheduleStartTime.CustomFormat = "HH:mm";
            this.dtpScheduleStartTime.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpScheduleStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpScheduleStartTime.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.dtpScheduleStartTime.Location = new System.Drawing.Point(12, 63);
            this.dtpScheduleStartTime.Name = "dtpScheduleStartTime";
            this.dtpScheduleStartTime.ShowUpDown = true;
            this.dtpScheduleStartTime.Size = new System.Drawing.Size(64, 25);
            this.dtpScheduleStartTime.TabIndex = 181;
            // 
            // cmbScheduleTanto
            // 
            this.cmbScheduleTanto.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbScheduleTanto.FormattingEnabled = true;
            this.cmbScheduleTanto.Location = new System.Drawing.Point(204, 22);
            this.cmbScheduleTanto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbScheduleTanto.Name = "cmbScheduleTanto";
            this.cmbScheduleTanto.Size = new System.Drawing.Size(71, 26);
            this.cmbScheduleTanto.TabIndex = 179;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label2.Location = new System.Drawing.Point(159, 25);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(48, 20);
            this.Label2.TabIndex = 180;
            this.Label2.Text = "担当：";
            // 
            // dtpScheduleEndTime
            // 
            this.dtpScheduleEndTime.CustomFormat = "HH:mm";
            this.dtpScheduleEndTime.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpScheduleEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpScheduleEndTime.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.dtpScheduleEndTime.Location = new System.Drawing.Point(104, 63);
            this.dtpScheduleEndTime.Name = "dtpScheduleEndTime";
            this.dtpScheduleEndTime.ShowUpDown = true;
            this.dtpScheduleEndTime.Size = new System.Drawing.Size(64, 25);
            this.dtpScheduleEndTime.TabIndex = 182;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("メイリオ", 9.75F);
            this.btnClose.Image = global::FlockAppC.Properties.Resources.閉じる_小;
            this.btnClose.Location = new System.Drawing.Point(244, 204);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 36);
            this.btnClose.TabIndex = 183;
            this.btnClose.Text = "閉じる";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnReg
            // 
            this.btnReg.Font = new System.Drawing.Font("メイリオ", 9.75F);
            this.btnReg.Image = global::FlockAppC.Properties.Resources.FD_1_小小;
            this.btnReg.Location = new System.Drawing.Point(12, 204);
            this.btnReg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(90, 36);
            this.btnReg.TabIndex = 185;
            this.btnReg.Text = "　登録";
            this.btnReg.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.BtnReg_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::FlockAppC.Properties.Resources.削除_1_小小;
            this.btnDelete.Location = new System.Drawing.Point(108, 204);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 36);
            this.btnDelete.TabIndex = 186;
            this.btnDelete.Text = "　削除";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // txtSchedule
            // 
            this.txtSchedule.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtSchedule.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtSchedule.Location = new System.Drawing.Point(12, 106);
            this.txtSchedule.Multiline = true;
            this.txtSchedule.Name = "txtSchedule";
            this.txtSchedule.Size = new System.Drawing.Size(322, 64);
            this.txtSchedule.TabIndex = 187;
            // 
            // dtpSchedule
            // 
            this.dtpSchedule.CalendarFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpSchedule.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpSchedule.Location = new System.Drawing.Point(12, 22);
            this.dtpSchedule.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpSchedule.Name = "dtpSchedule";
            this.dtpSchedule.Size = new System.Drawing.Size(133, 25);
            this.dtpSchedule.TabIndex = 188;
            // 
            // chkReturn
            // 
            this.chkReturn.AutoSize = true;
            this.chkReturn.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chkReturn.Location = new System.Drawing.Point(194, 65);
            this.chkReturn.Name = "chkReturn";
            this.chkReturn.Size = new System.Drawing.Size(80, 24);
            this.chkReturn.TabIndex = 189;
            this.chkReturn.Text = "帰社予定";
            this.chkReturn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(80, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 20);
            this.label1.TabIndex = 190;
            this.label1.Text = "～";
            // 
            // chkStatus
            // 
            this.chkStatus.AutoSize = true;
            this.chkStatus.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chkStatus.Location = new System.Drawing.Point(17, 176);
            this.chkStatus.Name = "chkStatus";
            this.chkStatus.Size = new System.Drawing.Size(41, 24);
            this.chkStatus.TabIndex = 191;
            this.chkStatus.Text = "済";
            this.chkStatus.UseVisualStyleBackColor = true;
            // 
            // frmScheduleBoardDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 251);
            this.Controls.Add(this.chkStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkReturn);
            this.Controls.Add(this.dtpSchedule);
            this.Controls.Add(this.txtSchedule);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnReg);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dtpScheduleEndTime);
            this.Controls.Add(this.dtpScheduleStartTime);
            this.Controls.Add(this.cmbScheduleTanto);
            this.Controls.Add(this.Label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmScheduleBoardDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "スケジュール詳細";
            this.Load += new System.EventHandler(this.FrmScheduleBoardDetail_Load);
            this.Shown += new System.EventHandler(this.FrmScheduleBoardDetail_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.DateTimePicker dtpScheduleStartTime;
        internal System.Windows.Forms.ComboBox cmbScheduleTanto;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.DateTimePicker dtpScheduleEndTime;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Button btnReg;
        internal System.Windows.Forms.Button btnDelete;
        internal System.Windows.Forms.TextBox txtSchedule;
        internal System.Windows.Forms.DateTimePicker dtpSchedule;
        private System.Windows.Forms.CheckBox chkReturn;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkStatus;
    }
}