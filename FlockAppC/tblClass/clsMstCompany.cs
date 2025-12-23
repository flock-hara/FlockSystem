using FlockAppC.pubClass;
using System;
using System.Data;
using System.Text;

namespace FlockAppC.tblClass
{
    public class ClsMstCompany
    {
        public int ID { get; set; }
        public string CompanyName1 { get; set; }
        public string CompanyName2 { get; set; }
        public string ZipCode1 { get; set; }
        public string ZipCode2 { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string TelNo1 { get; set; }
        public string TelNo2 { get; set; }
        public string TelNo3 { get; set; }
        public string FaxNo1 { get; set; }
        public string FaxNo2 { get; set; }
        public string MailAddress1 { get; set; }
        public string MailAddress2 { get; set; }
        public string MailAddress3 { get; set; }
        public string Url1 { get; set; }
        public string Url2 { get; set; }
        public string Delegete { get; set; }
        public string Comment { get; set; }

        private readonly StringBuilder sb = new();

        /// <summary>
        /// Insert
        /// </summary>
        public void Insert()
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("MAX(id) AS Max");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_自社");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            this.ID = int.Parse(dr["Max"].ToString()) + 1;
                        }
                    }

                    sb.Clear();
                    sb.AppendLine("INSERT INTO");
                    sb.AppendLine("Mst_自社");
                    sb.AppendLine("(");
                    sb.AppendLine(" id");
                    sb.AppendLine(",company_name1");
                    sb.AppendLine(",company_name2");
                    sb.AppendLine(",zip_code1");
                    sb.AppendLine(",zip_code2");
                    sb.AppendLine(",address1");
                    sb.AppendLine(",address2");
                    sb.AppendLine(",tel1");
                    sb.AppendLine(",tel2");
                    sb.AppendLine(",tel3");
                    sb.AppendLine(",fax1");
                    sb.AppendLine(",fax2");
                    sb.AppendLine(",mail1");
                    sb.AppendLine(",mail2");
                    sb.AppendLine(",mail3");
                    sb.AppendLine(",url1");
                    sb.AppendLine(",url2");
                    sb.AppendLine(",delegate");
                    sb.AppendLine(",comment");
                    // 2025/11/10↓
                    sb.AppendLine(",ins_user_id");
                    sb.AppendLine(",ins_date");
                    sb.AppendLine(",delete_flag");
                    // 2025/11/10↑
                    sb.AppendLine(") VALUES (");
                    sb.AppendLine(this.ID.ToString());
                    sb.AppendLine(",'" + CompanyName1 + "'");
                    sb.AppendLine(",'" + CompanyName2 + "'");
                    sb.AppendLine(",'" + ZipCode1 + "'");
                    sb.AppendLine(",'" + ZipCode2 + "'");
                    sb.AppendLine(",'" + Address1 + "'");
                    sb.AppendLine(",'" + Address2 + "'");
                    sb.AppendLine(",'" + TelNo1 + "'");
                    sb.AppendLine(",'" + TelNo2 + "'");
                    sb.AppendLine(",'" + TelNo3 + "'");
                    sb.AppendLine(",'" + FaxNo1 + "'");
                    sb.AppendLine(",'" + FaxNo2 + "'");
                    sb.AppendLine(",'" + MailAddress1 + "'");
                    sb.AppendLine(",'" + MailAddress2 + "'");
                    sb.AppendLine(",'" + MailAddress3 + "'");
                    sb.AppendLine(",'" + Url1 + "'");
                    sb.AppendLine(",'" + Url2 + "'");
                    sb.AppendLine(",'" + Delegete + "'");
                    sb.AppendLine(",'" + Comment + "'");
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
        /// Update
        /// </summary>
        public void Update()
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("UPDATE");
                    sb.AppendLine("Mst_自社");
                    sb.AppendLine("SET");
                    sb.AppendLine(" company_name1 = '" + CompanyName1 + "'");
                    sb.AppendLine(",company_name2 = '" + CompanyName2 + "'");
                    sb.AppendLine(",zip_code1 = '" + ZipCode1 + "'");
                    sb.AppendLine(",zip_code2 = '" + ZipCode2 + "'");
                    sb.AppendLine(",address1 = '" + Address1 + "'");
                    sb.AppendLine(",address2 = '" + Address2 + "'");
                    sb.AppendLine(",tel1 = '" + TelNo1 + "'");
                    sb.AppendLine(",tel2 = '" + TelNo2 + "'");
                    sb.AppendLine(",tel3 = '" + TelNo3 + "'");
                    sb.AppendLine(",fax1 = '" + FaxNo1 + "'");
                    sb.AppendLine(",fax2 = '" + FaxNo2 + "'");
                    sb.AppendLine(",mail1 = '" + MailAddress1 + "'");
                    sb.AppendLine(",mail2 = '" + MailAddress2 + "'");
                    sb.AppendLine(",mail3 = '" + MailAddress3 + "'");
                    sb.AppendLine(",url1 = '" + Url1 + "'");
                    sb.AppendLine(",url2 = '" + Url2 + "'");
                    sb.AppendLine(",delegete = '" + Delegete + "'");
                    sb.AppendLine(",comment = '" + Comment + "'");
                    // 2025/11/10↓
                    sb.AppendLine(",upd_user_id = " + ClsLoginUser.StaffID);
                    sb.AppendLine(",upd_date = '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    // 2025/11/10↑
                    sb.AppendLine("WHERE");
                    sb.AppendLine("id = " + ID);

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
        /// Delete
        /// </summary>
        public void Delete()
        {
        }
        /// <summary>
        /// SQL Serverテーブル値をXServerのmySQLに登録
        /// </summary>
        public void ExportCompanyData()
        {
            try
            {
                using (ClsMySqlDb clsMySqlDb = new(ClsDbConfig.MySQLNo))
                {
                    /////////////////////////////////////////////////////////////////////////
                    // TRUNCATE TABLE (MySQL)
                    // テーブルをクリア
                    /////////////////////////////////////////////////////////////////////////
                    sb.Clear();
                    sb.AppendLine("TRUNCATE TABLE");
                    sb.AppendLine("Mst_自社");
                    
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
                        sb.AppendLine(" id");
                        sb.AppendLine(",company_name1");
                        sb.AppendLine(",company_name2");
                        sb.AppendLine(",zip_code1");
                        sb.AppendLine(",zip_code2");
                        sb.AppendLine(",address1");
                        sb.AppendLine(",address2");
                        sb.AppendLine(",tel1");
                        sb.AppendLine(",tel2");
                        sb.AppendLine(",tel3");
                        sb.AppendLine(",fax1");
                        sb.AppendLine(",fax2");
                        sb.AppendLine(",mail1");
                        sb.AppendLine(",mail2");
                        sb.AppendLine(",mail3");
                        sb.AppendLine(",url1");
                        sb.AppendLine(",url2");
                        sb.AppendLine(",delegete");
                        sb.AppendLine(",comment");
                        // 2025/11/10↓
                        sb.AppendLine(",ins_user_id");
                        sb.AppendLine(",ins_date");
                        sb.AppendLine(",upd_user_id");
                        sb.AppendLine(",upd_date");
                        sb.AppendLine(",delete_flag");
                        // 2025/11/10↑
                        sb.AppendLine("FROM");
                        sb.AppendLine("Mst_自社");
                        sb.AppendLine("ORDER BY");
                        sb.AppendLine("id");

                        using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                        {

                            // MySQL INSERT
                            foreach (DataRow dr in dt_val.Rows)
                            {
                                sb.Clear();
                                sb.AppendLine("INSERT INTO Mst_自社 (");
                                sb.AppendLine(" id");
                                sb.AppendLine(",company_name1");
                                sb.AppendLine(",company_name2");
                                sb.AppendLine(",zip_code1");
                                sb.AppendLine(",zip_code2");
                                sb.AppendLine(",address1");
                                sb.AppendLine(",address2");
                                sb.AppendLine(",tel1");
                                sb.AppendLine(",tel2");
                                sb.AppendLine(",tel3");
                                sb.AppendLine(",fax1");
                                sb.AppendLine(",fax2");
                                sb.AppendLine(",mail1");
                                sb.AppendLine(",mail2");
                                sb.AppendLine(",mail3");
                                sb.AppendLine(",url1");
                                sb.AppendLine(",url2");
                                sb.AppendLine(",delegete");
                                sb.AppendLine(",comment");
                                // 2025/11/10↓
                                sb.AppendLine(",ins_user_id");
                                sb.AppendLine(",ins_date");
                                sb.AppendLine(",upd_user_id");
                                sb.AppendLine(",upd_date");
                                sb.AppendLine(",delete_flag");
                                // 2025/11/10↑
                                sb.AppendLine(") VALUES (");
                                sb.AppendLine(dr["id"].ToString());
                                sb.AppendLine(",'" + dr["company_name1"].ToString() + "'");
                                sb.AppendLine(",'" + dr["company_name2"].ToString() + "'");
                                sb.AppendLine(",'" + dr["zip_code1"].ToString() + "'");
                                sb.AppendLine(",'" + dr["zip_code2"].ToString() + "'");
                                sb.AppendLine(",'" + dr["address1"].ToString() + "'");
                                sb.AppendLine(",'" + dr["address2"].ToString() + "'");
                                sb.AppendLine(",'" + dr["tel1"].ToString() + "'");
                                sb.AppendLine(",'" + dr["tel2"].ToString() + "'");
                                sb.AppendLine(",'" + dr["tel3"].ToString() + "'");
                                sb.AppendLine(",'" + dr["fax1"].ToString() + "'");
                                sb.AppendLine(",'" + dr["fax2"].ToString() + "'");
                                sb.AppendLine(",'" + dr["mail1"].ToString() + "'");
                                sb.AppendLine(",'" + dr["mail2"].ToString() + "'");
                                sb.AppendLine(",'" + dr["mail3"].ToString() + "'");
                                sb.AppendLine(",'" + dr["url1"].ToString() + "'");
                                sb.AppendLine(",'" + dr["url2"].ToString() + "'");
                                sb.AppendLine(",'" + dr["delegete"].ToString() + "'");
                                sb.AppendLine(",'" + dr["comment"].ToString() + "'");

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
