namespace FlockAppC.勤務表
{
    partial class frmScheduleComment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScheduleComment));
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.txtShiftEntry = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbBackColor = new System.Windows.Forms.ComboBox();
            this.cmbFontBold = new System.Windows.Forms.ComboBox();
            this.cmbFontColor = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbFontSize = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnMenu10 = new System.Windows.Forms.Button();
            this.btnReg = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpDate
            // 
            this.dtpDate.CalendarFont = new System.Drawing.Font("游ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpDate.CustomFormat = "yyyy/MM/dd dddd";
            this.dtpDate.Font = new System.Drawing.Font("メイリオ", 12F);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(21, 13);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(216, 31);
            this.dtpDate.TabIndex = 78;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // txtShiftEntry
            // 
            this.txtShiftEntry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtShiftEntry.Font = new System.Drawing.Font("メイリオ", 11.25F);
            this.txtShiftEntry.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtShiftEntry.Location = new System.Drawing.Point(12, 51);
            this.txtShiftEntry.Multiline = true;
            this.txtShiftEntry.Name = "txtShiftEntry";
            this.txtShiftEntry.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtShiftEntry.Size = new System.Drawing.Size(106, 76);
            this.txtShiftEntry.TabIndex = 79;
            this.txtShiftEntry.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cmbBackColor);
            this.groupBox1.Controls.Add(this.cmbFontBold);
            this.groupBox1.Controls.Add(this.cmbFontColor);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmbFontSize);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Font = new System.Drawing.Font("游ゴシック Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox1.Location = new System.Drawing.Point(122, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(119, 251);
            this.groupBox1.TabIndex = 90;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "フォント設定";
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label17.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label17.Location = new System.Drawing.Point(12, 179);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(93, 22);
            this.label17.TabIndex = 92;
            this.label17.Text = "背景色";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label16.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label16.Location = new System.Drawing.Point(12, 129);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(93, 22);
            this.label16.TabIndex = 91;
            this.label16.Text = "太字";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label15.Location = new System.Drawing.Point(12, 75);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(93, 22);
            this.label15.TabIndex = 90;
            this.label15.Text = "カラー";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label11.Location = new System.Drawing.Point(12, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 22);
            this.label11.TabIndex = 89;
            this.label11.Text = "サイズ";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbBackColor
            // 
            this.cmbBackColor.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbBackColor.FormattingEnabled = true;
            this.cmbBackColor.Location = new System.Drawing.Point(12, 200);
            this.cmbBackColor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbBackColor.Name = "cmbBackColor";
            this.cmbBackColor.Size = new System.Drawing.Size(93, 25);
            this.cmbBackColor.TabIndex = 18;
            this.cmbBackColor.SelectedIndexChanged += new System.EventHandler(this.cmbBackColor_SelectedIndexChanged);
            // 
            // cmbFontBold
            // 
            this.cmbFontBold.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbFontBold.FormattingEnabled = true;
            this.cmbFontBold.Location = new System.Drawing.Point(12, 150);
            this.cmbFontBold.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbFontBold.Name = "cmbFontBold";
            this.cmbFontBold.Size = new System.Drawing.Size(93, 25);
            this.cmbFontBold.TabIndex = 16;
            this.cmbFontBold.SelectedIndexChanged += new System.EventHandler(this.cmbFontBold_SelectedIndexChanged);
            // 
            // cmbFontColor
            // 
            this.cmbFontColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbFontColor.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbFontColor.FormattingEnabled = true;
            this.cmbFontColor.Location = new System.Drawing.Point(12, 96);
            this.cmbFontColor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbFontColor.Name = "cmbFontColor";
            this.cmbFontColor.Size = new System.Drawing.Size(93, 29);
            this.cmbFontColor.TabIndex = 14;
            this.cmbFontColor.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmbFontColor_DrawItem);
            this.cmbFontColor.SelectedIndexChanged += new System.EventHandler(this.cmbFontSize_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("游ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(13, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "フォントカラー";
            // 
            // cmbFontSize
            // 
            this.cmbFontSize.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbFontSize.FormattingEnabled = true;
            this.cmbFontSize.Location = new System.Drawing.Point(12, 46);
            this.cmbFontSize.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbFontSize.Name = "cmbFontSize";
            this.cmbFontSize.Size = new System.Drawing.Size(93, 25);
            this.cmbFontSize.TabIndex = 12;
            this.cmbFontSize.SelectedIndexChanged += new System.EventHandler(this.cmbFontSize_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("游ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(13, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "フォントサイズ";
            // 
            // btnMenu10
            // 
            this.btnMenu10.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnMenu10.Image = global::FlockAppC.Properties.Resources.閉じる_小小;
            this.btnMenu10.Location = new System.Drawing.Point(141, 312);
            this.btnMenu10.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMenu10.Name = "btnMenu10";
            this.btnMenu10.Size = new System.Drawing.Size(100, 40);
            this.btnMenu10.TabIndex = 91;
            this.btnMenu10.Text = "閉じる";
            this.btnMenu10.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMenu10.UseVisualStyleBackColor = true;
            this.btnMenu10.Click += new System.EventHandler(this.btnMenu10_Click);
            // 
            // btnReg
            // 
            this.btnReg.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnReg.Image = global::FlockAppC.Properties.Resources.HD_小小;
            this.btnReg.Location = new System.Drawing.Point(12, 312);
            this.btnReg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(100, 40);
            this.btnReg.TabIndex = 92;
            this.btnReg.Text = "登録";
            this.btnReg.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // frmScheduleComment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 362);
            this.Controls.Add(this.btnReg);
            this.Controls.Add(this.btnMenu10);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtShiftEntry);
            this.Controls.Add(this.dtpDate);
            this.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmScheduleComment";
            this.Text = "備考入力";
            this.Load += new System.EventHandler(this.frmScheduleComment_Load);
            this.Shown += new System.EventHandler(this.frmScheduleComment_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.DateTimePicker dtpDate;
        internal System.Windows.Forms.TextBox txtShiftEntry;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label11;
        internal System.Windows.Forms.ComboBox cmbBackColor;
        internal System.Windows.Forms.ComboBox cmbFontBold;
        internal System.Windows.Forms.ComboBox cmbFontColor;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.ComboBox cmbFontSize;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Button btnMenu10;
        internal System.Windows.Forms.Button btnReg;
    }
}