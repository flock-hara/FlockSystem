using FlockAppC.pubClass;
using System;
using System.IO;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace FlockAppC.勤務表
{
    public partial class frmDisplayShiftExcel : Form
    {
        public frmDisplayShiftExcel()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 閉じるボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMenu10_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 表示ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMenu1_Click(object sender, EventArgs e)
        {
            Excel.Application xlApplication = new();
            Excel.Workbooks xlBooks;

            // ファイル選択チェック
            if (dgv.SelectedRows.Count <= 0)
            {
                MessageBox.Show("ﾌｧｲﾙを選択してください。", "確認", MessageBoxButtons.OK);
                return;
            }
            if (File.Exists(ClsPublic.stcConfig[dgv.CurrentRow.Index].FilePath) != true)
            {
                MessageBox.Show("ﾌｧｲﾙが存在しません。[" + ClsPublic.stcConfig[dgv.CurrentRow.Index].FilePath + "]", "確認", MessageBoxButtons.OK);
                return;
            }

            var s = ClsPublic.pubRootPath + ClsPublic.pubAppPath + "COPY勤務表.xlsx";
            try
            {
                // ------------------------------------------------
                // 勤務表表示／編集
                // ------------------------------------------------
                if (File.Exists(s) == true)
                {
                    File.Delete(s);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            try
            {
                // 勤務表コピー
                File.Copy(ClsPublic.stcConfig[dgv.CurrentRow.Index].FilePath, s);

                // xlApplication から WorkBooks を取得する
                xlBooks = xlApplication.Workbooks;

                // コピーした Excel ブックを開く(ReadOnly)
                xlBooks.Open(s, ReadOnly: true);

                // Excel を表示する
                xlApplication.WindowState = Excel.XlWindowState.xlMaximized;
                xlApplication.Visible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                xlBooks = null;
                xlApplication = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
        }
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmDisplayShiftExcel_Load(object sender, EventArgs e)
        {
            // 勤務表環境設定値取得
            ClsPublic.GetConfig();

            // ==========================================
            // シフト予定表示設定
            // ==========================================
            dgv.Columns.Clear();

            DataGridViewTextBoxColumn coChangeDate = new()              // 1列目を定義
            {
                Name = "FileName",
                HeaderText = "ファイル名",
                Width = 1100
            };
            dgv.Columns.Add(coChangeDate);

            //並び替えができないようにする
            foreach (DataGridViewColumn c in this.dgv.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            dgv.EnableHeadersVisualStyles = false;                                                      // Windows Color無効
            dgv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.CornflowerBlue;          // 列ヘッダ色
            dgv.RowTemplate.Height = 30;                                                                // 行高さ
            dgv.AllowUserToResizeColumns = false;                                                       // 列幅の変更不可
            dgv.AllowUserToResizeRows = false;                                                          // 行高さの変更不可
            dgv.Columns["FileName"].DefaultCellStyle.Font = new System.Drawing.Font("メイリオ", 12);    // フォント設定
            // dgv.ScrollBars = false;                                                                  // スクロールバー非表示
            dgv.MultiSelect = false;                                                                    // 
            dgv.ReadOnly = true;                                                                        // 
            dgv.AllowUserToAddRows = false;                                                             // 
            dgv.RowHeadersVisible = false;                                                              // 
            dgv.Columns["FileName"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;              // 

            // セルの文字表示位置
            DataGridViewCellStyle columnHeaderStyle = dgv.ColumnHeadersDefaultCellStyle;
            columnHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Rows.Add();                                                                             // 行追加
            dgv.Rows[0].Cells["FileName"].Value = ClsPublic.stcConfig[0].FilePath;
            if (ClsPublic.stcConfig[1].FilePath != "")
            {
                dgv.Rows.Add();                                                                         // 行追加
                dgv.Rows[1].Cells["FileName"].Value = ClsPublic.stcConfig[1].FilePath;
            }

            dgv.Columns[0].ReadOnly = true;                                                             // 書き込み禁止
            dgv.CurrentCell = null;
        }
    }
}
