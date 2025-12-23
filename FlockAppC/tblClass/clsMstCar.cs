using FlockAppC.pubClass;
using System;
using System.Data;
using System.Text;

namespace FlockAppC.tblClass
{
    public class ClsMstCar
    {
        public int id {  get; set; }
        public string car_no { get; set; }
        public string car_name { get; set; }
        public string reg_no { get; set; }
        public string base_no {  get; set; }
        public DateTime first_date { get; set; }
        public DateTime get_date { get; set; }
        public DateTime full_date { get; set; }
        public string etc { get; set; }
        public int used_user_id { get; set; }
        public string comment { get; set; }
        public DataTable Dt { get; set; }              // Select結果

        // オイル交換履歴情報
        public int oil_id { get; set; }
        public DateTime oil_change_date { get; set; }
        public int oil_change_odo { get; set; }
        public string oil_comment { get; set; }

        private readonly StringBuilder sb = new();

        /// <summary>
        /// Select
        /// </summary>
        public void Select()
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" Mst_社用車.id AS id");
                    sb.AppendLine(",car_no");
                    sb.AppendLine(",car_name");
                    sb.AppendLine(",reg_no");
                    sb.AppendLine(",base_no");
                    sb.AppendLine(",first_date");
                    sb.AppendLine(",get_date");
                    sb.AppendLine(",full_date");
                    sb.AppendLine(",etc");
                    sb.AppendLine(",used_user_id");
                    sb.AppendLine(",Mst_社用車.comment AS comment");
                    sb.AppendLine(",Mst_社員.name1");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_社用車");
                    sb.AppendLine("LEFT JOIN");
                    sb.AppendLine("Mst_社員");
                    sb.AppendLine("ON");
                    sb.AppendLine("used_user_id = Mst_社員.staff_id");
                    if (this.id > 0)
                    {
                        sb.AppendLine("WHERE");
                        sb.AppendLine("Mst_社用車.id = " + id);
                    }
                    else
                    {
                        sb.AppendLine("WHERE");
                        sb.AppendLine("Mst_社用車.delete_flag <> 1");
                        sb.AppendLine("ORDER BY");
                        sb.AppendLine("car_no");
                    }

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        this.Dt = dt_val;
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
        /// Select（オイル交換履歴）
        /// </summary>
        public void SelectOil()
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" Trn_社用車オイル交換履歴.id AS id");
                    sb.AppendLine(",Trn_社用車オイル交換履歴.car_id");
                    sb.AppendLine(",used_user_id");
                    sb.AppendLine(",Mst_社員.name1");
                    sb.AppendLine(",oil_change_date");
                    sb.AppendLine(",oil_change_odo");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Trn_社用車オイル交換履歴");
                    sb.AppendLine("LEFT JOIN");
                    sb.AppendLine("Mst_社員");
                    sb.AppendLine("ON");
                    sb.AppendLine("Mst_社員.staff_id = Trn_社用車オイル交換履歴.used_user_id");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("Trn_社用車オイル交換履歴.car_id = " + id);
                    sb.AppendLine("ORDER BY");
                    sb.AppendLine("oil_change_date");
                    sb.AppendLine("DESC");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        this.Dt = dt_val;
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
        /// INSERT ※INSERTしたレコードIDを返す
        /// </summary>
        /// <returns></returns>
        public int InsertScalar()
        {
            int new_id = -1;

            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("INSERT INTO");
                    sb.AppendLine("Mst_社用車");
                    sb.AppendLine("(");
                    sb.AppendLine(" car_no");
                    sb.AppendLine(",car_name");
                    sb.AppendLine(",reg_no");
                    sb.AppendLine(",base_no");
                    sb.AppendLine(",first_date");
                    sb.AppendLine(",get_date");
                    sb.AppendLine(",full_date");
                    sb.AppendLine(",etc");
                    sb.AppendLine(",used_user_id");
                    sb.AppendLine(",comment");
                    sb.AppendLine(",ins_user_id");
                    sb.AppendLine(",ins_date");
                    sb.AppendLine(",delete_flag");
                    sb.AppendLine(") VALUES (");
                    sb.AppendLine("'" + this.car_no + "'");
                    sb.AppendLine(",'" + this.car_name + "'");
                    sb.AppendLine(",'" + this.reg_no + "'");
                    sb.AppendLine(",'" + this.base_no + "'");
                    sb.AppendLine(",'" + this.first_date + "'");
                    sb.AppendLine(",'" + this.get_date + "'");
                    sb.AppendLine(",'" + this.full_date + "'");
                    sb.AppendLine(",'" + this.etc + "'");
                    sb.AppendLine("," + this.used_user_id);
                    sb.AppendLine(",'" + this.comment + "'");
                    sb.AppendLine("," + ClsLoginUser.StaffID);
                    sb.AppendLine(",'" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    sb.AppendLine("," + ClsPublic.FLAG_OFF);
                    sb.AppendLine("); SELECT SCOPE_IDENTITY();");

                    new_id = clsSqlDb.DMLUpdateScalar(sb.ToString());
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
        /// UPDATE
        /// </summary>
        public void Update()
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("UPDATE");
                    sb.AppendLine("Mst_社用車");
                    sb.AppendLine("SET");
                    sb.AppendLine(" car_no = '" + this.car_no + "'");
                    sb.AppendLine(",car_name = '" + this.car_name + "'");
                    sb.AppendLine(",reg_no = '" + this.reg_no + "'");
                    sb.AppendLine(",base_no = '" + this.base_no + "'");
                    sb.AppendLine(",first_date = '" + this.first_date + "'");
                    sb.AppendLine(",get_date = '" + this.get_date + "'");
                    sb.AppendLine(",full_date = '" + this.full_date + "'");
                    sb.AppendLine(",etc = '" + this.etc + "'");
                    sb.AppendLine(",used_user_id = " + this.used_user_id);
                    sb.AppendLine(",comment = '" + this.comment + "'");
                    sb.AppendLine(",ins_user_id = " + ClsLoginUser.StaffID);
                    sb.AppendLine(",ins_date = '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    sb.AppendLine(",delete_flag = " + ClsPublic.FLAG_OFF);
                    sb.AppendLine("WHERE");
                    sb.AppendLine("id = " + this.id);

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
        /// SQL Serverテーブル値をXServerのmySQLに登録
        /// </summary>
        public void ExportCarData(ref System.Windows.Forms.ProgressBar p_pgb)
        {
            int rec_cnt;
            int importCnt = 0;

            try
            {
                using (ClsMySqlDb clsMySqlDb = new(ClsDbConfig.MySQLNo))
                {
                    /////////////////////////////////////////////////////////////////////////
                    // TRUNCATE TABLE
                    // テーブルをクリア
                    /////////////////////////////////////////////////////////////////////////
                    sb.Clear();
                    sb.AppendLine("TRUNCATE TABLE");
                    sb.AppendLine("Mst_社用車");
                    
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
                        sb.AppendLine(",car_no");
                        sb.AppendLine(",car_name");
                        sb.AppendLine(",reg_no");
                        sb.AppendLine(",base_no");
                        sb.AppendLine(",first_date");
                        sb.AppendLine(",get_date");
                        sb.AppendLine(",fulldate");
                        sb.AppendLine(",etc");
                        sb.AppendLine(",used_user_id");
                        sb.AppendLine(",comment");
                        // 2025/11/10↓
                        sb.AppendLine(",ins_user_id");
                        sb.AppendLine(",ins_date");
                        sb.AppendLine(",upd_user_id");
                        sb.AppendLine(",upd_date");
                        sb.AppendLine(",delete_flag");
                        // 2025/11/10↑
                        sb.AppendLine("FROM");
                        sb.AppendLine("Mst_社用車");

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
                                sb.AppendLine("INSERT INTO Mst_社用車 (");
                                sb.AppendLine(" id");
                                sb.AppendLine(",car_no");
                                sb.AppendLine(",car_name");
                                sb.AppendLine(",reg_no");
                                sb.AppendLine(",base_no");
                                sb.AppendLine(",first_date");
                                sb.AppendLine(",get_date");
                                sb.AppendLine(",full_date");
                                sb.AppendLine(",etc");
                                sb.AppendLine(",used_user_id");
                                sb.AppendLine(",comment");
                                // 2025/11/10↓
                                sb.AppendLine(",ins_user_id");
                                sb.AppendLine(",ins_date");
                                sb.AppendLine(",upd_user_id");
                                sb.AppendLine(",upd_date");
                                sb.AppendLine(",delete_flag");
                                // 2025/11/10↑
                                sb.AppendLine(") VALUES (");
                                sb.AppendLine(dr["id"].ToString());
                                sb.AppendLine(",'" + dr["car_no"].ToString() + "'");
                                sb.AppendLine(",'" + dr["car_name"].ToString() + "'");
                                sb.AppendLine(",'" + dr["reg_no"].ToString() + "'");
                                sb.AppendLine(",'" + dr["base_no"].ToString() + "'");
                                sb.AppendLine(",'" + dr["firstdate"].ToString() + "'");
                                sb.AppendLine(",'" + dr["get_date"].ToString() + "'");
                                sb.AppendLine(",'" + dr["full_date"].ToString() + "'");
                                sb.AppendLine(",'" + dr["etc"].ToString() + "'");
                                sb.AppendLine("," + dr["used_user_id"].ToString());
                                sb.AppendLine(",'" + dr["comment"].ToString() + "'");
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
        /// SQL Serverテーブル値をXServerのmySQLに登録
        /// </summary>
        public void ExportOneCarData(int p_id, ClsSqlDb clsSqlDb, ClsMySqlDb clsMySqlDb)
        {
            try
            {
                /////////////////////////////////////////////////////////////////////////
                // 登録データ削除
                /////////////////////////////////////////////////////////////////////////
                sb.Clear();
                sb.AppendLine("DELETE FROM");
                sb.AppendLine("Mst_社用車");
                sb.AppendLine("WHERE");
                sb.AppendLine("id = " + p_id);
                clsMySqlDb.DMLUpdate(sb.ToString());

                /////////////////////////////////////////////////////////////////////////
                // データ登録
                /////////////////////////////////////////////////////////////////////////
                sb.Clear();
                sb.AppendLine("SELECT");
                sb.AppendLine(" id");
                sb.AppendLine(",car_no");
                sb.AppendLine(",car_name");
                sb.AppendLine(",reg_no");
                sb.AppendLine(",base_no");
                sb.AppendLine(",first_date");
                sb.AppendLine(",get_date");
                sb.AppendLine(",full_date");
                sb.AppendLine(",etc");
                sb.AppendLine(",used_user_id");
                sb.AppendLine(",comment");
                sb.AppendLine(",ins_user_id");
                sb.AppendLine(",ins_date");
                sb.AppendLine(",upd_user_id");
                sb.AppendLine(",upd_date");
                sb.AppendLine(",delete_flag");
                sb.AppendLine("FROM");
                sb.AppendLine("Mst_社用車");
                sb.AppendLine("WHERE");
                sb.AppendLine("id = " + p_id);

                using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                {
                    this.Dt = dt_val;
                }

                // MySQL INSERT
                foreach (DataRow dr in this.Dt.Rows)
                {
                    sb.Clear();
                    sb.AppendLine("INSERT INTO Mst_社用車 (");
                    sb.AppendLine(" id");
                    sb.AppendLine(",car_no");
                    sb.AppendLine(",car_name");
                    sb.AppendLine(",reg_no");
                    sb.AppendLine(",base_no");
                    sb.AppendLine(",first_date");
                    sb.AppendLine(",get_date");
                    sb.AppendLine(",full_date");
                    sb.AppendLine(",etc");
                    sb.AppendLine(",used_user_id");
                    sb.AppendLine(",comment");
                    sb.AppendLine(",ins_user_id");
                    sb.AppendLine(",ins_date");
                    sb.AppendLine(",upd_user_id");
                    sb.AppendLine(",upd_date");
                    sb.AppendLine(",delete_flag");
                    sb.AppendLine(") VALUES (");
                    sb.AppendLine(dr["id"].ToString());
                    sb.AppendLine(",'" + dr["car_no"].ToString() + "'");
                    sb.AppendLine(",'" + dr["car_name"].ToString() + "'");
                    sb.AppendLine(",'" + dr["reg_no"].ToString() + "'");
                    sb.AppendLine(",'" + dr["base_no"].ToString() + "'");
                    sb.AppendLine(",'" + dr["first_date"].ToString() + "'");
                    sb.AppendLine(",'" + dr["get_date"].ToString() + "'");
                    sb.AppendLine(",'" + dr["full_date"].ToString() + "'");
                    sb.AppendLine(",'" + dr["etc"].ToString() + "'");
                    sb.AppendLine("," + dr["used_user_id"].ToString());
                    sb.AppendLine(",'" + dr["comment"].ToString() + "'");
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
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
        }
    }
}
