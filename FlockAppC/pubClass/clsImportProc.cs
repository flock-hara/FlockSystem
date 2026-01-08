using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FlockAppC.pubClass
{
    public class ClsImportProc
    {
        // 読み込みデータ保持用
        ClsImport[,] cImp;

        private readonly StringBuilder sb = new();

        /// <summary>
        /// 勤務表インポートメイン
        /// </summary>
        public void Import()
        {
            // 勤務表環境設定値取得
            ClsPublic.GetConfig();

            // 勤務表（ｴｸｾﾙ）読込
            for (var i = 0; i <= 1; i++)
            {
                ReadSchedule(i);
            }
        }
        /// <summary>
        /// 勤務表（ｴｸｾﾙ）読込
        /// </summary>
        /// <param name="p_i">環境設定保持クラスインデックス</param>
        private void ReadSchedule(int p_i)
        {
            // DELETE エラー時のリカバリ情報
            var err_flag = false;
            var year = 0;
            var month = 0;

            // ファイル名:未設定の場合は処理終了
            if (ClsPublic.stcConfig[p_i].FilePath == "") { return; }

            #region "インポートデータ保持領域初期化"
            // =========================================================
            // インポートデータ保持領域初期化([36] x [26])
            // =========================================================
            cImp = new ClsImport[ClsPublic.EXCEL_MAX_ROW, ClsPublic.EXCEL_MAX_COL];
            // 行数分
            for (var row = 0; row <= ClsPublic.EXCEL_MAX_ROW-1; row++)
            {
                // 列数分
                for(var col = 0; col <= ClsPublic.EXCEL_MAX_COL-1; col++)
                {
                    // インポートデータ格納用クラス
                    // 初期値セット
                    cImp[row, col] = new ClsImport
                    {
                        ImportDate = DateTime.Now,                                                   // インポート日付
                        TantoId = 0,                                                                 // 担当者ID
                        TantoName = "",                                                              // 担当者名
                        Day = DateTime.Parse(ClsPublic.DEF_DATE),                                    // 勤務表予定日付
                        StartDate = DateTime.Parse(ClsPublic.stcConfig[p_i].StartDate),              // 月初日
                        EndDate = DateTime.Parse(ClsPublic.stcConfig[p_i].EndDate),                  // 月末日
                        FileName = ClsPublic.stcConfig[p_i].FileName,                                // ファイル名(エクセル)
                        FilePath = ClsPublic.stcConfig[p_i].FilePath,                                // パス月ファイル名
                        SheetName = ClsPublic.stcConfig[p_i].SheetName,                              // シート名
                        Year = ClsPublic.stcConfig[p_i].Year,                                        // 対象年
                        Month = ClsPublic.stcConfig[p_i].Month,                                      // 対象月
                        BackColor = ClsPublic.KIN_BACK_COLOR,                                        // セル：バックカラー
                        FontName = ClsPublic.KIN_FONT_NAME,                                          // セル：フォント名
                        FontSize = ClsPublic.KIN_FONT_SIZE,                                          // セル：フォントサイズ
                        FontColor = ClsPublic.KIN_FONT_COLOR,                                        // セル：フォントカラー
                        FontBold = ClsPublic.KIN_FONT_BOLD,                                          // セル：太字
                        FontItalic = ClsPublic.KIN_FONT_ITALIC,                                      // セル：イタリック
                        Value = "",                                                                  // セル：値
                        Text = "",                                                                   // セル：表示文字
                        Comment = "",                                                                // 備考
                        ContactFlag = 0,                                                             // 連絡済みフラグ
                        Row = row + 1,                                                               // セル：行
                        Col = col + 1                                                                // セル：列
                    };

                    //// 初期値セット
                    //cImp[row, col].ImportDate = DateTime.Now;                                                   // インポート日付
                    //cImp[row, col].TantoId = 0;                                                                 // 担当者ID
                    //cImp[row, col].TantoName = "";                                                              // 担当者名
                    //cImp[row, col].Day = DateTime.Parse(clsPublic.DEF_DATE);                                    // 勤務表予定日付
                    //cImp[row, col].StartDate = DateTime.Parse(clsPublic.stcConfig[p_i].StartDate);              // 月初日
                    //cImp[row, col].EndDate = DateTime.Parse(clsPublic.stcConfig[p_i].EndDate);                  // 月末日
                    //cImp[row, col].FileName = clsPublic.stcConfig[p_i].FileName;                                // ファイル名(エクセル)
                    //cImp[row, col].FilePath = clsPublic.stcConfig[p_i].FilePath;                                // パス月ファイル名
                    //cImp[row, col].SheetName = clsPublic.stcConfig[p_i].SheetName;                              // シート名
                    //cImp[row, col].Year = clsPublic.stcConfig[p_i].Year;                                        // 対象年
                    //cImp[row, col].Month = clsPublic.stcConfig[p_i].Month;                                      // 大量月
                    //cImp[row, col].BackColor = clsPublic.KIN_BACK_COLOR;                                        // セル：バックカラー
                    //cImp[row, col].FontName = clsPublic.KIN_FONT_NAME;                                          // セル：フォント名
                    //cImp[row, col].FontSize = clsPublic.KIN_FONT_SIZE;                                          // セル：フォントサイズ
                    //cImp[row, col].FontColor = clsPublic.KIN_FONT_COLOR;                                        // セル：フォントカラー
                    //cImp[row, col].FontBold = clsPublic.KIN_FONT_BOLD;                                          // セル：太字
                    //cImp[row, col].FontItalic = clsPublic.KIN_FONT_ITALIC;                                      // セル：イタリック
                    ////cImp[row, col].backColor = "";
                    ////cImp[row, col].fontName = "游明朝";
                    ////cImp[row, col].fontSize = 36;
                    ////cImp[row, col].fontColor = "Black";
                    ////cImp[row, col].fontBold = "普通";
                    ////cImp[row, col].fontItalic = "普通";
                    //cImp[row, col].Value = "";                                                                  // セル：値
                    //cImp[row, col].Text = "";                                                                   // セル：表示文字
                    //cImp[row, col].Comment = "";                                                                // 備考
                    //cImp[row, col].ContactFlag = 0;                                                             // 連絡済みフラグ
                    //cImp[row, col].Row = row + 1;                                                               // セル：行
                    //cImp[row, col].Col = col + 1;                                                               // セル：列
                }
            }
            #endregion

            try
            {
                var row = 0;            // 作業用ROW
                var col = 0;            // 作業用COL
                var max_row = 0;        // MAX行番号
                var max_col = 0;        // MAX列番号

                // ｴｸｾﾙ操作
                using (ClsMsExcel cEx = new())
                {
                    #region "勤務表ファイルチェック"
                    // =======================================================================
                    // 勤務表ファイルチェック
                    // =======================================================================
                    var rtn = ClsPublic.CheckFile(ClsPublic.stcConfig[p_i].FilePath);
                    if (rtn == 1)
                    {
                        MessageBox.Show("ファイルが存在しません。", "エラー", MessageBoxButtons.OK);
                        return;
                    }
                    else if (rtn == 2)
                    {
                        MessageBox.Show("ファイルが既に開かれています。", "エラー", MessageBoxButtons.OK);
                        return;
                    }
                    if (ClsPublic.IsFileLocked(ClsPublic.stcConfig[p_i].FilePath) == true)
                    {
                        MessageBox.Show("ファイルがロックされています。", "エラー", MessageBoxButtons.OK);
                        return;
                    }
                    #endregion

                    #region "勤務表ファイルオープン"
                    // =======================================================================
                    // 勤務表ファイルオープン
                    // =======================================================================
                    cEx.FileName = ClsPublic.stcConfig[p_i].FilePath;
                    cEx.SheetName = ClsPublic.stcConfig[p_i].SheetName;
                    cEx.OpenBook();
                    #endregion

                    #region "MAX 行、列取得 (max_row, max_col)"
                    // =======================================================================
                    // Max Row/Col取得
                    // =======================================================================
                    // 月末日取得
                    var end_day = DateTime.Parse(ClsPublic.stcConfig[p_i].EndDate).ToString("yyyy/MM/dd");

                    // ROW
                    // 月末日が出た行をMAXとする（開始は時短の為終盤から）※MAX35は固定
                    for (row = 30; row <= 35; row++)
                    {
                        // セル値取得
                        cEx.Row = row;          // 行番号
                        cEx.Col = 1;            // 日付列は1列目
                        cEx.GetCell();          // 値取得

                        // 取得した日付を変換
                        var read_day = DateTime.Parse(cEx.Value2).ToString("yyyy/MM/dd");

                        // 月末日と比較
                        if (read_day == end_day)
                        {
                            // 一致する場合は最終行とみなす
                            break;
                        }
                    }
                    // MAX行数セット
                    max_row = row;

                    // COL
                    // 担当者名がセットされている列数を求める
                    // 文字「日・曜日」が出た列をMAXとする（開始は時短の為終盤から）
                    for (col = 17; col <= ClsPublic.EXCEL_MAX_COL-1; col++)
                    {
                        cEx.Row = 3;                            // 担当者設定セル行番号(3固定)
                        cEx.Col = col;                          // セル列番号
                        cEx.GetCell();                          // セル値取得

                        // 列最終判定
                        if (cEx.Value.Trim() == ClsPublic.COL_END)
                        {
                            break;
                        }
                        //if (cEx.Value.Trim() == "日・曜日")
                        //{
                        //    break;
                        //}
                    }
                    // MAX列数セット
                    max_col = col - 1;
                    #endregion

                    #region "担当者ID取得、保持"
                    // =======================================================================
                    // 担当者
                    // =======================================================================
                    // l 日  l 備  l 名
                    // l 0/0 l 0/1 l 0/2
                    // l 1/0 l 1/1 l 1/2
                    var col_idx = 1;
                    var row_idx = 0;
                    //var col_idx = 0;
                    //var row_idx = 0;

                    // DB接続
                    // 2025/08/26 UPD
                    // using (clsDb cDb = new clsDb(clsPublic.DBNo))
                    using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                    {
                        // System.Data.DataTable dt;
                        // col_idx = 1;
                        // row_idx = 0;

                        // 担当者名は5列目から記載(固定)
                        for (col = 5; col <= max_col; col++)
                        {
                            // 担当者名は3行目に記載
                            row_idx = 3;                    // 担当者名の行番号(固定)
                            cEx.Row = row_idx;              // セル行番号
                            cEx.Col = col;                  // セル列番号
                            cEx.GetCell();                  // セル値取得

                            // 担当者ID取得
                            sb.Clear();
                            sb.AppendLine("SELECT");
                            sb.AppendLine(" staff_id");
                            sb.AppendLine(",id");
                            sb.AppendLine(",name1");
                            sb.AppendLine("FROM");
                            sb.AppendLine("Mst_社員");
                            sb.AppendLine("WHERE");
                            // sb.AppendLine("zai_flag = 1");                  2026/01/08 UPD
                            sb.AppendLine("delete_flag != " + ClsPublic.FLAG_ON);
                            sb.AppendLine("AND");
                            sb.AppendLine("proxy_flag = " + ClsPublic.FLAG_ON);                // 代務
                            sb.AppendLine("AND");
                            sb.AppendLine("name1 = '" + cEx.Value + "'");  // 氏名（苗字）

                            // 2025/08/26 DEL
                            // cDb.Sql = stb.ToString();
                            // cDb.DMLSelect();
                            // dt = new DataTable();
                            // dt = cDb.dt;
                            using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                            {
                                foreach (DataRow dr in dt_val.Rows)
                                {
                                    // 担当者情報を保持用クラスにセット
                                    // Max行分セット
                                    for (row = 0; row <= max_row; row++)
                                    {
                                        cImp[row, col_idx].TantoId = int.Parse(dr["staff_id"].ToString());  // 担当者ID
                                        cImp[row, col_idx].TantoName = dr["name1"].ToString();              // 担当者名
                                        cImp[row, col_idx].Row = row_idx;                                   // セル行番号
                                        cImp[row, col_idx].Col = col;                                       // セル列番号
                                        row_idx++;
                                    }

                                    // =======================================================================
                                    // Col更新（Mst_社員、Trn_勤務表シフト変更）
                                    // =======================================================================
                                    sb.Clear();
                                    sb.AppendLine("UPDATE");
                                    sb.AppendLine("Mst_社員");
                                    sb.AppendLine("SET");
                                    sb.AppendLine("col = " + col);                 // 列番号
                                    sb.AppendLine("WHERE");
                                    sb.AppendLine("staff_id = " + dr["staff_id"]);

                                    // 2025/08/26 DEL
                                    // cDb.Sql = stb.ToString();
                                    // cDb.DMLUpdate();
                                    clsSqlDb.DMLUpdate(sb.ToString());

                                    sb.Clear();
                                    sb.AppendLine("UPDATE");
                                    sb.AppendLine("Trn_勤務表シフト変更");
                                    sb.AppendLine("SET");
                                    sb.AppendLine("col = " + col);                 // 列番号
                                    sb.AppendLine("WHERE");
                                    sb.AppendLine("tanto_id = " + dr["staff_id"]);

                                    // 2025/08/26 DEL
                                    // cDb.Sql = stb.ToString();
                                    // cDb.DMLUpdate();
                                    clsSqlDb.DMLUpdate(sb.ToString());
                                }
                            }
                            col_idx++;
                        }
                    }
                    #endregion

                    #region "セル日付、バックカラー取得、保持"
                    // =======================================================================
                    // 勤務表日付、BACKCOLOR取得
                    // =======================================================================
                    //日付部分
                    row_idx = 0;
                    col_idx = 0;
                    
                    // 勤務予定記載セル(4行目)～MAX行迄
                    for (row = 4; row <= max_row; row++)
                    {
                        cEx.Row = row;                              // セル行番号
                        cEx.Col = 1;                                // セル列番号(1列目のみ取得)
                        cEx.GetCell();                              // セル値取得

                        cImp[row_idx, 0].Value = cEx.Value;         // セル値
                        cImp[row_idx, 0].Row = row;                 // セル行番号保持
                        cImp[row_idx, 0].Col = 1;                   // セル列番号保持

                        // Max列まで処理
                        for (col = 0; col <= max_col; col++)
                        {
                            // セル情報保持
                            cImp[row_idx, col].BackColor = cEx.BackColor;           // バックカラー
                            cImp[row_idx, col].Day = DateTime.Parse(cEx.Value2);    // 日付
                        }
                        row_idx++;
                    }
                    #endregion

                    #region "備考取得、保持"
                    // =======================================================================
                    // 備考
                    // =======================================================================
                    row_idx = 0;

                    // 勤務予定記載セル(4行目)～MAX行迄
                    for (row = 4; row <= max_row; row++)
                    {
                        cEx.Row = row;                              // セル行番号
                        cEx.Col = 2;                                // セル列番号(2列目固定)
                        cEx.GetCell();                              // セル値取得

                        // 備考値判定
                        if (cEx.Value == "")
                        {
                            // 備考なし
                            cImp[row_idx, 0].FontColor = "Black";   // フォントカラー（初期値）保持
                            cImp[row_idx, 0].FontSize = 36;         // フォントサイズ（初期値）保持
                            cImp[row_idx, 0].FontBold = "普通";     // フォント太字（初期値）保持
                        }
                        else
                        {
                            // 備考あり
                            cImp[row_idx, 0].FontColor = cEx.FontColor;                         // フォントカラー保持
                            cImp[row_idx, 0].FontSize = int.Parse(cEx.FontSize.ToString());     // フォントサイズ保持
                            cImp[row_idx, 0].FontBold = cEx.FontBold;                           // フォント太字保持
                        }
                        cImp[row_idx, 0].Value = cEx.Value;             // セル値保持
                        cImp[row_idx, 0].Row = row;                     // セル行番号保持
                        cImp[row_idx, 0].Col = 2;                       // セル列番号保持
                        cImp[row_idx, 0].TantoName = "備考";            // 担当名称「備考」(固定)  
                        cImp[row_idx, 1].Day = cImp[row_idx, 0].Day;    // 日付保持

                        row_idx++;
                    }
                    #endregion

                    #region "勤務表予定取得、保持"
                    // =======================================================================
                    // シフト予定
                    // =======================================================================
                    row_idx = 0;
                    var num = 0;

                    // 4行目(予定記載開始行)～最終行迄
                    for (row = 4; row <= max_row; row++)
                    {
                        col_idx = 1;
                        // 5列目(予定記載開始列番号)～最終列迄
                        for (col = 5; col <= max_col; col++)
                        {
                            cEx.Row = row;              // セル行番号
                            cEx.Col = col;              // セル列番号
                            cEx.GetCell();              // セル値取得

                            // 予定チェック
                            if (cEx.Value == "")
                            {
                                // 予定なし
                                cImp[row_idx, col_idx].FontColor = "Black";                                     // フォントカラー（初期値）保持
                                cImp[row_idx, col_idx].FontSize = 36;                                           // フォントサイズ（初期値）保持
                                cImp[row_idx, col_idx].FontBold = "普通";                                       // フォント太字（初期値）保持 
                            }
                            else
                            {
                                // 予定あり
                                cImp[row_idx, col_idx].FontColor = cEx.FontColor;                               // フォントカラー保持
                                // フォントサイズチェック
                                if (int.TryParse(cEx.FontSize.ToString(), out num) != true)
                                {
                                    // 取得失敗
                                    cImp[row_idx, col_idx].FontSize = 36;                                       // 初期値を保持
                                }
                                else
                                {
                                    // 取得成功
                                    cImp[row_idx, col_idx].FontSize = int.Parse(cEx.FontSize.ToString());       // フォントサイズ保持
                                }
                                cImp[row_idx, col_idx].FontBold = cEx.FontBold;                                 // フォント太字保持
                            }

                            cImp[row_idx, col_idx].Row = row;                                                   // セル行番号保持
                            cImp[row_idx, col_idx].Col = col;                                                   // セル列番号保持
                            cImp[row_idx, col_idx].Value = cEx.Value;                                           // セル値保持
                            cImp[row_idx, col_idx].BackColor = cEx.BackColor;                                   // セルバックカラー保持

                            col_idx++;
                        }
                        row_idx++;
                    }
                    #endregion

                    cEx.CloseBook();
                }

                // =========================================================
                // 保持データをDBへ登録
                // =========================================================
                #region "レコード登録済み（インポート済み）チェック、レコード削除"
                // 既に取り込まれているか確認
                sb.Clear();
                sb.AppendLine("SELECT");
                sb.AppendLine("day");
                sb.AppendLine("FROM");
                sb.AppendLine("Trn_勤務表シフト情報");
                sb.AppendLine("WHERE");
                sb.AppendLine("year = " + ClsPublic.stcConfig[p_i].Year);          // 対象年
                sb.AppendLine("AND");
                sb.AppendLine("month = " + ClsPublic.stcConfig[p_i].Month);        // 対象月

                // DB接続
                // 2025/08/26 UPD
                // using (clsDb cDb = new clsDb(clsPublic.DBNo))
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    // 更新フラグ(true:登録済み/false:未登録)
                    var flg = false;

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            flg = true;
                            break;
                        }
                    }

                    #region "既存レコード削除"
                    // 読込済みの場合はレコードを削除
                    if (flg == true)
                    {
                        // 対象レコードをWrkテーブルに退避
                        // 退避用テーブルクリア
                        sb.Clear();
                        sb.AppendLine("DELETE");
                        sb.AppendLine("FROM");
                        sb.AppendLine("Trn_勤務表シフト情報_Wrk");
                        clsSqlDb.DMLUpdate(sb.ToString());

                        // 退避用テーブルへINSERT
                        sb.Clear();
                        sb.AppendLine("INSERT INTO Trn_勤務表シフト情報_Wrk");
                        sb.AppendLine("SELECT * FROM Trn_勤務表シフト情報");
                        sb.AppendLine("WHERE");
                        sb.AppendLine("year = " + ClsPublic.stcConfig[p_i].Year);          // 対象年
                        sb.AppendLine("AND");
                        sb.AppendLine("month = " + ClsPublic.stcConfig[p_i].Month);        // 対象月
                        clsSqlDb.DMLUpdate(sb.ToString());

                        // trueをセット→正常終了でfalseをセット
                        err_flag = true;
                        year = ClsPublic.stcConfig[p_i].Year;
                        month = ClsPublic.stcConfig[p_i].Month;
                        sb.Clear();
                        sb.AppendLine("DELETE");
                        sb.AppendLine("FROM");
                        sb.AppendLine("Trn_勤務表シフト情報");
                        sb.AppendLine("WHERE");
                        sb.AppendLine("year = " + ClsPublic.stcConfig[p_i].Year);          // 対象年
                        sb.AppendLine("AND");
                        sb.AppendLine("month = " + ClsPublic.stcConfig[p_i].Month);        // 対象月
                        clsSqlDb.DMLUpdate(sb.ToString());

                        // UPDATEは実施しない
                        flg = false;
                    }
                    // dt.Dispose();
                    #endregion
                }
                #endregion

                #region "インポートデータDB登録(INSERT)"
                // インポートデータINSERT
                // 2025/08/26 UPD
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    // 最終行迄処理
                    for (row = 0; row <= max_row; row++)
                    {
                        // 最終列迄処理
                        for (col = 0; col <= max_col; col++)
                        {
                            // 担当者名有り、日付が初期値以外の場合、レコードを登録
                            if (cImp[row, col].TantoName != "" && cImp[row, col].Day.ToString("yyyy/MM/dd") != "1900/01/01")
                            {
                                sb.Clear();
                                sb.AppendLine("INSERT INTO");
                                sb.AppendLine("Trn_勤務表シフト情報");
                                sb.AppendLine("(");
                                sb.AppendLine("import_date");
                                sb.AppendLine(",start_date");
                                sb.AppendLine(",end_date");
                                sb.AppendLine(",file_name");
                                sb.AppendLine(",file_path");
                                sb.AppendLine(",sheet_name");
                                sb.AppendLine(",day");
                                sb.AppendLine(",year");
                                sb.AppendLine(",month");
                                sb.AppendLine(",row");
                                sb.AppendLine(",col");
                                sb.AppendLine(",font_size");
                                sb.AppendLine(",font_color");
                                sb.AppendLine(",font_bold");
                                sb.AppendLine(",back_color");
                                sb.AppendLine(",value");
                                sb.AppendLine(",comment");
                                sb.AppendLine(",contact_flag");
                                sb.AppendLine(",tanto_id");
                                sb.AppendLine(",tanto_name");
                                sb.AppendLine(") VALUES (");
                                sb.AppendLine("'" + DateTime.Now.ToString("yyyy/MM/dd") + "'");

                                // 月初日
                                if (DateTime.TryParse(cImp[row,col].StartDate.ToString(), out DateTime dtVal) == true)
                                {
                                    sb.AppendLine(",'" + cImp[row, col].StartDate + "'");
                                }
                                else
                                {
                                    MessageBox.Show("月初日付が間違っています。[" + cImp[row, col].StartDate.ToString() + "]", "エラー", MessageBoxButtons.OK);
                                    return;
                                }
                                // 月末日
                                if (DateTime.TryParse(cImp[row, col].EndDate.ToString(), out dtVal) == true)
                                {
                                    sb.AppendLine(",'" + cImp[row, col].EndDate + "'");
                                }
                                else
                                {
                                    MessageBox.Show("月末日付が間違っています。[" + cImp[row, col].EndDate.ToString() + "]", "エラー", MessageBoxButtons.OK);
                                    return;
                                }

                                // ファイル名、パス付きファイル名
                                if (cImp[row, col].FileName.Length != 0)
                                {
                                    sb.AppendLine(",'" + cImp[row, col].FileName + "'");
                                }
                                else
                                {
                                    MessageBox.Show("ファイル名が間違っています。[" + cImp[row, col].FileName + "]", "エラー", MessageBoxButtons.OK);
                                    return;
                                }
                                if (cImp[row, col].FilePath.Length != 0)
                                {
                                    sb.AppendLine(",'" + cImp[row, col].FilePath + "'");
                                }
                                else
                                {
                                    MessageBox.Show("パス付きファイル名が間違っています。[" + cImp[row, col].FilePath + "]", "エラー", MessageBoxButtons.OK);
                                    return;
                                }
                                // シート名
                                if (cImp[row, col].SheetName.Length != 0)
                                {
                                    sb.AppendLine(",'" + cImp[row, col].SheetName + "'");
                                }
                                else
                                {
                                    MessageBox.Show("パス付きファイル名が間違っています。[" + cImp[row, col].SheetName + "]", "エラー", MessageBoxButtons.OK);
                                    return;
                                }

                                // 予定日付
                                if (DateTime.TryParse(cImp[row, col].Day.ToString(), out dtVal) == true)
                                {
                                    sb.AppendLine(",'" + cImp[row, col].Day + "'");
                                }
                                else
                                {
                                    MessageBox.Show("予定日付が間違っています。[" + cImp[row, col].Day.ToString() + "]", "エラー", MessageBoxButtons.OK);
                                    return;
                                }
                                // 対象年月
                                if (int.TryParse(cImp[row, col].Year.ToString(), out int intVal) == true)
                                {
                                    sb.AppendLine("," + cImp[row, col].Year);
                                }
                                else
                                {
                                    MessageBox.Show("対象年が間違っています。[" + cImp[row, col].Year.ToString() + "]", "エラー", MessageBoxButtons.OK);
                                    return;
                                }
                                if (int.TryParse(cImp[row, col].Month.ToString(), out intVal) == true)
                                {
                                    sb.AppendLine("," + cImp[row, col].Month);
                                }
                                else
                                {
                                    MessageBox.Show("対象月が間違っています。[" + cImp[row, col].Month.ToString() + "]", "エラー", MessageBoxButtons.OK);
                                    return;
                                }
                                // セル行番号
                                if (int.TryParse(cImp[row, col].Row.ToString(), out intVal) == true)
                                {
                                    sb.AppendLine("," + cImp[row, col].Row);
                                }
                                else
                                {
                                    MessageBox.Show("行番号(Row)が間違っています。[" + cImp[row, col].Row.ToString() + "]", "エラー", MessageBoxButtons.OK);
                                    return;
                                }
                                // セル行番号　範囲チェック
                                if (int.Parse(cImp[row, col].Row.ToString()) < 4 || int.Parse(cImp[row, col].Row.ToString()) > 34 )
                                {
                                    MessageBox.Show("行番号(Row)が間違っています。[" + cImp[row, col].Row.ToString() + "]", "エラー", MessageBoxButtons.OK);
                                    return;
                                }

                                // セル列番号
                                if (int.TryParse(cImp[row, col].Col.ToString(), out intVal) == true)
                                {
                                    sb.AppendLine("," + cImp[row, col].Col);
                                }
                                else
                                {
                                    MessageBox.Show("列番号(Col)が間違っています。[" + cImp[row, col].Col.ToString() + "]", "エラー", MessageBoxButtons.OK);
                                    return;
                                }
                                // セル列番号　範囲チェック
                                if (int.Parse(cImp[row, col].Col.ToString()) < 2 || int.Parse(cImp[row, col].Col.ToString()) > 21)
                                {
                                    MessageBox.Show("列番号(Col)が間違っています。[" + cImp[row, col].Row.ToString() + "]", "エラー", MessageBoxButtons.OK);
                                    return;
                                }

                                // フォントサイズ
                                if (int.TryParse(cImp[row, col].FontSize.ToString(), out intVal) == true)
                                {
                                    sb.AppendLine("," + cImp[row, col].FontSize);
                                }
                                else
                                {
                                    MessageBox.Show("フォントサイズが間違っています。[" + cImp[row, col].FontSize.ToString() + "]", "エラー", MessageBoxButtons.OK);
                                    return;
                                }
                                sb.AppendLine(",'" + cImp[row, col].FontColor + "'");
                                sb.AppendLine(",'" + cImp[row, col].FontBold + "'");
                                sb.AppendLine(",'" + cImp[row, col].BackColor + "'");
                                sb.AppendLine(",'" + cImp[row, col].Value + "'");
                                sb.AppendLine(",'" + cImp[row, col].Comment + "'");
                                sb.AppendLine("," + cImp[row, col].ContactFlag);
                                sb.AppendLine("," + cImp[row, col].TantoId);
                                sb.AppendLine(",'" + cImp[row, col].TantoName + "'");
                                sb.AppendLine(")");

                                clsSqlDb.DMLUpdate(sb.ToString());
                            }
                        }
                    }
                    // 正常終了でfalse→エラー検知でtrueの場合、Wrkデータを戻す
                    err_flag = false;
                }
                #endregion
            }
            catch (Exception ex)
            {
                // DELETEエラー判定
                if (err_flag == true)
                {
                    // Trn_勤務表シフト情報の対象年月を削除
                    // WrkデータをINSERT
                    using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                    {
                        sb.Clear();
                        sb.AppendLine("DELETE");
                        sb.AppendLine("FROM");
                        sb.AppendLine("Trn_勤務表シフト情報");
                        sb.AppendLine("WHERE");
                        sb.AppendLine("year = " + year);          // 対象年
                        sb.AppendLine("AND");
                        sb.AppendLine("month = " + month);        // 対象月
                        clsSqlDb.DMLUpdate(sb.ToString());

                        // 退避データを戻す
                        sb.Clear();
                        sb.AppendLine("INSERT INTO Trn_勤務表シフト情報");
                        sb.AppendLine("SELECT * FROM Trn_勤務表シフト情報_Wrk");
                        sb.AppendLine("WHERE");
                        sb.AppendLine("year = " + year);          // 対象年
                        sb.AppendLine("AND");
                        sb.AppendLine("month = " + month);        // 対象月
                        clsSqlDb.DMLUpdate(sb.ToString());
                    }
                }

                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
