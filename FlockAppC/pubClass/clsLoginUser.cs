using System;
using System.Data;
using System.Text;

namespace FlockAppC.pubClass
{
    public static class ClsLoginUser
    {
        #region "プロパティ"
        public static int StaffID { get; set; }
        // 2025/12/24 DEL
        // public static int ID { get; set; }
        public static string Name1 {  get; set; }
        public static string Name2 { get; set; }
        public static string FullName { get; set; }
        public static string Kana1 { get; set; }
        public static string Kana2 { get; set; }
        public static string FullKana { get; set; }
        public static DateTime EntryCompany {  get; set; }
        public static DateTime LeavingCompany { get; set; }
        public static int OfficeID { get; set; }
        public static int GroupID { get; set; }
        public static int ProxyFlag { get; set; }
        public static int ConfirmFlag { get; set; }
        public static int CarManageFlag { get; set; }
        // 2025/12/24 DEL
        // public static int AttendanceFlag { get; set; }
        public static int MasterMenteFlag { get; set; }
        public static int ReportManageFlag { get; set; }
        public static int RecruitManageFlag { get; set; }
        public static int ReportConfirmFlag { get; set; }
        public static int SystemControlFlag { get; set; }
        public static string ConfirmPass { get; set; }
        public static int TantoSort { get; set; }
        public static int RegSort { get; set; }
        public static int Sort { get; set; }
        public static int Kbn { get; set; }
        public static int PositionFlag { get; set; }
        // public static int ZaiFlag { get; set; }          2026/01/08 DEL         
        public static string Comment { get; set; }
        public static int CarID { get; set; }
        // public static int TaskFlag { get; set; }     2025/12/24 DEL
        public static int Col { get; set; }

        private static readonly StringBuilder sb = new();
        #endregion

        /// <summary>
        /// 社員マスタデータ初期化
        /// </summary>
        public static void InitializeData()
        {
            StaffID = 0;
            // 2025/12/24 DEL
            // ID = 0;
            Name1 = "";
            Name2 = "";
            FullName = "";
            Kana1 = "";
            Kana2 = "";
            FullKana = "";
            EntryCompany = DateTime.Parse(ClsPublic.DEF_DATE);
            LeavingCompany = DateTime.Parse(ClsPublic.DEF_DATE);
            OfficeID = 0;
            GroupID = 0;
            ProxyFlag = 0;
            ConfirmFlag = 0;
            CarManageFlag = 0;
            // 2025/12/24 DEL
            // AttendanceFlag = 0;
            MasterMenteFlag = 0;
            ReportManageFlag = 0;
            RecruitManageFlag = 0;
            ReportConfirmFlag = 0;
            SystemControlFlag = 0;
            ConfirmPass = "";
            TantoSort = 0;
            RegSort = 0;
            Sort = 0;
            Kbn = 0;
            PositionFlag = 0;
            // ZaiFlag = 0;         2026/01/08 DEL            
            Comment = "";
            CarID = 0;
            // TaskFlag = 0;        2025/12/24 DEL
            Col = 0;
        }

        /// <summary>
        /// パスワードチェック
        /// </summary>
        /// <param name="p_id"></param>
        /// <returns>0:OK / 1:Password NG / 2:Password No Setting</returns>
        public static int CheckPassword(int p_id = 0, string p_password = "")
        {
            string pass = "";
            
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("confirm_password");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_社員");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("staff_id = " + p_id);

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            pass = dr["confirm_password"].ToString();
                            break;
                        }
                    }

