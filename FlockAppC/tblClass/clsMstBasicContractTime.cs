using FlockAppC.pubClass;
using System;
using System.Data;
using System.Text;

namespace FlockAppC.tblClass
{
    public class ClsMstBasicContractTime
    {
        public int Id {  get; set; }
        public int Location_id {  get; set; }
        // 2026/01/07 DEL
        // public int Kbn {  get; set; }
        public int Car_id {  get; set; }
        public DateTime Start_time1 {  get; set; }
        public DateTime End_time1 { get; set; }
        public DateTime Start_time2 { get; set; }
        public DateTime End_time2 { get; set; }
        public DateTime Start_time3 { get; set; }
        public DateTime End_time3 { get; set; }
        public decimal Work_time {  get; set; }
        public DateTime Start_break_time { get; set; }
        public DateTime End_break_time { get; set; }
        public decimal Break_time { get; set; }
        public string Comment1 { get; set; }
        public string Comment2 { get; set; }
        public string Comment3 { get; set; }
        public string Comment4 { get; set; }
        public string Comment5 { get; set; }

        // 取得用
        public string Week {  get; set; }
        public int Select_count { get; set; }

        public DataTable Dt { get; set; }              // Select結果

        private readonly StringBuilder sb = new();

        // Dispose
        // private bool disposed = false;   未使用

