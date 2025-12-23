using FlockAppC.pubClass;
using FlockReport.pubClass;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FlockReport
{
    public partial class frmDisplayTrnReport : Form
    {
        public frmDisplayTrnReport(int p_con = clsStatic.CON_SQL)
        {
            // 接続先情報
            con = p_con;

            InitializeComponent();
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmDisplayTrnReport_Load(object sender, EventArgs e)
        {
            // IDチェック
            if (Id <= 0)
            {
                // Id未設定の場合は処理終了
                return;
            }

            // 画面初期化
            Initialize_Display();

            // IDセット
            this.lblId.Text = Id.ToString();

            // 日報入力データ表示
            Display_ReportData(0);

            this.Location = new Point(0, 0);
        }

        /// <summary>
        /// 画面項目クリア
        /// </summary>
        private void Initialize_Display()
        {
            this.lblLocation_Name.Text = "";                // 専従先名
            this.lblDay.Text = "";                          // 日付
            this.lblCar_No.Text = "";                       // 車輌番号 
            this.lblCar_Name.Text = "";                     // 号車 
            this.lblInstructor_Name.Text = "";              // 責任者名 
            this.lblUser_Name1.Text = "";                   // 担当者名1 
            this.lblUser_Name2.Text = "";                   // 担当者名2
            this.lblUser_Name3.Text = "";                   // 担当者名3 
            this.lblStart_Time1.Text = "";                  // 始業時間1 
            this.lblStart_Time2.Text = "";                  // 始業時間2 
            this.lblStart_Time3.Text = "";                  // 始業時間3 
            this.lblEnd_Time1.Text = "";                    // 終業時間1 
            this.lblEnd_Time2.Text = "";                    // 終業時間2 
            this.lblEnd_Time3.Text = "";                    // 終業時間3 
            this.lblAfter_Meter.Text = "";                  // 入庫時メーター 
            this.lblBefore_Meter.Text = "";                 // 出庫時メーター 
            this.lblMileage.Text = "";                      // 走行距離
            this.lblGasoline.Text = "";                     // ガソリン／軽油
            this.lblOil.Text = "";                          // 給油量
            this.lblOil_Meter.Text = "";                    // 給油時メーター
            this.lblAlcohol1.Text = "";                     // アルコール値1 
            this.lblAlcohol2.Text = "";                     // アルコール値2 
            this.lblAlcohol3.Text = "";                     // アルコール値3 
            this.lblAlcohol_Check1.Text = "";               // アルコールチェック結果1 
            this.lblAlcohol_Check2.Text = "";               // アルコールチェック結果2 
            this.lblAlcohol_Check3.Text = "";               // アルコールチェック結果3 
            this.lblTemp1.Text = "";                        // 体温1 
            this.lblTemp2.Text = "";                        // 体温2 
            this.lblTemp3.Text = "";                        // 体温3 
            this.lblTemp_Time1.Text = "";                   // 検温時刻1 
            this.lblTemp_Time2.Text = "";                   // 検温時刻2 
            this.lblTemp_Time3.Text = "";                   // 検温時刻3 

            this.lblInspection_Check1.Text = "";            // 運行前点検1 
            this.lblInspection_Check2.Text = "";            // 運行前点検2 
            this.lblInspection_Check3.Text = "";            // 運行前点検3 
            this.lblInspection_Check4.Text = "";            // 運行前点検4 
            this.lblInspection_Check5.Text = "";            // 運行前点検5 
            this.lblInspection_Check6.Text = "";            // 運行前点検6 
            this.lblInspection_Check7.Text = "";            // 運行前点検7 

            this.lblPer_Inspection_Check1.Text = "";        // 定期点検1 
            this.lblPer_Inspection_Check2.Text = "";        // 定期点検2 
            this.lblPer_Inspection_Check3.Text = "";        // 定期点検3 
            this.lblPer_Inspection_Check4.Text = "";        // 定期点検4 
            this.lblPer_Inspection_Check5.Text = "";        // 定期点検5 
            this.lblPer_Inspection_Check6.Text = "";        // 定期点検6 
            this.lblPer_Inspection_Check7.Text = "";        // 定期点検7 
            this.lblPer_Inspection_Check8.Text = "";        // 定期点検8 
            this.lblPer_Inspection_Check9.Text = "";        // 定期点検9 
            this.lblPer_Inspection_Check10.Text = "";       // 定期点検10 
            this.lblPer_Inspection_Check11.Text = "";       // 定期点検11
            this.lblPer_Inspection_Check12.Text = "";       // 定期点検12 
            this.lblPer_Inspection_Check13.Text = "";       // 定期点検13 
            this.lblPer_Inspection_Check14.Text = "";       // 定期点検14 

            this.lblWid_Inspection_Check1.Text = "";        // 大型点検1 
            this.lblWid_Inspection_Check2.Text = "";        // 大型点検2 
            this.lblWid_Inspection_Check3.Text = "";        // 大型点検3 
            this.lblWid_Inspection_Check4.Text = "";        // 大型点検4 

            this.txtComment.Text = "";                      // 備考 
        }
 
        /// <summary>
        /// 日報入力データ表示
        /// </summary>
        /// <param name="iKbn">1:指定IDより前のデータが対象 2:指定IDより後のデータが対象 0:指定IDのデータが対象</param>
        private void Display_ReportData(int iKbn)
        {
            // ------------------------------------------------------------------------------------
            // 接続先指定
            // ------------------------------------------------------------------------------------
            clsPublic cPublic = new clsPublic(con);
            clsTrnReport cTrnReport = new clsTrnReport();

            StringBuilder stb = new StringBuilder();

            // エラーメッセージ用
            stb.AppendLine("【確認内容】");

            try
            {
                // Get Report Data ※from_day, to_day, user_id, car_idは未使用
                cTrnReport.Get(iKbn, day, from_day, to_day, Id, location_id, user_id1, car_id, car_no);

                // データ件数判定
                if (cTrnReport.dt.Rows.Count == 0)
                {
                    // データ無し→メッセージ表示
                    MessageBox.Show("日報入力データがありません。", "結果", MessageBoxButtons.OK);
                    return;
                }

                // 画面初期化
                Initialize_Display();

                foreach (DataRow dr in cTrnReport.dt.Rows)
                {
                    this.lblId.Text = dr["id"].ToString();
                    this.lblLocation_Name.Text = dr["location_fullname"].ToString();
                    this.lblDay.Text = DateTime.Parse(dr["day"].ToString()).ToString("yyyy年MM月dd日") + "(" + DateTime.Parse(dr["day"].ToString()).ToString("dddd") + ")";
                    this.lblCar_No.Text = dr["car_no"].ToString();
                    this.lblCar_Name.Text = dr["car_name"].ToString();
                    this.lblInstructor_Name.Text = dr["instructor_fullname"].ToString();
                    this.lblUser_Name1.Text = dr["user_fullname1"].ToString();
                    this.lblUser_Name2.Text = dr["user_fullname2"].ToString();
                    this.lblUser_Name3.Text = dr["user_fullname3"].ToString();

                    // ==============================================================================================
                    // 始業/終業時間
                    // ==============================================================================================
                    var st1 = DateTime.Parse("1900/01/01 00:00:00");
                    var st2 = DateTime.Parse("1900/01/01 00:00:00");
                    var st3 = DateTime.Parse("1900/01/01 00:00:00");
                    var en1 = DateTime.Parse("1900/01/01 00:00:00");
                    var en2 = DateTime.Parse("1900/01/01 00:00:00");
                    var en3 = DateTime.Parse("1900/01/01 00:00:00");
                    if (dr["start_time1"] != null && dr["start_time1"].ToString() != "")
                    {
                        this.lblStart_Time1.Text  = dr["start_time1"].ToString();
                        st1 = DateTime.Parse(dr["start_time1"].ToString());
                    }
                    if (dr["start_time2"] != null && dr["start_time2"].ToString() != "")
                    {
                        this.lblStart_Time2.Text  = dr["start_time2"].ToString();
                        st2 = DateTime.Parse(dr["start_time2"].ToString());
                    }
                    if (dr["start_time3"] != null && dr["start_time3"].ToString() != "") 
                    { 
                        this.lblStart_Time3.Text  = dr["start_time3"].ToString();
                        st3 = DateTime.Parse(dr["start_time3"].ToString());
                    }
                    // 終了時間
                    if (dr["end_time1"] != null && dr["end_time1"].ToString() != "") 
                    { 
                        this.lblEnd_Time1.Text  = dr["end_time1"].ToString();
                        en1 = DateTime.Parse(dr["end_time1"].ToString());
                    }
                    if (dr["end_time2"] != null && dr["end_time2"].ToString() != "") 
                    { 
                        this.lblEnd_Time2.Text  = dr["end_time2"].ToString();
                        en2 = DateTime.Parse(dr["end_time2"].ToString());
                    }
                    if (dr["end_time3"] != null && dr["end_time3"].ToString() != "") 
                    { 
                        this.lblEnd_Time3.Text  = dr["end_time3"].ToString();
                        en3 = DateTime.Parse(dr["end_time3"].ToString());
                    }
                    // 時刻整合性チェック
                    // 始業①終了①どちらか未入力の場合
                    if (st1 == DateTime.Parse("1900/01/01"))
                    {
                        // ラベル設定
                        cPublic.SetLabelFont("未入", clsStatic.CHK_FONT, 11, Color.Red, FontStyle.Bold, this.lblStart_Time1);
                        stb.AppendLine("・始業時間1が入力されていません。");
                    }
                    else
                    {
                        // ラベル設定（OK）
                        cPublic.SetLabelFont(this.lblStart_Time1.Text, clsStatic.CHK_FONT, 11, Color.Black, FontStyle.Regular, this.lblStart_Time1);
                    }
                    if (en1 == DateTime.Parse("1900/01/01"))
                    {
                        // ラベル設定
                        cPublic.SetLabelFont("未入", clsStatic.CHK_FONT, 11, Color.Red, FontStyle.Bold, this.lblEnd_Time1);
                        stb.AppendLine("・終業時間1が入力されていません。");
                    }
                    else
                    {
                        // ラベル設定（OK）
                        cPublic.SetLabelFont(this.lblEnd_Time1.Text, clsStatic.CHK_FONT, 11, Color.Black, FontStyle.Regular, this.lblEnd_Time1);
                    }

                    // 始業②入力あり終業②入力なし
                    if (st2 != DateTime.Parse("1900/01/01") && en2 == DateTime.Parse("1900/01/01"))
                    {
                        // ラベル設定
                        cPublic.SetLabelFont("未入", clsStatic.CHK_FONT, 11, Color.Red, FontStyle.Bold, this.lblEnd_Time2);
                        stb.AppendLine("・終業時間2が入力されていません。");
                    }
                    else
                    {
                        // ラベル設定（OK）
                        cPublic.SetLabelFont(this.lblEnd_Time2.Text, clsStatic.CHK_FONT, 11, Color.Black, FontStyle.Regular, this.lblEnd_Time2);
                    }


                    // 始業②入力なし終業②入力あり
                    if (st2 == DateTime.Parse("1900/01/01") && en2 != DateTime.Parse("1900/01/01"))
                    {
                        // ラベル設定
                        cPublic.SetLabelFont("未入", clsStatic.CHK_FONT, 11, Color.Red, FontStyle.Bold, this.lblStart_Time2);
                        stb.AppendLine("・始業時間2が入力されていません。");
                    }
                    else
                    {
                        // ラベル設定（OK）
                        cPublic.SetLabelFont(this.lblStart_Time2.Text, clsStatic.CHK_FONT, 11, Color.Black, FontStyle.Regular, this.lblStart_Time2);
                    }

                    // 始業③入力あり終業③入力なし
                    if (st3 != DateTime.Parse("1900/01/01") && en3 == DateTime.Parse("1900/01/01"))
                    {
                        // ラベル設定
                        cPublic.SetLabelFont("未入", clsStatic.CHK_FONT, 11, Color.Red, FontStyle.Bold, this.lblEnd_Time3);
                        stb.AppendLine("・終業時間3が入力されていません。");
                    }
                    else
                    {
                        // ラベル設定（OK）
                        cPublic.SetLabelFont(this.lblEnd_Time3.Text, clsStatic.CHK_FONT, 11, Color.Black, FontStyle.Regular, this.lblEnd_Time3);
                    }

                    // 始業③入力なし終業③入力あり
                    if (st3 == DateTime.Parse("1900/01/01") && en3 != DateTime.Parse("1900/01/01"))
                    {
                        // ラベル設定
                        cPublic.SetLabelFont("未入", clsStatic.CHK_FONT, 11, Color.Red, FontStyle.Bold, this.lblStart_Time3);
                        stb.AppendLine("・始業時間3が入力されていません。");
                    }
                    else
                    {
                        // ラベル設定（OK）
                        cPublic.SetLabelFont(this.lblStart_Time3.Text, clsStatic.CHK_FONT, 11, Color.Black, FontStyle.Regular, this.lblStart_Time3);
                    }

                    // 始業①入力あり終業①入力ありで始業①>終業①の場合
                    if (st1 != DateTime.Parse("1900/01/01") && en1 != DateTime.Parse("1900/01/01"))
                    {
                        if (st1 > en1)
                        {
                            // ラベル設定
                            cPublic.SetLabelFont(this.lblStart_Time1.Text, clsStatic.CHK_FONT, 11, Color.Red, FontStyle.Bold, this.lblStart_Time1);
                            cPublic.SetLabelFont(this.lblEnd_Time1.Text, clsStatic.CHK_FONT, 11, Color.Red, FontStyle.Bold, this.lblEnd_Time1);
                            stb.AppendLine("・始業時間1が終業時間1より遅い時間です。");
                        }
                        else
                        {
                            // ラベル設定（OK）
                            cPublic.SetLabelFont(this.lblStart_Time1.Text, clsStatic.CHK_FONT, 11, Color.Black, FontStyle.Regular, this.lblStart_Time1);
                            cPublic.SetLabelFont(this.lblEnd_Time1.Text, clsStatic.CHK_FONT, 11, Color.Black, FontStyle.Regular, this.lblEnd_Time1);
                        }
                    }
                    // 始業②入力あり終業②入力ありで始業②>終業②の場合
                    if (st2 != DateTime.Parse("1900/01/01") && en2 != DateTime.Parse("1900/01/01"))
                    {
                        if (st2 > en2)
                        {
                            // ラベル設定
                            cPublic.SetLabelFont(this.lblStart_Time2.Text, clsStatic.CHK_FONT, 11, Color.Red, FontStyle.Bold, this.lblStart_Time2);
                            cPublic.SetLabelFont(this.lblEnd_Time2.Text, clsStatic.CHK_FONT, 11, Color.Red, FontStyle.Bold, this.lblEnd_Time2);
                            stb.AppendLine("・始業時間2が終業時間2より遅い時間です。");
                        }
                        else
                        {
                            // ラベル設定（OK）
                            cPublic.SetLabelFont(this.lblStart_Time2.Text, clsStatic.CHK_FONT, 11, Color.Black, FontStyle.Regular, this.lblStart_Time2);
                            cPublic.SetLabelFont(this.lblEnd_Time2.Text, clsStatic.CHK_FONT, 11, Color.Black, FontStyle.Regular, this.lblEnd_Time2);
                        }
                    }
                    // 始業③入力あり終業③入力ありで始業③>終業③の場合
                    if (st3 != DateTime.Parse("1900/01/01") && en3 != DateTime.Parse("1900/01/01"))
                    {
                        if (st3 > en3)
                        {
                            // ラベル設定
                            cPublic.SetLabelFont(this.lblStart_Time3.Text, clsStatic.CHK_FONT, 11, Color.Red, FontStyle.Bold, this.lblStart_Time3);
                            cPublic.SetLabelFont(this.lblEnd_Time3.Text, clsStatic.CHK_FONT, 11, Color.Red, FontStyle.Bold, this.lblEnd_Time3);
                            stb.AppendLine("・始業時間3が終業時間3より遅い時間です。");
                        }
                        else
                        {
                            // ラベル設定（OK）
                            cPublic.SetLabelFont(this.lblStart_Time3.Text, clsStatic.CHK_FONT, 11, Color.Black, FontStyle.Regular, this.lblStart_Time3);
                            cPublic.SetLabelFont(this.lblEnd_Time3.Text, clsStatic.CHK_FONT, 11, Color.Black, FontStyle.Regular, this.lblEnd_Time3);
                        }
                    }
 
                    // ==============================================================================================
                    // 入庫時、出庫時メーター、走行距離
                    // ==============================================================================================
                    var aft = -1;
                    var bfr = -1;
                    if (dr["after_meter"] != null && dr["after_meter"].ToString() != "" && dr["after_meter"].ToString() != "-1") 
                    {
                        // ｶﾝﾏ付きで表示
                        this.lblAfter_Meter.Text = String.Format("{0:#,0}", int.Parse(dr["after_meter"].ToString()));
                        aft = int.Parse(dr["after_meter"].ToString());
                    }
                    if (dr["before_meter"] != null && dr["before_meter"].ToString() != "" && dr["before_meter"].ToString() != "-1")
                    {
                        // ｶﾝﾏ付きで表示
                        this.lblBefore_Meter.Text = String.Format("{0:#,0}", int.Parse(dr["before_meter"].ToString()));
                        bfr = int.Parse(dr["before_meter"].ToString());
                    }
                    // 入庫時、出庫時メーター値チェック
                    if (aft != -1 && bfr != -1)
                    {
                        // 整合性チェック
                        if (aft < bfr)
                        {
                            // ラベル設定（整合性NG）
                            cPublic.SetLabelFont(this.lblAfter_Meter.Text, clsStatic.CHK_FONT, 11, Color.Red, FontStyle.Bold, this.lblAfter_Meter);
                            cPublic.SetLabelFont(this.lblBefore_Meter.Text, clsStatic.CHK_FONT, 11, Color.Red, FontStyle.Bold, this.lblBefore_Meter);
                            stb.AppendLine("・入庫時メーターが出庫時メーターより少ない距離です。");
                        }
                        else
                        {
                            // ラベル設定（整合性OK）
                            cPublic.SetLabelFont(this.lblAfter_Meter.Text, clsStatic.CHK_FONT, 11, Color.Black, FontStyle.Regular, this.lblAfter_Meter);
                            cPublic.SetLabelFont(this.lblBefore_Meter.Text, clsStatic.CHK_FONT, 11, Color.Black, FontStyle.Regular, this.lblBefore_Meter);

                            // 走行距離算出
                            var clc = aft - bfr;

                            // 走行距離の整合性チェック
                            // 基本的に自動計算の為、整合性がNGになる事はない（はず）
                            if (this.lblMileage.Text != "")
                            {
                                if (int.Parse(this.lblMileage.Text) != clc)
                                {
                                    // ラベル設定（整合性NG）
                                    cPublic.SetLabelFont(this.lblMileage.Text, clsStatic.CHK_FONT, 11, Color.Red, FontStyle.Bold, this.lblMileage);
                                }
                                else
                                {
                                    // ラベル設定（整合性OK）
                                    cPublic.SetLabelFont(this.lblMileage.Text, clsStatic.CHK_FONT, 11, Color.Black, FontStyle.Regular, this.lblMileage);
                                }
                            }
                        }
                    }

                    if (dr["mileage"] != null && dr["mileage"].ToString() != "" && dr["mileage"].ToString() != "-1")
                    {
                        this.lblMileage.Text   = String.Format("{0:#,0}", int.Parse(dr["mileage"].ToString()));
                    }

                    // 前回の「入庫時メーター」と今回の「出庫時メーター」が同じか確認
                    if (bfr != -1)
                    {
                        // 直近の入庫時メーター値を取得
                        var iAfterMeter = cPublic.GetAfterMeter(int.Parse(dr["location_id"].ToString()), dr["car_no"].ToString(), DateTime.Parse(dr["day"].ToString()));

                        // 今回の出庫時メーターと比較
                        if (bfr != iAfterMeter && iAfterMeter != 0)
                        {
                            // ラベル設定（整合性NG）
                            cPublic.SetLabelFont(this.lblBefore_Meter.Text, clsStatic.CHK_FONT, 11, Color.Red, FontStyle.Bold, this.lblBefore_Meter);
                            stb.AppendLine("・出庫時メーターが直前の入庫時メーターと異なります。");
                        }
                        else
                        {
                            // ラベル設定（OK）
                            cPublic.SetLabelFont(this.lblBefore_Meter.Text, clsStatic.CHK_FONT, 11, Color.Black, FontStyle.Regular, this.lblBefore_Meter);
                        }
                    }

                    // ==============================================================================================
                    // ガソリン、軽油
                    // ==============================================================================================
                    if (dr["gasoline"] != null && dr["gasoline"].ToString() != "")
                    {
                        if (int.Parse(dr["gasoline"].ToString()) == 0) { this.lblGasoline.Text  = "ガソリン"; }
                        else if (int.Parse(dr["gasoline"].ToString()) == 1) { this.lblGasoline.Text = "軽　油"; }         // 軽油は「1」
                    }
                    // 給油量
                    if (dr["oil"] != null && dr["oil"].ToString() != "" && dr["oil"].ToString() != "-1")
                    {
                        this.lblOil.Text = dr["oil"].ToString(); 
                    }
                    // 給油時メーター値
                    if (dr["oil_meter"] != null && dr["oil_meter"].ToString() != "" && dr["oil_meter"].ToString() != "-1") 
                    {
                        // ｶﾝﾏ付きで表示
                        this.lblOil_Meter.Text = String.Format("{0:#,0} Bytes", int.Parse(dr["oil_meter"].ToString()));

                        // 給油時メーター
                        var oil = int.Parse(dr["oil_meter"].ToString());

                        // 出庫時メーターと入庫時メーターの間か
                        if (oil < bfr || oil > aft)
                        {
                            // ラベル設定（整合性NG）
                            cPublic.SetLabelFont(this.lblOil_Meter.Text, clsStatic.CHK_FONT, 11, Color.Red, FontStyle.Bold, this.lblOil_Meter);
                            stb.AppendLine("・給油時のメーターが出庫時と入庫時から外れています。");
                        }
                        else
                        {
                            // ラベル設定
                            cPublic.SetLabelFont(this.lblOil_Meter.Text, clsStatic.CHK_FONT, 11, Color.Black, FontStyle.Regular, this.lblOil_Meter);
                        }

                    }
                    //// 給油時時刻
                    //if (dr["oil_time"] != null && dr["oil_time"].ToString() != "") { this.lblOil_Time.Text = dr["oil_time"].ToString(); }

                    // ==============================================================================================
                    // アルコールチェック
                    // ==============================================================================================
                    decimal alc1 = -1;
                    decimal alc2 = -1;
                    decimal alc3 = -1;
                    if (dr["alcohol1"] != null && dr["alcohol1"].ToString() != "" && dr["alcohol1"].ToString() != "-1.0") 
                    {
                        this.lblAlcohol1.Text = dr["alcohol1"].ToString();
                        alc1 = decimal.Parse(dr["alcohol1"].ToString());
                    }
                    if (dr["alcohol2"] != null && dr["alcohol2"].ToString() != "" && dr["alcohol2"].ToString() != "-1.0") 
                    {
                        this.lblAlcohol2.Text = dr["alcohol2"].ToString();
                        alc2 = decimal.Parse(dr["alcohol2"].ToString());
                    }
                    if (dr["alcohol3"] != null && dr["alcohol3"].ToString() != "" && dr["alcohol3"].ToString() != "-1.0") 
                    {
                        this.lblAlcohol3.Text = dr["alcohol3"].ToString();
                        alc3 = decimal.Parse(dr["alcohol3"].ToString());
                    }
                    if (dr["alcohol_check1"] != null && dr["alcohol_check1"].ToString() != "")
                    {
                        if (int.Parse(dr["alcohol_check1"].ToString()) == 1)
                        {
                            // 整合性チェック
                            if (alc1 != 0)
                            {
                                // ラベル設定（整合性NG） 濃度0以外で「可」になっている
                                cPublic.SetLabelFont("可", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Red, FontStyle.Bold, this.lblAlcohol_Check1);
                                stb.AppendLine("・アルコール濃度1 > 0で、「可」になっています");
                            }
                            else
                            {
                                // ラベル設定
                                cPublic.SetLabelFont("可", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Black, FontStyle.Regular, this.lblAlcohol_Check1);
                            }
                        }
                        else if (int.Parse(dr["alcohol_check1"].ToString()) == 0)
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("否", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Red, FontStyle.Bold, this.lblAlcohol_Check1);
                            stb.AppendLine("・運転が「否」になっています");
                        }
                    }
                    if (dr["alcohol_check2"] != null && dr["alcohol_check2"].ToString() != "")
                    {
                        if (int.Parse(dr["alcohol_check2"].ToString()) == 1) 
                        {
                            // 整合性チェック
                            if (alc2 != 0)
                            {
                                // ラベル設定（整合性NG） 濃度0以外で「可」になっている
                                cPublic.SetLabelFont("可", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Red, FontStyle.Bold, this.lblAlcohol_Check2);
                                stb.AppendLine("・アルコール濃度2 > 0で、「可」になっています");
                            }
                            else
                            {
                                // ラベル設定
                                cPublic.SetLabelFont("可", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Black, FontStyle.Regular, this.lblAlcohol_Check2);
                            }
                        }
                        else if (int.Parse(dr["alcohol_check2"].ToString()) == 0)
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("否", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Red, FontStyle.Bold, this.lblAlcohol_Check2);
                            stb.AppendLine("・運転が「否」になっています");
                        }
                    }
                    if (dr["alcohol_check3"] != null && dr["alcohol_check3"].ToString() != "")
                    {
                        if (int.Parse(dr["alcohol_check3"].ToString()) == 1) 
                        {
                            // 整合性チェック
                            if (alc3 != 0)
                            {
                                // ラベル設定（整合性NG） 濃度0以外で「可」になっている
                                cPublic.SetLabelFont("可", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Red, FontStyle.Bold, this.lblAlcohol_Check3);
                                stb.AppendLine("・アルコール濃度3 > 0で、「可」になっています");
                            }
                            else
                            {
                                // ラベル設定
                                cPublic.SetLabelFont("可", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Black, FontStyle.Regular, this.lblAlcohol_Check3);
                            }
                        }
                        else if (int.Parse(dr["alcohol_check3"].ToString()) == 0)
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("否", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Red, FontStyle.Bold, this.lblAlcohol_Check3);
                            stb.AppendLine("・運転が「否」になっています");
                        }
                    }

                    // 検温
                    if (dr["temp1"] != null && dr["temp1"].ToString() != "" && dr["temp1"].ToString() != "-1.0") 
                    { 
                        this.lblTemp1.Text = dr["temp1"].ToString(); 
                    }
                    if (dr["temp2"] != null && dr["temp2"].ToString() != "" && dr["temp2"].ToString() != "-1.0")
                    {
                        this.lblTemp2.Text = dr["temp2"].ToString(); 
                    }
                    if (dr["temp3"] != null && dr["temp3"].ToString() != "" && dr["temp3"].ToString() != "-1.0") 
                    {
                        this.lblTemp3.Text = dr["temp3"].ToString();
                    }
                    if (dr["temp_time1"] != null && dr["temp_time1"].ToString() != "") { this.lblTemp_Time1.Text = dr["temp_time1"].ToString(); }
                    if (dr["temp_time2"] != null && dr["temp_time2"].ToString() != "") { this.lblTemp_Time2.Text = dr["temp_time2"].ToString(); }
                    if (dr["temp_time3"] != null && dr["temp_time3"].ToString() != "") { this.lblTemp_Time3.Text = dr["temp_time3"].ToString(); }

                    // 運行前点検 ①
                    if (dr["inspection_check1"] != null && dr["inspection_check1"].ToString() != "")
                    {
                        if (int.Parse(dr["inspection_check1"].ToString()) == 1) 
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("良", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Black, FontStyle.Regular, this.lblInspection_Check1);
                            //this.lblInspection_Check1.Text = "良";
                            //this.lblInspection_Check1.Font = new Font("游ゴシック", 9);
                            //this.lblInspection_Check1.ForeColor = Color.Black;
                        }
                        else 
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("否", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Red, FontStyle.Bold, this.lblInspection_Check1);
                            //this.lblInspection_Check1.Text = "否";
                            //this.lblInspection_Check1.Font = new Font("游ゴシック", 9, FontStyle.Bold);
                            //this.lblInspection_Check1.ForeColor = Color.Red;
                        }
                    }
                    // 運行前点検 ②
                    if (dr["inspection_check2"] != null && dr["inspection_check2"].ToString() != "")
                    {
                        if (int.Parse(dr["inspection_check2"].ToString()) == 1)
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("良", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Black, FontStyle.Regular, this.lblInspection_Check2);
                            //this.lblInspection_Check2.Text = "良"; 
                        } 
                        else 
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("否", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Red, FontStyle.Bold, this.lblInspection_Check2);
                            //this.lblInspection_Check2.Text = "否"; 
                        }
                    }
                    // 運行前点検 ③
                    if (dr["inspection_check3"] != null && dr["inspection_check3"].ToString() != "")
                    {
                        if (int.Parse(dr["inspection_check3"].ToString()) == 1)
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("良", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Black, FontStyle.Regular, this.lblInspection_Check3);
                            //this.lblInspection_Check3.Text = "良"; 
                        }
                        else 
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("否", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Red, FontStyle.Bold, this.lblInspection_Check3);
                            //this.lblInspection_Check3.Text = "否"; 
                        }
                    }
                    // 運行前点検 ④
                    if (dr["inspection_check4"] != null && dr["inspection_check4"].ToString() != "")
                    {
                        if (int.Parse(dr["inspection_check4"].ToString()) == 1)
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("良", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Black, FontStyle.Regular, this.lblInspection_Check4);
                            // this.lblInspection_Check4.Text = "良";
                        } 
                        else
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("否", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Red, FontStyle.Bold, this.lblInspection_Check4);
                            // this.lblInspection_Check4.Text = "否"; 
                        }
                    }
                    // 運行前点検 ⑤
                    if (dr["inspection_check5"] != null && dr["inspection_check5"].ToString() != "")
                    {
                        if (int.Parse(dr["inspection_check5"].ToString()) == 1) 
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("良", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Black, FontStyle.Regular, this.lblInspection_Check5);
                            //this.lblInspection_Check5.Text = "良"; 
                        }
                        else 
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("否", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Red, FontStyle.Bold, this.lblInspection_Check5);
                            // this.lblInspection_Check5.Text = "否";
                        }
                    }
                    // 運行前点検 ⑥
                    if (dr["inspection_check6"] != null && dr["inspection_check6"].ToString() != "")
                    {
                        if (int.Parse(dr["inspection_check6"].ToString()) == 1) 
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("良", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Black, FontStyle.Regular, this.lblInspection_Check6);
                            //this.lblInspection_Check6.Text = "良"; 
                        } 
                        else 
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("否", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Red, FontStyle.Bold, this.lblInspection_Check6);
                            // this.lblInspection_Check6.Text = "否"; 
                        }
                    }
                    // 運行前点検 ⑦
                    if (dr["inspection_check7"] != null && dr["inspection_check7"].ToString() != "")
                    {
                        if (int.Parse(dr["inspection_check7"].ToString()) == 1) 
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("無", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Black, FontStyle.Regular, this.lblInspection_Check7);
                            //this.lblInspection_Check7.Text = "無"; 
                        } 
                        else 
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("有", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Red, FontStyle.Bold, this.lblInspection_Check7);
                            // this.lblInspection_Check7.Text = "有"; 
                        }
                    }
                    // 定期点検 ①
                    if (dr["per_inspection_check1"] != null && dr["per_inspection_check1"].ToString() != "")
                    {
                        if (int.Parse(dr["per_inspection_check1"].ToString()) == 1) 
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("良", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Black, FontStyle.Regular, this.lblPer_Inspection_Check1);
                            //this.lblPer_Inspection_Check1.Text = "良"; 
                        } 
                        else 
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("否", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Red, FontStyle.Bold, this.lblPer_Inspection_Check1);
                            // this.lblPer_Inspection_Check1.Text = "否"; 
                        }
                    }
                    // 定期点検 ②
                    if (dr["per_inspection_check2"] != null && dr["per_inspection_check2"].ToString() != "")
                    {
                        if (int.Parse(dr["per_inspection_check2"].ToString()) == 1) 
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("良", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Black, FontStyle.Regular, this.lblPer_Inspection_Check2);
                            // this.lblPer_Inspection_Check2.Text = "良"; 
                        }
                        else 
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("否", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Red, FontStyle.Bold, this.lblPer_Inspection_Check2);
                            // this.lblPer_Inspection_Check2.Text = "否"; 
                        }
                    }
                    // 定期点検 ③
                    if (dr["per_inspection_check3"] != null && dr["per_inspection_check3"].ToString() != "")
                    {
                        if (int.Parse(dr["per_inspection_check3"].ToString()) == 1) 
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("良", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Black, FontStyle.Regular, this.lblPer_Inspection_Check3);
                            // this.lblPer_Inspection_Check3.Text = "良";
                        }
                        else 
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("否", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Red, FontStyle.Bold, this.lblPer_Inspection_Check3);
                            // this.lblPer_Inspection_Check3.Text = "否"; 
                        }
                    }
                    // 定期点検 ④
                    if (dr["per_inspection_check4"] != null && dr["per_inspection_check4"].ToString() != "")
                    {
                        if (int.Parse(dr["per_inspection_check4"].ToString()) == 1) 
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("良", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Black, FontStyle.Regular, this.lblPer_Inspection_Check4);
                            // this.lblPer_Inspection_Check4.Text = "良";
                        }
                        else 
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("否", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Red, FontStyle.Bold, this.lblPer_Inspection_Check4);
                            // this.lblPer_Inspection_Check4.Text = "否"; 
                        }
                    }
                    // 定期点検 ⑤
                    if (dr["per_inspection_check5"] != null && dr["per_inspection_check5"].ToString() != "")
                    {
                        if (int.Parse(dr["per_inspection_check5"].ToString()) == 1)
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("良", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Black, FontStyle.Regular, this.lblPer_Inspection_Check5);
                            // this.lblPer_Inspection_Check5.Text = "良"; 
                        }
                        else
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("否", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Red, FontStyle.Bold, this.lblPer_Inspection_Check5);
                            // this.lblPer_Inspection_Check5.Text = "否"; 
                        }
                    }
                    // 定期点検 ⑥
                    if (dr["per_inspection_check6"] != null && dr["per_inspection_check6"].ToString() != "")
                    {
                        if (int.Parse(dr["per_inspection_check6"].ToString()) == 1) 
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("良", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Black, FontStyle.Regular, this.lblPer_Inspection_Check6);
                            // this.lblPer_Inspection_Check6.Text = "良";
                        }
                        else 
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("否", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Red, FontStyle.Bold, this.lblPer_Inspection_Check6);
                            // this.lblPer_Inspection_Check6.Text = "否"; 
                        }
                    }
                    // 定期点検 ⑦
                    if (dr["per_inspection_check7"] != null && dr["per_inspection_check7"].ToString() != "")
                    {
                        if (int.Parse(dr["per_inspection_check7"].ToString()) == 1)
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("良", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Black, FontStyle.Regular, this.lblPer_Inspection_Check7);
                            // this.lblPer_Inspection_Check7.Text = "良"; 
                        } 
                        else
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("否", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Red, FontStyle.Bold, this.lblPer_Inspection_Check7);
                            //this.lblPer_Inspection_Check7.Text = "否";
                        }
                    }
                    // 定期点検 ⑧
                    if (dr["per_inspection_check8"] != null && dr["per_inspection_check8"].ToString() != "")
                    {
                        if (int.Parse(dr["per_inspection_check8"].ToString()) == 1) 
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("良", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Black, FontStyle.Regular, this.lblPer_Inspection_Check8);
                            // this.lblPer_Inspection_Check8.Text = "良";
                        }
                        else 
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("否", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Red, FontStyle.Bold, this.lblPer_Inspection_Check8);
                            // this.lblPer_Inspection_Check8.Text = "否"; 
                        }
                    }
                    // 定期点検 ⑨
                    if (dr["per_inspection_check9"] != null && dr["per_inspection_check9"].ToString() != "")
                    {
                        if (int.Parse(dr["per_inspection_check9"].ToString()) == 1) 
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("良", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Black, FontStyle.Regular, this.lblPer_Inspection_Check9);
                            // this.lblPer_Inspection_Check9.Text = "良"; 
                        }
                        else 
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("否", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Red, FontStyle.Bold, this.lblPer_Inspection_Check9);
                            // this.lblPer_Inspection_Check9.Text = "否"; 
                        }
                    }
                    // 定期点検 ⑩
                    if (dr["per_inspection_check10"] != null && dr["per_inspection_check10"].ToString() != "")
                    {
                        if (int.Parse(dr["per_inspection_check10"].ToString()) == 1) 
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("良", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Black, FontStyle.Regular, this.lblPer_Inspection_Check10);
                            // this.lblPer_Inspection_Check10.Text = "良"; 
                        }
                        else
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("否", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Red, FontStyle.Bold, this.lblPer_Inspection_Check10);
                            // this.lblPer_Inspection_Check10.Text = "否"; 
                        }
                    }
                    // 定期点検 ⑪
                    if (dr["per_inspection_check11"] != null && dr["per_inspection_check11"].ToString() != "")
                    {
                        if (int.Parse(dr["per_inspection_check11"].ToString()) == 1)
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("良", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Black, FontStyle.Regular, this.lblPer_Inspection_Check11);
                            // this.lblPer_Inspection_Check11.Text = "良"; 
                        }
                        else
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("否", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Red, FontStyle.Bold, this.lblPer_Inspection_Check11);
                            // this.lblPer_Inspection_Check11.Text = "否";
                        }
                    }
                    // 定期点検 ⑫
                    if (dr["per_inspection_check12"] != null && dr["per_inspection_check12"].ToString() != "")
                    {
                        if (int.Parse(dr["per_inspection_check12"].ToString()) == 1) 
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("良", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Black, FontStyle.Regular, this.lblPer_Inspection_Check12);
                            // this.lblPer_Inspection_Check12.Text = "良"; 
                        }
                        else
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("否", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Red, FontStyle.Bold, this.lblPer_Inspection_Check12);
                            // this.lblPer_Inspection_Check12.Text = "否"; 
                        }
                    }
                    // 定期点検 ⑬
                    if (dr["per_inspection_check13"] != null && dr["per_inspection_check13"].ToString() != "")
                    {
                        if (int.Parse(dr["per_inspection_check13"].ToString()) == 1) 
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("良", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Black, FontStyle.Regular, this.lblPer_Inspection_Check13);
                            // this.lblPer_Inspection_Check13.Text = "良"; 
                        }
                        else
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("否", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Red, FontStyle.Bold, this.lblPer_Inspection_Check13);
                            // this.lblPer_Inspection_Check13.Text = "否"; 
                        }
                    }
                    // 定期点検 ⑭
                    if (dr["per_inspection_check14"] != null && dr["per_inspection_check14"].ToString() != "")
                    {
                        if (int.Parse(dr["per_inspection_check14"].ToString()) == 1) 
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("良", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Black, FontStyle.Regular, this.lblPer_Inspection_Check14);
                            // this.lblPer_Inspection_Check14.Text = "良"; 
                        }
                        else 
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("否", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Red, FontStyle.Bold, this.lblPer_Inspection_Check14);
                            // this.lblPer_Inspection_Check14.Text = "否"; 
                        }
                    }
                    // 大型 ①
                    if (dr["wid_inspection_check1"] != null && dr["wid_inspection_check1"].ToString() != "")
                    {
                        if (int.Parse(dr["wid_inspection_check1"].ToString()) == 1) 
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("良", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Black, FontStyle.Regular, this.lblWid_Inspection_Check1);
                            // this.lblWid_Inspection_Check1.Text = "良";
                        }
                        else
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("否", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Red, FontStyle.Bold, this.lblWid_Inspection_Check1);
                            // this.lblWid_Inspection_Check1.Text = "否"; 
                        }
                    }
                    // 大型 ②
                    if (dr["wid_inspection_check2"] != null && dr["wid_inspection_check2"].ToString() != "")
                    {
                        if (int.Parse(dr["wid_inspection_check2"].ToString()) == 1)
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("良", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Black, FontStyle.Regular, this.lblWid_Inspection_Check2);
                            // this.lblWid_Inspection_Check2.Text = "良"; 
                        }
                        else
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("否", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Red, FontStyle.Bold, this.lblWid_Inspection_Check2);
                            // this.lblWid_Inspection_Check2.Text = "否"; 
                        }
                    }
                    // 大型 ③
                    if (dr["wid_inspection_check3"] != null && dr["wid_inspection_check3"].ToString() != "")
                    {
                        if (int.Parse(dr["wid_inspection_check3"].ToString()) == 1) 
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("無", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Black, FontStyle.Regular, this.lblWid_Inspection_Check3);
                            // this.lblWid_Inspection_Check3.Text = "無";
                        }
                        else 
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("有", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Red, FontStyle.Bold, this.lblWid_Inspection_Check3);
                            // this.lblWid_Inspection_Check3.Text = "有"; 
                        }
                    }
                    // 大型 ④
                    if (dr["wid_inspection_check4"] != null && dr["wid_inspection_check4"].ToString() != "")
                    {
                        if (int.Parse(dr["wid_inspection_check4"].ToString()) == 1)
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("無", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Black, FontStyle.Regular, this.lblWid_Inspection_Check4);
                            // this.lblWid_Inspection_Check4.Text = "無"; 
                        }
                        else 
                        {
                            // ラベル設定
                            cPublic.SetLabelFont("有", clsStatic.CHK_FONT, clsStatic.CHK_FONT_SIZE, Color.Red, FontStyle.Bold, this.lblWid_Inspection_Check4);
                            // this.lblWid_Inspection_Check4.Text = "有"; 
                        }
                    }
                    // 備考
                    this.txtComment.Text = dr["comment"].ToString();

                    // ========================================================================
                    // 保持
                    // ========================================================================
                    // 日報ID
                    Id = int.Parse(dr["id"].ToString());
                    day = DateTime.Parse(dr["day"].ToString());
                    location_id = int.Parse(dr["location_id"].ToString());
                    if (dr["user_id1"].ToString() != "") { user_id1 = int.Parse(dr["user_id1"].ToString()); }
                    else { user_id1 = -1; }
                    if (dr["user_id2"].ToString() != "") { user_id2 = int.Parse(dr["user_id2"].ToString()); }
                    else { user_id2 = -1; }
                    if (dr["user_id3"].ToString() != "") { user_id3 = int.Parse(dr["user_id3"].ToString()); }
                    else { user_id3 = -1; }
                    car_id = int.Parse(dr["car_id"].ToString());
                    car_no = dr["car_no"].ToString();

                    break;
                }

                // チェックエラーメッセージ
                this.txtErrorReport.Text = stb.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK);
                throw;
            }
            finally
            {

            }
        }

        /// <summary>
        /// 編集ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReg_Click(object sender, EventArgs e)
        {
            frmEditTrnReport fEditTrnReport = new frmEditTrnReport(con);
            fEditTrnReport.Id = int.Parse(this.lblId.Text);
            fEditTrnReport.ShowDialog();

            // 再表示
            Initialize_Display();
            // 編集画面の専従先IDをセット
            Id = fEditTrnReport.Id;

            // ------------------------------------------------------------------------------------
            // 接続先指定
            // ------------------------------------------------------------------------------------
            Display_ReportData(0);
        }

        /// <summary>
        /// 「前データ」ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrev_Click(object sender, EventArgs e)
        {
            // ------------------------------------------------------------------------------------
            // 接続先指定
            // ------------------------------------------------------------------------------------
            // 1つ前のデータ表示
            // Initialize_Display();
            Display_ReportData(1);
        }

        /// <summary>
        /// 「次データ」ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            // ------------------------------------------------------------------------------------
            // 接続先指定
            // ------------------------------------------------------------------------------------
            // 1つ前のデータ表示
            // Initialize_Display();
            Display_ReportData(2);
        }

        /// <summary>
        /// 削除ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            StringBuilder stb = new StringBuilder();

            clsDbCon cDbCon = new clsDbCon();
            clsMySQL cMySQL = new clsMySQL();

            try
            {
                if (Id > 0)
                {
                    // 確認メッセージ表示
                    if (MessageBox.Show("削除します。宜しいですか？", "確認", MessageBoxButtons.OKCancel) == DialogResult.Cancel) { return; }

                    stb.Length = 0;
                    stb.AppendLine("DELETE FROM");
                    stb.AppendLine("trn_report");
                    stb.AppendLine("WHERE");
                    stb.AppendLine("id = " + Id);

                    // ------------------------------------------------------------------------------------
                    // 接続先指定
                    // ------------------------------------------------------------------------------------
                    if (con == clsStatic.CON_SQL)
                    {
                        cDbCon.DbCon();
                        cDbCon.sql = stb.ToString();
                        cDbCon.DMLUpdate();
                    }
                    else
                    {
                        // mySQL接続
                        if (cMySQL.Connect() != clsSsh.ConstOK)
                        {
                            MessageBox.Show("MySQL接続エラー", "エラー", MessageBoxButtons.OK);
                            return;
                        }
                        cMySQL.sql = stb.ToString();
                        cMySQL.DMLUpdate();
                    }

                    MessageBox.Show("削除しました。", "結果", MessageBoxButtons.OK);

                    // カレント表示のIDをクリア
                    Id = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK);
                throw;
            }
            finally
            {
                cDbCon.DBClose();
                cDbCon.Dispose();
                cMySQL.DeConnect();
                cMySQL.Dispose();
            }
        }

        /// <summary>
        /// 戻るボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 一覧からのパラメータ
        // 「前へ」「次へ」用
        public int Id { get; set; }
        public DateTime from_day { get; set; }
        public DateTime to_day { get; set; }
        public int user_id1 { get; set; }
        public int user_id2 { get; set; }
        public int user_id3 { get; set; }
        public int location_id { get; set; }
        public string car_no { get; set; }
        public int car_id { get; set; }
        public DateTime day { get; set; }

        // 接続先情報
        private int con { get; set; }

    }
}
