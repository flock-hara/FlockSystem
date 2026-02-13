namespace FlockAppC.データ同期
{
    partial class frmCarRun
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCarRun));
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.dtpDate2 = new System.Windows.Forms.DateTimePicker();
            this.dtpDate1 = new System.Windows.Forms.DateTimePicker();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.cmbCar = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCnt = new System.Windows.Forms.Label();
            this.lblConnect = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.pgb = new System.Windows.Forms.ProgressBar();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Panel1.Controls.Add(this.Label4);
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(472, 37);
            this.Panel1.TabIndex = 79;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label4.Location = new System.Drawing.Point(12, 10);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(165, 20);
            this.Label4.TabIndex = 52;
            this.Label4.Text = "走行記録データインポート";
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Font = new System.Drawing.Font("メイリオ", 9F);
            this.Label10.Location = new System.Drawing.Point(263, 61);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(20, 18);
            this.Label10.TabIndex = 82;
            this.Label10.Text = "～";
            // 
            // dtpDate2
            // 
            this.dtpDate2.CalendarFont = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpDate2.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpDate2.Location = new System.Drawing.Point(284, 52);
            this.dtpDate2.Name = "dtpDate2";
            this.dtpDate2.Size = new System.Drawing.Size(160, 32);
            this.dtpDate2.TabIndex = 81;
            // 
            // dtpDate1
            // 
            this.dtpDate1.CalendarFont = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpDate1.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpDate1.Location = new System.Drawing.Point(100, 52);
            this.dtpDate1.Name = "dtpDate1";
            this.dtpDate1.Size = new System.Drawing.Size(160, 32);
            this.dtpDate1.TabIndex = 80;
            // 
            // cmbUser
            // 
            this.cmbUser.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Location = new System.Drawing.Point(72, 101);
            this.cmbUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(116, 28);
            this.cmbUser.TabIndex = 107;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.Location = new System.Drawing.Point(12, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 20);
            this.label9.TabIndex = 106;
            this.label9.Text = "担当者";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label7.Location = new System.Drawing.Point(211, 105);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(84, 20);
            this.Label7.TabIndex = 105;
            this.Label7.Text = "車番：車種";
            // 
            // cmbCar
            // 
            this.cmbCar.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbCar.FormattingEnabled = true;
            this.cmbCar.Location = new System.Drawing.Point(301, 100);
            this.cmbCar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbCar.Name = "cmbCar";
            this.cmbCar.Size = new System.Drawing.Size(153, 28);
            this.cmbCar.TabIndex = 104;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(12, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 108;
            this.label1.Text = "データ範囲";
            // 
            // lblCnt
            // 
            this.lblCnt.AutoSize = true;
            this.lblCnt.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCnt.Location = new System.Drawing.Point(152, 204);
            this.lblCnt.Name = "lblCnt";
            this.lblCnt.Size = new System.Drawing.Size(17, 20);
            this.lblCnt.TabIndex = 111;
            this.lblCnt.Text = "0";
            // 
            // lblConnect
            // 
            this.lblConnect.AutoSize = true;
            this.lblConnect.Font = new System.Drawing.Font("游ゴシック Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblConnect.ForeColor = System.Drawing.Color.Blue;
            this.lblConnect.Location = new System.Drawing.Point(13, 168);
            this.lblConnect.Name = "lblConnect";
            this.lblConnect.Size = new System.Drawing.Size(136, 16);
            this.lblConnect.TabIndex = 153;
            this.lblConnect.Text = "データベース接続中...";
            this.lblConnect.Visible = false;
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblMessage.Location = new System.Drawing.Point(126, 160);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(227, 36);
            this.lblMessage.TabIndex = 154;
            this.lblMessage.Text = "インポートが完了しました。";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pgb
            // 
            this.pgb.Location = new System.Drawing.Point(16, 142);
            this.pgb.Name = "pgb";
            this.pgb.Size = new System.Drawing.Size(441, 14);
            this.pgb.TabIndex = 169;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("メイリオ", 9.75F);
            this.btnClose.Image = global::FlockAppC.Properties.Resources.閉じる_小小;
            this.btnClose.Location = new System.Drawing.Point(354, 201);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 35);
            this.btnClose.TabIndex = 110;
            this.btnClose.Text = " 閉じる";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnImport
            // 
            this.btnImport.Image = global::FlockAppC.Properties.Resources.インポート_1_0;
            this.btnImport.Location = new System.Drawing.Point(12, 201);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(110, 35);
            this.btnImport.TabIndex = 109;
            this.btnImport.Text = "インポート";
            this.btnImport.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // frmCarRun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 247);
            this.Controls.Add(this.pgb);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblConnect);
            this.Controls.Add(this.lblCnt);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbUser);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.cmbCar);
            this.Controls.Add(this.Label10);
            this.Controls.Add(this.dtpDate2);
            this.Controls.Add(this.dtpDate1);
            this.Controls.Add(this.Panel1);
            this.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCarRun";
            this.Text = "データインポート";
            this.Load += new System.EventHandler(this.FrmCarRun_Load);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.DateTimePicker dtpDate2;
        internal System.Windows.Forms.DateTimePicker dtpDate1;
        internal System.Windows.Forms.ComboBox cmbUser;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.ComboBox cmbCar;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Button btnImport;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Label lblCnt;
        private System.Windows.Forms.Label lblConnect;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.ProgressBar pgb;
    }
}