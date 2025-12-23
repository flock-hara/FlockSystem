using FlockAppC.tblClass;
using System;
using System.Data;

namespace FlockAppC.pubClass
{
    public static class clsPublicReport
    {
        // 一覧表示日報ID保持
        public static int[] pub_Id_list;
        public static int pub_Current_id;

        // 日報統計表CSV出力
        public static string pub_Csv_path;

        /// <summary>
        /// 時間の妥当性チェック（単一）
        /// </summary>
        /// <param name="inputTime"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static Boolean CheckInputTime(string inputTime, out string errorMessage)
        {
            errorMessage = string.Empty;

            // 時間形式の妥当性チェック
            if (!DateTime.TryParse(inputTime, out DateTime resultTime))
            {
                errorMessage = "時間の形式が正しくありません。";
                return false;
            }

            return true;
        }
        /// <summary>
        /// 時間の妥当性チェック（開始・終了）
        /// </summary>
        public static Boolean CheckInputStartEndTime(string startTime, string endTime,
                                        out string errorMessage)
        {
            errorMessage = string.Empty;

            // ① 時間形式の妥当性チェック
            if (!DateTime.TryParse(startTime, out DateTime actualStart))
            {
                errorMessage = "開始時間の形式が正しくありません。";
                return false;
            }
            if (!DateTime.TryParse(endTime, out DateTime actualEnd))
            {
                errorMessage = "終了時間の形式が正しくありません。";
                return false;
            }

            // ② 開始・終了の順序チェック
            if (actualStart >= actualEnd)
            {
                errorMessage = "開始時間は終了時間より前である必要があります。";
                return false;
            }

            return true;
        }

