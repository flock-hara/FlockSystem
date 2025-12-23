using FlockAppC.pubClass;
using FlockAppC.tblClass;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

// 点検結果照会

namespace FlockAppC.日報関連
{
    public partial class frmResultCarCheck : Form
    {
        public int Report_id { get; set; }

        // 日報　運行前点検
        private int Inspection_check1 { get; set; }
        private int Inspection_check2 { get; set; }
        private int Inspection_check3 { get; set; }
        private int Inspection_check4 { get; set; }
        private int Inspection_check5 { get; set; }
        private int Inspection_check6 { get; set; }
        private int Inspection_check7 { get; set; }

        // 日報　定期点検
        private int Per_inspection_check1 { get; set; }
        private int Per_inspection_check2 { get; set; }
        private int Per_inspection_check3 { get; set; }
        private int Per_inspection_check4 { get; set; }
        private int Per_inspection_check5 { get; set; }
        private int Per_inspection_check6 { get; set; }
        private int Per_inspection_check7 { get; set; }
        private int Per_inspection_check8 { get; set; }
        private int Per_inspection_check9 { get; set; }
        private int Per_inspection_check10 { get; set; }
        private int Per_inspection_check11 { get; set; }
        private int Per_inspection_check12 { get; set; }
        private int Per_inspection_check13 { get; set; }
        private int Per_inspection_check14 { get; set; }

        private int Large_inspection_check1 { get; set; }
        private int Large_inspection_check2 { get; set; }
        private int Large_inspection_check3 { get; set; }
        private int Large_inspection_check4 { get; set; }


        public frmResultCarCheck()
        {
            InitializeComponent();
        }

        private void frmResultCarCheck_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);

            if (Report_id == 0)
            {
                return;
            }

            // ラジオボタン初期化
            this.rdoInspection_Check1_Ok.Checked = false;
            this.rdoInspection_Check1_Ng.Checked = false;
            this.rdoInspection_Check2_Ok.Checked = false;
            this.rdoInspection_Check2_Ng.Checked = false;
            this.rdoInspection_Check3_Ok.Checked = false;
            this.rdoInspection_Check3_Ng.Checked = false;
            this.rdoInspection_Check4_Ok.Checked = false;
            this.rdoInspection_Check4_Ng.Checked = false;
            this.rdoInspection_Check5_Ok.Checked = false;
            this.rdoInspection_Check5_Ng.Checked = false;
            this.rdoInspection_Check6_Ok.Checked = false;
            this.rdoInspection_Check6_Ng.Checked = false;
            this.rdoInspection_Check7_Ok.Checked = false;
            this.rdoInspection_Check7_Ng.Checked = false;

            this.rdoPer_Inspection_Check1_Ok.Checked = false;
            this.rdoPer_Inspection_Check1_Ng.Checked = false;
            this.rdoPer_Inspection_Check2_Ok.Checked = false;
            this.rdoPer_Inspection_Check2_Ng.Checked = false;
            this.rdoPer_Inspection_Check3_Ok.Checked = false;
            this.rdoPer_Inspection_Check3_Ng.Checked = false;
            this.rdoPer_Inspection_Check4_Ok.Checked = false;
            this.rdoPer_Inspection_Check4_Ng.Checked = false;
            this.rdoPer_Inspection_Check5_Ok.Checked = false;
            this.rdoPer_Inspection_Check5_Ng.Checked = false;
            this.rdoPer_Inspection_Check6_Ok.Checked = false;
            this.rdoPer_Inspection_Check6_Ng.Checked = false;
            this.rdoPer_Inspection_Check7_Ok.Checked = false;
            this.rdoPer_Inspection_Check7_Ng.Checked = false;
            this.rdoPer_Inspection_Check8_Ok.Checked = false;
            this.rdoPer_Inspection_Check8_Ng.Checked = false;
            this.rdoPer_Inspection_Check9_Ok.Checked = false;
            this.rdoPer_Inspection_Check9_Ng.Checked = false;
            this.rdoPer_Inspection_Check10_Ok.Checked = false;
            this.rdoPer_Inspection_Check10_Ng.Checked = false;
            this.rdoPer_Inspection_Check11_Ok.Checked = false;
            this.rdoPer_Inspection_Check11_Ng.Checked = false;
            this.rdoPer_Inspection_Check12_Ok.Checked = false;
            this.rdoPer_Inspection_Check12_Ng.Checked = false;
            this.rdoPer_Inspection_Check13_Ok.Checked = false;
            this.rdoPer_Inspection_Check13_Ng.Checked = false;
            this.rdoPer_Inspection_Check14_Ok.Checked = false;
            this.rdoPer_Inspection_Check14_Ng.Checked = false;

