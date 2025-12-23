using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FlockAppC.pubClass
{
    public static class ClsPublic
    {
        // 表示
        public const int DISP_ON = 2;                                   // 表示
        public const int DISP_OFF = 1;                                  // 閉じる

        // PG
        public const string PRC01 = "Shutdown";
        public const string PRC02 = "ShiftSchedulePreview";             // 勤務表
        public const string PRC03 = "PublishList";                      // 募集掲載
        public const string PRC04 = "CarList";                          // 社用車
        public const string PRC05 = "TaskList";                         // 作業タスク

        // 各定数
        public const int RESULT_OK = 0;                                 // 処理結果OK
        public const int RESULT_ERROR = 1;                              // 処理結果ERROR
        public const int FLAG_ON = 1;                                   // 各フラグ値ON
        public const int FLAG_OFF = 0;                                  // 各フラグ値OFF
                                                                        // public static int INT_INIT_VAL = 0;                          // int型初期値
                                                                        // public static string STR_INIT_VAL = "";                      // string型初期値
        public const string DEF_DATE = "1900/01/01";                    // デフォルト日付

        // =======================================================================
        // DB接続先
        // =======================================================================
        //public static string[] stcUserID = new String[4];          // 接続ユーザーID 
        //public static string[] stcPassword = new String[4];        // 接続パスワード 
        //public static string[] stcDatabase = new String[4];        // 接続データベース 
        //public static string[] stcInstance = new String[4];        // インスタンス 
        //public static int DBNo = 0;                                // 接続先№ 

        // public const int FLOCK_DB = 0;                            // 通常（主にダッシュボード以外） 
        // public const int XSERVER_DB = 1;                          // MySQL ※日報で使用
        // public const int FLOCK_TEST = 2;                          // テスト用 

        // MySQL接続中メッセージ表示ラベル（DB Connect処理で設定）
        public static System.Windows.Forms.Label lblConnect;

        // =======================================================================
        // サーバー情報 2025/08/26 ADD
        // =======================================================================
        public static string pubServerName = "";            // Server Name
        public static string pubServerIP = "";              // Serverr IP Address

        // =======================================================================
        // アプリケーションパス
        // =======================================================================
        public static string pubRootPath = "";
        public static string pubAppPath = "";

        // =======================================================================
        // Help ID
        // =======================================================================
        public static int pubHelpID;

        // DB情報
        // public static string DataBaseName = "";

        // =======================================================================
        // コントロールサイズ、位置
        // =======================================================================
        public static ClsControllLocation stcControllLocation;

        // =======================================================================
        // グループID  2025/09/03 ADD
        // =======================================================================
        public const int SALES = 1;                   // 営業
        public const int AFFAIRS = 2;                 // 総務
        public const int PROXY = 3;                   // 代務
        public const int PARTSTAFF = 4;               // 専従者
        public const int OFFICER = 9;                 // 役員
        public const int GUEST = 10;                  // ゲスト

        // =======================================================================
        // 勤務表関連
        // =======================================================================
        // インポート時の初期値
        public const string KIN_FONT_NAME = "游明朝";
        public const int KIN_FONT_SIZE = 36;
        public const string KIN_FONT_COLOR = "Black";
        public const string KIN_FONT_BOLD = "普通";
        public const string KIN_FONT_ITALIC = "普通";
        public const string KIN_BACK_COLOR = "";

        // インポート時の列終了キー
        public const string COL_END = "日・曜日";

        // 一覧
        public const string LIST_FONT_TYPE = "游ゴシック";
        public const string LIST_FONT_TYPE_MIN = "游明朝";
        public const string LIST_FONT_TYPE_GOS = "游ゴシック";
        public const string LIST_FONT_TYPE1 = "游ゴシック";
        public const string LIST_FONT_TYPE2 = "メイリオ";

        public const int LIST_FONT_SIZE9 = 9;
        public const int LIST_FONT_SIZE10 = 10;
        public const int LIST_FONT_SIZE11 = 11;
        public const int LIST_FONT_SIZE12 = 12;

        public const string CHK_FONT = "游ゴシック";
        public const int CHK_FONT_SIZE = 9;


        // 所属
        public const int OFFICE_HONSHA = 51;
        public const int OFFICE_SAITAMA = 52;
        public const int OFFICE_YOKOHAMA = 53;

        // 勤務表（エクセル）読み込みMAX行、列
        public const int EXCEL_MAX_ROW = 36;
        public const int EXCEL_MAX_COL = 26;

        // 勤務表MAX件数
        public const int MAX_SCHEDULE = 2;

        // 勤務表インポート用
        public static ClsConfig[] stcConfig = new ClsConfig[MAX_SCHEDULE];
        public static ClsImport[,] stcImport = new ClsImport[EXCEL_MAX_ROW-1, EXCEL_MAX_COL-1];

        // =======================================================================
        // 勤務表EXCEL関連
        // =======================================================================
        // 定数
        public const string STR_YELLOW = "Yellow";
        public const string STR_ORANGE = "Orange";
        public const string STR_SATURDAY = "SaturDayColor";
        public const string STR_SUNDAY = "SunDayColor";
        public const string STR_HOLIDAY = "HoliDayColor";
        public const string STR_SYSTEM = "SystemColor";
        public const string STR_BLACK = "Black";
        public const string STR_RED = "Red";
        public const string STR_BLUE = "Blue";

        public const string HEX_YELLOW = "#FFFF00";
        public const string HEX_ORANGE = "#FFC000";
        public const string HEX_SATURDAY = "#DDEBF7";
        public const string HEX_SUNDAY = "#FF99FF";
        public const string HEX_HOLIDAY = "#FFCCFF";
        public const string HEX_SYSTEM = "#FFFFFF";
        public const string HEX_BLACK = "#000000";
        public const string HEX_RED = "#FF0000";
        public const string HEX_BLUE = "#0070C0";

        public const string IDX_SATURDAY = "16247773";
        public const string IDX_SATURDAY2 = "15917529";        // 未使用？（以前使用してた名残）
        public const string IDX_SATURDAY3 = "14998742";        // 未使用？（以前使用してた名残）
        public const string IDX_SUNDAY = "16751103";
        public const string IDX_HOLIDAY = "16764159";
        public const string IDX_YELLOW = "65535";
        public const string IDX_ORANGE = "49407";
        public const string IDX_SYSTEM = "16777215";

        public const string RNG_BLACK = "0";
        public const string RNG_RED = "255";
        public const string RNG_BLUE = "12611584";
        public const string RNG_BLUE2 = "16711680";

        public const int NO_COLOR = -4142;                     // 背景色なし

        public const string STR_NOBOLD = "普通";
        public const string STR_BOLD = "太字";

        public const int DEF_FONT_SIZE = 36;

        // =======================================================================
        // 勤怠関連
        // =======================================================================
        // 勤怠
        //public static int pAttendanceYear;           // 勤怠編集対象年
        //public static int pAttendanceMonth;  　      // 勤怠編集対象月
        //public static DateTime pAttendanceStartDate; // 
        //public static DateTime pAttendanceEndDate;   //
        //public static int pKbn;                      // 実施：1/予定：2
        //public static int pBDKbn;                    // 営業：0/代務：1


        public static int pStartYear;               //タスク編集対象　年
        public static int pStartMonth;              //タスク編集対象　月
        public static DateTime pStartDate;
        public static DateTime pEndDate;

        // =======================================================================
        // タスク関連　↓↓↓
        // =======================================================================
        // Task
        // public static bool pblnUpdate;
        // public static clsTaskWork pclsTaskWork = new clsTaskWork();

        //public static int pubTaskKbnID = 0;
        //public static int pubTaskClassificationID = 0;
        //public static int pubTaskWorkItemID = 0;

        // フォント 
        // public const string TASK_FONT_TYPE = "メイリオ";
        public const string TASK_FONT_TYPE = "游ゴシック";
        public const string FONT_TYPE = "BIZ UDゴシック";

        // 各フォントサイズ
        public const int TASK_FONT_SIZE = 10;                       // タスク
        // public const int TASK_FONT_SIZE = 11;                       // タスク
        public const int TANTO_FONT_SIZE = 12;                      // 担当者
        public const int GRD_HEADER_FONT_SIZE = 10;                 // Gridヘッダー

        // ヘッダー
        public const int GRD_HEADER_HEIGHT = 30;                    // 高さ
        public static System.Drawing.Color GRD_COL_HEADER_COLOR = System.Drawing.Color.CornflowerBlue;  // 列ヘッダーカラー

        // Grid奇数行カラー
        // public static System.Drawing.Color GRD_ROW_ODD_COLOR = System.Drawing.Color.Moccasin;
        //// public static System.Drawing.Color GRD_ROW_ODD_COLOR = System.Drawing.Color.Ivory;
        public static System.Drawing.Color GRD_ROW_ODD_COLOR = System.Drawing.Color.OldLace;

        // タスクステータス
        // public const string TASK_STS_BEFORE = "未着手";
        public const string TASK_STS_BEFORE = "ストック";
        public const string TASK_STS_RUN = "作業中";
        public const string TASK_STS_END = "完了";
        public const string TASK_STS_WAIT = "中断";
        public const string TASK_STS_STOP = "中止";

        // タスクバックカラー Azure
        // public static System.Drawing.Color TASK_BACK_COLOR = System.Drawing.Color.Azure;

        // タスク識別カラー番号
        public const int TASK_BEFORE = 1;       // ストック
        public const int TASK_RUN = 2;          // 作業中
        public const int TASK_END = 3;          // 完了
        public const int TASK_WAIT = 4;         // 中断
        public const int TASK_STOP = 5;         // 中止

        // タスク識別カラー値
        //// public static System.Drawing.Color TASK_BEFORE_COLOR = System.Drawing.Color.PeachPuff;
        //// public static System.Drawing.Color TASK_BEFORE_COLOR = System.Drawing.Color.Yellow;
        //public static System.Drawing.Color TASK_STS_BEFORE_COLOR = System.Drawing.Color.Gold;
        public static System.Drawing.Color TASK_STS_BEFORE_COLOR = System.Drawing.Color.Khaki;
        public static System.Drawing.Color TASK_BEFORE_COLOR = System.Drawing.Color.Ivory;

        //// public static System.Drawing.Color TASK_RUN_COLOR = System.Drawing.Color.LightGreen;
        //// public static System.Drawing.Color TASK_RUN_COLOR = System.Drawing.Color.YellowGreen;
        //public static System.Drawing.Color TASK_STS_RUN_COLOR = System.Drawing.Color.Green;
        public static System.Drawing.Color TASK_STS_RUN_COLOR = System.Drawing.Color.PaleGreen;
        public static System.Drawing.Color TASK_RUN_COLOR = System.Drawing.Color.Honeydew;

        //// public static System.Drawing.Color TASK_END_COLOR = System.Drawing.Color.CornflowerBlue;
        //// public static System.Drawing.Color TASK_END_COLOR = System.Drawing.Color.LightSkyBlue;
        //public static System.Drawing.Color TASK_STS_END_COLOR = System.Drawing.Color.Blue;
        public static System.Drawing.Color TASK_STS_END_COLOR = System.Drawing.Color.LightSkyBlue;
        public static System.Drawing.Color TASK_END_COLOR = System.Drawing.Color.AliceBlue;

        //// public static System.Drawing.Color TASK_WAIT_COLOR = System.Drawing.Color.SandyBrown;
        //public static System.Drawing.Color TASK_STS_WAIT_COLOR = System.Drawing.Color.Gray;
        public static System.Drawing.Color TASK_STS_WAIT_COLOR = System.Drawing.Color.LightGray;
        public static System.Drawing.Color TASK_WAIT_COLOR = System.Drawing.Color.GhostWhite;

        //// public static System.Drawing.Color TASK_STOP_COLOR = System.Drawing.Color.DarkGray;
        //// public static System.Drawing.Color TASK_STOP_COLOR = System.Drawing.Color.LightCoral;
        //public static System.Drawing.Color TASK_STS_STOP_COLOR = System.Drawing.Color.Red;
        public static System.Drawing.Color TASK_STS_STOP_COLOR = System.Drawing.Color.LightPink;
        public static System.Drawing.Color TASK_STOP_COLOR = System.Drawing.Color.LavenderBlush;

        // タスクセルサイズ、表示数
        public const int TASK_CELL_STS_WIDTH = 20;
        public const int TASK_CELL_WIDTH = 150;
        public const int TASK_CELL_HEIGHTU = 48;        // 上段
        public const int TASK_CELL_HEIGHTD = 30;        // 下段
        // public const int TASK_MAX = 12;              // タスク表示数（横）
        public const int TASK_MAX = 16;                 // タスク表示数（横）

        // 完了・中断文字
        // public const string TASK_STOP_TITLE = "完了/中断";
        public const string TASK_STOP_TITLE = "完了/中断/中止";
        // =======================================================================
        // タスク関連　↑↑↑
        // =======================================================================

        private static readonly StringBuilder sb = new();


        /// <summary>
        /// =======================================================================
        /// データベース接続情報を読み込み、Static領域へ保持                                     未使用
        /// =======================================================================
        /// </summary>
        //public static void LoadDBConnectData()
        //{
        //    string uid = "";
        //    string pwd = "";
        //    string db = "";
        //    string ist = "";

        //    // DB情報取得（static領域へ保持）
        //    string strdb = "";
        //    // SQL Server
        //    strdb = System.Configuration.ConfigurationManager.AppSettings["DBConnectString"];
        //    string[] arr1 = strdb.Split(';');           // ';'で分割
        //    // [0]:インスタンス [1]:ユーザーID [2]:パスワード [3]:データベース名
        //    ist = arr1[0].Replace(" ", "");
        //    ist = ist.Replace("DataSource=", "");
        //    uid = arr1[1].Replace(" ", "");
        //    uid = uid.Replace("UserID=", "");
        //    pwd = arr1[2].Replace(" ", "");
        //    pwd = pwd.Replace("Password=", "");
        //    db = arr1[3].Replace(" ", "");
        //    db = db.Replace("InitialCatalog=", "");
        //    clsPublic.stcUserID[0] = uid;
        //    clsPublic.stcPassword[0] = pwd;
        //    clsPublic.stcDatabase[0] = db;
        //    clsPublic.stcInstance[0] = ist;

        //    // MySQL
        //    strdb = System.Configuration.ConfigurationManager.AppSettings["DBConnectString_MySQL"];
        //    string[] arr3 = strdb.Split(';');           // ';'で分割
        //    // [0]:インスタンス [1]:ユーザーID [2]:パスワード [3]:データベース名
        //    ist = arr3[0].Replace(" ", "");
        //    ist = ist.Replace("DataSource=", "");
        //    uid = arr3[1].Replace(" ", "");
        //    uid = uid.Replace("UserID=", "");
        //    pwd = arr3[2].Replace(" ", "");
        //    pwd = pwd.Replace("Password=", "");
        //    db = arr3[3].Replace(" ", "");
        //    db = db.Replace("InitialCatalog=", "");
        //    clsPublic.stcUserID[1] = uid;
        //    clsPublic.stcPassword[1] = pwd;
        //    clsPublic.stcDatabase[1] = db;
        //    clsPublic.stcInstance[1] = ist;

        //    // SQL Server（テスト用）
        //    strdb = System.Configuration.ConfigurationManager.AppSettings["DBConnectString_Test"];
        //    string[] arr2 = strdb.Split(';');           // ';'で分割
        //    // [0]:インスタンス [1]:ユーザーID [2]:パスワード [3]:データベース名
        //    ist = arr2[0].Replace(" ", "");
        //    ist = ist.Replace("DataSource=", "");
        //    uid = arr2[1].Replace(" ", "");
        //    uid = uid.Replace("UserID=", "");
        //    pwd = arr2[2].Replace(" ", "");
        //    pwd = pwd.Replace("Password=", "");
        //    db = arr2[3].Replace(" ", "");
        //    db = db.Replace("InitialCatalog=", "");
        //    clsPublic.stcUserID[2] = uid;
        //    clsPublic.stcPassword[2] = pwd;
        //    clsPublic.stcDatabase[2] = db;
        //    clsPublic.stcInstance[2] = ist;

        //    // 予備
        //    clsPublic.stcUserID[3] = "";
        //    clsPublic.stcPassword[3] = "";
        //    clsPublic.stcDatabase[3] = "";
        //    clsPublic.stcInstance[3] = "";

        //    // 接続先№
        //    clsPublic.DBNo = int.Parse(System.Configuration.ConfigurationManager.AppSettings["ConnectDB"]);
        //}
        /// <summary>
        /// =========================================================================
        /// 勤務表環境設定値読込
        /// =========================================================================
        /// </summary>
        public static void GetConfig()
        {
            string strPath;

            // 環境設定用
            stcConfig[0] = new ClsConfig();         // 当月分
            stcConfig[1] = new ClsConfig();         // 翌月分

            // 勤務表環境設定情報
            for (var i = 0; i <= 1; i++ )
            {
                stcConfig[i].Id = 0;                // レコードID
                stcConfig[i].FilePath = "";         // 勤務表ファイル(EXCEL)パス付きファイル名
                stcConfig[i].FileName = "";         // 勤務表ファイル名
                stcConfig[i].SheetName = "";        // 勤務表シート名
                stcConfig[i].Year = 0;              // 年
                stcConfig[i].Month = 0;             // 月    
                stcConfig[i].StartDate = "";        // 月初日付(n1月21日)
                stcConfig[i].EndDate = "";          // 月末日付(n2月20日)
                stcConfig[i].RefreshTimer = "";     // 勤務表再表示間隔(秒)
            }

            try
            {
                // 2025/08/26 UPD
                // using (clsDb cDb = new clsDb(DBNo))  // DB接続(DBNoはシステム起動時にセット)
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))       // DB接続(DBNoはシステム起動時にセット)
                {
                    // 勤務表環境設定情報取得(当月分のみの場合は1レコード(ID:1) 翌月分がある場合は2レコード(ID:2)
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
                    sb.AppendLine("ORDER BY");
                    sb.AppendLine("id");

                    var i = 0;
                    var id = 0;
                    var dat = DateTime.Now;

                    // 2025/08/26 DEL
                    // cDb.Sql = stb.ToString();
                    // cDb.DMLSelect();
                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            // レコードID
                            if (int.TryParse(dr["id"].ToString(), out id) == true)
                            {
                                // 数値
                                stcConfig[i].Id = id;
                            }
                            else
                            {
                                // 数値以外(null等)
                                // ログ出力
                            }

                            // 2025/08/26 サーバー名 -> IPアドレスに変換
                            strPath = dr["file_path"].ToString();
                            strPath = strPath.Replace(ClsPublic.pubServerName, ClsPublic.pubServerIP);
                            strPath = strPath.Replace(ClsPublic.pubServerName.ToUpper(), ClsPublic.pubServerIP);
                            stcConfig[i].FilePath = strPath;                                        // パス付きファイル名

                            stcConfig[i].FileName = dr["file_name"].ToString();                      // ファイル名
                            stcConfig[i].SheetName = dr["sheet_name"].ToString();                    // シート名
                            stcConfig[i].RefreshTimer = dr["refresh_timer"].ToString();              // 再表示間隔
                            stcConfig[i].Year = int.Parse(dr["year"].ToString());                   // 年
                            stcConfig[i].Month = int.Parse(dr["month"].ToString());                 // 月
                            if (DateTime.TryParse(dr["start_date"].ToString(), out dat) == true)      // 月初日付
                            {
                                // 日付の場合
                                stcConfig[i].StartDate = dat.ToString();
                            }
                            else
                            {
                                // 日付以外の場合 初期値セット
                                stcConfig[i].StartDate = "1900/01/01";
                            }
                            if (DateTime.TryParse(dr["end_date"].ToString(), out dat) == true)       // 月末日付
                            {
                                // 日付の場合
                                stcConfig[i].EndDate = dat.ToString();
                            }
                            else
                            {
                                // 日付以外の場合 初期値セット
                                stcConfig[i].EndDate = "1900/01/01";
                            }
                            i++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// =========================================================================
        /// 開始日、終了日取得２
        /// =========================================================================
        /// </summary>
        /// <param name="iYear">対象年</param>
        /// <param name="iMonth">対象月</param>
        /// <param name="sDate">月初日</param>
        /// <param name="eDate">月末日</param>
        public static void GetSEDate2(int iYear, int iMonth, ref DateTime sDate, ref DateTime eDate)
        {
            // 年月が未設定の場合は処理終了
            if ( iYear == 0 || iMonth == 0 ) { return; }

            try
            {
                // 月初、月末を求める
                DateTime datDay = DateTime.Parse(iYear.ToString() + "/" + iMonth.ToString() + "/1");
                sDate = datDay.AddMonths(-1);
                sDate = DateTime.Parse(sDate.ToString("yyyy/MM") + "/21");
                eDate = DateTime.Parse(iYear + "/" + iMonth + "/20");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// =========================================================================
        /// 開始日、終了日取得
        /// =========================================================================
        /// </summary>
        public static void GetSEDate()
        {
            // 年月が未設定の場合は処理終了
            if (ClsPublic.pStartYear == 0 || ClsPublic.pStartMonth == 0) { return; }

            try
            {
                // 月初、月末を求める
                DateTime datDay = DateTime.Parse( ClsPublic.pStartYear.ToString() + "/" + ClsPublic.pStartMonth.ToString() + "/1");
                pStartDate = datDay.AddMonths(-1);
                pStartDate = DateTime.Parse(pStartDate.ToString("yyyy/MM") + "/21");
                pEndDate = DateTime.Parse(pStartYear + "/" + pStartMonth + "/20"); 

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message , "エラー", MessageBoxButtons.OK);
                throw;
            }
        }
        /// <summary>
        /// =========================================================================
        /// 曜日取得 不要（ToString("dddd")で十分）
        /// =========================================================================
        /// </summary>
        /// <param name="dDay"></param>
        /// <param name="iType"></param>
        /// <param name="iJE"></param>
        /// <returns></returns>
        public static string GetWeekly(DateTime dDay,int iType = 1, int iJE = 1)
        {
            string strWeek;
            var culture = System.Globalization.CultureInfo.GetCultureInfo("en-US");     //日本語、英語

            //曜日タイプ（長い曜日：月曜日、短い曜日：月）
            if(iType == 1)
            {
                //長い曜日
                if(iJE == 1)
                {
                    //日本語
                    strWeek = dDay.ToString("dddd");
                }
                else
                {
                    //英語
                    strWeek = dDay.ToString("dddd", culture);
                }
            }
            else
            {
                //短い曜日
                if (iJE == 1)
                {
                    //日本語
                    strWeek = dDay.ToString("ddd");
                }
                else
                {
                    //英語
                    strWeek = dDay.ToString("ddd", culture);
                }
            }

            return strWeek; 
        }
        /// <summary>
        /// =========================================================================
        /// 日付編集　dd(曜日)を元に日付だけを取り出し、yyyy/MM/dd形式に編集し返す
        /// =========================================================================
        /// </summary>
        /// <param name="sValue"></param>
        /// <returns></returns>
        //public static string EditDay(string sValue)
        //{
        //    int intIdx;
        //    int intDay;
        //    string strDay;
        //    string strResult = null;

        //    // dd(曜日)を元に
        //    // mm/dd(曜日)の場合は ddのみ取り出し、以下の処理
        //    // dd : 21 ～ 31 は StartDateのyyyy/MM/を先頭に付ける
        //    // dd : 1 ～ 20 は EndDateのyyyy/MM/を先頭に付ける

        //    // mm/dd(曜日)判定 1.Length 6以上
        //    if (sValue.Length >= 7)
        //    {
        //        intIdx = sValue.IndexOf('/');
        //        sValue = sValue.Substring(intIdx+1, 2); 
        //    }

        //    // "("をスペースに変換
        //    sValue = sValue.Replace('(', ' ');
        //    // Left 2Byte取得
        //    sValue = sValue.Substring(0, 2);
        //    // スペースを除く
        //    sValue = sValue.Trim();

        //    if (int.TryParse(sValue,out intDay) == true)
        //    {
        //        if (intDay >= 21 && intDay <= 31)
        //        {
        //            strDay = clsPublic.pAttendanceStartDate.ToString("yyyy/MM").ToString();
        //            strDay = strDay + "/" + intDay.ToString();
        //        }
        //        else
        //        {
        //            strDay = clsPublic.pAttendanceEndDate.ToString("yyyy/MM").ToString();
        //            strDay = strDay + "/" + intDay.ToString();
        //        }
        //        strResult = strDay;
        //    }
        //    return strResult;
        //}
        /// <summary>
        /// =========================================================================
        /// 誕生日から年齢を求める
        /// =========================================================================
        /// </summary>
        /// <param name="p_bitrhday"></param>
        /// <param name="p_today"></param>
        /// <returns>年齢</returns>
        public static int CalcOld(DateTime p_bitrhday, DateTime p_today)
        {
            // int result = 0;

            // 年齢を計算
            int age = p_today.Year - p_bitrhday.Year;

            // 誕生日がまだ来ていなければ年齢を1つ引く
            if (p_bitrhday > p_today.AddYears(-age))
            {
                age--;
            }

            return age;

            // Console.WriteLine($"年齢は {age} 歳です。");
        }
        /// <summary>
        /// =========================================================================
        /// パスとファイル名を分離する
        /// =========================================================================
        /// </summary>
        /// <param name="p_fullpath">パス月ファイル名</param>
        /// <param name="p_path">パス名</param>
        /// <param name="p_file">ファイル名</param>
        public static void SeparateFilePath(string p_fullpath, ref string p_path, ref string p_file)
        {
            // ディレクトリパスを取得
            p_path = Path.GetDirectoryName(p_fullpath);

            // ファイル名を取得
            p_file = Path.GetFileName(p_fullpath);
        }
        /// <summary>
        /// =========================================================================
        /// ファイル選択ダイアログ
        /// =========================================================================
        /// </summary>
        /// <param name="p_path"></param>
        /// <param name="p_extension"></param>
        /// <returns></returns>
        // public static string SelectFileDialog(string p_path, string p_extension = "")
        public static string SelectFileDialog(string p_path)
        {
            string result = "";

            // OpenFileDialogのインスタンスを作成
            OpenFileDialog openFileDialog = new()
            {
                // ダイアログの設定を行う
                InitialDirectory = p_path,
                Filter = "All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            // ダイアログの設定を行う
            openFileDialog.InitialDirectory = p_path;
            openFileDialog.Filter = "All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            // ダイアログを表示し、ファイルが選択された場合にそのファイル名を表示する
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 選択されたファイルのパスを取得
                result = openFileDialog.FileName;
                // Console.WriteLine("Selected file: " + filePath);
            }

            return result;
        }
        /// <summary>
        /// =========================================================================
        /// 受信メッセージ件数取得　未使用
        /// =========================================================================
        /// </summary>
        /// <returns></returns>
        //public static int CheckReceiveMessage(int p_dbtype = 1)
        //{
        //    int cnt = 0;

        //    // 接続中メッセージ
        //    if (p_dbtype != 0)
        //    {
        //        // MySQL
        //        ClsPublic.lblConnect = null;
        //    }

        //    try
        //    {
        //        using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
        //        {
        //            sb.Clear();
        //            sb.AppendLine("SELECT");
        //            sb.AppendLine("COUNT(*) AS CNT");
        //            sb.AppendLine("FROM");
        //            sb.AppendLine("Trn_メッセージ履歴");
        //            sb.AppendLine("WHERE");
        //            sb.AppendLine("Kbn = 2");               // 受信
        //            sb.AppendLine("AND");
        //            sb.AppendLine("NoticeFlag = 0");        // 未閲覧
        //            sb.AppendLine("AND");
        //            sb.AppendLine("PartnerID = " + pubClass.ClsLoginUser.ID);

        //            using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
        //            {
        //                foreach (DataRow dr in dt_val.Rows)
        //                {
        //                    cnt = int.Parse(dr["CNT"].ToString());
        //                }
        //            }
        //        }
        //        return cnt;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return cnt;
        //        throw;
        //    }
        //}

        /// <summary>
        /// =========================================================================
        /// 勤務表変更フラグ更新 （どこでフラグを参照しているか？）
        /// =========================================================================
        /// </summary>
        /// <param name="p_bl"></param>
        public static void UpdateShiftFlag(int p_flg)
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("UPDATE");
                    sb.AppendLine("Mst_勤務表環境設定");
                    sb.AppendLine("SET");
                    sb.AppendLine("update_flag = " + p_flg);
                    sb.AppendLine("WHERE");
                    sb.AppendLine("id = 1");

                    clsSqlDb.DMLUpdate(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }


        /// <summary>
        /// =========================================================================
        /// 休日判定
        /// =========================================================================
        /// </summary>
        /// <param name="p_day"></param>
        /// <returns>true:休日 false:休日以外</returns>
        public static bool CheckHoliday(DateTime p_day)
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("holiday");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_休日");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("day = '" + p_day.ToString("yyyy/MM/dd") + "'");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        if (dt_val.Rows.Count > 0) { return true; }
                        else { return false; }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// =========================================================================
        /// ファイル存在、オープンチェック
        /// =========================================================================
        /// </summary>
        /// <param name="p_file"></param>
        /// <returns>0:OK 1:ファイル無し 2:ファイルオープン状態</returns>
        public static int CheckFile(string p_file)
        {
            var rtn = 0;

            // ファイル存在チェック
            if (File.Exists(p_file) != true) { rtn = 1; }

            // ファイルオープンチェック
            if (IsFileLocked(p_file) !=  false) { rtn = 2; }

            return rtn;
        }
        /// <summary>
        /// =========================================================================
        /// ファイルがロックされているかチェック
        /// =========================================================================
        /// </summary>
        /// <param name="p_file"></param>
        /// <returns></returns>
        public static bool IsFileLocked(string p_file)
        {
            FileStream stream = null;
            try
            {
                // ファイルを開いてロック状態を確認（読み取り・書き込み用）
                stream = File.Open(p_file, FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                // IOExceptionが発生した場合は、ファイルがロックされていると判断
                return true;
            }
            finally
            {
                // ストリームがnullでなければ閉じる
                stream?.Close();
            }

            return false;
        }

        /// <summary>
        /// =========================================================================
        /// プロセス起動/終了フラグ更新（改版）
        /// =========================================================================
        /// </summary>
        /// <param name="sAppFlagName"></param>
        /// <param name="iMode"></param>
        public static void SetControllFlagOnOff(string p_col, int p_mode)
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("UPDATE");
                    sb.AppendLine("Mst_プロセス制御");
                    sb.AppendLine("SET");
                    sb.AppendLine("control_flag = " + p_mode);
                    sb.AppendLine("WHERE");
                    sb.AppendLine("appName = '" + p_col + "'");

                    clsSqlDb.DMLUpdate(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// =========================================================================
        /// PC Shutdown（改版）
        /// =========================================================================
        /// </summary>
        public static void ShutdownMonitorPC()
        {
            // StringBuilder sb = new StringBuilder();

            string msg = "モニター(大)に接続しているPCをシャットダウンします。" + Environment.NewLine + "モニターはリモコンで電源を落としてください。";
            if (MessageBox.Show(msg, "確認", MessageBoxButtons.OKCancel) == DialogResult.Cancel) { return; }

            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("UPDATE");
                    sb.AppendLine("Mst_プロセス制御");
                    sb.AppendLine("SET");
                    sb.AppendLine("control_flag = 1");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("app_name = '" + PRC01 + "'");
                    // sb.AppendLine("app_name = 'Shutdown'");

                    clsSqlDb.DMLUpdate(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// =========================================================================
        /// PC ReBoot
        /// =========================================================================
        /// </summary>
        public static void ReBootPC()
        {
            // StringBuilder sb = new StringBuilder();

            string msg = "モニター(大)に接続しているPCを再起動します。" ;
            if (MessageBox.Show(msg, "確認", MessageBoxButtons.OKCancel) == DialogResult.Cancel) { return; }

            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("UPDATE");
                    sb.AppendLine("Mst_プロセス制御");
                    sb.AppendLine("SET");
                    sb.AppendLine("control_flag = 1");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("app_name = 'ReBoot'");

                    clsSqlDb.DMLUpdate(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// =========================================================================
        /// 月替わり処理
        /// 勤務表環境設定テーブル
        /// =========================================================================
        /// </summary>
        public static void ChangeMonthProc()
        {
            // 月替わり判定（21日が休日の場合を想定（暫定処理）
            var day = int.Parse(DateTime.Now.ToString("dd"));

            if ( day != 21 && day != 22 && day != 23 && day != 24 ) { return; }            

            // 翌月の勤務表が登録されている場合、入れ替え
            if (ClsPublic.stcConfig[1].FilePath == "") { return; }

            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    // ID = 1 レコードを 削除
                    sb.Clear();
                    sb.AppendLine("DELETE FROM");
                    sb.AppendLine("Mst_勤務表環境設定");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("id = 1");

                    clsSqlDb.DMLUpdate(sb.ToString());

                    // ID = 2 レコードを ID = 1 に更新
                    sb.Clear();
                    sb.AppendLine("UPDATE");
                    sb.AppendLine("Mst_勤務表環境設定");
                    sb.AppendLine("SET");
                    sb.AppendLine("id = 1");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("id = 2");

                    clsSqlDb.DMLUpdate(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 勤務表のタイムスタンプチェック
        /// 取り込んだ勤務表のタイムスタンプと差異があるか比較
        /// </summary>
        /// <returns>1:差異あり/0:なし</returns>
        public static int CompTimeStamp(string p_filename)
        {
            var result = 0;
            DateTime datStamp1, datStamp2;

            if (p_filename == "") { return result; }

            // ファイルの最終更新日時を取得
            datStamp1 = File.GetLastWriteTime(p_filename);

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
                            if (dr["time_stamp"] != null)
                            {
                                datStamp2 = DateTime.Parse(dr["time_stamp"].ToString());
                                if (datStamp1.ToString("yyyy/MM/dd hh:mm:ss") != datStamp2.ToString("yyyy/MM/dd hh:mm:ss"))
                                {
                                    result = 1;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }

                return result;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }
        /// <summary>
        /// テーブル保持のタイムスタンプを更新
        /// </summary>
        /// <param name="p_filename"></param>
        public static void UpdateTimeStamp(string p_filename)
        {
            DateTime datStamp;

            if (p_filename == "") { return; }

            // ファイルの最終更新日時を取得
            datStamp = File.GetLastWriteTime(p_filename);

            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("*");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Trn_勤務表更新日付");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("file_path = '" + p_filename + "'");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        if (dt_val.Rows.Count > 0)
                        {
                            // Time Stamp UPDATE
                            sb.Length = 0;
                            sb.AppendLine("UPDATE");
                            sb.AppendLine("Trn_勤務表更新日付");
                            sb.AppendLine("SET");
                            sb.AppendLine("time_stamp = '" + datStamp + "'");
                            sb.AppendLine("WHERE");
                            sb.AppendLine("file_path = '" + p_filename + "'");
                        }
                        else
                        {
                            // Time Stamp INSERT
                            sb.Length = 0;
                            sb.AppendLine("INSERT INTO");
                            sb.AppendLine("Trn_勤務表更新日付");
                            sb.AppendLine("(");
                            sb.AppendLine(" file_path");
                            sb.AppendLine(",file_name");
                            sb.AppendLine(",time_stamp");
                            sb.AppendLine(") VALUES (");
                            sb.AppendLine("'" + p_filename + "'");
                            sb.AppendLine(",'" + Path.GetFileName(p_filename) + "'");
                            sb.AppendLine(",'" + datStamp.ToString("yyyy/MM/dd hh:mm:ss") + "'");
                            sb.AppendLine(")");
                        }
                    }

                    clsSqlDb.DMLUpdate(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 半角カタカナ判定
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsHankakuKatakana(char c)
        {
            return c >= '\uFF66' && c <= '\uFF9F';
        }

        /// <summary>
        /// ラベル文字設定
        /// </summary>
        /// <param name="p_text"></param>
        /// <param name="p_font_type"></param>
        /// <param name="p_font_size"></param>
        /// <param name="p_font_color"></param>
        /// <param name="p_style"></param>
        /// <param name="p_label"></param>
        public static void SetLabelFont(string p_text, string p_font_type, int p_font_size, System.Drawing.Color p_font_color, System.Drawing.FontStyle p_style, System.Windows.Forms.Label p_label)
        {
            p_label.Text = p_text;
            p_label.Font = new System.Drawing.Font(p_font_type, p_font_size, p_style);
            p_label.ForeColor = p_font_color;
        }
        /// <summary>
        /// テキストボックス設定
        /// </summary>
        /// <param name="p_text"></param>
        /// <param name="p_font_type"></param>
        /// <param name="p_font_size"></param>
        /// <param name="p_font_color"></param>
        /// <param name="p_style"></param>
        /// <param name="p_textbox"></param>
        public static void SetTextBoxFont(string p_text, string p_font_type, int p_font_size, System.Drawing.Color p_font_color, System.Drawing.FontStyle p_style, System.Windows.Forms.TextBox p_textbox)
        {
            p_textbox.Text = p_text;
            p_textbox.Font = new System.Drawing.Font(p_font_type, p_font_size, p_style);
            p_textbox.ForeColor = p_font_color;
        }
        /// <summary>
        /// グリッドビューセル設定
        /// </summary>
        /// <param name="p_row">行</param>
        /// <param name="p_col">列</param>
        /// <param name="p_text">表示テキスト</param>
        /// <param name="p_font_type">フォントタイプ</param>
        /// <param name="p_font_size">フォントサイズ</param>
        /// <param name="p_font_color">フォントカラー</param>
        /// <param name="p_style">フォントスタイル（太字等）</param>
        /// <param name="p_gridview">コントロールオブジェクト</param>
        public static void SetGridViewFont(int p_row, int p_col, string p_text, string p_font_type, int p_font_size, System.Drawing.Color p_font_color, System.Drawing.FontStyle p_style, System.Windows.Forms.DataGridView p_gridview)
        {
            p_gridview[p_col, p_row].Value = p_text;
            p_gridview[p_col, p_row].Style.Font = new System.Drawing.Font(p_font_type, p_font_size, p_style);
            p_gridview[p_col, p_row].Style.ForeColor = p_font_color;
        }
    }
}
