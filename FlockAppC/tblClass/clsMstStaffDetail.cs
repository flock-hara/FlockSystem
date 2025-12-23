using FlockAppC.pubClass;
using System;
using System.Data;
using System.Text;

namespace FlockAppC.tblClass
{
    public class ClsMstStaffDetail
    {
        public int DetailID { get; set; }
        public int Id { get; set; }
        
        // 2025/08/13 ADD
        public DateTime EntryCompany { get; set; }
        public DateTime LeavingCompany { get; set; }
        
        public string ZipCode1 { get; set; }
        public string ZipCode2 { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string TelNo { get; set; }
        public string MobileNo { get; set; }
        public string FaxNo { get; set; }
        public string MailAddress { get; set; }
        public DateTime Birthday { get; set; }
        public int Old { get; set; }
        public int CapaYear1 { get; set; }
        public int CapaMonth1 { get; set; }
        public string Capa1 { get; set; }
        public int CapaYear2 { get; set; }
        public int CapaMonth2 { get; set; }
        public string Capa2 { get; set; }
        public int CapaYear3 { get; set; }
        public int CapaMonth3 { get; set; }
        public string Capa3 { get; set; }
        public int CapaYear4 { get; set; }
        public int CapaMonth4 { get; set; }
        public string Capa4 { get; set; }
        public int CapaYear5 { get; set; }
        public int CapaMonth5 { get; set; }
        public string Capa5 { get; set; }
        public string Comment { get; set; }
        public int CarFlag { get; set; }
        public string Station { get; set; }
        public string AppendedPath1 { get;set; }
        public string AppendedFile1 { get; set; }
        public string AppendedPath2 { get; set; }
        public string AppendedFile2 { get; set; }
        public string StaffName { get; set; }
        public string OfficeName { get; set; }
        public string GroupName { get; set; }
        public string LocationName { get; set; }
        public int ProxyFlag { get; set; }

        private readonly StringBuilder sb = new();

        /// <summary>
        /// インスタンス
        /// </summary>
        public ClsMstStaffDetail()
        {
            DetailID = 0;
            Id = 0;

            // 2025/08/13 ADD
            EntryCompany = DateTime.Parse("1900/01/01");
            LeavingCompany = DateTime.Parse("1900/01/01");

            ZipCode1 = "";
            ZipCode2 = "";
            Address1 = "";
            Address2 = "";
            TelNo = "";
            MobileNo = "";
            FaxNo = "";
            Birthday = DateTime.Parse("1900/01/01");
            Old = 0;
            CapaYear1 = 0;
            CapaMonth1 = 0;
            Capa1 = "";
            CapaYear2 = 0;
            CapaMonth2 = 0;
            Capa2 = "";
            CapaYear3 = 0;
            CapaMonth3 = 0;
            Capa3 = "";
            CapaYear4 = 0;
            CapaMonth4 = 0;
            Capa4 = "";
            CapaYear5 = 0;
            CapaMonth5 = 0;
            Capa5 = "";
            CarFlag = 0;
            Station = "";
            AppendedPath1 = "";
            AppendedPath2 = "";
            AppendedFile1 = "";
            AppendedFile2 = "";

            // 表示用
            StaffName = "";
            OfficeName = "";
            GroupName = "";
            LocationName = "";
            ProxyFlag = 0;
        }
        /// <summary>
        /// SELECT
        /// </summary>
        /// <param name="p_id"></param>
        /// <returns>件数</returns>
        public int Select(int p_id)
        {
            int result = 0;

            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" detail_id");
                    sb.AppendLine(",id");
                    sb.AppendLine(",entry_company");
                    sb.AppendLine(",leaving_company");
                    sb.AppendLine(",zip_code1");
                    sb.AppendLine(",zip_code2");
                    sb.AppendLine(",address1");
                    sb.AppendLine(",address2");
                    sb.AppendLine(",tel");
                    sb.AppendLine(",mobile");
                    sb.AppendLine(",fax");
                    sb.AppendLine(",mail");
                    sb.AppendLine(",birthday");
                    sb.AppendLine(",old");
                    sb.AppendLine(",capa_year1");
                    sb.AppendLine(",capa_year2");
                    sb.AppendLine(",capa_year3");
                    sb.AppendLine(",capa_year4");
                    sb.AppendLine(",capa_year5");
                    sb.AppendLine(",capa_month1");
                    sb.AppendLine(",capa_month2");
                    sb.AppendLine(",capa_month3");
                    sb.AppendLine(",capa_month4");
                    sb.AppendLine(",capa_month5");
                    sb.AppendLine(",capa1");
                    sb.AppendLine(",capa2");
                    sb.AppendLine(",capa3");
                    sb.AppendLine(",capa4");
                    sb.AppendLine(",capa5");
                    sb.AppendLine(",comment");
                    sb.AppendLine(",car_flag");
                    sb.AppendLine(",station");
                    sb.AppendLine(",appended_path1");
                    sb.AppendLine(",appended_path2");
                    sb.AppendLine(",appended_file1");
                    sb.AppendLine(",appended_file2");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_社員詳細");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("id = " + p_id);

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        result = dt_val.Rows.Count;

                        foreach (DataRow dr in dt_val.Rows)
                        {
                            DetailID = int.Parse(dr["detail_id"].ToString());
                            Id = int.Parse(dr["id"].ToString());

                            // 2025/08/13 ADD
                            EntryCompany = DateTime.Parse(dr["entry_company"].ToString());
                            LeavingCompany = DateTime.Parse(dr["leaving_company"].ToString());

                            ZipCode1 = dr["zip_code1"].ToString();
                            ZipCode2 = dr["zip_code2"].ToString();
                            Address1 = dr["address1"].ToString();
                            Address2 = dr["address2"].ToString();
                            TelNo = dr["tel"].ToString();
                            MobileNo = dr["mobile"].ToString();
                            FaxNo = dr["fax"].ToString();
                            MailAddress = dr["mail"].ToString();
                            Birthday = DateTime.Parse(dr["birthday"].ToString());
                            Old = int.Parse(dr["old"].ToString());
                            if (dr["capa_year1"].ToString() != "") { CapaYear1 = int.Parse(dr["capa_year1"].ToString()); }
                            if (dr["capa_year2"].ToString() != "") { CapaYear2 = int.Parse(dr["capa_year2"].ToString()); }
                            if (dr["capa_year3"].ToString() != "") { CapaYear3 = int.Parse(dr["capa_year3"].ToString()); }
                            if (dr["capa_year4"].ToString() != "") { CapaYear4 = int.Parse(dr["capa_year4"].ToString()); }
                            if (dr["capa_year5"].ToString() != "") { CapaYear5 = int.Parse(dr["capa_year5"].ToString()); }
                            if (dr["capa_month1"].ToString() != "") { CapaMonth1 = int.Parse(dr["capa_month1"].ToString()); }
                            if (dr["capa_month2"].ToString() != "") { CapaMonth2 = int.Parse(dr["capa_month2"].ToString()); }
                            if (dr["capa_month3"].ToString() != "") { CapaMonth3 = int.Parse(dr["capa_month3"].ToString()); }
                            if (dr["capa_month4"].ToString() != "") { CapaMonth4 = int.Parse(dr["capa_month4"].ToString()); }
                            if (dr["capa_month5"].ToString() != "") { CapaMonth5 = int.Parse(dr["capa_month5"].ToString()); }
                            Capa1 = dr["capa1"].ToString();
                            Capa2 = dr["capa2"].ToString();
                            Capa3 = dr["capa3"].ToString();
                            Capa4 = dr["capa4"].ToString();
                            Capa5 = dr["capa5"].ToString();
                            Comment = dr["comment"].ToString();
                            CarFlag = int.Parse(dr["car_flag"].ToString());
                            Station = dr["station"].ToString();
                            AppendedPath1 = dr["appended_path1"].ToString();
                            AppendedPath2 = dr["appended_path2"].ToString();
                            AppendedFile1 = dr["appended_file1"].ToString();
                            AppendedFile2 = dr["appended_file2"].ToString();
                            break;
                        }
                    }
                }

