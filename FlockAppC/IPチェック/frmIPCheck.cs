using FlockAppC.pubClass;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
// 手動送信時に使用
// using Microsoft.Office.Interop.Outlook;

namespace FlockAppC
{
    // 手動送信時に使用
    // using Outlook = Microsoft.Office.Interop.Outlook;

    public partial class frmIPCheck : Form
    {
        /// <summary>
        /// プロパティ
        /// </summary>
        public DataTable dt;

        private readonly StringBuilder sb = new();


        public frmIPCheck()
        {
            InitializeComponent();
        }

        /// <summary>
        /// form loadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmIPCheck_Load(object sender, EventArgs e)
        {
            // IP情報取得、表示
            GetIP();

            // IPが変更されている場合、メッセージ表示
            if (this.txtIP.Text != this.txtNewIP.Text)
            {
                lblMsg.Visible = true;              // メッセージ表示
                // btnUpdate.Visible = true;           // 更新ボタン表示
                // btnSendMail.Visible = false;        // メール送信ボタン非表示
            }
        }

        /// <summary>
        /// form shownイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmIPCheck_Shown(object sender, EventArgs e)
        {
            this.btnClose.Focus();
        }

        /// <summary>
        /// ■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
        /// New DB Controller対応済
        /// ■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
        /// IPアドレス取得（DB、最新）
        /// </summary>
        public void GetIP()
        {
            try
            {
                // DBから日付、IP取得
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    // 画面初期化
                    this.txtDay.Text = "";
                    this.txtIP.Text = "";
                    this.txtNewIP.Text = "";

                    // 登録日、IP取得
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" update_ip_day");
                    sb.AppendLine(",ip");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_GlobalIP");
                    sb.AppendLine("WHERE");
                    sb.AppendLine(" id = 1");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            // IP更新日付
                            if (dr["update_ip_day"] is DBNull)
                            {
                                // 未登録の場合、当日日付をセット
                                this.txtDay.Text = DateTime.Now.ToString("yyyy/MM/dd");
                            }
                            else
                            {
                                // 更新日付をセット
                                this.txtDay.Text = ((DateTime)dr["update_ip_day"]).ToString("yyyy/MM/dd");
                            }
                            // 登録IP
                            if (dr["ip"] is DBNull)
                            {
                                this.txtIP.Text = "";
                            }
                            else
                            {
                                this.txtIP.Text = (string)dr["ip"];
                            }
                        }
                    }
                }

                //最新のIPをコマンドで取得
                // curlコマンドにて最新IP取得
                txtNewIP.Text = GetGlobalIP();
            }
            catch (System.Exception ex)
            {
                ClsLogger.Log(ex.ToString());
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Global IP Address取得
        /// </summary>
        /// <returns></returns>
        public string GetGlobalIP()
        {
            try
            {
                // Processオブジェクトを作成
                System.Diagnostics.Process cmd = new();

                // ComSpec(cmd.exe)のパスを取得して、FileNameプロパティに指定
                cmd.StartInfo.FileName = System.Environment.GetEnvironmentVariable("ComSpec");

                // 出力を読み取れるようにする
                cmd.StartInfo.UseShellExecute = false;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.RedirectStandardInput = false;

                // ウィンドウを表示しないようにする
                cmd.StartInfo.CreateNoWindow = true;

                // コマンドラインを指定（先頭の「/c」は実行後閉じるために必要）
                cmd.StartInfo.Arguments = "/c curl inet-ip.info/ip";

                // 起動
                cmd.Start();

                // 出力を読み取る
                string result = cmd.StandardOutput.ReadToEnd();

                // プロセス終了まで待機する
                // WaitForExitはReadToEndの後である必要がある(親プロセス、子プロセスでブロック防止のため)
                cmd.WaitForExit();
                cmd.Close();

                //出力された結果を表示
                return result;   // .Trim() ※1

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// ■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
        /// New DB Controller対応済
        /// ■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
        /// 更新ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using(ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" id");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_GlobalIP");
                    sb.AppendLine("WHERE");
                    sb.AppendLine(" id = 1");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        if (dt_val.Rows.Count < 1)
                        {
                            // INSERT
                            sb.Length = 0;
                            sb.AppendLine("INSERT INTO");
                            sb.AppendLine("Mst_GlobalIP");
                            sb.AppendLine("(update_ip_day");
                            sb.AppendLine(",ip)");
                            sb.AppendLine("VALUES");
                            sb.AppendLine("(");
                            sb.AppendLine("'" + DateTime.Now.ToString("yyyy/MM/dd") + "'");
                            sb.AppendLine(",'" + txtNewIP.Text + "'");
                            sb.AppendLine(")");
                        }
                        else
                        {
                            // UPDATE
                            sb.Length = 0;
                            sb.AppendLine("UPDATE");
                            sb.AppendLine("Mst_GlobalIP");
                            sb.AppendLine("SET");
                            sb.AppendLine(" update_ip_day = '" + DateTime.Now.ToString("yyyy/MM/dd") + "'");
                            sb.AppendLine(",ip = '" + txtNewIP.Text + "'");
                            sb.AppendLine("WHERE");
                            sb.AppendLine(" id = 1");
                        }
                        clsSqlDb.DMLUpdate(sb.ToString());
                    }
                }

                // 画面再表示
                GetIP();

                this.lblMsg.Visible = false;                // メッセージ非表示
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Closeボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        /// <summary>
        /// IPアドレス変更通知メール作成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSendMail_Click(object sender, EventArgs e)
        {
            //string strMsg;

            //strMsg = "IPアドレス変更通知メールを送りますか？";
            //strMsg = strMsg + Environment.NewLine;
            //strMsg = strMsg + " => saitama269@flock.co.jp";
            //strMsg = strMsg + Environment.NewLine;
            //strMsg = strMsg + " => sakata@flock.co.jp";
            //strMsg = strMsg + Environment.NewLine;
            //strMsg = strMsg + " => nagaya@flock.co.jp";
            //strMsg = strMsg + Environment.NewLine;
            //strMsg = strMsg + " => hiramoto@flock.co.jp";
            //if (MessageBox.Show(strMsg, "確認", MessageBoxButtons.OKCancel ) == DialogResult.Cancel)
            //{
            //    return;
            //}

            // 自動送信
            SendMailAsync("", "");

            // ↓手動送信
            //StringBuilder stb = new StringBuilder();

            //// Mail送信画面
            //// outlookメールの立ち上げ
            //var application = new Outlook.Application();
            //MailItem mailItem = application.CreateItem(OlItemType.olMailItem);

            //if (mailItem != null)
            //{
            //    // To
            //    // さいたま営業所、坂田さん、長屋さん
            //    Recipient to = mailItem.Recipients.Add("hara.flock@gmail.com; mebaru.dog@gmail.com");
            //    to.Type = (int)Outlook.OlMailRecipientType.olTo;

            //    // Cc
            //    // Recipient cc = mailItem.Recipients.Add("YYY@YYY.co.jp");
            //    // cc.Type = (int)Outlook.OlMailRecipientType.olCC;

            //    // アドレス帳の表示名で表示できる
            //    // mailItem.Recipients.ResolveAll();

            //    // 件名
            //    mailItem.Subject = "★VPN IPアドレス変更のお知らせ(フロック本社)★";

            //    // 添付ファイル
            //    mailItem.Attachments.Add("\\\\Flockserver2017\\共有\\共通ホルダー\\個人用  ドキュメント\\システム関連\\1.インフラ\\VPN関連\\VPNが接続出来ない場合.xlsx");

            //    // 本文
            //    stb.AppendLine("VPNで使用しているIPアドレスが変更されました。");
            //    stb.AppendLine("");
            //    stb.AppendLine("添付ファイルの手順に沿って、IPアドレスを変更してください。");
            //    stb.AppendLine("※手順④だけでOK");
            //    stb.AppendLine("");
            //    stb.AppendLine("■新しいIPアドレス ==>> " + txtNewIP.Text);

            //    mailItem.Body = stb.ToString();

            //    // 表示(Displayメソッド引数のtrue/falseでモーダル/モードレスウィンドウを指定して表示できる)
            //    mailItem.Display(true);
            //}
            // ↑手動送信
        }

        /// <summary>
        /// ■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
        /// New DB Controller対応済
        /// ■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
        /// Mail送信処理
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        // static async void SendMailAsync(string userName, string password)
        public async void SendMailAsync(string userName, string password)
        {
            string strMsg;
            // StringBuilder sb = new StringBuilder();

            // MimeMessageを作り、宛先やタイトルなどを設定する
            var message = new MimeKit.MimeMessage();
            message.From.Add(new MimeKit.MailboxAddress("サーバー管理者", "mngtk@flock.co.jp"));

            // 通知対象アドレス取得
            try
            {
                using(ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" mail_address");
                    sb.AppendLine(",name");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_システム通知対象");
                    sb.AppendLine("WHERE");
                    sb.AppendLine(" enable = 1");
                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        if (dt_val.Rows.Count < 1)
                        {
                            return;
                        }

                        // 送信確認メッセージ
                        strMsg = "IPアドレス変更通知メールを送りますか？";

                        // 通知対象メールアドレス設定
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            // 宛先
                            message.To.Add(new MimeKit.MailboxAddress(dr["name"].ToString(), dr["mail_address"].ToString()));

                            // 確認メッセージ用
                            strMsg += Environment.NewLine;
                            strMsg += " => " + dr["mail_address"].ToString();
                        }
                        // 送信確認メッセージ
                        if (MessageBox.Show(strMsg, "確認", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                        {
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            // message.To.Add(new MimeKit.MailboxAddress("MailKit 試験1", "hara@flock.co.jp")) ;
            // message.Cc.Add(……省略……);
            // message.Bcc.Add(……省略……);

            message.Subject = "■グローバルIPアドレス変更通知■";

            // 本文を作る
            sb.Length = 0;
            sb.AppendLine("[本社内のNASを外部から使用している担当者向けの通知です]");
            sb.AppendLine("");
            sb.AppendLine("NAS接続で使用しているIPアドレスが変更されました。");
            sb.AppendLine("現在の設定を変更しないとNASに接続出来ません。");
            sb.AppendLine("添付ファイルの手順に沿って、IPアドレスを変更してください。");
            sb.AppendLine("");
            sb.AppendLine("■新しいIPアドレス ==>> " + txtNewIP.Text);
            sb.AppendLine("");
            sb.AppendLine("※本メールに対して返信は出来ません。");

            var textPart = new MimeKit.TextPart(MimeKit.Text.TextFormat.Plain);
            // textPart.Text = @"MailKit を使ってメールを送ってみるテストです。";
            textPart.Text = @sb.ToString();

            // ↓添付ファイルがある時の処理
            var path = @"\\Flockserver2017\共有\共通ホルダー\個人用  ドキュメント\システム関連\1.インフラ\VPN関連\IPアドレス変更手順.xlsx";    // 添付したいファイル
            // var attachment = new MimeKit.MimePart("image", "jpeg")
            var attachment = new MimeKit.MimePart()
            {
                Content = new MimeKit.MimeContent(System.IO.File.OpenRead(path)),
                ContentDisposition = new MimeKit.ContentDisposition(),
                ContentTransferEncoding = MimeKit.ContentEncoding.Base64,
                FileName = System.IO.Path.GetFileName(path)
            };

            var multipart = new MimeKit.Multipart("mixed");
            multipart.Add(textPart);
            multipart.Add(attachment);

            message.Body = multipart;
            // ↑添付ファイルがある時の処理

            //// MimeMessageを完成させる
            //添付がない時
            //message.Body = textPart;

            // SMTPサーバに接続してメールを送信する
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
#if DEBUG
                // 開発用のSMTPサーバが暗号化に対応していないときは、次の行を追加する
                //client.ServerCertificateValidationCallback = (s, c, h, e) => true;
#endif
                try
                {
                    // await client.ConnectAsync("smtp.***.com", 587);
                    await client.ConnectAsync("sv211.sixcore.ne.jp", 587);
                    Console.WriteLine("接続完了");

                    // SMTPサーバがユーザー認証を必要としない場合は、次の2行は不要
                    // await client.AuthenticateAsync(userName, password);
                    await client.AuthenticateAsync("mngtk@flock.co.jp", "THflck-2015");
                    Console.WriteLine("認証完了");

                    await client.SendAsync(message);
                    Console.WriteLine("送信完了");

                    await client.DisconnectAsync(true);
                    Console.WriteLine("切断");
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
