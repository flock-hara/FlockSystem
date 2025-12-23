using FlockAppC.pubClass;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FlockAppC.tblClass
{
    public class ClsTrnCarRun
    {
        /// <summary>
        /// データ絞り込み条件
        /// </summary>
        public DateTime Srch_start_date { get; set; }
        public DateTime Srch_end_date { get; set; }
        public int Srch_car_id { get; set; }
        public int Srch_staff_id { get; set; }
        /// <summary>
        /// 削除日付（基準日）
        /// </summary>
        public DateTime Delete_date { get; set; }


        /// <summary>
        /// 走行記録データ
        /// </summary>
        public int Id { get; set; }
        public int Car_id { get; set; }
        public string Car_name { get; set; }
        public int Used_user_id { get; set; }
        public string Used_user_name { get; set; }
        public DateTime Day { get; set; }
        public DateTime Start_time { get; set; }
        public DateTime End_time { get; set; }
        public int Start_odo { get; set; }
        public int End_odo { get; set; }
        public int Distance { get; set; }
        public int Check_distance { get; set; }
        public int Check_alcohol { get; set; }
        public int Maintenance { get; set; }
        public int Result_maintenance { get; set; }
        public string From_point { get; set; }
        public string To_point { get; set; }
        public string Note { get; set; }
        public decimal Gas_stock { get; set; }
        public int Delete_flag { get; set; }

        private readonly StringBuilder sb = new();

        /// <summary>
        /// 走行記録データインポート
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
                        sb.Clear();
                        sb.AppendLine("SELECT");
                        sb.AppendLine(" id");
                        sb.AppendLine(",car_id");
                        sb.AppendLine(",car_name");
                        sb.AppendLine(",used_user_id");
                        sb.AppendLine(",used_user_name");
                        sb.AppendLine(",day");
                        sb.AppendLine(",start_time");
                        sb.AppendLine(",end_time");
                        sb.AppendLine(",start_odo");
                        sb.AppendLine(",end_odo");
                        sb.AppendLine(",distance");
                        sb.AppendLine(",check_distance");
                        sb.AppendLine(",check_alcohol");
                        sb.AppendLine(",maintenance");
                        sb.AppendLine(",result_maintenance");
                        sb.AppendLine(",from_point");
                        sb.AppendLine(",to_point");
                        sb.AppendLine(",note");
                        sb.AppendLine(",gas_stock");
                        // 2025/11/10↓
                        sb.AppendLine(",ins_user_id");
                        sb.AppendLine(",ins_date");
                        sb.AppendLine(",upd_user_id");
                        sb.AppendLine(",upd_date");
                        sb.AppendLine(",delete_flag");
                        // 2025/11/10↑
                        sb.AppendLine("FROM");
                        sb.AppendLine("Trn_走行記録");
                        sb.AppendLine("WHERE");
                        sb.AppendLine("day >= '" + Srch_start_date.ToString("yyyy/MM/dd") + "'");
                        sb.AppendLine("AND");
                        sb.AppendLine("day <= '" + Srch_end_date.ToString("yyyy/MM/dd") + "'");
                        if (Srch_staff_id != -1)
                        {
                            // 利用者の指定有り
                            sb.AppendLine("AND");
                            sb.AppendLine("used_user_id = " + Srch_staff_id.ToString());
                        }
                        if (Srch_car_id != -1)
                        {
                            // 社用車の指定有り
                            sb.AppendLine("AND");
                            sb.AppendLine("car_id = " + Srch_car_id.ToString());
                        }

                        using (DataTable dt_val = clsMySqlDb.DMLSelect(sb.ToString()))
                        {
                            // 件数0の場合はメッセージ出力、処理終了
                            var rec_cnt = dt_val.Rows.Count;
                            if (rec_cnt <= 0)
                            {
                                MessageBox.Show("条件を満たす走行データがありません。", "結果", MessageBoxButtons.OK);
                                return 0;
                            }

                            // ProgressBar設定
                            p_pgb.Visible = true;
                            p_pgb.Maximum = rec_cnt;

                            // MySQL走行記録データ読み込み
                            DataTable dt_val2;
                            foreach (DataRow dr in dt_val.Rows)
                            {
                                // SQL Server登録チェック（未登録時はINSERT）
                                sb.Clear();
                                sb.AppendLine("SELECT");
                                sb.AppendLine("id");
                                sb.AppendLine("FROM");
                                sb.AppendLine("Trn_走行記録");
                                sb.AppendLine("WHERE");
                                sb.AppendLine("id = " + dr["id"].ToString());

                                dt_val2 = clsSqlDb.DMLSelect(sb.ToString());

                                // 該当レコード判定
                                if (dt_val2.Rows.Count > 0)
                                {
                                    // 該当レコード有り（UPDATE）
                                    sb.Clear();
                                    sb.AppendLine("UPDATE");
                                    sb.AppendLine("Trn_走行記録");
                                    sb.AppendLine("SET");
                                    sb.AppendLine(" car_id = " + dr["car_id"].ToString());
                                    sb.AppendLine(",car_name = '" + dr["car_name"].ToString() + "'");
                                    sb.AppendLine(",Used_user_id = " + dr["used_user_id"].ToString());
                                    sb.AppendLine(",used_user_name = '" + dr["used_user_name"].ToString() + "'");
                                    sb.AppendLine(",day = '" + dr["day"].ToString() + "'");
                                    if (dr.IsNull("start_time") == true)
                                    {
                                        sb.AppendLine(",start_time = null");
                                    }
                                    else
                                    {
                                        sb.AppendLine(",start_time = '" + dr["start_time"].ToString() + "'");
                                    }
                                    if (dr.IsNull("end_time") == true)
                                    {
                                        sb.AppendLine(",end_time = null");
                                    }
                                    else
                                    {
                                        sb.AppendLine(",end_time = '" + dr["end_time"].ToString() + "'");
                                    }
                                    if (dr.IsNull("start_odo") == true)
                                    {
                                        sb.AppendLine(",start_odo = null");
                                    }
                                    else
                                    {
                                        sb.AppendLine(",start_odo = " + dr["start_odo"].ToString());
                                    }
                                    if (dr.IsNull("end_odo") == true)
                                    {
                                        sb.AppendLine(",end_odo = null");
                                    }
                                    else
                                    {
                                        sb.AppendLine(",end_odo = " + dr["end_odo"].ToString());
                                    }
                                    if (dr.IsNull("distance") == true)
                                    {
                                        sb.AppendLine(",distance = null");
                                    }
                                    else
                                    {
                                        sb.AppendLine(",distance = " + dr["distance"].ToString());
                                    }
                                    if (dr.IsNull("check_distance") == true)
                                    {
                                        sb.AppendLine(",check_distance = null");
                                    }
                                    else
                                    {
                                        sb.AppendLine(",check_distance = " + dr["check_distance"].ToString());
                                    }
                                    if (dr.IsNull("check_alcohol") == true)
                                    {
                                        sb.AppendLine(",check_alcohol = null");
                                    }
                                    else
                                    {
                                        sb.AppendLine(",check_alcohol = " + dr["check_alcohol"].ToString());
                                    }
                                    if (dr.IsNull("maintenance") == true)
                                    {
                                        sb.AppendLine(",maintenance = null");
                                    }
                                    else
                                    {
                                        sb.AppendLine(",maintenance = " + dr["maintenance"].ToString());
                                    }
                                    if (dr.IsNull("result_maintenance") == true)
                                    {
                                        sb.AppendLine(",result_maintenance = null");
                                    }
                                    else
                                    {
                                        sb.AppendLine(",result_maintenance = " + dr["result_maintenance"].ToString());
                                    }
                                    sb.AppendLine(",from_point = '" + dr["from_point"].ToString() + "'");
                                    sb.AppendLine(",to_point = '" + dr["to_point"].ToString() + "'");
                                    sb.AppendLine(",note = '" + dr["note"].ToString() + "'");
                                    if (dr.IsNull("gas_stock") == true)
                                    {
                                        sb.AppendLine(",gas_stock = null");
                                    }
                                    else
                                    {
                                        sb.AppendLine(",gas_stock = " + dr["gas_stock"].ToString());
                                    }

                                    // 2025/11/10↓
                                    if (dr.IsNull("ins_user_id") != true) { sb.AppendLine(",ins_user_id = " + dr["ins_user_id"].ToString()); }
                                    else { sb.AppendLine(",ins_user_id = 0"); }
                                    if (dr.IsNull("ins_date") != true) { sb.AppendLine(",ins_date = '" + dr["ins_date"].ToString() + "'"); }
                                    else { sb.AppendLine(",ins_date = null"); }
                                    if (dr.IsNull("upd_user_id") != true) { sb.AppendLine(",upd_user_id = " + dr["upd_user_id"].ToString()); }
                                    else { sb.AppendLine(",upd_user_id = 0"); }
                                    if (dr.IsNull("upd_date") != true) { sb.AppendLine(",upd_date = '" + dr["upd_date"].ToString() + "'"); }
                                    else { sb.AppendLine(",upd_date = null"); }
                                    if (dr.IsNull("delete_flag") != true) { sb.AppendLine(",delete_flag = " + dr["delete_flag"].ToString()); }
                                    else { sb.AppendLine(",delete_flag = " + ClsPublic.FLAG_OFF); }
                                    // 2025/11/10↑

                                    sb.AppendLine("WHERE");
                                    sb.AppendLine("id = " + dr["id"].ToString());
                                }
                                else
                                {
                                    // 該当レコード無し（INSERT）
                                    sb.Clear();
                                    sb.AppendLine("INSERT INTO");
                                    sb.AppendLine("Trn_走行記録");
                                    sb.AppendLine("(");
                                    sb.AppendLine(" id");
                                    sb.AppendLine(",car_id");
                                    sb.AppendLine(",car_name");
                                    sb.AppendLine(",used_user_id");
                                    sb.AppendLine(",used_user_name");
                                    sb.AppendLine(",day");
                                    sb.AppendLine(",start_time");
                                    sb.AppendLine(",end_time");
                                    sb.AppendLine(",start_odo");
                                    sb.AppendLine(",end_odo");
                                    sb.AppendLine(",distance");
                                    sb.AppendLine(",check_distance");
                                    sb.AppendLine(",check_alcohol");
                                    sb.AppendLine(",maintenance");
                                    sb.AppendLine(",result_maintenance");
                                    sb.AppendLine(",from_point");
                                    sb.AppendLine(",to_point");
                                    sb.AppendLine(",note");
                                    sb.AppendLine(",gas_stock");
                                    // 2025/11/10↓
                                    sb.AppendLine(",ins_user_id");
                                    sb.AppendLine(",ins_date");
                                    sb.AppendLine(",upd_user_id");
                                    sb.AppendLine(",upd_date");
                                    sb.AppendLine(",delete_flag");
                                    // 2025/11/10↑
                                    sb.AppendLine(") VALUES (");
                                    sb.AppendLine(dr["id"].ToString());
                                    sb.AppendLine("," + dr["car_id"].ToString());
                                    sb.AppendLine(",'" + dr["car_name"].ToString() + "'");
                                    sb.AppendLine("," + dr["used_user_id"].ToString());
                                    sb.AppendLine(",'" + dr["used_user_name"].ToString() + "'");
                                    sb.AppendLine(",'" + dr["day"].ToString() + "'");
                                    if (dr.IsNull("start_time") == true)
                                    {
                                        sb.AppendLine(",null");
                                    }
                                    else
                                    {
                                        sb.AppendLine(",'" + dr["start_time"].ToString() + "'");
                                    }
                                    if (dr.IsNull("end_time") == true)
                                    {
                                        sb.AppendLine(",null");
                                    }
                                    else
                                    {
                                        sb.AppendLine(",'" + dr["end_time"].ToString() + "'");
                                    }
                                    if (dr.IsNull("start_odo") == true)
                                    {
                                        sb.AppendLine(",null");
                                    }
                                    else
                                    {
                                        sb.AppendLine("," + dr["start_odo"].ToString());
                                    }
                                    if (dr.IsNull("end_odo") == true)
                                    {
                                        sb.AppendLine(",null");
                                    }
                                    else
                                    {
                                        sb.AppendLine("," + dr["end_odo"].ToString());
                                    }
                                    if (dr.IsNull("distance") == true)
                                    {
                                        sb.AppendLine(",null");
                                    }
                                    else
                                    {
                                        sb.AppendLine("," + dr["distance"].ToString());
                                    }
                                    if (dr.IsNull("check_distance") == true)
                                    {
                                        sb.AppendLine(",null");
                                    }
                                    else
                                    {
                                        sb.AppendLine("," + dr["check_distance"].ToString());
                                    }
                                    if (dr.IsNull("check_alcohol") == true)
                                    {
                                        sb.AppendLine(",null");
                                    }
                                    else
                                    {
                                        sb.AppendLine("," + dr["check_alcohol"].ToString());
                                    }
                                    if (dr.IsNull("maintenance") == true)
                                    {
                                        sb.AppendLine(",null");
                                    }
                                    else
                                    {
                                        sb.AppendLine("," + dr["maintenance"].ToString());
                                    }
                                    if (dr.IsNull("result_maintenance") == true)
                                    {
                                        sb.AppendLine(",null");
                                    }
                                    else
                                    {
                                        sb.AppendLine("," + dr["result_maintenance"].ToString());
                                    }
                                    sb.AppendLine(",'" + dr["from_point"].ToString() + "'");
                                    sb.AppendLine(",'" + dr["to_point"].ToString() + "'");
                                    sb.AppendLine(",'" + dr["note"].ToString() + "'");
                                    if (dr.IsNull("gas_stock") == true)
                                    {
                                        sb.AppendLine(",null");
                                    }
                                    else
                                    {
                                        sb.AppendLine("," + dr["gas_stock"].ToString());
                                    }
                                    // 2025/11/10↓
                                    if (dr.IsNull("ins_user_id") != true) { sb.AppendLine("," + dr["ins_user_id"].ToString()); }
                                    else { sb.AppendLine(",0"); }
                                    if (dr.IsNull("ins_date") != true) { sb.AppendLine(",'" + dr["ins_date"].ToString() + "'"); }
                                    else { sb.AppendLine(",null"); }
                                    if (dr.IsNull("upd_user_id") != true) { sb.AppendLine("," + dr["upd_user_id"].ToString()); }
                                    else { sb.AppendLine(",0"); }
                                    if (dr.IsNull("upd_date") != true) { sb.AppendLine(",'" + dr["upd_date"].ToString() + "'"); }
                                    else { sb.AppendLine(",null"); }
                                    if (dr.IsNull("delete_flag") != true) { sb.AppendLine("," + dr["delete_flag"].ToString()); }
                                    else { sb.AppendLine("," + ClsPublic.FLAG_OFF); }
                                    // 2025/11/10↑
                                    sb.AppendLine(")");
                                }

                                dt_val2.Dispose();

                                clsSqlDb.DMLUpdate(sb.ToString());

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
        /// UPDATE
        /// </summary>
        public void Update()
        {
            try
            {
                sb.Clear();
                sb.AppendLine("UPDATE");
                sb.AppendLine("Trn_走行記録");
                sb.AppendLine("SET");
                sb.AppendLine(" car_id = " + Car_id);
                sb.AppendLine(",car_name = '" + Car_name + "'");
                sb.AppendLine(",Used_user_id = " + Used_user_id);
                sb.AppendLine(",used_user_name = '" + Used_user_name + "'");
                sb.AppendLine(",day = '" + Day + "'");
                sb.AppendLine(",start_time = '" + Start_time.ToString() + "'");
                sb.AppendLine(",end_time = '" + End_time.ToString() + "'");

                if (Start_odo == -1)
                {
                    sb.AppendLine(",start_odo = null");
                }
                else
                {
                    sb.AppendLine(",start_odo = " + Start_odo);
                }

                if (End_odo == -1)
                {
                    sb.AppendLine(",end_odo = null");
                }
                else
                {
                    sb.AppendLine(",end_odo = " + End_odo);
                }

                if (Distance == -1)
                {
                    sb.AppendLine(",distance = null");
                }
                else
                {
                    sb.AppendLine(",distance = " + Distance);
                }

                sb.AppendLine(",check_distance = 0");

                if (Check_alcohol == -1)
                {
                    sb.AppendLine(",check_alcohol = null");
                }
                else
                {
                    sb.AppendLine(",check_alcohol = " + Check_alcohol);
                }
                sb.AppendLine(",maintenance = null");
                sb.AppendLine(",result_maintenance = null");
                sb.AppendLine(",from_point = '" + From_point + "'");
                sb.AppendLine(",to_point = '" + To_point + "'");
                sb.AppendLine(",note = '" + Note + "'");
                if (Gas_stock == -1)
                {
                    sb.AppendLine(",gas_stock = null");
                }
                else
                {
                    sb.AppendLine(",gas_stock = " + Gas_stock);
                }
                // 2025/11/12↓
                sb.AppendLine(",upd_user_id = " + ClsLoginUser.StaffID);
                sb.AppendLine(",upd_date = '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                // 2025/11/12↑
                sb.AppendLine(",delete_flag = " + Delete_flag);
                sb.AppendLine("WHERE");
                sb.AppendLine("id = " + Id);

                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    clsSqlDb.DMLUpdate(sb.ToString());
                }
                using (ClsMySqlDb clsMySqlDb = new(ClsDbConfig.MySQLNo))
                {
                    clsMySqlDb.DMLUpdate(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// INSERT
        /// </summary>
        public void Insert()
        {
            var add_id = 0;
            
            try
            {
                using (ClsMySqlDb clsMySqlDb = new(ClsDbConfig.MySQLNo))
                {
                    sb.Clear();
                    sb.AppendLine("INSERT INTO");
                    sb.AppendLine("Trn_走行記録");
                    sb.AppendLine("(");
                    sb.AppendLine(" car_id");
                    sb.AppendLine(",car_name");
                    sb.AppendLine(",used_user_id");
                    sb.AppendLine(",used_user_name");
                    sb.AppendLine(",day");
                    sb.AppendLine(",start_time");
                    sb.AppendLine(",end_time");
                    sb.AppendLine(",start_odo");
                    sb.AppendLine(",end_odo");
                    sb.AppendLine(",distance");
                    sb.AppendLine(",check_distance");
                    sb.AppendLine(",check_alcohol");
                    sb.AppendLine(",maintenance");
                    sb.AppendLine(",result_maintenance");
                    sb.AppendLine(",from_point");
                    sb.AppendLine(",to_point");
                    sb.AppendLine(",note");
                    sb.AppendLine(",gas_stock");
                    // 2025/11/12↓
                    sb.AppendLine(",ins_user_id");
                    sb.AppendLine(",ins_date");
                    // 2025/11/12↑
                    sb.AppendLine(",delete_flag");
                    sb.AppendLine(") VALUES (");
                    // sb.AppendLine(id.ToString());
                    // car id
                    sb.AppendLine(Car_id.ToString());
                    // car name
                    sb.AppendLine(",'" + Car_name + "'");
                    // used user id
                    sb.AppendLine("," + Used_user_id);
                    // used user name
                    sb.AppendLine(",'" + Used_user_name + "'");
                    // day
                    sb.AppendLine(",'" + Day + "'");
                    // start time
                    sb.AppendLine(",'" + Start_time.ToString() + "'");
                    // end time
                    sb.AppendLine(",'" + End_time.ToString() + "'");
                    // start odo
                    if (Start_odo == -1)
                    {
                        sb.AppendLine(",null");
                    }
                    else
                    {
                        sb.AppendLine("," + Start_odo);
                    }
                    // end odo
                    if (End_odo == -1)
                    {
                        sb.AppendLine(",null");
                    }
                    else
                    {
                        sb.AppendLine("," + End_odo);
                    }
                    // distance
                    if (Distance == -1)
                    {
                        sb.AppendLine(",null");
                    }
                    else
                    {
                        sb.AppendLine("," + Distance);
                    }
                    // check distance
                    sb.AppendLine(",0");
                    // check alcohol
                    if (Check_alcohol == -1)
                    {
                        sb.AppendLine(",null");
                    }
                    else
                    {
                        sb.AppendLine("," + Check_alcohol);
                    }
                    // maintenance
                    sb.AppendLine(",null");
                    // result maintenance
                    sb.AppendLine(",null");
                    // from point
                    sb.AppendLine(",'" + From_point + "'");
                    // to point
                    sb.AppendLine(",'" + To_point + "'");
                    // note
                    sb.AppendLine(",'" + Note + "'");
                    // gas stock
                    if (Gas_stock == -1)
                    {
                        sb.AppendLine(",null");
                    }
                    else
                    {
                        sb.AppendLine("," + Gas_stock);
                    }
                    // 2025/11/12↓
                    sb.AppendLine("," + ClsLoginUser.StaffID);
                    sb.AppendLine(",'" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    // 2025/11/12↑

                    // delete flag
                    sb.AppendLine("," + Delete_flag);
                    sb.AppendLine(")");

                    clsMySqlDb.DMLUpdate(sb.ToString());

                    // 登録レコードのID取得　(car_id, used_user_id, day, start_time)
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("id");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Trn_走行記録");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("car_id = " + Car_id);
                    sb.AppendLine("AND");
                    sb.AppendLine("used_user_id = " + Used_user_id);
                    sb.AppendLine("AND");
                    sb.AppendLine("day = '" + Day.ToString("yyyy/MM/dd") + "'");
                    sb.AppendLine("AND");
                    sb.AppendLine("start_time = '" + Start_time + "'");

                    using (DataTable dt_val = clsMySqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            add_id = int.Parse(dr["id"].ToString());
                            break;
                        }
                    }
                }

                // SQL Serverへ登録
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("INSERT INTO");
                    sb.AppendLine("Trn_走行記録");
                    sb.AppendLine("(");
                    sb.AppendLine(" id");
                    sb.AppendLine(",car_id");
                    sb.AppendLine(",car_name");
                    sb.AppendLine(",used_user_id");
                    sb.AppendLine(",used_user_name");
                    sb.AppendLine(",day");
                    sb.AppendLine(",start_time");
                    sb.AppendLine(",end_time");
                    sb.AppendLine(",start_odo");
                    sb.AppendLine(",end_odo");
                    sb.AppendLine(",distance");
                    sb.AppendLine(",check_distance");
                    sb.AppendLine(",check_alcohol");
                    sb.AppendLine(",maintenance");
                    sb.AppendLine(",result_maintenance");
                    sb.AppendLine(",from_point");
                    sb.AppendLine(",to_point");
                    sb.AppendLine(",note");
                    sb.AppendLine(",gas_stock");
                    // 2025/11/12↓
                    sb.AppendLine(",ins_user_id");
                    sb.AppendLine(",ins_date");
                    // 2025/11/12↑
                    sb.AppendLine(",delete_flag");
                    sb.AppendLine(") VALUES (");
                    sb.AppendLine(add_id.ToString());
                    // car id
                    sb.AppendLine("," + Car_id);
                    // car name
                    sb.AppendLine(",'" + Car_name + "'");
                    // used user id
                    sb.AppendLine("," + Used_user_id);
                    // used user name
                    sb.AppendLine(",'" + Used_user_name + "'");
                    // day
                    sb.AppendLine(",'" + Day + "'");
                    // start time
                    sb.AppendLine(",'" + Start_time.ToString() + "'");
                    // end time
                    sb.AppendLine(",'" + End_time.ToString() + "'");
                    // start odo
                    if (Start_odo == -1)
                    {
                        sb.AppendLine(",null");
                    }
                    else
                    {
                        sb.AppendLine("," + Start_odo);
                    }
                    // end odo
                    if (End_odo == -1)
                    {
                        sb.AppendLine(",null");
                    }
                    else
                    {
                        sb.AppendLine("," + End_odo);
                    }
                    // distance
                    if (Distance == -1)
                    {
                        sb.AppendLine(",null");
                    }
                    else
                    {
                        sb.AppendLine("," + Distance);
                    }
                    // check distance
                    sb.AppendLine(",0");
                    // check alcohol
                    if (Check_alcohol == -1)
                    {
                        sb.AppendLine(",null");
                    }
                    else
                    {
                        sb.AppendLine("," + Check_alcohol);
                    }
                    // maintenance
                    sb.AppendLine(",null");
                    // result maintenance
                    sb.AppendLine(",null");
                    // from point
                    sb.AppendLine(",'" + From_point + "'");
                    // to point
                    sb.AppendLine(",'" + To_point + "'");
                    // note
                    sb.AppendLine(",'" + Note + "'");
                    // gas stock
                    if (Gas_stock == -1)
                    {
                        sb.AppendLine(",null");
                    }
                    else
                    {
                        sb.AppendLine("," + Gas_stock);
                    }
                    // 2025/11/12↓
                    sb.AppendLine("," + ClsLoginUser.StaffID);
                    sb.AppendLine(",'" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    // 2025/11/12↑

                    // delete flag
                    sb.AppendLine("," + Delete_flag);
                    sb.AppendLine(")");

                    clsSqlDb.DMLUpdate(sb.ToString());
                }
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
                //    sb.AppendLine("Trn_走行記録");
                //    sb.AppendLine("WHERE");
                //    sb.AppendLine("day <= '" + Delete_date + "'");

                //    clsSqlDb.DMLUpdate(sb.ToString());
                //}

                // MySQL側
                using (ClsMySqlDb clsMySqlDb = new(ClsDbConfig.MySQLNo))
                {
                    sb.Clear();
                    sb.AppendLine("DELETE FROM");
                    sb.AppendLine("Trn_走行記録");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("day <= '" + Delete_date + "'");

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