                return result;
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
        public void Insert()
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("INSERT INTO");
                    sb.AppendLine("Mst_社員詳細");
                    sb.AppendLine("(");
                    sb.AppendLine("id");

                    // 2025/08/13 ADD
                    sb.AppendLine(",entry_company");
                    sb.AppendLine(",leaving_company");

                    sb.AppendLine(",zip_code1");
                    sb.AppendLine(",zip_code2");
                    sb.AppendLine(",address1");
                    sb.AppendLine(",address2");
                    sb.AppendLine(",tel");
                    sb.AppendLine(",mobile");
                    sb.AppendLine(",fax");
                    sb.AppendLine(",mail");
                    sb.AppendLine(",birthday");
                    sb.AppendLine(",old");
                    sb.AppendLine(",capa_year1");
                    sb.AppendLine(",capa_month1");
                    sb.AppendLine(",capa1");
                    sb.AppendLine(",capa_year2");
                    sb.AppendLine(",capa_month2");
                    sb.AppendLine(",capa2");
                    sb.AppendLine(",capa_year3");
                    sb.AppendLine(",capa_month3");
                    sb.AppendLine(",capa3");
                    sb.AppendLine(",capa_year4");
                    sb.AppendLine(",capa_month4");
                    sb.AppendLine(",capa4");
                    sb.AppendLine(",capa_year5");
                    sb.AppendLine(",capa_month5");
                    sb.AppendLine(",capa5");
                    sb.AppendLine(",comment");
                    sb.AppendLine(",car_flag");
                    sb.AppendLine(",station");
                    sb.AppendLine(",appended_path1");
                    sb.AppendLine(",appended_file1");
                    sb.AppendLine(",appended_path2");
                    sb.AppendLine(",appended_file2");
                    // 2025/11/10↓
                    sb.AppendLine(",ins_user_id");
                    sb.AppendLine(",ins_date");
                    sb.AppendLine(",delete_flag");
                    // 2025/11/10↑
                    sb.AppendLine(") VALUES (");
                    sb.AppendLine(Id.ToString());

