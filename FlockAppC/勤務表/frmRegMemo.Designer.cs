namespace FlockAppC.勤務表
{
    partial class frmRegMemo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegMemo));
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnReg = new System.Windows.Forms.Button();
            this.btnMenu10 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtpDate
            // 
            this.dtpDate.CalendarFont = new System.Drawing.Font("游ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpDate.CustomFormat = "yyyy/MM/dd dddd";
            this.dtpDate.Font = new System.Drawing.Font("メイリオ", 12F);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(16, 19);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(216, 31);
            this.dtpDate.TabIndex = 79;
            // 
            // btnReg
            // 
            this.btnReg.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnReg.Image = global::FlockAppC.Properties.Resources.HD_小小;
            this.btnReg.Location = new System.Drawing.Point(192, 139);
            this.btnReg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(100, 40);
            this.btnReg.TabIndex = 94;
            this.btnReg.Text = "登録";
            this.btnReg.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReg.UseVisualStyleBackColor = true;
            // 
            // btnMenu10
            // 
            this.btnMenu10.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnMenu10.Image = global::FlockAppC.Properties.Resources.閉じる_小小;
            this.btnMenu10.Location = new System.Drawing.Point(298, 139);
            this.btnMenu10.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMenu10.Name = "btnMenu10";
            this.btnMenu10.Size = new System.Drawing.Size(100, 40);
            this.btnMenu10.TabIndex = 93;
            this.btnMenu10.Text = "閉じる";
            this.btnMenu10.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMenu10.UseVisualStyleBackColor = true;
            this.btnMenu10.Click += new System.EventHandler(this.btnMenu10_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 83);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 17);
            this.label10.TabIndex = 100;
            this.label10.Text = "メモ";
            // 
            // txtMemo
            // 
            this.txtMemo.Location = new System.Drawing.Point(58, 76);
            this.txtMemo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(340, 28);
            this.txtMemo.TabIndex = 99;
            // 
            // cmbUser
            // 
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Location = new System.Drawing.Point(306, 24);
            this.cmbUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(92, 25);
            this.cmbUser.TabIndex = 103;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.Location = new System.Drawing.Point(257, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 17);
            this.label9.TabIndex = 102;
            this.label9.Text = "担当者";
            // 
            // frmRegMemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 191);
            this.Controls.Add(this.cmbUser);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtMemo);
            this.Controls.Add(this.btnReg);
            this.Controls.Add(this.btnMenu10);
            this.Controls.Add(this.dtpDate);
            this.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmRegMemo";
            this.Text = "メモ登録";
            this.Load += new System.EventHandler(this.frmRegMemo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.DateTimePicker dtpDate;
        internal System.Windows.Forms.Button btnReg;
        internal System.Windows.Forms.Button btnMenu10;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.TextBox txtMemo;
        internal System.Windows.Forms.ComboBox cmbUser;
        internal System.Windows.Forms.Label label9;
    }
}