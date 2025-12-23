using ClosedXML.Excel;
using Microsoft.Office.Interop.Excel;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace FlockAppC.pubClass
{
    public class ClsMsExcel : IDisposable
    {
        #region プロパティ
        public Microsoft.Office.Interop.Excel.Application Eap {  get; set; }
        public Microsoft.Office.Interop.Excel.Workbook Wbk { get; set; }
        public Microsoft.Office.Interop.Excel.Worksheet Wst { get; set; }
        private Microsoft.Office.Interop.Excel.Range Erg { get; set; }

        // プロパティ
        public string Value { get; set; }
        public string Value2 { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string SheetName { get; set; }
        public long BackColorCode {  get; set; }
        public string BackColor { get; set; }
        public long FontColorCode { get; set; }
        public string FontColor { get; set; }
        public int FontSize { get; set; }
        public string FontBold {  get; set; }

        private readonly StringBuilder sb = new();
        #endregion

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            // nullでない場合Quit()
            Eap?.Quit();
            //if (Eap != null)
            //{
            //    Eap.Quit();
            //}

            // COMオブジェクトの解放
            ReleaseComObject(Wst);
            ReleaseComObject(Wbk);
            ReleaseComObject(Eap);
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ClsMsExcel()
        {
            Eap = new Microsoft.Office.Interop.Excel.Application();
            FileName = "";
            FilePath = "";
            SheetName = "";
            Value = "";
            Value = "";
            Row = 0;
            Col = 0;
            BackColorCode = 0;
            BackColor = "";
            FontColorCode = 0;
            FontColor = "";
            FontSize = 0;
            FontBold = "";
        }
        /// <summary>
        /// =====================================================================
        /// ブックオープン
        /// =====================================================================
        /// </summary>
        public void OpenBook()
        {
            if (FileName == "" || SheetName == "") { return; }
            Wbk = Eap.Workbooks.Open(FileName);
            Wst = Wbk.Sheets[SheetName];
        }
        /// <summary>
        /// =====================================================================
        /// ブックオープン（読み込み専用）
        /// =====================================================================
        /// </summary>
        public void OpenReadOnryBook()
        {
            if (FileName == "" || SheetName == "") { return; }
            Wbk = Eap.Workbooks.Open(FileName,ReadOnly:true);
            Wst = Wbk.Sheets[SheetName];
        }
        /// <summary>
        /// =====================================================================
        /// ブックオープン（オープンだけ）
        /// =====================================================================
        /// </summary>
        public void OpenOnlyBook()
        {
            if (FileName == "") { return; }
            Wbk = Eap.Workbooks.Open(FileName, ReadOnly: true);
        }
        /// <summary>
        /// シート一覧取得
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        //public string[] GetSheetList(string p_filename, string[] p_arr)
        public string[] GetSheetList(string p_filename)
        {
            int i = 0;
            // string[] ret = p_arr;
            string[] ret = { "", "", "", "", "", "", "", "", "", "" };

            if (p_filename == "") return ret;

            // 処理速度を考慮し、OpenXLMを使用
            using (var workbook = new XLWorkbook(p_filename))
            {
                // 全てのシート名を取得
                foreach (var worksheet in workbook.Worksheets)
                {
                    ret[i] = worksheet.Name;
                    i++;
                    // Console.WriteLine(worksheet.Name);

                    // 暫定処理（とりあえず１０シート迄）
                    if (i >= 10) break;
                }
            }
            return ret;
        }

        /// <summary>
        /// =====================================================================
        /// ブッククローズ（保存なし）
        /// =====================================================================
        /// </summary>
        public void CloseBook()
        {
            if (Wbk != null)
            {
                Wbk.Close(false);       // 保存せずに閉じる（trueにすると保存する）
                Wbk = null;
            }
            if (Eap != null)
            {
                Eap.Quit();
                Eap = null;
            }

            // COMオブジェクトの解放
            ReleaseComObject(Wst);
            ReleaseComObject(Wbk);
            ReleaseComObject(Eap);
        }
        /// <summary>
        /// =====================================================================
        /// ブッククローズ（保存）
        /// =====================================================================
        /// </summary>
        public void CloseSaveBook()
        {
            if (Wbk != null)
            {
                Wbk.Close(true);       // 保存せずに閉じる（trueにすると保存する）
                Wbk = null;
            }
            if (Eap != null)
            {
                Eap.Quit();
                Eap = null;
            }

            // COMオブジェクトの解放
            ReleaseComObject(Wst);
            ReleaseComObject(Wbk);
            ReleaseComObject(Eap);
        }
        /// <summary>
        /// ブッククローズ（確認なし保存）
        /// </summary>
        public void CloseSaveBook2()
        {
            // 保存して閉じる
            Wbk.Save(); // 上書き保存
            Wbk.Close(false); // 保存済みのファイルを閉じる（falseで追加の保存確認をしない）
        }
        /// <summary>
        /// シートをアクティブにする
        /// </summary>
        /// <param name="p_sheet"></param>
        public void ActiveSheet(string p_sheet)
        {
            Wst = Wbk.Sheets[p_sheet];
            Wst.Activate();
        }
        /// <summary>
        /// シートコピー
        /// </summary>
        /// <param name="p_sheet1">コピー元</param>
        /// <param name="p_sheet2">コピー先</param>
        public void CopySheet(string p_sheet1, string p_sheet2)
        {
            // コピー元のシートを取得
            Excel.Worksheet sourceSheet = Wbk.Sheets[p_sheet1];

            // シートをコピー（指定位置に挿入）
            sourceSheet.Copy(After: Wbk.Sheets[Wbk.Sheets.Count]);

            // コピーされたシートの名前を変更（オプション）
            Excel.Worksheet copiedSheet = Wbk.Sheets[Wbk.Sheets.Count];
            copiedSheet.Name = p_sheet2;
        }

        /// <summary>
        /// COMオブジェクトを解放するためのメソッド
        /// </summary>
        /// <param name="obj"></param>
        private static void ReleaseComObject(object obj)
        {
            try
            {
                if (obj != null && System.Runtime.InteropServices.Marshal.IsComObject(obj))
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("COMオブジェクトの解放時にエラーが発生しました: " + ex.Message);
            }
        }
        /// <summary>
        /// =====================================================================
        /// セルに値をセット
        /// =====================================================================
        /// </summary>
        public void SetCell()
        {
            if (Row < 1 || Col < 1) return;

            Wst.Cells[Row,Col].Value = Value;

            // 属性をセット
            SetBackColor();
            SetFontSize();
            SetFontColor();
            SetFontBold();
        }
        /// <summary>
        /// セルに値セット
        /// </summary>
        public void SetCellValue()
        {
            if (Row < 1 || Col < 1) return;

            Wst.Cells[Row, Col].Value = Value;

            //// 属性をセット
            //SetBackColor();
            //SetFontSize();
            //SetFontColor();
            //SetFontBold();
        }
        /// <summary>
        /// =====================================================================
        /// セル背景色セット
        /// =====================================================================
        /// </summary>
        public void SetBackColor()
        {
            string col;

            switch (BackColor)
            {
                case ClsPublic.STR_YELLOW:
                    col = ClsPublic.HEX_YELLOW;
                    break;
                case ClsPublic.STR_ORANGE:
                    col = ClsPublic.HEX_ORANGE;
                    break;
                case ClsPublic.STR_SATURDAY:
                    col = ClsPublic.HEX_SATURDAY;
                    break;
                case ClsPublic.STR_SUNDAY:
                    col = ClsPublic.HEX_SUNDAY;
                    break;
                case ClsPublic.STR_HOLIDAY:
                    col = ClsPublic.HEX_HOLIDAY;
                    break;
                case ClsPublic.STR_SYSTEM:
                    col = ClsPublic.HEX_SYSTEM;
                    break;
                default:
                    col = ClsPublic.HEX_SYSTEM;
                    break;
            }

            // セルの背景色を設定 (RGB値)
            Range cell = Wst.Cells[Row, Col];

            // SystemColor以外が対象（暫定処理）
            if (BackColor != ClsPublic.STR_SYSTEM)
            {
                // カラーコードをRGBに変換
                var color = ColorTranslator.FromHtml(col);
                // セルの背景色を設定 (RGB値)
                cell.Interior.Color = ColorTranslator.ToOle(color);
            }
            else
            {
                // 背景色なし
                cell.Interior.ColorIndex = ClsPublic.NO_COLOR;
            }
        }
        /// <summary>
        /// =====================================================================
        /// フォントサイズセット
        /// =====================================================================
        /// </summary>
        private void SetFontSize()
        {
            // セルのフォントサイズを設定
            Range cell = Wst.Cells[Row, Col];

            cell.Font.Size = FontSize;
        }
        /// <summary>
        /// =====================================================================
        /// フォントカラーセット
        /// =====================================================================
        /// </summary>
        private void SetFontColor()
        {
            string col;

            switch (FontColor)
            {
                case ClsPublic.STR_BLACK:
                    col = ClsPublic.HEX_BLACK;
                    break;
                case ClsPublic.STR_RED:
                    col = ClsPublic.HEX_RED;
                    break;
                case ClsPublic.STR_BLUE:
                    col = ClsPublic.HEX_BLUE;
                    break;
                default:
                    col = ClsPublic.HEX_BLACK;
                    break;
            }

            // カラーコードをRGBに変換
            var color = ColorTranslator.FromHtml(col);

            // セルのフォントカラーを設定
            Range cell = Wst.Cells[Row, Col];
            cell.Font.Color = ColorTranslator.ToOle(color);
        }
        /// <summary>
        /// =====================================================================
        /// フォント太字設定
        /// =====================================================================
        /// </summary>
        private void SetFontBold()
        {
            // セルのフォントカラーを設定
            Range cell = Wst.Cells[Row, Col];

            if (FontBold == ClsPublic.STR_BOLD)
            {
                cell.Font.Bold = true;
            }
            else
            {
                cell.Font.Bold = false;
            }
        }
        /// <summary>
        /// =====================================================================
        /// セルの値、属性を取得
        /// =====================================================================
        /// </summary>
        public void GetCell()
        {
            string sColor;

            this.Value = "";
            this.FontSize = ClsPublic.DEF_FONT_SIZE;
            this.FontColor = ClsPublic.STR_BLACK;
            this.FontBold = ClsPublic.STR_NOBOLD;
            this.BackColor = "";

            try
            {
                // セル値取得
                Range range = Wst.Cells[Row, Col] as Range;

                if (range.Text != null)
                {
                    this.Value = range.Text.ToString();
                }
                else
                {
                    this.Value = "";
                }
                if (range.Value != null)
                {
                    this.Value2 = range.Value.ToString();
                }
                else
                {
                    this.Value2 = "";
                }

                try
                {
                    // フォントサイズ
                    if (this.Value.Length == 0) { this.FontSize = ClsPublic.DEF_FONT_SIZE; }
                    else { this.FontSize = int.Parse(range.Font.Size.ToString()); }
                }
                catch (Exception)
                {
                    // セル内で異なるフォントサイズが設定されている場合あり
                    // エラーの場合
                    this.FontSize = ClsPublic.DEF_FONT_SIZE;
                }

                try
                {
                    // フォントカラー
                    switch (range.Font.Color.ToString())
                    {
                        case ClsPublic.RNG_BLACK:
                            this.FontColor = ClsPublic.STR_BLACK;
                            break;
                        case ClsPublic.RNG_RED:
                            this.FontColor = ClsPublic.STR_RED;
                            break;
                        case ClsPublic.RNG_BLUE:
                            this.FontColor = ClsPublic.STR_BLUE;
                            break;
                        case ClsPublic.RNG_BLUE2:
                            this.FontColor = ClsPublic.STR_BLUE;
                            break;
                        default:
                            this.FontColor = ClsPublic.STR_BLACK;
                            break;
                    }
                }
                catch (Exception)
                {
                    this.FontColor = ClsPublic.STR_BLACK;
                }

                try
                {
                    // 太字
                    if (range.Font.Bold == true) { this.FontBold = ClsPublic.STR_BOLD; }
                    else { this.FontBold = ClsPublic.STR_NOBOLD; }
                }
                catch (Exception)
                {
                    this.FontBold = ClsPublic.STR_NOBOLD;
                }

                try
                {
                    // バックカラー
                    if (range.Interior.Color == null) { sColor = ""; }
                    else { sColor = range.Interior.Color.ToString(); }
                }
                catch (Exception)
                {
                    sColor = "0";
                }

                // １列目の時、曜日と休日を判定
                // １列目以外の場合、１列目のバックカラーをセット
                if (this.Col == 1)
                {
                    // Valueから土日を判定
                    if (this.Value.Contains("土") == true) { sColor = ClsPublic.IDX_SATURDAY; }
                    if (this.Value.Contains("日") == true) { sColor = ClsPublic.IDX_SUNDAY; }

                    // 休日判定(Mst_休日から検索)
                    try
                    {
                        using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                        {
                            sb.Clear();
                            sb.AppendLine("SELECT");
                            sb.AppendLine("day");
                            sb.AppendLine("FROM");
                            sb.AppendLine("Mst_休日");
                            sb.AppendLine("WHERE");
                            sb.AppendLine("day = '" + DateTime.Parse(this.Value2).ToString("yyyy/MM/dd") + "'");

                            using (System.Data.DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                            {
                                foreach (DataRow dr in dt_val.Rows)
                                {
                                    sColor = ClsPublic.IDX_HOLIDAY;
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

                switch (sColor)
                {
                    case ClsPublic.IDX_YELLOW:
                        this.BackColor = ClsPublic.STR_YELLOW;
                        break;
                    case ClsPublic.IDX_ORANGE:
                        this.BackColor = ClsPublic.STR_ORANGE;
                        break;
                    case ClsPublic.IDX_SATURDAY:
                        this.BackColor = ClsPublic.STR_SATURDAY;
                        break;
                    case ClsPublic.IDX_SATURDAY2:
                        this.BackColor = ClsPublic.STR_SATURDAY;
                        break;
                    case ClsPublic.IDX_SATURDAY3:
                        this.BackColor = ClsPublic.STR_SATURDAY;
                        break;
                    case ClsPublic.IDX_SUNDAY:
                        this.BackColor = ClsPublic.STR_SUNDAY;
                        break;
                    case ClsPublic.IDX_HOLIDAY:
                        this.BackColor = ClsPublic.STR_HOLIDAY;
                        break;
                    case ClsPublic.IDX_SYSTEM:
                        this.BackColor = ClsPublic.STR_SYSTEM;
                        break;
                    default:
                        this.BackColor = ClsPublic.STR_SYSTEM;
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// 印刷
        /// </summary>
        /// <param name="file_Name"></param>
        /// <param name="sheet_Name"></param>
        public void PrintSheet(string file_Name,string sheet_Name)
        {
            // --------------------------------------------------------------
            // 以下は印刷処理
            // --------------------------------------------------------------
            // Excelアプリケーションを起動
            var excelApp = new Excel.Application();
            excelApp.Visible = false;  // Excel画面を非表示にする（デバッグ時はtrueでもOK）

            // 対象のExcelファイルを開く
            // string filePath = @"C:\test\sample.xlsx";
            Excel.Workbook workbook = excelApp.Workbooks.Open(file_Name);

            // 印刷したいシート名を指定
            // string sheetName = "日報指示書";  // ←ここを印刷したいシート名に変更
            Excel.Worksheet sheet = workbook.Sheets[sheet_Name];

            // シートをアクティブにして印刷
            sheet.Select(Type.Missing);
            sheet.PrintOutEx(
                From: Type.Missing,
                To: Type.Missing,
                Copies: 1,
                Preview: false,       // trueなら印刷プレビューを表示
                ActivePrinter: Type.Missing,
                PrintToFile: false,
                Collate: true,
                PrToFileName: Type.Missing
            );

            // 終了処理
            workbook.Close(false);
            excelApp.Quit();

            // COMオブジェクトを解放
            System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
        }
    }
}
