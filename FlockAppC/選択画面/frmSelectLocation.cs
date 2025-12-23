using FlockAppC.pubClass;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FlockAppC.選択画面
{
    public partial class frmSelectLocation : Form
    {
        // Select2 1行の表示アイテム数
        const int colItemMax = 4;       // 5件

        // 選択専従先
        public string Select_location_name { get; set; }
        public int Select_location_id { get; set; }
        // 締め日
        public int Select_Closing_Date { get; set; }

        // 対象テーブル
        public string TargetTable { get; set; }
        // 選択キー
        public string Key { get; set; }

        private readonly StringBuilder sb = new();

        public frmSelectLocation()
        {
            InitializeComponent();
        }

        private void frmSelectLocation_Load(object sender, EventArgs e)
        {
            // 選択情報初期化
            Select_location_id = 0;
            Select_location_name = "";

            this.lblLocation.Text = "";
            this.dgvSelect1.Columns.Clear();
            this.dgvSelect2.Columns.Clear();

            SetDgvSelect1();
            SetDgvSelect2();

            //選択1
            SetDgvSelect1Data();

            this.Location = new System.Drawing.Point(0, 0);
        }
        /// <summary>
        /// 選択１（ｱ～ﾜ）表示
        /// </summary>
        private void SetDgvSelect1Data()
        {
            //一覧クリア
            this.dgvSelect1.Rows.Clear();

            this.dgvSelect1.Rows.Add();
            this.dgvSelect1.Rows[0].Cells["all"].Value = "全て";
            this.dgvSelect1.Rows[0].Cells["s1"].Value = "ア行";
            this.dgvSelect1.Rows[0].Cells["s2"].Value = "カ行";
            this.dgvSelect1.Rows[0].Cells["s3"].Value = "サ行";
            this.dgvSelect1.Rows[0].Cells["s4"].Value = "タ行";
            this.dgvSelect1.Rows[0].Cells["s5"].Value = "ナ行";
            this.dgvSelect1.Rows[0].Cells["s6"].Value = "ハ行";
            this.dgvSelect1.Rows[0].Cells["s7"].Value = "マ行";
            this.dgvSelect1.Rows[0].Cells["s8"].Value = "ヤ行";
            this.dgvSelect1.Rows[0].Cells["s9"].Value = "ラ行";
            this.dgvSelect1.Rows[0].Cells["s10"].Value = "ワ行";
        }
        /// <summary>
        /// Set Select GridView1
        /// </summary>
        private void SetDgvSelect1()
        {
            int colWidth = 65;
            int rowHeight = 35;
            int fontSize = 12;

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

            col01.Name = "all";
            col01.HeaderText = "all";
            col01.Width = colWidth;
            col01.Visible = true;

            col02.Name = "s1";
            col02.HeaderText = "s1";
            col02.Width = colWidth;
            col02.Visible = true;

            col03.Name = "s2";
            col03.HeaderText = "s2";
            col03.Width = colWidth;
            col03.Visible = true;

            col04.Name = "s3";
            col04.HeaderText = "s3";
            col04.Width = colWidth;
            col04.Visible = true;

            col05.Name = "s4";
            col05.HeaderText = "s4";
            col05.Width = colWidth;
            col05.Visible = true;

            col06.Name = "s5";
            col06.HeaderText = "s5";
            col06.Width = colWidth;
            col06.Visible = true;

            col07.Name = "s6";
            col07.HeaderText = "s6";
            col07.Width = colWidth;
            col07.Visible = true;

            col08.Name = "s7";
            col08.HeaderText = "s7";
            col08.Width = colWidth;
            col08.Visible = true;

            col09.Name = "s8";
            col09.HeaderText = "s8";
            col09.Width = colWidth;
            col09.Visible = true;

            col10.Name = "s9";
            col10.HeaderText = "s9";
            col10.Width = colWidth;
            col10.Visible = true;

            col11.Name = "s10";
            col11.HeaderText = "s10";
            col11.Width = colWidth;
            col11.Visible = true;

            this.dgvSelect1.Columns.Add(col01);
            this.dgvSelect1.Columns.Add(col02);
            this.dgvSelect1.Columns.Add(col03);
            this.dgvSelect1.Columns.Add(col04);
            this.dgvSelect1.Columns.Add(col05);
            this.dgvSelect1.Columns.Add(col06);
            this.dgvSelect1.Columns.Add(col07);
            this.dgvSelect1.Columns.Add(col08);
            this.dgvSelect1.Columns.Add(col09);
            this.dgvSelect1.Columns.Add(col10);
            this.dgvSelect1.Columns.Add(col11);

            //並び替えができないようにする
            foreach (DataGridViewColumn c in this.dgvSelect1.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            this.dgvSelect1.EnableHeadersVisualStyles = false;                                                          //Windows Color無効
            this.dgvSelect1.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.CornflowerBlue;              //列ヘッダ色
            this.dgvSelect1.RowTemplate.Height = rowHeight;                                                             //行高さ
            this.dgvSelect1.AllowUserToResizeColumns = false;                                                           //列幅の変更不可
            this.dgvSelect1.AllowUserToResizeRows = false;                                                              //行高さの変更不可
            this.dgvSelect1.ColumnHeadersVisible = false;                                                               //列ヘッダ非表示

            //奇数行を黄色にする
            // this.dgvSelect1.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Moccasin;

            this.dgvSelect1.Columns["all"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;       //セルの文字表示位置
            this.dgvSelect1.Columns["s1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;        //セルの文字表示位置
            this.dgvSelect1.Columns["s2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;        //セルの文字表示位置
            this.dgvSelect1.Columns["s3"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;        //セルの文字表示位置
            this.dgvSelect1.Columns["s4"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;        //セルの文字表示位置
            this.dgvSelect1.Columns["s5"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;        //セルの文字表示位置
            this.dgvSelect1.Columns["s6"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;        //セルの文字表示位置
            this.dgvSelect1.Columns["s7"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;        //セルの文字表示位置
            this.dgvSelect1.Columns["s8"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;        //セルの文字表示位置
            this.dgvSelect1.Columns["s9"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;        //セルの文字表示位置
            this.dgvSelect1.Columns["s10"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;       //セルの文字表示位置

            this.dgvSelect1.Columns["all"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", fontSize, FontStyle.Bold);      //フォント設定
            this.dgvSelect1.Columns["s1"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", fontSize, FontStyle.Bold);       //フォント設定
            this.dgvSelect1.Columns["s2"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", fontSize, FontStyle.Bold);       //フォント設定
            this.dgvSelect1.Columns["s3"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", fontSize, FontStyle.Bold);       //フォント設定
            this.dgvSelect1.Columns["s4"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", fontSize, FontStyle.Bold);       //フォント設定
            this.dgvSelect1.Columns["s5"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", fontSize, FontStyle.Bold);       //フォント設定
            this.dgvSelect1.Columns["s6"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", fontSize, FontStyle.Bold);       //フォント設定
            this.dgvSelect1.Columns["s7"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", fontSize, FontStyle.Bold);       //フォント設定
            this.dgvSelect1.Columns["s8"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", fontSize, FontStyle.Bold);       //フォント設定
            this.dgvSelect1.Columns["s9"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", fontSize, FontStyle.Bold);       //フォント設定
            this.dgvSelect1.Columns["s10"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", fontSize, FontStyle.Bold);      //フォント設定

            //this.dgvSelect1.ScrollBars = false;                                                                        //スクロールバー非表示
            this.dgvSelect1.MultiSelect = false;                                                                         //複数選択
            this.dgvSelect1.ReadOnly = true;                                                                             //読込専用
            this.dgvSelect1.AllowUserToAddRows = false;                                                                  //行追加無効
            this.dgvSelect1.RowHeadersVisible = false;                                                                   //行ヘッダ非表示
            //this.dgvSelect1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;                                     //行選択時は１行全て選択状態にする
        }

        /// <summary>
        /// Set Select GridView2
        /// </summary>
        private void SetDgvSelect2()
        {
            int colWidth = 144;
            int rowHeight = 40;
            int fontSize = 14;

            DataGridViewTextBoxColumn col01 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col02 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col03 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col04 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col05 = new DataGridViewTextBoxColumn();

            DataGridViewTextBoxColumn col011 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col021 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col031 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col041 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col051 = new DataGridViewTextBoxColumn();

            DataGridViewTextBoxColumn col0111 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col0211 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col0311 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col0411 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col0511 = new DataGridViewTextBoxColumn();

            col01.Name = "i1";
            col01.HeaderText = "i1";
            col01.Width = colWidth;
            col01.Visible = true;

            col02.Name = "i2";
            col02.HeaderText = "i2";
            col02.Width = colWidth;
            col02.Visible = true;

            col03.Name = "i3";
            col03.HeaderText = "i3";
            col03.Width = colWidth;
            col03.Visible = true;

            col04.Name = "i4";
            col04.HeaderText = "i4";
            col04.Width = colWidth;
            col04.Visible = true;

            col05.Name = "i5";
            col05.HeaderText = "i5";
            col05.Width = colWidth;
            col05.Visible = true;

            // ID格納
            col011.Name = "i11";
            col011.HeaderText = "i11";
            col011.Width = colWidth;
            col011.Visible = false;

            col021.Name = "i21";
            col021.HeaderText = "i21";
            col021.Width = colWidth;
            col021.Visible = false;

            col031.Name = "i31";
            col031.HeaderText = "i31";
            col031.Width = colWidth;
            col031.Visible = false;

            col041.Name = "i41";
            col041.HeaderText = "i41";
            col041.Width = colWidth;
            col041.Visible = false;

            col051.Name = "i51";
            col051.HeaderText = "i51";
            col051.Width = colWidth;
            col051.Visible = false;

            // fullname格納
            col0111.Name = "i111";
            col0111.HeaderText = "i111";
            col0111.Width = colWidth;
            col0111.Visible = false;

            col0211.Name = "i211";
            col0211.HeaderText = "i211";
            col0211.Width = colWidth;
            col0211.Visible = false;

            col0311.Name = "i311";
            col0311.HeaderText = "i311";
            col0311.Width = colWidth;
            col0311.Visible = false;

            col0411.Name = "i411";
            col0411.HeaderText = "i411";
            col0411.Width = colWidth;
            col0411.Visible = false;

            col0511.Name = "i511";
            col0511.HeaderText = "i511";
            col0511.Width = colWidth;
            col0511.Visible = false;

            this.dgvSelect2.Columns.Add(col01);     // [0]
            this.dgvSelect2.Columns.Add(col02);     // [1]
            this.dgvSelect2.Columns.Add(col03);     // [2]
            this.dgvSelect2.Columns.Add(col04);     // [3]
            this.dgvSelect2.Columns.Add(col05);     // [4]
            this.dgvSelect2.Columns.Add(col011);    // [5] +5
            this.dgvSelect2.Columns.Add(col021);    // [6]
            this.dgvSelect2.Columns.Add(col031);    // [7]
            this.dgvSelect2.Columns.Add(col041);    // [8]
            this.dgvSelect2.Columns.Add(col051);    // [9]
            this.dgvSelect2.Columns.Add(col0111);   // [10] +10
            this.dgvSelect2.Columns.Add(col0211);   // [11]
            this.dgvSelect2.Columns.Add(col0311);   // [12]
            this.dgvSelect2.Columns.Add(col0411);   // [13]
            this.dgvSelect2.Columns.Add(col0511);   // [15]

            //並び替えができないようにする
            foreach (DataGridViewColumn c in this.dgvSelect2.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            this.dgvSelect2.EnableHeadersVisualStyles = false;                                                          //Windows Color無効
            this.dgvSelect2.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.CornflowerBlue;              //列ヘッダ色
            this.dgvSelect2.RowTemplate.Height = rowHeight;                                                             //行高さ
            this.dgvSelect2.AllowUserToResizeColumns = false;                                                           //列幅の変更不可
            this.dgvSelect2.AllowUserToResizeRows = false;                                                              //行高さの変更不可
            this.dgvSelect2.ColumnHeadersVisible = false;                                                               //列ヘッダ非表示

            //奇数行を黄色にする
            // this.dgvSelect2.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Moccasin;

            this.dgvSelect2.Columns["i1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;        //セルの文字表示位置
            this.dgvSelect2.Columns["i2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;        //セルの文字表示位置
            this.dgvSelect2.Columns["i3"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;        //セルの文字表示位置
            this.dgvSelect2.Columns["i4"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;        //セルの文字表示位置
            this.dgvSelect2.Columns["i5"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;        //セルの文字表示位置

            this.dgvSelect2.Columns["i1"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", fontSize, FontStyle.Bold);       //フォント設定
            this.dgvSelect2.Columns["i2"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", fontSize, FontStyle.Bold);       //フォント設定
            this.dgvSelect2.Columns["i3"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", fontSize, FontStyle.Bold);       //フォント設定
            this.dgvSelect2.Columns["i4"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", fontSize, FontStyle.Bold);       //フォント設定
            this.dgvSelect2.Columns["i5"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", fontSize, FontStyle.Bold);       //フォント設定

            //this.dgvSelect2.ScrollBars = false;                                                                        //スクロールバー非表示
            this.dgvSelect2.MultiSelect = false;                                                                         //複数選択
            this.dgvSelect2.ReadOnly = true;                                                                             //読込専用
            this.dgvSelect2.AllowUserToAddRows = false;                                                                  //行追加無効
            this.dgvSelect2.RowHeadersVisible = false;                                                                   //行ヘッダ非表示
            //this.dgvSelect2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;                                     //行選択時は１行全て選択状態にする
        }

        /// <summary>
        /// Select1 Cell Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSelect1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }
            if (e.ColumnIndex < 0) { return; }

            string[] selectKey = { "all", "ｱ", "ｶ", "ｻ", "ﾀ", "ﾅ", "ﾊ", "ﾏ", "ﾔ", "ﾗ", "ﾜ" };

            // 選択キー取得
            Key = selectKey[e.ColumnIndex];

            // 選択専従先/ID
            // this.lblLocation.Text = this.dgvSelect2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            // select_location_id = int.Parse(this.dgvSelect2.Rows[e.RowIndex].Cells[e.ColumnIndex + 5].Value.ToString());
            // select_location_name = this.dgvSelect2.Rows[e.RowIndex].Cells[e.ColumnIndex + 10].Value.ToString();

            // StringBuilder stb = new StringBuilder();

            try
            {
                //一覧クリア
                this.dgvSelect2.Rows.Clear();

                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" location_id");
                    sb.AppendLine(",name");
                    sb.AppendLine(",fullname");
                    sb.AppendLine(" FROM");
                    sb.AppendLine(" Mst_専従先");
                    sb.AppendLine(" WHERE");
                    sb.AppendLine(" 1=1");

                    // 締め日を条件に追加 2025/10/21
                    if (this.Select_Closing_Date >= 5 && this.Select_Closing_Date <= 31)
                    {
                        sb.AppendLine(" AND");
                        sb.AppendLine(" closing_date = " + this.Select_Closing_Date);
                    }

                    if (Key != "all")
                    {
                        sb.AppendLine(" AND");
                        sb.AppendLine(" kana1 = '" + Key + "'");
                    }

                    //if (Key != "all")
                    //{
                    //    sb.AppendLine("WHERE");
                    //    sb.AppendLine("kana1 = '" + Key + "'");
                    //}

                    sb.AppendLine("ORDER BY");
                    sb.AppendLine("kana2");

                    // 処理改善 2025/09/02
                    using(DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        if (dt_val.Rows.Count >= 1)
                        {
                            int colCnt = 0;
                            int rowCnt = 0;
                            Boolean bgcFlg = false;

                            //行追加
                            this.dgvSelect2.Rows.Add();

                            foreach (DataRow dr in dt_val.Rows)
                            {
                                // 1行表示アイテム数の範囲内か？
                                if (colCnt > colItemMax)
                                {
                                    //行追加
                                    this.dgvSelect2.Rows.Add();

                                    //各カウンター更新
                                    rowCnt += 1;
                                    colCnt = 0;
                                }

                                // 名称表示
                                this.dgvSelect2.Rows[rowCnt].Cells[colCnt + 5].Value = dr["location_id"].ToString();
                                this.dgvSelect2.Rows[rowCnt].Cells[colCnt].Value = dr["name"].ToString();               // 表示用
                                this.dgvSelect2.Rows[rowCnt].Cells[colCnt + 10].Value = dr["fullname"].ToString();      // 戻り値

                                // １マス毎にバックカラーを変える
                                if (bgcFlg == true)
                                {
                                    this.dgvSelect2[colCnt, rowCnt].Style.BackColor = Color.Moccasin;
                                    bgcFlg = false;
                                }
                                else
                                {
                                    this.dgvSelect2[colCnt, rowCnt].Style.BackColor = Color.White;
                                    bgcFlg = true;
                                }
                                colCnt += 1;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK);
                throw;
            }
        }

        /// <summary>
        /// 専従先ダブルクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSelect2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }
            if (e.ColumnIndex < 0) { return; }

            if (this.dgvSelect2.Rows[e.RowIndex].Cells[e.ColumnIndex + 5].Value != null)
            {
                Select_location_id = int.Parse(this.dgvSelect2.Rows[e.RowIndex].Cells[e.ColumnIndex + 5].Value.ToString());
                Select_location_name = this.dgvSelect2.Rows[e.RowIndex].Cells[e.ColumnIndex + 10].Value.ToString();
            }

            this.Close();
        }
        /// <summary>
        /// 決定ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheck_Click(object sender, EventArgs e)
        {
            // 最初に選択されたセルを取得
            DataGridViewCell selectedCell = dgvSelect2.SelectedCells[0];

            // 行インデックスと列インデックスを取得
            int selectedRowIndex = selectedCell.RowIndex;
            int selectedColumnIndex = selectedCell.ColumnIndex;

            // 選択されているセルの値を取得
            if (this.dgvSelect2.Rows[selectedRowIndex].Cells[selectedColumnIndex + 5].Value != null)
            {
                Select_location_id = int.Parse(this.dgvSelect2.Rows[selectedRowIndex].Cells[selectedColumnIndex + 5].Value.ToString());
                Select_location_name = this.dgvSelect2.Rows[selectedRowIndex].Cells[selectedColumnIndex + 10].Value.ToString();
            }

            // 画面を閉じる
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Key Down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSelect2_KeyDown(object sender, KeyEventArgs e)
        {
            // エンターキーが押されたかどうかを確認
            if (e.KeyCode == Keys.Enter)
            {
                // 選択されているセルの行番号を取得
                int rowIndex = dgvSelect2.CurrentCell.RowIndex;
                int colIndex = dgvSelect2.CurrentCell.ColumnIndex;

                // 行番号を表示（デバッグ用）
                // MessageBox.Show($"エンターキーが押された行の番号: {rowIndex}");

                // エンターキーのデフォルト動作を無効化
                e.Handled = true;

                Select_location_id = int.Parse(this.dgvSelect2.Rows[rowIndex].Cells[colIndex + 5].Value.ToString());
                Select_location_name = this.dgvSelect2.Rows[rowIndex].Cells[colIndex + 10].Value.ToString();

                this.Close();

            }

        }
    }
}
