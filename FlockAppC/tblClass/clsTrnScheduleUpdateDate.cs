using FlockAppC.pubClass;
using System;
using System.Data;
using System.IO;
using System.Text;

namespace FlockAppC.tblClass
{
    public class ClsTrnScheduleUpdateDate
    {
        private readonly StringBuilder sb = new();

        /// <summary>
        /// 勤務表（エクセル）ファイルのタイムスタンプ情報を更新
        /// </summary>
        /// <param name="p_filename"></param>
        public void UpdateTimeStamp(string p_filename)
        {
            // 入力チェック
            if (p_filename == null || p_filename == "") { return; }

            // 最終更新日時を取得
            DateTime lastWriteTime = File.GetLastWriteTime(p_filename);
            var filename = Path.GetFileName(p_filename);

            // タイムスタンプ更新（無ければ追加）
            // StringBuilder st = new StringBuilder();
            
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" time_stamp");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Trn_勤務表更新日付");
                    sb.AppendLine("WHERE");
                    sb.AppendLine(" file_path = '" + p_filename + "'");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            // ファイルのタイムスタンプと前回（DB保持）のタイムスタンプを比較
                            if (lastWriteTime != DateTime.Parse(dr["time_stamp"].ToString()))
                            {
                                // 異なる場合はDBを最新のタイムスタンプに更新
                                // UPDATE
                                sb.Clear();
                                sb.AppendLine("UPDATE");
                                sb.AppendLine("Trn_勤務表更新日付");
                                sb.AppendLine("SET");
                                sb.AppendLine("time_stamp = '" + lastWriteTime + "'");
                                sb.AppendLine("WHERE");
                                sb.AppendLine("file_path = '" + p_filename + "'");

                                clsSqlDb.DMLUpdate(sb.ToString());
                            }
                            break;
                        }
                        if (dt_val.Rows.Count == 0)
                        {
                            // 前回（DB保持）が無い場合は追加登録
                            // INSERT
                            sb.Clear();
                            sb.AppendLine("INSERT INTO");
                            sb.AppendLine("Trn_勤務表更新日付");
                            sb.AppendLine("(");
                            sb.AppendLine(" file_path");
                            sb.AppendLine(",file_name");
                            sb.AppendLine(",time_stamp");
                            sb.AppendLine(") VALUES (");
                            sb.AppendLine("'" + p_filename + "'");
                            sb.AppendLine(",'" + filename + "'");
                            sb.AppendLine(",'" + lastWriteTime + "'");
                            sb.AppendLine(")");

                            clsSqlDb.DMLUpdate(sb.ToString());
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
        /// タイムスタンプチェック
        /// </summary>
        /// <param name="p_fimename"></param>
        /// <returns>0:同じ 1:異なる</returns>
        public int CheckTimeStamp(string p_filename)
        {
            var rtn = 0;

            // 入力チェック
            if (p_filename == null || p_filename == "") { return rtn; }

            // 最終更新日時を取得
            DateTime lastWriteTime = File.GetLastWriteTime(p_filename);

            // DB保持のタイムスタンプ取得
            // StringBuilder st = new StringBuilder();

            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("time_stamp");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Trn_勤務表更新日付");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("file_path = '" + p_filename + "'");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            // ファイルのタイムスタンプと前回（DB保持）のタイムスタンプを比較
                            if (lastWriteTime != DateTime.Parse(dr["time_stamp"].ToString()))
                            {
                                rtn = 1;
                            }
                        }
                    }
                }
                return rtn;
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
        }
    }
}
