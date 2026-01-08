using FlockAppC.pubClass;
using FlockAppC.tblClass;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FlockAppC.勤務表
{
    public partial class frmScheduleEdit : Form
    {
        private int Select_userid {  get; set; }
        private string Select_username {  get; set; }
        private DateTime Select_day {  get; set; }

        private readonly StringBuilder sb = new();
        private readonly StringBuilder sb2 = new();

        public frmScheduleEdit()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 画面ロード処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmScheduleEdit_Load(object sender, EventArgs e)
        {
            // ====================================================
            // 承認権限ユーザー判定
            // ====================================================
            if (ClsLoginUser.ConfirmFlag == ClsPublic.FLAG_ON)
            {
                // 承認権限：有り→「承認」「解除」ボタン表示
                btnMenu1.Visible = true;
                btnMenu2.Visible = true;
            }

            // ====================================================
            // 登録ユーザー C#
            // ====================================================
            this.lblUserName.Text = ClsLoginUser.Name1;

            // ====================================================
            // 作業者一覧表示, 作業者一覧コンボボックス設定
            // ====================================================
            SetUserCmb();
            DispUserList();

            // ====================================================
            // 従業員別勤務予定一覧初期化
            // ====================================================
            InitializeUserShiftEntryList();

            // ====================================================
            // 勤務予定変更登録一覧初期化
            // ====================================================
            InitializeShiftEntryList();

            // ====================================================
            // フォントプロパティコンボボックス
            // ====================================================
            InitializeFontComboBox();

            // ====================================================
            // 表示条件コンボボックス
            // ====================================================
            this.cmbWhere.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbWhere.Items.Add("1日前から表示");
            this.cmbWhere.Items.Add("月初(21日)から表示");
            this.cmbWhere.Items.Add("承認待ち");
            this.cmbWhere.Items.Add("承認済");
            this.cmbWhere.SelectedIndex = 0;

            // ====================================================
            // 勤務予定変更情報表示
            // ====================================================
            DisplayShiftEntry();

            // クリア
            ClearFormData();

            // 従業員コンボボックス選択イベント有効
            cmbUser.SelectedIndexChanged += cmbUser_SelectedIndexChanged;

            this.Location = new System.Drawing.Point(0, 0);
        }

        /// <summary>
        /// ===============================================================================
        /// 従業員一覧表示 
        /// ===============================================================================
        /// </summary>
        private void DispUserList()
        {
            // Initialize DataGridView
            InitializeUserList();

            // 従業員一覧表示
            DisplayUser();
        }
        /// <summary>
        /// 従業員一覧(DataGridView)初期化
        /// </summary>
        private void InitializeUserList()
        {
            // カラムクリア
            dgvUserList.Columns.Clear();

            DataGridViewTextBoxColumn col01 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col02 = new DataGridViewTextBoxColumn();

            col01.Name = "id";
            col01.HeaderText = "id";
            col01.Width = 1;
            col01.Visible = false;

            col02.Name = "name";
            col02.HeaderText = "名前";
            col02.Width = 100;
            col02.Visible = true;

            this.dgvUserList.Columns.Add(col01);
            this.dgvUserList.Columns.Add(col02);

            //並び替えができないようにする
            foreach (DataGridViewColumn c in this.dgvUserList.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            this.dgvUserList.EnableHeadersVisualStyles = false;                                                                        // Windows Color無効
            this.dgvUserList.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.CornflowerBlue;                            // 列ヘッダ色
            this.dgvUserList.RowTemplate.Height = 30;                                                                                  // 行高さ
            this.dgvUserList.AllowUserToResizeColumns = false;                                                                         // 列幅の変更不可
            this.dgvUserList.AllowUserToResizeRows = false;                                                                            // 行高さの変更不可
            this.dgvUserList.ColumnHeadersVisible = false;                                                                             // 列ヘッダ非表示
            this.dgvUserList.Columns["id"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;                     // 列ヘッダ文字位置
            this.dgvUserList.Columns["name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;                   // 列ヘッダ文字位置

            // 奇数行を黄色にする
            // this.dgvUserList.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Moccasin;

            this.dgvUserList.Columns["id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;                     //セルの文字表示位置
            this.dgvUserList.Columns["name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;                   //セルの文字表示位置

            this.dgvUserList.Columns["id"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);       //フォント設定
            this.dgvUserList.Columns["name"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);     //フォント設定

            //this.dgvSelect1.ScrollBars = false;                                                                                      //スクロールバー非表示
            this.dgvUserList.MultiSelect = false;                                                                                      //複数選択
            this.dgvUserList.ReadOnly = true;                                                                                          //読込専用
            this.dgvUserList.AllowUserToAddRows = false;                                                                               //行追加無効
            this.dgvUserList.RowHeadersVisible = false;                                                                                //行ヘッダ非表示
            this.dgvUserList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;                                                  //行選択時は１行全て選択状態にする
        }
        /// <summary>
        /// 従業員一覧表示
        /// </summary>
        private void DisplayUser()
        {
            int row = 0;

            this.dgvUserList.Rows.Clear();

            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    // 在席、営業or代務 -> 在席、代務フラグON
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
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            this.dgvUserList.Rows.Add();             // 行追加
                            this.dgvUserList.Rows[row].Cells["name"].Value = dr["name1"];
                            this.dgvUserList.Rows[row].Cells["ID"].Value = dr["staff_id"];
                            row++;
                        }
                    }

                    this.dgvUserList.Columns["id"].ReadOnly = true;         // 書き込み禁止
                    this.dgvUserList.Columns["name"].ReadOnly = true;       // 書き込み禁止
                    this.dgvUserList.ClearSelection();                      // 未選択状態
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }
        /// <summary>
        /// 従業員コンボボックス
        /// </summary>
        private void SetUserCmb()
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new ClsSqlDb(ClsDbConfig.SQLServerNo))
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
        /// ===============================================================================
        /// 従業員別勤務予定一覧表示
        /// ===============================================================================
        /// </summary>
        private void DispUserShiftEntryList()
        {
            // InitializeUserShiftEntryList();

            // DisplayUserShiftEntry();
        }
        /// <summary>
        /// 従業員別勤務予定一覧(DataGridView)初期化
        /// </summary>
        private void InitializeUserShiftEntryList()
        {
            // カラムクリア
            dgvUserShiftEntryList.Columns.Clear();

            DataGridViewTextBoxColumn col01 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col02 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col03 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col04 = new DataGridViewTextBoxColumn();

            col01.Name = "changedate";
            col01.HeaderText = "日付";
            col01.Width = 90;
            col01.Visible = true;

            col02.Name = "value";
            col02.HeaderText = "予定";
            col02.Width = 130;
            col02.Visible = true;

            col03.Name = "userid";
            col03.HeaderText = "従業員ID";
            col03.Width = 100;
            col03.Visible = false;

            col04.Name = "date";
            col04.HeaderText = "日付";
            col04.Width = 100;
            col04.Visible = false;

            this.dgvUserShiftEntryList.Columns.Add(col01);
            this.dgvUserShiftEntryList.Columns.Add(col02);
            this.dgvUserShiftEntryList.Columns.Add(col03);
            this.dgvUserShiftEntryList.Columns.Add(col04);

            //並び替えができないようにする
            foreach (DataGridViewColumn c in this.dgvUserShiftEntryList.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            this.dgvUserShiftEntryList.EnableHeadersVisualStyles = false;                                                                        // Windows Color無効
            this.dgvUserShiftEntryList.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.CornflowerBlue;                            // 列ヘッダ色
            this.dgvUserShiftEntryList.RowTemplate.Height = 60;                                                                                  // 行高さ
            this.dgvUserShiftEntryList.AllowUserToResizeColumns = false;                                                                         // 列幅の変更不可
            this.dgvUserShiftEntryList.AllowUserToResizeRows = false;                                                                            // 行高さの変更不可
            this.dgvUserShiftEntryList.ColumnHeadersVisible = true;                                                                              // 列ヘッダ非表示
            this.dgvUserShiftEntryList.Columns["changedate"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;                     // 列ヘッダ文字位置
            this.dgvUserShiftEntryList.Columns["value"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;                  // 列ヘッダ文字位置

            // 奇数行を黄色にする
            // this.dgvUserList.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Moccasin;

            this.dgvUserShiftEntryList.Columns["changedate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;             //セルの文字表示位置
            this.dgvUserShiftEntryList.Columns["value"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;                  //セルの文字表示位置

            this.dgvUserShiftEntryList.Columns["changedate"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);  //フォント設定
            this.dgvUserShiftEntryList.Columns["value"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);       //フォント設定

            // Column1列のセルのテキストを折り返して表示する
            this.dgvUserShiftEntryList.Columns["changedate"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvUserShiftEntryList.Columns["value"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            //this.dgvSelect1.ScrollBars = false;                                                                                                //スクロールバー非表示
            this.dgvUserShiftEntryList.MultiSelect = false;                                                                                      //複数選択
            this.dgvUserShiftEntryList.ReadOnly = true;                                                                                          //読込専用
            this.dgvUserShiftEntryList.AllowUserToAddRows = false;                                                                               //行追加無効
            this.dgvUserShiftEntryList.RowHeadersVisible = false;                                                                                //行ヘッダ非表示
            this.dgvUserShiftEntryList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;                                                  //行選択時は１行全て選択状態にする
        }
        /// <summary>
        /// 従業員別勤務予定一覧表示（今処理はカラ）
        /// </summary>
        private void DisplayUserShiftEntry(int p_row = 0, int p_col = 0)
        {
            // 従業員ID、日付取得
            int userid = int.Parse(this.dgvUserList.Rows[p_row].Cells[p_col].Value.ToString());
            DateTime day = this.dtpDate.Value;
            DateTime to_day = day.AddDays(10);

            int row = 0;

            try
            {
                // SQL Server
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    // 指定日付～10日後迄のデータを取得
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("DISTINCT");
                    sb.AppendLine(" Trn_勤務表シフト情報.tanto_id");
                    sb.AppendLine(",Trn_勤務表シフト情報.day");
                    sb.AppendLine(",Trn_勤務表シフト情報.back_color");
                    sb.AppendLine(",Trn_勤務表シフト情報.font_size");
                    sb.AppendLine(",Trn_勤務表シフト情報.font_color");
                    sb.AppendLine(",Trn_勤務表シフト情報.font_bold");
                    sb.AppendLine(",Trn_勤務表シフト情報.value");
                    sb.AppendLine(",Trn_勤務表シフト変更.confirm_flag");
                    sb.AppendLine(",Trn_勤務表シフト変更.delete_flag");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Trn_勤務表シフト情報");
                    sb.AppendLine("LEFT JOIN");
                    sb.AppendLine("Trn_勤務表シフト変更");
                    sb.AppendLine("ON");
                    sb.AppendLine("Trn_勤務表シフト情報.tanto_id = Trn_勤務表シフト変更.tanto_id");
                    sb.AppendLine("AND");
                    sb.AppendLine("Trn_勤務表シフト情報.day = Trn_勤務表シフト変更.day");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("Trn_勤務表シフト情報.tanto_id = " + userid);
                    sb.AppendLine("AND");
                    sb.AppendLine("Trn_勤務表シフト情報.day >= '" + day.ToString("yyyy/MM/dd") + "'");
                    sb.AppendLine("AND");
                    sb.AppendLine("Trn_勤務表シフト情報.day <= '" + to_day.ToString("yyyy/MM/dd") + "'");
                    sb.AppendLine("ORDER BY");
                    sb.AppendLine("Trn_勤務表シフト情報.day");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        // 一覧クリア
                        this.dgvUserShiftEntryList.Rows.Clear();

                        foreach (DataRow dr in dt_val.Rows)
                        {
                            // 削除レコードは飛ばす
                            if (dr["delete_flag"].ToString() == ClsPublic.FLAG_ON.ToString()) { continue; }

                            this.dgvUserShiftEntryList.Rows.Add();
                            this.dgvUserShiftEntryList.Rows[row].Cells["changedate"].Value = DateTime.Parse(dr["day"].ToString()).ToString("MM/dd") + Environment.NewLine + "(" + DateTime.Parse(dr["day"].ToString()).ToString("dddd") + ")";
                            this.dgvUserShiftEntryList.Rows[row].Cells["userid"].Value = dr["tanto_id"].ToString();
                            this.dgvUserShiftEntryList.Rows[row].Cells["value"].Value = dr["value"].ToString().Replace("\n", Environment.NewLine);
                            this.dgvUserShiftEntryList.Rows[row].Cells["date"].Value = dr["day"];

                            // 休日、土曜、日曜判定
                            if (ClsPublic.CheckHoliday(DateTime.Parse(dr["day"].ToString())) == true)
                            {
                                // 休日
                                this.dgvUserShiftEntryList.Rows[row].DefaultCellStyle.BackColor = System.Drawing.Color.LightPink;
                            }
                            else if (this.dgvUserShiftEntryList.Rows[row].Cells["changedate"].Value.ToString().IndexOf("土曜") > 0)
                            {
                                // 土曜
                                this.dgvUserShiftEntryList.Rows[row].DefaultCellStyle.BackColor = System.Drawing.Color.LightSteelBlue;
                            }
                            else if (this.dgvUserShiftEntryList.Rows[row].Cells["changedate"].Value.ToString().IndexOf("日曜") > 0)
                            {
                                // 日曜
                                this.dgvUserShiftEntryList.Rows[row].DefaultCellStyle.BackColor = System.Drawing.Color.Pink;
                            }
                            else
                            {
                                this.dgvUserShiftEntryList.Rows[row].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                            }

                            //// 承認待ちの場合、色を変える
                            if (dr["confirm_flag"] != null)
                            {
                                if (dr["confirm_flag"].ToString() == ClsPublic.FLAG_OFF.ToString())
                                {
                                    this.dgvUserShiftEntryList.Rows[row].DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;
                                }
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
        /// ===============================================================================
        /// 勤務予定変更登録一覧(DataGridView)初期化
        /// ===============================================================================
        /// </summary>
        private void InitializeShiftEntryList()
        {
            // カラムクリア
            dgvShiftEntryList.Columns.Clear();

            DataGridViewCheckBoxColumn col01 = new DataGridViewCheckBoxColumn();
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

            col01.Name = "選択";
            col01.HeaderText = "選択";
            col01.Width = 25;
            col01.Visible = true;
            col01.ReadOnly = false;

            col02.Name = "changedate";
            col02.HeaderText = "日付";
            col02.Width = 85;
            col02.Visible = true;

            col03.Name = "username";
            col03.HeaderText = "担当";
            col03.Width = 60;
            col03.Visible = true;

            col04.Name = "before";
            col04.HeaderText = "変更前";
            col04.Width = 135;
            col04.Visible = true;

            col05.Name = "after";
            col05.HeaderText = "変更後";
            col05.Width = 135;
            col05.Visible = true;

            col06.Name = "regdate";
            col06.HeaderText = "登録日";
            col06.Width = 85;
            col06.Visible = true;

            col07.Name = "reguser";
            col07.HeaderText = "登録者";
            col07.Width = 60;
            col07.Visible = true;

            col08.Name = "confirm";
            col08.HeaderText = "承認";
            col08.Width = 80;
            col08.Visible = true;

            col09.Name = "day";
            col09.HeaderText = "日付(非表示)";
            col09.Width = 10;
            col09.Visible = false;

            col10.Name = "userid";
            col10.HeaderText = "ID";
            col10.Width = 10;
            col10.Visible = false;

            col11.Name = "comment";
            col11.HeaderText = "備考";
            col11.Width = 250;
            col11.Visible = true;

            this.dgvShiftEntryList.Columns.Add(col01);
            this.dgvShiftEntryList.Columns.Add(col02);
            this.dgvShiftEntryList.Columns.Add(col03);
            this.dgvShiftEntryList.Columns.Add(col04);
            this.dgvShiftEntryList.Columns.Add(col05);
            this.dgvShiftEntryList.Columns.Add(col06);
            this.dgvShiftEntryList.Columns.Add(col07);
            this.dgvShiftEntryList.Columns.Add(col08);
            this.dgvShiftEntryList.Columns.Add(col09);
            this.dgvShiftEntryList.Columns.Add(col10);
            this.dgvShiftEntryList.Columns.Add(col11);

            //並び替えができないようにする
            foreach (DataGridViewColumn c in this.dgvShiftEntryList.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            this.dgvShiftEntryList.EnableHeadersVisualStyles = false;                                                                        // Windows Color無効
            this.dgvShiftEntryList.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.CornflowerBlue;                            // 列ヘッダ色
            this.dgvShiftEntryList.RowTemplate.Height = 60;                                                                                  // 行高さ
            this.dgvShiftEntryList.AllowUserToResizeColumns = false;                                                                         // 列幅の変更不可
            this.dgvShiftEntryList.AllowUserToResizeRows = false;                                                                            // 行高さの変更不可
            this.dgvShiftEntryList.ColumnHeadersVisible = true;                                                                              // 列ヘッダ非表示
            this.dgvShiftEntryList.Columns["選択"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;                   // 列ヘッダ文字位置
            this.dgvShiftEntryList.Columns["changedate"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;             // 列ヘッダ文字位置
            this.dgvShiftEntryList.Columns["username"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;               // 列ヘッダ文字位置
            this.dgvShiftEntryList.Columns["before"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;                 // 列ヘッダ文字位置
            this.dgvShiftEntryList.Columns["after"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;                  // 列ヘッダ文字位置
            this.dgvShiftEntryList.Columns["regdate"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;                // 列ヘッダ文字位置
            this.dgvShiftEntryList.Columns["reguser"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;                // 列ヘッダ文字位置
            this.dgvShiftEntryList.Columns["confirm"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;                // 列ヘッダ文字位置
            this.dgvShiftEntryList.Columns["comment"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;                // 列ヘッダ文字位置

            // 奇数行を黄色にする
            this.dgvShiftEntryList.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Moccasin;

            this.dgvShiftEntryList.Columns["changedate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;             //セルの文字表示位置
            this.dgvShiftEntryList.Columns["username"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;               //セルの文字表示位置
            this.dgvShiftEntryList.Columns["before"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;                 //セルの文字表示位置
            this.dgvShiftEntryList.Columns["after"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;                  //セルの文字表示位置
            this.dgvShiftEntryList.Columns["regdate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;                //セルの文字表示位置
            this.dgvShiftEntryList.Columns["reguser"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;                //セルの文字表示位置
            this.dgvShiftEntryList.Columns["confirm"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;                //セルの文字表示位置
            this.dgvShiftEntryList.Columns["comment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;                  //セルの文字表示位置

            this.dgvShiftEntryList.Columns["changedate"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);  //フォント設定
            this.dgvShiftEntryList.Columns["username"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);  //フォント設定
            this.dgvShiftEntryList.Columns["before"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);  //フォント設定
            this.dgvShiftEntryList.Columns["after"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);  //フォント設定
            this.dgvShiftEntryList.Columns["regdate"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);  //フォント設定
            this.dgvShiftEntryList.Columns["reguser"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);  //フォント設定
            this.dgvShiftEntryList.Columns["confirm"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);  //フォント設定
            this.dgvShiftEntryList.Columns["comment"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);  //フォント設定

            // Column1列のセルのテキストを折り返して表示する
            this.dgvShiftEntryList.Columns["changedate"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvShiftEntryList.Columns["regdate"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvShiftEntryList.Columns["before"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvShiftEntryList.Columns["after"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            //this.dgvSelect1.ScrollBars = false;                                                                                                //スクロールバー非表示
            this.dgvShiftEntryList.MultiSelect = false;                                                                                      //複数選択
            this.dgvShiftEntryList.ReadOnly = false;                                                                                         //読込専用
            this.dgvShiftEntryList.AllowUserToAddRows = false;                                                                               //行追加無効
            this.dgvShiftEntryList.RowHeadersVisible = false;                                                                                //行ヘッダ非表示
            this.dgvShiftEntryList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;                                                  //行選択時は１行全て選択状態にする

            // ==========================================================================
            //セルの上と左を二重線のくぼんだ境界線にし、
            //下と右を一重線のくぼんだ境界線にする
            // ==========================================================================
            this.dgvShiftEntryList.AdvancedCellBorderStyle.Top =
                DataGridViewAdvancedCellBorderStyle.InsetDouble;
            this.dgvShiftEntryList.AdvancedCellBorderStyle.Right =
                DataGridViewAdvancedCellBorderStyle.Inset;
            this.dgvShiftEntryList.AdvancedCellBorderStyle.Bottom =
                DataGridViewAdvancedCellBorderStyle.Inset;
            this.dgvShiftEntryList.AdvancedCellBorderStyle.Left =
                DataGridViewAdvancedCellBorderStyle.InsetDouble;


        }
        /// <summary>
        /// ===============================================================================
        /// 勤務予定変更登録一覧表示
        /// ===============================================================================
        /// </summary>
        private void DisplayShiftEntry()
        {
            int row = 0;
            int disptype = 0;

            // 1日前の日付を取得（デフォルト）
            DateTime today = DateTime.Now;
            DateTime yesterday = today.AddDays(-1);
            
            sb2.Clear();
            sb2.Append(yesterday.ToString("yyyy/MM/dd"));

            if (this.cmbWhere.Text == "月初(21日)から表示")
            {
                // 月初からの場合はマスターから取得
                // 勤務表環境設定情報
                ClsConfig cls = new(1);
                sb2.Length = 0;
                sb2.Append(cls.StartDate);
                cls = null;
            }
            if (this.cmbWhere.Text == "承認待ち") { disptype = 1; }
            if (this.cmbWhere.Text == "承認済") { disptype = 2; }

            // SQL Server
            using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
            {
                sb.Clear();
                sb.AppendLine("SELECT");
                sb.AppendLine(" day");
                sb.AppendLine(",tanto_id");
                sb.AppendLine(",tanto_name");
                sb.AppendLine(",before_content");
                sb.AppendLine(",after_content");
                sb.AppendLine(",reg_date");
                sb.AppendLine(",reg_user_name");
                sb.AppendLine(",confirm_flag");
                sb.AppendLine(",comment");
                sb.AppendLine("FROM");
                sb.AppendLine("Trn_勤務表シフト変更");
                sb.AppendLine("WHERE");
                sb.AppendLine("delete_flag != " + ClsPublic.FLAG_ON);

                // 従業員の指定ありか判定
                if (this.cmbUser.SelectedIndex >= 0 && int.Parse(this.cmbUser.SelectedIndex.ToString()) != 0)
                {
                    var id = int.Parse(this.cmbUser.SelectedValue.ToString());
                    sb.AppendLine("AND");
                    sb.AppendLine("tanto_id = " + id);
                }

                if (disptype == 1)
                {
                    // 承認待ち
                    sb.AppendLine("AND");
                    sb.AppendLine("confirm_flag = " + ClsPublic.FLAG_OFF);
                }
                else if (disptype == 2)
                {
                    // 承認済
                    sb.AppendLine("AND");
                    sb.AppendLine("day >= '" + sb2.ToString() + "'");
                    sb.AppendLine("AND");
                    sb.AppendLine("confirm_flag = " + ClsPublic.FLAG_ON);
                }
                else
                {
                    sb.AppendLine("AND");
                    sb.AppendLine("day >= '" + sb2.ToString() + "'");
                }
                sb.AppendLine("ORDER BY");
                sb.AppendLine(" day");
                sb.AppendLine(",tanto_id");

                using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                {
                    this.dgvShiftEntryList.Rows.Clear();

                    foreach (DataRow dr in dt_val.Rows)
                    {
                        this.dgvShiftEntryList.Rows.Add();
                        this.dgvShiftEntryList.Rows[row].Cells[0].Value = false;
                        this.dgvShiftEntryList.Rows[row].Cells["changedate"].Value = DateTime.Parse(dr["day"].ToString()).ToString("MM/dd") + Environment.NewLine + "(" + DateTime.Parse(dr["day"].ToString()).ToString("dddd") + ")";
                        this.dgvShiftEntryList.Rows[row].Cells["username"].Value = dr["tanto_name"].ToString();
                        this.dgvShiftEntryList.Rows[row].Cells["before"].Value = dr["before_content"].ToString();
                        this.dgvShiftEntryList.Rows[row].Cells["after"].Value = dr["after_content"].ToString();
                        this.dgvShiftEntryList.Rows[row].Cells["regdate"].Value = DateTime.Parse(dr["reg_date"].ToString()).ToString("MM/dd") + Environment.NewLine + "(" + DateTime.Parse(dr["reg_date"].ToString()).ToString("dddd") + ")";
                        this.dgvShiftEntryList.Rows[row].Cells["reguser"].Value = dr["reg_user_name"].ToString();
                        if (int.Parse(dr["confirm_flag"].ToString()) == ClsPublic.FLAG_ON) { this.dgvShiftEntryList.Rows[row].Cells["confirm"].Value = "承認済"; }
                        else
                        {
                            this.dgvShiftEntryList.Rows[row].Cells["confirm"].Value = "承認待ち";
                            // 承認待ちの色を変える
                            this.dgvShiftEntryList.Rows[row].DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;
                        }
                        this.dgvShiftEntryList.Rows[row].Cells["day"].Value = DateTime.Parse(dr["day"].ToString()).ToString("yyyy/MM/dd");
                        this.dgvShiftEntryList.Rows[row].Cells["userid"].Value = dr["tanto_id"].ToString();
                        this.dgvShiftEntryList.Rows[row].Cells["comment"].Value = dr["comment"].ToString();
                        row++;
                    }
                }

                this.dgvShiftEntryList.Columns[1].ReadOnly = true;                         // 書き込み禁止
                this.dgvShiftEntryList.ClearSelection();
            }
        }
        /// <summary>
        /// ===============================================================================
        /// フォントプロパティコンボボックス
        /// ===============================================================================
        /// </summary>
        private void InitializeFontComboBox()
        {
            // フォントサイズ
            this.cmbFontSize.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbFontSize.Items.Add("24");
            this.cmbFontSize.Items.Add("26");
            this.cmbFontSize.Items.Add("28");
            this.cmbFontSize.Items.Add("36");
            this.cmbFontSize.Items.Add("48");
            this.cmbFontSize.SelectedIndex = 3;

            // フォントカラー
            this.cmbFontColor.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbFontColor.Items.Add("Black");
            this.cmbFontColor.Items.Add("Red");
            this.cmbFontColor.Items.Add("Blue");
            this.cmbFontColor.SelectedIndex = 0;

            // フォント太字
            this.cmbFontBold.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbFontBold.Items.Add("普通");
            this.cmbFontBold.Items.Add("太字");
            this.cmbFontBold.SelectedIndex = 0;

            // バックカラー
            this.cmbBackColor.DrawMode = DrawMode.OwnerDrawFixed;
            this.cmbBackColor.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbBackColor.Items.Add("");
            this.cmbBackColor.Items.Add("Yellow");
            this.cmbBackColor.Items.Add("Orange");
            // DrawItemイベントハンドラを設定
            cmbBackColor.DrawItem += new DrawItemEventHandler(cmbBackColor_DrawItem);
            this.cmbBackColor.SelectedIndex = 0;
        }
        /// <summary>
        /// バックカラー設定（コンボボックス）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbBackColor_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            // 背景色の設定
            e.DrawBackground();

            // 項目のテキスト取得
            string itemText = cmbBackColor.Items[e.Index].ToString();

            // 背景色をアイテムごとに変更
            System.Drawing.Color backgroundColor;

            if (itemText == "Yellow") {  backgroundColor = System.Drawing.Color.Yellow; }
            else if (itemText == "Orange") { backgroundColor = System.Drawing.Color.Orange; }
            else { backgroundColor  = SystemColors.Window; }

            // 背景を塗りつぶす
            e.Graphics.FillRectangle(new SolidBrush(backgroundColor), e.Bounds);

            // テキストを描画
            e.Graphics.DrawString(itemText, e.Font, Brushes.Black, e.Bounds);

            // フォーカスがある場合に枠線を描画
            e.DrawFocusRectangle();
        }
        /// <summary>
        /// フォントカラー（コンボボックス）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbFontColor_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            Graphics grfx = e.Graphics;
            System.Drawing.Rectangle rect = e.Bounds;

            switch(e.Index)
            {
                case 0:
                    grfx.DrawString(cmbFontColor.Items[e.Index].ToString(), e.Font, new SolidBrush(System.Drawing.Color.Black), rect);
                    break;
                case 1:
                    grfx.DrawString(cmbFontColor.Items[e.Index].ToString(), e.Font, new SolidBrush(System.Drawing.Color.Red), rect);
                    break;
                case 2:
                    grfx.DrawString(cmbFontColor.Items[e.Index].ToString(), e.Font, new SolidBrush(System.Drawing.Color.Blue), rect);
                    break;
                default:
                    break;
            }
            e.DrawFocusRectangle();
        }

        /// <summary>
        /// ===============================================================================
        /// 表示条件変更コンボボックス
        /// ===============================================================================
        /// 表示条件変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbWhere_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayShiftEntry();
        }
        /// <summary>
        /// 従業員コンボボックス選択イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayShiftEntry();
        }

        /// <summary>
        /// ===============================================================================
        /// フォントプロパティコンボボックスイベント
        /// ===============================================================================
        /// フォントサイズ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetFontProperty();
        }
        /// <summary>
        /// フォントカラー
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbFontColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetFontProperty();
        }
        /// <summary>
        /// フォント　太字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbFontBold_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetFontProperty();
        }
        /// <summary>
        /// バックカラー
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbBackColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetFontProperty();
        }
        /// <summary>
        /// フォントプロパティ選択コンボボックスの選択解除
        /// </summary>
        private void UnSelectFontComboBox()
        {
            this.cmbBackColor.SelectedIndex = 0;
            this.cmbFontSize.SelectedIndex = 3;
            this.cmbFontColor.SelectedIndex = 0;
            this.cmbFontBold.SelectedIndex = 0;
        }
        /// <summary>
        /// フォントプロパティ設定
        /// </summary>
        private void SetFontProperty()
        {
            switch(this.cmbFontSize.SelectedIndex)
            {
                case 0:
                    this.txtShiftEntry.Font = new System.Drawing.Font("游ゴシック", 8, FontStyle.Regular);
                    break;
                case 1:
                    this.txtShiftEntry.Font = new System.Drawing.Font("游ゴシック", 9, FontStyle.Regular);
                    break;
                case 2:
                    this.txtShiftEntry.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);
                    break;
                case 3:
                    this.txtShiftEntry.Font = new System.Drawing.Font("游ゴシック", 12, FontStyle.Regular);
                    break;
                case 4:
                    this.txtShiftEntry.Font = new System.Drawing.Font("游ゴシック", 14, FontStyle.Regular);
                    break;
                default:
                    this.txtShiftEntry.Font = new System.Drawing.Font("游ゴシック", 12, FontStyle.Regular);
                    break;
            }

            switch(this.cmbFontColor.SelectedIndex)
            {
                case 0:
                    this.txtShiftEntry.ForeColor = System.Drawing.Color.Black;
                    break;
                case 1:
                    this.txtShiftEntry.ForeColor = System.Drawing.Color.Red;
                    break;
                case 2:
                    this.txtShiftEntry.ForeColor = System.Drawing.Color.Blue;
                    break;
                default:
                    this.txtShiftEntry.ForeColor = System.Drawing.Color.Black;
                    break;
            }

            switch (this.cmbBackColor.SelectedIndex)
            {
                case 0:
                    this.txtShiftEntry.BackColor = SystemColors.Window;
                    break;
                case 1:
                    this.txtShiftEntry.BackColor = System.Drawing.Color.Yellow;
                    break;
                case 2:
                    this.txtShiftEntry.BackColor = System.Drawing.Color.Orange;
                    break;
                default:
                    this.txtShiftEntry.BackColor = SystemColors.Window;
                    break;
            }

            // 標準の場合は処理終了
            if (this.cmbFontBold.SelectedIndex == 0) { return; }

            // 表示に反映させる
            // 現在のフォントを覚えておく
            System.Drawing.Font oldFont = this.txtShiftEntry.Font;
            // 現在のフォントにBoldを付加したフォントを作成する
            // なおBoldを取り消す場合は、「oldFont.Style And Not FontStyle.Bold」とする
            System.Drawing.Font newFont = new System.Drawing.Font(oldFont, oldFont.Style | FontStyle.Bold);

            // Boldを付加したフォントを設定する
            txtShiftEntry.Font = newFont;
            // 前のフォントを解放する
            oldFont.Dispose();
        }

        /// <summary>
        /// ===============================================================================
        /// 従業員クリック
        /// ===============================================================================
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvUserList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 担当者シフト予定一覧クリア
            dgvUserShiftEntryList.Rows.Clear();

            // クリア
            ClearFormData();

            // 担当者シフト予定一覧表示
            // DisplayUserShiftEntry(e.RowIndex, e.ColumnIndex + 1);
            DisplayUserShiftEntry(e.RowIndex, e.ColumnIndex - 1);

            this.dgvUserShiftEntryList.ClearSelection();
            this.dgvShiftEntryList.ClearSelection();

            // 編集モード非表示
            this.lblUpdate.Visible = false;

            // 編集モード：編集可能
            SetConfirmMode(0);

            // フォント選択解除
            UnSelectFontComboBox();
        }
        /// <summary>
        /// ===============================================================================
        /// 担当者勤務予定クリック　登録済チェック、編集エリアに表示等
        /// ===============================================================================
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvUserShiftEntryList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 従業員コンボボックス
            this.cmbUser.SelectedIndex = 0;

            // 従業員ID、日付取得
            int userid = int.Parse(this.dgvUserShiftEntryList.Rows[e.RowIndex].Cells[2].Value.ToString());
            DateTime day = DateTime.Parse(this.dgvUserShiftEntryList.Rows[e.RowIndex].Cells[3].Value.ToString());

            try
            {
                // SQL Server
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    // 変更が既に登録済みか確認
                    var result = CheckScheduleChangeData(day, userid);
                    switch(result)
                    {
                        case 1:
                            SelectScheduleChangeList(day, userid);
                            SetConfirmMode(0);
                            // this.lblWarning.Text = "登録済" + Environment.NewLine + "[承認待ち]";
                            this.lblWarning.Text = "[承認待ち]";
                            break;
                        case 2:
                            SelectScheduleChangeList(day, userid);
                            // SetConfirmMode(1);
                            SetConfirmMode(0);          // 承認済でも変更が出来るようにする  
                            // this.lblWarning.Text = "登録済" + Environment.NewLine + "[承認済]";
                            this.lblWarning.Text = "[承認済]";
                            break;
                        default:
                            SetConfirmMode(0);
                            this.lblWarning.Text = "";
                            break;
                    }

                    // 従業員IDと日付からシフト予定を取得し、画面に表示
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" value");
                    sb.AppendLine(",day");
                    sb.AppendLine(",tanto_id");
                    sb.AppendLine(",tanto_name");
                    sb.AppendLine(",font_size");
                    sb.AppendLine(",font_color");
                    sb.AppendLine(",font_bold");
                    sb.AppendLine(",back_color");
                    sb.AppendLine(",comment");
                    sb.AppendLine("FROM");
                    sb.AppendLine(" Trn_勤務表シフト情報");
                    sb.AppendLine("WHERE");
                    sb.AppendLine(" tanto_id = " + userid);
                    sb.AppendLine("AND");
                    sb.AppendLine(" day = '" + day.ToString("yyyy/MM/dd") + "'");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            // シフト内容
                            this.txtShiftEntry.Text = dr["value"].ToString().Replace("\n", Environment.NewLine);

                            // コメント
                            this.txtMemo.Text = dr["comment"].ToString();

                            // 従業員ID、日付を保持
                            this.Select_userid = userid;
                            this.Select_username = dr["tanto_name"].ToString();
                            this.Select_day = day;

                            // 背景色
                            switch (dr["back_color"].ToString())
                            {
                                case "":
                                    cmbBackColor.SelectedIndex = 0;
                                    break;
                                case "Yellow":
                                    cmbBackColor.SelectedIndex = 1;
                                    break;
                                case "Orange":
                                    cmbBackColor.SelectedIndex = 2;
                                    break;
                                default:
                                    cmbBackColor.SelectedIndex = 0;
                                    break;
                            }

                            // フォントカラー
                            switch (dr["font_color"].ToString())
                            {
                                case "Black":
                                    cmbFontColor.SelectedIndex = 0;
                                    break;
                                case "Red":
                                    cmbFontColor.SelectedIndex = 1;
                                    break;
                                case "Blue":
                                    cmbFontColor.SelectedIndex = 2;
                                    break;
                                default:
                                    cmbFontColor.SelectedIndex = 0;
                                    break;
                            }

                            // フォントサイズ
                            switch (dr["font_size"].ToString())
                            {
                                case "24":
                                    cmbFontSize.SelectedIndex = 0;
                                    break;
                                case "26":
                                    cmbFontSize.SelectedIndex = 1;
                                    break;
                                case "28":
                                    cmbFontSize.SelectedIndex = 2;
                                    break;
                                case "36":
                                    cmbFontSize.SelectedIndex = 3;
                                    break;
                                case "48":
                                    cmbFontSize.SelectedIndex = 4;
                                    break;
                                default:
                                    cmbFontSize.SelectedIndex = 3;
                                    break;
                            }

                            //フォント太字
                            switch (dr["back_color"].ToString())
                            {
                                case "普通":
                                    cmbFontBold.SelectedIndex = 0;
                                    break;
                                case "太字":
                                    cmbFontBold.SelectedIndex = 1;
                                    break;
                                default:
                                    cmbFontBold.SelectedIndex = 0;
                                    break;
                            }

                            // 未選択状態に
                            if (result == 0) { this.dgvShiftEntryList.ClearSelection(); }
                            else
                            {
                                // 選択行が有る場合の処理（過去の変更データは一覧に表示されていないケースに対応）
                                if (dgvShiftEntryList.CurrentCell != null && dgvShiftEntryList.SelectedRows.Count > 0)
                                {
                                    // 選択された行のインデックスを取得
                                    int selectedRowIndex = dgvShiftEntryList.SelectedRows[0].Index;

                                    // データグリッドビューに表示される行数の半分を計算
                                    int visibleRowCount = dgvShiftEntryList.DisplayedRowCount(false) / 2;

                                    // 中心に表示するようにスクロール
                                    int scrollToRowIndex = Math.Max(0, selectedRowIndex - visibleRowCount);
                                    dgvShiftEntryList.FirstDisplayedScrollingRowIndex = scrollToRowIndex;

                                }
                                else
                                {
                                    MessageBox.Show("画面右の一覧（変更内容一覧）の表示を「月初(21日)から表示」にしてください。", "警告", MessageBoxButtons.OK);
                                    return;
                                }
                            }

                            // 新規モード　（要見直し）
                            this.lblUpdate.Visible = false;

                            // メモ登録ボタン
                            // this.btnRegMemo.Enabled = true;

                            break;
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
        /// シフト変更一覧の任意の行を選択状態にする
        /// </summary>
        /// <param name="p_day"></param>
        /// <param name="p_id"></param>
        private void SelectScheduleChangeList(DateTime p_day, int p_id)
        {
            for (var row = 0; row < this.dgvShiftEntryList.Rows.Count; row++)
            {
                // 日付と従業員ＩＤが一致する行を選択状態にする
                if (DateTime.Parse(this.dgvShiftEntryList.Rows[row].Cells["day"].Value.ToString()) == p_day &&
                    int.Parse(this.dgvShiftEntryList.Rows[row].Cells["userid"].Value.ToString()) == p_id)
                {
                    this.dgvShiftEntryList.Rows[row].Selected = true;
                    break;
                }
            }
        }
        /// <summary>
        /// ===============================================================================
        /// 変更登録一覧クリック
        /// ===============================================================================
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvShiftEntryList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // クリックされたセルのRow/Col取得
            var row = e.RowIndex;
            var col = e.ColumnIndex + 1;

            // 従業員ID、日付クリア
            Select_userid = 0;
            Select_username = "";
            Select_day = DateTime.Parse("1900/01/01");

            // 処理前のチェック
            if (row < 0) { return; }        // グリッド外
            if (this.dgvShiftEntryList.Rows[row].Cells["username"].Value.ToString() == "ｺﾒﾝﾄ")
            {
                MessageBox.Show("備考(担当者がｺﾒﾝﾄのもの)はメニュー「備考入力」から編集してください。", "インフォメーション", MessageBoxButtons.OK);
                return;
            }

            // 勤務表シフト変更データ取得
            var userid = int.Parse(this.dgvShiftEntryList.Rows[row].Cells["userid"].Value.ToString());
            var username = this.dgvShiftEntryList.Rows[row].Cells["username"].Value.ToString().Replace(" ", "");
            var day = DateTime.Parse(this.dgvShiftEntryList.Rows[row].Cells["day"].Value.ToString());
            ClsTrnScheduleChange clsTrn = new();
            clsTrn.Select(day, userid);

            // 従業員ID、日付保持
            Select_userid = userid;
            Select_username = username;
            Select_day = day;

            // 画面表示
            this.dtpDate.Value = clsTrn.Day;                                                        // 日付
            this.txtShiftEntry.Text = clsTrn.AfterContent.Replace("\n", Environment.NewLine);       // 変更内容
                                                                                                    // this.txtMemo.Text = clsTrn.Comment;                                                     // コメント 　コメントはシフト情報から取得

            #region "勤務表シフト情報コメント（メモ）取得"
            try
            {
                var memo = "";

                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" comment");
                    sb.AppendLine("FROM");
                    sb.AppendLine(" Trn_勤務表シフト情報");
                    sb.AppendLine("WHERE");
                    sb.AppendLine(" day = '" + Select_day.ToString("yyyy/MM/dd") + "'");
                    sb.AppendLine("AND");
                    sb.AppendLine(" tanto_id = " + Select_userid);

                    using(DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            memo = dr["comment"].ToString();
                            break;
                        }
                    }

                }
                // メモ表示
                this.txtMemo.Text = memo;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            #endregion

            #region "フォント属性設定"
            // フォント属性
            switch (clsTrn.AfterBackColor)
            {
                case "":
                    this.cmbBackColor.SelectedIndex = 0;
                    break;
                case "Yellow":
                    this.cmbBackColor.SelectedIndex = 1;
                    break;
                case "Orange":
                    this.cmbBackColor.SelectedIndex = 2;
                    break;
                default:
                    this.cmbBackColor.SelectedIndex = 0;
                    break;
            }
            switch (clsTrn.AfterFontColor)
            {
                case "Black":
                    this.cmbFontColor.SelectedIndex = 0;
                    break;
                case "Red":
                    this.cmbFontColor.SelectedIndex = 1;
                    break;
                case "Blue":
                    this.cmbFontColor.SelectedIndex = 2;
                    break;
                default:
                    this.cmbFontColor.SelectedIndex = 0;
                    break;
            }
            switch (clsTrn.AfterFontSize)
            {
                case 24:
                    this.cmbFontSize.SelectedIndex = 0;
                    break;
                case 26:
                    this.cmbFontSize.SelectedIndex = 1;
                    break;
                case 28:
                    this.cmbFontSize.SelectedIndex = 2;
                    break;
                case 36:
                    this.cmbFontSize.SelectedIndex = 3;
                    break;
                case 48:
                    this.cmbFontSize.SelectedIndex = 4;
                    break;
                default:
                    this.cmbFontSize.SelectedIndex = 3;
                    break;
            }
            switch (clsTrn.AfterFontBold)
            {
                case "普通":
                    this.cmbFontBold.SelectedIndex = 0;
                    break;
                case "太字":
                    this.cmbFontBold.SelectedIndex = 1;
                    break;
                default:
                    this.cmbFontBold.SelectedIndex = 0;
                    break;
            }
            #endregion

            // 承認メッセージ
            var result = CheckScheduleChangeData(day, userid);
            switch (result)
            {
                case 1:
                    SetConfirmMode(0);
                    // this.lblWarning.Text = "登録済" + Environment.NewLine + "[承認待ち]";
                    this.lblWarning.Text = "[承認待ち]";
                    break;
                case 2:
                    SetConfirmMode(1);
                    // this.lblWarning.Text = "登録済" + Environment.NewLine + "[承認済]";
                    this.lblWarning.Text = "[承認済]";
                    break;
                default:
                    SetConfirmMode(0);
                    this.lblWarning.Text = "";
                    break;
            }

            // 承認済か判定
            if (this.dgvShiftEntryList.Rows[row].Cells["confirm"].Value.ToString() == "承認済")
            {
                // 承認済み
                this.lblUpdate.Visible = false;                 // 更新モード　非表示
                SetConfirmMode(1);                              // 編集不可に設定
            }
            else
            {
                // 承認待ち
                this.lblUpdate.Visible = true;                  // 更新モード　表示
                this.dgvUserList.ClearSelection();              // 従業員一覧を未選択
                this.dgvUserShiftEntryList.Rows.Clear();        // 従業員別勤務予定一覧クリア
                SetConfirmMode(0);                              // 承認待ちモード（更新可能状態に）
            }

            // 担当者、担当者別勤務予定を表示
            #region "担当者を選択状態にする" 
            // var username = this.dgvShiftEntryList.Rows[row].Cells["username"].Value.ToString().Replace(" ","");
            var i = 0;
            for (i = 0; i < this.dgvUserList.RowCount; i++)
            {
                // 従業員名を比較し、一致した時に処理を抜ける（rowを取得する為）
                if (username == this.dgvUserList.Rows[i].Cells[1].Value.ToString().Replace(" ", ""))
                {
                    break;
                }
            }
            // 担当者一覧に存在しない場合あり（退職者）
            // if (i <= this.dgvUserList.RowCount)
            if (i < this.dgvUserList.RowCount)
            {
                    this.dgvUserList.Rows[i].Selected = true;
                // this.dgvUserList.CurrentCell = this.dgvUserList.Rows[i].Cells[1];

                // 従業員別勤務予定一覧の再表示
                DisplayUserShiftEntry(i, 0);

            }
            #endregion

            // 従業員別勤務予定一覧の再表示
            // DisplayUserShiftEntry(i, 0);
        }
        /// <summary>
        /// ===============================================================================
        /// ===============================================================================
        /// 保存ボタンクリック
        /// ===============================================================================
        /// ===============================================================================
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            #region "登録済みチェック"
            // -------------------------------------------------------
            // 登録済チェック　日付、従業員IDから変更登録済みか確認
            // -------------------------------------------------------
            var result = CheckScheduleChangeData(this.Select_day, this.Select_userid);
            var msg = "";
            switch(result)
            {
                case 1:
                    SelectScheduleChangeList(Select_day, Select_userid);
                    msg = "[" + Select_day.ToString("MM月dd日") + "  " + this.Select_username + "]" + Environment.NewLine + "既に変更依頼が登録されています。（承認待ち）" + Environment.NewLine + "登録を書き換えますか？";
                    if (MessageBox.Show(msg,"確認",MessageBoxButtons.OKCancel) == DialogResult.Cancel) { return; }
                    this.lblUpdate.Visible = true;
                    break;
                case 2:
                    SelectScheduleChangeList(Select_day, Select_userid);
                    // msg = "[" + select_day.ToString("MM月dd日") + "  " + this.select_username + "]" + Environment.NewLine + "既に変更依頼が登録されています。（承認済）" + Environment.NewLine + "承認解除後、登録を取消すか登録されている内容を変更してください。";
                    msg = "[" + Select_day.ToString("MM月dd日") + "  " + this.Select_username + "]" + Environment.NewLine + "既に変更依頼が登録されています。（承認済）" + Environment.NewLine + "登録を書き換えますか？";
                    MessageBox.Show(msg, "確認", MessageBoxButtons.OK);
                    // return;
                    break;
                default:
                    msg = "";
                    break;
            }
            #endregion

            // 念のためチェック（基本的には無いエラー）
            if (Select_userid <= 0) { return; }
            if (Select_day == DateTime.Parse("1900/01/01")) { return; }

            // モード確認
            if (this.lblUpdate.Visible != true)
            {
                // -------------------------------------------------------
                // 新規登録モード
                // -------------------------------------------------------
                if (this.dgvUserShiftEntryList.RowCount < 1) { return; }

                if (this.dgvUserShiftEntryList.CurrentRow == null)
                {
                    MessageBox.Show("登録する日付を選択してください。", "結果", MessageBoxButtons.OK);
                    return;
                }
                if (this.dgvUserShiftEntryList.CurrentRow.Index < 0)
                {
                    MessageBox.Show("登録する日付を選択してください。", "結果", MessageBoxButtons.OK);
                    return;
                }

                // 登録済み変更情報を削除（削除フラグON）
                try
                {
                    using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                    {
                        sb.Clear();
                        sb.AppendLine("UPDATE");
                        sb.AppendLine("Trn_勤務表シフト変更");
                        sb.AppendLine("SET");
                        // 2025/11/12↓
                        sb.AppendLine(" upd_user_id = " + ClsLoginUser.StaffID);
                        sb.AppendLine(",upd_date = '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                        // 2025/11/12↑
                        sb.AppendLine(",delete_flag = " + ClsPublic.FLAG_ON);
                        sb.AppendLine("WHERE");
                        sb.AppendLine(" day = '" + Select_day.ToString("yyyy/MM/dd") + "'");
                        sb.AppendLine("AND");
                        sb.AppendLine(" tanto_id = " + Select_userid);
                        
                        clsSqlDb.DMLUpdate(sb.ToString());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }

                // 勤務表シフト変更登録
                InsertTrnScheduleEntry();
            }
            else
            {
                // -------------------------------------------------------
                // 登録内容変更モード
                // -------------------------------------------------------
                // if (MessageBox.Show("書き換えますか？","確認",MessageBoxButtons.OKCancel) == DialogResult.Cancel) { return; }

                // 勤務表シフト変更更新
                UpdateTrnScheduleEntry(Select_day, Select_userid);

                // 更新モード非表示
                this.lblUpdate.Visible = false;
            }

            // 勤務表シフト変更情報取得／表示
            DisplayShiftEntry();

            // 勤務表変更フラグ更新
            ClsPublic.UpdateShiftFlag(ClsPublic.FLAG_ON);

            // メッセージ表示
            MessageBox.Show("変更情報を登録しました。" + "[" + Select_day.ToString("MM/dd") + " : " + Select_username + "]", "結果", MessageBoxButtons.OK);
        }
        /// <summary>
        /// 勤務表シフト変更　新規登録
        /// </summary>
        private void InsertTrnScheduleEntry()
        {
            ClsTrnScheduleEntry cls = new();

            // 勤務表シフト情報取得
            cls.Select(Select_day, Select_userid);

            // 勤務表シフト変更情報へ登録 INSERT
            ClsTrnScheduleChange clsc = new()
            {
                RegDate = DateTime.Now,
                RegUserID = ClsLoginUser.StaffID,
                RegUserName = ClsLoginUser.Name1,
                TantoID = cls.TantoID,
                TantoName = cls.TantoName,
                Day = cls.Day,
                BeforeContent = cls.Value,
                AfterContent = this.txtShiftEntry.Text.Replace(Environment.NewLine, "\n"),
                Row = cls.Row,
                Col = cls.Col,
                Comment = this.txtMemo.Text,
                FileName = cls.FilePath,
                SheetName = cls.SheetName,
                CommentFlag = ClsPublic.FLAG_OFF,
                ConfirmFlag = ClsPublic.FLAG_OFF,
                ConfirmUserID = ClsPublic.FLAG_OFF,
                ConfirmUserName = "",
                DeleteFlag = ClsPublic.FLAG_OFF,
                // 変更前のフォント情報
                BeforeBackColor = cls.BackColor,
                BeforeFontSize = cls.FontSize,
                BeforeFontColor = cls.FontColor,
                BeforeFontBold = cls.FontBold,
                // 変更後のフォント情報
                AfterBackColor = this.cmbBackColor.Text,
                AfterFontSize = int.Parse(this.cmbFontSize.Text),
                AfterFontColor = this.cmbFontColor.Text,
                AfterFontBold = this.cmbFontBold.Text,
                Year = cls.Year,
                Month = cls.Month,
            };

            // 勤務表シフト変更登録
            clsc.Insert();

            // コメントが変わっていたらシフト情報を更新
            if (clsc.Comment != cls.Comment)
            {
                //st.Length = 0;
                //st.AppendLine("UPDATE");
                //st.AppendLine("Trn_勤務表シフト情報");
                //st.AppendLine("SET");
                //st.AppendLine("Comment = '" + clsc.Comment + "'");
                //st.AppendLine("WHERE");
                //st.AppendLine("TantoID = " + select_userid);
                //st.AppendLine("AND");
                //st.AppendLine("Day = '" + select_day.ToString("yyyy/MM/dd") + "'");

                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("UPDATE");
                    sb.AppendLine("Trn_勤務表シフト情報");
                    sb.AppendLine("SET");
                    sb.AppendLine("comment = '" + clsc.Comment + "'");
                    // 2025/11/12↓
                    sb.AppendLine(",upd_user_id = " + ClsLoginUser.StaffID);
                    sb.AppendLine(",upd_date = '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    // 2025/11/12↑
                    sb.AppendLine("WHERE");
                    sb.AppendLine("tanto_id = " + Select_userid);
                    sb.AppendLine("AND");
                    sb.AppendLine("day = '" + Select_day.ToString("yyyy/MM/dd") + "'");

                    clsSqlDb.DMLUpdate(sb.ToString());
                }
            }

            // 勤務表変更履歴へ登録
            ClsTrnScheduleChangeHistory clsh = new()
            {
                RegDate = clsc.RegDate,
                RegUserID = clsc.RegUserID,
                RegUserName = clsc.RegUserName,
                TantoID = clsc.TantoID,
                TantoName = clsc.TantoName,
                Day = clsc.Day,
                BeforeContent = clsc.BeforeContent,
                AfterContent = clsc.AfterContent,
                Status = "変更"
            };
            clsh.Insert();
        }
        /// <summary>
        /// 勤務表シフト変更　更新登録
        /// </summary>
        /// <param name="p_day"></param>
        /// <param name="p_id"></param>
        private void UpdateTrnScheduleEntry(DateTime p_day, int p_id)
        {
            // 変更内容セット
            ClsTrnScheduleChange cls = new()
            {
                RegDate = DateTime.Now,
                RegUserID = ClsLoginUser.StaffID,
                RegUserName = ClsLoginUser.Name1,
                AfterContent = this.txtShiftEntry.Text,
                AfterBackColor = this.cmbBackColor.Text,
                AfterFontSize = int.Parse(this.cmbFontSize.Text),
                AfterFontColor = this.cmbFontColor.Text,
                AfterFontBold = this.cmbFontBold.Text,
                Comment = this.txtMemo.Text,
                // 承認待ち状態
                ConfirmFlag = ClsPublic.FLAG_OFF,
                ConfirmUserID = 0,
                ConfirmUserName = ""
            };
            // 勤務表シフト変更更新
            cls.Update(p_day, p_id);

            using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
            {
                // コメントを更新
                sb.Clear();
                sb.AppendLine("UPDATE");
                sb.AppendLine("Trn_勤務表シフト情報");
                sb.AppendLine("SET");
                sb.AppendLine("comment = '" + this.txtMemo.Text + "'");
                // 2025/11/12↓
                sb.AppendLine(",upd_user_id = " + ClsLoginUser.StaffID);
                sb.AppendLine(",upd_date = '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                // 2025/11/12↑
                sb.AppendLine("WHERE");
                sb.AppendLine("tanto_id = " + p_id);
                sb.AppendLine("AND");
                sb.AppendLine("day = '" + p_day.ToString("yyyy/MM/dd") + "'");
                
                clsSqlDb.DMLUpdate(sb.ToString());
            }

            // 勤務表変更履歴へ登録
            ClsTrnScheduleChangeHistory clsh = new()
            {
                RegDate = DateTime.Now,
                RegUserID = ClsLoginUser.StaffID,
                RegUserName = ClsLoginUser.Name1,
                TantoID = int.Parse(this.dgvShiftEntryList.Rows[this.dgvShiftEntryList.SelectedCells[0].RowIndex].Cells["userid"].Value.ToString()),
                TantoName = this.dgvShiftEntryList.Rows[this.dgvShiftEntryList.SelectedCells[0].RowIndex].Cells["username"].Value.ToString(),
                Day = DateTime.Parse(this.dgvShiftEntryList.Rows[this.dgvShiftEntryList.SelectedCells[0].RowIndex].Cells["day"].Value.ToString()),
                BeforeContent = this.dgvShiftEntryList.Rows[this.dgvShiftEntryList.SelectedCells[0].RowIndex].Cells["before"].Value.ToString(),
                AfterContent = this.txtShiftEntry.Text,
                Status = "変更"
            };
            clsh.Insert();
        }

        /// <summary>
        /// ===============================================================================
        /// 変更登録チェック
        /// ===============================================================================
        /// </summary>
        /// <param name="p_day"></param>
        /// <param name="p_id"></param>
        /// <returns>0:登録なし / 1:登録あり（承認待ち）/ 2:登録あり（承認済）</returns>
        private int CheckScheduleChangeData(DateTime p_day, int p_id)
        {
            int rtn = 0;

            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    // 日付と従業員から登録データを検索
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" confirm_flag");
                    sb.AppendLine("FROM");
                    sb.AppendLine(" Trn_勤務表シフト変更");
                    sb.AppendLine("WHERE");
                    sb.AppendLine(" tanto_id = " + p_id);
                    sb.AppendLine("AND");
                    sb.AppendLine(" day = '" + p_day.ToString("yyyy/MM/dd") + "'");
                    sb.AppendLine("AND");
                    sb.AppendLine(" delete_flag <> " + ClsPublic.FLAG_ON);

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            // 承認済フラグ参照
                            if (int.Parse(dr["confirm_flag"].ToString()) == ClsPublic.FLAG_ON)
                            {
                                // 承認済
                                rtn = 2;
                            }
                            else
                            {
                                // 承認待ち
                                rtn = 1;
                            }
                        }
                    }
                }
                return rtn;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// メニューボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMenu_Click(object sender, EventArgs e)
        {
            switch(((System.Windows.Forms.Button)sender).Name)
            {
                case "btnMenu1":            // 承認
                    SetApproval();
                    break;
                case "btnMenu2":            // 承認解除
                    ApprovalCancel();
                    break;
                case "btnMenu3":            // 予定連絡
                    frmRegContact frmRc = new();
                    frmRc.SelectTantoID = Select_userid;
                    frmRc.ShowDialog();
                    break;
                case "btnMenu4":            // クリア
                    ClearForm();
                    break;
                case "btnMenu5":            // 取消
                    CancelScheduleChange();
                    break;
                case "btnMenu6":            //  
                    break;
                case "btnMenu7":            // 
                    break;
                case "btnMenu8":            // 備考
                    frmScheduleComment frmSc = new();
                    frmSc.Day = this.dtpDate.Value;
                    frmSc.ShowDialog();
                    DisplayShiftEntry();
                    break;
                case "btnMenu9":            //  
                    break;
                case "btnMenu10":           // 閉じる
                    this.Close();
                    break;
                case "btnMenu11":           // 黄色戻し
                    ClsResetBackColor clsRst = new();
                    clsRst.ResetBackColor();
                    break;
                default:
                    break;
            }

        }
        /// <summary>
        /// 承認ボタン
        /// </summary>
        private void SetApproval()
        {
            var row = 0;
            var user_id = 0;
            var day = DateTime.Now;
            var cnt = 0;

            // ================================================================
            // 実行前チェック
            // ================================================================
            if (this.dgvShiftEntryList.RowCount == 0)
            {
                MessageBox.Show("シフト変更が登録されていません。", "結果", MessageBoxButtons.OK);
                return;
            }
            if (this.dgvShiftEntryList.CurrentRow == null) { return; }
            var flg = false;
            for (row = 0; row < this.dgvShiftEntryList.RowCount; row++)
            {
                if ((bool)this.dgvShiftEntryList.Rows[row].Cells[0].Value == true) { flg = true; }
            }
            if (flg == false)
            {
                MessageBox.Show("選択されていません。", "結果", MessageBoxButtons.OK);
                return;
            }

            // ================================================================
            // 確認メッセージ
            // ================================================================
            // メッセージボックス
            pubForm.frmMessageBox frmMsg = new()
            {
                F_size_height = 133,
                F_button_case = 2,
                L_value = "選択されている変更依頼を承認し、勤務表(エクセル)に反映させますか？" + Environment.NewLine + "尚、既に「承認済」のものは処理されません。",
                L_alignment = "TopCenter"
            };
            frmMsg.ShowDialog();

            if (frmMsg.F_result == 0) { return; }
            frmMsg.Dispose();

            // ================================================================
            // 処理中メッセージボックス
            // ================================================================
            frmMsg = new pubForm.frmMessageBox()
            {
                F_size_height = 95,
                F_button_case = 0,
                L_value = "承認処理中 ....."
            };
            frmMsg.Show();
            frmMsg.Refresh();

            // 勤務表設定情報
            ClsPublic.GetConfig();

            ClsTrnScheduleUpdateDate clss = new();
            ClsTrnScheduleChangeHistory clsh = new();
            ClsMsExcel clsmx;


            System.Data.DataTable dt_val1;
            System.Data.DataTable dt_val2;

            try
            {
                // ================================================================
                // 勤務表（エクセル）バックアップ（コピー）
                // ================================================================
                // バックアップファイル名編集
                var back_filename = ClsPublic.pubRootPath + ClsPublic.pubAppPath + @"\Backup\" + DateTime.Now.ToString("yyyyMMddhhmmss") + "_" + Path.GetFileName(ClsPublic.stcConfig[0].FilePath);
                // ファイルコピー
                File.Copy(ClsPublic.stcConfig[0].FilePath, back_filename);
                // 翌月判定
                if (ClsPublic.stcConfig[1].FilePath != "")
                {
                    // 翌月あり
                    // バックアップファイル名編集
                    back_filename = ClsPublic.pubRootPath + ClsPublic.pubAppPath + @"\Backup\" + DateTime.Now.ToString("yyyyMMddhhmmss") + "_" + Path.GetFileName(ClsPublic.stcConfig[1].FilePath);
                    // ファイルコピー
                    File.Copy(ClsPublic.stcConfig[1].FilePath, back_filename);
                }
                // ================================================================
                // 対象（チェックあり）の変更依頼に対して処理
                // ================================================================
                for (row = 0; row < this.dgvShiftEntryList.RowCount; row++)
                {
                    // チェックボックス判定
                    if ((bool)this.dgvShiftEntryList.Rows[row].Cells[0].Value != true) { continue; }

                    // 承認済みはスキップ
                    if (this.dgvShiftEntryList.Rows[row].Cells[7].Value.ToString() == "承認済") { continue; }

                    // エクセル操作クラス
                    clsmx = new ClsMsExcel();

                    // 従業員ID、日付
                    day = DateTime.Parse(this.dgvShiftEntryList.Rows[row].Cells["day"].Value.ToString());
                    user_id = int.Parse(this.dgvShiftEntryList.Rows[row].Cells["userid"].Value.ToString());

                    // using (clsDb cls = new clsDb(clsPublic.DBNo))
                    using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                    {
                        // 勤務表シフト情報取得（Trn_勤務表シフト情報）
                        sb.Clear();
                        sb.AppendLine("SELECT");
                        sb.AppendLine(" file_name");
                        sb.AppendLine(",file_path");
                        sb.AppendLine(",sheet_name");
                        sb.AppendLine(",row");
                        sb.AppendLine(",col");
                        sb.AppendLine("FROM");
                        sb.AppendLine(" Trn_勤務表シフト情報");
                        sb.AppendLine("WHERE");
                        sb.AppendLine(" day = '" + day.ToString("yyyy/MM/dd") + "'");
                        sb.AppendLine("AND");
                        sb.AppendLine(" tanto_id = " + user_id);

                        using (dt_val1 = clsSqlDb.DMLSelect(sb.ToString()))
                        {
                            foreach (DataRow dr in dt_val1.Rows)
                            {
                                switch (ClsPublic.CheckFile(dr["file_path"].ToString()))
                                {
                                    case 1:
                                        // ファイル無し
                                        MessageBox.Show("勤務表ファイルがありません。" + Environment.NewLine + dr["file_path"].ToString(), "結果", MessageBoxButtons.OK);
                                        return;
                                    case 2:
                                        // ファイル使用中
                                        MessageBox.Show("ファイルが使用されている可能性があります。" + Environment.NewLine + dr["file_path"].ToString(), "結果", MessageBoxButtons.OK);
                                        return;
                                }

                                // 勤務表（エクセル）更新
                                clsmx.FileName = dr["file_path"].ToString();
                                // clsx.FilePath = dr["FilePath"].ToString();
                                clsmx.SheetName = dr["sheet_name"].ToString();
                                clsmx.Row = int.Parse(dr["row"].ToString());
                                clsmx.Col = int.Parse(dr["col"].ToString());
                                clsmx.Value = this.dgvShiftEntryList.Rows[row].Cells["after"].Value.ToString();

                                // 変更後のフォント属性を取得
                                sb.Clear();
                                sb.AppendLine("SELECT");
                                sb.AppendLine(" after_back_color");
                                sb.AppendLine(",after_font_size");
                                sb.AppendLine(",after_font_color");
                                sb.AppendLine(",after_font_bold");
                                sb.AppendLine("FROM");
                                sb.AppendLine(" Trn_勤務表シフト変更");
                                sb.AppendLine("WHERE");
                                sb.AppendLine(" day = '" + day.ToString() + "'");
                                sb.AppendLine("AND");
                                sb.AppendLine(" tanto_id = " + user_id);

                                using (dt_val2 = clsSqlDb.DMLSelect(sb.ToString()))
                                {
                                    foreach (DataRow dr2 in dt_val2.Rows)
                                    {
                                        // フォント属性セット
                                        clsmx.FontSize = int.Parse(dr2["after_font_size"].ToString());
                                        clsmx.FontColor = dr2["after_font_color"].ToString();
                                        clsmx.FontBold = dr2["after_font_bold"].ToString();
                                        clsmx.BackColor = dr2["after_back_color"].ToString();
                                    }
                                }

                                // 塗潰しなし＋土曜日の場合を対応 2024/10/24
                                if (clsmx.BackColor == "")
                                {
                                    if (day.DayOfWeek == DayOfWeek.Saturday)
                                    {
                                        clsmx.BackColor = "SaturDayColor";
                                    }
                                }

                                clsmx.OpenBook();
                                clsmx.SetCell();
                                clsmx.CloseSaveBook();
                            }
                        }

                        // 勤務表シフト変更更新（承認済み）
                        sb.Clear();
                        sb.AppendLine("UPDATE");
                        sb.AppendLine(" Trn_勤務表シフト変更");
                        sb.AppendLine("SET");
                        sb.AppendLine(" confirm_flag = 1");
                        // 2025/11/12↓
                        sb.AppendLine(",upd_user_id = " + ClsLoginUser.StaffID);
                        sb.AppendLine(",upd_date = '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                        // 2025/11/12↑
                        sb.AppendLine("WHERE");
                        sb.AppendLine(" day = '" + day.ToString("yyyy/MM/dd") + "'");
                        sb.AppendLine("AND");
                        sb.AppendLine(" tanto_id = " + user_id);

                        clsSqlDb.DMLUpdate(sb.ToString());

                        // 勤務表シフト情報更新（変更後情報をセット）
                        sb.Clear();
                        sb.AppendLine("UPDATE");
                        sb.AppendLine(" Trn_勤務表シフト情報");
                        sb.AppendLine("SET");
                        sb.AppendLine(" back_color = '" + clsmx.BackColor + "'");
                        sb.AppendLine(",font_size = " + clsmx.FontSize);
                        sb.AppendLine(",font_color = '" + clsmx.FontColor + "'");
                        sb.AppendLine(",font_bold = '" + clsmx.FontBold + "'");
                        sb.AppendLine(",value = '" + clsmx.Value + "'");
                        // 2025/11/12↓
                        sb.AppendLine(",upd_user_id = " + ClsLoginUser.StaffID);
                        sb.AppendLine(",upd_date = '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                        // 2025/11/12↑
                        sb.AppendLine("WHERE");
                        sb.AppendLine(" day = '" + day.ToString("yyyy/MM/dd") + "'");
                        sb.AppendLine("AND");
                        sb.AppendLine(" tanto_id = " + user_id);

                        clsSqlDb.DMLUpdate(sb.ToString());

                        // タイムスタンプ
                        clss.UpdateTimeStamp(clsmx.FileName);

                        // ------------------------------------------------------------
                        // 変更履歴登録
                        // ------------------------------------------------------------
                        clsh.RegDate = DateTime.Now;
                        clsh.RegUserID = ClsLoginUser.StaffID;
                        clsh.RegUserName = ClsLoginUser.Name1;
                        clsh.TantoID = int.Parse(this.dgvShiftEntryList.Rows[row].Cells["userid"].Value.ToString());
                        clsh.TantoName = this.dgvShiftEntryList.Rows[row].Cells["username"].Value.ToString();
                        clsh.Day = DateTime.Parse(this.dgvShiftEntryList.Rows[row].Cells["day"].Value.ToString());
                        clsh.BeforeContent = this.dgvShiftEntryList.Rows[row].Cells["before"].Value.ToString();
                        clsh.AfterContent = this.dgvShiftEntryList.Rows[row].Cells["after"].Value.ToString();
                        clsh.Status = "承認";
                        clsh.Insert();
                    }

                    // 対象レコード数
                    cnt++;
                }

                // 担当者別シフト予定クリア
                this.dgvUserShiftEntryList.Rows.Clear();

                // 再表示
                DisplayShiftEntry();

                // 処理中メッセージクローズ
                frmMsg.Close();
                frmMsg.Dispose();

                // ================================================================
                // 終了メッセージボックス
                // ================================================================
                frmMsg = new pubForm.frmMessageBox();
                // frmMsg.f_position = 2;
                frmMsg.F_size_height = 133;
                frmMsg.F_button_case = 1;
                if (cnt > 0)
                {
                    frmMsg.L_value = "承認 処理が終了しました。";
                }
                else
                {
                    frmMsg.L_value = "承認対象となる予定が０件でした。";
                }
                frmMsg.ShowDialog();
                frmMsg.Dispose();
            }
            catch (Exception ex)
            {
                frmMsg.Close();
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK);
                throw;
            }
            finally
            {
                if (frmMsg != null) frmMsg.Close();
            }
        }
        /// <summary>
        /// 承認解除ボタン
        /// </summary>
        private void ApprovalCancel()
        {
            // var upflg = false;
            var row = 0;
            var user_id = 0;
            var day = DateTime.Now;
            var cnt = 0;

            // ================================================================
            // 実行前チェック
            // ================================================================
            if (this.dgvShiftEntryList.RowCount == 0)
            {
                MessageBox.Show("シフト変更が登録されていません。", "結果", MessageBoxButtons.OK);
                return;
            }
            var flg = false;
            for (row = 0; row < this.dgvShiftEntryList.RowCount; row++)
            {
                // if ((bool)this.dgvShiftEntryList.Rows[row].Cells["選択"].Value == true) { flg = true; }
                if ((bool)this.dgvShiftEntryList.Rows[row].Cells[0].Value == true) { flg = true; }
            }
            if (flg == false)
            {
                MessageBox.Show("選択されていません。", "結果", MessageBoxButtons.OK);
                return;
            }

            // ================================================================
            // 確認メッセージ
            // ================================================================
            // メッセージボックス
            pubForm.frmMessageBox frmMsg = new()
            {
                F_size_height = 133,
                F_button_case = 2,
                L_value = "選択されている承認済みを解除し、勤務表(エクセル)に反映させますか？" + Environment.NewLine + "尚、「承認待ち」のものは処理されません。",
                L_alignment = "TopCenter"
            };
            frmMsg.ShowDialog();

            if (frmMsg.F_result == 0) { return; }
            frmMsg.Dispose();

            // ================================================================
            // 処理中メッセージボックス
            // ================================================================
            frmMsg = new pubForm.frmMessageBox()
            {
                F_size_height = 95,
                F_button_case = 0,
                L_value = "承認解除処理中 ....."
            };
            frmMsg.Show();
            frmMsg.Refresh();

            // 勤務表設定情報
            ClsPublic.GetConfig();

            ClsMsExcel clsmx;
            ClsTrnScheduleUpdateDate clss = new();
            ClsTrnScheduleChangeHistory clsh = new();

            System.Data.DataTable dt_val1;
            System.Data.DataTable dt_val2;

            try
            {
                // ================================================================
                // 勤務表（エクセル）バックアップ（コピー）
                // ================================================================
                // バックアップファイル名編集
                var back_filename = ClsPublic.pubRootPath + ClsPublic.pubAppPath + @"\Backup\" + DateTime.Now.ToString("yyyyMMddhhmmss") + "_" + Path.GetFileName(ClsPublic.stcConfig[0].FilePath);
                // ファイルコピー
                File.Copy(ClsPublic.stcConfig[0].FilePath, back_filename);
                // 翌月判定
                if (ClsPublic.stcConfig[1].FilePath != "")
                {
                    // 翌月あり
                    // バックアップファイル名編集
                    back_filename = ClsPublic.pubRootPath + ClsPublic.pubAppPath + @"\Backup\" + DateTime.Now.ToString("yyyyMMddhhmmss") + "_" + Path.GetFileName(ClsPublic.stcConfig[1].FilePath);
                    // ファイルコピー
                    File.Copy(ClsPublic.stcConfig[1].FilePath, back_filename);
                }
                // ================================================================
                // 対象（チェックあり）の変更依頼に対して処理
                // ================================================================
                for (row = 0; row < this.dgvShiftEntryList.RowCount; row++)
                {
                    // チェックボックス判定
                    if ((bool)this.dgvShiftEntryList.Rows[row].Cells[0].Value != true) { continue; }

                    // 承認待ちはスキップ
                    // if (this.dgvShiftEntryList.Rows[row].Cells["userid"].Value.ToString() == "承認待ち") { continue; }
                    if (this.dgvShiftEntryList.Rows[row].Cells[7].Value.ToString() == "承認待ち") { continue; }

                    // エクセル操作クラス
                    clsmx = new ClsMsExcel();

                    // 従業員ID、日付
                    day = DateTime.Parse(this.dgvShiftEntryList.Rows[row].Cells["day"].Value.ToString());
                    user_id = int.Parse(this.dgvShiftEntryList.Rows[row].Cells["userid"].Value.ToString());

                    // 処理用DataTable(Trn_勤務表シフト情報,Trn_勤務表シフト変更)
                    // System.Data.DataTable dt1 = new System.Data.DataTable();
                    // System.Data.DataTable dt2 = new System.Data.DataTable();

                    using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                    {
                        // 勤務表シフト情報取得（Trn_勤務表シフト情報）
                        sb.Clear();
                        sb.AppendLine("SELECT");
                        sb.AppendLine(" file_name");
                        sb.AppendLine(",file_path");
                        sb.AppendLine(",sheet_name");
                        sb.AppendLine(",row");
                        sb.AppendLine(",col");
                        sb.AppendLine("FROM");
                        sb.AppendLine(" Trn_勤務表シフト情報");
                        sb.AppendLine("WHERE");
                        sb.AppendLine(" day = '" + day.ToString("yyyy/MM/dd") + "'");
                        sb.AppendLine("AND");
                        sb.AppendLine("tanto_id = " + user_id);

                        using (dt_val1 = clsSqlDb.DMLSelect(sb.ToString()))
                        {
                            foreach (DataRow dr in dt_val1.Rows)
                            {
                                switch (ClsPublic.CheckFile(dr["file_path"].ToString()))
                                {
                                    case 1:
                                        // ファイル無し
                                        MessageBox.Show("勤務表ファイルがありません。" + Environment.NewLine + dr["file_path"].ToString(), "結果", MessageBoxButtons.OK);
                                        return;
                                    case 2:
                                        // ファイル使用中
                                        MessageBox.Show("ファイルが使用されている可能性があります。" + Environment.NewLine + dr["file_pPath"].ToString(), "結果", MessageBoxButtons.OK);
                                        return;
                                }

                                // 勤務表（エクセル）更新
                                clsmx.FileName = dr["file_path"].ToString();
                                clsmx.SheetName = dr["sheet_name"].ToString();
                                clsmx.Row = int.Parse(dr["row"].ToString());
                                clsmx.Col = int.Parse(dr["col"].ToString());
                                clsmx.Value = this.dgvShiftEntryList.Rows[row].Cells["before"].Value.ToString();

                                // 変更後のフォント属性を取得
                                sb.Clear();
                                sb.AppendLine("SELECT");
                                sb.AppendLine(" before_back_color");
                                sb.AppendLine(",before_font_size");
                                sb.AppendLine(",before_font_color");
                                sb.AppendLine(",before_font_bold");
                                sb.AppendLine("FROM");
                                sb.AppendLine(" Trn_勤務表シフト変更");
                                sb.AppendLine("WHERE");
                                sb.AppendLine(" day = '" + day.ToString() + "'");
                                sb.AppendLine("AND");
                                sb.AppendLine(" tanto_id = " + user_id);

                                // cls.Sql = st.ToString();
                                // cls.DMLSelect();
                                // dt2 = cls.dt;
                                dt_val2 = clsSqlDb.DMLSelect(sb.ToString());

                                foreach (DataRow dr2 in dt_val2.Rows)
                                {
                                    // フォント属性セット
                                    clsmx.FontSize = int.Parse(dr2["before_font_size"].ToString());
                                    clsmx.FontColor = dr2["before_font_color"].ToString();
                                    clsmx.FontBold = dr2["before_font_bold"].ToString();
                                    clsmx.BackColor = dr2["before_back_color"].ToString();
                                }
                                dt_val2.Dispose();

                                clsmx.OpenBook();
                                clsmx.SetCell();
                                clsmx.CloseSaveBook();

                                // 更新フラグ
                                // upflg = true;
                            }
                        }

                        // 勤務表シフト変更更新（承認待ち）
                        sb.Clear();
                        sb.AppendLine("UPDATE");
                        sb.AppendLine(" Trn_勤務表シフト変更");
                        sb.AppendLine("SET");
                        sb.AppendLine(" confirm_flag = " + ClsPublic.FLAG_OFF);
                        // 2025/11/12↓
                        sb.AppendLine(",upd_user_id = " + ClsLoginUser.StaffID);
                        sb.AppendLine(",upd_date = '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                        // 2025/11/12↑
                        sb.AppendLine("WHERE");
                        sb.AppendLine(" day = '" + day.ToString("yyyy/MM/dd") + "'");
                        sb.AppendLine("AND");
                        sb.AppendLine(" tanto_id = " + user_id);
                        
                        clsSqlDb.DMLUpdate(sb.ToString());

                        // 勤務表シフト情報更新（変更後情報をセット）
                        sb.Clear();
                        sb.AppendLine("UPDATE");
                        sb.AppendLine(" Trn_勤務表シフト情報");
                        sb.AppendLine("SET");
                        sb.AppendLine(" back_color = '" + clsmx.BackColor + "'");
                        sb.AppendLine(",font_size = " + clsmx.FontSize);
                        sb.AppendLine(",font_color = '" + clsmx.FontColor + "'");
                        sb.AppendLine(",font_bold = '" + clsmx.FontBold + "'");
                        sb.AppendLine(",value = '" + clsmx.Value + "'");
                        // 2025/11/12↓
                        sb.AppendLine(",upd_user_id = " + ClsLoginUser.StaffID);
                        sb.AppendLine(",upd_date = '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                        // 2025/11/12↑
                        sb.AppendLine("WHERE");
                        sb.AppendLine(" day = '" + day.ToString("yyyy/MM/dd") + "'");
                        sb.AppendLine("AND");
                        sb.AppendLine(" tanto_id = " + user_id);

                        clsSqlDb.DMLUpdate(sb.ToString());

                        // タイムスタンプ
                        clss.UpdateTimeStamp(clsmx.FileName);

                        // ------------------------------------------------------------
                        // 変更履歴登録
                        // ------------------------------------------------------------
                        clsh.RegDate = DateTime.Now;
                        clsh.RegUserID = ClsLoginUser.StaffID;
                        clsh.RegUserName = ClsLoginUser.Name1;
                        clsh.TantoID = int.Parse(this.dgvShiftEntryList.Rows[row].Cells["userid"].Value.ToString());
                        clsh.TantoName = this.dgvShiftEntryList.Rows[row].Cells["username"].Value.ToString();
                        clsh.Day = DateTime.Parse(this.dgvShiftEntryList.Rows[row].Cells["day"].Value.ToString());
                        clsh.BeforeContent = this.dgvShiftEntryList.Rows[row].Cells["before"].Value.ToString();
                        clsh.AfterContent = this.dgvShiftEntryList.Rows[row].Cells["after"].Value.ToString();
                        clsh.Status = "承認解除";
                        clsh.Insert();
                    }

                    // 処理対象レコード数
                    cnt++;
                }

                // 再表示
                DisplayShiftEntry();

                // 処理中メッセージクローズ
                frmMsg.Close();
                frmMsg.Dispose();

                // ================================================================
                // 終了メッセージボックス
                // ================================================================
                frmMsg = new pubForm.frmMessageBox();
                // frmMsg.f_position = 2;
                frmMsg.F_size_height = 133;
                frmMsg.F_button_case = 1;
                if (cnt > 0)
                {
                    frmMsg.L_value = "承認解除 処理が終了しました。";
                }
                else
                {
                    frmMsg.L_value = "解除対象となるシフトが０件でした。";
                }
                frmMsg.ShowDialog();
                frmMsg.Dispose();
            }
            catch (Exception ex)
            {
                frmMsg.Close();
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK);
                throw;
            }
            finally
            {
                if (frmMsg != null) frmMsg.Close();
            }
        }

        /// <summary>
        /// 取消ボタン
        /// </summary>
        private void CancelScheduleChange()
        {
            // ================================================================
            // 実行前チェック
            // ================================================================
            if (this.dgvShiftEntryList.RowCount == 0)
            {
                MessageBox.Show("シフト変更が登録されていません。", "結果", MessageBoxButtons.OK);
                return;
            }
            if (this.dgvShiftEntryList.CurrentRow == null) { return; }
            var flg = false;
            for (var row = 0; row < this.dgvShiftEntryList.RowCount; row++)
            {
                if ((bool)this.dgvShiftEntryList.Rows[row].Cells[0].Value == true) { flg = true; }
            }
            if (flg == false)
            {
                MessageBox.Show("選択されていません。", "結果", MessageBoxButtons.OK);
                return;
            }

            // ================================================================
            // 確認メッセージ
            // ================================================================
            if (MessageBox.Show("削除して宜しいですか？" + Environment.NewLine + "「承認済み」は削除されません。","確認",MessageBoxButtons.OKCancel) == DialogResult.Cancel) { return; }

            // ================================================================
            // 勤務表シフト変更削除
            // ================================================================
            ClsTrnScheduleChangeHistory clshty = new();
            var day = DateTime.Now;
            var user_id = 0;
            var user_name = "";
            var confirm = "";
            var before_contact = "";
            var after_contact = "";
            var cnt = 0;

            for (var row = 0; row < this.dgvShiftEntryList.RowCount; row++ )
            {
                // チェックが入っている行が対象
                // if ((bool)this.dgvShiftEntryList.Rows[row].Cells["選択"].Value == true)
                if ((bool)this.dgvShiftEntryList.Rows[row].Cells[0].Value == true)
                {
                    day = DateTime.Parse(this.dgvShiftEntryList.Rows[row].Cells["day"].Value.ToString());
                    user_id = int.Parse(this.dgvShiftEntryList.Rows[row].Cells["userid"].Value.ToString());
                    user_name = this.dgvShiftEntryList.Rows[row].Cells["username"].Value.ToString();
                    confirm = this.dgvShiftEntryList.Rows[row].Cells["confirm"].Value.ToString();
                    before_contact = this.dgvShiftEntryList.Rows[row].Cells["before"].Value.ToString();
                    after_contact = this.dgvShiftEntryList.Rows[row].Cells["after"].Value.ToString();

                    if (confirm == "承認済") { continue; }

                    using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                    {
                        // ---------------------------------------------------------
                        // 勤務表シフト変更削除（物理削除） 
                        // ---------------------------------------------------------
                        sb.Clear();
                        sb.AppendLine("DELETE FROM");
                        sb.AppendLine(" Trn_勤務表シフト変更");
                        sb.AppendLine("WHERE");
                        sb.AppendLine(" day = '" + day.ToString("yyyy/MM/dd") + "'");
                        sb.AppendLine("AND");
                        sb.AppendLine(" tanto_id = " + user_id);
                        
                        clsSqlDb.DMLUpdate(sb.ToString());

                        // ---------------------------------------------------------
                        // 気歴登録
                        // ---------------------------------------------------------
                        clshty.RegDate = DateTime.Now;
                        clshty.RegUserID = ClsLoginUser.StaffID;
                        clshty.RegUserName = ClsLoginUser.Name1;
                        clshty.TantoID = user_id;
                        clshty.TantoName = user_name;
                        clshty.Day = day;
                        clshty.BeforeContent = before_contact;
                        clshty.AfterContent = after_contact;
                        clshty.Status = "削除";
                        clshty.Insert();

                        // 処理レコード数
                        cnt++;
                    }
                }
            }
            // 勤務表シフト変更情報取得／表示
            DisplayShiftEntry();

            // 勤務表変更フラグ更新
            // clsPublic.UpdateShiftFlag(clsPublic.FLAG_ON);

            if (cnt > 0)
            {
                // メッセージ表示
                MessageBox.Show("変更情報を削除しました。", "結果", MessageBoxButtons.OK);
            }
            else
            {
                // メッセージ表示
                MessageBox.Show("削除対象になるシフト予定は０件でした。", "結果", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// ===============================================================================
        /// 承認済データ表示制御
        /// ===============================================================================
        /// </summary>
        /// <param name="p_mode">0:更新可 / 1:更新不可</param>
        private void SetConfirmMode(int p_mode)
        {
            if (p_mode == 0)
            {
                // 更新可
                this.txtShiftEntry.Enabled = true;
                this.btnAdd.Enabled = true;
                this.cmbFontBold.Enabled = true;
                this.cmbFontColor.Enabled = true;
                this.cmbFontSize.Enabled = true;
                this.cmbBackColor.Enabled = true;
            }
            else
            {
                // 更新不可
                this.txtShiftEntry.Enabled = false;
                this.btnAdd.Enabled = false;
                this.cmbFontBold.Enabled = false;
                this.cmbFontColor.Enabled = false;
                this.cmbFontSize.Enabled = false;
                this.cmbBackColor.Enabled = false;
            }

        }

        /// <summary>
        /// ===============================================================================
        /// 保持情報クリア　編集エリア、メモ、従業員ID、日付、登録済警告メッセージエリア等
        /// ===============================================================================
        /// </summary>
        private void ClearFormData()
        {
            // シフト内容
            this.txtShiftEntry.Text = "";
            // コメント
            this.txtMemo.Text = "";
            // 従業員ID、日付
            this.Select_userid = 0;
            this.Select_username = "";
            this.Select_day = DateTime.Parse("1900/01/01");
            // 警告メッセージ
            this.lblWarning.Text = "";
        }
        /// <summary>
        /// ===============================================================================
        /// フォームクリア（クリアボタン処理）
        /// ===============================================================================
        /// </summary>
        private void ClearForm()
        {
            ClearFormData();                        // 保持情報

            SetConfirmMode(0);                      // 変更可能

            this.dtpDate.Value = DateTime.Now;
            this.lblUpdate.Visible = false;
            this.dgvUserList.ClearSelection();
            this.dgvUserList.Enabled = true;
            this.dgvUserShiftEntryList.Rows.Clear();
            this.dgvUserShiftEntryList.Enabled = true;
            this.dgvShiftEntryList.ClearSelection();

            this.cmbBackColor.SelectedIndex = 0;
            this.cmbFontSize.SelectedIndex = 3;
            this.cmbFontColor.SelectedIndex = 0;
            this.cmbFontBold.SelectedIndex = 0;

            this.cmbWhere.SelectedIndex = 0;
            this.cmbUser.SelectedIndex = 0;

            for (var i = 0; i < this.dgvShiftEntryList.Rows.Count; i++)
            {
                this.dgvShiftEntryList.Rows[i].Cells["選択"].Value = false;
            }

            // メモ登録ボタン
            // this.btnRegMemo.Enabled = false;
        }
        /// <summary>
        /// ===============================================================================
        /// メモ登録ボタン
        /// ===============================================================================
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegMemo_Click(object sender, EventArgs e)
        {
            // 念のためチェック（基本的には無いエラー）
            if (Select_userid <= 0) { return; }
            if (Select_day == DateTime.Parse("1900/01/01")) { return; }

            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    // 勤務表シフト情報を更新
                    sb.Clear();
                    sb.AppendLine("UPDATE");
                    sb.AppendLine(" Trn_勤務表シフト情報");
                    sb.AppendLine("SET");
                    sb.AppendLine(" comment = '" + this.txtMemo.Text + "'");
                    // 2025/11/12↓
                    sb.AppendLine(",upd_user_id = " + ClsLoginUser.StaffID);
                    sb.AppendLine(",upd_date = '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    // 2025/11/12↑
                    sb.AppendLine("WHERE");
                    sb.AppendLine(" day = '" + Select_day.ToString("yyyy/MM/dd") + "'");
                    sb.AppendLine("AND");
                    sb.AppendLine(" tanto_id = " + Select_userid);
                    
                    clsSqlDb.DMLUpdate(sb.ToString());
                }
                MessageBox.Show("メモを登録しました。", "結果", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 前週ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrev_Click(object sender, EventArgs e)
        {
            // 現在指定されている日付を取得
            DateTime nowdt = this.dtpDate.Value;
            this.dtpDate.Value = nowdt.AddDays(-10);

            // 開始年月日より前の場合は、開始年月日をセット
            if (this.dtpDate.Value < DateTime.Parse(ClsPublic.stcConfig[0].StartDate)) { this.dtpDate.Value = DateTime.Parse(ClsPublic.stcConfig[0].StartDate); }

            // 担当者シフト予定一覧クリア
            dgvUserShiftEntryList.Rows.Clear();

            // クリア
            ClearFormData();

            // 担当者シフト予定一覧表示
            // DisplayUserShiftEntry(e.RowIndex, e.ColumnIndex + 1);
            DisplayUserShiftEntry(this.dgvUserList.CurrentRow.Index, 0);

            this.dgvUserShiftEntryList.ClearSelection();
            this.dgvShiftEntryList.ClearSelection();

            // 編集モード非表示
            this.lblUpdate.Visible = false;

            // 編集モード：編集可能
            SetConfirmMode(0);

            // フォント選択解除
            UnSelectFontComboBox();

        }
        /// <summary>
        /// 次週ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            // 現在指定されている日付を取得
            DateTime nowdt = this.dtpDate.Value;
            this.dtpDate.Value = nowdt.AddDays(10);


            // 担当者シフト予定一覧クリア
            dgvUserShiftEntryList.Rows.Clear();

            // クリア
            ClearFormData();

            // 担当者シフト予定一覧表示
            // DisplayUserShiftEntry(e.RowIndex, e.ColumnIndex + 1);
            DisplayUserShiftEntry(this.dgvUserList.CurrentRow.Index, 0);

            this.dgvUserShiftEntryList.ClearSelection();
            this.dgvShiftEntryList.ClearSelection();

            // 編集モード非表示
            this.lblUpdate.Visible = false;

            // 編集モード：編集可能
            SetConfirmMode(0);

            // フォント選択解除
            UnSelectFontComboBox();

        }
    }
}
