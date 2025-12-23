using FlockAppC.pubClass;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FlockAppC.求人関連
{
    public partial class frmPublishList : Form
    {
        private readonly StringBuilder sb = new();

        public frmPublishList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPublishList_Load(object sender, EventArgs e)
        {
            InitializeList();

            DispList();
        }
        /// <summary>
        /// Initialize DataGridView
        /// </summary>
        private void InitializeList()
        {
            DataGridViewTextBoxColumn col01 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col02 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col03 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col04 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col05 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col06 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col07 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col08 = new DataGridViewTextBoxColumn();

            col01.Name = "SenjuName";
            col01.HeaderText = "専従先";
            col01.Width = 350;
            col01.ReadOnly = true;
            col01.Visible = true;
            this.dgvList.Columns.Add(col01);

            col02.Name = "Publish";
            col02.HeaderText = "掲載先" + Environment.NewLine + "応募者";
            col02.Width = 150;
            col02.ReadOnly = true;
            col02.Visible = false;
            this.dgvList.Columns.Add(col02);

            col03.Name = "PublishDate";
            col03.HeaderText = "掲載日" + Environment.NewLine + "応募者";
            col03.Width = 210;
            col03.ReadOnly = true;
            col03.Visible = false;
            this.dgvList.Columns.Add(col03);

            col04.Name = "Vacancy";
            col04.HeaderText = "欠員数" + Environment.NewLine + "応募者";
            col04.Width = 220;
            col04.ReadOnly = true;
            col04.Visible = true;
            this.dgvList.Columns.Add(col04);

            col05.Name = "col5";
            col05.HeaderText = "履歴書有無";
            col05.Width = 150;
            col05.ReadOnly = true;
            col05.Visible = true;
            this.dgvList.Columns.Add(col05);

            col06.Name = "col6";
            col06.HeaderText = "面接予定日";
            col06.Width = 270;
            col06.ReadOnly = true;
            col06.Visible = true;
            this.dgvList.Columns.Add(col06);

            col07.Name = "col7";
            col07.HeaderText = "健康診断";
            col07.Width = 120;
            col07.ReadOnly = true;
            col07.Visible = true;
            this.dgvList.Columns.Add(col07);

            col08.Name = "col8";
            col08.HeaderText = "入社予定日";
            col08.Width = 300;
            col08.ReadOnly = true;
            col08.Visible = true;
            this.dgvList.Columns.Add(col08);

            //並び替えができないようにする
            foreach (DataGridViewColumn c in this.dgvList.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;


            // 行ヘッダー
            this.dgvList.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 16);
            this.dgvList.EnableHeadersVisualStyles = false;                                                          // Windows Color無効
            this.dgvList.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.CornflowerBlue;              // 列ヘッダ色
            // this.dgvList.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.MediumSeaGreen;              // 列ヘッダ色
            this.dgvList.RowTemplate.Height = 30;                                                                    // 行高さ
            this.dgvList.AllowUserToResizeColumns = false;                                                           // 列幅の変更不可
            this.dgvList.AllowUserToResizeRows = false;                                                              // 行高さの変更不可
            // this.dgvList.ColumnHeadersVisible = true;                                                             // 列ヘッダ非表示
            this.dgvList.MultiSelect = false;                                                                        // 複数選択不可
            this.dgvList.ReadOnly = true;                                                                            // 表示専用
            this.dgvList.AllowUserToAddRows = false;                                                                 // 行自動追加不可
            this.dgvList.RowHeadersVisible = false;                                                                  // 行ヘッダ非表示

            this.dgvList.Columns["SenjuName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;      // セルの文字表示位置
            this.dgvList.Columns["Publish"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;        // セルの文字表示位置
            this.dgvList.Columns["PublishDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    // セルの文字表示位置
            this.dgvList.Columns["Vacancy"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;        // セルの文字表示位置
            this.dgvList.Columns["col5"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;           // セルの文字表示位置
            this.dgvList.Columns["col6"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;           // セルの文字表示位置
            this.dgvList.Columns["col7"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;           // セルの文字表示位置
            this.dgvList.Columns["col8"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;           // セルの文字表示位置

            this.dgvList.Columns["SenjuName"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 16);           // フォント設定
            this.dgvList.Columns["Publish"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 16);             // フォント設定
            this.dgvList.Columns["PublishDate"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 16);         // フォント設定
            this.dgvList.Columns["Vacancy"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 16);             // フォント設定
            this.dgvList.Columns["col5"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 16);                // フォント設定
            this.dgvList.Columns["col6"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 16);                // フォント設定
            this.dgvList.Columns["col7"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 16);                // フォント設定
            this.dgvList.Columns["col8"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 16);                // フォント設定
            this.dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;                                          //行選択時は１行全て選択状態にする

        }
        /// <summary>
        ///  応募状況表示
        /// </summary>
        private void DispList()
        {
            int row = -1;
            string strSenjuName = "";
            string strSenjuComment = "";
            string strApplyName = "";
            string strApplyName2 = "";
            DateTime datPublishDate = DateTime.Parse("1900/01/01");

            try
            {
                dgvList.Rows.Clear();

                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" Trn_求人掲載.location_name AS SenjuName");
                    sb.AppendLine(",Trn_求人掲載.location_comment AS SenjuComment");
                    sb.AppendLine(",Trn_求人掲載.publish");
                    sb.AppendLine(",Trn_求人掲載.publish_date");
                    sb.AppendLine(",Trn_求人掲載.vacancy");
                    sb.AppendLine(",Trn_求人応募者.apply_name");
                    sb.AppendLine(",Trn_求人応募者.rireki_flag");
                    sb.AppendLine(",Trn_求人応募者.interview_date");
                    sb.AppendLine(",Trn_求人応募者.kensin_flag");
                    sb.AppendLine(",Trn_求人応募者.in_company_schedule_date");
                    sb.AppendLine(",Trn_求人応募者.interview_date_flag");
                    sb.AppendLine(",Trn_求人応募者.in_company_schedule_date_flag");
                    sb.AppendLine("FROM");
                    sb.AppendLine(" Trn_求人掲載");
                    sb.AppendLine(" LEFT JOIN");
                    sb.AppendLine(" Trn_求人応募者");
                    sb.AppendLine(" ON");
                    sb.AppendLine(" Trn_求人掲載.id = Trn_求人応募者.header_id");
                    sb.AppendLine(" WHERE");
                    sb.AppendLine(" Trn_求人掲載.publish_flag <> 1");
                    sb.AppendLine(" ORDER BY");
                    sb.AppendLine(" SenjuName");
                    sb.AppendLine(",SenjuComment");
                    sb.AppendLine(",Trn_求人掲載.publish_date");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            if (dr["apply_name"].ToString() == "") { strApplyName = ""; }
                            else { strApplyName = dr["apply_name"].ToString(); }

                            if (strSenjuName == dr["SenjuName"].ToString() &&
                                strSenjuComment == dr["SenjuComment"].ToString() &&
                                strApplyName == strApplyName2 &&
                                datPublishDate == DateTime.Parse(dr["publish_date"].ToString()))
                            {
                                continue;
                            }

                            if (strSenjuName != dr["SenjuName"].ToString() || strSenjuComment != dr["SenjuComment"].ToString())
                            {
                                dgvList.Rows.Add();
                                row++;

                                dgvList[0, row].Style.Font = new System.Drawing.Font("游ゴシック", 16, FontStyle.Bold);
                                dgvList[1, row].Style.Font = new System.Drawing.Font("游ゴシック", 16, FontStyle.Bold);
                                dgvList[2, row].Style.Font = new System.Drawing.Font("游ゴシック", 16, FontStyle.Bold);
                                dgvList[3, row].Style.Font = new System.Drawing.Font("游ゴシック", 16, FontStyle.Bold);

                                if (dr["SenjuComment"].ToString() != "")
                                {
                                    dgvList.Rows[row].Cells["SenjuName"].Value = dr["SenjuName"] + " (" + dr["SenjuComment"] + ")";
                                }
                                else
                                {
                                    dgvList.Rows[row].Cells["SenjuName"].Value = dr["SenjuName"];
                                }

                                dgvList.Rows[row].Cells["Vacancy"].Value = dr["vacancy"];
                                dgvList.Rows[row].DefaultCellStyle.BackColor = Color.Wheat;
                                // dgvList.Rows[row].DefaultCellStyle.BackColor = Color.PowderBlue;
                            }

                            if (dr["apply_name"].ToString() != "")
                            {
                                dgvList.Rows.Add();
                                row++;

                                dgvList.Rows[row].Cells["Vacancy"].Value = dr["apply_name"].ToString();

                                switch (int.Parse(dr["rireki_flag"].ToString()))
                                {
                                    case 0:
                                        dgvList.Rows[row].Cells["col5"].Value = "履歴書無し";
                                        break;
                                    case 1:
                                        dgvList.Rows[row].Cells["col5"].Value = "履歴書有り";
                                        break;
                                    default:
                                        dgvList.Rows[row].Cells["col5"].Value = "";
                                        break;
                                }

                                if (DateTime.Parse(dr["interview_date"].ToString()).ToString("yyyy/MM/dd") == "1900/01/01")
                                {
                                    dgvList.Rows[row].Cells["col6"].Value = "面接日 未定";
                                }
                                else
                                {
                                    dgvList.Rows[row].Cells["col6"].Value = "面接日 " + DateTime.Parse(dr["interview_date"].ToString()).ToString("yyyy/MM/dd");
                                }

                                switch (int.Parse(dr["kensin_flag"].ToString()))
                                {
                                    case 0:
                                        dgvList.Rows[row].Cells["col7"].Value = "健診未";
                                        break;
                                    case 1:
                                        dgvList.Rows[row].Cells["col7"].Value = "健診済";
                                        break;
                                    default:
                                        dgvList.Rows[row].Cells["col7"].Value = "";
                                        break;
                                }

                                if (DateTime.Parse(dr["in_company_schedule_date"].ToString()).ToString("yyyy/MM/dd") == "1900/01/01")
                                {
                                    dgvList.Rows[row].Cells["col8"].Value = "入社予定 未定";
                                }
                                else
                                {
                                    dgvList.Rows[row].Cells["col8"].Value = "入社予定 " + DateTime.Parse(dr["in_company_schedule_date"].ToString()).ToString("yyyy/MM/dd");
                                }

                                dgvList.Rows[row].DefaultCellStyle.BackColor = Color.LightGreen;
                                dgvList.Rows[row].Cells["SenjuName"].Style.BackColor = Color.Wheat;
                                //dgvList.Rows[row].DefaultCellStyle.BackColor = Color.DodgerBlue;
                                //dgvList.Rows[row].Cells["SenjuName"].Style.BackColor = Color.PowderBlue;
                            }

                            strSenjuName = dr["SenjuName"].ToString();
                            strSenjuComment = dr["SenjuComment"].ToString();
                            datPublishDate = DateTime.Parse(dr["publish_date"].ToString());
                            if (dr["apply_name"].ToString() == "") { strApplyName2 = ""; }
                            else { strApplyName2 = dr["apply_name"].ToString(); }
                        }
                    }
                    dgvList.ClearSelection();
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
