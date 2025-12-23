using MySql.Data.MySqlClient;
using System;
using System.Data;

// ==========================================================================
// MySQL(XServer)アクセスクラス
// ==========================================================================

namespace FlockAppC.pubClass
{
    public class ClsMySqlDb : IDisposable
    {
        // 接続情報:User ID/Password/Database Name
        private readonly string _user_id;
        private readonly string _password;
        private readonly string _database_name;

        private readonly MySqlConnection _con = new();
        private readonly ClsSsh _ssh = new();
        private MySqlCommand _com;
        private MySqlTransaction _trn;

        // 要素が破棄されたかどうかを示すフラグ
        private bool _disposed = false;

        // ssh接続リトライカウント
        private readonly int retry_count = 5;

        /// <summary>
        /// コンストラクター（SSH接続、データベース接続迄行う）
        /// </summary>
        /// <param name="p_type"></param>
        public ClsMySqlDb(int p_type = 0)
        {
            // publicから接続情報取得
            _user_id = ClsDbConfig.mysqlParam[p_type].UserID;
            _password = ClsDbConfig.mysqlParam[p_type].Password;
            _database_name = ClsDbConfig.mysqlParam[p_type].Database;

            DbConnect();
        }

        /// <summary>
        /// MySQL,SSH接続
        /// </summary>
        /// <returns></returns>
        public bool DbConnect()
        {
            int retry;

            for (retry = 0; retry <= retry_count; retry++)
            {
                if (retry == retry_count)
                {
                    Console.WriteLine("SSH接続エラー リトライオーバー");
                    return false;
                }

                //  ssh接続
                if (_ssh.SshConnect() != ClsSsh.ConstOK)
                {
                    Console.WriteLine("SSH接続エラー : " + retry);

                    //一秒間（1000ミリ秒）停止する
                    System.Threading.Thread.Sleep(1000);

                    continue;
                    // return CONST_NG;
                }
                Console.WriteLine("SSH接続OK : " + retry);
                break;
            }
            //  ポートフォワーディング開始
            if (_ssh.PortForwardStart() != ClsSsh.ConstOK)
            {
                Console.WriteLine("ポートフォワーディング開始エラー");
                return false;
            }

            try
            {
                var server = _ssh.ForwardedPortLocal.BoundHost;
                var port = _ssh.ForwardedPortLocal.BoundPort;
                _con.ConnectionString = string.Format("Server={0};Database={1};Uid={2};Pwd={3};Port={4};Pooling=False;",
                    server,
                    _database_name,
                    _user_id, 
                    _password, 
                    port);
                _con.Open();
            }
            catch (MySqlException ex)
            {
                ClsLogger.Log(ex.ToString());
                Console.WriteLine(string.Format("DATABASE:{0} CONNECT ERROR", _database_name));
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        /// <summary>
        /// MySQL,SSH切断
        /// </summary>
        public void DbClose()
        {
            _ssh.PortForwardStop();
            _ssh.SshDeconnect();
            _con.Close();
        }

        /// <summary>
        /// SQL (DML : SELECT)
        /// </summary>
        public DataTable DMLSelect(string p_sql)
        {
            DataTable dt;

            try
            {
                // SQLが空の場合は処理しない
                if (string.IsNullOrEmpty(p_sql)) return null;

                _com = _con.CreateCommand();

                // SQLセット
                _com.CommandText = p_sql;

                //  SELECTしてDataTableに取り込む
                MySqlDataAdapter dataAdapter = new(_com);

                // DataTableへセット
                dt = new DataTable();
                dataAdapter.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                // エラー
                ClsLogger.Log(ex.ToString());
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// SQL (DML : INSERT,DELETE,UPDATE,etc...)
        /// </summary>
        public bool DMLUpdate(string p_sql)
        {
            // SQLが空の場合は処理しない
            if (string.IsNullOrEmpty(p_sql)) return false;

            try
            {
                _com = _con.CreateCommand();

                // トランザクション
                _com.Connection = _con;
                _com.Transaction = _trn;

                // SQLセット
                _com.CommandText = p_sql;

                // SQL発行
                _com.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                // エラー
                ClsLogger.Log(ex.ToString());
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Transaction
        /// </summary>
        public void BeginTrn()
        {
            try
            {
                if (_trn == null)
                {
                    _trn = _con.BeginTransaction();
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
                _trn?.Commit();
                _trn?.Dispose();
                _trn = null;
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
                _trn?.Rollback();
                _trn?.Dispose();
                _trn = null;
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
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // トランザクション破棄
                    _trn?.Dispose();
                    _trn = null;

                    // コマンド破棄
                    _com?.Dispose();
                    _com = null;

                    // MySQL接続破棄
                    if (_con != null)
                    {
                        _con.Close();
                        _con.Dispose();
                    }

                    // SSHセッション破棄（ClsSsh が IDisposable の場合）
                    if (_ssh is IDisposable disposableSsh)
                    {
                        disposableSsh.Dispose();
                    }
                    else
                    {
                        // IDisposable でない場合でも Close 相当が必要
                        _ssh.PortForwardStop();
                        _ssh.SshDeconnect();
                    }
                }

                _disposed = true;
            }
        }

        ~ClsMySqlDb()
        {
            Dispose(false);
        }        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

        ///// <summary>
        ///// Disposeパターン用 protected virtual
        ///// </summary>
        ///// <param name="disposing"></param>
        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!_disposed)
        //    {
        //        if (disposing)
        //        {
        //            DbClose();
        //        }
        //        _disposed = true;
        //    }
        //}

        ///// <summary>
        ///// ファイナライザ
        ///// </summary>
        //~ClsMySqlDb()
        //{
        //    Dispose(false);
        //}
    }
}
