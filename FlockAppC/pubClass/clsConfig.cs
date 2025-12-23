using System;
using System.Data;
using System.Text;

// ======================================================================================
// 勤務表環境設定テーブル読み込みクラス
// ======================================================================================
namespace FlockAppC.pubClass
{
    public class ClsConfig
    {
        public int Id { get; set; }                         // レコードID　1:当月/2:翌月
        public string FilePath { get; set; }                // パス付き勤務表ファイル名
        public string FileName { get; set; }                // 勤務表ファイル名（パス無し）
        public string SheetName { get; set; }               // シート名
        public string RefreshTimer { get; set; }            // 勤務表再表示間隔
        public int Year { get; set; }                       // 対象年度
        public int Month { get; set; }                      // 対象月度
        public string StartDate { get; set; }               // 対象年月の月初日
        public string EndDate { get; set; }                 // 対象年月の月締め日

        private readonly StringBuilder sb = new();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="p_pid"></param>
        public ClsConfig(int p_pid = 0)
        {
            // 初期化
            // sb = new StringBuilder();
            // システム環境値取得
            Get_config(p_pid);
        }

        /// <summary>
        /// システム環境値取得
        /// </summary>
        /// <param name="p_id">0:当月/1:翌月</param>
        private void Get_config(int p_id = 0)
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    FilePath = "";

                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" id");
                    sb.AppendLine(",file_path");
                    sb.AppendLine(",file_name");
                    sb.AppendLine(",sheet_name");
                    sb.AppendLine(",refresh_timer");
                    sb.AppendLine(",year");
                    sb.AppendLine(",month");
                    sb.AppendLine(",start_date");
                    sb.AppendLine(",end_date");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_勤務表環境設定");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("id = " + p_id);

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            Id = int.Parse(dr["id"].ToString());
                            FilePath = dr["file_path"].ToString();
                            FileName = dr["file_name"].ToString();
                            SheetName = dr["sheet_name"].ToString();
                            RefreshTimer = dr["refresh_timer"].ToString();
                            Year = int.Parse(dr["year"].ToString());
                            Month = int.Parse(dr["month"].ToString());
                            StartDate = dr["start_date"].ToString();
                            EndDate = dr["end_date"].ToString();
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // 例外処理を追加
                ClsLogger.Log(ex.ToString());
                Console.WriteLine("エラーが発生しました: " + ex.Message);
                throw;
            }
        }
    }
}
