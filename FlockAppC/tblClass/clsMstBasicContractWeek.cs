using FlockAppC.pubClass;
using System;
using System.Data;
using System.Text;

namespace FlockAppC.tblClass
{
    public class ClsMstBasicContractWeek
    {
        public int Contract_time_id { get; set; }
        public int Sort { get; set; }
        public string Week { get; set; }

        private readonly StringBuilder sb = new();

        public void Insert()
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("INSERT INTO");
                    sb.AppendLine(" Mst_基本契約曜日");
                    sb.AppendLine("(");
                    sb.AppendLine(" contract_time_id");
                    sb.AppendLine(",sort");
                    sb.AppendLine(",week");
                    // 2025/11/10↓
                    sb.AppendLine(",ins_user_id");
                    sb.AppendLine(",ins_date");
                    sb.AppendLine(",delete_flag");
                    // 2025/11/10↑
                    sb.AppendLine(") VALUES (");
                    sb.AppendLine(Contract_time_id.ToString());
                    sb.AppendLine("," + Sort);
                    sb.AppendLine(",'" + Week + "'");

                    // 2025/11/10↓
                    sb.AppendLine("," + ClsLoginUser.StaffID);
                    sb.AppendLine(",'" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    sb.AppendLine("," + ClsPublic.FLAG_OFF);
                    // 2025/11/10↑

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
        /// Delete
        /// </summary>
        public void Delete()
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("DELETE FROM");
                    sb.AppendLine(" Mst_基本契約曜日");
                    sb.AppendLine("WHERE");
                    sb.AppendLine(" contract_time_id = " + this.Contract_time_id);

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
        public void ExportBasicContractWeekData(ref System.Windows.Forms.ProgressBar p_pgb)
        {
            int rec_cnt;
            int importCnt = 0;

            // =============================================================================
            // １．MySQLに作業用テーブルを作成
            // ２．SQL Serverの全データをMySQLの作業用テーブルにINSERT
            // ３．SQL Serverテーブルと作業用テーブルを比較
            // ４．本番テーブルをリネーム
            // ５．作業用テーブルを本番テーブルにリネーム
            // ６．不要となった旧本番テーブルを削除
            // =============================================================================

            try
            {
                // xserver(mySQL)接続
                using (ClsMySqlDb clsMySqlDb = new(ClsDbConfig.MySQLNo))
                {
                    // １．MySQLに作業用テーブルを作成
                    sb.Clear();
                    sb.AppendLine("CREATE TABLE Mst_基本契約曜日_work LIKE Mst_基本契約曜日");
                    clsMySqlDb.DMLUpdate(sb.ToString());

                    // ２．SQL Serverの全データをMySQLの作業用テーブルにINSERT
                    using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                    {
                        // SQL Server SELECT ALL
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
                                sb.AppendLine("INSERT INTO Mst_基本契約曜日_work (");
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
                                if (dr.IsNull("week") != true) { sb.AppendLine(",'" + dr["week"].ToString() + "'"); }
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
                                else { sb.AppendLine("," + ClsPublic.FLAG_OFF); }
                                sb.AppendLine(")");
                                clsMySqlDb.DMLUpdate(sb.ToString());

                                importCnt++;

                                // ProgressBar値セット
                                p_pgb.Value = importCnt;
                                p_pgb.Refresh();
                            }
                        }
                        // ３．SQL Serverテーブルと作業用テーブルを比較
                        int cnt;
                        sb.Clear();
                        sb.AppendLine("SELECT COUNT(*) AS rec_cnt2 FROM Mst_基本契約曜日_work");         // MySQL側
                        using (DataTable dt_val = clsMySqlDb.DMLSelect(sb.ToString()))
                        {
                            cnt = int.Parse(dt_val.Rows[0]["rec_cnt2"].ToString());
                        }
                        if (rec_cnt != cnt)
                        {
                            // レコード件数不一致エラー
                            throw new Exception("基本契約曜日マスターのエクスポートでレコード件数不一致エラーが発生しました。");
                        }
                        // ４．本番テーブルをリネーム
                        // ５．作業用テーブルを本番テーブルにリネーム
                        sb.Clear();
                        sb.AppendLine("RENAME TABLE");
                        sb.AppendLine("Mst_基本契約曜日 TO Mst_基本契約曜日_old,");
                        sb.AppendLine("Mst_基本契約曜日_work TO Mst_基本契約曜日;");
                        clsMySqlDb.DMLUpdate(sb.ToString());

                        // ６．不要となった旧本番テーブルを削除
                        sb.Clear();
                        sb.AppendLine("DROP TABLE Mst_基本契約曜日_old;");
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
