using FlockAppC.pubClass;
using System;
using System.Data;
using System.Text;

namespace FlockAppC.tblClass
{
    public class ClsTrnScheduleChange
    {
        public DateTime RegDate {  get; set; }
        public int RegUserID { get; set; }
        public string RegUserName   { get; set; }
        public int TantoID { get; set; }
        public string TantoName { get; set; }
        public DateTime Day { get; set; }
        public string BeforeContent { get; set; }
        public string AfterContent { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
        public string Comment { get; set; }
        public string FileName { get; set; }
        public string SheetName { get; set; }
        public int CommentFlag { get; set; }
        public int DeleteFlag { get; set; }
        public int ConfirmFlag { get; set; }
        public int ConfirmUserID { get; set; }
        public string ConfirmUserName { get; set; }
        public string BeforeBackColor { get; set; }
        public int BeforeFontSize { get; set; }
        public string BeforeFontColor { get; set; }
        public string BeforeFontBold { get; set; }
        public string AfterBackColor { get; set; }
        public int AfterFontSize { get; set; }
        public string AfterFontColor { get; set; }
        public string AfterFontBold { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }

        public int BeforeBackColorArgb { get; set; }
        public int AfterBackColorArgb { get; set; }
        public int BeforeFontColorArgb { get; set; }
        public int AfterFontColorArgb { get; set; }
        public int BeforeFontBoldInt { get; set; }
        public int AfterFontBoldInt { get; set; }

        private readonly StringBuilder sb = new();

        /// <summary>
        /// ===============================================================================
        /// 変更データ取得　SELECT
        /// ===============================================================================
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
                    sb.AppendLine(" reg_date");
                    sb.AppendLine(",reg_user_id");
                    sb.AppendLine(",reg_user_name");
                    sb.AppendLine(",tanto_id");
                    sb.AppendLine(",tanto_name");
                    sb.AppendLine(",day");
                    sb.AppendLine(",before_content");
                    sb.AppendLine(",after_content");
                    sb.AppendLine(",row");
                    sb.AppendLine(",col");
                    sb.AppendLine(",comment");
                    sb.AppendLine(",file_name");
                    sb.AppendLine(",sheet_name");
                    sb.AppendLine(",comment_flag");
                    sb.AppendLine(",delete_flag");
                    sb.AppendLine(",confirm_flag");
                    sb.AppendLine(",confirm_user_id");
                    sb.AppendLine(",confirm_user_name");
                    sb.AppendLine(",before_back_color");
                    sb.AppendLine(",before_font_size");
                    sb.AppendLine(",before_font_color");
                    sb.AppendLine(",before_font_bold");
                    sb.AppendLine(",after_back_color");
                    sb.AppendLine(",after_font_size");
                    sb.AppendLine(",after_font_color");
                    sb.AppendLine(",after_font_bold");
                    sb.AppendLine(",year");
                    sb.AppendLine(",month");
                    sb.AppendLine(",before_back_color_argb");
                    sb.AppendLine(",after_back_color_argb");
                    sb.AppendLine(",before_font_color_argb");
                    sb.AppendLine(",after_font_color_argb");
                    sb.AppendLine(",before_font_bold_int");
                    sb.AppendLine(",after_font_bold_int");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Trn_勤務表シフト変更");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("delete_flag <> " + ClsPublic.FLAG_ON);
                    sb.AppendLine("AND");
                    sb.AppendLine("day = '" + p_day.ToString("yyyy/MM/dd") + "'");
                    sb.AppendLine("AND");
                    sb.AppendLine("tanto_id = " + p_id);

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            RegDate = DateTime.Parse(dr["reg_date"].ToString());
                            RegUserID = int.Parse(dr["reg_user_id"].ToString());
                            RegUserName = dr["reg_user_name"].ToString();
                            TantoID = int.Parse(dr["tanto_id"].ToString());
                            TantoName = dr["tanto_name"].ToString();
                            Day = DateTime.Parse(dr["day"].ToString());
                            BeforeContent = dr["before_content"].ToString();
                            AfterContent = dr["after_content"].ToString();
                            Row = int.Parse(dr["row"].ToString());
                            Col = int.Parse(dr["col"].ToString());
                            Comment = dr["comment"].ToString();
                            FileName = dr["file_name"].ToString();
                            SheetName = dr["sheet_name"].ToString();
                            CommentFlag = int.Parse(dr["comment_flag"].ToString());
                            DeleteFlag = int.Parse(dr["delete_flag"].ToString());
                            ConfirmFlag = int.Parse(dr["confirm_flag"].ToString());
                            ConfirmUserID = int.Parse(dr["confirm_user_id"].ToString());
                            ConfirmUserName = dr["confirm_user_name"].ToString();
                            BeforeBackColor = dr["before_back_color"].ToString();
                            BeforeFontSize = int.Parse(dr["before_font_size"].ToString());
                            BeforeFontColor = dr["before_font_color"].ToString();
                            BeforeFontBold = dr["before_font_bold"].ToString();
                            AfterBackColor = dr["after_back_color"].ToString();
                            AfterFontSize = int.Parse(dr["after_font_size"].ToString());
                            AfterFontColor = dr["after_font_color"].ToString();
                            AfterFontBold = dr["after_font_bold"].ToString();
                            Year = int.Parse(dr["year"].ToString());
                            Month = int.Parse(dr["month"].ToString());
                            BeforeBackColorArgb = int.Parse(dr["before_back_color_argb"].ToString());
                            AfterBackColorArgb = int.Parse(dr["after_back_color_argb"].ToString());
                            BeforeFontColorArgb = int.Parse(dr["before_font_color_argb"].ToString());
                            AfterFontColorArgb = int.Parse(dr["after_font_color_argb"].ToString());
                            BeforeFontBoldInt = int.Parse(dr["before_font_bold_int"].ToString());
                            AfterFontBoldInt = int.Parse(dr["after_font_bold_int"].ToString());
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
        /// ===============================================================================
        /// 更新　UPDATE
        /// ===============================================================================
        /// </summary>
        /// <param name="p_day"></param>
        /// <param name="p_id"></param>
        public void Update(DateTime p_day, int p_id)
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("UPDATE");
                    sb.AppendLine("Trn_勤務表シフト変更");
                    sb.AppendLine("SET");
                    sb.AppendLine("reg_date = '" + RegDate.ToString("yyyy/MM/dd") + "'");
                    sb.AppendLine(",reg_user_id = " + RegUserID );
                    sb.AppendLine(",reg_user_name = '" + RegUserName + "'");
                    sb.AppendLine(",after_content = '" + AfterContent + "'");
                    sb.AppendLine(",after_back_color = '" + AfterBackColor + "'");
                    sb.AppendLine(",after_font_size = " + AfterFontSize);
                    sb.AppendLine(",after_font_color = '" + AfterFontColor + "'");
                    sb.AppendLine(",after_font_bold = '" + AfterFontBold + "'");
                    sb.AppendLine(",comment = '" + Comment + "'");
                    sb.AppendLine(",confirm_flag = " + ConfirmFlag);
                    sb.AppendLine(",confirm_user_id = " + ConfirmUserID);
                    sb.AppendLine(",confirm_user_name = '" + ConfirmUserName + "'");
                    // 2025/11/11↓
                    sb.AppendLine(",upd_user_id = " + ClsLoginUser.StaffID);
                    sb.AppendLine(",upd_date = '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    // 2025/11/11↑
                    sb.AppendLine("WHERE");
                    sb.AppendLine("day = '" + p_day.ToString("yyyy/MM/dd") + "'");
                    sb.AppendLine("AND");
                    sb.AppendLine("tanto_id = " + p_id);

                    clsSqlDb.DMLUpdate(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// ===============================================================================
        /// コメント更新 UPDATE
        /// ===============================================================================
        /// </summary>
        /// <param name="p_day"></param>
        /// <param name="p_id"></param>
        public void UpdateComment(DateTime p_day,int p_id)
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("UPDATE");
                    sb.AppendLine("Trn_勤務表シフト変更");
                    sb.AppendLine("SET");
                    sb.AppendLine(" reg_date = '" + RegDate.ToString("yyyy/MM/dd") + "'");
                    sb.AppendLine(",reg_user_id = " + RegUserID);
                    sb.AppendLine(",reg_user_name = '" + RegUserName + "'");
                    sb.AppendLine(",comment = '" + Comment + "'");
                    // 2025/11/11↓
                    sb.AppendLine(",upd_user_id = " + ClsLoginUser.StaffID);
                    sb.AppendLine(",upd_date = '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    // 2025/11/11↑
                    sb.AppendLine("WHERE");
                    sb.AppendLine("day = '" + p_day.ToString("yyyy/MM/dd") + "'");
                    sb.AppendLine("AND");
                    sb.AppendLine("tanto_id = " + p_id);

                    clsSqlDb.DMLUpdate(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// ===============================================================================
        /// 追加登録 INSERT
        /// ===============================================================================
        /// </summary>
        public void Insert()
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("INSERT INTO");
                    sb.AppendLine("Trn_勤務表シフト変更");
                    sb.AppendLine("(");
                    sb.AppendLine(" reg_date");
                    sb.AppendLine(",reg_user_id");
                    sb.AppendLine(",reg_user_name");
                    sb.AppendLine(",tanto_id");
                    sb.AppendLine(",tanto_name");
                    sb.AppendLine(",day");
                    sb.AppendLine(",before_content");
                    sb.AppendLine(",after_content");
                    sb.AppendLine(",row");
                    sb.AppendLine(",col");
                    sb.AppendLine(",comment");
                    sb.AppendLine(",file_name");
                    sb.AppendLine(",sheet_name");
                    sb.AppendLine(",comment_flag");
                    sb.AppendLine(",delete_flag");
                    sb.AppendLine(",confirm_flag");
                    sb.AppendLine(",confirm_user_id");
                    sb.AppendLine(",confirm_user_name");
                    sb.AppendLine(",before_back_color");
                    sb.AppendLine(",before_font_size");
                    sb.AppendLine(",before_font_color");
                    sb.AppendLine(",before_font_bold");
                    sb.AppendLine(",after_back_color");
                    sb.AppendLine(",after_font_size");
                    sb.AppendLine(",after_font_color");
                    sb.AppendLine(",after_font_bold");
                    sb.AppendLine(",year");
                    sb.AppendLine(",month");
                    // 2025/11/11↓
                    sb.AppendLine(",ins_user_id");
                    sb.AppendLine(",ins_date");
                    // 2025/11/11↑
                    sb.AppendLine(") VALUES (");
                    sb.AppendLine("'" + RegDate.ToString("yyyy/MM/dd") + "'");
                    sb.AppendLine("," + RegUserID);
                    sb.AppendLine(",'" + RegUserName + "'");
                    sb.AppendLine("," + TantoID);
                    sb.AppendLine(",'" + TantoName + "'");
                    sb.AppendLine(",'" + Day.ToString("yyyy/MM/dd") + "'");
                    sb.AppendLine(",'" + BeforeContent + "'");
                    sb.AppendLine(",'" + AfterContent + "'");
                    sb.AppendLine("," + Row);
                    sb.AppendLine("," + Col);
                    sb.AppendLine(",'" + Comment + "'");
                    sb.AppendLine(",'" + FileName + "'");
                    sb.AppendLine(",'" + SheetName + "'");
                    sb.AppendLine("," + CommentFlag);
                    sb.AppendLine("," + DeleteFlag);
                    sb.AppendLine("," + ConfirmFlag);
                    sb.AppendLine("," + ConfirmUserID);
                    sb.AppendLine(",'" + ConfirmUserName + "'");
                    sb.AppendLine(",'" + BeforeBackColor + "'");
                    sb.AppendLine("," + BeforeFontSize);
                    sb.AppendLine(",'" + BeforeFontColor + "'");
                    sb.AppendLine(",'" + BeforeFontBold + "'");
                    sb.AppendLine(",'" + AfterBackColor + "'");
                    sb.AppendLine("," + AfterFontSize);
                    sb.AppendLine(",'" + AfterFontColor + "'");
                    sb.AppendLine(",'" + AfterFontBold + "'");
                    sb.AppendLine("," + Year);
                    sb.AppendLine("," + Month);
                    // 2025/11/11↓
                    sb.AppendLine("," + ClsLoginUser.StaffID);
                    sb.AppendLine(",'" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    // 2025/11/11↑
                    sb.AppendLine(")");

                    clsSqlDb.DMLUpdate(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// ===============================================================================
        /// 削除 DELETE
        /// ===============================================================================
        /// </summary>
        /// <param name="p_day"></param>
        /// <param name="p_id"></param>
        public void Delete(DateTime p_day, int p_id)
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("UPDATE");
                    sb.AppendLine("Trn_勤務表シフト変更");
                    sb.AppendLine("SET");
                    sb.AppendLine("delete_flag = " + ClsPublic.FLAG_ON);
                    sb.AppendLine("WHERE");
                    sb.AppendLine("day = '" + p_day.ToString("yyyy/MM/dd") + "'");
                    sb.AppendLine("AND");
                    sb.AppendLine("tanto_id = " + p_id);

                    clsSqlDb.DMLUpdate(sb.ToString());
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
