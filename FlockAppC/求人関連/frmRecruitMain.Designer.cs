namespace FlockAppC.求人関連
{
    partial class frmRecruitMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecruitMain));
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.chkEnd = new System.Windows.Forms.CheckBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.dgvApply = new System.Windows.Forms.DataGridView();
            this.dgvPublish = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnMenu10 = new System.Windows.Forms.Button();
            this.btnMenu1 = new System.Windows.Forms.Button();
            this.btnMenu6 = new System.Windows.Forms.Button();
            this.btnMenu5 = new System.Windows.Forms.Button();
            this.btnMenu4 = new System.Windows.Forms.Button();
            this.btnMenu3 = new System.Windows.Forms.Button();
            this.btnMenu2 = new System.Windows.Forms.Button();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApply)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPublish)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Panel1.Controls.Add(this.Label4);
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(1384, 37);
            this.Panel1.TabIndex = 119;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label4.Location = new System.Drawing.Point(12, 9);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(61, 20);
            this.Label4.TabIndex = 52;
            this.Label4.Text = "募集状況";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label1.Location = new System.Drawing.Point(17, 48);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(60, 17);
            this.Label1.TabIndex = 126;
            this.Label1.Text = "折込掲載";
            // 
            // chkEnd
            // 
            this.chkEnd.AutoSize = true;
            this.chkEnd.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chkEnd.Location = new System.Drawing.Point(98, 46);
            this.chkEnd.Name = "chkEnd";
            this.chkEnd.Size = new System.Drawing.Size(92, 21);
            this.chkEnd.TabIndex = 127;
            this.chkEnd.Text = "掲載終了分";
            this.chkEnd.UseVisualStyleBackColor = true;
            this.chkEnd.CheckedChanged += new System.EventHandler(this.chkEnd_CheckedChanged);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label2.Location = new System.Drawing.Point(640, 48);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(47, 17);
            this.Label2.TabIndex = 128;
            this.Label2.Text = "応募者";
            // 
            // dgvApply
            // 
            this.dgvApply.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApply.Location = new System.Drawing.Point(637, 68);
            this.dgvApply.MultiSelect = false;
            this.dgvApply.Name = "dgvApply";
            this.dgvApply.ReadOnly = true;
            this.dgvApply.RowTemplate.Height = 21;
            this.dgvApply.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApply.Size = new System.Drawing.Size(734, 485);
            this.dgvApply.TabIndex = 130;
            this.dgvApply.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvApply_CellClick);
            // 
            // dgvPublish
            // 
            this.dgvPublish.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPublish.Location = new System.Drawing.Point(14, 68);
            this.dgvPublish.MultiSelect = false;
            this.dgvPublish.Name = "dgvPublish";
            this.dgvPublish.ReadOnly = true;
            this.dgvPublish.RowTemplate.Height = 21;
            this.dgvPublish.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPublish.Size = new System.Drawing.Size(617, 485);
            this.dgvPublish.TabIndex = 129;
            this.dgvPublish.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPublish_CellClick);
            this.dgvPublish.SelectionChanged += new System.EventHandler(this.dgvPublish_SelectionChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("メイリオ", 9.75F);
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Image = global::FlockAppC.Properties.Resources.表_小小;
            this.button1.Location = new System.Drawing.Point(1073, 561);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 35);
            this.button1.TabIndex = 132;
            this.button1.Text = "一覧表示";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnMenu10
            // 
            this.btnMenu10.Font = new System.Drawing.Font("メイリオ", 9.75F);
            this.btnMenu10.ForeColor = System.Drawing.Color.Black;
            this.btnMenu10.Image = global::FlockAppC.Properties.Resources.閉じる_小小;
            this.btnMenu10.Location = new System.Drawing.Point(1271, 560);
            this.btnMenu10.Margin = new System.Windows.Forms.Padding(4);
            this.btnMenu10.Name = "btnMenu10";
            this.btnMenu10.Size = new System.Drawing.Size(100, 35);
            this.btnMenu10.TabIndex = 131;
            this.btnMenu10.Text = "閉じる";
            this.btnMenu10.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMenu10.UseVisualStyleBackColor = true;
            this.btnMenu10.Click += new System.EventHandler(this.btnMenu10_Click);
            // 
            // btnMenu1
            // 
            this.btnMenu1.Font = new System.Drawing.Font("游ゴシック Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnMenu1.ForeColor = System.Drawing.Color.Blue;
            this.btnMenu1.Image = global::FlockAppC.Properties.Resources.追加_小小;
            this.btnMenu1.Location = new System.Drawing.Point(16, 560);
            this.btnMenu1.Margin = new System.Windows.Forms.Padding(4);
            this.btnMenu1.Name = "btnMenu1";
            this.btnMenu1.Size = new System.Drawing.Size(100, 35);
            this.btnMenu1.TabIndex = 120;
            this.btnMenu1.Text = "掲載追加";
            this.btnMenu1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMenu1.UseVisualStyleBackColor = true;
            this.btnMenu1.Click += new System.EventHandler(this.btnMenu1_Click);
            // 
            // btnMenu6
            // 
            this.btnMenu6.Font = new System.Drawing.Font("游ゴシック Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnMenu6.ForeColor = System.Drawing.Color.Red;
            this.btnMenu6.Image = global::FlockAppC.Properties.Resources.削除1_4p;
            this.btnMenu6.Location = new System.Drawing.Point(866, 560);
            this.btnMenu6.Margin = new System.Windows.Forms.Padding(4);
            this.btnMenu6.Name = "btnMenu6";
            this.btnMenu6.Size = new System.Drawing.Size(115, 35);
            this.btnMenu6.TabIndex = 125;
            this.btnMenu6.Text = "応募者削除";
            this.btnMenu6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMenu6.UseVisualStyleBackColor = true;
            this.btnMenu6.Click += new System.EventHandler(this.btnMenu6_Click);
            // 
            // btnMenu5
            // 
            this.btnMenu5.Font = new System.Drawing.Font("游ゴシック Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnMenu5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnMenu5.Image = global::FlockAppC.Properties.Resources.編集_小;
            this.btnMenu5.Location = new System.Drawing.Point(751, 560);
            this.btnMenu5.Margin = new System.Windows.Forms.Padding(4);
            this.btnMenu5.Name = "btnMenu5";
            this.btnMenu5.Size = new System.Drawing.Size(115, 35);
            this.btnMenu5.TabIndex = 124;
            this.btnMenu5.Text = "応募者編集";
            this.btnMenu5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMenu5.UseVisualStyleBackColor = true;
            this.btnMenu5.Click += new System.EventHandler(this.btnMenu5_Click);
            // 
            // btnMenu4
            // 
            this.btnMenu4.Font = new System.Drawing.Font("游ゴシック Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnMenu4.ForeColor = System.Drawing.Color.Blue;
            this.btnMenu4.Image = global::FlockAppC.Properties.Resources.追加_小小;
            this.btnMenu4.Location = new System.Drawing.Point(637, 560);
            this.btnMenu4.Margin = new System.Windows.Forms.Padding(4);
            this.btnMenu4.Name = "btnMenu4";
            this.btnMenu4.Size = new System.Drawing.Size(115, 35);
            this.btnMenu4.TabIndex = 123;
            this.btnMenu4.Text = "応募者追加";
            this.btnMenu4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMenu4.UseVisualStyleBackColor = true;
            this.btnMenu4.Click += new System.EventHandler(this.btnMenu4_Click);
            // 
            // btnMenu3
            // 
            this.btnMenu3.Font = new System.Drawing.Font("游ゴシック Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnMenu3.ForeColor = System.Drawing.Color.Red;
            this.btnMenu3.Image = global::FlockAppC.Properties.Resources.削除1_4p;
            this.btnMenu3.Location = new System.Drawing.Point(214, 560);
            this.btnMenu3.Margin = new System.Windows.Forms.Padding(4);
            this.btnMenu3.Name = "btnMenu3";
            this.btnMenu3.Size = new System.Drawing.Size(100, 35);
            this.btnMenu3.TabIndex = 122;
            this.btnMenu3.Text = "掲載削除";
            this.btnMenu3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMenu3.UseVisualStyleBackColor = true;
            this.btnMenu3.Click += new System.EventHandler(this.btnMenu3_Click);
            // 
            // btnMenu2
            // 
            this.btnMenu2.Font = new System.Drawing.Font("游ゴシック Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnMenu2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnMenu2.Image = global::FlockAppC.Properties.Resources.編集_小;
            this.btnMenu2.Location = new System.Drawing.Point(115, 560);
            this.btnMenu2.Margin = new System.Windows.Forms.Padding(4);
            this.btnMenu2.Name = "btnMenu2";
            this.btnMenu2.Size = new System.Drawing.Size(100, 35);
            this.btnMenu2.TabIndex = 121;
            this.btnMenu2.Text = "掲載編集";
            this.btnMenu2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMenu2.UseVisualStyleBackColor = true;
            this.btnMenu2.Click += new System.EventHandler(this.btnMenu2_Click);
            // 
            // frmRecruitMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 601);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnMenu10);
            this.Controls.Add(this.dgvApply);
            this.Controls.Add(this.dgvPublish);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.chkEnd);
            this.Controls.Add(this.btnMenu1);
            this.Controls.Add(this.btnMenu6);
            this.Controls.Add(this.btnMenu5);
            this.Controls.Add(this.btnMenu4);
            this.Controls.Add(this.btnMenu3);
            this.Controls.Add(this.btnMenu2);
            this.Controls.Add(this.Panel1);
            this.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmRecruitMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "求人掲載・応募者管理";
            this.Load += new System.EventHandler(this.frmRecruitMain_Load);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApply)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPublish)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Button btnMenu1;
        internal System.Windows.Forms.Button btnMenu6;
        internal System.Windows.Forms.Button btnMenu5;
        internal System.Windows.Forms.Button btnMenu4;
        internal System.Windows.Forms.Button btnMenu3;
        internal System.Windows.Forms.Button btnMenu2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.CheckBox chkEnd;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.DataGridView dgvApply;
        internal System.Windows.Forms.DataGridView dgvPublish;
        internal System.Windows.Forms.Button btnMenu10;
        internal System.Windows.Forms.Button button1;
    }
}