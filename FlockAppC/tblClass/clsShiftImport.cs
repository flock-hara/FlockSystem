using System;

namespace FlockAppC.tblClass
{
    public class ClsShiftImport
    {
        public DateTime Day {  get; set; }
        public int TantoId { get; set; }
        public string TantoName { get; set; }
        public string Value { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string SheetName { get; set; }
        public int Kbn {  get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
    }
}
