namespace FlockAppC.pubClass
{
    public static class ClsDbConfig
    {
        // =======================================================================
        // 2025/08/13 本番/テストの切換えを柔軟に行いたい
        // 基本的に以下を使用する
        // =======================================================================
        public static int SQLServerNo = 0;                          // SQL SERVER接続先（本番:0/テスト:1）
        public static int MySQLNo = 0;                              // MySQL接続先（本番:0/テスト:1）         
        //public const int ACT = 0;                                 // 本番
        //public const int TST = 1;                                 // テスト 

        public static ClsDbParam[] sqlParam = new ClsDbParam[2];    // SQL Server接続情報 [0]:本番/[1]:テスト
        public static ClsDbParam[] mysqlParam = new ClsDbParam[2];  // MySQL接続情報 [0]:本番/[1]:テスト

        /// <summary>
        /// =======================================================================
        /// データベース接続情報を読み込み、Static領域へ保持
        /// =======================================================================
        /// </summary>
        public static void LoadDBParam()
        {

            #region Initialize
            for (int i = 0; i < sqlParam.Length; i++)
            {
                sqlParam[i] = new ClsDbParam()
                {
                    UserID = "",
                    Password = "",
                    Database = "",
                    Instance = ""
                };
                //sqlParam[i] = new ClsDbParam();
                //sqlParam[i].UserID = "";
                //sqlParam[i].Password = "";
                //sqlParam[i].Database = "";
                //sqlParam[i].Instance = "";
            }
            for (int i = 0; i < mysqlParam.Length; i++)
            {
                mysqlParam[i] = new ClsDbParam()
                {
                    UserID = "",
                    Password = "",
                    Database = "",
                    Instance = ""
                };
                //mysqlParam[i] = new ClsDbParam();
                //mysqlParam[i].UserID = "";
                //mysqlParam[i].Password = "";
                //mysqlParam[i].Database = "";
                //mysqlParam[i].Instance = "";
            }
            #endregion

            #region 接続情報読み込み
            // Read Connection Data
            // string strCon;   未使用
            string strWork;
            string[] arr;

            // =======================================
            // SQL Server 本番 : DBConnectString
            // =======================================
            // Connection Strinng
            // サーバー名をIPアドレスに変換 2025/08/26 ADD
            strWork = System.Configuration.ConfigurationManager.AppSettings["DBConnectString"];
            strWork = strWork.Replace(ClsPublic.pubServerName, ClsPublic.pubServerIP);
            strWork = strWork.Replace(ClsPublic.pubServerName.ToUpper(), ClsPublic.pubServerIP);                  // 大文字の場合も対応
            sqlParam[0].ConnectString = strWork;
            if (sqlParam[0].ConnectString != null)
            {
                arr = sqlParam[0].ConnectString.Split(';');                                                  // ';'で分割
                // Instance
                strWork = arr[0].Replace(" ", "");
                strWork = strWork.Replace("DataSource=", "");
                // サーバー名をIPアドレスに変換 2025/08/26 ADD
                strWork = strWork.Replace(ClsPublic.pubServerName, ClsPublic.pubServerIP);
                strWork = strWork.Replace(ClsPublic.pubServerName.ToUpper(), ClsPublic.pubServerIP);                  // 大文字の場合も対応
                sqlParam[0].Instance = strWork;
                // UserID
                strWork = arr[1].Replace(" ", "");
                strWork = strWork.Replace("UserID=", "");
                sqlParam[0].UserID = strWork;
                // Password
                strWork = arr[2].Replace(" ", "");
                strWork = strWork.Replace("Password=", "");
                sqlParam[0].Password = strWork;
                // Database
                strWork = arr[3].Replace(" ", "");
                strWork = strWork.Replace("InitialCatalog=", "");
                sqlParam[0].Database = strWork;
            }

            // =======================================
            // SQL Server テスト : DBConnectString_Test
            // =======================================
            sqlParam[1].ConnectString = System.Configuration.ConfigurationManager.AppSettings["DBConnectString_Test"];
            if (sqlParam[1].ConnectString != null)
            {
                arr = sqlParam[1].ConnectString.Split(';');                                                  // ';'で分割
                // Instance
                strWork = arr[0].Replace(" ", "");
                strWork = strWork.Replace("DataSource=", "");
                sqlParam[1].Instance = strWork;
                // UserID
                strWork = arr[1].Replace(" ", "");
                strWork = strWork.Replace("UserID=", "");
                sqlParam[1].UserID = strWork;
                // Password
                strWork = arr[2].Replace(" ", "");
                strWork = strWork.Replace("Password=", "");
                sqlParam[1].Password = strWork;
                // Database
                strWork = arr[3].Replace(" ", "");
                strWork = strWork.Replace("InitialCatalog=", "");
                sqlParam[1].Database = strWork;
            }


            // =======================================
            // MySQL 本番 : DBConnectString_MySQL
            // =======================================
            mysqlParam[0].ConnectString = System.Configuration.ConfigurationManager.AppSettings["DBConnectString_MySQL"];
            if (mysqlParam[0].ConnectString != null)
            {
                arr = mysqlParam[0].ConnectString.Split(';');                                                  // ';'で分割
                strWork = arr[0].Replace(" ", "");
                strWork = strWork.Replace("DataSource=", "");
                mysqlParam[0].Instance = strWork;
                // UserID
                strWork = arr[1].Replace(" ", "");
                strWork = strWork.Replace("UserID=", "");
                mysqlParam[0].UserID = strWork;
                // Password
                strWork = arr[2].Replace(" ", "");
                strWork = strWork.Replace("Password=", "");
                mysqlParam[0].Password = strWork;
                // Database
                strWork = arr[3].Replace(" ", "");
                strWork = strWork.Replace("InitialCatalog=", "");
                mysqlParam[0].Database = strWork;
            }

            // =======================================
            // MySQL テスト : DBConnectString_MySQL_Test
            // =======================================
            mysqlParam[1].ConnectString = System.Configuration.ConfigurationManager.AppSettings["DBConnectString_MySQL_Test"];
            if (mysqlParam[1].ConnectString != null)
            {
                arr = mysqlParam[1].ConnectString.Split(';');                                                  // ';'で分割
                strWork = arr[0].Replace(" ", "");
                strWork = strWork.Replace("DataSource=", "");
                mysqlParam[1].Instance = strWork;
                // UserID
                strWork = arr[1].Replace(" ", "");
                strWork = strWork.Replace("UserID=", "");
                mysqlParam[1].UserID = strWork;
                // Password
                strWork = arr[2].Replace(" ", "");
                strWork = strWork.Replace("Password=", "");
                mysqlParam[1].Password = strWork;
                // Database
                strWork = arr[3].Replace(" ", "");
                strWork = strWork.Replace("InitialCatalog=", "");
                mysqlParam[1].Database = strWork;
            }
            #endregion

            #region デフォルト接続先読み込み (0:本番 / 1:TEST)
            SQLServerNo = int.Parse(System.Configuration.ConfigurationManager.AppSettings["SQLConnectNo"]);
            MySQLNo = int.Parse(System.Configuration.ConfigurationManager.AppSettings["MySQLConnectNo"]);
            #endregion
        }
    }
}
