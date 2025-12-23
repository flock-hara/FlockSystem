namespace FlockAppC.選択画面
{
    partial class frmSelectLocation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectLocation));
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblLocation = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.dgvSelect2 = new System.Windows.Forms.DataGridView();
            this.dgvSelect1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelect2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelect1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCheck
            // 
            this.btnCheck.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCheck.Image = global::FlockAppC.Properties.Resources.選択_小小小;
            this.btnCheck.Location = new System.Drawing.Point(12, 382);
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
            this.btnClose.Location = new System.Drawing.Point(650, 382);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 37);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "閉じる";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("游ゴシック Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblLocation.Location = new System.Drawing.Point(12, 52);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(47, 16);
            this.lblLocation.TabIndex = 9;
            this.lblLocation.Text = "label1";
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnBack.Location = new System.Drawing.Point(96, 382);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 37);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "戻る";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Visible = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // dgvSelect2
            // 
            this.dgvSelect2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelect2.Location = new System.Drawing.Point(12, 71);
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
            this.dgvSelect1.Location = new System.Drawing.Point(12, 9);
            this.dgvSelect1.Name = "dgvSelect1";
            this.dgvSelect1.RowTemplate.Height = 21;
            this.dgvSelect1.Size = new System.Drawing.Size(718, 36);
            this.dgvSelect1.TabIndex = 6;
            this.dgvSelect1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSelect1_CellClick);
            // 
            // frmSelectLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 427);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dgvSelect2);
            this.Controls.Add(this.dgvSelect1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSelectLocation";
            this.Text = "専従先選択";
            this.Load += new System.EventHandler(this.frmSelectLocation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelect2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelect1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridView dgvSelect2;
        private System.Windows.Forms.DataGridView dgvSelect1;
    }
}