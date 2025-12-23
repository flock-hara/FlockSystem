using FlockAppC.pubClass;
using FlockAppC.tblClass;
using FlockAppC.日報関連;
using FlockAppC.選択画面;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FlockAppC.Report
{
    public partial class frmEditTrnReport : Form
    {
        // 削除実行フラグ
        public int delete_flag {  get; set; }

        // パラメータ用
        public int Report_id {  get; set; }
        private int Location_id {  get; set; }
        private string Location_name {  get; set; }
        private int Car_id {  get; set; }
        private string Car_no {  get; set; }
        private string Car_fullname { get; set; }
        private DateTime Day {  get; set; }
        private int Instructor_id {  get; set; }
        private string Instructor_name { get; set; }
        private int Staff_id1 {  get; set; }
        private string Staff_name1 { get; set; }
        // private int Staff_id2 { get; set; }
        // private int Staff_id3 { get; set; }
        private int After_meter {  get; set; }
        private int Before_meter {  get; set; }
        private int Mileage {  get; set; }
        private decimal Fuel {  get; set; }
        private int Fuel_meter {  get; set; }
        private decimal Oil {  get; set; }
        private decimal Kerosene {  get; set; }
        // private string Start_location {  get; set; }
        // private string End_location { get; set; }
        private DateTime Start_time1 {  get; set; }
        private DateTime Start_time2 { get; set; }
        private DateTime Start_time3 { get; set; }
        private DateTime End_time1 { get; set; }
        private DateTime End_time2 { get; set; }
        private DateTime End_time3 { get; set; }

        // 基本契約時間
        private DateTime Basic_Start_time1 { get; set; }
        private DateTime Basic_Start_time2 { get; set; }
        private DateTime Basic_Start_time3 { get; set; }
        private DateTime Basic_End_time1 { get; set; }
        private DateTime Basic_End_time2 { get; set; }
        private DateTime Basic_End_time3 { get; set; }

        // 残業時間
        private int Over_time1 { get; set; }
        private int Over_time2 { get; set; }
        private int Over_time3 { get; set; }

        // 始業前残業時間
        private int Start_over_time1 { get; set; }
        private int Start_over_time2 { get; set; }
        private int Start_over_time3 { get; set; }
        // 終業後残業時間
        private int End_over_time1 { get; set; }
        private int End_over_time2 { get; set; }
        private int End_over_time3 { get; set; }

        // 始業前残業理由区分
        private int Start_over_time_kbn1 { get; set; }
        private int Start_over_time_kbn2 { get; set; }
        private int Start_over_time_kbn3 { get; set; }

        // 終業後残業理由区分
        private int End_over_time_kbn1 { get; set; }
        private int End_over_time_kbn2 { get; set; }
        private int End_over_time_kbn3 { get; set; }

        // 始業前残業理由
        private string Start_over_time_comment1 { get; set; }
        private string Start_over_time_comment2 { get; set; }
        private string Start_over_time_comment3 { get; set; }

        // 終業後残業理由
        private string End_over_time_comment1 { get; set; }
        private string End_over_time_comment2 { get; set; }
        private string End_over_time_comment3 { get; set; }

        // 休憩時間
        private DateTime Start_break_time1 { get; set; }
        private DateTime Start_break_time2 { get; set; }
        private DateTime Start_break_time3 { get; set; }
        private DateTime End_break_time1 { get; set; }
        private DateTime End_break_time2 { get; set; }
        private DateTime End_break_time3 { get; set; }
        private int Break_time1 { get; set; }
        private int Break_time2 { get; set; }
        private int Break_time3 { get; set; }

        // 代車フラグ
        private int Subcar_flag {  get; set; }

        // 確認・認証
        private int Confirm1_id { get; set; }
        private DateTime Confirm1_date { get; set; }
        private string Confirm1_name { get; set; }
        private int Confirm2_id { get; set; }
        private DateTime Confirm2_date { get; set; }
        private string Confirm2_name { get; set; }
        private int Confirm3_id { get; set; }
        private DateTime Confirm3_date { get; set; }
        private string Confirm3_name { get; set; }
        private int Sales_id { get; set; }
        private DateTime Sales_confirm_date { get; set; }
        private string Sales_name { get; set; }
        private int Guest_id { get; set; }
        private DateTime Guest_confirm_date { get; set; }
        private string Guest_name { get; set; }
        private int Confirm_status { get; set; }

        // 日報アルコールチェック・検温
        private decimal Temp1 {  get; set; }
        private decimal Temp2 { get; set; }
        private decimal Temp3 { get; set; }
        private DateTime Temp_time1 { get; set; }
        private DateTime Temp_time2 { get; set; }
        private DateTime Temp_time3 { get; set; }
        private decimal Alcohol1 { get; set; }
        private decimal Alcohol2 { get; set; }
        private decimal Alcohol3 { get; set; }
        private int Alcohol_check1 {  get; set; }
        private int Alcohol_check2 { get; set; }
        private int Alcohol_check3 { get; set; }

        // 日報　備考
        private int Comment_kbn {  get; set; }
        private string Comment_kbn_name {  get; set; }
        private string Comment {  get; set; }
        private int Passenger_id { get; set; }      // 同乗者（1:あり)

        private readonly StringBuilder sb = new();


        public frmEditTrnReport()
        {
            InitializeComponent();
        }
        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmEditTrnReport_Load(object sender, EventArgs e)
        {
            // 入力項目初期化
            Initialize_Display();

            // Private値初期化
            Initialize_Data();

            // 更新モードの場合は日報データ表示
            if (this.Report_id > 0)
            {
                // =====================================================
                // Publicへ保持
                // =====================================================
                clsPublicReport.pub_Current_id = this.Report_id;

                // 編集ブロック項目
                this.btnSelectLocation.Enabled = false;
                this.btnSelectCar.Enabled = false;
                this.btnSelectInstructor.Enabled = false;
                this.btnSelectUser1.Enabled = false;

                // 日報入力データセット
                Get_ReportData();

                // 基本契約時間データセット
                Get_ContractTimeData();

                // 日報入力データ表示
                Display_ReportData();

                // ログインユーザー判定
                // 日報承認権限OFFのユーザーは、承認２を無効にする
                // テーブルとマスターメンテに項目を追加する必要あり
                if (ClsLoginUser.ReportConfirmFlag == 0)
                {
                    chkSalesConfirm.Enabled = false;
                }
                else
                {
                    chkSalesConfirm.Enabled = true;
                }
            }

            this.Location = new Point(0, 0);
        }
        /// <summary>
        /// 入力項目初期化
        /// </summary>
        private void Initialize_Display()
        {
            // チェック、承認
            this.chkConfirm1.Checked = false;
            this.chkConfirm2.Checked = false;
            this.chkConfirm3.Checked = false;
            this.chkSalesConfirm.Checked = false;
            this.lblConfirm1Date.Text = "";
            this.lblConfirm1Name.Text = "";
            this.lblConfirm2Date.Text = "";
            this.lblConfirm2Name.Text = "";
            this.lblConfirm3Date.Text = "";
            this.lblConfirm3Name.Text = "";
            this.lblSalesConfirmDate.Text = "";
            this.lblSalesName.Text = "";
            this.lblGuestConfirmDate.Text = "";
            this.lblGuestName.Text = "";
            // this.Confirm_status = 0;

            // 控え
            this.chkHikae.Checked = false;
            // 残業有のみ
            // this.chkOver_Time_Only.Checked = false;

            this.mskStart_Time1.Text = "";
            this.mskStart_Time2.Text = "";
            this.mskStart_Time3.Text = "";
            this.mskEnd_Time1.Text = "";
            this.mskEnd_Time2.Text = "";
            this.mskEnd_Time3.Text = "";
            this.mskTemp_Time1.Text = "";
            this.mskTemp_Time2.Text = "";
            this.mskTemp_Time3.Text = "";
            this.txtOver_Time1.Text = "";
            this.txtOver_Time2.Text = "";
            this.txtOver_Time3.Text = "";
            this.txtStart_Over_Time1.Text = "";
            this.txtStart_Over_Time2.Text = "";
            this.txtStart_Over_Time3.Text = "";
            this.txtEnd_Over_Time1.Text = "";
            this.txtEnd_Over_Time2.Text = "";
            this.txtEnd_Over_Time3.Text = "";
            this.txtStart_Over_Time_Comment1.Text = "";
            this.txtStart_Over_Time_Comment2.Text = "";
            this.txtStart_Over_Time_Comment3.Text = "";
            this.txtEnd_Over_Time_Comment1.Text = "";
            this.txtEnd_Over_Time_Comment2.Text = "";
            this.txtEnd_Over_Time_Comment3.Text = "";

            this.mskStart_Break_Time1.Text = "";
            this.mskStart_Break_Time2.Text = "";
            this.mskStart_Break_Time3.Text = "";
            this.mskEnd_Break_Time1.Text = "";
            this.mskEnd_Break_Time2.Text = "";
            this.mskEnd_Break_Time3.Text = "";
            this.txtBreak_Time1.Text = "";
            this.txtBreak_Time2.Text = "";
            this.txtBreak_Time3.Text = "";

            // 基本契約情報
            this.mskBasic_Start_Time1.Text = "";
            this.mskBasic_Start_Time2.Text = "";
            this.mskBasic_Start_Time3.Text = "";
            this.mskBasic_End_Time1.Text = "";
            this.mskBasic_End_Time2.Text = "";
            this.mskBasic_End_Time3.Text = "";

            this.lblReport_Id.Text = "";
            this.lblLocation_Name.Text = "";
            this.dtptDay.Value = DateTime.Now;
            this.lblCar_No.Text = "";
            this.lblInstructor_Name.Text = "";
            this.lblStaff_Name1.Text = "";
            this.chkSubcar.Checked = false;
            // this.lblStaff_Name2.Text = "";
            // this.lblStaff_Name3.Text = "";
            // this.lblStart_Location.Text = "";
            // this.lblEnd_Location.Text = "";
            this.txtAfter_Meter.Text = "";
            this.txtBefore_Meter.Text = "";
            this.txtMileage.Text = "";
            this.txtFuel.Text = "";
            this.txtFuel_Meter.Text = "";
            this.txtOil.Text = "";
            this.txtKerosene.Text = "";

            this.txtAlcohol1.Text = "";
            this.txtAlcohol2.Text = "";
            this.txtAlcohol3.Text = "";
            this.rdoAlcohol_Check1_Ok.Checked = false;
            this.rdoAlcohol_Check1_Ng.Checked = false;
            this.rdoAlcohol_Check2_Ok.Checked = false;
            this.rdoAlcohol_Check2_Ng.Checked = false;
            this.rdoAlcohol_Check3_Ok.Checked = false;
            this.rdoAlcohol_Check3_Ng.Checked = false;
            this.txtTemp1.Text = "";
            this.txtTemp2.Text = "";
            this.txtTemp3.Text = "";

            this.lblComment_Kbn.Text = "";
            this.txtComment.Text = "";

            // 同乗者
            this.chkPassenger.Checked = false;

            // ID指定がある場合は「更新」モード
            if (this.Report_id > 0) { this.lblNew.Visible = false; }
            else { this.lblNew.Visible = true; }

            // 始業前残業区分
            ClsControll clsControll = new ClsControll();
            clsControll.SetKbnCmb(this.cmbStart_Over_Time_Kbn1, 703);
            clsControll = new ClsControll();
            clsControll.SetKbnCmb(this.cmbStart_Over_Time_Kbn2, 703);
            clsControll = new ClsControll();
            clsControll.SetKbnCmb(this.cmbStart_Over_Time_Kbn3, 703);
            clsControll = new ClsControll();
            clsControll.SetKbnCmb(this.cmbEnd_Over_Time_Kbn1, 703);
            clsControll = new ClsControll();
            clsControll.SetKbnCmb(this.cmbEnd_Over_Time_Kbn2, 703);
            clsControll = new ClsControll();
            clsControll.SetKbnCmb(this.cmbEnd_Over_Time_Kbn3, 703);

            this.cmbStart_Over_Time_Kbn1.SelectedIndex = 0;
            this.cmbStart_Over_Time_Kbn2.SelectedIndex = 0;
            this.cmbStart_Over_Time_Kbn3.SelectedIndex = 0;
            this.cmbEnd_Over_Time_Kbn1.SelectedIndex = 0;
            this.cmbEnd_Over_Time_Kbn2.SelectedIndex = 0;
            this.cmbEnd_Over_Time_Kbn3.SelectedIndex = 0;
        }
        /// <summary>
        /// Private値初期化
        /// </summary>
        private void Initialize_Data()
        {
            // 日報データ
            // this.report_id = 0;
            this.Location_id = 0;
            this.Car_id = 0;
            this.Day = DateTime.Parse("1900/01/01");
            this.Instructor_id = 0;
            this.Staff_id1 = 0;
            // this.Staff_id2 = 0;
            // this.Staff_id3 = 0;
            this.After_meter = 0;
            this.Before_meter = 0;
            this.Mileage = 0;
            this.Fuel = 0;
            this.Fuel_meter = 0;
            this.Oil = 0;
            this.Kerosene = 0;
            // this.Start_location = null;
            // this.End_location = null;
            this.Start_time1 = DateTime.Parse("1900/01/01 00:00:00");
            this.Start_time2 = DateTime.Parse("1900/01/01 00:00:00");
            this.Start_time3 = DateTime.Parse("1900/01/01 00:00:00");
            this.End_time1 = DateTime.Parse("1900/01/01 00:00:00");
            this.End_time2 = DateTime.Parse("1900/01/01 00:00:00");
            this.End_time3 = DateTime.Parse("1900/01/01 00:00:00");

            // 基本契約時間
            this.Basic_Start_time1 = DateTime.Parse("1900/01/01 00:00:00");
            this.Basic_Start_time2 = DateTime.Parse("1900/01/01 00:00:00");
            this.Basic_Start_time3 = DateTime.Parse("1900/01/01 00:00:00");
            this.Basic_End_time1 = DateTime.Parse("1900/01/01 00:00:00");
            this.Basic_End_time2 = DateTime.Parse("1900/01/01 00:00:00");
            this.Basic_End_time3 = DateTime.Parse("1900/01/01 00:00:00");

            // 残業時間
            this.Over_time1 = 0;
            this.Over_time2 = 0;
            this.Over_time3 = 0;

            // 早出、通常残業時間
            this.Start_over_time1 = 0;
            this.Start_over_time2 = 0;
            this.Start_over_time3 = 0;
            this.End_over_time1 = 0;
            this.End_over_time2 = 0;
            this.End_over_time3 = 0;

            // 理由区分
            this.Start_over_time_kbn1 = 0;
            this.Start_over_time_kbn2 = 0;
            this.Start_over_time_kbn3 = 0;
            this.End_over_time_kbn1 = 0;
            this.End_over_time_kbn2 = 0;
            this.End_over_time_kbn3 = 0;

            // 理由
            this.Start_over_time_comment1 = "";
            this.Start_over_time_comment2 = "";
            this.Start_over_time_comment3 = "";
            this.End_over_time_comment1 = "";
            this.End_over_time_comment2 = "";
            this.End_over_time_comment3 = "";

            // 休憩時間
            this.Start_break_time1 = DateTime.Parse("1900/01/01 00:00:00");
            this.Start_break_time2 = DateTime.Parse("1900/01/01 00:00:00");
            this.Start_break_time3 = DateTime.Parse("1900/01/01 00:00:00");
            this.End_break_time1 = DateTime.Parse("1900/01/01 00:00:00");
            this.End_break_time2 = DateTime.Parse("1900/01/01 00:00:00");
            this.End_break_time3 = DateTime.Parse("1900/01/01 00:00:00");
            this.Break_time1 = 0;
            this.Break_time2 = 0;
            this.Break_time3 = 0;

            // 代車
            this.Subcar_flag = 0;

            // 承認済み
            this.Confirm1_id = 0;
            this.Confirm2_id = 0;
            this.Confirm3_id = 0;
            this.Sales_id = 0;
            this.Guest_id = 0;
            this.Confirm1_date = DateTime.Parse("1900/01/01 00:00:00");
            this.Confirm2_date = DateTime.Parse("1900/01/01 00:00:00");
            this.Confirm3_date = DateTime.Parse("1900/01/01 00:00:00");
            this.Sales_confirm_date = DateTime.Parse("1900/01/01 00:00:00");
            this.Guest_confirm_date = DateTime.Parse("1900/01/01 00:00:00");
            this.Confirm1_name = "";
            this.Confirm2_name = "";
            this.Confirm3_name = "";
            this.Sales_name = "";
            this.Guest_name = "";
            this.Confirm_status = 0;

            // 日報アルコールチェック・検温
            this.Temp1 = 0;
            this.Temp2 = 0;
            this.Temp3 = 0;
            this.Temp_time1 = DateTime.Parse("1900/01/01 00:00:00");
            this.Temp_time2 = DateTime.Parse("1900/01/01 00:00:00");
            this.Temp_time3 = DateTime.Parse("1900/01/01 00:00:00");
            this.Alcohol1 = -1;
            this.Alcohol2 = -1;
            this.Alcohol3 = -1;
            this.Alcohol_check1 = 0;
            this.Alcohol_check2 = 0;
            this.Alcohol_check3 = 0;

            // 日報　備考
            this.Comment_kbn = -1;
            this.Comment_kbn_name = "";
            this.Comment = null;
            this.Passenger_id = 0;
        }
        /// <summary>
        /// 日報入力データ取得
        /// </summary>
        /// <returns>取得件数</returns>
        private int Get_ReportData()
        {
            ClsTrnReport cls = new();

            try
            {
                // 日報ID指定
                cls.Key_report_id = this.Report_id;
                // 日報IDから日報データ取得
                // cls.SelectFromID(this.con);
                cls.SelectFromID();

                // 件数なし→処理終了
                if (cls.Select_count == 0 || cls.Select_count > 1) { return 0; }

                // 日報データ読み込み
                foreach (DataRow dr in cls.Dt.Rows)
                {
                    // Privateに保持
                    if (dr.IsNull("location_id") != true) { this.Location_id = int.Parse(dr["location_id"].ToString()); }               // 専従先ID
                    if (dr.IsNull("location_name") != true) { this.Location_name = dr["location_name"].ToString(); }                    // 専従先名称
                    if (dr.IsNull("car_id") != true) { this.Car_id = int.Parse(dr["car_id"].ToString()); }                              // 専従先車両ID
                    if (dr.IsNull("car_no") != true) { this.Car_no = dr["car_no"].ToString(); }                                         // 専従先車両番号
                    if (dr.IsNull("car_fullname") != true) { this.Car_fullname = dr["car_fullname"].ToString(); }                                   // 専従先車両番号+名称
                    if (dr.IsNull("day") != true) { this.Day = DateTime.Parse(dr["day"].ToString()); }                                  // 日付
                    if (dr.IsNull("instructor_name") != true) { this.Instructor_name = dr["instructor_name"].ToString(); }              // 管理責任者名
                    // if (dr.IsNull("start_location") != true) { this.Start_location = dr["start_location"].ToString(); }                 // 始業場所
                    // if (dr.IsNull("end_location") != true) { this.End_location = dr["end_location"].ToString(); }                       // 終業場所
                    if (dr.IsNull("staff_name1") != true) { this.Staff_name1 = dr["staff_name1"].ToString(); }                          // 担当者
                    if (dr.IsNull("start_time1") != true) { this.Start_time1 = DateTime.Parse(dr["start_time1"].ToString()); }          // 開始時間1
                    if (dr.IsNull("start_time2") != true) { this.Start_time2 = DateTime.Parse(dr["start_time2"].ToString()); }          // 開始時間2
                    if (dr.IsNull("start_time3") != true) { this.Start_time3 = DateTime.Parse(dr["start_time3"].ToString()); }          // 開始時間3
                    if (dr.IsNull("end_time1") != true) { this.End_time1 = DateTime.Parse(dr["end_time1"].ToString()); }                // 終了時間1
                    if (dr.IsNull("end_time2") != true) { this.End_time2 = DateTime.Parse(dr["end_time2"].ToString()); }                // 終了時間2
                    if (dr.IsNull("end_time3") != true) { this.End_time3 = DateTime.Parse(dr["end_time3"].ToString()); }                // 終了時間3

                    // 残業時間
                    if (dr.IsNull("over_time1") != true) { this.Over_time1 = int.Parse(dr["over_time1"].ToString()); }                  // 残業時間1
                    if (dr.IsNull("over_time2") != true) { this.Over_time2 = int.Parse(dr["over_time2"].ToString()); }                  // 残業時間1
                    if (dr.IsNull("over_time3") != true) { this.Over_time3 = int.Parse(dr["over_time3"].ToString()); }                  // 残業時間1

                    // 早出通常残業時間
                    if (dr.IsNull("start_over_time1") != true) { this.Start_over_time1 = int.Parse(dr["start_over_time1"].ToString()); }                  // 残業時間1
                    if (dr.IsNull("start_over_time2") != true) { this.Start_over_time2 = int.Parse(dr["start_over_time2"].ToString()); }                  // 残業時間1
                    if (dr.IsNull("start_over_time3") != true) { this.Start_over_time3 = int.Parse(dr["Start_over_time3"].ToString()); }                  // 残業時間1
                    if (dr.IsNull("end_over_time1") != true) { this.End_over_time1 = int.Parse(dr["end_over_time1"].ToString()); }                  // 残業時間1
                    if (dr.IsNull("end_over_time2") != true) { this.End_over_time2 = int.Parse(dr["end_over_time2"].ToString()); }                  // 残業時間1
                    if (dr.IsNull("end_over_time3") != true) { this.End_over_time3 = int.Parse(dr["end_over_time3"].ToString()); }                  // 残業時間1

                    // 理由区分
                    if (dr.IsNull("start_over_time_kbn1") != true) { this.Start_over_time_kbn1 = int.Parse(dr["start_over_time_kbn1"].ToString()); }                  // 残業時間1
                    if (dr.IsNull("start_over_time_kbn2") != true) { this.Start_over_time_kbn2 = int.Parse(dr["start_over_time_kbn2"].ToString()); }                  // 残業時間1
                    if (dr.IsNull("start_over_time_kbn3") != true) { this.Start_over_time_kbn3 = int.Parse(dr["start_over_time_kbn3"].ToString()); }                  // 残業時間1
                    if (dr.IsNull("end_over_time_kbn1") != true) { this.End_over_time_kbn1 = int.Parse(dr["end_over_time_kbn1"].ToString()); }                  // 残業時間1
                    if (dr.IsNull("end_over_time_kbn2") != true) { this.End_over_time_kbn2 = int.Parse(dr["end_over_time_kbn2"].ToString()); }                  // 残業時間1
                    if (dr.IsNull("end_over_time_kbn3") != true) { this.End_over_time_kbn3 = int.Parse(dr["end_over_time_kbn3"].ToString()); }                  // 残業時間1

                    // 理由
                    if (dr.IsNull("start_over_time_comment1") != true) { this.Start_over_time_comment1 = dr["start_over_time_comment1"].ToString(); }                                            // 備考
                    if (dr.IsNull("start_over_time_comment2") != true) { this.Start_over_time_comment2 = dr["start_over_time_comment2"].ToString(); }                                            // 備考
                    if (dr.IsNull("start_over_time_comment3") != true) { this.Start_over_time_comment3 = dr["start_over_time_comment3"].ToString(); }                                            // 備考
                    if (dr.IsNull("end_over_time_comment1") != true) { this.End_over_time_comment1 = dr["end_over_time_comment1"].ToString(); }                                            // 備考
                    if (dr.IsNull("end_over_time_comment2") != true) { this.End_over_time_comment2 = dr["end_over_time_comment2"].ToString(); }                                            // 備考
                    if (dr.IsNull("end_over_time_comment3") != true) { this.End_over_time_comment3 = dr["end_over_time_comment3"].ToString(); }                                            // 備考

                    // 休憩時間
                    if (dr.IsNull("start_break_time1") != true) { this.Start_break_time1 = DateTime.Parse(dr["start_break_time1"].ToString()); }          // 開始時間1
                    if (dr.IsNull("start_break_time2") != true) { this.Start_break_time2 = DateTime.Parse(dr["start_break_time2"].ToString()); }          // 開始時間2
                    if (dr.IsNull("start_break_time3") != true) { this.Start_break_time3 = DateTime.Parse(dr["start_break_time3"].ToString()); }          // 開始時間3
                    if (dr.IsNull("end_break_time1") != true) { this.End_break_time1 = DateTime.Parse(dr["end_break_time1"].ToString()); }                // 終了時間1
                    if (dr.IsNull("end_break_time2") != true) { this.End_break_time2 = DateTime.Parse(dr["end_break_time2"].ToString()); }                // 終了時間2
                    if (dr.IsNull("end_break_time3") != true) { this.End_break_time3 = DateTime.Parse(dr["end_break_time3"].ToString()); }                // 終了時間3
                    if (dr.IsNull("break_time1") != true) { this.Break_time1 = int.Parse(dr["break_time1"].ToString()); }                  // 休憩時間1
                    if (dr.IsNull("break_time2") != true) { this.Break_time2 = int.Parse(dr["break_time2"].ToString()); }                  // 休憩時間2
                    if (dr.IsNull("break_time3") != true) { this.Break_time3 = int.Parse(dr["break_time3"].ToString()); }                  // 休憩時間3

                    // 代車
                    if (dr.IsNull("subcar_flag") != true) { this.Subcar_flag = int.Parse(dr["subcar_flag"].ToString()); }               // 代車フラグ

                    if (dr.IsNull("after_meter") != true) { this.After_meter = int.Parse(dr["after_meter"].ToString()); }               // 入庫時メーター
                    if (dr.IsNull("before_meter") != true) { this.Before_meter = int.Parse(dr["before_meter"].ToString()); }            // 出庫時メーター
                    if (dr.IsNull("mileage") != true) { this.Mileage = int.Parse(dr["mileage"].ToString()); }                           // 走行距離
                    if (dr.IsNull("fuel") != true) { this.Fuel = decimal.Parse(dr["fuel"].ToString()); }                                // 給油量
                    if (dr.IsNull("fuel_meter") != true) { this.Fuel_meter = int.Parse(dr["fuel_meter"].ToString()); }                  // 給油時メーター
                    if (dr.IsNull("oil") != true) { this.Oil = decimal.Parse(dr["oil"].ToString()); }                                   // オイル
                    if (dr.IsNull("kerosene") != true) { this.Kerosene = decimal.Parse(dr["kerosene"].ToString()); }                    // 灯油
                    // ==============================================================================================================================
                    // 日報　アルコールチェック、検温
                    // ==============================================================================================================================
                    if (dr.IsNull("temp1") != true) { this.Temp1 = decimal.Parse(dr["temp1"].ToString()); }                             // 検温1回目
                    if (dr.IsNull("temp2") != true) { this.Temp2 = decimal.Parse(dr["temp2"].ToString()); }                             // 検温2回目
                    if (dr.IsNull("temp3") != true) { this.Temp3 = decimal.Parse(dr["temp3"].ToString()); }                             // 検温3回目
                    if (dr.IsNull("temp_time1") != true) { this.Temp_time1 = DateTime.Parse(dr["temp_time1"].ToString()); }             // 検温1回目時刻
                    if (dr.IsNull("temp_time2") != true) { this.Temp_time2 = DateTime.Parse(dr["temp_time2"].ToString()); }             // 検温2回目時刻
                    if (dr.IsNull("temp_time3") != true) { this.Temp_time3 = DateTime.Parse(dr["temp_time3"].ToString()); }             // 検温3回目時刻
                    if (dr.IsNull("alcohol1") != true) { this.Alcohol1 = decimal.Parse(dr["alcohol1"].ToString()); }                    // アルコール濃度1回目
                    if (dr.IsNull("alcohol2") != true) { this.Alcohol2 = decimal.Parse(dr["alcohol2"].ToString()); }                    // アルコール濃度2回目
                    if (dr.IsNull("alcohol3") != true) { this.Alcohol3 = decimal.Parse(dr["alcohol3"].ToString()); }                    // アルコール濃度3回目
                    if (dr.IsNull("alcohol_check1") != true) { this.Alcohol_check1 = int.Parse(dr["alcohol_check1"].ToString()); }      // アルコールチェック結果1回目
                    if (dr.IsNull("alcohol_check2") != true) { this.Alcohol_check2 = int.Parse(dr["alcohol_check2"].ToString()); }      // アルコールチェック結果2回目
                    if (dr.IsNull("alcohol_check3") != true) { this.Alcohol_check3 = int.Parse(dr["alcohol_check3"].ToString()); }      // アルコールチェック結果3回目

                    // ==============================================================================================================================
                    // 日報　備考
                    // ==============================================================================================================================
                    if (dr.IsNull("comment_kbn") != true) { this.Comment_kbn = int.Parse(dr["comment_kbn"].ToString()); }                     // 備考区分
                    if (dr.IsNull("comment_kbn_name") != true) { this.Comment_kbn_name = dr["comment_kbn_name"].ToString(); }                 // 区分名称
                    if (dr.IsNull("comment") != true) { this.Comment = dr["comment"].ToString(); }                                            // 備考
                    if (dr.IsNull("passenger_id") != true) { this.Passenger_id = int.Parse(dr["passenger_id"].ToString()); }                  // 同乗者

                    // ==============================================================================================================================
                    // チェック、承認
                    // ==============================================================================================================================
                    if (dr.IsNull("confirm1_id") != true) { this.Confirm1_id = int.Parse(dr["confirm1_id"].ToString()); }        // 確認1
                    if (dr.IsNull("confirm1_date") != true) { this.Confirm1_date = DateTime.Parse(dr["confirm1_date"].ToString()); }                                  // 日付
                    if (dr.IsNull("confirm1_name") != true) { this.Confirm1_name = dr["confirm1_name"].ToString(); }             
                    if (dr.IsNull("confirm2_id") != true) { this.Confirm2_id = int.Parse(dr["confirm2_id"].ToString()); }        // 確認2
                    if (dr.IsNull("confirm2_date") != true) { this.Confirm2_date = DateTime.Parse(dr["confirm2_date"].ToString()); }                                  // 日付
                    if (dr.IsNull("confirm2_name") != true) { this.Confirm2_name = dr["confirm2_name"].ToString(); }
                    if (dr.IsNull("confirm3_id") != true) { this.Confirm3_id = int.Parse(dr["confirm3_id"].ToString()); }        // 確認3
                    if (dr.IsNull("confirm3_date") != true) { this.Confirm3_date = DateTime.Parse(dr["confirm3_date"].ToString()); }                                  // 日付
                    if (dr.IsNull("confirm3_name") != true) { this.Confirm3_name = dr["confirm3_name"].ToString(); }
                    if (dr.IsNull("sales_id") != true) { this.Sales_id = int.Parse(dr["sales_id"].ToString()); }                 // 営業
                    if (dr.IsNull("sales_confirm_date") != true) { this.Sales_confirm_date = DateTime.Parse(dr["sales_confirm_date"].ToString()); }                                  // 日付
                    if (dr.IsNull("sales_name") != true) { this.Sales_name = dr["sales_name"].ToString(); }
                    if (dr.IsNull("guest_id") != true) { this.Guest_id = int.Parse(dr["guest_id"].ToString()); }                 // 顧客
                    if (dr.IsNull("guest_confirm_date") != true) { this.Guest_confirm_date = DateTime.Parse(dr["guest_confirm_date"].ToString()); }                                  // 日付
                    if (dr.IsNull("guest_name") != true) { this.Guest_name = dr["guest_name"].ToString(); }
                    if (dr.IsNull("confirm_status") != true) { this.Confirm_status = int.Parse(dr["confirm_status"].ToString()); }                 // 顧客
                }
                return 1;
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// 基本契約時間データ取得
        /// </summary>
        private void Get_ContractTimeData()
        {
            ClsMstBasicContractTime cls = new();

            try
            {
                // 専従先ID
                cls.Location_id = this.Location_id;
                // 車両ID
                cls.Car_id = this.Car_id;
                // 曜日
                cls.Week = this.Day.ToString("ddd", new System.Globalization.CultureInfo("ja-JP"));

                // 基本契約時間データ取得
                cls.Select();

                // 件数なし→処理終了
                if (cls.Select_count == 0) { return; }

                // 基本契約時間んデータ読み込み
                foreach (DataRow dr in cls.Dt.Rows)
                {
                    // Privateに保持
                    if (dr.IsNull("start_time1") != true) { this.Basic_Start_time1 = DateTime.Parse(dr["start_time1"].ToString()); }    // 開始時間1
                    if (dr.IsNull("start_time2") != true) { this.Basic_Start_time2 = DateTime.Parse(dr["start_time2"].ToString()); }    // 開始時間2
                    if (dr.IsNull("start_time3") != true) { this.Basic_Start_time3 = DateTime.Parse(dr["start_time3"].ToString()); }    // 開始時間3
                    if (dr.IsNull("end_time1") != true) { this.Basic_End_time1 = DateTime.Parse(dr["end_time1"].ToString()); }          // 終了時間1
                    if (dr.IsNull("end_time2") != true) { this.Basic_End_time2 = DateTime.Parse(dr["end_time2"].ToString()); }          // 終了時間2
                    if (dr.IsNull("end_time3") != true) { this.Basic_End_time3 = DateTime.Parse(dr["end_time3"].ToString()); }          // 終了時間3
                }
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// 日報入力データセット(画面→Privateプロパティ)
        /// </summary>
        private void Set_ReportData()
        {
            // 時間　※未入力の場合は1900/01/01 00:00:00をセットし、DB登録時はNULLに変換
            if (this.mskStart_Time1.Text == "  :") { this.Start_time1 = DateTime.Parse("1900/01/01 00:00:00"); }
            else { this.Start_time1 = DateTime.Parse("1900/01/01 " + this.mskStart_Time1.Text + ":00"); }

            if (this.mskStart_Time2.Text == "  :") { this.Start_time2 = DateTime.Parse("1900/01/01 00:00:00"); }
            else { this.Start_time2 = DateTime.Parse("1900/01/01 " + this.mskStart_Time2.Text + ":00"); }

            if (this.mskStart_Time3.Text == "  :") { this.Start_time3 = DateTime.Parse("1900/01/01 00:00:00"); }
            else { this.Start_time3 = DateTime.Parse("1900/01/01 " + this.mskStart_Time3.Text + ":00"); }

            if (this.mskEnd_Time1.Text == "  :") { this.End_time1 = DateTime.Parse("1900/01/01 00:00:00"); }
            else { this.Start_time1 = DateTime.Parse("1900/01/01 " + this.mskStart_Time1.Text + ":00"); }

            if (this.mskEnd_Time2.Text == "  :") { this.End_time2 = DateTime.Parse("1900/01/01 00:00:00"); }
            else { this.Start_time2 = DateTime.Parse("1900/01/01 " + this.mskStart_Time2.Text + ":00"); }

            if (this.mskEnd_Time3.Text == "  :") { this.End_time3 = DateTime.Parse("1900/01/01 00:00:00"); }
            else { this.Start_time3 = DateTime.Parse("1900/01/01 " + this.mskStart_Time3.Text + ":00"); }

            // 残業時間
            if (this.txtOver_Time1.Text != "") { this.Over_time1 = int.Parse(this.txtOver_Time1.Text); }
            else { this.Over_time1 = 0; }
            if (this.txtOver_Time2.Text != "") { this.Over_time2 = int.Parse(this.txtOver_Time2.Text); }
            else { this.Over_time2 = 0; }
            if (this.txtOver_Time3.Text != "") { this.Over_time3 = int.Parse(this.txtOver_Time3.Text); }
            else { this.Over_time3 = 0; }

            // 早出通常残業時間
            if (this.txtStart_Over_Time1.Text != "") { this.Start_over_time1 = int.Parse(this.txtStart_Over_Time1.Text); }
            else { this.Start_over_time1 = 0; }
            if (this.txtStart_Over_Time2.Text != "") { this.Start_over_time2 = int.Parse(this.txtStart_Over_Time2.Text); }
            else { this.Start_over_time2 = 0; }
            if (this.txtStart_Over_Time3.Text != "") { this.Start_over_time3 = int.Parse(this.txtStart_Over_Time3.Text); }
            else { this.Start_over_time3 = 0; }
            if (this.txtEnd_Over_Time1.Text != "") { this.End_over_time1 = int.Parse(this.txtEnd_Over_Time1.Text); }
            else { this.End_over_time1 = 0; }
            if (this.txtEnd_Over_Time2.Text != "") { this.End_over_time2 = int.Parse(this.txtEnd_Over_Time2.Text); }
            else { this.End_over_time2 = 0; }
            if (this.txtEnd_Over_Time3.Text != "") { this.End_over_time3 = int.Parse(this.txtEnd_Over_Time3.Text); }
            else { this.End_over_time3 = 0; }

            // 理由区分
            this.Start_over_time_kbn1 = this.cmbStart_Over_Time_Kbn1.SelectedIndex;
            this.Start_over_time_kbn2 = this.cmbStart_Over_Time_Kbn2.SelectedIndex;
            this.Start_over_time_kbn3 = this.cmbStart_Over_Time_Kbn3.SelectedIndex;
            this.End_over_time_kbn1 = this.cmbEnd_Over_Time_Kbn1.SelectedIndex;
            this.End_over_time_kbn2 = this.cmbEnd_Over_Time_Kbn2.SelectedIndex;
            this.End_over_time_kbn3 = this.cmbEnd_Over_Time_Kbn3.SelectedIndex;

            // 理由
            this.Start_over_time_comment1 = this.txtStart_Over_Time_Comment1.Text;
            this.Start_over_time_comment2 = this.txtStart_Over_Time_Comment2.Text;
            this.Start_over_time_comment3 = this.txtStart_Over_Time_Comment3.Text;
            this.End_over_time_comment1 = this.txtEnd_Over_Time_Comment1.Text;
            this.End_over_time_comment2 = this.txtEnd_Over_Time_Comment2.Text;
            this.End_over_time_comment3 = this.txtEnd_Over_Time_Comment3.Text;

            // 休憩時間
            // 時間　※未入力の場合は1900/01/01 00:00:00をセットし、DB登録時はNULLに変換
            if (this.mskStart_Break_Time1.Text == "  :") { this.Start_break_time1 = DateTime.Parse("1900/01/01 00:00:00"); }
            else { this.Start_break_time1 = DateTime.Parse("1900/01/01 " + this.mskStart_Break_Time1.Text + ":00"); }

            if (this.mskStart_Break_Time2.Text == "  :") { this.Start_break_time2 = DateTime.Parse("1900/01/01 00:00:00"); }
            else { this.Start_break_time2 = DateTime.Parse("1900/01/01 " + this.mskStart_Break_Time2.Text + ":00"); }

            if (this.mskStart_Break_Time3.Text == "  :") { this.Start_break_time3 = DateTime.Parse("1900/01/01 00:00:00"); }
            else { this.Start_break_time3 = DateTime.Parse("1900/01/01 " + this.mskStart_Break_Time3.Text + ":00"); }

            if (this.mskEnd_Break_Time1.Text == "  :") { this.End_break_time1 = DateTime.Parse("1900/01/01 00:00:00"); }
            else { this.End_break_time1 = DateTime.Parse("1900/01/01 " + this.mskEnd_Break_Time1.Text + ":00"); }

            if (this.mskEnd_Break_Time2.Text == "  :") { this.End_break_time2 = DateTime.Parse("1900/01/01 00:00:00"); }
            else { this.End_break_time2 = DateTime.Parse("1900/01/01 " + this.mskEnd_Break_Time2.Text + ":00"); }

            if (this.mskEnd_Break_Time3.Text == "  :") { this.End_break_time3 = DateTime.Parse("1900/01/01 00:00:00"); }
            else { this.End_break_time3 = DateTime.Parse("1900/01/01 " + this.mskEnd_Break_Time3.Text + ":00"); }

            // 休憩時間
            if (this.txtBreak_Time1.Text != "") { this.Break_time1 = int.Parse(this.txtBreak_Time1.Text); }
            else { this.Break_time1 = 0; }
            if (this.txtBreak_Time2.Text != "") { this.Break_time2 = int.Parse(this.txtBreak_Time2.Text); }
            else { this.Break_time2 = 0; }
            if (this.txtBreak_Time3.Text != "") { this.Break_time3 = int.Parse(this.txtBreak_Time3.Text); }
            else { this.Break_time3 = 0; }


            // メーター　※未入力の場合は0をセットし、DB登録時はNULLに変換
            if (this.txtAfter_Meter.Text != "") { this.After_meter = int.Parse(this.txtAfter_Meter.Text); }
            else { this.After_meter = 0; }
            if (this.txtBefore_Meter.Text != "") { this.Before_meter = int.Parse(this.txtBefore_Meter.Text); }
            else { this.Before_meter = 0; }
            if (this.txtMileage.Text != "") { this.Mileage = int.Parse(this.txtMileage.Text); }
            else { this.Mileage = 0; }

            // 給油関連　※未入力の場合は0をセットし、DB登録時はNULLに変換
            if (this.txtFuel.Text != "") { this.Fuel = decimal.Parse(this.txtFuel.Text); }
            else { this.Fuel = 0; }
            if (this.txtFuel_Meter.Text != "") { this.Fuel_meter = int.Parse(this.txtFuel_Meter.Text); }
            else { this.Fuel_meter = 0; }
            if (this.txtOil.Text != "") { this.Oil = decimal.Parse(this.txtOil.Text); }
            else { this.Oil = 0; }
            if (this.txtKerosene.Text != "") { this.Kerosene = decimal.Parse(this.txtKerosene.Text); }
            else { this.Kerosene = 0; }

            // 社内チェック、承認
            if (this.chkConfirm1.Checked == true && this.Confirm1_id == 0)
            {
                this.Confirm1_id = ClsLoginUser.StaffID;
                this.Confirm1_date = DateTime.Now;
            }
            if (this.chkConfirm2.Checked == true && this.Confirm2_id == 0)
            {
                this.Confirm2_id = ClsLoginUser.StaffID;
                this.Confirm2_date = DateTime.Now;
            }
            if (this.chkConfirm3.Checked == true && this.Confirm3_id == 0)
            {
                this.Confirm3_id = ClsLoginUser.StaffID;
                this.Confirm3_date = DateTime.Now;
            }
            if (this.chkSalesConfirm.Checked == true && this.Sales_id == 0)
            {
                this.Sales_id = ClsLoginUser.StaffID;
                this.Sales_confirm_date = DateTime.Now;
            }

            //{
            //    this.Confirm1 = 1; 
            //}
            //else { this.Confirm1 = 0; }
            //if (this.chkConfirm21.Checked == true) { this.Confirm2 = 1; }
            //else { this.Confirm2 = 0; }

            // 代車
            if (this.chkSubcar.Checked == true) { this.Subcar_flag = 1; }
            else { this.Subcar_flag = 0; }

            // アルコールチェック　※未入力の場合は-1をセットし、DB登録時はNULLに変換
            if (this.txtAlcohol1.Text != "") { this.Alcohol1 = decimal.Parse(this.txtAlcohol1.Text); }
            else { this.Alcohol1 = -1; }
            if (this.txtAlcohol2.Text != "") { this.Alcohol2 = decimal.Parse(this.txtAlcohol2.Text); }
            else { this.Alcohol2 = -1; }
            if (this.txtAlcohol3.Text != "") { this.Alcohol3 = decimal.Parse(this.txtAlcohol3.Text); }
            else { this.Alcohol3 = -1; }

            // ※未選択時は-1をセットし、DB登録時はNULLに変換
            if (this.rdoAlcohol_Check1_Ok.Checked == true) { this.Alcohol_check1 = 1; }
            else if (this.rdoAlcohol_Check1_Ng.Checked == true) { this.Alcohol_check1 = 0; }
            else { this.Alcohol_check1 = -1; }
            if (this.rdoAlcohol_Check2_Ok.Checked == true) { this.Alcohol_check2 = 1; }
            else if (this.rdoAlcohol_Check2_Ng.Checked == true) { this.Alcohol_check2 = 0; }
            else { this.Alcohol_check2 = -1; }
            if (this.rdoAlcohol_Check3_Ok.Checked == true) { this.Alcohol_check3 = 1; }
            else if (this.rdoAlcohol_Check3_Ng.Checked == true) { this.Alcohol_check3 = 0; }
            else { this.Alcohol_check3 = -1; }

            // 検温　※未入力の場合は1900/01/01 00:00:00をセットし、DB登録時はNULLに変換
            if (this.mskTemp_Time1.Text == "  :") { this.Temp_time1 = DateTime.Parse("1900/01/01 00:00:00"); }
            else { this.Temp_time1 = DateTime.Parse("1900/01/01 " + this.mskTemp_Time1.Text + ":00"); }
            if (this.mskTemp_Time2.Text == "  :") { this.Temp_time2 = DateTime.Parse("1900/01/01 00:00:00"); }
            else { this.Temp_time2 = DateTime.Parse("1900/01/01 " + this.mskTemp_Time2.Text + ":00"); }
            if (this.mskTemp_Time3.Text == "  :") { this.Temp_time3 = DateTime.Parse("1900/01/01 00:00:00"); }
            else { this.Temp_time3 = DateTime.Parse("1900/01/01 " + this.mskTemp_Time3.Text + ":00"); }

            // ※未入力の場合は0をセットし、DB登録時はNULLに変換
            if (this.txtTemp1.Text != "") { this.Temp1 = decimal.Parse(this.txtTemp1.Text); }
            else { this.Temp1 = 0; }
            if (this.txtTemp2.Text != "") { this.Temp2 = decimal.Parse(this.txtTemp2.Text); }
            else { this.Temp2 = 0; }
            if (this.txtTemp3.Text != "") { this.Temp3 = decimal.Parse(this.txtTemp3.Text); }
            else { this.Temp3 = 0; }


            // 備考 ※未入力の場合はNULLをセット
            // 備考区分は既にセットされている為、ここでの処理は無し
            if (this.txtComment.Text != "") { this.Comment = this.txtComment.Text; }
            else { this.Comment = null; }

            // 同乗者
            if (this.chkPassenger.Checked ==  true) { this.Passenger_id = 2; }
            else { this.Passenger_id = 0; }

        }
        /// <summary>
        /// 日報入力データ表示
        /// </summary>
        private void Display_ReportData()
        {
            // 日報ID表示
            if ( this.Report_id > 0 ) { this.lblReport_Id.Text = this.Report_id.ToString(); }
            else { return; }

            // =====================================================================================
            // 日報入力データ表示
            // =====================================================================================
            this.lblLocation_Name.Text = this.Location_name;                                    
            this.dtptDay.Value = this.Day;
            this.lblCar_No.Text = this.Car_no;
            if (this.Car_fullname != "") { this.lblCar_No.Text = this.Car_no + " : " + this.Car_fullname; }
            else { this.lblCar_No.Text = "未設定"; }
                this.lblInstructor_Name.Text = this.Instructor_name;
            this.lblStaff_Name1.Text = this.Staff_name1;

            // 始業・終業場所
            // if (this.Start_location != null) { this.lblStart_Location.Text = this.Start_location; }
            // if (this.End_location != null) { this.lblEnd_Location.Text = this.End_location; }

            // 開始時間
            if (this.Start_time1 != null && this.Start_time1.ToString("HH:mm") != "00:00") { this.mskStart_Time1.Text = DateTime.Parse(this.Start_time1.ToString()).ToString("HH:mm"); }
            else { this.mskStart_Time1.Text = ""; }
            if (this.Start_time2 != null && this.Start_time2.ToString("HH:mm") != "00:00") { this.mskStart_Time2.Text = DateTime.Parse(this.Start_time2.ToString()).ToString("HH:mm"); }
            else { this.mskStart_Time2.Text = ""; }
            if (this.Start_time3 != null && this.Start_time3.ToString("HH:mm") != "00:00") { this.mskStart_Time3.Text = DateTime.Parse(this.Start_time3.ToString()).ToString("HH:mm"); }
            else { this.mskStart_Time3.Text = ""; }
            // 終了時間
            if (this.End_time1 != null && this.End_time1.ToString("HH:mm") != "00:00") { this.mskEnd_Time1.Text = DateTime.Parse(this.End_time1.ToString()).ToString("HH:mm"); }
            else { this.mskEnd_Time1.Text = ""; }
            if (this.End_time2 != null && this.End_time2.ToString("HH:mm") != "00:00") { this.mskEnd_Time2.Text = DateTime.Parse(this.End_time2.ToString()).ToString("HH:mm"); }
            else { this.mskEnd_Time2.Text = ""; }
            if (this.End_time3 != null && this.End_time3.ToString("HH:mm") != "00:00") { this.mskEnd_Time3.Text = DateTime.Parse(this.End_time3.ToString()).ToString("HH:mm"); }
            else { this.mskEnd_Time3.Text = ""; }
            // 残業時間
            if (this.Over_time1 != 0) { this.txtOver_Time1.Text = this.Over_time1.ToString(); }
            else { this.txtOver_Time1.Text = ""; }
            if (this.Over_time2 != 0) { this.txtOver_Time2.Text = this.Over_time2.ToString(); }
            else { this.txtOver_Time2.Text = ""; }
            if (this.Over_time3 != 0) { this.txtOver_Time3.Text = this.Over_time3.ToString(); }
            else { this.txtOver_Time3.Text = ""; }

            // 基本契約時間
            // 開始時間
            if (this.Basic_Start_time1 != null && this.Basic_Start_time1.ToString("HH:mm") != "00:00") { this.mskBasic_Start_Time1.Text = DateTime.Parse(this.Basic_Start_time1.ToString()).ToString("HH:mm"); }
            else { this.mskBasic_Start_Time1.Text = ""; }
            if (this.Basic_Start_time2 != null && this.Basic_Start_time2.ToString("HH:mm") != "00:00") { this.mskBasic_Start_Time2.Text = DateTime.Parse(this.Basic_Start_time2.ToString()).ToString("HH:mm"); }
            else { this.mskBasic_Start_Time2.Text = ""; }
            if (this.Basic_Start_time3 != null && this.Basic_Start_time3.ToString("HH:mm") != "00:00") { this.mskBasic_Start_Time3.Text = DateTime.Parse(this.Basic_Start_time3.ToString()).ToString("HH:mm"); }
            else { this.mskBasic_Start_Time3.Text = ""; }
            // 終了時間
            if (this.Basic_End_time1 != null && this.Basic_End_time1.ToString("HH:mm") != "00:00") { this.mskBasic_End_Time1.Text = DateTime.Parse(this.Basic_End_time1.ToString()).ToString("HH:mm"); }
            else { this.mskBasic_End_Time1.Text = ""; }
            if (this.Basic_End_time2 != null && this.Basic_End_time2.ToString("HH:mm") != "00:00") { this.mskBasic_End_Time2.Text = DateTime.Parse(this.Basic_End_time2.ToString()).ToString("HH:mm"); }
            else { this.mskBasic_End_Time2.Text = ""; }
            if (this.Basic_End_time3 != null && this.Basic_End_time3.ToString("HH:mm") != "00:00") { this.mskBasic_End_Time3.Text = DateTime.Parse(this.Basic_End_time3.ToString()).ToString("HH:mm"); }
            else { this.mskBasic_End_Time3.Text = ""; }

            // 早出通常残業時間
            if (this.Start_over_time1 != 0) { this.txtStart_Over_Time1.Text = this.Start_over_time1.ToString(); }
            else { this.txtStart_Over_Time1.Text = ""; }
            if (this.Start_over_time2 != 0) { this.txtStart_Over_Time2.Text = this.Start_over_time2.ToString(); }
            else { this.txtStart_Over_Time2.Text = ""; }
            if (this.Start_over_time3 != 0) { this.txtStart_Over_Time3.Text = this.Start_over_time3.ToString(); }
            else { this.txtStart_Over_Time3.Text = ""; }
            if (this.End_over_time1 != 0) { this.txtEnd_Over_Time1.Text = this.End_over_time1.ToString(); }
            else { this.txtEnd_Over_Time1.Text = ""; }
            if (this.End_over_time2 != 0) { this.txtEnd_Over_Time2.Text = this.End_over_time2.ToString(); }
            else { this.txtEnd_Over_Time2.Text = ""; }
            if (this.End_over_time3 != 0) { this.txtEnd_Over_Time3.Text = this.End_over_time3.ToString(); }
            else { this.txtEnd_Over_Time3.Text = ""; }

            this.cmbStart_Over_Time_Kbn1.SelectedIndex = this.Start_over_time_kbn1;
            this.cmbStart_Over_Time_Kbn2.SelectedIndex = this.Start_over_time_kbn2;
            this.cmbStart_Over_Time_Kbn3.SelectedIndex = this.Start_over_time_kbn3;
            this.cmbEnd_Over_Time_Kbn1.SelectedIndex = this.End_over_time_kbn1;
            this.cmbEnd_Over_Time_Kbn2.SelectedIndex = this.End_over_time_kbn2;
            this.cmbEnd_Over_Time_Kbn3.SelectedIndex = this.End_over_time_kbn3;

            if (this.Start_over_time_comment1 != null && this.Start_over_time_comment1 != "") { this.txtStart_Over_Time_Comment1.Text = this.Start_over_time_comment1; }
            else { this.txtStart_Over_Time_Comment1.Text = ""; }
            if (this.Start_over_time_comment2 != null && this.Start_over_time_comment2 != "") { this.txtStart_Over_Time_Comment2.Text = this.Start_over_time_comment2; }
            else { this.txtStart_Over_Time_Comment2.Text = ""; }
            if (this.Start_over_time_comment3 != null && this.Start_over_time_comment3 != "") { this.txtStart_Over_Time_Comment3.Text = this.Start_over_time_comment3; }
            else { this.txtStart_Over_Time_Comment3.Text = ""; }
            if (this.End_over_time_comment1 != null && this.End_over_time_comment1 != "") { this.txtEnd_Over_Time_Comment1.Text = this.End_over_time_comment1; }
            else { this.txtEnd_Over_Time_Comment1.Text = ""; }
            if (this.End_over_time_comment2 != null && this.End_over_time_comment2 != "") { this.txtEnd_Over_Time_Comment2.Text = this.End_over_time_comment2; }
            else { this.txtEnd_Over_Time_Comment2.Text = ""; }
            if (this.End_over_time_comment3 != null && this.End_over_time_comment3 != "") { this.txtEnd_Over_Time_Comment3.Text = this.End_over_time_comment3; }
            else { this.txtEnd_Over_Time_Comment3.Text = ""; }

            // 休憩開始時間
            if (this.Start_break_time1 != null && this.Start_break_time1.ToString("HH:mm") != "00:00") { this.mskStart_Break_Time1.Text = DateTime.Parse(this.Start_break_time1.ToString()).ToString("HH:mm"); }
            else { this.mskStart_Break_Time1.Text = ""; }
            if (this.Start_break_time2 != null && this.Start_break_time2.ToString("HH:mm") != "00:00") { this.mskStart_Break_Time2.Text = DateTime.Parse(this.Start_break_time2.ToString()).ToString("HH:mm"); }
            else { this.mskStart_Break_Time2.Text = ""; }
            if (this.Start_break_time3 != null && this.Start_break_time3.ToString("HH:mm") != "00:00") { this.mskStart_Break_Time3.Text = DateTime.Parse(this.Start_break_time3.ToString()).ToString("HH:mm"); }
            else { this.mskStart_Break_Time3.Text = ""; }
            // 休憩終了時間
            if (this.End_break_time1 != null && this.End_break_time1.ToString("HH:mm") != "00:00") { this.mskEnd_Break_Time1.Text = DateTime.Parse(this.End_break_time1.ToString()).ToString("HH:mm"); }
            else { this.mskEnd_Break_Time1.Text = ""; }
            if (this.End_break_time2 != null && this.End_break_time2.ToString("HH:mm") != "00:00") { this.mskEnd_Break_Time2.Text = DateTime.Parse(this.End_break_time2.ToString()).ToString("HH:mm"); }
            else { this.mskEnd_Break_Time2.Text = ""; }
            if (this.End_break_time3 != null && this.End_break_time3.ToString("HH:mm") != "00:00") { this.mskEnd_Break_Time3.Text = DateTime.Parse(this.End_break_time3.ToString()).ToString("HH:mm"); }
            else { this.mskEnd_Break_Time3.Text = ""; }
            // 休憩時間
            if (this.Break_time1 != 0) { this.txtBreak_Time1.Text = this.Break_time1.ToString(); }
            else { this.txtBreak_Time1.Text = ""; }
            if (this.Break_time2 != 0) { this.txtBreak_Time2.Text = this.Break_time2.ToString(); }
            else { this.txtBreak_Time2.Text = ""; }
            if (this.Break_time3 != 0) { this.txtBreak_Time3.Text = this.Break_time3.ToString(); }
            else { this.txtBreak_Time3.Text = ""; }

            // 代車
            if (this.Subcar_flag == 1) { this.chkSubcar.Checked = true; }
            else { this.chkSubcar.Checked = false; }

            // 入庫・出庫時メーター・走行距離
            if (this.After_meter != 0) { this.txtAfter_Meter.Text = this.After_meter.ToString(); }
            else { this.txtAfter_Meter.Text = ""; }
            if (this.Before_meter != 0) { this.txtBefore_Meter.Text = this.Before_meter.ToString(); }
            else { this.txtBefore_Meter.Text = ""; }
            if (this.Mileage != 0) { this.txtMileage.Text = this.Mileage.ToString(); }
            else { this.txtMileage.Text = ""; }
            // 給油量・給油時メーター・オイル・灯油
            if (this.Fuel != 0) { this.txtFuel.Text = this.Fuel.ToString(); }
            else { this.txtFuel.Text = ""; }
            if (this.Fuel_meter != 0) { this.txtFuel_Meter.Text = this.Fuel_meter.ToString(); }
            else { this.txtFuel_Meter.Text = ""; }
            if (this.Oil != 0) { this.txtOil.Text = this.Oil.ToString(); }
            else { this.txtOil.Text = ""; }
            if (this.Kerosene != 0) { this.txtKerosene.Text = this.Kerosene.ToString(); }
            else { this.txtKerosene.Text = ""; }
            // =====================================================================================
            // 日報　チェックデータ
            // =====================================================================================
            // アルコール濃度①②③
            if (this.Alcohol1 != -1) { this.txtAlcohol1.Text = decimal.Parse(this.Alcohol1.ToString()).ToString(); }
            else { this.txtAlcohol1.Text = ""; }
            if (this.Alcohol2 != -1) { this.txtAlcohol2.Text = decimal.Parse(this.Alcohol2.ToString()).ToString(); }
            else { this.txtAlcohol2.Text = ""; }
            if (this.Alcohol3 != -1) { this.txtAlcohol3.Text = decimal.Parse(this.Alcohol3.ToString()).ToString(); }
            else { this.txtAlcohol3.Text = ""; }

            // アルコールチェック①②③
            if (this.Alcohol_check1 == 1) { this.rdoAlcohol_Check1_Ok.Checked = true; }
            else if (this.Alcohol_check1 == 0) { this.rdoAlcohol_Check1_Ng.Checked = true; }
            if (this.Alcohol_check2 == 1) { this.rdoAlcohol_Check2_Ok.Checked = true; }
            else if (this.Alcohol_check2 == 0) { this.rdoAlcohol_Check2_Ng.Checked = true; }
            if (this.Alcohol_check3 == 1) { this.rdoAlcohol_Check3_Ok.Checked = true; }
            else if (this.Alcohol_check3 == 0) { this.rdoAlcohol_Check3_Ng.Checked = true; }

            // 検温①②③
            if (this.Temp1 != 0) { this.txtTemp1.Text = decimal.Parse(this.Temp1.ToString()).ToString(); }
            else { this.txtTemp1.Text = ""; }
            if (this.Temp2 != 0) { this.txtTemp2.Text = decimal.Parse(this.Temp2.ToString()).ToString(); }
            else { this.txtTemp2.Text = ""; }
            if (this.Temp3 != 0) { this.txtTemp3.Text = decimal.Parse(this.Temp3.ToString()).ToString(); }
            else { this.txtTemp3.Text = ""; }

            // 検温時刻①②③
            if (this.Temp_time1.ToString("HH:mm") != "00:00") { this.mskTemp_Time1.Text = DateTime.Parse(this.Temp_time1.ToString()).ToString("HH:mm"); }
            else { this.mskTemp_Time1.Text = ""; }
            if (this.Temp_time2.ToString("HH:mm") != "00:00") { this.mskTemp_Time2.Text = DateTime.Parse(this.Temp_time2.ToString()).ToString("HH:mm"); }
            else { this.mskTemp_Time2.Text = ""; }
            if (this.Temp_time3.ToString("HH:mm") != "00:00") { this.mskTemp_Time3.Text = DateTime.Parse(this.Temp_time3.ToString()).ToString("HH:mm"); }
            else { this.mskTemp_Time3.Text = ""; }

            // =====================================================================================
            // 日報　備考
            // =====================================================================================
            if (this.Comment_kbn_name != null && this.Comment_kbn_name != "") { this.lblComment_Kbn.Text = this.Comment_kbn_name; }
            else { this.lblComment_Kbn.Text = ""; }
            if (this.Comment != null && this.Comment != "") { this.txtComment.Text = this.Comment; }
            else { this.txtComment.Text = ""; }
            if (this.Passenger_id == 2) { this.chkPassenger.Checked = true; }
            else { this.chkPassenger.Checked = false; }

            // =====================================================================================
            // 日報　承認
            // =====================================================================================
            // 一次確認
            if (this.Confirm1_id > 0)
            {
                this.chkConfirm1.Checked = true;
                this.lblConfirm1Date.Text = this.Confirm1_date.ToString("yyyy/MM/dd");
                this.lblConfirm1Name.Text = this.Confirm1_name.ToString();
                if (this.Confirm1_id == ClsLoginUser.StaffID) { this.chkConfirm1.Enabled = true; }
                else { this.chkConfirm1.Enabled = false; }
            }
            // 二次確認
            if (this.Confirm2_id > 0)
            {
                this.chkConfirm2.Checked = true;
                this.lblConfirm2Date.Text = this.Confirm2_date.ToString("yyyy/MM/dd");
                this.lblConfirm2Name.Text = this.Confirm2_name.ToString();
                if (this.Confirm2_id == ClsLoginUser.StaffID) { this.chkConfirm2.Enabled = true; }
                else { this.chkConfirm2.Enabled = false; }
            }
            // 三次確認
            if (this.Confirm3_id > 0)
            {
                this.chkConfirm3.Checked = true;
                this.lblConfirm3Date.Text = this.Confirm3_date.ToString("yyyy/MM/dd");
                this.lblConfirm3Name.Text = this.Confirm3_name.ToString();
                if (this.Confirm3_id == ClsLoginUser.StaffID) { this.chkConfirm3.Enabled = true; }
                else { this.chkConfirm3.Enabled = false; }
            }
            // 営業承認
            if (this.Sales_id > 0)
            {
                this.chkSalesConfirm.Checked = true;
                this.lblSalesConfirmDate.Text = this.Sales_confirm_date.ToString("yyyy/MM/dd");
                this.lblSalesName.Text = this.Sales_name.ToString();
                if (this.Sales_id == ClsLoginUser.StaffID) { this.chkSalesConfirm.Enabled = true; }
                else { this.chkSalesConfirm.Enabled = false; }
            }
            // 顧客承認
            if (this.Guest_id > 0)
            {
                this.lblGuestConfirm.Visible = true;
                this.lblGuestConfirmDate.Text = this.Guest_confirm_date.ToString("yyyy/MM/dd");
                this.lblGuestName.Text = this.Guest_name.ToString();
            }
        }

        /// <summary>
        /// 専従先選択ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectLocation_Click(object sender, EventArgs e)
        {
            frmSelectLocation fSelectLocation = new()
            {
                TargetTable = "Mst_専従先",
                Select_location_name = "",
                Select_location_id = 0
            };
            fSelectLocation.ShowDialog();

            if (fSelectLocation.Select_location_id == 0) return;

            this.Location_id = fSelectLocation.Select_location_id;
            this.lblLocation_Name.Text = fSelectLocation.Select_location_name.ToString();

            // 管理責任者情報取得
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" Mst_専従先.instructor_id");
                    sb.AppendLine(",Mst_社員.fullname");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_専従先");
                    sb.AppendLine("LEFT JOIN");
                    sb.AppendLine("Mst_社員");
                    sb.AppendLine("ON");
                    sb.AppendLine("Mst_専従先.instructor_id = Mst_社員.staff_id");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("location_id = " + this.Location_id);

                    // 処理改善 2025/09/02
                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            this.Instructor_id = int.Parse(dr["instructor_id"].ToString());
                            this.lblInstructor_Name.Text = dr["fullname"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 管理責任者選択ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectInstructor_Click(object sender, EventArgs e)
        {
            frmSelectStaff fSelectStaff = new()
            {
                TargetTable = "Mst_社員",
                Select_user_name = "",
                Select_user_id = 0
            };
            fSelectStaff.ShowDialog();
            if (fSelectStaff.Select_user_id == 0) { return; }

            // 管理責任者情報取得
            // StringBuilder st = new StringBuilder();

            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("Mst_社員.fullname");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_社員");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("staff_id = " + fSelectStaff.Select_user_id);

                    // 処理改善 2025/09/02
                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            this.Instructor_id = fSelectStaff.Select_user_id;
                            this.lblInstructor_Name.Text = dr["fullname"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 担当者選択ボタン１
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectUser_Click(object sender, EventArgs e)
        {
            frmSelectStaff fSelectStaff = new()
            {
                TargetTable = "Mst_社員",
                Select_user_name = "",
                Select_user_id = 0
            };
            fSelectStaff.ShowDialog();
            if (fSelectStaff.Select_user_id == 0) { return; }

            // 管理責任者情報取得

            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("Mst_社員.fullname");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_社員");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("staff_id = " + fSelectStaff.Select_user_id);

                    // 処理改善 2025/09/02
                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            this.Staff_id1 = fSelectStaff.Select_user_id;
                            this.lblStaff_Name1.Text = dr["fullname"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 車両選択ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectCar_Click(object sender, EventArgs e)
        {
            frmSelectItem fSelectItem = new()
            {
                IntKey = this.Location_id,
                Kbn = 6,                  // 専従先車両
                Value = 0
            };
            fSelectItem.ShowDialog();
            if (fSelectItem.Value == 0) { return; }

            // 車両情報保持
            this.Car_id = fSelectItem.Value;
            this.lblCar_No.Text = fSelectItem.StrVal;
        }
        /// <summary>
        /// 入庫前メーターテキストボックス値変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAfter_Meter_TextChanged(object sender, EventArgs e)
        {
            CalcMileage();
        }
        /// <summary>
        /// 出庫前メーターテキストボックス値変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBefore_Meter_TextChanged(object sender, EventArgs e)
        {
            CalcMileage();
        }
        /// <summary>
        /// 走行距離計算
        /// </summary>
        private void CalcMileage()
        {
            string after = txtAfter_Meter.Text;
            string before = txtBefore_Meter.Text;

            // 入庫時、出庫時どちらかが未入力の場合は処理終了
            if (after == null || after == "") { return; }
            if (before == null || before == "") { return; }

            // 入庫時メーター - 出庫時メーター
            txtMileage.Text = ((int)decimal.Parse(after) - (int)decimal.Parse(before)).ToString();
        }
        /// <summary>
        /// 備考区分選択ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectComment_Kbn_Click(object sender, EventArgs e)
        {
            frmSelectItem fSelectItem = new()
            {
                Kbn = 9,                  // 
                Value = 0
            };
            fSelectItem.ShowDialog();
            if (fSelectItem.Value == 0) { return; }

            this.Comment_kbn = fSelectItem.Value;
            this.Comment_kbn_name = fSelectItem.StrVal;
            this.lblComment_Kbn.Text = this.Comment_kbn_name;
        }
        /// <summary>
        /// 新規ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            // 入力項目初期化
            Initialize_Display();

            // Private値初期化
            Initialize_Data();

            // 新規ラベル
            this.lblNew.Visible = true;

            // 編集ブロック項目解除
            this.btnSelectLocation.Enabled = true;
        }
        /// <summary>
        /// 保存ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReg_Click(object sender, EventArgs e)
        {
            // 入力チェック
            var error_message = string.Empty;
            if (!Check_ReportData(out error_message))
            {
                // エラーの場合はメッセージ
                MessageBox.Show(error_message,"エラー",MessageBoxButtons.OK);
                return;
            }

            // 日報データセット
            Set_ReportData();

            // 日報データクラス
            ClsTrnReport cls = new();
            // 更新の場合はIDをキーにセット
            if (this.lblNew.Visible != true) { cls.Key_report_id = this.Report_id; }    // Update Key

            // Reportクラスに値セット
            // ==========================================================
            // Trn_日報
            // ==========================================================
            cls.Location_id = this.Location_id;
            cls.Car_id = this.Car_id;
            cls.Day = this.Day;
            cls.Instructor_id = this.Instructor_id;
            cls.Staff_id1 = this.Staff_id1;
            cls.Staff_id2 = 0;
            cls.Staff_id3 = 0;
            cls.After_meter = this.After_meter;
            cls.Before_meter = this.Before_meter;
            cls.Mileage = this.Mileage;
            cls.Fuel = this.Fuel;
            cls.Fuel_meter = this.Fuel_meter;
            cls.Oil = this.Oil;
            cls.Kerosene = this.Kerosene;
            // cls.Start_location = this.Start_location;
            // cls.End_location = this.End_location;
            cls.Start_time1 = this.Start_time1;
            cls.Start_time2 = this.Start_time2;
            cls.Start_time3 = this.Start_time3;
            cls.End_time1 = this.End_time1;
            cls.End_time2 = this.End_time2;
            cls.End_time3 = this.End_time3;
            cls.Over_time1 = this.Over_time1;
            cls.Over_time2 = this.Over_time2;
            cls.Over_time3 = this.Over_time3;

            // 早出残業
            cls.Start_over_time1 = this.Start_over_time1;
            cls.Start_over_time2 = this.Start_over_time2;
            cls.Start_over_time3 = this.Start_over_time3;
            cls.Start_over_time_kbn1 = this.Start_over_time_kbn1;
            cls.Start_over_time_kbn2 = this.Start_over_time_kbn2;
            cls.Start_over_time_kbn3 = this.Start_over_time_kbn3;
            cls.Start_over_time_comment1 = this.Start_over_time_comment1;
            cls.Start_over_time_comment2 = this.Start_over_time_comment2;
            cls.Start_over_time_comment3 = this.Start_over_time_comment3;

            // 終業後残業
            cls.End_over_time1 = this.End_over_time1;
            cls.End_over_time2 = this.End_over_time2;
            cls.End_over_time3 = this.End_over_time3;
            cls.End_over_time_kbn1 = this.End_over_time_kbn1;
            cls.End_over_time_kbn2 = this.End_over_time_kbn2;
            cls.End_over_time_kbn3 = this.End_over_time_kbn3;
            cls.End_over_time_comment1 = this.End_over_time_comment1;
            cls.End_over_time_comment2 = this.End_over_time_comment2;
            cls.End_over_time_comment3 = this.End_over_time_comment3;

            // 休憩時間
            cls.Start_break_time1 = this.Start_break_time1;
            cls.Start_break_time2 = this.Start_break_time2;
            cls.Start_break_time3 = this.Start_break_time3;
            cls.End_break_time1 = this.End_break_time1;
            cls.End_break_time2 = this.End_break_time2;
            cls.End_break_time3 = this.End_break_time3;
            cls.Break_time1 = this.Break_time1;
            cls.Break_time2 = this.Break_time2;
            cls.Break_time3 = this.Break_time3;

            cls.Subcar_flag = this.Subcar_flag;

            // ==================================================================
            // ==================================================================
            // ==================================================================
            cls.Confirm1_id = this.Confirm1_id;
            cls.Confirm1_date = this.Confirm1_date;
            cls.Confirm2_id = this.Confirm2_id;
            cls.Confirm2_date = this.Confirm2_date;
            cls.Confirm3_id = this.Confirm3_id;
            cls.Confirm3_date = this.Confirm3_date;
            cls.Sales_id = this.Sales_id;
            cls.Sales_confirm_date = this.Sales_confirm_date;
            cls.Guest_id = this.Guest_id;
            cls.Guest_confirm_date = this.Guest_confirm_date;
            cls.Confirm_status = this.Confirm_status;

            // ==========================================================
            // Trn_日報_チェック
            // ==========================================================
            cls.Temp1 = this.Temp1;
            cls.Temp2 = this.Temp2;
            cls.Temp3 = this.Temp3;
            cls.Temp_time1 = this.Temp_time1;
            cls.Temp_time2 = this.Temp_time2;
            cls.Temp_time3 = this.Temp_time3;
            cls.Alcohol1 = this.Alcohol1;
            cls.Alcohol2 = this.Alcohol2;
            cls.Alcohol3 = this.Alcohol3;
            cls.Alcohol_check1 = this.Alcohol_check1;
            cls.Alcohol_check2 = this.Alcohol_check2;
            cls.Alcohol_check3 = this.Alcohol_check3;

            // ==========================================================
            // Trn_日報_運行前点検
            // ==========================================================
            //cls.Inspection_check1 = this.Inspection_check1;
            //cls.Inspection_check2 = this.Inspection_check2;
            //cls.Inspection_check3 = this.Inspection_check3;
            //cls.Inspection_check4 = this.Inspection_check4;
            //cls.Inspection_check5 = this.Inspection_check5;
            //cls.Inspection_check6 = this.Inspection_check6;
            //cls.Inspection_check7 = this.Inspection_check7;

            // ==========================================================
            // Trn_日報_定期点検
            // ==========================================================
            //cls.Per_inspection_check1 = this.Per_inspection_check1;
            //cls.Per_inspection_check2 = this.Per_inspection_check2;
            //cls.Per_inspection_check3 = this.Per_inspection_check3;
            //cls.Per_inspection_check4 = this.Per_inspection_check4;
            //cls.Per_inspection_check5 = this.Per_inspection_check5;
            //cls.Per_inspection_check6 = this.Per_inspection_check6;
            //cls.Per_inspection_check7 = this.Per_inspection_check7;
            //cls.Per_inspection_check8 = this.Per_inspection_check8;
            //cls.Per_inspection_check9 = this.Per_inspection_check9;
            //cls.Per_inspection_check10 = this.Per_inspection_check10;
            //cls.Per_inspection_check11 = this.Per_inspection_check11;
            //cls.Per_inspection_check12 = this.Per_inspection_check12;
            //cls.Per_inspection_check13 = this.Per_inspection_check13;
            //cls.Per_inspection_check14 = this.Per_inspection_check14;

            // ==========================================================
            // Trn_日報_大型点検
            // ==========================================================
            //cls.Large_inspection_check1 = this.Large_inspection_check1;
            //cls.Large_inspection_check2 = this.Large_inspection_check2;
            //cls.Large_inspection_check3 = this.Large_inspection_check3;
            //cls.Large_inspection_check4 = this.Large_inspection_check4;

            // ==========================================================
            // Trn_日報_備考
            // ==========================================================
            cls.Comment_kbn = this.Comment_kbn;
            cls.Comment = this.Comment;
            cls.Passenger_id = this.Passenger_id;

            if (this.lblNew.Visible != true)
            {
                // ==========================================================
                // UPDATE
                // ==========================================================
                cls.Update();
            }
            else
            {
                // ==========================================================
                // INSERT (XServer)
                // ==========================================================
                cls.Insert();
            }

            MessageBox.Show("登録しました。", "結果", MessageBoxButtons.OK);
        }
        /// <summary>
        /// 点検結果ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            using (frmResultCarCheck frmResultCarCheck = new frmResultCarCheck())
            {
                frmResultCarCheck.Report_id = this.Report_id;
                frmResultCarCheck.ShowDialog();
            }
        }
        /// <summary>
        /// 備考区分選択ボタン (区分：702）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectComment_Kbn_Click_1(object sender, EventArgs e)
        {
            frmSelectItem cls = new()
            {
                Kbn = 9
            };
            cls.ShowDialog();
            if (cls.Value > 0)
            {
                this.lblComment_Kbn.Text = cls.StrVal;
                this.Comment_kbn_name = cls.StrVal;
                this.Comment_kbn = cls.Value;
            }
        }
        /// <summary>
        /// 前の日報ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBefore_Click(object sender, EventArgs e)
        {
            // 表示中の日報のindex取得
            var cur_idx = Array.IndexOf(clsPublicReport.pub_Id_list, clsPublicReport.pub_Current_id);

            if (cur_idx < 0)
            {
                // 該当なし
                return;
            } else if (cur_idx == 0)
            {
                // 先頭の日報の場合、メッセージ表示
                MessageBox.Show("これより前の日報はありません。一覧の表示条件を変えて再表示してください。", "情報", MessageBoxButtons.OK);
                return;
            }

            // 1つ前の日報のid取得
            this.Report_id = clsPublicReport.pub_Id_list[cur_idx - 1];

            // 1つ前の日報を表示
            // 入力項目初期化
            Initialize_Display();

            // Private値初期化
            Initialize_Data();

            clsPublicReport.pub_Current_id = this.Report_id;

            // 編集ブロック項目
            this.btnSelectLocation.Enabled = false;
            this.btnSelectCar.Enabled = false;
            this.btnSelectInstructor.Enabled = false;
            this.btnSelectUser1.Enabled = false;

            // 日報入力データセット
            Get_ReportData();

            // 基本契約時間データセット
            Get_ContractTimeData();

            // 日報入力データ表示
            Display_ReportData();
        }
        /// <summary>
        /// 後の日報ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAfter_Click(object sender, EventArgs e)
        {
            // 1つ後の表示のID取得
            var cur_idx = Array.IndexOf(clsPublicReport.pub_Id_list, clsPublicReport.pub_Current_id);

            if (cur_idx < 0)
            {
                // 該当なし
                return;
            }
            else if (clsPublicReport.pub_Id_list.Length == cur_idx+1)
            {
                // 最後の日報の場合、メッセージ表示
                MessageBox.Show("これより後の日報はありません。一覧の表示条件を変えて再表示してください。", "情報", MessageBoxButtons.OK);
                return;
            }

            // 1つ後の日報のid取得
            this.Report_id = clsPublicReport.pub_Id_list[cur_idx + 1];

            // 1つ後の日報を表示
            // 入力項目初期化
            Initialize_Display();

            // Private値初期化
            Initialize_Data();

            clsPublicReport.pub_Current_id = this.Report_id;

            // 編集ブロック項目
            this.btnSelectLocation.Enabled = false;
            this.btnSelectCar.Enabled = false;
            this.btnSelectInstructor.Enabled = false;
            this.btnSelectUser1.Enabled = false;

            // 日報入力データセット
            Get_ReportData();

            // 基本契約時間データセット
            Get_ContractTimeData();

            // 日報入力データ表示
            Display_ReportData();
        }

        /// <summary>
        /// 入力チェック
        /// </summary>
        /// <param name="error_msg"></param>
        /// <returns></returns>
        private Boolean Check_ReportData(out string error_msg)
        {
            error_msg = string.Empty;

            // ========================================================
            // 実走時間チェック
            // ========================================================
            // 実走時間1
            if (this.mskStart_Time1.Text != "  :" || this.mskEnd_Time1.Text != "  :")
            {
                if(!clsPublicReport.CheckInputStartEndTime(this.mskStart_Time1.Text, this.mskEnd_Time1.Text,out error_msg))
                {
                    this.mskStart_Time1.Focus();
                    return false; 
                }
            }
            // 実走時間2
            if (this.mskStart_Time2.Text != "  :" || this.mskEnd_Time2.Text != "  :")
            {
                if (!clsPublicReport.CheckInputStartEndTime(this.mskStart_Time2.Text, this.mskEnd_Time2.Text, out error_msg))
                {
                    this.mskStart_Time2.Focus();
                    return false;
                }
            }
            // 実走時間3
            if (this.mskStart_Time3.Text != "  :" || this.mskEnd_Time3.Text != "  :")
            {
                if (!clsPublicReport.CheckInputStartEndTime(this.mskStart_Time3.Text, this.mskEnd_Time3.Text, out error_msg))
                {
                    this.mskStart_Time3.Focus();
                    return false;
                }
            }
            // ========================================================
            // 残業時間チェック：計算した残業時間と入力された残業時間
            // ========================================================
            // 実走１残業時間
            if (this.mskStart_Time1.Text != "  :" || this.mskEnd_Time1.Text != "  :")
            {
                var result_over_time = clsPublicReport.CalcOvertimeMinutes(DateTime.Parse(this.mskStart_Time1.Text), DateTime.Parse(this.mskEnd_Time1.Text), DateTime.Parse(this.mskBasic_Start_Time1.Text), DateTime.Parse(this.mskBasic_End_Time1.Text));
                if ((this.txtOver_Time1.Text != result_over_time.ToString()) && (this.txtOver_Time1.Text == "" && result_over_time != 0))
                {
                    error_msg = "残業時間を確認してください。（実走１）";
                    return false;
                }
            }
            // 実走２残業時間
            if (this.mskStart_Time2.Text != "  :" || this.mskEnd_Time2.Text != "  :")
            {
                var result_over_time = clsPublicReport.CalcOvertimeMinutes(DateTime.Parse(this.mskStart_Time2.Text), DateTime.Parse(this.mskEnd_Time2.Text), DateTime.Parse(this.mskBasic_Start_Time2.Text), DateTime.Parse(this.mskBasic_End_Time2.Text));
                if ((this.txtOver_Time2.Text != result_over_time.ToString()) && (this.txtOver_Time2.Text == "" && result_over_time != 0))
                {
                    error_msg = "残業時間を確認してください。（実走２）";
                    return false;
                }
            }
            // 実走３残業時間
            if (this.mskStart_Time3.Text != "  :" || this.mskEnd_Time3.Text != "  :")
            {
                var result_over_time = clsPublicReport.CalcOvertimeMinutes(DateTime.Parse(this.mskStart_Time3.Text), DateTime.Parse(this.mskEnd_Time3.Text), DateTime.Parse(this.mskBasic_Start_Time3.Text), DateTime.Parse(this.mskBasic_End_Time3.Text));
                if ((this.txtOver_Time3.Text != result_over_time.ToString()) && (this.txtOver_Time3.Text == "" && result_over_time != 0))
                {
                    error_msg = "残業時間を確認してください。（実走３）";
                    return false;
                }
            }
            // ============================================================
            // 詳細残業時間チェック：合計残業時間と早出、通常残業の合計時間
            // ============================================================
            // 実走１
            if (this.txtOver_Time1.Text != "" || this.txtStart_Over_Time1.Text != "" || this.txtEnd_Over_Time1.Text != "")
            {
                var over_time = 0;
                if (this.txtOver_Time1.Text != "") { over_time = int.Parse(this.txtOver_Time1.Text); }
                var start_over_time = 0;
                if (this.txtStart_Over_Time1.Text != "") { start_over_time = int.Parse(this.txtStart_Over_Time1.Text); }
                var end_over_time = 0;
                if (this.txtEnd_Over_Time1.Text != "") { end_over_time = int.Parse(this.txtEnd_Over_Time1.Text); }

                if (over_time != (start_over_time + end_over_time))
                {
                    error_msg = "（合計残業時間）と（早出残業時間＋超過残業時間）が異なります。（実走１）";
                    return false;
                }
            }
            // 実走２
            if (this.txtOver_Time2.Text != "" || this.txtStart_Over_Time2.Text != "" || this.txtEnd_Over_Time2.Text != "")
            {
                var over_time = 0;
                if (this.txtOver_Time2.Text != "") { over_time = int.Parse(this.txtOver_Time2.Text); }
                var start_over_time = 0;
                if (this.txtStart_Over_Time2.Text != "") { start_over_time = int.Parse(this.txtStart_Over_Time2.Text); }
                var end_over_time = 0;
                if (this.txtEnd_Over_Time2.Text != "") { end_over_time = int.Parse(this.txtEnd_Over_Time2.Text); }

                if (over_time != (start_over_time + end_over_time))
                {
                    error_msg = "（合計残業時間）と（早出残業時間＋超過残業時間）が異なります。（実走２）";
                    return false;
                }
            }
            // 実走３
            if (this.txtOver_Time3.Text != "" || this.txtStart_Over_Time3.Text != "" || this.txtEnd_Over_Time3.Text != "")
            {
                var over_time = 0;
                if (this.txtOver_Time3.Text != "") { over_time = int.Parse(this.txtOver_Time3.Text); }
                var start_over_time = 0;
                if (this.txtStart_Over_Time3.Text != "") { start_over_time = int.Parse(this.txtStart_Over_Time3.Text); }
                var end_over_time = 0;
                if (this.txtEnd_Over_Time3.Text != "") { end_over_time = int.Parse(this.txtEnd_Over_Time3.Text); }

                if (over_time != (start_over_time + end_over_time))
                {
                    error_msg = "（合計残業時間）と（早出残業時間＋超過残業時間）が異なります。（実走３）";
                    return false;
                }
            }
            // ============================================================
            // 残業理由チェック：残業あり、理由なし/残業なし/理由あり　等
            // ============================================================
            // 実走１
            // 残業あり、理由なし
            if (this.txtOver_Time1.Text != "")
            {
                if (txtStart_Over_Time_Comment1.Text == "" && this.cmbStart_Over_Time_Kbn1.SelectedIndex == 0 && txtEnd_Over_Time_Comment1.Text == "" && this.cmbEnd_Over_Time_Kbn1.SelectedIndex == 0)
                {
                    error_msg = "残業理由が入力されていません。（実走１）";
                    return false;
                }
            }
            // 残業なし、理由あり
            if (txtStart_Over_Time_Comment1.Text != "" || this.cmbStart_Over_Time_Kbn1.SelectedIndex != 0 || txtEnd_Over_Time_Comment1.Text != "" || this.cmbEnd_Over_Time_Kbn1.SelectedIndex != 0)
            {
                if (this.txtOver_Time1.Text == "")
                {
                    error_msg = "残業なしで残業理由が入力されています。（実走１）";
                    return false;
                }
            }

            // 実走２
            // 残業あり、理由なし
            if (this.txtOver_Time2.Text != "")
            {
                if (txtStart_Over_Time_Comment2.Text == "" && this.cmbStart_Over_Time_Kbn2.SelectedIndex == 0 && txtEnd_Over_Time_Comment2.Text == "" && this.cmbEnd_Over_Time_Kbn2.SelectedIndex == 0)
                {
                    error_msg = "残業理由が入力されていません。（実走２）";
                    return false;
                }
            }
            // 残業なし、理由あり
            if (txtStart_Over_Time_Comment2.Text != "" || this.cmbStart_Over_Time_Kbn2.SelectedIndex != 0 || txtEnd_Over_Time_Comment2.Text != "" || this.cmbEnd_Over_Time_Kbn2.SelectedIndex != 0)
            {
                if (this.txtOver_Time2.Text == "")
                {
                    error_msg = "残業なしで残業理由が入力されています。（実走２）";
                    return false;
                }
            }

            // 実走３
            // 残業あり、理由なし
            if (this.txtOver_Time3.Text != "")
            {
                if (txtStart_Over_Time_Comment3.Text == "" && this.cmbStart_Over_Time_Kbn3.SelectedIndex == 0 && txtEnd_Over_Time_Comment3.Text == "" && this.cmbEnd_Over_Time_Kbn3.SelectedIndex == 0)
                {
                    error_msg = "残業理由が入力されていません。（実走３）";
                    return false;
                }
            }
            // 残業なし、理由あり
            if (txtStart_Over_Time_Comment3.Text != "" || this.cmbStart_Over_Time_Kbn3.SelectedIndex != 0 || txtEnd_Over_Time_Comment3.Text != "" || this.cmbEnd_Over_Time_Kbn3.SelectedIndex != 0)
            {
                if (this.txtOver_Time3.Text == "")
                {
                    error_msg = "残業なしで残業理由が入力されています。（実走３）";
                    return false;
                }
            }

            // ========================================================
            // 休憩時間チェック
            // ========================================================
            // 休憩1
            if (this.mskStart_Break_Time1.Text != "  :" || this.mskEnd_Break_Time1.Text != "  :")
            {
                if (!clsPublicReport.CheckInputStartEndTime(this.mskStart_Break_Time1.Text, this.mskEnd_Break_Time1.Text, out error_msg)) { return false; }
            }
            // 休憩2
            if (this.mskStart_Break_Time2.Text != "  :" || this.mskEnd_Break_Time2.Text != "  :")
            {
                if (!clsPublicReport.CheckInputStartEndTime(this.mskStart_Break_Time2.Text, this.mskEnd_Break_Time2.Text, out error_msg)) { return false; }
            }
            // 休憩3
            if (this.mskStart_Break_Time3.Text != "  :" || this.mskEnd_Break_Time3.Text != "  :")
            {
                if (!clsPublicReport.CheckInputStartEndTime(this.mskStart_Break_Time3.Text, this.mskEnd_Break_Time3.Text, out error_msg)) { return false; }
            }
            // ========================================================
            // 休憩時間チェック：計算した休憩時間と入力された休憩時間
            // ========================================================
            // 休憩１
            if (this.mskStart_Break_Time1.Text != "  :" || this.mskEnd_Break_Time1.Text != "  :")
            {
                var result_break_time = clsPublicReport.CalcMinutes(DateTime.Parse(this.mskStart_Break_Time1.Text), DateTime.Parse(this.mskEnd_Break_Time1.Text));
                if (this.txtBreak_Time1.Text != result_break_time.ToString())
                {
                    error_msg = "休憩時間を確認してください。（休憩１）";
                    return false;
                }
            }
            // 休憩２
            if (this.mskStart_Break_Time2.Text != "  :" || this.mskEnd_Break_Time2.Text != "  :")
            {
                var result_break_time = clsPublicReport.CalcMinutes(DateTime.Parse(this.mskStart_Break_Time2.Text), DateTime.Parse(this.mskEnd_Break_Time2.Text));
                if (this.txtBreak_Time2.Text != result_break_time.ToString())
                {
                    error_msg = "休憩時間を確認してください。（休憩２）";
                    return false;
                }
            }
            // 休憩３
            if (this.mskStart_Break_Time3.Text != "  :" || this.mskEnd_Break_Time3.Text != "  :")
            {
                var result_break_time = clsPublicReport.CalcMinutes(DateTime.Parse(this.mskStart_Break_Time3.Text), DateTime.Parse(this.mskEnd_Break_Time3.Text));
                if (this.txtBreak_Time3.Text != result_break_time.ToString())
                {
                    error_msg = "休憩時間を確認してください。（休憩３）";
                    return false;
                }
            }

            // ========================================================
            // メーターチェック：数字
            // ========================================================
            // 入庫時メーター
            if (this.txtAfter_Meter.Text != "")
            {
                if (!int.TryParse(this.txtAfter_Meter.Text, out int result))
                {
                    error_msg = "数字を入力してください。（入庫時メーター）";
                    return false;
                }
            }
            // 出庫時メーター
            if (this.txtBefore_Meter.Text != "")
            {
                if (!int.TryParse(this.txtBefore_Meter.Text, out int result))
                {
                    error_msg = "数字を入力してください。（出庫時メーター）";
                    return false;
                }
            }
            // ========================================================
            // メーターチェック：出庫時＜入庫時
            // ========================================================
            if (this.txtBefore_Meter.Text.Length != 0 && this.txtAfter_Meter.Text.Length != 0)
            {
                if (int.Parse(this.txtBefore_Meter.Text) > int.Parse(this.txtAfter_Meter.Text))
                {
                    error_msg = "出庫時メーター値の方が大きい数字です。（出庫時メーター）";
                    return false;
                }
            }
            // ========================================================
            // 給油量：数字
            // ========================================================
            if (this.txtFuel.Text != "")
            {
                if (!double.TryParse(this.txtFuel.Text, out double result))
                {
                    error_msg = "数字を入力してください。（給油量）";
                    return false;
                }
            }
            // ========================================================
            // 給油時メーター数字
            // ========================================================
            if (this.txtFuel_Meter.Text != "")
            {
                if (!int.TryParse(this.txtFuel_Meter.Text, out int result))
                {
                    error_msg = "数字を入力してください。（給油量メーター）";
                    return false;
                }
            }
            // ========================================================
            // オイル：数字
            // ========================================================
            if (this.txtOil.Text != "")
            {
                if (!double.TryParse(this.txtOil.Text, out double result))
                {
                    error_msg = "数字を入力してください。（オイル）";
                    return false;
                }
            }
            // ========================================================
            // 灯油：数字
            // ========================================================
            if (this.txtKerosene.Text != "")
            {
                if (!double.TryParse(this.txtKerosene.Text, out double result))
                {
                    error_msg = "数字を入力してください。（灯油）";
                    return false;
                }
            }

            // ========================================================
            // 検温：時刻
            // ========================================================
            // 検温１
            if (this.mskTemp_Time1.Text != "  :")
            {
                if (!clsPublicReport.CheckInputTime(this.mskTemp_Time1.Text, out error_msg))
                {
                    this.mskTemp_Time1.Focus();
                    return false; 
                }
            }
            // 検温２
            if (this.mskTemp_Time2.Text != "  :")
            {
                if (!clsPublicReport.CheckInputTime(this.mskTemp_Time2.Text, out error_msg))
                {
                    this.mskTemp_Time2.Focus();
                    return false; 
                }
            }
            // 検温３
            if (this.mskTemp_Time3.Text != "  :")
            {
                if (!clsPublicReport.CheckInputTime(this.mskTemp_Time3.Text, out error_msg))
                {
                    this.mskTemp_Time3.Focus();
                    return false; 
                }
            }
            // ========================================================
            // 検温：体温
            // ========================================================
            // 検温１
            if (this.txtTemp1.Text != "")
            {
                if (!double.TryParse(this.txtTemp1.Text, out double result))
                {
                    error_msg = "数字を入力してください。（検温１）";
                    return false;
                }
            }
            // 検温２
            if (this.txtTemp2.Text != "")
            {
                if (!double.TryParse(this.txtTemp2.Text, out double result))
                {
                    error_msg = "数字を入力してください。（検温２）";
                    return false;
                }
            }
            // 検温３
            if (this.txtTemp3.Text != "")
            {
                if (!double.TryParse(this.txtTemp3.Text, out double result))
                {
                    error_msg = "数字を入力してください。（検温３）";
                    return false;
                }
            }

            return true;
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
        /// 削除ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            // MessageBox.Show(Report_id.ToString(), "", MessageBoxButtons.OK);
            if (MessageBox.Show("削除しますか？", "確認", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    // 日報データ削除
                    using (ClsSqlDb clsSqlDb = new ClsSqlDb(ClsDbConfig.SQLServerNo))
                    {
                        sb.Clear();
                        sb.AppendLine("DELETE FROM");
                        sb.AppendLine(" Trn_日報");
                        sb.AppendLine(" WHERE");
                        sb.AppendLine(" id = " + Report_id);
                        clsSqlDb.DMLUpdate(sb.ToString());
                    }

                    delete_flag = 1;

                    this.Close();
                }
                catch (Exception ex)
                {
                    ClsLogger.Log(ex.Message);
                    throw;
                }

            }
        }
        /// <summary>
        /// 印刷ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            // 現在の日付と時刻を取得
            DateTime now = DateTime.Now;
                        // カスタム書式指定子 "yyyyMMddHHmmss" を使用して文字列に変換
            // 大文字の "MM" は月、大文字の "HH" は24時間表記の時を表します。
            string formattedDateTime = now.ToString("yyyyMMddHHmmss");
                        Console.WriteLine(formattedDateTime);
            // 出力例: 20251027133554 (※実行時の日付時刻によって変わります)

            // 書式指定子 意味  補足
            // yyyy    年(4桁)  例: 2025
            // MM 月(2桁、ゼロパディング)	大文字。小文字の mm は分です。
            // dd 日(2桁、ゼロパディング)	
            // HH 時(24時間表記、2桁、ゼロパディング)	大文字。小文字の hh は12時間表記です。
            // mm 分(2桁、ゼロパディング)	
            // ss 秒(2桁、ゼロパディング)

            // コピー元、コピー先ファイル名編集
            string from_file_name = ClsPublic.pubRootPath + @"\日報\日報_原紙.xlsx";
            string to_file_name = ClsPublic.pubRootPath + @"\日報\日報_" + lblLocation_Name.Text + "_" + formattedDateTime + "_" + this.Report_id + ".xlsx";


            // 日報（エクセル）コピー
            try
            {
                // --- 🚨 上書きしない場合（コピー先ファイルが存在すると例外が発生） ---
                // File.Copy(sourceFilePath, destinationFilePath);

                // --- ✅ 上書きを許可する場合（一般的に推奨） ---
                // 第3引数に 'true' を指定
                File.Copy(from_file_name, to_file_name, true);

                Console.WriteLine($"ファイルのコピーが完了しました: {from_file_name} -> {to_file_name}");

                // エクセルに出力
                clsPublicReport.WriteReport(this.Report_id, to_file_name,false);

                if (chkHikae.Checked == true)
                {
                    // エクセルに出力(控え)
                    clsPublicReport.WriteReport(this.Report_id, to_file_name, true);
                }

                // 印刷
                ClsMsExcel clsMsExcel = new ClsMsExcel();
                clsMsExcel.PrintSheet(to_file_name, "日報指示書");
                if (chkHikae.Checked == true)
                {
                    clsMsExcel.PrintSheet(to_file_name, "日報指示書_控え");
                }
                Console.WriteLine("印刷が完了しました。");
            }
            catch (IOException ex)
            {
                // ファイルが見つからない、コピー先ファイルが既に存在する（上書きオプションなし）、
                // またはその他のI/Oエラーが発生した場合の処理
                Console.WriteLine($"ファイル操作エラー: {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                // アクセス許可がない場合の処理
                Console.WriteLine($"アクセス権エラー: {ex.Message}");
            }
            catch (Exception ex)
            {
                // その他の予期せぬエラー
                Console.WriteLine($"予期せぬエラー: {ex.Message}");
            }

        }
        /// <summary>
        /// 一次確認チェックボックス
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkConfirm1_CheckedChanged(object sender, EventArgs e)
        {
            //StringBuilder sb = new StringBuilder();
            //int staff_id = 0;
            //string staff_name = "";
            //string confirm_date = "";
            //Boolean visible = false;

            //if (chkConfirm1.Checked == true)
            //{
            //    staff_id = ClsLoginUser.ID;
            //    staff_name = ClsLoginUser.FullName;
            //    confirm_date = DateTime.Today.ToString("yyyy/MM/dd");
            //    visible = true;
            //}

            //try
            //{
            //    // 日報データ更新
            //    using (ClsSqlDb clsSqlDb = new ClsSqlDb(ClsDbConfig.SQLServerNo))
            //    {
            //        sb.Clear();
            //        sb.AppendLine("UPDATE");
            //        sb.AppendLine(" Trn_日報");
            //        sb.AppendLine(" SET");
            //        sb.AppendLine(" confirm1_id = " + staff_id);
            //        if (staff_id != 0)
            //        {
            //            sb.AppendLine(",confirm1_date = '" + confirm_date + "'");
            //            this.lblConfirm1Date.Text = confirm_date;
            //        }
            //        else
            //        {
            //            sb.AppendLine(",confirm1_date = null");
            //            this.lblConfirm1Date.Text = "";
            //        }
            //        sb.AppendLine(" WHERE");
            //        sb.AppendLine(" id = " + Report_id);
            //        clsSqlDb.DMLUpdate(sb.ToString());

            //        this.lblConfirm1Name.Text = staff_name;
            //        this.lblConfirm1Date.Visible = visible;
            //        this.lblConfirm1Name.Visible = visible;
            //        this.lblConfirm1Date.Refresh();
            //        this.lblConfirm1Name.Refresh();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ClsLogger.Log(ex.Message);
            //    throw;
            //}

        }
        /// <summary>
        /// 車両管理責任者承認
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void chkConfirm2_CheckedChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// １走目開始時間変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mskStart_Time1_TextChanged(object sender, EventArgs e)
        {
            var stime = mskStart_Time1.Text;
            var etime = mskEnd_Time1.Text;
            var cstime = mskBasic_Start_Time1.Text;
            var cetime = mskBasic_End_Time1.Text;

            // どちらか未入力の場合は処理しない
            if (stime == "  :" || etime == "  :" || cstime == "  :" || cetime == "  :") { return; }

            var zan = clsPublicReport.CalcOvertimeMinutes(DateTime.Parse(stime),DateTime.Parse(etime),DateTime.Parse(cstime),DateTime.Parse(cetime));
            if (zan == 0) { return; }

            txtOver_Time1.Text = zan.ToString();
        }
        /// <summary>
        /// １走目終了時間変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mskEnd_Time1_TextChanged(object sender, EventArgs e)
        {
            var stime = mskStart_Time1.Text;
            var etime = mskEnd_Time1.Text;
            var cstime = mskBasic_Start_Time1.Text;
            var cetime = mskBasic_End_Time1.Text;

            // どちらか未入力の場合は処理しない
            if (stime == "  :" || etime == "  :" || cstime == "  :" || cetime == "  :") { return; }

            var zan = clsPublicReport.CalcOvertimeMinutes(DateTime.Parse(stime), DateTime.Parse(etime), DateTime.Parse(cstime), DateTime.Parse(cetime));
            if (zan == 0) { return; }

            txtOver_Time1.Text = zan.ToString();
        }

        private void chkConfirm3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkSalesConfirm_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