                    // 2025/08/13 ADD
                    sb.AppendLine(",'" + EntryCompany.ToString("yyyy/MM/dd") + "'");
                    sb.AppendLine(",'" + LeavingCompany.ToString("yyyy/MM/dd") + "'");

                    sb.AppendLine(",'" + ZipCode1 + "'");
                    sb.AppendLine(",'" + ZipCode2 + "'");
                    sb.AppendLine(",'" + Address1 + "'");
                    sb.AppendLine(",'" + Address2 + "'");
                    sb.AppendLine(",'" + TelNo + "'");
                    sb.AppendLine(",'" + MobileNo + "'");
                    sb.AppendLine(",'" + FaxNo + "'");
                    sb.AppendLine(",'" + MailAddress + "'");
                    sb.AppendLine(",'" + Birthday.ToString("yyyy/MM/dd") + "'");
                    sb.AppendLine("," + Old);
                    sb.AppendLine("," + CapaYear1);
                    sb.AppendLine("," + CapaMonth1);
                    sb.AppendLine(",'" + Capa1 +"'");
                    sb.AppendLine("," + CapaYear2);
                    sb.AppendLine("," + CapaMonth2);
                    sb.AppendLine(",'" + Capa2 + "'");
                    sb.AppendLine("," + CapaYear3);
                    sb.AppendLine("," + CapaMonth3);
                    sb.AppendLine(",'" + Capa3 + "'");
                    sb.AppendLine("," + CapaYear4);
                    sb.AppendLine("," + CapaMonth4);
                    sb.AppendLine(",'" + Capa4 +"'");
                    sb.AppendLine("," + CapaYear5);
                    sb.AppendLine("," + CapaMonth5);
                    sb.AppendLine(",'" + Capa5 + "'");
                    sb.AppendLine(",'" + Comment + "'");
                    sb.AppendLine("," + CarFlag);
                    sb.AppendLine(",'" + Station + "'");
                    sb.AppendLine(",'" + AppendedPath1 + "'");
                    sb.AppendLine(",'" + AppendedFile1 + "'");
                    sb.AppendLine(",'" + AppendedPath2 + "'");
                    sb.AppendLine(",'" + AppendedFile2 + "'");
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
        /// UPDATE
        /// </summary>
        public void Update()
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("UPDATE");
                    sb.AppendLine("Mst_社員詳細");
                    sb.AppendLine("SET");

