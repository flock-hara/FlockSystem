using DocumentFormat.OpenXml.Office2010.Excel;
using FlockAppC.pubClass;
using FlockAppC.tblClass;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FlockAppC.マスターメンテ
{
    public partial class frmMstKbn : Form
    {
        private int Kbn1 { get; set; }
        private int Kbn2 { get; set; }

        private readonly StringBuilder sb = new();

        public frmMstKbn()
        {
            InitializeComponent();
        }
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMstKbn_Load(object sender, EventArgs e)
        {
            // 区分一覧設定
            SetDgvKbnList();

            // 区分明細一覧設定
            SetDgvKbnDetailList();

            // フォームクリア
            InitializeForm(true);
            InitializeDetailForm();

            // 区分一覧表示
            DisplayKbnList();

            this.Location = new Point(0, 0);
        }
        /// <summary>
        /// 区分一覧設定
        /// </summary>
        private void SetDgvKbnList()
        {
            DataGridViewTextBoxColumn col01 = new()
            {
                Name = "KbnName",
                HeaderText = "区分名称",
                Width = 160,
                Visible = true
            };
            DataGridViewTextBoxColumn col02 = new()
            {
                Name = "Kbn1",
                HeaderText = "区分1",
                Width = 80,
                Visible = true
            };
            DataGridViewTextBoxColumn col03 = new()
            {
                Name = "Kbn2",
                HeaderText = "区分2",
                Width = 80,
                Visible = true
            };
            DataGridViewTextBoxColumn col04 = new()
            {
                Name = "Value",
                HeaderText = "値(数値)",
                Width = 80,
                Visible = true
            };
            DataGridViewTextBoxColumn col05 = new()
            {
                Name = "StrValue",
                HeaderText = "値(文字)",
                Width = 160,
                Visible = true
            };

            //DataGridViewTextBoxColumn col01 = new DataGridViewTextBoxColumn();
            //DataGridViewTextBoxColumn col02 = new DataGridViewTextBoxColumn();
            //DataGridViewTextBoxColumn col03 = new DataGridViewTextBoxColumn();
            //DataGridViewTextBoxColumn col04 = new DataGridViewTextBoxColumn();
            //DataGridViewTextBoxColumn col05 = new DataGridViewTextBoxColumn();
            //col01.Name = "KbnName";
            //col01.HeaderText = "区分名称";
            //col01.Width = 160;
            //col01.Visible = true;
            //col02.Name = "Kbn1";
            //col02.HeaderText = "区分1";
            //col02.Width = 80;
            //col02.Visible = true;
            //col03.Name = "Kbn2";
            //col03.HeaderText = "区分2";
            //col03.Width = 80;
            //col03.Visible = true;
            //col04.Name = "Value";
            //col04.HeaderText = "値(数値)";
            //col04.Width = 80;
            //col04.Visible = true;
            //col05.Name = "StrValue";
            //col05.HeaderText = "値(文字)";
            //col05.Width = 160;
            //col05.Visible = true;

            this.dgvKbnList.Columns.Add(col01);
            this.dgvKbnList.Columns.Add(col02);
            this.dgvKbnList.Columns.Add(col03);
            this.dgvKbnList.Columns.Add(col04);
            this.dgvKbnList.Columns.Add(col05);

            //並び替えができないようにする
            foreach (DataGridViewColumn c in this.dgvKbnList.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            this.dgvKbnList.EnableHeadersVisualStyles = false;                                                               //Windows Color無効
            this.dgvKbnList.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.CornflowerBlue;                   //列ヘッダ色
            this.dgvKbnList.RowTemplate.Height = 25;                                                                         //行高さ
            this.dgvKbnList.AllowUserToResizeColumns = false;                                                                //列幅の変更不可
            this.dgvKbnList.AllowUserToResizeRows = false;                                                                   //行高さの変更不可
            this.dgvKbnList.ColumnHeadersVisible = true;                                                                     //列ヘッダ非表示

            // 列ヘッダー文字位置
            this.dgvKbnList.Columns["KbnName"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvKbnList.Columns["Kbn1"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvKbnList.Columns["Kbn2"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvKbnList.Columns["Value"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvKbnList.Columns["StrValue"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // セル内表示位置
            this.dgvKbnList.Columns["KbnName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvKbnList.Columns["Kbn1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvKbnList.Columns["Kbn2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvKbnList.Columns["Value"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvKbnList.Columns["StrValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            //奇数行を黄色にする
            this.dgvKbnList.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Moccasin;
            // this.dgvKbnList.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.PaleTurquoise;

            // 選択した時の行のバックカラー
            // this.dgvCarList.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightBlue;
            // this.dgvKbnList.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SeaGreen;

            // フォント設定
            this.dgvKbnList.Columns["KbnName"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);
            this.dgvKbnList.Columns["Kbn1"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);
            this.dgvKbnList.Columns["Kbn2"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);
            this.dgvKbnList.Columns["Value"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);
            this.dgvKbnList.Columns["StrValue"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);

            // その他
            this.dgvKbnList.MultiSelect = false;                                                                         //複数選択
            this.dgvKbnList.ReadOnly = true;                                                                             //読込専用
            this.dgvKbnList.AllowUserToAddRows = false;                                                                  //行追加無効
            this.dgvKbnList.RowHeadersVisible = false;                                                                   //行ヘッダ非表示
            this.dgvKbnList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;                                     //行選択時は１行全て選択状態にする
        }
        /// <summary>
        /// 区分明細設定
        /// </summary>
        private void SetDgvKbnDetailList()
        {
            DataGridViewTextBoxColumn col01 = new()
            {
                Name = "Kbn2",
                HeaderText = "区分2",
                Width = 80,
                Visible = true
            };
            DataGridViewTextBoxColumn col02 = new()
            {
                Name = "Value",
                HeaderText = "値(数値)",
                Width = 80,
                Visible = true
            };
            DataGridViewTextBoxColumn col03 = new()
            {
                Name = "StrValue",
                HeaderText = "値(文字)",
                Width = 160,
                Visible = true
            };

            //DataGridViewTextBoxColumn col01 = new DataGridViewTextBoxColumn();
            //DataGridViewTextBoxColumn col02 = new DataGridViewTextBoxColumn();
            //DataGridViewTextBoxColumn col03 = new DataGridViewTextBoxColumn();
            //col01.Name = "Kbn2";
            //col01.HeaderText = "区分2";
            //col01.Width = 80;
            //col01.Visible = true;
            //col02.Name = "Value";
            //col02.HeaderText = "値(数値)";
            //col02.Width = 80;
            //col02.Visible = true;
            //col03.Name = "StrValue";
            //col03.HeaderText = "値(文字)";
            //col03.Width = 160;
            //col03.Visible = true;

            this.dgvKbnDetailList.Columns.Add(col01);
            this.dgvKbnDetailList.Columns.Add(col02);
            this.dgvKbnDetailList.Columns.Add(col03);

            //並び替えができないようにする
            foreach (DataGridViewColumn c in this.dgvKbnDetailList.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            this.dgvKbnDetailList.EnableHeadersVisualStyles = false;                                                               //Windows Color無効
            this.dgvKbnDetailList.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.CornflowerBlue;                   //列ヘッダ色
            this.dgvKbnDetailList.RowTemplate.Height = 25;                                                                         //行高さ
            this.dgvKbnDetailList.AllowUserToResizeColumns = false;                                                                //列幅の変更不可
            this.dgvKbnDetailList.AllowUserToResizeRows = false;                                                                   //行高さの変更不可
            this.dgvKbnDetailList.ColumnHeadersVisible = true;                                                                     //列ヘッダ非表示

            // 列ヘッダー文字位置
            this.dgvKbnDetailList.Columns["Kbn2"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvKbnDetailList.Columns["Value"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvKbnDetailList.Columns["StrValue"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // セル内表示位置
            this.dgvKbnDetailList.Columns["Kbn2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvKbnDetailList.Columns["Value"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvKbnDetailList.Columns["StrValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            //奇数行を黄色にする
            this.dgvKbnDetailList.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Moccasin;
            // this.dgvKbnDetailList.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.PaleTurquoise;

            // 選択した時の行のバックカラー
            // this.dgvKbnDetailList.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightBlue;
            // this.dgvKbnDetailList.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SeaGreen;

            // フォント設定
            this.dgvKbnDetailList.Columns["Kbn2"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);
            this.dgvKbnDetailList.Columns["Value"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);
            this.dgvKbnDetailList.Columns["StrValue"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);

            // その他
            this.dgvKbnDetailList.MultiSelect = false;                                                                         //複数選択
            this.dgvKbnDetailList.ReadOnly = false;                                                                             //読込専用
            this.dgvKbnDetailList.AllowUserToAddRows = false;                                                                  //行追加無効
            this.dgvKbnDetailList.RowHeadersVisible = false;                                                                   //行ヘッダ非表示
            this.dgvKbnDetailList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;                                     //行選択時は１行全て選択状態にする
        }
        /// <summary>
        /// フォームクリア
        /// </summary>
        /// <param name="p_flg"></param>
        private void InitializeForm(bool p_flg)
        {
            this.lblNew.Visible = p_flg;
            // this.dgvKbnList.ClearSelection();
        }
        /// <summary>
        /// フォームクリア（明細）
        /// </summary>
        /// <param name="p_flg"></param>
        private void InitializeDetailForm()
        {
            this.txtKbn1.Text = "";
            this.txtKbnName.Text = "";
            this.dgvKbnDetailList.Rows.Clear();
            // 空行を事前に表示
            for (var row = 0; row < 50; row++)
            {
                this.dgvKbnDetailList.Rows.Add();
            }
        }
        /// <summary>
        /// 区分一覧表示（全体）
        /// </summary>
        private void DisplayKbnList()
        {
            var row = 0;

            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" kbn1");
                    sb.AppendLine(",kbn2");
                    sb.AppendLine(",value");
                    sb.AppendLine(",strval");
                    sb.AppendLine(",comment");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_区分");
                    sb.AppendLine("ORDER BY");
                    sb.AppendLine(" kbn1");
                    sb.AppendLine(",kbn2");
                    sb.AppendLine(",value");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            this.dgvKbnList.Rows.Add();
                            this.dgvKbnList.Rows[row].Cells["KbnName"].Value = dr["comment"].ToString();
                            this.dgvKbnList.Rows[row].Cells["Kbn1"].Value = dr["kbn1"].ToString();
                            this.dgvKbnList.Rows[row].Cells["Kbn2"].Value = dr["kbn2"].ToString();
                            this.dgvKbnList.Rows[row].Cells["Value"].Value = dr["value"].ToString();
                            this.dgvKbnList.Rows[row].Cells["StrValue"].Value = dr["strval"].ToString();
                            row++;
                        }
                    }
                }
                this.dgvKbnList.ClearSelection();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 区分一覧表示（明細）
        /// </summary>
        private void DisplayKbnDetailList()
        {
            var row = 0;

            try
            {
                InitializeDetailForm();
                this.dgvKbnDetailList.Rows.Clear();

                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" kbn1");
                    sb.AppendLine(",kbn2");
                    sb.AppendLine(",value");
                    sb.AppendLine(",strval");
                    sb.AppendLine(",comment");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_区分");
                    sb.AppendLine("WHERE");
                    sb.AppendLine(" kbn1 = " + Kbn1);
                    sb.AppendLine("ORDER BY");
                    sb.AppendLine(" kbn2");
                    sb.AppendLine(",value");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            if (dr["Comment"].ToString() != "") { this.txtKbnName.Text = dr["comment"].ToString(); }
                            this.txtKbn1.Text = dr["kbn1"].ToString();

                            this.dgvKbnDetailList.Rows.Add();
                            this.dgvKbnDetailList.Rows[row].Cells["Kbn2"].Value = dr["kbn2"].ToString();
                            this.dgvKbnDetailList.Rows[row].Cells["Value"].Value = dr["value"].ToString();
                            this.dgvKbnDetailList.Rows[row].Cells["StrValue"].Value = dr["strval"].ToString();
                            row++;
                        }
                    }

                    for (; row < 50; row++)
                    {
                        this.dgvKbnDetailList.Rows.Add();
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
        /// 区分一覧（全件）セルクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvKbnList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }

            // 新規ラベルを非表示→更新モードに
            InitializeForm(false);

            //クリックされたセルのID取得
            Kbn1 = int.Parse(this.dgvKbnList.Rows[e.RowIndex].Cells[1].Value.ToString());

            DisplayKbnDetailList();
        }
        /// <summary>
        /// 明細一覧セルクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvKbnDetailList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 行と列が正しいかどうかをチェック
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // セルを選択し、編集モードに入る
                dgvKbnDetailList.CurrentCell = dgvKbnDetailList[e.ColumnIndex, e.RowIndex];
                dgvKbnDetailList.BeginEdit(true);  // true で編集モードに移行
            }
        }
        /// <summary>
        /// 新規ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            this.dgvKbnList.ClearSelection();

            InitializeForm(true);

            InitializeDetailForm();

            this.txtKbn1.Focus();
        }
        /// <summary>
        /// 削除ボタン１（全件一覧）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete1_Click(object sender, EventArgs e)
        {
            // 現在選択されているセルの行番号を取得
            int rowIndex = this.dgvKbnList.CurrentCell.RowIndex;

            if (rowIndex < 0) { return; }

            var kbn = int.Parse(this.dgvKbnList.Rows[rowIndex].Cells[1].Value.ToString());

            if (MessageBox.Show("選択した区分(" + kbn + ")を削除します。","確認",MessageBoxButtons.OKCancel) == DialogResult.Cancel) { return; }

            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("DELETE FROM");
                    sb.AppendLine("Mst_区分");
                    sb.AppendLine("WHERE");
                    sb.AppendLine(" kbn1 = " + kbn);

                    clsSqlDb.DMLUpdate(sb.ToString());
                }

                DisplayKbnList();
                InitializeDetailForm();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 保存ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReg_Click(object sender, EventArgs e)
        {
            // 一覧内容チェック
            if (int.TryParse(this.txtKbn1.Text,out _) != true)
            {
                MessageBox.Show("区分には数字を入力してください。", "警告", MessageBoxButtons.OK);
                return;
            }

            var flg = false;
            // 未入力チェック
            for (var row = 0; row < 50; row++)
            {
                if (this.dgvKbnDetailList.Rows[row].Cells[0].Value != null &&
                    this.dgvKbnDetailList.Rows[row].Cells[1].Value != null &
                    this.dgvKbnDetailList.Rows[row].Cells[2].Value != null  )
                {
                    flg = true;
                }
            }
            if (flg != true)
            {
                MessageBox.Show("登録区分が入力されていません。", "警告", MessageBoxButtons.OK);
                return;
            }
            // 一部未入力チェック
            for (var row = 0; row < 50; row++)
            {
                if (this.dgvKbnDetailList.Rows[row].Cells[0].Value != null)
                {
                    if (this.dgvKbnDetailList.Rows[row].Cells[1].Value == null || this.dgvKbnDetailList.Rows[row].Cells[2].Value == null)
                    {
                        MessageBox.Show("一部未入力の区分があります。", "警告", MessageBoxButtons.OK);
                        return;
                    }
                }
                else
                {
                    if (this.dgvKbnDetailList.Rows[row].Cells[1].Value != null || this.dgvKbnDetailList.Rows[row].Cells[2].Value != null)
                    {
                        MessageBox.Show("一部未入力の区分があります。", "警告", MessageBoxButtons.OK);
                        return;
                    }
                }
            }

            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    // 入力された区分が登録されている場合削除
                    sb.Clear();
                    sb.AppendLine("DELETE FROM");
                    sb.AppendLine("Mst_区分");
                    sb.AppendLine("WHERE");
                    sb.AppendLine(" kbn1 = " + this.txtKbn1.Text);
                    
                    clsSqlDb.DMLUpdate(sb.ToString());

                    // 一覧上の区分を全てINSERT
                    for (var row = 0; row < 50; row++)
                    {
                        if (this.dgvKbnDetailList.Rows[row].Cells[0].Value != null &&
                            this.dgvKbnDetailList.Rows[row].Cells[1].Value != null &&
                            this.dgvKbnDetailList.Rows[row].Cells[2].Value != null )
                        {
                            // 区分２、値、文字全て入力されている区分を登録
                            sb.Clear();
                            sb.AppendLine("INSERT INTO");
                            sb.AppendLine("Mst_区分");
                            sb.AppendLine("(");
                            sb.AppendLine(" kbn1");
                            sb.AppendLine(",kbn2");
                            sb.AppendLine(",value");
                            sb.AppendLine(",strval");
                            sb.AppendLine(",comment");
                            // 2025/11/12↓
                            sb.AppendLine(",ins_user_id");
                            sb.AppendLine(",ins_date");
                            sb.AppendLine(",delete_flag");
                            // 2025/11/12↑
                            sb.AppendLine(") VALUES (");
                            sb.AppendLine( this.txtKbn1.Text);
                            sb.AppendLine("," + this.dgvKbnDetailList.Rows[row].Cells[0].Value.ToString());
                            sb.AppendLine("," + this.dgvKbnDetailList.Rows[row].Cells[1].Value.ToString());
                            sb.AppendLine(",'" + this.dgvKbnDetailList.Rows[row].Cells[2].Value.ToString() + "'");
                            if (int.Parse(this.dgvKbnDetailList.Rows[row].Cells[0].Value.ToString()) == 1)
                            {
                                // 区分2が1の場合、区分名称（備考）をセット
                                sb.AppendLine(",'" + this.txtKbnName.Text + "'");
                            }
                            else
                            {
                                sb.AppendLine(",''");
                            }
                            // 2025/11/12↓
                            sb.AppendLine("," + ClsLoginUser.StaffID);
                            sb.AppendLine(",'" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                            sb.AppendLine("," + ClsPublic.FLAG_OFF);
                            // 2025/11/12↑
                            sb.AppendLine(")");

                            clsSqlDb.DMLUpdate(sb.ToString());
                        }
                    }
                }

                // 転送確認
                if (MessageBox.Show("登録しました。続けてサーバーに転送（同期）しますか？" + Environment.NewLine + "転送先 [" + ClsDbConfig.mysqlParam[ClsDbConfig.MySQLNo].Instance + "\\" + ClsDbConfig.mysqlParam[ClsDbConfig.MySQLNo].Database + "]", "確認", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    DisplayKbnList();
                    DisplayKbnDetailList();
                    // return;
                }
                else
                {
                    // 接続メッセージ
                    this.lblConnect.Visible = true;

                    // 転送（同期）処理
                    using (ClsMySqlDb clsMySqlDb = new(ClsDbConfig.MySQLNo))
                    using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                    {
                        // Mst_区分クラス
                        ClsMstKbn clsMstKbn = new();
                        // 区分登録
                        clsMstKbn.ExportKbnMstData(clsSqlDb, clsMySqlDb);
                    }
                    // 接続メッセージ
                    this.lblConnect.Visible = false;
                    MessageBox.Show("転送しました。", "結果", MessageBoxButtons.OK);
                    DisplayKbnList();
                    DisplayKbnDetailList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            // 新規ラベル非表示
            this.lblNew.Visible = false;

            // clearSelect（２つの表）
            this.dgvKbnList.ClearSelection();
            this.dgvKbnDetailList.ClearSelection();
        }
        /// <summary>
        /// 削除ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete2_Click(object sender, EventArgs e)
        {
            // 現在選択されているセルの行番号を取得
            int rowIndex = this.dgvKbnDetailList.CurrentCell.RowIndex;

            if (rowIndex < 0) { return; }

            var kbn2 = int.Parse(this.dgvKbnDetailList.Rows[rowIndex].Cells[0].Value.ToString());

            if (MessageBox.Show("選択した区分2(" + kbn2 + ")を削除します。", "確認", MessageBoxButtons.OKCancel) == DialogResult.Cancel) { return; }

            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("DELETE FROM");
                    sb.AppendLine("Mst_区分");
                    sb.AppendLine("WHERE");
                    sb.AppendLine(" kbn1 = " + this.txtKbn1.Text);
                    sb.AppendLine("AND");
                    sb.AppendLine(" kbn2 = " + kbn2);
                    
                    clsSqlDb.DMLUpdate(sb.ToString());
                }
                DisplayKbnList();
                DisplayKbnDetailList();
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
            this.Dispose();
        }
    }
}
