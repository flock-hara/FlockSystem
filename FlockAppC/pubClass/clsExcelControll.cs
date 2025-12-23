using Microsoft.Office.Interop.Excel;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

// ------------------------------------------------------------------------------------------------
// ■ClosedXML
// ------------------------------------------------------------------------------------------------
//  WorkBookオープン(Sheet指定)  : OpenBook
// ------------------------------------------------------------------------------------------------
//  WorkBookクローズ  : CloseBook
// ------------------------------------------------------------------------------------------------
//  WorkBook保存 : SaveWorkBook
// ------------------------------------------------------------------------------------------------
//  WorkBook上書き保存 : SaveAsWorkBook
// ------------------------------------------------------------------------------------------------
//  WorkSheet追加 : AddWorkSheet
// ------------------------------------------------------------------------------------------------
//  WorkSheet削除 : DeleteWorkSheet
// ------------------------------------------------------------------------------------------------
//  WorkSheet移動 : MoveWorkSheet
// ------------------------------------------------------------------------------------------------
//  SheetActive化 : SetActiveWorkSheet
// ------------------------------------------------------------------------------------------------
//  
// ------------------------------------------------------------------------------------------------
//  最終行番号取得 : GetLastRowNo
// ------------------------------------------------------------------------------------------------
//  最終列番号取得 : GetLastColNo
// ------------------------------------------------------------------------------------------------
//  行コピー : CopyRow
// ------------------------------------------------------------------------------------------------
//  行挿入（下） : InsertUnderRow
// ------------------------------------------------------------------------------------------------
//  行挿入（上） : InsertUpperRow
// ------------------------------------------------------------------------------------------------
//  行削除 : DeleteRow
// ------------------------------------------------------------------------------------------------
//  列挿入（前） : AddBeforeCol
// ------------------------------------------------------------------------------------------------
//  列挿入（後） : AddAfterCol
// ------------------------------------------------------------------------------------------------
//  列コピー : CopyCol
// ------------------------------------------------------------------------------------------------
//  列削除 : DeleteCol
// ------------------------------------------------------------------------------------------------
//  
// ------------------------------------------------------------------------------------------------
//  ウィンドウ枠固定 : WinLock
// ------------------------------------------------------------------------------------------------
//  ウィンドウ枠固定解除 : WinUnLock
// ------------------------------------------------------------------------------------------------
//  Cellに値（文字値）をセット　Row/Col指定 : SetStrValueR1C1
// ------------------------------------------------------------------------------------------------
//  Cellに値（文字値）をセット　A1形式指定 : SetStrValueA1
// ------------------------------------------------------------------------------------------------
//  Cellに値（文字値）をセット　１つの値を範囲指定で全てにセット : MultiSetStrValueR1C1
// ------------------------------------------------------------------------------------------------
//  
// ------------------------------------------------------------------------------------------------
//  セルのテキスト取得 : GetCellText
// ------------------------------------------------------------------------------------------------
//  セル値取得 R1C1形式 : GetStrValueR1C1
// ------------------------------------------------------------------------------------------------
//  セル値取得 A1形式 : GetStrValueA1
// ------------------------------------------------------------------------------------------------
//  セルから2次元配列へ読み込み（全件） ==>> Array[,]へ格納 : MultiGetStrValueR1C1
// ------------------------------------------------------------------------------------------------
//  背景色セット R1C1形式 : DrawColorR1C1
// ------------------------------------------------------------------------------------------------
//  背景色セット　A1形式 : DrawColorA1
// ------------------------------------------------------------------------------------------------
//  背景色セット　Range指定 : MultiDrawColor
// ------------------------------------------------------------------------------------------------
//  
// ------------------------------------------------------------------------------------------------
//  背景色取得 : GetCellBackColor
// ------------------------------------------------------------------------------------------------
//  
// ------------------------------------------------------------------------------------------------
//  枠線描画　R1C1形式　セル指定　上,下,左,右 : DrawUpLineR1C1
// ------------------------------------------------------------------------------------------------
//                                            : DrawBottonLineR1C1
// ------------------------------------------------------------------------------------------------
//                                            : DrawLeftLineR1C1
// ------------------------------------------------------------------------------------------------
//                                            : DrawRightLineR1C1
// ------------------------------------------------------------------------------------------------
//                                            : DrawRectLineR1C1
// ------------------------------------------------------------------------------------------------
//  
// ------------------------------------------------------------------------------------------------
//  セル内文字位置　R1C1形式 : SetAlignR1C1
// ------------------------------------------------------------------------------------------------
//  セルの結合/解除 : MargeCell
// ------------------------------------------------------------------------------------------------
//                  : UnMargeCell
// ------------------------------------------------------------------------------------------------
//  
// ------------------------------------------------------------------------------------------------
//  フォントタイプ設定 : SetFontType
// ------------------------------------------------------------------------------------------------
//  フォントカラー設定　単一 : SetFontColor
// ------------------------------------------------------------------------------------------------
//  フォントカラー設定　範囲指定 : MultiSetFontColor
// ------------------------------------------------------------------------------------------------
//  フォントサイズ設定　R1C1形式　単一 : SetFontSize
// ------------------------------------------------------------------------------------------------
//  フォントサイズ設定　範囲指定 : MultiSetFontSize
// ------------------------------------------------------------------------------------------------
//  フォント太字　R1C1形式　単一 : SetFontBold
// ------------------------------------------------------------------------------------------------
//  フォント太字　範囲指定 : MultiSetFontBold
// ------------------------------------------------------------------------------------------------
//  フォントイタリック　R1C1形式　単一 : SetFontItalic
// ------------------------------------------------------------------------------------------------
//  
// ------------------------------------------------------------------------------------------------
//  フォントタイプ取得 : GetFontType
// ------------------------------------------------------------------------------------------------
//  フォントサイズ取得 : GetFontSize
// ------------------------------------------------------------------------------------------------
//  フォント太字取得 : GetFontBold
// ------------------------------------------------------------------------------------------------
//  フォントカラー取得 : GetFontColor
// ------------------------------------------------------------------------------------------------
//  フォントイタリック取得 : GetFontIta
// ------------------------------------------------------------------------------------------------


