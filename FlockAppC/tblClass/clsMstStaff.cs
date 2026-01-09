    using FlockAppC.pubClass;
using System;
using System.Data;
using System.Text;

namespace FlockAppC.tblClass
{
    public class ClsMstStaff
    {
        public Boolean Exis { get; set; }
        public int Id { get; set; }
        public int StaffID { get; set; }
        public string FullName { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Kana1 { get; set; }
        public string Kana2 { get; set; }
        public string FullKana { get; set; }
        public DateTime BirthDay { get; set; }
        public int GroupID { get; set; }
        public int OfficeID { get; set; }
        public int ConfirmFlag { get; set; }
        public int CarManageFlag { get; set; }
        // public int AttendanceFlag { get; set; }      2025/12/24 DEL
        public int MasterMenteFlag { get; set; }
        public int ReportManageFlag { get; set; }
        public int RecruitManageFlag { get; set; }
        public int ReportConfirmFlag { get; set; }
        public string ConfirmPass { get; set; }
        public int TantoSort { get; set; }
        public int RegSort { get; set; }
        public int Sort { get; set; }
        public string Comment { get; set; }
        public string Comment2 { get; set; }
        public string GroupName { get; set; }
        public string OfficeName { get; set; }
        public int Kbn { get; set; }
        public int PositionFlag { get; set; }
        public string KbnName { get; set; }
        // public int ZaiFlag { get; set; }             2026/01/08 DEL
        public int CarID { get; set; }
        public string CarNo { get; set; }
        public string CarName { get; set; }
        public string RegNo { get; set; }
        public int UsedUserID { get; set; }
        public int ProxyFlag { get; set; }
        public int SystemControlFlag { get; set; }

        // public int AttSubjectFlag { get; set; }      2025/12/24 DEL

        // タスク関連
        // public int TaskFlag { get; set; }            2025/12/24 DEL

        // 更新日時
        public DateTime UpdDate { get; set; }
        // 削除フラグ
        public int Delete_Flag { get; set; }

        private readonly StringBuilder sb = new();

        /// <summary>
        /// 社員データ有無
        /// </summary>
        public void ExisStaff()
        {
            //有無初期化
            Exis = false;

            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("staff_id");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_社員");
                    sb.AppendLine("staff_id = " + Id);

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        if (dt_val.Rows.Count > 0) { Exis = true; }
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
        /// 社員ID取得（MAX ID + 1とする）
        /// </summary>
        /// <returns></returns>
        public int GetStaffId()
        {
            int intID = 0;

            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("MAX(staff_id) AS staff_id");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_社員");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            intID = int.Parse(dr["staff_id"].ToString()) + 1;
                        }
                    }
                }

