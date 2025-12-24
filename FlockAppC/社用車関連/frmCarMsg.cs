using FlockAppC.pubClass;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FlockAppC.社用車関連
{
    public partial class frmCarMsg : Form
    {
        // レコードID
        private int Id { get; set; }
        private int Row_id {  get; set; }

        private readonly StringBuilder sb = new();

        public frmCarMsg()
        {
            InitializeComponent();
        }
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCarMsg_Load(object sender, EventArgs e)
        {
            SetDgvList();
            InitializeForm();

            SetUserCmb();
            SetCarCmb();
            ShowLabel();

            DisplayList();

            this.Location = new　System.Drawing.Point(0, 0);
        }
        /// <summary>
        /// 新規ラベル表示制御
        /// </summary>
        private void ShowLabel()
        {
            if (this.Id == 0) { this.lblNew.Visible = true; }
            else { this.lblNew.Visible = false; }
        }
        /// <summary>
        /// フォームクリア
        /// </summary>
        private void InitializeForm()
        {
            this.Id = 0;
            this.Row_id = 0;
            this.rdoCar.Checked = false;
            this.rdoUser.Checked = true;
            this.cmbCar.Text = "";
            this.cmbUser.Text = "";
            this.txtMessage.Text = "";
            this.dgvList.ClearSelection();
        }
        /// <summary>
        /// 一覧初期設定
        /// </summary>
        private void SetDgvList()
        {
            // 走行記録一覧
            // DataGridViewButtonColumn col00 = new DataGridViewButtonColumn();
            DataGridViewTextBoxColumn col01 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col02 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col03 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col04 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col05 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col06 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col07 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col08 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col09 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col10 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col11 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col12 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col13 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col14 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col15 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col16 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col17 = new DataGridViewTextBoxColumn();

            // 編集ボタン
            //col00.Name = "edit";
            //col00.HeaderText = " ";
            //col00.Text = "編集";
            //col00.Width = 50;
            //col00.UseColumnTextForButtonValue = true;
            //col00.Visible = true;

            // レコードID
            col01.Name = "id";
            col01.HeaderText = "ID";
            col01.Width = 50;
            col01.Visible = false;

            // 日付
            col02.Name = "day";
            col02.HeaderText = "日付";
            col02.Width = 100;
            col02.Visible = true;

            // 社用車ID
            col03.Name = "car_id";
            col03.HeaderText = "社用車ID";
            col03.Width = 50;
            col03.Visible = false;

            // 社用車名
            col04.Name = "car_name";
            col04.HeaderText = "社用車名";
            col04.Width = 150;
            col04.Visible = true;

            // 利用者ID
            col05.Name = "used_user_id";
            col05.HeaderText = "利用者ID";
            col05.Width = 50;
            col05.Visible = false;

            // 利用者名
            col06.Name = "used_user_name";
            col06.HeaderText = "利用者名";
            col06.Width = 90;
            col06.Visible = true;

            // 区分
            col07.Name = "kbn";
            col07.HeaderText = "区分";
            col07.Width = 80;
            col07.Visible = false;

            // メッセージ
            col08.Name = "message";
            col08.HeaderText = "メッセージ";
            col08.Width = 260;
            col08.Visible = true;

            // 確認済み
            col09.Name = "confirm_flag";
            col09.HeaderText = "確認済フラグ";
            col09.Width = 90;
            col09.Visible = false;

            // 確認済み（表示用）
            col10.Name = "confirm";
            col10.HeaderText = "確認";
            col10.Width = 50;
            col10.Visible = true;

            // this.dgvList.Columns.Add(col00);
            this.dgvList.Columns.Add(col01);
            this.dgvList.Columns.Add(col02);
            this.dgvList.Columns.Add(col03);
            this.dgvList.Columns.Add(col04);
            this.dgvList.Columns.Add(col05);
            this.dgvList.Columns.Add(col06);
            this.dgvList.Columns.Add(col07);
            this.dgvList.Columns.Add(col08);
            this.dgvList.Columns.Add(col09);
            this.dgvList.Columns.Add(col10);

            //並び替えができないようにする
            foreach (DataGridViewColumn c in this.dgvList.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            this.dgvList.EnableHeadersVisualStyles = false;                                                               //Windows Color無効
            this.dgvList.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.CornflowerBlue;                   //列ヘッダ色
            this.dgvList.RowTemplate.Height = 25;                                                                         //行高さ
            this.dgvList.AllowUserToResizeColumns = false;                                                                //列幅の変更不可
            this.dgvList.AllowUserToResizeRows = false;                                                                   //行高さの変更不可
            this.dgvList.ColumnHeadersVisible = true;                                                                     //列ヘッダ非表示

            this.dgvList.Columns["day"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;              // 列ヘッダ文字位置
            this.dgvList.Columns["car_name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;         // 列ヘッダ文字位置
            this.dgvList.Columns["used_user_name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;   // 列ヘッダ文字位置
            this.dgvList.Columns["message"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;          // 列ヘッダ文字位置
            this.dgvList.Columns["confirm"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;          // 列ヘッダ文字位置

            //奇数行を黄色にする
            this.dgvList.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Moccasin;

            // 表示位置
            this.dgvList.Columns["day"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;              //セルの文字表示位置
            this.dgvList.Columns["car_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;           //セルの文字表示位置
            this.dgvList.Columns["used_user_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;     //セルの文字表示位置
            this.dgvList.Columns["message"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;            //セルの文字表示位置
            this.dgvList.Columns["confirm"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;          //セルの文字表示位置

            // フォント
            this.dgvList.Columns["day"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);            //フォント設定
            this.dgvList.Columns["car_name"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);       //フォント設定
            this.dgvList.Columns["used_user_name"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular); //フォント設定
            this.dgvList.Columns["message"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);        //フォント設定
            this.dgvList.Columns["confirm"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);        //フォント設定

            //this.dgvSelect1.ScrollBars = false;                                                                        //スクロールバー非表示
            this.dgvList.MultiSelect = false;                                                                         //複数選択
            this.dgvList.ReadOnly = true;                                                                             //読込専用
            this.dgvList.AllowUserToAddRows = false;                                                                  //行追加無効
            this.dgvList.RowHeadersVisible = false;                                                                   //行ヘッダ非表示
            this.dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;                                     //行選択時は１行全て選択状態にする
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
                    // コンボボックス用
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
                    sb.AppendLine(" zai_flag = " + ClsPublic.FLAG_ON);
                    sb.AppendLine("AND");
                    sb.AppendLine(" proxy_flag = " + ClsPublic.FLAG_ON);
                    sb.AppendLine("ORDER BY");
                    sb.AppendLine(" sort");

                    // 最初の空行
                    dr = dt.NewRow();
                    dr["Code"] = "0";
                    dr["Name"] = "";
                    dt.Rows.Add(dr);

                    // 処理改善 2025/09/02
                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
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
        /// 社用車コンボボックス
        /// </summary>
        private void SetCarCmb()
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    // コンボボックス用
                    DataRow dr;
                    DataTable dt = new();
                    dt.Columns.Add("Code");
                    dt.Columns.Add("Name");

                    // SQL編集
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" id");
                    sb.AppendLine(",car_no");
                    sb.AppendLine(",car_name");
                    sb.AppendLine("FROM");
                    sb.AppendLine(" Mst_社用車");
                    sb.AppendLine("ORDER BY");
                    sb.AppendLine(" car_no");

                    // 最初の空行
                    dr = dt.NewRow();
                    dr["Code"] = "0";
                    dr["Name"] = "";
                    dt.Rows.Add(dr);

                    // 書類改善 2025/09/02
                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        // 結果を読み込みデータテーブルへセット
                        foreach (DataRow drow in dt_val.Rows)
                        {
                            dr = dt.NewRow();
                            dr["Name"] = drow["car_no"] + ":" + drow["car_name"];
                            dr["Code"] = drow["id"];
                            dt.Rows.Add(dr);
                        }
                    }

                    // コンボボックスにデータテーブルセット
                    this.cmbCar.DataSource = dt;
                    this.cmbCar.DisplayMember = "Name";
                    this.cmbCar.ValueMember = "Code";

                    this.cmbCar.SelectedIndex = 0;
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
        /// ラジオボタンイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdo_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoCar.Checked == true) { this.cmbCar.Enabled = true; this.cmbUser.Enabled = false; }
            if (this.rdoUser.Checked == true) { this.cmbCar.Enabled = false; this.cmbUser.Enabled = true; }
        }

        private void DisplayList()
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" Trn_走行記録MSG.id");
                    sb.AppendLine(",Trn_走行記録MSG.car_id");
                    sb.AppendLine(",Mst_社用車.car_no");
                    sb.AppendLine(",Mst_社用車.car_name");
                    sb.AppendLine(",Trn_走行記録MSG.used_user_id");
                    sb.AppendLine(",Mst_社員.fullname");
                    sb.AppendLine(",Trn_走行記録MSG.day");
                    sb.AppendLine(",Trn_走行記録MSG.message");
                    sb.AppendLine(",Trn_走行記録MSG.confirm_flag");
                    sb.AppendLine(",Trn_走行記録MSG.kbn");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Trn_走行記録MSG");
                    sb.AppendLine("LEFT JOIN");
                    sb.AppendLine("Mst_社員");
                    sb.AppendLine("ON");
                    sb.AppendLine("Trn_走行記録MSG.used_user_id = Mst_社員.staff_id");
                    sb.AppendLine("LEFT JOIN");
                    sb.AppendLine("Mst_社用車");
                    sb.AppendLine("ON");
                    sb.AppendLine("Trn_走行記録MSG.car_id = Mst_社用車.id");
                    sb.AppendLine("ORDER BY");
                    sb.AppendLine(" Trn_走行記録MSG.day DESC");
                    sb.AppendLine(",Trn_走行記録MSG.used_user_id DESC");
                    sb.AppendLine(",Trn_走行記録MSG.id DESC");

                    // 処理改善 2025/09/02
                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        // 一覧クリア
                        if (dt_val.Rows.Count > 0)
                        {
                            this.dgvList.Rows.Clear();
                        }

                        var row = 0;
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            this.dgvList.Rows.Add();
                            this.dgvList.Rows[row].Cells["id"].Value = dr["id"].ToString();                                                     // id
                            this.dgvList.Rows[row].Cells["car_id"].Value = dr["car_id"].ToString();                                             // car_id
                            this.dgvList.Rows[row].Cells["car_name"].Value = dr["car_no"].ToString() + ":" + dr["car_name"].ToString();           // CarNo + CarName
                            this.dgvList.Rows[row].Cells["used_user_id"].Value = dr["used_user_id"].ToString();                                 // used_user_id
                            this.dgvList.Rows[row].Cells["used_user_name"].Value = dr["fullname"].ToString();                                   // FullName
                            this.dgvList.Rows[row].Cells["day"].Value = DateTime.Parse(dr["day"].ToString()).ToString("yyyy/MM/dd");            // day
                            this.dgvList.Rows[row].Cells["message"].Value = dr["message"].ToString();                                           // message
                            this.dgvList.Rows[row].Cells["confirm_flag"].Value = dr["confirm_flag"].ToString();                                 // confirm_flag
                            if (dr["confirm_flag"].ToString() == "0") { this.dgvList.Rows[row].Cells["confirm"].Value = "未"; }
                            else { this.dgvList.Rows[row].Cells["confirm"].Value = "済"; }
                            this.dgvList.Rows[row].Cells["kbn"].Value = dr["kbn"].ToString();                                                   // kbn
                            row++;
                        }
                    }
                    this.dgvList.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 一覧クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // ボタン列がクリックされたかを確認
            if (e.RowIndex >= 0)    // 0 はボタン列のインデックス
            {
                // ID取得
                var id = int.Parse(((DataGridView)sender).Rows[e.RowIndex].Cells["id"].Value.ToString());

                // 確認メッセージ
                // if (MessageBox.Show("ID = " + id, "確認", MessageBoxButtons.OKCancel) == DialogResult.Cancel) { return; }

                // 選択メッセージをヘッダに表示
                // 区分
                if (this.dgvList.Rows[e.RowIndex].Cells["kbn"].Value.ToString() == "0")
                {
                    this.rdoCar.Checked = true;
                }
                else
                {
                    this.rdoUser.Checked = true;
                }
                var idx = 0;
                // 社用車コンボボックス
                if (this.dgvList.Rows[e.RowIndex].Cells["car_id"].Value != null && this.dgvList.Rows[e.RowIndex].Cells["car_id"].Value.ToString() != "")
                {
                    idx = int.Parse(this.dgvList.Rows[e.RowIndex].Cells["car_id"].Value.ToString());
                    this.cmbCar.SelectedValue = idx;
                }
                else
                {
                    this.cmbCar.Text = "";
                }
                // 利用者コンボボックス
                if (this.dgvList.Rows[e.RowIndex].Cells["used_user_id"].Value != null && this.dgvList.Rows[e.RowIndex].Cells["used_user_id"].Value.ToString() != "")
                {
                    idx = int.Parse(this.dgvList.Rows[e.RowIndex].Cells["used_user_id"].Value.ToString());
                    this.cmbUser.SelectedValue = idx;
                }
                else
                {
                    this.cmbUser.Text = "";
                }
                this.txtMessage.Text = this.dgvList.Rows[e.RowIndex].Cells["message"].Value.ToString();

                this.Id = id;
                this.Row_id = e.RowIndex;
                ShowLabel();
            }
        }
        /// <summary>
        /// 新規モードボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            InitializeForm();
            ShowLabel();
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
        /// 保存ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 入力チェック
            if (this.rdoCar.Checked == true && this.cmbCar.Text == "")
            {
                MessageBox.Show("社用車が選択されていません。", "エラー", MessageBoxButtons.OK);
                return;
            }
            if (this.rdoUser.Checked == true && this.cmbUser.Text == "")
            {
                MessageBox.Show("利用者が選択されていません。", "エラー", MessageBoxButtons.OK);
                return;
            }
            if (this.txtMessage.Text == "")
            {
                MessageBox.Show("メッセージが入力されていません。", "エラー", MessageBoxButtons.OK);
                return;
            }

            // カーソル（砂時計）
            this.Cursor = Cursors.WaitCursor;
            try
            {
                // 新規 or 更新
                if (this.Id > 0)
                {
                    // 更新
                    sb.Clear();
                    sb.AppendLine("UPDATE");
                    sb.AppendLine("Trn_走行記録MSG");
                    sb.AppendLine("SET");
                    if (this.cmbCar.SelectedValue.ToString() == "0")
                    {
                        sb.AppendLine(" car_id = null");
                    }
                    else
                    {
                        sb.AppendLine(" car_id = " + this.cmbCar.SelectedValue);
                    }
                    if (this.cmbUser.SelectedValue.ToString() == "0")
                    {
                        sb.AppendLine(",used_user_id = null");
                    }
                    else
                    {
                        sb.AppendLine(",used_user_id = " + this.cmbUser.SelectedValue);
                    }
                    if (this.rdoCar.Checked == true) 
                    {
                        sb.AppendLine(",kbn = 0"); 
                    }
                    else 
                    {
                        sb.AppendLine(",kbn = 1"); 
                    }
                    sb.AppendLine(",message = '" + this.txtMessage.Text + "'");
                    // 2025/11/12↓
                    sb.AppendLine(",upd_user_id = " + ClsLoginUser.StaffID);
                    sb.AppendLine(",upd_date = '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    // 2025/11/12↑
                    sb.AppendLine("WHERE");
                    sb.AppendLine("id = " + this.Id);
                }
                else if (this.Id == 0)
                {
                    // 新規
                    sb.Clear();
                    sb.AppendLine("INSERT INTO");
                    sb.AppendLine("Trn_走行記録MSG");
                    sb.AppendLine("(");
                    sb.AppendLine(" car_id");
                    sb.AppendLine(",used_user_id");
                    sb.AppendLine(",kbn");
                    sb.AppendLine(",message");
                    sb.AppendLine(",day");
                    sb.AppendLine(",confirm_flag");
                    // 2025/11/12↓
                    sb.AppendLine(",ins_user_id");
                    sb.AppendLine(",ins_date");
                    sb.AppendLine(",delete_flag");
                    // 2025/11/12↑
                    sb.AppendLine(") VALUES (");
                    if (this.cmbCar.SelectedValue.ToString() == "0")
                    {
                        sb.AppendLine("null");
                    }
                    else
                    {
                        sb.AppendLine(this.cmbCar.SelectedValue.ToString());
                    }
                    if (this.cmbUser.SelectedValue.ToString() == "0")
                    {
                        sb.AppendLine(",null");
                    }
                    else
                    {
                        sb.AppendLine("," + this.cmbUser.SelectedValue.ToString());
                    }
                    if (this.rdoCar.Checked == true)
                    {
                        sb.AppendLine(",0");
                    }
                    else
                    {
                        sb.AppendLine(",1");
                    }
                    sb.AppendLine(",'" + this.txtMessage.Text + "'");
                    sb.AppendLine(",'" + DateTime.Now.ToString("yyyy/MM/dd")  + "'");
                    sb.AppendLine("," + ClsPublic.FLAG_OFF);
                    // 2025/11/12↓
                    sb.AppendLine("," + ClsLoginUser.StaffID);
                    sb.AppendLine(",'" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    sb.AppendLine("," + ClsPublic.FLAG_OFF);
                    // 2025/11/12↑
                    sb.AppendLine(")");
                }
                // using (clsDb cls = new clsDb(clsPublic.XSERVER_DB))
                using (ClsMySqlDb clsMySqlDb = new(ClsDbConfig.MySQLNo))
                {
                    clsMySqlDb.DMLUpdate(sb.ToString());
                }

                InitializeForm();
                DisplayList();

                MessageBox.Show("保存しました。", "結果", MessageBoxButtons.OK);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                // カーソルを戻す
                this.Cursor = Cursors.Default;
            }
        }
        /// <summary>
        /// 削除ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            // カーソル（砂時計）
            this.Cursor = Cursors.WaitCursor;

            if (MessageBox.Show("削除します。","確認",MessageBoxButtons.OKCancel) == DialogResult.Cancel) { return; }

            try
            {
                sb.Clear();
                sb.AppendLine("DELETE FROM");
                sb.AppendLine("Trn_走行記録MSG");
                sb.AppendLine("WHERE");
                sb.AppendLine("id = " + this.Id);

                using (ClsMySqlDb clsMySqlDb = new(ClsDbConfig.MySQLNo))
                {
                    clsMySqlDb.DMLUpdate(sb.ToString());
                }

                InitializeForm();
                DisplayList();

                MessageBox.Show("削除しました。", "結果", MessageBoxButtons.OK);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                // カーソルを戻す
                this.Cursor = Cursors.Default;
            }
        }
    }
}
