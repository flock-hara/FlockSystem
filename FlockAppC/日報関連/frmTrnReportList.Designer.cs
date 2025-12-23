namespace FlockAppC.Report
{
    partial class frmTrnReportList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTrnReportList));
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSelectLocation = new System.Windows.Forms.Button();
            this.lblLocationName = new System.Windows.Forms.Label();
            this.btnSelectCar = new System.Windows.Forms.Button();
            this.lblCarNo = new System.Windows.Forms.Label();
            this.btnSelectStaff = new System.Windows.Forms.Button();
            this.lblStaffName = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCsv = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDisplay = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdo2 = new System.Windows.Forms.RadioButton();
            this.rdo1 = new System.Windows.Forms.RadioButton();
            this.lblFromToDay = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbClosingDate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpYM = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.dtpDate2 = new System.Windows.Forms.DateTimePicker();
            this.dtpDate1 = new System.Windows.Forms.DateTimePicker();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkConfirm1_2 = new System.Windows.Forms.CheckBox();
            this.chkConfirm1_1 = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkConfirm2_2 = new System.Windows.Forms.CheckBox();
            this.chkConfirm2_1 = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkConfirm3_2 = new System.Windows.Forms.CheckBox();
            this.chkConfirm3_1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvList
            // 
            this.dgvList.ColumnHeadersHeight = 20;
            this.dgvList.Location = new System.Drawing.Point(12, 141);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowTemplate.Height = 21;
            this.dgvList.Size = new System.Drawing.Size(1665, 565);
            this.dgvList.TabIndex = 53;
            this.dgvList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("游ゴシック Medium", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.Location = new System.Drawing.Point(4, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(233, 19);
            this.label8.TabIndex = 0;
            this.label8.Text = "Web日報　日報入力データ一覧";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1689, 30);
            this.panel1.TabIndex = 54;
            // 
            // btnSelectLocation
            // 
            this.btnSelectLocation.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSelectLocation.Location = new System.Drawing.Point(580, 44);
            this.btnSelectLocation.Name = "btnSelectLocation";
            this.btnSelectLocation.Size = new System.Drawing.Size(100, 28);
            this.btnSelectLocation.TabIndex = 206;
            this.btnSelectLocation.Text = "専従先選択";
            this.btnSelectLocation.UseVisualStyleBackColor = true;
            this.btnSelectLocation.Click += new System.EventHandler(this.btnSelectLocation_Click);
            // 
            // lblLocationName
            // 
            this.lblLocationName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLocationName.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblLocationName.Location = new System.Drawing.Point(683, 46);
            this.lblLocationName.Name = "lblLocationName";
            this.lblLocationName.Size = new System.Drawing.Size(255, 27);
            this.lblLocationName.TabIndex = 207;
            this.lblLocationName.Text = "9999";
            this.lblLocationName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSelectCar
            // 
            this.btnSelectCar.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSelectCar.Location = new System.Drawing.Point(953, 44);
            this.btnSelectCar.Name = "btnSelectCar";
            this.btnSelectCar.Size = new System.Drawing.Size(100, 28);
            this.btnSelectCar.TabIndex = 212;
            this.btnSelectCar.Text = "車両選択";
            this.btnSelectCar.UseVisualStyleBackColor = true;
            this.btnSelectCar.Click += new System.EventHandler(this.btnSelectCar_Click);
            // 
            // lblCarNo
            // 
            this.lblCarNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCarNo.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCarNo.Location = new System.Drawing.Point(1055, 46);
            this.lblCarNo.Name = "lblCarNo";
            this.lblCarNo.Size = new System.Drawing.Size(139, 27);
            this.lblCarNo.TabIndex = 213;
            this.lblCarNo.Text = "9999";
            this.lblCarNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSelectStaff
            // 
            this.btnSelectStaff.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSelectStaff.Location = new System.Drawing.Point(1207, 44);
            this.btnSelectStaff.Name = "btnSelectStaff";
            this.btnSelectStaff.Size = new System.Drawing.Size(100, 28);
            this.btnSelectStaff.TabIndex = 214;
            this.btnSelectStaff.Text = "担当者選択";
            this.btnSelectStaff.UseVisualStyleBackColor = true;
            this.btnSelectStaff.Click += new System.EventHandler(this.btnSelectStaff_Click);
            // 
            // lblStaffName
            // 
            this.lblStaffName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStaffName.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblStaffName.Location = new System.Drawing.Point(1309, 45);
            this.lblStaffName.Name = "lblStaffName";
            this.lblStaffName.Size = new System.Drawing.Size(90, 27);
            this.lblStaffName.TabIndex = 215;
            this.lblStaffName.Text = "9999";
            this.lblStaffName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClear.Location = new System.Drawing.Point(1419, 45);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 28);
            this.btnClear.TabIndex = 216;
            this.btnClear.Text = "条件クリア";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCsv
            // 
            this.btnCsv.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCsv.Image = global::FlockAppC.Properties.Resources.CSV_1;
            this.btnCsv.Location = new System.Drawing.Point(12, 715);
            this.btnCsv.Name = "btnCsv";
            this.btnCsv.Size = new System.Drawing.Size(100, 37);
            this.btnCsv.TabIndex = 221;
            this.btnCsv.Text = "CSV出力";
            this.btnCsv.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCsv.UseVisualStyleBackColor = true;
            this.btnCsv.Click += new System.EventHandler(this.btnCsv_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.Image = global::FlockAppC.Properties.Resources.閉じる_小小;
            this.btnClose.Location = new System.Drawing.Point(1597, 715);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 37);
            this.btnClose.TabIndex = 220;
            this.btnClose.Text = "閉じる";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // btnDisplay
            // 
            this.btnDisplay.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnDisplay.Image = global::FlockAppC.Properties.Resources.検索_小1;
            this.btnDisplay.Location = new System.Drawing.Point(1597, 45);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(80, 37);
            this.btnDisplay.TabIndex = 203;
            this.btnDisplay.Text = "表示";
            this.btnDisplay.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnDisplay.UseVisualStyleBackColor = true;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdo2);
            this.groupBox1.Controls.Add(this.rdo1);
            this.groupBox1.Controls.Add(this.lblFromToDay);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbClosingDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpYM);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.Label10);
            this.groupBox1.Controls.Add(this.dtpDate2);
            this.groupBox1.Controls.Add(this.dtpDate1);
            this.groupBox1.Location = new System.Drawing.Point(12, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(561, 99);
            this.groupBox1.TabIndex = 227;
            this.groupBox1.TabStop = false;
            // 
            // rdo2
            // 
            this.rdo2.AutoSize = true;
            this.rdo2.Location = new System.Drawing.Point(13, 66);
            this.rdo2.Name = "rdo2";
            this.rdo2.Size = new System.Drawing.Size(14, 13);
            this.rdo2.TabIndex = 237;
            this.rdo2.TabStop = true;
            this.rdo2.UseVisualStyleBackColor = true;
            this.rdo2.CheckedChanged += new System.EventHandler(this.rdo2_CheckedChanged);
            // 
            // rdo1
            // 
            this.rdo1.AutoSize = true;
            this.rdo1.Location = new System.Drawing.Point(13, 32);
            this.rdo1.Name = "rdo1";
            this.rdo1.Size = new System.Drawing.Size(14, 13);
            this.rdo1.TabIndex = 236;
            this.rdo1.TabStop = true;
            this.rdo1.UseVisualStyleBackColor = true;
            this.rdo1.CheckedChanged += new System.EventHandler(this.rdo1_CheckedChanged);
            // 
            // lblFromToDay
            // 
            this.lblFromToDay.AutoSize = true;
            this.lblFromToDay.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblFromToDay.Location = new System.Drawing.Point(383, 29);
            this.lblFromToDay.Name = "lblFromToDay";
            this.lblFromToDay.Size = new System.Drawing.Size(82, 17);
            this.lblFromToDay.TabIndex = 235;
            this.lblFromToDay.Text = "yyyy/mm/dd";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(240, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 234;
            this.label2.Text = "締め日";
            // 
            // cmbClosingDate
            // 
            this.cmbClosingDate.FormattingEnabled = true;
            this.cmbClosingDate.Location = new System.Drawing.Point(298, 25);
            this.cmbClosingDate.Name = "cmbClosingDate";
            this.cmbClosingDate.Size = new System.Drawing.Size(64, 25);
            this.cmbClosingDate.TabIndex = 233;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(31, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 232;
            this.label1.Text = "対象年月";
            // 
            // dtpYM
            // 
            this.dtpYM.CalendarFont = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpYM.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpYM.Location = new System.Drawing.Point(115, 21);
            this.dtpYM.Name = "dtpYM";
            this.dtpYM.Size = new System.Drawing.Size(160, 32);
            this.dtpYM.TabIndex = 231;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(31, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 20);
            this.label6.TabIndex = 230;
            this.label6.Text = "範囲指定";
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Font = new System.Drawing.Font("メイリオ", 9F);
            this.Label10.Location = new System.Drawing.Point(277, 65);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(20, 18);
            this.Label10.TabIndex = 229;
            this.Label10.Text = "～";
            // 
            // dtpDate2
            // 
            this.dtpDate2.CalendarFont = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpDate2.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpDate2.Location = new System.Drawing.Point(298, 56);
            this.dtpDate2.Name = "dtpDate2";
            this.dtpDate2.Size = new System.Drawing.Size(160, 32);
            this.dtpDate2.TabIndex = 228;
            // 
            // dtpDate1
            // 
            this.dtpDate1.CalendarFont = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpDate1.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpDate1.Location = new System.Drawing.Point(114, 56);
            this.dtpDate1.Name = "dtpDate1";
            this.dtpDate1.Size = new System.Drawing.Size(160, 32);
            this.dtpDate1.TabIndex = 227;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnConfirm.Image = global::FlockAppC.Properties.Resources.承認5_小;
            this.btnConfirm.Location = new System.Drawing.Point(166, 715);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(140, 37);
            this.btnConfirm.TabIndex = 228;
            this.btnConfirm.Text = "日報一括確認";
            this.btnConfirm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkConfirm1_2);
            this.groupBox2.Controls.Add(this.chkConfirm1_1);
            this.groupBox2.Location = new System.Drawing.Point(591, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(171, 56);
            this.groupBox2.TabIndex = 229;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "社内チェック";
            // 
            // chkConfirm1_2
            // 
            this.chkConfirm1_2.AutoSize = true;
            this.chkConfirm1_2.Location = new System.Drawing.Point(90, 23);
            this.chkConfirm1_2.Name = "chkConfirm1_2";
            this.chkConfirm1_2.Size = new System.Drawing.Size(66, 21);
            this.chkConfirm1_2.TabIndex = 1;
            this.chkConfirm1_2.Text = "実施済";
            this.chkConfirm1_2.UseVisualStyleBackColor = true;
            // 
            // chkConfirm1_1
            // 
            this.chkConfirm1_1.AutoSize = true;
            this.chkConfirm1_1.Location = new System.Drawing.Point(18, 23);
            this.chkConfirm1_1.Name = "chkConfirm1_1";
            this.chkConfirm1_1.Size = new System.Drawing.Size(66, 21);
            this.chkConfirm1_1.TabIndex = 0;
            this.chkConfirm1_1.Text = "未実施";
            this.chkConfirm1_1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkConfirm2_2);
            this.groupBox3.Controls.Add(this.chkConfirm2_1);
            this.groupBox3.Location = new System.Drawing.Point(772, 79);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(171, 56);
            this.groupBox3.TabIndex = 230;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "管理責任者確認";
            // 
            // chkConfirm2_2
            // 
            this.chkConfirm2_2.AutoSize = true;
            this.chkConfirm2_2.Location = new System.Drawing.Point(90, 23);
            this.chkConfirm2_2.Name = "chkConfirm2_2";
            this.chkConfirm2_2.Size = new System.Drawing.Size(66, 21);
            this.chkConfirm2_2.TabIndex = 1;
            this.chkConfirm2_2.Text = "確認済";
            this.chkConfirm2_2.UseVisualStyleBackColor = true;
            // 
            // chkConfirm2_1
            // 
            this.chkConfirm2_1.AutoSize = true;
            this.chkConfirm2_1.Location = new System.Drawing.Point(18, 23);
            this.chkConfirm2_1.Name = "chkConfirm2_1";
            this.chkConfirm2_1.Size = new System.Drawing.Size(66, 21);
            this.chkConfirm2_1.TabIndex = 0;
            this.chkConfirm2_1.Text = "未確認";
            this.chkConfirm2_1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkConfirm3_2);
            this.groupBox4.Controls.Add(this.chkConfirm3_1);
            this.groupBox4.Location = new System.Drawing.Point(953, 79);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(171, 56);
            this.groupBox4.TabIndex = 231;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "お客様確認";
            // 
            // chkConfirm3_2
            // 
            this.chkConfirm3_2.AutoSize = true;
            this.chkConfirm3_2.Location = new System.Drawing.Point(90, 23);
            this.chkConfirm3_2.Name = "chkConfirm3_2";
            this.chkConfirm3_2.Size = new System.Drawing.Size(66, 21);
            this.chkConfirm3_2.TabIndex = 1;
            this.chkConfirm3_2.Text = "確認済";
            this.chkConfirm3_2.UseVisualStyleBackColor = true;
            // 
            // chkConfirm3_1
            // 
            this.chkConfirm3_1.AutoSize = true;
            this.chkConfirm3_1.Location = new System.Drawing.Point(18, 23);
            this.chkConfirm3_1.Name = "chkConfirm3_1";
            this.chkConfirm3_1.Size = new System.Drawing.Size(66, 21);
            this.chkConfirm3_1.TabIndex = 0;
            this.chkConfirm3_1.Text = "未確認";
            this.chkConfirm3_1.UseVisualStyleBackColor = true;
            // 
            // frmTrnReportList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1689, 761);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCsv);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblStaffName);
            this.Controls.Add(this.btnSelectStaff);
            this.Controls.Add(this.lblCarNo);
            this.Controls.Add(this.btnSelectCar);
            this.Controls.Add(this.lblLocationName);
            this.Controls.Add(this.btnSelectLocation);
            this.Controls.Add(this.btnDisplay);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvList);
            this.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmTrnReportList";
            this.Text = "日報入力一覧";
            this.Load += new System.EventHandler(this.frmTrnReportList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Button btnDisplay;
        private System.Windows.Forms.Button btnSelectLocation;
        private System.Windows.Forms.Label lblLocationName;
        private System.Windows.Forms.Button btnSelectCar;
        private System.Windows.Forms.Label lblCarNo;
        private System.Windows.Forms.Button btnSelectStaff;
        private System.Windows.Forms.Label lblStaffName;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCsv;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdo2;
        private System.Windows.Forms.RadioButton rdo1;
        internal System.Windows.Forms.Label lblFromToDay;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbClosingDate;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.DateTimePicker dtpYM;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.DateTimePicker dtpDate2;
        internal System.Windows.Forms.DateTimePicker dtpDate1;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkConfirm1_2;
        private System.Windows.Forms.CheckBox chkConfirm1_1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkConfirm2_2;
        private System.Windows.Forms.CheckBox chkConfirm2_1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkConfirm3_2;
        private System.Windows.Forms.CheckBox chkConfirm3_1;
    }
}