namespace FlockAppC.pubClass
{
    public class clsExcelControll : IDisposable
    {
        public void Dispose()
        {
            this.Wst = null;
            this.Wbk.Dispose();
            this.Dispose(); 
        }

        #region "ClosedXML"
        #region "ファイルオープン/クローズ"
        /// <summary>
        /// Excel WorkBookオープン(Sheet指定)
        /// </summary>
        /// <returns>
        ///  True:Normal / False:Error
        /// </returns>
        public Boolean  OpenBook()
        {
            if (FileName == "" || SheetName == "")
            {
                return false;
            }

            try
            {
                // ファイル名、シート名指定
                Wbk = new XLWorkbook(FileName);
                Wst = Wbk.Worksheet(SheetName);

                return true;

            }
            catch (Exception ex)
            {
                // エラー
                Console.WriteLine(ex.Message);
                return false;
                throw;
            }
        }

        /// <summary>
        /// Excel WorkBookクローズ
        /// </summary>
        public void CloseBook()
        {
            // オブジェクト解放
            // System.Runtime .InteropServices .Marshal .ReleaseComObject (Xwb);
            this.Wbk = null;
        }
        #endregion

        #region "ブック保存"
        /// <summary>
        /// WorkBook保存
        /// 3/13動作確認済
        /// </summary>
        public void SaveWorkBook()
        {
            Wbk.Save();
        }
        /// <summary>
        /// WorkBook上書き保存
        /// 3/13動作確認済
        /// </summary>
        public Boolean SaveAsWorkBook()
        {
            if (FileName == "")
            {
                return false;
            }

            Wbk.SaveAs(FileName);

            return true;
        }
        #endregion

        #region "ワークシート追加/削除/移動/アクティブ"
        /// <summary>
        /// WorkSheet追加
        /// 3/13動作確認済
        /// </summary>
        public void AddWorkSheet()
        {
            // シート名判定
            if (SheetName != "")
            {
                // 指定シート名で追加
                Wbk.Worksheets.Add(SheetName);
            }
            else
            {
                // [Sheet1]でシート追加
                Wbk.Worksheets.Add();
            }
        }
        /// <summary>
        /// WorkSheet削除
        /// 3/13動作確認済
        /// </summary>
        /// <returns>
        ///  True:Normal / False:Error
        /// </returns>
        public Boolean  DeleteWorkSheet()
        {
            if (SheetName == "")
            {
                return false;
            }

            Wbk.Worksheets.Delete(SheetName);

            return true;
        }
        /// <summary>
        /// WorkSheet移動
        /// 3/13動作確認済
        /// </summary>
        /// <returns>
        ///  True:Normal / False:Error
        /// </returns>
        public Boolean MoveWorkSheet()
        {
            if (this.Position == 0)
            {
                return false;
            }

            if (this.SheetName == "")
            {
                return false;
            }

            // WotkSheet移動
            Wbk.Worksheet(SheetName).Position = this.Position;

            return true;
        }
        /// <summary>
        /// SheetActive化
        /// 3/13動作確認済
        /// </summary>
        /// <returns>
        ///  True:Normal / False:Error
        /// </returns>
        public Boolean SetActiveWorkSheet()
        {
            if (this.SheetName == "")
            {
                return false;
            }

            // 現在ActiveなSheet取得
            var sheet =  Wbk.Worksheets.First(_ => _.TabActive).Worksheet;
            
            // 指定Sheetと現在ActiveなSheetを比較
            if (sheet != Wbk.Worksheet(SheetName) )
            {
                // 指定SheetをActiveに設定
                Wbk.Worksheet(SheetName).SetTabActive();

                // Sheetセット
                Wst = Wbk.Worksheet(SheetName);

                sheet.TabSelected = false;
            }

            return true;
        }
        #endregion

        #region "行番号/列番号取得"
        /// <summary>
        /// 最終行番号取得
        /// 3/13動作確認済
        /// 3/14動作確認済
        /// </summary>
        public void GetLastRowNo()
        {
            // 最終行取得
            var lastrow = Wst.LastRowUsed();

            // 最終行番号(1～)
            LastRowNo = lastrow.RowNumber();

            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // 取得した最終行を利用したい場合のコードをここに記述します。
　          // 例：最終行の次の行に値を設定する。
　          // wb.Worksheet("sheet1").Cell(lastRowNumber + 1, 1).Value = "次のデータ";
        }
        public void GetLastColNo()
        {
            // 最終列取得
            var lastcol = Wst.LastColumnUsed();

            // 最終列番号(1～)
            LastColNo = lastcol.ColumnNumber();

            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // 取得した最終列を利用したい場合のコードをここに記述します。
            // 例えば、最終列の次の列に値を設定する。
            // wb.Worksheet("sheet1").Cell(1, lastColumnNumber + 1).Value = "次のデータ";
        }
        #endregion

        #region "行コピー/追加/削除"
        /// <summary>
        /// 行コピー
        /// 3/14動作確認済
        /// </summary>
        /// <returns></returns>
        public Boolean CopyRow()
        {
            // コピー先行数未指定
            if (this.Num < 1)
            {
                return false;
            }
            // コピー元行数未設定 
            if (this.Row < 1)
            {
                return false;
            }

            // 各行を取得
            var row1 = Wst.Row(Row);
            var row2 = Wst.Row(Num);

            // Row行目をNum行目にコピー
            row1.CopyTo(row2);

            return true;
        }

