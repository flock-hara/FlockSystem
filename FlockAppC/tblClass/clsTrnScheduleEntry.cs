using FlockAppC.pubClass;
using System;
using System.Data;
using System.Text;

namespace FlockAppC.tblClass
{
    public class ClsTrnScheduleEntry
    {
        public DateTime ImportDate { get; set; }
        public int TantoID { get; set; }
        public string TantoName { get; set; }
        public DateTime Day { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string SheetName { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
        public string BackColor { get; set; }
        public int FontSize { get; set; }
        public string FontColor { get; set; }
        public string FontBold { get; set; }
        public string Value { get; set; }
        public string Comment { get; set; }
        public int CellType { get; set; }
        public int WeekType { get; set; }
        public int ContactFlag { get; set; }

        public int BackColorArgb { get; set; }
        public int FontColorArgb { get; set; }
        public int FontBoldInt { get; set; }
        public string CellText { get; set; }

        private readonly StringBuilder sb = new();

        /// <summary>
        /// 勤務表シフト情報 SELECT
        /// </summary>
        /// <param name="p_day"></param>
        /// <param name="p_id"></param>
        public void Select(DateTime p_day, int p_id)
        {
            try
            {
                // SQL Server
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" import_date");
                    sb.AppendLine(",tanto_id");
                    sb.AppendLine(",tanto_name");
                    sb.AppendLine(",day");
                    sb.AppendLine(",start_date");
                    sb.AppendLine(",end_date");
                    sb.AppendLine(",file_name");
                    sb.AppendLine(",file_path");
                    sb.AppendLine(",sheet_name");
                    sb.AppendLine(",year");
                    sb.AppendLine(",month");
                    sb.AppendLine(",row");
                    sb.AppendLine(",col");
                    sb.AppendLine(",back_color");
                    sb.AppendLine(",font_size");
                    sb.AppendLine(",font_color");
                    sb.AppendLine(",font_bold");
                    sb.AppendLine(",value");
                    sb.AppendLine(",comment");
                    sb.AppendLine(",cell_type");
                    sb.AppendLine(",week_type");
                    sb.AppendLine(",contact_flag");
                    sb.AppendLine(",back_color_argb");
                    sb.AppendLine(",font_color_argb");
                    sb.AppendLine(",font_bold_int");
                    sb.AppendLine(",cell_text");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Trn_勤務表シフト情報");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("Day = '" + p_day.ToString("yyyy/MM/dd") + "'");
                    sb.AppendLine("AND");
                    sb.AppendLine("tanto_id = " + p_id);

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            ImportDate = DateTime.Parse(dr["import_date"].ToString());
                            TantoID = int.Parse(dr["tanto_id"].ToString());
                            TantoName = dr["tanto_name"].ToString();
                            Day = DateTime.Parse(dr["day"].ToString());
                            StartDate = DateTime.Parse(dr["start_date"].ToString());
                            EndDate = DateTime.Parse(dr["end_date"].ToString());
                            FileName = dr["file_name"].ToString();
                            FilePath = dr["file_path"].ToString();
                            SheetName = dr["sheet_name"].ToString();
                            Year = int.Parse(dr["year"].ToString());
                            Month = int.Parse(dr["month"].ToString());
                            Row = int.Parse(dr["row"].ToString());
                            Col = int.Parse(dr["col"].ToString());
                            BackColor = dr["back_color"].ToString();
                            FontSize = int.Parse(dr["font_size"].ToString());
                            FontColor = dr["font_color"].ToString();
                            FontBold = dr["font_bold"].ToString();
                            Value = dr["value"].ToString();
                            Comment = dr["comment"].ToString();
                            //CellType = int.Parse(dr["CellType"].ToString());
                            //WeekType = int.Parse(dr["WeekType"].ToString());
                            CellType = 0;
                            WeekType = 0;
                            ContactFlag = int.Parse(dr["contact_flag"].ToString());

                            BackColorArgb = int.Parse(dr["back_color_argb"].ToString());
                            FontColorArgb = int.Parse(dr["font_color_argb"].ToString());
                            FontBoldInt = int.Parse(dr["font_bold_int"].ToString());
                            CellText = dr["cell_text"].ToString();

                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// 勤務表シフト情報 SELECT
        /// </summary>
        /// <param name="p_where"></param>
        public void Select2(string p_where)
        {
            try
            {
                // SQL Server
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" import_date");
                    sb.AppendLine(",tanto_id");
                    sb.AppendLine(",tanto_name");
                    sb.AppendLine(",day");
                    sb.AppendLine(",start_date");
                    sb.AppendLine(",end_date");
                    sb.AppendLine(",file_name");
                    sb.AppendLine(",file_path");
                    sb.AppendLine(",sheet_name");
                    sb.AppendLine(",year");
                    sb.AppendLine(",month");
                    sb.AppendLine(",row");
                    sb.AppendLine(",col");
                    sb.AppendLine(",back_color");
                    sb.AppendLine(",font_size");
                    sb.AppendLine(",font_color");
                    sb.AppendLine(",font_bold");
                    sb.AppendLine(",value");
                    sb.AppendLine(",comment");
                    sb.AppendLine(",cell_type");
                    sb.AppendLine(",week_type");
                    sb.AppendLine(",contact_flag");
                    sb.AppendLine(",back_color_argb");
                    sb.AppendLine(",font_color_argb");
                    sb.AppendLine(",font_bold_int");
                    sb.AppendLine(",cell_text");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Trn_勤務表シフト情報");
                    sb.AppendLine("WHERE");
                    sb.AppendLine(p_where);

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            ImportDate = DateTime.Parse(dr["import_date"].ToString());
                            TantoID = int.Parse(dr["tanto_id"].ToString());
                            TantoName = dr["tanto_name"].ToString();
                            Day = DateTime.Parse(dr["day"].ToString());
                            StartDate = DateTime.Parse(dr["start_date"].ToString());
                            EndDate = DateTime.Parse(dr["end_date"].ToString());
                            FileName = dr["file_name"].ToString();
                            FilePath = dr["file_path"].ToString();
                            SheetName = dr["sheet_name"].ToString();
                            Year = int.Parse(dr["year"].ToString());
                            Month = int.Parse(dr["month"].ToString());
                            Row = int.Parse(dr["row"].ToString());
                            Col = int.Parse(dr["col"].ToString());
                            BackColor = dr["back_color"].ToString();
                            FontSize = int.Parse(dr["font_size"].ToString());
                            FontColor = dr["font_color"].ToString();
                            FontBold = dr["font_bold"].ToString();
                            Value = dr["value"].ToString();
                            Comment = dr["comment"].ToString();
                            //CellType = int.Parse(dr["CellType"].ToString());
                            //WeekType = int.Parse(dr["WeekType"].ToString());
                            CellType = 0;
                            WeekType = 0;
                            ContactFlag = int.Parse(dr["contact_flag"].ToString());

                            BackColorArgb = int.Parse(dr["back_color_argb"].ToString());
                            FontColorArgb = int.Parse(dr["font_color_argb"].ToString());
                            FontBoldInt = int.Parse(dr["font_bold_int"].ToString());
                            CellText = dr["cell_text"].ToString();

                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
        }
    }
}
