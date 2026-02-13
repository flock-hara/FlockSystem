namespace FlockAppC.データ同期
{
    partial class frmExportReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExportReport));
            this.Panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.dtpDate2 = new System.Windows.Forms.DateTimePicker();
            this.dtpDate1 = new System.Windows.Forms.DateTimePicker();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCar = new System.Windows.Forms.Button();
            this.pgb = new System.Windows.Forms.ProgressBar();
            this.lblLocationName = new System.Windows.Forms.Label();
            this.btnSelectLocation = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblConnect = new System.Windows.Forms.Label();
            this.lblCnt = new System.Windows.Forms.Label();
            this.lblCarNo = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Panel1.Controls.Add(this.label2);
            this.Panel1.Controls.Add(this.Label4);
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(472, 37);
            this.Panel1.TabIndex = 81;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(228, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 20);
            this.label2.TabIndex = 53;
            this.label2.Text = "※日報データをXServerへ転送します";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label4.Location = new System.Drawing.Point(12, 10);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(178, 20);
            this.Label4.TabIndex = 52;
            this.Label4.Text = "日報入力データエクスポート";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(12, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 164;
            this.label1.Text = "データ範囲";
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Font = new System.Drawing.Font("メイリオ", 9F);
            this.Label10.Location = new System.Drawing.Point(263, 61);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(20, 18);
            this.Label10.TabIndex = 163;
            this.Label10.Text = "～";
            // 
            // dtpDate2
            // 
            this.dtpDate2.CalendarFont = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpDate2.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpDate2.Location = new System.Drawing.Point(284, 52);
            this.dtpDate2.Name = "dtpDate2";
            this.dtpDate2.Size = new System.Drawing.Size(160, 32);
            this.dtpDate2.TabIndex = 162;
            // 
            // dtpDate1
            // 
            this.dtpDate1.CalendarFont = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpDate1.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpDate1.Location = new System.Drawing.Point(100, 52);
            this.dtpDate1.Name = "dtpDate1";
            this.dtpDate1.Size = new System.Drawing.Size(160, 32);
            this.dtpDate1.TabIndex = 161;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClear.Location = new System.Drawing.Point(345, 102);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(99, 28);
            this.btnClear.TabIndex = 181;
            this.btnClear.Text = "条件クリア";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // btnCar
            // 
            this.btnCar.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCar.Location = new System.Drawing.Point(15, 141);
            this.btnCar.Name = "btnCar";
            this.btnCar.Size = new System.Drawing.Size(99, 28);
            this.btnCar.TabIndex = 180;
            this.btnCar.Text = "車両選択";
            this.btnCar.UseVisualStyleBackColor = true;
            this.btnCar.Click += new System.EventHandler(this.BtnCar_Click);
            // 
            // pgb
            // 
            this.pgb.Location = new System.Drawing.Point(16, 182);
            this.pgb.Name = "pgb";
            this.pgb.Size = new System.Drawing.Size(441, 14);
            this.pgb.TabIndex = 179;
            // 
            // lblLocationName
            // 
            this.lblLocationName.AutoSize = true;
            this.lblLocationName.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblLocationName.Location = new System.Drawing.Point(122, 107);
            this.lblLocationName.Name = "lblLocationName";
            this.lblLocationName.Size = new System.Drawing.Size(84, 20);
            this.lblLocationName.TabIndex = 178;
            this.lblLocationName.Text = "専従先名称";
            // 
            // btnSelectLocation
            // 
            this.btnSelectLocation.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSelectLocation.Location = new System.Drawing.Point(16, 102);
            this.btnSelectLocation.Name = "btnSelectLocation";
            this.btnSelectLocation.Size = new System.Drawing.Size(99, 28);
            this.btnSelectLocation.TabIndex = 177;
            this.btnSelectLocation.Text = "専従先選択";
            this.btnSelectLocation.UseVisualStyleBackColor = true;
            this.btnSelectLocation.Click += new System.EventHandler(this.BtnSelectLocation_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblMessage.Location = new System.Drawing.Point(152, 205);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(227, 36);
            this.lblMessage.TabIndex = 176;
            this.lblMessage.Text = "エクスポートが完了しました。";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblConnect
            // 
            this.lblConnect.AutoSize = true;
            this.lblConnect.Font = new System.Drawing.Font("游ゴシック Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblConnect.ForeColor = System.Drawing.Color.Blue;
            this.lblConnect.Location = new System.Drawing.Point(12, 213);
            this.lblConnect.Name = "lblConnect";
            this.lblConnect.Size = new System.Drawing.Size(136, 16);
            this.lblConnect.TabIndex = 175;
            this.lblConnect.Text = "データベース接続中...";
            this.lblConnect.Visible = false;
            // 
            // lblCnt
            // 
            this.lblCnt.AutoSize = true;
            this.lblCnt.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCnt.Location = new System.Drawing.Point(173, 249);
            this.lblCnt.Name = "lblCnt";
            this.lblCnt.Size = new System.Drawing.Size(17, 20);
            this.lblCnt.TabIndex = 174;
            this.lblCnt.Text = "0";
            // 
            // lblCarNo
            // 
            this.lblCarNo.AutoSize = true;
            this.lblCarNo.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCarNo.Location = new System.Drawing.Point(122, 146);
            this.lblCarNo.Name = "lblCarNo";
            this.lblCarNo.Size = new System.Drawing.Size(69, 20);
            this.lblCarNo.TabIndex = 171;
            this.lblCarNo.Text = "車両番号";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("メイリオ", 9.75F);
            this.btnClose.Image = global::FlockAppC.Properties.Resources.閉じる_小小1;
            this.btnClose.Location = new System.Drawing.Point(357, 242);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 35);
            this.btnClose.TabIndex = 173;
            this.btnClose.Text = " 閉じる";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnImport
            // 
            this.btnImport.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnImport.Image = global::FlockAppC.Properties.Resources.エクスポート1_小小;
            this.btnImport.Location = new System.Drawing.Point(12, 242);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(120, 35);
            this.btnImport.TabIndex = 172;
            this.btnImport.Text = "エクスポート";
            this.btnImport.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // frmExportReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 289);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCar);
            this.Controls.Add(this.pgb);
            this.Controls.Add(this.lblLocationName);
            this.Controls.Add(this.btnSelectLocation);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblConnect);
            this.Controls.Add(this.lblCnt);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.lblCarNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Label10);
            this.Controls.Add(this.dtpDate2);
            this.Controls.Add(this.dtpDate1);
            this.Controls.Add(this.Panel1);
            this.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmExportReport";
            this.Text = "データエクスポート";
            this.Load += new System.EventHandler(this.frmExportReport_Load);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.DateTimePicker dtpDate2;
        internal System.Windows.Forms.DateTimePicker dtpDate1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCar;
        private System.Windows.Forms.ProgressBar pgb;
        internal System.Windows.Forms.Label lblLocationName;
        private System.Windows.Forms.Button btnSelectLocation;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblConnect;
        internal System.Windows.Forms.Label lblCnt;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Button btnImport;
        internal System.Windows.Forms.Label lblCarNo;
        internal System.Windows.Forms.Label label2;
    }
}