            this.rdoLarge_Inspection_Check1_Ok.Checked = false;
            this.rdoLarge_Inspection_Check1_Ng.Checked = false;
            this.rdoLarge_Inspection_Check2_Ok.Checked = false;
            this.rdoLarge_Inspection_Check2_Ng.Checked = false;
            this.rdoLarge_Inspection_Check3_Ok.Checked = false;
            this.rdoLarge_Inspection_Check3_Ng.Checked = false;
            this.rdoLarge_Inspection_Check4_Ok.Checked = false;
            this.rdoLarge_Inspection_Check4_Ng.Checked = false;


            // 日報　運行前点検
            this.Inspection_check1 = 0;
            this.Inspection_check2 = 0;
            this.Inspection_check3 = 0;
            this.Inspection_check4 = 0;
            this.Inspection_check5 = 0;
            this.Inspection_check6 = 0;
            this.Inspection_check7 = 0;

            // 日報　定期点検
            this.Per_inspection_check1 = 0;
            this.Per_inspection_check2 = 0;
            this.Per_inspection_check3 = 0;
            this.Per_inspection_check4 = 0;
            this.Per_inspection_check5 = 0;
            this.Per_inspection_check6 = 0;
            this.Per_inspection_check7 = 0;
            this.Per_inspection_check8 = 0;
            this.Per_inspection_check9 = 0;
            this.Per_inspection_check10 = 0;
            this.Per_inspection_check11 = 0;
            this.Per_inspection_check12 = 0;
            this.Per_inspection_check13 = 0;
            this.Per_inspection_check14 = 0;

            // 日報　大型点検
            this.Large_inspection_check1 = 0;
            this.Large_inspection_check2 = 0;
            this.Large_inspection_check3 = 0;
            this.Large_inspection_check4 = 0;


            // 日報データ読み込み
            Get_ReportData();