        /// <summary>
        /// 行挿入（下）
        /// 3/14動作確認済
        /// </summary>
        /// <returns></returns>
        public Boolean InsertUnderRow()
        {
            // 挿入行数未指定
            if (this.Num < 1)
            {
                return false;
            }
            // 挿入対象行 
            if (this.Row < 1)
            {
                return false;
            }

            // Row行目の下にNum行追加
            Wst.Row(this.Row).InsertRowsBelow(this.Num); 

            return true;
        }
        /// <summary>
        /// 行挿入（上）
        /// 3/14動作確認済
        /// </summary>
        /// <returns></returns>
        public Boolean InsertUpperRow()
        {
            // 挿入行数未指定
            if (this.Num < 1)
            {
                return false;
            }
            // 挿入対象行 
            if (this.Row < 1)
            {
                return false;
            }

            // Row行目の上にNum行追加
            Wst.Row(this.Row).InsertRowsAbove(this.Num);

            return true;
        }
        /// <summary>
        /// 行削除
        /// 3/14動作確認済
        /// </summary>
        /// <returns></returns>
        public Boolean DeleteRow()
        {
            // 削除対象行が未指定
            if (this.Row < 1) 
            {
                return false;
            }

            // Row行目を削除
            Wst.Row(this.Row).Delete();

            return true;
        }
        #endregion

        #region "列コピー/追加/削除"
        /// <summary>
        /// 列挿入（前）
        /// 3/14動作確認済
        /// </summary>
        /// <returns></returns>
        public Boolean AddBeforeCol()
        {
            if (this.Col < 1)
            {
                return false;
            }
            if (this.Num < 1)
            {
                return false;
            }

            // Cal列目の前にNum列追加
            Wst.Column(this.Col).InsertColumnsBefore(this.Num);

            return true;
        }
        /// <summary>
        /// 列挿入（後）
        /// 3/14動作確認済
        /// </summary>
        /// <returns></returns>
        public Boolean AddAfterCol()
        {
            if (this.Col < 1)
            {
                return false;
            }
            if (this.Num < 1)
            {
                return false;
            }

            // Cal列目の前にNum列追加
            Wst.Column(this.Col).InsertColumnsAfter(this.Num);

            return true;
        }
        /// <summary>
        /// 列コピー
        /// 3/14動作確認済
        /// </summary>
        /// <returns></returns>
        public Boolean CopyCol()
        {
            if (this.Col < 1)
            {
                return false;
            }
            if (this.Num < 1)
            {
                return false;
            }

            // 各列取得
            var col1 = Wst.Column(Col);
            var col2 = Wst.Column(Num);

            // 列コピー
            col1.CopyTo(col2);

            return true;
        }
        /// <summary>
        /// 列削除
        /// 3/14動作確認済
        /// </summary>
        /// <returns></returns>
        public Boolean DeleteCol()
        {
            if (this.Col < 1)
            {
                return false;
            }

            // Col列目を削除
            Wst.Column(Col).Delete();

            return true;
        }
        #endregion

        #region "ウィンドウ枠固定/解除"
        /// <summary>
        /// Window枠Lock
        /// 3/14動作確認済
        /// </summary>
        /// <returns></returns>
        public Boolean WinLock()
        {
            // Row,Col
            if (this.Row < 1 || this.Col < 1 )
            {
                return false;
            }

            // Row行/Col列で固定
            Wst.SheetView.FreezeRows(Row);
            Wst.SheetView.FreezeColumns(Col);

            return true;
        }
        public void WinUnLock()
        {
            // Row行/Col列で固定解除
            Wst.SheetView.FreezeRows(0);
            Wst.SheetView.FreezeColumns(0);
        }
        #endregion


        #region "SETセル"
        /// <summary>
        /// Cellに値（文字値）をセット　Row/Col指定
        /// 3/14動作確認済
        /// </summary>
        /// <returns></returns>
        public Boolean SetStrValueR1C1()
        {
            if (Row < 1 || Col < 1)
            {
                return false;
            }

            // セルに書込み
            Wst.Cell(Row, Col).Value = this.StrValue;

            return true;
        }
        /// <summary>
        /// Cellに値（文字値）をセット　A1形式指定
        /// 3/14動作確認済
        /// </summary>
        /// <returns></returns>
        public Boolean SetStrValueA1()
        {
            if (this.Cell == "" )
            {
                return false;
            }

            // セルに書込み
            Wst.Cell(this.Cell).Value = this.StrValue;  

            return true;
        }
        /// <summary>
        /// Cellに値（文字値）をセット　１つの値を範囲指定で全てにセット
        /// 3/14動作確認済
        /// </summary>
        /// <returns></returns>
        public Boolean MultiSetStrValueR1C1()
        {
            // Start/End
            if (this.Rc[0] < 1 || this.Rc[1] < 1 || this.Rc[2] < 1 || this.Rc[3] < 1)
            {
                return false;
            }

            // (Rc[0],Rc[1]) , (Rc[2],Rc[3])の範囲のセルにStrValue値をセット
            Wst.Range(Rc[0], Rc[1], Rc[2], Rc[3]).Value = this.StrValue;

            return true;
        }
        #endregion

