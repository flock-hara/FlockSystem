using FlockAppC.pubClass;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FlockAppC.マスターメンテ
{
    public partial class frmMstHoliday : Form
    {
        private readonly StringBuilder sb = new();

        public frmMstHoliday()
        {
            InitializeComponent();
        }

        private void frmMstHoliday_Load(object sender, EventArgs e)
        {
            InitializeForm();
            DispList();
        }
        /// <summary>
        /// Initialize Form
        /// </summary>
        private void InitializeForm()
        {
            // DataGridView
            this.dgvList.Columns.Clear();

            DataGridViewTextBoxColumn col01 = new()
            {
                Name = "Day",
                HeaderText = "日",
                Width = 70,
                Visible = true
            };
            dgvList.Columns.Add(col01);

            DataGridViewTextBoxColumn col02 = new()
            {
                Name = "Holiday",
                HeaderText = "祝祭日",
                Width = 273
            };
            dgvList.Columns.Add(col02);

            DataGridViewTextBoxColumn col03 = new()
            {
                Name = "Before",
                HeaderText = "変更前日",
                Width = 80,
                Visible = false
            };
            dgvList.Columns.Add(col03);

            //DataGridViewTextBoxColumn col01 = new DataGridViewTextBoxColumn();
            //DataGridViewTextBoxColumn col02 = new DataGridViewTextBoxColumn();
            //DataGridViewTextBoxColumn col03 = new DataGridViewTextBoxColumn();
            //col01.Name = "Day";
            //col01.HeaderText = "日";
            //col01.Width = 70;
            //col01.Visible = true;
            //dgvList.Columns.Add(col01);
            //col02.Name = "Holiday";
            //col02.HeaderText = "祝祭日";
            //col02.Width = 273;
            //dgvList.Columns.Add(col02);
            //col03.Name = "Before";
            //col03.HeaderText = "変更前日";
            //col03.Width = 80;
            //col03.Visible = false;
            //dgvList.Columns.Add(col03);

            //並び替えができないようにする
            foreach (DataGridViewColumn c in this.dgvList.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            this.dgvList.EnableHeadersVisualStyles = false;                                                          //Windows Color無効
            this.dgvList.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.CornflowerBlue;              //列ヘッダ色
            this.dgvList.RowTemplate.Height = 25;                                                                    //行高さ
            this.dgvList.AllowUserToResizeColumns = false;                                                           //列幅の変更不可
            this.dgvList.AllowUserToResizeRows = false;                                                              //行高さの変更不可
            this.dgvList.ColumnHeadersVisible = true;                                                                //列ヘッダ非表示
            this.dgvList.Columns["Day"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;       // 列ヘッダ文字位置
            this.dgvList.Columns["Holiday"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;   // 列ヘッダ文字位置
            this.dgvList.Columns["Before"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;    // 列ヘッダ文字位置

            //奇数行を黄色にする
            this.dgvList.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Moccasin;

            this.dgvList.Columns["Day"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;                   //セルの文字表示位置
            this.dgvList.Columns["Holiday"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;               //セルの文字表示位置
            this.dgvList.Columns["Before"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;                //セルの文字表示位置
            this.dgvList.Columns["Day"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);     //フォント設定
            this.dgvList.Columns["Holiday"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular); //フォント設定
            this.dgvList.Columns["Before"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);  //フォント設定

            //this.dgvSelect1.ScrollBars = false;                                                                        //スクロールバー非表示
            this.dgvList.MultiSelect = false;                                                                         //複数選択
            this.dgvList.ReadOnly = true;                                                                             //読込専用
            this.dgvList.AllowUserToAddRows = false;                                                                  //行追加無効
            this.dgvList.RowHeadersVisible = false;                                                                   //行ヘッダ非表示
            this.dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;                                     //行選択時は１行全て選択状態にする

            // コンボボックス設定
            this.cmbYear.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbYear.Items.Add("2023");
            this.cmbYear.Items.Add("2024");
            this.cmbYear.Items.Add("2025");
            this.cmbYear.Items.Add("2026");
            this.cmbYear.Items.Add("2027");
            this.cmbYear.Items.Add("2028");
            this.cmbYear.Items.Add("2029");
            this.cmbYear.Items.Add("2030");

            switch (DateTime.Now.ToString("yyyy"))
            {
                case "2023":
                    this.cmbYear.SelectedIndex = 0;
                    break;
                case "2024":
                    this.cmbYear.SelectedIndex = 1;
                    break;
                case "2025":
                    this.cmbYear.SelectedIndex = 2;
                    break;
                case "2026":
                    this.cmbYear.SelectedIndex = 3;
                    break;
                case "2027":
                    this.cmbYear.SelectedIndex = 4;
                    break;
                case "2028":
                    this.cmbYear.SelectedIndex = 5;
                    break;
                case "2029":
                    this.cmbYear.SelectedIndex = 6;
                    break;
                case "2030":
                    this.cmbYear.SelectedIndex = 7;
                    break;
            }

        }
        /// <summary>
        /// Display List
        /// </summary>
        private void DispList()
        {
            int row = 0;
            
            try
            {
                this.dgvList.Rows.Clear();

                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" year");
                    sb.AppendLine(",day");
                    sb.AppendLine(",holiday");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_休日");
                    sb.AppendLine("WHERE");
                    sb.AppendLine(" year = " + this.cmbYear.Text);
                    sb.AppendLine("ORDER BY");
                    sb.AppendLine(" day");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            this.dgvList.Rows.Add();
                            this.dgvList.Rows[row].Cells["Day"].Value = DateTime.Parse(dr["day"].ToString()).ToString("MM/dd");
                            this.dgvList.Rows[row].Cells["Holiday"].Value = dr["holiday"].ToString();
                            this.dgvList.Rows[row].Cells["Before"].Value = DateTime.Parse(dr["day"].ToString()).ToString("MM/dd");
                            row++;
                        }
                    }
                }
                this.dgvList.Columns[0].ReadOnly = true;
                this.dgvList.Columns[1].ReadOnly = true;
                this.dgvList.Columns[2].ReadOnly = true;
                this.dgvList.ClearSelection();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 年選択コンボボックス
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            DispList();
        }
        /// <summary>
        /// 一覧クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = e.RowIndex;

            this.mtxtDay.Text = this.cmbYear.Text + "/" + this.dgvList.Rows[row].Cells[0].Value;
            this.txtHoliday.Text = this.dgvList.Rows[row].Cells[1].Value.ToString();
        }
        /// <summary>
        /// 保存ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReg_Click(object sender, EventArgs e)
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    // DELETE -> INSERT処理
                    sb.Clear();
                    sb.AppendLine("DELETE");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_休日");
                    sb.AppendLine("WHERE");
                    sb.AppendLine(" year = " + this.cmbYear.Text);
                    sb.AppendLine("AND");
                    sb.AppendLine(" day = '" + DateTime.Parse(this.mtxtDay.Text).ToString("yyyy/MM/dd") + "'");

                    clsSqlDb.DMLUpdate(sb.ToString());

                    // INSERT
                    sb.Length = 0;
                    sb.AppendLine("INSERT INTO");
                    sb.AppendLine("Mst_休日");
                    sb.AppendLine("(");
                    sb.AppendLine(" year");
                    sb.AppendLine(",day");
                    sb.AppendLine(",holiday");
                    sb.AppendLine(",kbn");
                    // 2025/11/12↓
                    sb.AppendLine(",ins_user_id");
                    sb.AppendLine(",ins_date");
                    sb.AppendLine(",delete_flag");
                    // 2025/11/12↑
                    sb.AppendLine(") VALUES (");
                    sb.AppendLine(this.cmbYear.Text);
                    sb.AppendLine(",'" + DateTime.Parse(this.mtxtDay.Text).ToString("yyyy/MM/dd") + "'");
                    sb.AppendLine(",'" + this.txtHoliday.Text + "'");
                    sb.AppendLine(",0");
                    // 2025/11/12↓
                    sb.AppendLine("," + ClsLoginUser.StaffID);
                    sb.AppendLine(",'" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    sb.AppendLine("," + ClsPublic.FLAG_OFF);
                    // 2025/11/12↑
                    sb.AppendLine(")");

                    clsSqlDb.DMLUpdate(sb.ToString());
                }
                DispList();
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
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("DELETE");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_休日");
                    sb.AppendLine("WHERE");
                    sb.AppendLine(" year = " + this.cmbYear.Text);
                    sb.AppendLine("AND");
                    sb.AppendLine(" day = '" + DateTime.Parse(this.mtxtDay.Text).ToString("yyyy/MM/dd") + "'");

                    clsSqlDb.DMLUpdate(sb.ToString());
                }
                MessageBox.Show("削除しました。", "結果", MessageBoxButtons.OK);
                DispList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 前年コピーボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("現在登録されている休日はクリアされます。" + Environment.NewLine + "よろしいですか？", "確認", MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;

            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    // 当年分DELETE
                    sb.Clear();
                    sb.AppendLine("DELETE");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_休日");
                    sb.AppendLine("WHERE");
                    sb.AppendLine(" year = " + this.cmbYear.Text);

                    clsSqlDb.DMLUpdate(sb.ToString());

                    // 前年分SELECT
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" year");
                    sb.AppendLine(",day");
                    sb.AppendLine(",holiday");
                    sb.AppendLine(",kbn");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_休日");
                    sb.AppendLine("WHERE");
                    sb.AppendLine(" year = " + (int.Parse(cmbYear.Text) - 1).ToString());
                    sb.AppendLine("ORDER BY");
                    sb.AppendLine(" day");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            // 当年分INSERT
                            sb.Clear();
                            sb.AppendLine("INSERT INTO");
                            sb.AppendLine("Mst_休日");
                            sb.AppendLine("(");
                            sb.AppendLine(" year");
                            sb.AppendLine(",day");
                            sb.AppendLine(",holiday");
                            sb.AppendLine(",kbn");
                            // 2025/11/12↓
                            sb.AppendLine(",ins_user_id");
                            sb.AppendLine(",ins_date");
                            sb.AppendLine(",delete_flag");
                            // 2025/11/12↑
                            sb.AppendLine(") VALUES (");
                            sb.AppendLine(cmbYear.Text);
                            sb.AppendLine(",'" + cmbYear.Text + "/" + DateTime.Parse(dr["day"].ToString()).ToString("MM/dd") + "'");
                            sb.AppendLine(",'" + dr["holiday"].ToString() + "'");
                            sb.AppendLine(",0");
                            // 2025/11/12↓
                            sb.AppendLine("," + ClsLoginUser.StaffID);
                            sb.AppendLine(",'" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                            sb.AppendLine("," + ClsPublic.FLAG_OFF);
                            // 2025/11/12↑
                            sb.AppendLine(")");

                            clsSqlDb.DMLUpdate(sb.ToString());
                        }
                    }
                }
                DispList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
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
        /// 新規ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            this.mtxtDay.Text = "";
            this.txtHoliday.Text = "";
            this.dgvList.ClearSelection();
        }
    }
}
