using FlockAppC.pubClass;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FlockAppC.選択画面
{
    public partial class frmSelectCar : Form
    {
        public int Id { get; set; }
        public string CarNo { get; set; }
        public string CarName { get; set; }
        public string RegNo { get; set; }
        public int UsedUserId { get; set; }
        public string UserName { get; set; }

        private readonly StringBuilder sb = new();

        public frmSelectCar()
        {
            InitializeComponent();
        }

        private void frmSelectCar_Load(object sender, EventArgs e)
        {
            // Initialize
            Id = 0;
            CarNo = "";
            CarName = "";
            RegNo = "";
            UsedUserId = 0;
            UserName = "";

            // Initialize DataGridView
            this.dgvList.Columns.Clear();
            SetDgvList();

            // 一覧表示
            DisplayCarList();

            this.Location = new Point(0, 0);
        }
        /// <summary>
        /// DataGridView設定
        /// </summary>
        private void SetDgvList()
        {
            DataGridViewTextBoxColumn col01 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col02 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col03 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col04 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col05 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col06 = new DataGridViewTextBoxColumn();

            col01.Name = "id";
            col01.HeaderText = "id";
            col01.Width = 1;
            col01.Visible = false;

            col02.Name = "no";
            col02.HeaderText = "№";
            col02.Width = 60;
            col02.Visible = true;

            col03.Name = "name";
            col03.HeaderText = "名称";
            col03.Width = 120;
            col03.Visible = true;

            col04.Name = "number";
            col04.HeaderText = "ナンバー";
            col04.Width = 120;
            col04.Visible = true;

            col05.Name = "user";
            col05.HeaderText = "使用者ID";
            col05.Width = 1;
            col05.Visible = false;

            col06.Name = "username";
            col06.HeaderText = "使用者";
            col06.Width = 120;
            col06.Visible = true;

            this.dgvList.Columns.Add(col01);
            this.dgvList.Columns.Add(col02);
            this.dgvList.Columns.Add(col03);
            this.dgvList.Columns.Add(col04);
            this.dgvList.Columns.Add(col05);
            this.dgvList.Columns.Add(col06);

            //並び替えができないようにする
            foreach (DataGridViewColumn c in this.dgvList.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            this.dgvList.EnableHeadersVisualStyles = false;                                                          //Windows Color無効
            this.dgvList.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.CornflowerBlue;              //列ヘッダ色
            this.dgvList.RowTemplate.Height = 25;                                                                    //行高さ
            this.dgvList.AllowUserToResizeColumns = false;                                                           //列幅の変更不可
            this.dgvList.AllowUserToResizeRows = false;                                                              //行高さの変更不可
            this.dgvList.ColumnHeadersVisible = true;                                                                //列ヘッダ非表示
            this.dgvList.Columns["id"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;       // 列ヘッダ文字位置
            this.dgvList.Columns["no"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;       // 列ヘッダ文字位置
            this.dgvList.Columns["name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 列ヘッダ文字位置
            this.dgvList.Columns["number"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;   // 列ヘッダ文字位置
            this.dgvList.Columns["username"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; // 列ヘッダ文字位置

            //奇数行を黄色にする
            this.dgvList.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Moccasin;

            this.dgvList.Columns["id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;                  //セルの文字表示位置
            this.dgvList.Columns["no"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;                  //セルの文字表示位置
            this.dgvList.Columns["name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;                //セルの文字表示位置
            this.dgvList.Columns["number"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;              //セルの文字表示位置
            // this.dgvList.Columns["user"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;                //セルの文字表示位置
            this.dgvList.Columns["username"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;            //セルの文字表示位置

            this.dgvList.Columns["id"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);       //フォント設定
            this.dgvList.Columns["no"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);       //フォント設定
            this.dgvList.Columns["name"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);     //フォント設定
            this.dgvList.Columns["number"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);   //フォント設定
            // this.dgvList.Columns["user"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);     //フォント設定
            this.dgvList.Columns["username"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular); //フォント設定

            //this.dgvList.Columns["id"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Bold);       //フォント設定
            //this.dgvList.Columns["no"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Bold);       //フォント設定
            //this.dgvList.Columns["name"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Bold);     //フォント設定
            //this.dgvList.Columns["number"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Bold);   //フォント設定
            //// this.dgvList.Columns["user"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Bold);     //フォント設定
            //this.dgvList.Columns["username"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Bold); //フォント設定

            //this.dgvSelect1.ScrollBars = false;                                                                        //スクロールバー非表示
            this.dgvList.MultiSelect = false;                                                                         //複数選択
            this.dgvList.ReadOnly = true;                                                                             //読込専用
            this.dgvList.AllowUserToAddRows = false;                                                                  //行追加無効
            this.dgvList.RowHeadersVisible = false;                                                                   //行ヘッダ非表示
            this.dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;                                     //行選択時は１行全て選択状態にする
        }
        /// <summary>
        /// 社用車一覧表示
        /// </summary>
        private void DisplayCarList()
        {
            try
            {
                sb.Clear();
                sb.AppendLine("SELECT");
                sb.AppendLine("Mst_社用車.id");
                sb.AppendLine(",Mst_社用車.car_no");
                sb.AppendLine(",Mst_社用車.car_name");
                sb.AppendLine(",Mst_社用車.reg_no");
                sb.AppendLine(",Mst_社用車.used_user_id");
                sb.AppendLine(",Mst_社員.name1");
                sb.AppendLine("FROM");
                sb.AppendLine(" Mst_社用車");
                sb.AppendLine("LEFT JOIN");
                sb.AppendLine(" Mst_社員");
                sb.AppendLine("ON");
                sb.AppendLine(" Mst_社用車.used_user_id = Mst_社員.staff_id");
                sb.AppendLine("ORDER BY");
                sb.AppendLine(" car_no");

                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    // 処置改善 2025/09/02
                    using(DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        var i = 0;
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            this.dgvList.Rows.Add();
                            this.dgvList.Rows[i].Cells["id"].Value = dr["id"].ToString();
                            this.dgvList.Rows[i].Cells["no"].Value = dr["car_no"].ToString();
                            this.dgvList.Rows[i].Cells["name"].Value = dr["car_name"].ToString();
                            this.dgvList.Rows[i].Cells["number"].Value = dr["reg_no"].ToString();
                            this.dgvList.Rows[i].Cells["user"].Value = dr["used_user_id"].ToString();
                            this.dgvList.Rows[i].Cells["username"].Value = dr["name1"].ToString();
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
        /// 決定ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (this.dgvList.SelectedRows.Count < 1) { return; }

            DataGridViewRow selectedRow = dgvList.SelectedRows[0];
            Id  = int.Parse(selectedRow.Cells[0].Value.ToString());
            CarNo = selectedRow.Cells[1].Value.ToString();
            CarName = selectedRow.Cells[2].Value.ToString();
            RegNo = selectedRow.Cells[3].Value.ToString();
            UsedUserId = int.Parse(selectedRow.Cells[4].Value.ToString());

            this.Close();
        }
        /// <summary>
        /// ダブルクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //クリックされたセルのClassificationID取得
            Id = int.Parse(this.dgvList.Rows[e.RowIndex].Cells[0].Value.ToString());
            CarNo = this.dgvList.Rows[e.RowIndex].Cells[1].Value.ToString();
            CarName = this.dgvList.Rows[e.RowIndex].Cells[2].Value.ToString();
            RegNo = this.dgvList.Rows[e.RowIndex].Cells[3].Value.ToString();
            UsedUserId = int.Parse(this.dgvList.Rows[e.RowIndex].Cells[4].Value.ToString());

            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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

                //クリックされたセルのClassificationID取得
                Id = int.Parse(this.dgvList.Rows[rowIndex].Cells[0].Value.ToString());
                CarNo = this.dgvList.Rows[rowIndex].Cells[1].Value.ToString();
                CarName = this.dgvList.Rows[rowIndex].Cells[2].Value.ToString();
                RegNo = this.dgvList.Rows[rowIndex].Cells[3].Value.ToString();
                UsedUserId = int.Parse(this.dgvList.Rows[rowIndex].Cells[4].Value.ToString());

                this.Close();
            }

        }
    }
}
