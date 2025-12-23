namespace FlockAppC.選択画面
{
    partial class frmSelectStaff
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectStaff));
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvSelect2 = new System.Windows.Forms.DataGridView();
            this.dgvSelect1 = new System.Windows.Forms.DataGridView();
            this.chkZai = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdo3 = new System.Windows.Forms.RadioButton();
            this.rdo2 = new System.Windows.Forms.RadioButton();
            this.rdo1 = new System.Windows.Forms.RadioButton();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelect2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelect1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCheck
            // 
            this.btnCheck.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCheck.Image = global::FlockAppC.Properties.Resources.選択_小小小;
            this.btnCheck.Location = new System.Drawing.Point(12, 369);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(80, 37);
            this.btnCheck.TabIndex = 11;
            this.btnCheck.Text = "決定";
            this.btnCheck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.Image = global::FlockAppC.Properties.Resources.閉じるA_8p;
            this.btnClose.Location = new System.Drawing.Point(650, 370);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 37);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "閉じる";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvSelect2
            // 
            this.dgvSelect2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelect2.Location = new System.Drawing.Point(12, 58);
            this.dgvSelect2.Name = "dgvSelect2";
            this.dgvSelect2.RowTemplate.Height = 21;
            this.dgvSelect2.Size = new System.Drawing.Size(718, 305);
            this.dgvSelect2.TabIndex = 7;
            this.dgvSelect2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSelect2_CellDoubleClick);
            this.dgvSelect2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvSelect2_KeyDown);
            // 
            // dgvSelect1
            // 
            this.dgvSelect1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelect1.Location = new System.Drawing.Point(12, 12);
            this.dgvSelect1.Name = "dgvSelect1";
            this.dgvSelect1.RowTemplate.Height = 21;
            this.dgvSelect1.Size = new System.Drawing.Size(718, 36);
            this.dgvSelect1.TabIndex = 6;
            this.dgvSelect1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSelect1_CellClick);
            // 
            // chkZai
            // 
            this.chkZai.AutoSize = true;
            this.chkZai.Location = new System.Drawing.Point(549, 385);
            this.chkZai.Name = "chkZai";
            this.chkZai.Size = new System.Drawing.Size(91, 16);
            this.chkZai.TabIndex = 96;
            this.chkZai.Text = "退職者も含む";
            this.chkZai.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdo3);
            this.groupBox1.Controls.Add(this.rdo2);
            this.groupBox1.Controls.Add(this.rdo1);
            this.groupBox1.Location = new System.Drawing.Point(340, 370);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 37);
            this.groupBox1.TabIndex = 97;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "表示条件";
            // 
            // rdo3
            // 
            this.rdo3.AutoSize = true;
            this.rdo3.Checked = true;
            this.rdo3.Location = new System.Drawing.Point(142, 15);
            this.rdo3.Name = "rdo3";
            this.rdo3.Size = new System.Drawing.Size(44, 16);
            this.rdo3.TabIndex = 2;
            this.rdo3.TabStop = true;
            this.rdo3.Text = "全て";
            this.rdo3.UseVisualStyleBackColor = true;
            // 
            // rdo2
            // 
            this.rdo2.AutoSize = true;
            this.rdo2.Location = new System.Drawing.Point(85, 15);
            this.rdo2.Name = "rdo2";
            this.rdo2.Size = new System.Drawing.Size(47, 16);
            this.rdo2.TabIndex = 1;
            this.rdo2.Text = "専従";
            this.rdo2.UseVisualStyleBackColor = true;
            // 
            // rdo1
            // 
            this.rdo1.AutoSize = true;
            this.rdo1.Location = new System.Drawing.Point(29, 15);
            this.rdo1.Name = "rdo1";
            this.rdo1.Size = new System.Drawing.Size(47, 16);
            this.rdo1.TabIndex = 0;
            this.rdo1.Text = "社員";
            this.rdo1.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("游ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSearch.Image = global::FlockAppC.Properties.Resources.検索_小1;
            this.btnSearch.Location = new System.Drawing.Point(295, 374);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(29, 30);
            this.btnSearch.TabIndex = 98;
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtKey
            // 
            this.txtKey.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtKey.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtKey.Location = new System.Drawing.Point(183, 375);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(113, 28);
            this.txtKey.TabIndex = 99;
            this.txtKey.Text = "キーワード";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("游ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label26.Location = new System.Drawing.Point(103, 381);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(79, 16);
            this.label26.TabIndex = 100;
            this.label26.Text = "あいまい検索";
            // 
            // frmSelectStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 411);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkZai);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvSelect2);
            this.Controls.Add(this.dgvSelect1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSelectStaff";
            this.Text = "スタッフ選択";
            this.Load += new System.EventHandler(this.frmSelectStaff_Load);
            this.Shown += new System.EventHandler(this.frmSelectStaff_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelect2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelect1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvSelect2;
        private System.Windows.Forms.DataGridView dgvSelect1;
        private System.Windows.Forms.CheckBox chkZai;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdo3;
        private System.Windows.Forms.RadioButton rdo2;
        private System.Windows.Forms.RadioButton rdo1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label26;
    }
}