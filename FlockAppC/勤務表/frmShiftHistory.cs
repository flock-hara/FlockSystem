using FlockAppC.pubClass;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FlockAppC.勤務表
{
    public partial class frmShiftHistory : Form
    {
        private readonly StringBuilder sb = new();

        public frmShiftHistory()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmShiftHistory_Load(object sender, EventArgs e)
        {
            SetDgvHistoryList();

            SetUserCmb();

            // 従業員コンボボックス選択イベント有効
            cmbUser.SelectedIndexChanged += cmbUser_SelectedIndexChanged;

            this.Location = new Point(0, 0);
        }
        /// <summary>
        /// 従業員コンボボックス
        /// </summary>
        private void SetUserCmb()
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    DataRow dr;
                    DataTable dt = new();
                    dt.Columns.Add("Code");
                    dt.Columns.Add("Name");

                    // SQL編集
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" staff_id");
                    sb.AppendLine(",id");
                    sb.AppendLine(",name1");
                    sb.AppendLine("FROM");
                    sb.AppendLine(" Mst_社員");
                    sb.AppendLine("WHERE");
                    // 2026/01/08 UPD (S)
                    // sb.AppendLine(" zai_flag = " + ClsPublic.FLAG_ON);
                    sb.AppendLine(" delete_flag != " + ClsPublic.FLAG_ON);
                    // 2026/01/08 UPD (E)
                    sb.AppendLine("AND");
                    sb.AppendLine(" proxy_flag = " + ClsPublic.FLAG_ON);
                    sb.AppendLine("ORDER BY");
                    sb.AppendLine(" sort");

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
                            // dr["Code"] = drow["ID"];
                            dr["Code"] = drow["staff_id"];
                            dt.Rows.Add(dr);
                        }
                    }

                    // コンボボックスにデータテーブルセット
                    this.cmbUser.DataSource = dt;
                    this.cmbUser.DisplayMember = "Name";
                    this.cmbUser.ValueMember = "Code";
                    this.cmbUser.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                // エラー
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 履歴一覧設定
        /// </summary>
        /// <summary>
        /// 従業員コンボボックス選択イベント
        /// </summary>
        /// <param name="sender"></param>
         /// <param name="e"></param>
        private void cmbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReDraw();
        }
        private void SetDgvHistoryList()
        {
            DataGridViewTextBoxColumn col01 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col02 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col03 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col04 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col05 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col06 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col07 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col08 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col09 = new DataGridViewTextBoxColumn();

            col01.Name = "changedate";
            col01.HeaderText = "日付";
            col01.Width = 100;
            col01.Visible = true;

            col02.Name = "username";
            col02.HeaderText = "担当";
            col02.Width = 80;
            col02.Visible = true;

            col03.Name = "before";
            col03.HeaderText = "変更前";
            col03.Width = 250;
            col03.Visible = true;

            col04.Name = "after";
            col04.HeaderText = "変更後";
            col04.Width = 250;
            col04.Visible = true;

            col05.Name = "regdate";
            col05.HeaderText = "登録日";
            col05.Width = 120;
            col05.Visible = true;

            col06.Name = "reguser";
            col06.HeaderText = "登録者";
            col06.Width = 80;
            col06.Visible = true;

            col07.Name = "status";
            col07.HeaderText = "状況";
            col07.Width = 100;
            col07.Visible = true;

            col08.Name = "day";
            col08.HeaderText = "日付(非表示)";
            col08.Width = 10;
            col08.Visible = false;

            col09.Name = "tantoid";
            col09.HeaderText = "ID";
            col09.Width = 10;
            col09.Visible = false;

            this.dgvHistoryList.Columns.Add(col01);
            this.dgvHistoryList.Columns.Add(col02);
            this.dgvHistoryList.Columns.Add(col03);
            this.dgvHistoryList.Columns.Add(col04);
            this.dgvHistoryList.Columns.Add(col05);
            this.dgvHistoryList.Columns.Add(col06);
            this.dgvHistoryList.Columns.Add(col07);
            this.dgvHistoryList.Columns.Add(col08);
            this.dgvHistoryList.Columns.Add(col09);

            //並び替えができないようにする
            foreach (DataGridViewColumn c in this.dgvHistoryList.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            this.dgvHistoryList.EnableHeadersVisualStyles = false;                                                          //Windows Color無効
            this.dgvHistoryList.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.CornflowerBlue;              //列ヘッダ色
            this.dgvHistoryList.RowTemplate.Height = 40;                                                                    //行高さ
            this.dgvHistoryList.AllowUserToResizeColumns = false;                                                           //列幅の変更不可
            this.dgvHistoryList.AllowUserToResizeRows = false;                                                              //行高さの変更不可
            this.dgvHistoryList.ColumnHeadersVisible = true;                                                                //列ヘッダ表示

            //奇数行を黄色にする
            this.dgvHistoryList.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Moccasin;

            this.dgvHistoryList.Columns["changedate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;      //セルの文字表示位置
            this.dgvHistoryList.Columns["username"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;        //セルの文字表示位置
            this.dgvHistoryList.Columns["before"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;          //セルの文字表示位置
            this.dgvHistoryList.Columns["after"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;           //セルの文字表示位置
            this.dgvHistoryList.Columns["regdate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;         //セルの文字表示位置
            this.dgvHistoryList.Columns["reguser"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;         //セルの文字表示位置
            this.dgvHistoryList.Columns["status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;          //セルの文字表示位置
            // this.dgvHistoryList.Columns["day"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;             //セルの文字表示位置
            // this.dgvHistoryList.Columns["tantoid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;         //セルの文字表示位置

            this.dgvHistoryList.Columns["changedate"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10);      //フォント設定
            this.dgvHistoryList.Columns["username"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10);        //フォント設定
            this.dgvHistoryList.Columns["before"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10);          //フォント設定
            this.dgvHistoryList.Columns["after"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10);           //フォント設定
            this.dgvHistoryList.Columns["regdate"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10);         //フォント設定
            this.dgvHistoryList.Columns["reguser"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10);         //フォント設定
            this.dgvHistoryList.Columns["status"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10);          //フォント設定
            //this.dgvHistoryList.Columns["changedate"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Bold);      //フォント設定
            //this.dgvHistoryList.Columns["username"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Bold);      //フォント設定
            //this.dgvHistoryList.Columns["before"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Bold);      //フォント設定
            //this.dgvHistoryList.Columns["after"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Bold);      //フォント設定
            //this.dgvHistoryList.Columns["regdate"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Bold);      //フォント設定
            //this.dgvHistoryList.Columns["reguser"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Bold);      //フォント設定
            //this.dgvHistoryList.Columns["status"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Bold);      //フォント設定

            //this.dgvHistoryList.ScrollBars = false;                                                                        //スクロールバー非表示
            this.dgvHistoryList.MultiSelect = false;                                                                         //複数選択
            this.dgvHistoryList.ReadOnly = true;                                                                             //読込専用
            this.dgvHistoryList.AllowUserToAddRows = false;                                                                  //行追加無効
            this.dgvHistoryList.RowHeadersVisible = false;                                                                   //行ヘッダ非表示
            this.dgvHistoryList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;                                     //行選択時は１行全て選択状態にする

            // Column1列のセルのテキストを折り返して表示する
            this.dgvHistoryList.Columns["before"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvHistoryList.Columns["after"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // セルの文字表示位置
            DataGridViewCellStyle columnHeaderStyle2 = dgvHistoryList.ColumnHeadersDefaultCellStyle;
            columnHeaderStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // ==========================================
            // コンボボックス設定
            // ==========================================
            // フォントサイズ
            this.cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbStatus.Items.Add("　　");
            this.cmbStatus.Items.Add("変更");
            this.cmbStatus.Items.Add("承認");
            this.cmbStatus.Items.Add("解除");
            this.cmbStatus.Items.Add("削除");
            this.cmbStatus.SelectedIndex = 0;

            ReDraw();
        }
        /// <summary>
        /// 再表示
        /// </summary>
        private void ReDraw()
        {
            int row = 0;
            string status_where = "";
            string user_where = "";

            // 抽出条件：状態
            switch (this.cmbStatus.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    status_where = " AND status = '変更'";
                    break;
                case 2:
                    status_where = " AND status = '承認'";
                    break;
                case 3:
                    status_where = " AND status = '解除'";
                    break;
                case 4:
                    status_where = " AND status = '削除'";
                    break;
            }

            // 抽出条件：担当者
            // 従業員の指定ありか判定
            if (this.cmbUser.SelectedIndex >= 0 && int.Parse(this.cmbUser.SelectedIndex.ToString()) != 0)
            {
                var id = int.Parse(this.cmbUser.SelectedValue.ToString());
                user_where = " AND tanto_id = " + id;
            }

            sb.Clear();
            sb.AppendLine("SELECT");
            sb.AppendLine(" reg_date");
            sb.AppendLine(",reg_user_id");
            sb.AppendLine(",reg_user_name");
            sb.AppendLine(",tanto_id");
            sb.AppendLine(",tanto_name");
            sb.AppendLine(",day");
            sb.AppendLine(",before_content");
            sb.AppendLine(",after_content");
            sb.AppendLine(",status");
            sb.AppendLine("FROM");
            sb.AppendLine("Trn_勤務表シフト変更履歴");
            sb.AppendLine("WHERE");

            // 抽出条件：予定日、登録日
            if (this.rboSchedule.Checked == true)
            {
                sb.AppendLine("day >= '" + this.dtpDate1.Value + "'");
                sb.AppendLine("AND");
                sb.AppendLine("day <= '" + this.dtpDate2.Value + "'");
            }
            else
            {
                sb.AppendLine("reg_date >= '" + this.dtpDate1.Value.ToString("yyyy/MM/dd") + "'");
                sb.AppendLine("AND");
                sb.AppendLine("reg_date <= '" + this.dtpDate2.Value.ToString("yyyy/MM/dd") + "'");
            }
            sb.AppendLine(status_where);
            sb.AppendLine(user_where);
            sb.AppendLine("ORDER BY");
            sb.AppendLine(" day");
            sb.AppendLine(",reg_date");
            sb.AppendLine(",tanto_id");

            try
            {
                this.dgvHistoryList.Rows.Clear();

                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            this.dgvHistoryList.Rows.Add();
                            this.dgvHistoryList.Rows[row].Cells["regdate"].Value = DateTime.Parse(dr["reg_date"].ToString()).ToString("MM/dd HH:mm");
                            this.dgvHistoryList.Rows[row].Cells["reguser"].Value = dr["reg_user_name"].ToString();
                            this.dgvHistoryList.Rows[row].Cells["changedate"].Value = DateTime.Parse(dr["day"].ToString()).ToString("MM/dd") + "(" + DateTime.Parse(dr["day"].ToString()).ToString("ddd") + ")";
                            this.dgvHistoryList.Rows[row].Cells["username"].Value = dr["tanto_name"].ToString();
                            this.dgvHistoryList.Rows[row].Cells["before"].Value = dr["before_content"].ToString().Replace(Environment.NewLine, " ");
                            this.dgvHistoryList.Rows[row].Cells["before"].Value = dr["before_content"].ToString().Replace("\n", " ");
                            this.dgvHistoryList.Rows[row].Cells["after"].Value = dr["after_content"].ToString().Replace(Environment.NewLine, " ");
                            this.dgvHistoryList.Rows[row].Cells["after"].Value = dr["after_content"].ToString().Replace("\n", " ");
                            this.dgvHistoryList.Rows[row].Cells["status"].Value = dr["status"].ToString();
                            row++;
                        }
                    }
                }
                this.dgvHistoryList.Columns[0].ReadOnly = true;          // 書き込み禁止
                this.dgvHistoryList.ClearSelection();                    // Loadイベントでは効果がない為、showイベントに記載
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReDraw();
        }

        private void rboSchedule_CheckedChanged(object sender, EventArgs e)
        {
            ReDraw();
        }

        private void rboReg_CheckedChanged(object sender, EventArgs e)
        {
            ReDraw();
        }

        private void dtpDate1_ValueChanged(object sender, EventArgs e)
        {
            ReDraw();
        }

        private void dtpDate2_VisibleChanged(object sender, EventArgs e)
        {
            ReDraw();
        }

        private void dtpDate2_ValueChanged(object sender, EventArgs e)
        {
            ReDraw();
        }
        /// <summary>
        /// EXCEL出力
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExcel_Click(object sender, EventArgs e)
        {
            // 表示件数チェック
            if (this.dgvHistoryList.Rows.Count < 1) { return; }

            pubForm.frmMessageBox frmMsg = new();

            using (ClsMsExcel clsEx = new())
            {
                // 出力ファイル名編集
                var output_filename = ClsPublic.pubRootPath + ClsPublic.pubAppPath + @"\変更履歴\" + DateTime.Now.ToString("yyyyMMddhhmmss") + "_変更履歴.xlsx";
                // ファイルコピー
                File.Copy(ClsPublic.pubRootPath + ClsPublic.pubAppPath + @"\変更履歴\勤務表変更履歴_原紙.xlsx", output_filename);

                // ================================================================
                // 処理中メッセージボックス
                // ================================================================
                // メッセージボックス
                frmMsg = new pubForm.frmMessageBox()
                {
                    F_size_height = 95,
                    F_button_case = 0,
                    L_value = "EXCEL出力中 ....."
                };
                frmMsg.Show();
                frmMsg.Refresh();

                clsEx.FileName = output_filename;
                clsEx.SheetName = "一覧";
                clsEx.OpenBook();

                // 日付
                clsEx.Value = dtpDate1.Value.ToString("yyyy/MM/dd");
                clsEx.FontSize = 12;
                clsEx.FontColor = "";
                clsEx.FontBold = "";
                clsEx.BackColor = "SystemColor";
                clsEx.Row = 3;
                clsEx.Col = 5;
                clsEx.SetCell();

                clsEx.Value = dtpDate2.Value.ToString("yyyy/MM/dd");
                clsEx.FontSize = 12;
                clsEx.FontColor = "";
                clsEx.FontBold = "";
                clsEx.BackColor = "SystemColor";
                clsEx.Row = 3;
                clsEx.Col = 12;
                clsEx.SetCell();

                string value;
                for(var row = 0; row < this.dgvHistoryList.RowCount; row++)
                {
                    for (var col = 0; col <= 6; col++)
                    {
                        value = this.dgvHistoryList.Rows[row].Cells[col].Value.ToString();

                        clsEx.Row = row + 6;

                        switch(col)
                        {
                            case 0:
                                clsEx.Col = 3;
                                break;
                            case 1:
                                clsEx.Col = 7;
                                break;
                            case 2:
                                clsEx.Col = 10;
                                break;
                            case 3:
                                clsEx.Col = 21;
                                break;
                            case 4:
                                clsEx.Col = 33;
                                break;
                            case 5:
                                clsEx.Col = 39;
                                break;
                            case 6:
                                clsEx.Col = 42;
                                break;
                        }
                        value = value.Replace(Environment.NewLine, "\n");
                        clsEx.Value = value.Replace("\n", Environment.NewLine);

                        clsEx.FontSize = 10;
                        clsEx.FontColor = "";
                        clsEx.FontBold = "";
                        clsEx.BackColor = "SystemColor";
                        clsEx.SetCell();
                    }
                }
                clsEx.CloseSaveBook();
            }
            // 処理中メッセージクローズ
            frmMsg.Close();
            frmMsg.Dispose();

            // ================================================================
            // 終了メッセージボックス
            // ================================================================
            frmMsg = new pubForm.frmMessageBox()
            {
                F_size_height = 133,
                F_button_case = 1,
                L_value = "EXCEL出力が終了しました。"
            };
            frmMsg.ShowDialog();
            frmMsg.Dispose();
        }
    }
}
