using FlockAppC.pubClass;
using FlockAppC.pubForm;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace FlockAppC.勤務表
{
    public partial class frmShiftPDF : Form
    {
        private string Output_path1 { get; set; }
        private string Output_path2 { get; set; }
        private string Output_file1 { get; set; }
        private string Output_file2 { get; set; }


        public frmShiftPDF()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 画面表示
        /// </summary>
        private void DisplayForm()
        {
            int year, month;

            // 勤務表実行設定取得
            ClsPublic.GetConfig();

            this.Output_path1 = "";
            this.Output_path2 = "";
            this.Output_file1 = "";
            this.Output_file2 = "";

            // 変換対象チェックボックス
            this.chkSelect1.Checked = true;
            this.chkSelect2.Checked = false;

            using (ClsMsExcel cls = new())
            {
                // 当月
                if (ClsPublic.stcConfig[0].FileName != "")
                {
                    // 実行情報表示
                    this.txtFileName1.Text = ClsPublic.stcConfig[0].FilePath;
                    // シート一覧取得
                    // string[] ret = cls.GetSheetList(clsPublic.stcConfig[0].filePath, sheetList);
                    string[] ret = cls.GetSheetList(ClsPublic.stcConfig[0].FilePath);
                    for (int i = 0; i < ret.Length - 1; i++)
                    {
                        // コンボボックスにセット
                        if (ret[i] != "") { this.cmbSheetName1.Items.Add(ret[i]); }
                        else { break; }
                    }
                    this.cmbSheetName1.Text = ClsPublic.stcConfig[0].SheetName;
                    year = (int)ClsPublic.stcConfig[0].Year;
                    month = (int)ClsPublic.stcConfig[0].Month;

                    Output_path1 = ClsPublic.pubRootPath + ClsPublic.pubAppPath + @"\PDF\";
                    Output_file1 = DateTime.Now.ToString("yyyyMMddhhmm") + Path.GetFileName(this.txtFileName1.Text).Replace("xlsx", "PDF");
                    this.txtOutputPath1.Text = Output_path1;
                }

                // 翌月
                // ファイル名が未設定の場合は翌月はまだ未設定と判断
                if (ClsPublic.stcConfig[1].FilePath != "")
                {
                    // 実行情報表示
                    this.txtFileName2.Text = ClsPublic.stcConfig[1].FilePath;
                    // シート一覧取得
                    // string[] ret = cls.GetSheetList(clsPublic.stcConfig[1].filePath, sheetList);
                    string[] ret = cls.GetSheetList(ClsPublic.stcConfig[1].FilePath);
                    for (int i = 0; i < ret.Length - 1; i++)
                    {
                        // コンボボックスにセット
                        if (ret[i] != "") { this.cmbSheetName2.Items.Add(ret[i]); }
                        else { break; }
                    }
                    this.cmbSheetName2.Text = ClsPublic.stcConfig[1].SheetName;

                    Output_path2 = ClsPublic.pubRootPath + ClsPublic.pubAppPath + @"\PDF\";
                    Output_file2 = DateTime.Now.ToString("yyyyMMddhhmm") + Path.GetFileName(this.txtFileName2.Text).Replace("xlsx", "PDF");
                    this.txtOutputPath2.Text = Output_path2;
                }
                else
                {
                    // 翌月未設定の場合
                    this.txtOutputPath2.Text = "";
                    this.txtFileName2.Enabled = false;
                    this.cmbSheetName2.Enabled = false;
                    this.txtOutputPath2.Enabled = false;
                    this.btnSelect2.Enabled = false;
                    this.chkSelect2.Enabled = false;
                }
            }
        }

        private void frmShiftPDF_Load(object sender, EventArgs e)
        {
            // ================================================================
            // 処理中メッセージボックス
            // ================================================================
            frmMessageBox frmMsg = new()
            {
                F_size_height = 95,
                F_button_case = 0,
                L_value = "読み込み中 ....."
            };
            frmMsg.Show();
            frmMsg.Refresh();
            // 画面表示
            DisplayForm();
            frmMsg.Close();
            // 表示位置
            this.Location = new Point(0, 0);
        }
        /// <summary>
        /// 出力先指定ボタン（当月）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect1_Click(object sender, EventArgs e)
        {
            // OpenFileDialog のインスタンスを作成
            OpenFileDialog openFileDialog = new();

            // ファイル名を除いたパスをセット
            openFileDialog.InitialDirectory = this.txtOutputPath1.Text;

            // フィルタ（表示するファイルの種類を指定）
            openFileDialog.Filter = "すべてのファイル (*.*)|*.*|テキスト ファイル (*.xlsx)|*.xlsx";

            // ダイアログを表示
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 選択されたファイルパスを取得
                string selectedFilePath = openFileDialog.FileName;
                this.txtOutputPath1.Text = selectedFilePath;
                // MessageBox.Show("選択されたファイル: " + selectedFilePath);
            }
        }
        /// <summary>
        /// 出力先指定ボタン（翌月）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect2_Click(object sender, EventArgs e)
        {
            // OpenFileDialog のインスタンスを作成
            OpenFileDialog openFileDialog = new();

            // ファイル名を除いたパスをセット
            openFileDialog.InitialDirectory = this.txtOutputPath2.Text;

            // フィルタ（表示するファイルの種類を指定）
            openFileDialog.Filter = "すべてのファイル (*.*)|*.*|テキスト ファイル (*.xlsx)|*.xlsx";

            // ダイアログを表示
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 選択されたファイルパスを取得
                string selectedFilePath = openFileDialog.FileName;
                this.txtOutputPath2.Text = selectedFilePath;
                // MessageBox.Show("選択されたファイル: " + selectedFilePath);
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
        }
        /// <summary>
        /// PDF変換出力
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReg_Click(object sender, EventArgs e)
        {
            // 出力指定内容チェック
            if (this.chkSelect1.Checked == false && this.chkSelect2.Checked == false)
            {
                this.chkSelect1.Checked = false;
                MessageBox.Show("変換するファイルが選択されていません。", "警告", MessageBoxButtons.OK);
                return;
            }
            if (this.txtFileName1.Text == "" && this.chkSelect1.Checked == true)
            {
                this.chkSelect1.Checked = false;
                MessageBox.Show("当月の変換するファイルが指定されていません。", "警告", MessageBoxButtons.OK);
                return;
            }
            if (this.txtFileName2.Text == "" && this.chkSelect2.Checked == true)
            {
                this.chkSelect2.Checked = false;
                MessageBox.Show("翌月の変換するファイルが指定されていません。", "警告", MessageBoxButtons.OK);
                return;
            }

            // ================================================================
            // 処理中メッセージボックス
            // ================================================================
            frmMessageBox frmMsg = new()
            {
                F_size_height = 95,
                F_button_case = 0,
                L_value = "変換中 ....."
            };
            frmMsg.Show();
            frmMsg.Refresh();

            // PDF変換処理
            ChangePDF();

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
                L_value = "PDF変換が終了しました。"
            };
            frmMsg.ShowDialog();
            frmMsg.Dispose();
        }
        /// <summary>
        /// PDF変換
        /// </summary>
        private void ChangePDF()
        {
            string outputFile;

            // Excel アプリケーションのインスタンスを作成
            Excel.Application excelApp = new();

            if (this.chkSelect1.Checked == true)
            {
                // ================================================================
                // 当月
                // ================================================================
                // Excel ファイルを開く
                Excel.Workbook workbook1 = excelApp.Workbooks.Open(this.txtFileName1.Text);
                // 出力する PDF のパス
                outputFile = Output_path1 + Output_file1;
                // Excel ファイルを PDF として保存
                workbook1.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, outputFile);
                // Excel を終了
                workbook1.Close(false);
            }
            if (this.chkSelect2.Checked == true)
            {
                // ================================================================
                // 翌月
                // ================================================================
                // Excel ファイルを開く
                Excel.Workbook workbook2 = excelApp.Workbooks.Open(this.txtFileName2.Text);
                // 出力する PDF のパス
                outputFile = Output_path2 + Output_file2;
                // Excel ファイルを PDF として保存
                workbook2.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, outputFile);
                // Excel を終了
                workbook2.Close(false);
            }
            excelApp.Quit();
        }
    }
}
