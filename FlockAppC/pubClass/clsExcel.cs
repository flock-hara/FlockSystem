using Microsoft.Office.Interop.Excel;
using ClosedXML.Excel;
using System;
using System.Linq;

namespace FlockAppC.pubClass
{

    public class clsExcel
    {
        /// <summary>
        /// WorkBook
        /// </summary>
        public XLWorkbook wkb { get; set; }
        /// <summary>
        /// WorkSheet
        /// </summary>
        public IXLWorksheet wst { get; set; }
        public string filename { get; set; }
        public string sheetname {  get; set; }

        /// <summary>
        /// WorkBook Open
        /// </summary>
        public void OpenBook()
        {
            // ファイル名、シート名指定
            wkb = new XLWorkbook(filename);
            wst = wkb.Worksheet(sheetname);
        }
        public void CloseBook()
        {



        }
    }
}
