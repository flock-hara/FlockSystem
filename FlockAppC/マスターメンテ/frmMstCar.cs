using FlockAppC.pubClass;
using FlockAppC.tblClass;
using FlockAppC.選択画面;
using Org.BouncyCastle.Pqc.Crypto.Lms;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FlockAppC.マスターメンテ
{
    public partial class frmMstCar : Form
    {
        private int Id {  get; set; }
        private int Id2 { get; set; }

        private readonly StringBuilder sb = new();

        public frmMstCar()
        {
            InitializeComponent();
        }
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMstCar_Load(object sender, EventArgs e)
        {
            // Initialize DataGridView
            SetDgvList();
            SetDgvList2();
            InitializeForm(true);
            DisplayCarList();

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
            DataGridViewTextBoxColumn col06 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col07 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col08 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col09 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col10 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col11 = new DataGridViewTextBoxColumn();

            col01.Name = "CarID";
            col01.HeaderText = "ID";
            col01.Width = 80;
            col01.Visible = false;

            col02.Name = "CarNo";
            col02.HeaderText = "車番";
            col02.Width = 80;
            col02.Visible = true;

            col03.Name = "CarName";
            col03.HeaderText = "車種";
            col03.Width = 100;
            col03.Visible = true;

            col04.Name = "RegNo";
            col04.HeaderText = "登録番号";
            col04.Width = 120;
            col04.Visible = true;

            col05.Name = "BaseNo";
            col05.HeaderText = "車台番号";
            col05.Width = 140;
            col05.Visible = true;

            col06.Name = "Etc";
            col06.HeaderText = "装着";
            col06.Width = 180;
            col06.Visible = false;

            col07.Name = "UsedUser";
            col07.HeaderText = "使用者";
            col07.Width = 100;
            col07.Visible = true;

            col08.Name = "FirstDate";
            col08.HeaderText = "初年度";
            col08.Width = 120;
            col08.Visible = true;

            col09.Name = "GetDate";
            col09.HeaderText = "取得日";
            col09.Width = 140;
            col09.Visible = true;

            col10.Name = "FullDate";
            col10.HeaderText = "車検満了";
            col10.Width = 140;
            col10.Visible = true;

            col11.Name = "comment";
            col11.HeaderText = "備考";
            col11.Width = 210;
            col11.Visible = true;

            this.dgvCarList.Columns.Add(col01);
            this.dgvCarList.Columns.Add(col02);
            this.dgvCarList.Columns.Add(col03);
            this.dgvCarList.Columns.Add(col04);
            this.dgvCarList.Columns.Add(col05);
            this.dgvCarList.Columns.Add(col06);
            this.dgvCarList.Columns.Add(col07);
            this.dgvCarList.Columns.Add(col08);
            this.dgvCarList.Columns.Add(col09);
            this.dgvCarList.Columns.Add(col10);
            this.dgvCarList.Columns.Add(col11);

            //並び替えができないようにする
            foreach (DataGridViewColumn c in this.dgvCarList.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable; 

            this.dgvCarList.EnableHeadersVisualStyles = false;                                                               //Windows Color無効
            this.dgvCarList.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.CornflowerBlue;                   //列ヘッダ色
            // this.dgvCarList.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.PowderBlue;                   //列ヘッダ色
            // this.dgvCarList.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.LightSteelBlue;                   //列ヘッダ色
            this.dgvCarList.RowTemplate.Height = 25;                                                                         //行高さ
            this.dgvCarList.AllowUserToResizeColumns = false;                                                                //列幅の変更不可
            this.dgvCarList.AllowUserToResizeRows = false;                                                                   //行高さの変更不可
            this.dgvCarList.ColumnHeadersVisible = true;                                                                     //列ヘッダ非表示

            // 列ヘッダー文字位置
            this.dgvCarList.Columns["CarNo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvCarList.Columns["CarName"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvCarList.Columns["RegNo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvCarList.Columns["BaseNo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
　          this.dgvCarList.Columns["Etc"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvCarList.Columns["UsedUser"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvCarList.Columns["FirstDate"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvCarList.Columns["GetDate"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvCarList.Columns["FullDate"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvCarList.Columns["comment"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // セル内表示位置
            this.dgvCarList.Columns["CarNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvCarList.Columns["CarName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvCarList.Columns["RegNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvCarList.Columns["BaseNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvCarList.Columns["Etc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvCarList.Columns["UsedUser"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvCarList.Columns["FirstDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvCarList.Columns["GetDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvCarList.Columns["FullDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvCarList.Columns["comment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            //奇数行を黄色にする
            //// this.dgvCarList.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Moccasin;
            // this.dgvCarList.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.PaleTurquoise;
            this.dgvCarList.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.PowderBlue;


            // 選択した時の行のバックカラー
            // this.dgvCarList.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightBlue;
            this.dgvCarList.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SeaGreen;

            // フォント設定
            this.dgvCarList.Columns["CarNo"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);
            this.dgvCarList.Columns["CarName"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);
            this.dgvCarList.Columns["RegNo"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular); 
            this.dgvCarList.Columns["BaseNo"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);
            this.dgvCarList.Columns["Etc"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);
            this.dgvCarList.Columns["UsedUser"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);
            this.dgvCarList.Columns["FirstDate"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);
            this.dgvCarList.Columns["GetDate"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular); 
            this.dgvCarList.Columns["FullDate"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);
            this.dgvCarList.Columns["comment"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);

            // その他
            this.dgvCarList.MultiSelect = false;                                                                         //複数選択
            this.dgvCarList.ReadOnly = true;                                                                             //読込専用
            this.dgvCarList.AllowUserToAddRows = false;                                                                  //行追加無効
            this.dgvCarList.RowHeadersVisible = false;                                                                   //行ヘッダ非表示
            this.dgvCarList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;                                     //行選択時は１行全て選択状態にする
        }
        /// <summary>
        /// DataGridView設定2
        /// </summary>
        private void SetDgvList2()
        {
            DataGridViewTextBoxColumn col01 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col02 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col03 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col04 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col05 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col06 = new DataGridViewTextBoxColumn();

            col01.Name = "ID";
            col01.HeaderText = "ID";
            col01.Width = 80;
            col01.Visible = false;

            col02.Name = "CarID";
            col02.HeaderText = "CarID";
            col02.Width = 80;
            col02.Visible = false;

            col03.Name = "OilChangeDate";
            col03.HeaderText = "ｵｲﾙ交換日";
            col03.Width = 140;
            col03.Visible = true;

            col04.Name = "OilChangeODO";
            col04.HeaderText = "メーター";
            col04.Width = 90;
            col04.Visible = true;

            col05.Name = "UsedUserID";
            col05.HeaderText = "UsedUserID";
            col05.Width = 100;
            col05.Visible = false;

            col06.Name = "UsedUserName";
            col06.HeaderText = "使用者";
            col06.Width = 80;
            col06.Visible = true;

            this.dgvOil.Columns.Add(col01);
            this.dgvOil.Columns.Add(col02);
            this.dgvOil.Columns.Add(col03);
            this.dgvOil.Columns.Add(col04);
            this.dgvOil.Columns.Add(col05);
            this.dgvOil.Columns.Add(col06);

            //並び替えができないようにする
            foreach (DataGridViewColumn c in this.dgvOil.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            this.dgvOil.EnableHeadersVisualStyles = false;                                                               //Windows Color無効
            this.dgvOil.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.CornflowerBlue;                   //列ヘッダ色
            this.dgvOil.RowTemplate.Height = 25;                                                                         //行高さ
            this.dgvOil.AllowUserToResizeColumns = false;                                                                //列幅の変更不可
            this.dgvOil.AllowUserToResizeRows = false;                                                                   //行高さの変更不可
            this.dgvOil.ColumnHeadersVisible = true;                                                                     //列ヘッダ非表示

            // 列ヘッダー文字位置
            this.dgvOil.Columns["OilChangeDate"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvOil.Columns["OilChangeODO"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvOil.Columns["UsedUserName"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // セル内表示位置
            this.dgvOil.Columns["OilChangeDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvOil.Columns["OilChangeODO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvOil.Columns["UsedUserName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //奇数行を黄色にする
            //// this.dgvCarList.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Moccasin;
            this.dgvOil.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.PaleTurquoise;

            // 選択した時の行のバックカラー
            this.dgvOil.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SeaGreen;

            // フォント設定
            this.dgvOil.Columns["OilChangeDate"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);
            this.dgvOil.Columns["OilChangeODO"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);
            this.dgvOil.Columns["UsedUserName"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);

            // その他
            this.dgvOil.MultiSelect = false;                                                                         //複数選択
            this.dgvOil.ReadOnly = true;                                                                             //読込専用
            this.dgvOil.AllowUserToAddRows = false;                                                                  //行追加無効
            this.dgvOil.RowHeadersVisible = false;                                                                   //行ヘッダ非表示
            this.dgvOil.SelectionMode = DataGridViewSelectionMode.FullRowSelect;                                     //行選択時は１行全て選択状態にする
        }
        /// <summary>
        /// フォーム入力エリア初期化
        /// </summary>
        private void InitializeForm(bool p_flg)
        {
            this.Id = 0;
            this.txtCarNo.Text = "";
            this.txtCarName.Text = "";
            this.txtCarRegNumber.Text = "";
            this.txtEtc.Text = "";
            this.txtComment.Text = "";
            this.txtCarBaseNumber.Text = "";
            this.txtStaffName.Text = "";
            this.mtxtFirstDate.Text = "____/__";
            this.mtxtGetDate.Text = "____/__/__";
            this.mtxtFullDate.Text = "____/__/__";
            this.lblStaffId.Text = "";
            this.lblNew.Visible = p_flg;

            // オイル履歴
            this.Id2 = 0;
            this.mtxtChangeDate.Text = "____/__/__";
            this.txtChangeODO.Text = "";
            this.txtStaffName2.Text = "";
            this.lblStaffId2.Text = "";
            this.lblNew2.Visible = p_flg;
            dgvOil.Rows.Clear();
        }
        /// <summary>
        /// 社用車情報表示
        /// </summary>
        private void DisplayCarList()
        {
            var row = 0;

            try
            {
                this.dgvCarList.Rows.Clear();

                ClsMstCar clsMstCar = new()
                {
                    id = 0       // 全件検索
                };
                clsMstCar.Select();
                DataTable dt_val = clsMstCar.Dt;
                // 件数0は処理終了
                if (dt_val.Rows.Count == 0) return;
                // 画面に表示
                foreach (DataRow dr in dt_val.Rows)
                {
                    this.dgvCarList.Rows.Add();
                    this.dgvCarList.Rows[row].Cells["CarID"].Value = dr["id"].ToString();
                    this.dgvCarList.Rows[row].Cells["CarNo"].Value = dr["car_no"].ToString();
                    this.dgvCarList.Rows[row].Cells["CarName"].Value = dr["car_name"].ToString();
                    this.dgvCarList.Rows[row].Cells["RegNo"].Value = dr["reg_no"].ToString();
                    this.dgvCarList.Rows[row].Cells["BaseNo"].Value = dr["base_no"].ToString();
                    if (DateTime.Parse(dr["first_date"].ToString()).ToString("yyyy/MM/dd") == "1900/01/01") { this.dgvCarList.Rows[row].Cells["FirstDate"].Value = ""; }
                    else { this.dgvCarList.Rows[row].Cells["FirstDate"].Value = DateTime.Parse(dr["first_date"].ToString()).ToString("yyyy年MM月"); }
                    if (DateTime.Parse(dr["get_date"].ToString()).ToString("yyyy/MM/dd") == "1900/01/01") { this.dgvCarList.Rows[row].Cells["GetDate"].Value = ""; }
                    else { this.dgvCarList.Rows[row].Cells["GetDate"].Value = DateTime.Parse(dr["get_date"].ToString()).ToString("yyyy年MM月dd日"); }
                    if (DateTime.Parse(dr["full_date"].ToString()).ToString("yyyy/MM/dd") == "1900/01/01") { this.dgvCarList.Rows[row].Cells["FullDate"].Value = ""; }
                    else { this.dgvCarList.Rows[row].Cells["FullDate"].Value = DateTime.Parse(dr["full_date"].ToString()).ToString("yyyy年MM月dd日"); }
                    this.dgvCarList.Rows[row].Cells["RegNo"].Value = dr["reg_no"].ToString();
                    this.dgvCarList.Rows[row].Cells["UsedUser"].Value = dr["name1"].ToString();
                    this.dgvCarList.Rows[row].Cells["Comment"].Value = dr["comment"].ToString();
                    row++;
                }

                this.dgvCarList.ClearSelection();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private void frmMstCar_Shown(object sender, EventArgs e)
        {
            this.dgvCarList.ClearSelection();
        }
        /// <summary>
        /// 社用車一覧セルクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCarList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }

            // 新規ラベルを非表示→更新モードに
            InitializeForm(false);

            //クリックされたセルのID取得
            Id = int.Parse(this.dgvCarList.Rows[e.RowIndex].Cells[0].Value.ToString());

            try
            {
                // 社用車クラス
                ClsMstCar clsMstCar = new()
                {
                    id = Id          // 条件指定有り
                };
                clsMstCar.Select();
                DataTable dt_val = clsMstCar.Dt;
                // 件数0は処理終了
                if (dt_val.Rows.Count == 0) return;
                // 画面に表示
                foreach (DataRow dr in dt_val.Rows)
                {
                    Id = int.Parse(dr["id"].ToString());
                    this.txtCarNo.Text = dr["car_no"].ToString();
                    this.txtCarName.Text = dr["car_name"].ToString();
                    this.txtCarRegNumber.Text = dr["reg_no"].ToString();
                    this.txtCarBaseNumber.Text = dr["base_no"].ToString();
                    if (DateTime.Parse(dr["first_date"].ToString()).ToString("yyyy/MM") == "1900/01") { this.mtxtFirstDate.Text = "____/__/__"; }
                    else { this.mtxtFirstDate.Text = DateTime.Parse(dr["first_date"].ToString()).ToString("yyyy/MM"); }
                    if (DateTime.Parse(dr["get_date"].ToString()).ToString("yyyy/MM/dd") == "1900/01/01") { this.mtxtGetDate.Text = "____/__/__"; }
                    else { this.mtxtGetDate.Text = DateTime.Parse(dr["get_date"].ToString()).ToString("yyyy/MM/dd"); }
                    if (DateTime.Parse(dr["full_date"].ToString()).ToString("yyyy/MM/dd") == "1900/01/01") { this.mtxtFullDate.Text = "____/__/__"; }
                    else { this.mtxtFullDate.Text = DateTime.Parse(dr["full_date"].ToString()).ToString("yyyy/MM/dd"); }
                    this.txtEtc.Text = dr["etc"].ToString();
                    if (dr["used_user_id"].ToString() != "0") { this.lblStaffId.Text = dr["used_user_id"].ToString(); }
                    else { this.lblStaffId.Text = ""; }
                    this.txtStaffName.Text = dr["name1"].ToString();
                    this.txtComment.Text = dr["comment"].ToString();
                    break;
                }

                // オイル交換履歴表示
                DisplayOilChangeHistory();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// オイル交換履歴表示
        /// </summary>
        public void DisplayOilChangeHistory()
        {
            // var row = 0;
            
            try
            {
                this.Id2 = 0;
                this.mtxtChangeDate.Text = "____/__/__";
                this.txtChangeODO.Text = "";
                this.txtStaffName2.Text = "";
                this.lblStaffId2.Text = "";
                this.lblNew2.Visible = true;

                // オイル交換履歴
                this.dgvOil.Rows.Clear();
                // 社用車クラス
                ClsMstCar clsMstCar = new()
                {
                    id = Id
                };
                clsMstCar.SelectOil();
                DataTable dt_val = clsMstCar.Dt;
                // 件数0は処理終了
                if (dt_val.Rows.Count == 0) return;
                // 画面に表示
                int row = 0;
                foreach (DataRow dr in dt_val.Rows)
                {
                    this.dgvOil.Rows.Add();
                    this.dgvOil.Rows[row].Cells["ID"].Value = dr["id"].ToString();
                    this.dgvOil.Rows[row].Cells["CarID"].Value = dr["car_id"].ToString();
                    this.dgvOil.Rows[row].Cells["OilChangeDate"].Value = DateTime.Parse(dr["oil_change_date"].ToString()).ToString("yyyy年MM月dd日");
                    this.dgvOil.Rows[row].Cells["OilChangeODO"].Value = dr["oil_change_odo"].ToString();
                    this.dgvOil.Rows[row].Cells["UsedUserID"].Value = dr["used_user_id"].ToString();
                    this.dgvOil.Rows[row].Cells["UsedUserName"].Value = dr["name1"].ToString();
                    row++;
                }

                this.dgvOil.ClearSelection();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 使用者ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectStaff_Click(object sender, EventArgs e)
        {
            frmSelectStaff fSelectStaff = new()
            {
                TargetTable = "Mst_社員",
                Select_user_name = "",
                Select_user_id = 0,
                SelectUserKbn = 1             // 社員
            };
            fSelectStaff.ShowDialog();
            if (fSelectStaff.Select_user_id == 0) { return; }

            // 選択従業員情報取得
            this.lblNew.Visible = false;
            ClsMstStaff cMstStaff = new()
            {
                Id = fSelectStaff.Select_user_id
            };
            cMstStaff.GetStaff();

            this.lblStaffId.Text = cMstStaff.Id.ToString();
            this.txtStaffName.Text = cMstStaff.Name1;
        }
        /// <summary>
        /// オイル交換履歴セルクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvOil_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }

            // 新規ラベルを非表示→更新モードに
            this.lblNew2.Visible = false;

            //クリックされたセルのID取得
            Id2 = int.Parse(this.dgvOil.Rows[e.RowIndex].Cells[0].Value.ToString());

            // 選択行の情報をテキストボックスにセット
            var day = DateTime.Parse(this.dgvOil.Rows[e.RowIndex].Cells[2].Value.ToString());
            this.mtxtChangeDate.Text = day.ToString("yyyy/MM/dd");
            this.txtChangeODO.Text = this.dgvOil.Rows[e.RowIndex].Cells[3].Value.ToString();
            this.lblStaffId2.Text = this.dgvOil.Rows[e.RowIndex].Cells[4].Value.ToString();
            this.txtStaffName2.Text = this.dgvOil.Rows[e.RowIndex].Cells[5].Value.ToString();
        }
        /// <summary>
        /// 「新規」ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            InitializeForm(true);
            this.txtCarNo.Focus();
        }
        /// <summary>
        /// 「保存」ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReg_Click(object sender, EventArgs e)
        {
            // 入力チェック
            if (this.txtCarNo.Text == "" || this.txtCarName.Text == "")
            {
                MessageBox.Show("未入力項目があります。", "結果", MessageBoxButtons.OK);
                return;
            }

            // 入力データセット
            ClsMstCar clsMstCar = new()
            {
                id = Id,
                car_no = this.txtCarNo.Text,
                car_name = this.txtCarName.Text,
                reg_no = this.txtCarRegNumber.Text,
                base_no = this.txtCarBaseNumber.Text
            };
            // if (this.mtxtFirstDate.Text == "    /") { clsMstCar.first_date = DateTime.Parse("1900/01/01"); }
            if (this.mtxtFirstDate.Text == "    /  /" || this.mtxtFirstDate.Text == "    /") { clsMstCar.first_date = DateTime.Parse("1900/01/01"); }
            else { clsMstCar.first_date = DateTime.Parse(this.mtxtFirstDate.Text + "/01"); }

            // if (this.mtxtGetDate.Text == "    /") { clsMstCar.get_date = DateTime.Parse("1900/01/01"); }
            if (this.mtxtGetDate.Text == "    /  /" || this.mtxtGetDate.Text == "    /") { clsMstCar.get_date = DateTime.Parse("1900/01/01"); }
            else { clsMstCar.get_date = DateTime.Parse(this.mtxtGetDate.Text ); }
            // else { clsMstCar.get_date = DateTime.Parse(this.mtxtGetDate.Text + "/01"); }

            // if (this.mtxtFullDate.Text == "    /") { clsMstCar.full_date = DateTime.Parse("1900/01/01"); }
            if (this.mtxtFullDate.Text == "    /  /" || this.mtxtFullDate.Text == "    /") { clsMstCar.full_date = DateTime.Parse("1900/01/01"); }
            else { clsMstCar.full_date = DateTime.Parse(this.mtxtFullDate.Text); }
            // else { clsMstCar.full_date = DateTime.Parse(this.mtxtFullDate.Text + "/01"); }

            clsMstCar.etc = this.txtEtc.Text;
            if (this.lblStaffId.Text == "") { clsMstCar.used_user_id = 0; }
            else { clsMstCar.used_user_id = int.Parse(this.lblStaffId.Text); }
            clsMstCar.comment = this.txtComment.Text;

            if (clsMstCar.id > 0)
            {
                // UPDATE
                clsMstCar.Update();
            }
            else
            {
                // INSERT
                Id = clsMstCar.InsertScalar();
            }

            // 転送確認
            if (MessageBox.Show("登録しました。続けてサーバーに転送（同期）しますか？" + Environment.NewLine + "転送先 [" + ClsDbConfig.mysqlParam[ClsDbConfig.MySQLNo].Instance + "\\" + ClsDbConfig.mysqlParam[ClsDbConfig.MySQLNo].Database + "]", "確認", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                DisplayCarList();
                InitializeForm(true);
                return;
            }

            try
            {
                // 接続メッセージ
                this.lblConnect.Visible = true;

                // 転送（同期）処理
                using (ClsMySqlDb clsMySqlDb = new(ClsDbConfig.MySQLNo))
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    // Mst_社用車
                    clsMstCar.ExportOneCarData(Id, clsSqlDb, clsMySqlDb);
                }
                MessageBox.Show("転送しました。", "結果", MessageBoxButtons.OK);
                DisplayCarList();
                InitializeForm(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK);
                throw;
            }
            finally
            {
                // 接続メッセージ
                this.lblConnect.Visible = false;
            }
        }
        /// <summary>
        /// 「削除」ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // 車両未選択の場合は処理終了
            if (Id == 0)
            {
                MessageBox.Show("車両が選択されていません。", "確認", MessageBoxButtons.OK);
                return;
            }

            if (MessageBox.Show("削除します。","確認",MessageBoxButtons.OKCancel) == DialogResult.Cancel) { return; }

            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    // ========================================================
                    // 社用車マスター
                    // ========================================================
                    sb.Clear();
                    sb.AppendLine("UPDATE");
                    sb.AppendLine("Mst_社用車");
                    sb.AppendLine("SET");
                    sb.AppendLine(",upd_user_id = " + ClsLoginUser.StaffID);
                    sb.AppendLine(",upd_date = '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    sb.AppendLine(",delete_flag = " + ClsPublic.FLAG_ON);
                    sb.AppendLine("WHERE");
                    sb.AppendLine("car_id = " + Id);
                    clsSqlDb.DMLUpdate(sb.ToString());
                    //sb.Clear();
                    //sb.AppendLine("DELETE FROM");
                    //sb.AppendLine("Mst_社用車");
                    //sb.AppendLine("WHERE");
                    //sb.AppendLine("id = " + Id);
                    //clsSqlDb.DMLUpdate(sb.ToString());

                    // オイル交換履歴
                    sb.Clear();
                    sb.AppendLine("DELETE FROM");
                    sb.AppendLine("Trn_社用車オイル交換履歴");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("car_id = " + Id);
                    clsSqlDb.DMLUpdate(sb.ToString());

                    // ========================================================
                    // 社員マスター
                    // ========================================================
                    sb.Clear();
                    sb.AppendLine("UPDATE");
                    sb.AppendLine("Mst_社員");
                    sb.AppendLine("SET");
                    sb.AppendLine(" car_id = 0");
                    sb.AppendLine(",upd_user_id = " + ClsLoginUser.StaffID);
                    sb.AppendLine(",upd_date = '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("car_id = " + Id);
                    clsSqlDb.DMLUpdate(sb.ToString());
                }

                DisplayCarList();
                InitializeForm(true);

                MessageBox.Show("削除しました。", "結果", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// オイル交換履歴「新規」ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewOil_Click(object sender, EventArgs e)
        {
            // 車両未選択の場合は処理終了
            if (Id == 0) 
            {
                MessageBox.Show("車両が選択されていません。", "確認", MessageBoxButtons.OK);
                return; 
            }

            this.Id2 = 0;
            this.mtxtChangeDate.Text = "    /  /";
            this.txtChangeODO.Text = "";
            this.txtStaffName2.Text = "";
            this.lblStaffId2.Text = "";
            this.lblNew2.Visible = true;

            this.mtxtChangeDate.Focus();
        }
        /// <summary>
        /// オイル交換履歴「保存」ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegOil_Click(object sender, EventArgs e)
        {
            // 入力チェック
            if (this.mtxtChangeDate.Text == "____/__/__" || this.txtChangeODO.Text == "")
            {
                MessageBox.Show("未入力項目があります。", "結果", MessageBoxButtons.OK);
                return;
            }

            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    if (Id2 == 0)
                    {
                        // INSERT
                        sb.Clear();
                        sb.AppendLine("INSERT INTO");
                        sb.AppendLine("Trn_社用車オイル交換履歴");
                        sb.AppendLine("(");
                        sb.AppendLine(" car_id");
                        sb.AppendLine(",used_user_id");
                        sb.AppendLine(",oil_change_date");
                        sb.AppendLine(",oil_change_odo");
                        // 2025/11/12↓
                        sb.AppendLine(",ins_user_id");
                        sb.AppendLine(",ins_date");
                        sb.AppendLine(",delete_flag");
                        // 2025/11/12↑
                        sb.AppendLine(") VALUES (");
                        sb.AppendLine(Id.ToString());
                        if (this.lblStaffId2.Text == "") { sb.AppendLine(",0"); }
                        else { sb.AppendLine("," + this.lblStaffId2.Text); }
                        if (this.mtxtChangeDate.Text == "____/__/__") { sb.AppendLine(",'1900/01/01'"); }
                        else { sb.AppendLine(",'" + this.mtxtChangeDate.Text + "'"); }
                        if (this.txtChangeODO.Text == "") { sb.AppendLine(",0"); }
                        else { sb.AppendLine("," + this.txtChangeODO.Text); }
                        // 2025/11/12↓
                        sb.AppendLine("," + ClsLoginUser.StaffID);
                        sb.AppendLine(",'" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                        sb.AppendLine("," + ClsPublic.FLAG_OFF);
                        // 2025/11/12↑
                        sb.AppendLine(")");
                    }
                    else
                    {
                        // UPDATE
                        sb.Clear();
                        sb.AppendLine("UPDATE");
                        sb.AppendLine("Trn_社用車オイル交換履歴");
                        sb.AppendLine("SET");
                        if (this.lblStaffId2.Text == "") { sb.AppendLine("used_user_id = 0"); }
                        else { sb.AppendLine("used_user_id = " + this.lblStaffId2.Text); }
                        if (this.mtxtChangeDate.Text == "____/__/__") { sb.AppendLine(",oil_change_date = '1900/01/01'"); }
                        else { sb.AppendLine(",oil_change_date = '" + this.mtxtChangeDate.Text + "'"); }
                        if (this.txtChangeODO.Text == "") { sb.AppendLine(",oil_change_odo = 0"); }
                        else { sb.AppendLine(",oil_change_odo = " + this.txtChangeODO.Text); }
                        // 2025/11/10↓
                        sb.AppendLine(",upd_user_id = " + ClsLoginUser.StaffID);
                        sb.AppendLine(",upd_date = '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                        // 2025/11/10↑
                        sb.AppendLine("WHERE");
                        sb.AppendLine("id = " + Id2);
                    }
                    // cls.Sql = st.ToString();
                    // cls.DMLUpdate();
                    clsSqlDb.DMLUpdate(sb.ToString());


                    DisplayOilChangeHistory();

                    MessageBox.Show("登録しました。", "結果", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// オイル交換履歴「削除」ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteOil_Click(object sender, EventArgs e)
        {
            // 車両未選択の場合は処理終了
            if (Id == 0)
            {
                MessageBox.Show("車両が選択されていません。", "確認", MessageBoxButtons.OK);
                return;
            }
            if (Id2 == 0)
            {
                MessageBox.Show("履歴が選択されていません。", "確認", MessageBoxButtons.OK);
                return;
            }

            if (MessageBox.Show("削除します。", "確認", MessageBoxButtons.OKCancel) == DialogResult.Cancel) { return; }

            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    // オイル交換履歴
                    sb.Clear();
                    sb.AppendLine("DELETE FROM");
                    sb.AppendLine("Trn_社用車オイル交換履歴");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("id = " + Id2);

                    clsSqlDb.DMLUpdate(sb.ToString());
                }

                DisplayOilChangeHistory();

                MessageBox.Show("削除しました。", "結果", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private void btnSelectStaff2_Click(object sender, EventArgs e)
        {
            frmSelectStaff fSelectStaff = new()
            {
                TargetTable = "Mst_社員",
                Select_user_name = "",
                Select_user_id = 0,
                SelectUserKbn = 1             // 社員
            };
            fSelectStaff.ShowDialog();
            if (fSelectStaff.Select_user_id == 0) { return; }

            // 選択従業員情報取得
            this.lblNew.Visible = false;
            ClsMstStaff cMstStaff = new()
            {
                Id = fSelectStaff.Select_user_id
            };
            cMstStaff.GetStaff();

            this.lblStaffId2.Text = cMstStaff.Id.ToString();
            this.txtStaffName2.Text = cMstStaff.Name1;
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
    }
}