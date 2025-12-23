using FlockAppC.pubClass;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FlockAppC.選択画面
{
    public partial class frmSelectItem : Form
    {
        public int Kbn { get; set; }
        public int Value { get; set; }
        public string StrVal { get; set; }
        public string StrKey { get; set; }              // あいまい検索キー（従業員選択で使用）
        public int IntKey {  get; set; }

        private readonly StringBuilder sb = new();

        public frmSelectItem()
        {
            InitializeComponent();
        }

        private void frmSelectEmployment_Load(object sender, EventArgs e)
        {
            // Initialize
            Value = 0;
            StrVal = "";

            // Initialize DataGridView
            this.dgvList.Columns.Clear();
            SetDgvList();

            // 一覧表示
            if (Kbn == 1)
            {
                // 雇用形態
                this.Text = "雇用形態選択";
                DisplayEmploymentList();
            }
            else if(Kbn == 2)
            {
                // 所属
                this.Text = "所属選択";
                DisplayOfficeList();
            }
            else if (Kbn == 3)
            {
                // 部門
                this.Text = "部門選択";
                DisplayGroupList();
            }
            else if (Kbn == 4)
            {
                // 掲載先（求人）
                this.Text = "掲載先選択";
                DisplayPublishList();
            }
            else if (Kbn == 5)
            {
                // 従業員
                this.Text = "従業員選択";
                DisplayStaffList();
            }
            else if (Kbn == 6)
            {
                // 専従先車両
                this.Text = "専従先車両選択";
                DisplayLocationCarList();
            }
            else if (Kbn == 7)
            {
                // 専従先専従者
                this.Text = "専従先専従者選択";
                DisplayLocationStaffList();
            }
            else if (Kbn == 8)
            {
                // 始業・終業場所
                this.Text = "始業・終業場所選択";
                DisplayStartEndLocationList();
            }
            else if (Kbn == 9)
            {
                // 備考区分
                this.Text = "備考区分選択";
                DisplayCommentKbnList();
            }

            this.Location = new Point(0, 0);

        }
        /// <summary>
        /// DataGridView設定
        /// </summary>
        private void SetDgvList()
        {
            DataGridViewTextBoxColumn col01 = new();
            DataGridViewTextBoxColumn col02 = new();

            col01.Name = "value";
            col01.HeaderText = "value";
            col01.Width = 1;
            col01.Visible = false;

            col02.Name = "strval";

            switch(Kbn)
            {
                case 1:
                    col02.HeaderText = "雇用形態";
                    break;
                case 2:
                    col02.HeaderText = "所属";
                    break;
                case 3:
                    col02.HeaderText = "部門";
                    break;
                case 4:
                    col02.HeaderText = "掲載先";
                    break;
                case 6:
                    col02.HeaderText = "専従先車両";
                    break;
                case 7:
                    col02.HeaderText = "専従先専従者";
                    break;
            }
            col02.Width = 200;
            col02.Visible = true;

            this.dgvList.Columns.Add(col01);
            this.dgvList.Columns.Add(col02);

            //並び替えができないようにする
            foreach (DataGridViewColumn c in this.dgvList.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            this.dgvList.EnableHeadersVisualStyles = false;                                                          // Windows Color無効
            // this.dgvList.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.CornflowerBlue;              // 列ヘッダ色
            this.dgvList.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.PowderBlue;                  // 列ヘッダ色
            this.dgvList.RowTemplate.Height = 25;                                                                    // 行高さ
            this.dgvList.AllowUserToResizeColumns = false;                                                           // 列幅の変更不可
            this.dgvList.AllowUserToResizeRows = false;                                                              // 行高さの変更不可
            this.dgvList.ColumnHeadersVisible = true;                                                                // 列ヘッダ非表示
            this.dgvList.Columns["StrVal"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;   // 列ヘッダ文字位置


            //奇数行を黄色にする
            this.dgvList.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Moccasin;

            this.dgvList.Columns["value"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;                  //セルの文字表示位置
            this.dgvList.Columns["strval"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;                  //セルの文字表示位置

            this.dgvList.Columns["value"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);       //フォント設定
            this.dgvList.Columns["strval"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);       //フォント設定

            this.dgvList.MultiSelect = false;                                                                         //複数選択
            this.dgvList.ReadOnly = true;                                                                             //読込専用
            this.dgvList.AllowUserToAddRows = false;                                                                  //行追加無効
            this.dgvList.RowHeadersVisible = false;                                                                   //行ヘッダ非表示
            this.dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;                                     //行選択時は１行全て選択状態にする
        }
        /// <summary>
        /// 雇用条件一覧表示
        /// </summary>
        private void DisplayEmploymentList()
        {
            try
            {
                var i = 0;
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("Mst_区分.value");
                    sb.AppendLine(",Mst_区分.strval");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_区分");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("Mst_区分.kbn1 = 101");
                    // sb.AppendLine("AND");
                    // sb.AppendLine("Mst_区分.Kbn2 = 1");
                    sb.AppendLine("ORDER BY");
                    sb.AppendLine("value");

                    // 処理改善 2025/09/02
                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            this.dgvList.Rows.Add();
                            this.dgvList.Rows[i].Cells["value"].Value = dr["value"].ToString();
                            this.dgvList.Rows[i].Cells["strval"].Value = dr["strval"].ToString();
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
        /// 部門一覧表示
        /// </summary>
        private void DisplayGroupList()
        {
            try
            {
                var i = 0;

                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" Mst_部門.name");
                    sb.AppendLine(",Mst_部門.id");
                    sb.AppendLine("FROM");
                    sb.AppendLine(" Mst_部門");
                    sb.AppendLine("WHERE");
                    sb.AppendLine(" Mst_部門.id < 10");
                    sb.AppendLine("ORDER BY");
                    sb.AppendLine(" id");

                    // 処理改善 2025/09/02
                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            this.dgvList.Rows.Add();
                            this.dgvList.Rows[i].Cells["value"].Value = dr["id"].ToString();
                            this.dgvList.Rows[i].Cells["strval"].Value = dr["name"].ToString();
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
        /// 所属一覧表示
        /// </summary>
        private void DisplayOfficeList()
        {
            try
            {
                var i = 0;

                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" Mst_所属.name");
                    sb.AppendLine(",Mst_所属.id");
                    sb.AppendLine("FROM");
                    sb.AppendLine(" Mst_所属");
                    sb.AppendLine("ORDER BY");
                    sb.AppendLine(" id");

                    // 処理改善 2025/09/02
                    using(DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            this.dgvList.Rows.Add();
                            this.dgvList.Rows[i].Cells["value"].Value = dr["id"].ToString();
                            this.dgvList.Rows[i].Cells["strval"].Value = dr["name"].ToString();
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
        /// 求人掲載先一覧表示
        /// </summary>
        private void DisplayPublishList()
        {
            try
            {
                var i = 0;

                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("Mst_区分.value");
                    sb.AppendLine(",Mst_区分.strval");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_区分");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("Mst_区分.kbn1 = 301");
                    sb.AppendLine("AND");
                    sb.AppendLine("Mst_区分.kbn2 = 1");
                    sb.AppendLine("ORDER BY");
                    sb.AppendLine("value");

                    // 処理改善 2025/09/02
                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            this.dgvList.Rows.Add();
                            this.dgvList.Rows[i].Cells["value"].Value = dr["value"].ToString();
                            this.dgvList.Rows[i].Cells["strval"].Value = dr["strval"].ToString();
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
        /// 従業員一覧表示
        /// </summary>
        private void DisplayStaffList()
        {
            try
            {
                var i = 0;

                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" Mst_社員.staff_id");
                    sb.AppendLine(",Mst_社員.fullname");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_社員");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("Mst_社員.fullname Like '%" + StrKey + "%'");
                    sb.AppendLine("ORDER BY");
                    sb.AppendLine("kana1");

                    // 処理改善 2025/09/02
                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            this.dgvList.Rows.Add();
                            this.dgvList.Rows[i].Cells["value"].Value = dr["staff_id"].ToString();
                            this.dgvList.Rows[i].Cells["strval"].Value = dr["fullname"].ToString();
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
        /// 専従先車両
        /// </summary>
        private void DisplayLocationCarList()
        {
            try
            {
                var i = 0;

                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("Mst_専従先車両.no");
                    sb.AppendLine(",Mst_専従先車両.fullname");
                    sb.AppendLine(",Mst_専従先車両.id");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_専従先車両");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("Mst_専従先車両.location_id = " + this.IntKey);
                    sb.AppendLine("ORDER BY");
                    sb.AppendLine("id");

                    // 処理改善 2025/09/02
                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            this.dgvList.Rows.Add();
                            this.dgvList.Rows[i].Cells["value"].Value = dr["id"].ToString();
                            this.dgvList.Rows[i].Cells["strval"].Value = dr["no"].ToString() + " : " + dr["fullname"].ToString();
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
        /// 専従先専従者
        /// </summary>
        private void DisplayLocationStaffList()
        {
            try
            {
                var i = 0;

                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" Mst_専従先専従者.staff_id");
                    sb.AppendLine(",Mst_社員.fullname");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_専従先専従者");
                    sb.AppendLine("LEFT JOIN");
                    sb.AppendLine("Mst_社員");
                    sb.AppendLine("ON");
                    sb.AppendLine("Mst_専従先専従者.staff_id = Mst_社員.staff_id");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("Mst_専従先専従者.location_id = " + this.IntKey);
                    sb.AppendLine("ORDER BY");
                    sb.AppendLine("Mst_専従先専従者.staff_id");

                    // 処理改善 2025/09/02
                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            this.dgvList.Rows.Add();
                            this.dgvList.Rows[i].Cells["value"].Value = dr["staff_id"].ToString();
                            this.dgvList.Rows[i].Cells["strval"].Value = dr["fullname"].ToString();
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
        /// 始業・終業場所一覧表示
        /// </summary>
        private void DisplayStartEndLocationList()
        {
            try
            {
                var i = 0;

                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("Mst_区分.value");
                    sb.AppendLine(",Mst_区分.strval");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_区分");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("Mst_区分.kbn1 = 701");
                    sb.AppendLine("ORDER BY");
                    sb.AppendLine("value");

                    // 処理改善 2025/09/02
                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            this.dgvList.Rows.Add();
                            this.dgvList.Rows[i].Cells["value"].Value = dr["value"].ToString();
                            this.dgvList.Rows[i].Cells["strval"].Value = dr["strval"].ToString();
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
        /// 備考区分一覧表示
        /// </summary>
        private void DisplayCommentKbnList()
        {
            try
            {
                var i = 0;

                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("Mst_区分.value");
                    sb.AppendLine(",Mst_区分.strval");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_区分");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("Mst_区分.kbn1 = 702");
                    sb.AppendLine("ORDER BY");
                    sb.AppendLine("value");

                    // 処理改善 20256/09/02
                    using(DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            this.dgvList.Rows.Add();
                            this.dgvList.Rows[i].Cells["value"].Value = dr["value"].ToString();
                            this.dgvList.Rows[i].Cells["strval"].Value = dr["strval"].ToString();
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
        /// 決定ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (this.dgvList.SelectedRows.Count < 1) { return; }

            DataGridViewRow selectedRow = dgvList.SelectedRows[0];
            Value = int.Parse(selectedRow.Cells[0].Value.ToString());
            StrVal = selectedRow.Cells[1].Value.ToString();

            this.Close();

        }
        /// <summary>
        /// 一覧ダブルクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //クリックされたセルのClassificationID取得
            Value = int.Parse(this.dgvList.Rows[e.RowIndex].Cells[0].Value.ToString());
            StrVal = this.dgvList.Rows[e.RowIndex].Cells[1].Value.ToString();

            this.Close();
        }   
        /// <summary>
        /// 閉じるボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 戻るボタン（未使用）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Key Down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvList_KeyDown(object sender, KeyEventArgs e)
        {
            // エンターキーが押されたかどうかを確認
            if (e.KeyCode == Keys.Enter)
            {
                // 選択されているセルの行番号を取得
                int rowIndex = dgvList.CurrentCell.RowIndex;

                // 行番号を表示（デバッグ用）
                // MessageBox.Show($"エンターキーが押された行の番号: {rowIndex}");

                // エンターキーのデフォルト動作を無効化
                e.Handled = true;

                Value = int.Parse(this.dgvList.Rows[rowIndex].Cells[0].Value.ToString());
                StrVal = this.dgvList.Rows[rowIndex].Cells[1].Value.ToString();

                this.Close();

            }
        }
    }
}
