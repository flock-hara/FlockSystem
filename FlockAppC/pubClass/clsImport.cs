using System;

namespace FlockAppC.pubClass
{
    public class ClsImport
    {
        // 読み込みファイル名
        public string ImportFileName { get; set; }
        // 読み込みシート名
        public string ImportSheetName { get; set; }
        // 読み込み日付
        public DateTime ImportDate { get; set; }
        // 担当者ID
        public int TantoId { get; set; }
        // 担当者名
        public string TantoName { get; set; }
        // 予定日付
        public DateTime Day { get; set; }
        // 開始日付
        public DateTime StartDate { get; set; }
        // 終了日付
        public DateTime EndDate { get; set; }
        // 読み込みファイル名
        public string FileName { get; set; }
        // 読み込みパス名
        public string FilePath { get; set; }
        // 読み込みシート名
        public string SheetName { get; set; }
        // 対象年
        public int Year { get; set; }
        // 対象月
        public int Month { get; set; }
        // 読み込みセルRow
        public int Row { get; set; }
        // 読み込みセルCol
        public int Col { get; set; }
        // セルバックカラーコード
        public long BackColorCode { get; set; }
        // セルバックカラー名称
        public string BackColor { get; set; }
        // フォントタイプ
        public string FontName { get; set; }
        // フォントサイズ
        public int FontSize { get; set; }
        // フォントカラーコード
        public long FontColorCode { get; set; }
        // フォントカラー名称
        public string FontColor { get; set; }
        // フォント太字
        public string FontBold { get; set; }
        // フォントイタリック
        public string FontItalic { get; set; }
        // セル値
        public string Value { get; set; }
        // セルテキスト
        public string Text { get; set; }
        // 備考
        public string Comment { get; set; }
        // セルタイプ
        public int CellType { get; set; }
        // 曜日タイプ
        public int WeekType {  get; set; }
        // 連絡済フWグ
        public int ContactFlag {  get; set; }
    }
}
