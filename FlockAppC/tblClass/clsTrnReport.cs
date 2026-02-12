using DocumentFormat.OpenXml.Bibliography;
using FlockAppC.pubClass;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FlockAppC.tblClass
{
    public class ClsTrnReport
    {
        // 画面からの検索キー指定
        public int Key_report_id {  get; set; }         // Key
        public DateTime Key_from_day {  get; set; }     // Where
        public DateTime Key_to_day { get; set; }        // Where
        public int Key_location_id {  get; set; }       // Where
        public int Key_car_id { get; set; }             // Where
        public int Key_staff_id { get; set; }           // Where
        // 締め日（CSV出力）
        public int Key_closing_date { get; set; }       // Where
        // 社内チェック実施
        public int Key_confirm1 { get; set; }           // Where
        // 管理責任者確認
        public int Key_confirm2 { get; set; }           // Where
        // お客様確認
        public int Key_confirm3 { get; set; }           // Where

        public int Select_count {  get; set; }          // Select結果
        public DataTable Dt {  get; set; }              // Select結果

        // 過去データ削除時の日付
        public DateTime Delete_date { get; set; }       // 削除日付（基準日）

        // ===============================================
        // Trn_日報
        // ===============================================
        public int Report_id { get; set; }
        public int Location_id {  get; set; }
        public int Car_id { get; set; }
        public DateTime Day {  get; set; }
        public int Instructor_id { get; set; }
        public int Staff_id1 { get; set; }
        // 2026/01/13 DEL (S)
        // public int Staff_id2 { get; set; }
        // public int Staff_id3 { get; set; }
        // 2026/01/13 DEL (E)
        public int After_meter { get; set; }
        public int Before_meter { get; set; }
        public int Mileage { get; set; }
        public decimal Fuel {  get; set; }
        public int Fuel_meter { get; set; }
        public decimal Oil { get; set; }
        public decimal Kerosene { get; set; }
        // 2026/01/13 DEL (S)
        // public string Start_location {  get; set; }
        // public string End_location { get; set; }
        // 2026/01/13 DEL (E) 

        // 2026/01/30 ADD (S)
        public DateTime Work_Start_time { get; set; }
        public DateTime Work_Finish_time { get; set; }
        // 2026/01/30 ADD (E)

        public DateTime Start_time1 { get; set; }
        public DateTime Start_time2 { get; set; }
        public DateTime Start_time3 { get; set; }
        public DateTime End_time1 { get; set; }
        public DateTime End_time2 { get; set; }
        public DateTime End_time3 { get; set; }

        public int Over_time1 { get; set; }
        public int Over_time2 { get; set; }
        public int Over_time3 { get; set; }

        public int Start_over_time1 { get; set; }
        public int Start_over_time2 { get; set; }
        public int Start_over_time3 { get; set; }

        public int End_over_time1 { get; set; }
        public int End_over_time2 { get; set; }
        public int End_over_time3 { get; set; }

        public int Start_over_time_kbn1 { get; set; }
        public int Start_over_time_kbn2 { get; set; }
        public int Start_over_time_kbn3 { get; set; }

        public int End_over_time_kbn1 { get; set; }
        public int End_over_time_kbn2 { get; set; }
        public int End_over_time_kbn3 { get; set; }

        public string Start_over_time_comment1 { get; set; }
        public string Start_over_time_comment2 { get; set; }
        public string Start_over_time_comment3 { get; set; }
        public string End_over_time_comment1 { get; set; }
        public string End_over_time_comment2 { get; set; }
        public string End_over_time_comment3 { get; set; }

        // 休憩時間
        public DateTime Start_break_time1 { get; set; }
        public DateTime Start_break_time2 { get; set; }
        public DateTime Start_break_time3 { get; set; }
        public DateTime End_break_time1 { get; set; }
        public DateTime End_break_time2 { get; set; }
        public DateTime End_break_time3 { get; set; }
        public int Break_time1 { get; set; }
        public int Break_time2 { get; set; }
        public int Break_time3 { get; set; }


        public int Subcar_flag { get; set; }
        public int Confirm1_id { get; set; }
        public DateTime Confirm1_date { get; set; }
        public int Confirm2_id { get; set; }
        public DateTime Confirm2_date { get; set; }
        public int Confirm3_id { get; set; }
        public DateTime Confirm3_date { get; set; }
        public int Sales_id { get; set; }
        public DateTime Sales_confirm_date { get; set; }
        public int Guest_id { get; set; }
        public DateTime Guest_confirm_date { get; set; }
        public int Confirm_status { get; set; }

        public decimal Temp1 { get; set; }
        public decimal Temp2 { get; set; }
        public decimal Temp3 { get; set; }
        public DateTime Temp_time1 { get; set; }
        public DateTime Temp_time2 { get; set; }
        public DateTime Temp_time3 { get; set; }
        public decimal Alcohol1 { get; set; }
        public decimal Alcohol2 { get; set; }
        public decimal Alcohol3 { get; set; }
        public int Alcohol_check1 {  get; set; }
        public int Alcohol_check2 { get; set; }
        public int Alcohol_check3 { get; set; }

        public string Comment { get; set; }
        public int Passenger_id {  get; set; }

        public int Inspection_check1 { get; set; }
        public int Inspection_check2 { get; set; }
        public int Inspection_check3 { get; set; }
        public int Inspection_check4 { get; set; }
        public int Inspection_check5 { get; set; }
        public int Inspection_check6 { get; set; }
        public int Inspection_check7 { get; set; }

        public int Per_inspection_check1 { get; set; }
        public int Per_inspection_check2 { get; set; }
        public int Per_inspection_check3 { get; set; }
        public int Per_inspection_check4 { get; set; }
        public int Per_inspection_check5 { get; set; }
        public int Per_inspection_check6 { get; set; }
        public int Per_inspection_check7 { get; set; }
        public int Per_inspection_check8 { get; set; }
        public int Per_inspection_check9 { get; set; }
        public int Per_inspection_check10 { get; set; }
        public int Per_inspection_check11 { get; set; }
        public int Per_inspection_check12 { get; set; }
        public int Per_inspection_check13 { get; set; }
        public int Per_inspection_check14 { get; set; }

        public int Large_inspection_check1 { get; set; }
        public int Large_inspection_check2 { get; set; }
        public int Large_inspection_check3 { get; set; }
        public int Large_inspection_check4 { get; set; }

        private readonly StringBuilder sb = new();
        private readonly StringBuilder sql_sb = new();
        private readonly StringBuilder mysql_sb = new();

        public void Dispose()
        {
            // this.Dispose();
        }

        /// <summary>
        /// 日報データインポート
        /// </summary>
        /// <returns>インポート件数</returns>
        public int ImportData(ref ProgressBar p_pgb)
        {
            int importCnt = 0;
            
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    using (ClsMySqlDb clsMySqlDb = new(ClsDbConfig.MySQLNo))
                    {
                        // インポートデータ取得SQL
                        mysql_sb.Clear();
                        mysql_sb.AppendLine("SELECT");
                        // ===============================================
                        // Trn_日報
                        // ===============================================
                        mysql_sb.AppendLine(" id");
                        mysql_sb.AppendLine(",location_id");  
                        mysql_sb.AppendLine(",car_id");
                        mysql_sb.AppendLine(",day");
                        mysql_sb.AppendLine(",instructor_id");
                        mysql_sb.AppendLine(",staff_id1");
                        // 2026/01/13 DEL (S)
                        // mysql_sb.AppendLine(",staff_id2");
                        // mysql_sb.AppendLine(",staff_id3");
                        // 2026/01/13 DEL (E)
                        mysql_sb.AppendLine(",after_meter");
                        mysql_sb.AppendLine(",before_meter");
                        mysql_sb.AppendLine(",mileage");
                        mysql_sb.AppendLine(",fuel");
                        mysql_sb.AppendLine(",fuel_meter");
                        mysql_sb.AppendLine(",oil");
                        mysql_sb.AppendLine(",kerosene");
                        // 2026/01/13 DEL (S)
                        // mysql_sb.AppendLine(",start_location");
                        // mysql_sb.AppendLine(",end_location");
                        // 2026/01/13 DEL (E)
                        //2026/01/30 ADD (S)
                        mysql_sb.AppendLine(",work_start_time");
                        mysql_sb.AppendLine(",work_finish_time");
                        //2026/01/30 ADD (E)
                        mysql_sb.AppendLine(",start_time1");
                        mysql_sb.AppendLine(",start_time2");
                        mysql_sb.AppendLine(",start_time3");
                        mysql_sb.AppendLine(",end_time1");
                        mysql_sb.AppendLine(",end_time2");
                        mysql_sb.AppendLine(",end_time3");
                        mysql_sb.AppendLine(",over_time1");
                        mysql_sb.AppendLine(",over_time2");
                        mysql_sb.AppendLine(",over_time3");
                        mysql_sb.AppendLine(",start_over_time1");
                        mysql_sb.AppendLine(",start_over_time2");
                        mysql_sb.AppendLine(",start_over_time3");
                        mysql_sb.AppendLine(",end_over_time1");
                        mysql_sb.AppendLine(",end_over_time2");
                        mysql_sb.AppendLine(",end_over_time3");
                        mysql_sb.AppendLine(",start_over_time_kbn1");
                        mysql_sb.AppendLine(",start_over_time_kbn2");
                        mysql_sb.AppendLine(",start_over_time_kbn3");
                        mysql_sb.AppendLine(",end_over_time_kbn1");
                        mysql_sb.AppendLine(",end_over_time_kbn2");
                        mysql_sb.AppendLine(",end_over_time_kbn3");
                        mysql_sb.AppendLine(",start_over_time_comment1");
                        mysql_sb.AppendLine(",start_over_time_comment2");
                        mysql_sb.AppendLine(",start_over_time_comment3");
                        mysql_sb.AppendLine(",end_over_time_comment1");
                        mysql_sb.AppendLine(",end_over_time_comment2");
                        mysql_sb.AppendLine(",end_over_time_comment3");
                        mysql_sb.AppendLine(",subcar_flag");
                        mysql_sb.AppendLine(",confirm1_id");
                        mysql_sb.AppendLine(",confirm1_date");
                        mysql_sb.AppendLine(",confirm2_id");
                        mysql_sb.AppendLine(",confirm2_date");
                        mysql_sb.AppendLine(",confirm3_id");
                        mysql_sb.AppendLine(",confirm3_date");
                        mysql_sb.AppendLine(",sales_id");
                        mysql_sb.AppendLine(",sales_confirm_date");
                        mysql_sb.AppendLine(",guest_id");
                        mysql_sb.AppendLine(",guest_confirm_date");
                        mysql_sb.AppendLine(",confirm_status");

                        // ===============================================
                        // 検温・アルコールチェック
                        // ===============================================
                        mysql_sb.AppendLine(",temp1");
                        mysql_sb.AppendLine(",temp2");
                        mysql_sb.AppendLine(",temp3");
                        mysql_sb.AppendLine(",temp_time1");
                        mysql_sb.AppendLine(",temp_time2");
                        mysql_sb.AppendLine(",temp_time3");
                        mysql_sb.AppendLine(",alcohol1");
                        mysql_sb.AppendLine(",alcohol2");
                        mysql_sb.AppendLine(",alcohol3");
                        mysql_sb.AppendLine(",alcohol_check1");
                        mysql_sb.AppendLine(",alcohol_check2");
                        mysql_sb.AppendLine(",alcohol_check3");

                        // ===============================================
                        // 備考
                        // ===============================================
                        mysql_sb.AppendLine(",comment");
                        mysql_sb.AppendLine(",passenger_id");            // 2025/02/18 ADD

                        // ===============================================
                        // 運行前点検
                        // ===============================================
                        mysql_sb.AppendLine(",inspection_check1");
                        mysql_sb.AppendLine(",inspection_check2");
                        mysql_sb.AppendLine(",inspection_check3");
                        mysql_sb.AppendLine(",inspection_check4");
                        mysql_sb.AppendLine(",inspection_check5");
                        mysql_sb.AppendLine(",inspection_check6");
                        mysql_sb.AppendLine(",inspection_check7");

                        // ===============================================
                        // 定期点検
                        // ===============================================
                        mysql_sb.AppendLine(",per_inspection_check1");
                        mysql_sb.AppendLine(",per_inspection_check2");
                        mysql_sb.AppendLine(",per_inspection_check3");
                        mysql_sb.AppendLine(",per_inspection_check4");
                        mysql_sb.AppendLine(",per_inspection_check5");
                        mysql_sb.AppendLine(",per_inspection_check6");
                        mysql_sb.AppendLine(",per_inspection_check7");
                        mysql_sb.AppendLine(",per_inspection_check8");
                        mysql_sb.AppendLine(",per_inspection_check9");
                        mysql_sb.AppendLine(",per_inspection_check10");
                        mysql_sb.AppendLine(",per_inspection_check11");
                        mysql_sb.AppendLine(",per_inspection_check12");
                        mysql_sb.AppendLine(",per_inspection_check13");
                        mysql_sb.AppendLine(",per_inspection_check14");

                        // ===============================================
                        // その他点検
                        // ===============================================
                        //mysql_sb.AppendLine(",wid_inspection_check1");
                        //mysql_sb.AppendLine(",wid_inspection_check2");
                        //mysql_sb.AppendLine(",wid_inspection_check3");
                        //mysql_sb.AppendLine(",wid_inspection_check4");

                        // ===============================================
                        // 大型
                        // ===============================================
                        mysql_sb.AppendLine(",large_inspection_check1");
                        mysql_sb.AppendLine(",large_inspection_check2");
                        mysql_sb.AppendLine(",large_inspection_check3");
                        mysql_sb.AppendLine(",large_inspection_check4");

                        // ===============================================
                        // 休憩時間
                        // ===============================================
                        mysql_sb.AppendLine(",start_break_time1");
                        mysql_sb.AppendLine(",start_break_time2");
                        mysql_sb.AppendLine(",start_break_time3");
                        mysql_sb.AppendLine(",end_break_time1");
                        mysql_sb.AppendLine(",end_break_time2");
                        mysql_sb.AppendLine(",end_break_time3");
                        mysql_sb.AppendLine(",break_time1");
                        mysql_sb.AppendLine(",break_time2");
                        mysql_sb.AppendLine(",break_time3");

                        // ===============================================
                        // 更新情報
                        // ===============================================
                        mysql_sb.AppendLine(",ins_user_id");
                        mysql_sb.AppendLine(",ins_date");
                        mysql_sb.AppendLine(",upd_user_id");
                        mysql_sb.AppendLine(",upd_date");
                        mysql_sb.AppendLine(",delete_flag");

                        mysql_sb.AppendLine("FROM");
                        mysql_sb.AppendLine("Trn_日報");
                        mysql_sb.AppendLine("WHERE");
                        mysql_sb.AppendLine("day >= '" + this.Key_from_day.ToString("yyyy/MM/dd") + "'");
                        mysql_sb.AppendLine("AND");
                        mysql_sb.AppendLine("day <= '" + this.Key_to_day.ToString("yyyy/MM/dd") + "'");
                        if (this.Key_location_id != 0)
                        {
                            // 専従先の指定有り
                            mysql_sb.AppendLine("AND");
                            mysql_sb.AppendLine("location_id = " + this.Key_location_id.ToString());
                        }
                        if (this.Key_car_id != 0)
                        {
                            // 車両の指定有り
                            mysql_sb.AppendLine("AND");
                            mysql_sb.AppendLine("car_id = " +　this.Key_car_id.ToString() + ";");
                        }

                        using (DataTable dt_val = clsMySqlDb.DMLSelect(mysql_sb.ToString()))
                        {
                            // 件数0の場合はメッセージ出力、処理終了
                            var rec_cnt = dt_val.Rows.Count;
                            if (rec_cnt <= 0)
                            {
                                MessageBox.Show("条件を満たす日報データがありません。", "結果", MessageBoxButtons.OK);
                                return 0;
                            }

                            // ProgressBar設定
                            p_pgb.Visible = true;
                            p_pgb.Maximum = rec_cnt;


                            // MySQL日報データ読み込み
                            DataTable dt_val2;
                            foreach (DataRow dr in dt_val.Rows)
                            {
                                // SQL Server登録チェック（未登録時はINSERT）
                                sql_sb.Clear();
                                sql_sb.AppendLine("SELECT");
                                sql_sb.AppendLine("id");
                                sql_sb.AppendLine("FROM");
                                sql_sb.AppendLine("Trn_日報");
                                sql_sb.AppendLine("WHERE");
                                sql_sb.AppendLine("id = " + dr["id"].ToString());

                                dt_val2 = clsSqlDb.DMLSelect(sql_sb.ToString());

                                // 該当レコード判定
                                if (dt_val2.Rows.Count > 0)
                                {
                                    // 該当レコード有り（UPDATE）
                                    // ===============================================
                                    // Trn_日報
                                    // ===============================================
                                    sql_sb.Clear();
                                    sql_sb.AppendLine("UPDATE");
                                    sql_sb.AppendLine("Trn_日報");
                                    sql_sb.AppendLine("SET");
                                    // 車両ID
                                    if (dr.IsNull("car_id") != true) { sql_sb.AppendLine(" car_id = " + dr["car_id"].ToString()); } else { sql_sb.AppendLine(" car_id = null"); }
                                    // 日付
                                    if (dr.IsNull("day") != true) { sql_sb.AppendLine(",day = '" + dr["day"].ToString() + "'"); } else { sql_sb.AppendLine(",day = null"); }
                                    // 管理責任者ID
                                    if (dr.IsNull("instructor_id") != true) { sql_sb.AppendLine(",instructor_id = " + dr["instructor_id"].ToString()); } else { sql_sb.AppendLine(",instructor_id = null"); }
                                    // 車両管理者1
                                    if (dr.IsNull("staff_id1") != true) { sql_sb.AppendLine(",staff_id1 = " + dr["staff_id1"].ToString()); } else { sql_sb.AppendLine(",staff_id1 = null"); }
                                    // 2026/01/13 DEL (S)
                                    // 車両管理者2
                                    // if (dr.IsNull("staff_id2") != true) { sql_sb.AppendLine(",staff_id2 = " + dr["staff_id2"].ToString()); } else { sql_sb.AppendLine(",staff_id2 = null"); }
                                    // 車両管理者3
                                    // if (dr.IsNull("staff_id3") != true) { sql_sb.AppendLine(",staff_id3 = " + dr["staff_id3"].ToString()); } else { sql_sb.AppendLine(",staff_id3 = null"); }
                                    // 2026/01/13 DEL (E)
                                    // 入庫時メーター
                                    if (dr.IsNull("after_meter") != true) { sql_sb.AppendLine(",after_meter = " + dr["after_meter"].ToString()); } else { sql_sb.AppendLine(",after_meter = null"); }
                                    // 出庫時メーター
                                    if (dr.IsNull("before_meter") != true) { sql_sb.AppendLine(",before_meter = " + dr["before_meter"].ToString()); } else { sql_sb.AppendLine(",before_meter = null"); }
                                    // 走行距離
                                    if (dr.IsNull("mileage") != true) { sql_sb.AppendLine(",mileage = " + dr["mileage"].ToString()); } else { sql_sb.AppendLine(",mileage = null"); }
                                    // 給油
                                    if (dr.IsNull("fuel") != true) { sql_sb.AppendLine(",fuel = " + dr["fuel"].ToString()); } else { sql_sb.AppendLine(",fuel = null"); }
                                    // 給油時メーター値
                                    if (dr.IsNull("fuel_meter") != true) { sql_sb.AppendLine(",fuel_meter = " + dr["fuel_meter"].ToString()); } else { sql_sb.AppendLine(",fuel_meter = null"); }
                                    // オイル
                                    if (dr.IsNull("oil") != true) { sql_sb.AppendLine(",oil = " + dr["oil"].ToString()); } else { sql_sb.AppendLine(",oil = null"); }
                                    // 灯油
                                    if (dr.IsNull("kerosene") != true) { sql_sb.AppendLine(",kerosene = " + dr["kerosene"].ToString()); } else { sql_sb.AppendLine(",kerosene = null"); }
                                    // 2026/01/13 DEL (S)
                                    // 始業場所
                                    // if (dr.IsNull("start_location") != true) { sql_sb.AppendLine(",start_location = '" + dr["start_location"].ToString() + "'"); } else { sql_sb.AppendLine(",start_location = ''"); }
                                    // 終業場所
                                    // if (dr.IsNull("end_location") != true) { sql_sb.AppendLine(",end_location = '" + dr["end_location"].ToString() + "'"); } else { sql_sb.AppendLine(",end_location = ''"); }
                                    // 2026/01/13 DEL (E)
                                    // 2026/01/30 ADD (S)
                                    if (dr.IsNull("work_start_time") != true) { sql_sb.AppendLine(",work_start_time = '" + dr["work_start_time"].ToString() + "'"); } else { sql_sb.AppendLine(",work_start_time = null"); }
                                    if (dr.IsNull("work_finish_time") != true) { sql_sb.AppendLine(",work_finish_time = '" + dr["work_finish_time"].ToString() + "'"); } else { sql_sb.AppendLine(",work_finish_time = null"); }
                                    // 2026/01/30 ADD (E)
                                    // 始業時間1～3
                                    if (dr.IsNull("start_time1") != true) { sql_sb.AppendLine(",start_time1 = '" + dr["start_time1"].ToString() + "'"); } else { sql_sb.AppendLine(",start_time1 = null"); }
                                    if (dr.IsNull("start_time2") != true) { sql_sb.AppendLine(",start_time2 = '" + dr["start_time2"].ToString() + "'"); } else { sql_sb.AppendLine(",start_time2 = null"); }
                                    if (dr.IsNull("start_time3") != true) { sql_sb.AppendLine(",start_time3 = '" + dr["start_time3"].ToString() + "'"); } else { sql_sb.AppendLine(",start_time3 = null"); }
                                    // 終業時間1～3
                                    if (dr.IsNull("end_time1") != true) { sql_sb.AppendLine(",end_time1 = '" + dr["end_time1"].ToString() + "'"); } else { sql_sb.AppendLine(",end_time1 = null"); }
                                    if (dr.IsNull("end_time2") != true) { sql_sb.AppendLine(",end_time2 = '" + dr["end_time2"].ToString() + "'"); } else { sql_sb.AppendLine(",end_time2 = null"); }
                                    if (dr.IsNull("end_time3") != true) { sql_sb.AppendLine(",end_time3 = '" + dr["end_time3"].ToString() + "'"); } else { sql_sb.AppendLine(",end_time3 = null"); }
                                    // 残業時間1～3
                                    if (dr.IsNull("over_time1") != true) { sql_sb.AppendLine(",over_time1 = " + dr["over_time1"].ToString()); } else { sql_sb.AppendLine(",over_time1 = null"); }
                                    if (dr.IsNull("over_time2") != true) { sql_sb.AppendLine(",over_time2 = " + dr["over_time2"].ToString()); } else { sql_sb.AppendLine(",over_time2 = null"); }
                                    if (dr.IsNull("over_time3") != true) { sql_sb.AppendLine(",over_time3 = " + dr["over_time3"].ToString()); } else { sql_sb.AppendLine(",over_time3 = null"); }
                                    // 始業残業時間1～3
                                    if (dr.IsNull("start_over_time1") != true) { sql_sb.AppendLine(",start_over_time1 = " + dr["start_over_time1"].ToString()); } else { sql_sb.AppendLine(",start_over_time1 = null"); }
                                    if (dr.IsNull("start_over_time2") != true) { sql_sb.AppendLine(",start_over_time2 = " + dr["start_over_time2"].ToString()); } else { sql_sb.AppendLine(",start_over_time2 = null"); }
                                    if (dr.IsNull("start_over_time3") != true) { sql_sb.AppendLine(",start_over_time3 = " + dr["start_over_time3"].ToString()); } else { sql_sb.AppendLine(",start_over_time3 = null"); }
                                    // 終業残業時間1～3
                                    if (dr.IsNull("end_over_time1") != true) { sql_sb.AppendLine(",end_over_time1 = " + dr["end_over_time1"].ToString()); } else { sql_sb.AppendLine(",end_over_time1 = null"); }
                                    if (dr.IsNull("end_over_time2") != true) { sql_sb.AppendLine(",end_over_time2 = " + dr["end_over_time2"].ToString()); } else { sql_sb.AppendLine(",end_over_time2 = null"); }
                                    if (dr.IsNull("end_over_time3") != true) { sql_sb.AppendLine(",end_over_time3 = " + dr["end_over_time3"].ToString()); } else { sql_sb.AppendLine(",end_over_time3 = null"); }
                                    // 始業残業理由区分1～3
                                    if (dr.IsNull("start_over_time_kbn1") != true) { sql_sb.AppendLine(",start_over_time_kbn1 = " + dr["start_over_time_kbn1"].ToString()); } else { sql_sb.AppendLine(",start_over_time_kbn1 = null"); }
                                    if (dr.IsNull("start_over_time_kbn2") != true) { sql_sb.AppendLine(",start_over_time_kbn2 = " + dr["start_over_time_kbn2"].ToString()); } else { sql_sb.AppendLine(",start_over_time_kbn2 = null"); }
                                    if (dr.IsNull("start_over_time_kbn3") != true) { sql_sb.AppendLine(",start_over_time_kbn3 = " + dr["start_over_time_kbn3"].ToString()); } else { sql_sb.AppendLine(",start_over_time_kbn3 = null"); }
                                    // 終業残業理由区分1～3
                                    if (dr.IsNull("end_over_time_kbn1") != true) { sql_sb.AppendLine(",end_over_time_kbn1 = " + dr["end_over_time_kbn1"].ToString()); } else { sql_sb.AppendLine(",end_over_time_kbn1 = null"); }
                                    if (dr.IsNull("end_over_time_kbn2") != true) { sql_sb.AppendLine(",end_over_time_kbn2 = " + dr["end_over_time_kbn2"].ToString()); } else { sql_sb.AppendLine(",end_over_time_kbn2 = null"); }
                                    if (dr.IsNull("end_over_time_kbn3") != true) { sql_sb.AppendLine(",end_over_time_kbn3 = " + dr["end_over_time_kbn3"].ToString()); } else { sql_sb.AppendLine(",end_over_time_kbn3 = null"); }
                                    // 始業残業理由1～3
                                    if (dr.IsNull("start_over_time_comment1") != true) { sql_sb.AppendLine(",start_over_time_comment1 = '" + dr["start_over_time_comment1"].ToString() + "'"); } else { sql_sb.AppendLine(",start_over_time_comment1 = ''"); }
                                    if (dr.IsNull("start_over_time_comment2") != true) { sql_sb.AppendLine(",start_over_time_comment2 = '" + dr["start_over_time_comment2"].ToString() + "'"); } else { sql_sb.AppendLine(",start_over_time_comment2 = ''"); }
                                    if (dr.IsNull("start_over_time_comment3") != true) { sql_sb.AppendLine(",start_over_time_comment3 = '" + dr["start_over_time_comment3"].ToString() + "'"); } else { sql_sb.AppendLine(",start_over_time_comment3 = ''"); }
                                    // 終業残業理由1～3
                                    if (dr.IsNull("end_over_time_comment1") != true) { sql_sb.AppendLine(",end_over_time_comment1 = '" + dr["end_over_time_comment1"].ToString() + "'"); } else { sql_sb.AppendLine(",end_over_time_comment1 = ''"); }
                                    if (dr.IsNull("end_over_time_comment2") != true) { sql_sb.AppendLine(",end_over_time_comment2 = '" + dr["end_over_time_comment2"].ToString() + "'"); } else { sql_sb.AppendLine(",end_over_time_comment2 = ''"); }
                                    if (dr.IsNull("end_over_time_comment3") != true) { sql_sb.AppendLine(",end_over_time_comment3 = '" + dr["end_over_time_comment3"].ToString() + "'"); } else { sql_sb.AppendLine(",end_over_time_comment3 = ''"); }
                                    // 代車フラグ
                                    if (dr.IsNull("subcar_flag") != true) { sql_sb.AppendLine(",subcar_flag = " + dr["subcar_flag"].ToString()); } else { sql_sb.AppendLine(",subcar_flag = 0"); }

                                    // 2026/01/22 インポート時は承認フラグは更新しない↓
                                    // 確認1
                                    // if (dr.IsNull("confirm1_id") != true) { sql_sb.AppendLine(",confirm1_id = " + dr["confirm1_id"].ToString()); } else { sql_sb.AppendLine(",confirm1_id = 0"); }
                                    // 日付1
                                    // if (dr.IsNull("confirm1_date") != true) { sql_sb.AppendLine(",confirm1_date = '" + dr["confirm1_date"].ToString() + "'"); } else { sql_sb.AppendLine(",confirm1_date = null"); }

                                    // 確認2
                                    // if (dr.IsNull("confirm2_id") != true) { sql_sb.AppendLine(",confirm2_id = " + dr["confirm2_id"].ToString()); } else { sql_sb.AppendLine(",confirm2_id = 0"); }
                                    // 日付2
                                    // if (dr.IsNull("confirm2_date") != true) { sql_sb.AppendLine(",confirm2_date = '" + dr["confirm2_date"].ToString() + "'"); } else { sql_sb.AppendLine(",confirm2_date = null"); }

                                    // 確認3
                                    // if (dr.IsNull("confirm3_id") != true) { sql_sb.AppendLine(",confirm3_id = " + dr["confirm3_id"].ToString()); } else { sql_sb.AppendLine(",confirm3_id = 0"); }
                                    // 日付3
                                    // if (dr.IsNull("confirm3_date") != true) { sql_sb.AppendLine(",confirm3_date = '" + dr["confirm3_date"].ToString() + "'"); } else { sql_sb.AppendLine(",confirm3_date = null"); }

                                    // 営業承認
                                    // if (dr.IsNull("sales_id") != true) { sql_sb.AppendLine(",sales_id = " + dr["sales_id"].ToString()); } else { sql_sb.AppendLine(",sales_id = 0"); }
                                    // 営業承認日付
                                    // if (dr.IsNull("sales_confirm_date") != true) { sql_sb.AppendLine(",sales_confirm_date = '" + dr["sales_confirm_date"].ToString() + "'"); } else { sql_sb.AppendLine(",sales_confirm_date = null"); }

                                    // 顧客承認
                                     if (dr.IsNull("guest_id") != true) { sql_sb.AppendLine(",guest_id = " + dr["guest_id"].ToString()); } else { sql_sb.AppendLine(",guest_id = 0"); }
                                    // 顧客承認日付
                                     if (dr.IsNull("guest_confirm_date") != true) { sql_sb.AppendLine(",guest_confirm_date = '" + dr["guest_confirm_date"].ToString() + "'"); } else { sql_sb.AppendLine(",guest_confirm_date = null"); }

                                    // 承認ステータス
                                    // if (dr.IsNull("confirm_status") != true) { sql_sb.AppendLine(",confirm_status = " + dr["confirm_status"].ToString()); } else { sql_sb.AppendLine(",confirm_status = null"); }
                                    // 2026/01/22 インポート時は承認フラグは更新しない↑

                                    // 検温1回目～3回目
                                    if (dr.IsNull("temp1") != true) { sql_sb.AppendLine(",temp1 = " + dr["temp1"].ToString()); } else { sql_sb.AppendLine(",temp1 = null"); }
                                    if (dr.IsNull("temp2") != true) { sql_sb.AppendLine(",temp2 = " + dr["temp2"].ToString()); } else { sql_sb.AppendLine(",temp2 = null"); }
                                    if (dr.IsNull("temp3") != true) { sql_sb.AppendLine(",temp3 = " + dr["temp3"].ToString()); } else { sql_sb.AppendLine(",temp3 = null"); }
                                    // 検温時刻1回目～3回目
                                    if (dr.IsNull("temp_time1") != true) { sql_sb.AppendLine(",temp_time1 = '" + dr["temp_time1"].ToString() + "'"); } else { sql_sb.AppendLine(",temp_time1 = null"); }
                                    if (dr.IsNull("temp_time2") != true) { sql_sb.AppendLine(",temp_time2 = '" + dr["temp_time2"].ToString() + "'"); } else { sql_sb.AppendLine(",temp_time2 = null"); }
                                    if (dr.IsNull("temp_time3") != true) { sql_sb.AppendLine(",temp_time3 = '" + dr["temp_time3"].ToString() + "'"); } else { sql_sb.AppendLine(",temp_time3 = null"); }
                                    // アルコール濃度1回目～3回目
                                    if (dr.IsNull("alcohol1") != true) { sql_sb.AppendLine(",alcohol1 = " + dr["alcohol1"].ToString()); } else { sql_sb.AppendLine(",alcohol1 = null"); }
                                    if (dr.IsNull("alcohol2") != true) { sql_sb.AppendLine(",alcohol2 = " + dr["alcohol2"].ToString()); } else { sql_sb.AppendLine(",alcohol2 = null"); }
                                    if (dr.IsNull("alcohol3") != true) { sql_sb.AppendLine(",alcohol3 = " + dr["alcohol3"].ToString()); } else { sql_sb.AppendLine(",alcohol3 = null"); }
                                    // アルコールチェック結果1回目～3回目
                                    if (dr.IsNull("alcohol_check1") != true) { sql_sb.AppendLine(",alcohol_check1 = " + dr["alcohol_check1"].ToString()); } else { sql_sb.AppendLine(",alcohol_check1 = null"); }
                                    if (dr.IsNull("alcohol_check2") != true) { sql_sb.AppendLine(",alcohol_check2 = " + dr["alcohol_check2"].ToString()); } else { sql_sb.AppendLine(",alcohol_check2 = null"); }
                                    if (dr.IsNull("alcohol_check3") != true) { sql_sb.AppendLine(",alcohol_check3 = " + dr["alcohol_check3"].ToString()); } else { sql_sb.AppendLine(",alcohol_check3 = null"); }
                                    // 備考
                                    if (dr.IsNull("comment") != true) { sql_sb.AppendLine(",comment = '" + dr["comment"].ToString() + "'"); } else { sql_sb.AppendLine(",comment = ''"); }
                                    // 同乗者有無
                                    if (dr.IsNull("passenger_id") != true) { sql_sb.AppendLine(",passenger_id = " + dr["passenger_id"].ToString()); } else { sql_sb.AppendLine(",passenger_id = null"); }
                                    // [運行前点検]
                                    // 項目1～7
                                    if (dr.IsNull("inspection_check1") != true) { sql_sb.AppendLine(",inspection_check1 = " + dr["inspection_check1"].ToString()); } else { sql_sb.AppendLine(",inspection_check1 = null"); }
                                    if (dr.IsNull("inspection_check2") != true) { sql_sb.AppendLine(",inspection_check2 = " + dr["inspection_check2"].ToString()); } else { sql_sb.AppendLine(",inspection_check2 = null"); }
                                    if (dr.IsNull("inspection_check3") != true) { sql_sb.AppendLine(",inspection_check3 = " + dr["inspection_check3"].ToString()); } else { sql_sb.AppendLine(",inspection_check3 = null"); }
                                    if (dr.IsNull("inspection_check4") != true) { sql_sb.AppendLine(",inspection_check4 = " + dr["inspection_check4"].ToString()); } else { sql_sb.AppendLine(",inspection_check4 = null"); }
                                    if (dr.IsNull("inspection_check5") != true) { sql_sb.AppendLine(",inspection_check5 = " + dr["inspection_check5"].ToString()); } else { sql_sb.AppendLine(",inspection_check5 = null"); }
                                    if (dr.IsNull("inspection_check6") != true) { sql_sb.AppendLine(",inspection_check6 = " + dr["inspection_check6"].ToString()); } else { sql_sb.AppendLine(",inspection_check6 = null"); }
                                    if (dr.IsNull("inspection_check7") != true) { sql_sb.AppendLine(",inspection_check7 = " + dr["inspection_check7"].ToString()); } else { sql_sb.AppendLine(",inspection_check7 = null"); }
                                    // [定期点検]
                                    // 項目1～14
                                    if (dr.IsNull("per_inspection_check1") != true) { sql_sb.AppendLine(",per_inspection_check1 = " + dr["per_inspection_check1"].ToString()); } else { sql_sb.AppendLine(",per_inspection_check1 = null"); }
                                    if (dr.IsNull("per_inspection_check2") != true) { sql_sb.AppendLine(",per_inspection_check2 = " + dr["per_inspection_check2"].ToString()); } else { sql_sb.AppendLine(",per_inspection_check2 = null"); }
                                    if (dr.IsNull("per_inspection_check3") != true) { sql_sb.AppendLine(",per_inspection_check3 = " + dr["per_inspection_check3"].ToString()); } else { sql_sb.AppendLine(",per_inspection_check3 = null"); }
                                    if (dr.IsNull("per_inspection_check4") != true) { sql_sb.AppendLine(",per_inspection_check4 = " + dr["per_inspection_check4"].ToString()); } else { sql_sb.AppendLine(",per_inspection_check4 = null"); }
                                    if (dr.IsNull("per_inspection_check5") != true) { sql_sb.AppendLine(",per_inspection_check5 = " + dr["per_inspection_check5"].ToString()); } else { sql_sb.AppendLine(",per_inspection_check5 = null"); }
                                    if (dr.IsNull("per_inspection_check6") != true) { sql_sb.AppendLine(",per_inspection_check6 = " + dr["per_inspection_check6"].ToString()); } else { sql_sb.AppendLine(",per_inspection_check6 = null"); }
                                    if (dr.IsNull("per_inspection_check7") != true) { sql_sb.AppendLine(",per_inspection_check7 = " + dr["per_inspection_check7"].ToString()); } else { sql_sb.AppendLine(",per_inspection_check7 = null"); }
                                    if (dr.IsNull("per_inspection_check8") != true) { sql_sb.AppendLine(",per_inspection_check8 = " + dr["per_inspection_check8"].ToString()); } else { sql_sb.AppendLine(",per_inspection_check8 = null"); }
                                    if (dr.IsNull("per_inspection_check9") != true) { sql_sb.AppendLine(",per_inspection_check9 = " + dr["per_inspection_check9"].ToString()); } else { sql_sb.AppendLine(",per_inspection_check9 = null"); }
                                    if (dr.IsNull("per_inspection_check10") != true) { sql_sb.AppendLine(",per_inspection_check10 = " + dr["per_inspection_check10"].ToString()); } else { sql_sb.AppendLine(",per_inspection_check10 = null"); }
                                    if (dr.IsNull("per_inspection_check11") != true) { sql_sb.AppendLine(",per_inspection_check11 = " + dr["per_inspection_check11"].ToString()); } else { sql_sb.AppendLine(",per_inspection_check11 = null"); }
                                    if (dr.IsNull("per_inspection_check12") != true) { sql_sb.AppendLine(",per_inspection_check12 = " + dr["per_inspection_check12"].ToString()); } else { sql_sb.AppendLine(",per_inspection_check12 = null"); }
                                    if (dr.IsNull("per_inspection_check13") != true) { sql_sb.AppendLine(",per_inspection_check13 = " + dr["per_inspection_check13"].ToString()); } else { sql_sb.AppendLine(",per_inspection_check13 = null"); }
                                    if (dr.IsNull("per_inspection_check14") != true) { sql_sb.AppendLine(",per_inspection_check14 = " + dr["per_inspection_check14"].ToString()); } else { sql_sb.AppendLine(",per_inspection_check14 = null"); }
                                    // [大型点検]
                                    // 項目1～4
                                    if (dr.IsNull("large_inspection_check1") != true) { sql_sb.AppendLine(",large_inspection_check1 = " + dr["large_inspection_check1"].ToString()); } else { sql_sb.AppendLine(",large_inspection_check1 = null"); }
                                    if (dr.IsNull("large_inspection_check2") != true) { sql_sb.AppendLine(",large_inspection_check2 = " + dr["large_inspection_check2"].ToString()); } else { sql_sb.AppendLine(",large_inspection_check2 = null"); }
                                    if (dr.IsNull("large_inspection_check3") != true) { sql_sb.AppendLine(",large_inspection_check3 = " + dr["large_inspection_check3"].ToString()); } else { sql_sb.AppendLine(",large_inspection_check3 = null"); }
                                    if (dr.IsNull("large_inspection_check4") != true) { sql_sb.AppendLine(",large_inspection_check4 = " + dr["large_inspection_check4"].ToString()); } else { sql_sb.AppendLine(",large_inspection_check4 = null"); }

                                    // 休憩開始時間1～3
                                    if (dr.IsNull("start_break_time1") != true) { sql_sb.AppendLine(",start_break_time1 = '" + dr["start_break_time1"].ToString() + "'"); } else { sql_sb.AppendLine(",start_break_time1 = null"); }
                                    if (dr.IsNull("start_break_time2") != true) { sql_sb.AppendLine(",start_break_time2 = '" + dr["start_break_time2"].ToString() + "'"); } else { sql_sb.AppendLine(",start_break_time2 = null"); }
                                    if (dr.IsNull("start_break_time3") != true) { sql_sb.AppendLine(",start_break_time3 = '" + dr["start_break_time3"].ToString() + "'"); } else { sql_sb.AppendLine(",start_break_time3 = null"); }
                                    // 休憩終了時間1～3
                                    if (dr.IsNull("end_break_time1") != true) { sql_sb.AppendLine(",end_break_time1 = '" + dr["end_break_time1"].ToString() + "'"); } else { sql_sb.AppendLine(",end_break_time1 = null"); }
                                    if (dr.IsNull("end_break_time2") != true) { sql_sb.AppendLine(",end_break_time2 = '" + dr["end_break_time2"].ToString() + "'"); } else { sql_sb.AppendLine(",end_break_time2 = null"); }
                                    if (dr.IsNull("end_break_time3") != true) { sql_sb.AppendLine(",end_break_time3 = '" + dr["end_break_time3"].ToString() + "'"); } else { sql_sb.AppendLine(",end_break_time3 = null"); }
                                    // 休憩時間1～3
                                    if (dr.IsNull("break_time1") != true) { sql_sb.AppendLine(",break_time1 = " + dr["break_time1"].ToString()); } else { sql_sb.AppendLine(",break_time1 = null"); }
                                    if (dr.IsNull("break_time2") != true) { sql_sb.AppendLine(",break_time2 = " + dr["break_time2"].ToString()); } else { sql_sb.AppendLine(",break_time2 = null"); }
                                    if (dr.IsNull("break_time3") != true) { sql_sb.AppendLine(",break_time3 = " + dr["break_time3"].ToString()); } else { sql_sb.AppendLine(",break_time3 = null"); }

                                    // 2025/11/11↓
                                    if (dr.IsNull("ins_user_id") != true) { sql_sb.AppendLine(",ins_user_id = " + dr["ins_user_id"].ToString()); }
                                    else { sql_sb.AppendLine(",ins_user_id = 0"); }
                                    if (dr.IsNull("ins_date") != true) { sql_sb.AppendLine(",ins_date = '" + dr["ins_date"].ToString() + "'"); }
                                    else { sql_sb.AppendLine(",ins_date = null"); }
                                    if (dr.IsNull("upd_user_id") != true) { sql_sb.AppendLine(",upd_user_id = " + dr["upd_user_id"].ToString()); }
                                    else { sql_sb.AppendLine(",upd_user_id = 0"); }
                                    if (dr.IsNull("upd_date") != true) { sql_sb.AppendLine(",upd_date = '" + dr["upd_date"].ToString() + "'"); }
                                    else { sql_sb.AppendLine(",upd_date = null"); }
                                    if (dr.IsNull("delete_flag") != true) { sql_sb.AppendLine(",delete_flag = " + dr["delete_flag"].ToString()); }
                                    else { sql_sb.AppendLine(",delete_flag = " + ClsPublic.FLAG_OFF); }
                                    // 2025/11/11↑

                                    sql_sb.AppendLine("WHERE");
                                    sql_sb.AppendLine("id = " + dr["id"].ToString());
                                }
                                else
                                {
                                    // 該当レコード無し（INSERT）
                                    // ===============================================
                                    // Trn_日報
                                    // ===============================================
                                    sql_sb.Clear();
                                    sql_sb.AppendLine("INSERT INTO");
                                    sql_sb.AppendLine("Trn_日報");
                                    sql_sb.AppendLine("(");
                                    sql_sb.AppendLine(" id");
                                    sql_sb.AppendLine(",location_id");
                                    sql_sb.AppendLine(",car_id");
                                    sql_sb.AppendLine(",day");
                                    sql_sb.AppendLine(",instructor_id");
                                    sql_sb.AppendLine(",staff_id1");
                                    // 2026/01/13 DEL (S)
                                    // sql_sb.AppendLine(",staff_id2");
                                    // sql_sb.AppendLine(",staff_id3");
                                    // 2026/01/13 DEL (E)
                                    sql_sb.AppendLine(",after_meter");
                                    sql_sb.AppendLine(",before_meter");
                                    sql_sb.AppendLine(",mileage");
                                    sql_sb.AppendLine(",fuel");
                                    sql_sb.AppendLine(",fuel_meter");
                                    sql_sb.AppendLine(",oil");
                                    sql_sb.AppendLine(",kerosene");
                                    // 2026/01/13 DEL (S)
                                    // sql_sb.AppendLine(",start_location");
                                    // sql_sb.AppendLine(",end_location");
                                    // 2026/01/13 DEL (E)
                                    // 2026/01/30 ADD (S)
                                    sql_sb.AppendLine(",work_start_time");
                                    sql_sb.AppendLine(",work_finish_time");
                                    // 2026/01/30 ADD (E)
                                    sql_sb.AppendLine(",start_time1");
                                    sql_sb.AppendLine(",start_time2");
                                    sql_sb.AppendLine(",start_time3");
                                    sql_sb.AppendLine(",end_time1");
                                    sql_sb.AppendLine(",end_time2");
                                    sql_sb.AppendLine(",end_time3");
                                    sql_sb.AppendLine(",over_time1");
                                    sql_sb.AppendLine(",over_time2");
                                    sql_sb.AppendLine(",over_time3");
                                    sql_sb.AppendLine(",start_over_time1");
                                    sql_sb.AppendLine(",start_over_time2");
                                    sql_sb.AppendLine(",start_over_time3");
                                    sql_sb.AppendLine(",end_over_time1");
                                    sql_sb.AppendLine(",end_over_time2");
                                    sql_sb.AppendLine(",end_over_time3");
                                    sql_sb.AppendLine(",start_over_time_kbn1");
                                    sql_sb.AppendLine(",start_over_time_kbn2");
                                    sql_sb.AppendLine(",start_over_time_kbn3");
                                    sql_sb.AppendLine(",end_over_time_kbn1");
                                    sql_sb.AppendLine(",end_over_time_kbn2");
                                    sql_sb.AppendLine(",end_over_time_kbn3");
                                    sql_sb.AppendLine(",start_over_time_comment1");
                                    sql_sb.AppendLine(",start_over_time_comment2");
                                    sql_sb.AppendLine(",start_over_time_comment3");
                                    sql_sb.AppendLine(",end_over_time_comment1");
                                    sql_sb.AppendLine(",end_over_time_comment2");
                                    sql_sb.AppendLine(",end_over_time_comment3");
                                    sql_sb.AppendLine(",subcar_flag");
                                    sql_sb.AppendLine(",confirm1_id");
                                    sql_sb.AppendLine(",confirm1_date");
                                    sql_sb.AppendLine(",confirm2_id");
                                    sql_sb.AppendLine(",confirm2_date");
                                    sql_sb.AppendLine(",confirm3_id");
                                    sql_sb.AppendLine(",confirm3_date");
                                    sql_sb.AppendLine(",sales_id");
                                    sql_sb.AppendLine(",sales_confirm_date");
                                    sql_sb.AppendLine(",guest_id");
                                    sql_sb.AppendLine(",guest_confirm_date");
                                    sql_sb.AppendLine(",confirm_status");
                                    sql_sb.AppendLine(",temp1");
                                    sql_sb.AppendLine(",temp2");
                                    sql_sb.AppendLine(",temp3");
                                    sql_sb.AppendLine(",temp_time1");
                                    sql_sb.AppendLine(",temp_time2");
                                    sql_sb.AppendLine(",temp_time3");
                                    sql_sb.AppendLine(",alcohol1");
                                    sql_sb.AppendLine(",alcohol2");
                                    sql_sb.AppendLine(",alcohol3");
                                    sql_sb.AppendLine(",alcohol_check1");
                                    sql_sb.AppendLine(",alcohol_check2");
                                    sql_sb.AppendLine(",alcohol_check3");
                                    sql_sb.AppendLine(",comment");
                                    sql_sb.AppendLine(",passenger_id");
                                    sql_sb.AppendLine(",inspection_check1");
                                    sql_sb.AppendLine(",inspection_check2");
                                    sql_sb.AppendLine(",inspection_check3");
                                    sql_sb.AppendLine(",inspection_check4");
                                    sql_sb.AppendLine(",inspection_check5");
                                    sql_sb.AppendLine(",inspection_check6");
                                    sql_sb.AppendLine(",inspection_check7");
                                    sql_sb.AppendLine(",per_inspection_check1");
                                    sql_sb.AppendLine(",per_inspection_check2");
                                    sql_sb.AppendLine(",per_inspection_check3");
                                    sql_sb.AppendLine(",per_inspection_check4");
                                    sql_sb.AppendLine(",per_inspection_check5");
                                    sql_sb.AppendLine(",per_inspection_check6");
                                    sql_sb.AppendLine(",per_inspection_check7");
                                    sql_sb.AppendLine(",per_inspection_check8");
                                    sql_sb.AppendLine(",per_inspection_check9");
                                    sql_sb.AppendLine(",per_inspection_check10");
                                    sql_sb.AppendLine(",per_inspection_check11");
                                    sql_sb.AppendLine(",per_inspection_check12");
                                    sql_sb.AppendLine(",per_inspection_check13");
                                    sql_sb.AppendLine(",per_inspection_check14");
                                    sql_sb.AppendLine(",large_inspection_check1");
                                    sql_sb.AppendLine(",large_inspection_check2");
                                    sql_sb.AppendLine(",large_inspection_check3");
                                    sql_sb.AppendLine(",large_inspection_check4");
                                    // 休憩時間
                                    sql_sb.AppendLine(",start_break_time1");
                                    sql_sb.AppendLine(",start_break_time2");
                                    sql_sb.AppendLine(",start_break_time3");
                                    sql_sb.AppendLine(",end_break_time1");
                                    sql_sb.AppendLine(",end_break_time2");
                                    sql_sb.AppendLine(",end_break_time3");
                                    sql_sb.AppendLine(",break_time1");
                                    sql_sb.AppendLine(",break_time2");
                                    sql_sb.AppendLine(",break_time3");
                                    // 更新情報
                                    sql_sb.AppendLine(",ins_user_id");
                                    sql_sb.AppendLine(",ins_date");
                                    sql_sb.AppendLine(",upd_user_id");
                                    sql_sb.AppendLine(",upd_date");
                                    sql_sb.AppendLine(",delete_flag");

                                    sql_sb.AppendLine(") VALUES (");
                                    // レコードID
                                    sql_sb.AppendLine(dr["id"].ToString());
                                    // 専従先ID
                                    if (dr.IsNull("location_id") != true) { sql_sb.AppendLine("," + dr["location_id"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    // 車両ID
                                    if (dr.IsNull("car_id") != true) { sql_sb.AppendLine("," + dr["car_id"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    // 日付
                                    if (dr.IsNull("day") != true) { sql_sb.AppendLine(",'" + dr["day"].ToString() + "'"); } else { sql_sb.AppendLine(",null"); }
                                    // 管理責任者ID
                                    if (dr.IsNull("instructor_id") != true) { sql_sb.AppendLine("," + dr["instructor_id"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    // 車両管理者ID 1～3
                                    if (dr.IsNull("staff_id1") != true) { sql_sb.AppendLine("," + dr["staff_id1"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    // 2026/01/13 DEL (S)
                                    // if (dr.IsNull("staff_id2") != true) { sql_sb.AppendLine("," + dr["staff_id2"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    // if (dr.IsNull("staff_id3") != true) { sql_sb.AppendLine("," + dr["staff_id3"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    // 2026/01/13 DEL (E)
                                    // 入庫時メーター値
                                    if (dr.IsNull("after_meter") != true) { sql_sb.AppendLine("," + dr["after_meter"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    // 出庫時メーター値
                                    if (dr.IsNull("before_meter") != true) { sql_sb.AppendLine("," + dr["before_meter"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    // 走行距離
                                    if (dr.IsNull("mileage") != true) { sql_sb.AppendLine("," + dr["mileage"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    // 給油
                                    if (dr.IsNull("fuel") != true) { sql_sb.AppendLine("," + dr["fuel"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    // 給油時メーター値
                                    if (dr.IsNull("fuel_meter") != true) { sql_sb.AppendLine("," + dr["fuel_meter"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    // オイル
                                    if (dr.IsNull("oil") != true) { sql_sb.AppendLine("," + dr["oil"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    // 灯油
                                    if (dr.IsNull("kerosene") != true) { sql_sb.AppendLine("," + dr["kerosene"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    // 2026/01/13 DEL (S)
                                    // 始業場所
                                    // if (dr.IsNull("start_location") != true) { sql_sb.AppendLine(",'" + dr["start_location"].ToString() + "'"); } else { sql_sb.AppendLine(",''"); }
                                    // 終業場所
                                    // if (dr.IsNull("end_location") != true) { sql_sb.AppendLine(",'" + dr["end_location"].ToString() + "'"); } else { sql_sb.AppendLine(",''"); }
                                    // 2026/01/13 DEL (E)
                                    // 2026/01/30 ADD (S)
                                    if (dr.IsNull("work_start_time") != true) { sql_sb.AppendLine(",'" + dr["work_start_time"].ToString() + "'"); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("work_finish_time") != true) { sql_sb.AppendLine(",'" + dr["work_finish_time"].ToString() + "'"); } else { sql_sb.AppendLine(",null"); }
                                    // 2026/01/30 ADD (E)
                                    // 始業時間1～3
                                    if (dr.IsNull("start_time1") != true) { sql_sb.AppendLine(",'" + dr["start_time1"].ToString() + "'"); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("start_time2") != true) { sql_sb.AppendLine(",'" + dr["start_time2"].ToString() + "'"); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("start_time3") != true) { sql_sb.AppendLine(",'" + dr["start_time3"].ToString() + "'"); } else { sql_sb.AppendLine(",null"); }
                                    // 終業時間1～3
                                    if (dr.IsNull("end_time1") != true) { sql_sb.AppendLine(",'" + dr["end_time1"].ToString() + "'"); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("end_time2") != true) { sql_sb.AppendLine(",'" + dr["end_time2"].ToString() + "'"); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("end_time3") != true) { sql_sb.AppendLine(",'" + dr["end_time3"].ToString() + "'"); } else { sql_sb.AppendLine(",null"); }
                                    // 残業時間1～3
                                    if (dr.IsNull("over_time1") != true) { sql_sb.AppendLine("," + dr["over_time1"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("over_time2") != true) { sql_sb.AppendLine("," + dr["over_time2"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("over_time3") != true) { sql_sb.AppendLine("," + dr["over_time3"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    // 始業残業時間1～3
                                    if (dr.IsNull("start_over_time1") != true) { sql_sb.AppendLine("," + dr["start_over_time1"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("start_over_time2") != true) { sql_sb.AppendLine("," + dr["start_over_time2"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("start_over_time3") != true) { sql_sb.AppendLine("," + dr["start_over_time3"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    // 終業残業時間1～3
                                    if (dr.IsNull("end_over_time1") != true) { sql_sb.AppendLine("," + dr["end_over_time1"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("end_over_time2") != true) { sql_sb.AppendLine("," + dr["end_over_time2"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("end_over_time3") != true) { sql_sb.AppendLine("," + dr["end_over_time3"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    // 始業残業理由区分1～3
                                    if (dr.IsNull("start_over_time_kbn1") != true) { sql_sb.AppendLine("," + dr["start_over_time_kbn1"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("start_over_time_kbn2") != true) { sql_sb.AppendLine("," + dr["start_over_time_kbn2"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("start_over_time_kbn3") != true) { sql_sb.AppendLine("," + dr["start_over_time_kbn3"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    // 終業残業理由区分1～3
                                    if (dr.IsNull("end_over_time_kbn1") != true) { sql_sb.AppendLine("," + dr["end_over_time_kbn1"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("end_over_time_kbn2") != true) { sql_sb.AppendLine("," + dr["end_over_time_kbn2"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("end_over_time_kbn3") != true) { sql_sb.AppendLine("," + dr["end_over_time_kbn3"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    // 始業残業理由1～3
                                    if (dr.IsNull("start_over_time_comment1") != true) { sql_sb.AppendLine(",'" + dr["start_over_time_comment1"].ToString() + "'"); } else { sql_sb.AppendLine(",''"); }
                                    if (dr.IsNull("start_over_time_comment2") != true) { sql_sb.AppendLine(",'" + dr["start_over_time_comment2"].ToString() + "'"); } else { sql_sb.AppendLine(",''"); }
                                    if (dr.IsNull("start_over_time_comment3") != true) { sql_sb.AppendLine(",'" + dr["start_over_time_comment3"].ToString() + "'"); } else { sql_sb.AppendLine(",''"); }
                                    // 終業残業理由1～3
                                    if (dr.IsNull("end_over_time_comment1") != true) { sql_sb.AppendLine(",'" + dr["end_over_time_comment1"].ToString() + "'"); } else { sql_sb.AppendLine(",''"); }
                                    if (dr.IsNull("end_over_time_comment2") != true) { sql_sb.AppendLine(",'" + dr["end_over_time_comment2"].ToString() + "'"); } else { sql_sb.AppendLine(",''"); }
                                    if (dr.IsNull("end_over_time_comment3") != true) { sql_sb.AppendLine(",'" + dr["end_over_time_comment3"].ToString() + "'"); } else { sql_sb.AppendLine(",''"); }
                                    // 代車フラグ
                                    if (dr.IsNull("subcar_flag") != true) { sql_sb.AppendLine("," + dr["subcar_flag"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    
                                    // 確認1
                                    if (dr.IsNull("confirm1_id") != true) { sql_sb.AppendLine("," + dr["confirm1_id"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    // 日付
                                    if (dr.IsNull("confirm1_date") != true) { sql_sb.AppendLine(",'" + dr["confirm1_date"].ToString() + "'"); } else { sql_sb.AppendLine(",null"); }
                                    // 確認2
                                    if (dr.IsNull("confirm2_id") != true) { sql_sb.AppendLine("," + dr["confirm2_id"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    // 日付
                                    if (dr.IsNull("confirm2_date") != true) { sql_sb.AppendLine(",'" + dr["confirm2_date"].ToString() + "'"); } else { sql_sb.AppendLine(",null"); }
                                    // 確認3
                                    if (dr.IsNull("confirm3_id") != true) { sql_sb.AppendLine("," + dr["confirm3_id"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    // 日付
                                    if (dr.IsNull("confirm3_date") != true) { sql_sb.AppendLine(",'" + dr["confirm3_date"].ToString() + "'"); } else { sql_sb.AppendLine(",null"); }
                                    // 営業認証
                                    if (dr.IsNull("sales_id") != true) { sql_sb.AppendLine("," + dr["sales_id"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    // 日付
                                    if (dr.IsNull("sales_confirm_date") != true) { sql_sb.AppendLine(",'" + dr["sales_confirm_date"].ToString() + "'"); } else { sql_sb.AppendLine(",null"); }
                                    // 顧客認証
                                    if (dr.IsNull("guest_id") != true) { sql_sb.AppendLine("," + dr["guest_id"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    // 日付
                                    if (dr.IsNull("guest_confirm_date") != true) { sql_sb.AppendLine(",'" + dr["guest_confirm_date"].ToString() + "'"); } else { sql_sb.AppendLine(",null"); }
                                    // 認証ステータス
                                    if (dr.IsNull("confirm_status") != true) { sql_sb.AppendLine("," + dr["confirm_status"].ToString()); } else { sql_sb.AppendLine(",0"); }

                                    // 検温1回目～3回目
                                    if (dr.IsNull("temp1") != true) { sql_sb.AppendLine("," + dr["temp1"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("temp2") != true) { sql_sb.AppendLine("," + dr["temp2"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("temp3") != true) { sql_sb.AppendLine("," + dr["temp3"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    // 検温時刻1回目～3回目
                                    if (dr.IsNull("temp_time1") != true) { sql_sb.AppendLine(",'" + dr["temp_time1"].ToString() + "'"); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("temp_time2") != true) { sql_sb.AppendLine(",'" + dr["temp_time2"].ToString() + "'"); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("temp_time3") != true) { sql_sb.AppendLine(",'" + dr["temp_time3"].ToString() + "'"); } else { sql_sb.AppendLine(",null"); }
                                    // アルコール濃度1回目～3回目
                                    if (dr.IsNull("alcohol1") != true) { sql_sb.AppendLine("," + dr["alcohol1"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("alcohol2") != true) { sql_sb.AppendLine("," + dr["alcohol2"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("alcohol3") != true) { sql_sb.AppendLine("," + dr["alcohol3"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    // アルコールチェック結果1回目～3回目
                                    if (dr.IsNull("alcohol_check1") != true) { sql_sb.AppendLine("," + dr["alcohol_check1"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("alcohol_check2") != true) { sql_sb.AppendLine("," + dr["alcohol_check2"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("alcohol_check3") != true) { sql_sb.AppendLine("," + dr["alcohol_check3"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    // 備考
                                    if (dr.IsNull("comment") != true) { sql_sb.AppendLine(",'" + dr["comment"].ToString() + "'"); } else { sql_sb.AppendLine(",''"); }
                                    // 同乗者有無
                                    if (dr.IsNull("passenger_id") != true) { sql_sb.AppendLine("," + dr["passenger_id"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    // 運行前点検項目1～7
                                    if (dr.IsNull("inspection_check1") != true) { sql_sb.AppendLine("," + dr["inspection_check1"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("inspection_check2") != true) { sql_sb.AppendLine("," + dr["inspection_check2"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("inspection_check3") != true) { sql_sb.AppendLine("," + dr["inspection_check3"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("inspection_check4") != true) { sql_sb.AppendLine("," + dr["inspection_check4"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("inspection_check5") != true) { sql_sb.AppendLine("," + dr["inspection_check5"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("inspection_check6") != true) { sql_sb.AppendLine("," + dr["inspection_check6"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("inspection_check7") != true) { sql_sb.AppendLine("," + dr["inspection_check7"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    // 定期点検項目1～14
                                    if (dr.IsNull("per_inspection_check1") != true) { sql_sb.AppendLine("," + dr["per_inspection_check1"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("per_inspection_check2") != true) { sql_sb.AppendLine("," + dr["per_inspection_check2"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("per_inspection_check3") != true) { sql_sb.AppendLine("," + dr["per_inspection_check3"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("per_inspection_check4") != true) { sql_sb.AppendLine("," + dr["per_inspection_check4"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("per_inspection_check5") != true) { sql_sb.AppendLine("," + dr["per_inspection_check5"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("per_inspection_check6") != true) { sql_sb.AppendLine("," + dr["per_inspection_check6"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("per_inspection_check7") != true) { sql_sb.AppendLine("," + dr["per_inspection_check7"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("per_inspection_check8") != true) { sql_sb.AppendLine("," + dr["per_inspection_check8"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("per_inspection_check9") != true) { sql_sb.AppendLine("," + dr["per_inspection_check9"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("per_inspection_check10") != true) { sql_sb.AppendLine("," + dr["per_inspection_check10"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("per_inspection_check11") != true) { sql_sb.AppendLine("," + dr["per_inspection_check11"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("per_inspection_check12") != true) { sql_sb.AppendLine("," + dr["per_inspection_check12"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("per_inspection_check13") != true) { sql_sb.AppendLine("," + dr["per_inspection_check13"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("per_inspection_check14") != true) { sql_sb.AppendLine("," + dr["per_inspection_check14"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    // 大型点検項目1～4
                                    if (dr.IsNull("large_inspection_check1") != true) { sql_sb.AppendLine("," + dr["large_inspection_check1"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("large_inspection_check2") != true) { sql_sb.AppendLine("," + dr["large_inspection_check2"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("large_inspection_check3") != true) { sql_sb.AppendLine("," + dr["large_inspection_check3"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("large_inspection_check4") != true) { sql_sb.AppendLine("," + dr["large_inspection_check4"].ToString()); } else { sql_sb.AppendLine(",null"); }

                                    // 休憩開始時間1～3
                                    if (dr.IsNull("start_break_time1") != true) { sql_sb.AppendLine(",'" + dr["start_break_time1"].ToString() + "'"); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("start_break_time2") != true) { sql_sb.AppendLine(",'" + dr["start_break_time2"].ToString() + "'"); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("start_break_time3") != true) { sql_sb.AppendLine(",'" + dr["start_break_time3"].ToString() + "'"); } else { sql_sb.AppendLine(",null"); }
                                    // 休憩終了時間1～3
                                    if (dr.IsNull("end_break_time1") != true) { sql_sb.AppendLine(",'" + dr["end_break_time1"].ToString() + "'"); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("end_break_time2") != true) { sql_sb.AppendLine(",'" + dr["end_break_time2"].ToString() + "'"); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("end_break_time3") != true) { sql_sb.AppendLine(",'" + dr["end_break_time3"].ToString() + "'"); } else { sql_sb.AppendLine(",null"); }
                                    // 休憩時間1～3
                                    if (dr.IsNull("break_time1") != true) { sql_sb.AppendLine("," + dr["break_time1"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("break_time2") != true) { sql_sb.AppendLine("," + dr["break_time2"].ToString()); } else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("break_time3") != true) { sql_sb.AppendLine("," + dr["break_time3"].ToString()); } else { sql_sb.AppendLine(",null"); }

                                    // 2025/11/11↓
                                    if (dr.IsNull("ins_user_id") != true) { sql_sb.AppendLine("," + dr["ins_user_id"].ToString()); }
                                    else { sql_sb.AppendLine(",0"); }
                                    if (dr.IsNull("ins_date") != true) { sql_sb.AppendLine(",'" + dr["ins_date"].ToString() + "'"); }
                                    else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("upd_user_id") != true) { sql_sb.AppendLine("," + dr["upd_user_id"].ToString()); }
                                    else { sql_sb.AppendLine(",0"); }
                                    if (dr.IsNull("upd_date") != true) { sql_sb.AppendLine(",'" + dr["upd_date"].ToString() + "'"); }
                                    else { sql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("delete_flag") != true) { sql_sb.AppendLine("," + dr["delete_flag"].ToString()); }
                                    else { sql_sb.AppendLine("," + ClsPublic.FLAG_OFF); }
                                    // 2025/11/11↑

                                    sql_sb.AppendLine(")");
                                }

                                clsSqlDb.DMLUpdate(sql_sb.ToString());

                                importCnt++;

                                // ProgressBar値セット
                                p_pgb.Value = importCnt;
                                p_pgb.Refresh();
                            }
                        }
                    }
                }
                return importCnt;
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 日報データエクスポート
        /// </summary>
        /// <returns>エクスポート件数</returns>
        public int ExportData(ref ProgressBar p_pgb)
        {
            int exportCnt = 0;

            try
            {
                using (ClsMySqlDb clsMySqlDb = new(ClsDbConfig.MySQLNo))
                {
                    using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                    {
                        // エクスポートデータ取得SQL
                        sql_sb.Clear();
                        sql_sb.AppendLine("SELECT");
                        // ===============================================
                        // Trn_日報
                        // ===============================================
                        sql_sb.AppendLine(" id");
                        sql_sb.AppendLine(",location_id");
                        sql_sb.AppendLine(",car_id");
                        sql_sb.AppendLine(",day");
                        sql_sb.AppendLine(",instructor_id");
                        sql_sb.AppendLine(",staff_id1");
                        // 2026/01/13 DEL (S)
                        // sql_sb.AppendLine(",staff_id2");
                        // sql_sb.AppendLine(",staff_id3");
                        // 2026/01/13 DEL (E)
                        sql_sb.AppendLine(",after_meter");
                        sql_sb.AppendLine(",before_meter");
                        sql_sb.AppendLine(",mileage");
                        sql_sb.AppendLine(",fuel");
                        sql_sb.AppendLine(",fuel_meter");
                        sql_sb.AppendLine(",oil");
                        sql_sb.AppendLine(",kerosene");
                        // 2026/01/13 DEL (S)
                        // sql_sb.AppendLine(",start_location");
                        // sql_sb.AppendLine(",end_location");
                        // 2026/01/13 DEL (E)
                        // 2026/01/30 ADD (S)
                        sql_sb.AppendLine(",work_start_time");
                        sql_sb.AppendLine(",work_finish_time");
                        // 2026/01/30 ADD (E)
                        sql_sb.AppendLine(",start_time1");
                        sql_sb.AppendLine(",start_time2");
                        sql_sb.AppendLine(",start_time3");
                        sql_sb.AppendLine(",end_time1");
                        sql_sb.AppendLine(",end_time2");
                        sql_sb.AppendLine(",end_time3");
                        sql_sb.AppendLine(",over_time1");
                        sql_sb.AppendLine(",over_time2");
                        sql_sb.AppendLine(",over_time3");
                        sql_sb.AppendLine(",start_over_time1");
                        sql_sb.AppendLine(",start_over_time2");
                        sql_sb.AppendLine(",start_over_time3");
                        sql_sb.AppendLine(",end_over_time1");
                        sql_sb.AppendLine(",end_over_time2");
                        sql_sb.AppendLine(",end_over_time3");
                        sql_sb.AppendLine(",start_over_time_kbn1");
                        sql_sb.AppendLine(",start_over_time_kbn2");
                        sql_sb.AppendLine(",start_over_time_kbn3");
                        sql_sb.AppendLine(",end_over_time_kbn1");
                        sql_sb.AppendLine(",end_over_time_kbn2");
                        sql_sb.AppendLine(",end_over_time_kbn3");
                        sql_sb.AppendLine(",start_over_time_comment1");
                        sql_sb.AppendLine(",start_over_time_comment2");
                        sql_sb.AppendLine(",start_over_time_comment3");
                        sql_sb.AppendLine(",end_over_time_comment1");
                        sql_sb.AppendLine(",end_over_time_comment2");
                        sql_sb.AppendLine(",end_over_time_comment3");
                        sql_sb.AppendLine(",subcar_flag");
                        sql_sb.AppendLine(",confirm1_id");
                        sql_sb.AppendLine(",confirm1_date");
                        sql_sb.AppendLine(",confirm2_id");
                        sql_sb.AppendLine(",confirm2_date");
                        sql_sb.AppendLine(",confirm3_id");
                        sql_sb.AppendLine(",confirm3_date");
                        sql_sb.AppendLine(",sales_id");
                        sql_sb.AppendLine(",sales_confirm_date");
                        sql_sb.AppendLine(",guest_id");
                        sql_sb.AppendLine(",guest_confirm_date");
                        sql_sb.AppendLine(",confirm_status");

                        // ===============================================
                        // 検温・アルコールチェック
                        // ===============================================
                        sql_sb.AppendLine(",temp1");
                        sql_sb.AppendLine(",temp2");
                        sql_sb.AppendLine(",temp3");
                        sql_sb.AppendLine(",temp_time1");
                        sql_sb.AppendLine(",temp_time2");
                        sql_sb.AppendLine(",temp_time3");
                        sql_sb.AppendLine(",alcohol1");
                        sql_sb.AppendLine(",alcohol2");
                        sql_sb.AppendLine(",alcohol3");
                        sql_sb.AppendLine(",alcohol_check1");
                        sql_sb.AppendLine(",alcohol_check2");
                        sql_sb.AppendLine(",alcohol_check3");

                        // ===============================================
                        // 備考
                        // ===============================================
                        sql_sb.AppendLine(",comment");
                        sql_sb.AppendLine(",passenger_id");            // 2025/02/18 ADD

                        // ===============================================
                        // 運行前点検
                        // ===============================================
                        sql_sb.AppendLine(",inspection_check1");
                        sql_sb.AppendLine(",inspection_check2");
                        sql_sb.AppendLine(",inspection_check3");
                        sql_sb.AppendLine(",inspection_check4");
                        sql_sb.AppendLine(",inspection_check5");
                        sql_sb.AppendLine(",inspection_check6");
                        sql_sb.AppendLine(",inspection_check7");

                        // ===============================================
                        // 定期点検
                        // ===============================================
                        sql_sb.AppendLine(",per_inspection_check1");
                        sql_sb.AppendLine(",per_inspection_check2");
                        sql_sb.AppendLine(",per_inspection_check3");
                        sql_sb.AppendLine(",per_inspection_check4");
                        sql_sb.AppendLine(",per_inspection_check5");
                        sql_sb.AppendLine(",per_inspection_check6");
                        sql_sb.AppendLine(",per_inspection_check7");
                        sql_sb.AppendLine(",per_inspection_check8");
                        sql_sb.AppendLine(",per_inspection_check9");
                        sql_sb.AppendLine(",per_inspection_check10");
                        sql_sb.AppendLine(",per_inspection_check11");
                        sql_sb.AppendLine(",per_inspection_check12");
                        sql_sb.AppendLine(",per_inspection_check13");
                        sql_sb.AppendLine(",per_inspection_check14");

                        // ===============================================
                        // その他点検
                        // ===============================================
                        //sql_sb.AppendLine(",wid_inspection_check1");
                        //sql_sb.AppendLine(",wid_inspection_check2");
                        //sql_sb.AppendLine(",wid_inspection_check3");
                        //sql_sb.AppendLine(",wid_inspection_check4");

                        // ===============================================
                        // 大型
                        // ===============================================
                        sql_sb.AppendLine(",large_inspection_check1");
                        sql_sb.AppendLine(",large_inspection_check2");
                        sql_sb.AppendLine(",large_inspection_check3");
                        sql_sb.AppendLine(",large_inspection_check4");

                        // ===============================================
                        // 休憩時間
                        // ===============================================
                        sql_sb.AppendLine(",start_break_time1");
                        sql_sb.AppendLine(",start_break_time2");
                        sql_sb.AppendLine(",start_break_time3");
                        sql_sb.AppendLine(",end_break_time1");
                        sql_sb.AppendLine(",end_break_time2");
                        sql_sb.AppendLine(",end_break_time3");
                        sql_sb.AppendLine(",break_time1");
                        sql_sb.AppendLine(",break_time2");
                        sql_sb.AppendLine(",break_time3");

                        // ===============================================
                        // 更新情報
                        // ===============================================
                        sql_sb.AppendLine(",ins_user_id");
                        sql_sb.AppendLine(",ins_date");
                        sql_sb.AppendLine(",upd_user_id");
                        sql_sb.AppendLine(",upd_date");
                        sql_sb.AppendLine(",delete_flag");

                        sql_sb.AppendLine("FROM");
                        sql_sb.AppendLine("Trn_日報");
                        sql_sb.AppendLine("WHERE");
                        sql_sb.AppendLine("day >= '" + this.Key_from_day.ToString("yyyy/MM/dd") + "'");
                        sql_sb.AppendLine("AND");
                        sql_sb.AppendLine("day <= '" + this.Key_to_day.ToString("yyyy/MM/dd") + "'");
                        if (this.Key_location_id != 0)
                        {
                            // 専従先の指定有り
                            sql_sb.AppendLine("AND");
                            sql_sb.AppendLine("location_id = " + this.Key_location_id.ToString());
                        }
                        if (this.Key_car_id != 0)
                        {
                            // 車両の指定有り
                            sql_sb.AppendLine("AND");
                            sql_sb.AppendLine("car_id = " + this.Key_car_id.ToString() + ";");
                        }

                        using (DataTable dt_val = clsSqlDb.DMLSelect(sql_sb.ToString()))
                        {
                            // 件数0の場合はメッセージ出力、処理終了
                            var rec_cnt = dt_val.Rows.Count;
                            if (rec_cnt <= 0)
                            {
                                MessageBox.Show("条件を満たす日報データがありません。", "結果", MessageBoxButtons.OK);
                                return 0;
                            }

                            // ProgressBar設定
                            p_pgb.Visible = true;
                            p_pgb.Maximum = rec_cnt;


                            // SQL Server日報データ読み込み
                            DataTable dt_val2;
                            foreach (DataRow dr in dt_val.Rows)
                            {
                                // MySQL登録チェック（未登録時はINSERT）
                                mysql_sb.Clear();
                                mysql_sb.AppendLine("SELECT");
                                mysql_sb.AppendLine("id");
                                mysql_sb.AppendLine("FROM");
                                mysql_sb.AppendLine("Trn_日報");
                                mysql_sb.AppendLine("WHERE");
                                mysql_sb.AppendLine("id = " + dr["id"].ToString());

                                dt_val2 = clsSqlDb.DMLSelect(mysql_sb.ToString());

                                // 該当レコード判定
                                if (dt_val2.Rows.Count > 0)
                                {
                                    // 該当レコード有り（UPDATE）
                                    // ===============================================
                                    // Trn_日報
                                    // ===============================================
                                    mysql_sb.Clear();
                                    mysql_sb.AppendLine("UPDATE");
                                    mysql_sb.AppendLine("Trn_日報");
                                    mysql_sb.AppendLine("SET");
                                    // 車両ID
                                    if (dr.IsNull("car_id") != true) { mysql_sb.AppendLine(" car_id = " + dr["car_id"].ToString()); } else { mysql_sb.AppendLine(" car_id = null"); }
                                    // 日付
                                    if (dr.IsNull("day") != true) { mysql_sb.AppendLine(",day = '" + dr["day"].ToString() + "'"); } else { mysql_sb.AppendLine(",day = null"); }
                                    // 管理責任者ID
                                    if (dr.IsNull("instructor_id") != true) { mysql_sb.AppendLine(",instructor_id = " + dr["instructor_id"].ToString()); } else { mysql_sb.AppendLine(",instructor_id = null"); }
                                    // 車両管理者1
                                    if (dr.IsNull("staff_id1") != true) { mysql_sb.AppendLine(",staff_id1 = " + dr["staff_id1"].ToString()); } else { mysql_sb.AppendLine(",staff_id1 = null"); }
                                    // 2026/01/13 DEL (S)
                                    // 車両管理者2
                                    // if (dr.IsNull("staff_id2") != true) { mysql_sb.AppendLine(",staff_id2 = " + dr["staff_id2"].ToString()); } else { mysql_sb.AppendLine(",staff_id2 = null"); }
                                    // 車両管理者3
                                    // if (dr.IsNull("staff_id3") != true) { mysql_sb.AppendLine(",staff_id3 = " + dr["staff_id3"].ToString()); } else { mysql_sb.AppendLine(",staff_id3 = null"); }
                                    // 2026/01/13 DEL (E)
                                    // 入庫時メーター
                                    if (dr.IsNull("after_meter") != true) { mysql_sb.AppendLine(",after_meter = " + dr["after_meter"].ToString()); } else { mysql_sb.AppendLine(",after_meter = null"); }
                                    // 出庫時メーター
                                    if (dr.IsNull("before_meter") != true) { mysql_sb.AppendLine(",before_meter = " + dr["before_meter"].ToString()); } else { mysql_sb.AppendLine(",before_meter = null"); }
                                    // 走行距離
                                    if (dr.IsNull("mileage") != true) { mysql_sb.AppendLine(",mileage = " + dr["mileage"].ToString()); } else { mysql_sb.AppendLine(",mileage = null"); }
                                    // 給油
                                    if (dr.IsNull("fuel") != true) { mysql_sb.AppendLine(",fuel = " + dr["fuel"].ToString()); } else { mysql_sb.AppendLine(",fuel = null"); }
                                    // 給油時メーター値
                                    if (dr.IsNull("fuel_meter") != true) { mysql_sb.AppendLine(",fuel_meter = " + dr["fuel_meter"].ToString()); } else { mysql_sb.AppendLine(",fuel_meter = null"); }
                                    // オイル
                                    if (dr.IsNull("oil") != true) { mysql_sb.AppendLine(",oil = " + dr["oil"].ToString()); } else { mysql_sb.AppendLine(",oil = null"); }
                                    // 灯油
                                    if (dr.IsNull("kerosene") != true) { mysql_sb.AppendLine(",kerosene = " + dr["kerosene"].ToString()); } else { mysql_sb.AppendLine(",kerosene = null"); }
                                    // 2025/01/13 DEL (S)
                                    // 始業場所
                                    // if (dr.IsNull("start_location") != true) { mysql_sb.AppendLine(",start_location = '" + dr["start_location"].ToString() + "'"); } else { mysql_sb.AppendLine(",start_location = ''"); }
                                    // 終業場所
                                    // if (dr.IsNull("end_location") != true) { mysql_sb.AppendLine(",end_location = '" + dr["end_location"].ToString() + "'"); } else { mysql_sb.AppendLine(",end_location = ''"); }
                                    // 2025/01/13 DEL (E)
                                    // 2026/01/30 ADD (S)
                                    if (dr.IsNull("work_start_time") != true) { mysql_sb.AppendLine(",work_start_time = '" + dr["work_start_time"].ToString() + "'"); } else { mysql_sb.AppendLine(",work_start_time = null"); }
                                    if (dr.IsNull("work_finish_time") != true) { mysql_sb.AppendLine(",work_finish_time = '" + dr["work_finish_time"].ToString() + "'"); } else { mysql_sb.AppendLine(",work_finish_time = null"); }
                                    // 2026/01/30 ADD (E)
                                    // 始業時間1～3
                                    if (dr.IsNull("start_time1") != true) { mysql_sb.AppendLine(",start_time1 = '" + dr["start_time1"].ToString() + "'"); } else { mysql_sb.AppendLine(",start_time1 = null"); }
                                    if (dr.IsNull("start_time2") != true) { mysql_sb.AppendLine(",start_time2 = '" + dr["start_time2"].ToString() + "'"); } else { mysql_sb.AppendLine(",start_time2 = null"); }
                                    if (dr.IsNull("start_time3") != true) { mysql_sb.AppendLine(",start_time3 = '" + dr["start_time3"].ToString() + "'"); } else { mysql_sb.AppendLine(",start_time3 = null"); }
                                    // 終業時間1～3
                                    if (dr.IsNull("end_time1") != true) { mysql_sb.AppendLine(",end_time1 = '" + dr["end_time1"].ToString() + "'"); } else { mysql_sb.AppendLine(",end_time1 = null"); }
                                    if (dr.IsNull("end_time2") != true) { mysql_sb.AppendLine(",end_time2 = '" + dr["end_time2"].ToString() + "'"); } else { mysql_sb.AppendLine(",end_time2 = null"); }
                                    if (dr.IsNull("end_time3") != true) { mysql_sb.AppendLine(",end_time3 = '" + dr["end_time3"].ToString() + "'"); } else { mysql_sb.AppendLine(",end_time3 = null"); }
                                    // 残業時間1～3
                                    if (dr.IsNull("over_time1") != true) { mysql_sb.AppendLine(",over_time1 = " + dr["over_time1"].ToString()); } else { mysql_sb.AppendLine(",over_time1 = null"); }
                                    if (dr.IsNull("over_time2") != true) { mysql_sb.AppendLine(",over_time2 = " + dr["over_time2"].ToString()); } else { mysql_sb.AppendLine(",over_time2 = null"); }
                                    if (dr.IsNull("over_time3") != true) { mysql_sb.AppendLine(",over_time3 = " + dr["over_time3"].ToString()); } else { mysql_sb.AppendLine(",over_time3 = null"); }
                                    // 始業残業時間1～3
                                    if (dr.IsNull("start_over_time1") != true) { mysql_sb.AppendLine(",start_over_time1 = " + dr["start_over_time1"].ToString()); } else { mysql_sb.AppendLine(",start_over_time1 = null"); }
                                    if (dr.IsNull("start_over_time2") != true) { mysql_sb.AppendLine(",start_over_time2 = " + dr["start_over_time2"].ToString()); } else { mysql_sb.AppendLine(",start_over_time2 = null"); }
                                    if (dr.IsNull("start_over_time3") != true) { mysql_sb.AppendLine(",start_over_time3 = " + dr["start_over_time3"].ToString()); } else { mysql_sb.AppendLine(",start_over_time3 = null"); }
                                    // 終業残業時間1～3
                                    if (dr.IsNull("end_over_time1") != true) { mysql_sb.AppendLine(",end_over_time1 = " + dr["end_over_time1"].ToString()); } else { mysql_sb.AppendLine(",end_over_time1 = null"); }
                                    if (dr.IsNull("end_over_time2") != true) { mysql_sb.AppendLine(",end_over_time2 = " + dr["end_over_time2"].ToString()); } else { mysql_sb.AppendLine(",end_over_time2 = null"); }
                                    if (dr.IsNull("end_over_time3") != true) { mysql_sb.AppendLine(",end_over_time3 = " + dr["end_over_time3"].ToString()); } else { mysql_sb.AppendLine(",end_over_time3 = null"); }
                                    // 始業残業理由区分1～3
                                    if (dr.IsNull("start_over_time_kbn1") != true) { mysql_sb.AppendLine(",start_over_time_kbn1 = " + dr["start_over_time_kbn1"].ToString()); } else { mysql_sb.AppendLine(",start_over_time_kbn1 = null"); }
                                    if (dr.IsNull("start_over_time_kbn2") != true) { mysql_sb.AppendLine(",start_over_time_kbn2 = " + dr["start_over_time_kbn2"].ToString()); } else { mysql_sb.AppendLine(",start_over_time_kbn2 = null"); }
                                    if (dr.IsNull("start_over_time_kbn3") != true) { mysql_sb.AppendLine(",start_over_time_kbn3 = " + dr["start_over_time_kbn3"].ToString()); } else { mysql_sb.AppendLine(",start_over_time_kbn3 = null"); }
                                    // 終業残業理由区分1～3
                                    if (dr.IsNull("end_over_time_kbn1") != true) { mysql_sb.AppendLine(",end_over_time_kbn1 = " + dr["end_over_time_kbn1"].ToString()); } else { mysql_sb.AppendLine(",end_over_time_kbn1 = null"); }
                                    if (dr.IsNull("end_over_time_kbn2") != true) { mysql_sb.AppendLine(",end_over_time_kbn2 = " + dr["end_over_time_kbn2"].ToString()); } else { mysql_sb.AppendLine(",end_over_time_kbn2 = null"); }
                                    if (dr.IsNull("end_over_time_kbn3") != true) { mysql_sb.AppendLine(",end_over_time_kbn3 = " + dr["end_over_time_kbn3"].ToString()); } else { mysql_sb.AppendLine(",end_over_time_kbn3 = null"); }
                                    // 始業残業理由1～3
                                    if (dr.IsNull("start_over_time_comment1") != true) { mysql_sb.AppendLine(",start_over_time_comment1 = '" + dr["start_over_time_comment1"].ToString() + "'"); } else { mysql_sb.AppendLine(",start_over_time_comment1 = ''"); }
                                    if (dr.IsNull("start_over_time_comment2") != true) { mysql_sb.AppendLine(",start_over_time_comment2 = '" + dr["start_over_time_comment2"].ToString() + "'"); } else { mysql_sb.AppendLine(",start_over_time_comment2 = ''"); }
                                    if (dr.IsNull("start_over_time_comment3") != true) { mysql_sb.AppendLine(",start_over_time_comment3 = '" + dr["start_over_time_comment3"].ToString() + "'"); } else { mysql_sb.AppendLine(",start_over_time_comment3 = ''"); }
                                    // 終業残業理由1～3
                                    if (dr.IsNull("end_over_time_comment1") != true) { mysql_sb.AppendLine(",end_over_time_comment1 = '" + dr["end_over_time_comment1"].ToString() + "'"); } else { mysql_sb.AppendLine(",end_over_time_comment1 = ''"); }
                                    if (dr.IsNull("end_over_time_comment2") != true) { mysql_sb.AppendLine(",end_over_time_comment2 = '" + dr["end_over_time_comment2"].ToString() + "'"); } else { mysql_sb.AppendLine(",end_over_time_comment2 = ''"); }
                                    if (dr.IsNull("end_over_time_comment3") != true) { mysql_sb.AppendLine(",end_over_time_comment3 = '" + dr["end_over_time_comment3"].ToString() + "'"); } else { mysql_sb.AppendLine(",end_over_time_comment3 = ''"); }
                                    // 代車フラグ
                                    if (dr.IsNull("subcar_flag") != true) { mysql_sb.AppendLine(",subcar_flag = " + dr["subcar_flag"].ToString()); } else { mysql_sb.AppendLine(",subcar_flag = 0"); }

                                    // 確認1
                                    if (dr.IsNull("confirm1_id") != true) { mysql_sb.AppendLine(",confirm1_id = " + dr["confirm1_id"].ToString()); } else { mysql_sb.AppendLine(",confirm1_id = 0"); }
                                    // 日付1
                                    if (dr.IsNull("confirm1_date") != true) { mysql_sb.AppendLine(",confirm1_date = '" + dr["confirm1_date"].ToString() + "'"); } else { mysql_sb.AppendLine(",confirm1_date = null"); }

                                    // 確認2
                                    if (dr.IsNull("confirm2_id") != true) { mysql_sb.AppendLine(",confirm2_id = " + dr["confirm2_id"].ToString()); } else { mysql_sb.AppendLine(",confirm2_id = 0"); }
                                    // 日付2
                                    if (dr.IsNull("confirm2_date") != true) { mysql_sb.AppendLine(",confirm2_date = '" + dr["confirm2_date"].ToString() + "'"); } else { mysql_sb.AppendLine(",confirm2_date = null"); }

                                    // 確認3
                                    if (dr.IsNull("confirm3_id") != true) { mysql_sb.AppendLine(",confirm3_id = " + dr["confirm3_id"].ToString()); } else { mysql_sb.AppendLine(",confirm3_id = 0"); }
                                    // 日付3
                                    if (dr.IsNull("confirm3_date") != true) { mysql_sb.AppendLine(",confirm3_date = '" + dr["confirm3_date"].ToString() + "'"); } else { mysql_sb.AppendLine(",confirm3_date = null"); }

                                    // 営業承認
                                    if (dr.IsNull("sales_id") != true) { mysql_sb.AppendLine(",sales_id = " + dr["sales_id"].ToString()); } else { mysql_sb.AppendLine(",sales_id = 0"); }
                                    // 営業承認日付
                                    if (dr.IsNull("sales_confirm_date") != true) { mysql_sb.AppendLine(",sales_confirm_date = '" + dr["sales_confirm_date"].ToString() + "'"); } else { mysql_sb.AppendLine(",sales_confirm_date = null"); }

                                    // 顧客承認
                                    if (dr.IsNull("guest_id") != true) { mysql_sb.AppendLine(",guest_id = " + dr["guest_id"].ToString()); } else { mysql_sb.AppendLine(",guest_id = 0"); }
                                    // 顧客承認日付
                                    if (dr.IsNull("guest_confirm_date") != true) { mysql_sb.AppendLine(",guest_confirm_date = '" + dr["guest_confirm_date"].ToString() + "'"); } else { mysql_sb.AppendLine(",guest_confirm_date = null"); }

                                    // 承認ステータス
                                    if (dr.IsNull("confirm_status") != true) { mysql_sb.AppendLine(",confirm_status = " + dr["confirm_status"].ToString()); } else { mysql_sb.AppendLine(",confirm_status = null"); }

                                    // 検温1回目～3回目
                                    if (dr.IsNull("temp1") != true) { mysql_sb.AppendLine(",temp1 = " + dr["temp1"].ToString()); } else { mysql_sb.AppendLine(",temp1 = null"); }
                                    if (dr.IsNull("temp2") != true) { mysql_sb.AppendLine(",temp2 = " + dr["temp2"].ToString()); } else { mysql_sb.AppendLine(",temp2 = null"); }
                                    if (dr.IsNull("temp3") != true) { mysql_sb.AppendLine(",temp3 = " + dr["temp3"].ToString()); } else { mysql_sb.AppendLine(",temp3 = null"); }
                                    // 検温時刻1回目～3回目
                                    if (dr.IsNull("temp_time1") != true) { mysql_sb.AppendLine(",temp_time1 = '" + dr["temp_time1"].ToString() + "'"); } else { mysql_sb.AppendLine(",temp_time1 = null"); }
                                    if (dr.IsNull("temp_time2") != true) { mysql_sb.AppendLine(",temp_time2 = '" + dr["temp_time2"].ToString() + "'"); } else { mysql_sb.AppendLine(",temp_time2 = null"); }
                                    if (dr.IsNull("temp_time3") != true) { mysql_sb.AppendLine(",temp_time3 = '" + dr["temp_time3"].ToString() + "'"); } else { mysql_sb.AppendLine(",temp_time3 = null"); }
                                    // アルコール濃度1回目～3回目
                                    if (dr.IsNull("alcohol1") != true) { mysql_sb.AppendLine(",alcohol1 = " + dr["alcohol1"].ToString()); } else { mysql_sb.AppendLine(",alcohol1 = null"); }
                                    if (dr.IsNull("alcohol2") != true) { mysql_sb.AppendLine(",alcohol2 = " + dr["alcohol2"].ToString()); } else { mysql_sb.AppendLine(",alcohol2 = null"); }
                                    if (dr.IsNull("alcohol3") != true) { mysql_sb.AppendLine(",alcohol3 = " + dr["alcohol3"].ToString()); } else { mysql_sb.AppendLine(",alcohol3 = null"); }
                                    // アルコールチェック結果1回目～3回目
                                    if (dr.IsNull("alcohol_check1") != true) { mysql_sb.AppendLine(",alcohol_check1 = " + dr["alcohol_check1"].ToString()); } else { mysql_sb.AppendLine(",alcohol_check1 = null"); }
                                    if (dr.IsNull("alcohol_check2") != true) { mysql_sb.AppendLine(",alcohol_check2 = " + dr["alcohol_check2"].ToString()); } else { mysql_sb.AppendLine(",alcohol_check2 = null"); }
                                    if (dr.IsNull("alcohol_check3") != true) { mysql_sb.AppendLine(",alcohol_check3 = " + dr["alcohol_check3"].ToString()); } else { mysql_sb.AppendLine(",alcohol_check3 = null"); }
                                    // 備考
                                    if (dr.IsNull("comment") != true) { mysql_sb.AppendLine(",comment = '" + dr["comment"].ToString() + "'"); } else { mysql_sb.AppendLine(",comment = ''"); }
                                    // 同乗者有無
                                    if (dr.IsNull("passenger_id") != true) { mysql_sb.AppendLine(",passenger_id = " + dr["passenger_id"].ToString()); } else { mysql_sb.AppendLine(",passenger_id = null"); }
                                    // [運行前点検]
                                    // 項目1～7
                                    if (dr.IsNull("inspection_check1") != true) { mysql_sb.AppendLine(",inspection_check1 = " + dr["inspection_check1"].ToString()); } else { mysql_sb.AppendLine(",inspection_check1 = null"); }
                                    if (dr.IsNull("inspection_check2") != true) { mysql_sb.AppendLine(",inspection_check2 = " + dr["inspection_check2"].ToString()); } else { mysql_sb.AppendLine(",inspection_check2 = null"); }
                                    if (dr.IsNull("inspection_check3") != true) { mysql_sb.AppendLine(",inspection_check3 = " + dr["inspection_check3"].ToString()); } else { mysql_sb.AppendLine(",inspection_check3 = null"); }
                                    if (dr.IsNull("inspection_check4") != true) { mysql_sb.AppendLine(",inspection_check4 = " + dr["inspection_check4"].ToString()); } else { mysql_sb.AppendLine(",inspection_check4 = null"); }
                                    if (dr.IsNull("inspection_check5") != true) { mysql_sb.AppendLine(",inspection_check5 = " + dr["inspection_check5"].ToString()); } else { mysql_sb.AppendLine(",inspection_check5 = null"); }
                                    if (dr.IsNull("inspection_check6") != true) { mysql_sb.AppendLine(",inspection_check6 = " + dr["inspection_check6"].ToString()); } else { mysql_sb.AppendLine(",inspection_check6 = null"); }
                                    if (dr.IsNull("inspection_check7") != true) { mysql_sb.AppendLine(",inspection_check7 = " + dr["inspection_check7"].ToString()); } else { mysql_sb.AppendLine(",inspection_check7 = null"); }
                                    // [定期点検]
                                    // 項目1～14
                                    if (dr.IsNull("per_inspection_check1") != true) { mysql_sb.AppendLine(",per_inspection_check1 = " + dr["per_inspection_check1"].ToString()); } else { mysql_sb.AppendLine(",per_inspection_check1 = null"); }
                                    if (dr.IsNull("per_inspection_check2") != true) { mysql_sb.AppendLine(",per_inspection_check2 = " + dr["per_inspection_check2"].ToString()); } else { mysql_sb.AppendLine(",per_inspection_check2 = null"); }
                                    if (dr.IsNull("per_inspection_check3") != true) { mysql_sb.AppendLine(",per_inspection_check3 = " + dr["per_inspection_check3"].ToString()); } else { mysql_sb.AppendLine(",per_inspection_check3 = null"); }
                                    if (dr.IsNull("per_inspection_check4") != true) { mysql_sb.AppendLine(",per_inspection_check4 = " + dr["per_inspection_check4"].ToString()); } else { mysql_sb.AppendLine(",per_inspection_check4 = null"); }
                                    if (dr.IsNull("per_inspection_check5") != true) { mysql_sb.AppendLine(",per_inspection_check5 = " + dr["per_inspection_check5"].ToString()); } else { mysql_sb.AppendLine(",per_inspection_check5 = null"); }
                                    if (dr.IsNull("per_inspection_check6") != true) { mysql_sb.AppendLine(",per_inspection_check6 = " + dr["per_inspection_check6"].ToString()); } else { mysql_sb.AppendLine(",per_inspection_check6 = null"); }
                                    if (dr.IsNull("per_inspection_check7") != true) { mysql_sb.AppendLine(",per_inspection_check7 = " + dr["per_inspection_check7"].ToString()); } else { mysql_sb.AppendLine(",per_inspection_check7 = null"); }
                                    if (dr.IsNull("per_inspection_check8") != true) { mysql_sb.AppendLine(",per_inspection_check8 = " + dr["per_inspection_check8"].ToString()); } else { mysql_sb.AppendLine(",per_inspection_check8 = null"); }
                                    if (dr.IsNull("per_inspection_check9") != true) { mysql_sb.AppendLine(",per_inspection_check9 = " + dr["per_inspection_check9"].ToString()); } else { mysql_sb.AppendLine(",per_inspection_check9 = null"); }
                                    if (dr.IsNull("per_inspection_check10") != true) { mysql_sb.AppendLine(",per_inspection_check10 = " + dr["per_inspection_check10"].ToString()); } else { mysql_sb.AppendLine(",per_inspection_check10 = null"); }
                                    if (dr.IsNull("per_inspection_check11") != true) { mysql_sb.AppendLine(",per_inspection_check11 = " + dr["per_inspection_check11"].ToString()); } else { mysql_sb.AppendLine(",per_inspection_check11 = null"); }
                                    if (dr.IsNull("per_inspection_check12") != true) { mysql_sb.AppendLine(",per_inspection_check12 = " + dr["per_inspection_check12"].ToString()); } else { mysql_sb.AppendLine(",per_inspection_check12 = null"); }
                                    if (dr.IsNull("per_inspection_check13") != true) { mysql_sb.AppendLine(",per_inspection_check13 = " + dr["per_inspection_check13"].ToString()); } else { mysql_sb.AppendLine(",per_inspection_check13 = null"); }
                                    if (dr.IsNull("per_inspection_check14") != true) { mysql_sb.AppendLine(",per_inspection_check14 = " + dr["per_inspection_check14"].ToString()); } else { mysql_sb.AppendLine(",per_inspection_check14 = null"); }
                                    // [大型点検]
                                    // 項目1～4
                                    if (dr.IsNull("large_inspection_check1") != true) { mysql_sb.AppendLine(",large_inspection_check1 = " + dr["large_inspection_check1"].ToString()); } else { mysql_sb.AppendLine(",large_inspection_check1 = null"); }
                                    if (dr.IsNull("large_inspection_check2") != true) { mysql_sb.AppendLine(",large_inspection_check2 = " + dr["large_inspection_check2"].ToString()); } else { mysql_sb.AppendLine(",large_inspection_check2 = null"); }
                                    if (dr.IsNull("large_inspection_check3") != true) { mysql_sb.AppendLine(",large_inspection_check3 = " + dr["large_inspection_check3"].ToString()); } else { mysql_sb.AppendLine(",large_inspection_check3 = null"); }
                                    if (dr.IsNull("large_inspection_check4") != true) { mysql_sb.AppendLine(",large_inspection_check4 = " + dr["large_inspection_check4"].ToString()); } else { mysql_sb.AppendLine(",large_inspection_check4 = null"); }

                                    // 休憩開始時間1～3
                                    if (dr.IsNull("start_break_time1") != true) { mysql_sb.AppendLine(",start_break_time1 = '" + dr["start_break_time1"].ToString() + "'"); } else { mysql_sb.AppendLine(",start_break_time1 = null"); }
                                    if (dr.IsNull("start_break_time2") != true) { mysql_sb.AppendLine(",start_break_time2 = '" + dr["start_break_time2"].ToString() + "'"); } else { mysql_sb.AppendLine(",start_break_time2 = null"); }
                                    if (dr.IsNull("start_break_time3") != true) { mysql_sb.AppendLine(",start_break_time3 = '" + dr["start_break_time3"].ToString() + "'"); } else { mysql_sb.AppendLine(",start_break_time3 = null"); }
                                    // 休憩終了時間1～3
                                    if (dr.IsNull("end_break_time1") != true) { mysql_sb.AppendLine(",end_break_time1 = '" + dr["end_break_time1"].ToString() + "'"); } else { mysql_sb.AppendLine(",end_break_time1 = null"); }
                                    if (dr.IsNull("end_break_time2") != true) { mysql_sb.AppendLine(",end_break_time2 = '" + dr["end_break_time2"].ToString() + "'"); } else { mysql_sb.AppendLine(",end_break_time2 = null"); }
                                    if (dr.IsNull("end_break_time3") != true) { mysql_sb.AppendLine(",end_break_time3 = '" + dr["end_break_time3"].ToString() + "'"); } else { mysql_sb.AppendLine(",end_break_time3 = null"); }
                                    // 休憩時間1～3
                                    if (dr.IsNull("break_time1") != true) { mysql_sb.AppendLine(",break_time1 = " + dr["break_time1"].ToString()); } else { mysql_sb.AppendLine(",break_time1 = null"); }
                                    if (dr.IsNull("break_time2") != true) { mysql_sb.AppendLine(",break_time2 = " + dr["break_time2"].ToString()); } else { mysql_sb.AppendLine(",break_time2 = null"); }
                                    if (dr.IsNull("break_time3") != true) { mysql_sb.AppendLine(",break_time3 = " + dr["break_time3"].ToString()); } else { mysql_sb.AppendLine(",break_time3 = null"); }

                                    // 2025/11/11↓
                                    if (dr.IsNull("ins_user_id") != true) { mysql_sb.AppendLine(",ins_user_id = " + dr["ins_user_id"].ToString()); }
                                    else { mysql_sb.AppendLine(",ins_user_id = 0"); }
                                    if (dr.IsNull("ins_date") != true) { mysql_sb.AppendLine(",ins_date = '" + dr["ins_date"].ToString() + "'"); }
                                    else { mysql_sb.AppendLine(",ins_date = null"); }
                                    if (dr.IsNull("upd_user_id") != true) { mysql_sb.AppendLine(",upd_user_id = " + dr["upd_user_id"].ToString()); }
                                    else { mysql_sb.AppendLine(",upd_user_id = 0"); }
                                    if (dr.IsNull("upd_date") != true) { mysql_sb.AppendLine(",upd_date = '" + dr["upd_date"].ToString() + "'"); }
                                    else { mysql_sb.AppendLine(",upd_date = null"); }
                                    if (dr.IsNull("delete_flag") != true) { mysql_sb.AppendLine(",delete_flag = " + dr["delete_flag"].ToString()); }
                                    else { mysql_sb.AppendLine(",delete_flag = " + ClsPublic.FLAG_OFF); }
                                    // 2025/11/11↑

                                    mysql_sb.AppendLine("WHERE");
                                    mysql_sb.AppendLine("id = " + dr["id"].ToString());
                                }
                                else
                                {
                                    // 該当レコード無し（INSERT）
                                    // →→→ 社内で日報を新規に登録する事はない為、INSERTは発生しない（はず）
                                    // ===============================================
                                    // Trn_日報
                                    // ===============================================
                                    mysql_sb.Clear();
                                    mysql_sb.AppendLine("INSERT INTO");
                                    mysql_sb.AppendLine("Trn_日報");
                                    mysql_sb.AppendLine("(");
                                    mysql_sb.AppendLine(" id");
                                    mysql_sb.AppendLine(",location_id");
                                    mysql_sb.AppendLine(",car_id");
                                    mysql_sb.AppendLine(",day");
                                    mysql_sb.AppendLine(",instructor_id");
                                    mysql_sb.AppendLine(",staff_id1");
                                    // 2026/01/13 DEL (S)
                                    // mysql_sb.AppendLine(",staff_id2");
                                    // mysql_sb.AppendLine(",staff_id3");
                                    // 2026/01/13 DEL (E)
                                    mysql_sb.AppendLine(",after_meter");
                                    mysql_sb.AppendLine(",before_meter");
                                    mysql_sb.AppendLine(",mileage");
                                    mysql_sb.AppendLine(",fuel");
                                    mysql_sb.AppendLine(",fuel_meter");
                                    mysql_sb.AppendLine(",oil");
                                    mysql_sb.AppendLine(",kerosene");
                                    // 2025/01/13 DEL (S)
                                    // mysql_sb.AppendLine(",start_location");
                                    // mysql_sb.AppendLine(",end_location");
                                    // 2025/01/13 DEL (E)
                                    // 2026/01/30 ADD (S)
                                    mysql_sb.AppendLine(",work_start_time");
                                    mysql_sb.AppendLine(",work_finish_time");
                                    // 2026/01/30 ADD (E)
                                    mysql_sb.AppendLine(",start_time1");
                                    mysql_sb.AppendLine(",start_time2");
                                    mysql_sb.AppendLine(",start_time3");
                                    mysql_sb.AppendLine(",end_time1");
                                    mysql_sb.AppendLine(",end_time2");
                                    mysql_sb.AppendLine(",end_time3");
                                    mysql_sb.AppendLine(",over_time1");
                                    mysql_sb.AppendLine(",over_time2");
                                    mysql_sb.AppendLine(",over_time3");
                                    mysql_sb.AppendLine(",start_over_time1");
                                    mysql_sb.AppendLine(",start_over_time2");
                                    mysql_sb.AppendLine(",start_over_time3");
                                    mysql_sb.AppendLine(",end_over_time1");
                                    mysql_sb.AppendLine(",end_over_time2");
                                    mysql_sb.AppendLine(",end_over_time3");
                                    mysql_sb.AppendLine(",start_over_time_kbn1");
                                    mysql_sb.AppendLine(",start_over_time_kbn2");
                                    mysql_sb.AppendLine(",start_over_time_kbn3");
                                    mysql_sb.AppendLine(",end_over_time_kbn1");
                                    mysql_sb.AppendLine(",end_over_time_kbn2");
                                    mysql_sb.AppendLine(",end_over_time_kbn3");
                                    mysql_sb.AppendLine(",start_over_time_comment1");
                                    mysql_sb.AppendLine(",start_over_time_comment2");
                                    mysql_sb.AppendLine(",start_over_time_comment3");
                                    mysql_sb.AppendLine(",end_over_time_comment1");
                                    mysql_sb.AppendLine(",end_over_time_comment2");
                                    mysql_sb.AppendLine(",end_over_time_comment3");
                                    mysql_sb.AppendLine(",subcar_flag");
                                    mysql_sb.AppendLine(",confirm1_id");
                                    mysql_sb.AppendLine(",confirm1_date");
                                    mysql_sb.AppendLine(",confirm2_id");
                                    mysql_sb.AppendLine(",confirm2_date");
                                    mysql_sb.AppendLine(",confirm3_id");
                                    mysql_sb.AppendLine(",confirm3_date");
                                    mysql_sb.AppendLine(",sales_id");
                                    mysql_sb.AppendLine(",sales_confirm_date");
                                    mysql_sb.AppendLine(",guest_id");
                                    mysql_sb.AppendLine(",guest_confirm_date");
                                    mysql_sb.AppendLine(",confirm_status");
                                    mysql_sb.AppendLine(",temp1");
                                    mysql_sb.AppendLine(",temp2");
                                    mysql_sb.AppendLine(",temp3");
                                    mysql_sb.AppendLine(",temp_time1");
                                    mysql_sb.AppendLine(",temp_time2");
                                    mysql_sb.AppendLine(",temp_time3");
                                    mysql_sb.AppendLine(",alcohol1");
                                    mysql_sb.AppendLine(",alcohol2");
                                    mysql_sb.AppendLine(",alcohol3");
                                    mysql_sb.AppendLine(",alcohol_check1");
                                    mysql_sb.AppendLine(",alcohol_check2");
                                    mysql_sb.AppendLine(",alcohol_check3");
                                    mysql_sb.AppendLine(",comment");
                                    mysql_sb.AppendLine(",passenger_id");
                                    mysql_sb.AppendLine(",inspection_check1");
                                    mysql_sb.AppendLine(",inspection_check2");
                                    mysql_sb.AppendLine(",inspection_check3");
                                    mysql_sb.AppendLine(",inspection_check4");
                                    mysql_sb.AppendLine(",inspection_check5");
                                    mysql_sb.AppendLine(",inspection_check6");
                                    mysql_sb.AppendLine(",inspection_check7");
                                    mysql_sb.AppendLine(",per_inspection_check1");
                                    mysql_sb.AppendLine(",per_inspection_check2");
                                    mysql_sb.AppendLine(",per_inspection_check3");
                                    mysql_sb.AppendLine(",per_inspection_check4");
                                    mysql_sb.AppendLine(",per_inspection_check5");
                                    mysql_sb.AppendLine(",per_inspection_check6");
                                    mysql_sb.AppendLine(",per_inspection_check7");
                                    mysql_sb.AppendLine(",per_inspection_check8");
                                    mysql_sb.AppendLine(",per_inspection_check9");
                                    mysql_sb.AppendLine(",per_inspection_check10");
                                    mysql_sb.AppendLine(",per_inspection_check11");
                                    mysql_sb.AppendLine(",per_inspection_check12");
                                    mysql_sb.AppendLine(",per_inspection_check13");
                                    mysql_sb.AppendLine(",per_inspection_check14");
                                    mysql_sb.AppendLine(",large_inspection_check1");
                                    mysql_sb.AppendLine(",large_inspection_check2");
                                    mysql_sb.AppendLine(",large_inspection_check3");
                                    mysql_sb.AppendLine(",large_inspection_check4");
                                    // 休憩時間
                                    mysql_sb.AppendLine(",start_break_time1");
                                    mysql_sb.AppendLine(",start_break_time2");
                                    mysql_sb.AppendLine(",start_break_time3");
                                    mysql_sb.AppendLine(",end_break_time1");
                                    mysql_sb.AppendLine(",end_break_time2");
                                    mysql_sb.AppendLine(",end_break_time3");
                                    mysql_sb.AppendLine(",break_time1");
                                    mysql_sb.AppendLine(",break_time2");
                                    mysql_sb.AppendLine(",break_time3");

                                    mysql_sb.AppendLine(") VALUES (");
                                    // レコードID
                                    mysql_sb.AppendLine(dr["id"].ToString());
                                    // 専従先ID
                                    if (dr.IsNull("location_id") != true) { mysql_sb.AppendLine("," + dr["location_id"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    // 車両ID
                                    if (dr.IsNull("car_id") != true) { mysql_sb.AppendLine("," + dr["car_id"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    // 日付
                                    if (dr.IsNull("day") != true) { mysql_sb.AppendLine(",'" + dr["day"].ToString() + "'"); } else { mysql_sb.AppendLine(",null"); }
                                    // 管理責任者ID
                                    if (dr.IsNull("instructor_id") != true) { mysql_sb.AppendLine("," + dr["instructor_id"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    // 車両管理者ID 1～3
                                    if (dr.IsNull("staff_id1") != true) { mysql_sb.AppendLine("," + dr["staff_id1"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    // 2026/01/13 DEL (S)
                                    // if (dr.IsNull("staff_id2") != true) { mysql_sb.AppendLine("," + dr["staff_id2"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    // if (dr.IsNull("staff_id3") != true) { mysql_sb.AppendLine("," + dr["staff_id3"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    // 2026/01/13 DEL (E)
                                    // 入庫時メーター値
                                    if (dr.IsNull("after_meter") != true) { mysql_sb.AppendLine("," + dr["after_meter"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    // 出庫時メーター値
                                    if (dr.IsNull("before_meter") != true) { mysql_sb.AppendLine("," + dr["before_meter"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    // 走行距離
                                    if (dr.IsNull("mileage") != true) { mysql_sb.AppendLine("," + dr["mileage"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    // 給油
                                    if (dr.IsNull("fuel") != true) { mysql_sb.AppendLine("," + dr["fuel"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    // 給油時メーター値
                                    if (dr.IsNull("fuel_meter") != true) { mysql_sb.AppendLine("," + dr["fuel_meter"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    // オイル
                                    if (dr.IsNull("oil") != true) { mysql_sb.AppendLine("," + dr["oil"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    // 灯油
                                    if (dr.IsNull("kerosene") != true) { mysql_sb.AppendLine("," + dr["kerosene"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    // 2025/01/13 DEL (S)
                                    // 始業場所
                                    // if (dr.IsNull("start_location") != true) { mysql_sb.AppendLine(",'" + dr["start_location"].ToString() + "'"); } else { mysql_sb.AppendLine(",''"); }
                                    // 終業場所
                                    // if (dr.IsNull("end_location") != true) { mysql_sb.AppendLine(",'" + dr["end_location"].ToString() + "'"); } else { mysql_sb.AppendLine(",''"); }
                                    // 2025/01/13 DEL (E)
                                    // 2026/01/30 ADD (S)
                                    if (dr.IsNull("work_start_time") != true) { mysql_sb.AppendLine(",'" + dr["work_start_time"].ToString() + "'"); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("work_finish_time") != true) { mysql_sb.AppendLine(",'" + dr["work_finish_time"].ToString() + "'"); } else { mysql_sb.AppendLine(",null"); }
                                    // 2026/01/30 ADD (E)
                                    // 始業時間1～3
                                    if (dr.IsNull("start_time1") != true) { mysql_sb.AppendLine(",'" + dr["start_time1"].ToString() + "'"); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("start_time2") != true) { mysql_sb.AppendLine(",'" + dr["start_time2"].ToString() + "'"); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("start_time3") != true) { mysql_sb.AppendLine(",'" + dr["start_time3"].ToString() + "'"); } else { mysql_sb.AppendLine(",null"); }
                                    // 終業時間1～3
                                    if (dr.IsNull("end_time1") != true) { mysql_sb.AppendLine(",'" + dr["end_time1"].ToString() + "'"); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("end_time2") != true) { mysql_sb.AppendLine(",'" + dr["end_time2"].ToString() + "'"); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("end_time3") != true) { mysql_sb.AppendLine(",'" + dr["end_time3"].ToString() + "'"); } else { mysql_sb.AppendLine(",null"); }
                                    // 残業時間1～3
                                    if (dr.IsNull("over_time1") != true) { mysql_sb.AppendLine("," + dr["over_time1"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("over_time2") != true) { mysql_sb.AppendLine("," + dr["over_time2"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("over_time3") != true) { mysql_sb.AppendLine("," + dr["over_time3"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    // 始業残業時間1～3
                                    if (dr.IsNull("start_over_time1") != true) { mysql_sb.AppendLine("," + dr["start_over_time1"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("start_over_time2") != true) { mysql_sb.AppendLine("," + dr["start_over_time2"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("start_over_time3") != true) { mysql_sb.AppendLine("," + dr["start_over_time3"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    // 終業残業時間1～3
                                    if (dr.IsNull("end_over_time1") != true) { mysql_sb.AppendLine("," + dr["end_over_time1"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("end_over_time2") != true) { mysql_sb.AppendLine("," + dr["end_over_time2"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("end_over_time3") != true) { mysql_sb.AppendLine("," + dr["end_over_time3"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    // 始業残業理由区分1～3
                                    if (dr.IsNull("start_over_time_kbn1") != true) { mysql_sb.AppendLine("," + dr["start_over_time_kbn1"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("start_over_time_kbn2") != true) { mysql_sb.AppendLine("," + dr["start_over_time_kbn2"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("start_over_time_kbn3") != true) { mysql_sb.AppendLine("," + dr["start_over_time_kbn3"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    // 終業残業理由区分1～3
                                    if (dr.IsNull("end_over_time_kbn1") != true) { mysql_sb.AppendLine("," + dr["end_over_time_kbn1"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("end_over_time_kbn2") != true) { mysql_sb.AppendLine("," + dr["end_over_time_kbn2"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("end_over_time_kbn3") != true) { mysql_sb.AppendLine("," + dr["end_over_time_kbn3"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    // 始業残業理由1～3
                                    if (dr.IsNull("start_over_time_comment1") != true) { mysql_sb.AppendLine(",'" + dr["start_over_time_comment1"].ToString() + "'"); } else { mysql_sb.AppendLine(",''"); }
                                    if (dr.IsNull("start_over_time_comment2") != true) { mysql_sb.AppendLine(",'" + dr["start_over_time_comment2"].ToString() + "'"); } else { mysql_sb.AppendLine(",''"); }
                                    if (dr.IsNull("start_over_time_comment3") != true) { mysql_sb.AppendLine(",'" + dr["start_over_time_comment3"].ToString() + "'"); } else { mysql_sb.AppendLine(",''"); }
                                    // 終業残業理由1～3
                                    if (dr.IsNull("end_over_time_comment1") != true) { mysql_sb.AppendLine(",'" + dr["end_over_time_comment1"].ToString() + "'"); } else { mysql_sb.AppendLine(",''"); }
                                    if (dr.IsNull("end_over_time_comment2") != true) { mysql_sb.AppendLine(",'" + dr["end_over_time_comment2"].ToString() + "'"); } else { mysql_sb.AppendLine(",''"); }
                                    if (dr.IsNull("end_over_time_comment3") != true) { mysql_sb.AppendLine(",'" + dr["end_over_time_comment3"].ToString() + "'"); } else { mysql_sb.AppendLine(",''"); }
                                    // 代車フラグ
                                    if (dr.IsNull("subcar_flag") != true) { mysql_sb.AppendLine("," + dr["subcar_flag"].ToString()); } else { mysql_sb.AppendLine(",null"); }

                                    // 確認1
                                    if (dr.IsNull("confirm1_id") != true) { mysql_sb.AppendLine("," + dr["confirm1_id"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    // 日付
                                    if (dr.IsNull("confirm1_date") != true) { mysql_sb.AppendLine(",'" + dr["confirm1_date"].ToString() + "'"); } else { mysql_sb.AppendLine(",null"); }
                                    // 確認2
                                    if (dr.IsNull("confirm2_id") != true) { mysql_sb.AppendLine("," + dr["confirm2_id"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    // 日付
                                    if (dr.IsNull("confirm2_date") != true) { mysql_sb.AppendLine(",'" + dr["confirm2_date"].ToString() + "'"); } else { mysql_sb.AppendLine(",null"); }
                                    // 確認3
                                    if (dr.IsNull("confirm3_id") != true) { mysql_sb.AppendLine("," + dr["confirm3_id"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    // 日付
                                    if (dr.IsNull("confirm3_date") != true) { mysql_sb.AppendLine(",'" + dr["confirm3_date"].ToString() + "'"); } else { mysql_sb.AppendLine(",null"); }
                                    // 営業認証
                                    if (dr.IsNull("sales_id") != true) { mysql_sb.AppendLine("," + dr["sales_id"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    // 日付
                                    if (dr.IsNull("sales_confirm_date") != true) { mysql_sb.AppendLine(",'" + dr["sales_confirm_date"].ToString() + "'"); } else { mysql_sb.AppendLine(",null"); }
                                    // 顧客認証
                                    if (dr.IsNull("guest_id") != true) { mysql_sb.AppendLine("," + dr["guest_id"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    // 日付
                                    if (dr.IsNull("guest_confirm_date") != true) { mysql_sb.AppendLine(",'" + dr["guest_confirm_date"].ToString() + "'"); } else { mysql_sb.AppendLine(",null"); }
                                    // 認証ステータス
                                    if (dr.IsNull("confirm,_status") != true) { mysql_sb.AppendLine("," + dr["confirm_status"].ToString()); } else { mysql_sb.AppendLine(",0"); }

                                    // 検温1回目～3回目
                                    if (dr.IsNull("temp1") != true) { mysql_sb.AppendLine("," + dr["temp1"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("temp2") != true) { mysql_sb.AppendLine("," + dr["temp2"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("temp3") != true) { mysql_sb.AppendLine("," + dr["temp3"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    // 検温時刻1回目～3回目
                                    if (dr.IsNull("temp_time1") != true) { mysql_sb.AppendLine(",'" + dr["temp_time1"].ToString() + "'"); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("temp_time2") != true) { mysql_sb.AppendLine(",'" + dr["temp_time2"].ToString() + "'"); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("temp_time3") != true) { mysql_sb.AppendLine(",'" + dr["temp_time3"].ToString() + "'"); } else { mysql_sb.AppendLine(",null"); }
                                    // アルコール濃度1回目～3回目
                                    if (dr.IsNull("alcohol1") != true) { mysql_sb.AppendLine("," + dr["alcohol1"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("alcohol2") != true) { mysql_sb.AppendLine("," + dr["alcohol2"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("alcohol3") != true) { mysql_sb.AppendLine("," + dr["alcohol3"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    // アルコールチェック結果1回目～3回目
                                    if (dr.IsNull("alcohol_check1") != true) { mysql_sb.AppendLine("," + dr["alcohol_check1"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("alcohol_check2") != true) { mysql_sb.AppendLine("," + dr["alcohol_check2"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("alcohol_check3") != true) { mysql_sb.AppendLine("," + dr["alcohol_check3"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    // 備考
                                    if (dr.IsNull("comment") != true) { mysql_sb.AppendLine(",'" + dr["comment"].ToString() + "'"); } else { mysql_sb.AppendLine(",''"); }
                                    // 同乗者有無
                                    if (dr.IsNull("passenger_id") != true) { mysql_sb.AppendLine("," + dr["passenger_id"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    // 運行前点検項目1～7
                                    if (dr.IsNull("inspection_check1") != true) { mysql_sb.AppendLine("," + dr["inspection_check1"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("inspection_check2") != true) { mysql_sb.AppendLine("," + dr["inspection_check2"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("inspection_check3") != true) { mysql_sb.AppendLine("," + dr["inspection_check3"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("inspection_check4") != true) { mysql_sb.AppendLine("," + dr["inspection_check4"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("inspection_check5") != true) { mysql_sb.AppendLine("," + dr["inspection_check5"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("inspection_check6") != true) { mysql_sb.AppendLine("," + dr["inspection_check6"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("inspection_check7") != true) { mysql_sb.AppendLine("," + dr["inspection_check7"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    // 定期点検項目1～14
                                    if (dr.IsNull("per_inspection_check1") != true) { mysql_sb.AppendLine("," + dr["per_inspection_check1"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("per_inspection_check2") != true) { mysql_sb.AppendLine("," + dr["per_inspection_check2"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("per_inspection_check3") != true) { mysql_sb.AppendLine("," + dr["per_inspection_check3"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("per_inspection_check4") != true) { mysql_sb.AppendLine("," + dr["per_inspection_check4"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("per_inspection_check5") != true) { mysql_sb.AppendLine("," + dr["per_inspection_check5"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("per_inspection_check6") != true) { mysql_sb.AppendLine("," + dr["per_inspection_check6"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("per_inspection_check7") != true) { mysql_sb.AppendLine("," + dr["per_inspection_check7"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("per_inspection_check8") != true) { mysql_sb.AppendLine("," + dr["per_inspection_check8"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("per_inspection_check9") != true) { mysql_sb.AppendLine("," + dr["per_inspection_check9"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("per_inspection_check10") != true) { mysql_sb.AppendLine("," + dr["per_inspection_check10"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("per_inspection_check11") != true) { mysql_sb.AppendLine("," + dr["per_inspection_check11"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("per_inspection_check12") != true) { mysql_sb.AppendLine("," + dr["per_inspection_check12"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("per_inspection_check13") != true) { mysql_sb.AppendLine("," + dr["per_inspection_check13"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("per_inspection_check14") != true) { mysql_sb.AppendLine("," + dr["per_inspection_check14"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    // 大型点検項目1～4
                                    if (dr.IsNull("large_inspection_check1") != true) { mysql_sb.AppendLine("," + dr["large_inspection_check1"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("large_inspection_check2") != true) { mysql_sb.AppendLine("," + dr["large_inspection_check2"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("large_inspection_check3") != true) { mysql_sb.AppendLine("," + dr["large_inspection_check3"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("large_inspection_check4") != true) { mysql_sb.AppendLine("," + dr["large_inspection_check4"].ToString()); } else { mysql_sb.AppendLine(",null"); }

                                    // 休憩開始時間1～3
                                    if (dr.IsNull("start_break_time1") != true) { mysql_sb.AppendLine(",'" + dr["start_break_time1"].ToString() + "'"); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("start_break_time2") != true) { mysql_sb.AppendLine(",'" + dr["start_break_time2"].ToString() + "'"); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("start_break_time3") != true) { mysql_sb.AppendLine(",'" + dr["start_break_time3"].ToString() + "'"); } else { mysql_sb.AppendLine(",null"); }
                                    // 休憩終了時間1～3
                                    if (dr.IsNull("end_break_time1") != true) { mysql_sb.AppendLine(",'" + dr["end_break_time1"].ToString() + "'"); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("end_break_time2") != true) { mysql_sb.AppendLine(",'" + dr["end_break_time2"].ToString() + "'"); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("end_break_time3") != true) { mysql_sb.AppendLine(",'" + dr["end_break_time3"].ToString() + "'"); } else { mysql_sb.AppendLine(",null"); }
                                    // 休憩時間1～3
                                    if (dr.IsNull("break_time1") != true) { mysql_sb.AppendLine("," + dr["break_time1"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("break_time2") != true) { mysql_sb.AppendLine("," + dr["break_time2"].ToString()); } else { mysql_sb.AppendLine(",null"); }
                                    if (dr.IsNull("break_time3") != true) { mysql_sb.AppendLine("," + dr["break_time3"].ToString()); } else { mysql_sb.AppendLine(",null"); }


                                    mysql_sb.AppendLine(")");
                                }

                                clsMySqlDb.DMLUpdate(mysql_sb.ToString());

                                exportCnt++;

                                // ProgressBar値セット
                                p_pgb.Value = exportCnt;
                                p_pgb.Refresh();
                            }
                        }
                    }
                }
                return exportCnt;
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// SELECT
        /// </summary>
        public void Select()
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" Trn_日報.id");
                    sb.AppendLine(",Trn_日報.location_id");
                    sb.AppendLine(",Trn_日報.car_id");
                    sb.AppendLine(",Trn_日報.day");
                    sb.AppendLine(",Trn_日報.instructor_id");
                    sb.AppendLine(",Trn_日報.staff_id1");
                    // 2026/01/13 DEL (S)
                    // sb.AppendLine(",Trn_日報.staff_id2");
                    // sb.AppendLine(",Trn_日報.staff_id3");
                    // 2026/01/13 DEL (E)
                    sb.AppendLine(",Trn_日報.after_meter");
                    sb.AppendLine(",Trn_日報.before_meter");
                    sb.AppendLine(",Trn_日報.mileage");
                    sb.AppendLine(",Trn_日報.fuel");
                    sb.AppendLine(",Trn_日報.fuel_meter");
                    sb.AppendLine(",Trn_日報.oil");
                    sb.AppendLine(",Trn_日報.kerosene");
                    // 2025/01/13 DEL (S)
                    // sb.AppendLine(",Trn_日報.start_location");
                    // sb.AppendLine(",Trn_日報.end_location");
                    // 2025/01/13 DEL (E)
                    // 2026/01/30 ADD (S)
                    sb.AppendLine(",Trn_日報.work_start_time");
                    sb.AppendLine(",Trn_日報.work_finish_time");
                    // 2026/01/30 ADD (E)
                    sb.AppendLine(",Trn_日報.start_time1");
                    sb.AppendLine(",Trn_日報.start_time2");
                    sb.AppendLine(",Trn_日報.start_time3");
                    sb.AppendLine(",Trn_日報.end_time1");
                    sb.AppendLine(",Trn_日報.end_time2");
                    sb.AppendLine(",Trn_日報.end_time3");

                    sb.AppendLine(",Trn_日報.over_time1");
                    sb.AppendLine(",Trn_日報.over_time2");
                    sb.AppendLine(",Trn_日報.over_time3");
                    sb.AppendLine(",Trn_日報.start_over_time1");
                    sb.AppendLine(",Trn_日報.start_over_time2");
                    sb.AppendLine(",Trn_日報.start_over_time3");
                    sb.AppendLine(",Trn_日報.end_over_time1");
                    sb.AppendLine(",Trn_日報.end_over_time2");
                    sb.AppendLine(",Trn_日報.end_over_time3");
                    sb.AppendLine(",Trn_日報.start_over_time_kbn1");
                    sb.AppendLine(",Trn_日報.start_over_time_kbn2");
                    sb.AppendLine(",Trn_日報.start_over_time_kbn3");
                    sb.AppendLine(",Trn_日報.end_over_time_kbn1");
                    sb.AppendLine(",Trn_日報.end_over_time_kbn2");
                    sb.AppendLine(",Trn_日報.end_over_time_kbn3");
                    sb.AppendLine(",Trn_日報.start_over_time_comment1");
                    sb.AppendLine(",Trn_日報.start_over_time_comment2");
                    sb.AppendLine(",Trn_日報.start_over_time_comment3");
                    sb.AppendLine(",Trn_日報.end_over_time_comment1");
                    sb.AppendLine(",Trn_日報.end_over_time_comment2");
                    sb.AppendLine(",Trn_日報.end_over_time_comment3");
                    // 代車フラグ
                    sb.AppendLine(",Trn_日報.subcar_flag");
                    // 同乗者有無
                    sb.AppendLine(",Trn_日報.passenger_id");
                    // 確認・承認
                    sb.AppendLine(",Trn_日報.confirm1_id");
                    sb.AppendLine(",Trn_日報.confirm1_date");
                    sb.AppendLine(",Trn_日報.confirm2_id");
                    sb.AppendLine(",Trn_日報.confirm2_date");
                    sb.AppendLine(",Trn_日報.confirm3_id");
                    sb.AppendLine(",Trn_日報.confirm3_date");
                    sb.AppendLine(",Trn_日報.sales_id");
                    sb.AppendLine(",Trn_日報.sales_confirm_date");
                    sb.AppendLine(",Trn_日報.guest_id");
                    sb.AppendLine(",Trn_日報.guest_confirm_date");
                    sb.AppendLine(",Trn_日報.confirm_status");
                    
                    // 休憩時間
                    sb.AppendLine(",Trn_日報.start_break_time1");
                    sb.AppendLine(",Trn_日報.end_break_time1");
                    sb.AppendLine(",Trn_日報.start_break_time2");
                    sb.AppendLine(",Trn_日報.end_break_time2");
                    sb.AppendLine(",Trn_日報.start_break_time3");
                    sb.AppendLine(",Trn_日報.end_break_time3");

                    sb.AppendLine(",Mst_専従先.fullname AS FullNameLocation");
                    sb.AppendLine(",Mst_専従先.closing_date");
                    sb.AppendLine(",Mst_専従先車両.no");
                    sb.AppendLine(",Mst_専従先車両.fullname AS FullNameCar");
                    sb.AppendLine(",Mst_社員A.fullname AS FullNameA");
                    sb.AppendLine(",Mst_社員B.fullname AS FullNameB");
                    // 確認・承認
                    sb.AppendLine(",Mst_社員C.fullname AS FullNameC");
                    sb.AppendLine(",Mst_社員D.fullname AS FullNameD");
                    sb.AppendLine(",Mst_社員E.fullname AS FullNameE");
                    sb.AppendLine(",Mst_社員F.fullname AS FullNameF");
                    sb.AppendLine(",Mst_専従先担当者.user_name AS FullNameG");

                    sb.AppendLine("FROM");
                    sb.AppendLine("Trn_日報");

                    sb.AppendLine("LEFT JOIN");
                    sb.AppendLine("Mst_専従先");
                    sb.AppendLine("ON");
                    sb.AppendLine("Trn_日報.location_id = Mst_専従先.id");

                    sb.AppendLine("LEFT JOIN");
                    sb.AppendLine("Mst_専従先車両");
                    sb.AppendLine("ON");
                    sb.AppendLine("Trn_日報.car_id = Mst_専従先車両.id");

                    sb.AppendLine("LEFT JOIN");
                    sb.AppendLine("Mst_社員 AS Mst_社員A");
                    sb.AppendLine("ON");
                    sb.AppendLine("Trn_日報.instructor_id = Mst_社員A.staff_id");

                    sb.AppendLine("LEFT JOIN");
                    sb.AppendLine("Mst_社員 AS Mst_社員B");
                    sb.AppendLine("ON");
                    sb.AppendLine("Trn_日報.staff_id1 = Mst_社員B.staff_id");

                    // 確認・承認
                    sb.AppendLine("LEFT JOIN");
                    sb.AppendLine("Mst_社員 AS Mst_社員C");
                    sb.AppendLine("ON");
                    sb.AppendLine("Trn_日報.confirm1_id = Mst_社員C.staff_id");

                    sb.AppendLine("LEFT JOIN");
                    sb.AppendLine("Mst_社員 AS Mst_社員D");
                    sb.AppendLine("ON");
                    sb.AppendLine("Trn_日報.confirm2_id = Mst_社員D.staff_id");

                    sb.AppendLine("LEFT JOIN");
                    sb.AppendLine("Mst_社員 AS Mst_社員E");
                    sb.AppendLine("ON");
                    sb.AppendLine("Trn_日報.confirm3_id = Mst_社員E.staff_id");

                    sb.AppendLine("LEFT JOIN");
                    sb.AppendLine("Mst_社員 AS Mst_社員F");
                    sb.AppendLine("ON");
                    sb.AppendLine("Trn_日報.sales_id = Mst_社員F.staff_id");

                    sb.AppendLine("LEFT JOIN");
                    sb.AppendLine("Mst_専従先担当者");
                    sb.AppendLine("ON");
                    sb.AppendLine("Trn_日報.guest_id = Mst_専従先担当者.id");

                    sb.AppendLine("WHERE");
                    sb.AppendLine("1 = 1");

                    // 日報ID指定有無
                    if (this.Key_report_id != 0)
                    {
                        sb.AppendLine("AND");
                        sb.AppendLine("Trn_日報.id = " + this.Key_report_id);
                    }
                    // 日付指定有無
                    if (this.Key_from_day != null)
                    {
                        sb.AppendLine("AND");
                        sb.AppendLine("Trn_日報.day >= '" + this.Key_from_day.ToString("yyyy/MM/dd") + "'");
                        sb.AppendLine("AND");
                        sb.AppendLine("Trn_日報.day <= '" + this.Key_to_day.ToString("yyyy/MM/dd") + "'");
                    }
                    // 専従先指定有無
                    if (this.Key_location_id != 0)
                    {
                        sb.AppendLine("AND");
                        sb.AppendLine("Trn_日報.location_id = " + this.Key_location_id.ToString());
                    }
                    // 車両指定有無
                    if (this.Key_car_id != 0)
                    {
                        sb.AppendLine("AND");
                        sb.AppendLine("Trn_日報.car_id = " + this.Key_car_id.ToString());
                    }
                    // 担当者指定有無
                    if (this.Key_staff_id != 0)
                    {
                        sb.AppendLine("AND");
                        sb.AppendLine("Trn_日報.staff_id1 = " + this.Key_staff_id.ToString());
                    }
                    // 締め日
                    if (this.Key_closing_date > 0)
                    {
                        sb.AppendLine("AND");
                        sb.AppendLine("Mst_専従先.closing_date = " + this.Key_closing_date.ToString());
                    }
                    // 社内チェック
                    if (this.Key_confirm1 == 0)
                    {
                        sb.AppendLine("AND");
                        sb.AppendLine("Trn_日報.confirm1_id = 0");
                        sb.AppendLine("AND");
                        sb.AppendLine("Trn_日報.confirm2_id = 0");
                        sb.AppendLine("AND");
                        sb.AppendLine("Trn_日報.confirm3_id = 0");
                    }
                    else if (this.Key_confirm1 == 1)
                    {
                        sb.AppendLine("AND");
                        sb.AppendLine("(Trn_日報.confirm1_id > 0");
                        sb.AppendLine("OR");
                        sb.AppendLine("Trn_日報.confirm2_id > 0");
                        sb.AppendLine("OR");
                        sb.AppendLine("Trn_日報.confirm3_id > 0)");
                    }
                    // 管理責任者確認
                    if (this.Key_confirm2 == 0)
                    {
                        sb.AppendLine("AND");
                        sb.AppendLine("Trn_日報.sales_id = 0");
                    }
                    else if (this.Key_confirm2 == 1)
                    {
                        sb.AppendLine("AND");
                        sb.AppendLine("Trn_日報.sales_id > 0");
                    }
                    // お客様確認
                    if (this.Key_confirm3 == 0)
                    {
                        sb.AppendLine("AND");
                        sb.AppendLine("Trn_日報.guest_id = 0");
                    }
                    else if (this.Key_confirm3 == 1)
                    {
                        sb.AppendLine("AND");
                        sb.AppendLine("Trn_日報.guest_id > 0");
                    }

                    // 2026/01/16 UPD (S)
                    //sb.AppendLine("ORDER BY");
                    //sb.AppendLine(" Trn_日報.location_id");
                    //sb.AppendLine(",Trn_日報.car_id");
                    //sb.AppendLine(",Trn_日報.day");
                    sb.AppendLine("ORDER BY");
                    sb.AppendLine(" Trn_日報.location_id ASC");
                    sb.AppendLine(",Trn_日報.car_id ASC");
                    sb.AppendLine(",Trn_日報.day ASC");
                    sb.AppendLine(",CASE WHEN Trn_日報.start_time1 IS NULL THEN 1 ELSE 0 END ASC");
                    sb.AppendLine(",Trn_日報.start_time1 ASC");
                    // 2026/01/16 UPD (E)

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        // Select結果
                        this.Select_count = dt_val.Rows.Count;              // 件数
                        this.Dt = dt_val;                                   // DataTable
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
        /// 日報IDから日報データを取得
        /// </summary>
        public void SelectFromID()
        {
            try
            {
                sb.Clear();
                sb.AppendLine("SELECT");
                sb.AppendLine(" Trn_日報.id");                                                           // ID
                sb.AppendLine(",Trn_日報.location_id");                                             // 専従先ID 
                sb.AppendLine(",Mst_専従先.fullname AS location_name");              // 専従先名 
                sb.AppendLine(",Trn_日報.car_id");                                                    // 車両ID  
                sb.AppendLine(",Mst_専従先車両.no AS car_no");                             // 車両No
                sb.AppendLine(",Mst_専従先車両.fullname AS car_fullname");         // 車両名
                sb.AppendLine(",Trn_日報.day");                                                        // 日付
                sb.AppendLine(",Trn_日報.instructor_id");                                         // 指導員ID
                sb.AppendLine(",Mst_社員A.fullname AS instructor_name");           // 指導員名
                sb.AppendLine(",Trn_日報.staff_id1");                                               // 担当者1ID 
                sb.AppendLine(",Mst_社員B.fullname AS staff_name1");                 // 担当者1名
                sb.AppendLine(",Trn_日報.after_meter");                                          // 走行後メーター
                sb.AppendLine(",Trn_日報.before_meter");                                       // 走行前メーター 
                sb.AppendLine(",Trn_日報.mileage");                                                // 走行距離
                sb.AppendLine(",Trn_日報.fuel");                                                       // 燃料
                sb.AppendLine(",Trn_日報.fuel_meter");                                            // 燃料メーター
                sb.AppendLine(",Trn_日報.oil");                                                          // オイル    
                sb.AppendLine(",Trn_日報.kerosene");                                               // 灯油
                // 2025/01/13 ADD (S)
                // sb.AppendLine(",Trn_日報.start_location");
                // sb.AppendLine(",Trn_日報.end_location");
                // 2025/01/13 ADD (E)
                // 2026/01/30 ADD (S)
                sb.AppendLine(",Trn_日報.work_start_time");
                sb.AppendLine(",Trn_日報.work_finish_time");
                // 2026/01/30 ADD (E)
                sb.AppendLine(",Trn_日報.start_time1");
                sb.AppendLine(",Trn_日報.start_time2");
                sb.AppendLine(",Trn_日報.start_time3");
                sb.AppendLine(",Trn_日報.end_time1");
                sb.AppendLine(",Trn_日報.end_time2");
                sb.AppendLine(",Trn_日報.end_time3");

                sb.AppendLine(",Trn_日報.over_time1");
                sb.AppendLine(",Trn_日報.over_time2");
                sb.AppendLine(",Trn_日報.over_time3");

                sb.AppendLine(",Trn_日報.start_over_time1");
                sb.AppendLine(",Trn_日報.start_over_time2");
                sb.AppendLine(",Trn_日報.start_over_time3");

                sb.AppendLine(",Trn_日報.end_over_time1");
                sb.AppendLine(",Trn_日報.end_over_time2");
                sb.AppendLine(",Trn_日報.end_over_time3");

                sb.AppendLine(",Trn_日報.start_over_time_kbn1");
                sb.AppendLine(",Trn_日報.start_over_time_kbn2");
                sb.AppendLine(",Trn_日報.start_over_time_kbn3");

                sb.AppendLine(",Trn_日報.end_over_time_kbn1");
                sb.AppendLine(",Trn_日報.end_over_time_kbn2");
                sb.AppendLine(",Trn_日報.end_over_time_kbn3");

                sb.AppendLine(",Trn_日報.start_over_time_comment1");
                sb.AppendLine(",Trn_日報.start_over_time_comment2");
                sb.AppendLine(",Trn_日報.start_over_time_comment3");

                sb.AppendLine(",Trn_日報.end_over_time_comment1");
                sb.AppendLine(",Trn_日報.end_over_time_comment2");
                sb.AppendLine(",Trn_日報.end_over_time_comment3");

                sb.AppendLine(",Trn_日報.subcar_flag");

                sb.AppendLine(",Trn_日報.confirm1_id");
                sb.AppendLine(",Trn_日報.confirm1_date");
                sb.AppendLine(",Trn_日報.confirm2_id");
                sb.AppendLine(",Trn_日報.confirm2_date");
                sb.AppendLine(",Trn_日報.confirm3_id");
                sb.AppendLine(",Trn_日報.confirm3_date");
                sb.AppendLine(",Trn_日報.sales_id");                                              // 管理責任者ID
                sb.AppendLine(",Trn_日報.sales_confirm_date");                            // 管理責任者確認日
                sb.AppendLine(",Trn_日報.guest_id");                                              // お客様確認ID
                sb.AppendLine(",Trn_日報.guest_confirm_date");                            // お客様確認日
                sb.AppendLine(",Trn_日報.confirm_status");

                sb.AppendLine(",Mst_社員C.fullname AS confirm1_name");
                sb.AppendLine(",Mst_社員D.fullname AS confirm2_name");
                sb.AppendLine(",Mst_社員E.fullname AS confirm3_name");
                sb.AppendLine(",Mst_社員F.fullname AS sales_name");
                sb.AppendLine(",Mst_専従先担当者.user_name AS guest_name");

                sb.AppendLine(",Trn_日報.temp1");
                sb.AppendLine(",Trn_日報.temp2");
                sb.AppendLine(",Trn_日報.temp3");
                sb.AppendLine(",Trn_日報.temp_time1");
                sb.AppendLine(",Trn_日報.temp_time2");
                sb.AppendLine(",Trn_日報.temp_time3");
                sb.AppendLine(",Trn_日報.alcohol1");
                sb.AppendLine(",Trn_日報.alcohol2");
                sb.AppendLine(",Trn_日報.alcohol3");
                sb.AppendLine(",Trn_日報.alcohol_check1");
                sb.AppendLine(",Trn_日報.alcohol_check2");
                sb.AppendLine(",Trn_日報.alcohol_check3");

                sb.AppendLine(",Trn_日報.comment");
                sb.AppendLine(",Trn_日報.passenger_id");

                sb.AppendLine(",Trn_日報.inspection_check1");
                sb.AppendLine(",Trn_日報.inspection_check2");
                sb.AppendLine(",Trn_日報.inspection_check3");
                sb.AppendLine(",Trn_日報.inspection_check4");
                sb.AppendLine(",Trn_日報.inspection_check5");
                sb.AppendLine(",Trn_日報.inspection_check6");
                sb.AppendLine(",Trn_日報.inspection_check7");

                sb.AppendLine(",Trn_日報.per_inspection_check1");
                sb.AppendLine(",Trn_日報.per_inspection_check2");
                sb.AppendLine(",Trn_日報.per_inspection_check3");
                sb.AppendLine(",Trn_日報.per_inspection_check4");
                sb.AppendLine(",Trn_日報.per_inspection_check5");
                sb.AppendLine(",Trn_日報.per_inspection_check6");
                sb.AppendLine(",Trn_日報.per_inspection_check7");
                sb.AppendLine(",Trn_日報.per_inspection_check8");
                sb.AppendLine(",Trn_日報.per_inspection_check9");
                sb.AppendLine(",Trn_日報.per_inspection_check10");
                sb.AppendLine(",Trn_日報.per_inspection_check11");
                sb.AppendLine(",Trn_日報.per_inspection_check12");
                sb.AppendLine(",Trn_日報.per_inspection_check13");
                sb.AppendLine(",Trn_日報.per_inspection_check14");

                sb.AppendLine(",Trn_日報.large_inspection_check1");
                sb.AppendLine(",Trn_日報.large_inspection_check2");
                sb.AppendLine(",Trn_日報.large_inspection_check3");
                sb.AppendLine(",Trn_日報.large_inspection_check4");

                sb.AppendLine(",Trn_日報.start_break_time1");
                sb.AppendLine(",Trn_日報.start_break_time2");
                sb.AppendLine(",Trn_日報.start_break_time3");
                sb.AppendLine(",Trn_日報.end_break_time1");
                sb.AppendLine(",Trn_日報.end_break_time2");
                sb.AppendLine(",Trn_日報.end_break_time3");
                sb.AppendLine(",Trn_日報.break_time1");
                sb.AppendLine(",Trn_日報.break_time2");
                sb.AppendLine(",Trn_日報.break_time3");

                sb.AppendLine("FROM");
                sb.AppendLine("Trn_日報");
                sb.AppendLine("LEFT JOIN");
                sb.AppendLine("Mst_専従先");
                sb.AppendLine("ON");
                sb.AppendLine("Trn_日報.location_id = Mst_専従先.location_id");

                sb.AppendLine("LEFT JOIN");
                sb.AppendLine("Mst_専従先車両");
                sb.AppendLine("ON");
                sb.AppendLine("Trn_日報.car_id = Mst_専従先車両.id");

                sb.AppendLine("LEFT JOIN");
                sb.AppendLine("Mst_社員 AS Mst_社員A");
                sb.AppendLine("ON");
                sb.AppendLine("Trn_日報.instructor_id = Mst_社員A.staff_id");

                sb.AppendLine("LEFT JOIN");
                sb.AppendLine("Mst_社員 AS Mst_社員B");
                sb.AppendLine("ON");
                sb.AppendLine("Trn_日報.staff_id1 = Mst_社員B.staff_id");

                sb.AppendLine("LEFT JOIN");
                sb.AppendLine("Mst_社員 AS Mst_社員C");
                sb.AppendLine("ON");
                sb.AppendLine("Trn_日報.confirm1_id = Mst_社員C.staff_id");

                sb.AppendLine("LEFT JOIN");
                sb.AppendLine("Mst_社員 AS Mst_社員D");
                sb.AppendLine("ON");
                sb.AppendLine("Trn_日報.confirm2_id = Mst_社員D.staff_id");

                sb.AppendLine("LEFT JOIN");
                sb.AppendLine("Mst_社員 AS Mst_社員E");
                sb.AppendLine("ON");
                sb.AppendLine("Trn_日報.confirm3_id = Mst_社員E.staff_id");

                sb.AppendLine("LEFT JOIN");
                sb.AppendLine("Mst_社員 AS Mst_社員F");
                sb.AppendLine("ON");
                sb.AppendLine("Trn_日報.sales_id = Mst_社員F.staff_id");

                // ==============================================================
                // guest_id ==>> 専従先担当者テーブルとJOIN
                // ==============================================================
                sb.AppendLine("LEFT JOIN");
                sb.AppendLine("Mst_専従先担当者");
                sb.AppendLine("ON");
                sb.AppendLine("Trn_日報.guest_id = Mst_専従先担当者.id");

                sb.AppendLine("WHERE");
                sb.AppendLine("Trn_日報.id = " + this.Key_report_id);

                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        // Select結果
                        this.Select_count = dt_val.Rows.Count;          // 件数
                        this.Dt = dt_val;                               // DataTable
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
        /// CSV出力対象日報データSELECT
        /// </summary>
        public void SelectCsv()
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" Trn_日報.id");
                    sb.AppendLine(",Trn_日報.location_id");
                    sb.AppendLine(",Trn_日報.car_id");
                    sb.AppendLine(",Trn_日報.day");
                    sb.AppendLine(",Trn_日報.staff_id1");
                    sb.AppendLine(",Trn_日報.after_meter");
                    sb.AppendLine(",Trn_日報.before_meter");
                    sb.AppendLine(",Trn_日報.mileage");
                    sb.AppendLine(",Trn_日報.fuel");
                    sb.AppendLine(",Trn_日報.fuel_meter");
                    sb.AppendLine(",Trn_日報.start_time1");
                    sb.AppendLine(",Trn_日報.start_time2");
                    sb.AppendLine(",Trn_日報.start_time3");
                    sb.AppendLine(",Trn_日報.end_time1");
                    sb.AppendLine(",Trn_日報.end_time2");
                    sb.AppendLine(",Trn_日報.end_time3");

                    sb.AppendLine(",Mst_専従先.fullname AS FullNameLocation");
                    sb.AppendLine(",Mst_専従先.closing_date");

                    sb.AppendLine(",Mst_専従先車両.no");
                    sb.AppendLine(",Mst_専従先車両.fullname AS FullNameCar");

                    sb.AppendLine(",Mst_社員.fullname AS FullName");
                    sb.AppendLine(",Mst_社員.group_id");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Trn_日報");

                    sb.AppendLine("LEFT JOIN");
                    sb.AppendLine("Mst_専従先");
                    sb.AppendLine("ON");
                    sb.AppendLine("Trn_日報.location_id = Mst_専従先.id");

                    sb.AppendLine("LEFT JOIN");
                    sb.AppendLine("Mst_専従先車両");
                    sb.AppendLine("ON");
                    sb.AppendLine("Trn_日報.car_id = Mst_専従先車両.id");

                    sb.AppendLine("LEFT JOIN");
                    sb.AppendLine("Mst_社員 AS Mst_社員");
                    sb.AppendLine("ON");
                    sb.AppendLine("Trn_日報.staff_id1 = Mst_社員.staff_id");

                    sb.AppendLine("WHERE");
                    sb.AppendLine("1 = 1");

                    // 日報ID指定有無
                    if (this.Key_report_id != 0)
                    {
                        sb.AppendLine("AND");
                        sb.AppendLine("Trn_日報.id = " + this.Key_report_id);
                    }
                    // 日付指定有無
                    if (this.Key_from_day != null)
                    {
                        sb.AppendLine("AND");
                        sb.AppendLine("Trn_日報.day >= '" + this.Key_from_day.ToString("yyyy/MM/dd") + "'");
                        sb.AppendLine("AND");
                        sb.AppendLine("Trn_日報.day <= '" + this.Key_to_day.ToString("yyyy/MM/dd") + "'");
                    }
                    // 専従先指定有無
                    if (this.Key_location_id != 0)
                    {
                        sb.AppendLine("AND");
                        sb.AppendLine("Trn_日報.location_id = " + this.Key_location_id.ToString());
                    }
                    // 車両指定有無
                    if (this.Key_car_id != 0)
                    {
                        sb.AppendLine("AND");
                        sb.AppendLine("Trn_日報.car_id = " + this.Key_car_id.ToString());
                    }
                    // 担当者指定有無
                    if (this.Key_staff_id != 0)
                    {
                        sb.AppendLine("AND");
                        sb.AppendLine("Trn_日報.staff_id1 = " + this.Key_staff_id.ToString());
                    }
                    // 締め日
                    if (this.Key_closing_date > 0)
                    {
                        sb.AppendLine("AND");
                        sb.AppendLine("Mst_専従先.closing_date = " + this.Key_closing_date.ToString());
                    }

                    // 2026/01/16 UPD (S)
                    //sb.AppendLine("ORDER BY");
                    //sb.AppendLine(" Trn_日報.location_id ASC");
                    //sb.AppendLine(",Trn_日報.staff_id1 ASC");
                    //sb.AppendLine(",Trn_日報.day ASC");
                    sb.AppendLine("ORDER BY");
                    sb.AppendLine(" Trn_日報.location_id ASC");
                    sb.AppendLine(",Trn_日報.staff_id1 DESC");
                    sb.AppendLine(",Trn_日報.car_id ASC");
                    sb.AppendLine(",Trn_日報.day ASC");
                    sb.AppendLine(",CASE WHEN Trn_日報.start_time1 IS NULL THEN 1 ELSE 0 END ASC");
                    sb.AppendLine(",Trn_日報.start_time1 ASC");
                    // 2026/01/16 UPD (E)

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        // Select結果
                        this.Select_count = dt_val.Rows.Count;              // 件数
                        this.Dt = dt_val;                                   // DataTable
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
        /// UPDATE
        /// </summary>
        public void Update()
        {
            try
            {
                // =======================================================
                // Trn_日報
                // =======================================================
                sb.Clear();
                sb.AppendLine("UPDATE");
                sb.AppendLine("Trn_日報");
                sb.AppendLine("SET");
                // 日付
                sb.AppendLine(" day = '" + this.Day.ToString("yyyy/MM/dd") + "'");

                // 始業開始・終了前作業時間
                if (this.Work_Start_time.ToString("yyyy/MM/dd HH:mm:ss") == "1900/01/01 00:00:00") { sb.AppendLine(",work_start_time = null"); }
                else { sb.AppendLine(",work_start_time = '" + this.Work_Start_time.ToString() + "'"); }
                if (this.Work_Finish_time.ToString("yyyy/MM/dd HH:mm:ss") == "1900/01/01 00:00:00") { sb.AppendLine(",work_finish_time = null"); }
                else { sb.AppendLine(",work_finish_time = '" + this.Work_Finish_time.ToString() + "'"); }

                // 開始・終了時間
                if (this.Start_time1.ToString("yyyy/MM/dd HH:mm:ss") == "1900/01/01 00:00:00") { sb.AppendLine(",start_time1 = null"); }
                else { sb.AppendLine(",start_time1 = '" + this.Start_time1.ToString() + "'"); }
                if (this.Start_time2.ToString("yyyy/MM/dd HH:mm:ss") == "1900/01/01 00:00:00") { sb.AppendLine(",start_time2 = null"); }
                else { sb.AppendLine(",start_time2 = '" + this.Start_time2.ToString() + "'"); }
                if (this.Start_time3.ToString("yyyy/MM/dd HH:mm:ss") == "1900/01/01 00:00:00") { sb.AppendLine(",start_time3 = null"); }
                else { sb.AppendLine(",start_time3 = '" + this.Start_time3.ToString() + "'"); }
                if (this.End_time1.ToString("yyyy/MM/dd HH:mm:ss") == "1900/01/01 00:00:00") { sb.AppendLine(",end_time1 = null"); }
                else { sb.AppendLine(",end_time1 = '" + this.End_time1.ToString() + "'"); }
                if (this.End_time2.ToString("yyyy/MM/dd HH:mm:ss") == "1900/01/01 00:00:00") { sb.AppendLine(",end_time2 = null"); }
                else { sb.AppendLine(",end_time2 = '" + this.End_time2.ToString() + "'"); }
                if (this.End_time3.ToString("yyyy/MM/dd HH:mm:ss") == "1900/01/01 00:00:00") { sb.AppendLine(",end_time3 = null"); }
                else { sb.AppendLine(",end_time3 = '" + this.End_time3.ToString() + "'"); }

                // 残業時間
                //if (this.Over_time1 == 0) { sb.AppendLine(",over_time1 = null"); }
                //else { sb.AppendLine(",over_time1 = " + this.Over_time1.ToString()); }
                //if (this.Over_time2 == 0) { sb.AppendLine(",over_time2 = null"); }
                //else { sb.AppendLine(",over_time2 = " + this.Over_time2.ToString()); }
                //if (this.Over_time3 == 0) { sb.AppendLine(",over_time3 = null"); }
                //else { sb.AppendLine(",over_time3 = " + this.Over_time3.ToString()); }
                // 未入力時は0い更新
                if (this.Over_time1 == 0) { sb.AppendLine(",over_time1 = 0"); }
                else { sb.AppendLine(",over_time1 = " + this.Over_time1.ToString()); }
                if (this.Over_time2 == 0) { sb.AppendLine(",over_time2 = 0"); }
                else { sb.AppendLine(",over_time2 = " + this.Over_time2.ToString()); }
                if (this.Over_time3 == 0) { sb.AppendLine(",over_time3 = 0"); }
                else { sb.AppendLine(",over_time3 = " + this.Over_time3.ToString()); }

                // 始業残業
                //if (this.Start_over_time1 == 0) { sb.AppendLine(",start_over_time1 = null"); }
                //else { sb.AppendLine(",start_over_time1 = " + this.Start_over_time1.ToString()); }
                //if (this.Start_over_time2 == 0) { sb.AppendLine(",start_over_time2 = null"); }
                //else { sb.AppendLine(",start_over_time2 = " + this.Start_over_time2.ToString()); }
                //if (this.Start_over_time3 == 0) { sb.AppendLine(",start_over_time3 = null"); }
                //else { sb.AppendLine(",start_over_time3 = " + this.Start_over_time3.ToString()); }
                // 未入力時は0い更新
                if (this.Start_over_time1 == 0) { sb.AppendLine(",start_over_time1 = 0"); }
                else { sb.AppendLine(",start_over_time1 = " + this.Start_over_time1.ToString()); }
                if (this.Start_over_time2 == 0) { sb.AppendLine(",start_over_time2 = 0"); }
                else { sb.AppendLine(",start_over_time2 = " + this.Start_over_time2.ToString()); }
                if (this.Start_over_time3 == 0) { sb.AppendLine(",start_over_time3 = 0"); }
                else { sb.AppendLine(",start_over_time3 = " + this.Start_over_time3.ToString()); }

                // 終業残業
                //if (this.End_over_time1 == 0) { sb.AppendLine(",end_over_time1 = null"); }
                //else { sb.AppendLine(",end_over_time1 = " + this.End_over_time1.ToString()); }
                //if (this.End_over_time2 == 0) { sb.AppendLine(",end_over_time2 = null"); }
                //else { sb.AppendLine(",end_over_time2 = " + this.End_over_time2.ToString()); }
                //if (this.End_over_time3 == 0) { sb.AppendLine(",end_over_time3 = null"); }
                //else { sb.AppendLine(",end_over_time3 = " + this.End_over_time3.ToString()); }
                // 未入力時は0い更新
                if (this.End_over_time1 == 0) { sb.AppendLine(",end_over_time1 = 0"); }
                else { sb.AppendLine(",end_over_time1 = " + this.End_over_time1.ToString()); }
                if (this.End_over_time2 == 0) { sb.AppendLine(",end_over_time2 = 0"); }
                else { sb.AppendLine(",end_over_time2 = " + this.End_over_time2.ToString()); }
                if (this.End_over_time3 == 0) { sb.AppendLine(",end_over_time3 = 0"); }
                else { sb.AppendLine(",end_over_time3 = " + this.End_over_time3.ToString()); }

                // 始業残業区分
                if (this.Start_over_time_kbn1 == 0) { sb.AppendLine(",start_over_time_kbn1 = null"); }
                else { sb.AppendLine(",start_over_time_kbn1 = " + this.Start_over_time_kbn1.ToString()); }
                if (this.Start_over_time_kbn2 == 0) { sb.AppendLine(",start_over_time_kbn2 = null"); }
                else { sb.AppendLine(",start_over_time_kbn2 = " + this.Start_over_time_kbn2.ToString()); }
                if (this.Start_over_time_kbn3 == 0) { sb.AppendLine(",start_over_time_kbn3 = null"); }
                else { sb.AppendLine(",start_over_time_kbn3 = " + this.Start_over_time_kbn3.ToString()); }

                // 終業残業区分
                if (this.End_over_time_kbn1 == 0) { sb.AppendLine(",end_over_time_kbn1 = null"); }
                else { sb.AppendLine(",end_over_time_kbn1 = " + this.End_over_time_kbn1.ToString()); }
                if (this.End_over_time_kbn2 == 0) { sb.AppendLine(",end_over_time_kbn2 = null"); }
                else { sb.AppendLine(",end_over_time_kbn2 = " + this.End_over_time_kbn2.ToString()); }
                if (this.End_over_time_kbn3 == 0) { sb.AppendLine(",end_over_time_kbn3 = null"); }
                else { sb.AppendLine(",end_over_time_kbn3 = " + this.End_over_time_kbn3.ToString()); }

                // 始業残業理由
                sb.AppendLine(",start_over_time_comment1 = '" + this.Start_over_time_comment1 + "'");
                sb.AppendLine(",start_over_time_comment2 = '" + this.Start_over_time_comment2 + "'");
                sb.AppendLine(",start_over_time_comment3 = '" + this.Start_over_time_comment3 + "'");

                // 終業残業理由
                sb.AppendLine(",end_over_time_comment1 = '" + this.End_over_time_comment1 + "'");
                sb.AppendLine(",end_over_time_comment2 = '" + this.End_over_time_comment2 + "'");
                sb.AppendLine(",end_over_time_comment3 = '" + this.End_over_time_comment3 + "'");

                // メーター
                if (this.After_meter == 0) { sb.AppendLine(",after_meter = null"); }
                else { sb.AppendLine(",after_meter = " + this.After_meter.ToString()); }
                if (this.Before_meter == 0) { sb.AppendLine(",before_meter = null"); }
                else { sb.AppendLine(",before_meter = " + this.Before_meter.ToString()); }
                if (this.Mileage == 0) { sb.AppendLine(",mileage = null"); }
                else { sb.AppendLine(",mileage = " + this.Mileage.ToString()); }
                // 給油
                if (this.Fuel == 0) { sb.AppendLine(",fuel = null"); }
                else { sb.AppendLine(",fuel = " + this.Fuel.ToString()); }
                if (this.Fuel_meter == 0) { sb.AppendLine(",fuel_meter = null"); }
                else { sb.AppendLine(",fuel_meter = " + this.Fuel_meter.ToString()); }
                if (this.Oil == 0) { sb.AppendLine(",oil = null"); }
                else { sb.AppendLine(",oil = " + this.Oil.ToString()); }
                if (this.Kerosene == 0) { sb.AppendLine(",kerosene = null"); }
                else { sb.AppendLine(",kerosene = " + this.Kerosene.ToString()); }
                // 代車識別
                if (this.Subcar_flag == 0) { sb.AppendLine(",subcar_flag = 0"); }
                else { sb.AppendLine(",subcar_flag = " + this.Subcar_flag.ToString()); }
 
                // 承認
                sb.AppendLine(",confirm1_id = " + this.Confirm1_id.ToString());
                if (this.Confirm1_date.ToString("yyyy/MM/dd HH:mm:ss") == "1900/01/01 00:00:00") { sb.AppendLine(",confirm1_date = null"); }
                else { sb.AppendLine(",confirm1_date = '" + this.Confirm1_date.ToString() + "'"); }

                sb.AppendLine(",confirm2_id = " + this.Confirm2_id.ToString());
                if (this.Confirm2_date.ToString("yyyy/MM/dd HH:mm:ss") == "1900/01/01 00:00:00") { sb.AppendLine(",confirm2_date = null"); }
                else { sb.AppendLine(",confirm2_date = '" + this.Confirm2_date.ToString() + "'"); }

                sb.AppendLine(",confirm3_id = " + this.Confirm3_id.ToString());
                if (this.Confirm3_date.ToString("yyyy/MM/dd HH:mm:ss") == "1900/01/01 00:00:00") { sb.AppendLine(",confirm3_date = null"); }
                else { sb.AppendLine(",confirm3_date = '" + this.Confirm3_date.ToString() + "'"); }

                sb.AppendLine(",sales_id = " + this.Sales_id.ToString());
                if (this.Sales_confirm_date.ToString("yyyy/MM/dd HH:mm:ss") == "1900/01/01 00:00:00") { sb.AppendLine(",sales_confirm_date = null"); }
                else { sb.AppendLine(",sales_confirm_date = '" + this.Sales_confirm_date.ToString() + "'"); }

                sb.AppendLine(",guest_id = " + this.Guest_id.ToString());
                if (this.Guest_confirm_date.ToString("yyyy/MM/dd HH:mm:ss") == "1900/01/01 00:00:00") { sb.AppendLine(",guest_confirm_date = null"); }
                else { sb.AppendLine(",guest_confirm_date = '" + this.Guest_confirm_date.ToString() + "'"); }

                sb.AppendLine(",confirm_status = " + this.Confirm_status.ToString());

                // 検温
                if (this.Temp1 == 0) { sb.AppendLine(",temp1 = null"); }
                else { sb.AppendLine(",temp1 = " + this.Temp1.ToString()); }
                if (this.Temp2 == 0) { sb.AppendLine(",temp2 = null"); }
                else { sb.AppendLine(",temp2 = " + this.Temp2.ToString()); }
                if (this.Temp3 == 0) { sb.AppendLine(",temp3 = null"); }
                else { sb.AppendLine(",temp3 = " + this.Temp3.ToString()); }
                if (this.Temp_time1.ToString("yyyy/MM/dd HH:mm:ss") == "1900/01/01 00:00:00") { sb.AppendLine(",temp_time1 = null"); }
                else { sb.AppendLine(",temp_time1 = '" + this.Temp_time1.ToString() + "'"); }
                if (this.Temp_time2.ToString("yyyy/MM/dd HH:mm:ss") == "1900/01/01 00:00:00") { sb.AppendLine(",temp_time2 = null"); }
                else { sb.AppendLine(",temp_time2 = '" + this.Temp_time2.ToString() + "'"); }
                if (this.Temp_time3.ToString("yyyy/MM/dd HH:mm:ss") == "1900/01/01 00:00:00") { sb.AppendLine(",temp_time3 = null"); }
                else { sb.AppendLine(",temp_time3 = '" + this.Temp_time3.ToString() + "'"); }
                // アルコールチェック
                if (this.Alcohol1 == -1) { sb.AppendLine(",alcohol1 = null"); }
                else { sb.AppendLine(",alcohol1 = " + this.Alcohol1.ToString()); }
                if (this.Alcohol2 == -1) { sb.AppendLine(",alcohol2 = null"); }
                else { sb.AppendLine(",alcohol2 = " + this.Alcohol2.ToString()); }
                if (this.Alcohol3 == -1) { sb.AppendLine(",alcohol3 = null"); }
                else { sb.AppendLine(",alcohol3 = " + this.Alcohol3.ToString()); }
                if (this.Alcohol_check1 == -1) { sb.AppendLine(",alcohol_check1 = null"); }
                else { sb.AppendLine(",alcohol_check1 = " + this.Alcohol_check1.ToString()); }
                if (this.Alcohol_check2 == -1) { sb.AppendLine(",alcohol_check2 = null"); }
                else { sb.AppendLine(",alcohol_check2 = " + this.Alcohol_check2.ToString()); }
                if (this.Alcohol_check3 == -1) { sb.AppendLine(",alcohol_check3 = null"); }
                else { sb.AppendLine(",alcohol_check3 = " + this.Alcohol_check3.ToString()); }

                // 備考
                sb.AppendLine(",comment = '" + this.Comment + "'");
                sb.AppendLine(",passenger_id = " + this.Passenger_id.ToString());

                //// 運行前点検
                //if (this.Inspection_check1 == -1) { sb.AppendLine(" inspection_check1 = null"); }
                //else { sb.AppendLine(" inspection_check1 = " + this.Inspection_check1.ToString()); }
                //if (this.Inspection_check2 == -1) { sb.AppendLine(",inspection_check2 = null"); }
                //else { sb.AppendLine(",inspection_check2 = " + this.Inspection_check2.ToString()); }
                //if (this.Inspection_check3 == -1) { sb.AppendLine(",inspection_check3 = null"); }
                //else { sb.AppendLine(",inspection_check3 = " + this.Inspection_check3.ToString()); }
                //if (this.Inspection_check4 == -1) { sb.AppendLine(",inspection_check4 = null"); }
                //else { sb.AppendLine(",inspection_check4 = " + this.Inspection_check4.ToString()); }
                //if (this.Inspection_check5 == -1) { sb.AppendLine(",inspection_check5 = null"); }
                //else { sb.AppendLine(",inspection_check5 = " + this.Inspection_check5.ToString()); }
                //if (this.Inspection_check6 == -1) { sb.AppendLine(",inspection_check6 = null"); }
                //else { sb.AppendLine(",inspection_check6 = " + this.Inspection_check6.ToString()); }
                //if (this.Inspection_check7 == -1) { sb.AppendLine(",inspection_check7 = null"); }
                //else { sb.AppendLine(",inspection_check7 = " + this.Inspection_check7.ToString()); }

                //// 定期点検
                //if (this.Per_inspection_check1 == -1) { sb.AppendLine(" per_inspection_check1 = null"); }
                //else { sb.AppendLine(" per_inspection_check1 = " + this.Per_inspection_check1.ToString()); }
                //if (this.Per_inspection_check2 == -1) { sb.AppendLine(",per_inspection_check2 = null"); }
                //else { sb.AppendLine(",per_inspection_check2 = " + this.Per_inspection_check2.ToString()); }
                //if (this.Per_inspection_check3 == -1) { sb.AppendLine(",per_inspection_check3 = null"); }
                //else { sb.AppendLine(",per_inspection_check3 = " + this.Per_inspection_check3.ToString()); }
                //if (this.Per_inspection_check4 == -1) { sb.AppendLine(",per_inspection_check4 = null"); }
                //else { sb.AppendLine(",per_inspection_check4 = " + this.Per_inspection_check4.ToString()); }
                //if (this.Per_inspection_check5 == -1) { sb.AppendLine(",per_inspection_check5 = null"); }
                //else { sb.AppendLine(",per_inspection_check5 = " + this.Per_inspection_check5.ToString()); }
                //if (this.Per_inspection_check6 == -1) { sb.AppendLine(",per_inspection_check6 = null"); }
                //else { sb.AppendLine(",per_inspection_check6 = " + this.Per_inspection_check6.ToString()); }
                //if (this.Per_inspection_check7 == -1) { sb.AppendLine(",per_inspection_check7 = null"); }
                //else { sb.AppendLine(",per_inspection_check7 = " + this.Per_inspection_check7.ToString()); }
                //if (this.Per_inspection_check8 == -1) { sb.AppendLine(",per_inspection_check8 = null"); }
                //else { sb.AppendLine(",per_inspection_check8 = " + this.Per_inspection_check8.ToString()); }
                //if (this.Per_inspection_check9 == -1) { sb.AppendLine(",per_inspection_check9 = null"); }
                //else { sb.AppendLine(",per_inspection_check9 = " + this.Per_inspection_check9.ToString()); }
                //if (this.Per_inspection_check10 == -1) { sb.AppendLine(",per_inspection_check10 = null"); }
                //else { sb.AppendLine(",per_inspection_check10 = " + this.Per_inspection_check10.ToString()); }
                //if (this.Per_inspection_check11 == -1) { sb.AppendLine(",per_inspection_check11 = null"); }
                //else { sb.AppendLine(",per_inspection_check11 = " + this.Per_inspection_check11.ToString()); }
                //if (this.Per_inspection_check12 == -1) { sb.AppendLine(",per_inspection_check12 = null"); }
                //else { sb.AppendLine(",per_inspection_check12 = " + this.Per_inspection_check12.ToString()); }
                //if (this.Per_inspection_check13 == -1) { sb.AppendLine(",per_inspection_check13 = null"); }
                //else { sb.AppendLine(",per_inspection_check13 = " + this.Per_inspection_check13.ToString()); }
                //if (this.Per_inspection_check14 == -1) { sb.AppendLine(",per_inspection_check14 = null"); }
                //else { sb.AppendLine(",per_inspection_check14 = " + this.Per_inspection_check14.ToString()); }

                //// 大型点検
                //if (this.Large_inspection_check1 == -1) { sb.AppendLine(" large_inspection_check1 = null"); }
                //else { sb.AppendLine(" large_inspection_check1 = " + this.Large_inspection_check1.ToString()); }
                //if (this.Large_inspection_check2 == -1) { sb.AppendLine(",large_inspection_check2 = null"); }
                //else { sb.AppendLine(",large_inspection_check2 = " + this.Large_inspection_check2.ToString()); }
                //if (this.Large_inspection_check3 == -1) { sb.AppendLine(",large_inspection_check3 = null"); }
                //else { sb.AppendLine(",large_inspection_check3 = " + this.Large_inspection_check3.ToString()); }
                //if (this.Large_inspection_check4 == -1) { sb.AppendLine(",large_inspection_check4 = null"); }
                //else { sb.AppendLine(",large_inspection_check4 = " + this.Large_inspection_check4.ToString()); }

                // 休憩開始時間
                if (this.Start_break_time1.ToString("yyyy/MM/dd HH:mm:ss") == "1900/01/01 00:00:00") { sb.AppendLine(",start_break_time1 = null"); }
                else { sb.AppendLine(",start_break_time1 = '" + this.Start_break_time1.ToString() + "'"); }
                if (this.Start_break_time2.ToString("yyyy/MM/dd HH:mm:ss") == "1900/01/01 00:00:00") { sb.AppendLine(",start_break_time2 = null"); }
                else { sb.AppendLine(",start_break_time2 = '" + this.Start_break_time2.ToString() + "'"); }
                if (this.Start_break_time3.ToString("yyyy/MM/dd HH:mm:ss") == "1900/01/01 00:00:00") { sb.AppendLine(",start_break_time3 = null"); }
                else { sb.AppendLine(",start_break_time3 = '" + this.Start_break_time3.ToString() + "'"); }

                // 休憩終了時間
                if (this.End_break_time1.ToString("yyyy/MM/dd HH:mm:ss") == "1900/01/01 00:00:00") { sb.AppendLine(",end_break_time1 = null"); }
                else { sb.AppendLine(",end_break_time1 = '" + this.End_break_time1.ToString() + "'"); }
                if (this.End_break_time2.ToString("yyyy/MM/dd HH:mm:ss") == "1900/01/01 00:00:00") { sb.AppendLine(",end_break_time2 = null"); }
                else { sb.AppendLine(",end_break_time2 = '" + this.End_break_time2.ToString() + "'"); }
                if (this.End_break_time3.ToString("yyyy/MM/dd HH:mm:ss") == "1900/01/01 00:00:00") { sb.AppendLine(",end_break_time3 = null"); }
                else { sb.AppendLine(",end_break_time3 = '" + this.End_break_time3.ToString() + "'"); }

                // 休憩時間
                if (this.Break_time1 == 0) { sb.AppendLine(",break_time1 = null"); }
                else { sb.AppendLine(",break_time1 = " + this.Break_time1.ToString()); }
                if (this.Break_time2 == 0) { sb.AppendLine(",break_time2 = null"); }
                else { sb.AppendLine(",break_time2 = " + this.Break_time2.ToString()); }
                if (this.Break_time3 == 0) { sb.AppendLine(",break_time3 = null"); }
                else { sb.AppendLine(",break_time3 = " + this.Break_time3.ToString()); }

                // 2025/11/11↓
                sb.AppendLine(",upd_user_id = " + ClsLoginUser.StaffID);
                sb.AppendLine(",upd_date = '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                // 2025/11/11↑

                sb.AppendLine("WHERE");
                sb.AppendLine("id = " + this.Key_report_id.ToString());

                // ==================================================
                // SQL Server
                // ==================================================
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    clsSqlDb.DMLUpdate(sb.ToString());
                }
                // XServerは更新しない
                // ==================================================
                // XServer
                // ==================================================
                //using (ClsMySqlDb clsMySqlDb = new(ClsDbConfig.MySQLNo))
                //{
                //    clsMySqlDb.DMLUpdate(sb.ToString());
                //}
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// Insert (XServer)
        /// </summary>
        public void Insert()
        {
            // var add_id = 0;

            try
            {
                //// MySQL登録
                //using (clsDb xDb = new clsDb(clsPublic.XSERVER_DB))
                //{
                //    st.Length = 0;
                //    st.AppendLine("INSERT INTO");
                //    st.AppendLine("Trn_日報");
                //    st.AppendLine("(");
                //    // st.AppendLine(" id");
                //    st.AppendLine(" car_id");
                //    st.AppendLine(",car_name");
                //    st.AppendLine(",used_user_id");
                //    st.AppendLine(",used_user_name");
                //    st.AppendLine(",day");
                //    st.AppendLine(",start_time");
                //    st.AppendLine(",end_time");
                //    st.AppendLine(",start_odo");
                //    st.AppendLine(",end_odo");
                //    st.AppendLine(",distance");
                //    st.AppendLine(",check_distance");
                //    st.AppendLine(",check_alcohol");
                //    st.AppendLine(",maintenance");
                //    st.AppendLine(",result_maintenance");
                //    st.AppendLine(",from_point");
                //    st.AppendLine(",to_point");
                //    st.AppendLine(",note");
                //    st.AppendLine(",gas_stock");
                //    st.AppendLine(",delete_flag");
                //    st.AppendLine(") VALUES (");
                //    // st.AppendLine(id.ToString());
                //    // car id
                //    st.AppendLine(car_id.ToString());
                //    // car name
                //    st.AppendLine(",'" + car_name + "'");
                //    // used user id
                //    st.AppendLine("," + used_user_id);
                //    // used user name
                //    st.AppendLine(",'" + used_user_name + "'");
                //    // day
                //    st.AppendLine(",'" + day + "'");
                //    // start time
                //    st.AppendLine(",'" + start_time.ToString() + "'");
                //    // end time
                //    st.AppendLine(",'" + end_time.ToString() + "'");
                //    // start odo
                //    if (start_odo == -1)
                //    {
                //        st.AppendLine(",null");
                //    }
                //    else
                //    {
                //        st.AppendLine("," + start_odo);
                //    }
                //    // end odo
                //    if (end_odo == -1)
                //    {
                //        st.AppendLine(",null");
                //    }
                //    else
                //    {
                //        st.AppendLine("," + end_odo);
                //    }
                //    // distance
                //    if (distance == -1)
                //    {
                //        st.AppendLine(",null");
                //    }
                //    else
                //    {
                //        st.AppendLine("," + distance);
                //    }
                //    // check distance
                //    st.AppendLine(",0");
                //    // check alcohol
                //    if (check_alcohol == -1)
                //    {
                //        st.AppendLine(",null");
                //    }
                //    else
                //    {
                //        st.AppendLine("," + check_alcohol);
                //    }
                //    // maintenance
                //    st.AppendLine(",null");
                //    // result maintenance
                //    st.AppendLine(",null");
                //    // from point
                //    st.AppendLine(",'" + from_point + "'");
                //    // to point
                //    st.AppendLine(",'" + to_point + "'");
                //    // note
                //    st.AppendLine(",'" + note + "'");
                //    // gas stock
                //    if (gas_stock == -1)
                //    {
                //        st.AppendLine(",null");
                //    }
                //    else
                //    {
                //        st.AppendLine("," + gas_stock);
                //    }
                //    // delete flag
                //    st.AppendLine("," + delete_flag);
                //    st.AppendLine(")");

                //    xDb.Sql = st.ToString();
                //    xDb.DMLUpdate();

                //    // 登録レコードのID取得　(car_id, used_user_id, day, start_time)
                //    st.Length = 0;
                //    st.AppendLine("SELECT");
                //    st.AppendLine("id");
                //    st.AppendLine("FROM");
                //    st.AppendLine("Trn_走行記録");
                //    st.AppendLine("WHERE");
                //    st.AppendLine("car_id = " + car_id);
                //    st.AppendLine("AND");
                //    st.AppendLine("used_user_id = " + used_user_id);
                //    st.AppendLine("AND");
                //    st.AppendLine("day = '" + day.ToString("yyyy/MM/dd") + "'");
                //    st.AppendLine("AND");
                //    st.AppendLine("start_time = '" + start_time + "'");

                //    xDb.Sql = st.ToString();
                //    xDb.DMLSelect();

                //    foreach (DataRow dr in xDb.dt.Rows)
                //    {
                //        add_id = int.Parse(dr["id"].ToString());
                //        break;
                //    }
                //}

                //// SQL Serverへ登録
                //using (clsDb sDb = new clsDb(clsPublic.DBNo))
                //{
                //    st.Length = 0;
                //    st.AppendLine("INSERT INTO");
                //    st.AppendLine("Trn_走行記録");
                //    st.AppendLine("(");
                //    st.AppendLine(" id");
                //    st.AppendLine(",car_id");
                //    st.AppendLine(",car_name");
                //    st.AppendLine(",used_user_id");
                //    st.AppendLine(",used_user_name");
                //    st.AppendLine(",day");
                //    st.AppendLine(",start_time");
                //    st.AppendLine(",end_time");
                //    st.AppendLine(",start_odo");
                //    st.AppendLine(",end_odo");
                //    st.AppendLine(",distance");
                //    st.AppendLine(",check_distance");
                //    st.AppendLine(",check_alcohol");
                //    st.AppendLine(",maintenance");
                //    st.AppendLine(",result_maintenance");
                //    st.AppendLine(",from_point");
                //    st.AppendLine(",to_point");
                //    st.AppendLine(",note");
                //    st.AppendLine(",gas_stock");
                //    st.AppendLine(",delete_flag");
                //    st.AppendLine(") VALUES (");
                //    st.AppendLine(add_id.ToString());
                //    // car id
                //    st.AppendLine("," + car_id);
                //    // car name
                //    st.AppendLine(",'" + car_name + "'");
                //    // used user id
                //    st.AppendLine("," + used_user_id);
                //    // used user name
                //    st.AppendLine(",'" + used_user_name + "'");
                //    // day
                //    st.AppendLine(",'" + day + "'");
                //    // start time
                //    st.AppendLine(",'" + start_time.ToString() + "'");
                //    // end time
                //    st.AppendLine(",'" + end_time.ToString() + "'");
                //    // start odo
                //    if (start_odo == -1)
                //    {
                //        st.AppendLine(",null");
                //    }
                //    else
                //    {
                //        st.AppendLine("," + start_odo);
                //    }
                //    // end odo
                //    if (end_odo == -1)
                //    {
                //        st.AppendLine(",null");
                //    }
                //    else
                //    {
                //        st.AppendLine("," + end_odo);
                //    }
                //    // distance
                //    if (distance == -1)
                //    {
                //        st.AppendLine(",null");
                //    }
                //    else
                //    {
                //        st.AppendLine("," + distance);
                //    }
                //    // check distance
                //    st.AppendLine(",0");
                //    // check alcohol
                //    if (check_alcohol == -1)
                //    {
                //        st.AppendLine(",null");
                //    }
                //    else
                //    {
                //        st.AppendLine("," + check_alcohol);
                //    }
                //    // maintenance
                //    st.AppendLine(",null");
                //    // result maintenance
                //    st.AppendLine(",null");
                //    // from point
                //    st.AppendLine(",'" + from_point + "'");
                //    // to point
                //    st.AppendLine(",'" + to_point + "'");
                //    // note
                //    st.AppendLine(",'" + note + "'");
                //    // gas stock
                //    if (gas_stock == -1)
                //    {
                //        st.AppendLine(",null");
                //    }
                //    else
                //    {
                //        st.AppendLine("," + gas_stock);
                //    }
                //    // delete flag
                //    st.AppendLine("," + delete_flag);
                //    st.AppendLine(")");

                //    sDb.Sql = st.ToString();
                //    sDb.DMLUpdate();
                //}
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 過去データ削除
        /// </summary>
        public void DeleteDate()
        {
            try
            {
                // SQL Server側
                //using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                //{
                //    sb.Clear();
                //    sb.AppendLine("DELETE FROM");
                //    sb.AppendLine("Trn_日報");
                //    sb.AppendLine("WHERE");
                //    sb.AppendLine(",day <= '" + Delete_date + "'");
                //    clsSqlDb.DMLUpdate(sb.ToString());
                //}
                // MySQL側
                using (ClsMySqlDb clsMySqlDb = new(ClsDbConfig.MySQLNo))
                {
                    sb.Clear();
                    sb.AppendLine("DELETE FROM");
                    sb.AppendLine("Trn_日報");
                    sb.AppendLine("WHERE");
                    sb.AppendLine(",day <= '" + Delete_date + "'");
                    clsMySqlDb.DMLUpdate(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
        }

    }
}
