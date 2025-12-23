using FlockAppC.pubClass;
using System;
using System.Data;
using System.Text;

namespace FlockAppC.tblClass
{
    public class ClsTrnSchedule
    {
        public int Id { get; set; }

        public DateTime Day { get; set; }

        public string Schedule {  get; set; }

        public int TantoID { get; set; }

        public DateTime ScheduleStartTime { get; set; }

        public DateTime ScheduleEndTime { get; set; }

        public int ReturnFlag { get; set; }

        public int Status { get; set; }

        public DataTable Dt {  get; set; }

        private readonly StringBuilder sb = new();

        /// <summary>
        /// SELECT
        /// </summary>
        public void DMLSelect()
        {
            try
            {
                // MySQLが対象 -> SQL Serverに変更
                // using (ClsMySqlDb clsMySqlDb = new(ClsDbConfig.MySQLNo))
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" id");
                    sb.AppendLine(",day");
                    sb.AppendLine(",schedule");
                    sb.AppendLine(",tanto_id");
                    sb.AppendLine(",schedule_start_time");
                    sb.AppendLine(",schedule_end_time");
                    sb.AppendLine(",return_flag");
                    sb.AppendLine(",status");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Trn_予定履歴");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("id = " + Id.ToString());
                    sb.AppendLine("AND");
                    sb.AppendLine("delete_flag <> 1");
                    
                    this.Dt = clsSqlDb.DMLSelect(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// SELECT  2025/08/26 UPD
        /// </summary>
        public void DMLSelectDay()
        {
            try
            {
                // MySQLが対象 -> SQL Serverに変更
                // using (ClsMySqlDb clsMySqlDb = new(ClsDbConfig.MySQLNo))
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" Trn_予定履歴.id");
                    sb.AppendLine(",Trn_予定履歴.day");
                    sb.AppendLine(",Trn_予定履歴.schedule");
                    sb.AppendLine(",Trn_予定履歴.tanto_id");
                    sb.AppendLine(",Mst_社員.name1");
                    sb.AppendLine(",Trn_予定履歴.schedule_start_time");
                    sb.AppendLine(",Trn_予定履歴.schedule_end_time");
                    sb.AppendLine(",Trn_予定履歴.return_flag");
                    sb.AppendLine(",Trn_予定履歴.status");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Trn_予定履歴");
                    sb.AppendLine("LEFT JOIN");
                    sb.AppendLine("Mst_社員");
                    sb.AppendLine("ON");
                    sb.AppendLine("Trn_予定履歴.tanto_id = Mst_社員.staff_id");
                    sb.AppendLine("AND");
                    sb.AppendLine("(Mst_社員.delete_flag = 0 OR Mst_社員.delete_flag IS NULL)");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("Trn_予定履歴.Day = '" + Day.ToString("yyyy/MM/dd") + "'");
                    // sb.AppendLine("WHERE");
                    // sb.AppendLine("Trn_予定履歴.Day = '" + Day.ToString("yyyy/MM/dd") + "'");
                    sb.AppendLine("AND");
                    sb.AppendLine("Mst_社員.delete_flag <> " + ClsPublic.FLAG_ON);
                    
                    this.Dt = clsSqlDb.DMLSelect(sb.ToString());
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
        public void DMLUpdate()
        {
            try
            {
                // MySQLが対象 -> SQL Serverに変更
                // using (ClsMySqlDb clsMySqlDb = new(ClsDbConfig.MySQLNo))
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("UPDATE");
                    sb.AppendLine("Trn_予定履歴");
                    sb.AppendLine("SET");
                    sb.AppendLine(" day = '" + Day.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    sb.AppendLine(",schedule = '" + Schedule + "'");
                    sb.AppendLine(",tanto_id = " + TantoID);
                    sb.AppendLine(",schedule_start_time = '" + ScheduleStartTime.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    sb.AppendLine(",schedule_end_time = '" + ScheduleEndTime.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    sb.AppendLine(",return_flag = " + ReturnFlag);
                    sb.AppendLine(",status = " + Status);
                    sb.AppendLine(",delete_flag = " + ClsPublic.FLAG_OFF);
                    sb.AppendLine("WHERE");
                    sb.AppendLine(" id = " + Id);

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
        /// INSERT
        /// </summary>
        public void DMLInsert()
        {
            try
            {
                // MySQLが対象 -> SQL Serverに変更
                // using (ClsMySqlDb clsMySqlDb = new(ClsDbConfig.MySQLNo))
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("INSERT INTO");
                    sb.AppendLine("Trn_予定履歴");
                    sb.AppendLine("(");
                    sb.AppendLine(" day");
                    sb.AppendLine(",schedule");
                    sb.AppendLine(",tanto_id");
                    sb.AppendLine(",schedule_start_time");
                    sb.AppendLine(",schedule_end_time");
                    sb.AppendLine(",return_flag");
                    sb.AppendLine(",delete_flag");
                    sb.AppendLine(",status");
                    sb.AppendLine(") VALUES (");
                    sb.AppendLine(" '" + Day.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    sb.AppendLine(",'" + Schedule + "'");
                    sb.AppendLine("," + TantoID);
                    sb.AppendLine(",'" + ScheduleStartTime.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    sb.AppendLine(",'" + ScheduleEndTime.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    sb.AppendLine("," + ReturnFlag);
                    sb.AppendLine("," + ClsPublic.FLAG_OFF);
                    sb.AppendLine("," + ClsPublic.FLAG_OFF);
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
        /// DELETE
        /// </summary>
        public void DMLDelete()
        {
            try
            {
                // MySQLが対象 -> SQL Serverに変更
                // using (ClsMySqlDb clsMySqlDb = new(ClsDbConfig.MySQLNo))
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("UPDATE");
                    sb.AppendLine("Trn_予定履歴");
                    sb.AppendLine("SET");
                    sb.AppendLine("delete_flag = " + ClsPublic.FLAG_ON);
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
    }
}
