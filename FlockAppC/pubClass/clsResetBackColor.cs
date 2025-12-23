using System;
using System.Data;
using System.Text;

namespace FlockAppC.pubClass
{
    /// <summary>
    /// 変更の目印「黄色」のセルを元の色に戻す
    /// </summary>
    public class ClsResetBackColor
    {
        private readonly StringBuilder sb = new();

        public void ResetBackColor()
        {
            // ================================================================
            // 確認メッセージ
            // ================================================================
            // メッセージボックス
            using (pubForm.frmMessageBox frmMsg = new())
            {
                frmMsg.F_size_height = 133;
                frmMsg.F_button_case = 2;
                frmMsg.L_value = "エクセルの変更箇所（黄色）を元の色に戻します。" + Environment.NewLine + "実行すると元には戻せません。実行しますか？";
                frmMsg.L_alignment = "TopCenter";
                frmMsg.ShowDialog();
                if (frmMsg.F_result == 0) { return; }
            }

            // ================================================================
            // 処理中メッセージボックス
            // ================================================================
            pubForm.frmMessageBox frmMsg1 = new()
            {
                F_size_height = 95,
                F_button_case = 0,
                L_value = "黄色戻し処理中 ....."
            };
            frmMsg1.Show();
            frmMsg1.Refresh();

            ClsPublic.stcConfig[0] = new ClsConfig(1);
            ClsPublic.stcConfig[1] = new ClsConfig(2);

            string color;

            try
            {
                using (ClsMsExcel clsmx = new())
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    for (var i = 0; i < 2; i++)
                    {
                        if (ClsPublic.stcConfig[i].FilePath == "") break;

                        sb.Clear();
                        sb.AppendLine("SELECT");
                        sb.AppendLine(" tanto_id");
                        sb.AppendLine(",day");
                        sb.AppendLine(",year");
                        sb.AppendLine(",month");
                        sb.AppendLine(",row");
                        sb.AppendLine(",col");
                        sb.AppendLine(",back_color");
                        sb.AppendLine(",file_path");
                        sb.AppendLine(",sheet_name");
                        sb.AppendLine("FROM");
                        sb.AppendLine("Trn_勤務表シフト情報");
                        sb.AppendLine("WHERE");
                        sb.AppendLine("year = " + ClsPublic.stcConfig[i].Year);
                        sb.AppendLine("AND");
                        sb.AppendLine("month = " + ClsPublic.stcConfig[i].Month);
                        sb.AppendLine("AND");
                        sb.AppendLine("back_color = '" + ClsPublic.STR_YELLOW + "'");

                        using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                        {
                            if (dt_val.Rows.Count > 0)
                            {
                                // ｴｸｾﾙｵｰﾌﾟﾝ
                                // clsmx = new clsMsExcel();
                                clsmx.FileName = ClsPublic.stcConfig[i].FilePath;
                                clsmx.SheetName = ClsPublic.stcConfig[i].SheetName;
                                clsmx.OpenBook();

                                foreach (DataRow dr in dt_val.Rows)
                                {
                                    // 日付をもとにバックカラーを取得
                                    color = GetBackColor(dr["day"].ToString());

                                    // 元のバックカラー取得（日付列の色）
                                    clsmx.Row = int.Parse(dr["row"].ToString());
                                    clsmx.Col = 1;
                                    clsmx.GetCell();                // セルデータ取得
                                                                    // 勤務表（ｴｸｾﾙ）更新：取得した元のバックカラーに設定
                                    clsmx.Col = int.Parse(dr["col"].ToString());
                                    clsmx.SetBackColor();

                                    // Trn_勤務表シフト情報 更新
                                    sb.Clear();
                                    sb.AppendLine("UPDATE");
                                    sb.AppendLine("Trn_勤務表シフト情報");
                                    sb.AppendLine("SET");
                                    sb.AppendLine("back_color = '" + color + "'");
                                    sb.AppendLine("WHERE");
                                    sb.AppendLine("tanto_id = " + dr["tanto_id"].ToString());
                                    sb.AppendLine("AND");
                                    sb.AppendLine("day = '" + dr["day"].ToString() + "'");

                                    clsSqlDb.DMLUpdate(sb.ToString());

                                    // Trn_勤務表シフト変更　更新
                                    sb.Clear();
                                    sb.AppendLine("UPDATE");
                                    sb.AppendLine("Trn_勤務表シフト変更");
                                    sb.AppendLine("SET");
                                    sb.AppendLine("after_back_color = ''");
                                    sb.AppendLine("WHERE");
                                    sb.AppendLine("tanto_id = " + dr["tanto_id"].ToString());
                                    sb.AppendLine("AND");
                                    sb.AppendLine("day = '" + dr["day"].ToString() + "'");
                                    sb.AppendLine("AND");
                                    sb.AppendLine("delete_flag = 0");

                                    clsSqlDb.DMLUpdate(sb.ToString());
                                }
                                // 保存
                                clsmx.CloseSaveBook();
                            }
                        }
                    }
                }
                // 処理中メッセージクローズ
                frmMsg1.Close();
                frmMsg1.Dispose();

                // ================================================================
                // 終了メッセージボックス
                // ================================================================
                using (pubForm.frmMessageBox frmMsg3 = new())
                {
                    frmMsg3.F_size_height = 133;
                    frmMsg3.F_button_case = 1;
                    frmMsg3.L_value = "黄色戻し 処理が終了しました。";
                    frmMsg3.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (frmMsg1 != null) frmMsg1.Close();
            }
        }

        private string GetBackColor(string day)
        {
            string week = "";
            using (ClsMsExcel clsmx = new())
            {
                // string week = "SystemColor";
                week = ClsPublic.STR_SYSTEM;

                // 日付(day)からバックカラーを取得
                // 土曜：SaturDayColor
                // 日曜：SunDayColor
                // 祝祭日：HoliDayColor

                // 曜日を取得
                // DateTime today = DateTime.Now;
                string dayOfWeekJp = DateTime.Parse(day).ToString("ddd", new System.Globalization.CultureInfo("ja-JP"));
                if (dayOfWeekJp == "土")
                {
                    // week = "SaturDayColor";
                    week = ClsPublic.STR_SATURDAY;
                }
                else if (dayOfWeekJp == "日")
                {
                    // week = "SunDayColor";
                    week = ClsPublic.STR_SUNDAY;
                }
                else
                {
                    // 祝祭日か判定
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
                            sb.AppendLine("year = " + day.Substring(0, 4));
                            sb.AppendLine("AND");
                            sb.AppendLine("day = '" + day + "'");

                            using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                            {
                                foreach (DataRow dr in dt_val.Rows)
                                {
                                    // week = "HoliDayColor";
                                    week = ClsPublic.STR_HOLIDAY;
                                    break;
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
            return week;
        }
    }
}