        #region "GETセル"
        public void GetCell()
        {
            this.StrValue = "";
            this.StrText = "";
            this.FontSize = 36;
            this.FontBoldLabel = "普通";
            this.FontColorLabel = "Black";
            this.BackColorLabel = "SystemColor";

            // セル値取得
            if (GetStrValueR1C1() != true) { return; }

            // セルテキスト取得
            if (GetCellText() != true) { return; }

            // セル背景色取得
            //GetCellBackColor();
            //var strColor = "";
            //if (this.Color != null)
            //{
            //    strColor = this.Color.ToString();
            //}

            // フォントサイズ取得
            GetFontSize();
            if ( StrValue.Length == 0 )
            {
                this.FontSize = 36;
            }

            // フォント太字取得
            if (GetFontBold() == true)
            {
                FontBoldLabel = "太字";
            }
            else
            {
                FontBoldLabel = "普通";
            }

            // フォントカラー取得
            GetFontColor();
            var strColor = this.FontColor.ToString();
            switch(strColor)
            {
                case "0":
                    FontColorLabel = "Black";
                    break;

                case "255":
                    FontColorLabel = "Red";
                    break;

                case "12611584":
                    FontColorLabel = "Blue";
                    break;

                case "16711680":
                    FontColorLabel = "Blue";
                    break;

                default:
                    FontColorLabel = "Black";
                    break;
            }

            // フォントイタリック取得


            // １列目の時、曜日と休日を判定
            // １列目以外の場合、１列目のバックカラーをセット
            if ( Col == 1 )
            {
                // Valueから土日を判定
                if (this.StrValue.Contains("土") == true)
                {
                    strColor = "16247773";
                }
                else
                {
                    strColor = "16751103";
                }

                // 休日判定(Mst_休日から検索)
                // System.Data.DataTable dt;
                // using (clsDbCon cDb = new clsDbCon())
                using (clsDb cDb = new clsDb(clsPublic.DBNo))
                {
                    StringBuilder stb = new StringBuilder();
                    stb.Length = 0;
                    stb.AppendLine("SELECT");
                    stb.AppendLine("Day");
                    stb.AppendLine("FROM");
                    stb.AppendLine("Mst_休日");
                    stb.AppendLine("WHERE");
                    stb.AppendLine("Day = '" + DateTime.Parse(this.StrValue).ToString("yyyy/MM/dd") + "'");
                    // cDb.DbCon();
                    cDb.Sql = stb.ToString();
                    cDb.DMLSelect();
                    // dt = new System.Data.DataTable();
                    // dt = cDb.dt;
                    foreach (DataRow dr in cDb.dt.Rows)
                    {
                        strColor = "16764159";
                    }
                    // cDb.DBClose();
                }

                switch(strColor)
                {
                    case "65535":
                        this.BackColorLabel = "Yellow";
                        break;

                    case "49407":
                        this.BackColorLabel = "Orange";
                        break;

                    case "16247773":
                        this.BackColorLabel = "SaturDayColor";
                        break;

                    case "15917529":
                        this.BackColorLabel = "SaturDayColor";
                        break;

                    case "14998742":
                        this.BackColorLabel = "SaturDayColor";
                        break;

                    case "16751103":
                        this.BackColorLabel = "SunDayColor";
                        break;

                    case "16764159":
                        this.BackColorLabel = "HoliDayColor";
                        break;

                    case "16777215":
                        this.BackColorLabel = "SystemColor";
                        break;

                    default:
                        this.BackColorLabel = "SystemColor";
                        break;
                }
            }
        }

        /// <summary>
        /// セルのテキスト取得
        /// </summary>
        /// <returns></returns>
        public Boolean GetCellText()
        {
            if (Row < 1 || Col < 1)
            {
                return false;
            }

            var cell = Wst.Cell(Row, Col);
            var cellText = cell.GetValue<string>();

            this.StrText = cellText;

            return true;
        }

        /// <summary>
        /// セル値取得 R1C1形式
        /// 3/14動作確認済
        /// </summary>
        /// <returns></returns>
        public Boolean GetStrValueR1C1()
        {
            if (Row < 1 || Col < 1)
            {
                return false;
            }

            // セル値取得
            var cell = Wst.Cell(Row, Col);
            //IXLCell cell = Xst.Cell(Row, Col);

            // this.StrValue = cell.GetString();
            this.StrValue = cell.Value.ToString(); ;


            // this.StrValue = Xst.Cell(Row, Col).Value.ToString();

            return true;
        }
        /// <summary>
        /// セル値取得 A1形式
        /// 3/14動作確認済
        /// </summary>
        /// <returns></returns>
        public Boolean GetStrValueA1()
        {
            if (Cell == "")
            {
                return false;
            }

            // セル値取得
            this.StrValue = Wst.Cell(Cell).Value.ToString();

            return true;
        }
        /// <summary>
        /// セルから2次元配列へ読み込み（全件） ==>> Array[,]へ格納
        /// 3/14動作確認済
        /// </summary>
        /// <returns></returns>
        public void MultiGetStrValueR1C1()
        {
            // 使用されている範囲を取得
            var range = Wst.RangeUsed();

            // 2次元配列を定義
            this.Array = new object[range.RowCount(),range.ColumnCount()];

            // Excelの範囲から2次元配列へデータを読み込み
            for (int i = 1; i < range.RowCount(); i++)
            {
                for (int j = 1;  j < range.ColumnCount(); j++)
                {
                    this.Array[i - 1, j - 1] = range.Cell(i, j).Value;
                }
            }
        }
        #endregion


        #region 背景色セット
        /// <summary>
        /// 背景色セット R1C1形式
        /// 3/14動作確認済
        /// </summary>
        /// <returns></returns>
        public Boolean  DrawColorR1C1()
        {
            if (Row < 1 || Col < 1)
            {
                return false;
            }

            // BackColor設定
            //
            //   XLColor.xxxxxx
            //
            Wst.Cell(this.Row, this.Col).Style.Fill.BackgroundColor = this.Color;

            return true;
        }
        /// <summary>
        /// 背景色セット　A1形式
        /// 3/14動作確認済
        /// </summary>
        /// <returns></returns>
        public Boolean DrawColorA1()
        {
            if (this.Cell == "")
            {
                return false;
            }

            // BackColor設定
            //
            //   XLColor.xxxxxx
            //
            Wst.Cell(this.Cell).Style.Fill.BackgroundColor = this.Color;

            return true;
        }
        /// <summary>
        /// 背景色セット　Range指定
        /// 3/14動作確認済
        /// </summary>
        /// <returns></returns>
        public Boolean MultiDrawColor()
        {
            if (Rc[0] < 1 || Rc[1] < 1 || Rc[2] < 1 || Rc[3] < 1) 
            {
                return false;
            }

            // BackColor設定
            //
            //   XLColor.xxxxxx
            //
            Wst.Range(Rc[0], Rc[1], Rc[2], Rc[3]).Style .Fill.BackgroundColor = this.Color;

            return true;
        }
        #endregion

