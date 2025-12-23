using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FlockAppC.pubClass
{
    public class ClsControll
    {
        private readonly StringBuilder sb = new();
        private readonly DataTable dt = new();
        DataRow dr;

        /// <summary>
        /// ===================================================================
        /// 担当者コンボボックスをセット : Sort
        /// 　[ID],[Name1]
        /// ===================================================================
        /// </summary>
        /// <param name="combo"></param>
        public void SetTantoCmb(ComboBox combo)
        {
            try
            {
                using(ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    dt.Columns.Add("Code");
                    dt.Columns.Add("Name");

                    // SQL編集
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" staff_id");
                    sb.AppendLine(",id");
                    sb.AppendLine(",name1");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_社員");
                    sb.AppendLine("WHERE");
                    // 部門（暫定処理：追々はSELECTして編集する形にする）
                    // 1:営業/2:総務/3:代務/9:役員/10:ゲスト
                    sb.AppendLine("group_id IN(" + ClsPublic.SALES + "," + ClsPublic.AFFAIRS + "," + ClsPublic.PROXY + "," + ClsPublic.OFFICER + "," + ClsPublic.GUEST );
                    // sb.AppendLine("group_id IN(1,2,3,9,10)");
                    sb.AppendLine("AND");
                    // 所属（暫定処理：追々はSELECTして編集する形にする）
                    sb.AppendLine("office_id IN(" + ClsPublic.OFFICE_HONSHA + "," + ClsPublic.OFFICE_SAITAMA + "," + ClsPublic.OFFICE_YOKOHAMA +")");
                    sb.AppendLine("AND");
                    sb.AppendLine("zai_flag = " + ClsPublic.FLAG_ON);
                    // sb.AppendLine("zai_flag = 1");
                    sb.AppendLine("ORDER BY");
                    // 並び順：「Sort」
                    sb.AppendLine("sort");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        // 最初の空行
                        dr = dt.NewRow();
                        dr["Code"] = "0";
                        dr["Name"] = "";
                        dt.Rows.Add(dr);

                        // 結果を読み込みデータテーブルへセット
                        foreach (DataRow drow in dt_val.Rows)
                        {
                            dr = dt.NewRow();
                            dr["Name"] = drow["name1"];
                            dr["Code"] = drow["staff_id"];
                            dt.Rows.Add(dr);
                        }
                    }
                }
                // コンボボックスにデータテーブルセット
                combo.DataSource = dt;
                combo.DisplayMember = "Name";
                combo.ValueMember = "Code";
            }
            catch (Exception ex)
			{
                // エラー
                ClsLogger.Log(ex.ToString());
                Console.WriteLine(ex.Message);
                throw;
			}
        }

        /// <summary>
        /// ===================================================================
        /// 担当者コンボボックスをセット（ケース２）: TantoSort
        /// 　在籍者全てが対象
        /// 　[ID],[FullName]
        /// ===================================================================
        /// </summary>
        /// <param name="combo"></param>
        public void SetTantoCmb2(ComboBox combo)
        {
            try
            {
                using(ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    dt.Columns.Add("Code");
                    dt.Columns.Add("Name");

                    // SQL編集
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" staff_id");
                    sb.AppendLine(",fullname");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_社員");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("zai_flag = " + ClsPublic.FLAG_ON);
                    // sb.AppendLine("zai_flag = 1");
                    sb.AppendLine("ORDER BY");
                    // 並び順：「TantoSort」
                    sb.AppendLine("tanto_sort");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        // 最初の空行
                        dr = dt.NewRow();
                        dr["Code"] = "0";
                        dr["Name"] = "";
                        dt.Rows.Add(dr);

                        // 結果を読み込みデータテーブルへセット
                        foreach (DataRow drow in dt_val.Rows)
                        {
                            dr = dt.NewRow();
                            dr["Name"] = drow["fullname"];
                            dr["Code"] = drow["staff_id"];
                            dt.Rows.Add(dr);
                        }
                    }
                }
                // コンボボックスにデータテーブルセット
                combo.DataSource = dt;
                combo.DisplayMember = "Name";
                combo.ValueMember = "Code";
            }
            catch (Exception ex)
            {
                // エラー
                Console.WriteLine(ex.Message);
                ClsLogger.Log(ex.ToString());
                throw;
            }
        }

        /// <summary>
        /// ===================================================================
        /// 担当者コンボボックスをセット（ケース３）: Sort
        /// 　パラメータで条件指定
        /// 　[ID],[FullName]
        /// ===================================================================
        /// </summary>
        /// <param name="combo"></param>
        /// <param name="sWhere"></param>
        public void SetTantoCmb3(ComboBox combo, string sWhere)
        {
            try
            {
                using(ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    dt.Columns.Add("Code");
                    dt.Columns.Add("Name");

                    // SQL編集
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" staff_id");
                    sb.AppendLine(",name1");
                    sb.AppendLine(",fullName");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_社員");
                    sb.AppendLine("WHERE");
                    sb.AppendLine(sWhere);
                    sb.AppendLine("ORDER BY");
                    sb.AppendLine("sort");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        // 最初の空行
                        dr = dt.NewRow();
                        dr["Code"] = "0";
                        dr["Name"] = "";
                        dt.Rows.Add(dr);

                        // 結果を読み込みデータテーブルへセット
                        foreach (DataRow drow in dt_val.Rows)
                        {
                            dr = dt.NewRow();
                            dr["Name"] = drow["fullname"];
                            dr["Code"] = drow["staff_id"];
                            dt.Rows.Add(dr);
                        }
                    }
                }
                // コンボボックスにデータテーブルセット
                combo.DataSource = dt;
                combo.DisplayMember = "Name";
                combo.ValueMember = "Code";
            }
            catch (Exception ex)
            {
                // エラー
                ClsLogger.Log(ex.ToString());
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// ===================================================================
        /// 担当者コンボボックスをセット（ケース４）    【SQL Server】
        /// 　ログイン画面等からコール
        /// 　条件指定
        /// 　並べ替え指定
        /// 　担当者ID指定（選択状態にする）
        /// 　[ID],[Name1]
        /// ===================================================================
        /// </summary>
        /// <param name="combo"></param>
        /// <param name="p_tantoid"></param>
        /// <param name="p_where"></param>
        /// <param name="p_sort"></param>
        public void SetTantoCmb4(ComboBox combo, int p_tantoid, string p_where, string p_sort)
        {
            int row = 0;
            int selected_row = 0;

            try
            {
                // SQL Server接続（コンストラクター、接続）
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    dt.Columns.Add("StaffID");
                    dt.Columns.Add("Name");

                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" staff_id");
                    sb.AppendLine(",name1");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_社員");
                    sb.AppendLine("WHERE");
                    sb.AppendLine(p_where);
                    sb.AppendLine("ORDER BY");
                    sb.AppendLine(p_sort);

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        // 最初の空行
                        dr = dt.NewRow();
                        dr["StaffID"] = "";
                        dr["Name"] = "";
                        dt.Rows.Add(dr);

                        foreach (DataRow drow in dt_val.Rows)
                        {
                            dr = dt.NewRow();
                            dr["StaffID"] = drow["staff_id"];
                            dr["Name"] = drow["name1"];
                            dt.Rows.Add(dr);

                            // ログインユーザーID判定
                            if (p_tantoid == int.Parse(dr["StaffID"].ToString()))
                            {
                                selected_row = row + 1;
                            }
                            row++;
                        }
                    }
                }

                combo.DataSource = dt;
                combo.DisplayMember = "Name";
                combo.ValueMember = "StaffID";
                combo.SelectedIndex = selected_row;
            }
            catch (Exception ex)
            {
                // エラー
                ClsLogger.Log(ex.ToString());
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// ===================================================================
        /// 区分コンボボックスをセット
        /// 　区分１を指定
        /// ===================================================================
        /// </summary>
        /// <param name="combo"></param>
        /// <param name="p_kbn1"></param>
        public void SetKbnCmb(ComboBox combo, int p_kbn1)
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    dt.Columns.Add("Code");
                    dt.Columns.Add("Name");

                    // SQL編集
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" kbn2");
                    sb.AppendLine(",value");
                    sb.AppendLine(",strval");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_区分");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("kbn1 = " + p_kbn1);
                    sb.AppendLine("ORDER BY");
                    sb.AppendLine("kbn2");

                    // 区分データ取得
                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        // 最初の空行
                        //dr = dt.NewRow();
                        //dr["Code"] = "0";
                        //dr["Name"] = "";
                        //dt.Rows.Add(dr);

                        // 結果を読み込みデータテーブルへセット
                        foreach (DataRow drow in dt_val.Rows)
                        {
                            dr = dt.NewRow();
                            dr["Name"] = drow["strval"];
                            dr["Code"] = drow["value"];
                            dt.Rows.Add(dr);
                        }
                    }
                }

                // コンボボックスにデータテーブルセット
                combo.DataSource = dt;
                combo.DisplayMember = "Name";
                combo.ValueMember = "Code";
            }
            catch (Exception ex)
            {
                // エラー
                ClsLogger.Log(ex.ToString());
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
