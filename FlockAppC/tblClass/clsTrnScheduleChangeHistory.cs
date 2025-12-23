using FlockAppC.pubClass;
using System;
using System.Data;
using System.Text;

namespace FlockAppC.tblClass
{
    public class ClsTrnScheduleChangeHistory
    {
        public int Id { get; set; }
        public DateTime RegDate { get; set; }
        public int RegUserID {  get; set; }
        public string RegUserName { get; set; }
        public int TantoID { get; set; }
        public string TantoName { get; set; }
        public DateTime Day { get; set; }
        public string BeforeContent { get; set; }
        public string AfterContent { get; set; }
        public string Status { get; set; }

        private readonly StringBuilder sb = new();

        /// <summary>
        /// ===============================================================================
        /// 取得　SELECT
        /// ===============================================================================
        /// </summary>
        public void Select()
        {
            try
            {
                // SQL Server
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" id");
                    sb.AppendLine(",reg_date");
                    sb.AppendLine(",reg_user_id");
                    sb.AppendLine(",reg_user_name");
                    sb.AppendLine(",tanto_id");
                    sb.AppendLine(",tanto_name");
                    sb.AppendLine(",day");
                    sb.AppendLine(",before_content");
                    sb.AppendLine(",after_content");
                    sb.AppendLine(",status");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Trn_勤務表シフト変更履歴");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            Id = int.Parse(dr["id"].ToString());
                            RegDate = DateTime.Parse(dr["reg_date"].ToString());
                            RegUserID = int.Parse(dr["reg_user_id"].ToString());
                            RegUserName = dr["reg_user_name"].ToString();
                            TantoID = int.Parse(dr["tanto_id"].ToString());
                            TantoName = dr["tanto_name"].ToString();
                            Day = DateTime.Parse(dr["day"].ToString());
                            BeforeContent = dr["before_content"].ToString();
                            AfterContent = dr["after_content"].ToString();
                            Status = dr["status"].ToString();
                            break;
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
        /// ===============================================================================
        /// 追加登録 INSERT
        /// ===============================================================================
        /// </summary>
        public void Insert()
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("INSERT INTO");
                    sb.AppendLine("Trn_勤務表シフト変更履歴");
                    sb.AppendLine("(");
                    sb.AppendLine(" reg_date");
                    sb.AppendLine(",reg_user_id");
                    sb.AppendLine(",reg_user_name");
                    sb.AppendLine(",tanto_id");
                    sb.AppendLine(",tanto_name");
                    sb.AppendLine(",day");
                    sb.AppendLine(",before_content");
                    sb.AppendLine(",after_content");
                    sb.AppendLine(",status");
                    sb.AppendLine(") VALUES (");
                    sb.AppendLine("'" + RegDate.ToString("yyyy/MM/dd hh:mm:ss") + "'");
                    sb.AppendLine("," + RegUserID);
                    sb.AppendLine(",'" + RegUserName + "'");
                    sb.AppendLine("," + TantoID);
                    sb.AppendLine(",'" + TantoName + "'");
                    sb.AppendLine(",'" + Day.ToString("yyyy/MM/dd") + "'");
                    sb.AppendLine(",'" + BeforeContent + "'");
                    sb.AppendLine(",'" + AfterContent + "'");
                    sb.AppendLine(",'" + Status + "'");
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
    }
}