                return intID;
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// 社員情報取得
        /// </summary>
        public void GetStaff()
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" Mst_社員.staff_id");
                    // sb.AppendLine(",Mst_社員.id");         2025/12/24 DEL
                    sb.AppendLine(",Mst_社員.name1");
                    sb.AppendLine(",Mst_社員.name2");
                    sb.AppendLine(",Mst_社員.fullname");
                    sb.AppendLine(",Mst_社員.kana1");
                    sb.AppendLine(",Mst_社員.kana2");
                    sb.AppendLine(",Mst_社員.fullkana");
                    sb.AppendLine(",Mst_社員.office_id");
                    sb.AppendLine(",Mst_社員.group_id");
                    sb.AppendLine(",Mst_社員.proxy_flag");
                    sb.AppendLine(",Mst_社員.confirm_flag");
                    sb.AppendLine(",Mst_社員.car_manage_flag");
                    // sb.AppendLine(",Mst_社員.attendance_flag");    2025/12/24 DEL
                    sb.AppendLine(",Mst_社員.master_mente_flag");
                    sb.AppendLine(",Mst_社員.report_manage_flag");
                    sb.AppendLine(",Mst_社員.recruit_manage_flag");
                    sb.AppendLine(",Mst_社員.report_confirm_flag");
                    sb.AppendLine(",Mst_社員.system_control_flag");
                    sb.AppendLine(",Mst_社員.confirm_password");
                    sb.AppendLine(",Mst_社員.tanto_sort");
                    sb.AppendLine(",Mst_社員.reg_sort");
                    sb.AppendLine(",Mst_社員.sort");
                    sb.AppendLine(",Mst_社員.kbn");
                    sb.AppendLine(",Mst_社員.position_flag");
                    // sb.AppendLine(",Mst_社員.zai_flag");       2026/01/08 DEL
                    sb.AppendLine(",Mst_社員.comment");
                    sb.AppendLine(",Mst_社員.car_id");
                    // sb.AppendLine(",Mst_社員.task_flag");      2025/12/24 DEL
                    sb.AppendLine(",Mst_社員.upd_date");
                    sb.AppendLine(",Mst_所属.name AS office_name");
                    sb.AppendLine(",Mst_部門.name AS group_name");
                    sb.AppendLine(",Mst_区分.strval AS kbn_name");
                    // sb.AppendLine(",Mst_社員.attsubject_flag");    2025/12/24 DEL
                    sb.AppendLine(",Mst_社用車.car_no");
                    sb.AppendLine(",Mst_社用車.car_name");
                    sb.AppendLine(",Mst_社用車.reg_no");
                    sb.AppendLine(",Mst_社用車.used_user_id");
                    sb.AppendLine(" FROM Mst_社員");
                    sb.AppendLine(" LEFT JOIN Mst_部門");
                    sb.AppendLine(" ON Mst_社員.group_id = Mst_部門.id");
                    sb.AppendLine(" LEFT JOIN Mst_所属");
                    sb.AppendLine(" ON Mst_社員.office_id = Mst_所属.id");
                    sb.AppendLine(" LEFT JOIN Mst_社用車");
                    sb.AppendLine(" ON Mst_社員.car_id = Mst_社用車.id");
                    sb.AppendLine(" LEFT JOIN Mst_区分");
                    sb.AppendLine(" ON Mst_社員.kbn  = Mst_区分.value");
                    sb.AppendLine(" AND");
                    sb.AppendLine(" Mst_区分.kbn1 = 101");
                    sb.AppendLine(" WHERE Mst_社員.staff_id = " + Id);
                    sb.AppendLine(" AND");
                    sb.AppendLine(" (Mst_社員.delete_flag = 0 OR Mst_社員.delete_flag IS NULL)");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            //NULL判定が必要
                            Id = int.Parse(dr["staff_id"].ToString());
                            if (dr.IsNull("staff_id") != true) { StaffID = int.Parse(dr["staff_id"].ToString()); }
                            if (dr.IsNull("fullname") != true) { FullName = dr["fullname"].ToString(); }
                            if (dr.IsNull("name1") != true) { Name1 = dr["name1"].ToString(); }
                            if (dr.IsNull("name2") != true) { Name2 = dr["name2"].ToString(); }
                            if (dr.IsNull("kana1") != true) { Kana1 = dr["kana1"].ToString(); }
                            if (dr.IsNull("kana2") != true) { Kana2 = dr["kana2"].ToString(); }
                            if (dr.IsNull("fullkana") != true) { FullKana = dr["fullkana"].ToString(); }
                            if (dr.IsNull("proxy_flag") != true) { ProxyFlag = int.Parse(dr["proxy_flag"].ToString()); }
                            if (dr.IsNull("confirm_flag") != true) { ConfirmFlag = int.Parse(dr["confirm_flag"].ToString()); }
                            if (dr.IsNull("confirm_password") != true) { ConfirmPass = dr["confirm_password"].ToString(); }
                            if (dr.IsNull("tanto_sort") != true) { TantoSort = int.Parse(dr["tanto_sort"].ToString()); }
                            if (dr.IsNull("reg_sort") != true) { RegSort = int.Parse(dr["reg_sort"].ToString()); }
                            if (dr.IsNull("sort") != true) { Sort = int.Parse(dr["sort"].ToString()); }
                            if (dr.IsNull("comment") != true) { Comment = dr["comment"].ToString(); }
                            if (dr.IsNull("group_id") != true) { GroupID = int.Parse(dr["group_id"].ToString()); }
                            if (dr.IsNull("group_name") != true) { GroupName = dr["group_name"].ToString(); }
                            if (dr.IsNull("office_id") != true) { OfficeID = int.Parse(dr["office_id"].ToString()); }
                            if (dr.IsNull("office_name") != true) { OfficeName = dr["office_name"].ToString(); }
                            if (dr.IsNull("kbn") != true) { Kbn = int.Parse(dr["kbn"].ToString()); }
                            if (dr.IsNull("kbn_name") != true) { KbnName = dr["kbn_name"].ToString(); }
                            if (dr.IsNull("position_flag") != true) { PositionFlag = int.Parse(dr["position_flag"].ToString()); }
                            // if (dr.IsNull("zai_flag") != true) { ZaiFlag = int.Parse(dr["zai_flag"].ToString()); }       2026/01/08 DEL
                            if (dr.IsNull("car_manage_flag") != true) { CarManageFlag = int.Parse(dr["car_manage_flag"].ToString()); }
                            // if (dr.IsNull("attendance_flag") != true) { AttendanceFlag = int.Parse(dr["attendance_flag"].ToString()); }          2025/12/24 DEL
                            if (dr.IsNull("master_mente_flag") != true) { MasterMenteFlag = int.Parse(dr["master_mente_flag"].ToString()); }
                            if (dr.IsNull("report_manage_flag") != true) { ReportManageFlag = int.Parse(dr["report_manage_flag"].ToString()); }
                            if (dr.IsNull("recruit_manage_flag") != true) { RecruitManageFlag = int.Parse(dr["recruit_manage_flag"].ToString()); }
                            if (dr.IsNull("report_confirm_flag") != true) { ReportConfirmFlag = int.Parse(dr["report_confirm_flag"].ToString()); }
                            if (dr.IsNull("system_control_flag") != true) { SystemControlFlag = int.Parse(dr["system_control_flag"].ToString()); }
                            // if (dr.IsNull("task_flag") != true) { TaskFlag = int.Parse(dr["task_flag"].ToString()); }            2025/12/24 DEL
                            if (dr.IsNull("upd_date") != true) { UpdDate = DateTime.Parse(dr["upd_date"].ToString()); }
                            // if (dr.IsNull("attsubject_flag") != true) { AttSubjectFlag = int.Parse(dr["attsubject_flag"].ToString()); }          2025/12/24 DEL
                            if (dr.IsNull("car_id") != true) { CarID = int.Parse(dr["car_id"].ToString()); }
                            if (dr.IsNull("car_no") != true) { CarNo = dr["car_no"].ToString(); }
                            if (dr.IsNull("car_name") != true) { CarName = dr["car_name"].ToString(); }
                            if (dr.IsNull("reg_no") != true) { RegNo = dr["reg_no"].ToString(); }
                            if (dr["used_user_id"].ToString() == "" || dr.IsNull("used_user_id") == true) { UsedUserID = 0; }
                            else { UsedUserID = int.Parse(dr["used_user_id"].ToString()); }
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
        /// 社員データクリア
        /// </summary>
        public void ClearStaff()
        {
            StaffID = 0;
            Id = 0;
            Name1 = "";
            Name2 = "";
            FullName = "";
            Kana1 = "";
            Kana2 = "";
            FullKana = "";
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
            Kbn = 1;
            PositionFlag = 0;
            // ZaiFlag = 1;             2026/01/08 DEL 
            Comment = "";
            CarID = 0;
            CarName = "";
            RegNo = "";
            UsedUserID = 0;
            // 2025/12/24 DEL
            // AttSubjectFlag = 0;
            // TaskFlag = 0;
            UpdDate = DateTime.Parse("1900/01/01");
            UsedUserID = 0;
        }

