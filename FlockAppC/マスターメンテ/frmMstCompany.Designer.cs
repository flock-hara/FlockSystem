namespace FlockAppC.マスターメンテ
{
    partial class frmMstCompany
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMstCompany));
            this.Panel1 = new System.Windows.Forms.Panel();
            this.lblNew = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReg = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCompanyName1 = new System.Windows.Forms.TextBox();
            this.txtCompanyName2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtZipCode1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtZipCode2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAddress1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAddress2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTelNo1 = new System.Windows.Forms.TextBox();
            this.txtTelNo3 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTelNo2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtFaxNo1 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtFaxNo2 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtMailAddress1 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtMailAddress2 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtMailAddress3 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtDelegete = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtUrl1 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtUrl2 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Panel1.Controls.Add(this.lblNew);
            this.Panel1.Controls.Add(this.Label4);
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(614, 37);
            this.Panel1.TabIndex = 119;
            // 
            // lblNew
            // 
            this.lblNew.BackColor = System.Drawing.Color.IndianRed;
            this.lblNew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNew.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblNew.Location = new System.Drawing.Point(524, 4);
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
            this.Label4.Size = new System.Drawing.Size(191, 20);
            this.Label4.TabIndex = 52;
            this.Label4.Text = "自社情報マスターメンテナンス";
            // 
            // cmbCompany
            // 
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(94, 56);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(359, 25);
            this.cmbCompany.TabIndex = 120;
            this.cmbCompany.SelectedIndexChanged += new System.EventHandler(this.cmbCompany_SelectedIndexChanged);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label3.Location = new System.Drawing.Point(53, 59);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(34, 17);
            this.Label3.TabIndex = 121;
            this.Label3.Text = "選択";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.Image = global::FlockAppC.Properties.Resources.閉じるA_8p;
            this.btnClose.Location = new System.Drawing.Point(527, 498);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 37);
            this.btnClose.TabIndex = 129;
            this.btnClose.Text = "閉る";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReg
            // 
            this.btnReg.Font = new System.Drawing.Font("游ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnReg.Image = global::FlockAppC.Properties.Resources.FD_1_小小;
            this.btnReg.Location = new System.Drawing.Point(12, 498);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(75, 37);
            this.btnReg.TabIndex = 128;
            this.btnReg.Text = "保存";
            this.btnReg.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(53, 98);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 17);
            this.label1.TabIndex = 130;
            this.label1.Text = "名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(14, 130);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 131;
            this.label2.Text = "営業所名等";
            // 
            // txtCompanyName1
            // 
            this.txtCompanyName1.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtCompanyName1.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtCompanyName1.Location = new System.Drawing.Point(94, 95);
            this.txtCompanyName1.Name = "txtCompanyName1";
            this.txtCompanyName1.Size = new System.Drawing.Size(359, 28);
            this.txtCompanyName1.TabIndex = 132;
            this.txtCompanyName1.Text = "〇〇株式会社";
            // 
            // txtCompanyName2
            // 
            this.txtCompanyName2.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtCompanyName2.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtCompanyName2.Location = new System.Drawing.Point(94, 127);
            this.txtCompanyName2.Name = "txtCompanyName2";
            this.txtCompanyName2.Size = new System.Drawing.Size(359, 28);
            this.txtCompanyName2.TabIndex = 133;
            this.txtCompanyName2.Text = "△△営業所";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(32, 175);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 17);
            this.label5.TabIndex = 134;
            this.label5.Text = "郵便番号";
            // 
            // txtZipCode1
            // 
            this.txtZipCode1.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtZipCode1.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtZipCode1.Location = new System.Drawing.Point(94, 172);
            this.txtZipCode1.Name = "txtZipCode1";
            this.txtZipCode1.Size = new System.Drawing.Size(40, 28);
            this.txtZipCode1.TabIndex = 135;
            this.txtZipCode1.Text = "999";
            this.txtZipCode1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(131, 178);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 17);
            this.label6.TabIndex = 136;
            this.label6.Text = "ー";
            // 
            // txtZipCode2
            // 
            this.txtZipCode2.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtZipCode2.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtZipCode2.Location = new System.Drawing.Point(148, 172);
            this.txtZipCode2.Name = "txtZipCode2";
            this.txtZipCode2.Size = new System.Drawing.Size(40, 28);
            this.txtZipCode2.TabIndex = 137;
            this.txtZipCode2.Text = "9999";
            this.txtZipCode2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(53, 207);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 17);
            this.label7.TabIndex = 138;
            this.label7.Text = "住所";
            // 
            // txtAddress1
            // 
            this.txtAddress1.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtAddress1.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtAddress1.Location = new System.Drawing.Point(94, 204);
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.Size = new System.Drawing.Size(499, 28);
            this.txtAddress1.TabIndex = 139;
            this.txtAddress1.Text = "千葉県流山市〇〇〇町１－２－３";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.Location = new System.Drawing.Point(31, 239);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 17);
            this.label8.TabIndex = 140;
            this.label8.Text = "建物名等";
            // 
            // txtAddress2
            // 
            this.txtAddress2.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtAddress2.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtAddress2.Location = new System.Drawing.Point(94, 236);
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Size = new System.Drawing.Size(359, 28);
            this.txtAddress2.TabIndex = 141;
            this.txtAddress2.Text = "流山ビル　３１０号";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.Location = new System.Drawing.Point(19, 281);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 17);
            this.label9.TabIndex = 142;
            this.label9.Text = "電話番号１";
            // 
            // txtTelNo1
            // 
            this.txtTelNo1.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtTelNo1.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtTelNo1.Location = new System.Drawing.Point(94, 278);
            this.txtTelNo1.Name = "txtTelNo1";
            this.txtTelNo1.Size = new System.Drawing.Size(130, 28);
            this.txtTelNo1.TabIndex = 143;
            this.txtTelNo1.Text = "99-9999-9999";
            this.txtTelNo1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTelNo3
            // 
            this.txtTelNo3.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtTelNo3.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtTelNo3.Location = new System.Drawing.Point(94, 340);
            this.txtTelNo3.Name = "txtTelNo3";
            this.txtTelNo3.Size = new System.Drawing.Size(130, 28);
            this.txtTelNo3.TabIndex = 145;
            this.txtTelNo3.Text = "99-9999-9999";
            this.txtTelNo3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label10.Location = new System.Drawing.Point(19, 343);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 17);
            this.label10.TabIndex = 144;
            this.label10.Text = "電話番号３";
            // 
            // txtTelNo2
            // 
            this.txtTelNo2.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtTelNo2.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtTelNo2.Location = new System.Drawing.Point(94, 309);
            this.txtTelNo2.Name = "txtTelNo2";
            this.txtTelNo2.Size = new System.Drawing.Size(130, 28);
            this.txtTelNo2.TabIndex = 147;
            this.txtTelNo2.Text = "99-9999-9999";
            this.txtTelNo2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label11.Location = new System.Drawing.Point(19, 312);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 17);
            this.label11.TabIndex = 146;
            this.label11.Text = "電話番号２";
            // 
            // txtFaxNo1
            // 
            this.txtFaxNo1.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtFaxNo1.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtFaxNo1.Location = new System.Drawing.Point(94, 381);
            this.txtFaxNo1.Name = "txtFaxNo1";
            this.txtFaxNo1.Size = new System.Drawing.Size(130, 28);
            this.txtFaxNo1.TabIndex = 149;
            this.txtFaxNo1.Text = "99-9999-9999";
            this.txtFaxNo1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label12.Location = new System.Drawing.Point(21, 384);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 17);
            this.label12.TabIndex = 148;
            this.label12.Text = "FAX番号１";
            // 
            // txtFaxNo2
            // 
            this.txtFaxNo2.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtFaxNo2.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtFaxNo2.Location = new System.Drawing.Point(94, 412);
            this.txtFaxNo2.Name = "txtFaxNo2";
            this.txtFaxNo2.Size = new System.Drawing.Size(130, 28);
            this.txtFaxNo2.TabIndex = 151;
            this.txtFaxNo2.Text = "99-9999-9999";
            this.txtFaxNo2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label13.Location = new System.Drawing.Point(21, 415);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 17);
            this.label13.TabIndex = 150;
            this.label13.Text = "FAX番号２";
            // 
            // txtMailAddress1
            // 
            this.txtMailAddress1.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtMailAddress1.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtMailAddress1.Location = new System.Drawing.Point(315, 278);
            this.txtMailAddress1.Name = "txtMailAddress1";
            this.txtMailAddress1.Size = new System.Drawing.Size(278, 28);
            this.txtMailAddress1.TabIndex = 153;
            this.txtMailAddress1.Text = "99-9999-9999";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label14.Location = new System.Drawing.Point(248, 281);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 17);
            this.label14.TabIndex = 152;
            this.label14.Text = "メール１";
            // 
            // txtMailAddress2
            // 
            this.txtMailAddress2.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtMailAddress2.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtMailAddress2.Location = new System.Drawing.Point(315, 309);
            this.txtMailAddress2.Name = "txtMailAddress2";
            this.txtMailAddress2.Size = new System.Drawing.Size(278, 28);
            this.txtMailAddress2.TabIndex = 155;
            this.txtMailAddress2.Text = "99-9999-9999";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label15.Location = new System.Drawing.Point(248, 312);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 17);
            this.label15.TabIndex = 154;
            this.label15.Text = "メール２";
            // 
            // txtMailAddress3
            // 
            this.txtMailAddress3.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtMailAddress3.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtMailAddress3.Location = new System.Drawing.Point(315, 340);
            this.txtMailAddress3.Name = "txtMailAddress3";
            this.txtMailAddress3.Size = new System.Drawing.Size(278, 28);
            this.txtMailAddress3.TabIndex = 157;
            this.txtMailAddress3.Text = "99-9999-9999";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label16.Location = new System.Drawing.Point(248, 343);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 17);
            this.label16.TabIndex = 156;
            this.label16.Text = "メール３";
            // 
            // txtDelegete
            // 
            this.txtDelegete.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtDelegete.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtDelegete.Location = new System.Drawing.Point(505, 98);
            this.txtDelegete.Name = "txtDelegete";
            this.txtDelegete.Size = new System.Drawing.Size(88, 28);
            this.txtDelegete.TabIndex = 159;
            this.txtDelegete.Text = "フロック太郎";
            this.txtDelegete.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label17.Location = new System.Drawing.Point(457, 101);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 17);
            this.label17.TabIndex = 158;
            this.label17.Text = "代表者";
            // 
            // txtUrl1
            // 
            this.txtUrl1.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtUrl1.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtUrl1.Location = new System.Drawing.Point(315, 381);
            this.txtUrl1.Name = "txtUrl1";
            this.txtUrl1.Size = new System.Drawing.Size(278, 28);
            this.txtUrl1.TabIndex = 161;
            this.txtUrl1.Text = "http://aaaaa.bb.cc";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label18.Location = new System.Drawing.Point(273, 384);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 17);
            this.label18.TabIndex = 160;
            this.label18.Text = "URL";
            // 
            // txtUrl2
            // 
            this.txtUrl2.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtUrl2.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtUrl2.Location = new System.Drawing.Point(315, 412);
            this.txtUrl2.Name = "txtUrl2";
            this.txtUrl2.Size = new System.Drawing.Size(278, 28);
            this.txtUrl2.TabIndex = 163;
            this.txtUrl2.Text = "http://bbbbb.cc.dd";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label19.Location = new System.Drawing.Point(273, 415);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 17);
            this.label19.TabIndex = 162;
            this.label19.Text = "URL";
            // 
            // txtComment
            // 
            this.txtComment.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtComment.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtComment.Location = new System.Drawing.Point(94, 456);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(499, 28);
            this.txtComment.TabIndex = 165;
            this.txtComment.Text = "補足事項記載";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label20.Location = new System.Drawing.Point(31, 459);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(34, 17);
            this.label20.TabIndex = 164;
            this.label20.Text = "備考";
            // 
            // frmMstCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 547);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.txtUrl2);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtUrl1);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtDelegete);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtMailAddress3);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtMailAddress2);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtMailAddress1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtFaxNo2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtFaxNo1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtTelNo2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtTelNo3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtTelNo1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtAddress2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtAddress1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtZipCode2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtZipCode1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCompanyName2);
            this.Controls.Add(this.txtCompanyName1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnReg);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.cmbCompany);
            this.Controls.Add(this.Panel1);
            this.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMstCompany";
            this.Text = "マスターメンテナンス";
            this.Load += new System.EventHandler(this.frmMstCompany_Load);
            this.Shown += new System.EventHandler(this.frmMstCompany_Shown);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label lblNew;
        internal System.Windows.Forms.Label Label4;
        private System.Windows.Forms.ComboBox cmbCompany;
        internal System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnReg;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCompanyName1;
        private System.Windows.Forms.TextBox txtCompanyName2;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtZipCode1;
        internal System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtZipCode2;
        internal System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAddress1;
        internal System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAddress2;
        internal System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTelNo1;
        private System.Windows.Forms.TextBox txtTelNo3;
        internal System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTelNo2;
        internal System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtFaxNo1;
        internal System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtFaxNo2;
        internal System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtMailAddress1;
        internal System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtMailAddress2;
        internal System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtMailAddress3;
        internal System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtDelegete;
        internal System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtUrl1;
        internal System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtUrl2;
        internal System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtComment;
        internal System.Windows.Forms.Label label20;
    }
}