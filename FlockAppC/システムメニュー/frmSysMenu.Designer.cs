namespace FlockAppC
{
    partial class frmSysMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysMenu));
            this.btnIpCheck = new System.Windows.Forms.Button();
            this.btnRelease = new System.Windows.Forms.Button();
            this.btnMenu99 = new System.Windows.Forms.Button();
            this.btnChangeDB = new System.Windows.Forms.Button();
            this.dgvDBList = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvDBList2 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDBList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDBList2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIpCheck
            // 
            this.btnIpCheck.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold);
            this.btnIpCheck.ForeColor = System.Drawing.Color.Black;
            this.btnIpCheck.Location = new System.Drawing.Point(134, 23);
            this.btnIpCheck.Name = "btnIpCheck";
            this.btnIpCheck.Size = new System.Drawing.Size(106, 32);
            this.btnIpCheck.TabIndex = 112;
            this.btnIpCheck.Text = "IPｱﾄﾞﾚｽﾁｪｯｸ";
            this.btnIpCheck.UseVisualStyleBackColor = true;
            this.btnIpCheck.Click += new System.EventHandler(this.BtnIpCheck_Click);
            // 
            // btnRelease
            // 
            this.btnRelease.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnRelease.Location = new System.Drawing.Point(22, 23);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(106, 32);
            this.btnRelease.TabIndex = 114;
            this.btnRelease.Text = "ﾘﾘｰｽ情報";
            this.btnRelease.UseVisualStyleBackColor = true;
            this.btnRelease.Click += new System.EventHandler(this.BtnRelease_Click);
            // 
            // btnMenu99
            // 
            this.btnMenu99.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnMenu99.Location = new System.Drawing.Point(485, 219);
            this.btnMenu99.Name = "btnMenu99";
            this.btnMenu99.Size = new System.Drawing.Size(57, 32);
            this.btnMenu99.TabIndex = 115;
            this.btnMenu99.Text = "閉じる";
            this.btnMenu99.UseVisualStyleBackColor = true;
            this.btnMenu99.Click += new System.EventHandler(this.BtnMenu99_Click);
            // 
            // btnChangeDB
            // 
            this.btnChangeDB.Enabled = false;
            this.btnChangeDB.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnChangeDB.Location = new System.Drawing.Point(22, 219);
            this.btnChangeDB.Name = "btnChangeDB";
            this.btnChangeDB.Size = new System.Drawing.Size(194, 32);
            this.btnChangeDB.TabIndex = 117;
            this.btnChangeDB.Text = "DataBase切替";
            this.btnChangeDB.UseVisualStyleBackColor = true;
            this.btnChangeDB.Click += new System.EventHandler(this.BtnChangeDB_Click);
            // 
            // dgvDBList
            // 
            this.dgvDBList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDBList.Enabled = false;
            this.dgvDBList.Location = new System.Drawing.Point(22, 90);
            this.dgvDBList.Name = "dgvDBList";
            this.dgvDBList.RowTemplate.Height = 21;
            this.dgvDBList.Size = new System.Drawing.Size(257, 110);
            this.dgvDBList.TabIndex = 118;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(358, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 32);
            this.button1.TabIndex = 119;
            this.button1.Text = "予備";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(246, 23);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 32);
            this.button2.TabIndex = 120;
            this.button2.Text = "予備";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 121;
            this.label1.Text = "SQL Server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(291, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 17);
            this.label2.TabIndex = 122;
            this.label2.Text = "MySQL(XServer)";
            // 
            // dgvDBList2
            // 
            this.dgvDBList2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDBList2.Enabled = false;
            this.dgvDBList2.Location = new System.Drawing.Point(285, 90);
            this.dgvDBList2.Name = "dgvDBList2";
            this.dgvDBList2.RowTemplate.Height = 21;
            this.dgvDBList2.Size = new System.Drawing.Size(257, 110);
            this.dgvDBList2.TabIndex = 123;
            // 
            // frmSysMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 262);
            this.Controls.Add(this.dgvDBList2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvDBList);
            this.Controls.Add(this.btnChangeDB);
            this.Controls.Add(this.btnMenu99);
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.btnIpCheck);
            this.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSysMenu";
            this.Text = "その他";
            this.Load += new System.EventHandler(this.FrmSysMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDBList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDBList2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnIpCheck;
        internal System.Windows.Forms.Button btnRelease;
        internal System.Windows.Forms.Button btnMenu99;
        internal System.Windows.Forms.Button btnChangeDB;
        private System.Windows.Forms.DataGridView dgvDBList;
        internal System.Windows.Forms.Button button1;
        internal System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvDBList2;
    }
}