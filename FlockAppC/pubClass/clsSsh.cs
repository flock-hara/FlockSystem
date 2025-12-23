using Renci.SshNet;
using System;
using System.Configuration;

namespace FlockAppC.pubClass
{
    public class ClsSsh : IDisposable
    {
        public const bool ConstOK = true;
        public const bool ConstNG = false;

        public SshClient SshClient;
        public ForwardedPortLocal ForwardedPortLocal;

        private bool _disposed = false;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ClsSsh()
        {
            ServeAddress = ConfigurationManager.AppSettings["mySQL_ServeAddress"];
            SshPort = int.Parse(ConfigurationManager.AppSettings["mySQL_SshPort"]);
            ServerUserId = ConfigurationManager.AppSettings["mySQL_ServerUserId"];
            ServerPassword = ConfigurationManager.AppSettings["mySQL_ServerPassword"];
            SshKey = ConfigurationManager.AppSettings["mySQL_SshKey"];
            SshKeyPassPhrase = ConfigurationManager.AppSettings["mySQL_SshKeyPassPhrase"];
            LocalAddress = ConfigurationManager.AppSettings["mySQL_LocalAddress"];
            LocalPort = int.Parse(ConfigurationManager.AppSettings["mySQL_LocalPort"]);
            MySqlAddress = ConfigurationManager.AppSettings["mySQL_MySqlAddress"];
            MySqlPort = int.Parse(ConfigurationManager.AppSettings["mySQL_MySqlPort"]);
        }

        //  *******************************************************************
        //  SSHでXSERVERのMySQLに接続する
        //  *******************************************************************
        public bool SshConnect()
        {
            // 接続中メッセージ表示
            if (ClsPublic.lblConnect != null)
            {
                ClsPublic.lblConnect.Visible = true;
                ClsPublic.lblConnect.Refresh();
            }

            //  SSH接続
            try
            {
                var _PassAuth = new PasswordAuthenticationMethod(ServerUserId, ServerPassword);   // パスワード認証
                                                                                                  // 秘密鍵認証
                var _PrivateKey = new PrivateKeyAuthenticationMethod(ServerUserId, new PrivateKeyFile[]
                {
                 new PrivateKeyFile(SshKey, SshKeyPassPhrase)
                });
                // 接続情報の生成
                ConnectionInfo ConnNfo = new(ServeAddress, SshPort, ServerUserId, new AuthenticationMethod[]
                {
                _PassAuth,          // パスワード認証
                _PrivateKey,        // 秘密鍵認証
                });
                SshClient = new SshClient(ConnNfo);                 //  sshクライアント生成
                SshClient.Connect();                                //  ssh接続
                if (!SshClient.IsConnected)
                {
                    Console.WriteLine("SSH Connection Error No1");
                    return ConstNG;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SSH Connection Error No2");
                Console.WriteLine(ex.Message);
                return ConstNG;
            }
            // 接続中メッセージ非表示
            if (ClsPublic.lblConnect != null)
            {
                ClsPublic.lblConnect.Visible = false;
                ClsPublic.lblConnect.Refresh();
            }
            return ConstOK;
        }
        //  *******************************************************************
        //  SSHクローズ
        //  *******************************************************************
        public void SshDeconnect()
        {
            if (SshClient != null)
            {
                SshClient.Disconnect();
            }
        }
        //  *******************************************************************
        //  ポートフォワーディング開始
        //  *******************************************************************
        public bool PortForwardStart()
        {
            try
            {
                ForwardedPortLocal = new ForwardedPortLocal(LocalAddress, (uint)LocalPort, MySqlAddress, (uint)MySqlPort);
                SshClient.AddForwardedPort(ForwardedPortLocal);
                ForwardedPortLocal.Start();
                if (!ForwardedPortLocal.IsStarted)
                {
                    Console.WriteLine("forwardedPortLocal ERROR No1");
                    return ConstNG;
                }
                //  var BoundHostaddress    =   ForwardedPortLocal.BoundHost;
                //  var BoundHostPort       =   ForwardedPortLocal.BoundPort;
            }
            catch (Exception ex)
            {
                Console.WriteLine("forwardedPortLocal ERROR No2");
                Console.WriteLine(ex.Message);
                return ConstNG;
            }
            return ConstOK;
        }
        //  *******************************************************************
        //  ポートフォワーディング終了
        //  *******************************************************************
        public void PortForwardStop()
        {
            if (ForwardedPortLocal != null)
            {
                ForwardedPortLocal.Stop();
            }
        }
        /// <summary>
        /// Dispose実装
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
                    // マネージドリソースの解放
                    try
                    {
                        ForwardedPortLocal?.Stop();
                        ForwardedPortLocal?.Dispose();
                    }
                    catch { }

                    try
                    {
                        if (SshClient != null)
                        {
                            if (SshClient.IsConnected)
                                SshClient.Disconnect();
                            SshClient.Dispose();
                        }
                    }
                    catch { }
                }

                // アンマネージドリソースがあればここで解放
                _disposed = true;
            }
        }
        ~ClsSsh()
        {
            Dispose(false);
        }

        private string ServeAddress { get; set; }
        private int SshPort { get; set; }
        private string ServerUserId { get; set; }
        private string ServerPassword { get; set; }
        private string SshKey { get; set; }
        private string SshKeyPassPhrase { get; set; }
        private string LocalAddress { get; set; }
        private int LocalPort { get; set; }
        private string MySqlAddress { get; set; }
        private int MySqlPort { get; set; }
    }
}
