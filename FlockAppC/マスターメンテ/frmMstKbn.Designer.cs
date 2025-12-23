namespace FlockAppC.マスターメンテ
{
    partial class frmMstKbn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMstKbn));
            this.Panel1 = new System.Windows.Forms.Panel();
            this.lblNew = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.dgvKbnList = new System.Windows.Forms.DataGridView();
            this.txtKbnName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKbn1 = new System.Windows.Forms.TextBox();
            this.dgvKbnDetailList = new System.Windows.Forms.DataGridView();
            this.btnDelete1 = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete2 = new System.Windows.Forms.Button();
            this.btnReg = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblConnect = new System.Windows.Forms.Label();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKbnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKbnDetailList)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Panel1.Controls.Add(this.lblNew);
            this.Panel1.Controls.Add(this.Label4);
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(964, 37);
            this.Panel1.TabIndex = 120;
            // 
            // lblNew
            // 
            this.lblNew.BackColor = System.Drawing.Color.IndianRed;
            this.lblNew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNew.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblNew.Location = new System.Drawing.Point(874, 4);
            this.lblNew.Name = "lblNew";
            this.lblNew.Size = new System.Drawing.Size(86, 30);
            this.lblNew.TabIndex = 128;
            this.lblNew.Text = "　新規　";
            this.lblNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label4.Location = new System.Drawing.Point(12, 9);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(165, 20);
            this.Label4.TabIndex = 52;
            this.Label4.Text = "区分マスターメンテナンス";
            // 
            // dgvKbnList
            // 
            this.dgvKbnList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKbnList.Location = new System.Drawing.Point(16, 56);
            this.dgvKbnList.Name = "dgvKbnList";
            this.dgvKbnList.RowTemplate.Height = 21;
            this.dgvKbnList.Size = new System.Drawing.Size(580, 540);
            this.dgvKbnList.TabIndex = 121;
            this.dgvKbnList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKbnList_CellClick);
            // 
            // txtKbnName
            // 
            this.txtKbnName.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtKbnName.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtKbnName.Location = new System.Drawing.Point(750, 51);
            this.txtKbnName.Name = "txtKbnName";
            this.txtKbnName.Size = new System.Drawing.Size(197, 28);
            this.txtKbnName.TabIndex = 137;
            this.txtKbnName.Text = "999";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(690, 57);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 17);
            this.label5.TabIndex = 136;
            this.label5.Text = "区分名称";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(603, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 17);
            this.label1.TabIndex = 138;
            this.label1.Text = "区分";
            // 
            // txtKbn1
            // 
            this.txtKbn1.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtKbn1.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtKbn1.Location = new System.Drawing.Point(636, 51);
            this.txtKbn1.Name = "txtKbn1";
            this.txtKbn1.Size = new System.Drawing.Size(48, 28);
            this.txtKbn1.TabIndex = 139;
            this.txtKbn1.Text = "999";
            this.txtKbn1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dgvKbnDetailList
            // 
            this.dgvKbnDetailList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKbnDetailList.Location = new System.Drawing.Point(607, 85);
            this.dgvKbnDetailList.Name = "dgvKbnDetailList";
            this.dgvKbnDetailList.RowTemplate.Height = 21;
            this.dgvKbnDetailList.Size = new System.Drawing.Size(340, 511);
            this.dgvKbnDetailList.TabIndex = 140;
            this.dgvKbnDetailList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKbnDetailList_CellClick);
            // 
            // btnDelete1
            // 
            this.btnDelete1.Font = new System.Drawing.Font("メイリオ", 9.75F);
            this.btnDelete1.Image = global::FlockAppC.Properties.Resources.削除1_4p;
            this.btnDelete1.Location = new System.Drawing.Point(180, 603);
            this.btnDelete1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete1.Name = "btnDelete1";
            this.btnDelete1.Size = new System.Drawing.Size(100, 40);
            this.btnDelete1.TabIndex = 145;
            this.btnDelete1.Text = "削除";
            this.btnDelete1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete1.UseVisualStyleBackColor = true;
            this.btnDelete1.Click += new System.EventHandler(this.btnDelete1_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("メイリオ", 9.75F);
            this.btnNew.Image = global::FlockAppC.Properties.Resources.追加_小2;
            this.btnNew.Location = new System.Drawing.Point(15, 603);
            this.btnNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(162, 40);
            this.btnNew.TabIndex = 144;
            this.btnNew.Text = "新しい区分を追加";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete2
            // 
            this.btnDelete2.Font = new System.Drawing.Font("メイリオ", 9.75F);
            this.btnDelete2.Image = global::FlockAppC.Properties.Resources.削除1_4p;
            this.btnDelete2.Location = new System.Drawing.Point(712, 603);
            this.btnDelete2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete2.Name = "btnDelete2";
            this.btnDelete2.Size = new System.Drawing.Size(100, 40);
            this.btnDelete2.TabIndex = 143;
            this.btnDelete2.Text = "削除";
            this.btnDelete2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete2.UseVisualStyleBackColor = true;
            this.btnDelete2.Click += new System.EventHandler(this.btnDelete2_Click);
            // 
            // btnReg
            // 
            this.btnReg.Font = new System.Drawing.Font("メイリオ", 9.75F);
            this.btnReg.Image = global::FlockAppC.Properties.Resources.FD_4_小小;
            this.btnReg.Location = new System.Drawing.Point(606, 603);
            this.btnReg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(100, 40);
            this.btnReg.TabIndex = 142;
            this.btnReg.Text = "保存";
            this.btnReg.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("メイリオ", 9.75F);
            this.btnClose.Image = global::FlockAppC.Properties.Resources.閉じるA_10p;
            this.btnClose.Location = new System.Drawing.Point(847, 603);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 40);
            this.btnClose.TabIndex = 141;
            this.btnClose.Text = "閉じる";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblConnect
            // 
            this.lblConnect.AutoSize = true;
            this.lblConnect.Font = new System.Drawing.Font("游ゴシック Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblConnect.ForeColor = System.Drawing.Color.Blue;
            this.lblConnect.Location = new System.Drawing.Point(441, 615);
            this.lblConnect.Name = "lblConnect";
            this.lblConnect.Size = new System.Drawing.Size(136, 16);
            this.lblConnect.TabIndex = 229;
            this.lblConnect.Text = "データベース接続中...";
            this.lblConnect.Visible = false;
            // 
            // frmMstKbn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 651);
            this.Controls.Add(this.lblConnect);
            this.Controls.Add(this.btnDelete1);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnDelete2);
            this.Controls.Add(this.btnReg);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvKbnDetailList);
            this.Controls.Add(this.txtKbn1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtKbnName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvKbnList);
            this.Controls.Add(this.Panel1);
            this.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMstKbn";
            this.Text = "マスターメンテナンス";
            this.Load += new System.EventHandler(this.frmMstKbn_Load);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKbnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKbnDetailList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label lblNew;
        internal System.Windows.Forms.Label Label4;
        private System.Windows.Forms.DataGridView dgvKbnList;
        private System.Windows.Forms.TextBox txtKbnName;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKbn1;
        private System.Windows.Forms.DataGridView dgvKbnDetailList;
        internal System.Windows.Forms.Button btnReg;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Button btnDelete2;
        internal System.Windows.Forms.Button btnDelete1;
        internal System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label lblConnect;
    }
}