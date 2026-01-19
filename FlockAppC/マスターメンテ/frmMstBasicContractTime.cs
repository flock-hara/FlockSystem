using FlockAppC.pubClass;
using FlockAppC.tblClass;
using FlockAppC.選択画面;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FlockAppC.マスターメンテ
{
    public partial class frmMstBasicContractTime : Form
    {
        public int Location_id {  get; set; }
        public int Car_id {  get; set; }
        public int Contract_time_id { get; set; }

        // コピー・ペースト
        private int cp_item1;               // 1:透析／2:バス・デイ・配送
        private int cp_week1;               // 月曜
        private int cp_week2;               // 火曜
        private int cp_week3;               // 水曜
        private int cp_week4;               // 木曜
        private int cp_week5;               // 金曜
        private int cp_week6;               // 土曜
        private int cp_week7;               // 日曜
        private DateTime cp_start_time1;    // 開始時間1
        private DateTime cp_start_time2;    // 開始時間2
        private DateTime cp_start_time3;    // 開始時間3
        private DateTime cp_end_time1;      // 開始時間1
        private DateTime cp_end_time2;      // 開始時間2
        private DateTime cp_end_time3;      // 開始時間3
        private decimal cp_work_time;       // 実働時間
        private decimal cp_break_time;      // 休憩時間
        private string cp_comment;          // 備考

        private readonly StringBuilder sb = new();

        public frmMstBasicContractTime()
        {
            InitializeComponent();
        }
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMstBasicContractTime_Load(object sender, EventArgs e)
        {
            // 車両リスト
            SetDgvCarList();

            // 契約時間リスト
            SetDgvContractList();

            // 画面クリア（専従先情報を含む）
            InitializeForm(true,true);

            // 入力項目制御（初期表示時はfalse）
            InputControl(false);

            // コピー・ペースト保持領域クリア
            ClearCopyPast();

            this.Location = new System.Drawing.Point(0, 0);
        }
        /// <summary>
        /// 入力項目制御
        /// </summary>
        /// <param name="enable_flag"></param>
        private void InputControl(Boolean enable_flag)
        {
            this.gbox1.Enabled = enable_flag;
            this.gbox2.Enabled = enable_flag;
            this.dtpStart_Time1.Enabled = enable_flag;
            this.dtpStart_Time2.Enabled = enable_flag;
            this.dtpStart_Time3.Enabled = enable_flag;
            this.dtpEnd_Time1.Enabled = enable_flag;
            this.dtpEnd_Time2.Enabled = enable_flag;
            this.dtpEnd_Time3.Enabled = enable_flag;
            this.txtWork_Time.Enabled = enable_flag;
            this.dtpStart_Break_Time.Enabled = enable_flag;
            this.dtpEnd_Break_Time.Enabled = enable_flag;
            this.txtBreak_Time.Enabled = enable_flag;
            this.txtComment.Enabled = enable_flag;
            this.btnCopy.Enabled = enable_flag;
            this.btnPast.Enabled = enable_flag;
        }
        /// <summary>
        /// コピー・ペースト領域クリア
        /// </summary>
        private void ClearCopyPast()
        {
            cp_item1 = 0;
            cp_week1 = 0;               // 月曜
            cp_week2 = 0;               // 火曜
            cp_week3 = 0;               // 水曜
            cp_week4 = 0;               // 木曜
            cp_week5 = 0;               // 金曜
            cp_week6 = 0;               // 土曜
            cp_week7 = 0;               // 日曜
            cp_start_time1 = DateTime.Parse("1900-01-01");    // 開始時間1
            cp_start_time2 = DateTime.Parse("1900-01-01");    // 開始時間2
            cp_start_time3 = DateTime.Parse("1900-01-01");    // 開始時間3
            cp_end_time1 = DateTime.Parse("1900-01-01");      // 開始時間1
            cp_end_time2 = DateTime.Parse("1900-01-01");      // 開始時間2
            cp_end_time3 = DateTime.Parse("1900-01-01");      // 開始時間3
            cp_work_time = 0;           // 実働時間
            cp_break_time = 0;          // 休憩時間
            cp_comment = "";            // 備考
        }
        /// <summary>
        /// 入力されている値を保持
        /// </summary>
        private void CopyItem()
        {
            // 透析／バス・デイ・配送
            if (this.rdoKbn1.Checked == true) { cp_item1 = 1; }
            if (this.rdoKbn2.Checked == true) { cp_item1 = 2; }
            // 曜日
            if (this.chkMon.Checked == true) { cp_week1 = 1; }
            else { cp_week1 = 0; }
            if (this.chkTue.Checked == true) { cp_week2 = 1; }
            else { cp_week2 = 0; }
            if (this.chkWed.Checked == true) { cp_week3 = 1; }
            else { cp_week3 = 0; }
            if (this.chkThu.Checked == true) { cp_week4 = 1; }
            else { cp_week4 = 0; }
            if (this.chkFri.Checked == true) { cp_week5 = 1; }
            else { cp_week5 = 0; }
            if (this.chkSat.Checked == true) { cp_week6 = 1; }
            else { cp_week6 = 0; }
            if (this.chkSun.Checked == true) { cp_week7 = 1; }
            else { cp_week7 = 0; }
            // 開始・終了時間
            // if (this.dtpStart_Time1.Text != "00:00") { cp_start_time1 = this.dtpStart_Time1.Value; }
            cp_start_time1 = this.dtpStart_Time1.Value;
            cp_start_time2 = this.dtpStart_Time2.Value;
            cp_start_time3 = this.dtpStart_Time3.Value;
            cp_end_time1 = this.dtpEnd_Time1.Value;
            cp_end_time2 = this.dtpEnd_Time2.Value;
            cp_end_time3 = this.dtpEnd_Time3.Value;
            // 実働時間
            if (decimal.TryParse(this.txtWork_Time.Text, out var wt) == true) { cp_work_time = wt; }
            else { cp_work_time = 0; }
            // 休憩時間
            if (decimal.TryParse(this.txtBreak_Time.Text, out var bt) == true) { cp_break_time = bt; }
            else { cp_break_time = 0; }
            // 備考
            cp_comment = this.txtComment.Text;
        }
        /// <summary>
        /// 保持されている値を画面に反映
        /// </summary>
        private void PastItem()
        {
            // 漱石／バス・デイ・配送
            if (cp_item1 == 1) { this.rdoKbn1.Checked = true; }
            if (cp_item1 == 2) { this.rdoKbn2.Checked = true; }
            // 曜日
            if (cp_week1 == 1) { this.chkMon.Checked = true; }
            if (cp_week2 == 1) { this.chkTue.Checked = true; }
            if (cp_week3 == 1) { this.chkWed.Checked = true; }
            if (cp_week4 == 1) { this.chkThu.Checked = true; }
            if (cp_week5 == 1) { this.chkFri.Checked = true; }
            if (cp_week6 == 1) { this.chkSat.Checked = true; }
            if (cp_week7 == 1) { this.chkSun.Checked = true; }
            // 開始・終了時間
            this.dtpStart_Time1.Value = cp_start_time1;
            this.dtpStart_Time2.Value = cp_start_time2;
            this.dtpStart_Time3.Value = cp_start_time3;
            this.dtpEnd_Time1.Value = cp_end_time1;
            this.dtpEnd_Time2.Value = cp_end_time2;
            this.dtpEnd_Time3.Value = cp_end_time3;
            // 実働時間
            if (cp_work_time > 0) { this.txtWork_Time.Text = cp_work_time.ToString(); }
            // 休憩時間
            if (cp_break_time > 0) { this.txtBreak_Time.Text = cp_break_time.ToString(); }
            // 備考
            this.txtComment.Text = cp_comment.ToString();
        }

        /// <summary>
        /// 車両リスト初期設定
        /// </summary>
        private void SetDgvCarList()
        {

            DataGridViewTextBoxColumn col01 = new()
            {
                Name = "id",
                HeaderText = "ID",
                Width = 80,
                Visible = false
            };

            DataGridViewTextBoxColumn col02 = new()
            {
                Name = "no",
                HeaderText = "車番",
                Width = 80,
                Visible = true
            };

            DataGridViewTextBoxColumn col03 = new()
            {
                Name = "name",
                HeaderText = "号車",
                Width = 100,
                Visible = true
            };

            DataGridViewTextBoxColumn col04 = new()
            {
                Name = "car_name",
                HeaderText = "車種",
                Width = 100,
                Visible = false
            };

            // 2026/01/19 ADD (S)
            DataGridViewTextBoxColumn col05 = new()
            {
                Name = "identification",
                HeaderText = "車両識別",
                Width = 100,
                Visible = false
            };
            // 2026/01/19 ADD (E)

            this.dgvCarList.Columns.Add(col01);
            this.dgvCarList.Columns.Add(col02);
            this.dgvCarList.Columns.Add(col03);
            this.dgvCarList.Columns.Add(col04);
            // 2026/01/19 ADD (S)
            this.dgvCarList.Columns.Add(col05);
            // 2026/01/19 ADD (E)

            //並び替えができないようにする
            foreach (DataGridViewColumn c in this.dgvCarList.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;


            // ヘッダ設定
            this.dgvCarList.EnableHeadersVisualStyles = false;                                                               // Windows Color無効
            this.dgvCarList.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.CornflowerBlue;                   // 列ヘッダ色
            this.dgvCarList.AllowUserToResizeColumns = false;                                                                // 列幅の変更不可
            this.dgvCarList.AllowUserToResizeRows = false;                                                                   // 行高さの変更不可
            this.dgvCarList.ColumnHeadersVisible = true;                                                                     // 列ヘッダ非表示
            this.dgvCarList.ColumnHeadersHeight = 35;                                                                        // 列ヘッダ高さ   
            this.dgvCarList.Columns["no"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;            // 列ヘッダ文字位置
            this.dgvCarList.Columns["name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;          // 列ヘッダ文字位置
            this.dgvCarList.Columns["no"].HeaderCell.Style.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);    // 列ヘッダ文字フォント
            this.dgvCarList.Columns["no"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;                  // 列ヘッダ文字位置
            this.dgvCarList.Columns["name"].HeaderCell.Style.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);  // 列ヘッダ文字フォント
            this.dgvCarList.Columns["name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;                // 列ヘッダ文字位置

            // セル内表示位置
            this.dgvCarList.Columns["no"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvCarList.Columns["name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // フォント設定
            this.dgvCarList.Columns["no"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);
            this.dgvCarList.Columns["name"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);

            //奇数行を黄色にする
            //// this.dgvCarList.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Moccasin;
            this.dgvCarList.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.PaleTurquoise;

            // 選択した時の行のバックカラー
            // this.dgvCarList.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightBlue;
            this.dgvCarList.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SeaGreen;

            // その他
            this.dgvCarList.RowTemplate.Height = 30;                                                                     //行高さ
            this.dgvCarList.MultiSelect = false;                                                                         //複数選択
            this.dgvCarList.ReadOnly = true;                                                                             //読込専用
            this.dgvCarList.AllowUserToAddRows = false;                                                                  //行追加無効
            this.dgvCarList.RowHeadersVisible = false;                                                                   //行ヘッダ非表示
            this.dgvCarList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;                                     //行選択時は１行全て選択状態にする
        }
        /// <summary>
        /// 契約情報リスト初期設定
        /// </summary>
        private void SetDgvContractList()
        {

            DataGridViewTextBoxColumn col01 = new()
            {
                Name = "id",
                HeaderText = "ID",
                Width = 80,
                Visible = false
            };

            DataGridViewTextBoxColumn col02 = new()
            {
                Name = "car_id",
                HeaderText = "車両ID",
                Width = 80,
                Visible = false
            };

            //col20.Name = "sort";
            //col20.HeaderText = "表順";
            //col20.Width = 50;
            //col20.Visible = true;

            DataGridViewTextBoxColumn col03 = new()
            {
                Name = "no",
                HeaderText = "車番",
                Width = 100,
                Visible = true
            };

            DataGridViewTextBoxColumn col04 = new()
            {
                Name = "name",
                HeaderText = "号車",
                Width = 100,
                Visible = true
            };

            DataGridViewTextBoxColumn col05 = new()
            {
                Name = "car_name",
                HeaderText = "車種",
                Width = 100,
                Visible = true
            };

            DataGridViewTextBoxColumn col06 = new()
            {
                // Name = "kbn",                     2016/01/07 UPD   
                Name = "identification",
                HeaderText = "区分ID",            // 1:透析 or 2:ﾊﾞｽ・ﾃﾞｲ・配送
                Width = 100,
                Visible = false
            };

            DataGridViewTextBoxColumn col07 = new()
            {
                Name = "kbn_name",
                HeaderText = "区分",              // 透析 or ﾊﾞｽ・ﾃﾞｲ・配送
                Width = 100,
                Visible = true
            };

            DataGridViewTextBoxColumn col08 = new()
            {
                Name = "week",
                HeaderText = "曜日",
                Width = 100,
                Visible = true
            };

            DataGridViewTextBoxColumn col09 = new()
            {
                Name = "start_time1",
                HeaderText = "開始時間1",
                Width = 90,
                Visible = true
            };

            DataGridViewTextBoxColumn col10 = new()
            {
                Name = "end_time1",
                HeaderText = "終了時間1",
                Width = 90,
                Visible = true
            };

            DataGridViewTextBoxColumn col11 = new()
            {
                Name = "start_time2",
                HeaderText = "開始時間2",
                Width = 90,
                Visible = true
            };

            DataGridViewTextBoxColumn col12 = new()
            {
                Name = "end_time2",
                HeaderText = "終了時間2",
                Width = 90,
                Visible = true
            };

            DataGridViewTextBoxColumn col13 = new()
            {
                Name = "start_time3",
                HeaderText = "開始時間3",
                Width = 90,
                Visible = true
            };

            DataGridViewTextBoxColumn col14 = new()
            {
                Name = "end_time3",
                HeaderText = "終了時間3",
                Width = 90,
                Visible = true
            };

            DataGridViewTextBoxColumn col15 = new()
            {
                Name = "work_time",
                HeaderText = "実働時間",
                Width = 90,
                Visible = true
            };

            DataGridViewTextBoxColumn col16 = new()
            {
                Name = "start_break_time",
                HeaderText = "休憩開始",
                Width = 90,
                Visible = true
            };

            DataGridViewTextBoxColumn col17 = new()
            {
                Name = "end_break_time",
                HeaderText = "休憩終了",
                Width = 90,
                Visible = true
            };

            DataGridViewTextBoxColumn col18 = new()
            {
                Name = "break_time",
                HeaderText = "休憩時間",
                Width = 100,
                Visible = true
            };

            DataGridViewTextBoxColumn col19 = new()
            {
                Name = "comment1",
                HeaderText = "備考",
                Width = 100,
                Visible = true
            };

            this.dgvContractList.Columns.Add(col01);
            this.dgvContractList.Columns.Add(col02);
            this.dgvContractList.Columns.Add(col03);
            this.dgvContractList.Columns.Add(col04);
            this.dgvContractList.Columns.Add(col05);
            this.dgvContractList.Columns.Add(col06);
            this.dgvContractList.Columns.Add(col07);
            this.dgvContractList.Columns.Add(col08);
            this.dgvContractList.Columns.Add(col09);
            this.dgvContractList.Columns.Add(col10);
            this.dgvContractList.Columns.Add(col11);
            this.dgvContractList.Columns.Add(col12);
            this.dgvContractList.Columns.Add(col13);
            this.dgvContractList.Columns.Add(col14);
            this.dgvContractList.Columns.Add(col15);
            this.dgvContractList.Columns.Add(col16);
            this.dgvContractList.Columns.Add(col17);
            this.dgvContractList.Columns.Add(col18);
            this.dgvContractList.Columns.Add(col19);

            //並び替えができないようにする
            foreach (DataGridViewColumn c in this.dgvContractList.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            // ヘッダ設定
            this.dgvContractList.EnableHeadersVisualStyles = false;                                                                   // Windows Color無効
            this.dgvContractList.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.CornflowerBlue;                       // 列ヘッダ色
            this.dgvContractList.AllowUserToResizeColumns = false;                                                                    // 列幅の変更不可
            this.dgvContractList.AllowUserToResizeRows = false;                                                                       // 行高さの変更不可
            this.dgvContractList.ColumnHeadersVisible = true;                                                                         // 列ヘッダ非表示
            this.dgvContractList.ColumnHeadersHeight = 35;                                                                            // 列ヘッダ高さ   
            this.dgvContractList.Columns["no"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;                // 列ヘッダ文字位置
            this.dgvContractList.Columns["name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;              // 列ヘッダ文字位置
            this.dgvContractList.Columns["car_name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;          // 列ヘッダ文字位置
            this.dgvContractList.Columns["kbn_name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;          // 列ヘッダ文字位置
            this.dgvContractList.Columns["week"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;              // 列ヘッダ文字位置
            this.dgvContractList.Columns["start_time1"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;       // 列ヘッダ文字位置
            this.dgvContractList.Columns["end_time1"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;         // 列ヘッダ文字位置
            this.dgvContractList.Columns["start_time2"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;       // 列ヘッダ文字位置
            this.dgvContractList.Columns["end_time2"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;         // 列ヘッダ文字位置
            this.dgvContractList.Columns["start_time3"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;       // 列ヘッダ文字位置
            this.dgvContractList.Columns["end_time3"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;         // 列ヘッダ文字位置
            this.dgvContractList.Columns["work_time"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;         // 列ヘッダ文字位置
            this.dgvContractList.Columns["start_break_time"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;  // 列ヘッダ文字位置
            this.dgvContractList.Columns["end_break_time"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;    // 列ヘッダ文字位置
            this.dgvContractList.Columns["break_time"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;        // 列ヘッダ文字位置
            this.dgvContractList.Columns["comment1"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;          // 列ヘッダ文字位置
            // this.dgvContractList.Columns["sort"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;              // 列ヘッダ文字位置

            // 列ヘッダー色を変更
            var head1 = new DataGridViewCellStyle();
            var head2 = new DataGridViewCellStyle();
            var head3 = new DataGridViewCellStyle();
            head1.BackColor = System.Drawing.Color.Moccasin;
            this.dgvContractList.Columns["start_time1"].HeaderCell.Style = head1;
            this.dgvContractList.Columns["end_time1"].HeaderCell.Style = head1;
            head2.BackColor = System.Drawing.Color.LemonChiffon;
            this.dgvContractList.Columns["start_time2"].HeaderCell.Style = head2;
            this.dgvContractList.Columns["end_time2"].HeaderCell.Style = head2;
            head3.BackColor = System.Drawing.Color.Beige;
            this.dgvContractList.Columns["start_time3"].HeaderCell.Style = head3;
            this.dgvContractList.Columns["end_time3"].HeaderCell.Style = head3;

            this.dgvContractList.Columns["no"].HeaderCell.Style.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);               // 列ヘッダ文字フォント
            this.dgvContractList.Columns["no"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;                             // 列ヘッダ文字位置
            this.dgvContractList.Columns["name"].HeaderCell.Style.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);             // 列ヘッダ文字フォント
            this.dgvContractList.Columns["name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;                           // 列ヘッダ文字位置
            this.dgvContractList.Columns["car_name"].HeaderCell.Style.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);         // 列ヘッダ文字フォント
            this.dgvContractList.Columns["car_name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;                       // 列ヘッダ文字位置
            this.dgvContractList.Columns["kbn_name"].HeaderCell.Style.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);         // 列ヘッダ文字フォント
            this.dgvContractList.Columns["kbn_name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;                       // 列ヘッダ文字位置
            this.dgvContractList.Columns["week"].HeaderCell.Style.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);             // 列ヘッダ文字フォント
            this.dgvContractList.Columns["week"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;                           // 列ヘッダ文字位置
            this.dgvContractList.Columns["start_time1"].HeaderCell.Style.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);      // 列ヘッダ文字フォント
            this.dgvContractList.Columns["start_time1"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;                    // 列ヘッダ文字位置
            this.dgvContractList.Columns["end_time1"].HeaderCell.Style.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);        // 列ヘッダ文字フォント
            this.dgvContractList.Columns["end_time1"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;                      // 列ヘッダ文字位置
            this.dgvContractList.Columns["start_time2"].HeaderCell.Style.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);      // 列ヘッダ文字フォント
            this.dgvContractList.Columns["start_time2"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;                    // 列ヘッダ文字位置
            this.dgvContractList.Columns["end_time2"].HeaderCell.Style.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);        // 列ヘッダ文字フォント
            this.dgvContractList.Columns["end_time2"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;                      // 列ヘッダ文字位置
            this.dgvContractList.Columns["start_time3"].HeaderCell.Style.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);      // 列ヘッダ文字フォント
            this.dgvContractList.Columns["start_time3"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;                    // 列ヘッダ文字位置
            this.dgvContractList.Columns["end_time3"].HeaderCell.Style.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);        // 列ヘッダ文字フォント
            this.dgvContractList.Columns["end_time3"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;                      // 列ヘッダ文字位置
            this.dgvContractList.Columns["work_time"].HeaderCell.Style.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);        // 列ヘッダ文字フォント
            this.dgvContractList.Columns["work_time"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;                      // 列ヘッダ文字位置
            this.dgvContractList.Columns["start_break_time"].HeaderCell.Style.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular); // 列ヘッダ文字フォント
            this.dgvContractList.Columns["start_break_time"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;               // 列ヘッダ文字位置
            this.dgvContractList.Columns["end_break_time"].HeaderCell.Style.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);   // 列ヘッダ文字フォント
            this.dgvContractList.Columns["end_break_time"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;                 // 列ヘッダ文字位置
            this.dgvContractList.Columns["break_time"].HeaderCell.Style.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);       // 列ヘッダ文字フォント
            this.dgvContractList.Columns["break_time"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;                     // 列ヘッダ文字位置
            this.dgvContractList.Columns["comment1"].HeaderCell.Style.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);         // 列ヘッダ文字フォント
            this.dgvContractList.Columns["comment1"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;                       // 列ヘッダ文字位置
            // this.dgvContractList.Columns["sort"].HeaderCell.Style.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);             // 列ヘッダ文字フォント
            // this.dgvContractList.Columns["sort"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;                           // 列ヘッダ文字位置

            // セル内表示位置
            this.dgvContractList.Columns["no"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvContractList.Columns["name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvContractList.Columns["car_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvContractList.Columns["kbn_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvContractList.Columns["week"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvContractList.Columns["start_time1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvContractList.Columns["end_time1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvContractList.Columns["start_time2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvContractList.Columns["end_time2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvContractList.Columns["start_time3"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvContractList.Columns["end_time3"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvContractList.Columns["work_time"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvContractList.Columns["start_break_time"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvContractList.Columns["end_break_time"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvContractList.Columns["break_time"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvContractList.Columns["comment1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            // this.dgvContractList.Columns["sort"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            
            // フォント設定
            this.dgvContractList.Columns["no"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);
            this.dgvContractList.Columns["name"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);
            this.dgvContractList.Columns["car_name"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);
            this.dgvContractList.Columns["kbn_name"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);
            this.dgvContractList.Columns["week"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);
            this.dgvContractList.Columns["start_time1"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);
            this.dgvContractList.Columns["end_time1"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);
            this.dgvContractList.Columns["start_time2"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);
            this.dgvContractList.Columns["end_time2"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);
            this.dgvContractList.Columns["start_time3"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);
            this.dgvContractList.Columns["end_time3"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);
            this.dgvContractList.Columns["work_time"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);
            this.dgvContractList.Columns["start_break_time"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);
            this.dgvContractList.Columns["end_break_time"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);
            this.dgvContractList.Columns["break_time"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);
            this.dgvContractList.Columns["comment1"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);
            // this.dgvContractList.Columns["sort"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);

            //奇数行を黄色にする
            //// this.dgvContractList.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Moccasin;
            // this.dgvContractList.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.PaleTurquoise;

            this.dgvContractList.Columns["start_time1"].DefaultCellStyle.BackColor = System.Drawing.Color.Moccasin;
            this.dgvContractList.Columns["end_time1"].DefaultCellStyle.BackColor = System.Drawing.Color.Moccasin;
            this.dgvContractList.Columns["start_time2"].DefaultCellStyle.BackColor = System.Drawing.Color.LemonChiffon;
            this.dgvContractList.Columns["end_time2"].DefaultCellStyle.BackColor = System.Drawing.Color.LemonChiffon;
            this.dgvContractList.Columns["start_time3"].DefaultCellStyle.BackColor = System.Drawing.Color.Beige;
            this.dgvContractList.Columns["end_time3"].DefaultCellStyle.BackColor = System.Drawing.Color.Beige;

            // 選択した時の行のバックカラー
            // this.dgvContractList.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightBlue;
            this.dgvContractList.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SeaGreen;

            // その他
            this.dgvContractList.RowTemplate.Height = 30;                                                                     //行高さ
            this.dgvContractList.MultiSelect = false;                                                                         //複数選択
            this.dgvContractList.ReadOnly = true;                                                                             //読込専用
            this.dgvContractList.AllowUserToAddRows = false;                                                                  //行追加無効
            this.dgvContractList.RowHeadersVisible = false;                                                                   //行ヘッダ非表示
            this.dgvContractList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;                                     //行選択時は１行全て選択状態にする
        }
        /// <summary>
        /// 画面クリア
        /// </summary>
        /// <param name="p_location">専従先クリア対象</param>
        /// <param name="p_location">車両クリア対象</param>
        private void InitializeForm(bool p_location, bool p_car)
        {
            this.lblNew.Visible = true;

            // 専従先情報もクリアするか
            if (p_location == true)
            {
                // クリアする
                this.lblLocation.Text = "";
                this.Location_id = 0;
            }
            // 車両情報もクリアするか
            if (p_car == true)
            {
                // クリアする
                this.Car_id = 0;
            }
            // 契約時間IDクリア
            this.Contract_time_id = 0;

            this.txtLocationComment.Text = "";
            this.lblCarNo.Text = "";
            this.lblCarIdent.Text = "";
            this.lblCarName.Text = "";

            this.rdoKbn1.Checked = false;
            this.rdoKbn2.Checked = false;

            this.chkMon.Checked = false;
            this.chkTue.Checked = false;
            this.chkWed.Checked = false;
            this.chkThu.Checked = false;
            this.chkFri.Checked = false;
            this.chkSat.Checked = false;
            this.chkSun.Checked = false;

            this.dtpStart_Time1.Value = DateTime.Parse("1900/01/01 00:00:00");
            this.dtpStart_Time2.Value = DateTime.Parse("1900/01/01 00:00:00");
            this.dtpStart_Time3.Value = DateTime.Parse("1900/01/01 00:00:00");
            this.dtpEnd_Time1.Value = DateTime.Parse("1900/01/01 00:00:00");
            this.dtpEnd_Time2.Value = DateTime.Parse("1900/01/01 00:00:00");
            this.dtpEnd_Time3.Value = DateTime.Parse("1900/01/01 00:00:00");
            this.txtWork_Time.Text = "";

            this.dtpStart_Break_Time.Value = DateTime.Parse("1900/01/01 00:00:00");
            this.dtpEnd_Break_Time.Value = DateTime.Parse("1900/01/01 00:00:00");
            this.txtBreak_Time.Text = "";

            this.txtComment.Text = "";
            // this.txtSort.Text = "";
        }
        /// <summary>
        /// 専従先の車両を一覧に表示
        /// </summary>
        /// <param name="p_location_id">専従先ID</param>
        private void DisplayCarList(int p_location_id)
        {
            // リストクリア
            this.dgvCarList.Rows.Clear();
            this.dgvContractList.Rows.Clear();

            try
            {
                int row = 0;
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" id");
                    sb.AppendLine(",no");
                    sb.AppendLine(",fullname");
                    sb.AppendLine(",name");
                    sb.AppendLine(",car_name");
                    // 2026/01/19 ADD
                    sb.AppendLine(",identification");
                    sb.AppendLine("FROM");
                    sb.AppendLine(" Mst_専従先車両");
                    sb.AppendLine("WHERE");
                    sb.AppendLine(" delete_flag != 1");
                    sb.AppendLine("AND");
                    sb.AppendLine(" location_id = " + p_location_id);
                    sb.AppendLine("ORDER BY");
                    sb.AppendLine(" no");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            this.dgvCarList.Rows.Add();
                            this.dgvCarList.Rows[row].Cells["id"].Value = dr["id"].ToString();
                            this.dgvCarList.Rows[row].Cells["no"].Value = dr["no"].ToString();
                            if (dr.IsNull("name") != true) { this.dgvCarList.Rows[row].Cells["name"].Value = dr["name"].ToString(); }
                            else { this.dgvCarList.Rows[row].Cells["name"].Value = ""; }
                            if (dr.IsNull("car_name") != true) { this.dgvCarList.Rows[row].Cells["car_name"].Value = dr["car_name"].ToString(); }
                            else { this.dgvCarList.Rows[row].Cells["car_name"].Value = ""; }
                            // 2026/01/19 ADD (S)
                            if (dr.IsNull("identification") != true) { this.dgvCarList.Rows[row].Cells["identification"].Value = dr["identification"].ToString(); }
                            // 2026/01/19 ADD (E)

                            row++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
            
            // 未選択状態にする
            this.dgvCarList.ClearSelection();
        }
        /// <summary>
        /// 基本契約情報を一覧に表示
        /// </summary>
        /// <param name="p_location_id"></param>
        private void DisplayContractList(int p_location_id)
        {
            int row = 0;
            string week = "";

            // リストクリア
            this.dgvContractList.Rows.Clear();

            try
            {
                using (ClsSqlDb clsSqlDb = new (ClsDbConfig.SQLServerNo))
                using (ClsSqlDb clsSqlDb2 = new (ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" Mst_基本契約時間.id");
                    sb.AppendLine(",Mst_基本契約時間.location_id");
                    // 2026/01/07 DEL
                    // sb.AppendLine(",Mst_基本契約時間.kbn");
                    sb.AppendLine(",Mst_基本契約時間.car_id");
                    sb.AppendLine(",Mst_基本契約時間.start_time1");
                    sb.AppendLine(",Mst_基本契約時間.end_time1");
                    sb.AppendLine(",Mst_基本契約時間.start_time2");
                    sb.AppendLine(",Mst_基本契約時間.end_time2");
                    sb.AppendLine(",Mst_基本契約時間.start_time3");
                    sb.AppendLine(",Mst_基本契約時間.end_time3");
                    sb.AppendLine(",Mst_基本契約時間.work_time");
                    sb.AppendLine(",Mst_基本契約時間.start_break_time");
                    sb.AppendLine(",Mst_基本契約時間.end_break_time");
                    sb.AppendLine(",Mst_基本契約時間.break_time");
                    sb.AppendLine(",Mst_基本契約時間.comment1");
                    sb.AppendLine(",Mst_専従先車両.no");
                    sb.AppendLine(",Mst_専従先車両.fullname");
                    sb.AppendLine(",Mst_専従先車両.name");
                    sb.AppendLine(",Mst_専従先車両.car_name");
                    // 2026/01/07 ADD
                    sb.AppendLine(",Mst_専従先車両.identification");
                    sb.AppendLine("FROM");
                    sb.AppendLine(" Mst_基本契約時間");
                    sb.AppendLine("LEFT JOIN");
                    sb.AppendLine("Mst_専従先車両");
                    sb.AppendLine("ON");
                    sb.AppendLine("Mst_専従先車両.location_id = Mst_基本契約時間.location_id");
                    sb.AppendLine("AND");
                    sb.AppendLine("Mst_専従先車両.id = Mst_基本契約時間.car_id");
                    sb.AppendLine("WHERE");
                    sb.AppendLine(" Mst_基本契約時間.location_id = " + p_location_id);
                    sb.AppendLine("ORDER BY");
                    // 2026/01/07 UPD
                    // sb.AppendLine(" kbn");
                    sb.AppendLine(" identification");
                    sb.AppendLine(",name");
                    sb.AppendLine(",start_time1");
                    sb.AppendLine(",id");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        // 件数判定
                        if (dt_val.Rows.Count <= 0) { return; }

                        foreach (DataRow dr in dt_val.Rows)
                        {
                            sb.Clear();
                            sb.AppendLine("SELECT");
                            sb.AppendLine(" week");
                            sb.AppendLine("FROM");
                            sb.AppendLine(" Mst_基本契約曜日");
                            sb.AppendLine("WHERE");
                            sb.AppendLine(" contract_time_id = " + dr["id"].ToString());
                            sb.AppendLine("ORDER BY");
                            sb.AppendLine(" sort");

                            using (DataTable dt_val2 = clsSqlDb2.DMLSelect(sb.ToString()))
                            {
                                week = "";
                                foreach (DataRow dr2 in dt_val2.Rows)
                                {
                                    week = week + " " + dr2["week"].ToString();
                                }
                            }

                            this.dgvContractList.Rows.Add();
                            this.dgvContractList.Rows[row].Cells["id"].Value = dr["id"].ToString();
                            this.dgvContractList.Rows[row].Cells["car_id"].Value = dr["car_id"].ToString();
                            this.dgvContractList.Rows[row].Cells["no"].Value = dr["no"].ToString();
                            this.dgvContractList.Rows[row].Cells["name"].Value = dr["name"].ToString();
                            this.dgvContractList.Rows[row].Cells["car_name"].Value = dr["car_name"].ToString();
                            // 2026/01/07 UPD (S)
                            //if (dr.IsNull("kbn") != true)
                            //{
                            //    this.dgvContractList.Rows[row].Cells["kbn"].Value = dr["kbn"].ToString();
                            //    if (dr["kbn"].ToString() == "1")
                            //    {
                            //        this.dgvContractList.Rows[row].Cells["kbn_name"].Value = "透析";
                            //    }
                            //    else
                            //    {
                            //        this.dgvContractList.Rows[row].Cells["kbn_name"].Value = "ﾊﾞｽ･ﾃﾞｲ･配送";
                            //    }
                            //}
                            if (dr.IsNull("identification") != true)
                            {
                                this.dgvContractList.Rows[row].Cells["identification"].Value = dr["identification"].ToString();
                                if (dr["identification"].ToString() == "1")
                                {
                                    this.dgvContractList.Rows[row].Cells["kbn_name"].Value = "透析";
                                }
                                else
                                {
                                    this.dgvContractList.Rows[row].Cells["kbn_name"].Value = "ﾊﾞｽ･ﾃﾞｲ･配送";
                                }
                            }
                            // 2026/01/07 UPD (E)

                            this.dgvContractList.Rows[row].Cells["week"].Value = week;

                            // 2025/07/28 null判定に変更
                            // 1走目
                            if (!Convert.IsDBNull(dr["start_time1"]))
                            {
                                dgvContractList.Rows[row].Cells["start_time1"].Value = DateTime.Parse(dr["start_time1"].ToString()).ToString("HH:mm");
                            }
                            else
                            {
                                // null（= DBNull）だった場合の処理
                            }
                            if (!Convert.IsDBNull(dr["end_time1"]))
                            {
                                dgvContractList.Rows[row].Cells["end_time1"].Value = DateTime.Parse(dr["end_time1"].ToString()).ToString("HH:mm");
                            }
                            else
                            {
                                // null（= DBNull）だった場合の処理
                            }
                            // 2走目
                            if (!Convert.IsDBNull(dr["start_time2"]))
                            {
                                dgvContractList.Rows[row].Cells["start_time2"].Value = DateTime.Parse(dr["start_time2"].ToString()).ToString("HH:mm");
                            }
                            else
                            {
                                // null（= DBNull）だった場合の処理
                            }
                            if (!Convert.IsDBNull(dr["end_time2"]))
                            {
                                dgvContractList.Rows[row].Cells["end_time2"].Value = DateTime.Parse(dr["end_time2"].ToString()).ToString("HH:mm");
                            }
                            else
                            {
                                // null（= DBNull）だった場合の処理
                            }
                            // 3走目
                            if (!Convert.IsDBNull(dr["start_time3"]))
                            {
                                dgvContractList.Rows[row].Cells["start_time3"].Value = DateTime.Parse(dr["start_time3"].ToString()).ToString("HH:mm");
                            }
                            else
                            {
                                // null（= DBNull）だった場合の処理
                            }
                            if (!Convert.IsDBNull(dr["end_time3"]))
                            {
                                dgvContractList.Rows[row].Cells["end_time3"].Value = DateTime.Parse(dr["end_time3"].ToString()).ToString("HH:mm");
                            }
                            else
                            {
                                // null（= DBNull）だった場合の処理
                            }

                            /*
                            if (DateTime.Parse(dr["start_time1"].ToString()).ToString("HH:mm:ss") != "00:00:00") { this.dgvContractList.Rows[row].Cells["start_time1"].Value = DateTime.Parse(dr["start_time1"].ToString()).ToString("HH:mm"); }
                            if (DateTime.Parse(dr["end_time1"].ToString()).ToString("HH:mm:ss") != "00:00:00") { this.dgvContractList.Rows[row].Cells["end_time1"].Value = DateTime.Parse(dr["end_time1"].ToString()).ToString("HH:mm"); }
                            if (DateTime.Parse(dr["start_time2"].ToString()).ToString("HH:mm:ss") != "00:00:00") { this.dgvContractList.Rows[row].Cells["start_time2"].Value = DateTime.Parse(dr["start_time2"].ToString()).ToString("HH:mm"); }
                            if (DateTime.Parse(dr["end_time2"].ToString()).ToString("HH:mm:ss") != "00:00:00") { this.dgvContractList.Rows[row].Cells["end_time2"].Value = DateTime.Parse(dr["end_time2"].ToString()).ToString("HH:mm"); }
                            if (DateTime.Parse(dr["start_time3"].ToString()).ToString("HH:mm:ss") != "00:00:00") { this.dgvContractList.Rows[row].Cells["start_time3"].Value = DateTime.Parse(dr["start_time3"].ToString()).ToString("HH:mm"); }
                            if (DateTime.Parse(dr["end_time3"].ToString()).ToString("HH:mm:ss") != "00:00:00") { this.dgvContractList.Rows[row].Cells["end_time3"].Value = DateTime.Parse(dr["end_time3"].ToString()).ToString("HH:mm"); }
                            */

                            this.dgvContractList.Rows[row].Cells["work_time"].Value = dr["work_time"].ToString();

                            // 2025/07/28 null判定に変更
                            if (!Convert.IsDBNull(dr["start_break_time"]))
                            {
                                dgvContractList.Rows[row].Cells["start_break_time"].Value = DateTime.Parse(dr["start_break_time"].ToString()).ToString("HH:mm");
                            }
                            else
                            {
                                // null（= DBNull）だった場合の処理
                            }
                            if (!Convert.IsDBNull(dr["end_break_time"]))
                            {
                                dgvContractList.Rows[row].Cells["end_break_time"].Value = DateTime.Parse(dr["end_break_time"].ToString()).ToString("HH:mm");
                            }
                            else
                            {
                                // null（= DBNull）だった場合の処理
                            }
                            /*
                            if (DateTime.Parse(dr["start_break_time"].ToString()).ToString("HH:mm:ss") != "00:00:00") { this.dgvContractList.Rows[row].Cells["start_break_time"].Value = DateTime.Parse(dr["start_break_time"].ToString()).ToString("HH:mm"); }
                            if (DateTime.Parse(dr["end_break_time"].ToString()).ToString("HH:mm:ss") != "00:00:00") { this.dgvContractList.Rows[row].Cells["end_break_time"].Value = DateTime.Parse(dr["end_break_time"].ToString()).ToString("HH:mm"); }
                            */
                            this.dgvContractList.Rows[row].Cells["break_time"].Value = dr["break_time"].ToString();
                            this.dgvContractList.Rows[row].Cells["comment1"].Value = dr["comment1"].ToString();
                            row++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }

            // =========================
            // 専従先のコメントを表示
            // =========================
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("comment");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_専従先");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("location_id = " + p_location_id);

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            if (dr.IsNull("comment") != true) { this.txtLocationComment.Text = dr["comment"].ToString(); }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// 専従先選択ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSelectLocation_Click(object sender, EventArgs e)
        {
            frmSelectLocation fSelectLocation = new()
            {
                TargetTable = "Mst_専従先",
                Select_location_name = "",
                Select_location_id = 0
            };
            fSelectLocation.ShowDialog();

            // 未選択は処理終了
            if (fSelectLocation.Select_location_id <= 0) { return; }

            // 選択情報保持、表示
            this.Location_id = fSelectLocation.Select_location_id;
            this.lblLocation.Text = fSelectLocation.Select_location_name.ToString();

            // 画面クリア（専従先情報はクリアしない）
            InitializeForm(false,true);

            //// 専従先の備考（コメント）を取得し表示
            //StringBuilder st = new StringBuilder();
            //try
            //{
            //    st.Length = 0;
            //    st.AppendLine("SELECT");
            //    st.AppendLine(" comment");
            //    st.AppendLine("FROM");
            //    st.AppendLine(" Mst_専従先");
            //    st.AppendLine("WHERE");
            //    st.AppendLine(" location_id = " + this.location_id);
            //    using(clsDb cDb = new clsDb(clsPublic.DBNo))
            //    {
            //        cDb.Sql = st.ToString();
            //        cDb.DMLSelect();
            //        foreach(DataRow dr in cDb.dt.Rows)
            //        {
            //            if (dr.IsNull("comment") != true) { this.txtLocationComment.Text = dr["comment"].ToString(); }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    clsLogger.Log(ex.Message);
            //    throw;
            //}

            // 選択された専従先の車両をリストに表示
            DisplayCarList(this.Location_id);

            // 選択された専従先の契約時間をリストに表示
            DisplayContractList(this.Location_id);

            // 各一覧を未選択状態にする
            this.dgvCarList.ClearSelection();
            this.dgvContractList.ClearSelection();
        }
        /// <summary>
        /// 車両一覧クリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvCarList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }

            //クリックされたセルのID取得
            int id = int.Parse(this.dgvCarList.Rows[e.RowIndex].Cells["id"].Value.ToString());
            this.Car_id = id;

            InitializeForm(false,false);

            // 入力項目制御
            InputControl(true);

            //// ヘッダー車種クリア
            //this.lblCarNo.Text = "";
            //this.lblCarIdent.Text = "";
            //this.lblCarName.Text = "";

            // ヘッダー車種セット
            this.lblCarNo.Text = this.dgvCarList.Rows[e.RowIndex].Cells["no"].Value.ToString();
            this.lblCarIdent.Text = this.dgvCarList.Rows[e.RowIndex].Cells["name"].Value.ToString();
            this.lblCarName.Text = this.dgvCarList.Rows[e.RowIndex].Cells["car_name"].Value.ToString();
            // 2026/01/19 ADD (S)
            // 車両種別セット
            if (this.dgvCarList.Rows[e.RowIndex].Cells["identification"].Value.ToString() == "1")
            {
                this.rdoKbn1.Checked = true;
            }
            else
            {
                this.rdoKbn2.Checked = true;
            }
            // 2026/01/19 ADD (E)

            this.dgvContractList.ClearSelection();
        }
        /// <summary>
        /// 新規ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNew_Click(object sender, EventArgs e)
        {
            // 画面クリア（専従先情報はクリアしない）
            InitializeForm(false, true);

            this.dgvCarList.ClearSelection();
        }
        /// <summary>
        /// 保存ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnReg_Click(object sender, EventArgs e)
        {
            if (this.Location_id <= 0) { MessageBox.Show("専従先を選択してください。", "エラ－", MessageBoxButtons.OK); return; }

            // =========================
            // 専従先のコメントを更新
            // =========================
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("UPDATE");
                    sb.AppendLine("Mst_専従先");
                    sb.AppendLine("SET");
                    sb.AppendLine(" comment = '" + this.txtLocationComment.Text + "'");
                    // 2025/11/12↓
                    sb.AppendLine(",upd_user_id = " + ClsLoginUser.StaffID);
                    sb.AppendLine(",upd_date = '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    // 2025/11/12↑
                    sb.AppendLine("WHERE");
                    sb.AppendLine("location_id = " + this.Location_id);

                    clsSqlDb.DMLUpdate(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }

            // 車両選択チェック
            if (this.Car_id <= 0) { MessageBox.Show("車両を選択してください。", "エラ－", MessageBoxButtons.OK); return; }

            ClsMstBasicContractTime cMstBasicContractTime = new();

            // 画面入力データセット
            cMstBasicContractTime.Location_id = this.Location_id;
            // 2026/01/07 DEL (S)
            //if (this.rdoKbn1.Checked == true) { cMstBasicContractTime.Kbn = 1; }
            //else if (this.rdoKbn2.Checked == true) { cMstBasicContractTime.Kbn = 2; }
            //else { cMstBasicContractTime.Kbn = 0; }
            // 2026/01/07 DEL (E)
            cMstBasicContractTime.Car_id = this.Car_id;
            cMstBasicContractTime.Start_time1 = this.dtpStart_Time1.Value;
            cMstBasicContractTime.End_time1 = this.dtpEnd_Time1.Value;
            cMstBasicContractTime.Start_time2 = this.dtpStart_Time2.Value;
            cMstBasicContractTime.End_time2 = this.dtpEnd_Time2.Value;
            cMstBasicContractTime.Start_time3 = this.dtpStart_Time3.Value;
            cMstBasicContractTime.End_time3 = this.dtpEnd_Time3.Value;
            if (this.txtWork_Time.Text != "") { cMstBasicContractTime.Work_time = decimal.Parse(this.txtWork_Time.Text); }
            else { cMstBasicContractTime.Work_time = 0; }
            cMstBasicContractTime.Start_break_time = this.dtpStart_Break_Time.Value;
            cMstBasicContractTime.End_break_time = this.dtpEnd_Break_Time.Value;
            if (this.txtBreak_Time.Text != "") { cMstBasicContractTime.Break_time = decimal.Parse(this.txtBreak_Time.Text); }
            else { cMstBasicContractTime.Break_time = 0; }
            cMstBasicContractTime.Comment1 = this.txtComment.Text;


            // 契約時間ID
            if (this.Contract_time_id > 0)
            {
                // ======================================
                // UPDATE
                // ======================================
                // 契約時間データ更新
                cMstBasicContractTime.Id = this.Contract_time_id;
                cMstBasicContractTime.Update();

                // 曜日データ削除
                DeleteWeekData(Contract_time_id);
            }
            else
            {
                // ======================================
                // INSERT
                // ======================================
                // 契約時間データ登録
                // cMstBasicContractTime.Insert();
                this.Contract_time_id = cMstBasicContractTime.InsertScalar();
            }

            // 曜日データ登録
            if (this.chkMon.Checked == true)
            {
                RegWeekData(this.Contract_time_id, "月", 1);
            }
            if (this.chkTue.Checked == true)
            {
                RegWeekData(this.Contract_time_id, "火", 2);
            }
            if (this.chkWed.Checked == true)
            {
                RegWeekData(this.Contract_time_id, "水", 3);
            }
            if (this.chkThu.Checked == true)
            {
                RegWeekData(this.Contract_time_id, "木", 4);
            }
            if (this.chkFri.Checked == true)
            {
                RegWeekData(this.Contract_time_id, "金", 5);
            }
            if (this.chkSat.Checked == true)
            {
                RegWeekData(this.Contract_time_id, "土", 6);
            }
            if (this.chkSun.Checked == true)
            {
                RegWeekData(this.Contract_time_id, "日", 7);
            }

            // 転送確認
            if (MessageBox.Show("登録しました。続けてサーバーに転送（同期）しますか？" + Environment.NewLine + "転送先 [" + ClsDbConfig.mysqlParam[ClsDbConfig.MySQLNo].Instance + "\\" + ClsDbConfig.mysqlParam[ClsDbConfig.MySQLNo].Database + "]", "確認", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                InitializeForm(false, false);
                DisplayContractList(this.Location_id);
                return;
            }

            // 転送処理
            try
            {
                // 接続メッセージ
                this.lblConnect.Visible = true;

                // 転送（同期）処理
                using (ClsMySqlDb clsMySqlDb = new(ClsDbConfig.MySQLNo))
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    // Mst_専従先クラス
                    ClsMstLocation clsMstLocation = new();
                    // 専従先登録
                    clsMstLocation.ExportLocationOneData(this.Location_id, clsSqlDb, clsMySqlDb);

                    // Mst_基本契約時間, Mst_基本契約曜日
                    ClsMstBasicContractTime clsMstBasicContractTime = new();
                    // 基本契約時間登録
                    clsMstBasicContractTime.ExportBasicContractOneTimeData(this.Contract_time_id, clsSqlDb, clsMySqlDb);
                    // 基本契約曜日登録
                    clsMstBasicContractTime.ExportBasicContractOneWeekData(this.Contract_time_id, clsSqlDb, clsMySqlDb);
                }
                InitializeForm(false, false);
                DisplayContractList(this.Location_id);
                MessageBox.Show("転送しました。", "結果", MessageBoxButtons.OK);
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
        /// 曜日データ削除
        /// </summary>
        /// <param name="p_location_id"></param>
        /// <param name="p_car_id"></param>
        private void DeleteWeekData(int p_contract_time_id)
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("DELETE FROM");
                    sb.AppendLine(" Mst_基本契約曜日");
                    sb.AppendLine("WHERE");
                    sb.AppendLine(" contract_time_id = " + p_contract_time_id);

                    clsSqlDb.DMLUpdate(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 曜日データ登録
        /// </summary>
        /// <param name="p_contract_time_id"></param>
        /// <param name="p_week"></param>
        private void RegWeekData(int p_contract_time_id, string p_week, int p_sort)
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("INSERT INTO");
                    sb.AppendLine(" Mst_基本契約曜日");
                    sb.AppendLine("(");
                    sb.AppendLine(" contract_time_id");
                    sb.AppendLine(",sort");
                    sb.AppendLine(",week");
                    // 2025/11/12↓
                    sb.AppendLine(",ins_user_id");
                    sb.AppendLine(",ins_date");
                    sb.AppendLine(",delete_flag");
                    // 2025/11/12↑
                    sb.AppendLine(") VALUES (");
                    sb.AppendLine(p_contract_time_id.ToString());
                    sb.AppendLine("," + p_sort.ToString());
                    sb.AppendLine(",'" + p_week + "'");
                    // 2025/11/12↓
                    sb.AppendLine("," + ClsLoginUser.StaffID);
                    sb.AppendLine(",'" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    sb.AppendLine("," + ClsPublic.FLAG_OFF);
                    // 2025/11/12↑
                    sb.AppendLine(")");

                    clsSqlDb.DMLUpdate(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 契約時間一覧クリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvContractList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;

            if (row < 0) { return; }

            //クリックされたセルのID取得
            this.Contract_time_id = int.Parse(this.dgvContractList.Rows[row].Cells["id"].Value.ToString());

            // 新規ラベル非表示
            this.lblNew.Visible = false;

            // 選択された契約情報をヘッダーに表示
            this.Car_id = int.Parse(this.dgvContractList.Rows[row].Cells["car_id"].Value.ToString());
            this.lblCarNo.Text = this.dgvContractList.Rows[row].Cells["no"].Value.ToString();
            this.lblCarIdent.Text = this.dgvContractList.Rows[row].Cells["name"].Value.ToString();
            this.lblCarName.Text = this.dgvContractList.Rows[row].Cells["car_name"].Value.ToString();
            // 2026/01/07 UPD (S)
            //if (this.dgvContractList.Rows[row].Cells["kbn"].Value.ToString() == "1")
            //{
            //    this.rdoKbn1.Checked = true;
            //}
            //else if (this.dgvContractList.Rows[row].Cells["kbn"].Value.ToString() == "2")
            //{
            //    this.rdoKbn2.Checked = true;
            //}
            //else
            //{
            //    this.rdoKbn1.Checked = false;
            //    this.rdoKbn2.Checked = false;
            //}
            // 車両識別（1:透析、2:バス・デイ・配送）    
            if (this.dgvContractList.Rows[row].Cells["identification"].Value.ToString() == "1")
            {
                this.rdoKbn1.Checked = true;
            }
            else if (this.dgvContractList.Rows[row].Cells["identification"].Value.ToString() == "2")
            {
                this.rdoKbn2.Checked = true;
            }
            else
            {
                this.rdoKbn1.Checked = false;
                this.rdoKbn2.Checked = false;
            }
            // 2026/01/07 UPD (E)

            if (this.dgvContractList.Rows[row].Cells["start_time1"].Value != null) { this.dtpStart_Time1.Value = DateTime.Parse("1900-01-01 " + this.dgvContractList.Rows[row].Cells["start_time1"].Value.ToString()); }
            else { this.dtpStart_Time1.Value = DateTime.Parse("1900-01-01 00:00:00"); }
            if (this.dgvContractList.Rows[row].Cells["end_time1"].Value != null) { this.dtpEnd_Time1.Value = DateTime.Parse("1900-01-01 " + this.dgvContractList.Rows[row].Cells["end_time1"].Value.ToString()); }
            else { this.dtpEnd_Time1.Value = DateTime.Parse("1900-01-01 00:00:00"); }
            if (this.dgvContractList.Rows[row].Cells["start_time2"].Value != null) { this.dtpStart_Time2.Value = DateTime.Parse("1900-01-01 " + this.dgvContractList.Rows[row].Cells["start_time2"].Value.ToString()); }
            else { this.dtpStart_Time2.Value = DateTime.Parse("1900-01-01 00:00:00"); }
            if (this.dgvContractList.Rows[row].Cells["end_time2"].Value != null) { this.dtpEnd_Time2.Value = DateTime.Parse("1900-01-01 " + this.dgvContractList.Rows[row].Cells["end_time2"].Value.ToString()); }
            else { this.dtpEnd_Time2.Value = DateTime.Parse("1900-01-01 00:00:00"); }
            if (this.dgvContractList.Rows[row].Cells["start_time3"].Value != null) { this.dtpStart_Time3.Value = DateTime.Parse("1900-01-01 " + this.dgvContractList.Rows[row].Cells["start_time3"].Value.ToString()); }
            else { this.dtpStart_Time3.Value = DateTime.Parse("1900-01-01 00:00:00"); }
            if (this.dgvContractList.Rows[row].Cells["end_time3"].Value != null) { this.dtpEnd_Time3.Value = DateTime.Parse("1900-01-01 " + this.dgvContractList.Rows[row].Cells["end_time3"].Value.ToString()); }
            else { this.dtpEnd_Time3.Value = DateTime.Parse("1900-01-01 00:00:00"); }
            this.txtWork_Time.Text = this.dgvContractList.Rows[row].Cells["work_time"].Value.ToString();
            if (this.dgvContractList.Rows[row].Cells["start_break_time"].Value != null) { this.dtpStart_Break_Time.Value = DateTime.Parse("1900-01-01 " + this.dgvContractList.Rows[row].Cells["start_break_time"].Value.ToString()); }
            else { this.dtpStart_Break_Time.Value = DateTime.Parse("1900-01-01 00:00:00"); }
            if (this.dgvContractList.Rows[row].Cells["end_break_time"].Value != null) { this.dtpEnd_Break_Time.Value = DateTime.Parse("1900-01-01 " + this.dgvContractList.Rows[row].Cells["end_break_time"].Value.ToString()); }
            else { this.dtpEnd_Break_Time.Value = DateTime.Parse("1900-01-01 00:00:00"); }
            this.txtBreak_Time.Text = this.dgvContractList.Rows[row].Cells["break_time"].Value.ToString();
            this.txtComment.Text = this.dgvContractList.Rows[row].Cells["comment1"].Value.ToString();
            // this.txtSort.Text = this.dgvContractList.Rows[row].Cells["sort"].Value.ToString();

            // 曜日取得、画面表示
            this.chkMon.Checked = false; this.chkTue.Checked = false; this.chkWed.Checked = false; this.chkThu.Checked = false; this.chkFri.Checked = false; chkSat.Checked = false; this.chkSun.Checked = false;
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" week");
                    sb.AppendLine("FROM");
                    sb.AppendLine(" Mst_基本契約曜日");
                    sb.AppendLine("WHERE");
                    sb.AppendLine(" contract_time_id = " + this.Contract_time_id);

                    using(DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            switch (dr["week"].ToString())
                            {
                                case "月":
                                    this.chkMon.Checked = true;
                                    break;
                                case "火":
                                    this.chkTue.Checked = true;
                                    break;
                                case "水":
                                    this.chkWed.Checked = true;
                                    break;
                                case "木":
                                    this.chkThu.Checked = true;
                                    break;
                                case "金":
                                    this.chkFri.Checked = true;
                                    break;
                                case "土":
                                    this.chkSat.Checked = true;
                                    break;
                                case "日":
                                    this.chkSun.Checked = true;
                                    break;
                            }
                        }
                    }
                }
                // 入力項目制御
                InputControl(true);
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }

        }
        /// <summary>
        /// 削除ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (this.Contract_time_id <= 0) { return; }

            if (MessageBox.Show("削除します。","確認",MessageBoxButtons.OKCancel) == DialogResult.Cancel) { return; }

            // 契約時間削除
            ClsMstBasicContractTime cMstBasicContractTime = new();
            cMstBasicContractTime.Id = this.Contract_time_id;
            cMstBasicContractTime.Delete();
            DeleteWeekData(this.Contract_time_id);

            InitializeForm(false, false);
            DisplayContractList(this.Location_id);

            MessageBox.Show("削除しました。", "結果", MessageBoxButtons.OK);
        }
        /// <summary>
        /// 閉じるボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// クリアボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void BtnClearLocation_Click(object sender, EventArgs e)
        {
            // 画面クリア（専従先情報を含む）
            InitializeForm(true, true);

            // リストクリア
            this.dgvCarList.Rows.Clear();
            this.dgvContractList.Rows.Clear();
        }
        /// <summary>
        /// コピーボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCopy_Click(object sender, EventArgs e)
        {
            CopyItem();
        }
        /// <summary>
        /// ペーストボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPast_Click(object sender, EventArgs e)
        {
            PastItem();
        }
    }
}
