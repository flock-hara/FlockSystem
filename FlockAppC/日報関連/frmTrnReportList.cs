using FlockAppC.pubClass;
using FlockAppC.tblClass;
using FlockAppC.選択画面;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FlockAppC.Report
{
    public partial class frmTrnReportList : Form
    {
        private DateTime From_day { get; set; }
        private DateTime To_day { get; set; }
        private int Location_id { get; set; }
        private string Location_name { get; set; }
        private int Car_id { get; set; }
        private string Car_no { get; set; }
        private int Staff_id { get; set; }
        private string Staff_name { get; set; }
        private int Report_id { get; set; }

        // 締め日
        private int Closing_data {  get; set; }

        // ヘッダー、一覧フォントサイズ
        private int Header_font_size { get; set; }
        private int List_font_size { get; set; }
        // ヘッダー、一覧フォント
        private string Header_font_type { get; set; }
        private string List_font_type { get; set; }

        // DataGridViewカラム定義
        DataGridViewTextBoxColumn col01 = new();
        DataGridViewTextBoxColumn col02 = new();
        DataGridViewTextBoxColumn col03 = new();
        DataGridViewTextBoxColumn col04 = new();
        DataGridViewTextBoxColumn col05 = new();
        DataGridViewTextBoxColumn col06 = new();
        DataGridViewTextBoxColumn col07 = new();
        DataGridViewTextBoxColumn col08 = new();
        DataGridViewTextBoxColumn col09 = new();
        DataGridViewTextBoxColumn col10 = new();
        DataGridViewTextBoxColumn col11 = new();
        DataGridViewTextBoxColumn col12 = new();
        DataGridViewTextBoxColumn col13 = new();
        DataGridViewTextBoxColumn col14 = new();
        DataGridViewTextBoxColumn col15 = new();
        DataGridViewTextBoxColumn col16 = new();
        DataGridViewTextBoxColumn col17 = new();
        DataGridViewTextBoxColumn col18 = new();
        DataGridViewTextBoxColumn col19 = new();
        DataGridViewTextBoxColumn col20 = new();
        DataGridViewTextBoxColumn col21 = new();
        DataGridViewTextBoxColumn col22 = new();
        DataGridViewTextBoxColumn col23 = new();
        DataGridViewTextBoxColumn col24 = new();
        DataGridViewTextBoxColumn col25 = new();
        DataGridViewTextBoxColumn col26 = new();
        DataGridViewTextBoxColumn col27 = new();
        DataGridViewTextBoxColumn col28 = new();

        public frmTrnReportList()
        {
            InitializeComponent();
        }
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTrnReportList_Load(object sender, EventArgs e)
        {
            // フォント情報セット
            Header_font_size = ClsPublic.LIST_FONT_SIZE12;
            List_font_size = ClsPublic.LIST_FONT_SIZE11;
            Header_font_type = ClsPublic.LIST_FONT_TYPE_GOS;
            List_font_type = ClsPublic.LIST_FONT_TYPE_GOS;

            // XML(CSV出力先等)読み込み
            LoadConfig();

            // DataGridView初期化
            SetDgvList();

            // Formクリア
            ClearForm();

            // 日付：当日日付
            this.dtpDate1.Value = DateTime.Now;
            this.dtpDate2.Value = DateTime.Now;

            // 年月カレンダー設定
            dtpYM.Format = DateTimePickerFormat.Custom;
            dtpYM.CustomFormat = "yyyy年MM月";
            dtpYM.ShowUpDown = false;     // カレンダーを出さずに上下スピンで選択
            dtpYM.Value = DateTime.Now;  // 初期値は現在年月
            dtpYM.Width = 120;

            // 日報一括確認ボタン
            if (ClsLoginUser.ReportConfirmFlag == ClsPublic.FLAG_ON)
            {
                btnConfirm.Enabled = true;
            }
            else
            {
                btnConfirm.Enabled = false;
            }

            // 締め日コンボボックス
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("Code");
            dt.Columns.Add("Name");
            // 20日締め行
            dr = dt.NewRow();
            dr["Code"] = "20";
            dr["Name"] = "20日";
            dt.Rows.Add(dr);
            // 末締め行
            dr = dt.NewRow();
            dr["Code"] = "31";
            dr["Name"] = "末";
            dt.Rows.Add(dr);
            cmbClosingDate.DataSource = dt;
            cmbClosingDate.DisplayMember = "Name";
            cmbClosingDate.ValueMember = "Code";
            cmbClosingDate.SelectedIndex = 0;

            // 締め年月（ラジオボタン）
            rdo1.Checked = true;

            // 初期イベント登録
            dtpYM.ValueChanged += new EventHandler(UpdateClosePeriod);
            cmbClosingDate.SelectedIndexChanged += new EventHandler(UpdateClosePeriod);

            // 初期表示
            UpdateClosePeriod(null, null);

            this.Location = new Point(0, 0);
        }
        /// <summary>
        /// 日報統計表設定読み込み
        /// </summary>
        private void LoadConfig()
        {
            // CSV出力パス　※本来はxmlファイルから読み込むが、とりあえず固定
            // clsPublicReport.pub_Csv_path = @"\\Flockserver2017\共有\\共通ホルダー\個人用  ドキュメント\事務担当用\\アンタッチャブル！( ･`д･´)\\日報.xml";
            clsPublicReport.pub_Csv_path = @"\\Flockserver2017\共有\\共通ホルダー\個人用  ドキュメント\事務担当用\\アンタッチャブル！( ･`д･´)";
        }
        /// <summary>
        /// Initialize DataGridView
        /// </summary>
        private void SetDgvList()
        {
            DataGridViewButtonColumn col00 = new();
            // 編集ボタン
            col00.Name = "edit";
            col00.HeaderText = " ";
            col00.Text = "詳細";
            col00.Width = 50;
            col00.UseColumnTextForButtonValue = true;
            col00.Visible = true;
            // 日報データID
            col01.Name = "col01";
            col01.HeaderText = "ID";
            col01.Width = 50;
            col01.Visible = false;
            // 専従先ID
            col02.Name = "col02";
            col02.HeaderText = "専ID";
            col02.Width = 50;
            col02.Visible = false;
            // 専従先名称
            col03.Name = "col03";
            col03.HeaderText = "専従先";
            col03.Width = 240;
            col03.Visible = true;
            // 日報日付
            col04.Name = "col04";
            col04.HeaderText = "日付";
            col04.Width = 190;
            col04.Visible = true;
            // 車両番号
            col05.Name = "col05";
            col05.HeaderText = "車番";
            col05.Width = 85;
            col05.Visible = true;
            // 号車
            col06.Name = "col06";
            col06.HeaderText = "号車";
            col06.Width = 120;
            col06.Visible = true;
            // 車両ID
            col07.Name = "col07";
            col07.HeaderText = "車両ID";
            col07.Width = 90;
            col07.Visible = false;
            // 担当者1 ID
            col08.Name = "col08";
            col08.HeaderText = "担ID";
            col08.Width = 50;
            col08.Visible = false;
            // 担当者1 名
            col09.Name = "col09";
            col09.HeaderText = "担当者";
            col09.Width = 105;
            col09.Visible = true;
            // 担当者2 ID
            col10.Name = "col10";
            col10.HeaderText = "担ID";
            col10.Width = 50;
            col10.Visible = false;
            // 担当者2 名
            col11.Name = "col11";
            col11.HeaderText = "担当者";
            col11.Width = 80;
            col11.Visible = false;
            // 担当者3 ID
            col12.Name = "col12";
            col12.HeaderText = "担ID";
            col12.Width = 50;
            col12.Visible = false;
            // 担当者3 名
            col13.Name = "col13";
            col13.HeaderText = "担当者";
            col13.Width = 80;
            col13.Visible = false;
            // 開始時間1
            col14.Name = "col14";
            col14.HeaderText = "開時1";
            col14.Width = 65;
            col14.Visible = true;
            // 開始時間2
            col15.Name = "col15";
            col15.HeaderText = "開時2";
            col15.Width = 65;
            col15.Visible = true;
            // 開始時間3
            col16.Name = "col16";
            col16.HeaderText = "開時3";
            col16.Width = 65;
            col16.Visible = true;
            // 終了時間1
            col17.Name = "col17";
            col17.HeaderText = "終時1";
            col17.Width = 65;
            col17.Visible = true;
            // 終了時間2
            col18.Name = "col18";
            col18.HeaderText = "終時2";
            col18.Width = 65;
            col18.Visible = true;
            // 終了時間3
            col19.Name = "col19";
            col19.HeaderText = "終時3";
            col19.Width = 65;
            col19.Visible = true;
            // 入庫時メーター
            col20.Name = "col20";
            col20.HeaderText = "入庫ﾒｰﾀｰ";
            col20.Width = 80;
            col20.Visible = true;
            // 出庫時メーター
            col21.Name = "col21";
            col21.HeaderText = "出庫ﾒｰﾀｰ";
            col21.Width = 80;
            col21.Visible = true;
            // 走行粁
            col22.Name = "col22";
            col22.HeaderText = "走行粁";
            col22.Width = 65;
            col22.Visible = true;
            // 給油量
            col23.Name = "col23";
            col23.HeaderText = "給油量";
            col23.Width = 70;
            col23.Visible = true;
            // 残業有無
            col24.Name = "col24";
            col24.HeaderText = "残業";
            col24.Width = 50;
            col24.Visible = true;
            // 社内チェック
            col25.Name = "col25";
            col25.HeaderText = "総";
            col25.Width = 30;
            col25.Visible = true;
            // 管理責任者確認
            col26.Name = "col26";
            col26.HeaderText = "営";
            col26.Width = 30;
            col26.Visible = true;
            // お客様確認
            col27.Name = "col27";
            col27.HeaderText = "得";
            col27.Width = 30;
            col27.Visible = true;
            // お客様確認
            col28.Name = "col28";
            col28.HeaderText = "代";
            col28.Width = 30;
            col28.Visible = true;

            this.dgvList.Columns.Add(col00);
            this.dgvList.Columns.Add(col01);
            this.dgvList.Columns.Add(col02);
            this.dgvList.Columns.Add(col03);
            this.dgvList.Columns.Add(col04);
            this.dgvList.Columns.Add(col05);
            this.dgvList.Columns.Add(col06);
            this.dgvList.Columns.Add(col07);
            this.dgvList.Columns.Add(col28);
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
            this.dgvList.Columns.Add(col18);
            this.dgvList.Columns.Add(col19);
            this.dgvList.Columns.Add(col24);
            this.dgvList.Columns.Add(col20);
            this.dgvList.Columns.Add(col21);
            this.dgvList.Columns.Add(col22);
            this.dgvList.Columns.Add(col23);
            this.dgvList.Columns.Add(col25);
            this.dgvList.Columns.Add(col26);
            this.dgvList.Columns.Add(col27);

            //並び替えができないようにする
            foreach (DataGridViewColumn c in this.dgvList.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            // ヘッダープロパティ
            this.dgvList.EnableHeadersVisualStyles = false;                                                                     //Windows Color無効
            // this.dgvList.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.CornflowerBlue;                         //列ヘッダ色
            //this.dgvList.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.SlateBlue;                         //列ヘッダ色
            //this.dgvList.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.SlateBlue;                         //列ヘッダ色
            this.dgvList.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.CornflowerBlue;                         //列ヘッダ色
            // this.dgvList.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.SteelBlue;                         //列ヘッダ色
            // this.dgvList.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.MediumSlateBlue;                         //列ヘッダ色
            // this.dgvList.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.SlateBlue;                         //列ヘッダ色
            this.dgvList.ColumnHeadersHeight = 30;                                                                              //ヘッダー高さ 
            this.dgvList.RowTemplate.Height = 25;                                                                               //行高さ
            this.dgvList.AllowUserToResizeColumns = false;                                                                      //列幅の変更不可
            this.dgvList.AllowUserToResizeRows = false;                                                                         //行高さの変更不可
            this.dgvList.ColumnHeadersVisible = true;                                                                           //列ヘッダ表示
            this.dgvList.EnableHeadersVisualStyles = false;                                                                     //Windows C
            this.dgvList.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(Header_font_type, Header_font_size, FontStyle.Regular);     //ヘッダーフォント設定

            this.dgvList.Columns["col01"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;         // ヘッダー文字位置
            this.dgvList.Columns["col02"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;         // ヘッダー文字位置
            this.dgvList.Columns["col03"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;         // ヘッダー文字位置
            this.dgvList.Columns["col04"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;         // ヘッダー文字位置
            this.dgvList.Columns["col05"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;         // ヘッダー文字位置
            this.dgvList.Columns["col06"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;         // ヘッダー文字位置
            this.dgvList.Columns["col07"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;         // ヘッダー文字位置
            this.dgvList.Columns["col08"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;         // ヘッダー文字位置
            this.dgvList.Columns["col09"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;         // ヘッダー文字位置
            this.dgvList.Columns["col10"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;         // ヘッダー文字位置
            this.dgvList.Columns["col11"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;         // ヘッダー文字位置
            this.dgvList.Columns["col12"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;         // ヘッダー文字位置
            this.dgvList.Columns["col13"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;         // ヘッダー文字位置
            this.dgvList.Columns["col14"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;         // ヘッダー文字位置
            this.dgvList.Columns["col15"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;         // ヘッダー文字位置
            this.dgvList.Columns["col16"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;         // ヘッダー文字位置
            this.dgvList.Columns["col17"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;         // ヘッダー文字位置
            this.dgvList.Columns["col18"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;         // ヘッダー文字位置
            this.dgvList.Columns["col19"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;         // ヘッダー文字位置
            this.dgvList.Columns["col20"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;         // ヘッダー文字位置
            this.dgvList.Columns["col21"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;         // ヘッダー文字位置
            this.dgvList.Columns["col22"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;         // ヘッダー文字位置
            this.dgvList.Columns["col23"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;         // ヘッダー文字位置
            this.dgvList.Columns["col24"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;         // ヘッダー文字位置
            this.dgvList.Columns["col25"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;         // ヘッダー文字位置
            this.dgvList.Columns["col26"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;         // ヘッダー文字位置
            this.dgvList.Columns["col27"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;         // ヘッダー文字位置
            this.dgvList.Columns["col28"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;         // ヘッダー文字位置

            //奇数行を黄色にする
            //// this.dgvList.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Moccasin;
            //// this.dgvList.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LightSkyBlue;
            //this.dgvList.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.PowderBlue;
            this.dgvList.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;

            // 一覧データ表示位置
            this.dgvList.Columns["col01"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;            //セルの文字表示位置
            this.dgvList.Columns["col02"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;            //セルの文字表示位置
            this.dgvList.Columns["col03"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;              //セルの文字表示位置
            this.dgvList.Columns["col04"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;            //セルの文字表示位置
            this.dgvList.Columns["col05"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;            //セルの文字表示位置
            this.dgvList.Columns["col06"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;            //セルの文字表示位置
            this.dgvList.Columns["col07"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;            //セルの文字表示位置
            this.dgvList.Columns["col08"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;            //セルの文字表示位置
            this.dgvList.Columns["col09"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;            //セルの文字表示位置
            this.dgvList.Columns["col10"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;            //セルの文字表示位置
            this.dgvList.Columns["col11"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;            //セルの文字表示位置
            this.dgvList.Columns["col12"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;            //セルの文字表示位置
            this.dgvList.Columns["col13"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;            //セルの文字表示位置
            this.dgvList.Columns["col14"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;            //セルの文字表示位置
            this.dgvList.Columns["col15"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;            //セルの文字表示位置
            this.dgvList.Columns["col16"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;            //セルの文字表示位置
            this.dgvList.Columns["col17"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;            //セルの文字表示位置
            this.dgvList.Columns["col18"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;            //セルの文字表示位置
            this.dgvList.Columns["col19"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;            //セルの文字表示位置
            this.dgvList.Columns["col20"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;             //セルの文字表示位置
            this.dgvList.Columns["col21"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;             //セルの文字表示位置
            this.dgvList.Columns["col22"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;             //セルの文字表示位置
            this.dgvList.Columns["col23"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;             //セルの文字表示位置
            this.dgvList.Columns["col24"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;            //セルの文字表示位置
            this.dgvList.Columns["col25"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;            //セルの文字表示位置
            this.dgvList.Columns["col26"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;            //セルの文字表示位置
            this.dgvList.Columns["col27"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;            //セルの文字表示位置
            this.dgvList.Columns["col28"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;            //セルの文字表示位置

            // 一覧データフォント設定
            this.dgvList.Columns["col01"].DefaultCellStyle.Font = new System.Drawing.Font(Header_font_type, List_font_size, FontStyle.Regular);            //フォント設定
            this.dgvList.Columns["col02"].DefaultCellStyle.Font = new System.Drawing.Font(Header_font_type, List_font_size, FontStyle.Regular);            //フォント設定
            this.dgvList.Columns["col03"].DefaultCellStyle.Font = new System.Drawing.Font(Header_font_type, List_font_size, FontStyle.Regular);            //フォント設定
            this.dgvList.Columns["col04"].DefaultCellStyle.Font = new System.Drawing.Font(Header_font_type, List_font_size, FontStyle.Regular);            //フォント設定
            this.dgvList.Columns["col05"].DefaultCellStyle.Font = new System.Drawing.Font(Header_font_type, List_font_size, FontStyle.Regular);            //フォント設定
            this.dgvList.Columns["col06"].DefaultCellStyle.Font = new System.Drawing.Font(Header_font_type, List_font_size, FontStyle.Regular);            //フォント設定
            this.dgvList.Columns["col07"].DefaultCellStyle.Font = new System.Drawing.Font(Header_font_type, List_font_size, FontStyle.Regular);            //フォント設定
            this.dgvList.Columns["col08"].DefaultCellStyle.Font = new System.Drawing.Font(Header_font_type, List_font_size, FontStyle.Regular);            //フォント設定
            this.dgvList.Columns["col09"].DefaultCellStyle.Font = new System.Drawing.Font(Header_font_type, List_font_size, FontStyle.Regular);            //フォント設定
            this.dgvList.Columns["col10"].DefaultCellStyle.Font = new System.Drawing.Font(Header_font_type, List_font_size, FontStyle.Regular);            //フォント設定
            this.dgvList.Columns["col11"].DefaultCellStyle.Font = new System.Drawing.Font(Header_font_type, List_font_size, FontStyle.Regular);            //フォント設定
            this.dgvList.Columns["col12"].DefaultCellStyle.Font = new System.Drawing.Font(Header_font_type, List_font_size, FontStyle.Regular);            //フォント設定
            this.dgvList.Columns["col13"].DefaultCellStyle.Font = new System.Drawing.Font(Header_font_type, List_font_size, FontStyle.Regular);            //フォント設定
            this.dgvList.Columns["col14"].DefaultCellStyle.Font = new System.Drawing.Font(Header_font_type, List_font_size, FontStyle.Regular);            //フォント設定
            this.dgvList.Columns["col15"].DefaultCellStyle.Font = new System.Drawing.Font(Header_font_type, List_font_size, FontStyle.Regular);            //フォント設定
            this.dgvList.Columns["col16"].DefaultCellStyle.Font = new System.Drawing.Font(Header_font_type, List_font_size, FontStyle.Regular);            //フォント設定
            this.dgvList.Columns["col17"].DefaultCellStyle.Font = new System.Drawing.Font(Header_font_type, List_font_size, FontStyle.Regular);            //フォント設定
            this.dgvList.Columns["col18"].DefaultCellStyle.Font = new System.Drawing.Font(Header_font_type, List_font_size, FontStyle.Regular);            //フォント設定
            this.dgvList.Columns["col19"].DefaultCellStyle.Font = new System.Drawing.Font(Header_font_type, List_font_size, FontStyle.Regular);            //フォント設定
            this.dgvList.Columns["col20"].DefaultCellStyle.Font = new System.Drawing.Font(Header_font_type, List_font_size, FontStyle.Regular);            //フォント設定
            this.dgvList.Columns["col21"].DefaultCellStyle.Font = new System.Drawing.Font(Header_font_type, List_font_size, FontStyle.Regular);            //フォント設定
            this.dgvList.Columns["col22"].DefaultCellStyle.Font = new System.Drawing.Font(Header_font_type, List_font_size, FontStyle.Regular);            //フォント設定
            this.dgvList.Columns["col23"].DefaultCellStyle.Font = new System.Drawing.Font(Header_font_type, List_font_size, FontStyle.Regular);            //フォント設定
            this.dgvList.Columns["col24"].DefaultCellStyle.Font = new System.Drawing.Font(Header_font_type, List_font_size, FontStyle.Regular);            //フォント設定
            this.dgvList.Columns["col25"].DefaultCellStyle.Font = new System.Drawing.Font(Header_font_type, List_font_size, FontStyle.Regular);            //フォント設定
            this.dgvList.Columns["col26"].DefaultCellStyle.Font = new System.Drawing.Font(Header_font_type, List_font_size, FontStyle.Regular);            //フォント設定
            this.dgvList.Columns["col27"].DefaultCellStyle.Font = new System.Drawing.Font(Header_font_type, List_font_size, FontStyle.Regular);            //フォント設定
            this.dgvList.Columns["col28"].DefaultCellStyle.Font = new System.Drawing.Font(Header_font_type, List_font_size, FontStyle.Regular);            //フォント設定

            // その他設定
            //this.dgvSelect1.ScrollBars = false;                                                                                   //スクロールバー非表示
            this.dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;                                                                                       //複数選択
            this.dgvList.MultiSelect = false;                                                                                       //複数選択
            this.dgvList.ReadOnly = true;                                                                                           //読込専用
            this.dgvList.AllowUserToAddRows = false;                                                                                //行追加無効
            this.dgvList.RowHeadersVisible = false;                                                                                 //行ヘッダ非表示

            // ヘッダーカラー設定DodgerBlue
            // 開始時間1～3、終了時間1～3
            //col14.HeaderCell.Style.BackColor = System.Drawing.Color.RoyalBlue;                // 開始時間1
            //col15.HeaderCell.Style.BackColor = System.Drawing.Color.LightSkyBlue;             // 開始時間2
            //col16.HeaderCell.Style.BackColor = System.Drawing.Color.DodgerBlue;               // 開始時間3
            //col17.HeaderCell.Style.BackColor = System.Drawing.Color.RoyalBlue;                // 終了時間1
            //col18.HeaderCell.Style.BackColor = System.Drawing.Color.LightSkyBlue;             // 終了時間2
            //col19.HeaderCell.Style.BackColor = System.Drawing.Color.DodgerBlue;               // 終了時間3
            col14.HeaderCell.Style.BackColor = System.Drawing.Color.PowderBlue;                 // 開始時間1
            col15.HeaderCell.Style.BackColor = System.Drawing.Color.SkyBlue;                    // 開始時間2
            col16.HeaderCell.Style.BackColor = System.Drawing.Color.LightSteelBlue;             // 開始時間3
            col17.HeaderCell.Style.BackColor = System.Drawing.Color.PowderBlue;                 // 終了時間1
            col18.HeaderCell.Style.BackColor = System.Drawing.Color.SkyBlue;                    // 終了時間2
            col19.HeaderCell.Style.BackColor = System.Drawing.Color.LightSteelBlue;             // 終了時間3
        }
        /// <summary>
        /// Clear Form
        /// </summary>
        private void ClearForm()
        {
            //// 日付：当日日付
            //this.dtpDate1.Value = DateTime.Now;
            //this.dtpDate2.Value = DateTime.Now;

            // 専従先名、車両、担当者
            this.lblLocationName.Text = "";
            this.lblCarNo.Text = "";
            this.lblStaffName.Text = "";

            // 車両番号、担当者：Disable (専従先選択で有効にする)
            this.btnSelectCar.Enabled = false;
            // this.btnSelectStaff.Enabled = false;

            // 各ID初期化
            this.Location_id = 0;
            this.Car_id = 0;
            this.Staff_id = 0;
        }
        /// <summary>
        /// 詳細表示ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisplayDetail_Click(object sender, EventArgs e)
        {
            int iRow = this.dgvList.CurrentRow.Index;
            if (iRow < 0) { return; }

            //frmDisplayTrnReport fDisplayTrnReport = new frmDisplayTrnReport(con);

            //// 検索条件セット（指定されている項目のみ）
            //// 選択されているレポートIDセット
            //fDisplayTrnReport.Id = int.Parse(this.dgvList.Rows[iRow].Cells["col01"].Value.ToString());
            //// 日付
            //fDisplayTrnReport.day = DateTime.Parse(this.dgvList.Rows[iRow].Cells["col04"].Value.ToString());
            //// 日付（from,to）
            //fDisplayTrnReport.from_day = from_day;
            //fDisplayTrnReport.to_day = to_day;
            //// 専従先ID
            //fDisplayTrnReport.location_id = int.Parse(this.dgvList.Rows[iRow].Cells["col02"].Value.ToString()); ;

            //// 担当者ID
            //if (this.dgvList.Rows[iRow].Cells["col22"].Value.ToString() != "")
            //{
            //    fDisplayTrnReport.user_id1 = int.Parse(this.dgvList.Rows[iRow].Cells["col22"].Value.ToString());
            //}
            //else
            //{
            //    fDisplayTrnReport.user_id1 = 0;
            //}
            //if (this.dgvList.Rows[iRow].Cells["col24"].Value.ToString() != "")
            //{
            //    fDisplayTrnReport.user_id2 = int.Parse(this.dgvList.Rows[iRow].Cells["col24"].Value.ToString());
            //}
            //else
            //{
            //    fDisplayTrnReport.user_id2 = 0;
            //}
            //if (this.dgvList.Rows[iRow].Cells["col26"].Value.ToString() != "")
            //{
            //    fDisplayTrnReport.user_id3 = int.Parse(this.dgvList.Rows[iRow].Cells["col26"].Value.ToString());
            //}
            //else
            //{
            //    fDisplayTrnReport.user_id3 = 0;
            //}


            //// 車輌番号、ID
            //fDisplayTrnReport.car_id = int.Parse(this.dgvList.Rows[iRow].Cells["col28"].Value.ToString()); ;
            //fDisplayTrnReport.car_no = this.dgvList.Rows[iRow].Cells["col05"].Value.ToString();

            //// 詳細画面表示
            //fDisplayTrnReport.ShowDialog();

            //// 再表示
            //this.dgvList.Rows.Clear();
            //DisplayTrnReport();

            //// レコード選択設定
            //// fDisplayTrnReport.Id を参照
            //SelectRow(fDisplayTrnReport.Id);
        }

        private void SelectRow(int p_id)
        {
            for (var iRow = 0; iRow < dgvList.Rows.Count; iRow++)
            {
                // 日報入力ID比較
                if (int.Parse(dgvList.Rows[iRow].Cells["col01"].Value.ToString()) == p_id)
                {
                    // 該当IDの行を選択状態にする
                    dgvList.Rows[iRow].Selected = true;
                    break;
                }
            }
        }

        /// <summary>
        /// 新規登録ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            //// 編集画面
            //frmEditTrnReport cEditTrnReport = new frmEditTrnReport(con);

            //// ID=0（新規モード）に設定
            //cEditTrnReport.Id = 0;

            //// 編集画面表示
            //cEditTrnReport.ShowDialog();

            //// 新規登録された場合、再表示
            //if (cEditTrnReport.Id != 0)
            //{
            //    // 画面表示
            //    this.dgvList.Rows.Clear();
            //    DisplayTrnReport();

            //    // レコード選択設定
            //    // fDisplayTrnReport.Id を参照
            //    SelectRow(cEditTrnReport.Id);
            //}
        }
        /// <summary>
        /// 専従先選択ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectLocation_Click(object sender, EventArgs e)
        {
            // 専従先選択画面表示
            DisplayLocation();

            // 車両IDクリア、ボタン有効
            if (this.Location_id > 0)
            {
                this.Car_id = 0;
                this.Staff_id = 0;
                this.btnSelectCar.Enabled = true;
                // this.btnSelectStaff.Enabled = true;
                this.lblCarNo.Text = "";
                this.lblStaffName.Text = "";
            }
        }
        /// <summary>
        /// 専従先情報表示
        /// </summary>
        private void DisplayLocation()
        {
            var closind_date = 0;
            if (rdo1.Checked == true)
            {
                // 締め日を指定
                closind_date = int.Parse(this.cmbClosingDate.SelectedValue.ToString());
            }

            frmSelectLocation fSelectLocation = new()
            {
                TargetTable = "Mst_専従先",
                Select_location_name = "",
                Select_location_id = 0,
                Select_Closing_Date = closind_date
            };
            fSelectLocation.ShowDialog();

            if (fSelectLocation.Select_location_id > 0)
            {
                this.Location_id = fSelectLocation.Select_location_id;
                this.lblLocationName.Text = fSelectLocation.Select_location_name.ToString();
            }
        }
        /// <summary>
        /// 車両選択ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectCar_Click(object sender, EventArgs e)
        {
            // 車両選択画面表示
            DisplayLocationCar();
        }
        /// <summary>
        /// 専従先車両選択画面
        /// </summary>
        private void DisplayLocationCar()
        {
            選択画面.frmSelectItem fSelectItem = new()
            {
                IntKey = this.Location_id,
                Kbn = 6,                  // 専従先車両
                Value = 0
            };
            fSelectItem.ShowDialog();
            if (fSelectItem.Value == 0) { return; }

            // 車両情報保持
            this.Car_id = fSelectItem.Value;
            this.lblCarNo.Text = fSelectItem.StrVal;
        }
        /// <summary>
        /// 専従先専従者選択ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectStaff_Click(object sender, EventArgs e)
        {
            frmSelectStaff fSelectStaff = new()
            {
                TargetTable = "Mst_社員",
                Select_user_name = "",
                Select_user_id = 0
            };
            fSelectStaff.ShowDialog();
            if (fSelectStaff.Select_user_id == 0) { return; }

            this.Staff_id = fSelectStaff.Select_user_id;
            this.lblStaffName.Text = fSelectStaff.Select_user_name;

            // 担当者選択画面表示
            // DisplayLocationStaff();
        }
        /// <summary>
        /// 専従先専従者選択画面
        /// </summary>
        private void DisplayLocationStaff()
        {
            選択画面.frmSelectItem fSelectItem = new()
            {
                IntKey = this.Location_id,
                Kbn = 7,                  // 専従先車両
                Value = 0
            };
            fSelectItem.ShowDialog();
            if (fSelectItem.Value == 0) { return; }

            // 担当者情報保持
            this.Staff_id = fSelectItem.Value;
            this.lblStaffName.Text = fSelectItem.StrVal;
        }
        /// <summary>
        /// 条件クリアボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            // Formクリア
            ClearForm();
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
        /// 表示ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                this.dgvList.Rows.Clear();

                // 日付範囲取得
                string selectedYm = dtpYM.Value.ToString("yyyyMM");

                if (rdo2.Checked == true)
                {
                    // 範囲指定
                    this.From_day = this.dtpDate1.Value;
                    this.To_day = this.dtpDate2.Value;
                }

                // ============================================================
                // 日報データ取得
                // ============================================================
                ClsTrnReport cls = new()
                {
                    Key_report_id = 0,                      // 日報IDは指定しない
                    Key_from_day = this.From_day,           // 開始日
                    Key_to_day = this.To_day                // 終了日
                };

                // 年月指定は締め日を指定
                if (rdo1.Checked == true)
                {
                    cls.Key_closing_date = this.Closing_data;
                }

                // 専従先
                if (this.Location_id != 0)
                {
                    cls.Key_location_id = this.Location_id;
                }
                else
                {
                    cls.Key_location_id = 0;
                }
                // 車両
                if (this.Car_id != 0)
                {
                    cls.Key_car_id = this.Car_id;
                }
                else
                {
                    cls.Key_car_id = 0;
                }
                // 担当者
                if (this.Staff_id != 0)
                {
                    cls.Key_staff_id = this.Staff_id;
                }
                else
                {
                    cls.Key_staff_id = 0;
                }
                // 社内チェック
                if (this.chkConfirm1_1.Checked == true && this.chkConfirm1_2.Checked == false)
                {
                    cls.Key_confirm1 = 0;   // 未実施
                }
                else if (this.chkConfirm1_1.Checked == false && this.chkConfirm1_2.Checked == true)
                {
                    cls.Key_confirm1 = 1;   // 実施済
                }
                else
                {
                    cls.Key_confirm1 = 2;   // 両方
                }
                // 管理責任者確認
                if (this.chkConfirm2_1.Checked == true && this.chkConfirm2_2.Checked == false)
                {
                    cls.Key_confirm2 = 0;   // 未実施
                }
                else if (this.chkConfirm2_1.Checked == false && this.chkConfirm2_2.Checked == true)
                {
                    cls.Key_confirm2 = 1;   // 実施済
                }
                else
                {
                    cls.Key_confirm2 = 2;   // 両方
                }
                // お客様確認
                if (this.chkConfirm3_1.Checked == true && this.chkConfirm3_2.Checked == false)
                {
                    cls.Key_confirm3 = 0;   // 未実施
                }
                else if (this.chkConfirm3_1.Checked == false && this.chkConfirm3_2.Checked == true)
                {
                    cls.Key_confirm3 = 1;   // 実施済
                }
                else
                {
                    cls.Key_confirm3 = 2;   // 両方
                }

                // ID配列クリア
                clsPublicReport.pub_Id_list = null;
                clsPublicReport.pub_Current_id = 0;

                cls.Select();
                if (cls.Select_count <= 0)
                {
                    MessageBox.Show("条件に合う日報データはありません。", "結果", MessageBoxButtons.OK);
                    return;
                }

                // ID配列領域確保
                clsPublicReport.pub_Id_list = new int[cls.Select_count];

                // ============================================================
                // 日報データ表示
                // ============================================================
                DisplayList(cls.Dt);
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 日報データ一覧表示
        /// </summary>
        /// <param name="p_dt"></param>
        private void DisplayList(DataTable p_dt)
        {
            int i = 0;
            int over_time1 = 0;
            int over_time2 = 0;
            int over_time3 = 0;
            int location_id = 0;
            string car_no = null;
            int after_meter = 0;

            // 社内チェック
            int confirm1;
            int confirm2;
            int confirm3;
            string res;

            this.dgvList.Rows.Clear();

            try
            {
                // Selectデータを一覧へ表示
                foreach (DataRow dr in p_dt.Rows)
                {
                    // IDを配列に保持
                    clsPublicReport.pub_Id_list[i] = (int)dr["id"];

                    // 残業時間
                    over_time1 = dr["over_time1"] == DBNull.Value ? 0 : Convert.ToInt32(dr["over_time1"]);
                    over_time2 = dr["over_time2"] == DBNull.Value ? 0 : Convert.ToInt32(dr["over_time2"]);
                    over_time3 = dr["over_time3"] == DBNull.Value ? 0 : Convert.ToInt32(dr["over_time3"]);

                    this.dgvList.Rows.Add();
                    this.dgvList.Rows[i].Cells["col01"].Value = dr["id"];
                    this.dgvList.Rows[i].Cells["col02"].Value = dr["location_id"];
                    this.dgvList.Rows[i].Cells["col03"].Value = dr["FullNameLocation"];
                    this.dgvList.Rows[i].Cells["col04"].Value = DateTime.Parse(dr["day"].ToString()).ToString("yyyy年MM月dd日 dddd");
                    this.dgvList.Rows[i].Cells["col05"].Value = dr["no"];
                    this.dgvList.Rows[i].Cells["col06"].Value = dr["FullNameCar"];
                    this.dgvList.Rows[i].Cells["col07"].Value = dr["car_id"];
                    this.dgvList.Rows[i].Cells["col08"].Value = dr["staff_id1"];
                    this.dgvList.Rows[i].Cells["col09"].Value = dr["FullNameB"];
                    this.dgvList.Rows[i].Cells["col10"].Value = dr["staff_id2"];
                    this.dgvList.Rows[i].Cells["col11"].Value = "";
                    this.dgvList.Rows[i].Cells["col12"].Value = dr["staff_id3"];
                    this.dgvList.Rows[i].Cells["col13"].Value = "";

                    // ========================================================================================================
                    // 始業/終業時間（整合性チェック用）
                    // ========================================================================================================
                    var st1 = DateTime.Parse("1900/01/01 00:00:00");
                    var st2 = DateTime.Parse("1900/01/01 00:00:00");
                    var st3 = DateTime.Parse("1900/01/01 00:00:00");
                    var en1 = DateTime.Parse("1900/01/01 00:00:00");
                    var en2 = DateTime.Parse("1900/01/01 00:00:00");
                    var en3 = DateTime.Parse("1900/01/01 00:00:00");

                    // 開始時間
                    if (dr.IsNull("start_time1") != true)
                    {
                        this.dgvList.Rows[i].Cells["col14"].Value = DateTime.Parse(dr["start_time1"].ToString()).ToString("HH:mm");
                        st1 = DateTime.Parse(dr["start_time1"].ToString());
                    }
                    else
                    {
                        this.dgvList.Rows[i].Cells["col14"].Value = "";
                    }
                    if (dr.IsNull("start_time2") != true)
                    {
                        this.dgvList.Rows[i].Cells["col15"].Value = DateTime.Parse(dr["start_time2"].ToString()).ToString("HH:mm");
                        st2 = DateTime.Parse(dr["start_time2"].ToString());
                    }
                    else
                    {
                        this.dgvList.Rows[i].Cells["col15"].Value = "";
                    }
                    if (dr.IsNull("start_time3") != true)
                    {
                        this.dgvList.Rows[i].Cells["col16"].Value = DateTime.Parse(dr["start_time3"].ToString()).ToString("HH:mm");
                        st3 = DateTime.Parse(dr["start_time3"].ToString());
                    }
                    else
                    {
                        this.dgvList.Rows[i].Cells["col16"].Value = "";
                    }
                    // 終了時間
                    if (dr.IsNull("end_time1") != true)
                    {
                        this.dgvList.Rows[i].Cells["col17"].Value = DateTime.Parse(dr["end_time1"].ToString()).ToString("HH:mm");
                        en1 = DateTime.Parse(dr["end_time1"].ToString());
                    }
                    else
                    {
                        this.dgvList.Rows[i].Cells["col17"].Value = "";
                    }
                    if (dr.IsNull("end_time2") != true)
                    {
                        this.dgvList.Rows[i].Cells["col18"].Value = DateTime.Parse(dr["end_time2"].ToString()).ToString("HH:mm");
                        en2 = DateTime.Parse(dr["end_time2"].ToString());
                    }
                    else
                    {
                        this.dgvList.Rows[i].Cells["col18"].Value = "";
                    }
                    if (dr.IsNull("end_time3") != true)
                    {
                        this.dgvList.Rows[i].Cells["col19"].Value = DateTime.Parse(dr["end_time3"].ToString()).ToString("HH:mm");
                        en3 = DateTime.Parse(dr["end_time3"].ToString());
                    }
                    else
                    {
                        this.dgvList.Rows[i].Cells["col19"].Value = "";
                    }

                    // 時刻整合性チェック
                    // 始業①終了①どちらか未入力の場合
                    if (st1 == DateTime.Parse("1900/01/01"))
                    {
                        // セル設定
                        // ClsPublic.SetGridViewFont(i, 14, "未入", ClsPublic.LIST_FONT_TYPE, ClsPublic.LIST_FONT_SIZE11, System.Drawing.Color.Red, FontStyle.Bold, this.dgvList);
                    }
                    else
                    {
                        // セル設定（OK）
                        // ClsPublic.SetGridViewFont(i, 14, this.dgvList.Rows[i].Cells["col14"].Value.ToString(), ClsPublic.LIST_FONT_TYPE, ClsPublic.LIST_FONT_SIZE11, System.Drawing.Color.Black, FontStyle.Regular, this.dgvList);
                    }
                    if (en1 == DateTime.Parse("1900/01/01"))
                    {
                        // セル設定
                        // ClsPublic.SetGridViewFont(i, 17, "未入", ClsPublic.LIST_FONT_TYPE, ClsPublic.LIST_FONT_SIZE11, System.Drawing.Color.Red, FontStyle.Bold, this.dgvList);
                    }
                    else
                    {
                        // セル設定（OK）
                        // ClsPublic.SetGridViewFont(i, 17, this.dgvList.Rows[i].Cells["col17"].Value.ToString(), ClsPublic.LIST_FONT_TYPE, ClsPublic.LIST_FONT_SIZE11, System.Drawing.Color.Black, FontStyle.Regular, this.dgvList);
                    }

                    //// 始業②入力あり終業②入力なし
                    if (st2 != DateTime.Parse("1900/01/01") && en2 == DateTime.Parse("1900/01/01"))
                    {
                        // セル設定
                        // ClsPublic.SetGridViewFont(i, 15, "未入", ClsPublic.LIST_FONT_TYPE, ClsPublic.LIST_FONT_SIZE11, System.Drawing.Color.Red, FontStyle.Bold, this.dgvList);
                    }
                    else
                    {
                        // セル設定（OK）
                        ClsPublic.SetGridViewFont(i, 16, this.dgvList.Rows[i].Cells["col15"].Value.ToString(), ClsPublic.LIST_FONT_TYPE, ClsPublic.LIST_FONT_SIZE11, System.Drawing.Color.Black, FontStyle.Regular, this.dgvList);
                    }

                    //// 始業②入力なし終業②入力あり
                    if (st2 == DateTime.Parse("1900/01/01") && en2 != DateTime.Parse("1900/01/01"))
                    {
                        // セル設定
                        // ClsPublic.SetGridViewFont(i, 18, "未入", ClsPublic.LIST_FONT_TYPE, ClsPublic.LIST_FONT_SIZE11, System.Drawing.Color.Red, FontStyle.Bold, this.dgvList);
                    }
                    else
                    {
                        // セル設定（OK）
                        // ClsPublic.SetGridViewFont(i, 18, this.dgvList.Rows[i].Cells["col18"].Value.ToString(), ClsPublic.LIST_FONT_TYPE, ClsPublic.LIST_FONT_SIZE11, System.Drawing.Color.Black, FontStyle.Regular, this.dgvList);
                    }

                    //// 始業③入力あり終業③入力なし
                    if (st3 != DateTime.Parse("1900/01/01") && en3 == DateTime.Parse("1900/01/01"))
                    {
                        // セル設定
                        // ClsPublic.SetGridViewFont(i, 16, "未入", ClsPublic.LIST_FONT_TYPE, ClsPublic.LIST_FONT_SIZE11, System.Drawing.Color.Red, FontStyle.Bold, this.dgvList);
                    }
                    else
                    {
                        // セル設定（OK）
                        ClsPublic.SetGridViewFont(i, 17, this.dgvList.Rows[i].Cells["col16"].Value.ToString(), ClsPublic.LIST_FONT_TYPE, ClsPublic.LIST_FONT_SIZE11, System.Drawing.Color.Black, FontStyle.Regular, this.dgvList);
                    }

                    //// 始業③入力なし終業③入力あり
                    if (st3 == DateTime.Parse("1900/01/01") && en3 != DateTime.Parse("1900/01/01"))
                    {
                        // セル設定
                        // ClsPublic.SetGridViewFont(i, 19, "未入", ClsPublic.LIST_FONT_TYPE, ClsPublic.LIST_FONT_SIZE11, System.Drawing.Color.Red, FontStyle.Bold, this.dgvList);
                    }
                    else
                    {
                        // セル設定（OK）
                        
                        ClsPublic.SetGridViewFont(i, 20, this.dgvList.Rows[i].Cells["col19"].Value.ToString(), ClsPublic.LIST_FONT_TYPE, ClsPublic.LIST_FONT_SIZE11, System.Drawing.Color.Black, FontStyle.Regular, this.dgvList);
                    }

                    // 始業①入力あり終業①入力ありで始業①>終業①の場合
                    if (st1 != DateTime.Parse("1900/01/01") && en1 != DateTime.Parse("1900/01/01"))
                    {
                        if (st1 > en1)
                        {
                            // セル設定
                            ClsPublic.SetGridViewFont(i, 15, this.dgvList.Rows[i].Cells["col14"].Value.ToString(), ClsPublic.LIST_FONT_TYPE, ClsPublic.LIST_FONT_SIZE11, System.Drawing.Color.Red, FontStyle.Bold, this.dgvList);
                            ClsPublic.SetGridViewFont(i, 18, this.dgvList.Rows[i].Cells["col17"].Value.ToString(), ClsPublic.LIST_FONT_TYPE, ClsPublic.LIST_FONT_SIZE11, System.Drawing.Color.Red, FontStyle.Bold, this.dgvList);
                        }
                        else
                        {
                            // セル設定（OK）
                            ClsPublic.SetGridViewFont(i, 15, this.dgvList.Rows[i].Cells["col14"].Value.ToString(), ClsPublic.LIST_FONT_TYPE, ClsPublic.LIST_FONT_SIZE11, System.Drawing.Color.Black, FontStyle.Regular, this.dgvList);
                            ClsPublic.SetGridViewFont(i, 18, this.dgvList.Rows[i].Cells["col17"].Value.ToString(), ClsPublic.LIST_FONT_TYPE, ClsPublic.LIST_FONT_SIZE11, System.Drawing.Color.Black, FontStyle.Regular, this.dgvList);
                        }
                    }
                    //// 始業②入力あり終業②入力ありで始業②>終業②の場合
                    if (st2 != DateTime.Parse("1900/01/01") && en2 != DateTime.Parse("1900/01/01"))
                    {
                        if (st2 > en2)
                        {
                            // セル設定
                            ClsPublic.SetGridViewFont(i, 16, this.dgvList.Rows[i].Cells["col15"].Value.ToString(), ClsPublic.LIST_FONT_TYPE, ClsPublic.LIST_FONT_SIZE11, System.Drawing.Color.Red, FontStyle.Bold, this.dgvList);
                            ClsPublic.SetGridViewFont(i, 19, this.dgvList.Rows[i].Cells["col18"].Value.ToString(), ClsPublic.LIST_FONT_TYPE, ClsPublic.LIST_FONT_SIZE11, System.Drawing.Color.Red, FontStyle.Bold, this.dgvList);
                        }
                        else
                        {
                            // セル設定（OK）
                            ClsPublic.SetGridViewFont(i, 16, this.dgvList.Rows[i].Cells["col15"].Value.ToString(), ClsPublic.LIST_FONT_TYPE, ClsPublic.LIST_FONT_SIZE11, System.Drawing.Color.Black, FontStyle.Regular, this.dgvList);
                            ClsPublic.SetGridViewFont(i, 19, this.dgvList.Rows[i].Cells["col18"].Value.ToString(), ClsPublic.LIST_FONT_TYPE, ClsPublic.LIST_FONT_SIZE11, System.Drawing.Color.Black, FontStyle.Regular, this.dgvList);
                        }
                    }
                    //// 始業③入力あり終業③入力ありで始業③>終業③の場合
                    if (st3 != DateTime.Parse("1900/01/01") && en3 != DateTime.Parse("1900/01/01"))
                    {
                        if (st3 > en3)
                        {
                            // セル設定
                            ClsPublic.SetGridViewFont(i, 17, this.dgvList.Rows[i].Cells["col16"].Value.ToString(), ClsPublic.LIST_FONT_TYPE, ClsPublic.LIST_FONT_SIZE11, System.Drawing.Color.Red, FontStyle.Bold, this.dgvList);
                            ClsPublic.SetGridViewFont(i, 20, this.dgvList.Rows[i].Cells["col19"].Value.ToString(), ClsPublic.LIST_FONT_TYPE, ClsPublic.LIST_FONT_SIZE11, System.Drawing.Color.Red, FontStyle.Bold, this.dgvList);
                        }
                        else
                        {
                            // セル設定（OK）
                            ClsPublic.SetGridViewFont(i, 17, this.dgvList.Rows[i].Cells["col16"].Value.ToString(), ClsPublic.LIST_FONT_TYPE, ClsPublic.LIST_FONT_SIZE11, System.Drawing.Color.Black, FontStyle.Regular, this.dgvList);
                            ClsPublic.SetGridViewFont(i, 20, this.dgvList.Rows[i].Cells["col19"].Value.ToString(), ClsPublic.LIST_FONT_TYPE, ClsPublic.LIST_FONT_SIZE11, System.Drawing.Color.Black, FontStyle.Regular, this.dgvList);
                        }
                    }
                    //this.dgvList.Rows[i].Cells["col14"].Style.BackColor = System.Drawing.Color.RoyalBlue;
                    //this.dgvList.Rows[i].Cells["col15"].Style.BackColor = System.Drawing.Color.LightSkyBlue;
                    //this.dgvList.Rows[i].Cells["col16"].Style.BackColor = System.Drawing.Color.DodgerBlue;
                    //this.dgvList.Rows[i].Cells["col17"].Style.BackColor = System.Drawing.Color.RoyalBlue;
                    //this.dgvList.Rows[i].Cells["col18"].Style.BackColor = System.Drawing.Color.LightSkyBlue;
                    //this.dgvList.Rows[i].Cells["col19"].Style.BackColor = System.Drawing.Color.DodgerBlue;
                    this.dgvList.Rows[i].Cells["col14"].Style.BackColor = System.Drawing.Color.PowderBlue;
                    this.dgvList.Rows[i].Cells["col15"].Style.BackColor = System.Drawing.Color.SkyBlue;
                    this.dgvList.Rows[i].Cells["col16"].Style.BackColor = System.Drawing.Color.LightSteelBlue;
                    this.dgvList.Rows[i].Cells["col17"].Style.BackColor = System.Drawing.Color.PowderBlue;
                    this.dgvList.Rows[i].Cells["col18"].Style.BackColor = System.Drawing.Color.SkyBlue;
                    this.dgvList.Rows[i].Cells["col19"].Style.BackColor = System.Drawing.Color.LightSteelBlue;

                    // ========================================================================================================
                    // 残業有無
                    // ========================================================================================================
                    if ((over_time1 + over_time2 + over_time3) > 0)
                    {
                        this.dgvList.Rows[i].Cells["col24"].Value = (over_time1 + over_time2 + over_time3);
                    }

                    // ========================================================================================================
                    // 入庫時、出庫時メーター、走行距離
                    // ========================================================================================================
                    var aft = -1;
                    var bfr = -1;

                    if (dr.IsNull("after_meter") != true && dr["after_meter"].ToString() != "" && dr["after_meter"].ToString() != "-1")
                    {
                        this.dgvList.Rows[i].Cells["col20"].Value = dr["after_meter"];
                        aft = int.Parse(dr["after_meter"].ToString());

                    }
                    if (dr.IsNull("before_meter") != true && dr["before_meter"].ToString() != "" && dr["before_meter"].ToString() != "-1")
                    {
                        this.dgvList.Rows[i].Cells["col21"].Value = dr["before_meter"];
                        bfr = int.Parse(dr["before_meter"].ToString());
                    }

                    // 入庫時、出庫時メーター値チェック
                    if (aft != -1 && bfr != -1)
                    {
                        // 整合性チェック
                        if (aft < bfr)
                        {
                            // セル設定
                            //ClsPublic.SetGridViewFont(i, 21, this.dgvList.Rows[i].Cells["col20"].Value.ToString(), ClsPublic.LIST_FONT_TYPE, ClsPublic.LIST_FONT_SIZE11, System.Drawing.Color.Red, FontStyle.Bold, this.dgvList);
                            //ClsPublic.SetGridViewFont(i, 22, this.dgvList.Rows[i].Cells["col21"].Value.ToString(), ClsPublic.LIST_FONT_TYPE, ClsPublic.LIST_FONT_SIZE11, System.Drawing.Color.Red, FontStyle.Bold, this.dgvList);
                            ClsPublic.SetGridViewFont(i, 22, aft.ToString(), ClsPublic.LIST_FONT_TYPE, ClsPublic.LIST_FONT_SIZE11, System.Drawing.Color.Red, FontStyle.Bold, this.dgvList);
                            ClsPublic.SetGridViewFont(i, 23, bfr.ToString(), ClsPublic.LIST_FONT_TYPE, ClsPublic.LIST_FONT_SIZE11, System.Drawing.Color.Red, FontStyle.Bold, this.dgvList);
                        }
                        else
                        {
                            // セル設定（OK）
                            //ClsPublic.SetGridViewFont(i, 21, this.dgvList.Rows[i].Cells["col20"].Value.ToString(), ClsPublic.LIST_FONT_TYPE, ClsPublic.LIST_FONT_SIZE11, System.Drawing.Color.Black, FontStyle.Regular, this.dgvList);
                            //ClsPublic.SetGridViewFont(i, 22, this.dgvList.Rows[i].Cells["col21"].Value.ToString(), ClsPublic.LIST_FONT_TYPE, ClsPublic.LIST_FONT_SIZE11, System.Drawing.Color.Black, FontStyle.Regular, this.dgvList);
                            ClsPublic.SetGridViewFont(i, 22, aft.ToString(), ClsPublic.LIST_FONT_TYPE, ClsPublic.LIST_FONT_SIZE11, System.Drawing.Color.Black, FontStyle.Regular, this.dgvList);
                            ClsPublic.SetGridViewFont(i, 23, bfr.ToString(), ClsPublic.LIST_FONT_TYPE, ClsPublic.LIST_FONT_SIZE11, System.Drawing.Color.Black, FontStyle.Regular, this.dgvList);
                        }
                    }

                    // 前回日報の入庫メーター値と今回日報の「出庫メーター」比較
                    if (location_id != 0 && location_id == int.Parse(dr["location_id"].ToString()) && car_no == dr["no"].ToString())
                    {
                        // 前回メータと比較
                        if (after_meter != bfr)
                        {
                            // ClsPublic.SetGridViewFont(i, 22, this.dgvList.Rows[i].Cells["col21"].Value.ToString(), ClsPublic.LIST_FONT_TYPE, ClsPublic.LIST_FONT_SIZE11, System.Drawing.Color.Red, FontStyle.Bold, this.dgvList);
                            ClsPublic.SetGridViewFont(i, 23, bfr.ToString(), ClsPublic.LIST_FONT_TYPE, ClsPublic.LIST_FONT_SIZE11, System.Drawing.Color.Red, FontStyle.Bold, this.dgvList);
                        }
                        after_meter = aft;
                    }
                    else
                    {
                        location_id = int.Parse(dr["location_id"].ToString());
                        car_no = dr["no"].ToString();
                        after_meter = aft;
                    }

                    if (dr["mileage"] != null && dr["mileage"].ToString() != "" && dr["mileage"].ToString() != "-1")
                    {
                        this.dgvList.Rows[i].Cells["col22"].Value = dr["mileage"];
                    }

                    if (dr["fuel"] != null && dr["fuel"].ToString() != "" && dr["fuel"].ToString() != "-1")
                    {
                        this.dgvList.Rows[i].Cells["col23"].Value = dr["fuel"];
                    }

                    // ========================================================================================================
                    // 社内チェック・営業承認
                    // ========================================================================================================
                    confirm1 = 0;       // 一次確認
                    confirm2 = 0;       // 二次確認
                    confirm3 = 0;       // 三次確認
                    res = "";           // 表示用
                    if (dr["confirm1_id"].ToString() != "0") { confirm1 = int.Parse(dr["confirm1_id"].ToString()); }
                    if (dr["confirm2_id"].ToString() != "0") { confirm2 = int.Parse(dr["confirm2_id"].ToString()); }
                    if (dr["confirm3_id"].ToString() != "0") { confirm3 = int.Parse(dr["confirm3_id"].ToString()); }

                    // 0以外の値の数をカウント
                    int count = new[] { confirm1, confirm2, confirm3 }.Count(v => v != 0);
                    // 結果を判定
                    res = count switch
                    {
                        1 => "①",
                        2 => "②",
                        3 => "済",
                        _ => "" // 全て0の場合
                    };
                    this.dgvList.Rows[i].Cells["col25"].Value = res;
                    // 上記処理LINQを使用しない処理↓
                    //int check_count = 0;
                    //if (confirm1 != 0) check_count++;
                    //if (confirm2 != 0) check_count++;
                    //if (confirm3 != 0) check_count++;
                    //res = "";
                    //if (check_count == 1) res = "①";
                    //else if (check_count == 2) res = "②";
                    //else if (check_count == 3) res = "済";

                    // 管理責任者確認
                    if (dr["sales_id"] != null && dr["sales_id"].ToString() != "" && dr["sales_id"].ToString() != "0")
                    {
                        this.dgvList.Rows[i].Cells["col26"].Value = "済";
                    }
                    // お客様確認
                    if (dr["guest_id"] != null && dr["guest_id"].ToString() != "" && dr["guest_id"].ToString() != "0")
                    {
                        this.dgvList.Rows[i].Cells["col27"].Value = "済";
                    }

                    // 代車
                    if (dr["subcar_flag"] != null && dr["subcar_flag"].ToString() != "" && dr["subcar_flag"].ToString() != "0")
                    {
                        this.dgvList.Rows[i].Cells["col28"].Value = "代";
                    }

                    i++;
                }
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// セルクリックイベント(ボタンのみ処理)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // ボタン列がクリックされたかを確認
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) // 0 はボタン列のインデックス
            {
                // 日報ID取得
                var report_id = int.Parse(((DataGridView)sender).Rows[e.RowIndex].Cells[1].Value.ToString());

                frmEditTrnReport cls = new()
                {
                    Report_id = report_id   // 日報IDセット
                };

                cls.delete_flag = ClsPublic.FLAG_OFF; // 削除実施フラグクリア
                cls.ShowDialog();           // 日報編集画面表示

                // 削除実施判定
                if (cls.delete_flag == ClsPublic.FLAG_ON)
                {
                    // 削除実施の場合は再表示
                    btnDisplay_Click(null, null);
                }
            }
        }
        /// <summary>
        /// 閉じるボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// 日報統計表CSV出力ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCsv_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdo2.Checked == true)
                {
                    // 範囲指定
                    this.From_day = this.dtpDate1.Value;
                    this.To_day = this.dtpDate2.Value;
                }

                // ============================================================
                // 日報データ取得
                // ============================================================
                ClsTrnReport clsTrnReport = new()
                {
                    Key_report_id = 0,                      // 日報IDは指定しない
                    Key_from_day = this.From_day,           // 開始日
                    Key_to_day = this.To_day                // 終了日
                };


                // 専従先
                if (this.Location_id != 0)
                {
                    clsTrnReport.Key_location_id = this.Location_id;
                }
                else
                {
                    clsTrnReport.Key_location_id = 0;
                }
                // 車両
                if (this.Car_id != 0)
                {
                    clsTrnReport.Key_car_id = this.Car_id;
                }
                else
                {
                    clsTrnReport.Key_car_id = 0;
                }
                // 担当者
                if (this.Staff_id != 0)
                {
                    clsTrnReport.Key_staff_id = this.Staff_id;
                }
                else
                {
                    clsTrnReport.Key_staff_id = 0;
                }
                // 締め日
                clsTrnReport.Key_closing_date = this.Closing_data;

                clsTrnReport.SelectCsv();
                if (clsTrnReport.Select_count <= 0)
                {
                    MessageBox.Show("条件に合う日報データはありません。", "結果", MessageBoxButtons.OK);
                    return;
                }

                // CSV出力
                OutputCsv(clsTrnReport.Dt);

                MessageBox.Show("CSV出力　正常終了", "結果", MessageBoxButtons.OK);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK);
                throw;
            } 
        }
        /// <summary>
        /// 年月、締め日変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateClosePeriod(object sender, EventArgs e)
        {
            DateTime selectedYm = dtpYM.Value;
            string val = cmbClosingDate.SelectedValue.ToString();

            DateTime startDate, endDate;

            if (val == "20")
            {
                // 前月21日～当月20日
                DateTime prevMonth = selectedYm.AddMonths(-1);
                startDate = new DateTime(prevMonth.Year, prevMonth.Month, 21);
                endDate = new DateTime(selectedYm.Year, selectedYm.Month, 20);
                // 締め日
                this.Closing_data = 20;
            }
            else
            {
                // 当月1日～月末日
                startDate = new DateTime(selectedYm.Year, selectedYm.Month, 1);
                endDate = new DateTime(selectedYm.Year, selectedYm.Month,
                    DateTime.DaysInMonth(selectedYm.Year, selectedYm.Month));
                // 締め日
                this.Closing_data = 31;
            }

            // 日付保持
            this.From_day = startDate;
            this.To_day = endDate;

            lblFromToDay.Text = $"{startDate:yyyy/MM/dd} ～ {endDate:yyyy/MM/dd}";
        }
        /// <summary>
        /// 締め年月指定（ラジオボタン）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdo1_CheckedChanged(object sender, EventArgs e)
        {
            dtpYM.Enabled = true;
            cmbClosingDate.Enabled = true;
            lblFromToDay.Visible = true;
            dtpDate1.Enabled = false;
            dtpDate2.Enabled = false;
            btnCsv.Enabled = true;

            UpdateClosePeriod(null, null);
        }
        /// <summary>
        /// 日付範囲指定（ラジオボタン）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdo2_CheckedChanged(object sender, EventArgs e)
        {
            dtpYM.Enabled = false;
            cmbClosingDate.Enabled = false;
            lblFromToDay.Visible = false;
            dtpDate1.Enabled = true;
            dtpDate2.Enabled = true;
            btnCsv.Enabled = false;
        }
        /// <summary>
        /// 日報データCSV出力
        /// </summary>
        /// <param name="dt"></param>
        private void OutputCsv(DataTable dt)
        {
            // 指定年月
            DateTime selectedYm = dtpYM.Value;                          // 指定年月
            string selected_y = selectedYm.ToString("yyyy");            // 年
            string selected_ym = selectedYm.ToString("yyyyMM");         // 年月

            // CSV出力 パス付きフォルダ名編集
            string folder_path = clsPublicReport.pub_Csv_path + @"\" + selected_y + "年" + @"\" + selected_ym + "_日報処理" + @"\" + selected_ym + "_日報CSV";

            // フォルダ作成
            Directory.CreateDirectory(folder_path);

            // CSV出力処理
            var file_name = string.Empty;                  // CSVファイル名 
            var location_name = string.Empty;              // 専従先
            StringBuilder sb = new StringBuilder();        // CSV書き込みデータ 
            foreach(DataRow dr in dt.Rows)
            {
                // 専従先（保持）と専従先（DataRow）比較
                if (location_name != dr["FullNameLocation"].ToString())
                {
                    // 異なる場合、DataRow最初のデータであるかチェック
                    if (location_name != string.Empty)
                    {
                        // ==============================================================
                        // 専従先が変わった場合、CSVファイルへ書き込み
                        // ==============================================================
                        // パス付きCSVファイル名編集
                        file_name = folder_path + @"\" + selected_ym + "_" + location_name + ".csv";
                        if (File.Exists(file_name))
                        {
                            // 存在する場合は削除
                            File.Delete(file_name);
                            Console.WriteLine("ファイルを削除しました。");
                        }
                        // CSVファイルとして保存
                        File.WriteAllText(file_name, sb.ToString(), Encoding.UTF8);
                    }

                    // 専従先名を保持
                    location_name = dr["FullNameLocation"].ToString();

                    // 書き込み用bufferクリア
                    sb.Clear();
                }
                // 書き込みデータをbufferへセット
                var s_time1 = "";                                 // 開始時間1
                var s_time2 = "";                                 // 開始時間2
                var s_time3 = "";                                 // 開始時間3
                var e_time1 = "";                                 // 終了時間1
                var e_time2 = "";                                 // 終了時間2
                var e_time3 = "";                                 // 終了時間3
                if (dr["start_time1"].ToString() != "") { s_time1 = DateTime.Parse(dr["start_time1"].ToString()).ToString("Hmm"); }
                if (dr["start_time2"].ToString() != "") { s_time2 = DateTime.Parse(dr["start_time2"].ToString()).ToString("Hmm"); }
                if (dr["start_time3"].ToString() != "") { s_time3 = DateTime.Parse(dr["start_time3"].ToString()).ToString("Hmm"); }
                if (dr["end_time1"].ToString() != "") { e_time1 = DateTime.Parse(dr["end_time1"].ToString()).ToString("Hmm"); }
                if (dr["end_time2"].ToString() != "") { e_time2 = DateTime.Parse(dr["end_time2"].ToString()).ToString("Hmm"); }
                if (dr["end_time3"].ToString() != "") { e_time3 = DateTime.Parse(dr["end_time3"].ToString()).ToString("Hmm"); }

                var write_buffer = dr["FullName"] + "," + dr["day"].ToString().Substring(0,10) + "," + dr["no"] + "," + dr["after_meter"] + "," + dr["before_meter"] + "," + dr["fuel"] + "," + s_time1 + "," + s_time2 + "," + s_time3 + "," + e_time1 + "," + e_time2 + "," + e_time3;
                sb.AppendLine(write_buffer);
            }
            // ==============================================================
            // 最後の専従先をCSVファイルへ書き込み
            // ==============================================================
            // パス付きCSVファイル名編集
            file_name = folder_path + @"\" + selected_ym + "_" + location_name + ".csv";
            if (File.Exists(file_name))
            {
                // 存在する場合は削除
                File.Delete(file_name);
                Console.WriteLine("ファイルを削除しました。");
            }
            // CSVファイルとして保存
            File.WriteAllText(file_name, sb.ToString(), Encoding.UTF8);
        }
        /// <summary>
        /// 日報一括確認
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("表示中の日報を全て確認済みにします。","確認",MessageBoxButtons.OKCancel) == DialogResult.Cancel) { return; }

            var cnt = clsPublicReport.pub_Id_list.Length;

            if (cnt == 0) { return; }

            StringBuilder sb = new StringBuilder();

            try
            {
                for (int i = 0; i < cnt; i++)
                {
                    // 日報データ更新
                    using (ClsSqlDb clsSqlDb = new ClsSqlDb(ClsDbConfig.SQLServerNo))
                    {
                        sb.Clear();
                        sb.AppendLine("UPDATE");
                        sb.AppendLine(" Trn_日報");
                        sb.AppendLine(" SET");
                        sb.AppendLine(" sales_id = " + ClsLoginUser.StaffID);
                        sb.AppendLine(",sales_confirm_date = '" + DateTime.Now.ToString("yyyy/MM/dd") + "'");
                        sb.AppendLine(" WHERE");
                        sb.AppendLine(" id = " + clsPublicReport.pub_Id_list[i]);
                        sb.AppendLine(" AND");
                        sb.AppendLine(" (over_time1 = 0 OR over_time1 IS NULL)");
                        sb.AppendLine(" AND");
                        sb.AppendLine(" (over_time2 = 0 OR over_time2 IS NULL)");
                        sb.AppendLine(" AND");
                        sb.AppendLine(" (over_time3 = 0 OR over_time3 IS NULL)");
                        clsSqlDb.DMLUpdate(sb.ToString());
                    }
                }
                MessageBox.Show("表示中の日報を全て確認済みに設定しました。");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
    }
}
