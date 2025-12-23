using FlockAppC.pubClass;
using System;
using System.Data;
using System.Text;

namespace FlockAppC.tblClass
{
    public class ClsMstLocationCar
    {
        public int Id { get; set; }
        public int Location_Id { get; set; }
        public string FullName { get; set; }
        public string Name { get; set; }
        public string CarName { get; set; }
        public string No { get; set; }
        public int Kbn { get; set; }             // 2024/12/17 ADD

        private readonly StringBuilder sb = new();

        /// <summary>
        /// Insert
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
                    sb.AppendLine("Mst_専従先車両");
                    sb.AppendLine("(");
                    sb.AppendLine("no");
                    sb.AppendLine(",fullname");
                    sb.AppendLine(",name");
                    sb.AppendLine(",car_name");
                    sb.AppendLine(",location_id");
                    sb.AppendLine(",kbn");
                    // 2025/11/10↓
                    sb.AppendLine(",ins_user_id");
                    sb.AppendLine(",ins_date");
                    sb.AppendLine(",delete_flag");
                    // 2025/11/10↑
                    sb.AppendLine(") VALUES (");
                    sb.AppendLine(" '" + No + "'");
                    sb.AppendLine(",'" + FullName + "'");
                    sb.AppendLine(",'" + Name + "'");
                    sb.AppendLine(",'" + CarName + "'");
                    sb.AppendLine("," + Location_Id);
                    sb.AppendLine("," + Kbn);
                    // 2025/11/10↓
                    sb.AppendLine("," + ClsLoginUser.StaffID);
                    sb.AppendLine(",'" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    sb.AppendLine("," + ClsPublic.FLAG_OFF);
                    // 2025/11/10↑
                    sb.AppendLine("); SELECT SCOPE_IDENTITY();");

                    // clsSqlDb.DMLUpdate(sb.ToString());
                    new_id = clsSqlDb.DMLUpdateScalar(sb.ToString());

                    //// 登録ID取得
                    //sb.Clear();
                    //sb.AppendLine("SELECT");
                    //sb.AppendLine("id");
                    //sb.AppendLine("FROM");
                    //sb.AppendLine("Mst_専従先車両");
                    //sb.AppendLine("WHERE");
                    //sb.AppendLine("fullname = '" + FullName + "'");
                    //sb.AppendLine("AND");
                    //sb.AppendLine("name = '" + Name + "'");
                    //sb.AppendLine("AND");
                    //sb.AppendLine("car_name = '" + CarName + "'");
                    //sb.AppendLine("AND");
                    //sb.AppendLine("location_id = " + Location_Id);
                    //sb.AppendLine("AND");
                    //sb.AppendLine("delete_flag = 0");

                    //using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    //{
                    //    foreach (DataRow dr in dt_val.Rows)
                    //    {
                    //        ID = int.Parse(dr["id"].ToString());
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
        /// Update
        /// </summary>
        public void Update()
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("UPDATE");
                    sb.AppendLine("Mst_専従先車両");
                    sb.AppendLine("SET");
                    sb.AppendLine("no = '" + No + "'");
                    sb.AppendLine(",fullname = '" + FullName + "'");
                    sb.AppendLine(",name = '" + Name + "'");
                    sb.AppendLine(",car_name = '" + CarName + "'");
                    sb.AppendLine(",location_id = " + Location_Id);
                    sb.AppendLine(",kbn = " + Kbn);
                    // 2025/11/10↓
                    sb.AppendLine(",upd_user_id = " + ClsLoginUser.StaffID);
                    sb.AppendLine(",upd_date = '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    // 2025/11/10↑
                    sb.AppendLine("WHERE");
                    sb.AppendLine("id = " + Id);

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
        /// Delete
        /// </summary>
        public void Delete()
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("UPDATE");
                    sb.AppendLine("Mst_専従先車両");
                    sb.AppendLine("SET");
                    sb.AppendLine("delete_flag = 1");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("id = " + Id);

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
        /// 専従先車両テーブルの値をXServerのmySQLに登録
        /// </summary>
        public void ExportLocationCarData(ref System.Windows.Forms.ProgressBar p_pgb)
        {
            int rec_cnt;
            int importCnt = 0;
            
            // =============================================================================
            // 更新日付を参照し、エクスポート対象のデータのみエクスポートする
            // 追々対応予定
            // 専従先車両マスターには更新日付項目は追加済み
            // =============================================================================

            try
            {
                using (ClsMySqlDb clsMySqlDb = new(ClsDbConfig.MySQLNo))
                {
                    /////////////////////////////////////////////////////////////////////////
                    // TRUNCATE TABLE
                    // 専従先車両テーブルをクリア
                    /////////////////////////////////////////////////////////////////////////
                    sb.Clear();
                    sb.AppendLine("TRUNCATE TABLE");
                    sb.AppendLine("Mst_専従先車両");
                    
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
                        sb.AppendLine(",no");
                        sb.AppendLine(",fullname");
                        sb.AppendLine(",name");
                        sb.AppendLine(",car_name");
                        sb.AppendLine(",location_id");
                        sb.AppendLine(",kbn");
                        // 2025/11/10↓
                        sb.AppendLine(",ins_user_id");
                        sb.AppendLine(",ins_date");
                        sb.AppendLine(",upd_user_id");
                        sb.AppendLine(",upd_date");
                        sb.AppendLine(",delete_flag");
                        // 2025/11/10↑
                        sb.AppendLine("FROM");
                        sb.AppendLine("Mst_専従先車両");
                        sb.AppendLine("WHERE");
                        sb.AppendLine("delete_flag = 0");
                        sb.AppendLine("ORDER BY");
                        sb.AppendLine("id");

                        using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                        {
                            // ProgressBar設定
                            rec_cnt = dt_val.Rows.Count;
                            p_pgb.Visible = true;
                            p_pgb.Maximum = rec_cnt;

                            // MySQL INSERT
                            foreach (DataRow dr in dt_val.Rows)
                            {
                                sb.Clear();
                                sb.AppendLine("INSERT INTO Mst_専従先車両 (");
                                sb.AppendLine(" id");
                                sb.AppendLine(",no");
                                sb.AppendLine(",fullname");
                                sb.AppendLine(",name");
                                sb.AppendLine(",car_name");
                                sb.AppendLine(",location_id");
                                sb.AppendLine(",kbn");
                                // 2025/11/10↓
                                sb.AppendLine(",ins_user_id");
                                sb.AppendLine(",ins_date");
                                sb.AppendLine(",upd_user_id");
                                sb.AppendLine(",upd_date");
                                sb.AppendLine(",delete_flag");
                                // 2025/11/10↑
                                sb.AppendLine(") VALUES (");
                                sb.AppendLine(dr["id"].ToString());
                                sb.AppendLine(",'" + dr["no"].ToString() + "'");
                                sb.AppendLine(",'" + dr["fullname"].ToString() + "'");
                                sb.AppendLine(",'" + dr["name"].ToString() + "'");
                                sb.AppendLine(",'" + dr["car_name"].ToString() + "'");
                                sb.AppendLine("," + dr["location_id"].ToString());
                                sb.AppendLine("," + dr["kbn"].ToString());
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
        /// 専従先車両テーブルの値をXServerのmySQLに登録
        /// </summary>
        public void ExportLocationCarAllData(ClsSqlDb clsSqlDb, ClsMySqlDb clsMySqlDb)
        {
            try
            {
                /////////////////////////////////////////////////////////////////////////
                // TRUNCATE TABLE
                // 専従先車両テーブルをクリア
                /////////////////////////////////////////////////////////////////////////
                sb.Clear();
                sb.AppendLine("TRUNCATE TABLE");
                sb.AppendLine("Mst_専従先車両");
                clsMySqlDb.DMLUpdate(sb.ToString());

                // SQL Server SELECT ALL
                // SQL Serverデータを読み込み、MySQLへ書き込む
                sb.Clear();
                sb.AppendLine("SELECT");
                sb.AppendLine(" id");
                sb.AppendLine(",no");
                sb.AppendLine(",fullname");
                sb.AppendLine(",name");
                sb.AppendLine(",car_name");
                sb.AppendLine(",location_id");
                sb.AppendLine(",kbn");
                sb.AppendLine(",ins_user_id");
                sb.AppendLine(",ins_date");
                sb.AppendLine(",upd_user_id");
                sb.AppendLine(",upd_date");
                sb.AppendLine(",delete_flag");
                sb.AppendLine("FROM");
                sb.AppendLine("Mst_専従先車両");
                sb.AppendLine("WHERE");
                sb.AppendLine("delete_flag = " + ClsPublic.FLAG_OFF);
                sb.AppendLine("ORDER BY");
                sb.AppendLine("id");

                using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                {
                    // MySQL INSERT
                    foreach (DataRow dr in dt_val.Rows)
                    {
                        sb.Clear();
                        sb.AppendLine("INSERT INTO Mst_専従先車両 (");
                        sb.AppendLine(" id");
                        sb.AppendLine(",no");
                        sb.AppendLine(",fullname");
                        sb.AppendLine(",name");
                        sb.AppendLine(",car_name");
                        sb.AppendLine(",location_id");
                        sb.AppendLine(",kbn");
                        sb.AppendLine(",ins_user_id");
                        sb.AppendLine(",ins_date");
                        sb.AppendLine(",upd_user_id");
                        sb.AppendLine(",upd_date");
                        sb.AppendLine(",delete_flag");
                        sb.AppendLine(") VALUES (");
                        sb.AppendLine(dr["id"].ToString());
                        sb.AppendLine(",'" + dr["no"].ToString() + "'");
                        sb.AppendLine(",'" + dr["fullname"].ToString() + "'");
                        sb.AppendLine(",'" + dr["name"].ToString() + "'");
                        sb.AppendLine(",'" + dr["car_name"].ToString() + "'");
                        sb.AppendLine("," + dr["location_id"].ToString());
                        sb.AppendLine("," + dr["kbn"].ToString());
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
        /// <summary>
        /// 専従先車両テーブルの値をXServerのmySQLに登録
        /// </summary>
        public void ExportLocationOneCarData(int p_id, ClsSqlDb clsSqlDb, ClsMySqlDb clsMySqlDb )
        {
            // =============================================================================
            // 更新日付を参照し、エクスポート対象のデータのみエクスポートする
            // 追々対応予定
            // 専従先車両マスターには更新日付項目は追加済み
            // =============================================================================

            try
            {
                /////////////////////////////////////////////////////////////////////////
                // TRUNCATE TABLE
                // 専従先車両テーブルをクリア
                /////////////////////////////////////////////////////////////////////////
                sb.Clear();
                sb.AppendLine("DELETE FROM");
                sb.AppendLine("Mst_専従先車両");
                sb.AppendLine("WHERE");
                sb.AppendLine("id = " + p_id);
                clsMySqlDb.DMLUpdate(sb.ToString());

                // SQL Server SELECT ALL
                // SQL Serverデータを読み込み、MySQLへ書き込む
                sb.Clear();
                sb.AppendLine("SELECT");
                sb.AppendLine(" id");
                sb.AppendLine(",no");
                sb.AppendLine(",fullname");
                sb.AppendLine(",name");
                sb.AppendLine(",car_name");
                sb.AppendLine(",location_id");
                sb.AppendLine(",kbn");
                sb.AppendLine(",ins_user_id");
                sb.AppendLine(",ins_date");
                sb.AppendLine(",upd_user_id");
                sb.AppendLine(",upd_date");
                sb.AppendLine(",delete_flag");
                sb.AppendLine("FROM");
                sb.AppendLine("Mst_専従先車両");
                sb.AppendLine("WHERE");
                sb.AppendLine("id = " + p_id);

                using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                {
                    // MySQL INSERT
                    foreach (DataRow dr in dt_val.Rows)
                    {
                        sb.Clear();
                        sb.AppendLine("INSERT INTO Mst_専従先車両 (");
                        sb.AppendLine(" id");
                        sb.AppendLine(",no");
                        sb.AppendLine(",fullname");
                        sb.AppendLine(",name");
                        sb.AppendLine(",car_name");
                        sb.AppendLine(",location_id");
                        sb.AppendLine(",kbn");
                        sb.AppendLine(",ins_user_id");
                        sb.AppendLine(",ins_date");
                        sb.AppendLine(",upd_user_id");
                        sb.AppendLine(",upd_date");
                        sb.AppendLine(",delete_flag");
                        sb.AppendLine(") VALUES (");
                        sb.AppendLine(dr["id"].ToString());
                        sb.AppendLine(",'" + dr["no"].ToString() + "'");
                        sb.AppendLine(",'" + dr["fullname"].ToString() + "'");
                        sb.AppendLine(",'" + dr["name"].ToString() + "'");
                        sb.AppendLine(",'" + dr["car_name"].ToString() + "'");
                        sb.AppendLine("," + dr["location_id"].ToString());
                        sb.AppendLine("," + dr["kbn"].ToString());
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