        #region 背景色取得
        public Boolean GetCellBackColor()
        {
            if (Row < 1 || Col < 1)
            {
                return false;
            }

            // セル値取得
            var cell = Wst.Cell(Row, Col);

            // Backcolor
            this.Color = cell.Style.Fill.BackgroundColor;

            return true;
        }
        #endregion

        #region セル枠線
        /////////////////////////////////////////////////////////////////////////////////////
        // スタイルの名称	XLBorderStyleValuesのパラメータ	説明
        //
        // 無し             None                            枠線なし
        // 細い実線         Thin                            細い実線
        // 中くらいの実線   Medium                          中くらいの太さの実線
        // 太い実線         Thick                           太い実線
        // 点線             Dotted                          点線
        // 細い点線         Hair                            非常に細い点線
        // 点線（太い）	    Dashed                          太い点線
        // 二重線           Double                          二重線
        // 細い点線（2種）	DashDot	                        1点鎖線（細い点と線が交互に来る）
        // 中点線（2種）	MediumDashDot	                1点鎖線（中くらいの点と線が交互）
        /////////////////////////////////////////////////////////////////////////////////////
        // 枠線の位置とプロパティの対応表（サンプルコード付き）
        // 位置             プロパティ                      説明 
        //
        // 上               TopBorder                       上側の枠線を設定する wb.Worksheet("sheet1").Cell("C5").Style.Border.TopBorder = XLBorderStyleValues.Thin;
        // 下               BottomBorder                    下側の枠線を設定する wb.Worksheet("sheet1").Cell("C5").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
        // 左               LeftBorder                      左側の枠線を設定する wb.Worksheet("sheet1").Cell("C5").Style.Border.LeftBorder = XLBorderStyleValues.Thin;
        // 右               RightBorder                     右側の枠線を設定する wb.Worksheet("sheet1").Cell("C5").Style.Border.RightBorder = XLBorderStyleValues.Thin;
        // 外側全体         OutsideBorder                   範囲の外側の枠線を一括で設定する wb.Worksheet("sheet1").Range(1, 5, 100, 5).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        // 内側水平         InsideBorder                    範囲の内側の水平枠線を一括で設定する wb.Worksheet("sheet1").Range(1, 5, 100, 5).Style.Border.InsideBorder = XLBorderStyleValues.Thin;
        // 内側垂直         InsideBorder                    範囲の内側の垂直枠線を一括で設定する wb.Worksheet("sheet1").Range(1, 5, 100, 5).Style.Border.InsideBorder = XLBorderStyleValues.Thin;
        // 内側全体         InsideBorder                    範囲の内側の枠線を一括で設定する wb.Worksheet("sheet1").Range(1, 5, 100, 5).Style.Border.InsideBorder = XLBorderStyleValues.Thin;
        // 対角線           DiagonalBorder                  対角線の枠線を設定する wb.Worksheet("sheet1").Cell("C5").Style.Border.DiagonalBorder = XLBorderStyleValues.Thin;
        // 対角線（逆）	    DiagonalBorder                  逆方向の対角線の枠線を設定する wb.Worksheet("sheet1").Cell("C5").Style.Border.DiagonalBorder = XLBorderStyleValues.Thin;
        /////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 枠線描画　R1C1形式　セル指定　上,下,左,右
        /// 3/14動作確認済
        /// </summary>
        /// <returns></returns>
        public Boolean  DrawUpLineR1C1()
        {
            if (this.Row < 1 || this.Col < 1)
            {
                return false;
            }

            Wst.Cell(this.Row, this.Col).Style.Border.TopBorder = this.BorderStyle;
            Wst.Cell(this.Row, this.Col).Style.Border.TopBorderColor = this.Color;

            return true;
        }
        public Boolean DrawBottonLineR1C1()
        {
            if (this.Row < 1 || this.Col < 1)
            {
                return false;
            }

            Wst.Cell(this.Row, this.Col).Style.Border.BottomBorder=this.BorderStyle;    
            Wst.Cell(this.Row, this.Col).Style.Border.BottomBorderColor  = this.Color;

            return true;
        }
        public Boolean DrawLeftLineR1C1()
        {
            if (this.Row < 1 || this.Col < 1)
            {
                return false;
            }

            Wst.Cell(this.Row, this.Col).Style.Border.LeftBorder = this.BorderStyle;
            Wst.Cell(this.Row, this.Col).Style.Border.LeftBorderColor = this.Color;

            return true;
        }
        public Boolean DrawRightLineR1C1()
        {
            if (this.Row < 1 || this.Col < 1)
            {
                return false;
            }

            Wst.Cell(this.Row, this.Col).Style.Border.RightBorder = this.BorderStyle;
            Wst.Cell(this.Row, this.Col).Style.Border.RightBorderColor = this.Color;

            return true;
        }
        public Boolean DrawRectLineR1C1()
        {
            if (this.Row < 1 || this.Col < 1)
            {
                return false;
            }

            // セルを枠線で囲む
            Wst.Cell(this.Row,this.Col).Style.Border .SetOutsideBorder(this.BorderStyle);
            Wst.Cell(this.Row, this.Col).Style.Border.SetOutsideBorderColor(this.Color);

            return true;
        }
        #endregion

