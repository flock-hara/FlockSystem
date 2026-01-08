using FlockAppC.pubClass;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FlockAppC.勤務表
{
    public partial class frmRegContact : Form
    {
        // 一覧の連絡ボタンのインデックス
        public int SelectTantoID { get; set; }

        private readonly StringBuilder sb = new();

        public frmRegContact()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 連絡済登録画面ロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmRegContact_Load(object sender, EventArgs e)
        {
            dtpDate.Value = DateTime.Now;

            //==========================================
            // 担当者一覧表示
            // ==========================================
            dgvTanto.Columns.Clear();

            DataGridViewTextBoxColumn colName = new();              // 1列目を定義
            colName.Name = "name";
            colName.HeaderText = "名前";
            colName.Width = 100;
            dgvTanto.Columns.Add(colName);
            DataGridViewTextBoxColumn colID = new();                // 2列目を定義
            colID.Name = "ID";
            colID.HeaderText = "ID";
            colID.Width = 100;
            colID.Visible = false;
            dgvTanto.Columns.Add(colID);

            //並び替えができないようにする
            foreach (DataGridViewColumn c in this.dgvTanto.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            dgvTanto.EnableHeadersVisualStyles = false;                                                         // Windows Color無効
            dgvTanto.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.CornflowerBlue;             // 列ヘッダ色
            dgvTanto.RowTemplate.Height = 30;                                                                   // 行高さ
            dgvTanto.Columns["name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    // セルの文字表示位置
            dgvTanto.AllowUserToResizeColumns = false;                                                          // 列幅の変更不可
            dgvTanto.AllowUserToResizeRows = false;                                                             // 行高さの変更不可
            dgvTanto.Columns["name"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11);         // フォント設定
            // dgvTanto.ScrollBars = false;                                                                        // スクロールバー非表示
            dgvTanto.MultiSelect = false;
            dgvTanto.ReadOnly = true;
            dgvTanto.AllowUserToAddRows = false;
            dgvTanto.RowHeadersVisible = false;

            using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
            {
                sb.Clear();
                sb.AppendLine("SELECT");
                sb.AppendLine(" staff_id");
                sb.AppendLine(",id");
                sb.AppendLine(",name1");
                sb.AppendLine("FROM");
                sb.AppendLine("Mst_社員");
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
                    var i = 0;
                    foreach (DataRow dr in dt_val.Rows)
                    {
                        dgvTanto.Rows.Add();
                        dgvTanto.Rows[i].Cells["name"].Value = dr["name1"];
                        // dgvTanto.Rows[i].Cells["ID"].Value = dr["ID"];
                        dgvTanto.Rows[i].Cells["ID"].Value = dr["staff_id"];
                        i++;
                    }
                }
            }

            //==========================================
            // シフト予定表示設定
            // ==========================================
            dgvShift.Columns.Clear();

            DataGridViewTextBoxColumn coChangeDate = new();
            coChangeDate.Name = "changedate";
            coChangeDate.HeaderText = "日付";
            coChangeDate.Width = 90;
            dgvShift.Columns.Add(coChangeDate);

            DataGridViewTextBoxColumn coShift = new();
            coShift.Name = "value";
            coShift.HeaderText = "シフト予定";
            coShift.Width = 110;
            dgvShift.Columns.Add(coShift);

            DataGridViewTextBoxColumn coTantoID = new();
            coTantoID.Name = "tantoid";
            coTantoID.HeaderText = "担当者ID";
            coTantoID.Width = 100;
            coTantoID.Visible = false;
            dgvShift.Columns.Add(coTantoID);

            DataGridViewTextBoxColumn coDate = new();
            coDate.Name = "date";
            coDate.HeaderText = "日付(非表示)";
            coDate.Width = 10;
            coDate.Visible = false;
            dgvShift.Columns.Add(coDate);

            // 連絡済チェックボックス、「連絡済」追加 2024/07/26 ADD ↓↓↓
            DataGridViewCheckBoxColumn colChk = new();
            colChk.Name = "連絡";
            colChk.Width = 50;
            dgvShift.Columns.Add(colChk);

            DataGridViewTextBoxColumn coChkTxt = new();
            coChkTxt.Name = "checktext";
            coChkTxt.HeaderText = "";
            coChkTxt.Width = 80;
            dgvShift.Columns.Add(coChkTxt);
            // 連絡済チェックボックス、「連絡済」追加 2024/07/26 ADD ↑↑↑

            // 備考追加 2024/07/26　↓↓↓
            DataGridViewTextBoxColumn coComment = new();
            coComment.Name = "comment";
            coComment.HeaderText = "メモ";
            coComment.Width = 200;
            dgvShift.Columns.Add(coComment);
            // 備考追加 2024/07/26　↑↑↑

            //並び替えができないようにする
            foreach (DataGridViewColumn c in this.dgvShift.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            dgvShift.EnableHeadersVisualStyles = false;                                                 // Windows Color無効
            dgvShift.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.CornflowerBlue;     // 列ヘッダ色
            dgvShift.RowTemplate.Height = 60;                                                           // 行高さ
            dgvShift.AllowUserToResizeColumns = false;                                                  // 列幅の変更不可
            dgvShift.AllowUserToResizeRows = false;                                                     // 行高さの変更不可

            dgvShift.Columns["changedate"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11);   // フォント設定
            dgvShift.Columns["value"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11);        // フォント設定
            dgvShift.Columns["comment"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10);      // フォント設定
            dgvShift.Columns["checktext"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック,", 12, FontStyle.Bold);

            dgvShift.Columns["changedate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // セルの文字表示位置
            dgvShift.Columns["value"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;      // セルの文字表示位置
            dgvShift.Columns["checktext"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  // セルの文字表示位置

            // dgvShift.ScrollBars = false;
            dgvShift.MultiSelect = false;
            dgvShift.ReadOnly = false;
            dgvShift.AllowUserToAddRows = false;
            dgvShift.RowHeadersVisible = false;

            // "Column1"列のセルのテキストを折り返して表示する
            dgvShift.Columns["changedate"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvShift.Columns["value"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // セルの文字表示位置
            DataGridViewCellStyle columnHeaderStyle = new();
            columnHeaderStyle = dgvShift.ColumnHeadersDefaultCellStyle;
            columnHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // 奇数行を黄色にする
            // dgvShift.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Moccasin;


            // 担当者一覧
            dgvTanto.Columns[0].ReadOnly = true;                         // 書き込み禁止
            dgvTanto.CurrentCell = null;

            dgvShift.Columns["changedate"].ReadOnly = true;               // 書き込み禁止
            dgvShift.Columns["value"].ReadOnly = true;                    // 書き込み禁止
            dgvShift.Columns["comment"].ReadOnly = true;                  // 書き込み禁止
            dgvShift.Columns["checktext"].ReadOnly = false;               // 書き込みOK
            dgvShift.CurrentCell = null;

            this.Location = new Point(0, 0);
        }
        /// <summary>
        /// 登録ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReg_Click(object sender, EventArgs e)
        {
            string strName = "";
            int intValue = 0;
            int intChecked;
            DateTime datDate;

            DateTime[] datArr = new DateTime[7];
            DateTime now = DateTime.Now;
            datArr[0] = now.AddDays(0);
            datArr[1] = now.AddDays(1);
            datArr[2] = now.AddDays(2); 
            datArr[3] = now.AddDays(3); 
            datArr[4] = now.AddDays(4); 
            datArr[5] = now.AddDays(5); 
            datArr[6] = now.AddDays(6);

            foreach(DataGridViewCell cl in dgvTanto.SelectedCells)
            {
                intValue = int.Parse(dgvTanto.Rows[cl.RowIndex].Cells[1].Value.ToString());        // ID取得
                strName = dgvTanto.Rows[cl.RowIndex].Cells[0].Value.ToString();                    // 名前取得
            }

            using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
            {
                for (int i = 0; i < 7; i++)
                {
                    datDate = datArr[i];
                    intChecked = 0;

                    /////////////////////////////////////////////////////////////////////////////////////////////
                    /// この処理は再確認
                    /////////////////////////////////////////////////////////////////////////////////////////////
                    if (bool.Parse(dgvShift.Rows[i].Cells["連絡"].Value.ToString()) == true)
                    {
                        intChecked = 1;
                    }

                    // Trn_連絡　削除
                    sb.Clear();
                    sb.AppendLine("DELETE FROM");
                    sb.AppendLine("Trn_連絡");
                    sb.AppendLine("WHERE");
                    sb.AppendLine(" tanto_id = " + intValue);
                    sb.AppendLine("AND");
                    sb.AppendLine(" day = '" + datDate + "'");

                    clsSqlDb.DMLUpdate(sb.ToString());

                    if (intChecked == 1)
                    {
                        // Trn_連絡　登録
                        // DELETE->INSERT
                        sb.Clear();
                        sb.AppendLine("INSERT INTO");
                        sb.AppendLine("Trn_連絡");
                        sb.AppendLine("(");
                        sb.AppendLine(" tanto_id");
                        sb.AppendLine(",tanto_name");
                        sb.AppendLine(",day");
                        // 2025/11/12↓
                        sb.AppendLine(",ins_user_id");
                        sb.AppendLine(",ins_date");
                        sb.AppendLine(",delete_flag");
                        // 2025/11/12↑
                        sb.AppendLine(") VALUES (");
                        sb.AppendLine(intValue.ToString());
                        sb.AppendLine(",'" + strName + "'");
                        sb.AppendLine(",'" + datDate + "'");
                        // 2025/11/12↓
                        sb.AppendLine("," + ClsLoginUser.StaffID);
                        sb.AppendLine(",'" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                        sb.AppendLine("," + ClsPublic.FLAG_OFF);
                        // 2025/11/12↑
                        sb.AppendLine(")");

                        clsSqlDb.DMLUpdate(sb.ToString());
                    }
                }

                // 2024/09/24 ADD
                // 勤務表変更フラグ更新
                ClsPublic.UpdateShiftFlag(1);

                MessageBox.Show("登録しました。", "結果", MessageBoxButtons.OK);
            }
        }
        /// <summary>
        /// 担当者クリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvTanto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row;
            int col;

            dgvShift.Rows.Clear();

            // クリックされたセルのRow/Col取得
            row = e.RowIndex;
            col = e.ColumnIndex + 1;

            DspShift(row, col);
            dgvShift.CurrentCell = null;
        }
        /// <summary>
        /// シフト表示
        /// </summary>
        /// <param name="p_row"></param>
        /// <param name="p_col"></param>
        private void DspShift(int p_row, int p_col)
        {
            int row = 0;
            int value;
            DateTime day;
            DateTime start_day;
            DateTime end_day;
            
            try
            {
                value = int.Parse(this.dgvTanto.Rows[p_row].Cells[p_col].Value.ToString());      // ID取得
                day = DateTime.Parse(this.dtpDate.Text);                                         // 日付取得

                // 開始日、終了日取得：１０日分
                start_day = day.AddDays(0);
                end_day = day.AddDays(10);

                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" Trn_勤務表シフト情報.value");
                    sb.AppendLine(",Trn_勤務表シフト情報.day");
                    sb.AppendLine(",Trn_勤務表シフト情報.tanto_id");
                    sb.AppendLine(",Trn_勤務表シフト情報.font_size");
                    sb.AppendLine(",Trn_勤務表シフト情報.font_color");
                    sb.AppendLine(",Trn_勤務表シフト情報.font_bold");
                    sb.AppendLine(",Trn_勤務表シフト情報.back_color");
                    sb.AppendLine(",Trn_勤務表シフト情報.contact_flag");
                    sb.AppendLine(",Trn_勤務表シフト情報.comment");
                    sb.AppendLine(",Trn_連絡.tanto_id AS EXI");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Trn_勤務表シフト情報");
                    sb.AppendLine("LEFT JOIN");
                    sb.AppendLine("Trn_連絡");
                    sb.AppendLine("ON");
                    sb.AppendLine("Trn_勤務表シフト情報.day = Trn_連絡.day");
                    sb.AppendLine("AND");
                    sb.AppendLine("Trn_勤務表シフト情報.tanto_id = Trn_連絡.tanto_id");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("Trn_勤務表シフト情報.tanto_id =" + value);
                    sb.AppendLine("AND");
                    sb.AppendLine("Trn_勤務表シフト情報.day >= '" + start_day.ToString() + "'");
                    sb.AppendLine("AND");
                    sb.AppendLine("Trn_勤務表シフト情報.day <= '" + end_day.ToString() + "'");
                    sb.AppendLine("ORDER BY");
                    sb.AppendLine("Trn_勤務表シフト情報.day");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            dgvShift.Rows.Add();
                            this.dgvShift.Rows[row].Cells["changedate"].Value = DateTime.Parse(dr["day"].ToString()).ToString("MM/dd") + Environment.NewLine + "(" + DateTime.Parse(dr["day"].ToString()).ToString("dddd") + ")";
                            // this.dgvShift.Rows[intCnt].Cells["changedate"].Value = DateTime.Parse(dr["Day"].ToString()).ToString("MM/dd") + "(" + clsPublic.GetWeekly(DateTime.Parse(dr["Day"].ToString()), 2, 1) + ")";
                            this.dgvShift.Rows[row].Cells["tantoid"].Value = dr["tanto_id"].ToString();
                            this.dgvShift.Rows[row].Cells["value"].Value = dr["value"].ToString();
                            this.dgvShift.Rows[row].Cells["date"].Value = dr["day"];
                            this.dgvShift.Rows[row].Cells["comment"].Value = dr["comment"];

                            if (dr["EXI"].ToString() != "")
                            {
                                this.dgvShift.Rows[row].Cells["checktext"].Value = "連絡済";
                                this.dgvShift.Rows[row].Cells["連絡"].Value = true;
                            }
                            else
                            {
                                this.dgvShift.Rows[row].Cells["checktext"].Value = "";
                                this.dgvShift.Rows[row].Cells["連絡"].Value = false;
                            }


                            // 休日、土曜、日曜判定
                            if (ClsPublic.CheckHoliday(DateTime.Parse(dr["day"].ToString())) == true)
                            {
                                // 休日
                                this.dgvShift.Rows[row].DefaultCellStyle.BackColor = System.Drawing.Color.LightPink;
                            }
                            else if (this.dgvShift.Rows[row].Cells["changedate"].Value.ToString().IndexOf("土曜") > 0)
                            {
                                // 土曜
                                this.dgvShift.Rows[row].DefaultCellStyle.BackColor = System.Drawing.Color.LightSteelBlue;
                            }
                            else if (this.dgvShift.Rows[row].Cells["changedate"].Value.ToString().IndexOf("日曜") > 0)
                            {
                                // 日曜
                                this.dgvShift.Rows[row].DefaultCellStyle.BackColor = System.Drawing.Color.Pink;
                            }
                            else
                            {
                                this.dgvShift.Rows[row].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                            }
                            row++;
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
        /// 閉じるボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 画面表示イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmRegContact_Shown(object sender, EventArgs e)
        {
            for (int row = 0; row < this.dgvTanto.RowCount; row++)
            {
                if (int.Parse(this.dgvTanto.Rows[row].Cells["ID"].Value.ToString()) == SelectTantoID)
                {
                    this.dgvTanto.Rows[row].Selected = true;

                    // CellClickイベントの引数を作成
                    DataGridViewCellEventArgs args = new(0, row);
                    // CellClickイベントハンドラーを手動で呼び出し
                    dgvTanto_CellClick(dgvTanto, args);
                    break;
                }
            }
        }
        /// <summary>
        /// データグリッドビュー　セルクリックイベント　：　DB即時登録
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvShift_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 連絡済みフラグ
            var flg = 0;

            // チェックボックスカラムかどうかを確認
            if (dgvShift.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex >= 0)
            {
                // 現在のセルの値を取得（CheckedかUncheckedか）
                DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)dgvShift.Rows[e.RowIndex].Cells["連絡"];
                bool isChecked = (bool)checkBoxCell.Value;

                // チェックボックスの状態に応じた処理
                if (isChecked)
                {
                    dgvShift.Rows[e.RowIndex].Cells["checktext"].Value = "連絡済";
                    flg = 1;
                }
                else
                {
                    dgvShift.Rows[e.RowIndex].Cells["checktext"].Value = "";
                }
            }
            else
            {
                return;
            }

            // ============================================================
            // 連絡済み情報の登録
            // ============================================================
            var user_id = 0;
            var user_name = "";

            var day = DateTime.Parse(dgvShift.Rows[e.RowIndex].Cells["date"].Value.ToString());   // 日付
            foreach (DataGridViewCell cl in dgvTanto.SelectedCells)
            {
                user_id = int.Parse(dgvTanto.Rows[cl.RowIndex].Cells["ID"].Value.ToString());           // ID
                user_name = dgvTanto.Rows[cl.RowIndex].Cells["name"].Value.ToString();                  // 名前
            }

            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    // Trn_連絡　削除
                    sb.Clear();
                    sb.AppendLine("DELETE FROM");
                    sb.AppendLine("Trn_連絡");
                    sb.AppendLine("WHERE");
                    sb.AppendLine(" tanto_id = " + user_id);
                    sb.AppendLine("AND");
                    sb.AppendLine(" day = '" + day.ToString("yyyy/MM/dd") + "'");
                    
                    clsSqlDb.DMLUpdate(sb.ToString());

                    // 連絡済み以外は処理終了
                    if (flg != 1) { return; }

                    // Trn_連絡　登録
                    sb.Clear();
                    sb.AppendLine("INSERT INTO");
                    sb.AppendLine("Trn_連絡");
                    sb.AppendLine("(");
                    sb.AppendLine(" tanto_id");
                    sb.AppendLine(",tanto_name");
                    sb.AppendLine(",day");
                    // 2025/11/12↓
                    sb.AppendLine(",ins_user_id");
                    sb.AppendLine(",ins_date");
                    sb.AppendLine(",delete_flag");
                    // 2025/11/12↑
                    sb.AppendLine(") VALUES (");
                    sb.AppendLine(user_id.ToString());
                    sb.AppendLine(",'" + user_name + "'");
                    sb.AppendLine(",'" + day.ToString("yyyy/MM/dd") + "'");
                    // 2025/11/12↓
                    sb.AppendLine("," + ClsLoginUser.StaffID);
                    sb.AppendLine(",'" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    sb.AppendLine("," + ClsPublic.FLAG_OFF);
                    // 2025/11/12↑
                    sb.AppendLine(")");

                    clsSqlDb.DMLUpdate(sb.ToString());
                }
                // 勤務表変更フラグ更新
                ClsPublic.UpdateShiftFlag(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// チェックボックスの変更を直ぐに反映する（コミットする）　これをしないとCellContentClickイベントでリアルタイムの状態を参照出来ない
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvShift_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvShift.IsCurrentCellDirty)
            {
                dgvShift.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}
