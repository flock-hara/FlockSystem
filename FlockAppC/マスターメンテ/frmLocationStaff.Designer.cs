namespace FlockAppC.マスターメンテ
{
    partial class frmLocationStaff
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLocationStaff));
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.btnSelectLocation = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvInstructor = new System.Windows.Forms.DataGridView();
            this.btnSelectStaff = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnLocattionCarAdd = new System.Windows.Forms.Button();
            this.dgvLocationCar = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnLocationStaffAdd = new System.Windows.Forms.Button();
            this.dgvLocationStaff = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReg = new System.Windows.Forms.Button();
            this.btnMstStaff = new System.Windows.Forms.Button();
            this.btnMstLocationCar = new System.Windows.Forms.Button();
            this.lblConnect = new System.Windows.Forms.Label();
            this.Panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInstructor)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocationCar)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocationStaff)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Panel1.Controls.Add(this.Label4);
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(852, 37);
            this.Panel1.TabIndex = 120;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label4.Location = new System.Drawing.Point(12, 9);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(152, 20);
            this.Label4.TabIndex = 52;
            this.Label4.Text = "専従先車両・担当者設定";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblLocation);
            this.groupBox1.Controls.Add(this.btnSelectLocation);
            this.groupBox1.Font = new System.Drawing.Font("游ゴシック Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox1.Location = new System.Drawing.Point(26, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 64);
            this.groupBox1.TabIndex = 121;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "専従先";
            // 
            // lblLocation
            // 
            this.lblLocation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLocation.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblLocation.Location = new System.Drawing.Point(76, 24);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(264, 27);
            this.lblLocation.TabIndex = 91;
            this.lblLocation.Text = "9999";
            this.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSelectLocation
            // 
            this.btnSelectLocation.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSelectLocation.Location = new System.Drawing.Point(25, 23);
            this.btnSelectLocation.Name = "btnSelectLocation";
            this.btnSelectLocation.Size = new System.Drawing.Size(50, 28);
            this.btnSelectLocation.TabIndex = 90;
            this.btnSelectLocation.Text = "選択";
            this.btnSelectLocation.UseVisualStyleBackColor = true;
            this.btnSelectLocation.Click += new System.EventHandler(this.BtnSelectLocation_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvInstructor);
            this.groupBox2.Controls.Add(this.btnSelectStaff);
            this.groupBox2.Font = new System.Drawing.Font("游ゴシック Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox2.Location = new System.Drawing.Point(386, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(443, 88);
            this.groupBox2.TabIndex = 122;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "管理責任者・担当営業";
            // 
            // dgvInstructor
            // 
            this.dgvInstructor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInstructor.Location = new System.Drawing.Point(81, 24);
            this.dgvInstructor.Name = "dgvInstructor";
            this.dgvInstructor.RowTemplate.Height = 21;
            this.dgvInstructor.Size = new System.Drawing.Size(343, 48);
            this.dgvInstructor.TabIndex = 91;
            this.dgvInstructor.SelectionChanged += new System.EventHandler(this.DgvInstructor_SelectionChanged);
            // 
            // btnSelectStaff
            // 
            this.btnSelectStaff.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSelectStaff.Location = new System.Drawing.Point(25, 24);
            this.btnSelectStaff.Name = "btnSelectStaff";
            this.btnSelectStaff.Size = new System.Drawing.Size(50, 28);
            this.btnSelectStaff.TabIndex = 90;
            this.btnSelectStaff.Text = "変更";
            this.btnSelectStaff.UseVisualStyleBackColor = true;
            this.btnSelectStaff.Click += new System.EventHandler(this.BtnSelectStaff_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnLocattionCarAdd);
            this.groupBox3.Controls.Add(this.dgvLocationCar);
            this.groupBox3.Font = new System.Drawing.Font("游ゴシック Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox3.Location = new System.Drawing.Point(26, 147);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(304, 442);
            this.groupBox3.TabIndex = 123;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "登録車両";
            // 
            // btnLocattionCarAdd
            // 
            this.btnLocattionCarAdd.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnLocattionCarAdd.Location = new System.Drawing.Point(26, 406);
            this.btnLocattionCarAdd.Name = "btnLocattionCarAdd";
            this.btnLocattionCarAdd.Size = new System.Drawing.Size(50, 28);
            this.btnLocattionCarAdd.TabIndex = 92;
            this.btnLocattionCarAdd.Text = "追加";
            this.btnLocattionCarAdd.UseVisualStyleBackColor = true;
            this.btnLocattionCarAdd.Click += new System.EventHandler(this.BtnLocattionCarAdd_Click);
            // 
            // dgvLocationCar
            // 
            this.dgvLocationCar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocationCar.Location = new System.Drawing.Point(26, 32);
            this.dgvLocationCar.Name = "dgvLocationCar";
            this.dgvLocationCar.RowTemplate.Height = 21;
            this.dgvLocationCar.Size = new System.Drawing.Size(253, 366);
            this.dgvLocationCar.TabIndex = 91;
            this.dgvLocationCar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvLocationCar_CellClick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnLocationStaffAdd);
            this.groupBox4.Controls.Add(this.dgvLocationStaff);
            this.groupBox4.Font = new System.Drawing.Font("游ゴシック Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox4.Location = new System.Drawing.Point(336, 147);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(493, 442);
            this.groupBox4.TabIndex = 124;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "登録運転者";
            // 
            // btnLocationStaffAdd
            // 
            this.btnLocationStaffAdd.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnLocationStaffAdd.Location = new System.Drawing.Point(26, 406);
            this.btnLocationStaffAdd.Name = "btnLocationStaffAdd";
            this.btnLocationStaffAdd.Size = new System.Drawing.Size(50, 28);
            this.btnLocationStaffAdd.TabIndex = 93;
            this.btnLocationStaffAdd.Text = "追加";
            this.btnLocationStaffAdd.UseVisualStyleBackColor = true;
            this.btnLocationStaffAdd.Click += new System.EventHandler(this.BtnLocationStaffAdd_Click);
            // 
            // dgvLocationStaff
            // 
            this.dgvLocationStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocationStaff.Location = new System.Drawing.Point(26, 32);
            this.dgvLocationStaff.Name = "dgvLocationStaff";
            this.dgvLocationStaff.RowTemplate.Height = 21;
            this.dgvLocationStaff.Size = new System.Drawing.Size(448, 366);
            this.dgvLocationStaff.TabIndex = 91;
            this.dgvLocationStaff.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvLocationStaff_CellClick);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.Image = global::FlockAppC.Properties.Resources.閉じる_小小;
            this.btnClose.Location = new System.Drawing.Point(749, 595);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 37);
            this.btnClose.TabIndex = 125;
            this.btnClose.Text = "閉じる";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnReg
            // 
            this.btnReg.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnReg.Image = global::FlockAppC.Properties.Resources.FD_1_小小;
            this.btnReg.Location = new System.Drawing.Point(663, 595);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(80, 37);
            this.btnReg.TabIndex = 126;
            this.btnReg.Text = "保存";
            this.btnReg.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Visible = false;
            // 
            // btnMstStaff
            // 
            this.btnMstStaff.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnMstStaff.Image = global::FlockAppC.Properties.Resources.ダウンロード;
            this.btnMstStaff.Location = new System.Drawing.Point(336, 595);
            this.btnMstStaff.Name = "btnMstStaff";
            this.btnMstStaff.Size = new System.Drawing.Size(178, 37);
            this.btnMstStaff.TabIndex = 127;
            this.btnMstStaff.Text = "従業員マスタメンテ";
            this.btnMstStaff.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMstStaff.UseVisualStyleBackColor = true;
            this.btnMstStaff.Click += new System.EventHandler(this.BtnMstStaff_Click);
            // 
            // btnMstLocationCar
            // 
            this.btnMstLocationCar.Image = global::FlockAppC.Properties.Resources.ハイエース1小;
            this.btnMstLocationCar.Location = new System.Drawing.Point(26, 595);
            this.btnMstLocationCar.Name = "btnMstLocationCar";
            this.btnMstLocationCar.Size = new System.Drawing.Size(178, 37);
            this.btnMstLocationCar.TabIndex = 128;
            this.btnMstLocationCar.Text = "専従先車両マスタ";
            this.btnMstLocationCar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnMstLocationCar.UseVisualStyleBackColor = true;
            this.btnMstLocationCar.Click += new System.EventHandler(this.BtnMstLocationCar_Click);
            // 
            // lblConnect
            // 
            this.lblConnect.AutoSize = true;
            this.lblConnect.Font = new System.Drawing.Font("游ゴシック Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblConnect.ForeColor = System.Drawing.Color.Blue;
            this.lblConnect.Location = new System.Drawing.Point(520, 606);
            this.lblConnect.Name = "lblConnect";
            this.lblConnect.Size = new System.Drawing.Size(136, 16);
            this.lblConnect.TabIndex = 229;
            this.lblConnect.Text = "データベース接続中...";
            this.lblConnect.Visible = false;
            // 
            // frmLocationStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 639);
            this.Controls.Add(this.lblConnect);
            this.Controls.Add(this.btnMstLocationCar);
            this.Controls.Add(this.btnMstStaff);
            this.Controls.Add(this.btnReg);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Panel1);
            this.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmLocationStaff";
            this.Text = "専従先設定";
            this.Load += new System.EventHandler(this.FrmLocationStaff_Load);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInstructor)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocationCar)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocationStaff)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label Label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Button btnSelectLocation;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvInstructor;
        private System.Windows.Forms.Button btnSelectStaff;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvLocationCar;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvLocationStaff;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.Button btnLocattionCarAdd;
        private System.Windows.Forms.Button btnLocationStaffAdd;
        private System.Windows.Forms.Button btnMstStaff;
        internal System.Windows.Forms.Button btnMstLocationCar;
        private System.Windows.Forms.Label lblConnect;
    }
}