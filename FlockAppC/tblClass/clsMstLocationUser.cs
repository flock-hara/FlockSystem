using FlockAppC.pubClass;
using System;
using System.Data;
using System.Text;

namespace FlockAppC.tblClass
{
    public class ClsMstLocationUser
    {
        public int Id { get; set; }
        public int Location_id { get; set; }
        public string User_name { get; set; }
        public string Group_name { get; set; }
        public string Post { get; set; }
        public string Tel_no { get; set; }
        public string Mobile_no { get; set; }
        public string Mailaddress { get; set; }
        public int Confirm_flag { get; set; }
        public string Login_id { get; set; }
        public string Password { get; set; }
        public string Comment { get; set; }

        private readonly StringBuilder sb = new();

        /// <summary>
        /// Select
        /// </summary>
        public void Select()
        {
            if (this.Id <= 0)
            {
                throw new ArgumentException("IDが設定されていません。");
            }   

            try
            {
                this.Location_id = 0;
                this.User_name = string.Empty;
                this.Group_name = string.Empty;
                this.Post = string.Empty;
                this.Tel_no = string.Empty;
                this.Mobile_no = string.Empty;
                this.Mailaddress = string.Empty;
                this.Confirm_flag = 0;
                this.Login_id = string.Empty;
                this.Password = string.Empty;
                this.Comment = string.Empty;

                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" location_id");
                    sb.AppendLine(",user_name");
                    sb.AppendLine(",group_name");
                    sb.AppendLine(",post");
                    sb.AppendLine(",tel_no");
                    sb.AppendLine(",mobile_no");
                    sb.AppendLine(",mailaddress");
                    sb.AppendLine(",confirm_flag");
                    sb.AppendLine(",login_id");
                    sb.AppendLine(",password");
                    sb.AppendLine(",comment");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_専従先担当者");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("id = " + this.Id);

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            this.Location_id = int.Parse(dr["location_id"].ToString());
                            this.User_name = dr["user_name"].ToString();
                            this.Group_name = dr["group_name"].ToString();
                            this.Post = dr["post"].ToString();
                            this.Tel_no = dr["tel_no"].ToString();
                            this.Mobile_no = dr["mobile_no"].ToString();
                            this.Mailaddress = dr["mailaddress"].ToString();
                            this.Confirm_flag = int.Parse(dr["confirm_flag"].ToString());
                            this.Login_id = dr["login_id"].ToString();
                            this.Password = dr["password"].ToString();
                            this.Comment = dr["comment"].ToString();
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
        /// Insert
        /// </summary>
        public void Insert()
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("INSERT INTO");
                    sb.AppendLine("Mst_専従先担当者");
                    sb.AppendLine("(");
                    sb.AppendLine("location_id");
                    sb.AppendLine(",user_name");
                    sb.AppendLine(",group_name");
                    sb.AppendLine(",post");
                    sb.AppendLine(",tel_no");
                    sb.AppendLine(",mobile_no");
                    sb.AppendLine(",mailaddress");
                    sb.AppendLine(",confirm_flag");
                    sb.AppendLine(",login_id");
                    sb.AppendLine(",password");
                    sb.AppendLine(",comment");
                    // 2025/11/10↓
                    sb.AppendLine(",ins_user_id");
                    sb.AppendLine(",ins_date");
                    sb.AppendLine(",delete_flag");
                    // 2025/11/10↑
                    sb.AppendLine(") VALUES (");
                    sb.AppendLine(this.Location_id.ToString());
                    sb.AppendLine(",'" + this.User_name + "'");
                    sb.AppendLine(",'" + this.Group_name + "'");
                    sb.AppendLine(",'" + this.Post + "'");
                    sb.AppendLine(",'" + this.Tel_no + "'");
                    sb.AppendLine(",'" + this.Mobile_no + "'");
                    sb.AppendLine(",'" + this.Mailaddress + "'");
                    sb.AppendLine("," + this.Confirm_flag.ToString());
                    sb.AppendLine(",'" + this.Login_id + "'");
                    sb.AppendLine(",'" + this.Password + "'");
                    sb.AppendLine(",'" + this.Comment + "'");
                    // 2025/11/10↓
                    sb.AppendLine("," + ClsLoginUser.StaffID);
                    sb.AppendLine(",'" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    sb.AppendLine("," + ClsPublic.FLAG_OFF);
                    // 2025/11/10↑
                    sb.AppendLine(")");

                    clsSqlDb.DMLUpdate(sb.ToString());

                    //// InsertしたレコードIDを取得
                    //sb.Clear();
                    //sb.AppendLine("SELECT");
                    //sb.AppendLine("id");
                    //sb.AppendLine("FROM");
                    //sb.AppendLine("Mst_専従先担当者");
                    //sb.AppendLine("ORDER BY");
                    //sb.AppendLine("id DESC");

                    //using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    //{
                    //    foreach (DataRow dr in dt_val.Rows)
                    //    {
                    //        this.Id = int.Parse(dr["id"].ToString());
                    //        ID = this.Id; // InsertしたレコードIDをセット
                    //        break;
                    //    }
                    //}
                }
                // return ID;
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// Insert
        /// </summary>
        public int InsertScalar()
        {
            int new_id = -1;

            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("INSERT INTO");
                    sb.AppendLine("Mst_専従先担当者");
                    sb.AppendLine("(");
                    sb.AppendLine("location_id");
                    sb.AppendLine(",user_name");
                    sb.AppendLine(",group_name");
                    sb.AppendLine(",post");
                    sb.AppendLine(",tel_no");
                    sb.AppendLine(",mobile_no");
                    sb.AppendLine(",mailaddress");
                    sb.AppendLine(",confirm_flag");
                    sb.AppendLine(",login_id");
                    sb.AppendLine(",password");
                    sb.AppendLine(",comment");
                    // 2025/11/10↓
                    sb.AppendLine(",ins_user_id");
                    sb.AppendLine(",ins_date");
                    sb.AppendLine(",delete_flag");
                    // 2025/11/10↑
                    sb.AppendLine(") VALUES (");
                    sb.AppendLine(this.Location_id.ToString());
                    sb.AppendLine(",'" + this.User_name + "'");
                    sb.AppendLine(",'" + this.Group_name + "'");
                    sb.AppendLine(",'" + this.Post + "'");
                    sb.AppendLine(",'" + this.Tel_no + "'");
                    sb.AppendLine(",'" + this.Mobile_no + "'");
                    sb.AppendLine(",'" + this.Mailaddress + "'");
                    sb.AppendLine("," + this.Confirm_flag.ToString());
                    sb.AppendLine(",'" + this.Login_id + "'");
                    sb.AppendLine(",'" + this.Password + "'");
                    sb.AppendLine(",'" + this.Comment + "'");
                    // 2025/11/10↓
                    sb.AppendLine("," + ClsLoginUser.StaffID);
                    sb.AppendLine(",'" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    sb.AppendLine("," + ClsPublic.FLAG_OFF);
                    // 2025/11/10↑
                    sb.AppendLine("); SELECT SCOPE_IDENTITY();");

                    new_id = clsSqlDb.DMLUpdateScalar(sb.ToString());
                }
                return new_id;
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                return new_id;
                throw;
            }
        }
        /// <summary>
        /// Update
        /// </summary>
        public void Update()
        {
            if (this.Id <= 0)
            {
                throw new ArgumentException("IDが設定されていません。");
            }

            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("UPDATE");
                    sb.AppendLine("Mst_専従先担当者");
                    sb.AppendLine("SET");
                    sb.AppendLine("location_id = " + this.Location_id);
                    sb.AppendLine(",user_name = '" + this.User_name + "'");
                    sb.AppendLine(",group_name = '" + this.Group_name + "'");
                    sb.AppendLine(",post = '" + this.Post + "'");
                    sb.AppendLine(",tel_no = '" + this.Tel_no + "'");
                    sb.AppendLine(",mobile_no = '" + this.Mobile_no + "'");
                    sb.AppendLine(",mailaddress = '" + this.Mailaddress + "'");
                    sb.AppendLine(",confirm_flag = " + this.Confirm_flag);
                    sb.AppendLine(",login_id = '" + this.Login_id + "'");
                    sb.AppendLine(",password = '" + this.Password + "'");
                    sb.AppendLine(",comment = '" + this.Comment + "'");
                    // 2025/11/10↓
                    sb.AppendLine(",upd_user_id = " + ClsLoginUser.StaffID);
                    sb.AppendLine(",upd_date = '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    // 2025/11/10↑
                    sb.AppendLine("WHERE");
                    sb.AppendLine("id = " + this.Id);

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
            if (this.Id <= 0)
            {
                throw new ArgumentException("IDが設定されていません。");
            }

            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("DELETE FROM");
                    sb.AppendLine("Mst_専従先担当者");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("id = " + this.Id);

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
        /// 専従先担当者テーブルの値をXServerのmySQLに登録
        /// </summary>
        public void ExportLocationUserData(ref System.Windows.Forms.ProgressBar p_pgb)
        {
            int rec_cnt;
            int importCnt = 0;

            try
            {
                using (ClsMySqlDb clsMySqlDb = new(ClsDbConfig.MySQLNo))
                {
                    /////////////////////////////////////////////////////////////////////////
                    // TRUNCATE TABLE
                    // XServer側専従先テーブルをクリア
                    /////////////////////////////////////////////////////////////////////////
                    sb.Clear();
                    sb.AppendLine("TRUNCATE TABLE");
                    sb.AppendLine("Mst_専従先担当者");

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
                        sb.AppendLine(",location_id");
                        sb.AppendLine(",user_name");
                        sb.AppendLine(",group_name");
                        sb.AppendLine(",post");
                        sb.AppendLine(",tel_no");
                        sb.AppendLine(",mobile_no");
                        sb.AppendLine(",mailaddress");
                        sb.AppendLine(",confirm_flag");
                        sb.AppendLine(",login_id");
                        sb.AppendLine(",password");
                        sb.AppendLine(",comment");
                        // 2025/11/10↓
                        sb.AppendLine(",ins_user_id");
                        sb.AppendLine(",ins_date");
                        sb.AppendLine(",upd_user_id");
                        sb.AppendLine(",upd_date");
                        sb.AppendLine(",delete_flag");
                        // 2025/11/10↑
                        sb.AppendLine("FROM");
                        sb.AppendLine("Mst_専従先担当者");
                        sb.AppendLine("ORDER BY");
                        sb.AppendLine("id");

                        using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                        {
                            // ProgressBar設定
                            rec_cnt = dt_val.Rows.Count;            // 抽出件数
                            p_pgb.Visible = true;                   // ProgressBar表示
                            p_pgb.Maximum = rec_cnt;                // 件数を最大値に設定

                            // MySQL INSERT
                            foreach (DataRow dr in dt_val.Rows)
                            {
                                sb.Clear();
                                sb.AppendLine("INSERT INTO Mst_専従先担当者 (");
                                sb.AppendLine(" id");
                                sb.AppendLine(",location_id");
                                sb.AppendLine(",user_name");
                                sb.AppendLine(",group_name");
                                sb.AppendLine(",post");
                                sb.AppendLine(",tel_no");
                                sb.AppendLine(",mobile_no");
                                sb.AppendLine(",mailaddress");
                                sb.AppendLine(",confirm_flag");
                                sb.AppendLine(",login_id");
                                sb.AppendLine(",password");
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
                                sb.AppendLine("," + dr["location_id"].ToString());
                                sb.AppendLine(",'" + dr["user_name"].ToString() + "'");
                                sb.AppendLine(",'" + dr["group_name"].ToString() + "'");
                                sb.AppendLine(",'" + dr["post"].ToString() + "'");
                                sb.AppendLine(",'" + dr["tel_no"].ToString() + "'");
                                sb.AppendLine(",'" + dr["mobile_no"].ToString() + "'");
                                sb.AppendLine(",'" + dr["mailaddress"].ToString() + "'");
                                sb.AppendLine("," + dr["confirm_flag"].ToString());
                                sb.AppendLine(",'" + dr["login_id"].ToString() + "'");
                                sb.AppendLine(",'" + dr["password"].ToString() + "'");
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

                                importCnt++;

                                // ProgressBar値セット
                                p_pgb.Value = importCnt;
                                p_pgb.Refresh();
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
        /// <summary>
        /// 専従先担当者テーブルの値をXServerのmySQLに登録
        /// </summary>
        public void ExportLocationOneUserData(int p_id, ClsSqlDb clsSqlDb, ClsMySqlDb clsMySqlDb)
        {
            try
            {
                /////////////////////////////////////////////////////////////////////////
                // TRUNCATE TABLE
                // XServer側専従先テーブルをクリア
                /////////////////////////////////////////////////////////////////////////
                sb.Clear();
                sb.AppendLine("DELETE FROM");
                sb.AppendLine("Mst_専従先担当者");
                sb.AppendLine("WHERE");
                sb.AppendLine("id = " + p_id);
                clsMySqlDb.DMLUpdate(sb.ToString());

                // SQL Server SELECT ALL
                // SQL Serverデータを読み込み、MySQLへ書き込む
                sb.Clear();
                sb.AppendLine("SELECT");
                sb.AppendLine(" id");
                sb.AppendLine(",location_id");
                sb.AppendLine(",user_name");
                sb.AppendLine(",group_name");
                sb.AppendLine(",post");
                sb.AppendLine(",tel_no");
                sb.AppendLine(",mobile_no");
                sb.AppendLine(",mailaddress");
                sb.AppendLine(",confirm_flag");
                sb.AppendLine(",login_id");
                sb.AppendLine(",password");
                sb.AppendLine(",comment");
                sb.AppendLine(",ins_user_id");
                sb.AppendLine(",ins_date");
                sb.AppendLine(",upd_user_id");
                sb.AppendLine(",upd_date");
                sb.AppendLine(",delete_flag");
                sb.AppendLine("FROM");
                sb.AppendLine("Mst_専従先担当者");
                sb.AppendLine("WHERE");
                sb.AppendLine("id = " + p_id);

                using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                {
                    // MySQL INSERT
                    foreach (DataRow dr in dt_val.Rows)
                    {
                        sb.Clear();
                        sb.AppendLine("INSERT INTO Mst_専従先担当者 (");
                        sb.AppendLine(" id");
                        sb.AppendLine(",location_id");
                        sb.AppendLine(",user_name");
                        sb.AppendLine(",group_name");
                        sb.AppendLine(",post");
                        sb.AppendLine(",tel_no");
                        sb.AppendLine(",mobile_no");
                        sb.AppendLine(",mailaddress");
                        sb.AppendLine(",confirm_flag");
                        sb.AppendLine(",login_id");
                        sb.AppendLine(",password");
                        sb.AppendLine(",comment");
                        sb.AppendLine(",ins_user_id");
                        sb.AppendLine(",ins_date");
                        sb.AppendLine(",upd_user_id");
                        sb.AppendLine(",upd_date");
                        sb.AppendLine(",delete_flag");
                        sb.AppendLine(") VALUES (");
                        sb.AppendLine(dr["id"].ToString());
                        sb.AppendLine("," + dr["location_id"].ToString());
                        sb.AppendLine(",'" + dr["user_name"].ToString() + "'");
                        sb.AppendLine(",'" + dr["group_name"].ToString() + "'");
                        sb.AppendLine(",'" + dr["post"].ToString() + "'");
                        sb.AppendLine(",'" + dr["tel_no"].ToString() + "'");
                        sb.AppendLine(",'" + dr["mobile_no"].ToString() + "'");
                        sb.AppendLine(",'" + dr["mailaddress"].ToString() + "'");
                        sb.AppendLine("," + dr["confirm_flag"].ToString());
                        sb.AppendLine(",'" + dr["login_id"].ToString() + "'");
                        sb.AppendLine(",'" + dr["password"].ToString() + "'");
                        sb.AppendLine(",'" + dr["comment"].ToString() + "'");
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
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
        }
    }
}
