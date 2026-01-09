using FlockAppC.pubClass;
using System;
using System.Data;
using System.Text;

namespace FlockAppC.tblClass
{
    public class ClsMstKbn
    {
        private readonly StringBuilder sb = new();

        /// <summary>
        /// Insert
        /// </summary>
        public void Insert()
        {
            //StringBuilder st = new StringBuilder();

            //try
            //{
            //    using (clsDbCon cDb = new clsDbCon())
            //    {
            //        st.Length = 0;
            //        st.AppendLine("INSERT INTO");
            //        st.AppendLine("Mst_部門");
            //        st.AppendLine("(");
            //        st.AppendLine("Name");
            //        st.AppendLine(",Sort");
            //        st.AppendLine(") VALUES (");
            //        st.AppendLine("'" + Name + "'");
            //        st.AppendLine("," + Sort);
            //        st.AppendLine(")");
            //        cDb.Sql = st.ToString();
            //        cDb.DbCon();
            //        cDb.DMLUpdate();
            //        cDb.DBClose();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    throw;
            //}
        }
        /// <summary>
        /// Update
        /// </summary>
        public void Update()
        {
            //StringBuilder st = new StringBuilder();

            //try
            //{
            //    using (clsDbCon cDb = new clsDbCon())
            //    {
            //        st.Length = 0;
            //        st.AppendLine("UPDATE");
            //        st.AppendLine("Mst_部門");
            //        st.AppendLine("SET");
            //        st.AppendLine("Name = '" + Name + "'");
            //        st.AppendLine(",Sort = " + Sort);
            //        st.AppendLine("WHERE");
            //        st.AppendLine("ID = " + ID);
            //        cDb.Sql = st.ToString();
            //        cDb.DbCon();
            //        cDb.DMLUpdate();
            //        cDb.DBClose();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    throw;
            //}

        }
        /// <summary>
        /// Delete
        /// </summary>
        public void Delete()
        {
            //StringBuilder st = new StringBuilder();

            //try
            //{
            //    using (clsDbCon cDb = new clsDbCon())
            //    {
            //        st.Length = 0;
            //        st.AppendLine("DELETE FROM");
            //        st.AppendLine("Mst_部門");
            //        st.AppendLine("WHERE");
            //        st.AppendLine("ID = " + ID);
            //        cDb.Sql = st.ToString();
            //        cDb.DbCon();
            //        cDb.DMLUpdate();
            //        cDb.DBClose();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    throw;
            //}
        }
        /// <summary>
        /// SQL Serverテーブル値をXServerのmySQLに登録
        /// </summary>
        public void ExportKbnData(ref System.Windows.Forms.ProgressBar p_pgb)
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
                // xserver(mySQL)接続
                using (ClsMySqlDb clsMySqlDb = new(ClsDbConfig.MySQLNo))
                {
                    // １．MySQLに作業用テーブルを作成
                    sb.Clear();
                    sb.AppendLine("CREATE TABLE Mst_区分_work LIKE Mst_区分");
                    clsMySqlDb.DMLUpdate(sb.ToString());

                    // ２．SQL Serverの全データをMySQLの作業用テーブルにINSERT
                    using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                    {
                        // SQL Server SELECT ALL
                        sb.Clear();
                        sb.AppendLine("SELECT");
                        sb.AppendLine(" kbn1");
                        sb.AppendLine(",kbn2");
                        sb.AppendLine(",value");
                        sb.AppendLine(",strval");
                        sb.AppendLine(",comment");
                        sb.AppendLine(",ins_user_id");
                        sb.AppendLine(",ins_date");
                        sb.AppendLine(",upd_user_id");
                        sb.AppendLine(",upd_date");
                        sb.AppendLine(",delete_flag");
                        sb.AppendLine("FROM");
                        sb.AppendLine("Mst_区分");
                        sb.AppendLine("ORDER BY");
                        sb.AppendLine("kbn1,kbn2");

                        using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                        {
                            // ProgressBar設定
                            rec_cnt = dt_val.Rows.Count;
                            p_pgb.Visible = true;
                            p_pgb.Maximum = rec_cnt;

                            // MySQL INSERT
                            foreach (DataRow dr in dt_val.Rows)
                            {
                                sb.Clear();
                                sb.AppendLine("INSERT INTO Mst_区分_work (");
                                sb.AppendLine(" kbn1");
                                sb.AppendLine(",kbn2");
                                sb.AppendLine(",value");
                                sb.AppendLine(",strval");
                                sb.AppendLine(",comment");
                                sb.AppendLine(",ins_user_id");
                                sb.AppendLine(",ins_date");
                                sb.AppendLine(",upd_user_id");
                                sb.AppendLine(",upd_date");
                                sb.AppendLine(",delete_flag");
                                sb.AppendLine(") VALUES (");
                                sb.AppendLine(dr["kbn1"].ToString());
                                sb.AppendLine("," + dr["kbn2"].ToString());
                                sb.AppendLine("," + dr["value"].ToString());
                                sb.AppendLine(",'" + dr["strval"].ToString() + "'");
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

                                importCnt++;

                                // ProgressBar値セット
                                p_pgb.Value = importCnt;
                                p_pgb.Refresh();
                            }
                        }
                        // ３．SQL Serverテーブルと作業用テーブルを比較
                        int cnt;
                        sb.Clear();
                        sb.AppendLine("SELECT COUNT(*) AS rec_cnt2 FROM Mst_区分_work");         // MySQL側
                        using (DataTable dt_val = clsMySqlDb.DMLSelect(sb.ToString()))
                        {
                            cnt = int.Parse(dt_val.Rows[0]["rec_cnt2"].ToString());
                        }
                        if (rec_cnt != cnt)
                        {
                            // レコード件数不一致エラー
                            throw new Exception("区分マスターのエクスポートでレコード件数不一致エラーが発生しました。");
                        }
                        // ４．本番テーブルをリネーム
                        // ５．作業用テーブルを本番テーブルにリネーム
                        sb.Clear();
                        sb.AppendLine("RENAME TABLE");
                        sb.AppendLine("Mst_区分 TO Mst_区分_old,");
                        sb.AppendLine("Mst_区分_work TO Mst_区分;");
                        clsMySqlDb.DMLUpdate(sb.ToString());

                        // ６．不要となった旧本番テーブルを削除
                        sb.Clear();
                        sb.AppendLine("DROP TABLE Mst_区分_old;");
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
        /// SQL Serverテーブル値をXServerのmySQLに登録（ProgressBar無し）
        /// マスターメンテからコールされる
        /// </summary>
        public void ExportKbnMstData(ClsSqlDb clsSqlDb, ClsMySqlDb clsMySqlDb)
        {
            int rec_cnt;

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
                sb.AppendLine("CREATE TABLE Mst_区分_work LIKE Mst_区分");
                clsMySqlDb.DMLUpdate(sb.ToString());

                // SQL Server SELECT ALL
                sb.Clear();
                sb.AppendLine("SELECT");
                sb.AppendLine(" kbn1");
                sb.AppendLine(",kbn2");
                sb.AppendLine(",value");
                sb.AppendLine(",strval");
                sb.AppendLine(",comment");
                sb.AppendLine(",ins_user_id");
                sb.AppendLine(",ins_date");
                sb.AppendLine(",upd_user_id");
                sb.AppendLine(",upd_date");
                sb.AppendLine(",delete_flag");
                sb.AppendLine("FROM");
                sb.AppendLine("Mst_区分");
                sb.AppendLine("ORDER BY");
                sb.AppendLine("kbn1,kbn2");

                using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                {
                    rec_cnt = dt_val.Rows.Count;

                    // MySQL INSERT
                    foreach (DataRow dr in dt_val.Rows)
                    {
                        sb.Clear();
                        sb.AppendLine("INSERT INTO Mst_区分_work (");
                        sb.AppendLine(" kbn1");
                        sb.AppendLine(",kbn2");
                        sb.AppendLine(",value");
                        sb.AppendLine(",strval");
                        sb.AppendLine(",comment");
                        sb.AppendLine(",ins_user_id");
                        sb.AppendLine(",ins_date");
                        sb.AppendLine(",upd_user_id");
                        sb.AppendLine(",upd_date");
                        sb.AppendLine(",delete_flag");
                        sb.AppendLine(") VALUES (");
                        sb.AppendLine(dr["kbn1"].ToString());
                        sb.AppendLine("," + dr["kbn2"].ToString());
                        sb.AppendLine("," + dr["value"].ToString());
                        sb.AppendLine(",'" + dr["strval"].ToString() + "'");
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
                // ３．SQL Serverテーブルと作業用テーブルを比較
                int cnt;
                sb.Clear();
                sb.AppendLine("SELECT COUNT(*) AS rec_cnt2 FROM Mst_区分_work");         // MySQL側
                using (DataTable dt_val = clsMySqlDb.DMLSelect(sb.ToString()))
                {
                    cnt = int.Parse(dt_val.Rows[0]["rec_cnt2"].ToString());
                }
                if (rec_cnt != cnt)
                {
                    // レコード件数不一致エラー
                    throw new Exception("区分マスターのエクスポートでレコード件数不一致エラーが発生しました。");
                }
                // ４．本番テーブルをリネーム
                // ５．作業用テーブルを本番テーブルにリネーム
                sb.Clear();
                sb.AppendLine("RENAME TABLE");
                sb.AppendLine("Mst_区分 TO Mst_区分_old,");
                sb.AppendLine("Mst_区分_work TO Mst_区分;");
                clsMySqlDb.DMLUpdate(sb.ToString());

                // ６．不要となった旧本番テーブルを削除
                sb.Clear();
                sb.AppendLine("DROP TABLE Mst_区分_old;");
                clsMySqlDb.DMLUpdate(sb.ToString());
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
        }
    }
}
