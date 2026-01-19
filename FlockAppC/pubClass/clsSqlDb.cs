using System;
using System.Data;
using System.Data.SqlClient;

// ==========================================================================
// SQL Serverアクセスクラス
// ==========================================================================

namespace FlockAppC.pubClass
{
    public class ClsSqlDb : IDisposable
    {
        private SqlConnection Con { get; set; }             // 接続用
        // private SqlCommand Com { get; set; }                // SQLコマンド発行
        private SqlTransaction Trn { get; set; }            // トランザクション用

        // 要素が破棄されたかどうかを示すフラグ
        private bool _disposed = false;

        /// <summary>
        /// コンストラクター（データベース接続迄行う）
        /// </summary>
        /// <param name="p_type">ACT:0/TST:1</param>
        public ClsSqlDb(int p_type = 0)
        {
            // 指定DBをセット
            // dbtype = p_type;

            DbConnect(p_type);                      // Database接続
        }
        /// <summary>
        /// SQL Server接続
        /// </summary>
        /// <param name="p_type">0:本番/1:テスト</param>
        private void DbConnect(int p_type)
        {
            try
            {
                // 接続文字取得+接続
                // ConfigurationManagerは、usingに加えて、参照設定しておかないと使用出来ない。
                Con = new SqlConnection(ClsDbConfig.sqlParam[p_type].ConnectString);
                Con.Open();
            }
            catch (Exception ex)
            {
                // エラー
                ClsLogger.Log(ex.ToString());
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// SQL Server切断
        /// </summary>
        public void DbClose()
        {
            try
            {
                if (Con != null)
                {
                    Con.Close();
                    Con.Dispose();
                    Con = null;
                }
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.ToString());
                throw;
            }
        }

        /// <summary>
        /// SELECT
        /// </summary>
        public DataTable DMLSelect(string p_sql)
        {
            // SQLが空の場合は処理しない
            if (string.IsNullOrEmpty(p_sql)) return null;

            // DataTable dt;                       // Data Table（結果セット）

            try
            {
                using (var com = Con.CreateCommand())
                {
                    com.CommandText = p_sql;

                    using (var dataAdapter = new SqlDataAdapter(com))
                    {
                        var dt = new DataTable();
                        dataAdapter.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.ToString());
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// UPDATE, INSERT, DETELE
        /// </summary>
        /// <returns></returns>
        public bool DMLUpdate(string p_sql)
        {
            // SQLが空の場合は処理しない
            if (string.IsNullOrEmpty(p_sql)) return false;

            try
            {
                using (SqlCommand command = Con.CreateCommand())
                {
                    command.Transaction = Trn;
                    command.CommandText = p_sql;
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.ToString());
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// INSERTでIDを取得したい場合に使用
        /// </summary>
        /// <param name="p_sql"></param>
        /// <returns></returns>
        public int DMLUpdateScalar(string p_sql)
        {
            // SQLが空の場合は処理しない
            if (string.IsNullOrEmpty(p_sql)) return -1;

            int new_id;

            try
            {
                using (SqlCommand cmd = new SqlCommand(p_sql, Con))
                {
                    // INSERT された ID の取得
                    object result = cmd.ExecuteScalar();
                    new_id = Convert.ToInt32(result);
                }
                return new_id;
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.ToString());
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        /// <summary>
        /// Transaction
        /// </summary>
        public void BeginTrn()
        {
            try
            {
                if (Trn == null)
                {
                    Trn = Con.BeginTransaction();
                }
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.ToString());
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Commit
        /// </summary>
        public void CommitTrn()
        {
            try
            {
                Trn?.Commit();
                Trn?.Dispose();
                Trn = null;
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.ToString());
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Roll Back
        /// </summary>
        public void RollBackTrn()
        {
            try
            {
                Trn?.Rollback();
                Trn?.Dispose();
                Trn = null;
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.ToString());
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// IDisposable実装
        /// </summary>
        public void Dispose()
        {
            if (!_disposed)
            {
                Trn?.Dispose();
                Trn = null;

                if (Con != null)
                {
                    Con.Close();
                    Con.Dispose();
                    Con = null;
                }

                _disposed = true;
            }
        }
    }
}
