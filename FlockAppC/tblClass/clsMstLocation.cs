using FlockAppC.pubClass;
using System;
using System.Data;
using System.Text;

namespace FlockAppC.tblClass
{
    public class ClsMstLocation
    {
        public int Id { get; set; }
        public int Location_Id { get; set; }
        public string Name { get; set; }
        public string Ryaku { get; set; }
        public string Kana { get; set; }
        public int Instructor_Id { get; set; }
        public int Sort { get; set; }
        public string Comment { get; set; }
        public string TelNo { get; set; }
        public string FaxNo { get; set; }
        public string MailAddress { get; set; }
        public string EmergencyTelNo { get; set; }
        public string EmergencyMemo { get; set; }
        public int ClosingDate { get; set; }
        public int ConstractFlag { get; set; }

        private readonly StringBuilder sb = new();

        /// <summary>
        /// 専従先名称取得
        /// </summary>
        public void SelectName()
        {
            try
            {
                this.Name = "";

                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" fullname");
                    sb.AppendLine(",closing_date");
                    sb.AppendLine(",constract_flag");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_専従先");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("location_id = " + Location_Id);

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            this.Name = dr["fullname"].ToString();
                            if (dr["closing_date"] != null && dr["closing_date"].ToString().Length > 0) { this.ClosingDate = int.Parse(dr["closing_date"].ToString()); }
                            else { this.ClosingDate = -1; }
                            if (dr["constract_flag"] != null && dr["constract_flag"].ToString().Length > 0) { this.ConstractFlag = int.Parse(dr["constract_flag"].ToString()); }
                            else { this.ConstractFlag = -1; }
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
        public int Insert()
        {
            int ID = 0;
            
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("INSERT INTO");
                    sb.AppendLine("Mst_専従先");
                    sb.AppendLine("(");
                    sb.AppendLine("location_id");
                    sb.AppendLine(",name");
                    sb.AppendLine(",fullname");
                    sb.AppendLine(",kana1");
                    sb.AppendLine(",kana2");
                    sb.AppendLine(",instructor_id");
                    sb.AppendLine(",sort");
                    sb.AppendLine(",comment");
                    sb.AppendLine(",tel_no");
                    sb.AppendLine(",fax_no");
                    sb.AppendLine(",mailaddress");
                    sb.AppendLine(",emergency_tel_no");
                    sb.AppendLine(",emergency_memo");
                    sb.AppendLine(",closing_date");
                    sb.AppendLine(",constract_flag");
                    // 2025/11/10↓
                    sb.AppendLine(",ins_user_id");
                    sb.AppendLine(",ins_date");
                    sb.AppendLine(",delete_flag");
                    // 2025/11/10↑
                    sb.AppendLine(") VALUES (");
                    sb.AppendLine(Location_Id.ToString());      // Location IDは現時点では未使用 8/23
                    sb.AppendLine(",'" + Ryaku + "'" );
                    sb.AppendLine(",'" + Name + "'");
                    sb.AppendLine(",'" + Kana + "'");
                    sb.AppendLine(",'" + Kana + "'");
                    sb.AppendLine("," + Instructor_Id);
                    sb.AppendLine("," + Sort);
                    sb.AppendLine(",'" + Comment + "'");
                    sb.AppendLine(",'" + TelNo + "'");
                    sb.AppendLine(",'" + FaxNo + "'");
                    sb.AppendLine(",'" + MailAddress + "'");
                    sb.AppendLine(",'" + EmergencyTelNo + "'");
                    sb.AppendLine(",'" + EmergencyMemo + "'");
                    sb.AppendLine("," + ClosingDate);
                    sb.AppendLine("," + ConstractFlag);
                    // 2025/11/10↓
                    sb.AppendLine("," + ClsLoginUser.StaffID);
                    sb.AppendLine(",'" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    sb.AppendLine("," + ClsPublic.FLAG_OFF);
                    // 2025/11/10↑
                    sb.AppendLine(")");

                    clsSqlDb.DMLUpdate(sb.ToString());

                    // InsertしたレコードIDを取得
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("id");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_専従先");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("name = '" + Ryaku + "'");
                    sb.AppendLine("AND");
                    sb.AppendLine("fullname = '" + Name + "'");
                    sb.AppendLine("AND");
                    sb.AppendLine("kana1 = '" + Kana + "'");
                    sb.AppendLine("AND");
                    sb.AppendLine("instructor_id = " + Instructor_Id);
                    sb.AppendLine("AND");
                    sb.AppendLine("sort = " + Sort);

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            ID = int.Parse(dr["id"].ToString());
                        }
                    }

                    // Insertしたレコードのlocation_idを書き換える
                    sb.Clear();
                    sb.AppendLine("UPDATE");
                    sb.AppendLine("Mst_専従先");
                    sb.AppendLine("SET");
                    sb.AppendLine("location_id = " + ID);
                    sb.AppendLine("WHERE");
                    sb.AppendLine("id = " + ID);

                    clsSqlDb.DMLUpdate(sb.ToString());
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
        /// Insert ※INSERTしたレコードIDをlocation_idに更新
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
                    sb.AppendLine("Mst_専従先");
                    sb.AppendLine("(");
                    sb.AppendLine("location_id");
                    sb.AppendLine(",name");
                    sb.AppendLine(",fullname");
                    sb.AppendLine(",kana1");
                    sb.AppendLine(",kana2");
                    sb.AppendLine(",instructor_id");
                    sb.AppendLine(",sort");
                    sb.AppendLine(",comment");
                    sb.AppendLine(",tel_no");
                    sb.AppendLine(",fax_no");
                    sb.AppendLine(",mailaddress");
                    sb.AppendLine(",emergency_tel_no");
                    sb.AppendLine(",emergency_memo");
                    sb.AppendLine(",closing_date");
                    sb.AppendLine(",constract_flag");
                    // 2025/11/10↓
                    sb.AppendLine(",ins_user_id");
                    sb.AppendLine(",ins_date");
                    sb.AppendLine(",delete_flag");
                    // 2025/11/10↑
                    sb.AppendLine(") VALUES (");
                    sb.AppendLine(Location_Id.ToString());      // Location IDは現時点では未使用 8/23
                    sb.AppendLine(",'" + Ryaku + "'");
                    sb.AppendLine(",'" + Name + "'");
                    sb.AppendLine(",'" + Kana + "'");
                    sb.AppendLine(",'" + Kana + "'");
                    sb.AppendLine("," + Instructor_Id);
                    sb.AppendLine("," + Sort);
                    sb.AppendLine(",'" + Comment + "'");
                    sb.AppendLine(",'" + TelNo + "'");
                    sb.AppendLine(",'" + FaxNo + "'");
                    sb.AppendLine(",'" + MailAddress + "'");
                    sb.AppendLine(",'" + EmergencyTelNo + "'");
                    sb.AppendLine(",'" + EmergencyMemo + "'");
                    sb.AppendLine("," + ClosingDate);
                    sb.AppendLine("," + ConstractFlag);
                    // 2025/11/10↓
                    sb.AppendLine("," + ClsLoginUser.StaffID);
                    sb.AppendLine(",'" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    sb.AppendLine("," + ClsPublic.FLAG_OFF);
                    // 2025/11/10↑
                    sb.AppendLine("); SELECT SCOPE_IDENTITY();");

                    new_id = clsSqlDb.DMLUpdateScalar(sb.ToString());

                    //// InsertしたレコードIDを取得
                    //sb.Clear();
                    //sb.AppendLine("SELECT");
                    //sb.AppendLine("id");
                    //sb.AppendLine("FROM");
                    //sb.AppendLine("Mst_専従先");
                    //sb.AppendLine("WHERE");
                    //sb.AppendLine("name = '" + Ryaku + "'");
                    //sb.AppendLine("AND");
                    //sb.AppendLine("fullname = '" + Name + "'");
                    //sb.AppendLine("AND");
                    //sb.AppendLine("kana1 = '" + Kana + "'");
                    //sb.AppendLine("AND");
                    //sb.AppendLine("instructor_id = " + Instructor_Id);
                    //sb.AppendLine("AND");
                    //sb.AppendLine("sort = " + Sort);

                    //using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    //{
                    //    foreach (DataRow dr in dt_val.Rows)
                    //    {
                    //        ID = int.Parse(dr["id"].ToString());
                    //    }
                    //}

                    // Insertしたレコードのlocation_idを書き換える
                    sb.Clear();
                    sb.AppendLine("UPDATE");
                    sb.AppendLine("Mst_専従先");
                    sb.AppendLine("SET");
                    sb.AppendLine("location_id = " + new_id);
                    sb.AppendLine("WHERE");
                    sb.AppendLine("id = " + new_id);

                    clsSqlDb.DMLUpdate(sb.ToString());
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
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("UPDATE");
                    sb.AppendLine("Mst_専従先");
                    sb.AppendLine("SET");
                    sb.AppendLine("location_id = " + Id);
                    sb.AppendLine(",name = '" + Ryaku + "'");
                    sb.AppendLine(",fullname = '" + Name + "'");
                    sb.AppendLine(",kana1 = '" + Kana + "'");
                    sb.AppendLine(",kana2 = '" + Kana + "'");
                    sb.AppendLine(",instructor_id = " + Instructor_Id);
                    sb.AppendLine(",sort = " + Sort);
                    sb.AppendLine(",comment = '" + Comment + "'");
                    sb.AppendLine(",tel_no = '" + TelNo + "'");
                    sb.AppendLine(",fax_no = '" + FaxNo + "'");
                    sb.AppendLine(",mailaddress = '" + MailAddress + "'");
                    sb.AppendLine(",emergency_tel_no = '" + EmergencyTelNo + "'");
                    sb.AppendLine(",emergency_memo = '" + EmergencyMemo + "'");
                    sb.AppendLine(",closing_date = " + ClosingDate);
                    sb.AppendLine(",constract_flag = " + ConstractFlag);
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
        /// Delete
        /// </summary>
        public void Delete()
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("DELETE FROM");
                    sb.AppendLine("Mst_専従先");
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
        /// 専従先テーブルの値をXServerのmySQLに登録
        /// </summary>
        public void ExportLocationData(ref System.Windows.Forms.ProgressBar p_pgb)
        {
            int rec_cnt;
            int importCnt = 0;
            
            // =============================================================================
            // 更新日付を参照し、エクスポート対象のデータのみエクスポートする
            // 追々対応予定
            // 専従先マスターには更新日付項目は追加済み
            // =============================================================================

            try
            {
                using (ClsMySqlDb clsMySqlDb = new(ClsDbConfig.MySQLNo))
                {
                    /////////////////////////////////////////////////////////////////////////
                    // TRUNCATE TABLE (MySQL)
                    // XServer側専従先テーブルをクリア
                    /////////////////////////////////////////////////////////////////////////
                    sb.Clear();
                    sb.AppendLine("TRUNCATE TABLE");
                    sb.AppendLine("Mst_専従先");
                    
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
                        sb.AppendLine(",name");
                        sb.AppendLine(",fullname");
                        sb.AppendLine(",kana1");
                        sb.AppendLine(",kana2");
                        sb.AppendLine(",instructor_id");
                        sb.AppendLine(",sort");
                        sb.AppendLine(",comment");
                        sb.AppendLine(",tel_no");
                        sb.AppendLine(",fax_no");
                        sb.AppendLine(",mailaddress");
                        sb.AppendLine(",emergency_tel_no");
                        sb.AppendLine(",emergency_memo");
                        sb.AppendLine(",closing_date");
                        sb.AppendLine(",constract_flag");
                        // 2025/11/10↓
                        sb.AppendLine(",ins_user_id");
                        sb.AppendLine(",ins_date");
                        sb.AppendLine(",upd_user_id");
                        sb.AppendLine(",upd_date");
                        sb.AppendLine(",delete_flag");
                        // 2025/11/10↑
                        sb.AppendLine("FROM");
                        sb.AppendLine("Mst_専従先");
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
                                sb.Length = 0;
                                sb.AppendLine("INSERT INTO Mst_専従先 (");
                                sb.AppendLine(" id");
                                sb.AppendLine(",location_id");
                                sb.AppendLine(",name");
                                sb.AppendLine(",fullname");
                                sb.AppendLine(",kana1");
                                sb.AppendLine(",kana2");
                                sb.AppendLine(",instructor_id");
                                sb.AppendLine(",sort");
                                sb.AppendLine(",comment");
                                sb.AppendLine(",tel_no");
                                sb.AppendLine(",fax_no");
                                sb.AppendLine(",mailaddress");
                                sb.AppendLine(",emergency_tel_no");
                                sb.AppendLine(",emergency_memo");
                                sb.AppendLine(",closing_date");
                                sb.AppendLine(",constract_flag");
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
                                sb.AppendLine(",'" + dr["name"].ToString() + "'");
                                sb.AppendLine(",'" + dr["fullname"].ToString() + "'");
                                sb.AppendLine(",'" + dr["kana1"].ToString() + "'");
                                sb.AppendLine(",'" + dr["kana2"].ToString() + "'");
                                sb.AppendLine("," + dr["instructor_id"].ToString());
                                sb.AppendLine("," + dr["sort"].ToString());
                                sb.AppendLine(",'" + dr["comment"].ToString() + "'");
                                sb.AppendLine(",'" + dr["tel_no"].ToString() + "'");
                                sb.AppendLine(",'" + dr["fax_no"].ToString() + "'");
                                sb.AppendLine(",'" + dr["mailaddress"].ToString() + "'");
                                sb.AppendLine(",'" + dr["emergency_tel_no"].ToString() + "'");
                                sb.AppendLine(",'" + dr["emergency_memo"].ToString() + "'");

                                if (dr["closing_date"].ToString().Length != 0)
                                {
                                    sb.AppendLine("," + dr["closing_date"].ToString());
                                }
                                else
                                {
                                    sb.AppendLine(",31");
                                }

                                if (dr["constract_flag"].ToString().Length != 0)
                                {
                                    sb.AppendLine("," + dr["constract_flag"].ToString());
                                }
                                else
                                {
                                    sb.AppendLine("," + ClsPublic.FLAG_OFF);
                                }
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
        /// 専従先テーブルの値をXServerのmySQLに登録
        /// </summary>
        public void ExportLocationAllData(ClsSqlDb clsSqlDb, ClsMySqlDb clsMySqlDb)
        {
            try
            {
                /////////////////////////////////////////////////////////////////////////
                // TRUNCATE TABLE (MySQL)
                // XServer側専従先テーブルをクリア
                /////////////////////////////////////////////////////////////////////////
                sb.Clear();
                sb.AppendLine("TRUNCATE TABLE");
                sb.AppendLine("Mst_専従先");
                clsMySqlDb.DMLUpdate(sb.ToString());

                // SQL Server SELECT ALL
                // SQL Serverデータを読み込み、MySQLへ書き込む
                sb.Clear();
                sb.AppendLine("SELECT");
                sb.AppendLine(" id");
                sb.AppendLine(",location_id");
                sb.AppendLine(",name");
                sb.AppendLine(",fullname");
                sb.AppendLine(",kana1");
                sb.AppendLine(",kana2");
                sb.AppendLine(",instructor_id");
                sb.AppendLine(",sort");
                sb.AppendLine(",comment");
                sb.AppendLine(",tel_no");
                sb.AppendLine(",fax_no");
                sb.AppendLine(",mailaddress");
                sb.AppendLine(",emergency_tel_no");
                sb.AppendLine(",emergency_memo");
                sb.AppendLine(",closing_date");
                sb.AppendLine(",constract_flag");
                sb.AppendLine(",ins_user_id");
                sb.AppendLine(",ins_date");
                sb.AppendLine(",upd_user_id");
                sb.AppendLine(",upd_date");
                sb.AppendLine(",delete_flag");
                sb.AppendLine("FROM");
                sb.AppendLine("Mst_専従先");
                sb.AppendLine("ORDER BY");
                sb.AppendLine("id");

                using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                {
                    // MySQL INSERT
                    foreach (DataRow dr in dt_val.Rows)
                    {
                        sb.Clear();
                        sb.AppendLine("INSERT INTO Mst_専従先 (");
                        sb.AppendLine(" id");
                        sb.AppendLine(",location_id");
                        sb.AppendLine(",name");
                        sb.AppendLine(",fullname");
                        sb.AppendLine(",kana1");
                        sb.AppendLine(",kana2");
                        sb.AppendLine(",instructor_id");
                        sb.AppendLine(",sort");
                        sb.AppendLine(",comment");
                        sb.AppendLine(",tel_no");
                        sb.AppendLine(",fax_no");
                        sb.AppendLine(",mailaddress");
                        sb.AppendLine(",emergency_tel_no");
                        sb.AppendLine(",emergency_memo");
                        sb.AppendLine(",closing_date");
                        sb.AppendLine(",constract_flag");
                        sb.AppendLine(",ins_user_id");
                        sb.AppendLine(",ins_date");
                        sb.AppendLine(",upd_user_id");
                        sb.AppendLine(",upd_date");
                        sb.AppendLine(",delete_flag");
                        sb.AppendLine(") VALUES (");
                        sb.AppendLine(dr["id"].ToString());
                        sb.AppendLine("," + dr["location_id"].ToString());
                        sb.AppendLine(",'" + dr["name"].ToString() + "'");
                        sb.AppendLine(",'" + dr["fullname"].ToString() + "'");
                        sb.AppendLine(",'" + dr["kana1"].ToString() + "'");
                        sb.AppendLine(",'" + dr["kana2"].ToString() + "'");
                        sb.AppendLine("," + dr["instructor_id"].ToString());
                        sb.AppendLine("," + dr["sort"].ToString());
                        sb.AppendLine(",'" + dr["comment"].ToString() + "'");
                        sb.AppendLine(",'" + dr["tel_no"].ToString() + "'");
                        sb.AppendLine(",'" + dr["fax_no"].ToString() + "'");
                        sb.AppendLine(",'" + dr["mailaddress"].ToString() + "'");
                        sb.AppendLine(",'" + dr["emergency_tel_no"].ToString() + "'");
                        sb.AppendLine(",'" + dr["emergency_memo"].ToString() + "'");

                        if (dr["closing_date"].ToString().Length != 0)
                        {
                            sb.AppendLine("," + dr["closing_date"].ToString());
                        }
                        else
                        {
                            sb.AppendLine(",31");
                        }

                        if (dr["constract_flag"].ToString().Length != 0)
                        {
                            sb.AppendLine("," + dr["constract_flag"].ToString());
                        }
                        else
                        {
                            sb.AppendLine(",0");
                        }
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
        /// <summary>
        /// 専従先テーブルの値をXServerのmySQLに登録（１件）
        /// </summary>
        public void ExportLocationOneData(int p_location, ClsSqlDb clsSqlDb, ClsMySqlDb clsMySqlDb)
        {
            // =============================================================================
            // 更新日付を参照し、エクスポート対象のデータのみエクスポートする
            // 追々対応予定
            // 専従先マスターには更新日付項目は追加済み
            // =============================================================================
            try
            {
                /////////////////////////////////////////////////////////////////////////
                // DELETE TABLE (MySQL)
                /////////////////////////////////////////////////////////////////////////
                sb.Clear();
                sb.AppendLine("DELETE TABLE");
                sb.AppendLine("Mst_専従先");
                sb.AppendLine("WHERE");
                sb.AppendLine("location_id" + p_location);
                clsMySqlDb.DMLUpdate(sb.ToString());

                /////////////////////////////////////////////////////////////////////////
                // SQL Server → MySQL
                /////////////////////////////////////////////////////////////////////////
                sb.Clear();
                sb.AppendLine("SELECT");
                sb.AppendLine(" id");
                sb.AppendLine(",location_id");
                sb.AppendLine(",name");
                sb.AppendLine(",fullname");
                sb.AppendLine(",kana1");
                sb.AppendLine(",kana2");
                sb.AppendLine(",instructor_id");
                sb.AppendLine(",sort");
                sb.AppendLine(",comment");
                sb.AppendLine(",tel_no");
                sb.AppendLine(",fax_no");
                sb.AppendLine(",mailaddress");
                sb.AppendLine(",emergency_tel_no");
                sb.AppendLine(",emergency_memo");
                sb.AppendLine(",closing_date");
                sb.AppendLine(",constract_flag");
                sb.AppendLine(",ins_user_id");
                sb.AppendLine(",ins_date");
                sb.AppendLine(",upd_user_id");
                sb.AppendLine(",upd_date");
                sb.AppendLine(",delete_flag");
                sb.AppendLine("FROM");
                sb.AppendLine(" Mst_専従先");
                sb.AppendLine(" WHERE");
                sb.AppendLine(" location_id = " + p_location);

                using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                {
                    // MySQL INSERT
                    foreach (DataRow dr in dt_val.Rows)
                    {
                        sb.Clear();
                        sb.AppendLine("INSERT INTO Mst_専従先 (");
                        sb.AppendLine(" id");
                        sb.AppendLine(",location_id");
                        sb.AppendLine(",name");
                        sb.AppendLine(",fullname");
                        sb.AppendLine(",kana1");
                        sb.AppendLine(",kana2");
                        sb.AppendLine(",instructor_id");
                        sb.AppendLine(",sort");
                        sb.AppendLine(",comment");
                        sb.AppendLine(",tel_no");
                        sb.AppendLine(",fax_no");
                        sb.AppendLine(",mailaddress");
                        sb.AppendLine(",emergency_tel_no");
                        sb.AppendLine(",emergency_memo");
                        sb.AppendLine(",closing_date");
                        sb.AppendLine(",constract_flag");
                        sb.AppendLine(",ins_user_id");
                        sb.AppendLine(",ins_date");
                        sb.AppendLine(",upd_user_id");
                        sb.AppendLine(",upd_date");
                        sb.AppendLine(",delete_flag");
                        sb.AppendLine(") VALUES (");
                        sb.AppendLine(dr["id"].ToString());
                        sb.AppendLine("," + dr["location_id"].ToString());
                        sb.AppendLine(",'" + dr["name"].ToString() + "'");
                        sb.AppendLine(",'" + dr["fullname"].ToString() + "'");
                        sb.AppendLine(",'" + dr["kana1"].ToString() + "'");
                        sb.AppendLine(",'" + dr["kana2"].ToString() + "'");
                        sb.AppendLine("," + dr["instructor_id"].ToString());
                        sb.AppendLine("," + dr["sort"].ToString());
                        sb.AppendLine(",'" + dr["comment"].ToString() + "'");
                        sb.AppendLine(",'" + dr["tel_no"].ToString() + "'");
                        sb.AppendLine(",'" + dr["fax_no"].ToString() + "'");
                        sb.AppendLine(",'" + dr["mailaddress"].ToString() + "'");
                        sb.AppendLine(",'" + dr["emergency_tel_no"].ToString() + "'");
                        sb.AppendLine(",'" + dr["emergency_memo"].ToString() + "'");

                        if (dr["closing_date"].ToString().Length != 0)
                        {
                            sb.AppendLine("," + dr["closing_date"].ToString());
                        }
                        else
                        {
                            sb.AppendLine(",31");
                        }

                        if (dr["constract_flag"].ToString().Length != 0)
                        {
                            sb.AppendLine("," + dr["constract_flag"].ToString());
                        }
                        else
                        {
                            sb.AppendLine("," + ClsPublic.FLAG_OFF);
                        }
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