        #region セル内文字位置
        /////////////////////////////////////////////////////////////////////////////////////
        // 配置オプションの一覧表
        // 配置オプション                   説明                                  サンプルコード
        //
        // 水平方向の配置（設定一覧）	    セル内のテキストの水平方向の位置      wb.Worksheet("sheet1").Cell("C5").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        // 垂直方向の配置（設定一覧）  	    セル内のテキストの垂直方向の位置      wb.Worksheet("sheet1").Cell("C5").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
        // テキストの折り返し               テキストをセル内で折り返す            wb.Worksheet("sheet1").Cell("C5").Style.Alignment.WrapText = true;
        // 縮小して表示                     テキストを縮小してセルに収める        wb.Worksheet("sheet1").Cell("C5").Style.Alignment.ShrinkToFit = true;
        // インデント                       テキストのインデントを設定            wb.Worksheet("sheet1").Cell("C5").Style.Alignment.Indent = 2;
        // テキストの回転                   テキストの角度を設定                  wb.Worksheet("sheet1").Cell("C5").Style.Alignment.TextRotation = 45;
        // 改行                             テキストで改行を行う                  wb.Worksheet("sheet1").Cell("C5").Style.Alignment.JustifyLastLine = true;
        /////////////////////////////////////////////////////////////////////////////////////
        // 水平方向の配置設定一覧
        // オプション              説明                                                      サンプルコード
        //
        // General                 デフォルトの配置。内容に基づいて自動的に配置されます。	            wb.Worksheet("sheet1").Cell("C5").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.General;
        // Left                    テキストを左揃えにします。	                                        wb.Worksheet("sheet1").Cell("C5").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
        // Center                  テキストを中央揃えにします。	                                        wb.Worksheet("sheet1").Cell("C5").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        // Right                   テキストを右揃えにします。	                                        wb.Worksheet("sheet1").Cell("C5").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
        // Fill                    セルを埋めるようにテキストを繰り返します。	                        wb.Worksheet("sheet1").Cell("C5").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Fill;
        // Justify                 テキストを両端揃えにし、単語の間隔を調整します。	                    wb.Worksheet("sheet1").Cell("C5").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Justify;
        // CenterContinuous        中央揃えですが、隣接する空白セルにまたがって中央揃えが継続されます。	wb.Worksheet("sheet1").Cell("C5").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.CenterContinuous;
        // Distributed             テキストを均等に分散させ、両端を揃えます。	                        wb.Worksheet("sheet1").Cell("C5").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Distributed;
        /////////////////////////////////////////////////////////////////////////////////////
        // 垂直方向の配置設定一覧
        // オプション              説明                                                      サンプルコード
        //
        // Top                     テキストを上揃えにします。	                             wb.Worksheet("sheet1").Cell("C5").Style.Alignment.Vertical = XLAlignmentVerticalValues.Top;
        // Center                  テキストを中央揃えにします。	                             wb.Worksheet("sheet1").Cell("C5").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
        // Bottom                  テキストを下揃えにします。	                             wb.Worksheet("sheet1").Cell("C5").Style.Alignment.Vertical = XLAlignmentVerticalValues.Bottom;
        // Justify                 テキストをセル内で垂直に均等に分散させます。	             wb.Worksheet("sheet1").Cell("C5").Style.Alignment.Vertical = XLAlignmentVerticalValues.Justify;
        // Distributed             テキストとセルの上下の余白を均等に分散させます。	         wb.Worksheet("sheet1").Cell("C5").Style.Alignment.Vertical = XLAlignmentVerticalValues.Distributed;
        /////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// セル内文字位置　R1C1形式
        /// 3/14動作確認済
        /// </summary>
        public void SetAlignR1C1()
        {
            Wst.Cell(this.Row, this.Col).Style.Alignment.Horizontal = this.AlignHori;
            Wst.Cell(this.Row, this.Col).Style.Alignment.Vertical = this.AlignVart;  
        }
        #endregion

        #region セルの結合/解除
        /// <summary>
        /// セルの結合/解除
        /// </summary>
        /// <returns></returns>
        public Boolean MargeCell()
        {
            if (this.Rc[0] < 1 || this.Rc[1] < 1 || this.Rc[2] < 1 || this.Rc[3] < 1)
            {
                return false;
            }

            // 範囲指定したセルを結合
            Wst.Range(Rc[0], Rc[1], Rc[2], Rc[3]).Merge();

            return true;
        }
        public Boolean UnMargeCell()
        {
            if (this.Rc[0] < 1 || this.Rc[1] < 1 || this.Rc[2] < 1 || this.Rc[3] < 1)
            {
                return false;
            }

            // 範囲指定したセルの結合解除
            Wst.Range(Rc[0], Rc[1], Rc[2], Rc[3]).Unmerge(); 

            return true;
        }
        #endregion

