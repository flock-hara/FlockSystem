using System;
using System.Data;
using System.Text;

namespace FlockAppC.pubClass
{
    public class ClsControllLocation
    {
        // Form Width
        public int PreWidth { get; set; }
        // Form Height
        public int PreHeight { get; set; }
        // Grid Width
        public int PreShiftGridWidth { get; set; }
        // Grid Height
        public int PreShiftGridHeight { get; set; }
        // Grid Cell Width
        public int PreShiftGridCellWidth { get; set; }
        // Grid Cell Height
        public int PreShiftGridCellHeight { get; set; }
        // Grid Columns Header Height
        public int PreColumnHeadHeight { get; set; }
        // Grid Rows Header Width
        public int PreRowHeadWidth { get; set; }
        // 連絡済ボタン：幅
        public int TantoBtnWidth { get; set; }
        // 連絡済ボタン：高さ
        public int TantoBtnHeight { get; set; }
        // 連絡済ボタン位置：X座標
        public int TantoBtnX { get; set; }
        // 連絡済ボタン位置：Y座標
        public int TantoBtnY { get; set; }
        // 閉じるボタン位置：X座標
        public int EndButtonX { get; set; }

        private readonly StringBuilder sb = new();

        /// <summary>
        /// コンストラクター
        /// </summary>
        public ClsControllLocation()
        {
            Get_location();
        }

        /// <summary>
        /// 位置情報取得
        /// </summary>
        private void Get_location()
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" pre_width");                       // Form幅
                    sb.AppendLine(",pre_height");                      // Form高さ
                    sb.AppendLine(",pre_shift_grid_width");            // Grid幅
                    sb.AppendLine(",pre_shift_grid_height");           // Grid高さ
                    sb.AppendLine(",pre_shift_grid_cell_width");       // セル幅
                    sb.AppendLine(",pre_shift_grid_cell_height");      // セル高さ
                    sb.AppendLine(",pre_column_head_height");          // 列ヘッダ高さ
                    sb.AppendLine(",pre_row_head_width");              // 行ヘッダ幅
                    sb.AppendLine(",tanto_btn_width");                 // 連絡済みパネル幅
                    sb.AppendLine(",tanto_btn_height");                // 連絡済みパネル高さ
                    sb.AppendLine(",tanto_btn_x");                     // 連絡済みパネル位置
                    sb.AppendLine(",end_button_x");                    // 閉じるボタン位置
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_画面サイズ");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        if (dt_val.Rows.Count > 0)
                        {
                            DataRow dr = dt_val.Rows[0];
                            PreWidth = Convert.ToInt32(dr["pre_width"]);
                            PreHeight = Convert.ToInt32(dr["pre_height"]);
                            PreShiftGridWidth = Convert.ToInt32(dr["pre_shift_grid_width"]);
                            PreShiftGridHeight = Convert.ToInt32(dr["pre_shift_grid_height"]);
                            PreShiftGridCellWidth = Convert.ToInt32(dr["pre_shift_grid_cell_width"]);
                            PreShiftGridCellHeight = Convert.ToInt32(dr["pre_shift_grid_cell_height"]);
                            PreColumnHeadHeight = Convert.ToInt32(dr["Pre_column_head_height"]);
                            PreRowHeadWidth = Convert.ToInt32(dr["pre_row_head_width"]);
                            TantoBtnWidth = Convert.ToInt32(dr["tanto_btn_width"]);
                            TantoBtnHeight = Convert.ToInt32(dr["tanto_btn_height"]);
                            TantoBtnX = Convert.ToInt32(dr["tanto_btn_x"]);
                            TantoBtnY = 50; // 固定値
                            EndButtonX = Convert.ToInt32(dr["end_button_x"]);
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
    }
}
