using DocumentFormat.OpenXml.Spreadsheet;
using FlockAppC.pubClass;
using FlockAppC.tblClass;
using FlockAppC.選択画面;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FlockAppC.マスターメンテ
{
    public partial class frmMstStaff : Form
    {
        #region "プロパティ"
        public int List_Staff_Id { get; set; }
        public int Staff_Id { get; set; }
        public int Employment_Id { get; set; }
        public int Group_Id { get; set; }
        public int Office_Id { get; set; }
        public int Location1_Id { get; set; }
        public int Location2_Id { get; set; }
        public int Location3_Id { get; set; }
        public int Location4_Id { get; set; }
        public int Location5_Id { get; set; }
        public int Location6_Id { get; set; }
        public int Location7_Id { get; set; }
        public int Location8_Id { get; set; }
        public int Location9_Id { get; set; }
        public int Location10_Id { get; set; }

        // 2025/08/13 ADD
        public int Location11_Id { get; set; }
        public int Location12_Id { get; set; }
        public int Location13_Id { get; set; }
        public int Location14_Id { get; set; }
        public int Location15_Id { get; set; }

        public int Car_Id { get; set; }

        private readonly StringBuilder sb = new();

        #endregion

        public frmMstStaff()
        {
            InitializeComponent();
        }
        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMstStaff_Load(object sender, EventArgs e)
        {
            // 初期表示時は新規モード
            this.lblNew.Visible = true;

            // フォーム初期化
            InitializeForm();

            // コントロール制御
            ControllObject();

            // 一覧画面からの遷移の場合、担当者情報を表示
            if(List_Staff_Id > 0)
            {
                // 画面表示
                this.lblNew.Visible = false;

                // frmSelectStaff fSelectStaff = new();

                ClsMstStaff cMstStaff = new();

                Staff_Id = List_Staff_Id;

                cMstStaff.Id = List_Staff_Id;

                cMstStaff.GetStaff();

                DisplayStaff(cMstStaff);
            }

            // フォーム表示位置
            this.Location = new Point(0, 0);
        }

        /// <summary>
        /// 権限によってコントロールを制御
        /// </summary>
        private void ControllObject()
        {
            if ( ClsLoginUser.MasterMenteFlag != 1)
            {
                // 権限なし
                this.btnReg.Enabled = false;
                this.btnNew.Enabled = false;
                this.btnDelete.Enabled = false;
                this.txtPassword.Visible = false;
                this.lblPasswordComment.Visible = false;
            }
            else
            {
                // 権限あり
                this.btnReg.Enabled = true;
                this.btnNew.Enabled = true;
                this.btnDelete.Enabled = true;
                this.txtPassword.Visible = true;
                this.lblPasswordComment.Visible = true;
            }
        }

        /// <summary>
        /// 各コントロールクリア
        /// </summary>
        private void InitializeForm()
        {
            // property
            this.Staff_Id = 0;
            this.Car_Id = 0;
            this.Group_Id = 0;
            this.Office_Id = 0;
            this.Employment_Id = 0;
            this.Location1_Id = 0;
            this.Location2_Id = 0;
            this.Location3_Id = 0;
            this.Location4_Id = 0;
            this.Location5_Id = 0;
            this.Location6_Id = 0;
            this.Location7_Id = 0;
            this.Location8_Id = 0;
            this.Location9_Id = 0;
            this.Location10_Id = 0;
            // 2025/08/13 ADD
            this.Location11_Id = 0;
            this.Location12_Id = 0;
            this.Location13_Id = 0;
            this.Location14_Id = 0;
            this.Location15_Id = 0;

            this.lblStaffId.Text = "";
            this.txtStaffName1.Text = "";
            this.txtStaffName2.Text = "";
            this.txtKana1.Text = "";
            this.txtKana2.Text = "";

            // 2025/08/13 DELETE
            // this.mtxtEntryCompany.Text = "____/__/__";
            // this.mtxtLeavingCompany.Text = "____/__/__";

            this.lblEmployment.Text = "";
            this.txtComment.Text = "";
            this.lblOffice.Text = "";
            this.lblGroup.Text = "";
            this.chkProxy.Checked = false;
            this.chkPositionFlag.Checked = false;

            this.lblLocation1.Text = "";
            this.chkLocationManager1.Checked = false;
            this.lblLocation2.Text = "";
            this.chkLocationManager2.Checked = false;
            this.lblLocation3.Text = "";
            this.chkLocationManager3.Checked = false;
            this.lblLocation4.Text = "";
            this.chkLocationManager4.Checked = false;
            this.lblLocation5.Text = "";
            this.chkLocationManager5.Checked = false;
            this.lblLocation6.Text = "";
            this.chkLocationManager6.Checked = false;
            this.lblLocation7.Text = "";
            this.chkLocationManager7.Checked = false;
            this.lblLocation8.Text = "";
            this.chkLocationManager8.Checked = false;
            this.lblLocation9.Text = "";
            this.chkLocationManager9.Checked = false;
            this.lblLocation10.Text = "";
            this.chkLocationManager10.Checked = false;

            // 2025/08/13 ADD
            this.lblLocation11.Text = "";
            this.chkLocationManager11.Checked = false;
            this.lblLocation12.Text = "";
            this.chkLocationManager12.Checked = false;
            this.lblLocation13.Text = "";
            this.chkLocationManager13.Checked = false;
            this.lblLocation14.Text = "";
            this.chkLocationManager14.Checked = false;
            this.lblLocation15.Text = "";
            this.chkLocationManager15.Checked = false;

            this.chkZai.Checked = true;
            this.txtPassword.Text = "";
            this.txtLoginSort.Text = "";
            this.txtSort.Text = "";
            // this.chkAttSubjectFlag.Checked = false;      2025/12/24 DEL
            // this.chkTask.Checked = false;                2025/12/24 DEL
            this.lblCarNo.Text = "";
            this.lblCarName.Text = "";
            this.lblRegNo.Text = "";

            this.chkConfirm.Checked = false;
            this.chkMaster.Checked = false;
            this.chkCarManage.Checked = false;
            // this.chkAttendance.Checked = false;                  // 2025/12/24 DEL
            this.chkSystemControll.Checked = false;
            this.chkReportManage.Checked = false;                   // 2024/12/16 ADD
            this.chkRecruitManage.Checked = false;                  // 2024/12/16 ADD
            this.chkReportConfirm.Checked = false;                  // 2025/10/28 ADD
        }
        /// <summary>
        /// 従業員選択ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectStaff_Click(object sender, EventArgs e)
        {
            frmSelectStaff fSelectStaff = new()
            {
                TargetTable = "Mst_社員",
                Select_user_name = "",
                Select_user_id = 0
            };
            fSelectStaff.ShowDialog();
            if (fSelectStaff.Select_user_id == 0) { return; }

            // 選択従業員情報取得
            this.lblNew.Visible = false;
            ClsMstStaff cMstStaff = new()
            {
                Id = fSelectStaff.Select_user_id
            };
            cMstStaff.GetStaff();
            DisplayStaff(cMstStaff);
        }
        /// <summary>
        /// 従業員情報表示
        /// </summary>
        /// <param name="cMstStaff">従業員情報</param>
        private void DisplayStaff(ClsMstStaff cMstStaff)
        {
            // フォーム初期化
            InitializeForm();

            this.Staff_Id = cMstStaff.Id;                                               // 従業員ID（プロパティ値）
            this.lblStaffId.Text = cMstStaff.Id.ToString();                             // ID
            this.txtStaffName1.Text = cMstStaff.FullName;                               // 従業員氏名（フルネーム）
            this.txtStaffName2.Text = cMstStaff.Name1;                                  // 従業員氏名（苗字）
            this.txtKana1.Text = cMstStaff.Kana1;                                       // 従業員氏名（ｶﾅ　先頭1文字）
            this.txtKana2.Text = cMstStaff.Kana2;                                       // 従業員氏名（ｶﾅ　苗字）
            // this.txtKana2.Text = cMstStaff.FullKana;                                    // 従業員氏名（ｶﾅ　フルネーム）

            // 在席フラグ
            if (cMstStaff.ZaiFlag == ClsPublic.FLAG_ON) { this.chkZai.Checked = true; }
            else { this.chkZai.Checked = false; }

            // 2025/08/13 DELETE
            // 入社日
            // if (cMstStaff.EntryCompany.ToString("yyyy/MM/dd") != "1900/01/01") { this.mtxtEntryCompany.Text = cMstStaff.EntryCompany.ToString("yyyy/MM/dd"); }
            // else { this.mtxtEntryCompany.Text = "____/__/__"; }

            // 2025/08/13 DELETE
            // 退社日
            // if (cMstStaff.LeavingCompany.ToString("yyyy/MM/dd") != "1900/01/01") { this.mtxtLeavingCompany.Text = cMstStaff.LeavingCompany.ToString("yyyy/MM/dd"); }
            // else { this.mtxtLeavingCompany.Text = "____/__/__"; }

            // 雇用形態
            this.lblEmployment.Text = cMstStaff.KbnName;
            this.Employment_Id = cMstStaff.Kbn;
            // this.lblEmploymentId.Text = cMstStaff.Kbn.ToString();

            // 備考
            this.txtComment.Text = cMstStaff.Comment;

            // 所属
            this.lblOffice.Text = cMstStaff.OfficeName;
            this.Office_Id = cMstStaff.OfficeID;
            // this.lblOfficeId.Text = cMstStaff.OfficeID.ToString();

            // 部門
            this.lblGroup.Text = cMstStaff.GroupName;
            this.Group_Id = cMstStaff.GroupID;
            // this.lblAffiliationId.Text = cMstStaff.AffiliationID.ToString();

            // 代務フラグ
            if (cMstStaff.ProxyFlag == ClsPublic.FLAG_ON) { this.chkProxy.Checked = true; }
            else { this.chkProxy.Checked = false; }

            // ポジションフラグ
            if (cMstStaff.PositionFlag == ClsPublic.FLAG_ON) { this.chkPositionFlag.Checked = true; }
            else { this.chkPositionFlag.Checked = false; }

            // 専従先専従者
            DisplayLocationStaff(cMstStaff);

            // パスワード
            this.txtPassword.Text = cMstStaff.ConfirmPass;

            // 並び
            this.txtLoginSort.Text = cMstStaff.RegSort.ToString();
            this.txtSort.Text = cMstStaff.Sort.ToString();

            // 勤怠表対象フラグ、タスク表示対象フラグ  2025/12/24 DEL
            // if (cMstStaff.AttSubjectFlag == ClsPublic.FLAG_ON) { this.chkAttSubjectFlag.Checked = true; }
            // else { this.chkAttSubjectFlag.Checked = false; }

            // if (cMstStaff.TaskFlag == ClsPublic.FLAG_ON) { this.chkTask.Checked = true; }
            // else { this.chkTask.Checked = false; }

            // 社用車
            this.Car_Id = cMstStaff.CarID;
            // this.lblCarId.Text=cMstStaff.CarID.ToString();
            this.lblCarNo.Text = cMstStaff.CarNo;
            this.lblCarName.Text = cMstStaff.CarName;
            this.lblRegNo.Text = cMstStaff.RegNo;

            // 各権限
            if (cMstStaff.ConfirmFlag == ClsPublic.FLAG_ON) { this.chkConfirm.Checked = true; }
            else { this.chkConfirm.Checked = false; }

            if (cMstStaff.MasterMenteFlag == ClsPublic.FLAG_ON) { this.chkMaster.Checked = true; }
            else { this.chkMaster.Checked = false; }

            if (cMstStaff.CarManageFlag == ClsPublic.FLAG_ON) { this.chkCarManage.Checked = true; }
            else { this.chkCarManage.Checked = false; }

            // 2025/12/24 DEL
            // if (cMstStaff.AttendanceFlag == ClsPublic.FLAG_ON) { this.chkAttendance.Checked = true; }
            // else { this.chkAttendance.Checked = false; }

            if (cMstStaff.SystemControlFlag == ClsPublic.FLAG_ON) { this.chkSystemControll.Checked = true; }
            else { this.chkSystemControll.Checked = false; }

            // 2024/12/16 ADD
            if (cMstStaff.ReportManageFlag == ClsPublic.FLAG_ON) { this.chkReportManage.Checked = true; }
            else { this.chkReportManage.Checked = false; }

            // 2024/12/16 ADD
            if (cMstStaff.RecruitManageFlag == ClsPublic.FLAG_ON) { this.chkRecruitManage.Checked = true; }
            else { this.chkRecruitManage.Checked = false; }

            // 2025/10/28 ADD
            if (cMstStaff.ReportConfirmFlag == ClsPublic.FLAG_ON) { this.chkReportConfirm.Checked = true; }
            else { this.chkReportConfirm.Checked = false; }

            //// 権限によってコントロールEnableを制御
            //if (cMstStaff.MasterMenteFlag != 1)
            //{
            //    // マスターメンテ権限なし
            //}
        }
        /// <summary>
        /// 専従先の従業員表示
        /// </summary>
        /// <param name="cMstStaff"></param>
        private void DisplayLocationStaff(ClsMstStaff cMstStaff)
        {
            int i = 1;

            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("Mst_専従先専従者.location_id");
                    sb.AppendLine(",Mst_専従先専従者.staff_id");
                    sb.AppendLine(",Mst_専従先.fullname");
                    sb.AppendLine(",Mst_専従先.instructor_id");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_専従先専従者");
                    sb.AppendLine("LEFT JOIN");
                    sb.AppendLine("Mst_専従先");
                    sb.AppendLine("ON");
                    sb.AppendLine("Mst_専従先専従者.location_id = Mst_専従先.location_id");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("Mst_専従先専従者.staff_id = " + cMstStaff.Id);
                    sb.AppendLine("ORDER BY");
                    sb.AppendLine("Mst_専従先.location_id");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            switch (i)
                            {
                                case 1:
                                    this.lblLocation1.Text = dr["fullname"].ToString();
                                    this.Location1_Id = int.Parse(dr["location_id"].ToString());
                                    // this.lblLocation1Id.Text = dr["LocationId"].ToString();
                                    if (int.Parse(dr["instructor_id"].ToString()) == cMstStaff.Id) { this.chkLocationManager1.Checked = true; }
                                    else { this.chkLocationManager1.Checked = false; }
                                    break;
                                case 2:
                                    this.lblLocation2.Text = dr["fullname"].ToString();
                                    this.Location2_Id = int.Parse(dr["location_id"].ToString());
                                    // this.lblLocation2Id.Text = dr["LocationId"].ToString();
                                    if (int.Parse(dr["instructor_id"].ToString()) == cMstStaff.Id) { this.chkLocationManager2.Checked = true; }
                                    else { this.chkLocationManager2.Checked = false; }
                                    break;
                                case 3:
                                    this.lblLocation3.Text = dr["fullname"].ToString();
                                    this.Location3_Id = int.Parse(dr["location_id"].ToString());
                                    // this.lblLocation3Id.Text = dr["LocationId"].ToString();
                                    if (int.Parse(dr["instructor_id"].ToString()) == cMstStaff.Id) { this.chkLocationManager3.Checked = true; }
                                    else { this.chkLocationManager3.Checked = false; }
                                    break;
                                case 4:
                                    this.lblLocation4.Text = dr["fullname"].ToString();
                                    this.Location4_Id = int.Parse(dr["location_id"].ToString());
                                    // this.lblLocation4Id.Text = dr["LocationId"].ToString();
                                    if (int.Parse(dr["instructor_id"].ToString()) == cMstStaff.Id) { this.chkLocationManager4.Checked = true; }
                                    else { this.chkLocationManager4.Checked = false; }
                                    break;
                                case 5:
                                    this.lblLocation5.Text = dr["fullname"].ToString();
                                    this.Location5_Id = int.Parse(dr["location_id"].ToString());
                                    // this.lblLocation5Id.Text = dr["LocationId"].ToString();
                                    if (int.Parse(dr["instructor_id"].ToString()) == cMstStaff.Id) { this.chkLocationManager5.Checked = true; }
                                    else { this.chkLocationManager5.Checked = false; }
                                    break;
                                case 6:
                                    this.lblLocation6.Text = dr["fullname"].ToString();
                                    this.Location6_Id = int.Parse(dr["location_id"].ToString());
                                    // this.lblLocation6Id.Text = dr["LocationId"].ToString();
                                    if (int.Parse(dr["instructor_id"].ToString()) == cMstStaff.Id) { this.chkLocationManager6.Checked = true; }
                                    else { this.chkLocationManager6.Checked = false; }
                                    break;
                                case 7:
                                    this.lblLocation7.Text = dr["fullname"].ToString();
                                    this.Location7_Id = int.Parse(dr["location_id"].ToString());
                                    // this.lblLocation7Id.Text = dr["LocationId"].ToString();
                                    if (int.Parse(dr["instructor_id"].ToString()) == cMstStaff.Id) { this.chkLocationManager7.Checked = true; }
                                    else { this.chkLocationManager7.Checked = false; }
                                    break;
                                case 8:
                                    this.lblLocation8.Text = dr["fullname"].ToString();
                                    this.Location8_Id = int.Parse(dr["location_id"].ToString());
                                    // this.lblLocation8Id.Text = dr["LocationId"].ToString();
                                    if (int.Parse(dr["instructor_id"].ToString()) == cMstStaff.Id) { this.chkLocationManager8.Checked = true; }
                                    else { this.chkLocationManager8.Checked = false; }
                                    break;
                                case 9:
                                    this.lblLocation9.Text = dr["fullname"].ToString();
                                    this.Location9_Id = int.Parse(dr["location_id"].ToString());
                                    // this.lblLocation9Id.Text = dr["LocationId"].ToString();
                                    if (int.Parse(dr["instructor_id"].ToString()) == cMstStaff.Id) { this.chkLocationManager9.Checked = true; }
                                    else { this.chkLocationManager9.Checked = false; }
                                    break;
                                case 10:
                                    this.lblLocation10.Text = dr["fullname"].ToString();
                                    this.Location10_Id = int.Parse(dr["location_id"].ToString());
                                    // this.lblLocation10Id.Text = dr["LocationId"].ToString();
                                    if (int.Parse(dr["instructor_id"].ToString()) == cMstStaff.Id) { this.chkLocationManager10.Checked = true; }
                                    else { this.chkLocationManager10.Checked = false; }
                                    break;

                                // 2025/08/13 ADD
                                case 11:
                                    this.lblLocation11.Text = dr["fullname"].ToString();
                                    this.Location11_Id = int.Parse(dr["location_id"].ToString());
                                    if (int.Parse(dr["instructor_id"].ToString()) == cMstStaff.Id) { this.chkLocationManager11.Checked = true; }
                                    else { this.chkLocationManager11.Checked = false; }
                                    break;
                                case 12:
                                    this.lblLocation12.Text = dr["fullname"].ToString();
                                    this.Location12_Id = int.Parse(dr["location_id"].ToString());
                                    if (int.Parse(dr["instructor_id"].ToString()) == cMstStaff.Id) { this.chkLocationManager12.Checked = true; }
                                    else { this.chkLocationManager12.Checked = false; }
                                    break;
                                case 13:
                                    this.lblLocation13.Text = dr["fullname"].ToString();
                                    this.Location13_Id = int.Parse(dr["location_id"].ToString());
                                    if (int.Parse(dr["instructor_id"].ToString()) == cMstStaff.Id) { this.chkLocationManager13.Checked = true; }
                                    else { this.chkLocationManager13.Checked = false; }
                                    break;
                                case 14:
                                    this.lblLocation14.Text = dr["fullname"].ToString();
                                    this.Location14_Id = int.Parse(dr["location_id"].ToString());
                                    if (int.Parse(dr["instructor_id"].ToString()) == cMstStaff.Id) { this.chkLocationManager14.Checked = true; }
                                    else { this.chkLocationManager14.Checked = false; }
                                    break;
                                case 15:
                                    this.lblLocation15.Text = dr["fullname"].ToString();
                                    this.Location15_Id = int.Parse(dr["location_id"].ToString());
                                    if (int.Parse(dr["instructor_id"].ToString()) == cMstStaff.Id) { this.chkLocationManager15.Checked = true; }
                                    else { this.chkLocationManager15.Checked = false; }
                                    break;
                            }
                            i++;
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
        /// 雇用形態ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectEmployment_Click(object sender, EventArgs e)
        {
            frmSelectItem fSelectItem = new()
            {
                Kbn = 1,                  // 雇用形態
                Value = 0
            };
            fSelectItem.ShowDialog();
            if (fSelectItem.Value == 0) { return; }

            // 雇用形態情報表示
            this.Employment_Id = fSelectItem.Value;
            this.lblEmployment.Text = fSelectItem.StrVal;
        }
        /// <summary>
        /// 社用車ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectCar_Click(object sender, EventArgs e)
        {
            frmSelectCar fSelectCar = new()
            {
                Id = 0
            };
            fSelectCar.ShowDialog();
            if (fSelectCar.Id == 0) { return; }

            // 社用車情報表示
            this.Car_Id = fSelectCar.Id;
            this.lblCarNo.Text = fSelectCar.CarNo;
            this.lblCarName.Text = fSelectCar.CarName;
            this.lblRegNo.Text = fSelectCar.RegNo;
        }
        /// <summary>
        /// 所属ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectOffice_Click(object sender, EventArgs e)
        {
            frmSelectItem fSelectItem = new()
            {
                Kbn = 2,                  // 
                Value = 0
            };
            fSelectItem.ShowDialog();
            if (fSelectItem.Value == 0) { return; }

            // 所属情報表示
            this.Office_Id = fSelectItem.Value;
            this.lblOffice.Text = fSelectItem.StrVal;
        }
        /// <summary>
        /// 部門ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectGroup_Click(object sender, EventArgs e)
        {
            frmSelectItem fSelectItem = new()
            {
                Kbn = 3,                  // 
                Value = 0
            };
            fSelectItem.ShowDialog();
            if (fSelectItem.Value == 0) { return; }

            // 部門情報表示
            this.Group_Id = fSelectItem.Value;
            this.lblGroup.Text = fSelectItem.StrVal;
            /////////////////////////////////////////////////////
            // 暫定処理
            /////////////////////////////////////////////////////
            if (this.lblGroup.Text == "代務")
            {
                this.chkProxy.Checked = true;
            }
        }
        /// <summary>
        /// 専従先情報表示
        /// </summary>
        /// <param name="p_no">idx</param>
        private void DisplayLocation(int p_no)
        {
            frmSelectLocation fSelectLocation = new()
            {
                TargetTable = "Mst_専従先",
                Select_location_name = "",
                Select_location_id = 0
            };
            fSelectLocation.ShowDialog();

            switch(p_no)
            {
                case 1:
                    this.Location1_Id = fSelectLocation.Select_location_id;
                    this.lblLocation1.Text = fSelectLocation.Select_location_name.ToString();
                    break;
                case 2:
                    this.Location2_Id = fSelectLocation.Select_location_id;
                    this.lblLocation2.Text = fSelectLocation.Select_location_name.ToString();
                    break;
                case 3:
                    this.Location3_Id = fSelectLocation.Select_location_id;
                    this.lblLocation3.Text = fSelectLocation.Select_location_name.ToString();
                    break;
                case 4:
                    this.Location4_Id = fSelectLocation.Select_location_id;
                    this.lblLocation4.Text = fSelectLocation.Select_location_name.ToString();
                    break;
                case 5:
                    this.Location5_Id = fSelectLocation.Select_location_id;
                    this.lblLocation5.Text = fSelectLocation.Select_location_name.ToString();
                    break;
                case 6:
                    this.Location6_Id = fSelectLocation.Select_location_id;
                    this.lblLocation6.Text = fSelectLocation.Select_location_name.ToString();
                    break;
                case 7:
                    this.Location7_Id = fSelectLocation.Select_location_id;
                    this.lblLocation7.Text = fSelectLocation.Select_location_name.ToString();
                    break;
                case 8:
                    this.Location8_Id = fSelectLocation.Select_location_id;
                    this.lblLocation8.Text = fSelectLocation.Select_location_name.ToString();
                    break;
                case 9:
                    this.Location9_Id = fSelectLocation.Select_location_id;
                    this.lblLocation9.Text = fSelectLocation.Select_location_name.ToString();
                    break;
                case 10:
                    this.Location10_Id = fSelectLocation.Select_location_id;
                    this.lblLocation10.Text = fSelectLocation.Select_location_name.ToString();
                    break;
                // 2025/08/13 ADD
                case 11:
                    this.Location11_Id = fSelectLocation.Select_location_id;
                    this.lblLocation11.Text = fSelectLocation.Select_location_name.ToString();
                    break;
                case 12:
                    this.Location12_Id = fSelectLocation.Select_location_id;
                    this.lblLocation12.Text = fSelectLocation.Select_location_name.ToString();
                    break;
                case 13:
                    this.Location13_Id = fSelectLocation.Select_location_id;
                    this.lblLocation13.Text = fSelectLocation.Select_location_name.ToString();
                    break;
                case 14:
                    this.Location14_Id = fSelectLocation.Select_location_id;
                    this.lblLocation14.Text = fSelectLocation.Select_location_name.ToString();
                    break;
                case 15:
                    this.Location15_Id = fSelectLocation.Select_location_id;
                    this.lblLocation15.Text = fSelectLocation.Select_location_name.ToString();
                    break;
            }

        }
        /// <summary>
        /// 専従先1ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectLocation1_Click(object sender, EventArgs e)
        {
            DisplayLocation(1);
        }
        /// <summary>
        /// 専従先2ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectLocation2_Click(object sender, EventArgs e)
        {
            DisplayLocation(2);
        }
        /// <summary>
        /// 専従先3ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectLocation3_Click(object sender, EventArgs e)
        {
            DisplayLocation(3);
        }
        /// <summary>
        /// 専従先4ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectLocation4_Click(object sender, EventArgs e)
        {
            DisplayLocation(4);
        }
        /// <summary>
        /// 専従先5ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectLocation5_Click(object sender, EventArgs e)
        {
            DisplayLocation(5);
        }
        /// <summary>
        /// 専従先6ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectLocation6_Click(object sender, EventArgs e)
        {
            DisplayLocation(6);
        }
        /// <summary>
        /// 専従先7ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectLocation7_Click(object sender, EventArgs e)
        {
            DisplayLocation(7);
        }
        /// <summary>
        /// 専従先8ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectLocation8_Click(object sender, EventArgs e)
        {
            DisplayLocation(8);
        }
        /// <summary>
        /// 専従先9ボタンクリックイベント
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectLocation9_Click(object sender, EventArgs e)
        {
            DisplayLocation(9);
        }
        /// <summary>
        /// 専従先10ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectLocation10_Click(object sender, EventArgs e)
        {
            DisplayLocation(10);
        }

        /// <summary>
        /// 専従先11ボタンクリックイベント  2025/08/13 ADD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectLocation11_Click(object sender, EventArgs e)
        {
            DisplayLocation(11);
        }
        /// <summary>
        /// 専従先12ボタンクリックイベント  2025/08/13 ADD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectLocation12_Click(object sender, EventArgs e)
        {
            DisplayLocation(12);
        }
        /// <summary>
        /// 専従先13ボタンクリックイベント  2025/08/13 ADD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectLocation13_Click(object sender, EventArgs e)
        {
            DisplayLocation(13);
        }
        /// <summary>
        /// 専従先14ボタンクリックイベント  2025/08/13 ADD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectLocation14_Click(object sender, EventArgs e)
        {
            DisplayLocation(14);
        }
        /// <summary>
        /// 専従先15ボタンクリックイベント  2025/08/13 ADD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectLocation15_Click(object sender, EventArgs e)
        {
            DisplayLocation(15);
        }

        /// <summary>
        /// 専従先情報クリア
        /// </summary>
        /// <param name="p_no"></param>
        private void ClearLocation(int p_no)
        {
            switch(p_no)
            {
                case 1:
                    this.lblLocation1.Text = "";
                    this.Location1_Id = 0;
                    break;
                case 2:
                    this.lblLocation2.Text = "";
                    this.Location2_Id = 0;
                    break;
                case 3:
                    this.lblLocation3.Text = "";
                    this.Location3_Id = 0;
                    break;
                case 4:
                    this.lblLocation4.Text = "";
                    this.Location4_Id = 0;
                    break;
                case 5:
                    this.lblLocation5.Text = "";
                    this.Location5_Id = 0;
                    break;
                case 6:
                    this.lblLocation6.Text = "";
                    this.Location6_Id = 0;
                    break;
                case 7:
                    this.lblLocation7.Text = "";
                    this.Location7_Id = 0;
                    break;
                case 8:
                    this.lblLocation8.Text = "";
                    this.Location8_Id = 0;
                    break;
                case 9:
                    this.lblLocation9.Text = "";
                    this.Location9_Id = 0;
                    break;
                case 10:
                    this.lblLocation10.Text = "";
                    this.Location10_Id = 0;
                    break;
                // 2025/08/13 ADD
                case 11:
                    this.lblLocation11.Text = "";
                    this.Location11_Id = 0;
                    break;
                case 12:
                    this.lblLocation12.Text = "";
                    this.Location12_Id = 0;
                    break;
                case 13:
                    this.lblLocation13.Text = "";
                    this.Location13_Id = 0;
                    break;
                case 14:
                    this.lblLocation14.Text = "";
                    this.Location14_Id = 0;
                    break;
                case 15:
                    this.lblLocation15.Text = "";
                    this.Location15_Id = 0;
                    break;
            }
        }
        /// <summary>
        /// 専従先クリアボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearLocation1_Click(object sender, EventArgs e)
        {
            ClearLocation(1);
        }
        /// <summary>
        /// 専従先クリアボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnClearLocation2_Click(object sender, EventArgs e)
        {
            ClearLocation(2);
        }
        /// <summary>
        /// 専従先クリアボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnClearLocation3_Click(object sender, EventArgs e)
        {
            ClearLocation(3);
        }
        /// <summary>
        /// 専従先クリアボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnClearLocation4_Click(object sender, EventArgs e)
        {
            ClearLocation(4);
        }
        /// <summary>
        /// 専従先クリアボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnClearLocation5_Click(object sender, EventArgs e)
        {
            ClearLocation(5);
        }
        /// <summary>
        /// 専従先クリアボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnClearLocation6_Click(object sender, EventArgs e)
        {
            ClearLocation(6);
        }
        /// <summary>
        /// 専従先クリアボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnClearLocation7_Click(object sender, EventArgs e)
        {
            ClearLocation(7);
        }
        /// <summary>
        /// 専従先クリアボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnClearLocation8_Click(object sender, EventArgs e)
        {
            ClearLocation(8);
        }
        /// <summary>
        /// 専従先クリアボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnClearLocation9_Click(object sender, EventArgs e)
        {
            ClearLocation(9);
        }
        /// <summary>
        /// 専従先クリアボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearLocation10_Click(object sender, EventArgs e)
        {
            ClearLocation(10);
        }

        /// <summary>
        /// 専従先クリアボタンクリックイベント  2025/08/13 ADD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearLocation11_Click(object sender, EventArgs e)
        {
            ClearLocation(11);
        }
        /// <summary>
        /// 専従先クリアボタンクリックイベント  2025/08/13 ADD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearLocation12_Click(object sender, EventArgs e)
        {
            ClearLocation(12);
        }
        /// <summary>
        /// 専従先クリアボタンクリックイベント  2025/08/13 ADD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearLocation13_Click(object sender, EventArgs e)
        {
            ClearLocation(13);
        }
        /// <summary>
        /// 専従先クリアボタンクリックイベント  2025/08/13 ADD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearLocation14_Click(object sender, EventArgs e)
        {
            ClearLocation(14);
        }
        /// <summary>
        /// 専従先クリアボタンクリックイベント  2025/08/13 ADD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearLocation15_Click(object sender, EventArgs e)
        {
            ClearLocation(15);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < 10; i++)
            {
                this.lblNew.Visible = true;
                InitializeForm();
                ClearLocation(i+1);
            }
        }
        /// <summary>
        /// 保存ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReg_Click(object sender, EventArgs e)
        {
            // 2025/01/23 ADD
            // 入力チェック
            if (this.txtStaffName1.Text == "" ||
                this.txtStaffName2.Text == "" ||
                this.txtKana2.Text == "" ||
                this.Employment_Id == 0 ||
                this.Office_Id == 0 ||
                this.Group_Id == 0)
            {
                // 名前、苗字、ｶﾅ、雇用携帯、所属、部門のいずれかが未入力
                MessageBox.Show("未入力の必須項目があります。（緑色が必須項目）", "", MessageBoxButtons.OK);
                return;
            }
            if (ClsPublic.IsHankakuKatakana(char.Parse(this.txtKana2.Text.ToString().Substring(0,1))) != true)
            {
                MessageBox.Show("苗字には半角ｶﾅを入力してください。", "", MessageBoxButtons.OK);
                return;
            }

            ClsMstStaff cMstStaff = new();
            ClsMstStaffDetail cMstStaffDetail = new();

            // 従業員情報セット
            SetStaffData(ref cMstStaff);

            if (this.Staff_Id == 0)
            {
                // 新規 (INSERT)
                cMstStaff.Id = cMstStaff.GetStaffId();
                this.Staff_Id = cMstStaff.Id;
                cMstStaff.InsertStaff();

                // 詳細も合わせて登録
                cMstStaffDetail.Id = cMstStaff.Id;
                cMstStaffDetail.Insert();

                // MessageBox.Show("登録しました。", "結果", MessageBoxButtons.OK);
                // this.Close();
            }
            else
            {
                // 更新 (UPDATE)
                cMstStaff.Id = this.Staff_Id;
                cMstStaff.UpdateStaff();

                // 詳細がない場合は登録
                if (cMstStaffDetail.Select(cMstStaff.Id) == 0)
                {
                    cMstStaffDetail.Id = cMstStaff.Id;
                    cMstStaffDetail.Insert();
                }

                // MessageBox.Show("更新しました。", "結果", MessageBoxButtons.OK);
                // this.Close();
            }

            // location_id, staff_id格納用（宣言と同時に全て0で初期化される）
            int[] ints = new int[15];      // Mst_専従先用
            Boolean delete_flag = false;

            // 専従先
            cMstStaff.ClearLocationStaff();
            
            if (this.Location1_Id > 0)
            {
                // Mst_専従先専従者
                cMstStaff.InsertLocationStaff(this.Location1_Id, this.Staff_Id);

                if (this.chkLocationManager1.Checked == true)
                {
                    // Mst_専従先
                    cMstStaff.UpdateInstructor(this.Location1_Id, this.Staff_Id);
                    ints[0] = this.Location1_Id;    // 専従先専従者
                }
            }
            if (this.Location2_Id > 0)
            {
                cMstStaff.InsertLocationStaff(this.Location2_Id, this.Staff_Id);

                if (this.chkLocationManager2.Checked == true)
                {
                    cMstStaff.UpdateInstructor(this.Location2_Id, this.Staff_Id);
                    ints[1] = this.Location2_Id;    // 専従先専従者
                }
            }
            if (this.Location3_Id > 0)
            {
                cMstStaff.InsertLocationStaff(this.Location3_Id, this.Staff_Id);

                if (this.chkLocationManager3.Checked == true)
                {
                    cMstStaff.UpdateInstructor(this.Location3_Id, this.Staff_Id);
                    ints[2] = this.Location3_Id;    // 専従先専従者
                }
            }
            if (this.Location4_Id > 0)
            {
                cMstStaff.InsertLocationStaff(this.Location4_Id, this.Staff_Id);

                if (this.chkLocationManager4.Checked == true)
                {
                    cMstStaff.UpdateInstructor(this.Location4_Id, this.Staff_Id);
                    ints[3] = this.Location4_Id;    // 専従先専従者
                }
            }
            if (this.Location5_Id > 0)
            {
                cMstStaff.InsertLocationStaff(this.Location5_Id, this.Staff_Id);

                if (this.chkLocationManager5.Checked == true)
                {
                    cMstStaff.UpdateInstructor(this.Location5_Id, this.Staff_Id);
                    ints[4] = this.Location5_Id;    // 専従先専従者
                }
            }
            if (this.Location6_Id > 0)
            {
                cMstStaff.InsertLocationStaff(this.Location6_Id, this.Staff_Id);

                if (this.chkLocationManager6.Checked == true)
                {
                    cMstStaff.UpdateInstructor(this.Location6_Id, this.Staff_Id);
                    ints[5] = this.Location6_Id;    // 専従先専従者
                }
            }
            if (this.Location7_Id > 0)
            {
                cMstStaff.InsertLocationStaff(this.Location7_Id, this.Staff_Id);

                if (this.chkLocationManager7.Checked == true)
                {
                    cMstStaff.UpdateInstructor(this.Location7_Id, this.Staff_Id);
                    ints[6] = this.Location7_Id;    // 専従先専従者
                }
            }
            if (this.Location8_Id > 0)
            {
                cMstStaff.InsertLocationStaff(this.Location8_Id, this.Staff_Id);

                if (this.chkLocationManager8.Checked == true)
                {
                    cMstStaff.UpdateInstructor(this.Location8_Id, this.Staff_Id);
                    ints[7] = this.Location8_Id;    // 専従先専従者
                }
            }
            if (this.Location9_Id > 0)
            {
                cMstStaff.InsertLocationStaff(this.Location9_Id, this.Staff_Id);

                if (this.chkLocationManager9.Checked == true)
                {
                    cMstStaff.UpdateInstructor(this.Location9_Id, this.Staff_Id);
                    ints[8] = this.Location9_Id;    // 専従先専従者
                }
            }
            if (this.Location10_Id > 0)
            {
                cMstStaff.InsertLocationStaff(this.Location10_Id, this.Staff_Id);

                if (this.chkLocationManager10.Checked == true)
                {
                    cMstStaff.UpdateInstructor(this.Location10_Id, this.Staff_Id);
                    ints[9] = this.Location10_Id;    // 専従先専従者
                }
            }

            // 2025/08/13 ADD
            if (this.Location11_Id > 0)
            {
                cMstStaff.InsertLocationStaff(this.Location11_Id, this.Staff_Id);

                if (this.chkLocationManager11.Checked == true)
                {
                    cMstStaff.UpdateInstructor(this.Location11_Id, this.Staff_Id);
                    ints[10] = this.Location11_Id;    // 専従先専従者
                }
            }
            if (this.Location12_Id > 0)
            {
                cMstStaff.InsertLocationStaff(this.Location12_Id, this.Staff_Id);

                if (this.chkLocationManager12.Checked == true)
                {
                    cMstStaff.UpdateInstructor(this.Location12_Id, this.Staff_Id);
                    ints[11] = this.Location12_Id;    // 専従先専従者
                }
            }
            if (this.Location13_Id > 0)
            {
                cMstStaff.InsertLocationStaff(this.Location13_Id, this.Staff_Id);

                if (this.chkLocationManager13.Checked == true)
                {
                    cMstStaff.UpdateInstructor(this.Location13_Id, this.Staff_Id);
                    ints[12] = this.Location13_Id;    // 専従先専従者
                }
            }
            if (this.Location14_Id > 0)
            {
                cMstStaff.InsertLocationStaff(this.Location14_Id, this.Staff_Id);

                if (this.chkLocationManager14.Checked == true)
                {
                    cMstStaff.UpdateInstructor(this.Location14_Id, this.Staff_Id);
                    ints[13] = this.Location14_Id;    // 専従先専従者
                }
            }
            if (this.Location15_Id > 0)
            {
                cMstStaff.InsertLocationStaff(this.Location15_Id, this.Staff_Id);

                if (this.chkLocationManager15.Checked == true)
                {
                    cMstStaff.UpdateInstructor(this.Location15_Id, this.Staff_Id);
                    ints[14] = this.Location15_Id;    // 専従先専従者
                }
            }

            // 専従先専従者
            // 在席フラグOFF時、専従先専従者情報から削除
            if (cMstStaff.ZaiFlag != 1)
            {
                try
                {
                    using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                    {
                        sb.Clear();
                        sb.AppendLine("DELETE FROM");
                        sb.AppendLine("Mst_専従先専従者");
                        sb.AppendLine("WHERE");
                        sb.AppendLine("staff_id = " + this.Staff_Id);
                        
                        clsSqlDb.DMLUpdate(sb.ToString());
                    }

                    delete_flag = true;

                    // MessageBox.Show("削除しました。", "結果", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }

            // 転送確認
            if (MessageBox.Show("登録しました。続けてサーバーに転送（同期）しますか？" + Environment.NewLine + "転送先 [" + ClsDbConfig.mysqlParam[ClsDbConfig.MySQLNo].Instance + "\\" + ClsDbConfig.mysqlParam[ClsDbConfig.MySQLNo].Database + "]", "確認", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                InitializeForm();
                return;
            }

            try
            {
                // 接続メッセージ
                this.lblConnect.Visible = true;

                // 転送（同期）処理
                using (ClsMySqlDb clsMySqlDb = new(ClsDbConfig.MySQLNo))
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    // Mst_社員クラス
                    ClsMstStaff clsMstStaff = new();
                    // 従業員情報転送
                    clsMstStaff.ExportOneStaffData(this.Staff_Id, clsSqlDb, clsMySqlDb);
                    // Mst_社員詳細（現時点では転送不要）
                    // 専従先専従者から対象の従業員を一旦削除
                    clsMstStaff.ClearLocationStaffMySQL(this.Staff_Id, clsMySqlDb);
                    // 削除（不在）の場合は処理なし
                    if (delete_flag != true)
                    {
                        // 専従先専従者
                        clsMstStaff.ExportLocationOneStaffData(this.Staff_Id, clsSqlDb, clsMySqlDb);
                    }

                    // ===========================================================
                    // 削除（不在）の場合を考慮した処理に変える必要あり
                    // ===========================================================
                    ClsMstLocation clsMstLocation = new();
                    // 専従先専従者
                    for (int i = 0; i < ints.GetLength(0); i++)      // 行数（2）
                    {
                        // 専従先が未設定の場合はスキップ
                        if (ints[i] == 0) { continue; }

                        // 専従先登録
                        clsMstLocation.ExportLocationOneData(ints[i], clsSqlDb, clsMySqlDb);
                    }
                }
                InitializeForm();
                MessageBox.Show("転送しました。","結果",MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK);
                throw;
            }
            finally
            {
                // 接続メッセージ
                this.lblConnect.Visible = false;
            }
        }
        /// <summary>
        /// 画面情報を社員クラスにセット
        /// </summary>
        /// <param name="cstf"></param>
        private void SetStaffData(ref ClsMstStaff cstf)
        {
            cstf.StaffID = 0;
            cstf.Name1 = this.txtStaffName2.Text;
            cstf.Name2 = "";
            cstf.FullName = this.txtStaffName1.Text;
            cstf.Kana1 = this.txtKana1.Text;
            cstf.Kana2 = this.txtKana2.Text;
            cstf.FullKana = "";

            // 2025/08/13 DELETE
            // if (this.mtxtEntryCompany.Text != "    /  /") { cstf.EntryCompany = DateTime.Parse(this.mtxtEntryCompany.Text); }
            // else { cstf.EntryCompany = DateTime.Parse("1900/01/01"); }
            // if (this.mtxtLeavingCompany.Text != "    /  /") { cstf.LeavingCompany = DateTime.Parse(this.mtxtLeavingCompany.Text); }
            // else { cstf.LeavingCompany = DateTime.Parse("1900/01/01"); }

            cstf.GroupID = this.Group_Id;
            cstf.OfficeID = this.Office_Id;
            if (this.chkProxy.Checked == true) { cstf.ProxyFlag = ClsPublic.FLAG_ON; }
            else { cstf.ProxyFlag = 0; }
            if (this.chkPositionFlag.Checked == true) { cstf.PositionFlag = ClsPublic.FLAG_ON; }
            else { cstf.PositionFlag = 0; }
            if (this.chkConfirm.Checked == true) { cstf.ConfirmFlag = ClsPublic.FLAG_ON; }
            else { cstf.ConfirmFlag = 0; }
            if (this.chkMaster.Checked == true)
            { 
                cstf.MasterMenteFlag = ClsPublic.FLAG_ON;
                // 2026/01/07 DEL
                // ClsLoginUser.MasterMenteFlag = ClsPublic.FLAG_ON;
            }
            else 
            { 
                cstf.MasterMenteFlag = ClsPublic.FLAG_OFF;
                // 2026/01/07 DEL
                // ClsLoginUser.MasterMenteFlag = ClsPublic.FLAG_OFF;
            }
            if (this.chkCarManage.Checked == true) 
            { 
                cstf.CarManageFlag = ClsPublic.FLAG_ON;
                // 2026/01/07 DEL
                // ClsLoginUser.CarManageFlag = ClsPublic.FLAG_ON;
            }
            else 
            { 
                cstf.CarManageFlag = ClsPublic.FLAG_OFF;
                // 2026/01/07 DEL
                // ClsLoginUser.CarManageFlag = ClsPublic.FLAG_OFF;
            }

            // 2025/12/24 DEL
            //if (this.chkAttendance.Checked == true) 
            //{ 
            //    cstf.AttendanceFlag = ClsPublic.FLAG_ON; 
            //    ClsLoginUser.AttendanceFlag = ClsPublic.FLAG_ON;
            //}
            //else 
            //{ 
            //    cstf.AttendanceFlag = ClsPublic.FLAG_OFF;
            //    ClsLoginUser.AttendanceFlag = ClsPublic.FLAG_OFF;
            //}

            if (this.chkSystemControll.Checked == true) 
            { 
                cstf.SystemControlFlag = ClsPublic.FLAG_ON;
                ClsLoginUser.SystemControlFlag= ClsPublic.FLAG_ON;
            }
            else 
            { 
                cstf.SystemControlFlag = ClsPublic.FLAG_OFF;
                ClsLoginUser.SystemControlFlag = ClsPublic.FLAG_OFF;
            }
            // 2024/12/16 ADD
            if (this.chkReportManage.Checked == true) 
            { 
                cstf.ReportManageFlag = ClsPublic.FLAG_ON; 
                ClsLoginUser.ReportManageFlag= ClsPublic.FLAG_ON;
            }
            else 
            { 
                cstf.ReportManageFlag = ClsPublic.FLAG_OFF;
                ClsLoginUser.ReportManageFlag = ClsPublic.FLAG_OFF;
            }
            // 2024/12/16 ADD
            if (this.chkRecruitManage.Checked == true) 
            { 
                cstf.RecruitManageFlag = ClsPublic.FLAG_ON;
                ClsLoginUser.RecruitManageFlag= ClsPublic.FLAG_ON;
            }
            else 
            { 
                cstf.RecruitManageFlag = ClsPublic.FLAG_OFF;
                ClsLoginUser.RecruitManageFlag = ClsPublic.FLAG_OFF;
            }
            // 2025/10/28 ADD
            if (this.chkReportConfirm.Checked == true) 
            { 
                cstf.ReportConfirmFlag = ClsPublic.FLAG_ON; 
                ClsLoginUser.ReportConfirmFlag= ClsPublic.FLAG_ON;
            }
            else 
            { 
                cstf.ReportConfirmFlag = ClsPublic.FLAG_OFF;
                ClsLoginUser.ReportConfirmFlag = ClsPublic.FLAG_OFF;
            }
            cstf.ConfirmPass = this.txtPassword.Text;

            if (this.txtLoginSort.Text == "")
            {
                // 並び順MAX値取得
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    cstf.RegSort = 0;
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("MAX(reg_sort) AS Sort");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_社員");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            cstf.RegSort = int.Parse(dr["Sort"].ToString()) + 1;
                        }
                    }
                }
            }
            else
            {
                cstf.RegSort = int.Parse(this.txtLoginSort.Text);
            }

            if (this.txtSort.Text == "")
            {
                // 並び順MAX値取得
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    cstf.Sort = 0;
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("MAX(sort) AS Sort");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_社員");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            cstf.Sort = int.Parse(dr["Sort"].ToString()) + 1;
                        }
                    }
                }
            }
            else
            {
                cstf.Sort = int.Parse(this.txtSort.Text);
            }

            cstf.TantoSort = 0;
            cstf.Kbn = this.Employment_Id;
            if (this.chkZai.Checked == true) {
                cstf.ZaiFlag = ClsPublic.FLAG_ON;
            }
            else 
            { 
                cstf.ZaiFlag = ClsPublic.FLAG_OFF;
            }
            cstf.Comment = this.txtComment.Text;

            // 勤怠関連
            //cstf.SumListType = 0;
            //cstf.ZanTime = 0;
            //cstf.HolidayKbn = 0;
            //cstf.HourlyWage = 0;
            //cstf.SheetName = "";
            //cstf.Comment2 = "";
            cstf.CarID = this.Car_Id;
            // 2025/12/24 DEL
            //if (this.chkAttSubjectFlag.Checked == true) { cstf.AttSubjectFlag = ClsPublic.FLAG_ON; }
            //else { cstf.AttSubjectFlag = ClsPublic.FLAG_OFF; }
            //if (this.chkTask.Checked == true) { cstf.TaskFlag = ClsPublic.FLAG_ON; }
            //else { cstf.TaskFlag = ClsPublic.FLAG_OFF; }
        }
        /// <summary>
        /// 削除ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Staff_Id  == 0) { return; }

            if (MessageBox.Show("削除しますか？","確認",MessageBoxButtons.OKCancel) == DialogResult.Cancel) { return; }

            try
            {
                // 削除→削除フラグON
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    // sb.AppendLine("DELETE FROM");
                    sb.AppendLine("UPDATE");
                    sb.AppendLine("Mst_社員");
                    sb.AppendLine("SET");
                    sb.AppendLine(" zai_flag = " + ClsPublic.FLAG_OFF);             // 未使用
                    // 2025/11/12↓
                    sb.AppendLine(",upd_user_id = " + ClsLoginUser.StaffID);
                    sb.AppendLine(",upd_date = '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    // 2025/11/12↑
                    sb.AppendLine(",delete_flag = " + ClsPublic.FLAG_ON);
                    sb.AppendLine("WHERE");
                    sb.AppendLine("staff_id = " + Staff_Id);
                    clsSqlDb.DMLUpdate(sb.ToString());

                    sb.Clear();
                    sb.AppendLine("UPDATE");
                    sb.AppendLine("Mst_社員詳細");
                    sb.AppendLine("SET");
                    // 2025/11/12↓
                    sb.AppendLine(" upd_user_id = " + ClsLoginUser.StaffID);
                    sb.AppendLine(",upd_date = '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    // 2025/11/12↑
                    sb.AppendLine(",delete_flag = " + ClsPublic.FLAG_ON);
                    sb.AppendLine("WHERE");
                    sb.AppendLine("id = " + Staff_Id);
                    clsSqlDb.DMLUpdate(sb.ToString());

                    sb.Clear();
                    sb.AppendLine("DELETE FROM");
                    // sb.AppendLine("UPDATE");
                    sb.AppendLine("Mst_専従先専従者");
                    // sb.AppendLine("SET");
                    // sb.AppendLine("Delete_Flag = 1");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("staff_id = " + Staff_Id);
                    clsSqlDb.DMLUpdate(sb.ToString());

                    sb.Clear();
                    sb.AppendLine("UPDATE");
                    sb.AppendLine("Mst_専従先");
                    sb.AppendLine("SET");
                    sb.AppendLine("instructor_id = 0");
                    // 2025/11/12↓
                    sb.AppendLine(",upd_user_id = " + ClsLoginUser.StaffID);
                    sb.AppendLine(",upd_date = '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    // 2025/11/12↑
                    sb.AppendLine("WHERE");
                    sb.AppendLine("instructor_id = " + Staff_Id);
                    clsSqlDb.DMLUpdate(sb.ToString());
                }

                MessageBox.Show("削除しました。続けてサーバーのデータも削除します。", "結果", MessageBoxButtons.OK);

                // ========================================================
                // MySQL側データ削除
                // ========================================================
                // 削除→削除フラグON
                using (ClsMySqlDb clsMySqlDb = new(ClsDbConfig.MySQLNo))
                {
                    sb.Clear();
                    sb.AppendLine("DELETE FROM");
                    sb.AppendLine("Mst_社員");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("staff_id = " + Staff_Id);
                    clsMySqlDb.DMLUpdate(sb.ToString());

                    sb.Clear();
                    sb.AppendLine("DELETE FROM");
                    sb.AppendLine("Mst_社員詳細");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("id = " + Staff_Id);
                    clsMySqlDb.DMLUpdate(sb.ToString());

                    sb.Clear();
                    sb.AppendLine("DELETE FROM");
                    sb.AppendLine("Mst_専従先専従者");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("staff_id = " + Staff_Id);
                    clsMySqlDb.DMLUpdate(sb.ToString());

                    sb.Clear();
                    sb.AppendLine("UPDATE");
                    sb.AppendLine("Mst_専従先");
                    sb.AppendLine("SET");
                    sb.AppendLine("instructor_id = 0");
                    sb.AppendLine(",upd_user_id = " + ClsLoginUser.StaffID);
                    sb.AppendLine(",upd_date = '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("instructor_id = " + Staff_Id);
                    clsMySqlDb.DMLUpdate(sb.ToString());

                    MessageBox.Show("削除しました。", "結果", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
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
        /// 詳細ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEtc_Click(object sender, EventArgs e)
        {
            if (Staff_Id == 0)
            {
                MessageBox.Show("保存してください。", "警告", MessageBoxButtons.OK);
                return; 
            }

            frmMstStaffDetail fMstStaffDetail = new()
            {
                Id = Staff_Id,
                StaffName = this.txtStaffName1.Text,
                OfficeName = this.lblOffice.Text,
                GroupName = this.lblGroup.Text
            };
            if (this.chkProxy.Checked) { fMstStaffDetail.ProxyFlag = 1; }
            else { fMstStaffDetail.ProxyFlag = 0; }
            fMstStaffDetail.ShowDialog();
        }
        /// <summary>
        /// ｶﾅ（半角）入力
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtKana1_TextChanged(object sender, EventArgs e)
        {
            // 入力チェック
            if(this.txtKana1.Text == "ｱ" ||
                this.txtKana1.Text == "ｶ" ||
                this.txtKana1.Text == "ｻ" ||
                this.txtKana1.Text == "ﾀ" ||
                this.txtKana1.Text == "ﾅ" ||
                this.txtKana1.Text == "ﾊ" ||
                this.txtKana1.Text == "ﾏ" ||
                this.txtKana1.Text == "ﾔ" ||
                this.txtKana1.Text == "ﾗ" ||
                this.txtKana1.Text == "ﾜ"
                )
            {
                return;
            }
            // 上記以外の場合は入力をクリア
            this.txtKana1.Text = "";
        }
        /// <summary>
        /// 社用車クリアボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectCarClear_Click(object sender, EventArgs e)
        {
            this.Car_Id = 0;
            this.lblCarNo.Text = "";
            this.lblCarName.Text = "";
            this.lblRegNo.Text = "";
        }
        /// <summary>
        /// 苗字（ｶﾅ）テキスト変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtKana2_TextChanged(object sender, EventArgs e)
        {
            if (this.txtKana2.Text == "") return;

            // 先頭1文字取得
            string s = txtKana2.Text.ToString().Substring(0,1);

            // 頭文字を取得
            if (s == "ｱ" || s == "ｲ" || s == "ｳ" || s == "ｴ" || s == "ｵ") { this.txtKana1.Text = "ｱ"; }
            else if (s == "ｶ" || s == "ｷ" || s == "ｸ" || s == "ｹ" || s == "ｺ") { this.txtKana1.Text = "ｶ"; }
            else if (s == "ｻ" || s == "ｼ" || s == "ｽ" || s == "ｾ" || s == "ｿ") { this.txtKana1.Text = "ｻ"; }
            else if (s == "ﾀ" || s == "ﾁ" || s == "ﾂ" || s == "ﾃ" || s == "ﾄ") { this.txtKana1.Text = "ﾀ"; }
            else if (s == "ﾅ" || s == "ﾆ" || s == "ﾇ" || s == "ﾈ" || s == "ﾉ") { this.txtKana1.Text = "ﾅ"; }
            else if (s == "ﾊ" || s == "ﾋ" || s == "ﾌ" || s == "ﾍ" || s == "ﾎ") { this.txtKana1.Text = "ﾊ"; }
            else if (s == "ﾏ" || s == "ﾐ" || s == "ﾑ" || s == "ﾒ" || s == "ﾓ") { this.txtKana1.Text = "ﾏ"; }
            else if (s == "ﾔ" || s == "ﾕ" || s == "ﾖ") { this.txtKana1.Text = "ﾔ"; }
            else if (s == "ﾗ" || s == "ﾘ" || s == "ﾙ" || s == "ﾚ" || s == "ﾛ") { this.txtKana1.Text = "ﾗ"; }
            else if (s == "ﾜ" || s == "ｦ" || s == "ﾝ") { this.txtKana1.Text = "ﾜ"; }
        }
    }
}