        #region フォント属性設定
        /// <summary>
        /// フォントタイプ設定
        /// </summary>
        /// <returns></returns>
        public Boolean SetFontType()
        {
            if (this.Row < 1 || this.Col < 1)
            {
                return false;
            }

            Wst.Cell(this.Row, this.Col).Style.Font.FontName = this.FontName;

            return true;
        }
        /// <summary>
        /// フォントカラー設定　単一
        /// </summary>
        /// <returns></returns>
        public Boolean SetFontColor()
        {
            if (this.Row < 1 || this.Col < 1)
            {
                return false;
            }

            Wst.Cell(this.Row, this.Col).Style.Font.FontColor = this.Color;

            return true;
        }
        /// <summary>
        /// フォントカラー設定　範囲指定
        /// </summary>
        /// <returns></returns>
        public Boolean  MultiSetFontColor()
        {
            if (this.Rc[0] < 1 || this.Rc[1] < 1 || this.Rc[2] < 1 || this.Rc[3] < 1)
            {
                return false;
            }

            Wst.Range(Rc[0], Rc[1], Rc[2], Rc[3]).Style.Font.FontColor = this.Color;

            return true;
        }
        /// <summary>
        /// フォントサイズ設定　R1C1形式　単一
        /// </summary>
        /// <returns></returns>
        public Boolean SetFontSize()
        {
            if (this.Row < 1 || this.Col < 1)
            {
                return false;
            }

            Wst.Cell(this.Row, this.Col).Style.Font.FontSize = this.FontSize;

            return true;
        }
        /// <summary>
        /// フォントサイズ設定　範囲指定
        /// </summary>
        /// <returns></returns>
        public Boolean MultiSetFontSize()
        {
            if (this.Rc[0] < 1 || this.Rc[1] < 1 || this.Rc[2] < 1 || this.Rc[3] < 1)
            {
                return false;
            }

            Wst.Range(Rc[0], Rc[1], Rc[2], Rc[3]).Style.Font.FontSize = this.FontSize;

            return true;
        }
        /// <summary>
        /// フォント太字　R1C1形式　単一
        /// </summary>
        /// <returns></returns>
        public Boolean SetFontBold()
        {
            if (this.Row < 1 || this.Col < 1)
            {
                return false;
            }

            Wst.Cell(this.Row, this.Col).Style.Font.Bold  = this.FontBold;

            return true;
        }
        /// <summary>
        /// フォント太字　範囲指定
        /// </summary>
        /// <returns></returns>
        public Boolean MultiSetFontBold()
        {
            if (this.Rc[0] < 1 || this.Rc[1] < 1 || this.Rc[2] < 1 || this.Rc[3] < 1)
            {
                return false;
            }

            Wst.Range(Rc[0], Rc[1], Rc[2], Rc[3]).Style.Font.Bold = this.FontBold;

            return true;
        }
        /// <summary>
        /// フォントイタリック　R1C1形式　単一
        /// </summary>
        /// <returns></returns>
        public Boolean SetFontItalic()
        {
            if (this.Row < 1 || this.Col < 1)
            {
                return false;
            }

            Wst.Cell(this.Row, this.Col).Style.Font.Italic = this.Italic;

            return true;
        }

        #endregion

        #region フォント属性取得
        /// <summary>
        /// フォントタイプ取得
        /// </summary>
        /// <returns></returns>
        public Boolean GetFontType()
        {
            if (Row < 1 || Col < 1)
            {
                return false;
            }

            // セル値取得
            var cell = Wst.Cell(Row, Col);

            // Font名
            this.FontName = cell.Style.Font.FontName;

            return true;
        }
        /// <summary>
        /// フォントサイズ取得
        /// </summary>
        /// <returns></returns>
        public Boolean GetFontSize()
        {
            if (Row < 1 || Col < 1)
            {
                return false;
            }

            // セル値取得
            var cell = Wst.Cell(Row, Col);

            // Fontサイズ
            this.FontSize = cell.Style.Font.FontSize;

            return true;
        }
        /// <summary>
        /// フォント太字取得
        /// </summary>
        /// <returns></returns>
        public Boolean GetFontBold()
        {
            if (Row < 1 || Col < 1)
            {
                return false;
            }

            // セル値取得
            var cell = Wst.Cell(Row, Col);

            // Font太字
            this.FontBold = cell.Style.Font.Bold;

            return true;
        }
        /// <summary>
        /// フォントカラー
        /// </summary>
        /// <returns></returns>
        public Boolean GetFontColor()
        {
            if (Row < 1 || Col < 1)
            {
                return false;
            }

            // セル値取得
            var cell = Wst.Cell(Row, Col);

            // Fontカラー
            this.FontColor = cell.Style.Font.FontColor;

            return true;
        }
        /// <summary>
        /// フォントイタリック取得
        /// </summary>
        /// <returns></returns>
        public Boolean GetFontIta()
        {
            if (Row < 1 || Col < 1)
            {
                return false;
            }

            // セル値取得
            var cell = Wst.Cell(Row, Col);

            // Font太字
            this.Italic = cell.Style.Font.Italic;

            return true;
        }

        #endregion


        #region "Property定義"

        // ファイルパス
        public string PathName { get; set; }
        // ファイル名
        public string FileName { get; set; }
        // シート名
        public string SheetName { get; set; }


        // ワークブック
        public XLWorkbook Wbk { get; set; }
        // ワークシート
        public IXLWorksheet Wst { get; set; }


        // セル位置/シートポジション
        public int Position { get; set; }
        // Row
        public int Row { get; set; }
        // Col
        public int Col { get; set; }
        // StartRow,Col/EndRow,Col
        public int[] Rc = new int[4];
        // セル位置（ex. A2）
        public string Cell { get; set; }
        // 数値（各処理で使用 ex.挿入行数、開始行番号）
        public int Num { get; set; }


        // 最終行番号
        public int LastRowNo { get; set; }
        // 最終列番号取得
        public int LastColNo { get; set; }

        // 取得/設定値（文字値）
        public string StrValue { get; set; }
        // 取得/設定値（テキスト）
        public string StrText { get; set; }

        // 取得/設定値（数値）
        public int IntValue { get; set; }

        //取得/設定値（日付型）
        public DateTime DatValue { get; set; }

        // 取得/設定値（10進数浮動小数）
        public decimal DecValue { get; set; }

        // 取得値（2次元配列）
        public Object[,] Array { get; set; }