        /// <summary>
        /// 社員データ更新
        /// </summary>
        public void UpdateStaff()
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("UPDATE Mst_社員 SET");
                    sb.AppendLine(" name1 = '" + Name1 + "'");
                    sb.AppendLine(",name2 = '" + Name2 + "'");
                    sb.AppendLine(",fullname = '" + FullName + "'");
                    sb.AppendLine(",kana1 = '" + Kana1 + "'");
                    sb.AppendLine(",kana2 = '" + Kana2 + "'");
                    sb.AppendLine(",fullkana = '" + FullKana + "'");
                    sb.AppendLine(",office_id = " + OfficeID);
                    sb.AppendLine(",group_id = " + GroupID);
                    sb.AppendLine(",proxy_flag = " + ProxyFlag);
                    sb.AppendLine(",confirm_flag = " + ConfirmFlag);
                    sb.AppendLine(",car_manage_flag = " + CarManageFlag);
                    // 2025/12/24 DEL
                    // sb.AppendLine(",attendance_flag = " + AttendanceFlag);
                    sb.AppendLine(",master_mente_flag = " + MasterMenteFlag);
                    sb.AppendLine(",report_manage_flag = " + ReportManageFlag);
                    sb.AppendLine(",recruit_manage_flag = " + RecruitManageFlag);
                    sb.AppendLine(",report_confirm_flag = " + ReportConfirmFlag);
                    sb.AppendLine(",system_control_flag = " + SystemControlFlag);
                    sb.AppendLine(",confirm_password = '" + ConfirmPass + "'");
                    sb.AppendLine(",tanto_sort = " + TantoSort);
                    sb.AppendLine(",reg_sort = " + RegSort);
                    sb.AppendLine(",sort = " + Sort);
                    sb.AppendLine(",kbn = " + Kbn);
                    sb.AppendLine(",position_flag = " + PositionFlag);
                    // sb.AppendLine(",zai_flag = " + ZaiFlag);                2026/01/08 DEL
                    sb.AppendLine(",comment = '" + Comment + "'");
                    sb.AppendLine(",car_id = " + CarID);
                    // 2025/12/24 DEL (S)
                    // sb.AppendLine(",attsubject_flag = " + AttSubjectFlag);
                    // sb.AppendLine(",task_flag = " + TaskFlag);
                    // 2025/12/24 DEL (E)

