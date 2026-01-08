using FlockAppC.pubClass;
using FlockAppC.tblClass;
using FlockAppC.マスターメンテ;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FlockAppC.社用車関連
{
    public partial class frmCar : Form
    {
        private readonly StringBuilder sb = new();

        public frmCar()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 走行記録データ取込
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImport_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this.dtpDate1.Value.ToString("yyyy/MM/dd") + "～" + this.dtpDate2.Value.ToString("yyyy/MM/dd") + " までの走行記録データをインポートしますか？", "確認", MessageBoxButtons.OKCancel) == DialogResult.Cancel) { return; }

            try
            {
                // カーソルを砂時計に変更
                Cursor.Current = Cursors.WaitCursor;

                // XServer接続メッセージ表示
                this.lblConnect.Visible = true;
                this.lblConnect.Refresh();

                // 件数クリア
                this.lblCnt.Text = "";

                ClsTrnCarRun cls = new()
                {
                    // 抽出条件設定
                    Srch_start_date = this.dtpDate1.Value,
                    Srch_end_date = this.dtpDate2.Value
                };

                // 利用者
                if (this.cmbUser.Text != "") { cls.Srch_staff_id = int.Parse(this.cmbUser.SelectedValue.ToString()); }
                else { cls.Srch_staff_id = -1; }

                // 社用車
                if (this.cmbCar.Text != "") { cls.Srch_car_id = int.Parse(this.cmbCar.SelectedValue.ToString()); }
                else { cls.Srch_car_id = -1; }

                // インポート実行
                var cnt = cls.ImportData(ref this.pgb);

                // XServer接続メッセージ
                this.lblConnect.Visible = false;
                this.lblConnect.Refresh();

                // インポート完了メッセージ
                this.lblMessage.Visible = true;
                this.lblMessage.Refresh();
                this.lblCnt.Text = cnt.ToString() + "件";

                // MessageBox.Show("インポート終了", "結果", MessageBoxButtons.OK);

                // 走行記録表示
                DisplayList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                // カーソルを元に戻す
                Cursor.Current = Cursors.Default;
            }
        }
        /// <summary>
        /// 社用車マスターメンテ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMaster_Click(object sender, EventArgs e)
        {
            using (frmMstCar frm = new())
            {
                frm.ShowDialog();
            }
        }
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCar_Load(object sender, EventArgs e)
        {
            SetDgvList();

            this.dtpDate1.Value = DateTime.Now;
            this.dtpDate2.Value = DateTime.Now;

            SetUserCmb();
            SetCarCmb();

            this.chkDelete.Checked = false;
            this.lblCnt.Text = "";

            // XServer接続メッセージ
            this.lblConnect.Visible = false;

            // インポート完了メッセージ
            this.lblMessage.Visible = false;

            // インポート件数クリア
            this.lblCnt.Text = "";

            // プログレスバー非表示、値初期化
            this.pgb.Visible = false;
            this.pgb.Minimum = 0;
            this.pgb.Maximum = 100;
            this.pgb.Value = 0;
            this.Dock = DockStyle.Top;

            // 権限判定→権限無しは閲覧、エクセル出力のみ
            if (ClsLoginUser.CarManageFlag != ClsPublic.FLAG_ON)
            {
                this.btnAdd.Enabled = false;
                this.btnImport.Enabled = false;
                this.btnMaster.Enabled = false;
            }

            this.Location = new System.Drawing.Point(0, 0);

            // 走行記録表示
            DisplayList();
        }
        /// <summary>
        /// DataGridView設定
        /// </summary>
        private void SetDgvList()
        {
            // 走行記録一覧
            DataGridViewButtonColumn col00 = new DataGridViewButtonColumn();
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
            col00.Name = "edit";
            col00.HeaderText = " ";
            col00.Text = "編集";
            col00.Width = 50;
            col00.UseColumnTextForButtonValue = true;
            col00.Visible = true;

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
            col04.Width = 180;
            col04.Visible = true;

            // 利用者ID
            col05.Name = "used_user_id";
            col05.HeaderText = "利用者ID";
            col05.Width = 50;
            col05.Visible = false;

            // 利用者名
            col06.Name = "used_user_name";
            col06.HeaderText = "利用者名";
            col06.Width = 80;
            col06.Visible = true;

            // 出発時刻
            col07.Name = "start_time";
            col07.HeaderText = "出発時刻";
            col07.Width = 80;
            col07.Visible = true;

            // 到着時刻
            col08.Name = "end_time";
            col08.HeaderText = "到着時刻";
            col08.Width = 80;
            col08.Visible = true;

            // 出発時ODO
            col09.Name = "start_odo";
            col09.HeaderText = "出発時ﾒｰﾀｰ";
            col09.Width = 90;
            col09.Visible = true;

            // 到着時ODO
            col10.Name = "end_odo";
            col10.HeaderText = "到着時ﾒｰﾀｰ";
            col10.Width = 90;
            col10.Visible = true;

            // 走行距離
            col11.Name = "distance";
            col11.HeaderText = "走行距離";
            col11.Width = 80;
            col11.Visible = true;

            // 行先(From)
            col12.Name = "from_point";
            col12.HeaderText = "行先(From)";
            col12.Width = 100;
            col12.Visible = true;

            // 行先(To)
            col13.Name = "to_point";
            col13.HeaderText = "行先(To)";
            col13.Width = 100;
            col13.Visible = true;

            // 補足
            col14.Name = "note";
            col14.HeaderText = "補足";
            col14.Width = 200;
            col14.Visible = true;

            // 給油量
            col15.Name = "gas_stock";
            col15.HeaderText = "給油量";
            col15.Width = 80;
            col15.Visible = true;

            // アルコールチェック
            col16.Name = "check_alcohol";
            col16.HeaderText = "ｱﾙﾁｪｯｸ";
            col16.Width = 60;
            col16.Visible = true;

            // 削除
            col17.Name = "delete_flag";
            col17.HeaderText = "削除";
            col17.Width = 50;
            col17.Visible = true;

            this.dgvList.Columns.Add(col00);
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
            this.dgvList.Columns.Add(col11);
            this.dgvList.Columns.Add(col12);
            this.dgvList.Columns.Add(col13);
            this.dgvList.Columns.Add(col14);
            this.dgvList.Columns.Add(col15);
            this.dgvList.Columns.Add(col16);
            this.dgvList.Columns.Add(col17);

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
            this.dgvList.Columns["start_time"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;       // 列ヘッダ文字位置
            this.dgvList.Columns["end_time"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;         // 列ヘッダ文字位置
            this.dgvList.Columns["start_odo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;        // 列ヘッダ文字位置
            this.dgvList.Columns["end_odo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;          // 列ヘッダ文字位置
            this.dgvList.Columns["distance"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;         // 列ヘッダ文字位置
            this.dgvList.Columns["from_point"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;       // 列ヘッダ文字位置
            this.dgvList.Columns["to_point"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;         // 列ヘッダ文字位置
            this.dgvList.Columns["note"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;             // 列ヘッダ文字位置
            this.dgvList.Columns["gas_stock"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;        // 列ヘッダ文字位置
            this.dgvList.Columns["check_alcohol"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;    // 列ヘッダ文字位置
            this.dgvList.Columns["delete_flag"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;      // 列ヘッダ文字位置

            //奇数行を黄色にする
            this.dgvList.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Moccasin;

            // 表示位置
            this.dgvList.Columns["day"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;              //セルの文字表示位置
            this.dgvList.Columns["car_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;           //セルの文字表示位置
            this.dgvList.Columns["used_user_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;     //セルの文字表示位置
            this.dgvList.Columns["start_time"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;       //セルの文字表示位置
            this.dgvList.Columns["end_time"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;         //セルの文字表示位置
            this.dgvList.Columns["start_odo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;         //セルの文字表示位置
            this.dgvList.Columns["end_odo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;           //セルの文字表示位置
            this.dgvList.Columns["distance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;          //セルの文字表示位置
            this.dgvList.Columns["from_point"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;         //セルの文字表示位置
            this.dgvList.Columns["to_point"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;           //セルの文字表示位置
            this.dgvList.Columns["note"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;               //セルの文字表示位置
            this.dgvList.Columns["gas_stock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;         //セルの文字表示位置
            this.dgvList.Columns["check_alcohol"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    //セルの文字表示位置
            this.dgvList.Columns["delete_flag"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;      //セルの文字表示位置

            // フォント
            this.dgvList.Columns["day"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);            //フォント設定
            this.dgvList.Columns["car_name"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);       //フォント設定
            this.dgvList.Columns["used_user_name"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular); //フォント設定
            this.dgvList.Columns["start_time"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);     //フォント設定
            this.dgvList.Columns["end_time"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);       //フォント設定
            this.dgvList.Columns["start_odo"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);      //フォント設定
            this.dgvList.Columns["end_odo"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);        //フォント設定
            this.dgvList.Columns["distance"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);       //フォント設定
            this.dgvList.Columns["from_point"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);     //フォント設定
            this.dgvList.Columns["to_point"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);       //フォント設定
            this.dgvList.Columns["note"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);           //フォント設定
            this.dgvList.Columns["gas_stock"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);      //フォント設定
            this.dgvList.Columns["check_alcohol"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);  //フォント設定
            this.dgvList.Columns["delete_flag"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);    //フォント設定

            //this.dgvSelect1.ScrollBars = false;                                                                        //スクロールバー非表示
            this.dgvList.MultiSelect = false;                                                                         //複数選択
            this.dgvList.ReadOnly = true;                                                                             //読込専用
            this.dgvList.AllowUserToAddRows = false;                                                                  //行追加無効
            this.dgvList.RowHeadersVisible = false;                                                                   //行ヘッダ非表示
            // this.dgvLocationCar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;                                     //行選択時は１行全て選択状態にする
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
                    // 2026/01/08 UPD (S)
                    // sb.AppendLine(" zai_flag = " + ClsPublic.FLAG_ON);
                    sb.AppendLine(" delete_flag != " + ClsPublic.FLAG_ON);
                    // 2026/01/08 UPD (E)
                    sb.AppendLine("AND");
                    sb.AppendLine(" proxy_flag = " + ClsPublic.FLAG_ON);
                    sb.AppendLine("ORDER BY");
                    sb.AppendLine(" sort");

                    // 最初の空行
                    dr = dt.NewRow();
                    dr["Code"] = "0";
                    dr["Name"] = "";
                    dt.Rows.Add(dr);

                    // 処理改善 2025/0902
                    using(DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
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
                    sb.AppendLine("Mst_社用車");
                    sb.AppendLine("ORDER BY");
                    sb.AppendLine("car_no");

                    // 最初の空行
                    dr = dt.NewRow();
                    dr["Code"] = "0";
                    dr["Name"] = "";
                    dt.Rows.Add(dr);

                    using(DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
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
        /// 走行記録表示(SQL Server)
        /// </summary>
        private void DisplayList()
        {
            // 抽出条件設定
            var staff_id = -1;
            var car_id = -1;
            var delete_flag = 0;
            // 利用者
            if (this.cmbUser.Text != "") { staff_id = int.Parse(this.cmbUser.SelectedValue.ToString()); }
            // 社用車
            if (this.cmbCar.Text != "") { car_id = int.Parse(this.cmbCar.SelectedValue.ToString()); }
            // 削除含む
            if (this.chkDelete.Checked == true) { delete_flag = 1; }

            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" id");
                    sb.AppendLine(",car_id");
                    sb.AppendLine(",car_name");
                    sb.AppendLine(",used_user_id");
                    sb.AppendLine(",used_user_name");
                    sb.AppendLine(",day");
                    sb.AppendLine(",start_time");
                    sb.AppendLine(",end_time");
                    sb.AppendLine(",start_odo");
                    sb.AppendLine(",end_odo");
                    sb.AppendLine(",distance");
                    sb.AppendLine(",check_alcohol");
                    sb.AppendLine(",from_point");
                    sb.AppendLine(",to_point");
                    sb.AppendLine(",note");
                    sb.AppendLine(",gas_stock");
                    sb.AppendLine(",delete_flag");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Trn_走行記録");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("day >= '" + this.dtpDate1.Value.ToString("yyyy/MM/dd") + "'");
                    sb.AppendLine("AND");
                    sb.AppendLine("day <= '" + this.dtpDate2.Value.ToString("yyyy/MM/dd") + "'");
                    if (staff_id != -1)
                    {
                        // 利用者の指定有り
                        sb.AppendLine("AND");
                        sb.AppendLine("used_user_id = " + staff_id.ToString());
                    }
                    if (car_id != -1)
                    {
                        // 社用車の指定有り
                        sb.AppendLine("AND");
                        sb.AppendLine("car_id = " + car_id.ToString());
                    }
                    if (delete_flag == 0)
                    {
                        // 削除は含まない
                        sb.AppendLine("AND");
                        sb.AppendLine("delete_flag = " + ClsPublic.FLAG_OFF);
                    }
                    sb.AppendLine("ORDER BY");
                    sb.AppendLine(" car_id ASC");
                    sb.AppendLine(",day DESC");
                    sb.AppendLine(",start_time DESC");

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
                            this.dgvList.Rows[row].Cells["car_name"].Value = dr["car_name"].ToString();                                         // car_name
                            this.dgvList.Rows[row].Cells["used_user_id"].Value = dr["used_user_id"].ToString();                                 // used_user_id
                            this.dgvList.Rows[row].Cells["used_user_name"].Value = dr["used_user_name"].ToString();                             // used_user_name
                            this.dgvList.Rows[row].Cells["day"].Value = DateTime.Parse(dr["day"].ToString()).ToString("yyyy/MM/dd");            // day
                            if (dr.IsNull("start_time") != true)
                            {
                                // 初期値（未入力）判定
                                if (dr["start_time"].ToString().Substring(dr["start_time"].ToString().Length - 8) != " 0:00:00")
                                {
                                    // 入力有りの場合は表示
                                    this.dgvList.Rows[row].Cells["start_time"].Value = DateTime.Parse(dr["start_time"].ToString()).ToString("HH:mm");   // start_time
                                }
                            }
                            if (dr.IsNull("end_time") != true)
                            {
                                // 初期値（未入力）判定
                                if (dr["end_time"].ToString().Substring(dr["end_time"].ToString().Length - 8) != " 0:00:00")
                                {
                                    // 入力有りの場合は表示
                                    this.dgvList.Rows[row].Cells["end_time"].Value = DateTime.Parse(dr["end_time"].ToString()).ToString("HH:mm");      // end_time
                                }
                            }
                            // 出発時メーター
                            if (dr.IsNull("start_odo") != true)
                            {
                                this.dgvList.Rows[row].Cells["start_odo"].Value = dr["start_odo"].ToString();                                 // start_odo
                            }
                            // 到着時メーター
                            if (dr.IsNull("end_odo") != true)
                            {
                                this.dgvList.Rows[row].Cells["end_odo"].Value = dr["end_odo"].ToString();                                     // end_odo
                            }
                            // 走行距離
                            if (dr.IsNull("distance") != true)
                            {
                                this.dgvList.Rows[row].Cells["distance"].Value = dr["distance"].ToString();                                   // distance
                            }
                            // 給油良
                            if (dr.IsNull("gas_stock") != true)
                            {
                                this.dgvList.Rows[row].Cells["gas_stock"].Value = dr["gas_stock"].ToString();                                 // gas_stock
                            }
                            // アルコールチェック
                            if (dr.IsNull("check_alcohol") != true)
                            {
                                if (dr["check_alcohol"].ToString() == "0")
                                {
                                    this.dgvList.Rows[row].Cells["check_alcohol"].Value = "良";
                                }
                                else
                                {
                                    this.dgvList.Rows[row].Cells["check_alcohol"].Value = "否";
                                }
                            }
                            // 行先(From)
                            this.dgvList.Rows[row].Cells["from_point"].Value = dr["from_point"].ToString();                                   // from_point
                                                                                                                                              // 行先(To)
                            this.dgvList.Rows[row].Cells["to_point"].Value = dr["to_point"].ToString();                                       // to_point
                                                                                                                                              // 補足
                            this.dgvList.Rows[row].Cells["note"].Value = dr["note"].ToString();                                               // note
                                                                                                                                              // 削除
                            if (dr["delete_flag"].ToString() == ClsPublic.FLAG_OFF.ToString())
                            {
                                this.dgvList.Rows[row].Cells["delete_flag"].Value = " ";
                            }
                            else
                            {
                                this.dgvList.Rows[row].Cells["delete_flag"].Value = "消";
                            }
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
        /// 一覧表示ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisplay_Click(object sender, EventArgs e)
        {
            DisplayList();
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
        /// セルクリック（編集ボタン）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // ボタン列がクリックされたかを確認
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) // 0 はボタン列のインデックス
            {
                // ID取得
                var id = int.Parse(((DataGridView)sender).Rows[e.RowIndex].Cells[1].Value.ToString());

                // 確認メッセージ
                // if (MessageBox.Show("ID = " + id, "確認", MessageBoxButtons.OKCancel) == DialogResult.Cancel) { return; }

                // 編集画面に遷移
                frmCarEdit cls = new()
                {
                    Id = id
                };
                cls.ShowDialog();
                cls.Dispose();

                // 再表示
                DisplayList();
            }

        }
        /// <summary>
        /// 追加ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCarEdit cls = new()
            {
                // idには0指定
                Id = 0
            };
            cls.ShowDialog();
            cls.Dispose();
        }
        /// <summary>
        /// エクセル出力ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("表示されている内容を出力しますか？", "確認", MessageBoxButtons.OKCancel) == DialogResult.Cancel) { return; }

            // 表示件数チェック
            if (this.dgvList.Rows.Count < 1) { return; }

            pubForm.frmMessageBox frmMsg = new();

            try
            {
                int ex_row = 0;
                string car_name = "";

                // 出力ファイル名編集
                var output_filename = ClsPublic.pubRootPath + @"\車両管理\走行記録エクセル\" + DateTime.Now.ToString("yyyyMMddhhmmss") + "_走行記録.xlsx";
                // ファイルコピー
                File.Copy(ClsPublic.pubRootPath + @"\車両管理\走行記録_原紙.xlsx", output_filename);

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


                // 最終行から1行ずつ読み込む
                for (var row = this.dgvList.RowCount - 1; row >= 0; row--)
                {
                    // 社用車名比較
                    if (car_name != this.dgvList.Rows[row].Cells["car_name"].Value.ToString().Replace(":", ""))
                    {
                        // 社用車名保持
                        car_name = this.dgvList.Rows[row].Cells["car_name"].Value.ToString().Replace(":", "");

                        using (ClsMsExcel clsEx = new())
                        {
                            // ファイル名,シート名指定
                            clsEx.FileName = output_filename;
                            clsEx.SheetName = "原紙";

                            // ブックオープン（シートは指定無し）
                            clsEx.OpenBook();

                            // 変わった場合はシートをコピーしシート名を社用車名に変更する
                            clsEx.CopySheet("原紙", car_name);

                            //    // Close
                            //    clsEx.CloseSaveBook();
                            //}
                            //using(clsMsExcel clsEx = new clsMsExcel())
                            //{
                            // ファイル名,シート名指定
                            clsEx.FileName = output_filename;
                            clsEx.SheetName = car_name;

                            //    // ブックオープン（シートは指定無し）
                            //    clsEx.OpenBook();

                            // シートをアクティブにする
                            clsEx.ActiveSheet(car_name);

                            // =========================================
                            // 日付(from,to)と社用車をヘッダーに出力
                            // =========================================
                            // 日付(from)
                            clsEx.Value = this.dtpDate1.Value.ToString("yyyy/MM/dd");
                            clsEx.Row = 1;                // 出力先Row
                            clsEx.Col = 16;               // 出力先Col
                            clsEx.FontSize = 10;
                            clsEx.SetCell();
                            // 日付(to)
                            clsEx.Value = this.dtpDate2.Value.ToString("yyyy/MM/dd");
                            clsEx.Row = 1;                // 出力先Row
                            clsEx.Col = 22;               // 出力先Col
                            clsEx.FontSize = 10;
                            clsEx.SetCell();
                            // 社用車名
                            clsEx.Value = this.dgvList.Rows[row].Cells["car_name"].Value.ToString();
                            clsEx.Row = 1;                // 出力先Row
                            clsEx.Col = 32;               // 出力先Col
                            clsEx.FontSize = 10;
                            clsEx.SetCell();

                            // Close
                            clsEx.CloseSaveBook();
                        }
                        // エクセル出力Row初期化
                        ex_row = 3;
                    }

                    using (ClsMsExcel clsEx = new())
                    {
                        ex_row++;

                        // ファイル名,シート名指定
                        clsEx.FileName = output_filename;
                        clsEx.SheetName = car_name;

                        // ファイルオープン
                        clsEx.OpenBook();

                        // ================================================================
                        // 一覧内容を出力
                        // ================================================================
                        // 日付
                        clsEx.Value = this.dgvList.Rows[row].Cells["day"].Value.ToString();
                        clsEx.Row = ex_row;             // 出力先Row
                        clsEx.Col = 1;                  // 出力先Col
                        clsEx.FontSize = 9;
                        clsEx.SetCell();

                        // 出発時刻
                        if (this.dgvList.Rows[row].Cells["start_time"].Value != null)
                        {
                            clsEx.Value = this.dgvList.Rows[row].Cells["start_time"].Value.ToString();
                            clsEx.Row = ex_row;             // 出力先Row
                            clsEx.Col = 6;                  // 出力先Col
                            clsEx.FontSize = 9;
                            clsEx.SetCell();
                        }

                        // 到着時刻
                        if (this.dgvList.Rows[row].Cells["end_time"].Value != null)
                        {
                            clsEx.Value = this.dgvList.Rows[row].Cells["end_time"].Value.ToString();
                            clsEx.Row = ex_row;            // 出力先Row
                            clsEx.Col = 9;                  // 出力先Col
                            clsEx.FontSize = 9;
                            clsEx.SetCell();
                        }

                        // 出発時メーター
                        if (this.dgvList.Rows[row].Cells["start_odo"].Value != null)
                        {
                            clsEx.Value = this.dgvList.Rows[row].Cells["start_odo"].Value.ToString();
                            clsEx.Row = ex_row;            // 出力先Row
                            clsEx.Col = 12;                 // 出力先Col
                            clsEx.FontSize = 9;
                            clsEx.SetCell();
                        }
                        // 到着時メーター
                        if (this.dgvList.Rows[row].Cells["end_odo"].Value != null)
                        {
                            clsEx.Value = this.dgvList.Rows[row].Cells["end_odo"].Value.ToString();
                            clsEx.Row = ex_row;            // 出力先Row
                            clsEx.Col = 16;                 // 出力先Col
                            clsEx.FontSize = 9;
                            clsEx.SetCell();
                        }
                        // 距離
                        if (this.dgvList.Rows[row].Cells["distance"].Value != null)
                        {
                            clsEx.Value = this.dgvList.Rows[row].Cells["distance"].Value.ToString();
                            clsEx.Row = ex_row;            // 出力先Row
                            clsEx.Col = 20;                 // 出力先Col
                            clsEx.FontSize = 9;
                            clsEx.SetCell();
                        }

                        // 行先(from)
                        clsEx.Value = this.dgvList.Rows[row].Cells["from_point"].Value.ToString();
                        clsEx.Row = ex_row;            // 出力先Row
                        clsEx.Col = 23;                 // 出力先Col
                        clsEx.FontSize = 9;
                        clsEx.SetCell();
                        // 行先(to)
                        clsEx.Value = this.dgvList.Rows[row].Cells["to_point"].Value.ToString();
                        clsEx.Row = ex_row;            // 出力先Row
                        clsEx.Col = 28;                 // 出力先Col
                        clsEx.FontSize = 9;
                        clsEx.SetCell();
                        // 補足
                        clsEx.Value = this.dgvList.Rows[row].Cells["note"].Value.ToString();
                        clsEx.Row = ex_row;            // 出力先Row
                        clsEx.Col = 33;                 // 出力先Col
                        clsEx.FontSize = 9;
                        clsEx.SetCell();

                        // 給油
                        if (this.dgvList.Rows[row].Cells["gas_stock"].Value != null)
                        {
                            clsEx.Value = this.dgvList.Rows[row].Cells["gas_stock"].Value.ToString();
                            clsEx.Row = ex_row;            // 出力先Row
                            clsEx.Col = 47;                 // 出力先Col
                            clsEx.FontSize = 9;
                            clsEx.SetCell();
                        }

                        // 利用者
                        clsEx.Value = this.dgvList.Rows[row].Cells["used_user_name"].Value.ToString();
                        clsEx.Row = ex_row;            // 出力先Row
                        clsEx.Col = 50;                 // 出力先Col
                        clsEx.FontSize = 9;
                        clsEx.SetCell();

                        // アルコールチェック
                        if (this.dgvList.Rows[row].Cells["check_alcohol"].Value != null)
                        {
                            clsEx.Value = this.dgvList.Rows[row].Cells["check_alcohol"].Value.ToString();
                            clsEx.Row = ex_row;            // 出力先Row
                            clsEx.Col = 54;                 // 出力先Col
                            clsEx.FontSize = 9;
                            clsEx.SetCell();
                        }
                        // Close
                        clsEx.CloseSaveBook();
                    }
                }

                // ====================================================================
                // 2025/03/07 日付・時刻の古い順に出力を行うように変更の為、以下は削除
                // ====================================================================
                //// 一覧を1行目から読み込む（社用車が変わったタイミングでシートをコピー）
                //for (var row = 0; row < this.dgvList.RowCount; row++)
                //{
                //    // 社用車名比較
                //    if (car_name != this.dgvList.Rows[row].Cells["car_name"].Value.ToString().Replace(":", ""))
                //    {
                //        // 社用車名保持
                //        car_name = this.dgvList.Rows[row].Cells["car_name"].Value.ToString().Replace(":", "");

                //        using(clsMsExcel clsEx = new clsMsExcel())
                //        {
                //            // ファイル名,シート名指定
                //            clsEx.FileName = output_filename;
                //            clsEx.SheetName = "原紙";

                //            // ブックオープン（シートは指定無し）
                //            clsEx.OpenBook();

                //            // 変わった場合はシートをコピーしシート名を社用車名に変更する
                //            clsEx.CopySheet("原紙", car_name);

                //            //    // Close
                //            //    clsEx.CloseSaveBook();
                //            //}
                //            //using(clsMsExcel clsEx = new clsMsExcel())
                //            //{
                //            // ファイル名,シート名指定
                //            clsEx.FileName = output_filename;
                //            clsEx.SheetName = car_name;

                //            //    // ブックオープン（シートは指定無し）
                //            //    clsEx.OpenBook();

                //            // シートをアクティブにする
                //            clsEx.ActiveSheet(car_name);

                //            // =========================================
                //            // 日付(from,to)と社用車をヘッダーに出力
                //            // =========================================
                //            // 日付(from)
                //            clsEx.Value = this.dtpDate1.Value.ToString("yyyy/MM/dd");
                //            clsEx.Row = 1;                // 出力先Row
                //            clsEx.Col = 16;               // 出力先Col
                //            clsEx.FontSize = 10;
                //            clsEx.SetCell();
                //            // 日付(to)
                //            clsEx.Value = this.dtpDate2.Value.ToString("yyyy/MM/dd");
                //            clsEx.Row = 1;                // 出力先Row
                //            clsEx.Col = 22;               // 出力先Col
                //            clsEx.FontSize = 10;
                //            clsEx.SetCell();
                //            // 社用車名
                //            clsEx.Value = this.dgvList.Rows[row].Cells["car_name"].Value.ToString();
                //            clsEx.Row = 1;                // 出力先Row
                //            clsEx.Col = 32;               // 出力先Col
                //            clsEx.FontSize = 10;
                //            clsEx.SetCell();

                //            // Close
                //            clsEx.CloseSaveBook();
                //        }
                //        // エクセル出力Row初期化
                //        ex_row = 3;
                //    }

                //    using(clsMsExcel clsEx = new clsMsExcel())
                //    {
                //        ex_row++;

                //        // ファイル名,シート名指定
                //        clsEx.FileName = output_filename;
                //        clsEx.SheetName = car_name;

                //        // ファイルオープン
                //        clsEx.OpenBook();

                //        // ================================================================
                //        // 一覧内容を出力
                //        // ================================================================
                //        // 日付
                //        clsEx.Value = this.dgvList.Rows[row].Cells["day"].Value.ToString();
                //        clsEx.Row = ex_row;             // 出力先Row
                //        clsEx.Col = 1;                  // 出力先Col
                //        clsEx.FontSize = 9;
                //        clsEx.SetCell();

                //        // 出発時刻
                //        if (this.dgvList.Rows[row].Cells["start_time"].Value != null)
                //        {
                //            clsEx.Value = this.dgvList.Rows[row].Cells["start_time"].Value.ToString();
                //            clsEx.Row = ex_row;             // 出力先Row
                //            clsEx.Col = 6;                  // 出力先Col
                //            clsEx.FontSize = 9;
                //            clsEx.SetCell();
                //        }

                //        // 到着時刻
                //        if (this.dgvList.Rows[row].Cells["end_time"].Value != null)
                //        {
                //            clsEx.Value = this.dgvList.Rows[row].Cells["end_time"].Value.ToString();
                //            clsEx.Row = ex_row;            // 出力先Row
                //            clsEx.Col = 9;                  // 出力先Col
                //            clsEx.FontSize = 9;
                //            clsEx.SetCell();
                //        }

                //        // 出発時メーター
                //        if (this.dgvList.Rows[row].Cells["start_odo"].Value != null)
                //        {
                //            clsEx.Value = this.dgvList.Rows[row].Cells["start_odo"].Value.ToString();
                //            clsEx.Row = ex_row;            // 出力先Row
                //            clsEx.Col = 12;                 // 出力先Col
                //            clsEx.FontSize = 9;
                //            clsEx.SetCell();
                //        }
                //        // 到着時メーター
                //        if (this.dgvList.Rows[row].Cells["end_odo"].Value != null)
                //        {
                //            clsEx.Value = this.dgvList.Rows[row].Cells["end_odo"].Value.ToString();
                //            clsEx.Row = ex_row;            // 出力先Row
                //            clsEx.Col = 16;                 // 出力先Col
                //            clsEx.FontSize = 9;
                //            clsEx.SetCell();
                //        }
                //        // 距離
                //        if (this.dgvList.Rows[row].Cells["distance"].Value != null)
                //        {
                //            clsEx.Value = this.dgvList.Rows[row].Cells["distance"].Value.ToString();
                //            clsEx.Row = ex_row;            // 出力先Row
                //            clsEx.Col = 20;                 // 出力先Col
                //            clsEx.FontSize = 9;
                //            clsEx.SetCell();
                //        }

                //        // 行先(from)
                //        clsEx.Value = this.dgvList.Rows[row].Cells["from_point"].Value.ToString();
                //        clsEx.Row = ex_row;            // 出力先Row
                //        clsEx.Col = 23;                 // 出力先Col
                //        clsEx.FontSize = 9;
                //        clsEx.SetCell();
                //        // 行先(to)
                //        clsEx.Value = this.dgvList.Rows[row].Cells["to_point"].Value.ToString();
                //        clsEx.Row = ex_row;            // 出力先Row
                //        clsEx.Col = 28;                 // 出力先Col
                //        clsEx.FontSize = 9;
                //        clsEx.SetCell();
                //        // 補足
                //        clsEx.Value = this.dgvList.Rows[row].Cells["note"].Value.ToString();
                //        clsEx.Row = ex_row;            // 出力先Row
                //        clsEx.Col = 33;                 // 出力先Col
                //        clsEx.FontSize = 9;
                //        clsEx.SetCell();

                //        // 給油
                //        if (this.dgvList.Rows[row].Cells["gas_stock"].Value != null)
                //        {
                //            clsEx.Value = this.dgvList.Rows[row].Cells["gas_stock"].Value.ToString();
                //            clsEx.Row = ex_row;            // 出力先Row
                //            clsEx.Col = 47;                 // 出力先Col
                //            clsEx.FontSize = 9;
                //            clsEx.SetCell();
                //        }

                //        // 利用者
                //        clsEx.Value = this.dgvList.Rows[row].Cells["used_user_name"].Value.ToString();
                //        clsEx.Row = ex_row;            // 出力先Row
                //        clsEx.Col = 50;                 // 出力先Col
                //        clsEx.FontSize = 9;
                //        clsEx.SetCell();

                //        // アルコールチェック
                //        if (this.dgvList.Rows[row].Cells["check_alcohol"].Value != null)
                //        {
                //            clsEx.Value = this.dgvList.Rows[row].Cells["check_alcohol"].Value.ToString();
                //            clsEx.Row = ex_row;            // 出力先Row
                //            clsEx.Col = 54;                 // 出力先Col
                //            clsEx.FontSize = 9;
                //            clsEx.SetCell();
                //        }
                //        // Close
                //        clsEx.CloseSaveBook();
                //    }
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
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
        /// <summary>
        /// メッセージ登録画面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMsg_Click(object sender, EventArgs e)
        {
            using (frmCarMsg cls = new())
            {
                cls.ShowDialog();
            }
        }
    }
}