        /// <summary>
        /// 契約時間 SELECT
        /// </summary>
        public void Select()
        {
            try
            {
                using(ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" location_id");
                    // 2026/01/07 DEL
                    // sb.AppendLine(",kbn");
                    sb.AppendLine(",car_id");
                    sb.AppendLine(",start_time1");
                    sb.AppendLine(",end_time1");
                    sb.AppendLine(",start_time2");
                    sb.AppendLine(",end_time2");
                    sb.AppendLine(",start_time3");
                    sb.AppendLine(",end_time3");
                    sb.AppendLine(",work_time");
                    sb.AppendLine(",start_break_time");
                    sb.AppendLine(",end_break_time");
                    sb.AppendLine(",break_time");
                    sb.AppendLine(",comment1");
                    sb.AppendLine(",week");
                    sb.AppendLine(" FROM");
                    sb.AppendLine(" Mst_基本契約時間");
                    sb.AppendLine(" LEFT JOIN");
                    sb.AppendLine(" Mst_基本契約曜日");
                    sb.AppendLine(" ON");
                    sb.AppendLine(" Mst_基本契約時間.id = Mst_基本契約曜日.contract_time_id");
                    sb.AppendLine(" WHERE");
                    sb.AppendLine(" location_id = " + this.Location_id);
                    sb.AppendLine(" AND");
                    sb.AppendLine(" car_id = " + this.Car_id);
                    sb.AppendLine(" AND");
                    sb.AppendLine(" week = '" + this.Week + "'");

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
        /// 契約時間 INSERT
        /// </summary>
        public void Insert()
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("INSERT INTO");
                    sb.AppendLine(" Mst_基本契約時間");
                    sb.AppendLine("(");
                    sb.AppendLine(" location_id");
                    // 2026/01/07 DEL
                    // sb.AppendLine(",kbn");
                    sb.AppendLine(",car_id");
                    sb.AppendLine(",start_time1");
                    sb.AppendLine(",end_time1");
                    sb.AppendLine(",start_time2");
                    sb.AppendLine(",end_time2");
                    sb.AppendLine(",start_time3");
                    sb.AppendLine(",end_time3");
                    sb.AppendLine(",work_time");
                    sb.AppendLine(",start_break_time");
                    sb.AppendLine(",end_break_time");
                    sb.AppendLine(",break_time");
                    sb.AppendLine(",comment1");
                    sb.AppendLine(",ins_user_id");                  // 2025/11/10
                    sb.AppendLine(",ins_date");                      // 2025/11/10
                    sb.AppendLine(",delete_flag");                  // 2025/11/10
                    sb.AppendLine(") VALUES (");
                    sb.AppendLine(Location_id.ToString());
                    // 2026/01/07 DEL
                    // sb.AppendLine("," + Kbn);
                    sb.AppendLine("," + Car_id);

                    // 1900-01-01 00:00:00 の場合は nullを設定する
                    // 1走目
                    if (Start_time1 == new DateTime(1900, 1, 1, 0, 0, 0))
                    {
                        sb.AppendLine(",null");
                    }
                    else
                    {
                        sb.AppendLine(",'" + Start_time1.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    }
                    if (End_time1 == new DateTime(1900, 1, 1, 0, 0, 0))
                    {
                        sb.AppendLine(",null");
                    }
                    else
                    {
                        sb.AppendLine(",'" + End_time1.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    }
                    // 2走目
                    if (Start_time2 == new DateTime(1900, 1, 1, 0, 0, 0))
                    {
                        sb.AppendLine(",null");
                    }
                    else
                    {
                        sb.AppendLine(",'" + Start_time2.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    }
                    if (End_time2 == new DateTime(1900, 1, 1, 0, 0, 0))
                    {
                        sb.AppendLine(",null");
                    }
                    else
                    {
                        sb.AppendLine(",'" + End_time2.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    }
                    // 3走目
                    if (Start_time3 == new DateTime(1900, 1, 1, 0, 0, 0))
                    {
                        sb.AppendLine(",null");
                    }
                    else
                    {
                        sb.AppendLine(",'" + Start_time3.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    }
                    if (End_time3== new DateTime(1900, 1, 1, 0, 0, 0))
                    {
                        sb.AppendLine(",null");
                    }
                    else
                    {
                        sb.AppendLine(",'" + End_time3.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    }

                    if (Work_time > 0) { sb.AppendLine("," + Work_time); }
                    else { sb.AppendLine(",null"); }

                    // 1900-01-01 00:00:00 の場合は nullを設定する
                    // 開始時間
                    if (Start_break_time == new DateTime(1900, 1, 1, 0, 0, 0))
                    {
                        sb.AppendLine(",null");
                    }
                    else
                    {
                        sb.AppendLine(",'" + Start_break_time.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    }
                    // 終了時間
                    if (End_break_time == new DateTime(1900, 1, 1, 0, 0, 0))
                    {
                        sb.AppendLine(",null");
                    }
                    else
                    {
                        sb.AppendLine(",'" + End_break_time.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    }
                    
                    if (Break_time > 0) { sb.AppendLine("," + Break_time); }
                    else { sb.AppendLine(",null"); }
                    sb.AppendLine(",'" + Comment1 + "'");

                    // 2025/11/10↓
                    sb.AppendLine("," + ClsLoginUser.StaffID);
                    sb.AppendLine(",'" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    sb.AppendLine("," + ClsPublic.FLAG_OFF);
                    // 2025/11/10↑

                    sb.AppendLine(")");
                    
                    clsSqlDb.DMLUpdate(sb.ToString());

                    // id取得（最大値）
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("MAX(id) AS max_id");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_基本契約時間");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            Id = int.Parse(dr["max_id"].ToString());
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
        /// 契約時間 INSERT　※INSERTしたレコードIDを返す
        /// </summary>
        public int InsertScalar()
        {
            int new_id = -1;

            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("INSERT INTO");
                    sb.AppendLine(" Mst_基本契約時間");
                    sb.AppendLine("(");
                    sb.AppendLine(" location_id");
                    // 2026/01/07 DEL
                    // sb.AppendLine(",kbn");
                    sb.AppendLine(",car_id");
                    sb.AppendLine(",start_time1");
                    sb.AppendLine(",end_time1");
                    sb.AppendLine(",start_time2");
                    sb.AppendLine(",end_time2");
                    sb.AppendLine(",start_time3");
                    sb.AppendLine(",end_time3");
                    sb.AppendLine(",work_time");
                    sb.AppendLine(",start_break_time");
                    sb.AppendLine(",end_break_time");
                    sb.AppendLine(",break_time");
                    sb.AppendLine(",comment1");
                    sb.AppendLine(",ins_user_id");                  // 2025/11/10
                    sb.AppendLine(",ins_date");                      // 2025/11/10
                    sb.AppendLine(",delete_flag");                  // 2025/11/10
                    sb.AppendLine(") VALUES (");
                    sb.AppendLine(Location_id.ToString());
                    // 2026/01/07 DEL
                    // sb.AppendLine("," + Kbn);
                    sb.AppendLine("," + Car_id);

                    // 1900-01-01 00:00:00 の場合は nullを設定する
                    // 1走目
                    if (Start_time1 == new DateTime(1900, 1, 1, 0, 0, 0))
                    {
                        sb.AppendLine(",null");
                    }
                    else
                    {
                        sb.AppendLine(",'" + Start_time1.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    }
                    if (End_time1 == new DateTime(1900, 1, 1, 0, 0, 0))
                    {
                        sb.AppendLine(",null");
                    }
                    else
                    {
                        sb.AppendLine(",'" + End_time1.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    }
                    // 2走目
                    if (Start_time2 == new DateTime(1900, 1, 1, 0, 0, 0))
                    {
                        sb.AppendLine(",null");
                    }
                    else
                    {
                        sb.AppendLine(",'" + Start_time2.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    }
                    if (End_time2 == new DateTime(1900, 1, 1, 0, 0, 0))
                    {
                        sb.AppendLine(",null");
                    }
                    else
                    {
                        sb.AppendLine(",'" + End_time2.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    }
                    // 3走目
                    if (Start_time3 == new DateTime(1900, 1, 1, 0, 0, 0))
                    {
                        sb.AppendLine(",null");
                    }
                    else
                    {
                        sb.AppendLine(",'" + Start_time3.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    }
                    if (End_time3 == new DateTime(1900, 1, 1, 0, 0, 0))
                    {
                        sb.AppendLine(",null");
                    }
                    else
                    {
                        sb.AppendLine(",'" + End_time3.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    }

                    if (Work_time > 0) { sb.AppendLine("," + Work_time); }
                    else { sb.AppendLine(",null"); }

                    // 1900-01-01 00:00:00 の場合は nullを設定する
                    // 開始時間
                    if (Start_break_time == new DateTime(1900, 1, 1, 0, 0, 0))
                    {
                        sb.AppendLine(",null");
                    }
                    else
                    {
                        sb.AppendLine(",'" + Start_break_time.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    }
                    // 終了時間
                    if (End_break_time == new DateTime(1900, 1, 1, 0, 0, 0))
                    {
                        sb.AppendLine(",null");
                    }
                    else
                    {
                        sb.AppendLine(",'" + End_break_time.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    }

                    if (Break_time > 0) { sb.AppendLine("," + Break_time); }
                    else { sb.AppendLine(",null"); }
                    sb.AppendLine(",'" + Comment1 + "'");

                    // 2025/11/10↓
                    sb.AppendLine("," + ClsLoginUser.StaffID);
                    sb.AppendLine(",'" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    sb.AppendLine("," + ClsPublic.FLAG_OFF);
                    // 2025/11/10↑

                    sb.AppendLine("); SELECT SCOPE_IDENTITY();");

                    // clsSqlDb.DMLUpdate(sb.ToString());
                    new_id = clsSqlDb.DMLUpdateScalar(sb.ToString());

                    //// id取得（最大値）
                    //sb.Clear();
                    //sb.AppendLine("SELECT");
                    //sb.AppendLine("MAX(id) AS max_id");
                    //sb.AppendLine("FROM");
                    //sb.AppendLine("Mst_基本契約時間");

                    //using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    //{
                    //    foreach (DataRow dr in dt_val.Rows)
                    //    {
                    //        Id = int.Parse(dr["max_id"].ToString());
                    //    }
                    //}
                }
                return new_id;
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                return new_id;
                throw;
            }
        }
        /// <summary>
        /// 契約時間 UPDATE
        /// </summary>
        public void Update()
        {
            try
            {
                using(ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("UPDATE");
                    sb.AppendLine("Mst_基本契約時間");
                    sb.AppendLine("SET");
                    sb.AppendLine(" location_id = " + this.Location_id);
                    // 2026/01/07 DEL
                    // sb.AppendLine(",kbn = " + this.Kbn);
                    sb.AppendLine(",car_id = " + this.Car_id);

                    // 1900-01-01 00:00:00 の場合は nullを設定する
                    // 1走目
                    if (Start_time1 == new DateTime(1900, 1, 1, 0, 0, 0))
                    {
                        sb.AppendLine(",start_time1 = null");
                    }
                    else
                    {
                        sb.AppendLine(",start_time1 = '" + Start_time1.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    }
                    if (End_time1 == new DateTime(1900, 1, 1, 0, 0, 0))
                    {
                        sb.AppendLine(",end_time1 = null");
                    }
                    else
                    {
                        sb.AppendLine(",end_time1 = '" + End_time1.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    }
                    // 2走目
                    if (Start_time2 == new DateTime(1900, 1, 1, 0, 0, 0))
                    {
                        sb.AppendLine(",start_time2 = null");
                    }
                    else
                    {
                        sb.AppendLine(",start_time2 = '" + Start_time2.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    }
                    if (End_time2 == new DateTime(1900, 1, 1, 0, 0, 0))
                    {
                        sb.AppendLine(",end_time2 = null");
                    }
                    else
                    {
                        sb.AppendLine(",end_time2 = '" + End_time2.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    }
                    // 3走目
                    if (Start_time3 == new DateTime(1900, 1, 1, 0, 0, 0))
                    {
                        sb.AppendLine(",start_time3 = null");
                    }
                    else
                    {
                        sb.AppendLine(",start_time3 = '" + Start_time3.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    }
                    if (End_time3 == new DateTime(1900, 1, 1, 0, 0, 0))
                    {
                        sb.AppendLine(",end_time3 = null");
                    }
                    else
                    {
                        sb.AppendLine(",end_time3 = '" + End_time3.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    }

                    if (this.Work_time > 0) { sb.AppendLine(",work_time = " + this.Work_time); }
                    else { sb.AppendLine(",work_time = null"); }

                    // 1900-01-01 00:00:00 の場合は nullを設定する
                    // 開始時間
                    if (Start_break_time == new DateTime(1900, 1, 1, 0, 0, 0))
                    {
                        sb.AppendLine(",start_break_time = null");
                    }
                    else
                    {
                        sb.AppendLine(",start_break_time = '" + Start_break_time.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    }
                    // 終了時間
                    if (End_break_time == new DateTime(1900, 1, 1, 0, 0, 0))
                    {
                        sb.AppendLine(",end_break_time = null");
                    }
                    else
                    {
                        sb.AppendLine(",end_break_time = '" + End_break_time.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    }

                    if (this.Break_time > 0) { sb.AppendLine(",break_time = " + this.Break_time); }
                    else { sb.AppendLine(",break_time = null"); }
                    sb.AppendLine(",comment1 = '" + this.Comment1 + "'");

                    // 2025/11/10↓
                    sb.AppendLine(",upd_user_id = " + ClsLoginUser.StaffID);
                    sb.AppendLine(",upd_date = '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    // 2025/11/10↑

                    sb.AppendLine("WHERE");
                    sb.AppendLine(" id = " + this.Id);
                    
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
        /// 契約時間 DELETE
        /// </summary>
        public void Delete()
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("DELETE FROM");
                    sb.AppendLine(" Mst_基本契約時間");
                    sb.AppendLine("WHERE");
                    sb.AppendLine(" id = " + this.Id);
                }
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// SQL Serverテーブル値をXServerのmySQLに登録
        /// </summary>
        public void ExportBasicContractTimeData(ref System.Windows.Forms.ProgressBar p_pgb)
        {
            int rec_cnt;
            int importCnt = 0;

            // =============================================================================
            // 更新日付を参照し、エクスポート対象のデータのみエクスポートする
            // 追々対応予定
            // 基本契約時間マスターには更新日付項目は追加済み
            // =============================================================================

            try
            {
                // 2025/08/27 UPD
                // MySQL接続(XServer)
                using (ClsMySqlDb clsMySqlDb = new(ClsDbConfig.MySQLNo))
                {
                    /////////////////////////////////////////////////////////////////////////
                    // TRUNCATE TABLE (MySQL)
                    // テーブルをクリア
                    /////////////////////////////////////////////////////////////////////////
                    sb.Clear();
                    sb.AppendLine("TRUNCATE TABLE");
                    sb.AppendLine("Mst_基本契約時間");

                    clsMySqlDb.DMLUpdate(sb.ToString());

                    /////////////////////////////////////////////////////////////////////////
                    // SQL Server → MySQL
                    /////////////////////////////////////////////////////////////////////////
                    using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                    {
                        // SQL Server SELECT ALL
                        // SQL Serverデータを読み込み、MySQLへ書き込む
                        sb.Clear();
                        sb.AppendLine("SELECT");
                        sb.AppendLine(" id");
                        sb.AppendLine(",location_id");
                        // 2026/01/07 DEL
                        // sb.AppendLine(",kbn");
                        sb.AppendLine(",car_id");
                        sb.AppendLine(",start_time1");
                        sb.AppendLine(",end_time1");
                        sb.AppendLine(",start_time2");
                        sb.AppendLine(",end_time2");
                        sb.AppendLine(",start_time3");
                        sb.AppendLine(",end_time3");
                        sb.AppendLine(",work_time");
                        sb.AppendLine(",start_break_time");
                        sb.AppendLine(",end_break_time");
                        sb.AppendLine(",break_time");
                        sb.AppendLine(",comment1");
                        sb.AppendLine(",comment2");
                        sb.AppendLine(",comment3");
                        sb.AppendLine(",comment4");
                        sb.AppendLine(",comment5");
                        // 2025/11/10↓
                        sb.AppendLine(",ins_user_id");
                        sb.AppendLine(",ins_date");
                        sb.AppendLine(",upd_user_id");
                        sb.AppendLine(",upd_date");
                        sb.AppendLine(",delete_flag");
                        // 2025/11/10↑
                        sb.AppendLine("FROM");
                        sb.AppendLine("Mst_基本契約時間");

                        using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                        {
                            // ProgressBar設定
                            // rec_cnt = clsSql.dt.Rows.Count;
                            rec_cnt = dt_val.Rows.Count;
                            p_pgb.Visible = true;
                            p_pgb.Maximum = rec_cnt;

                            // MySQL INSERT
                            foreach (DataRow dr in dt_val.Rows)
                            {
                                sb.Clear();
                                sb.AppendLine("INSERT INTO Mst_基本契約時間 (");
                                sb.AppendLine(" id");
                                sb.AppendLine(",location_id");
                                // 2026/01/07 DEL
                                // sb.AppendLine(",kbn");
                                sb.AppendLine(",car_id");
                                sb.AppendLine(",start_time1");
                                sb.AppendLine(",end_time1");
                                sb.AppendLine(",start_time2");
                                sb.AppendLine(",end_time2");
                                sb.AppendLine(",start_time3");
                                sb.AppendLine(",end_time3");
                                sb.AppendLine(",work_time");
                                sb.AppendLine(",start_break_time");
                                sb.AppendLine(",end_break_time");
                                sb.AppendLine(",break_time");
                                sb.AppendLine(",comment1");
                                sb.AppendLine(",comment2");
                                sb.AppendLine(",comment3");
                                sb.AppendLine(",comment4");
                                sb.AppendLine(",comment5");
                                // 2025/11/10↓
                                sb.AppendLine(",ins_user_id");
                                sb.AppendLine(",ins_date");
                                sb.AppendLine(",upd_user_id");
                                sb.AppendLine(",upd_date");
                                sb.AppendLine(",delete_flag");
                                // 2025/11/10↑
                                sb.AppendLine(") VALUES (");
                                sb.AppendLine(dr["id"].ToString());
                                sb.AppendLine("," + dr["location_id"].ToString());
                                // 2026/01/07 DEL
                                // sb.AppendLine("," + dr["kbn"].ToString());
                                sb.AppendLine("," + dr["car_id"].ToString());

                                // 2025/07/28 未設定時はnullセットに変更
                                if (dr.IsNull("start_time1") != true) { sb.AppendLine(",'" + dr["start_time1"].ToString() + "'"); }
                                else { sb.AppendLine(",null"); }
                                if (dr.IsNull("end_time1") != true) { sb.AppendLine(",'" + dr["end_time1"].ToString() + "'"); }
                                else { sb.AppendLine(",null"); }

                                if (dr.IsNull("start_time2") != true) { sb.AppendLine(",'" + dr["start_time2"].ToString() + "'"); }
                                else { sb.AppendLine(",null"); }
                                if (dr.IsNull("end_time2") != true) { sb.AppendLine(",'" + dr["end_time2"].ToString() + "'"); }
                                else { sb.AppendLine(",null"); }

                                if (dr.IsNull("start_time3") != true) { sb.AppendLine(",'" + dr["start_time3"].ToString() + "'"); }
                                else { sb.AppendLine(",null"); }
                                if (dr.IsNull("end_time3") != true) { sb.AppendLine(",'" + dr["end_time3"].ToString() + "'"); }
                                else { sb.AppendLine(",null"); }

                                if (dr.IsNull("work_time") != true) { sb.AppendLine("," + dr["work_time"].ToString()); }
                                else { sb.AppendLine(",0"); }

                                if (dr.IsNull("start_break_time") != true) { sb.AppendLine(",'" + dr["start_break_time"].ToString() + "'"); }
                                else { sb.AppendLine(",null"); }

                                if (dr.IsNull("end_break_time") != true) { sb.AppendLine(",'" + dr["end_break_time"].ToString() + "'"); }
                                else { sb.AppendLine(",null"); }

                                /*
                                if (dr.IsNull("start_time1") != true) { st.AppendLine(",'" + dr["start_time1"].ToString() + "'"); }
                                else { st.AppendLine(",'1900/01/01 00:00:00'"); }
                                if (dr.IsNull("end_time1") != true) { st.AppendLine(",'" + dr["end_time1"].ToString() + "'"); }
                                else { st.AppendLine(",'1900/01/01 00:00:00'"); }

                                if (dr.IsNull("start_time2") != true) { st.AppendLine(",'" + dr["start_time2"].ToString() + "'"); }
                                else { st.AppendLine(",'1900/01/01 00:00:00'"); }
                                if (dr.IsNull("end_time2") != true) { st.AppendLine(",'" + dr["end_time2"].ToString() + "'"); }
                                else { st.AppendLine(",'1900/01/01 00:00:00'"); }

                                if (dr.IsNull("start_time3") != true) { st.AppendLine(",'" + dr["start_time3"].ToString() + "'"); }
                                else { st.AppendLine(",'1900/01/01 00:00:00'"); }
                                if (dr.IsNull("end_time3") != true) { st.AppendLine(",'" + dr["end_time3"].ToString() + "'"); }
                                else { st.AppendLine(",'1900/01/01 00:00:00'"); }

                                if (dr.IsNull("work_time") != true) { st.AppendLine("," + dr["work_time"].ToString()); }
                                else { st.AppendLine(",0"); }

                                if (dr.IsNull("start_break_time") != true) { st.AppendLine(",'" + dr["start_break_time"].ToString() + "'"); }
                                else { st.AppendLine(",'1900/01/01 00:00:00'"); }

                                if (dr.IsNull("end_break_time") != true) { st.AppendLine(",'" + dr["end_break_time"].ToString() + "'"); }
                                else { st.AppendLine(",'1900/01/01 00:00:00'"); }
                                */

                                if (dr.IsNull("break_time") != true) { sb.AppendLine("," + dr["break_time"].ToString()); }
                                else { sb.AppendLine(",0"); }

                                if (dr.IsNull("comment1") != true) { sb.AppendLine(",'" + dr["Comment1"].ToString() + "'"); }
                                else { sb.AppendLine(",''"); }

                                if (dr.IsNull("comment2") != true) { sb.AppendLine(",'" + dr["Comment2"].ToString() + "'"); }
                                else { sb.AppendLine(",''"); }

                                if (dr.IsNull("comment3") != true) { sb.AppendLine(",'" + dr["Comment3"].ToString() + "'"); }
                                else { sb.AppendLine(",''"); }

                                if (dr.IsNull("comment4") != true) { sb.AppendLine(",'" + dr["Comment4"].ToString() + "'"); }
                                else { sb.AppendLine(",''"); }

                                if (dr.IsNull("comment5") != true) { sb.AppendLine(",'" + dr["Comment5"].ToString() + "'"); }
                                else { sb.AppendLine(",''"); }

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
                                else { sb.AppendLine(",0"); }
                                // 2025/11/10↑

                                sb.AppendLine(")");

                                clsMySqlDb.DMLUpdate(sb.ToString());

                                importCnt++;

                                // ProgressBar値セット
                                p_pgb.Value = importCnt;
                                p_pgb.Refresh();
                            }
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
        /// SQL Serverテーブル値をXServerのmySQLに登録
        /// </summary>
        public void ExportBasicContractOneTimeData(int p_id, ClsSqlDb clsSqlDb, ClsMySqlDb clsMySqlDb)
        {
            // =============================================================================
            // 更新日付を参照し、エクスポート対象のデータのみエクスポートする
            // 追々対応予定
            // 基本契約時間マスターには更新日付項目は追加済み
            // =============================================================================

            try
            {
                /////////////////////////////////////////////////////////////////////////
                // TRUNCATE TABLE (MySQL)
                // テーブルをクリア
                /////////////////////////////////////////////////////////////////////////
                sb.Clear();
                sb.AppendLine("DELETE FROM");
                sb.AppendLine("Mst_基本契約時間");
                sb.AppendLine("WHERE");
                sb.AppendLine("id = " + p_id);
                clsMySqlDb.DMLUpdate(sb.ToString());

                // SQL Server SELECT ALL
                // SQL Serverデータを読み込み、MySQLへ書き込む
                sb.Clear();
                sb.AppendLine("SELECT");
                sb.AppendLine(" id");
                sb.AppendLine(",location_id");
                // 2026/01/07 DEL
                // sb.AppendLine(",kbn");
                sb.AppendLine(",car_id");
                sb.AppendLine(",start_time1");
                sb.AppendLine(",end_time1");
                sb.AppendLine(",start_time2");
                sb.AppendLine(",end_time2");
                sb.AppendLine(",start_time3");
                sb.AppendLine(",end_time3");
                sb.AppendLine(",work_time");
                sb.AppendLine(",start_break_time");
                sb.AppendLine(",end_break_time");
                sb.AppendLine(",break_time");
                sb.AppendLine(",comment1");
                sb.AppendLine(",comment2");
                sb.AppendLine(",comment3");
                sb.AppendLine(",comment4");
                sb.AppendLine(",comment5");
                sb.AppendLine(",ins_user_id");
                sb.AppendLine(",ins_date");
                sb.AppendLine(",upd_user_id");
                sb.AppendLine(",upd_date");
                sb.AppendLine(",delete_flag");
                sb.AppendLine("FROM");
                sb.AppendLine("Mst_基本契約時間");
                sb.AppendLine("WHERE");
                sb.AppendLine("id = " + p_id);

                using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                {
                    // MySQL INSERT
                    foreach (DataRow dr in dt_val.Rows)
                    {
                        sb.Clear();
                        sb.AppendLine("INSERT INTO Mst_基本契約時間 (");
                        sb.AppendLine(" id");
                        sb.AppendLine(",location_id");
                        // 2026/01/07 DEL
                        // sb.AppendLine(",kbn");
                        sb.AppendLine(",car_id");
                        sb.AppendLine(",start_time1");
                        sb.AppendLine(",end_time1");
                        sb.AppendLine(",start_time2");
                        sb.AppendLine(",end_time2");
                        sb.AppendLine(",start_time3");
                        sb.AppendLine(",end_time3");
                        sb.AppendLine(",work_time");
                        sb.AppendLine(",start_break_time");
                        sb.AppendLine(",end_break_time");
                        sb.AppendLine(",break_time");
                        sb.AppendLine(",comment1");
                        sb.AppendLine(",comment2");
                        sb.AppendLine(",comment3");
                        sb.AppendLine(",comment4");
                        sb.AppendLine(",comment5");
                        sb.AppendLine(",ins_user_id");
                        sb.AppendLine(",ins_date");
                        sb.AppendLine(",upd_user_id");
                        sb.AppendLine(",upd_date");
                        sb.AppendLine(",delete_flag");
                        sb.AppendLine(") VALUES (");
                        sb.AppendLine(dr["id"].ToString());
                        sb.AppendLine("," + dr["location_id"].ToString());
                        // 2026/01/07 DEL
                        // sb.AppendLine("," + dr["kbn"].ToString());
                        sb.AppendLine("," + dr["car_id"].ToString());
                        if (dr.IsNull("start_time1") != true) { sb.AppendLine(",'" + dr["start_time1"].ToString() + "'"); }
                        else { sb.AppendLine(",null"); }
                        if (dr.IsNull("end_time1") != true) { sb.AppendLine(",'" + dr["end_time1"].ToString() + "'"); }
                        else { sb.AppendLine(",null"); }
                        if (dr.IsNull("start_time2") != true) { sb.AppendLine(",'" + dr["start_time2"].ToString() + "'"); }
                        else { sb.AppendLine(",null"); }
                        if (dr.IsNull("end_time2") != true) { sb.AppendLine(",'" + dr["end_time2"].ToString() + "'"); }
                        else { sb.AppendLine(",null"); }
                        if (dr.IsNull("start_time3") != true) { sb.AppendLine(",'" + dr["start_time3"].ToString() + "'"); }
                        else { sb.AppendLine(",null"); }
                        if (dr.IsNull("end_time3") != true) { sb.AppendLine(",'" + dr["end_time3"].ToString() + "'"); }
                        else { sb.AppendLine(",null"); }
                        if (dr.IsNull("work_time") != true) { sb.AppendLine("," + dr["work_time"].ToString()); }
                        else { sb.AppendLine(",0"); }
                        if (dr.IsNull("start_break_time") != true) { sb.AppendLine(",'" + dr["start_break_time"].ToString() + "'"); }
                        else { sb.AppendLine(",null"); }
                        if (dr.IsNull("end_break_time") != true) { sb.AppendLine(",'" + dr["end_break_time"].ToString() + "'"); }
                        else { sb.AppendLine(",null"); }
                        if (dr.IsNull("break_time") != true) { sb.AppendLine("," + dr["break_time"].ToString()); }
                        else { sb.AppendLine(",0"); }
                        if (dr.IsNull("comment1") != true) { sb.AppendLine(",'" + dr["Comment1"].ToString() + "'"); }
                        else { sb.AppendLine(",''"); }
                        if (dr.IsNull("comment2") != true) { sb.AppendLine(",'" + dr["Comment2"].ToString() + "'"); }
                        else { sb.AppendLine(",''"); }
                        if (dr.IsNull("comment3") != true) { sb.AppendLine(",'" + dr["Comment3"].ToString() + "'"); }
                        else { sb.AppendLine(",''"); }
                        if (dr.IsNull("comment4") != true) { sb.AppendLine(",'" + dr["Comment4"].ToString() + "'"); }
                        else { sb.AppendLine(",''"); }
                        if (dr.IsNull("comment5") != true) { sb.AppendLine(",'" + dr["Comment5"].ToString() + "'"); }
                        else { sb.AppendLine(",''"); }
                        if (dr.IsNull("ins_user_id") != true) { sb.AppendLine("," + dr["ins_user_id"].ToString()); }
                        else { sb.AppendLine(",0"); }
                        if (dr.IsNull("ins_date") != true) { sb.AppendLine(",'" + dr["ins_date"].ToString() + "'"); }
                        else { sb.AppendLine(",null"); }
                        if (dr.IsNull("upd_user_id") != true) { sb.AppendLine("," + dr["upd_user_id"].ToString()); }
                        else { sb.AppendLine(",0"); }
                        if (dr.IsNull("upd_date") != true) { sb.AppendLine(",'" + dr["upd_date"].ToString() + "'"); }
                        else { sb.AppendLine(",null"); }
                        if (dr.IsNull("delete_flag") != true) { sb.AppendLine("," + dr["delete_flag"].ToString()); }
                        else { sb.AppendLine(",0"); }
                        sb.AppendLine(")");
                        clsMySqlDb.DMLUpdate(sb.ToString());
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
        /// SQL Serverテーブル値をXServerのmySQLに登録
        /// </summary>
        /// <param name="p_contract_time_id"></param>
        /// <param name="clsSqlDb"></param>
        /// <param name="clsMySqlDb"></param>
        public void ExportBasicContractOneWeekData(int p_contract_time_id, ClsSqlDb clsSqlDb, ClsMySqlDb clsMySqlDb)
        {
            try
            {
                /////////////////////////////////////////////////////////////////////////
                // TRUNCATE TABLE (MySQL)
                // テーブルをクリア
                /////////////////////////////////////////////////////////////////////////
                sb.Clear();
                sb.AppendLine("DELETE FROM");
                sb.AppendLine("Mst_基本契約曜日");
                sb.AppendLine("WHERE");
                sb.AppendLine("contract_time_id = " + p_contract_time_id);
                clsMySqlDb.DMLUpdate(sb.ToString());

                // SQL Server SELECT ALL
                // SQL Serverデータを読み込み、MySQLへ書き込む
                sb.Clear();
                sb.AppendLine("SELECT");
                sb.AppendLine(" contract_time_id");
                sb.AppendLine(",sort");
                sb.AppendLine(",week");
                sb.AppendLine(",ins_user_id");
                sb.AppendLine(",ins_date");
                sb.AppendLine(",upd_user_id");
                sb.AppendLine(",upd_date");
                sb.AppendLine(",delete_flag");
                sb.AppendLine("FROM");
                sb.AppendLine("Mst_基本契約曜日");
                sb.AppendLine("WHERE");
                sb.AppendLine(" contract_time_id = " + p_contract_time_id);
                sb.AppendLine("ORDER BY");
                sb.AppendLine(" sort");

                using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                {
                    // MySQL INSERT
                    foreach (DataRow dr in dt_val.Rows)
                    {
                        sb.Clear();
                        sb.AppendLine("INSERT INTO Mst_基本契約曜日 (");
                        sb.AppendLine(" contract_time_id");
                        sb.AppendLine(",sort");
                        sb.AppendLine(",week");
                        sb.AppendLine(",ins_user_id");
                        sb.AppendLine(",ins_date");
                        sb.AppendLine(",upd_user_id");
                        sb.AppendLine(",upd_date");
                        sb.AppendLine(",delete_flag");
                        sb.AppendLine(") VALUES (");
                        sb.AppendLine(dr["contract_time_id"].ToString());
                        sb.AppendLine("," + dr["sort"].ToString());
                        sb.AppendLine(",'" + dr["week"].ToString() + "'");
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
                        sb.AppendLine(")");
                        clsMySqlDb.DMLUpdate(sb.ToString());
                    }
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