                    // 2025/11/10↓
                    sb.AppendLine(",upd_user_id = " + ClsLoginUser.StaffID);
                    sb.AppendLine(",upd_date = '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    sb.AppendLine(",delete_flag = " + Delete_Flag);
                    // 2025/11/10↑
                    sb.AppendLine(" WHERE staff_id = " + Id);

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
        /// 社員データ追加
        /// </summary>
        public void InsertStaff()
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("INSERT INTO Mst_社員 (");
                    sb.AppendLine(" id");
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
                    // 2025/12/24 DEL
                    // sb.AppendLine(",attendance_flag");
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
                    // sb.AppendLine(",zai_flag");              2026/01/08 DEL
                    sb.AppendLine(",comment");
                    sb.AppendLine(",car_id");
                    // 2025/12/24 DEL (S)
                    //sb.AppendLine(",attsubject_flag");
                    //sb.AppendLine(",task_flag");
                    // 2025/12/24 DEL (E)
                    // 2025/11/10 (S)
                    sb.AppendLine(",ins_user_id");
                    sb.AppendLine(",ins_date");
                    sb.AppendLine(",delete_flag");
                    // 2025/11/10 (E)
                    sb.AppendLine(") VALUES (");
                    sb.AppendLine(Id.ToString());
                    sb.AppendLine(",'" + Name1 + "'");
                    sb.AppendLine(",'" + Name2 + "'");
                    sb.AppendLine(",'" + FullName + "'");
                    sb.AppendLine(",'" + Kana1 + "'");
                    sb.AppendLine(",'" + Kana2 + "'");
                    sb.AppendLine(",'" + FullKana + "'");
                    sb.AppendLine("," + OfficeID);
                    sb.AppendLine("," + GroupID);
                    sb.AppendLine("," + ProxyFlag);
                    sb.AppendLine("," + ConfirmFlag);
                    sb.AppendLine("," + CarManageFlag);
                    // 2025/12/24 DEL
                    // sb.AppendLine("," + AttendanceFlag);
                    sb.AppendLine("," + MasterMenteFlag);
                    sb.AppendLine("," + ReportManageFlag);
                    sb.AppendLine("," + RecruitManageFlag);
                    sb.AppendLine("," + ReportConfirmFlag);
                    sb.AppendLine("," + SystemControlFlag);
                    sb.AppendLine(",'" + ConfirmPass + "'");
                    sb.AppendLine("," + TantoSort);
                    sb.AppendLine("," + RegSort);
                    sb.AppendLine("," + Sort);
                    sb.AppendLine("," + Kbn);
                    sb.AppendLine("," + PositionFlag);
                    // sb.AppendLine("," + ZaiFlag);            2026/01/08 DEL
                    sb.AppendLine(",'" + Comment + "'");
                    sb.AppendLine("," + CarID);
                    // 2025/12/24 DEL
                    //sb.AppendLine("," + AttSubjectFlag);
                    //sb.AppendLine("," + TaskFlag);

                    // 2025/11/10↓
                    sb.AppendLine("," + ClsLoginUser.StaffID);
                    sb.AppendLine(",'" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    sb.AppendLine("," + ClsPublic.FLAG_OFF);
                    // 2025/11/10↑
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
        /// 削除フラグONの社員を物理削除する
        /// </summary>
        public void DeleteStaff()
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("DELETE FROM Mst_社員 ");
                    sb.AppendLine("WHERE");
                    // sb.AppendLine("StaffID = " + Id);
                    sb.AppendLine("delete_flag = 1");

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
        /// ==========================================================
        /// 不要
        /// ==========================================================
        /// StaffIDの最大値取得
        /// IDにセットする為だが、基本的にはIDは使用しない為、不要かも
        /// </summary>
        /// <returns></returns>
        public int GetMaxStaffId()
        {
            int ID = 0;

            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("MAX(staff_id) AS staff_id");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_社員");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            ID = int.Parse(dr["staff_id"].ToString()) + 1;
                            break;
                        }
                    }
                }
                return ID;
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// 専従先専従者、管理責任者をクリア
        /// </summary>
        public void ClearLocationStaff()
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    // 専従先専従者削除
                    sb.Clear();
                    sb.AppendLine("DELETE");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_専従先専従者");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("staff_id = " + this.Id);

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
        /// 専従先専従者、管理責任者をクリア
        /// </summary>
        public void ClearLocationStaffMySQL(int p_staff, ClsMySqlDb clsMySqlDb)
        {
            try
            {
                // 専従先専従者削除
                sb.Clear();
                sb.AppendLine("DELETE");
                sb.AppendLine("FROM");
                sb.AppendLine("Mst_専従先専従者");
                sb.AppendLine("WHERE");
                sb.AppendLine("staff_id = " + p_staff);

                clsMySqlDb.DMLUpdate(sb.ToString());
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 専従先専従者を登録
        /// </summary>
        /// <param name="p_location">専従先ID</param>
        /// <param name="p_staff">担当者ID</param>
        public void InsertLocationStaff(int p_location, int p_staff)
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    // 専従先専従者登録
                    sb.Clear();
                    sb.AppendLine("INSERT INTO");
                    sb.AppendLine("Mst_専従先専従者");
                    sb.AppendLine("(");
                    sb.AppendLine(" location_id");
                    sb.AppendLine(",staff_id");
                    // 2025/11/10↓
                    sb.AppendLine(",ins_user_id");
                    sb.AppendLine(",ins_date");
                    sb.AppendLine(",delete_flag");
                    // 2025/11/10↑
                    sb.AppendLine(") VALUES (");
                    sb.AppendLine(p_location.ToString());
                    sb.AppendLine("," + p_staff.ToString());
                    // 2025/11/10↓
                    sb.AppendLine("," + ClsLoginUser.StaffID);
                    sb.AppendLine(",'" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    sb.AppendLine("," + ClsPublic.FLAG_OFF);
                    // 2025/11/10↑
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
        /// 専従先専従者を更新
        /// </summary>
        /// <param name="p_location">専従先ID</param>
        /// <param name="p_staff">担当者ID</param>
        public void UpdateLocationStaff(int p_location, int p_staff)
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    // 専従先専従者更新
                    sb.Clear();
                    sb.AppendLine("UPDATE");
                    sb.AppendLine("Mst_専従先専従者");
                    sb.AppendLine("SET");
                    sb.AppendLine("staff_id = " + p_staff);
                    // 2025/11/10↓
                    sb.AppendLine(",upd_user_id = " + ClsLoginUser.StaffID);
                    sb.AppendLine(",upd_date = '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    // 2025/11/10↑
                    sb.AppendLine("WHERE");
                    sb.AppendLine("location_id = " + p_location);

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
        /// 管理責任者を更新
        /// </summary>
        /// <param name="p_location">専従先ID</param>
        /// <param name="p_staff">担当者ID</param>
        public void UpdateInstructor(int p_location, int p_staff)
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    // 所属の管理責任者クリア
                    sb.Clear();
                    sb.AppendLine("UPDATE");
                    sb.AppendLine("Mst_専従先");
                    sb.AppendLine("SET");
                    sb.AppendLine("instructor_id = " + p_staff);
                    // 2025/11/10↓
                    sb.AppendLine(",upd_user_id = " + ClsLoginUser.StaffID);
                    sb.AppendLine(",upd_date = '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    // 2025/11/10↑
                    sb.AppendLine("WHERE");
                    sb.AppendLine("location_id = " + p_location);

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
        /// 従業員情報エクスポート（１件）
        /// </summary>
        /// <param name="p_staff">従業員ID</param>
        /// <param name="clsSqlDb">SQL SERVER</param>
        /// <param name="clsMySqlDb">MySQL</param>
        public void ExportOneStaffData(int p_staff, ClsSqlDb clsSqlDb, ClsMySqlDb clsMySqlDb)
        {
            try
            {
                // 対象データ削除
                sb.Clear();
                sb.AppendLine("DELETE");
                sb.AppendLine("FROM");
                sb.AppendLine("Mst_社員");
                sb.AppendLine("WHERE");
                sb.AppendLine("staff_id = " + p_staff);
                clsMySqlDb.DMLUpdate(sb.ToString());

                // SQL Server SELECT ALL
                sb.Clear();
                sb.AppendLine("SELECT");
                sb.AppendLine(" staff_id");
                sb.AppendLine(",id");
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
                sb.AppendLine(",comment");
                sb.AppendLine(",car_id");
                sb.AppendLine(",col");
                sb.AppendLine(",ins_user_id");
                sb.AppendLine(",ins_date");
                sb.AppendLine(",upd_user_id");
                sb.AppendLine(",upd_date");
                sb.AppendLine(",delete_flag");
                sb.AppendLine("FROM");
                sb.AppendLine("Mst_社員");
                sb.AppendLine("WHERE");
                sb.AppendLine("staff_id = " + p_staff);

                using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                {
                    DataRow dr = dt_val.Rows[0];
                    sb.Clear();
                    sb.AppendLine("INSERT INTO Mst_社員 (");
                    sb.AppendLine(" staff_id");
                    sb.AppendLine(",id");
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
                    sb.AppendLine(",comment");
                    sb.AppendLine(",car_id");
                    sb.AppendLine(",col");
                    sb.AppendLine(",ins_user_id");
                    sb.AppendLine(",ins_date");
                    sb.AppendLine(",upd_user_id");
                    sb.AppendLine(",upd_date");
                    sb.AppendLine(",delete_flag");
                    sb.AppendLine(") VALUES (");
                    sb.AppendLine(p_staff.ToString());
                    sb.AppendLine("," + dr["id"].ToString());
                    sb.AppendLine(",'" + dr["name1"].ToString() + "'");
                    sb.AppendLine(",'" + dr["name2"].ToString() + "'");
                    sb.AppendLine(",'" + dr["fullname"].ToString() + "'");
                    sb.AppendLine(",'" + dr["kana1"].ToString() + "'");
                    sb.AppendLine(",'" + dr["kana2"].ToString() + "'");
                    sb.AppendLine(",'" + dr["fullkana"].ToString() + "'");
                    sb.AppendLine("," + dr["office_id"].ToString());
                    sb.AppendLine("," + dr["group_id"].ToString());
                    sb.AppendLine("," + dr["proxy_flag"].ToString());
                    sb.AppendLine("," + dr["confirm_flag"].ToString());
                    sb.AppendLine("," + dr["car_manage_flag"].ToString());
                    sb.AppendLine("," + dr["master_mente_flag"].ToString());
                    sb.AppendLine("," + dr["report_manage_flag"].ToString());
                    sb.AppendLine("," + dr["recruit_manage_flag"].ToString());
                    sb.AppendLine("," + dr["report_confirm_flag"].ToString());
                    sb.AppendLine("," + dr["system_control_flag"].ToString());
                    sb.AppendLine(",'" + dr["confirm_password"].ToString() + "'");
                    sb.AppendLine("," + dr["tanto_sort"].ToString());
                    sb.AppendLine("," + dr["reg_sort"].ToString());
                    sb.AppendLine("," + dr["sort"].ToString());
                    sb.AppendLine("," + dr["kbn"].ToString());
                    sb.AppendLine("," + dr["position_flag"].ToString());
                    sb.AppendLine(",'" + dr["comment"].ToString() + "'");
                    sb.AppendLine("," + dr["car_id"].ToString());
                    if (dr["col"].ToString() != "") { sb.AppendLine("," + dr["col"].ToString()); }
                    else { sb.AppendLine(",NULL"); }
                    if (dr.IsNull("ins_user_id") != true) { sb.AppendLine("," + dr["ins_user_id"].ToString()); }
                    else { sb.AppendLine(",0"); }
                    if (dr.IsNull("ins_date") != true) { sb.AppendLine(",'" + dr["ins_date"].ToString() + "'"); }
                    else { sb.AppendLine(",null"); }
                    if (dr.IsNull("upd_user_id") != true) { sb.AppendLine("," + dr["upd_user_id"].ToString()); }
                    else { sb.AppendLine(",0"); }
                    if (dr.IsNull("upd_date") != true) { sb.AppendLine(",'" + dr["upd_date"].ToString() + "'"); }
                    else { sb.AppendLine(",null"); }
                    if (dr.IsNull("delete_flag") != true) { sb.AppendLine("," + dr["delete_flag"].ToString()); }
                    else { sb.AppendLine("," + ClsPublic.FLAG_OFF); }
                    sb.AppendLine(")");
                    clsMySqlDb.DMLUpdate(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 従業員情報エクスポート（全件）
        /// </summary>
        public void ExportStaffData(ref System.Windows.Forms.ProgressBar p_pgb)
        {
            int rec_cnt;                        // レコード件数
            int importCnt = 0;              // インポート件数

            // =============================================================================
            // １．MySQLに作業用テーブルを作成
            // ２．SQL Serverの全データをMySQLの作業用テーブルにINSERT
            // ３．SQL Serverテーブルと作業用テーブルを比較
            // ４．本番テーブルをリネーム
            // ５．作業用テーブルを本番テーブルにリネーム
            // ６．不要となった旧本番テーブルを削除
            // =============================================================================
            try
            {
                // xserver(mySQL)接続
                using (ClsMySqlDb clsMySqlDb = new(ClsDbConfig.MySQLNo))
                {
                    // １．MySQLに作業用テーブルを作成
                    sb.Clear();
                    sb.AppendLine("CREATE TABLE Mst_社員_work LIKE Mst_社員");
                    clsMySqlDb.DMLUpdate(sb.ToString());

                    // ２．SQL Serverの全データをMySQLの作業用テーブルにINSERT
                    using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                    {
                        // SQL Server SELECT ALL
                        sb.Clear();
                        sb.AppendLine("SELECT");
                        sb.AppendLine(" staff_id");
                        sb.AppendLine(",id");
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
                        sb.AppendLine(",comment");
                        sb.AppendLine(",car_id");
                        sb.AppendLine(",col");
                        sb.AppendLine(",ins_user_id");
                        sb.AppendLine(",ins_date");
                        sb.AppendLine(",upd_user_id");
                        sb.AppendLine(",upd_date");
                        sb.AppendLine(",delete_flag");
                        sb.AppendLine("FROM");
                        sb.AppendLine("Mst_社員");
                        sb.AppendLine("ORDER BY");
                        sb.AppendLine("staff_id");

                        using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                        {
                            // ProgressBar設定
                            rec_cnt = dt_val.Rows.Count;
                            p_pgb.Visible = true;
                            p_pgb.Maximum = rec_cnt;
                            p_pgb.Refresh();

                            foreach (DataRow dr in dt_val.Rows)
                            {
                                // INSERT
                                sb.Clear();
                                sb.AppendLine("INSERT INTO Mst_社員_work (");
                                sb.AppendLine(" staff_id");
                                sb.AppendLine(",id");
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
                                sb.AppendLine(",comment");
                                sb.AppendLine(",car_id");
                                sb.AppendLine(",col");
                                sb.AppendLine(",ins_user_id");
                                sb.AppendLine(",ins_date");
                                sb.AppendLine(",upd_user_id");
                                sb.AppendLine(",upd_date");
                                sb.AppendLine(",delete_flag");
                                sb.AppendLine(") VALUES (");
                                sb.AppendLine(dr["staff_id"].ToString());
                                sb.AppendLine("," + dr["id"].ToString());
                                sb.AppendLine(",'" + dr["name1"].ToString() + "'");
                                sb.AppendLine(",'" + dr["name2"].ToString() + "'");
                                sb.AppendLine(",'" + dr["fullname"].ToString() + "'");
                                sb.AppendLine(",'" + dr["kana1"].ToString() + "'");
                                sb.AppendLine(",'" + dr["kana2"].ToString() + "'");
                                sb.AppendLine(",'" + dr["fullkana"].ToString() + "'");
                                sb.AppendLine("," + dr["office_id"].ToString());
                                sb.AppendLine("," + dr["group_id"].ToString());
                                sb.AppendLine("," + dr["proxy_flag"].ToString());
                                sb.AppendLine("," + dr["confirm_flag"].ToString());
                                sb.AppendLine("," + dr["car_manage_flag"].ToString());
                                sb.AppendLine("," + dr["master_mente_flag"].ToString());
                                sb.AppendLine("," + dr["report_manage_flag"].ToString());
                                sb.AppendLine("," + dr["recruit_manage_flag"].ToString());
                                sb.AppendLine("," + dr["report_confirm_flag"].ToString());
                                sb.AppendLine("," + dr["system_control_flag"].ToString());
                                sb.AppendLine(",'" + dr["confirm_password"].ToString() + "'");
                                sb.AppendLine("," + dr["tanto_sort"].ToString());
                                sb.AppendLine("," + dr["reg_sort"].ToString());
                                sb.AppendLine("," + dr["sort"].ToString());
                                sb.AppendLine("," + dr["kbn"].ToString());
                                sb.AppendLine("," + dr["position_flag"].ToString());
                                sb.AppendLine(",'" + dr["comment"].ToString() + "'");
                                sb.AppendLine("," + dr["car_id"].ToString());
                                if (dr["col"].ToString() != "") { sb.AppendLine("," + dr["col"].ToString()); }
                                else { sb.AppendLine(",NULL"); }
                                if (dr.IsNull("ins_user_id") != true) { sb.AppendLine("," + dr["ins_user_id"].ToString()); }
                                else { sb.AppendLine(",0"); }
                                if (dr.IsNull("ins_date") != true) { sb.AppendLine(",'" + dr["ins_date"].ToString() + "'"); }
                                else { sb.AppendLine(",null"); }
                                if (dr.IsNull("upd_user_id") != true) { sb.AppendLine("," + dr["upd_user_id"].ToString()); }
                                else { sb.AppendLine(",0"); }
                                if (dr.IsNull("upd_date") != true) { sb.AppendLine(",'" + dr["upd_date"].ToString() + "'"); }
                                else { sb.AppendLine(",null"); }
                                if (dr.IsNull("delete_flag") != true) { sb.AppendLine("," + dr["delete_flag"].ToString()); }
                                else { sb.AppendLine("," + ClsPublic.FLAG_OFF); }
                                sb.AppendLine(")");
                                clsMySqlDb.DMLUpdate(sb.ToString());

                                importCnt++;

                                // ProgressBar値セット
                                p_pgb.Value = importCnt;
                                p_pgb.Refresh();
                            }
                        }

                        // ３．SQL Serverテーブルと作業用テーブルを比較
                        int cnt;
                        sb.Clear();
                        sb.AppendLine("SELECT COUNT(*) AS rec_cnt2 FROM Mst_社員_work");         // MySQL側
                        using (DataTable dt_val = clsMySqlDb.DMLSelect(sb.ToString()))
                        {
                            cnt = int.Parse(dt_val.Rows[0]["rec_cnt2"].ToString());
                        }
                        if (rec_cnt != cnt)
                        {
                            // レコード件数不一致エラー
                            throw new Exception("従業員マスターのエクスポートでレコード件数不一致エラーが発生しました。");
                        }

                        // ４．本番テーブルをリネーム
                        // ５．作業用テーブルを本番テーブルにリネーム
                        sb.Clear();
                        sb.AppendLine("RENAME TABLE");
                        sb.AppendLine("Mst_社員 TO Mst_社員_old,");
                        sb.AppendLine("Mst_社員_work TO Mst_社員;");
                        clsMySqlDb.DMLUpdate(sb.ToString());

                        // ６．不要となった旧本番テーブルを削除
                        sb.Clear();
                        sb.AppendLine("DROP TABLE Mst_社員_old;");
                        clsMySqlDb.DMLUpdate(sb.ToString());
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
        /// 専従先専従者（全件）をエクスポート
        /// </summary>
        public void ExportLocationStaffData(ref System.Windows.Forms.ProgressBar p_pgb)
        {
            int rec_cnt;
            int importCnt = 0;

            // =============================================================================
            // １．MySQLに作業用テーブルを作成
            // ２．SQL Serverの全データをMySQLの作業用テーブルにINSERT
            // ３．SQL Serverテーブルと作業用テーブルを比較
            // ４．本番テーブルをリネーム
            // ５．作業用テーブルを本番テーブルにリネーム
            // ６．不要となった旧本番テーブルを削除
            // =============================================================================
            try
            {
                using (ClsMySqlDb clsMySqlDb = new(ClsDbConfig.MySQLNo))
                {
                    // １．MySQLに作業用テーブルを作成
                    sb.Clear();
                    sb.AppendLine("CREATE TABLE Mst_専従先専従者_work LIKE Mst_専従先専従者");
                    clsMySqlDb.DMLUpdate(sb.ToString());

                    // ２．SQL Serverの全データをMySQLの作業用テーブルにINSERT
                    using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                    {
                        // SQL Server SELECT ALL
                        sb.Clear();
                        sb.AppendLine("SELECT");
                        sb.AppendLine(" id");
                        sb.AppendLine(",location_id");
                        sb.AppendLine(",staff_id");
                        sb.AppendLine(",ins_user_id");
                        sb.AppendLine(",ins_date");
                        sb.AppendLine(",upd_user_id");
                        sb.AppendLine(",upd_date");
                        sb.AppendLine(",delete_flag");
                        sb.AppendLine("FROM");
                        sb.AppendLine("Mst_専従先専従者");
                        sb.AppendLine("ORDER BY");
                        sb.AppendLine("staff_id");

                        using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                        {
                            // ProgressBar設定
                            rec_cnt = dt_val.Rows.Count;
                            p_pgb.Visible = true;
                            p_pgb.Maximum = rec_cnt;
                            p_pgb.Refresh();

                            // MySQL INSERT
                            foreach (DataRow dr in dt_val.Rows)
                            {
                                sb.Length = 0;
                                sb.AppendLine("INSERT INTO Mst_専従先専従者_work (");
                                sb.AppendLine(" id");
                                sb.AppendLine(",location_id");
                                sb.AppendLine(",staff_id");
                                sb.AppendLine(",ins_user_id");
                                sb.AppendLine(",ins_date");
                                sb.AppendLine(",upd_user_id");
                                sb.AppendLine(",upd_date");
                                sb.AppendLine(",delete_flag");
                                sb.AppendLine(") VALUES (");
                                sb.AppendLine(dr["id"].ToString());
                                sb.AppendLine("," + dr["location_id"].ToString());
                                sb.AppendLine("," + dr["staff_id"].ToString());
                                if (dr.IsNull("ins_user_id") != true) { sb.AppendLine("," + dr["ins_user_id"].ToString()); }
                                else { sb.AppendLine(",0"); }
                                if (dr.IsNull("ins_date") != true) { sb.AppendLine(",'" + dr["ins_date"].ToString() + "'"); }
                                else { sb.AppendLine(",null"); }
                                if (dr.IsNull("upd_user_id") != true) { sb.AppendLine("," + dr["upd_user_id"].ToString()); }
                                else { sb.AppendLine(",0"); }
                                if (dr.IsNull("upd_date") != true) { sb.AppendLine(",'" + dr["upd_date"].ToString() + "'"); }
                                else { sb.AppendLine(",null"); }
                                if (dr.IsNull("delete_flag") != true) { sb.AppendLine("," + dr["delete_flag"].ToString()); }
                                else { sb.AppendLine("," + ClsPublic.FLAG_OFF); }
                                sb.AppendLine(")");
                                clsMySqlDb.DMLUpdate(sb.ToString());

                                importCnt++;

                                // ProgressBar値セット
                                p_pgb.Value = importCnt;
                                p_pgb.Refresh();
                            }
                        }

                        // ３．SQL Serverテーブルと作業用テーブルを比較
                        int cnt;
                        sb.Clear();
                        sb.AppendLine("SELECT COUNT(*) AS rec_cnt2 FROM Mst_専従先専従者_work");         // MySQL側
                        using (DataTable dt_val = clsMySqlDb.DMLSelect(sb.ToString()))
                        {
                            cnt = int.Parse(dt_val.Rows[0]["rec_cnt2"].ToString());
                        }
                        if (rec_cnt != cnt)
                        {
                            // レコード件数不一致エラー
                            throw new Exception("専従先専従者マスターのエクスポートでレコード件数不一致エラーが発生しました。");
                        }

                        // ４．本番テーブルをリネーム
                        // ５．作業用テーブルを本番テーブルにリネーム
                        sb.Clear();
                        sb.AppendLine("RENAME TABLE");
                        sb.AppendLine("Mst_専従先専従者 TO Mst_専従先専従者_old,");
                        sb.AppendLine("Mst_専従先専従者_work TO Mst_専従先専従者;");
                        clsMySqlDb.DMLUpdate(sb.ToString());

                        // ６．不要となった旧本番テーブルを削除
                        sb.Clear();
                        sb.AppendLine("DROP TABLE Mst_専従先専従者_old;");
                        clsMySqlDb.DMLUpdate(sb.ToString());
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
        /// 専従先専従者（全件）をエクスポート（プログレスバーなし）
        /// </summary>
        public void ExportLocationStaffAllData(ClsSqlDb clsSqlDb, ClsMySqlDb clsMySqlDb)
        {
            int rec_cnt;
            int importCnt = 0;

            // =============================================================================
            // １．MySQLに作業用テーブルを作成
            // ２．SQL Serverの全データをMySQLの作業用テーブルにINSERT
            // ３．SQL Serverテーブルと作業用テーブルを比較
            // ４．本番テーブルをリネーム
            // ５．作業用テーブルを本番テーブルにリネーム
            // ６．不要となった旧本番テーブルを削除
            // =============================================================================
            try
            {
                // １．MySQLに作業用テーブルを作成
                sb.Clear();
                sb.AppendLine("CREATE TABLE Mst_専従先専従者_work LIKE Mst_専従先専従者");
                clsMySqlDb.DMLUpdate(sb.ToString());

                // ２．SQL Serverの全データをMySQLの作業用テーブルにINSERT
                // SQL Server SELECT ALL
                sb.Clear();
                sb.AppendLine("SELECT");
                sb.AppendLine(" id");
                sb.AppendLine(",location_id");
                sb.AppendLine(",staff_id");
                sb.AppendLine(",ins_user_id");
                sb.AppendLine(",ins_date");
                sb.AppendLine(",upd_user_id");
                sb.AppendLine(",upd_date");
                sb.AppendLine(",delete_flag");
                sb.AppendLine("FROM");
                sb.AppendLine("Mst_専従先専従者");
                sb.AppendLine("ORDER BY");
                sb.AppendLine("staff_id");

                using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                {
                    rec_cnt = dt_val.Rows.Count;

                    // MySQL INSERT
                    foreach (DataRow dr in dt_val.Rows)
                    {
                        sb.Length = 0;
                        sb.AppendLine("INSERT INTO Mst_専従先専従者_work (");
                        sb.AppendLine(" id");
                        sb.AppendLine(",location_id");
                        sb.AppendLine(",staff_id");
                        sb.AppendLine(",ins_user_id");
                        sb.AppendLine(",ins_date");
                        sb.AppendLine(",upd_user_id");
                        sb.AppendLine(",upd_date");
                        sb.AppendLine(",delete_flag");
                        sb.AppendLine(") VALUES (");
                        sb.AppendLine(dr["id"].ToString());
                        sb.AppendLine("," + dr["location_id"].ToString());
                        sb.AppendLine("," + dr["staff_id"].ToString());
                        if (dr.IsNull("ins_user_id") != true) { sb.AppendLine("," + dr["ins_user_id"].ToString()); }
                        else { sb.AppendLine(",0"); }
                        if (dr.IsNull("ins_date") != true) { sb.AppendLine(",'" + dr["ins_date"].ToString() + "'"); }
                        else { sb.AppendLine(",null"); }
                        if (dr.IsNull("upd_user_id") != true) { sb.AppendLine("," + dr["upd_user_id"].ToString()); }
                        else { sb.AppendLine(",0"); }
                        if (dr.IsNull("upd_date") != true) { sb.AppendLine(",'" + dr["upd_date"].ToString() + "'"); }
                        else { sb.AppendLine(",null"); }
                        if (dr.IsNull("delete_flag") != true) { sb.AppendLine("," + dr["delete_flag"].ToString()); }
                        else { sb.AppendLine("," + ClsPublic.FLAG_OFF); }
                        sb.AppendLine(")");
                        clsMySqlDb.DMLUpdate(sb.ToString());

                        importCnt++;
                    }
                }

                // ３．SQL Serverテーブルと作業用テーブルを比較
                int cnt;
                sb.Clear();
                sb.AppendLine("SELECT COUNT(*) AS rec_cnt2 FROM Mst_専従先専従者_work");         // MySQL側
                using (DataTable dt_val = clsMySqlDb.DMLSelect(sb.ToString()))
                {
                    cnt = int.Parse(dt_val.Rows[0]["rec_cnt2"].ToString());
                }
                if (rec_cnt != cnt)
                {
                    // レコード件数不一致エラー
                    throw new Exception("専従先専従者マスターのエクスポートでレコード件数不一致エラーが発生しました。");
                }

                // ４．本番テーブルをリネーム
                // ５．作業用テーブルを本番テーブルにリネーム
                sb.Clear();
                sb.AppendLine("RENAME TABLE");
                sb.AppendLine("Mst_専従先専従者 TO Mst_専従先専従者_old,");
                sb.AppendLine("Mst_専従先専従者_work TO Mst_専従先専従者;");
                clsMySqlDb.DMLUpdate(sb.ToString());

                // ６．不要となった旧本番テーブルを削除
                sb.Clear();
                sb.AppendLine("DROP TABLE Mst_専従先専従者_old;");
                clsMySqlDb.DMLUpdate(sb.ToString());
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// 専従先専従者（１件）をエクスポート
        /// </summary>
        public void ExportLocationOneStaffData(int p_staff, ClsSqlDb clsSqlDb, ClsMySqlDb clsMySqlDb)
        {
            try
            {
                // 専従先専従者登録
                sb.Clear();
                sb.AppendLine("SELECT");
                sb.AppendLine(" id");
                sb.AppendLine(",location_id");
                sb.AppendLine(",staff_id");
                sb.AppendLine(",ins_user_id");
                sb.AppendLine(",ins_date");
                sb.AppendLine(",delete_flag");
                sb.AppendLine("FROM");
                sb.AppendLine("Mst_専従先専従者");
                sb.AppendLine("WHERE");
                sb.AppendLine("staff_id = " + p_staff);

                using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                {
                    // MySQL INSERT
                    foreach (DataRow dr in dt_val.Rows)
                    {
                        sb.Length = 0;
                        sb.AppendLine("INSERT INTO Mst_専従先専従者 (");
                        sb.AppendLine(" id");
                        sb.AppendLine(",location_id");
                        sb.AppendLine(",staff_id");
                        sb.AppendLine(",ins_user_id");
                        sb.AppendLine(",ins_date");
                        sb.AppendLine(",delete_flag");
                        sb.AppendLine(") VALUES (");
                        sb.AppendLine(dr["id"].ToString());
                        sb.AppendLine("," + dr["location_id"].ToString());
                        sb.AppendLine("," + dr["staff_id"].ToString());
                        if (dr.IsNull("ins_user_id") != true) { sb.AppendLine("," + dr["ins_user_id"].ToString()); }
                        else { sb.AppendLine(",0"); }
                        if (dr.IsNull("ins_date") != true) { sb.AppendLine(",'" + dr["ins_date"].ToString() + "'"); }
                        else { sb.AppendLine(",null"); }
                        if (dr.IsNull("delete_flag") != true) { sb.AppendLine("," + dr["delete_flag"].ToString()); }
                        else { sb.AppendLine("," + ClsPublic.FLAG_OFF); }
                        sb.AppendLine(")");

                        clsMySqlDb.DMLUpdate(sb.ToString());
                    }
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