            // 日報データ表示
            Display_ReportData();
        }

        /// <summary>
        /// 日報入力データ取得
        /// </summary>
        private void Get_ReportData()
        {
            ClsTrnReport cls = new();

            try
            {
                // 日報ID指定
                cls.Key_report_id = this.Report_id;
                // 日報IDから日報データ取得
                cls.SelectFromID();

                // 件数なし→処理終了
                if (cls.Select_count == 0 || cls.Select_count > 1) { return; }

                // 日報データ読み込み
                foreach (DataRow dr in cls.Dt.Rows)
                {
                    // ==============================================================================================================================
                    // 日報　アルコールチェック、検温
                    // ==============================================================================================================================
                    //if (dr.IsNull("temp1") != true) { this.Temp1 = decimal.Parse(dr["temp1"].ToString()); }                             // 検温1回目
                    //if (dr.IsNull("temp2") != true) { this.Temp2 = decimal.Parse(dr["temp2"].ToString()); }                             // 検温2回目
                    //if (dr.IsNull("temp3") != true) { this.Temp3 = decimal.Parse(dr["temp3"].ToString()); }                             // 検温3回目
                    //if (dr.IsNull("temp_time1") != true) { this.Temp_time1 = DateTime.Parse(dr["temp_time1"].ToString()); }             // 検温1回目時刻
                    //if (dr.IsNull("temp_time2") != true) { this.Temp_time2 = DateTime.Parse(dr["temp_time2"].ToString()); }             // 検温2回目時刻
                    //if (dr.IsNull("temp_time3") != true) { this.Temp_time3 = DateTime.Parse(dr["temp_time3"].ToString()); }             // 検温3回目時刻
                    //if (dr.IsNull("alcohol1") != true) { this.Alcohol1 = decimal.Parse(dr["alcohol1"].ToString()); }                    // アルコール濃度1回目
                    //if (dr.IsNull("alcohol2") != true) { this.Alcohol2 = decimal.Parse(dr["alcohol2"].ToString()); }                    // アルコール濃度2回目
                    //if (dr.IsNull("alcohol3") != true) { this.Alcohol3 = decimal.Parse(dr["alcohol3"].ToString()); }                    // アルコール濃度3回目
                    //if (dr.IsNull("alcohol_check1") != true) { this.Alcohol_check1 = int.Parse(dr["alcohol_check1"].ToString()); }      // アルコールチェック結果1回目
                    //if (dr.IsNull("alcohol_check2") != true) { this.Alcohol_check2 = int.Parse(dr["alcohol_check2"].ToString()); }      // アルコールチェック結果2回目
                    //if (dr.IsNull("alcohol_check3") != true) { this.Alcohol_check3 = int.Parse(dr["alcohol_check3"].ToString()); }      // アルコールチェック結果3回目
                    // ==============================================================================================================================
                    // 日報　運行前点検
                    // ==============================================================================================================================
                    if (dr.IsNull("inspection_check1") != true) { this.Inspection_check1 = int.Parse(dr["inspection_check1"].ToString()); }   // チェック1
                    if (dr.IsNull("inspection_check2") != true) { this.Inspection_check2 = int.Parse(dr["inspection_check2"].ToString()); }   // チェック2
                    if (dr.IsNull("inspection_check3") != true) { this.Inspection_check3 = int.Parse(dr["inspection_check3"].ToString()); }   // チェック3
                    if (dr.IsNull("inspection_check4") != true) { this.Inspection_check4 = int.Parse(dr["inspection_check4"].ToString()); }   // チェック4
                    if (dr.IsNull("inspection_check5") != true) { this.Inspection_check5 = int.Parse(dr["inspection_check5"].ToString()); }   // チェック5
                    if (dr.IsNull("inspection_check6") != true) { this.Inspection_check6 = int.Parse(dr["inspection_check6"].ToString()); }   // チェック6
                    if (dr.IsNull("inspection_check7") != true) { this.Inspection_check7 = int.Parse(dr["inspection_check7"].ToString()); }   // チェック7
                    // ==============================================================================================================================
                    // 日報　定期点検
                    // ==============================================================================================================================
                    if (dr.IsNull("per_inspection_check1") != true) { this.Per_inspection_check1 = int.Parse(dr["per_inspection_check1"].ToString()); }   // チェック1
                    if (dr.IsNull("per_inspection_check2") != true) { this.Per_inspection_check2 = int.Parse(dr["per_inspection_check2"].ToString()); }   // チェック2
                    if (dr.IsNull("per_inspection_check3") != true) { this.Per_inspection_check3 = int.Parse(dr["per_inspection_check3"].ToString()); }   // チェック3
                    if (dr.IsNull("per_inspection_check4") != true) { this.Per_inspection_check4 = int.Parse(dr["per_inspection_check4"].ToString()); }   // チェック4
                    if (dr.IsNull("per_inspection_check5") != true) { this.Per_inspection_check5 = int.Parse(dr["per_inspection_check5"].ToString()); }   // チェック5
                    if (dr.IsNull("per_inspection_check6") != true) { this.Per_inspection_check6 = int.Parse(dr["per_inspection_check6"].ToString()); }   // チェック6
                    if (dr.IsNull("per_inspection_check7") != true) { this.Per_inspection_check7 = int.Parse(dr["per_inspection_check7"].ToString()); }   // チェック7
                    if (dr.IsNull("per_inspection_check8") != true) { this.Per_inspection_check8 = int.Parse(dr["per_inspection_check8"].ToString()); }   // チェック8
                    if (dr.IsNull("per_inspection_check9") != true) { this.Per_inspection_check9 = int.Parse(dr["per_inspection_check9"].ToString()); }   // チェック9
                    if (dr.IsNull("per_inspection_check10") != true) { this.Per_inspection_check10 = int.Parse(dr["per_inspection_check10"].ToString()); }   // チェック10
                    if (dr.IsNull("per_inspection_check11") != true) { this.Per_inspection_check11 = int.Parse(dr["per_inspection_check11"].ToString()); }   // チェック11
                    if (dr.IsNull("per_inspection_check12") != true) { this.Per_inspection_check12 = int.Parse(dr["per_inspection_check12"].ToString()); }   // チェック12
                    if (dr.IsNull("per_inspection_check13") != true) { this.Per_inspection_check13 = int.Parse(dr["per_inspection_check13"].ToString()); }   // チェック13
                    if (dr.IsNull("per_inspection_check14") != true) { this.Per_inspection_check14 = int.Parse(dr["per_inspection_check14"].ToString()); }   // チェック14
                    // ==============================================================================================================================
                    // 日報　大型点検
                    // ==============================================================================================================================
                    if (dr.IsNull("large_inspection_check1") != true) { this.Large_inspection_check1 = int.Parse(dr["large_inspection_check1"].ToString()); }   // チェック1
                    if (dr.IsNull("large_inspection_check2") != true) { this.Large_inspection_check2 = int.Parse(dr["large_inspection_check2"].ToString()); }   // チェック1
                    if (dr.IsNull("large_inspection_check3") != true) { this.Large_inspection_check3 = int.Parse(dr["large_inspection_check3"].ToString()); }   // チェック1
                    if (dr.IsNull("large_inspection_check4") != true) { this.Large_inspection_check4 = int.Parse(dr["large_inspection_check4"].ToString()); }   // チェック1
                }
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// 日報入力データ表示
        /// </summary>
        private void Display_ReportData()
        {

            // =====================================================================================
            // 日報　チェックデータ
            // =====================================================================================
            // アルコール濃度①②③
            //if (this.Alcohol1 != -1) { this.txtAlcohol1.Text = decimal.Parse(this.Alcohol1.ToString()).ToString(); }
            //if (this.Alcohol2 != -1) { this.txtAlcohol2.Text = decimal.Parse(this.Alcohol2.ToString()).ToString(); }
            //if (this.Alcohol3 != -1) { this.txtAlcohol3.Text = decimal.Parse(this.Alcohol3.ToString()).ToString(); }

            //// アルコールチェック①②③
            //if (this.Alcohol_check1 == 1) { this.rdoAlcohol_Check1_Ok.Checked = true; }
            //else if (this.Alcohol_check1 == 0) { this.rdoAlcohol_Check1_Ng.Checked = true; }
            //if (this.Alcohol_check2 == 1) { this.rdoAlcohol_Check2_Ok.Checked = true; }
            //else if (this.Alcohol_check2 == 0) { this.rdoAlcohol_Check2_Ng.Checked = true; }
            //if (this.Alcohol_check3 == 1) { this.rdoAlcohol_Check3_Ok.Checked = true; }
            //else if (this.Alcohol_check3 == 0) { this.rdoAlcohol_Check3_Ng.Checked = true; }

            //// 検温①②③
            //if (this.Temp1 != 0) { this.txtTemp1.Text = decimal.Parse(this.Temp1.ToString()).ToString(); }
            //if (this.Temp2 != 0) { this.txtTemp2.Text = decimal.Parse(this.Temp2.ToString()).ToString(); }
            //if (this.Temp3 != 0) { this.txtTemp3.Text = decimal.Parse(this.Temp3.ToString()).ToString(); }

            //// 検温時刻①②③
            //if (this.Temp_time1.ToString("HH:mm") != "00:00") { this.mskTemp_Time1.Text = DateTime.Parse(this.Temp_time1.ToString()).ToString("HH:mm"); }
            //if (this.Temp_time2.ToString("HH:mm") != "00:00") { this.mskTemp_Time2.Text = DateTime.Parse(this.Temp_time2.ToString()).ToString("HH:mm"); }
            //if (this.Temp_time3.ToString("HH:mm") != "00:00") { this.mskTemp_Time3.Text = DateTime.Parse(this.Temp_time3.ToString()).ToString("HH:mm"); }

            // =====================================================================================
            // 日報　運行前点検①～⑦
            // =====================================================================================
            if (this.Inspection_check1 == 1) { this.rdoInspection_Check1_Ok.Checked = true; }
            else if (this.Inspection_check1 == 0) { this.rdoInspection_Check1_Ng.Checked = true; }
            if (this.Inspection_check2 == 1) { this.rdoInspection_Check2_Ok.Checked = true; }
            else if (this.Inspection_check2 == 0) { this.rdoInspection_Check2_Ng.Checked = true; }
            if (this.Inspection_check3 == 1) { this.rdoInspection_Check3_Ok.Checked = true; }
            else if (this.Inspection_check3 == 0) { this.rdoInspection_Check3_Ng.Checked = true; }
            if (this.Inspection_check4 == 1) { this.rdoInspection_Check4_Ok.Checked = true; }
            else if (this.Inspection_check4 == 0) { this.rdoInspection_Check4_Ng.Checked = true; }
            if (this.Inspection_check5 == 1) { this.rdoInspection_Check5_Ok.Checked = true; }
            else if (this.Inspection_check5 == 0) { this.rdoInspection_Check5_Ng.Checked = true; }
            if (this.Inspection_check6 == 1) { this.rdoInspection_Check6_Ok.Checked = true; }
            else if (this.Inspection_check6 == 0) { this.rdoInspection_Check6_Ng.Checked = true; }
            if (this.Inspection_check7 == 1) { this.rdoInspection_Check7_Ok.Checked = true; }
            else if (this.Inspection_check7 == 0) { this.rdoInspection_Check7_Ng.Checked = true; }

            // =====================================================================================
            // 日報　定期点検①～⑭
            // =====================================================================================
            if (this.Per_inspection_check1 == 1) { this.rdoPer_Inspection_Check1_Ok.Checked = true; }
            else if (this.Per_inspection_check1 == 0) { this.rdoPer_Inspection_Check1_Ng.Checked = true; }
            if (this.Per_inspection_check2 == 1) { this.rdoPer_Inspection_Check2_Ok.Checked = true; }
            else if (this.Per_inspection_check2 == 0) { this.rdoPer_Inspection_Check2_Ng.Checked = true; }
            if (this.Per_inspection_check3 == 1) { this.rdoPer_Inspection_Check3_Ok.Checked = true; }
            else if (this.Per_inspection_check3 == 0) { this.rdoPer_Inspection_Check3_Ng.Checked = true; }
            if (this.Per_inspection_check4 == 1) { this.rdoPer_Inspection_Check4_Ok.Checked = true; }
            else if (this.Per_inspection_check4 == 0) { this.rdoPer_Inspection_Check4_Ng.Checked = true; }
            if (this.Per_inspection_check5 == 1) { this.rdoPer_Inspection_Check5_Ok.Checked = true; }
            else if (this.Per_inspection_check5 == 0) { this.rdoPer_Inspection_Check5_Ng.Checked = true; }
            if (this.Per_inspection_check6 == 1) { this.rdoPer_Inspection_Check6_Ok.Checked = true; }
            else if (this.Per_inspection_check6 == 0) { this.rdoPer_Inspection_Check6_Ng.Checked = true; }
            if (this.Per_inspection_check7 == 1) { this.rdoPer_Inspection_Check7_Ok.Checked = true; }
            else if (this.Per_inspection_check7 == 0) { this.rdoPer_Inspection_Check7_Ng.Checked = true; }
            if (this.Per_inspection_check8 == 1) { this.rdoPer_Inspection_Check8_Ok.Checked = true; }
            else if (this.Per_inspection_check8 == 0) { this.rdoPer_Inspection_Check8_Ng.Checked = true; }
            if (this.Per_inspection_check9 == 1) { this.rdoPer_Inspection_Check9_Ok.Checked = true; }
            else if (this.Per_inspection_check9 == 0) { this.rdoPer_Inspection_Check9_Ng.Checked = true; }
            if (this.Per_inspection_check10 == 1) { this.rdoPer_Inspection_Check10_Ok.Checked = true; }
            else if (this.Per_inspection_check10 == 0) { this.rdoPer_Inspection_Check10_Ng.Checked = true; }
            if (this.Per_inspection_check11 == 1) { this.rdoPer_Inspection_Check11_Ok.Checked = true; }
            else if (this.Per_inspection_check11 == 0) { this.rdoPer_Inspection_Check11_Ng.Checked = true; }
            if (this.Per_inspection_check12 == 1) { this.rdoPer_Inspection_Check12_Ok.Checked = true; }
            else if (this.Per_inspection_check12 == 0) { this.rdoPer_Inspection_Check12_Ng.Checked = true; }
            if (this.Per_inspection_check13 == 1) { this.rdoPer_Inspection_Check13_Ok.Checked = true; }
            else if (this.Per_inspection_check13 == 0) { this.rdoPer_Inspection_Check13_Ng.Checked = true; }
            if (this.Per_inspection_check14 == 1) { this.rdoPer_Inspection_Check14_Ok.Checked = true; }
            else if (this.Per_inspection_check14 == 0) { this.rdoPer_Inspection_Check14_Ng.Checked = true; }

            // =====================================================================================
            // 日報　大型点検①～④
            // =====================================================================================
            if (this.Large_inspection_check1 == 1) { this.rdoLarge_Inspection_Check1_Ok.Checked = true; }
            else if (this.Large_inspection_check1 == 0) { this.rdoLarge_Inspection_Check1_Ng.Checked = true; }
            if (this.Large_inspection_check2 == 1) { this.rdoLarge_Inspection_Check2_Ok.Checked = true; }
            else if (this.Large_inspection_check1 == 0) { this.rdoLarge_Inspection_Check2_Ng.Checked = true; }
            if (this.Large_inspection_check3 == 1) { this.rdoLarge_Inspection_Check3_Ok.Checked = true; }
            else if (this.Large_inspection_check1 == 0) { this.rdoLarge_Inspection_Check3_Ng.Checked = true; }
            if (this.Large_inspection_check4 == 1) { this.rdoLarge_Inspection_Check4_Ok.Checked = true; }
            else if (this.Large_inspection_check1 == 0) { this.rdoLarge_Inspection_Check4_Ng.Checked = true; }
        }

        /// <summary>
        /// 保存ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReg_Click(object sender, EventArgs e)
        {
            // 画面入力情報→プロパティセット
            Set_ReportData();

            // 日報更新
            Update_ReportData();
        }

        /// <summary>
        /// 日報入力データセット(画面→Privateプロパティ)
        /// </summary>
        private void Set_ReportData()
        {
            // アルコールチェック　※未入力の場合は-1をセットし、DB登録時はNULLに変換
            //if (this.txtAlcohol1.Text != "") { this.Alcohol1 = decimal.Parse(this.txtAlcohol1.Text); }
            //else { this.Alcohol1 = -1; }
            //if (this.txtAlcohol2.Text != "") { this.Alcohol2 = decimal.Parse(this.txtAlcohol2.Text); }
            //else { this.Alcohol2 = -1; }
            //if (this.txtAlcohol3.Text != "") { this.Alcohol3 = decimal.Parse(this.txtAlcohol3.Text); }
            //else { this.Alcohol3 = -1; }

            //// ※未選択時は-1をセットし、DB登録時はNULLに変換
            //if (this.rdoAlcohol_Check1_Ok.Checked == true) { this.Alcohol_check1 = 1; }
            //else if (this.rdoAlcohol_Check1_Ng.Checked == true) { this.Alcohol_check1 = 0; }
            //else { this.Alcohol_check1 = -1; }
            //if (this.rdoAlcohol_Check2_Ok.Checked == true) { this.Alcohol_check2 = 1; }
            //else if (this.rdoAlcohol_Check2_Ng.Checked == true) { this.Alcohol_check2 = 0; }
            //else { this.Alcohol_check2 = -1; }
            //if (this.rdoAlcohol_Check3_Ok.Checked == true) { this.Alcohol_check3 = 1; }
            //else if (this.rdoAlcohol_Check3_Ng.Checked == true) { this.Alcohol_check3 = 0; }
            //else { this.Alcohol_check3 = -1; }

            //// 検温　※未入力の場合は1900/01/01 00:00:00をセットし、DB登録時はNULLに変換
            //if (this.mskTemp_Time1.Text == "  :") { this.Temp_time1 = DateTime.Parse("1900/01/01 00:00:00"); }
            //else { this.Temp_time1 = DateTime.Parse("1900/01/01 " + this.mskTemp_Time1.Text + ":00"); }
            //if (this.mskTemp_Time2.Text == "  :") { this.Temp_time2 = DateTime.Parse("1900/01/01 00:00:00"); }
            //else { this.Temp_time2 = DateTime.Parse("1900/01/01 " + this.mskTemp_Time2.Text + ":00"); }
            //if (this.mskTemp_Time3.Text == "  :") { this.Temp_time3 = DateTime.Parse("1900/01/01 00:00:00"); }
            //else { this.Temp_time3 = DateTime.Parse("1900/01/01 " + this.mskTemp_Time3.Text + ":00"); }

            //// ※未入力の場合は0をセットし、DB登録時はNULLに変換
            //if (this.txtTemp1.Text != "") { this.Temp1 = decimal.Parse(this.txtTemp1.Text); }
            //else { this.Temp1 = 0; }
            //if (this.txtTemp2.Text != "") { this.Temp2 = decimal.Parse(this.txtTemp2.Text); }
            //else { this.Temp2 = 0; }
            //if (this.txtTemp3.Text != "") { this.Temp3 = decimal.Parse(this.txtTemp3.Text); }
            //else { this.Temp3 = 0; }

            // 運行前点検
            // ※未選択時は-1をセットし、DB登録時はNULLに変換
            if (this.rdoInspection_Check1_Ok.Checked == true) { this.Inspection_check1 = 1; }
            else if (this.rdoInspection_Check1_Ng.Checked == true) { this.Inspection_check1 = 0; }
            else { this.Inspection_check1 = -1; }
            if (this.rdoInspection_Check2_Ok.Checked == true) { this.Inspection_check2 = 1; }
            else if (this.rdoInspection_Check2_Ng.Checked == true) { this.Inspection_check2 = 0; }
            else { this.Inspection_check2 = -1; }
            if (this.rdoInspection_Check3_Ok.Checked == true) { this.Inspection_check3 = 1; }
            else if (this.rdoInspection_Check3_Ng.Checked == true) { this.Inspection_check3 = 0; }
            else { this.Inspection_check3 = -1; }
            if (this.rdoInspection_Check4_Ok.Checked == true) { this.Inspection_check4 = 1; }
            else if (this.rdoInspection_Check4_Ng.Checked == true) { this.Inspection_check4 = 0; }
            else { this.Inspection_check4 = -1; }
            if (this.rdoInspection_Check5_Ok.Checked == true) { this.Inspection_check5 = 1; }
            else if (this.rdoInspection_Check5_Ng.Checked == true) { this.Inspection_check5 = 0; }
            else { this.Inspection_check5 = -1; }
            if (this.rdoInspection_Check6_Ok.Checked == true) { this.Inspection_check6 = 1; }
            else if (this.rdoInspection_Check6_Ng.Checked == true) { this.Inspection_check6 = 0; }
            else { this.Inspection_check6 = -1; }
            if (this.rdoInspection_Check7_Ok.Checked == true) { this.Inspection_check7 = 1; }
            else if (this.rdoInspection_Check7_Ng.Checked == true) { this.Inspection_check7 = 0; }
            else { this.Inspection_check7 = -1; }

            // 定期点検
            // ※未選択時は-1をセットし、DB登録時はNULLに変換
            if (this.rdoPer_Inspection_Check1_Ok.Checked == true) { this.Per_inspection_check1 = 1; }
            else if (this.rdoPer_Inspection_Check1_Ng.Checked == true) { this.Per_inspection_check1 = 0; }
            else { this.Per_inspection_check1 = -1; }
            if (this.rdoPer_Inspection_Check2_Ok.Checked == true) { this.Per_inspection_check2 = 1; }
            else if (this.rdoPer_Inspection_Check2_Ng.Checked == true) { this.Per_inspection_check2 = 0; }
            else { this.Per_inspection_check2 = -1; }
            if (this.rdoPer_Inspection_Check3_Ok.Checked == true) { this.Per_inspection_check3 = 1; }
            else if (this.rdoPer_Inspection_Check3_Ng.Checked == true) { this.Per_inspection_check3 = 0; }
            else { this.Per_inspection_check3 = -1; }
            if (this.rdoPer_Inspection_Check4_Ok.Checked == true) { this.Per_inspection_check4 = 1; }
            else if (this.rdoPer_Inspection_Check4_Ng.Checked == true) { this.Per_inspection_check4 = 0; }
            else { this.Per_inspection_check4 = -1; }
            if (this.rdoPer_Inspection_Check5_Ok.Checked == true) { this.Per_inspection_check5 = 1; }
            else if (this.rdoPer_Inspection_Check5_Ng.Checked == true) { this.Per_inspection_check5 = 0; }
            else { this.Per_inspection_check5 = -1; }
            if (this.rdoPer_Inspection_Check6_Ok.Checked == true) { this.Per_inspection_check6 = 1; }
            else if (this.rdoPer_Inspection_Check6_Ng.Checked == true) { this.Per_inspection_check6 = 0; }
            else { this.Per_inspection_check6 = -1; }
            if (this.rdoPer_Inspection_Check7_Ok.Checked == true) { this.Per_inspection_check7 = 1; }
            else if (this.rdoPer_Inspection_Check7_Ng.Checked == true) { this.Per_inspection_check7 = 0; }
            else { this.Per_inspection_check7 = -1; }
            if (this.rdoPer_Inspection_Check8_Ok.Checked == true) { this.Per_inspection_check8 = 1; }
            else if (this.rdoPer_Inspection_Check8_Ng.Checked == true) { this.Per_inspection_check8 = 0; }
            else { this.Per_inspection_check8 = -1; }
            if (this.rdoPer_Inspection_Check9_Ok.Checked == true) { this.Per_inspection_check9 = 1; }
            else if (this.rdoPer_Inspection_Check9_Ng.Checked == true) { this.Per_inspection_check9 = 0; }
            else { this.Per_inspection_check9 = -1; }
            if (this.rdoPer_Inspection_Check10_Ok.Checked == true) { this.Per_inspection_check10 = 1; }
            else if (this.rdoPer_Inspection_Check10_Ng.Checked == true) { this.Per_inspection_check10 = 0; }
            else { this.Per_inspection_check10 = -1; }
            if (this.rdoPer_Inspection_Check11_Ok.Checked == true) { this.Per_inspection_check11 = 1; }
            else if (this.rdoPer_Inspection_Check11_Ng.Checked == true) { this.Per_inspection_check11 = 0; }
            else { this.Per_inspection_check11 = -1; }
            if (this.rdoPer_Inspection_Check12_Ok.Checked == true) { this.Per_inspection_check12 = 1; }
            else if (this.rdoPer_Inspection_Check12_Ng.Checked == true) { this.Per_inspection_check12 = 0; }
            else { this.Per_inspection_check12 = -1; }
            if (this.rdoPer_Inspection_Check13_Ok.Checked == true) { this.Per_inspection_check13 = 1; }
            else if (this.rdoPer_Inspection_Check13_Ng.Checked == true) { this.Per_inspection_check13 = 0; }
            else { this.Per_inspection_check13 = -1; }
            if (this.rdoPer_Inspection_Check14_Ok.Checked == true) { this.Per_inspection_check14 = 1; }
            else if (this.rdoPer_Inspection_Check14_Ng.Checked == true) { this.Per_inspection_check14 = 0; }
            else { this.Per_inspection_check14 = -1; }

            // 大型点検
            if (this.rdoLarge_Inspection_Check1_Ok.Checked == true) { this.Large_inspection_check1 = 1; }
            else if (this.rdoLarge_Inspection_Check1_Ng.Checked == true) { this.Large_inspection_check1 = 0; }
            else { this.Large_inspection_check1 = -1; }
            if (this.rdoLarge_Inspection_Check2_Ok.Checked == true) { this.Large_inspection_check2 = 1; }
            else if (this.rdoLarge_Inspection_Check2_Ng.Checked == true) { this.Large_inspection_check2 = 0; }
            else { this.Large_inspection_check2 = -1; }
            if (this.rdoLarge_Inspection_Check3_Ok.Checked == true) { this.Large_inspection_check3 = 1; }
            else if (this.rdoLarge_Inspection_Check3_Ng.Checked == true) { this.Large_inspection_check3 = 0; }
            else { this.Large_inspection_check3 = -1; }
            if (this.rdoLarge_Inspection_Check4_Ok.Checked == true) { this.Large_inspection_check4 = 1; }
            else if (this.rdoLarge_Inspection_Check4_Ng.Checked == true) { this.Large_inspection_check4 = 0; }
            else { this.Large_inspection_check4 = -1; }

        }

        /// <summary>
        /// 日報入力データ　点検結果更新
        /// </summary>
        private void Update_ReportData()
        {
            StringBuilder sb = new();

            using(ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
            {
                sb.AppendLine("UPDATE");
                sb.AppendLine("Trn_日報");
                sb.AppendLine("SET");
                sb.AppendLine(" inspection_check1 = " + Inspection_check1);
                sb.AppendLine(",inspection_check2 = " + Inspection_check2);
                sb.AppendLine(",inspection_check3 = " + Inspection_check3);
                sb.AppendLine(",inspection_check4 = " + Inspection_check4);
                sb.AppendLine(",inspection_check5 = " + Inspection_check5);
                sb.AppendLine(",inspection_check6 = " + Inspection_check6);
                sb.AppendLine(",inspection_check7 = " + Inspection_check7);

                sb.AppendLine(",per_inspection_check1 = " + Per_inspection_check1);
                sb.AppendLine(",per_inspection_check2 = " + Per_inspection_check2);
                sb.AppendLine(",per_inspection_check3 = " + Per_inspection_check3);
                sb.AppendLine(",per_inspection_check4 = " + Per_inspection_check4);
                sb.AppendLine(",per_inspection_check5 = " + Per_inspection_check5);
                sb.AppendLine(",per_inspection_check6 = " + Per_inspection_check6);
                sb.AppendLine(",per_inspection_check7 = " + Per_inspection_check7);
                sb.AppendLine(",per_inspection_check8 = " + Per_inspection_check8);
                sb.AppendLine(",per_inspection_check9 = " + Per_inspection_check9);
                sb.AppendLine(",per_inspection_check10 = " + Per_inspection_check10);
                sb.AppendLine(",per_inspection_check11 = " + Per_inspection_check11);
                sb.AppendLine(",per_inspection_check12 = " + Per_inspection_check12);
                sb.AppendLine(",per_inspection_check13 = " + Per_inspection_check13);
                sb.AppendLine(",per_inspection_check14 = " + Per_inspection_check14);

                sb.AppendLine(",large_inspection_check1 = " + Large_inspection_check1);
                sb.AppendLine(",large_inspection_check2 = " + Large_inspection_check2);
                sb.AppendLine(",large_inspection_check3 = " + Large_inspection_check3);
                sb.AppendLine(",large_inspection_check4 = " + Large_inspection_check4);

                sb.AppendLine("WHERE");
                sb.AppendLine("id = " + Report_id);

                clsSqlDb.DMLUpdate(sb.ToString());

                MessageBox.Show("登録しました。");
            }

        }

        /// <summary>
        /// 閉じるボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}