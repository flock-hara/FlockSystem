namespace FlockAppC.マスターメンテ
{
    partial class frmMstLocation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMstLocation));
            this.txtName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.lblNew = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRyakuName = new System.Windows.Forms.TextBox();
            this.txtKana1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSelectStaff = new System.Windows.Forms.Button();
            this.txtStaffName1 = new System.Windows.Forms.TextBox();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.txtSort = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtEmergency_Memo = new System.Windows.Forms.TextBox();
            this.txtEmergency_TelNo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtMailAddress = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFaxNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTelNo = new System.Windows.Forms.TextBox();
            this.txtClosingDate = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.chkContract = new System.Windows.Forms.CheckBox();
            this.dgvUserList = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.btnUserAdd = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLocationCar = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnReg = new System.Windows.Forms.Button();
            this.lblConnect = new System.Windows.Forms.Label();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtName.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtName.Location = new System.Drawing.Point(54, 54);
            this.txtName.MaxLength = 40;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(282, 28);
            this.txtName.TabIndex = 96;
            this.txtName.Text = "専従先名";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(19, 57);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 17);
            this.label13.TabIndex = 95;
            this.label13.Text = "名称";
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Panel1.Controls.Add(this.lblNew);
            this.Panel1.Controls.Add(this.Label4);
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(1019, 37);
            this.Panel1.TabIndex = 97;
            // 
            // lblNew
            // 
            this.lblNew.BackColor = System.Drawing.Color.IndianRed;
            this.lblNew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNew.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblNew.Location = new System.Drawing.Point(928, 3);
            this.lblNew.Name = "lblNew";
            this.lblNew.Size = new System.Drawing.Size(86, 30);
            this.lblNew.TabIndex = 128;
            this.lblNew.Text = "　新規　";
            this.lblNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label4.Location = new System.Drawing.Point(12, 9);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(178, 20);
            this.Label4.TabIndex = 52;
            this.Label4.Text = "専従先マスターメンテナンス";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(338, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 17);
            this.label1.TabIndex = 98;
            this.label1.Text = "略称";
            // 
            // txtRyakuName
            // 
            this.txtRyakuName.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtRyakuName.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtRyakuName.Location = new System.Drawing.Point(371, 54);
            this.txtRyakuName.MaxLength = 20;
            this.txtRyakuName.Name = "txtRyakuName";
            this.txtRyakuName.Size = new System.Drawing.Size(123, 28);
            this.txtRyakuName.TabIndex = 99;
            this.txtRyakuName.Text = "専従先名";
            // 
            // txtKana1
            // 
            this.txtKana1.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtKana1.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.txtKana1.Location = new System.Drawing.Point(551, 54);
            this.txtKana1.MaxLength = 1;
            this.txtKana1.Name = "txtKana1";
            this.txtKana1.Size = new System.Drawing.Size(26, 28);
            this.txtKana1.TabIndex = 102;
            this.txtKana1.Text = "ｱ";
            this.txtKana1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtKana1.TextChanged += new System.EventHandler(this.txtKana1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(495, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 17);
            this.label3.TabIndex = 101;
            this.label3.Text = "ｶﾅ(半角)";
            // 
            // btnSelectStaff
            // 
            this.btnSelectStaff.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSelectStaff.Location = new System.Drawing.Point(27, 176);
            this.btnSelectStaff.Name = "btnSelectStaff";
            this.btnSelectStaff.Size = new System.Drawing.Size(116, 28);
            this.btnSelectStaff.TabIndex = 103;
            this.btnSelectStaff.Text = "フロック営業";
            this.btnSelectStaff.UseVisualStyleBackColor = true;
            this.btnSelectStaff.Click += new System.EventHandler(this.btnSelectStaff_Click);
            // 
            // txtStaffName1
            // 
            this.txtStaffName1.BackColor = System.Drawing.Color.White;
            this.txtStaffName1.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtStaffName1.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtStaffName1.Location = new System.Drawing.Point(149, 176);
            this.txtStaffName1.Name = "txtStaffName1";
            this.txtStaffName1.Size = new System.Drawing.Size(115, 28);
            this.txtStaffName1.TabIndex = 104;
            this.txtStaffName1.Text = "従業員氏名";
            this.txtStaffName1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgvList
            // 
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Location = new System.Drawing.Point(12, 247);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowTemplate.Height = 21;
            this.dgvList.Size = new System.Drawing.Size(996, 343);
            this.dgvList.TabIndex = 106;
            this.dgvList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellClick);
            // 
            // txtSort
            // 
            this.txtSort.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtSort.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtSort.Location = new System.Drawing.Point(858, 209);
            this.txtSort.MaxLength = 3;
            this.txtSort.Name = "txtSort";
            this.txtSort.Size = new System.Drawing.Size(26, 28);
            this.txtSort.TabIndex = 107;
            this.txtSort.Text = "ｱ";
            this.txtSort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSort.TextChanged += new System.EventHandler(this.txtSort_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(809, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 17);
            this.label5.TabIndex = 108;
            this.label5.Text = "並び順";
            // 
            // txtComment
            // 
            this.txtComment.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtComment.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtComment.Location = new System.Drawing.Point(469, 209);
            this.txtComment.MaxLength = 100;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(330, 28);
            this.txtComment.TabIndex = 109;
            this.txtComment.Text = "専従先名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(432, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 110;
            this.label2.Text = "備考";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 17);
            this.label8.TabIndex = 119;
            this.label8.Text = "電話番号（代表）";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtEmergency_Memo);
            this.groupBox1.Controls.Add(this.txtEmergency_TelNo);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtMailAddress);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtFaxNo);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtTelNo);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(23, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(575, 88);
            this.groupBox1.TabIndex = 120;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "お客様情報";
            // 
            // txtEmergency_Memo
            // 
            this.txtEmergency_Memo.BackColor = System.Drawing.Color.White;
            this.txtEmergency_Memo.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtEmergency_Memo.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtEmergency_Memo.Location = new System.Drawing.Point(482, 52);
            this.txtEmergency_Memo.MaxLength = 40;
            this.txtEmergency_Memo.Name = "txtEmergency_Memo";
            this.txtEmergency_Memo.Size = new System.Drawing.Size(82, 28);
            this.txtEmergency_Memo.TabIndex = 127;
            this.txtEmergency_Memo.Text = "従業員氏名";
            this.txtEmergency_Memo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtEmergency_TelNo
            // 
            this.txtEmergency_TelNo.BackColor = System.Drawing.Color.White;
            this.txtEmergency_TelNo.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtEmergency_TelNo.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtEmergency_TelNo.Location = new System.Drawing.Point(361, 52);
            this.txtEmergency_TelNo.MaxLength = 15;
            this.txtEmergency_TelNo.Name = "txtEmergency_TelNo";
            this.txtEmergency_TelNo.Size = new System.Drawing.Size(115, 28);
            this.txtEmergency_TelNo.TabIndex = 126;
            this.txtEmergency_TelNo.Text = "従業員氏名";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(280, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 17);
            this.label11.TabIndex = 125;
            this.label11.Text = "緊急連絡先";
            // 
            // txtMailAddress
            // 
            this.txtMailAddress.BackColor = System.Drawing.Color.White;
            this.txtMailAddress.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtMailAddress.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtMailAddress.Location = new System.Drawing.Point(333, 20);
            this.txtMailAddress.MaxLength = 50;
            this.txtMailAddress.Name = "txtMailAddress";
            this.txtMailAddress.Size = new System.Drawing.Size(231, 28);
            this.txtMailAddress.TabIndex = 124;
            this.txtMailAddress.Text = "従業員氏名";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(242, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 17);
            this.label10.TabIndex = 123;
            this.label10.Text = "メール（代表）";
            // 
            // txtFaxNo
            // 
            this.txtFaxNo.BackColor = System.Drawing.Color.White;
            this.txtFaxNo.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtFaxNo.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtFaxNo.Location = new System.Drawing.Point(125, 52);
            this.txtFaxNo.MaxLength = 15;
            this.txtFaxNo.Name = "txtFaxNo";
            this.txtFaxNo.Size = new System.Drawing.Size(115, 28);
            this.txtFaxNo.TabIndex = 122;
            this.txtFaxNo.Text = "従業員氏名";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(59, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 17);
            this.label9.TabIndex = 121;
            this.label9.Text = "Fax番号";
            // 
            // txtTelNo
            // 
            this.txtTelNo.BackColor = System.Drawing.Color.White;
            this.txtTelNo.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtTelNo.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtTelNo.Location = new System.Drawing.Point(125, 20);
            this.txtTelNo.MaxLength = 15;
            this.txtTelNo.Name = "txtTelNo";
            this.txtTelNo.Size = new System.Drawing.Size(115, 28);
            this.txtTelNo.TabIndex = 120;
            this.txtTelNo.Text = "従業員氏名";
            // 
            // txtClosingDate
            // 
            this.txtClosingDate.BackColor = System.Drawing.Color.White;
            this.txtClosingDate.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtClosingDate.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtClosingDate.Location = new System.Drawing.Point(62, 209);
            this.txtClosingDate.MaxLength = 2;
            this.txtClosingDate.Name = "txtClosingDate";
            this.txtClosingDate.Size = new System.Drawing.Size(37, 28);
            this.txtClosingDate.TabIndex = 122;
            this.txtClosingDate.Text = "31";
            this.txtClosingDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtClosingDate.TextChanged += new System.EventHandler(this.txtClosingDate_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(28, 214);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 17);
            this.label12.TabIndex = 121;
            this.label12.Text = "締日";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(103, 214);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(166, 17);
            this.label14.TabIndex = 123;
            this.label14.Text = "日 (末締の場合、31を入力)";
            // 
            // chkContract
            // 
            this.chkContract.AutoSize = true;
            this.chkContract.Location = new System.Drawing.Point(273, 213);
            this.chkContract.Name = "chkContract";
            this.chkContract.Size = new System.Drawing.Size(157, 21);
            this.chkContract.TabIndex = 125;
            this.chkContract.Text = "基本契約走行距離あり";
            this.chkContract.UseVisualStyleBackColor = true;
            // 
            // dgvUserList
            // 
            this.dgvUserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserList.Location = new System.Drawing.Point(607, 85);
            this.dgvUserList.Name = "dgvUserList";
            this.dgvUserList.RowTemplate.Height = 21;
            this.dgvUserList.Size = new System.Drawing.Size(191, 118);
            this.dgvUserList.TabIndex = 127;
            this.dgvUserList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUserList_CellClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(604, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 17);
            this.label6.TabIndex = 128;
            this.label6.Text = "担当者";
            // 
            // btnUserAdd
            // 
            this.btnUserAdd.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnUserAdd.Location = new System.Drawing.Point(719, 53);
            this.btnUserAdd.Name = "btnUserAdd";
            this.btnUserAdd.Size = new System.Drawing.Size(80, 28);
            this.btnUserAdd.TabIndex = 129;
            this.btnUserAdd.Text = "新規追加";
            this.btnUserAdd.UseVisualStyleBackColor = true;
            this.btnUserAdd.Click += new System.EventHandler(this.btnUserAdd_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FlockAppC.Properties.Resources.病院5;
            this.pictureBox1.Location = new System.Drawing.Point(812, 56);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(195, 143);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 126;
            this.pictureBox1.TabStop = false;
            // 
            // btnLocationCar
            // 
            this.btnLocationCar.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnLocationCar.Image = global::FlockAppC.Properties.Resources.ハイエース1小;
            this.btnLocationCar.Location = new System.Drawing.Point(292, 600);
            this.btnLocationCar.Name = "btnLocationCar";
            this.btnLocationCar.Size = new System.Drawing.Size(117, 37);
            this.btnLocationCar.TabIndex = 124;
            this.btnLocationCar.Text = "車両登録";
            this.btnLocationCar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLocationCar.UseVisualStyleBackColor = true;
            this.btnLocationCar.Click += new System.EventHandler(this.btnLocationCar_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.Image = global::FlockAppC.Properties.Resources.閉じる_小小;
            this.btnClose.Location = new System.Drawing.Point(928, 600);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 37);
            this.btnClose.TabIndex = 114;
            this.btnClose.Text = "閉じる";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnDelete.Image = global::FlockAppC.Properties.Resources.削除1_4p;
            this.btnDelete.Location = new System.Drawing.Point(183, 600);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 37);
            this.btnDelete.TabIndex = 113;
            this.btnDelete.Text = "削除";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnNew.Image = global::FlockAppC.Properties.Resources.追加_小小;
            this.btnNew.Location = new System.Drawing.Point(97, 600);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(80, 37);
            this.btnNew.TabIndex = 112;
            this.btnNew.Text = "新規";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnReg
            // 
            this.btnReg.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnReg.Image = global::FlockAppC.Properties.Resources.FD_1_小小;
            this.btnReg.Location = new System.Drawing.Point(11, 600);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(80, 37);
            this.btnReg.TabIndex = 111;
            this.btnReg.Text = "保存";
            this.btnReg.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // lblConnect
            // 
            this.lblConnect.AutoSize = true;
            this.lblConnect.Font = new System.Drawing.Font("游ゴシック Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblConnect.ForeColor = System.Drawing.Color.Blue;
            this.lblConnect.Location = new System.Drawing.Point(441, 611);
            this.lblConnect.Name = "lblConnect";
            this.lblConnect.Size = new System.Drawing.Size(136, 16);
            this.lblConnect.TabIndex = 154;
            this.lblConnect.Text = "データベース接続中...";
            this.lblConnect.Visible = false;
            // 
            // frmMstLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 645);
            this.Controls.Add(this.lblConnect);
            this.Controls.Add(this.btnUserAdd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvUserList);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.chkContract);
            this.Controls.Add(this.btnLocationCar);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtClosingDate);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnReg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSort);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.btnSelectStaff);
            this.Controls.Add(this.txtStaffName1);
            this.Controls.Add(this.txtKana1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRyakuName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label13);
            this.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMstLocation";
            this.Text = "マスターメンテナンス";
            this.Load += new System.EventHandler(this.frmMstLocation_Load);
            this.Shown += new System.EventHandler(this.frmMstLocation_Shown);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label13;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label Label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRyakuName;
        private System.Windows.Forms.TextBox txtKana1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSelectStaff;
        private System.Windows.Forms.TextBox txtStaffName1;
        private System.Windows.Forms.DataGridView dgvList;
        internal System.Windows.Forms.Label lblNew;
        private System.Windows.Forms.TextBox txtSort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMailAddress;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtFaxNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTelNo;
        private System.Windows.Forms.TextBox txtEmergency_Memo;
        private System.Windows.Forms.TextBox txtEmergency_TelNo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtClosingDate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnLocationCar;
        private System.Windows.Forms.CheckBox chkContract;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvUserList;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnUserAdd;
        private System.Windows.Forms.Label lblConnect;
    }
}