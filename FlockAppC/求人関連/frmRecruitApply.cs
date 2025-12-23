using FlockAppC.pubClass;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FlockAppC.求人関連
{

    public partial class frmRecruitApply : Form
    {
        public int Id { get; set; }
        public int Header_id { get; set; }
        public int Location_id { get; set; }
        public string Location_name { get; set; }
        public string Location_comment { get; set; }
        public string Publish_name { get; set; }
        public string Publish_date { get; set; }

        private readonly StringBuilder sb = new();

        public frmRecruitApply()
        {
            InitializeComponent();
        }

        private void frmRecruitApply_Load(object sender, EventArgs e)
        {
            InitializeForm();

            // 新規、更新
            if (this.Id != 0)
            {
                // 更新：応募者情報表示
                DisplayApply(this.Id);
                this.lblNew.Visible = false;
                // 採用の場合はボタンを有効
                if (this.chkResult.Checked == true)
                {
                    this.btnRegSystem.Enabled = true;
                }
            }
            else
            {
                this.lblNew.Visible = true;
            }
        }
        /// <summary>
        /// 画面初期化
        /// </summary>
        private void InitializeForm()
        {
            // 掲載情報
            this.txtLocationName.Text = this.Location_name;
            this.txtPublish.Text = this.Publish_name;
            this.mtxtDate.Text = this.Publish_date;

            // 応募者項目
            this.mtxtApplyDate.Text = "    /  /";
            this.txtUserName.Text = "";
            this.txtOld.Text = "";
            this.txtAddress.Text = "";

            this.chkRirekiFlag.Checked = false;
            this.chkCarFlag.Checked = false;

            this.txtTelNo.Text = "";
            this.txtFaxNo.Text = "";
            this.txtMailAddress.Text = "";

            this.mtxtInterviewDate.Text = "    /  /";
            this.mtxtKensinDate.Text = "    /  /";
            this.mtxtInYoteiCompany.Text = "    /  /";
            this.mtxtInCompany.Text = "    /  /";

            this.chkKensinFlag.Checked = false;
            this.chkResult.Checked = false;

            this.txtComment.Text = "";

            this.txtFilePath1.Text = "";
            this.txtFilePath2.Text = "";
        }
        /// <summary>
        /// 応募者情報表示
        /// </summary>
        /// <param name="p_id">ID</param>
        private void DisplayApply(int p_id)
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" header_id");
                    sb.AppendLine(",apply_name");
                    sb.AppendLine(",apply_date");
                    sb.AppendLine(",rireki_flag");
                    sb.AppendLine(",interview_date");
                    sb.AppendLine(",result");
                    sb.AppendLine(",kensin_schedule_date");
                    sb.AppendLine(",kensin_flag");
                    sb.AppendLine(",in_company_schedule_date");
                    sb.AppendLine(",in_company_date");
                    sb.AppendLine(",file_path1");
                    sb.AppendLine(",file_path2");
                    sb.AppendLine(",comment");
                    sb.AppendLine(",old");
                    sb.AppendLine(",address");
                    sb.AppendLine(",tel");
                    sb.AppendLine(",fax");
                    sb.AppendLine(",mail");
                    sb.AppendLine(",car_flag");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Trn_求人応募者");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("id = " + p_id);

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            this.Header_id = int.Parse(dr["header_id"].ToString());
                            this.txtUserName.Text = dr["apply_name"].ToString();
                            // 応募日付
                            if (DateTime.Parse(dr["apply_date"].ToString()).ToString("yyyy/MM/dd") == "1900/01/01") { this.mtxtApplyDate.Text = "    /  "; }
                            else { this.mtxtApplyDate.Text = dr["apply_date"].ToString(); }
                            this.txtOld.Text = dr["old"].ToString();
                            this.txtAddress.Text = dr["address"].ToString();
                            this.txtTelNo.Text = dr["tel"].ToString();
                            this.txtFaxNo.Text = dr["fax"].ToString();
                            this.txtMailAddress.Text = dr["mail"].ToString();
                            // 履歴書有無
                            if (int.Parse(dr["rireki_flag"].ToString()) == 1) { this.chkRirekiFlag.Checked = true; }
                            // 面接日
                            if (DateTime.Parse(dr["interview_date"].ToString()).ToString("yyyy/MM/dd") == "1900/01/01") { this.mtxtInterviewDate.Text = "    /  "; }
                            else { this.mtxtInterviewDate.Text = dr["interview_date"].ToString(); }
                            // 面接結果
                            if (int.Parse(dr["result"].ToString()) == 1) { this.chkResult.Checked = true; }
                            // 健康診断予定日
                            if (DateTime.Parse(dr["kensin_schedule_date"].ToString()).ToString("yyyy/MM/dd") == "1900/01/01") { this.mtxtKensinDate.Text = "    /  "; }
                            else { this.mtxtKensinDate.Text = dr["kensin_schedule_date"].ToString(); }
                            // 健康診断結果受領
                            if (int.Parse(dr["kensin_flag"].ToString()) == 1) { this.chkKensinFlag.Checked = true; }
                            // 入社日
                            if (DateTime.Parse(dr["in_company_schedule_date"].ToString()).ToString("yyyy/MM/dd") == "1900/01/01") { this.mtxtInYoteiCompany.Text = "    /  "; }
                            else { this.mtxtInYoteiCompany.Text = dr["in_company_schedule_date"].ToString(); }
                            if (DateTime.Parse(dr["in_company_date"].ToString()).ToString("yyyy/MM/dd") == "1900/01/01") { this.mtxtInCompany.Text = "    /  "; }
                            else { this.mtxtInCompany.Text = dr["in_company_date"].ToString(); }
                            this.txtComment.Text = dr["comment"].ToString();
                            this.txtFilePath1.Text = dr["file_path1"].ToString();
                            this.txtFilePath2.Text = dr["file_path2"].ToString();
                            // 自通勤
                            if (int.Parse(dr["car_flag"].ToString()) == 1) { this.chkCarFlag.Checked = true; }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 登録ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMenu1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Id == 0)
                {
                    // 新規
                    sb.Clear();
                    sb.AppendLine("INSERT INTO");
                    sb.AppendLine("Trn_求人応募者");
                    sb.AppendLine("(");
                    sb.AppendLine(" header_id");
                    sb.AppendLine(",apply_name");
                    sb.AppendLine(",apply_date");
                    sb.AppendLine(",rireki_flag");
                    sb.AppendLine(",interview_date");
                    sb.AppendLine(",result");
                    sb.AppendLine(",kensin_schedule_date");
                    sb.AppendLine(",kensin_flag");
                    sb.AppendLine(",in_company_schedule_date");
                    sb.AppendLine(",in_company_date");
                    sb.AppendLine(",file_path1");
                    sb.AppendLine(",file_path2");
                    sb.AppendLine(",comment");
                    sb.AppendLine(",interview_date_flag");
                    sb.AppendLine(",kensin_schedule_date_flag");
                    sb.AppendLine(",in_company_schedule_date_flag");
                    sb.AppendLine(",in_company_date_flag");
                    sb.AppendLine(",old");
                    sb.AppendLine(",address");
                    sb.AppendLine(",tel");
                    sb.AppendLine(",fax");
                    sb.AppendLine(",mail");
                    sb.AppendLine(",car_flag");
                    sb.AppendLine(") VALUES (");
                    sb.AppendLine(this.Header_id.ToString());
                    sb.AppendLine(",'" + this.txtUserName.Text + "'");
                    if (this.mtxtApplyDate.Text == "    /  /") { sb.AppendLine(",'1900/01/01'"); }
                    else { sb.AppendLine(",'" + this.mtxtApplyDate.Text + "'"); }
                    if (this.chkRirekiFlag.Checked == true) { sb.AppendLine(",1"); }
                    else { sb.AppendLine(",0"); }
                    if (this.mtxtInterviewDate.Text == "    /  /") { sb.AppendLine(",'1900/01/01'"); }
                    else { sb.AppendLine(",'" + this.mtxtInterviewDate.Text + "'"); }
                    if (this.chkResult.Checked == true) { sb.AppendLine(",1"); }
                    else { sb.AppendLine(",0"); }
                    if (this.mtxtKensinDate.Text == "    /  /") { sb.AppendLine(",'1900/01/01'"); }
                    else { sb.AppendLine(",'" + this.mtxtKensinDate.Text + "'"); }
                    if (this.chkKensinFlag.Checked == true) { sb.AppendLine(",1"); }
                    else { sb.AppendLine(",0"); }
                    if (this.mtxtInYoteiCompany.Text == "    /  /") { sb.AppendLine(",'1900/01/01'"); }
                    else { sb.AppendLine(",'" + this.mtxtInYoteiCompany.Text + "'"); }
                    if (this.mtxtInCompany.Text == "    /  /") { sb.AppendLine(",'1900/01/01'"); }
                    else { sb.AppendLine(",'" + this.mtxtInCompany.Text + "'"); }
                    sb.AppendLine(",'" + this.txtFilePath1.Text + "'");
                    sb.AppendLine(",'" + this.txtFilePath2.Text + "'");
                    sb.AppendLine(",'" + this.txtComment.Text + "'");
                    sb.AppendLine(",0");
                    sb.AppendLine(",0");
                    sb.AppendLine(",0");
                    sb.AppendLine(",0");
                    if (this.txtOld.Text != "") { sb.AppendLine("," + this.txtOld.Text); }
                    else { sb.AppendLine(",NULL"); }
                    sb.AppendLine(",'" + this.txtAddress.Text + "'");
                    sb.AppendLine(",'" + this.txtTelNo.Text + "'");
                    sb.AppendLine(",'" + this.txtFaxNo.Text + "'");
                    sb.AppendLine(",'" + this.txtMailAddress.Text + "'");
                    if (this.chkCarFlag.Checked == true) { sb.AppendLine(",1"); }
                    else { sb.AppendLine(",0"); }
                    sb.AppendLine(")");
                }
                else
                {
                    // 更新
                    sb.Clear();
                    sb.AppendLine("UPDATE");
                    sb.AppendLine("Trn_求人応募者");
                    sb.AppendLine("SET");
                    sb.AppendLine(" apply_name = '" + this.txtUserName.Text + "'");
                    if (this.mtxtApplyDate.Text == "    /  /") { sb.AppendLine(",ApplyDate = '1900/01/01'"); }
                    else { sb.AppendLine(",apply_date = '" + this.mtxtApplyDate.Text + "'"); }
                    if (this.chkRirekiFlag.Checked == true) { sb.AppendLine(",rireki_flag = 1"); }
                    else { sb.AppendLine(",rireki_flag = 0"); }
                    if (this.mtxtInterviewDate.Text == "    /  /") { sb.AppendLine(",interview_date = '1900/01/01'"); }
                    else { sb.AppendLine(",interview_date = '" + this.mtxtInterviewDate.Text + "'"); }
                    if (this.chkResult.Checked == true) { sb.AppendLine(",result = 1"); }
                    else { sb.AppendLine(",result = 0"); }
                    if (this.mtxtKensinDate.Text == "    /  /") { sb.AppendLine(",kensin_schedule_date = '1900/01/01'"); }
                    else { sb.AppendLine(",kensin_schedule_date = '" + this.mtxtKensinDate.Text + "'"); }
                    if (this.chkKensinFlag.Checked == true) { sb.AppendLine(",kensin_flag = 1"); }
                    else { sb.AppendLine(",kensin_flag = 0"); }
                    if (this.mtxtInYoteiCompany.Text == "    /  /") { sb.AppendLine(",in_company_schedule_date = '1900/01/01'"); }
                    else { sb.AppendLine(",in_company_schedule_date = '" + this.mtxtInYoteiCompany.Text + "'"); }
                    if (this.mtxtInCompany.Text == "    /  /") { sb.AppendLine(",in_company_date = '1900/01/01'"); }
                    else { sb.AppendLine(",in_company_date = '" + this.mtxtInCompany.Text + "'"); }
                    sb.AppendLine(",file_path1 = '" + this.txtFilePath1.Text + "'");
                    sb.AppendLine(",file_path2 = '" + this.txtFilePath2.Text + "'");
                    sb.AppendLine(",comment = '" + this.txtComment.Text + "'");
                    sb.AppendLine(",interview_date_flag = 0");
                    sb.AppendLine(",kensin_schedule_date_flag = 0");
                    sb.AppendLine(",in_company_sSchedule_date_flag = 0");
                    sb.AppendLine(",in_company_date_flag = 0");
                    if (this.txtOld.Text != "") { sb.AppendLine(",old = " + this.txtOld.Text); }
                    else { sb.AppendLine(",old = NULL"); }
                    sb.AppendLine(",address = '" + this.txtAddress.Text + "'");
                    sb.AppendLine(",tel = '" + this.txtTelNo.Text + "'");
                    sb.AppendLine(",fax = '" + this.txtFaxNo.Text + "'");
                    sb.AppendLine(",mail = '" + this.txtMailAddress.Text + "'");
                    if (this.chkCarFlag.Checked == true) { sb.AppendLine(",car_flag = 1"); }
                    else { sb.AppendLine(",car_flag = 0"); }
                    sb.AppendLine("WHERE");
                    sb.AppendLine("id = " + this.Id);
                }

                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    clsSqlDb.DMLUpdate(sb.ToString());
                }
                MessageBox.Show("登録しました。", "結果", MessageBoxButtons.OK);
                this.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 削除ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMenu3_Click(object sender, EventArgs e)
        {
            if (this.Id == 0) return;

            if (MessageBox.Show("削除しますか？。", "確認", MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;

            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("DELETE");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Trn_求人応募者");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("id = " + this.Id);

                    // cls.Sql = st.ToString();
                    // cls.DMLUpdate();
                    clsSqlDb.DMLUpdate(sb.ToString());
                }
                MessageBox.Show("削除しました。", "結果", MessageBoxButtons.OK);
                this.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        private void btnMenu10_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 表示ボタン１
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisplay1_Click(object sender, EventArgs e)
        {
            using (ClsPreview cls = new())
            {
                cls.File_name = this.txtFilePath1.Text;
                if (cls.CheckFile() != true) return;
                cls.PreviewFile();
            }
        }
        /// <summary>
        /// 表示ボタン２
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisplay2_Click(object sender, EventArgs e)
        {
            using (ClsPreview cls = new())
            {
                cls.File_name = this.txtFilePath2.Text;
                if (cls.CheckFile() != true) return;
                cls.PreviewFile();
            }
        }
        /// <summary>
        /// ファイル選択ボタン１
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect1_Click(object sender, EventArgs e)
        {
            string path = "";
            string file = "";
            string select = "";

            if (this.txtFilePath1.Text.Length > 3)
            {
                ClsPublic.SeparateFilePath(this.txtFilePath1.Text, ref path, ref file);
                select = ClsPublic.SelectFileDialog(path);
                if (select.Length != 0) { this.txtFilePath1.Text = select; }
            }
            else
            {
                select = ClsPublic.SelectFileDialog(@"C:\");
                this.txtFilePath1.Text = select;
            }

        }
        /// <summary>
        /// ファイル選択ボタン２
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect2_Click(object sender, EventArgs e)
        {
            string path = "";
            string file = "";
            string select = "";

            if (this.txtFilePath2.Text.Length > 3)
            {
                ClsPublic.SeparateFilePath(this.txtFilePath2.Text, ref path, ref file);
                select = ClsPublic.SelectFileDialog(path);
                if (select.Length != 0) { this.txtFilePath2.Text = select; }
            }
            else
            {
                select = ClsPublic.SelectFileDialog(@"C:\");
                this.txtFilePath2.Text = select;
            }

        }
        /// <summary>
        /// 採用チェックボックスイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkResult_CheckedChanged(object sender, EventArgs e)
        {
            // 採用チェックボックスONの場合、システム登録ボタンを有効にする
            if (this.chkResult.Checked == true)
            {
                this.btnRegSystem.Enabled = true;
            }
            else
            {
                this.btnRegSystem.Enabled = false;
            }
        }
        /// <summary>
        /// フォーム表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmRecruitApply_Shown(object sender, EventArgs e)
        {
            // 日付にフォーカス
            this.mtxtApplyDate.Focus();
        }
    }
}
