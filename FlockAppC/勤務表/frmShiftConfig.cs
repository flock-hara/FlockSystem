using FlockAppC.pubClass;
using FlockAppC.pubForm;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FlockAppC.勤務表
{
    public partial class frmShiftConfig : Form
    {
        private readonly StringBuilder sb = new();

        public frmShiftConfig()
        {
            InitializeComponent();
        }
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmShiftConfig_Load(object sender, EventArgs e)
        {
            int year = 0, month = 0;

            // ================================================================
            // 処理中メッセージボックス
            // ================================================================
            frmMessageBox frmMsg = new()
            {
                F_size_height = 95,
                F_button_case = 0,
                L_value = "読み込み中 .....",
            };
            frmMsg.Show();
            frmMsg.Refresh();

            // 勤務表実行設定取得
            ClsPublic.GetConfig();

            using (ClsMsExcel cls = new())
            {
                // 当月
                if (ClsPublic.stcConfig[0].FileName != "")
                {
                    // ファイルロックチェック
                    if (ClsPublic.CheckFile(ClsPublic.stcConfig[0].FilePath) != 0)
                    {
                        MessageBox.Show("ファイルが存在しない、または使用中の可能性があります。[" + ClsPublic.stcConfig[0].FileName + "]", "確認", MessageBoxButtons.OK);
                        frmMsg.Close();
                        this.Close();
                        return;
                    }

                    // 実行情報表示
                    this.txtYear1.Text = ClsPublic.stcConfig[0].Year.ToString();
                    this.txtMonth1.Text = ClsPublic.stcConfig[0].Month.ToString();
                    this.txtFileName1.Text = ClsPublic.stcConfig[0].FilePath;
                    // シート一覧取得
                    string[] ret = cls.GetSheetList(ClsPublic.stcConfig[0].FilePath);
                    for (int i= 0; i < ret.Length-1; i++)
                    {
                        // コンボボックスにセット
                        if (ret[i] != "") { this.cmbSheetName1.Items.Add(ret[i]); }
                        else { break; }
                    }
                    this.cmbSheetName1.Text = ClsPublic.stcConfig[0].SheetName;
                    this.txtReView.Text = ClsPublic.stcConfig[0].RefreshTimer;
                    year = (int)ClsPublic.stcConfig[0].Year;
                    month = (int)ClsPublic.stcConfig[0].Month;
                }
                // 翌月
                // ファイル名が未設定の場合は翌月はまだ未設定と判断
                if (ClsPublic.stcConfig[1].FilePath != "")
                {
                    // ファイルロックチェック
                    if (ClsPublic.CheckFile(ClsPublic.stcConfig[1].FilePath) != 0)
                    {
                        MessageBox.Show("ファイルが存在しない、または使用中の可能性があります。[" + ClsPublic.stcConfig[1].FileName + "]", "確認", MessageBoxButtons.OK);
                        frmMsg.Close();
                        this.Close();
                        return;
                    }

                    // 実行情報表示
                    this.txtYear2.Text = ClsPublic.stcConfig[1].Year.ToString();
                    this.txtMonth2.Text = ClsPublic.stcConfig[1].Month.ToString();
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
                }
                else
                {
                    // 当月が12月の場合は、翌年、1月をセット
                    if (month == 12) { year++; month = 1; }
                    else { month++; }
                    this.txtYear2.Text = year.ToString();
                    this.txtMonth2.Text = month.ToString();
                    // ファイル名を除いたパスを表示
                    this.txtFileName2.Text = this.txtFileName1.Text.Replace(Path.GetFileName(txtFileName1.Text), "");
                }
            }
            // 表示位置
            this.Location = new System.Drawing.Point(0, 0);

            frmMsg.Close();
        }
        /// <summary>
        /// ファイル選択ボタン（当月）　クリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect1_Click(object sender, EventArgs e)
        {
            // OpenFileDialog のインスタンスを作成
            OpenFileDialog openFileDialog = new()
            {
                // ファイル名を除いたパスをセット
                InitialDirectory = this.txtFileName1.Text.Replace(Path.GetFileName(this.txtFileName1.Text), ""),
                // フィルタ（表示するファイルの種類を指定）
                Filter = "すべてのファイル (*.*)|*.*|テキスト ファイル (*.xlsx)|*.xlsx"
            };

            // ダイアログを表示
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 選択されたファイルパスを取得
                string selectedFilePath = openFileDialog.FileName;
                this.txtFileName1.Text = selectedFilePath;
                // MessageBox.Show("選択されたファイル: " + selectedFilePath);

                SetSheetComboBox(txtFileName1.Text, 0);
            }
        }
        /// <summary>
        /// ファイル選択ボタン（翌月）　クリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect2_Click(object sender, EventArgs e)
        {
            // OpenFileDialog のインスタンスを作成
            OpenFileDialog openFileDialog = new();

            // ファイル名を除いたパスをセット
            if (Path.GetFileName(this.txtFileName2.Text) != "")
            {
                openFileDialog.InitialDirectory = this.txtFileName2.Text.Replace(Path.GetFileName(this.txtFileName2.Text), "");
            }
            else
            {
                openFileDialog.InitialDirectory = this.txtFileName2.Text;
            }

            // フィルタ（表示するファイルの種類を指定）
            openFileDialog.Filter = "すべてのファイル (*.*)|*.*|テキスト ファイル (*.xlsx)|*.xlsx";

            // ダイアログを表示
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 選択されたファイルパスを取得
                string selectedFilePath = openFileDialog.FileName;
                this.txtFileName2.Text = selectedFilePath;
                // MessageBox.Show("選択されたファイル: " + selectedFilePath);

                SetSheetComboBox(txtFileName2.Text, 1);
            }
        }
        /// <summary>
        /// 閉じるボタン　クリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 保存ボタン　クリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReg_Click(object sender, EventArgs e)
        {
            // =======================================================
            // 入力内容チェック（当月）
            // =======================================================
            if (this.txtYear1.Text == "") { MessageBox.Show("当月の「年」を入力してください。", "入力漏れ", MessageBoxButtons.OK); return; }
            if (this.txtMonth1.Text == "") { MessageBox.Show("当月の「月」を入力してください。", "入力漏れ", MessageBoxButtons.OK); return; }
            if (this.txtFileName1.Text == "") { MessageBox.Show("当月の「勤務表ファイル」を選択してください。", "選択漏れ", MessageBoxButtons.OK); return; }
            if (this.cmbSheetName1.Text == "") { MessageBox.Show("当月の「勤務表のシート」を選択してください。", "選択漏れ", MessageBoxButtons.OK); return; }
            // =======================================================
            // 入力内容チェック（翌月）
            // =======================================================
            if (this.cmbSheetName2.Text != "")
            {
                if (this.txtYear2.Text == "") { MessageBox.Show("翌月の「年」を入力してください。", "入力漏れ", MessageBoxButtons.OK); return; }
                if (this.txtMonth2.Text == "") { MessageBox.Show("翌月の「月」を入力してください。", "入力漏れ", MessageBoxButtons.OK); return; }
                if (this.txtFileName2.Text == "") { MessageBox.Show("翌月の「勤務表ファイル」を選択してください。", "選択漏れ", MessageBoxButtons.OK); return; }
                if (this.cmbSheetName2.Text == "") { MessageBox.Show("翌月の「勤務表のシート」を選択してください。", "選択漏れ", MessageBoxButtons.OK); return; }
            }


            // =======================================================
            // 当月更新
            // =======================================================
            // 開始、終了日付取得
            ClsPublic.pStartYear = int.Parse(this.txtYear1.Text);
            ClsPublic.pStartMonth = int.Parse(this.txtMonth1.Text);
            ClsPublic.GetSEDate();

            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("UPDATE");
                    sb.AppendLine("Mst_勤務表環境設定");
                    sb.AppendLine("SET");
                    sb.AppendLine(" file_path = '" + this.txtFileName1.Text + "'");
                    sb.AppendLine(",file_name = '" + Path.GetFileName(this.txtFileName1.Text) + "'");
                    sb.AppendLine(",sheet_name = '" + this.cmbSheetName1.Text + "'");
                    sb.AppendLine(",refresh_timer = " + this.txtReView.Text);
                    sb.AppendLine(",year = " + this.txtYear1.Text);
                    sb.AppendLine(",month = " + this.txtMonth1.Text);
                    sb.AppendLine(",start_date = '" + ClsPublic.pStartDate.ToString("yyyy/MM/dd") + "'");
                    sb.AppendLine(",end_date = '" + ClsPublic.pEndDate.ToString("yyyy/MM/dd") + "'");
                    sb.AppendLine(",update_flag = " + ClsPublic.FLAG_ON);
                    // 2025/11/12↓
                    sb.AppendLine(",upd_user_id = " + ClsLoginUser.StaffID);
                    sb.AppendLine(",upd_date = '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    // 2025/11/12↑
                    sb.AppendLine("WHERE");
                    sb.AppendLine("id = 1");

                    clsSqlDb.DMLUpdate(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            // =======================================================
            // 翌月更新
            // =======================================================
            if (cmbSheetName2.Text.Replace(" ","") != "")
            {
                // 翌月設定あり
                // 開始、終了日付取得
                ClsPublic.pStartYear = int.Parse(this.txtYear2.Text);
                ClsPublic.pStartMonth = int.Parse(this.txtMonth2.Text);
                ClsPublic.GetSEDate();

                // 翌月のレコード存在チェック
                try
                {
                    using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                    {
                        sb.Clear();
                        sb.AppendLine("SELECT");
                        sb.AppendLine(" id");
                        sb.AppendLine("FROM");
                        sb.AppendLine(" Mst_勤務表環境設定");
                        sb.AppendLine("WHERE");
                        sb.AppendLine(" id = 2");                    // 翌月分

                        using (System.Data.DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                        {
                            if (dt_val.Rows.Count > 0)
                            {
                                // 翌月レコードあり
                                sb.Clear();
                                sb.AppendLine("UPDATE");
                                sb.AppendLine(" Mst_勤務表環境設定");
                                sb.AppendLine("SET");
                                sb.AppendLine(" file_path = '" + this.txtFileName2.Text + "'");
                                sb.AppendLine(",file_name = '" + Path.GetFileName(this.txtFileName2.Text) + "'");
                                sb.AppendLine(",sheet_name = '" + this.cmbSheetName2.Text + "'");
                                sb.AppendLine(",refresh_timer = '" + this.txtReView.Text + "'");
                                sb.AppendLine(",year = " + this.txtYear2.Text);
                                sb.AppendLine(",month = " + this.txtMonth2.Text);
                                sb.AppendLine(",start_date = '" + ClsPublic.pStartDate.ToString("yyyy/MM/dd") + "'");
                                sb.AppendLine(",end_date = '" + ClsPublic.pEndDate.ToString("yyyy/MM/dd") + "'");
                                sb.AppendLine(",update_flag = " + ClsPublic.FLAG_ON);
                                // 2025/11/12↓
                                sb.AppendLine(",upd_user_id = " + ClsLoginUser.StaffID);
                                sb.AppendLine(",upd_date = '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                                // 2025/11/12↑
                                sb.AppendLine("WHERE");
                                sb.AppendLine("id = 2");

                                clsSqlDb.DMLUpdate(sb.ToString());
                            }
                            else
                            {
                                // 翌月レコードなし
                                sb.Clear();
                                sb.AppendLine("INSERT INTO");
                                sb.AppendLine(" Mst_勤務表環境設定");
                                sb.AppendLine("(");
                                sb.AppendLine(" id");
                                sb.AppendLine(",file_path");
                                sb.AppendLine(",file_name");
                                sb.AppendLine(",sheet_name");
                                sb.AppendLine(",refresh_timer");
                                sb.AppendLine(",year");
                                sb.AppendLine(",month");
                                sb.AppendLine(",start_date");
                                sb.AppendLine(",end_date");
                                // 2025/11/12↓
                                sb.AppendLine(",ins_user_id");
                                sb.AppendLine(",ins_date");
                                sb.AppendLine(",delete_flag");
                                // 2025/11/12↑
                                sb.AppendLine(") VALUES (");
                                sb.AppendLine("2");
                                sb.AppendLine(",'" + this.txtFileName2.Text + "'");
                                sb.AppendLine(",'" + Path.GetFileName(this.txtFileName2.Text) + "'");
                                sb.AppendLine(",'" + this.cmbSheetName2.Text + "'");
                                sb.AppendLine(",'" + this.txtReView.Text + "'");
                                sb.AppendLine("," + this.txtYear2.Text);
                                sb.AppendLine("," + this.txtMonth2.Text);
                                sb.AppendLine(",'" + ClsPublic.pStartDate.ToString("yyyy/MM/dd") + "'");
                                sb.AppendLine(",'" + ClsPublic.pEndDate.ToString("yyyy/MM/dd") + "'");
                                // 2025/11/12↓
                                sb.AppendLine("," + ClsLoginUser.StaffID);
                                sb.AppendLine(",'" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                                sb.AppendLine("," + ClsPublic.FLAG_OFF);
                                // 2025/11/12↑
                                sb.AppendLine(")");
                            }
                            clsSqlDb.DMLUpdate(sb.ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
            else
            {
                // 翌月の空レコード登録
                try
                {
                    using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                    {
                        // レコード削除（念のため）
                        sb.Clear();
                        sb.AppendLine("DELETE");
                        sb.AppendLine("FROM");
                        sb.AppendLine("Mst_勤務表環境設定");
                        sb.AppendLine("WHERE");
                        sb.AppendLine("id = 2");

                        clsSqlDb.DMLUpdate(sb.ToString());

                        // 空レコード登録
                        sb.Clear();
                        sb.AppendLine("INSERT INTO");
                        sb.AppendLine("Mst_勤務表環境設定");
                        sb.AppendLine("(");
                        sb.AppendLine(" id");
                        sb.AppendLine(",file_path");
                        sb.AppendLine(",file_name");
                        sb.AppendLine(",sheet_name");
                        sb.AppendLine(",refresh_timer");
                        sb.AppendLine(",year");
                        sb.AppendLine(",month");
                        sb.AppendLine(",start_date");
                        sb.AppendLine(",end_date");
                        // 2025/11/12↓
                        sb.AppendLine(",ins_user_id");
                        sb.AppendLine(",ins_date");
                        sb.AppendLine(",delete_flag");
                        // 2025/11/12↑
                        sb.AppendLine(") VALUES (");
                        sb.AppendLine("2");
                        sb.AppendLine(",''");
                        sb.AppendLine(",''");
                        sb.AppendLine(",''");
                        sb.AppendLine(",'5'");          // RefreshTimer 2025/04/25 UPD
                        sb.AppendLine(",0");
                        sb.AppendLine(",0");
                        sb.AppendLine(",'1900-01-01'"); // StartDate 2025/04/25 ADD
                        sb.AppendLine(",'1900-01-01'"); // EndDate   2025/04/25 ADD
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
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }

            // 勤務表変更フラグ更新
            // clsPublic.UpdateShiftFlag(clsPublic.FLAG_ON);

            MessageBox.Show("保存しました。", "結果", MessageBoxButtons.OK);
        }

        /// <summary>
        /// 定ファイルのシート一覧を取得しコンボボックスにセット
        /// </summary>
        /// <param name="p_filename"></param>
        /// <param name="p_i">0:当月/1:翌月</param>
        private void SetSheetComboBox(string p_filename,int p_i)
        {
            this.cmbSheetName1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbSheetName2.DropDownStyle = ComboBoxStyle.DropDownList;

            // string[] sheetList = { "", "", "", "", "", "", "", "", "", "" };

            if (p_i == 0)
            {
                this.cmbSheetName1.Items.Clear();
            }
            else
            {
                this.cmbSheetName2.Items.Clear();
            }

            using (ClsMsExcel clsEx = new())
            {
                // シート一覧取得
                string[] ret = clsEx.GetSheetList(p_filename);
                for (var i = 0; i < ret.Length - 1; i++)
                {
                    if (p_i == 0)
                    {
                        // コンボボックスにセット：当月
                        if (ret[i] != "") { this.cmbSheetName1.Items.Add(ret[i]); }
                        else { break; }
                    }
                    else
                    {
                        // コンボボックスにセット：翌月
                        if (ret[i] != "") { this.cmbSheetName2.Items.Add(ret[i]); }
                        else { break; }
                    }
                }
            }
        }
    }
}
