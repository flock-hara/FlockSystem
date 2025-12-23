namespace FlockAppC.勤務表
{
    partial class frmShiftMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShiftMenu));
            this.lblMsg = new System.Windows.Forms.Label();
            this.btnMnuGuide = new System.Windows.Forms.Button();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Label1 = new System.Windows.Forms.Label();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnMnu02 = new System.Windows.Forms.Button();
            this.btnMnu04 = new System.Windows.Forms.Button();
            this.btnMnu08 = new System.Windows.Forms.Button();
            this.btnMnu01 = new System.Windows.Forms.Button();
            this.btnMnu05 = new System.Windows.Forms.Button();
            this.btnMnu06 = new System.Windows.Forms.Button();
            this.btnMnu07 = new System.Windows.Forms.Button();
            this.btnMnuClose = new System.Windows.Forms.Button();
            this.btnMnu03 = new System.Windows.Forms.Button();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(27, 316);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(392, 18);
            this.lblMsg.TabIndex = 28;
            this.lblMsg.Text = "勤務表ファイルが更新されています。インポートを実行してください。";
            this.lblMsg.Visible = false;
            // 
            // btnMnuGuide
            // 
            this.btnMnuGuide.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnMnuGuide.Location = new System.Drawing.Point(384, 1);
            this.btnMnuGuide.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMnuGuide.Name = "btnMnuGuide";
            this.btnMnuGuide.Size = new System.Drawing.Size(66, 37);
            this.btnMnuGuide.TabIndex = 31;
            this.btnMnuGuide.Text = "操作説明";
            this.btnMnuGuide.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMnuGuide.UseVisualStyleBackColor = true;
            this.btnMnuGuide.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Location = new System.Drawing.Point(44, 0);
            this.Panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(340, 38);
            this.Panel1.TabIndex = 29;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label1.Location = new System.Drawing.Point(126, 8);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(122, 24);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "勤務表メニュー";
            // 
            // PictureBox1
            // 
            this.PictureBox1.BackgroundImage = global::FlockAppC.Properties.Resources.flock_512x512;
            this.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PictureBox1.InitialImage = null;
            this.PictureBox1.Location = new System.Drawing.Point(1, 0);
            this.PictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(42, 38);
            this.PictureBox1.TabIndex = 30;
            this.PictureBox1.TabStop = false;
            // 
            // btnMnu02
            // 
            this.btnMnu02.Font = new System.Drawing.Font("メイリオ", 9.75F);
            this.btnMnu02.Image = global::FlockAppC.Properties.Resources.シフト２_１;
            this.btnMnu02.Location = new System.Drawing.Point(26, 112);
            this.btnMnu02.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMnu02.Name = "btnMnu02";
            this.btnMnu02.Size = new System.Drawing.Size(180, 45);
            this.btnMnu02.TabIndex = 27;
            this.btnMnu02.Text = "シフト変更履歴";
            this.btnMnu02.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMnu02.UseVisualStyleBackColor = true;
            this.btnMnu02.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnMnu04
            // 
            this.btnMnu04.Font = new System.Drawing.Font("メイリオ", 9.75F);
            this.btnMnu04.Image = global::FlockAppC.Properties.Resources.PDF_A_2;
            this.btnMnu04.Location = new System.Drawing.Point(25, 212);
            this.btnMnu04.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMnu04.Name = "btnMnu04";
            this.btnMnu04.Size = new System.Drawing.Size(180, 45);
            this.btnMnu04.TabIndex = 26;
            this.btnMnu04.Text = "PDF変換";
            this.btnMnu04.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMnu04.UseVisualStyleBackColor = true;
            this.btnMnu04.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnMnu08
            // 
            this.btnMnu08.Font = new System.Drawing.Font("メイリオ", 9.75F);
            this.btnMnu08.Image = global::FlockAppC.Properties.Resources.設定_小小小;
            this.btnMnu08.Location = new System.Drawing.Point(245, 161);
            this.btnMnu08.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMnu08.Name = "btnMnu08";
            this.btnMnu08.Size = new System.Drawing.Size(180, 45);
            this.btnMnu08.TabIndex = 25;
            this.btnMnu08.Text = "　設定";
            this.btnMnu08.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMnu08.UseVisualStyleBackColor = true;
            this.btnMnu08.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnMnu01
            // 
            this.btnMnu01.Font = new System.Drawing.Font("メイリオ", 9.75F);
            this.btnMnu01.Image = global::FlockAppC.Properties.Resources.シフト３_２;
            this.btnMnu01.Location = new System.Drawing.Point(25, 62);
            this.btnMnu01.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMnu01.Name = "btnMnu01";
            this.btnMnu01.Size = new System.Drawing.Size(180, 45);
            this.btnMnu01.TabIndex = 24;
            this.btnMnu01.Text = "シフト変更登録";
            this.btnMnu01.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMnu01.UseVisualStyleBackColor = true;
            this.btnMnu01.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnMnu05
            // 
            this.btnMnu05.Font = new System.Drawing.Font("メイリオ", 9.75F);
            this.btnMnu05.Image = global::FlockAppC.Properties.Resources.表_小;
            this.btnMnu05.Location = new System.Drawing.Point(25, 261);
            this.btnMnu05.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMnu05.Name = "btnMnu05";
            this.btnMnu05.Size = new System.Drawing.Size(180, 45);
            this.btnMnu05.TabIndex = 23;
            this.btnMnu05.Text = "勤務表表示Ⅱ";
            this.btnMnu05.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMnu05.UseVisualStyleBackColor = true;
            this.btnMnu05.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnMnu06
            // 
            this.btnMnu06.Font = new System.Drawing.Font("メイリオ", 9.75F);
            this.btnMnu06.Image = global::FlockAppC.Properties.Resources.連絡４_2;
            this.btnMnu06.Location = new System.Drawing.Point(245, 61);
            this.btnMnu06.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMnu06.Name = "btnMnu06";
            this.btnMnu06.Size = new System.Drawing.Size(180, 45);
            this.btnMnu06.TabIndex = 22;
            this.btnMnu06.Text = "定時連絡登録";
            this.btnMnu06.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMnu06.UseVisualStyleBackColor = true;
            this.btnMnu06.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnMnu07
            // 
            this.btnMnu07.Font = new System.Drawing.Font("メイリオ", 9.75F);
            this.btnMnu07.Image = global::FlockAppC.Properties.Resources.インポート小2;
            this.btnMnu07.Location = new System.Drawing.Point(245, 112);
            this.btnMnu07.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMnu07.Name = "btnMnu07";
            this.btnMnu07.Size = new System.Drawing.Size(180, 45);
            this.btnMnu07.TabIndex = 21;
            this.btnMnu07.Text = "勤務表取り込み";
            this.btnMnu07.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMnu07.UseVisualStyleBackColor = true;
            this.btnMnu07.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnMnuClose
            // 
            this.btnMnuClose.Font = new System.Drawing.Font("メイリオ", 9.75F);
            this.btnMnuClose.Image = global::FlockAppC.Properties.Resources.閉じる;
            this.btnMnuClose.Location = new System.Drawing.Point(245, 261);
            this.btnMnuClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMnuClose.Name = "btnMnuClose";
            this.btnMnuClose.Size = new System.Drawing.Size(180, 45);
            this.btnMnuClose.TabIndex = 20;
            this.btnMnuClose.Text = " 閉じる";
            this.btnMnuClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMnuClose.UseVisualStyleBackColor = true;
            this.btnMnuClose.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnMnu03
            // 
            this.btnMnu03.Font = new System.Drawing.Font("メイリオ", 9.75F);
            this.btnMnu03.Image = global::FlockAppC.Properties.Resources.エクセルA_１;
            this.btnMnu03.Location = new System.Drawing.Point(25, 161);
            this.btnMnu03.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMnu03.Name = "btnMnu03";
            this.btnMnu03.Size = new System.Drawing.Size(180, 45);
            this.btnMnu03.TabIndex = 19;
            this.btnMnu03.Text = "勤務表表示(ｴｸｾﾙ)";
            this.btnMnu03.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMnu03.UseVisualStyleBackColor = true;
            this.btnMnu03.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // frmShiftMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 340);
            this.Controls.Add(this.btnMnuGuide);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.btnMnu02);
            this.Controls.Add(this.btnMnu04);
            this.Controls.Add(this.btnMnu08);
            this.Controls.Add(this.btnMnu01);
            this.Controls.Add(this.btnMnu05);
            this.Controls.Add(this.btnMnu06);
            this.Controls.Add(this.btnMnu07);
            this.Controls.Add(this.btnMnuClose);
            this.Controls.Add(this.btnMnu03);
            this.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmShiftMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "勤務表メニュー";
            this.Load += new System.EventHandler(this.frmShiftMenu_Load);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnMnu02;
        internal System.Windows.Forms.Button btnMnu04;
        internal System.Windows.Forms.Button btnMnu08;
        internal System.Windows.Forms.Button btnMnu01;
        internal System.Windows.Forms.Button btnMnu05;
        internal System.Windows.Forms.Button btnMnu06;
        internal System.Windows.Forms.Button btnMnu07;
        internal System.Windows.Forms.Button btnMnuClose;
        internal System.Windows.Forms.Button btnMnu03;
        internal System.Windows.Forms.Label lblMsg;
        internal System.Windows.Forms.Button btnMnuGuide;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label Label1;
    }
}