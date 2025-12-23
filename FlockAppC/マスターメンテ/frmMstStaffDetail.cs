using FlockAppC.pubClass;
using FlockAppC.tblClass;
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FlockAppC.マスターメンテ
{
    public partial class frmMstStaffDetail : Form
    {
        public int Id { get; set; }
        public string StaffName { get; set; }
        public string OfficeName { get; set; }
        public string GroupName { get; set; }
        public string LocationName { get; set; }
        public int ProxyFlag { get; set; }

        private readonly StringBuilder sb = new();

        public frmMstStaffDetail()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 保存ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReg_Click(object sender, EventArgs e)
        {
            if (Id == 0) return;

            ClsMstStaffDetail cMstStaffDetail = new();
            cMstStaffDetail.Id = Id;

            // 2025/08/13 ADD
            if (this.mtxtEntryCompany.Text == "    /  /")
            {
                cMstStaffDetail.EntryCompany = DateTime.Parse("1900/01/01");
            }
            else
            {
                cMstStaffDetail.EntryCompany = DateTime.Parse(this.mtxtEntryCompany.Text);
            }
            if (this.mtxtLeavingCompany.Text == "    /  /")
            {
                cMstStaffDetail.LeavingCompany = DateTime.Parse("1900/01/01");
            }
            else
            {
                cMstStaffDetail.LeavingCompany = DateTime.Parse(this.mtxtLeavingCompany.Text);
            }

            cMstStaffDetail.ZipCode1 = this.txtZipCode1.Text;
            cMstStaffDetail.ZipCode2 = this.txtZipCode2.Text;
            cMstStaffDetail.Address1 = this.txtAddress1.Text;
            cMstStaffDetail.Address2 = this.txtAddress2.Text;
            cMstStaffDetail.TelNo = this.txtTelNo.Text;
            cMstStaffDetail.MobileNo = this.txtMobileNo.Text;
            cMstStaffDetail.FaxNo = this.txtFaxNo.Text;
            cMstStaffDetail.MailAddress = this.txtMailAddress.Text;
            if (this.mtxtBirthday.Text == "    /  /")
            {
                cMstStaffDetail.Birthday = DateTime.Parse("1900/01/01");
                cMstStaffDetail.Old = 0;
            }
            else
            {
                cMstStaffDetail.Birthday = DateTime.Parse(this.mtxtBirthday.Text);
                // 年齢算出
                cMstStaffDetail.Old = ClsPublic.CalcOld(cMstStaffDetail.Birthday, DateTime.Now);
            }
            // cMstStaffDetail.Old = int.Parse(lblOld.Text);
            if (this.txtCapaYear1.Text != "") { cMstStaffDetail.CapaYear1 = int.Parse(this.txtCapaYear1.Text); }
            if (this.txtCapaYear2.Text != "") { cMstStaffDetail.CapaYear2 = int.Parse(this.txtCapaYear2.Text); }
            if (this.txtCapaYear3.Text != "") { cMstStaffDetail.CapaYear3 = int.Parse(this.txtCapaYear3.Text); }
            if (this.txtCapaYear4.Text != "") { cMstStaffDetail.CapaYear4 = int.Parse(this.txtCapaYear4.Text); }
            if (this.txtCapaYear5.Text != "") { cMstStaffDetail.CapaYear5 = int.Parse(this.txtCapaYear5.Text); }
            if (this.txtCapaMonth1.Text != "") { cMstStaffDetail.CapaMonth1 = int.Parse(this.txtCapaMonth1.Text); }
            if (this.txtCapaMonth2.Text != "") { cMstStaffDetail.CapaMonth2 = int.Parse(this.txtCapaMonth2.Text); }
            if (this.txtCapaMonth3.Text != "") { cMstStaffDetail.CapaMonth3 = int.Parse(this.txtCapaMonth3.Text); }
            if (this.txtCapaMonth4.Text != "") { cMstStaffDetail.CapaMonth4 = int.Parse(this.txtCapaMonth4.Text); }
            if (this.txtCapaMonth5.Text != "") { cMstStaffDetail.CapaMonth5 = int.Parse(this.txtCapaMonth5.Text); }
            cMstStaffDetail.Capa1 = this.txtCapa1.Text;
            cMstStaffDetail.Capa2 = this.txtCapa2.Text;
            cMstStaffDetail.Capa3 = this.txtCapa3.Text;
            cMstStaffDetail.Capa4 = this.txtCapa4.Text;
            cMstStaffDetail.Capa5 = this.txtCapa5.Text;
            cMstStaffDetail.Comment = this.txtComment.Text;
            if (this.chkCar.Checked) { cMstStaffDetail.CarFlag = ClsPublic.FLAG_ON; }
            cMstStaffDetail.Station = this.txtStation.Text;

            // パス付きファイル名→パスとファイルに分ける
            string path = "";
            string file = "";
            if (this.txtAppended1.Text.Length > 3)
            {
                ClsPublic.SeparateFilePath(this.txtAppended1.Text, ref path, ref file);
                cMstStaffDetail.AppendedPath1 = path;
                cMstStaffDetail.AppendedFile1 = file;
            }
            if (this.txtAppended2.Text.Length > 3)
            {
                ClsPublic.SeparateFilePath(this.txtAppended2.Text, ref path, ref file);
                cMstStaffDetail.AppendedPath2 = path;
                cMstStaffDetail.AppendedFile2 = file;
            }

            cMstStaffDetail.Update();

            MessageBox.Show("保存しました。", "結果", MessageBoxButtons.OK);
            this.Close();
        }
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMstStaffDetail_Load(object sender, EventArgs e)
        {
            // 画面クリア
            InitializeForm();

            // IDから詳細情報を読み込む
            ClsMstStaffDetail cMstStaffDetail = new();
            cMstStaffDetail.Select(Id);

            // 詳細が登録されていない場合は登録する
            if (cMstStaffDetail.Id == 0)
            {
                // 登録
                cMstStaffDetail.Id = Id;        // 親画面で編集中の社員ID
                cMstStaffDetail.Insert();
            }
            DisplayForm(cMstStaffDetail);

            // フォーム表示位置
            this.Location = new Point(0, 0);
        }
        /// <summary>
        /// 画面クリア
        /// </summary>
        private void InitializeForm()
        {
            this.lblStaffId.Text = "";
            this.lblStaffName.Text = "";
            this.lblOffice.Text = "";
            this.lblGroup.Text = "";
            this.lblLocation.Text = "";
            this.lblProxy.Image = null;

            this.mtxtBirthday.Text = "";
            this.lblOld.Text = "";
            this.txtZipCode1.Text = "";
            this.txtZipCode2.Text = "";
            this.txtAddress1.Text = "";
            this.txtAddress2.Text = "";
            this.txtTelNo.Text = "";
            this.txtMobileNo.Text = "";
            this.txtFaxNo.Text = "";
            this.txtStation.Text = "";
            this.chkCar.Checked = false;

            // 2025/08/13 ADD
            this.mtxtEntryCompany.Text = "";
            this.mtxtLeavingCompany.Text = "";

            this.txtCapaYear1.Text = "";
            this.txtCapaMonth1.Text = "";
            this.txtCapa1.Text = "";
            this.txtCapaYear2.Text = "";
            this.txtCapaMonth2.Text = "";
            this.txtCapa2.Text = "";
            this.txtCapaYear3.Text = "";
            this.txtCapaMonth3.Text = "";
            this.txtCapa3.Text = "";
            this.txtCapaYear4.Text = "";
            this.txtCapaMonth4.Text = "";
            this.txtCapa4.Text = "";
            this.txtCapaYear5.Text = "";
            this.txtCapaMonth5.Text = "";
            this.txtCapa5.Text = "";

            this.txtComment.Text = "";
            this.txtAppended1.Text = "";
            this.txtAppended2.Text = "";
        }
        /// <summary>
        /// 詳細情報を画面表示
        /// </summary>
        /// <param name="p_cls"></param>
        private void DisplayForm(ClsMstStaffDetail p_cls)
        {
            this.lblStaffId.Text = p_cls.Id.ToString();
            this.lblStaffName.Text = StaffName;
            this.lblOffice.Text = OfficeName;
            this.lblGroup.Text = GroupName;
            this.lblLocation.Text = "";                     // 未使用
            if (ProxyFlag == ClsPublic.FLAG_ON) { this.lblProxy.Image = Properties.Resources.チェックマーク_小; }
            else { this.lblProxy.Image = null; }
            if (p_cls.Birthday.ToString("yyyy/MM/dd") == "1900/01/01")
            { 
                this.mtxtBirthday.Text = "    /  /"; 
            }
            else
            { 
                this.mtxtBirthday.Text = p_cls.Birthday.ToString("yyyy/MM/dd");
                this.lblOld.Text = ClsPublic.CalcOld(p_cls.Birthday, DateTime.Today).ToString();
            }
            // if (p_cls.Old != 0) { this.lblOld.Text = p_cls.Old.ToString(); }
            this.txtZipCode1.Text = p_cls.ZipCode1;
            this.txtZipCode2.Text = p_cls.ZipCode2;
            this.txtAddress1.Text = p_cls.Address1;
            this.txtAddress2.Text = p_cls.Address2;
            this.txtTelNo.Text = p_cls.TelNo;
            this.txtMobileNo.Text = p_cls.MobileNo;
            this.txtFaxNo.Text = p_cls.FaxNo;
            this.txtMailAddress.Text = p_cls.MailAddress;
            this.txtStation.Text = p_cls.Station;

            // 2025/08/13 ADD
            if (p_cls.EntryCompany.ToString("yyyy/MM/dd") == "1900/01/01")
            {
                this.mtxtEntryCompany.Text = "    /  /";
            }
            else
            {
                this.mtxtEntryCompany.Text = p_cls.EntryCompany.ToString("yyyy/MM/dd");
            }

            if (p_cls.CarFlag == 1) { this.chkCar.Checked = true; }
            else { this.chkCar.Checked = false; }
            if (p_cls.CapaYear1 != 0) { this.txtCapaYear1.Text = p_cls.CapaYear1.ToString(); }
            if (p_cls.CapaMonth1 != 0) { this.txtCapaMonth1.Text = p_cls.CapaMonth1.ToString(); }
            this.txtCapa1.Text = p_cls.Capa1;
            if (p_cls.CapaYear2 != 0) { this.txtCapaYear2.Text = p_cls.CapaYear2.ToString(); }
            if (p_cls.CapaMonth2 != 0) { this.txtCapaMonth2.Text = p_cls.CapaMonth2.ToString(); }
            this.txtCapa2.Text = p_cls.Capa2;
            if (p_cls.CapaYear3 != 0) { this.txtCapaYear3.Text = p_cls.CapaYear3.ToString(); }
            if (p_cls.CapaMonth3 != 0) { this.txtCapaMonth3.Text = p_cls.CapaMonth3.ToString(); }
            this.txtCapa3.Text = p_cls.Capa3;
            if (p_cls.CapaYear4 != 0) { this.txtCapaYear4.Text = p_cls.CapaYear4.ToString(); }
            if (p_cls.CapaMonth4 != 0) { this.txtCapaMonth4.Text = p_cls.CapaMonth4.ToString(); }
            this.txtCapa4.Text = p_cls.Capa4;
            if (p_cls.CapaYear5 != 0) { this.txtCapaYear5.Text = p_cls.CapaYear5.ToString(); }
            if (p_cls.CapaMonth5 != 0) { this.txtCapaMonth5.Text = p_cls.CapaMonth5.ToString(); }
            this.txtCapa5.Text = p_cls.Capa5;
            this.txtComment.Text = p_cls.Comment;
            if (p_cls.AppendedPath1.Length != 0) { this.txtAppended1.Text = p_cls.AppendedPath1 + "\\" + p_cls.AppendedFile1; }
            if (p_cls.AppendedPath2.Length != 0) { this.txtAppended2.Text = p_cls.AppendedPath2 + "\\" + p_cls.AppendedFile2; }
        }
        /// <summary>
        /// 閉じるボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 生年月日入力変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mtxtBirthday_TextChanged(object sender, EventArgs e)
        {
            DateTime wk = DateTime.Now;
            if (DateTime.TryParse(this.mtxtBirthday.Text,out wk) == true)
            {
                // 年齢算出
                this.lblOld.Text = ClsPublic.CalcOld(DateTime.Parse(this.mtxtBirthday.Text), DateTime.Now).ToString();
            }

        }
        /// <summary>
        /// 添付ファイル選択ボタン１
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectFile1_Click(object sender, EventArgs e)
        {
            string path = "";
            string file = "";
            string select = "";

            if (this.txtAppended1.Text.Length > 3)
            {
                ClsPublic.SeparateFilePath(this.txtAppended1.Text, ref path, ref file);
                select = ClsPublic.SelectFileDialog(path);
                if (select.Length != 0) { this.txtAppended1.Text = select; }
            }
            else
            {
                select = ClsPublic.SelectFileDialog(@"C:\");
                this.txtAppended1.Text = select;
            }
        }
        /// <summary>
        /// 添付ファイル選択ボタン２
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectFile2_Click(object sender, EventArgs e)
        {
            string path = "";
            string file = "";
            string select = "";

            if (this.txtAppended2.Text.Length > 3)
            {
                ClsPublic.SeparateFilePath(this.txtAppended2.Text, ref path, ref file);
                select = ClsPublic.SelectFileDialog(path);
                if (select.Length != 0) { this.txtAppended2.Text = select; }
            }
            else
            {
                select = ClsPublic.SelectFileDialog(@"C:\");
                this.txtAppended2.Text = select;
            }
        }

        private void btnDisplayFile1_Click(object sender, EventArgs e)
        {

        }
    }
}