        /// <summary>
        /// 残業時間計算（7捨8入）
        /// </summary>
        /// <param name="actualStart">開始時間</param>
        /// <param name="actualEnd">終了時間</param>
        /// <param name="contractStart">開始契約時間</param>
        /// <param name="contractEnd">終了契約時間</param>
        /// <returns></returns>
        public static int CalcOvertimeMinutes(DateTime actualStart, DateTime actualEnd,
                               DateTime contractStart, DateTime contractEnd)
        {
            int overtime = 0;

            // 前残業：契約より早く開始した分
            double startDiff = (contractStart - actualStart).TotalMinutes; // 早いと正
            if (startDiff >= 8)
            {
                // 15分単位、7分以下切り捨て、8分以上切り上げ
                overtime += (int)Math.Round(startDiff / 15.0, MidpointRounding.AwayFromZero) * 15;
            }

            // 後残業：契約より遅く終了した分
            double endDiff = (actualEnd - contractEnd).TotalMinutes; // 遅いと正
            if (endDiff >= 8)
            {
                overtime += (int)Math.Round(endDiff / 15.0, MidpointRounding.AwayFromZero) * 15;
            }

            return overtime;
        }
        /// <summary>
        /// 経過時間（分）取得
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public static int CalcMinutes(DateTime startTime, DateTime endTime)
        {
            double diffMinutes = (endTime - startTime).TotalMinutes;

            return ((int)diffMinutes);
        }
        /// <summary>
        /// 日報データエクセル出力
        /// </summary>
        /// <param name="report_Id"></param>
        /// <param name="file_Name"></param>
        /// <param name="hikae_Flag"></param>
        public static void WriteReport(int report_Id, string file_Name,Boolean hikae_Flag)
        {
            try
            {
                string hikae_Sheet = string.Empty;
                if (hikae_Flag != true) { hikae_Sheet = "日報指示書"; }
                else { hikae_Sheet = "日報指示書_控え"; }

                    // エクセルクラス
                    ClsMsExcel clsMsExcel = new()
                    {
                        FileName = file_Name,
                        SheetName = hikae_Sheet
                    };

                // 日報データ取得
                ClsTrnReport clsTrnReport = new()
                {
                    Key_report_id = report_Id
                };
                clsTrnReport.SelectFromID();

                // 件数なし→処理終了
                if (clsTrnReport.Select_count == 0 || clsTrnReport.Select_count > 1) { return; }

                // エクセルファイルオープン
                clsMsExcel.OpenBook();

                // 日報データ読み込み
                foreach (DataRow dr in clsTrnReport.Dt.Rows)
                {
                    // 専従先名
                    clsMsExcel.Row = 2;
                    clsMsExcel.Col = 2;
                    clsMsExcel.Value = dr["location_name"].ToString();
                    clsMsExcel.SetCellValue();

                    // 日付（年）
                    clsMsExcel.Row = 2;
                    clsMsExcel.Col = 21;
                    clsMsExcel.Value = DateTime.Parse(dr["day"].ToString()).ToString("yyyy");
                    clsMsExcel.SetCellValue();
                    // 日付（月）
                    clsMsExcel.Row = 2;
                    clsMsExcel.Col = 24;
                    clsMsExcel.Value = DateTime.Parse(dr["day"].ToString()).ToString("MM");
                    clsMsExcel.SetCellValue();
                    // 日付（日）
                    clsMsExcel.Row = 2;
                    clsMsExcel.Col = 27;
                    clsMsExcel.Value = DateTime.Parse(dr["day"].ToString()).ToString("dd");
                    clsMsExcel.SetCellValue();
                    // 日付（曜日）
                    clsMsExcel.Row = 2;
                    clsMsExcel.Col = 30;
                    clsMsExcel.Value = "(" + DateTime.Parse(dr["day"].ToString()).ToString("ddd") + ")";
                    clsMsExcel.SetCellValue();

                    // 指示者
                    clsMsExcel.Row = 1;
                    clsMsExcel.Col = 38;
                    clsMsExcel.Value = dr["instructor_name"].ToString();
                    clsMsExcel.SetCellValue();

                    // 車両管理者
                    clsMsExcel.Row = 2;
                    clsMsExcel.Col = 38;
                    clsMsExcel.Value = dr["staff_name1"].ToString();
                    clsMsExcel.SetCellValue();

                    // 始業時間①
                    if (dr["start_time1"] != null && dr["start_time1"].ToString() != "")
                    {
                        clsMsExcel.Row = 4;
                        clsMsExcel.Col = 5;
                        clsMsExcel.Value = DateTime.Parse(dr["start_time1"].ToString()).ToString("t");
                        clsMsExcel.SetCellValue();
                    }

                    // 始業時間②
                    if (dr["start_time2"] != null && dr["start_time2"].ToString() != "")
                    {
                        clsMsExcel.Row = 5;
                        clsMsExcel.Col = 5;
                        clsMsExcel.Value = DateTime.Parse(dr["start_time2"].ToString()).ToString("t");
                        clsMsExcel.SetCellValue();
                    }

                    // 始業時間③
                    if (dr["start_time3"] != null && dr["start_time3"].ToString() != "")
                    {
                        clsMsExcel.Row = 6;
                        clsMsExcel.Col = 5;
                        clsMsExcel.Value = DateTime.Parse(dr["start_time3"].ToString()).ToString("t");
                        clsMsExcel.SetCellValue();
                    }

                    // 終業時間①
                    if (dr["end_time1"] != null && dr["end_time1"].ToString() != "")
                    {
                        clsMsExcel.Row = 7;
                        clsMsExcel.Col = 5;
                        clsMsExcel.Value = DateTime.Parse(dr["end_time1"].ToString()).ToString("t");
                        clsMsExcel.SetCellValue();
                    }

                    // 終業時間②
                    if (dr["end_time2"] != null && dr["end_time2"].ToString() != "")
                    {
                        clsMsExcel.Row = 8;
                        clsMsExcel.Col = 5;
                        clsMsExcel.Value = DateTime.Parse(dr["end_time2"].ToString()).ToString("t");
                        clsMsExcel.SetCellValue();
                    }

                    // 終業時間③
                    if (dr["end_time3"] != null && dr["end_time3"].ToString() != "")
                    {
                        clsMsExcel.Row = 9;
                        clsMsExcel.Col = 5;
                        clsMsExcel.Value = DateTime.Parse(dr["end_time3"].ToString()).ToString("t");
                        clsMsExcel.SetCellValue();
                    }

                    // 車両番号
                    clsMsExcel.Row = 4;
                    clsMsExcel.Col = 12;
                    clsMsExcel.Value = dr["car_no"].ToString();
                    clsMsExcel.SetCellValue();

                    // 入庫時メーター
                    if (dr["after_meter"] != null && dr["after_meter"].ToString() != "")
                    {
                        clsMsExcel.Row = 5;
                        clsMsExcel.Col = 14;
                        clsMsExcel.Value = dr["after_meter"].ToString();
                        clsMsExcel.SetCellValue();
                    }

                    // 出庫時メーター
                    if (dr["before_meter"] != null && dr["before_meter"].ToString() != "")
                    {
                        clsMsExcel.Row = 6;
                        clsMsExcel.Col = 14;
                        clsMsExcel.Value = dr["before_meter"].ToString();
                        clsMsExcel.SetCellValue();
                    }

                    // 走行キロメーター
                    if (dr["mileage"] != null && dr["mileage"].ToString() != "")
                    {
                        clsMsExcel.Row = 7;
                        clsMsExcel.Col = 14;
                        clsMsExcel.Value = dr["mileage"].ToString();
                        clsMsExcel.SetCellValue();
                    }

                    // 給油量
                    if (dr["fuel"] != null && dr["fuel"].ToString() != "")
                    {
                        clsMsExcel.Row = 8;
                        clsMsExcel.Col = 11;
                        clsMsExcel.Value = dr["fuel"].ToString();
                        clsMsExcel.SetCellValue();
                    }

                    // 給油時メーター
                    if (dr["fuel_meter"] != null && dr["fuel_meter"].ToString() != "")
                    {
                        clsMsExcel.Row = 8;
                        clsMsExcel.Col = 21;
                        clsMsExcel.Value = dr["fuel_meter"].ToString();
                        clsMsExcel.SetCellValue();
                    }

                    // オイル
                    if (dr["oil"] != null && dr["oil"].ToString() != "")
                    {
                        clsMsExcel.Row = 7;
                        clsMsExcel.Col = 30;
                        clsMsExcel.Value = dr["oil"].ToString();
                        clsMsExcel.SetCellValue();
                    }

                    // 灯油
                    if (dr["kerosene"] != null && dr["kerosene"].ToString() != "")
                    {
                        clsMsExcel.Row = 8;
                        clsMsExcel.Col = 30;
                        clsMsExcel.Value = dr["kerosene"].ToString();
                        clsMsExcel.SetCellValue();
                    }

                    // アルコールチェック値①
                    if (dr["alcohol1"] != null && dr["alcohol1"].ToString() != "")
                    {
                        clsMsExcel.Row = 11;
                        clsMsExcel.Col = 10;
                        clsMsExcel.Value = decimal.Parse(dr["alcohol1"].ToString()).ToString();
                        clsMsExcel.SetCellValue();
                    }

                    // アルコールチェック値②
                    if (dr["alcohol2"] != null && dr["alcohol2"].ToString() != "")
                    {
                        clsMsExcel.Row = 12;
                        clsMsExcel.Col = 10;
                        clsMsExcel.Value = decimal.Parse(dr["alcohol2"].ToString()).ToString();
                        clsMsExcel.SetCellValue();
                    }

                    // アルコールチェック値③
                    if (dr["alcohol3"] != null && dr["alcohol3"].ToString() != "")
                    {
                        clsMsExcel.Row = 13;
                        clsMsExcel.Col = 10;
                        clsMsExcel.Value = decimal.Parse(dr["alcohol3"].ToString()).ToString();
                        clsMsExcel.SetCellValue();
                    }

                    // アルコールチェック結果①
                    clsMsExcel.Row = 11;
                    if (int.Parse(dr["alcohol_check1"].ToString()) > 0)
                    {
                        clsMsExcel.Col = 17;
                        clsMsExcel.Value = "良";
                    }
                    //else
                    //{
                    //    clsMsExcel.Col = 18;
                    //    clsMsExcel.Value = "否";
                    //}
                    clsMsExcel.SetCellValue();

                    // アルコールチェック結果②
                    clsMsExcel.Row = 12;
                    if (int.Parse(dr["alcohol_check2"].ToString()) > 0)
                    {
                        clsMsExcel.Col = 17;
                        clsMsExcel.Value = "良";
                    }
                    //else
                    //{
                    //    clsMsExcel.Col = 18;
                    //    clsMsExcel.Value = "否";
                    //}
                    clsMsExcel.SetCellValue();

                    // アルコールチェック結果③
                    clsMsExcel.Row = 13;
                    if (int.Parse(dr["alcohol_check3"].ToString()) > 0)
                    {
                        clsMsExcel.Col = 17;
                        clsMsExcel.Value = "良";
                    }
                    //else
                    //{
                    //    clsMsExcel.Col = 18;
                    //    clsMsExcel.Value = "否";
                    //}
                    clsMsExcel.SetCellValue();

                    // 検温時間①
                    if (dr["temp_time1"] != null && dr["temp_time1"].ToString() != "")
                    {
                        clsMsExcel.Row = 11;
                        clsMsExcel.Col = 24;
                        clsMsExcel.Value = DateTime.Parse(dr["temp_time1"].ToString()).ToString("t");
                        clsMsExcel.SetCellValue();
                    }
                    // 検温時間②
                    if (dr["temp_time2"] != null && dr["temp_time2"].ToString() != "")
                    {
                        clsMsExcel.Row = 12;
                        clsMsExcel.Col = 24;
                        clsMsExcel.Value = DateTime.Parse(dr["temp_time2"].ToString()).ToString("t");
                        clsMsExcel.SetCellValue();
                    }
                    // 検温時間③
                    if (dr["temp_time3"] != null && dr["temp_time3"].ToString() != "")
                    {
                        clsMsExcel.Row = 13;
                        clsMsExcel.Col = 24;
                        clsMsExcel.Value = DateTime.Parse(dr["temp_time3"].ToString()).ToString("t");
                        clsMsExcel.SetCellValue();
                    }
                    // 検温①
                    if (dr["temp1"] != null && dr["temp1"].ToString() != "")
                    {
                        clsMsExcel.Row = 11;
                        clsMsExcel.Col = 28;
                        clsMsExcel.Value = dr["temp1"].ToString();
                        clsMsExcel.SetCellValue();
                    }
                    // 検温②
                    if (dr["temp2"] != null && dr["temp2"].ToString() != "")
                    {
                        clsMsExcel.Row = 12;
                        clsMsExcel.Col = 28;
                        clsMsExcel.Value = dr["temp2"].ToString();
                        clsMsExcel.SetCellValue();
                    }
                    // 検温③
                    if (dr["temp3"] != null && dr["temp3"].ToString() != "")
                    {
                        clsMsExcel.Row = 13;
                        clsMsExcel.Col = 28;
                        clsMsExcel.Value = dr["temp3"].ToString();
                        clsMsExcel.SetCellValue();
                    }

                    // 代車
                    if (dr["subcar_flag"] != null)
                    {
                        if (int.Parse(dr["subcar_flag"].ToString()) > 0)
                        {
                            clsMsExcel.Row = 4;
                            clsMsExcel.Col = 21;
                            clsMsExcel.Value = "代車";
                            clsMsExcel.SetCellValue();
                        }
                    }

                    // 備考
                    if (dr.IsNull("passenger_id") != true)
                    {
                        clsMsExcel.Row = 35;
                        clsMsExcel.Col = 2;
                        clsMsExcel.Value = "同乗者あり";
                        clsMsExcel.SetCellValue();
                    }
                    if (dr.IsNull("comment") != true)
                    {
                        clsMsExcel.Row = 34;
                        clsMsExcel.Col = 8;
                        clsMsExcel.Value = dr["comment"].ToString();
                        clsMsExcel.SetCellValue();
                    }

                    // 運行前点検１
                    if (dr.IsNull("inspection_check1") != true)
                    {
                        if (int.Parse(dr["inspection_check1"].ToString()) > 0)
                        {
                            clsMsExcel.Row = 16;
                            clsMsExcel.Col = 20;
                            clsMsExcel.Value = "良";
                            clsMsExcel.SetCellValue();

                        }
                        //else
                        //{
                        //    clsMsExcel.Row = 16;
                        //    clsMsExcel.Col = 21;
                        //    clsMsExcel.Value = "否";
                        //    clsMsExcel.SetCellValue();
                        //}
                    }
                    // 運行前点検２
                    if (dr.IsNull("inspection_check2") != true)
                    {
                        if (int.Parse(dr["inspection_check2"].ToString()) > 0)
                        {
                            clsMsExcel.Row = 17;
                            clsMsExcel.Col = 20;
                            clsMsExcel.Value = "良";
                            clsMsExcel.SetCellValue();

                        }
                        //else
                        //{
                        //    clsMsExcel.Row = 17;
                        //    clsMsExcel.Col = 21;
                        //    clsMsExcel.Value = "否";
                        //    clsMsExcel.SetCellValue();
                        //}
                    }
                    // 運行前点検３
                    if (dr.IsNull("inspection_check3") != true)
                    {
                        if (int.Parse(dr["inspection_check3"].ToString()) > 0)
                        {
                            clsMsExcel.Row = 18;
                            clsMsExcel.Col = 20;
                            clsMsExcel.Value = "良";
                            clsMsExcel.SetCellValue();

                        }
                        //else
                        //{
                        //    clsMsExcel.Row = 18;
                        //    clsMsExcel.Col = 21;
                        //    clsMsExcel.Value = "否";
                        //    clsMsExcel.SetCellValue();
                        //}
                    }
                    // 運行前点検４
                    if (dr.IsNull("inspection_check4") != true)
                    {
                        if (int.Parse(dr["inspection_check4"].ToString()) > 0)
                        {
                            clsMsExcel.Row = 16;
                            clsMsExcel.Col = 42;
                            clsMsExcel.Value = "良";
                            clsMsExcel.SetCellValue();

                        }
                        //else
                        //{
                        //    clsMsExcel.Row = 16;
                        //    clsMsExcel.Col = 43;
                        //    clsMsExcel.Value = "否";
                        //    clsMsExcel.SetCellValue();
                        //}
                    }
                    // 運行前点検５
                    if (dr.IsNull("inspection_check5") != true)
                    {
                        if (int.Parse(dr["inspection_check5"].ToString()) > 0)
                        {
                            clsMsExcel.Row = 17;
                            clsMsExcel.Col = 42;
                            clsMsExcel.Value = "良";
                            clsMsExcel.SetCellValue();

                        }
                        //else
                        //{
                        //    clsMsExcel.Row = 17;
                        //    clsMsExcel.Col = 43;
                        //    clsMsExcel.Value = "否";
                        //    clsMsExcel.SetCellValue();
                        //}
                        // 運行前点検６
                        if (dr.IsNull("inspection_check6") != true)
                        {
                            if (int.Parse(dr["inspection_check6"].ToString()) > 0)
                            {
                                clsMsExcel.Row = 18;
                                clsMsExcel.Col = 42;
                                clsMsExcel.Value = "良";
                                clsMsExcel.SetCellValue();

                            }
                            //else
                            //{
                            //    clsMsExcel.Row = 18;
                            //    clsMsExcel.Col = 43;
                            //    clsMsExcel.Value = "否";
                            //    clsMsExcel.SetCellValue();
                            //}
                        }
                        // 運行前点検７
                        if (dr.IsNull("inspection_check7") != true)
                        {
                            if (int.Parse(dr["inspection_check7"].ToString()) > 0)
                            {
                                clsMsExcel.Row = 19;
                                clsMsExcel.Col = 42;
                                clsMsExcel.Value = "無";
                                clsMsExcel.SetCellValue();

                            }
                            //else
                            //{
                            //    clsMsExcel.Row = 19;
                            //    clsMsExcel.Col = 43;
                            //    clsMsExcel.Value = "有";
                            //    clsMsExcel.SetCellValue();
                            //}
                        }

                        // 定期点検１
                        if (dr.IsNull("per_inspection_check1") != true)
                        {
                            if (int.Parse(dr["per_inspection_check1"].ToString()) > 0)
                            {
                                clsMsExcel.Row = 22;
                                clsMsExcel.Col = 20;
                                clsMsExcel.Value = "良";
                                clsMsExcel.SetCellValue();

                            }
                            //else
                            //{
                            //    clsMsExcel.Row = 22;
                            //    clsMsExcel.Col = 21;
                            //    clsMsExcel.Value = "否";
                            //    clsMsExcel.SetCellValue();
                            //}
                        }
                        // 定期点検２
                        if (dr.IsNull("per_inspection_check2") != true)
                        {
                            if (int.Parse(dr["per_inspection_check2"].ToString()) > 0)
                            {
                                clsMsExcel.Row = 23;
                                clsMsExcel.Col = 20;
                                clsMsExcel.Value = "良";
                                clsMsExcel.SetCellValue();

                            }
                            //else
                            //{
                            //    clsMsExcel.Row = 23;
                            //    clsMsExcel.Col = 21;
                            //    clsMsExcel.Value = "否";
                            //    clsMsExcel.SetCellValue();
                            //}
                        }
                        // 定期点検３
                        if (dr.IsNull("per_inspection_check3") != true)
                        {
                            if (int.Parse(dr["per_inspection_check3"].ToString()) > 0)
                            {
                                clsMsExcel.Row = 24;
                                clsMsExcel.Col = 20;
                                clsMsExcel.Value = "良";
                                clsMsExcel.SetCellValue();

                            }
                            //else
                            //{
                            //    clsMsExcel.Row = 24;
                            //    clsMsExcel.Col = 21;
                            //    clsMsExcel.Value = "否";
                            //    clsMsExcel.SetCellValue();
                            //}
                        }
                        // 定期点検４
                        if (dr.IsNull("per_inspection_check4") != true)
                        {
                            if (int.Parse(dr["per_inspection_check4"].ToString()) > 0)
                            {
                                clsMsExcel.Row = 25;
                                clsMsExcel.Col = 20;
                                clsMsExcel.Value = "良";
                                clsMsExcel.SetCellValue();

                            }
                            //else
                            //{
                            //    clsMsExcel.Row = 25;
                            //    clsMsExcel.Col = 21;
                            //    clsMsExcel.Value = "否";
                            //    clsMsExcel.SetCellValue();
                            //}
                        }
                        // 定期点検５
                        if (dr.IsNull("per_inspection_check5") != true)
                        {
                            if (int.Parse(dr["per_inspection_check5"].ToString()) > 0)
                            {
                                clsMsExcel.Row = 26;
                                clsMsExcel.Col = 20;
                                clsMsExcel.Value = "良";
                                clsMsExcel.SetCellValue();

                            }
                            //else
                            //{
                            //    clsMsExcel.Row = 26;
                            //    clsMsExcel.Col = 21;
                            //    clsMsExcel.Value = "否";
                            //    clsMsExcel.SetCellValue();
                            //}
                        }
                        // 定期点検６
                        if (dr.IsNull("per_inspection_check6") != true)
                        {
                            if (int.Parse(dr["per_inspection_check6"].ToString()) > 0)
                            {
                                clsMsExcel.Row = 27;
                                clsMsExcel.Col = 20;
                                clsMsExcel.Value = "良";
                                clsMsExcel.SetCellValue();

                            }
                            //else
                            //{
                            //    clsMsExcel.Row = 27;
                            //    clsMsExcel.Col = 21;
                            //    clsMsExcel.Value = "否";
                            //    clsMsExcel.SetCellValue();
                            //}
                        }
                        // 定期点検７
                        if (dr.IsNull("per_inspection_check7") != true)
                        {
                            if (int.Parse(dr["per_inspection_check7"].ToString()) > 0)
                            {
                                clsMsExcel.Row = 28;
                                clsMsExcel.Col = 20;
                                clsMsExcel.Value = "良";
                                clsMsExcel.SetCellValue();

                            }
                            //else
                            //{
                            //    clsMsExcel.Row = 28;
                            //    clsMsExcel.Col = 21;
                            //    clsMsExcel.Value = "否";
                            //    clsMsExcel.SetCellValue();
                            //}
                        }
                        // 定期点検８
                        if (dr.IsNull("per_inspection_check8") != true)
                        {
                            if (int.Parse(dr["per_inspection_check8"].ToString()) > 0)
                            {
                                clsMsExcel.Row = 22;
                                clsMsExcel.Col = 42;
                                clsMsExcel.Value = "良";
                                clsMsExcel.SetCellValue();

                            }
                            //else
                            //{
                            //    clsMsExcel.Row = 22;
                            //    clsMsExcel.Col = 43;
                            //    clsMsExcel.Value = "否";
                            //    clsMsExcel.SetCellValue();
                            //}
                        }
                        // 定期点検９
                        if (dr.IsNull("per_inspection_check9") != true)
                        {
                            if (int.Parse(dr["per_inspection_check9"].ToString()) > 0)
                            {
                                clsMsExcel.Row = 23;
                                clsMsExcel.Col = 42;
                                clsMsExcel.Value = "良";
                                clsMsExcel.SetCellValue();

                            }
                            //else
                            //{
                            //    clsMsExcel.Row = 23;
                            //    clsMsExcel.Col = 43;
                            //    clsMsExcel.Value = "否";
                            //    clsMsExcel.SetCellValue();
                            //}
                        }
                        // 定期点検１０
                        if (dr.IsNull("per_inspection_check10") != true)
                        {
                            if (int.Parse(dr["per_inspection_check10"].ToString()) > 0)
                            {
                                clsMsExcel.Row = 24;
                                clsMsExcel.Col = 42;
                                clsMsExcel.Value = "良";
                                clsMsExcel.SetCellValue();

                            }
                            //else
                            //{
                            //    clsMsExcel.Row = 24;
                            //    clsMsExcel.Col = 43;
                            //    clsMsExcel.Value = "否";
                            //    clsMsExcel.SetCellValue();
                            //}
                        }
                        // 定期点検１１
                        if (dr.IsNull("per_inspection_check11") != true)
                        {
                            if (int.Parse(dr["per_inspection_check11"].ToString()) > 0)
                            {
                                clsMsExcel.Row = 25;
                                clsMsExcel.Col = 42;
                                clsMsExcel.Value = "良";
                                clsMsExcel.SetCellValue();

                            }
                            //else
                            //{
                            //    clsMsExcel.Row = 25;
                            //    clsMsExcel.Col = 43;
                            //    clsMsExcel.Value = "否";
                            //    clsMsExcel.SetCellValue();
                            //}
                        }
                        // 定期点検１２
                        if (dr.IsNull("per_inspection_check12") != true)
                        {
                            if (int.Parse(dr["per_inspection_check12"].ToString()) > 0)
                            {
                                clsMsExcel.Row = 26;
                                clsMsExcel.Col = 42;
                                clsMsExcel.Value = "良";
                                clsMsExcel.SetCellValue();

                            }
                            //else
                            //{
                            //    clsMsExcel.Row = 26;
                            //    clsMsExcel.Col = 43;
                            //    clsMsExcel.Value = "否";
                            //    clsMsExcel.SetCellValue();
                            //}
                        }
                        // 定期点検１３
                        if (dr.IsNull("per_inspection_check13") != true)
                        {
                            if (int.Parse(dr["per_inspection_check13"].ToString()) > 0)
                            {
                                clsMsExcel.Row = 27;
                                clsMsExcel.Col = 42;
                                clsMsExcel.Value = "良";
                                clsMsExcel.SetCellValue();

                            }
                            //else
                            //{
                            //    clsMsExcel.Row = 27;
                            //    clsMsExcel.Col = 43;
                            //    clsMsExcel.Value = "否";
                            //    clsMsExcel.SetCellValue();
                            //}
                        }
                        // 定期点検１４
                        if (dr.IsNull("per_inspection_check14") != true)
                        {
                            if (int.Parse(dr["per_inspection_check14"].ToString()) > 0)
                            {
                                clsMsExcel.Row = 28;
                                clsMsExcel.Col = 42;
                                clsMsExcel.Value = "良";
                                clsMsExcel.SetCellValue();

                            }
                            //else
                            //{
                            //    clsMsExcel.Row = 28;
                            //    clsMsExcel.Col = 43;
                            //    clsMsExcel.Value = "否";
                            //    clsMsExcel.SetCellValue();
                            //}
                        }

                        // 大型１
                        if (dr.IsNull("large_inspection_check1") != true)
                        {
                            if (int.Parse(dr["large_inspection_check1"].ToString()) > 0)
                            {
                                clsMsExcel.Row = 31;
                                clsMsExcel.Col = 20;
                                clsMsExcel.Value = "良";
                                clsMsExcel.SetCellValue();

                            }
                            //else
                            //{
                            //    clsMsExcel.Row = 31;
                            //    clsMsExcel.Col = 21;
                            //    clsMsExcel.Value = "否";
                            //    clsMsExcel.SetCellValue();
                            //}
                        }
                        // 大型２
                        if (dr.IsNull("large_inspection_check2") != true)
                        {
                            if (int.Parse(dr["large_inspection_check2"].ToString()) > 0)
                            {
                                clsMsExcel.Row = 32;
                                clsMsExcel.Col = 20;
                                clsMsExcel.Value = "良";
                                clsMsExcel.SetCellValue();

                            }
                            //else
                            //{
                            //    clsMsExcel.Row = 32;
                            //    clsMsExcel.Col = 21;
                            //    clsMsExcel.Value = "否";
                            //    clsMsExcel.SetCellValue();
                            //}
                        }
                        // 大型３
                        if (dr.IsNull("large_inspection_check3") != true)
                        {
                            if (int.Parse(dr["large_inspection_check3"].ToString()) > 0)
                            {
                                clsMsExcel.Row = 31;
                                clsMsExcel.Col = 42;
                                clsMsExcel.Value = "無";
                                clsMsExcel.SetCellValue();

                            }
                            //else
                            //{
                            //    clsMsExcel.Row = 31;
                            //    clsMsExcel.Col = 43;
                            //    clsMsExcel.Value = "有";
                            //    clsMsExcel.SetCellValue();
                            //}
                        }
                        // 大型４
                        if (dr.IsNull("large_inspection_check4") != true)
                        {
                            if (int.Parse(dr["large_inspection_check4"].ToString()) > 0)
                            {
                                clsMsExcel.Row = 32;
                                clsMsExcel.Col = 42;
                                clsMsExcel.Value = "無";
                                clsMsExcel.SetCellValue();
                            }
                            //else
                            //{
                            //    clsMsExcel.Row = 32;
                            //    clsMsExcel.Col = 43;
                            //    clsMsExcel.Value = "有";
                            //    clsMsExcel.SetCellValue();
                            //}
                        }
                    }
                }
                // 保存して閉じる
                clsMsExcel.CloseSaveBook();
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
        }
    }
}
