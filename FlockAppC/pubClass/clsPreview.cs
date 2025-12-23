using System;
using System.Diagnostics;
using System.IO;

namespace FlockAppC.pubClass
{
    public class ClsPreview : IDisposable
    {
        public string File_name { get; set; }

        public void Dispose()
        {
            // this.Dispose();
        }

        /// <summary>
        /// ファイル存在チェック
        /// </summary>
        /// <returns></returns>
        public bool CheckFile()
        {
            if (File_name == "") return false;
            return File.Exists(File_name);
        }
        /// <summary>
        /// ファイル種類取得
        /// </summary>
        /// <returns>ファイル拡張子</returns>
        public string GetFileType()
        {
            if (File_name == "") return "";
            // ファイル拡張子を取得
            return Path.GetExtension(File_name);
        }
        /// <summary>
        /// ファイルプレビュー
        /// </summary>
        public void PreviewFile()
        {
            var typ = GetFileType();

            switch (typ)
            {
                // エクセル
                case ".xlsx":
                    XLSX_Preview(this.File_name);
                    break;
                case ".XLSX":
                    XLSX_Preview(this.File_name);
                    break;

                // エクセル（旧）
                case ".xls":
                    XLSX_Preview(this.File_name);
                    break;
                case ".XLS":
                    XLSX_Preview(this.File_name);
                    break;

                // ワード
                case ".docx":
                    DOCX_Preview(this.File_name);
                    break;
                case ".DOCX":
                    DOCX_Preview(this.File_name);
                    break;

                // ワード（旧）
                case ".doc":
                    DOCX_Preview(this.File_name);
                    break;
                case ".DOC":
                    DOCX_Preview(this.File_name);
                    break;

                // パワーポイント
                case ".pptx":
                    break;
                case ".PPTX":
                    break;

                // テキストファイル
                case ".txt":
                    TXT_Preview(this.File_name);
                    break;
                case ".TXT":
                    TXT_Preview(this.File_name);
                    break;

                // CSVファイル
                case ".csv":
                    XLSX_Preview(this.File_name);
                    break;
                case ".CSV":
                    XLSX_Preview(this.File_name);
                    break;

                // PDFファイル
                case ".pdf":
                    PDF_Preview(this.File_name);
                    break;
                case ".PDF":
                    PDF_Preview(this.File_name);
                    break;

                // 画像
                case ".jpg":
                    PIC_Preview(this.File_name);
                    break;
                case ".JPG":
                    PIC_Preview(this.File_name);
                    break;

                // 画像
                case ".png":
                    PIC_Preview(this.File_name);
                    break;
                case ".PNG":
                    PIC_Preview(this.File_name);
                    break;

                // 画像
                case ".bmp":
                    PIC_Preview(this.File_name);
                    break;
                case ".BMP":
                    PIC_Preview(this.File_name);
                    break;
            }
        }
        /// <summary>
        /// PDFファイル表示
        /// </summary>
        /// <param name="p_file_name"></param>
        public void PDF_Preview(string p_file_name)
        {
            // WebBrowser コントロールを使って PDF を表示
            // webBrowser1.Navigate(@"C:\path\to\your\file.pdf");

            // System.Diagnostics を使用して、外部ビューアで PDF を開く
            System.Diagnostics.Process.Start(p_file_name);
        }
        /// <summary>
        /// エクセル系ファイル表示
        /// </summary>
        /// <param name="p_file_name"></param>
        public void XLSX_Preview(string p_file_name)
        {
            // Excel を外部アプリケーションとして起動
            Process.Start(p_file_name);
        }
        /// <summary>
        /// ワード系ファイル表示
        /// </summary>
        /// <param name="p_file_name"></param>
        public void DOCX_Preview(string p_file_name)
        {
            // Excel を外部アプリケーションとして起動
            Process.Start(p_file_name);
        }
        /// <summary>
        /// テキストファイル表示
        /// </summary>
        /// <param name="p_file_name"></param>
        public void TXT_Preview(string p_file_name)
        {
            // Excel を外部アプリケーションとして起動
            Process.Start(p_file_name);
        }
        /// <summary>
        /// 画像ファイル表示
        /// </summary>
        /// <param name="p_file_name"></param>
        public void PIC_Preview(string p_file_name)
        {
            // Excel を外部アプリケーションとして起動
            Process.Start(p_file_name);
        }
    }
}
