using FlockAppC.pubClass;
using System;
using System.Data;
using System.Text;

namespace FlockAppC.tblClass
{
    public class ClsMstHoliday
    {
        private readonly StringBuilder sb = new();

        /// <summary>
        /// SQL Serverテーブル値をXServerのmySQLに登録
        /// </summary>
        public void ExportHolidayData()
        {
            try
            {
                using (ClsMySqlDb clsMySqlDb = new(ClsDbConfig.MySQLNo))
                {
                    /////////////////////////////////////////////////////////////////////////
                    // TRUNCATE TABLE (MySQL)
                    // テーブルをクリア
                    /////////////////////////////////////////////////////////////////////////
                    sb.Clear();
                    sb.AppendLine("TRUNCATE TABLE");
                    sb.AppendLine("Mst_休日");
                    
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
                        sb.AppendLine(" year");
                        sb.AppendLine(",day");
                        sb.AppendLine(",holiday");
                        sb.AppendLine(",kbn");
                        // 2025/11/10↓
                        sb.AppendLine(",ins_user_id");
                        sb.AppendLine(",ins_date");
                        sb.AppendLine(",upd_user_id");
                        sb.AppendLine(",upd_date");
                        sb.AppendLine(",delete_flag");
                        // 2025/11/10↑
                        sb.AppendLine("FROM");
                        sb.AppendLine("Mst_休日");
                        sb.AppendLine("ORDER BY");
                        sb.AppendLine("year,day");

                        using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                        {
                            // MySQL INSERT
                            foreach (DataRow dr in dt_val.Rows)
                            {
                                sb.Clear();
                                sb.AppendLine("INSERT INTO Mst_休日 (");
                                sb.AppendLine(" year");
                                sb.AppendLine(",day");
                                sb.AppendLine(",holiday");
                                sb.AppendLine(",kbn");
                                // 2025/11/10↓
                                sb.AppendLine(",ins_user_id");
                                sb.AppendLine(",ins_date");
                                sb.AppendLine(",upd_user_id");
                                sb.AppendLine(",upd_date");
                                sb.AppendLine(",delete_flag");
                                // 2025/11/10↑
                                sb.AppendLine(") VALUES (");
                                sb.AppendLine(dr["year"].ToString());
                                sb.AppendLine(",'" + dr["day"].ToString() + "'");
                                sb.AppendLine(",'" + dr["holiday"].ToString() + "'");
                                sb.AppendLine(",0");
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
    }
}