                    // パスワード判定
                    if (pass == "") { return 2; }
                    else if (pass != p_password) { return 1; }
                    else { return 0; }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// 社員マスターデータ取得
        /// </summary>
        /// <param name="p_id"></param>
        public static void GetUser(int p_id)
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" staff_id");
                    // sb.AppendLine(",id");            2025/12/24 DEL
                    sb.AppendLine(",name1");
                    sb.AppendLine(",name2");
                    sb.AppendLine(",fullname");
                    sb.AppendLine(",kana1");
                    sb.AppendLine(",kana2");
                    sb.AppendLine(",fullkana");
                    sb.AppendLine(",office_id");
                    sb.AppendLine(",group_id");
                    sb.AppendLine(",proxy_flag");
                    sb.AppendLine(",confirm_flag");
                    sb.AppendLine(",car_manage_flag");
                    // sb.AppendLine(",attendance_flag");           2025/12/24 DEL
                    sb.AppendLine(",master_mente_flag");
                    sb.AppendLine(",report_manage_flag");
                    sb.AppendLine(",recruit_manage_flag");
                    sb.AppendLine(",report_confirm_flag");
                    sb.AppendLine(",system_control_flag");
                    sb.AppendLine(",confirm_password");
                    sb.AppendLine(",tanto_sort");
                    sb.AppendLine(",reg_sort");
                    sb.AppendLine(",sort");
                    sb.AppendLine(",kbn");
                    sb.AppendLine(",position_flag");
                    // sb.AppendLine(",zai_flag");          2026/01/08 DEL
                    sb.AppendLine(",comment");
                    sb.AppendLine(",car_id");
                    // sb.AppendLine(",task_flag");        2025/12/24 DEL
                    sb.AppendLine(",col");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_社員");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("staff_id = " + p_id);
                    // 2026/01/08 ADD (S)
                    sb.AppendLine("AND");
                    sb.AppendLine("delete_flag != " + ClsPublic.FLAG_ON);
                    // 2026/01/08 ADD (E)

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            StaffID = int.Parse(dr["staff_id"].ToString());
                            // 2025/12/24 DEL
                            // ID = int.Parse(dr["staff_id"].ToString());
                            Name1 = dr["name1"].ToString();
                            Name2 = dr["name2"].ToString();
                            FullName = dr["fullname"].ToString();
                            Kana1 = dr["kana1"].ToString();
                            Kana2 = dr["kana2"].ToString();
                            FullKana = dr["fullkana"].ToString();

                            if (dr.IsNull("office_id") != true) { OfficeID = int.Parse(dr["office_id"].ToString()); }
                            else { OfficeID = ClsPublic.OFFICE_HONSHA; }         // 未設定→本社

                            if (dr.IsNull("group_id") != true) { GroupID = int.Parse(dr["group_id"].ToString()); }
                            else { GroupID = ClsPublic.PARTSTAFF; }       // 未設定→専従

                            if (dr.IsNull("proxy_flag") != true) { ProxyFlag = int.Parse(dr["proxy_flag"].ToString()); }
                            else { ProxyFlag = ClsPublic.FLAG_OFF; }


                            if (dr.IsNull("confirm_flag") != true) { ConfirmFlag = int.Parse(dr["confirm_flag"].ToString()); }
                            else { ConfirmFlag = ClsPublic.FLAG_OFF; }

                            if (dr.IsNull("car_manage_flag") != true) { CarManageFlag = int.Parse(dr["car_manage_flag"].ToString()); }
                            else { CarManageFlag = ClsPublic.FLAG_OFF; }

                            // 2025/12/24 DEL
                            // if (dr.IsNull("attendance_flag") != true) { AttendanceFlag = int.Parse(dr["attendance_flag"].ToString()); }
                            // else { AttendanceFlag = ClsPublic.FLAG_OFF; }

                            if (dr.IsNull("master_mente_flag") != true) { MasterMenteFlag = int.Parse(dr["master_mente_flag"].ToString()); }
                            else { MasterMenteFlag = ClsPublic.FLAG_OFF; }

                            if (dr.IsNull("report_manage_flag") != true) { ReportManageFlag = int.Parse(dr["report_manage_flag"].ToString()); }
                            else { ReportManageFlag = ClsPublic.FLAG_OFF; }

                            if (dr.IsNull("recruit_manage_flag") != true) { RecruitManageFlag = int.Parse(dr["recruit_manage_flag"].ToString()); }
                            else { RecruitManageFlag = ClsPublic.FLAG_OFF; }

                            if (dr.IsNull("report_confirm_flag") != true) { ReportConfirmFlag = int.Parse(dr["report_confirm_flag"].ToString()); }
                            else { ReportConfirmFlag = ClsPublic.FLAG_OFF; }

                            if (dr.IsNull("system_control_flag") != true) { SystemControlFlag = int.Parse(dr["system_control_flag"].ToString()); }
                            else { SystemControlFlag = ClsPublic.FLAG_OFF; }

                            ConfirmPass = dr["confirm_password"].ToString();

                            if (dr.IsNull("tanto_sort") != true) { TantoSort = int.Parse(dr["tanto_sort"].ToString()); }
                            else { TantoSort = 99; }        // 未設定→最大値（暫定）

                            if (dr.IsNull("reg_sort") != true) { RegSort = int.Parse(dr["reg_sort"].ToString()); }
                            else { RegSort = 99; }        // 未設定→最大値（暫定）

                            if (dr.IsNull("sort") != true) { Sort = int.Parse(dr["sort"].ToString()); }
                            else { Sort = 99; }        // 未設定→最大値（暫定）

                            if (dr.IsNull("kbn") != true) { Kbn = int.Parse(dr["kbn"].ToString()); }
                            else { Kbn = 2; }

                            if (dr.IsNull("position_flag") != true) { PositionFlag = int.Parse(dr["position_flag"].ToString()); }
                            else { PositionFlag = 0; }

                            // 2026/01/08 DEL (S)
                            // if (dr.IsNull("zai_flag") != true) { ZaiFlag = int.Parse(dr["zai_flag"].ToString()); }
                            // else { ZaiFlag = ClsPublic.FLAG_ON; }
                            // 2026/01/08 DEL (E)

                            Comment = dr["comment"].ToString();

                            // 2025/12/24 DEL
                            // if (dr.IsNull("task_flag") != true) { TaskFlag = int.Parse(dr["task_flag"].ToString()); }
                            // else { TaskFlag = ClsPublic.FLAG_OFF; }

                            if (dr.IsNull("car_id") != true) { CarID = int.Parse(dr["car_id"].ToString()); }
                            else { CarID = ClsPublic.FLAG_OFF; }

                            // 未設定の場合は0
                            if (dr["col"].ToString() != "") { Col = int.Parse(dr["col"].ToString()); }
                            else { Col = 0; }
                            break;
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
    }
}