                    // 2025/08/13 ADD
                    sb.AppendLine(" entry_company = '" + EntryCompany + "'");
                    sb.AppendLine(",leaving_company = '" + LeavingCompany + "'");

                    sb.AppendLine(",zip_code1 = '" + ZipCode1 + "'");
                    sb.AppendLine(",zip_code2 = '" + ZipCode2 + "'");
                    sb.AppendLine(",address1 = '" + Address1 + "'");
                    sb.AppendLine(",address2 = '" + Address2 + "'");
                    sb.AppendLine(",tel = '" + TelNo + "'");
                    sb.AppendLine(",mobile = '" + MobileNo + "'");
                    sb.AppendLine(",fax = '" + FaxNo + "'");
                    sb.AppendLine(",mail = '" + MailAddress + "'");
                    sb.AppendLine(",birthday = '" + Birthday.ToString("yyyy/MM/dd") + "'");
                    sb.AppendLine(",old = " + Old);
                    sb.AppendLine(",capa_year1 = " + CapaYear1);
                    sb.AppendLine(",capa_month1 = " + CapaMonth1);
                    sb.AppendLine(",capa1 = '" + Capa1 + "'");
                    sb.AppendLine(",capa_year2 = " + CapaYear2);
                    sb.AppendLine(",capa_month2 = " + CapaMonth2);
                    sb.AppendLine(",capa2 = '" + Capa2 + "'");
                    sb.AppendLine(",capa_year3 = " + CapaYear3);
                    sb.AppendLine(",capa_month3 = " + CapaMonth3);
                    sb.AppendLine(",capa3 = '" + Capa3 + "'");
                    sb.AppendLine(",capa_year4 = " + CapaYear4);
                    sb.AppendLine(",capa_month4 = " + CapaMonth4);
                    sb.AppendLine(",capa4 = '" + Capa4 + "'");
                    sb.AppendLine(",capa_year5 = " + CapaYear5);
                    sb.AppendLine(",capa_month5 = " + CapaMonth5);
                    sb.AppendLine(",capa5 = '" + Capa5 + "'");
                    sb.AppendLine(",comment = '" + Comment + "'");
                    sb.AppendLine(",car_flag = " + CarFlag);
                    sb.AppendLine(",station = '" + Station + "'");
                    sb.AppendLine(",appended_path1 = '" + AppendedPath1 + "'");
                    sb.AppendLine(",appended_file1 = '" + AppendedFile1 + "'");
                    sb.AppendLine(",appended_path2 = '" + AppendedPath2 + "'");
                    sb.AppendLine(",appended_file2 = '" + AppendedFile2+ "'");
                    // 2025/11/10↓
                    sb.AppendLine(",upd_user_id = " + ClsLoginUser.StaffID);
                    sb.AppendLine(",upd_date = '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    // 2025/11/10↑
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
        /// <summary>
        /// DELETE
        /// </summary>
        public void Delete()
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("DELET");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_社員詳細");
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
        /// <summary>
        /// 社員詳細テーブルの値をXServerのmySQLに登録
        /// </summary>
        public void ExportStaffDetailData()
        {
            try
            {
                using (ClsMySqlDb clsMySqlDb = new(ClsDbConfig.MySQLNo))
                {
                    /////////////////////////////////////////////////////////////////////////
                    // TRUNCATE TABLE
                    // 社員詳細テーブルをクリア
                    /////////////////////////////////////////////////////////////////////////
                    sb.Clear();
                    sb.AppendLine("TRUNCATE TABLE");
                    sb.AppendLine("Mst_社員詳細");

                    clsMySqlDb.DMLUpdate(sb.ToString());

                    /////////////////////////////////////////////////////////////////////////
                    // SQL Server → MySQL
                    /////////////////////////////////////////////////////////////////////////
                    using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                    {
                        // SQL Server SELECT ALL
                        // SQL Serverデータを読み込み、MySQLへ書き込む
                        sb.Clear();
                        sb.AppendLine("SELECT");
                        sb.AppendLine(" detail_id");
                        sb.AppendLine(",id");

                        // 2025/08/13 ADD
                        sb.AppendLine(",entry_company");
                        sb.AppendLine(",leaving_company");

                        sb.AppendLine(",zip_code1");
                        sb.AppendLine(",zip_code2");
                        sb.AppendLine(",address1");
                        sb.AppendLine(",address2");
                        sb.AppendLine(",tel");
                        sb.AppendLine(",fax");
                        sb.AppendLine(",mobile");
                        sb.AppendLine(",mail");
                        sb.AppendLine(",birthday");
                        sb.AppendLine(",old");
                        sb.AppendLine(",capa_year1");
                        sb.AppendLine(",capa_year2");
                        sb.AppendLine(",capa_year3");
                        sb.AppendLine(",capa_year4");
                        sb.AppendLine(",capa_year5");
                        sb.AppendLine(",capa_month1");
                        sb.AppendLine(",capa_month2");
                        sb.AppendLine(",capa_month3");
                        sb.AppendLine(",capa_month4");
                        sb.AppendLine(",capa_month5");
                        sb.AppendLine(",capa1");
                        sb.AppendLine(",capa2");
                        sb.AppendLine(",capa3");
                        sb.AppendLine(",capa4");
                        sb.AppendLine(",capa5");
                        sb.AppendLine(",comment");
                        sb.AppendLine(",car_flag");
                        sb.AppendLine(",station");
                        sb.AppendLine(",appended_path1");
                        sb.AppendLine(",appended_file1");
                        sb.AppendLine(",appended_path2");
                        sb.AppendLine(",appended_file2");
                        // 2025/11/10↓
                        sb.AppendLine(",ins_user_id");
                        sb.AppendLine(",ins_date");
                        sb.AppendLine(",upd_user_id");
                        sb.AppendLine(",upd_date");
                        sb.AppendLine(",delete_flag");
                        // 2025/11/10↑
                        sb.AppendLine("FROM");
                        sb.AppendLine("Mst_社員詳細");
                        sb.AppendLine("ORDER BY");
                        sb.AppendLine("id");

                        using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                        {
                            // MySQL INSERT
                            foreach (DataRow dr in dt_val.Rows)
                            {
                                sb.Clear();
                                sb.AppendLine("INSERT INTO Mst_社員詳細 (");
                                sb.AppendLine(" detail_id");
                                sb.AppendLine(",id");

                                // 2025/08/13 ADD
                                sb.AppendLine(",entry_company");
                                sb.AppendLine(",leaving_company");

                                sb.AppendLine(",zip_code1");
                                sb.AppendLine(",zip_code2");
                                sb.AppendLine(",address1");
                                sb.AppendLine(",address2");
                                sb.AppendLine(",tel");
                                sb.AppendLine(",fax");
                                sb.AppendLine(",mobile");
                                sb.AppendLine(",mail");
                                sb.AppendLine(",birthday");
                                sb.AppendLine(",old");
                                sb.AppendLine(",capa_year1");
                                sb.AppendLine(",capa_year2");
                                sb.AppendLine(",capa_year3");
                                sb.AppendLine(",capa_year4");
                                sb.AppendLine(",capa_year5");
                                sb.AppendLine(",capa_month1");
                                sb.AppendLine(",capa_month2");
                                sb.AppendLine(",capa_month3");
                                sb.AppendLine(",capa_month4");
                                sb.AppendLine(",capa_month5");
                                sb.AppendLine(",capa1");
                                sb.AppendLine(",capa2");
                                sb.AppendLine(",capa3");
                                sb.AppendLine(",capa4");
                                sb.AppendLine(",capa5");
                                sb.AppendLine(",comment");
                                sb.AppendLine(",car_flag");
                                sb.AppendLine(",station");
                                sb.AppendLine(",appended_path1");
                                sb.AppendLine(",appended_file1");
                                sb.AppendLine(",appended_path2");
                                sb.AppendLine(",appended_file2");
                                // 2025/11/10↓
                                sb.AppendLine(",ins_user_id");
                                sb.AppendLine(",ins_date");
                                sb.AppendLine(",upd_user_id");
                                sb.AppendLine(",upd_date");
                                sb.AppendLine(",delete_flag");
                                // 2025/11/10↑
                                sb.AppendLine(") VALUES (");
                                sb.AppendLine(dr["detail_id"].ToString());
                                sb.AppendLine("," + dr["id"].ToString());

                                // 2025/08/13 ADD
                                sb.AppendLine(",'" + dr["entry_company"].ToString() + "'");
                                sb.AppendLine(",'" + dr["leaving_company"].ToString() + "'");

                                sb.AppendLine(",'" + dr["zip_code1"].ToString() + "'");
                                sb.AppendLine(",'" + dr["zip_code2"].ToString() + "'");
                                sb.AppendLine(",'" + dr["address1"].ToString() + "'");
                                sb.AppendLine(",'" + dr["address2"].ToString() + "'");
                                sb.AppendLine(",'" + dr["tel"].ToString() + "'");
                                sb.AppendLine(",'" + dr["fax"].ToString() + "'");
                                sb.AppendLine(",'" + dr["mobile"].ToString() + "'");
                                sb.AppendLine(",'" + dr["mail"].ToString() + "'");
                                sb.AppendLine(",'" + dr["birthday"].ToString() + "'");
                                sb.AppendLine("," + dr["old"].ToString());
                                sb.AppendLine("," + dr["capa_year1"].ToString());
                                sb.AppendLine("," + dr["capa_year2"].ToString());
                                sb.AppendLine("," + dr["capa_year3"].ToString());
                                sb.AppendLine("," + dr["capa_year4"].ToString());
                                sb.AppendLine("," + dr["capa_year5"].ToString());
                                sb.AppendLine("," + dr["capa_month1"].ToString());
                                sb.AppendLine("," + dr["capa_month2"].ToString());
                                sb.AppendLine("," + dr["capa_month3"].ToString());
                                sb.AppendLine("," + dr["capa_month4"].ToString());
                                sb.AppendLine("," + dr["capa_month5"].ToString());
                                sb.AppendLine(",'" + dr["capa1"].ToString() + "'");
                                sb.AppendLine(",'" + dr["capa2"].ToString() + "'");
                                sb.AppendLine(",'" + dr["capa3"].ToString() + "'");
                                sb.AppendLine(",'" + dr["capa4"].ToString() + "'");
                                sb.AppendLine(",'" + dr["capa5"].ToString() + "'");
                                sb.AppendLine(",'" + dr["comment"].ToString() + "'");
                                sb.AppendLine("," + dr["car_flag"].ToString());
                                sb.AppendLine(",'" + dr["station"].ToString() + "'");
                                sb.AppendLine(",'" + dr["appended_path1"].ToString() + "'");
                                sb.AppendLine(",'" + dr["appended_file1"].ToString() + "'");
                                sb.AppendLine(",'" + dr["appended_path2"].ToString() + "'");
                                sb.AppendLine(",'" + dr["appended_file2"].ToString() + "'");
                                // 2025/11/10↓
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
                                // 2025/11/10↑
                                sb.AppendLine(")");

                                clsMySqlDb.DMLUpdate(sb.ToString());
                            }
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
    }
}
