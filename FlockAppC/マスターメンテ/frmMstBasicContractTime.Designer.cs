namespace FlockAppC.マスターメンテ
{
    partial class frmMstBasicContractTime
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMstBasicContractTime));
            this.Panel1 = new System.Windows.Forms.Panel();
            this.lblNew = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.dgvContractList = new System.Windows.Forms.DataGridView();
            this.btnClearLocation = new System.Windows.Forms.Button();
            this.lblLocation = new System.Windows.Forms.Label();
            this.btnSelectLocation = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.gbox1 = new System.Windows.Forms.GroupBox();
            this.rdoKbn2 = new System.Windows.Forms.RadioButton();
            this.rdoKbn1 = new System.Windows.Forms.RadioButton();
            this.txtLocationComment = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gbox2 = new System.Windows.Forms.GroupBox();
            this.chkSun = new System.Windows.Forms.CheckBox();
            this.chkSat = new System.Windows.Forms.CheckBox();
            this.chkFri = new System.Windows.Forms.CheckBox();
            this.chkThu = new System.Windows.Forms.CheckBox();
            this.chkWed = new System.Windows.Forms.CheckBox();
            this.chkTue = new System.Windows.Forms.CheckBox();
            this.chkMon = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpStart_Time1 = new System.Windows.Forms.DateTimePicker();
            this.dtpStart_Time2 = new System.Windows.Forms.DateTimePicker();
            this.dtpStart_Time3 = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd_Time3 = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd_Time2 = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd_Time1 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtWork_Time = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dtpEnd_Break_Time = new System.Windows.Forms.DateTimePicker();
            this.dtpStart_Break_Time = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtBreak_Time = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnReg = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.dgvCarList = new System.Windows.Forms.DataGridView();
            this.lblCarNo = new System.Windows.Forms.Label();
            this.lblCarIdent = new System.Windows.Forms.Label();
            this.lblCarName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSort = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.btnPast = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.lblConnect = new System.Windows.Forms.Label();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContractList)).BeginInit();
            this.gbox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarList)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Panel1.Controls.Add(this.lblNew);
            this.Panel1.Controls.Add(this.Label4);
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(1482, 37);
            this.Panel1.TabIndex = 79;
            // 
            // lblNew
            // 
            this.lblNew.BackColor = System.Drawing.Color.IndianRed;
            this.lblNew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNew.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblNew.Location = new System.Drawing.Point(1392, 4);
            this.lblNew.Name = "lblNew";
            this.lblNew.Size = new System.Drawing.Size(86, 30);
            this.lblNew.TabIndex = 129;
            this.lblNew.Text = "　新規　";
            this.lblNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label4.Location = new System.Drawing.Point(12, 10);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(87, 20);
            this.Label4.TabIndex = 52;
            this.Label4.Text = "基本契約時間";
            // 
            // dgvContractList
            // 
            this.dgvContractList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContractList.Location = new System.Drawing.Point(198, 227);
            this.dgvContractList.Name = "dgvContractList";
            this.dgvContractList.RowTemplate.Height = 21;
            this.dgvContractList.Size = new System.Drawing.Size(1273, 446);
            this.dgvContractList.TabIndex = 80;
            this.dgvContractList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvContractList_CellClick);
            // 
            // btnClearLocation
            // 
            this.btnClearLocation.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClearLocation.Location = new System.Drawing.Point(357, 28);
            this.btnClearLocation.Name = "btnClearLocation";
            this.btnClearLocation.Size = new System.Drawing.Size(40, 28);
            this.btnClearLocation.TabIndex = 131;
            this.btnClearLocation.Text = "ｸﾘｱ";
            this.btnClearLocation.UseVisualStyleBackColor = true;
            this.btnClearLocation.Click += new System.EventHandler(this.BtnClearLocation_Click);
            // 
            // lblLocation
            // 
            this.lblLocation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLocation.Font = new System.Drawing.Font("游ゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblLocation.Location = new System.Drawing.Point(119, 28);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(232, 27);
            this.lblLocation.TabIndex = 130;
            this.lblLocation.Text = "9999";
            this.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSelectLocation
            // 
            this.btnSelectLocation.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSelectLocation.Location = new System.Drawing.Point(68, 27);
            this.btnSelectLocation.Name = "btnSelectLocation";
            this.btnSelectLocation.Size = new System.Drawing.Size(50, 28);
            this.btnSelectLocation.TabIndex = 10;
            this.btnSelectLocation.Text = "選択";
            this.btnSelectLocation.UseVisualStyleBackColor = true;
            this.btnSelectLocation.Click += new System.EventHandler(this.BtnSelectLocation_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(21, 33);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(47, 17);
            this.label26.TabIndex = 128;
            this.label26.Text = "専従先";
            // 
            // gbox1
            // 
            this.gbox1.Controls.Add(this.rdoKbn2);
            this.gbox1.Controls.Add(this.rdoKbn1);
            this.gbox1.Location = new System.Drawing.Point(443, 100);
            this.gbox1.Name = "gbox1";
            this.gbox1.Size = new System.Drawing.Size(268, 48);
            this.gbox1.TabIndex = 12;
            this.gbox1.TabStop = false;
            // 
            // rdoKbn2
            // 
            this.rdoKbn2.AutoSize = true;
            this.rdoKbn2.Enabled = false;
            this.rdoKbn2.Location = new System.Drawing.Point(105, 18);
            this.rdoKbn2.Name = "rdoKbn2";
            this.rdoKbn2.Size = new System.Drawing.Size(129, 21);
            this.rdoKbn2.TabIndex = 1;
            this.rdoKbn2.TabStop = true;
            this.rdoKbn2.Text = "バス・デイ・配送";
            this.rdoKbn2.UseVisualStyleBackColor = true;
            // 
            // rdoKbn1
            // 
            this.rdoKbn1.AutoSize = true;
            this.rdoKbn1.Enabled = false;
            this.rdoKbn1.Location = new System.Drawing.Point(32, 18);
            this.rdoKbn1.Name = "rdoKbn1";
            this.rdoKbn1.Size = new System.Drawing.Size(52, 21);
            this.rdoKbn1.TabIndex = 0;
            this.rdoKbn1.TabStop = true;
            this.rdoKbn1.Text = "透析";
            this.rdoKbn1.UseVisualStyleBackColor = true;
            // 
            // txtLocationComment
            // 
            this.txtLocationComment.Font = new System.Drawing.Font("游ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtLocationComment.Location = new System.Drawing.Point(119, 69);
            this.txtLocationComment.Multiline = true;
            this.txtLocationComment.Name = "txtLocationComment";
            this.txtLocationComment.Size = new System.Drawing.Size(278, 92);
            this.txtLocationComment.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 17);
            this.label1.TabIndex = 135;
            this.label1.Text = "補足";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSelectLocation);
            this.groupBox2.Controls.Add(this.txtLocationComment);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.lblLocation);
            this.groupBox2.Controls.Add(this.btnClearLocation);
            this.groupBox2.Location = new System.Drawing.Point(12, 43);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(421, 178);
            this.groupBox2.TabIndex = 136;
            this.groupBox2.TabStop = false;
            // 
            // gbox2
            // 
            this.gbox2.Controls.Add(this.chkSun);
            this.gbox2.Controls.Add(this.chkSat);
            this.gbox2.Controls.Add(this.chkFri);
            this.gbox2.Controls.Add(this.chkThu);
            this.gbox2.Controls.Add(this.chkWed);
            this.gbox2.Controls.Add(this.chkTue);
            this.gbox2.Controls.Add(this.chkMon);
            this.gbox2.Location = new System.Drawing.Point(443, 145);
            this.gbox2.Name = "gbox2";
            this.gbox2.Size = new System.Drawing.Size(268, 50);
            this.gbox2.TabIndex = 13;
            this.gbox2.TabStop = false;
            // 
            // chkSun
            // 
            this.chkSun.AutoSize = true;
            this.chkSun.Font = new System.Drawing.Font("游ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chkSun.Location = new System.Drawing.Point(227, 19);
            this.chkSun.Name = "chkSun";
            this.chkSun.Size = new System.Drawing.Size(38, 20);
            this.chkSun.TabIndex = 6;
            this.chkSun.Text = "日";
            this.chkSun.UseVisualStyleBackColor = true;
            // 
            // chkSat
            // 
            this.chkSat.AutoSize = true;
            this.chkSat.Font = new System.Drawing.Font("游ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chkSat.Location = new System.Drawing.Point(189, 19);
            this.chkSat.Name = "chkSat";
            this.chkSat.Size = new System.Drawing.Size(38, 20);
            this.chkSat.TabIndex = 5;
            this.chkSat.Text = "土";
            this.chkSat.UseVisualStyleBackColor = true;
            // 
            // chkFri
            // 
            this.chkFri.AutoSize = true;
            this.chkFri.Font = new System.Drawing.Font("游ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chkFri.Location = new System.Drawing.Point(153, 19);
            this.chkFri.Name = "chkFri";
            this.chkFri.Size = new System.Drawing.Size(38, 20);
            this.chkFri.TabIndex = 4;
            this.chkFri.Text = "金";
            this.chkFri.UseVisualStyleBackColor = true;
            // 
            // chkThu
            // 
            this.chkThu.AutoSize = true;
            this.chkThu.Font = new System.Drawing.Font("游ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chkThu.Location = new System.Drawing.Point(114, 19);
            this.chkThu.Name = "chkThu";
            this.chkThu.Size = new System.Drawing.Size(38, 20);
            this.chkThu.TabIndex = 3;
            this.chkThu.Text = "木";
            this.chkThu.UseVisualStyleBackColor = true;
            // 
            // chkWed
            // 
            this.chkWed.AutoSize = true;
            this.chkWed.Font = new System.Drawing.Font("游ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chkWed.Location = new System.Drawing.Point(78, 19);
            this.chkWed.Name = "chkWed";
            this.chkWed.Size = new System.Drawing.Size(38, 20);
            this.chkWed.TabIndex = 2;
            this.chkWed.Text = "水";
            this.chkWed.UseVisualStyleBackColor = true;
            // 
            // chkTue
            // 
            this.chkTue.AutoSize = true;
            this.chkTue.Font = new System.Drawing.Font("游ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chkTue.Location = new System.Drawing.Point(41, 19);
            this.chkTue.Name = "chkTue";
            this.chkTue.Size = new System.Drawing.Size(38, 20);
            this.chkTue.TabIndex = 1;
            this.chkTue.Text = "火";
            this.chkTue.UseVisualStyleBackColor = true;
            // 
            // chkMon
            // 
            this.chkMon.AutoSize = true;
            this.chkMon.Font = new System.Drawing.Font("游ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chkMon.Location = new System.Drawing.Point(6, 19);
            this.chkMon.Name = "chkMon";
            this.chkMon.Size = new System.Drawing.Size(38, 20);
            this.chkMon.TabIndex = 0;
            this.chkMon.Text = "月";
            this.chkMon.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(720, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 17);
            this.label3.TabIndex = 140;
            this.label3.Text = "1走目";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(720, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 17);
            this.label5.TabIndex = 141;
            this.label5.Text = "2走目";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(720, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 17);
            this.label6.TabIndex = 142;
            this.label6.Text = "3走目";
            // 
            // dtpStart_Time1
            // 
            this.dtpStart_Time1.CalendarFont = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpStart_Time1.CustomFormat = "HH:mm";
            this.dtpStart_Time1.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpStart_Time1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart_Time1.Location = new System.Drawing.Point(764, 107);
            this.dtpStart_Time1.Name = "dtpStart_Time1";
            this.dtpStart_Time1.ShowUpDown = true;
            this.dtpStart_Time1.Size = new System.Drawing.Size(70, 28);
            this.dtpStart_Time1.TabIndex = 14;
            // 
            // dtpStart_Time2
            // 
            this.dtpStart_Time2.CalendarFont = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpStart_Time2.CustomFormat = "HH:mm";
            this.dtpStart_Time2.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpStart_Time2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart_Time2.Location = new System.Drawing.Point(764, 137);
            this.dtpStart_Time2.Name = "dtpStart_Time2";
            this.dtpStart_Time2.ShowUpDown = true;
            this.dtpStart_Time2.Size = new System.Drawing.Size(70, 28);
            this.dtpStart_Time2.TabIndex = 16;
            // 
            // dtpStart_Time3
            // 
            this.dtpStart_Time3.CalendarFont = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpStart_Time3.CustomFormat = "HH:mm";
            this.dtpStart_Time3.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpStart_Time3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart_Time3.Location = new System.Drawing.Point(764, 167);
            this.dtpStart_Time3.Name = "dtpStart_Time3";
            this.dtpStart_Time3.ShowUpDown = true;
            this.dtpStart_Time3.Size = new System.Drawing.Size(70, 28);
            this.dtpStart_Time3.TabIndex = 18;
            // 
            // dtpEnd_Time3
            // 
            this.dtpEnd_Time3.CalendarFont = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpEnd_Time3.CustomFormat = "HH:mm";
            this.dtpEnd_Time3.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpEnd_Time3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd_Time3.Location = new System.Drawing.Point(844, 167);
            this.dtpEnd_Time3.Name = "dtpEnd_Time3";
            this.dtpEnd_Time3.ShowUpDown = true;
            this.dtpEnd_Time3.Size = new System.Drawing.Size(70, 28);
            this.dtpEnd_Time3.TabIndex = 19;
            // 
            // dtpEnd_Time2
            // 
            this.dtpEnd_Time2.CalendarFont = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpEnd_Time2.CustomFormat = "HH:mm";
            this.dtpEnd_Time2.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpEnd_Time2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd_Time2.Location = new System.Drawing.Point(844, 137);
            this.dtpEnd_Time2.Name = "dtpEnd_Time2";
            this.dtpEnd_Time2.ShowUpDown = true;
            this.dtpEnd_Time2.Size = new System.Drawing.Size(70, 28);
            this.dtpEnd_Time2.TabIndex = 17;
            // 
            // dtpEnd_Time1
            // 
            this.dtpEnd_Time1.CalendarFont = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpEnd_Time1.CustomFormat = "HH:mm";
            this.dtpEnd_Time1.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpEnd_Time1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd_Time1.Location = new System.Drawing.Point(844, 107);
            this.dtpEnd_Time1.Name = "dtpEnd_Time1";
            this.dtpEnd_Time1.ShowUpDown = true;
            this.dtpEnd_Time1.Size = new System.Drawing.Size(70, 28);
            this.dtpEnd_Time1.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(777, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 17);
            this.label7.TabIndex = 197;
            this.label7.Text = "開始";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(857, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 17);
            this.label8.TabIndex = 198;
            this.label8.Text = "終了";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(922, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 17);
            this.label9.TabIndex = 199;
            this.label9.Text = "実稼働時間";
            // 
            // txtWork_Time
            // 
            this.txtWork_Time.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtWork_Time.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtWork_Time.Location = new System.Drawing.Point(997, 79);
            this.txtWork_Time.Name = "txtWork_Time";
            this.txtWork_Time.Size = new System.Drawing.Size(57, 28);
            this.txtWork_Time.TabIndex = 20;
            this.txtWork_Time.Text = "99";
            this.txtWork_Time.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1057, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 17);
            this.label10.TabIndex = 201;
            this.label10.Text = "h";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1371, 59);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 17);
            this.label11.TabIndex = 206;
            this.label11.Text = "終了";
            this.label11.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1291, 58);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 17);
            this.label12.TabIndex = 205;
            this.label12.Text = "開始";
            this.label12.Visible = false;
            // 
            // dtpEnd_Break_Time
            // 
            this.dtpEnd_Break_Time.CalendarFont = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpEnd_Break_Time.CustomFormat = "HH:mm";
            this.dtpEnd_Break_Time.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpEnd_Break_Time.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd_Break_Time.Location = new System.Drawing.Point(1358, 78);
            this.dtpEnd_Break_Time.Name = "dtpEnd_Break_Time";
            this.dtpEnd_Break_Time.ShowUpDown = true;
            this.dtpEnd_Break_Time.Size = new System.Drawing.Size(70, 28);
            this.dtpEnd_Break_Time.TabIndex = 22;
            this.dtpEnd_Break_Time.Visible = false;
            // 
            // dtpStart_Break_Time
            // 
            this.dtpStart_Break_Time.CalendarFont = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpStart_Break_Time.CustomFormat = "HH:mm";
            this.dtpStart_Break_Time.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpStart_Break_Time.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart_Break_Time.Location = new System.Drawing.Point(1278, 78);
            this.dtpStart_Break_Time.Name = "dtpStart_Break_Time";
            this.dtpStart_Break_Time.ShowUpDown = true;
            this.dtpStart_Break_Time.Size = new System.Drawing.Size(70, 28);
            this.dtpStart_Break_Time.TabIndex = 21;
            this.dtpStart_Break_Time.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1242, 86);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 17);
            this.label13.TabIndex = 202;
            this.label13.Text = "休憩";
            this.label13.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(1210, 84);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(16, 17);
            this.label14.TabIndex = 209;
            this.label14.Text = "h";
            // 
            // txtBreak_Time
            // 
            this.txtBreak_Time.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtBreak_Time.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtBreak_Time.Location = new System.Drawing.Point(1151, 79);
            this.txtBreak_Time.Name = "txtBreak_Time";
            this.txtBreak_Time.Size = new System.Drawing.Size(57, 28);
            this.txtBreak_Time.TabIndex = 23;
            this.txtBreak_Time.Text = "99";
            this.txtBreak_Time.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(1089, 86);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 17);
            this.label15.TabIndex = 207;
            this.label15.Text = "休憩時間";
            // 
            // txtComment
            // 
            this.txtComment.Font = new System.Drawing.Font("游ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtComment.Location = new System.Drawing.Point(997, 112);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(417, 56);
            this.txtComment.TabIndex = 24;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(960, 116);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(34, 17);
            this.label16.TabIndex = 211;
            this.label16.Text = "備考";
            // 
            // btnReg
            // 
            this.btnReg.Font = new System.Drawing.Font("游ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnReg.Image = global::FlockAppC.Properties.Resources.FD_1_小小;
            this.btnReg.Location = new System.Drawing.Point(1054, 179);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(80, 37);
            this.btnReg.TabIndex = 212;
            this.btnReg.Text = "保存";
            this.btnReg.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.BtnReg_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.Image = global::FlockAppC.Properties.Resources.閉じる_小小;
            this.btnClose.Location = new System.Drawing.Point(1391, 179);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 37);
            this.btnClose.TabIndex = 213;
            this.btnClose.Text = "閉じる";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("游ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnDelete.Image = global::FlockAppC.Properties.Resources.削除1_4p;
            this.btnDelete.Location = new System.Drawing.Point(1226, 179);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 37);
            this.btnDelete.TabIndex = 215;
            this.btnDelete.Text = "削除";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("游ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnNew.Image = global::FlockAppC.Properties.Resources.追加_小小;
            this.btnNew.Location = new System.Drawing.Point(1140, 179);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(80, 37);
            this.btnNew.TabIndex = 214;
            this.btnNew.Text = "新規";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // dgvCarList
            // 
            this.dgvCarList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarList.Location = new System.Drawing.Point(12, 227);
            this.dgvCarList.Name = "dgvCarList";
            this.dgvCarList.RowTemplate.Height = 21;
            this.dgvCarList.Size = new System.Drawing.Size(180, 446);
            this.dgvCarList.TabIndex = 216;
            this.dgvCarList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvCarList_CellClick);
            // 
            // lblCarNo
            // 
            this.lblCarNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lblCarNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCarNo.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblCarNo.Location = new System.Drawing.Point(443, 73);
            this.lblCarNo.Name = "lblCarNo";
            this.lblCarNo.Size = new System.Drawing.Size(75, 30);
            this.lblCarNo.TabIndex = 217;
            this.lblCarNo.Text = "あ1234";
            this.lblCarNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCarIdent
            // 
            this.lblCarIdent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lblCarIdent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCarIdent.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblCarIdent.Location = new System.Drawing.Point(521, 73);
            this.lblCarIdent.Name = "lblCarIdent";
            this.lblCarIdent.Size = new System.Drawing.Size(90, 30);
            this.lblCarIdent.TabIndex = 218;
            this.lblCarIdent.Text = "シャトル便";
            this.lblCarIdent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCarName
            // 
            this.lblCarName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lblCarName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCarName.Font = new System.Drawing.Font("游ゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCarName.Location = new System.Drawing.Point(614, 73);
            this.lblCarName.Name = "lblCarName";
            this.lblCarName.Size = new System.Drawing.Size(147, 30);
            this.lblCarName.TabIndex = 219;
            this.lblCarName.Text = "ハイエース";
            this.lblCarName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(795, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 17);
            this.label2.TabIndex = 220;
            this.label2.Text = "契約基本時間";
            // 
            // txtSort
            // 
            this.txtSort.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtSort.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtSort.Location = new System.Drawing.Point(1006, 185);
            this.txtSort.Name = "txtSort";
            this.txtSort.Size = new System.Drawing.Size(29, 28);
            this.txtSort.TabIndex = 221;
            this.txtSort.Text = "99";
            this.txtSort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSort.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(953, 191);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 17);
            this.label17.TabIndex = 222;
            this.label17.Text = "表示順";
            this.label17.Visible = false;
            // 
            // btnPast
            // 
            this.btnPast.Font = new System.Drawing.Font("游ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnPast.Location = new System.Drawing.Point(839, 199);
            this.btnPast.Name = "btnPast";
            this.btnPast.Size = new System.Drawing.Size(80, 24);
            this.btnPast.TabIndex = 226;
            this.btnPast.Text = "ペースト";
            this.btnPast.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPast.UseVisualStyleBackColor = true;
            this.btnPast.Click += new System.EventHandler(this.btnPast_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Font = new System.Drawing.Font("游ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCopy.Location = new System.Drawing.Point(758, 199);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(80, 24);
            this.btnCopy.TabIndex = 225;
            this.btnCopy.Text = "コピー";
            this.btnCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // lblConnect
            // 
            this.lblConnect.AutoSize = true;
            this.lblConnect.Font = new System.Drawing.Font("游ゴシック Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblConnect.ForeColor = System.Drawing.Color.Blue;
            this.lblConnect.Location = new System.Drawing.Point(446, 205);
            this.lblConnect.Name = "lblConnect";
            this.lblConnect.Size = new System.Drawing.Size(136, 16);
            this.lblConnect.TabIndex = 227;
            this.lblConnect.Text = "データベース接続中...";
            this.lblConnect.Visible = false;
            // 
            // frmMstBasicContractTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1483, 695);
            this.Controls.Add(this.lblConnect);
            this.Controls.Add(this.btnPast);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.txtSort);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCarName);
            this.Controls.Add(this.lblCarIdent);
            this.Controls.Add(this.lblCarNo);
            this.Controls.Add(this.gbox1);
            this.Controls.Add(this.dgvCarList);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnReg);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtBreak_Time);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dtpEnd_Break_Time);
            this.Controls.Add(this.dtpStart_Break_Time);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtWork_Time);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpEnd_Time3);
            this.Controls.Add(this.dtpEnd_Time2);
            this.Controls.Add(this.dtpEnd_Time1);
            this.Controls.Add(this.dtpStart_Time3);
            this.Controls.Add(this.dtpStart_Time2);
            this.Controls.Add(this.dtpStart_Time1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gbox2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvContractList);
            this.Controls.Add(this.Panel1);
            this.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMstBasicContractTime";
            this.Text = "マスターメンテ";
            this.Load += new System.EventHandler(this.FrmMstBasicContractTime_Load);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContractList)).EndInit();
            this.gbox1.ResumeLayout(false);
            this.gbox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbox2.ResumeLayout(false);
            this.gbox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label Label4;
        private System.Windows.Forms.DataGridView dgvContractList;
        private System.Windows.Forms.Button btnClearLocation;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Button btnSelectLocation;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.GroupBox gbox1;
        private System.Windows.Forms.RadioButton rdoKbn2;
        private System.Windows.Forms.RadioButton rdoKbn1;
        private System.Windows.Forms.TextBox txtLocationComment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox gbox2;
        private System.Windows.Forms.CheckBox chkSun;
        private System.Windows.Forms.CheckBox chkSat;
        private System.Windows.Forms.CheckBox chkFri;
        private System.Windows.Forms.CheckBox chkThu;
        private System.Windows.Forms.CheckBox chkWed;
        private System.Windows.Forms.CheckBox chkTue;
        private System.Windows.Forms.CheckBox chkMon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.DateTimePicker dtpStart_Time1;
        internal System.Windows.Forms.DateTimePicker dtpStart_Time2;
        internal System.Windows.Forms.DateTimePicker dtpStart_Time3;
        internal System.Windows.Forms.DateTimePicker dtpEnd_Time3;
        internal System.Windows.Forms.DateTimePicker dtpEnd_Time2;
        internal System.Windows.Forms.DateTimePicker dtpEnd_Time1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtWork_Time;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        internal System.Windows.Forms.DateTimePicker dtpEnd_Break_Time;
        internal System.Windows.Forms.DateTimePicker dtpStart_Break_Time;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtBreak_Time;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DataGridView dgvCarList;
        internal System.Windows.Forms.Label lblNew;
        internal System.Windows.Forms.Label lblCarNo;
        internal System.Windows.Forms.Label lblCarIdent;
        internal System.Windows.Forms.Label lblCarName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSort;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnPast;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Label lblConnect;
    }
}