namespace FlockAppC.マスターメンテ
{
    partial class frmMstStaffList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMstStaffList));
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSort = new System.Windows.Forms.ComboBox();
            this.chkZaiFlag = new System.Windows.Forms.CheckBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.lblEmployment = new System.Windows.Forms.Label();
            this.btnDisplay = new System.Windows.Forms.Button();
            this.btnSelectEmployment = new System.Windows.Forms.Button();
            this.chkProxy = new System.Windows.Forms.CheckBox();
            this.btnSelectOffice = new System.Windows.Forms.Button();
            this.lblOffice = new System.Windows.Forms.Label();
            this.btnSelectGroup = new System.Windows.Forms.Button();
            this.lblGroup = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.Panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvList
            // 
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Location = new System.Drawing.Point(12, 132);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowTemplate.Height = 21;
            this.dgvList.Size = new System.Drawing.Size(793, 630);
            this.dgvList.TabIndex = 0;
            this.dgvList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellClick);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Panel1.Controls.Add(this.Label4);
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(817, 37);
            this.Panel1.TabIndex = 75;
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
            this.Label4.Text = "担当者マスター一覧";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmbSort);
            this.groupBox2.Controls.Add(this.chkZaiFlag);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.lblEmployment);
            this.groupBox2.Controls.Add(this.btnDisplay);
            this.groupBox2.Controls.Add(this.btnSelectEmployment);
            this.groupBox2.Controls.Add(this.chkProxy);
            this.groupBox2.Controls.Add(this.btnSelectOffice);
            this.groupBox2.Controls.Add(this.lblOffice);
            this.groupBox2.Controls.Add(this.btnSelectGroup);
            this.groupBox2.Controls.Add(this.lblGroup);
            this.groupBox2.Location = new System.Drawing.Point(12, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(793, 85);
            this.groupBox2.TabIndex = 99;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "表示条件";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(325, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 110;
            this.label1.Text = "並べ替え";
            // 
            // cmbSort
            // 
            this.cmbSort.FormattingEnabled = true;
            this.cmbSort.Location = new System.Drawing.Point(388, 51);
            this.cmbSort.Name = "cmbSort";
            this.cmbSort.Size = new System.Drawing.Size(60, 25);
            this.cmbSort.TabIndex = 104;
            // 
            // chkZaiFlag
            // 
            this.chkZaiFlag.AutoSize = true;
            this.chkZaiFlag.Location = new System.Drawing.Point(218, 52);
            this.chkZaiFlag.Name = "chkZaiFlag";
            this.chkZaiFlag.Size = new System.Drawing.Size(66, 21);
            this.chkZaiFlag.TabIndex = 109;
            this.chkZaiFlag.Text = "退職者";
            this.chkZaiFlag.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtName.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtName.Location = new System.Drawing.Point(113, 48);
            this.txtName.MaxLength = 20;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(95, 28);
            this.txtName.TabIndex = 108;
            this.txtName.Text = "従業員氏名";
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClear.Location = new System.Drawing.Point(718, 49);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(69, 30);
            this.btnClear.TabIndex = 103;
            this.btnClear.Text = "条件ｸﾘｱ";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(11, 53);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(96, 17);
            this.label15.TabIndex = 107;
            this.label15.Text = "名前(あいまい)";
            // 
            // lblEmployment
            // 
            this.lblEmployment.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblEmployment.Location = new System.Drawing.Point(522, 17);
            this.lblEmployment.Name = "lblEmployment";
            this.lblEmployment.Size = new System.Drawing.Size(116, 27);
            this.lblEmployment.TabIndex = 94;
            this.lblEmployment.Text = "9999";
            this.lblEmployment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDisplay
            // 
            this.btnDisplay.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnDisplay.Location = new System.Drawing.Point(658, 49);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(60, 30);
            this.btnDisplay.TabIndex = 100;
            this.btnDisplay.Text = "表示";
            this.btnDisplay.UseVisualStyleBackColor = true;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // btnSelectEmployment
            // 
            this.btnSelectEmployment.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSelectEmployment.Location = new System.Drawing.Point(442, 16);
            this.btnSelectEmployment.Name = "btnSelectEmployment";
            this.btnSelectEmployment.Size = new System.Drawing.Size(80, 28);
            this.btnSelectEmployment.TabIndex = 93;
            this.btnSelectEmployment.Text = "雇用形態";
            this.btnSelectEmployment.UseVisualStyleBackColor = true;
            this.btnSelectEmployment.Click += new System.EventHandler(this.btnSelectEmployment_Click);
            // 
            // chkProxy
            // 
            this.chkProxy.AutoSize = true;
            this.chkProxy.Location = new System.Drawing.Point(381, 20);
            this.chkProxy.Name = "chkProxy";
            this.chkProxy.Size = new System.Drawing.Size(53, 21);
            this.chkProxy.TabIndex = 89;
            this.chkProxy.Text = "代務";
            this.chkProxy.UseVisualStyleBackColor = true;
            this.chkProxy.CheckedChanged += new System.EventHandler(this.chkProxy_CheckedChanged);
            // 
            // btnSelectOffice
            // 
            this.btnSelectOffice.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSelectOffice.Location = new System.Drawing.Point(14, 15);
            this.btnSelectOffice.Name = "btnSelectOffice";
            this.btnSelectOffice.Size = new System.Drawing.Size(80, 28);
            this.btnSelectOffice.TabIndex = 85;
            this.btnSelectOffice.Text = "所属";
            this.btnSelectOffice.UseVisualStyleBackColor = true;
            this.btnSelectOffice.Click += new System.EventHandler(this.btnSelectOffice_Click);
            // 
            // lblOffice
            // 
            this.lblOffice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOffice.Location = new System.Drawing.Point(94, 15);
            this.lblOffice.Name = "lblOffice";
            this.lblOffice.Size = new System.Drawing.Size(114, 27);
            this.lblOffice.TabIndex = 86;
            this.lblOffice.Text = "9999";
            this.lblOffice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSelectGroup
            // 
            this.btnSelectGroup.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSelectGroup.Location = new System.Drawing.Point(212, 15);
            this.btnSelectGroup.Name = "btnSelectGroup";
            this.btnSelectGroup.Size = new System.Drawing.Size(80, 28);
            this.btnSelectGroup.TabIndex = 87;
            this.btnSelectGroup.Text = "部門";
            this.btnSelectGroup.UseVisualStyleBackColor = true;
            this.btnSelectGroup.Click += new System.EventHandler(this.btnSelectGroup_Click);
            // 
            // lblGroup
            // 
            this.lblGroup.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblGroup.Location = new System.Drawing.Point(292, 16);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(81, 27);
            this.lblGroup.TabIndex = 88;
            this.lblGroup.Text = "9999";
            this.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.Image = global::FlockAppC.Properties.Resources.閉じるA_8p;
            this.btnClose.Location = new System.Drawing.Point(721, 768);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 37);
            this.btnClose.TabIndex = 102;
            this.btnClose.Text = "閉じる";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmMstStaffList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 811);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.dgvList);
            this.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMstStaffList";
            this.Text = "マスターメンテナンス";
            this.Load += new System.EventHandler(this.frmMstStaffList_Load);
            this.Shown += new System.EventHandler(this.frmMstStaffList_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvList;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label Label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkProxy;
        private System.Windows.Forms.Button btnSelectOffice;
        private System.Windows.Forms.Label lblOffice;
        private System.Windows.Forms.Button btnSelectGroup;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.Label lblEmployment;
        private System.Windows.Forms.Button btnSelectEmployment;
        private System.Windows.Forms.Button btnDisplay;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.CheckBox chkZaiFlag;
        internal System.Windows.Forms.ComboBox cmbSort;
        private System.Windows.Forms.Label label1;
    }
}