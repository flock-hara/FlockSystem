using FlockAppC.pubClass;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FlockAppC.マスターメンテ
{
    public partial class frmMstProcess : Form
    {
        private int Id {  get; set; }

        private readonly StringBuilder sb = new();

        public frmMstProcess()
        {
            InitializeComponent();
        }

        private void frmMstProcess_Load(object sender, EventArgs e)
        {
            // Initialize DataGridView
            SetDgvList();
            InitializeForm(true);
            DisplayAppList();

            // フォーム表示位置
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

            col01.Name = "id";
            col01.HeaderText = "ID";
            col01.Width = 50;
            col01.Visible = false;

            col02.Name = "appname";
            col02.HeaderText = "プログラムID";
            col02.Width = 200;
            col02.Visible = true;

            col03.Name = "apppath";
            col03.HeaderText = "フォルダ付きファイル名";
            col03.Width = 500;
            col03.Visible = true;

            col04.Name = "controllflag";
            col04.HeaderText = "制御Flag";
            col04.Width = 100;
            col04.Visible = true;

            col05.Name = "comment";
            col05.HeaderText = "備考（プログラム名等）";
            col05.Width = 225;
            col05.Visible = true;

            // this.dgvList.Columns.Add(col00);
            this.dgvAppList.Columns.Add(col01);
            this.dgvAppList.Columns.Add(col02);
            this.dgvAppList.Columns.Add(col03);
            this.dgvAppList.Columns.Add(col04);
            this.dgvAppList.Columns.Add(col05);

            //並び替えができないようにする
            foreach (DataGridViewColumn c in this.dgvAppList.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            this.dgvAppList.EnableHeadersVisualStyles = false;                                                               //Windows Color無効
            this.dgvAppList.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.CornflowerBlue;                   //列ヘッダ色
            this.dgvAppList.RowTemplate.Height = 25;                                                                         //行高さ
            this.dgvAppList.AllowUserToResizeColumns = false;                                                                //列幅の変更不可
            this.dgvAppList.AllowUserToResizeRows = false;                                                                   //行高さの変更不可
            this.dgvAppList.ColumnHeadersVisible = true;                                                                     //列ヘッダ非表示
            this.dgvAppList.Columns["id"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;            // 列ヘッダ文字位置
            this.dgvAppList.Columns["appname"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;       // 列ヘッダ文字位置
            this.dgvAppList.Columns["apppath"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;       // 列ヘッダ文字位置
            this.dgvAppList.Columns["controllflag"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;  // 列ヘッダ文字位置
            this.dgvAppList.Columns["comment"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;       // 列ヘッダ文字位置

            this.dgvAppList.Columns["appname"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;         //セルの文字表示位置
            this.dgvAppList.Columns["apppath"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;         //セルの文字表示位置
            this.dgvAppList.Columns["controllflag"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  //セルの文字表示位置
            this.dgvAppList.Columns["comment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;         //セルの文字表示位置

            //奇数行を黄色にする
            this.dgvAppList.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Moccasin;

            this.dgvAppList.Columns["id"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);          //フォント設定
            this.dgvAppList.Columns["appname"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);     //フォント設定
            this.dgvAppList.Columns["apppath"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);     //フォント設定
            this.dgvAppList.Columns["controllflag"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);//フォント設定
            this.dgvAppList.Columns["comment"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);     //フォント設定

            //this.dgvSelect1.ScrollBars = false;                                                                        //スクロールバー非表示
            this.dgvAppList.MultiSelect = false;                                                                         //複数選択
            this.dgvAppList.ReadOnly = true;                                                                             //読込専用
            this.dgvAppList.AllowUserToAddRows = false;                                                                  //行追加無効
            this.dgvAppList.RowHeadersVisible = false;                                                                   //行ヘッダ非表示
            this.dgvAppList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;                                     //行選択時は１行全て選択状態にする
        }
        /// <summary>
        /// Initialize Form
        /// </summary>
        private void InitializeForm(bool p_flg)
        {
            this.Id = 0;
            this.txtAppName.Text = "";
            this.txtAppPath.Text = "";
            this.txtControllFlag.Text = "";
            this.txtComment.Text = "";

            this.lblNew.Visible = p_flg;
        }
        /// <summary>
        /// 専従先情報表示
        /// </summary>
        private void DisplayAppList()
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" id");
                    sb.AppendLine(",app_name");
                    sb.AppendLine(",app_path");
                    sb.AppendLine(",control_flag");
                    sb.AppendLine(",comment");
                    sb.AppendLine(" FROM");
                    sb.AppendLine("Mst_プロセス制御");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        if (dt_val.Rows.Count == 0)
                        {
                            MessageBox.Show("0件です。", "結果", MessageBoxButtons.OK);
                            return;
                        }
                        else
                        {
                            this.dgvAppList.Rows.Clear();
                        }

                        var i = 0;
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            this.dgvAppList.Rows.Add();
                            this.dgvAppList.Rows[i].Cells["id"].Value = dr["id"].ToString();
                            this.dgvAppList.Rows[i].Cells["appname"].Value = dr["app_name"].ToString();
                            this.dgvAppList.Rows[i].Cells["apppath"].Value = dr["app_path"].ToString();
                            this.dgvAppList.Rows[i].Cells["controllflag"].Value = dr["control_flag"].ToString();
                            this.dgvAppList.Rows[i].Cells["comment"].Value = dr["comment"].ToString();
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
        /// セルクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvAppList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }

            // 新規ラベルを非表示→更新モードに
            InitializeForm(false);

            //クリックされたセルのID取得
            Id = int.Parse(this.dgvAppList.Rows[e.RowIndex].Cells[0].Value.ToString());

            // 画面表示
            this.txtAppName.Text = this.dgvAppList.Rows[e.RowIndex].Cells[1].Value.ToString();
            this.txtAppPath.Text = this.dgvAppList.Rows[e.RowIndex].Cells[2].Value.ToString();
            this.txtControllFlag.Text = this.dgvAppList.Rows[e.RowIndex].Cells[3].Value.ToString();
            this.txtComment.Text = this.dgvAppList.Rows[e.RowIndex].Cells[4].Value.ToString();
        }
        /// <summary>
        /// 閉じるボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        /// <summary>
        /// 新規ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            InitializeForm(true);
            this.dgvAppList.ClearSelection();
        }
        /// <summary>
        /// 保存ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReg_Click(object sender, EventArgs e)
        {
            // 未入力判定
            if (this.txtAppName.Text.Length == 0 || (this.txtAppPath.Text.Length == 0 && this.txtAppName.Text != "Shutdown"))
            {
                MessageBox.Show("未入力項目がります。", "結果", MessageBoxButtons.OK);
                return;
            }

            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    if (this.Id == 0)
                    {
                        // INSERT
                        sb.Clear();
                        sb.AppendLine("INSERT INTO");
                        sb.AppendLine("Mst_プロセス制御");
                        sb.AppendLine("(");
                        sb.AppendLine(" app_name");
                        sb.AppendLine(",app_path");
                        sb.AppendLine(",control_flag");
                        sb.AppendLine(",comment");
                        sb.AppendLine(") VALUES (");
                        sb.AppendLine("'" + this.txtAppName.Text + "'");
                        sb.AppendLine(",'" + this.txtAppPath.Text + "'");
                        sb.AppendLine("," + this.txtControllFlag.Text);
                        sb.AppendLine(",'" + this.txtComment.Text + "'");
                        sb.AppendLine(")");
                    }
                    else
                    {
                        // UPDATE
                        sb.Clear();
                        sb.AppendLine("UPDATE");
                        sb.AppendLine("Mst_プロセス制御");
                        sb.AppendLine("SET");
                        sb.AppendLine(" app_name = '" + this.txtAppName.Text + "'");
                        sb.AppendLine(",app_path = '" + this.txtAppPath.Text + "'");
                        sb.AppendLine(",control_flag = " + this.txtControllFlag.Text);
                        sb.AppendLine(",comment = '" + this.txtComment.Text + "'");
                        sb.AppendLine("WHERE");
                        sb.AppendLine("id = " + this.Id);
                    }
                    clsSqlDb.DMLUpdate(sb.ToString());
                }

                MessageBox.Show("保存しました。", "結果", MessageBoxButtons.OK);
                InitializeForm(true);
                DisplayAppList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 削除ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // IDチェック
            if (Id == 0) { return; }

            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    // DELETE
                    sb.Clear();
                    sb.AppendLine("DELETE FROM");
                    sb.AppendLine("Mst_プロセス制御");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("id = " + Id);

                    clsSqlDb.DMLUpdate(sb.ToString());
                }

                MessageBox.Show("削除しました。", "結果", MessageBoxButtons.OK);

                InitializeForm(true);
                DisplayAppList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
