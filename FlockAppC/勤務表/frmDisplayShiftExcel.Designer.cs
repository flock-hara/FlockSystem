namespace FlockAppC.勤務表
{
    partial class frmDisplayShiftExcel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDisplayShiftExcel));
            this.Panel1 = new System.Windows.Forms.Panel();
            this.btnMenu1 = new System.Windows.Forms.Button();
            this.btnMenu10 = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel1.Controls.Add(this.btnMenu1);
            this.Panel1.Controls.Add(this.btnMenu10);
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(1047, 39);
            this.Panel1.TabIndex = 4;
            // 
            // btnMenu1
            // 
            this.btnMenu1.Font = new System.Drawing.Font("メイリオ", 9.75F);
            this.btnMenu1.Image = global::FlockAppC.Properties.Resources.エクセル_3_小小;
            this.btnMenu1.Location = new System.Drawing.Point(5, 1);
            this.btnMenu1.Name = "btnMenu1";
            this.btnMenu1.Size = new System.Drawing.Size(110, 35);
            this.btnMenu1.TabIndex = 15;
            this.btnMenu1.Text = "表示";
            this.btnMenu1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMenu1.UseVisualStyleBackColor = true;
            this.btnMenu1.Click += new System.EventHandler(this.btnMenu1_Click);
            // 
            // btnMenu10
            // 
            this.btnMenu10.Font = new System.Drawing.Font("メイリオ", 9.75F);
            this.btnMenu10.Image = global::FlockAppC.Properties.Resources.閉じる_小小;
            this.btnMenu10.Location = new System.Drawing.Point(939, 1);
            this.btnMenu10.Name = "btnMenu10";
            this.btnMenu10.Size = new System.Drawing.Size(100, 35);
            this.btnMenu10.TabIndex = 6;
            this.btnMenu10.Text = "閉じる";
            this.btnMenu10.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMenu10.UseVisualStyleBackColor = true;
            this.btnMenu10.Click += new System.EventHandler(this.btnMenu10_Click);
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(0, 41);
            this.dgv.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowTemplate.Height = 25;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1047, 105);
            this.dgv.TabIndex = 5;
            // 
            // frmDisplayShiftExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 150);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.Panel1);
            this.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDisplayShiftExcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "シフト表（エクセル）表示";
            this.Load += new System.EventHandler(this.frmDisplayShiftExcel_Load);
            this.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Button btnMenu1;
        internal System.Windows.Forms.Button btnMenu10;
        internal System.Windows.Forms.DataGridView dgv;
    }
}