using FlockAppC.pubClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FlockAppC.pubClass
{
    /// <summary>
    /// メール送信先クラス
    /// </summary>
    public class MailRecipient
    {
        public string user_name { get; set; }                // 担当者名
        public string mailaddress { get; set; }              // メールアドレス
    }

    /// <summary>
    ///  日報送信用データクラス
    /// </summary>
    public class clsSendMailData
    {
        public List<MailRecipient> mail_to { get; private set; }                               // メール送信先リスト

        // private string[] user_name { get; set; } = Array.Empty<string>();                // 担当者名リスト
        // private string[] mail_to { get; set; } = Array.Empty<string>();                     // メール送信先アドレスリスト
        private string mail_subject { get; set; } = string.Empty;                               // メール件名
        private string mail_body { get; set; } = string.Empty;                                   // メール本文   
        private string mail_attachment { get; set; } = string.Empty;                        // メール添付ファイルパス
        private string mail_from { get; set; } = string.Empty;                                   // メール送信元アドレス   
        private string report_day { get; set; } = string.Empty;                                  // 日報日付
        private string car_no { get; set; } = string.Empty;                                        // 車両番号

        // StringBuilder
        private StringBuilder sb = new StringBuilder();

        /// <summary>
        /// 日報変更発生通知メール送信用データクラス コンストラクタ
        /// </summary>
        /// <param name="location_id"></param>
        /// <param name="day"></param>
        /// <param name="car_no"></param>
        public clsSendMailData(int location_id,DateTime day,string car_no = "")
        {
            // メール送信先リスト初期化
            this.mail_to = new List<MailRecipient>();

            // 送信メール情報セット
            this.mail_from = ClsPublic.MAIL_FROM;
            this.mail_subject = "【Flock日報】日報変更発生通知";
            this.report_day = day.ToString("yyyy/MM/dd");
            this.car_no = car_no;

            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))       // DB接続(DBNoはシステム起動時にセット)
                {
                    sb.Clear();
                    // ■将来的にはパラメータクエリに変更すること
                    sb.AppendLine("SELECT user_name, mailaddress FROM Mst_専従先担当者 WHERE location_id = " + location_id);

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            // 担当者名、メールアドレスリスト作成
                            string name = dr["user_name"]?.ToString() ?? "";
                            string mail = dr["mailaddress"]?.ToString() ?? "";

                            // メールアドレスが空でなければ追加
                            if (!string.IsNullOrWhiteSpace(mail))
                            {
                                // メール送信先リストに追加
                                this.mail_to.Add(new MailRecipient
                                {
                                    user_name = name,
                                    mailaddress = mail
                                });
                            }
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