        // カラー
        public XLColor Color { get; set; }
        // バックカラーラベル
        public string BackColorLabel { get; set; }
        // 枠線
        public XLBorderStyleValues BorderStyle { get; set; }
        // 文字位置（平行）
        public XLAlignmentHorizontalValues AlignHori { get; set; }
        // 文字位置（垂直）
        public XLAlignmentVerticalValues AlignVart { get; set; }
        // フォントサイズ
        public double FontSize { get; set; }
        // フォント太字
        public Boolean FontBold { get; set; }
        // フォント太字ラベル
        public string FontBoldLabel { get; set; }
        // フォントカラー
        public XLColor FontColor { get; set; }
        // フォントカラーラベル
        public string FontColorLabel { get; set; }
        // フォントタイプ
        public string FontName { get; set; }
        // フォントイタリック
        public Boolean Italic { get; set; }
        // フォントイタリックラベル
        public string ItalicLabel { get; set; }

        #endregion
        #endregion

        #region "Ms"
        #region "オープン／クローズ"
        public Boolean MsOpenBook()
        {
            if (FileName == "" || SheetName == "")
            {
                return false;
            }

            Microsoft.Office.Interop.Excel.Application exl = new Microsoft.Office.Interop.Excel.Application();

            try
            {
                // ファイル名、シート名指定
                this.Mwb = exl.Workbooks.Open(FileName);
                this.Mst = this.Mwb.Sheets[SheetName];
                return true;

            }
            catch (Exception ex)
            {
                // エラー
                Console.WriteLine(ex.Message);
                return false;
                throw;
            }
            finally
            {
                exl = null;    
            }
        }

        public Boolean  MsOpenOnlyBook()
        {
            if (FileName == "" || SheetName == "")
            {
                return false;
            }

            Microsoft.Office.Interop.Excel.Application exl = new Microsoft.Office.Interop.Excel.Application();

            try
            {
                this.Mwb = exl.Workbooks.Open(FileName);

                return true;

            }
            catch (Exception ex)
            {
                // エラー
                Console.WriteLine(ex.Message);
                return false;
                throw;
            }
            finally
            {
                exl = null;
            }
        }


        public void MsCloseBook()
        {
            if (Mst != null) { Mst = null; }
            if (Mwb == null) { return; }
            Mwb.Close();
            Mwb = null;
        }
        #endregion

        #region "値取得"
        public void MsGetCellText()
        {
            try
            {
                Range rg = Mst.Cells[Row, Col];
                StrValue = "";
                StrValue = (string)rg.Value2; 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {

            }
        }
        public void MsGetCellValue()
        {
            try
            {
                Microsoft.Office.Interop.Excel.Range rg;
                rg = (Microsoft.Office.Interop.Excel.Range)Mst.Cells[Row, Col];

                StrValue = rg.Text; 

                // var StrValue =((Microsoft.Office.Interop.Excel.Range)Mst.Cells[Row, Col]).Text;



                // StrValue = Mst.Rows[Row].Cells[Col].Value;


                //Range rg = Mst.Cells[Row, Col];
                //StrValue = "";
                //StrValue = (string)rg.Value2;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {

            }
        }
        #endregion

        #region "ワークブック/シート"
        /// <summary>
        /// WorkBook
        /// </summary>
        private Microsoft.Office.Interop.Excel.Workbook _Mwb;
        public Microsoft.Office.Interop.Excel.Workbook Mwb
        {
            set { _Mwb = value; }
            get { return _Mwb; }
        }
        /// <summary>
        /// WorkSheet
        /// </summary>
        private Microsoft.Office.Interop.Excel.Worksheet _Mst;
        public Microsoft.Office.Interop.Excel.Worksheet Mst
        {
            set { _Mst = value; }
            get { return _Mst; }
        }
        #endregion





        #endregion

    }


    // COMオブジェクトを解放し忘れる典型的パターン
    //以下に、解放を忘れるパターンを示します。この記述を行うとCOMオブジェクトの解放し忘れにつながるため、使用してはいけません。この記述を見つけた場合、速やかに指摘してあげてください。

    //一気にOpen
    //一般的にC#でファイルをオープンするときは、以下の様な記述をすることがよくあります。
    //　　FileStream fs = System.IO.File.Open(filename, FileMode.Open);
    //    これと同じ感覚でExcelファイルのオープンを記述すると
    //    Workbook book = new Application().Workbooks.Open(ExcelFileName);
    //となりますが、ApplicationオブジェクトとWorkbooksオブジェクトをどの変数にも格納していないため、後々ReleaseComObject()で解放することができず、COMオブジェクトが残存します。COMオブジェクトを返すメソッドやプロパティでは、面倒でもひとつひとつ変数に格納して行きましょう。
    //Cellsプロパティ
    //セルの領域を取得する方法として、上ではRange[] アクセサーを使用する方法を紹介しましたが、Cellsプロパティを使用して取得することもできます。
    //　　　Range TableRange = sheet.Cells["A1", "B15"];
    //    しかし、CellsプロパティはCOMオブジェクトを返すので、上記の記述ではCellsを受け取る変数がおらず、COMオブジェクトを開放することができません。
    //　（実際はこうなっている）
    //　　Range TableRange = sheet.Cells.Range["A1", "B15"];
    //    Cellsプロパティを使用して各セルにアクセスする場合は、Cellsのオブジェクトを変数に格納し、そこから各セルのRangeオブジェクトをアクセサーで取得する必要があります。
    //　　Range cells = sheet.Cells; // cellsはあとでReleaseComObject()で解放する
    //    Range TableRange = cells["A1", "B15"];
    //    その他、COMオブジェクトを返すプロパティを、変数へ格納せずに使用している箇所はすべて解放忘れにつながります。発見次第、修正してください。COMオブジェクトを返すプロパティについては、Appendix.「COMオブジェクトを返すプロパティ」を参照してください。



}
