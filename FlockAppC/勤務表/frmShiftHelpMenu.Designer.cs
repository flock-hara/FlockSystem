namespace FlockAppC.勤務表
{
    partial class frmShiftHelpMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShiftHelpMenu));
            this.btnHelp6 = new System.Windows.Forms.Button();
            this.btnHelp5 = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnHelp4 = new System.Windows.Forms.Button();
            this.btnHelp3 = new System.Windows.Forms.Button();
            this.btnHelp2 = new System.Windows.Forms.Button();
            this.btnHelp1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnHelp6
            // 
            this.btnHelp6.Location = new System.Drawing.Point(25, 182);
            this.btnHelp6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnHelp6.Name = "btnHelp6";
            this.btnHelp6.Size = new System.Drawing.Size(230, 30);
            this.btnHelp6.TabIndex = 13;
            this.btnHelp6.Text = "PDF変換について";
            this.btnHelp6.UseVisualStyleBackColor = true;
            // 
            // btnHelp5
            // 
            this.btnHelp5.Location = new System.Drawing.Point(25, 222);
            this.btnHelp5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnHelp5.Name = "btnHelp5";
            this.btnHelp5.Size = new System.Drawing.Size(230, 30);
            this.btnHelp5.TabIndex = 12;
            this.btnHelp5.Text = "エラー発生時の対処";
            this.btnHelp5.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(25, 270);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(230, 30);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "閉じる";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnHelp4
            // 
            this.btnHelp4.Location = new System.Drawing.Point(25, 142);
            this.btnHelp4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnHelp4.Name = "btnHelp4";
            this.btnHelp4.Size = new System.Drawing.Size(230, 30);
            this.btnHelp4.TabIndex = 10;
            this.btnHelp4.Text = "勤務表の設定について";
            this.btnHelp4.UseVisualStyleBackColor = true;
            // 
            // btnHelp3
            // 
            this.btnHelp3.Location = new System.Drawing.Point(25, 102);
            this.btnHelp3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnHelp3.Name = "btnHelp3";
            this.btnHelp3.Size = new System.Drawing.Size(230, 30);
            this.btnHelp3.TabIndex = 9;
            this.btnHelp3.Text = "担当者の追加、削除について";
            this.btnHelp3.UseVisualStyleBackColor = true;
            // 
            // btnHelp2
            // 
            this.btnHelp2.Location = new System.Drawing.Point(25, 62);
            this.btnHelp2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnHelp2.Name = "btnHelp2";
            this.btnHelp2.Size = new System.Drawing.Size(230, 30);
            this.btnHelp2.TabIndex = 8;
            this.btnHelp2.Text = "変更予定の登録、承認について";
            this.btnHelp2.UseVisualStyleBackColor = true;
            // 
            // btnHelp1
            // 
            this.btnHelp1.Location = new System.Drawing.Point(25, 22);
            this.btnHelp1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnHelp1.Name = "btnHelp1";
            this.btnHelp1.Size = new System.Drawing.Size(230, 30);
            this.btnHelp1.TabIndex = 7;
            this.btnHelp1.Text = "勤務表メニューについて";
            this.btnHelp1.UseVisualStyleBackColor = true;
            this.btnHelp1.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmShiftHelpMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 317);
            this.Controls.Add(this.btnHelp6);
            this.Controls.Add(this.btnHelp5);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnHelp4);
            this.Controls.Add(this.btnHelp3);
            this.Controls.Add(this.btnHelp2);
            this.Controls.Add(this.btnHelp1);
            this.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmShiftHelpMenu";
            this.Text = "勤務表　操作説明";
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnHelp6;
        internal System.Windows.Forms.Button btnHelp5;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Button btnHelp4;
        internal System.Windows.Forms.Button btnHelp3;
        internal System.Windows.Forms.Button btnHelp2;
        internal System.Windows.Forms.Button btnHelp1;
    }
}