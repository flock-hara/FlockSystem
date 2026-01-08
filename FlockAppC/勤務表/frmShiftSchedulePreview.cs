using FlockAppC.pubClass;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FlockAppC.勤務表
{
    public partial class frmShiftSchedulePreview : Form
    {
        // ----------------------------------------------------------------
        // Column定義
        // ----------------------------------------------------------------
        readonly DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
        readonly DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
        readonly DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
        readonly DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
        readonly DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn();
        readonly DataGridViewTextBoxColumn col6 = new DataGridViewTextBoxColumn();
        readonly DataGridViewTextBoxColumn col7 = new DataGridViewTextBoxColumn();
        readonly DataGridViewTextBoxColumn col8 = new DataGridViewTextBoxColumn();
        readonly DataGridViewTextBoxColumn col9 = new DataGridViewTextBoxColumn();
        readonly DataGridViewTextBoxColumn col10 = new DataGridViewTextBoxColumn();
        readonly DataGridViewTextBoxColumn col11 = new DataGridViewTextBoxColumn();
        readonly DataGridViewTextBoxColumn col12 = new DataGridViewTextBoxColumn();
        readonly DataGridViewTextBoxColumn col13 = new DataGridViewTextBoxColumn();
        readonly DataGridViewTextBoxColumn col14 = new DataGridViewTextBoxColumn();
        readonly DataGridViewTextBoxColumn col15 = new DataGridViewTextBoxColumn();
        readonly DataGridViewTextBoxColumn col16 = new DataGridViewTextBoxColumn();
        readonly DataGridViewTextBoxColumn col17 = new DataGridViewTextBoxColumn();
        readonly DataGridViewTextBoxColumn col18 = new DataGridViewTextBoxColumn();
        readonly DataGridViewTextBoxColumn col19 = new DataGridViewTextBoxColumn();
        readonly DataGridViewTextBoxColumn col20 = new DataGridViewTextBoxColumn();
        readonly DataGridViewTextBoxColumn col21 = new DataGridViewTextBoxColumn();
        readonly DataGridViewTextBoxColumn col22 = new DataGridViewTextBoxColumn();
        readonly DataGridViewTextBoxColumn col23 = new DataGridViewTextBoxColumn();
        readonly DataGridViewTextBoxColumn col24 = new DataGridViewTextBoxColumn();
        readonly DataGridViewTextBoxColumn col25 = new DataGridViewTextBoxColumn();
        readonly DataGridViewTextBoxColumn col26 = new DataGridViewTextBoxColumn();

        private readonly StringBuilder sb = new();

        public frmShiftSchedulePreview()
        {
            InitializeComponent();
        }

        private void frmShiftSchedulePreview_Load(object sender, EventArgs e)
        {
            // ----------------------------------------------------------------
            // システム環境値
            // ----------------------------------------------------------------
            ClsPublic.stcConfig[0] = new ClsConfig(1);
            ClsPublic.stcConfig[1] = new ClsConfig(2);

            // ----------------------------------------------------------------
            // 日付(From/To)
            // ----------------------------------------------------------------
            // From
            this.lblFromYear.Text = ClsPublic.stcConfig[0].Year.ToString();
            this.lblFromMonth.Text = ClsPublic.stcConfig[0].Month.ToString();
            // To
            if (ClsPublic.stcConfig[1].FilePath != "" && ClsPublic.stcConfig[1].FilePath != null)
            {
                this.lblToYear.Text = ClsPublic.stcConfig[1].Year.ToString();
                this.lblToMonth.Text = ClsPublic.stcConfig[1].Month.ToString();
                this.lblToYear.Visible = true;
                this.lblToMonth.Visible = true;
                this.lblToYearLabel.Visible = true;
                this.lblToMonthLabel.Visible = true;
                this.lblKara.Visible = true;
                this.lblKakko2.Visible = false;
                this.lblKakko3.Visible = true;
            }

            // ----------------------------------------------------------------
            // コントロールサイズ、位置
            // ----------------------------------------------------------------
            SetControllLocation();

            // ----------------------------------------------------------------
            // カラー説明
            // ----------------------------------------------------------------
            this.pnlContact.BackColor = System.Drawing.Color.PaleGreen;
            this.pnlApproval.BackColor = System.Drawing.Color.LightCoral;

            // ----------------------------------------------------------------
            // 連絡済(Trn_連絡)を削除
            // ----------------------------------------------------------------
            // deleteContactData();

            // ----------------------------------------------------------------
            // 当月、翌月登録担当者数比較
            // ----------------------------------------------------------------
            // 同じ場合は「当月翌月」にチェック
            if (CheckTantoCount() == true) { this.rdo3.Checked = true; }
            else { this.rdo1.Checked = true; }


            // ----------------------------------------------------------------
            // DataGridView初期設定
            // ----------------------------------------------------------------
            this.dgvList.Columns.Clear();
            InitializeDgvList();

            // ----------------------------------------------------------------
            // 予定勤務データ表示
            // ----------------------------------------------------------------
            // rdo1=check:当月のみ表示　rdo3=check:当月、翌月を表示
            if (this.rdo1.Checked == true) { DisplayShiftList(0); }
            else { DisplayShiftList(1); }

            // ----------------------------------------------------------------
            // 連絡済情報
            // ----------------------------------------------------------------
            ShiftContact();

            // 自動再表示:true
            this.chkAuto.Checked = true;

            // 左上に表示
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);

            // ====== 2024/09/06 タイマーでの再表示はとりあえずしない =========
            // ----------------------------------------------------------------
            // 5秒おき
            // Timer1.Interval = 5000
            this.timer1.Interval = int.Parse(ClsPublic.stcConfig[0].RefreshTimer) * 1000;
            // タイマー開始
            this.timer1.Enabled = false;
            // this.timer1.Enabled = true;
        }
        /// <summary>
        /// コントロール表示位置設定
        /// </summary>
        private void SetControllLocation()
        {
            // コントロール位置情報取得
            // clsControllLocation clsControllLocation = new clsControllLocation();
            ClsPublic.stcControllLocation = new ClsControllLocation();

            // コントロール位置、サイズ設定
            this.Width = ClsPublic.stcControllLocation.PreWidth;
            this.Height = ClsPublic.stcControllLocation.PreHeight;
            this.dgvList.Width = ClsPublic.stcControllLocation.PreShiftGridWidth;
            this.dgvList.Height = ClsPublic.stcControllLocation.PreShiftGridHeight;
            this.btnClose.Left = ClsPublic.stcControllLocation.EndButtonX;

            this.btn1.Width = ClsPublic.stcControllLocation.TantoBtnWidth;
            this.btn2.Width = ClsPublic.stcControllLocation.TantoBtnWidth;
            this.btn3.Width = ClsPublic.stcControllLocation.TantoBtnWidth;
            this.btn4.Width = ClsPublic.stcControllLocation.TantoBtnWidth;
            this.btn5.Width = ClsPublic.stcControllLocation.TantoBtnWidth;
            this.btn6.Width = ClsPublic.stcControllLocation.TantoBtnWidth;
            this.btn7.Width = ClsPublic.stcControllLocation.TantoBtnWidth;
            this.btn8.Width = ClsPublic.stcControllLocation.TantoBtnWidth;
            this.btn9.Width = ClsPublic.stcControllLocation.TantoBtnWidth;
            this.btn10.Width = ClsPublic.stcControllLocation.TantoBtnWidth;
            this.btn11.Width = ClsPublic.stcControllLocation.TantoBtnWidth;
            this.btn12.Width = ClsPublic.stcControllLocation.TantoBtnWidth;
            this.btn13.Width = ClsPublic.stcControllLocation.TantoBtnWidth;
            this.btn14.Width = ClsPublic.stcControllLocation.TantoBtnWidth;
            this.btn15.Width = ClsPublic.stcControllLocation.TantoBtnWidth;
            this.btn16.Width = ClsPublic.stcControllLocation.TantoBtnWidth;
            this.btn17.Width = ClsPublic.stcControllLocation.TantoBtnWidth;

            this.btn1.Left = ClsPublic.stcControllLocation.TantoBtnX;
            this.btn2.Left = this.btn1.Left + ClsPublic.stcControllLocation.TantoBtnWidth;
            this.btn3.Left = this.btn2.Left + ClsPublic.stcControllLocation.TantoBtnWidth;
            this.btn4.Left = this.btn3.Left + ClsPublic.stcControllLocation.TantoBtnWidth;
            this.btn5.Left = this.btn4.Left + ClsPublic.stcControllLocation.TantoBtnWidth;
            this.btn6.Left = this.btn5.Left + ClsPublic.stcControllLocation.TantoBtnWidth;
            this.btn7.Left = this.btn6.Left + ClsPublic.stcControllLocation.TantoBtnWidth;
            this.btn8.Left = this.btn7.Left + ClsPublic.stcControllLocation.TantoBtnWidth;
            this.btn9.Left = this.btn8.Left + ClsPublic.stcControllLocation.TantoBtnWidth;
            this.btn10.Left = this.btn9.Left + ClsPublic.stcControllLocation.TantoBtnWidth;
            this.btn11.Left = this.btn10.Left + ClsPublic.stcControllLocation.TantoBtnWidth;
            this.btn12.Left = this.btn11.Left + ClsPublic.stcControllLocation.TantoBtnWidth;
            this.btn13.Left = this.btn12.Left + ClsPublic.stcControllLocation.TantoBtnWidth;
            this.btn14.Left = this.btn13.Left + ClsPublic.stcControllLocation.TantoBtnWidth;
            this.btn15.Left = this.btn14.Left + ClsPublic.stcControllLocation.TantoBtnWidth;
            this.btn16.Left = this.btn15.Left + ClsPublic.stcControllLocation.TantoBtnWidth;
            this.btn17.Left = this.btn16.Left + ClsPublic.stcControllLocation.TantoBtnWidth;

            this.btn1.Top = ClsPublic.stcControllLocation.TantoBtnY;
            this.btn2.Top = ClsPublic.stcControllLocation.TantoBtnY;
            this.btn3.Top = ClsPublic.stcControllLocation.TantoBtnY;
            this.btn4.Top = ClsPublic.stcControllLocation.TantoBtnY;
            this.btn5.Top = ClsPublic.stcControllLocation.TantoBtnY;
            this.btn6.Top = ClsPublic.stcControllLocation.TantoBtnY;
            this.btn7.Top = ClsPublic.stcControllLocation.TantoBtnY;
            this.btn8.Top = ClsPublic.stcControllLocation.TantoBtnY;
            this.btn9.Top = ClsPublic.stcControllLocation.TantoBtnY;
            this.btn10.Top = ClsPublic.stcControllLocation.TantoBtnY;
            this.btn11.Top = ClsPublic.stcControllLocation.TantoBtnY;
            this.btn12.Top = ClsPublic.stcControllLocation.TantoBtnY;
            this.btn13.Top = ClsPublic.stcControllLocation.TantoBtnY;
            this.btn14.Top = ClsPublic.stcControllLocation.TantoBtnY;
            this.btn15.Top = ClsPublic.stcControllLocation.TantoBtnY;
            this.btn16.Top = ClsPublic.stcControllLocation.TantoBtnY;
            this.btn17.Top = ClsPublic.stcControllLocation.TantoBtnY;
        }

        /// <summary>
        /// 当月、翌月登録担当者数チェック
        /// </summary>
        /// <returns></returns>
        private bool CheckTantoCount()
        {
            bool bl = true;
            
            // 翌月有無判定
            if (ClsPublic.stcConfig[1].FilePath == "") { return false; }

            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    // 当月登録担当者取得
                    // =0は間違ってはいないが、clear()使用の方が今風
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("COUNT(DISTINCT tanto_id) AS CNT");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Trn_勤務表シフト情報");
                    sb.AppendLine("LEFT JOIN");
                    sb.AppendLine("Mst_社員");
                    sb.AppendLine("ON");
                    sb.AppendLine("Trn_勤務表シフト情報.tanto_id = Mst_社員.staff_id");
                    // このJOINの場合、INNER JOINと同じになる
                    // WHEREをANDに変える→LEFT JOINになる
                    // sb.AppendLine("WHERE");
                    sb.AppendLine("AND");
                    sb.AppendLine("Mst_社員.proxy_flag = " + ClsPublic.FLAG_ON);
                    sb.AppendLine("AND");
                    // 2026/01/08 UPD (S)
                    // sb.AppendLine("Mst_社員.zai_flag = " + ClsPublic.FLAG_ON);
                    sb.AppendLine("Mst_社員.delete_flag != " + ClsPublic.FLAG_ON);
                    // 2026/01/08 UPD (E)
                    sb.AppendLine("AND");
                    sb.AppendLine("year = " + ClsPublic.stcConfig[0].Year);
                    sb.AppendLine("AND");
                    sb.AppendLine("month = " + ClsPublic.stcConfig[0].Month);

                    // 当月登録の担当者数取得
                    // 2025/09/02 処理改善の為、変更
                    var rec_count = 0;
                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        if (dt_val.Rows.Count > 0)
                        {
                            rec_count = Convert.ToInt32(dt_val.Rows[0]["CNT"]);
                        }
                    }

                    // 翌月登録担当者取得
                    // =0は間違ってはいないが、clear()使用の方が今風
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("COUNT(DISTINCT tanto_id) AS CNT");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Trn_勤務表シフト情報");
                    sb.AppendLine("LEFT JOIN");
                    sb.AppendLine("Mst_社員");
                    sb.AppendLine("ON");
                    sb.AppendLine("Trn_勤務表シフト情報.tanto_id = Mst_社員.staff_id");
                    // このJOINの場合、INNER JOINと同じになる
                    // WHEREをANDに変える→LEFT JOINになる
                    // sb.AppendLine("WHERE");
                    sb.AppendLine("AND");
                    sb.AppendLine("Mst_社員.proxy_flag = " + ClsPublic.FLAG_ON);
                    sb.AppendLine("AND");
                    // 2026/01/08 UPD (S)
                    // sb.AppendLine("Mst_社員.zai_flag = " + ClsPublic.FLAG_ON);
                    sb.AppendLine("Mst_社員.delete_flag != " + ClsPublic.FLAG_ON);
                    // 2026/01/08 UPD (E)
                    sb.AppendLine("AND");
                    sb.AppendLine("Year = " + ClsPublic.stcConfig[1].Year);
                    sb.AppendLine("AND");
                    sb.AppendLine("Month = " + ClsPublic.stcConfig[1].Month);

                    // 当月登録の担当者数取得
                    // 2025/09/02 処理改善の為、変更
                    using (DataTable dt_val2 = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        if (dt_val2.Rows.Count > 0)
                        {
                            if (rec_count != Convert.ToInt32(dt_val2.Rows[0]["CNT"]))
                            {
                                bl = false;
                            }
                        }
                    }
                }
                return bl;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// DataGridView初期設定
        /// </summary>
        private void InitializeDgvList()
        {
            // ----------------------------------------------------------------
            // 連絡ボタンイメージクリア
            // ----------------------------------------------------------------
            btn1.Image = null;
            btn2.Image = null;
            btn3.Image = null;
            btn4.Image = null;
            btn5.Image = null;
            btn6.Image = null;
            btn7.Image = null;
            btn8.Image = null;
            btn9.Image = null;
            btn10.Image = null;
            btn11.Image = null;
            btn12.Image = null;
            btn13.Image = null;
            btn14.Image = null;
            btn15.Image = null;
            btn16.Image = null;
            btn17.Image = null;

            // ----------------------------------------------------------------
            // Column名
            // ----------------------------------------------------------------
            col1.Name = "1";
            col2.Name = "2";
            col3.Name = "3";
            col4.Name = "4";
            col5.Name = "5";
            col6.Name = "6";
            col7.Name = "7";
            col8.Name = "8";
            col9.Name = "9";
            col10.Name = "10";
            col11.Name = "11";
            col12.Name = "12";
            col13.Name = "13";
            col14.Name = "14";
            col15.Name = "15";
            col16.Name = "16";
            col17.Name = "17";
            col18.Name = "18";
            col19.Name = "19";
            col20.Name = "20";
            col21.Name = "21";
            col22.Name = "22";
            col23.Name = "23";
            col24.Name = "24";
            col25.Name = "25";
            col26.Name = "26";

            // ----------------------------------------------------------------
            // Columnサイズ
            // ----------------------------------------------------------------
            col1.Width = ClsPublic.stcControllLocation.PreShiftGridCellWidth;
            // col2.Width = ClsPublic.stcControllLocation.PreShiftGridCellWidth;
            col2.Width = ClsPublic.stcControllLocation.PreShiftGridCellWidth - 15;          // 2025/02/06
            col3.Width = ClsPublic.stcControllLocation.PreShiftGridCellWidth;
            col4.Width = ClsPublic.stcControllLocation.PreShiftGridCellWidth;
            col5.Width = ClsPublic.stcControllLocation.PreShiftGridCellWidth;
            col6.Width = ClsPublic.stcControllLocation.PreShiftGridCellWidth;
            col7.Width = ClsPublic.stcControllLocation.PreShiftGridCellWidth;
            col8.Width = ClsPublic.stcControllLocation.PreShiftGridCellWidth;
            col9.Width = ClsPublic.stcControllLocation.PreShiftGridCellWidth;
            col10.Width = ClsPublic.stcControllLocation.PreShiftGridCellWidth;
            col11.Width = ClsPublic.stcControllLocation.PreShiftGridCellWidth;
            col12.Width = ClsPublic.stcControllLocation.PreShiftGridCellWidth;
            col13.Width = ClsPublic.stcControllLocation.PreShiftGridCellWidth;
            col14.Width = ClsPublic.stcControllLocation.PreShiftGridCellWidth;
            col15.Width = ClsPublic.stcControllLocation.PreShiftGridCellWidth;
            col16.Width = ClsPublic.stcControllLocation.PreShiftGridCellWidth;
            col17.Width = ClsPublic.stcControllLocation.PreShiftGridCellWidth;
            col18.Width = ClsPublic.stcControllLocation.PreShiftGridCellWidth;
            col19.Width = ClsPublic.stcControllLocation.PreShiftGridCellWidth;
            col20.Width = ClsPublic.stcControllLocation.PreShiftGridCellWidth;
            col21.Width = ClsPublic.stcControllLocation.PreShiftGridCellWidth;
            col22.Width = ClsPublic.stcControllLocation.PreShiftGridCellWidth;
            col23.Width = ClsPublic.stcControllLocation.PreShiftGridCellWidth;
            col24.Width = ClsPublic.stcControllLocation.PreShiftGridCellWidth;
            col25.Width = ClsPublic.stcControllLocation.PreShiftGridCellWidth;
            col26.Width = ClsPublic.stcControllLocation.PreShiftGridCellWidth;

            // ----------------------------------------------------------------
            // Columnヘッダー文字
            // ----------------------------------------------------------------
            col1.HeaderText = "";
            col2.HeaderText = "";
            col3.HeaderText = "";
            col4.HeaderText = "";
            col5.HeaderText = "";
            col6.HeaderText = "";
            col7.HeaderText = "";
            col8.HeaderText = "";
            col9.HeaderText = "";
            col10.HeaderText = "";
            col11.HeaderText = "";
            col12.HeaderText = "";
            col13.HeaderText = "";
            col14.HeaderText = "";
            col15.HeaderText = "";
            col16.HeaderText = "";
            col17.HeaderText = "";
            col18.HeaderText = "";
            col19.HeaderText = "";
            col20.HeaderText = "";
            col21.HeaderText = "";
            col22.HeaderText = "";
            col23.HeaderText = "";
            col24.HeaderText = "";
            col25.HeaderText = "";
            col26.HeaderText = "";

            // ----------------------------------------------------------------
            // Column表示/非表示
            // ----------------------------------------------------------------
            col1.Visible = false;
            col2.Visible = true;
            col3.Visible = false;
            col4.Visible = false;
            col5.Visible = false;
            col6.Visible = false;
            col7.Visible = false;
            col8.Visible = false;
            col9.Visible = false;
            col10.Visible = false;
            col11.Visible = false;
            col12.Visible = false;
            col13.Visible = false;
            col14.Visible = false;
            col15.Visible = false;
            col16.Visible = false;
            col17.Visible = false;
            col18.Visible = false;
            col19.Visible = false;
            col20.Visible = false;
            col21.Visible = false;
            col22.Visible = false;
            col23.Visible = false;
            col24.Visible = false;
            col25.Visible = false;
            col26.Visible = false;

            // ----------------------------------------------------------------
            // Column表示/非表示
            // ----------------------------------------------------------------
            this.dgvList.Columns.Add(col1);
            this.dgvList.Columns.Add(col2);
            this.dgvList.Columns.Add(col3);
            this.dgvList.Columns.Add(col4);
            this.dgvList.Columns.Add(col5);
            this.dgvList.Columns.Add(col6);
            this.dgvList.Columns.Add(col7);
            this.dgvList.Columns.Add(col8);
            this.dgvList.Columns.Add(col9);
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
            this.dgvList.Columns.Add(col20);
            this.dgvList.Columns.Add(col21);
            this.dgvList.Columns.Add(col22);
            this.dgvList.Columns.Add(col23);
            this.dgvList.Columns.Add(col24);
            this.dgvList.Columns.Add(col25);
            this.dgvList.Columns.Add(col26);

            // ----------------------------------------------------------------
            // DataGridView各プロパティ設定
            // ----------------------------------------------------------------
            //並び替えができないようにする
            foreach (DataGridViewColumn c in this.dgvList.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            this.dgvList.EnableHeadersVisualStyles = false;                                                             // Windows Color無効
            this.dgvList.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.LightSeaGreen;                  // 列ヘッダ色
            this.dgvList.RowTemplate.Height = ClsPublic.stcControllLocation.PreShiftGridCellHeight;                     // 行高さ
            this.dgvList.AllowUserToResizeColumns = false;                                                              // 列幅の変更不可
            // this.dgvList.AllowUserToResizeRows = false;                                                       // 行高さの変更不可

            this.dgvList.Columns["1"].DefaultCellStyle.Font = new System.Drawing.Font(ClsPublic.LIST_FONT_TYPE_GOS, 10);    //フォント設定
            this.dgvList.Columns["1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;           //セルの文字表示位置

            this.dgvList.MultiSelect = false;                                                                           //複数選択
            this.dgvList.ReadOnly = true;                                                                               //読込専用
            this.dgvList.AllowUserToAddRows = false;                                                                    //行追加無効

            // 左端上の文字
            this.dgvList.TopLeftHeaderCell.Value = "日付";

            // 列ヘッダー
            this.dgvList.ColumnHeadersHeight = ClsPublic.stcControllLocation.PreColumnHeadHeight;                       // 列見出し高さ ＭＳ Ｐゴシック
            this.dgvList.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(ClsPublic.LIST_FONT_TYPE_GOS, 18, FontStyle.Bold);

            // 行ヘッダー
            this.dgvList.RowHeadersWidth = ClsPublic.stcControllLocation.PreRowHeadWidth;                               // 行見出し幅
            this.dgvList.RowHeadersDefaultCellStyle.Font = new System.Drawing.Font(ClsPublic.LIST_FONT_TYPE_GOS, 14, FontStyle.Bold);

            col1.HeaderCell.Style.BackColor = Color.Silver;
            col2.HeaderCell.Style.BackColor = Color.Silver;
            col3.HeaderCell.Style.BackColor = Color.Silver;
        }

        /// <summary>
        /// 勤務予定リスト表示
        /// </summary>
        /// <param name="p_kbn">0:当月 1:当月、翌月</param>
        private void DisplayShiftList(int p_kbn = 0)
        {
            string SQL;
            string s_cell;

            // ----------------------------------------------------------------
            // 担当者IDラベル 表示されている担当者のIDを保持する
            // ----------------------------------------------------------------
            this.lblID1.Text = "";
            this.lblID2.Text = "";
            this.lblID3.Text = "";
            this.lblID4.Text = "";
            this.lblID5.Text = "";
            this.lblID6.Text = "";
            this.lblID7.Text = "";
            this.lblID8.Text = "";
            this.lblID9.Text = "";
            this.lblID10.Text = "";
            this.lblID11.Text = "";
            this.lblID12.Text = "";
            this.lblID13.Text = "";
            this.lblID14.Text = "";
            this.lblID15.Text = "";
            this.lblID16.Text = "";
            this.lblID17.Text = "";

            // ----------------------------------------------------------------
            // システム環境値解放（再読込の為）
            // ----------------------------------------------------------------
            ClsPublic.stcConfig[0] = null;
            ClsPublic.stcConfig[1] = null;
            ClsPublic.stcConfig[0] = new ClsConfig(1);
            ClsPublic.stcConfig[1] = new ClsConfig(2);

            // ----------------------------------------------------------------
            // データ取得SQL（当月）
            // ----------------------------------------------------------------
            SQL = EditSQL(ClsPublic.stcConfig[0].Year, ClsPublic.stcConfig[0].Month);

            // ----------------------------------------------------------------
            // 勤務予定表示（当月）
            // ----------------------------------------------------------------
            int irow = -1;
            // irow = displayShiftDataGridView(irow, p_kbn, SQL);
            irow = DisplayShiftDataGridView(irow, 0, SQL);

            // 翌月有無判定
            if (p_kbn == 1)
            {
                // ----------------------------------------------------------------
                // データ取得SQL（翌月）
                // ----------------------------------------------------------------
                SQL = EditSQL(ClsPublic.stcConfig[1].Year, ClsPublic.stcConfig[1].Month);

                // ----------------------------------------------------------------
                // 勤務予定表示（翌月）　当月で追加したRow Countを引き渡す
                // ----------------------------------------------------------------
                irow = DisplayShiftDataGridView(irow, p_kbn, SQL);
            }

            // ----------------------------------------------------------------
            //当日を画面最初に表示（自動スクロール）
            // ----------------------------------------------------------------
            for (irow = 0; irow < this.dgvList.Rows.Count; irow++)
            {
                s_cell = DateTime.Parse(this.dgvList.Rows[irow].Cells[0].Value.ToString()).ToString("MM/dd");
                if (s_cell.ToString().Length < 5) { continue; }
                s_cell = s_cell.Substring(0, 5);
                // 当日日付(mm/dd)と同じ場合、そのRowIndexを使用
                if (DateTime.Now.ToString("MM/dd").ToString() == s_cell) { break; }
            }
            if (irow >= this.dgvList.Rows.Count) { this.dgvList.FirstDisplayedScrollingRowIndex = 0; }
            else { this.dgvList.FirstDisplayedScrollingRowIndex = irow; }

        }

        /// <summary>
        /// シフト情報取得用SQL編集
        /// </summary>
        /// <param name="p_year">対象年</param>
        /// <param name="p_month">対象月</param>
        /// <returns></returns>
        private string EditSQL(int p_year, int p_month)
        {
            sb.Clear();
            sb.AppendLine("SELECT");
            sb.AppendLine("Trn_勤務表シフト情報.import_date");
            sb.AppendLine(",Trn_勤務表シフト情報.tanto_id");
            sb.AppendLine(",Trn_勤務表シフト情報.tanto_name");
            sb.AppendLine(",Trn_勤務表シフト情報.day");
            sb.AppendLine(",Trn_勤務表シフト情報.start_date");
            sb.AppendLine(",Trn_勤務表シフト情報.end_date");
            sb.AppendLine(",Trn_勤務表シフト情報.file_name");
            sb.AppendLine(",Trn_勤務表シフト情報.file_path");
            sb.AppendLine(",Trn_勤務表シフト情報.sheet_name");
            sb.AppendLine(",Trn_勤務表シフト情報.year");
            sb.AppendLine(",Trn_勤務表シフト情報.month");
            sb.AppendLine(",Trn_勤務表シフト情報.row");
            sb.AppendLine(",Trn_勤務表シフト情報.col");
            sb.AppendLine(",Trn_勤務表シフト情報.back_color");
            sb.AppendLine(",Trn_勤務表シフト情報.font_size");
            sb.AppendLine(",Trn_勤務表シフト情報.font_color");
            sb.AppendLine(",Trn_勤務表シフト情報.font_bold");
            sb.AppendLine(",Trn_勤務表シフト情報.value");
            sb.AppendLine(",Trn_勤務表シフト情報.comment");
            sb.AppendLine(",Trn_勤務表シフト情報.cell_type");
            sb.AppendLine(",Trn_勤務表シフト情報.week_type");
            sb.AppendLine(",Trn_勤務表シフト情報.contact_flag");
            sb.AppendLine(",Mst_社員.proxy_flag");
            sb.AppendLine(",Trn_連絡.tanto_id AS EXI");
            sb.AppendLine("FROM");
            sb.AppendLine("Trn_勤務表シフト情報");
            sb.AppendLine("LEFT JOIN");
            sb.AppendLine("Mst_社員");
            sb.AppendLine("ON");
            sb.AppendLine("Trn_勤務表シフト情報.tanto_id = Mst_社員.staff_id");
            sb.AppendLine("LEFT JOIN");
            sb.AppendLine("Trn_連絡");
            sb.AppendLine("ON");
            sb.AppendLine("Trn_勤務表シフト情報.tanto_id = Trn_連絡.tanto_id");
            sb.AppendLine("AND");
            sb.AppendLine("Trn_勤務表シフト情報.day = Trn_連絡.day");
            sb.AppendLine("WHERE");
            sb.AppendLine("Trn_勤務表シフト情報.year = " + p_year.ToString());
            sb.AppendLine("AND");
            sb.AppendLine("Trn_勤務表シフト情報.month = " + p_month.ToString());
            sb.AppendLine("AND");
            sb.AppendLine("(Mst_社員.proxy_flag = 1 Or Trn_勤務表シフト情報.tanto_id = 0)");
            sb.AppendLine("AND");
            // 2026/01/08 UPD (S)
            // sb.AppendLine("Mst_社員.zai_flag = " + ClsPublic.FLAG_ON);
            sb.AppendLine("Mst_社員.delete_flag != " + ClsPublic.FLAG_ON);
            // 2026/01/08 UPD (E)
            sb.AppendLine("OR");
            sb.AppendLine("(");
            sb.AppendLine("Trn_勤務表シフト情報.tanto_id = 0");
            sb.AppendLine("AND");
            sb.AppendLine("Trn_勤務表シフト情報.year = " + p_year.ToString());
            sb.AppendLine("AND");
            sb.AppendLine("Trn_勤務表シフト情報.month = " + p_month.ToString());
            sb.AppendLine(")");
            sb.AppendLine("ORDER BY");
            sb.AppendLine("Trn_勤務表シフト情報.year");
            sb.AppendLine(",Trn_勤務表シフト情報.month");
            sb.AppendLine(",Trn_勤務表シフト情報.row");
            sb.AppendLine(",Trn_勤務表シフト情報.col");

            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_row">Start Row No</param>
        /// <param name="p_kbn">0:当月/1:翌月</param>
        /// <param name="p_sql">SQL</param>
        /// <returns>Row No</returns>
        private int DisplayShiftDataGridView(int p_row, int p_kbn, string p_sql)
        {
            //int intSaveRow;
            int i_save_row;

            //int intCellRow;
            int i_cell_row;

            //int intCellCol;
            int i_cell_col;

            //int intRow;
            int i_row;

            //int intCol;
            int i_col;

            Color header_color = Color.White;

            try
            {
                i_save_row = p_row;
                i_row = i_save_row;
                i_col = -1;
                i_cell_row = 0;

                // 当月の場合はRowクリア
                if (p_kbn == 0)
                {
                    // DataGridView Rowクリア
                    this.dgvList.Rows.Clear();
                }

                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    // ----------------------------------------------------------------
                    // データ取得
                    // ----------------------------------------------------------------
                    // 処理の改善 2025/09/02
                    //cDb.Sql = p_sql;
                    //cDb.DMLSelect();
                    //dt = new DataTable();
                    //dt = cDb.dt;
                    using(DataTable dt_val = clsSqlDb.DMLSelect(p_sql))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            // セル値クリア
                            // s_cell = "";

                            // 列番号
                            i_cell_col = int.Parse(dr["col"].ToString());

                            // ----------------------------------------------------------------
                            //行番号比較:異なる場合は行追加
                            // ----------------------------------------------------------------
                            if (i_cell_row != int.Parse(dr["row"].ToString()))
                            {
                                this.dgvList.Rows.Add();                            // Row追加
                                i_cell_row = int.Parse(dr["row"].ToString());       // Importしたｴｸｾﾙの行番号
                                i_row++;                                            // DataGridViewの行番号

                                // ----------------------------------------------------------------
                                // 行ヘッダ設定（日付＋曜日）
                                // ----------------------------------------------------------------
                                // 日付編集 ([Day] -> MM/dd 改行 (Week)
                                sb.Clear();
                                sb.AppendLine(DateTime.Parse(dr["day"].ToString()).ToString("MM/dd"));
                                sb.AppendLine("  (" + DateTime.Parse(dr["day"].ToString()).ToString("ddd") + ")");

                                // 行ヘッダに日付を表示
                                this.dgvList.Rows[i_row].HeaderCell.Value = sb.ToString();

                                // 行のバックカラー設定
                                if (dr["back_color"].ToString() == "SaturDayColor") { this.dgvList.Rows[i_row].DefaultCellStyle.BackColor = System.Drawing.Color.LightSteelBlue; }
                                else if (dr["back_color"].ToString() == "SunDayColor") { this.dgvList.Rows[i_row].DefaultCellStyle.BackColor = System.Drawing.Color.Pink; }
                                else if (dr["back_color"].ToString() == "HoliDayColor") { this.dgvList.Rows[i_row].DefaultCellStyle.BackColor = System.Drawing.Color.LightPink; }
                            }

                            // ----------------------------------------------------------------
                            // 列ヘッダ設定（担当者名）
                            // ----------------------------------------------------------------
                            if (p_kbn == 0)
                            {
                                // 当月の場合、ｴｸｾﾙの担当者が記載されている行か判定
                                if (i_cell_row == 4)
                                {
                                    // ----------------------------------------------------------------
                                    // 担当者が記載されている行の場合、各担当者のバックカラー設定
                                    // ----------------------------------------------------------------
                                    header_color = GetColHeaderColor(dr["tanto_name"].ToString());

                                    // ----------------------------------------------------------------
                                    // 担当者が記載されている行の場合、各担当者のバックカラー設定
                                    // ----------------------------------------------------------------
                                    SetHeaderTextColor(i_cell_col, dr["tanto_name"].ToString(), header_color);
                                }
                            }

                            // ----------------------------------------------------------------
                            // 予定情報表示
                            // ----------------------------------------------------------------
                            // 日付（最初の列に日付をセット）
                            // strCell = .dr("Day").ToString;
                            this.dgvList.Rows[i_row].Cells[0].Value = dr["day"].ToString();

                            // DataGridViewの列番号にｴｸｾﾙの列番号-1をセット
                            i_col = i_cell_col - 1;

                            // 予定内容を表示
                            this.dgvList.Rows[i_row].Cells[i_col].Value = dr["value"].ToString();

                            // ----------------------------------------------------------------
                            // 担当者IDを保持
                            // ----------------------------------------------------------------
                            switch (i_col)
                            {
                                case 4:
                                    lblID1.Text = dr["tanto_id"].ToString();
                                    break;
                                case 5:
                                    lblID2.Text = dr["tanto_id"].ToString();
                                    break;
                                case 6:
                                    lblID3.Text = dr["tanto_id"].ToString();
                                    break;
                                case 7:
                                    lblID4.Text = dr["tanto_id"].ToString();
                                    break;
                                case 8:
                                    lblID5.Text = dr["tanto_id"].ToString();
                                    break;
                                case 9:
                                    lblID6.Text = dr["tanto_id"].ToString();
                                    break;
                                case 10:
                                    lblID7.Text = dr["tanto_id"].ToString();
                                    break;
                                case 11:
                                    lblID8.Text = dr["tanto_id"].ToString();
                                    break;
                                case 12:
                                    lblID9.Text = dr["tanto_id"].ToString();
                                    break;
                                case 13:
                                    lblID10.Text = dr["tanto_id"].ToString();
                                    break;
                                case 14:
                                    lblID11.Text = dr["tanto_id"].ToString();
                                    break;
                                case 15:
                                    lblID12.Text = dr["tanto_id"].ToString();
                                    break;
                                case 16:
                                    lblID13.Text = dr["tanto_id"].ToString();
                                    break;
                                case 17:
                                    lblID14.Text = dr["tanto_id"].ToString();
                                    break;
                                case 18:
                                    lblID15.Text = dr["tanto_id"].ToString();
                                    break;
                                case 19:
                                    lblID16.Text = dr["tanto_id"].ToString();
                                    break;
                                case 20:
                                    lblID17.Text = dr["tanto_id"].ToString();
                                    break;
                            }

                            // 文字数によりフォントサイズを設定
                            if (dr["value"].ToString().Length <= 3) { this.dgvList[i_col, i_row].Style.Font = new System.Drawing.Font(ClsPublic.LIST_FONT_TYPE_GOS, 20, FontStyle.Bold); }
                            else if (dr["value"].ToString().Length <= 5) { this.dgvList[i_col, i_row].Style.Font = new System.Drawing.Font(ClsPublic.LIST_FONT_TYPE_GOS, 17, FontStyle.Bold); }
                            else if (dr["value"].ToString().Length <= 7) { this.dgvList[i_col, i_row].Style.Font = new System.Drawing.Font(ClsPublic.LIST_FONT_TYPE_GOS, 16, FontStyle.Bold); }
                            else if (dr["value"].ToString().Length <= 10) { this.dgvList[i_col, i_row].Style.Font = new System.Drawing.Font(ClsPublic.LIST_FONT_TYPE_GOS, 14, FontStyle.Bold); }
                            else { this.dgvList[i_col, i_row].Style.Font = new System.Drawing.Font(ClsPublic.LIST_FONT_TYPE_GOS, 12, FontStyle.Bold); }

                            // ----------------------------------------------------------------
                            // フォントカラー設定
                            // ----------------------------------------------------------------
                            switch (dr["font_color"].ToString())
                            {
                                case "Black":
                                    break;
                                case "Red":
                                    this.dgvList[i_col, i_row].Style.ForeColor = System.Drawing.Color.Red;
                                    break;
                                case "Blue":
                                    this.dgvList[i_col, i_row].Style.ForeColor = System.Drawing.Color.Blue;
                                    break;
                                default:
                                    break;
                            }

                            // ----------------------------------------------------------------
                            // 備考
                            // ----------------------------------------------------------------
                            if (dr["comment"].ToString().Length != 0)
                            {
                                this.dgvList[i_col, i_row].Style.BackColor = System.Drawing.Color.PowderBlue;
                            }

                            // ----------------------------------------------------------------
                            // セル背景色
                            // ----------------------------------------------------------------
                            switch (dr["back_color"].ToString())
                            {
                                case "":
                                    break;
                                case "Yellow":
                                    this.dgvList[i_col, i_row].Style.BackColor = System.Drawing.Color.Yellow;
                                    break;
                                case "Orange":
                                    this.dgvList[i_col, i_row].Style.BackColor = System.Drawing.Color.Orange;
                                    break;
                                default:
                                    break;
                            }

                            // ----------------------------------------------------------------
                            // 連絡済のバックカラー変更
                            // ----------------------------------------------------------------
                            if (dr["EXI"].ToString() != "") { this.dgvList[i_col, i_row].Style.BackColor = System.Drawing.Color.PaleGreen; }
                        }
                    }

                    // ----------------------------------------------------------------
                    // 承認待ちバックカラー設定
                    // ----------------------------------------------------------------
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" row");
                    sb.AppendLine(",col");
                    sb.AppendLine("FROM");
                    sb.AppendLine(" Trn_勤務表シフト変更");
                    sb.AppendLine("WHERE");
                    sb.AppendLine(" delete_flag = " + ClsPublic.FLAG_OFF);
                    sb.AppendLine("AND");
                    sb.AppendLine("confirm_flag = " + ClsPublic.FLAG_OFF);

                    if (p_kbn == 0)
                    {
                        // 当月が対象
                        sb.AppendLine("AND");
                        sb.AppendLine("year = " + ClsPublic.stcConfig[0].Year);
                        sb.AppendLine("AND");
                        sb.AppendLine("month = " + ClsPublic.stcConfig[0].Month);
                    }
                    else
                    {
                        // 翌月が対象
                        sb.AppendLine("AND");
                        sb.AppendLine("year = " + ClsPublic.stcConfig[1].Year);
                        sb.AppendLine("AND");
                        sb.AppendLine("month = " + ClsPublic.stcConfig[1].Month);
                    }

                    // 処理の改善 2025/09/02
                    using (DataTable dt_val2 = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val2.Rows)
                        {
                            if (p_kbn == 0)
                            {
                                this.dgvList[int.Parse(dr["col"].ToString()) - 1, int.Parse(dr["row"].ToString()) - 4].Style.BackColor = System.Drawing.Color.LightCoral;
                            }
                            else
                            {
                                this.dgvList[int.Parse(dr["col"].ToString()) - 1, int.Parse(dr["row"].ToString()) + i_save_row - 3].Style.BackColor = System.Drawing.Color.LightCoral;
                            }
                        }
                    }
                }

                return i_row;               // 追加した行数(row count)を戻す
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// DataGridViewヘッダーカラー取得
        /// </summary>
        /// <param name="p_tnato_name">担当者名</param>
        /// <returns></returns>
        private Color GetColHeaderColor(string p_tnato_name)
        {
            Color colorResult = new Color();
            
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" office_id");
                    sb.AppendLine(",group_id");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_社員");
                    sb.AppendLine("WHERE");
                    // 2026/01/08 UPD (S)
                    // sb.AppendLine("zai_flag = " + ClsPublic.FLAG_ON);
                    sb.AppendLine("delete_flag != " + ClsPublic.FLAG_ON);
                    // 2026/01/08 UPD (E)
                    sb.AppendLine("AND");
                    sb.AppendLine("proxy_flag = " + ClsPublic.FLAG_ON);
                    sb.AppendLine("AND");
                    sb.AppendLine("name1 = '" + p_tnato_name + "'");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            // 所属部署
                            switch (int.Parse(dr["group_id"].ToString()))
                            {
                                case 1:
                                    // 営業
                                    // 所属先
                                    switch (int.Parse(dr["office_id"].ToString()))
                                    {
                                        case ClsPublic.OFFICE_HONSHA:
                                            // 本社
                                            colorResult = System.Drawing.Color.CornflowerBlue;
                                            break;
                                        case ClsPublic.OFFICE_SAITAMA:
                                            // さいたま
                                            colorResult = System.Drawing.Color.LightSalmon;
                                            break;
                                        case ClsPublic.OFFICE_YOKOHAMA:
                                            // 横浜
                                            colorResult = System.Drawing.Color.CornflowerBlue;
                                            break;
                                    }
                                    break;
                                case 2:
                                    // 総務
                                    // 所属先
                                    switch (int.Parse(dr["office_id"].ToString()))
                                    {
                                        case ClsPublic.OFFICE_HONSHA:
                                            // 本社
                                            colorResult = System.Drawing.Color.MediumPurple;
                                            break;
                                        case ClsPublic.OFFICE_SAITAMA:
                                            // さいたま
                                            colorResult = System.Drawing.Color.LightSalmon;
                                            break;
                                        case ClsPublic.OFFICE_YOKOHAMA:
                                            // 横浜
                                            colorResult = System.Drawing.Color.CornflowerBlue;
                                            break;
                                    }
                                    break;
                                case 3:
                                    // 代務
                                    // 所属先
                                    // 代務の場合は所属先に関わらず同じ色（暫定処理）
                                    switch (int.Parse(dr["office_id"].ToString()))
                                    {
                                        case ClsPublic.OFFICE_HONSHA:
                                            // 本社
                                            colorResult = System.Drawing.Color.Wheat;
                                            break;
                                        case ClsPublic.OFFICE_SAITAMA:
                                            // さいたま
                                            colorResult = System.Drawing.Color.Wheat;
                                            break;
                                        case ClsPublic.OFFICE_YOKOHAMA:
                                            // 横浜
                                            colorResult = System.Drawing.Color.Wheat;
                                            break;
                                    }
                                    break;
                            }
                        }
                    }
                    return colorResult;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// DataGridViewヘッダーテキスト、カラー設定
        /// </summary>
        /// <param name="p_text"></param>
        /// <param name="p_color"></param>
        private void SetHeaderTextColor(int p_cellcol, string p_text, Color p_color)
        {
            switch (p_cellcol)
            {
                case 1:
                    break;
                case 2:
                    // 備考
                    col2.HeaderText = "";
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    // 担当者1
                    col5.Visible = true;
                    col5.HeaderText = p_text;
                    col5.HeaderCell.Style.BackColor = p_color;
                    break;
                case 6:
                    // 担当者2
                    col6.Visible = true;
                    col6.HeaderText = p_text;
                    col6.HeaderCell.Style.BackColor = p_color;
                    break;
                case 7:
                    // 担当者3
                    col7.Visible = true;
                    col7.HeaderText = p_text;
                    col7.HeaderCell.Style.BackColor = p_color;
                    break;
                case 8:
                    // 担当者4
                    col8.Visible = true;
                    col8.HeaderText = p_text;
                    col8.HeaderCell.Style.BackColor = p_color;
                    break;
                case 9:
                    // 担当者5
                    col9.Visible = true;
                    col9.HeaderText = p_text;
                    col9.HeaderCell.Style.BackColor = p_color;
                    break;
                case 10:
                    // 担当者6
                    col10.Visible = true;
                    col10.HeaderText = p_text;
                    col10.HeaderCell.Style.BackColor = p_color;
                    break;
                case 11:
                    // 担当者7
                    col11.Visible = true;
                    col11.HeaderText = p_text;
                    col11.HeaderCell.Style.BackColor = p_color;
                    break;
                case 12:
                    // 担当者8
                    col12.Visible = true;
                    col12.HeaderText = p_text;
                    col12.HeaderCell.Style.BackColor = p_color;
                    break;
                case 13:
                    // 担当者9
                    col13.Visible = true;
                    col13.HeaderText = p_text;
                    col13.HeaderCell.Style.BackColor = p_color;
                    break;
                case 14:
                    // 担当者10
                    col14.Visible = true;
                    col14.HeaderText = p_text;
                    col14.HeaderCell.Style.BackColor = p_color;
                    break;
                case 15:
                    // 担当者11
                    col15.Visible = true;
                    col15.HeaderText = p_text;
                    col15.HeaderCell.Style.BackColor = p_color;
                    break;
                case 16:
                    // 担当者12
                    col16.Visible = true;
                    col16.HeaderText = p_text;
                    col16.HeaderCell.Style.BackColor = p_color;
                    break;
                case 17:
                    // 担当者13
                    col17.Visible = true;
                    col17.HeaderText = p_text;
                    col17.HeaderCell.Style.BackColor = p_color;
                    break;
                case 18:
                    // 担当者14
                    col18.Visible = true;
                    col18.HeaderText = p_text;
                    col18.HeaderCell.Style.BackColor = p_color;
                    break;
                case 19:
                    // 担当者15
                    col19.Visible = true;
                    col19.HeaderText = p_text;
                    col19.HeaderCell.Style.BackColor = p_color;
                    break;
                case 20:
                    // 担当者16
                    col20.Visible = true;
                    col20.HeaderText = p_text;
                    col20.HeaderCell.Style.BackColor = p_color;
                    break;
                case 21:
                    // 担当者17
                    col21.Visible = true;
                    col21.HeaderText = p_text;
                    col21.HeaderCell.Style.BackColor = p_color;
                    break;
                case 22:
                    // 担当者18
                    col22.Visible = true;
                    col22.HeaderText = p_text;
                    col22.HeaderCell.Style.BackColor = p_color;
                    break;
                case 23:
                    // 担当者19
                    col23.Visible = true;
                    col23.HeaderText = p_text;
                    col23.HeaderCell.Style.BackColor = p_color;
                    break;
                case 24:
                    // 担当者20
                    col24.Visible = true;
                    col24.HeaderText = p_text;
                    col24.HeaderCell.Style.BackColor = p_color;
                    break;
                case 25:
                    // 担当者21
                    col25.Visible = true;
                    col25.HeaderText = p_text;
                    col25.HeaderCell.Style.BackColor = p_color;
                    break;
                case 26:
                    // 担当者21
                    col26.Visible = true;
                    col26.HeaderText = p_text;
                    col26.HeaderCell.Style.BackColor = p_color;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 連絡済みパネル
        /// </summary>
        private void ShiftContact()
        {
            DateTime today = DateTime.Now;
            
            try
            {
                // ----------------------------------------------------------------
                // ボタンバックカラー初期化
                // ----------------------------------------------------------------
                this.btn1.BackColor = SystemColors.ActiveCaption;
                this.btn2.BackColor = SystemColors.ActiveCaption;
                this.btn3.BackColor = SystemColors.ActiveCaption;
                this.btn4.BackColor = SystemColors.ActiveCaption;
                this.btn5.BackColor = SystemColors.ActiveCaption;
                this.btn6.BackColor = SystemColors.ActiveCaption;
                this.btn7.BackColor = SystemColors.ActiveCaption;
                this.btn8.BackColor = SystemColors.ActiveCaption;
                this.btn9.BackColor = SystemColors.ActiveCaption;
                this.btn10.BackColor = SystemColors.ActiveCaption;
                this.btn11.BackColor = SystemColors.ActiveCaption;
                this.btn12.BackColor = SystemColors.ActiveCaption;
                this.btn13.BackColor = SystemColors.ActiveCaption;
                this.btn14.BackColor = SystemColors.ActiveCaption;
                this.btn15.BackColor = SystemColors.ActiveCaption;
                this.btn16.BackColor = SystemColors.ActiveCaption;
                this.btn17.BackColor = SystemColors.ActiveCaption;

                // ----------------------------------------------------------------
                // ラベルテキスト初期化
                // ----------------------------------------------------------------
                this.btn1.Text = "";
                this.btn2.Text = "";
                this.btn3.Text = "";
                this.btn4.Text = "";
                this.btn5.Text = "";
                this.btn6.Text = "";
                this.btn7.Text = "";
                this.btn8.Text = "";
                this.btn9.Text = "";
                this.btn10.Text = "";
                this.btn11.Text = "";
                this.btn12.Text = "";
                this.btn13.Text = "";
                this.btn14.Text = "";
                this.btn15.Text = "";
                this.btn16.Text = "";
                this.btn17.Text = "";

                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("Trn_勤務表シフト情報.tanto_name");
                    sb.AppendLine(",Trn_連絡.tanto_id");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Trn_勤務表シフト情報");
                    sb.AppendLine("LEFT JOIN");
                    sb.AppendLine("Trn_連絡");
                    sb.AppendLine("ON");
                    sb.AppendLine("Trn_勤務表シフト情報.tanto_id = Trn_連絡.tanto_id");
                    sb.AppendLine("AND");
                    sb.AppendLine("Trn_勤務表シフト情報.day = Trn_連絡.day");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("Trn_勤務表シフト情報.day >= '" + today.AddDays(1) + "'");
                    sb.AppendLine("AND");
                    sb.AppendLine("Trn_連絡.tanto_id > 0");

                    // バックカラー
                    var bkcolor = Color.ForestGreen;
                    var frcolor = Color.White;

                    using(DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            // ヘッダの名前と比べ、ボタンカラーを変える
                            if (dr["tanto_name"].ToString() == col5.HeaderText)
                            {
                                this.btn1.Font = new Font(ClsPublic.LIST_FONT_TYPE_MIN, 14, FontStyle.Bold | FontStyle.Italic);
                                this.btn1.BackColor = bkcolor;
                                this.btn1.ForeColor = frcolor;
                                this.btn1.Text = "連絡済";
                            }
                            if (dr["tanto_name"].ToString() == col6.HeaderText)
                            {
                                this.btn2.Font = new Font(ClsPublic.LIST_FONT_TYPE_MIN, 14, FontStyle.Bold | FontStyle.Italic);
                                this.btn2.BackColor = bkcolor;
                                this.btn2.ForeColor = frcolor;
                                this.btn2.Text = "連絡済";
                            }
                            if (dr["tanto_name"].ToString() == col7.HeaderText)
                            {
                                this.btn3.Font = new Font(ClsPublic.LIST_FONT_TYPE_MIN, 14, FontStyle.Bold | FontStyle.Italic);
                                this.btn3.BackColor = bkcolor;
                                this.btn3.ForeColor = frcolor;
                                this.btn3.Text = "連絡済";
                            }
                            if (dr["tanto_name"].ToString() == col8.HeaderText)
                            {
                                this.btn4.Font = new Font(ClsPublic.LIST_FONT_TYPE_MIN, 14, FontStyle.Bold | FontStyle.Italic);
                                this.btn4.BackColor = bkcolor;
                                this.btn4.ForeColor = frcolor;
                                this.btn4.Text = "連絡済";
                            }
                            if (dr["tanto_name"].ToString() == col9.HeaderText)
                            {
                                this.btn5.Font = new Font(ClsPublic.LIST_FONT_TYPE_MIN, 14, FontStyle.Bold | FontStyle.Italic);
                                this.btn5.BackColor = bkcolor;
                                this.btn5.ForeColor = frcolor;
                                this.btn5.Text = "連絡済";
                            }
                            if (dr["tanto_name"].ToString() == col10.HeaderText)
                            {
                                this.btn6.Font = new Font(ClsPublic.LIST_FONT_TYPE_MIN, 14, FontStyle.Bold | FontStyle.Italic);
                                this.btn6.BackColor = bkcolor;
                                this.btn6.ForeColor = frcolor;
                                this.btn6.Text = "連絡済";
                            }
                            if (dr["tanto_name"].ToString() == col11.HeaderText)
                            {
                                this.btn7.Font = new Font(ClsPublic.LIST_FONT_TYPE_MIN, 14, FontStyle.Bold | FontStyle.Italic);
                                this.btn7.BackColor = bkcolor;
                                this.btn7.ForeColor = frcolor;
                                this.btn7.Text = "連絡済";
                            }
                            if (dr["tanto_name"].ToString() == col12.HeaderText)
                            {
                                this.btn8.Font = new Font(ClsPublic.LIST_FONT_TYPE_MIN, 14, FontStyle.Bold | FontStyle.Italic);
                                this.btn8.BackColor = bkcolor;
                                this.btn8.ForeColor = frcolor;
                                this.btn8.Text = "連絡済";
                            }
                            if (dr["tanto_name"].ToString() == col13.HeaderText)
                            {
                                this.btn9.Font = new Font(ClsPublic.LIST_FONT_TYPE_MIN, 14, FontStyle.Bold | FontStyle.Italic);
                                this.btn9.BackColor = bkcolor;
                                this.btn9.ForeColor = frcolor;
                                this.btn9.Text = "連絡済";
                            }
                            if (dr["tanto_name"].ToString() == col14.HeaderText)
                            {
                                this.btn10.Font = new Font(ClsPublic.LIST_FONT_TYPE_MIN, 14, FontStyle.Bold | FontStyle.Italic);
                                this.btn10.BackColor = bkcolor;
                                this.btn10.ForeColor = frcolor;
                                this.btn10.Text = "連絡済";
                            }
                            if (dr["tanto_name"].ToString() == col15.HeaderText)
                            {
                                this.btn11.Font = new Font(ClsPublic.LIST_FONT_TYPE_MIN, 14, FontStyle.Bold | FontStyle.Italic);
                                this.btn11.BackColor = bkcolor;
                                this.btn11.ForeColor = frcolor;
                                this.btn11.Text = "連絡済";
                            }
                            if (dr["tanto_name"].ToString() == col16.HeaderText)
                            {
                                this.btn12.Font = new Font(ClsPublic.LIST_FONT_TYPE_MIN, 14, FontStyle.Bold | FontStyle.Italic);
                                this.btn12.BackColor = bkcolor;
                                this.btn12.ForeColor = frcolor;
                                this.btn12.Text = "連絡済";
                            }
                            if (dr["tanto_name"].ToString() == col17.HeaderText)
                            {
                                this.btn13.Font = new Font(ClsPublic.LIST_FONT_TYPE_MIN, 14, FontStyle.Bold | FontStyle.Italic);
                                this.btn13.BackColor = bkcolor;
                                this.btn13.ForeColor = frcolor;
                                this.btn13.Text = "連絡済";
                            }
                            if (dr["tanto_name"].ToString() == col18.HeaderText)
                            {
                                this.btn14.Font = new Font(ClsPublic.LIST_FONT_TYPE_MIN, 14, FontStyle.Bold | FontStyle.Italic);
                                this.btn14.BackColor = bkcolor;
                                this.btn14.ForeColor = frcolor;
                                this.btn14.Text = "連絡済";
                            }
                            if (dr["tanto_name"].ToString() == col19.HeaderText)
                            {
                                this.btn15.Font = new Font(ClsPublic.LIST_FONT_TYPE_MIN, 14, FontStyle.Bold | FontStyle.Italic);
                                this.btn15.BackColor = bkcolor;
                                this.btn15.ForeColor = frcolor;
                                this.btn15.Text = "連絡済";
                            }
                            if (dr["tanto_name"].ToString() == col20.HeaderText)
                            {
                                this.btn16.Font = new Font(ClsPublic.LIST_FONT_TYPE_MIN, 14, FontStyle.Bold | FontStyle.Italic);
                                this.btn16.BackColor = bkcolor;
                                this.btn16.ForeColor = frcolor;
                                this.btn16.Text = "連絡済";
                            }
                            if (dr["tanto_name"].ToString() == col21.HeaderText)
                            {
                                this.btn17.Font = new Font(ClsPublic.LIST_FONT_TYPE_MIN, 14, FontStyle.Bold | FontStyle.Italic);
                                this.btn17.BackColor = bkcolor;
                                this.btn17.ForeColor = frcolor;
                                this.btn17.Text = "連絡済";
                            }
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
        /// タイマーイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            // 自動再表示
            if (this.chkAuto.Checked != true) { return; }

            // ----------------------------------------------------------------
            // 予定勤務データ表示
            // ----------------------------------------------------------------
            // rdo1=check:当月のみ表示　rdo3=check:当月、翌月を表示
            if (this.rdo1.Checked == true) { DisplayShiftList(0); }
            else { DisplayShiftList(1); }

            // ----------------------------------------------------------------
            // 連絡済情報
            // ----------------------------------------------------------------
            ShiftContact();
        }

        private void btn_Click(object sender, EventArgs e) 
        {
            // クリックされたボタンの名称を取得する
            string buttonName = "";
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                buttonName = clickedButton.Name;
                // MessageBox.Show($"クリックされたボタンの名前は: {buttonName} です");
            }

            frmRegContact frm = new();

            // ボタン名称からIDを設定
            switch (buttonName)
            {
                case "btn1":
                    frm.SelectTantoID = int.Parse(lblID1.Text);
                    break;
                case "btn2":
                    frm.SelectTantoID = int.Parse(lblID2.Text);
                    break;
                case "btn3":
                    frm.SelectTantoID = int.Parse(lblID3.Text);
                    break;
                case "btn4":
                    frm.SelectTantoID = int.Parse(lblID4.Text);
                    break;
                case "btn5":
                    frm.SelectTantoID = int.Parse(lblID5.Text);
                    break;
                case "btn6":
                    frm.SelectTantoID = int.Parse(lblID6.Text);
                    break;
                case "btn7":
                    frm.SelectTantoID = int.Parse(lblID7.Text);
                    break;
                case "btn8":
                    frm.SelectTantoID = int.Parse(lblID8.Text);
                    break;
                case "btn9":
                    frm.SelectTantoID = int.Parse(lblID9.Text);
                    break;
                case "btn10":
                    frm.SelectTantoID = int.Parse(lblID10.Text);
                    break;
                case "btn11":
                    frm.SelectTantoID = int.Parse(lblID11.Text);
                    break;
                case "btn12":
                    frm.SelectTantoID = int.Parse(lblID12.Text);
                    break;
                case "btn13":
                    frm.SelectTantoID = int.Parse(lblID13.Text);
                    break;
                case "btn14":
                    frm.SelectTantoID = int.Parse(lblID14.Text);
                    break;
                case "btn15":
                    frm.SelectTantoID = int.Parse(lblID15.Text);
                    break;
                case "btn16":
                    frm.SelectTantoID = int.Parse(lblID16.Text);
                    break;
                case "btn17":
                    frm.SelectTantoID = int.Parse(lblID17.Text);
                    break;
                default:
                    frm.SelectTantoID = 0;
                    break;
            }

            frm.ShowDialog();

            // ----------------------------------------------------------------
            // 予定勤務データ表示
            // ----------------------------------------------------------------
            // rdo1=check:当月のみ表示　rdo3=check:当月、翌月を表示
            if (this.rdo1.Checked == true) { DisplayShiftList(0); }
            else { DisplayShiftList(1); }

            // ----------------------------------------------------------------
            // 連絡済情報
            // ----------------------------------------------------------------
            ShiftContact();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 再表示ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReDisplay_Click(object sender, EventArgs e)
        {
            // ----------------------------------------------------------------
            // 予定勤務データ表示
            // ----------------------------------------------------------------
            // rdo1=check:当月のみ表示　rdo3=check:当月、翌月を表示
            if (this.rdo1.Checked == true) { DisplayShiftList(0); }
            else { DisplayShiftList(1); }

            // ----------------------------------------------------------------
            // 連絡済情報
            // ----------------------------------------------------------------
            ShiftContact();
        }
    }
}
