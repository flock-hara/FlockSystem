namespace FlockAppC.社用車関連
{
    partial class frmCarEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCarEdit));
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Label4 = new System.Windows.Forms.Label();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.cmbCar = new System.Windows.Forms.ComboBox();
            this.dtpDay = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStart_Time = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStart_Odo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEnd_Odo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpEnd_Time = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDistance = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbFron_Point = new System.Windows.Forms.ComboBox();
            this.cmbTo_Point = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtGas_Stock = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.rdoAlcohol_Ok = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoAlcohol_Ng = new System.Windows.Forms.RadioButton();
            this.chkDelete_Flag = new System.Windows.Forms.CheckBox();
            this.btnReg = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.Panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Panel1.Controls.Add(this.Label4);
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(701, 37);
            this.Panel1.TabIndex = 121;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label4.Location = new System.Drawing.Point(12, 9);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(126, 20);
            this.Label4.TabIndex = 52;
            this.Label4.Text = "走行記録編集・登録";
            // 
            // cmbUser
            // 
            this.cmbUser.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Location = new System.Drawing.Point(98, 58);
            this.cmbUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(116, 28);
            this.cmbUser.TabIndex = 125;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.Location = new System.Drawing.Point(38, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 20);
            this.label9.TabIndex = 124;
            this.label9.Text = "担当者";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label7.Location = new System.Drawing.Point(223, 62);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(84, 20);
            this.Label7.TabIndex = 123;
            this.Label7.Text = "車番：車種";
            // 
            // cmbCar
            // 
            this.cmbCar.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbCar.FormattingEnabled = true;
            this.cmbCar.Location = new System.Drawing.Point(313, 57);
            this.cmbCar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbCar.Name = "cmbCar";
            this.cmbCar.Size = new System.Drawing.Size(153, 28);
            this.cmbCar.TabIndex = 122;
            // 
            // dtpDay
            // 
            this.dtpDay.CalendarFont = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpDay.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpDay.Location = new System.Drawing.Point(98, 106);
            this.dtpDay.Name = "dtpDay";
            this.dtpDay.Size = new System.Drawing.Size(160, 32);
            this.dtpDay.TabIndex = 126;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(51, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 20);
            this.label1.TabIndex = 127;
            this.label1.Text = "日付";
            // 
            // dtpStart_Time
            // 
            this.dtpStart_Time.CalendarFont = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpStart_Time.CustomFormat = "HH:mm";
            this.dtpStart_Time.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpStart_Time.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart_Time.Location = new System.Drawing.Point(178, 163);
            this.dtpStart_Time.Name = "dtpStart_Time";
            this.dtpStart_Time.ShowUpDown = true;
            this.dtpStart_Time.Size = new System.Drawing.Size(70, 32);
            this.dtpStart_Time.TabIndex = 190;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(103, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 191;
            this.label2.Text = "出発時刻";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(269, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 20);
            this.label3.TabIndex = 192;
            this.label3.Text = "出発時メーター";
            // 
            // txtStart_Odo
            // 
            this.txtStart_Odo.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtStart_Odo.Location = new System.Drawing.Point(393, 163);
            this.txtStart_Odo.Margin = new System.Windows.Forms.Padding(4);
            this.txtStart_Odo.Name = "txtStart_Odo";
            this.txtStart_Odo.Size = new System.Drawing.Size(113, 32);
            this.txtStart_Odo.TabIndex = 193;
            this.txtStart_Odo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtStart_Odo.TextChanged += new System.EventHandler(this.TextBoxes_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(506, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 20);
            this.label5.TabIndex = 194;
            this.label5.Text = "km";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(506, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 20);
            this.label6.TabIndex = 199;
            this.label6.Text = "km";
            // 
            // txtEnd_Odo
            // 
            this.txtEnd_Odo.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtEnd_Odo.Location = new System.Drawing.Point(393, 217);
            this.txtEnd_Odo.Margin = new System.Windows.Forms.Padding(4);
            this.txtEnd_Odo.Name = "txtEnd_Odo";
            this.txtEnd_Odo.Size = new System.Drawing.Size(113, 32);
            this.txtEnd_Odo.TabIndex = 198;
            this.txtEnd_Odo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEnd_Odo.TextChanged += new System.EventHandler(this.TextBoxes_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.Location = new System.Drawing.Point(269, 223);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 20);
            this.label8.TabIndex = 197;
            this.label8.Text = "到着時メーター";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label10.Location = new System.Drawing.Point(103, 223);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 20);
            this.label10.TabIndex = 196;
            this.label10.Text = "到着時刻";
            // 
            // dtpEnd_Time
            // 
            this.dtpEnd_Time.CalendarFont = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpEnd_Time.CustomFormat = "HH:mm";
            this.dtpEnd_Time.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpEnd_Time.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd_Time.Location = new System.Drawing.Point(178, 217);
            this.dtpEnd_Time.Name = "dtpEnd_Time";
            this.dtpEnd_Time.ShowUpDown = true;
            this.dtpEnd_Time.Size = new System.Drawing.Size(70, 32);
            this.dtpEnd_Time.TabIndex = 195;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("游ゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(295, 125);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(211, 21);
            this.label11.TabIndex = 200;
            this.label11.Text = "追加、編集はMySQLも対象";
            this.label11.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label12.Location = new System.Drawing.Point(506, 275);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 20);
            this.label12.TabIndex = 203;
            this.label12.Text = "km";
            // 
            // txtDistance
            // 
            this.txtDistance.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtDistance.Location = new System.Drawing.Point(393, 267);
            this.txtDistance.Margin = new System.Windows.Forms.Padding(4);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.ReadOnly = true;
            this.txtDistance.Size = new System.Drawing.Size(113, 32);
            this.txtDistance.TabIndex = 202;
            this.txtDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label13.Location = new System.Drawing.Point(314, 272);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 20);
            this.label13.TabIndex = 201;
            this.label13.Text = "走行距離";
            // 
            // txtNote
            // 
            this.txtNote.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtNote.Location = new System.Drawing.Point(176, 372);
            this.txtNote.Margin = new System.Windows.Forms.Padding(4);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(477, 32);
            this.txtNote.TabIndex = 204;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label14.Location = new System.Drawing.Point(85, 331);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(85, 20);
            this.label14.TabIndex = 205;
            this.label14.Text = "行先(From)";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label15.Location = new System.Drawing.Point(394, 331);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(66, 20);
            this.label15.TabIndex = 206;
            this.label15.Text = "行先(To)";
            // 
            // cmbFron_Point
            // 
            this.cmbFron_Point.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbFron_Point.FormattingEnabled = true;
            this.cmbFron_Point.Location = new System.Drawing.Point(176, 328);
            this.cmbFron_Point.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbFron_Point.Name = "cmbFron_Point";
            this.cmbFron_Point.Size = new System.Drawing.Size(187, 28);
            this.cmbFron_Point.TabIndex = 207;
            // 
            // cmbTo_Point
            // 
            this.cmbTo_Point.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbTo_Point.FormattingEnabled = true;
            this.cmbTo_Point.Location = new System.Drawing.Point(466, 328);
            this.cmbTo_Point.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbTo_Point.Name = "cmbTo_Point";
            this.cmbTo_Point.Size = new System.Drawing.Size(187, 28);
            this.cmbTo_Point.TabIndex = 208;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label16.Location = new System.Drawing.Point(127, 377);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(39, 20);
            this.label16.TabIndex = 209;
            this.label16.Text = "補足";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label17.Location = new System.Drawing.Point(127, 432);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(39, 20);
            this.label17.TabIndex = 210;
            this.label17.Text = "給油";
            // 
            // txtGas_Stock
            // 
            this.txtGas_Stock.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtGas_Stock.Location = new System.Drawing.Point(176, 427);
            this.txtGas_Stock.Margin = new System.Windows.Forms.Padding(4);
            this.txtGas_Stock.Name = "txtGas_Stock";
            this.txtGas_Stock.Size = new System.Drawing.Size(56, 32);
            this.txtGas_Stock.TabIndex = 211;
            this.txtGas_Stock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label18.Location = new System.Drawing.Point(231, 433);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(24, 20);
            this.label18.TabIndex = 212;
            this.label18.Text = "ℓ";
            // 
            // rdoAlcohol_Ok
            // 
            this.rdoAlcohol_Ok.AutoSize = true;
            this.rdoAlcohol_Ok.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoAlcohol_Ok.Location = new System.Drawing.Point(20, 28);
            this.rdoAlcohol_Ok.Name = "rdoAlcohol_Ok";
            this.rdoAlcohol_Ok.Size = new System.Drawing.Size(42, 24);
            this.rdoAlcohol_Ok.TabIndex = 213;
            this.rdoAlcohol_Ok.TabStop = true;
            this.rdoAlcohol_Ok.Text = "良";
            this.rdoAlcohol_Ok.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoAlcohol_Ng);
            this.groupBox1.Controls.Add(this.rdoAlcohol_Ok);
            this.groupBox1.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox1.Location = new System.Drawing.Point(493, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(160, 65);
            this.groupBox1.TabIndex = 214;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "アルコールチェック";
            // 
            // rdoAlcohol_Ng
            // 
            this.rdoAlcohol_Ng.AutoSize = true;
            this.rdoAlcohol_Ng.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoAlcohol_Ng.Location = new System.Drawing.Point(70, 28);
            this.rdoAlcohol_Ng.Name = "rdoAlcohol_Ng";
            this.rdoAlcohol_Ng.Size = new System.Drawing.Size(42, 24);
            this.rdoAlcohol_Ng.TabIndex = 214;
            this.rdoAlcohol_Ng.TabStop = true;
            this.rdoAlcohol_Ng.Text = "否";
            this.rdoAlcohol_Ng.UseVisualStyleBackColor = true;
            // 
            // chkDelete_Flag
            // 
            this.chkDelete_Flag.AutoSize = true;
            this.chkDelete_Flag.Font = new System.Drawing.Font("游ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chkDelete_Flag.Location = new System.Drawing.Point(318, 432);
            this.chkDelete_Flag.Name = "chkDelete_Flag";
            this.chkDelete_Flag.Size = new System.Drawing.Size(58, 24);
            this.chkDelete_Flag.TabIndex = 215;
            this.chkDelete_Flag.Text = "削除";
            this.chkDelete_Flag.UseVisualStyleBackColor = true;
            // 
            // btnReg
            // 
            this.btnReg.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnReg.Image = global::FlockAppC.Properties.Resources.メモ4_小小;
            this.btnReg.Location = new System.Drawing.Point(16, 486);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(100, 35);
            this.btnReg.TabIndex = 217;
            this.btnReg.Text = "登録";
            this.btnReg.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.Image = global::FlockAppC.Properties.Resources.閉じる_小;
            this.btnClose.Location = new System.Drawing.Point(590, 486);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 35);
            this.btnClose.TabIndex = 216;
            this.btnClose.Text = "閉じる";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmCarEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 533);
            this.Controls.Add(this.btnReg);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.chkDelete_Flag);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtGas_Stock);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.cmbTo_Point);
            this.Controls.Add(this.cmbFron_Point);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtDistance);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtEnd_Odo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dtpEnd_Time);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtStart_Odo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpStart_Time);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpDay);
            this.Controls.Add(this.cmbUser);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.cmbCar);
            this.Controls.Add(this.Panel1);
            this.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCarEdit";
            this.Text = "走行記録";
            this.Load += new System.EventHandler(this.frmCarEdit_Load);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.ComboBox cmbUser;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.ComboBox cmbCar;
        internal System.Windows.Forms.DateTimePicker dtpDay;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.DateTimePicker dtpStart_Time;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtStart_Odo;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox txtEnd_Odo;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.DateTimePicker dtpEnd_Time;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.TextBox txtDistance;
        internal System.Windows.Forms.Label label13;
        internal System.Windows.Forms.TextBox txtNote;
        internal System.Windows.Forms.Label label14;
        internal System.Windows.Forms.Label label15;
        internal System.Windows.Forms.ComboBox cmbFron_Point;
        internal System.Windows.Forms.ComboBox cmbTo_Point;
        internal System.Windows.Forms.Label label16;
        internal System.Windows.Forms.Label label17;
        internal System.Windows.Forms.TextBox txtGas_Stock;
        internal System.Windows.Forms.Label label18;
        private System.Windows.Forms.RadioButton rdoAlcohol_Ok;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoAlcohol_Ng;
        private System.Windows.Forms.CheckBox chkDelete_Flag;
        internal System.Windows.Forms.Button btnReg;
        internal System.Windows.Forms.Button btnClose;
    }
}