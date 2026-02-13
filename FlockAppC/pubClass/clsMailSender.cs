using System;
using System.Net;
using System.Net.Mail;

namespace FlockAppC.pubClass
{
    public class clsMailSender
    {
        // SMTPサーバー設定 (app.config)
        private readonly string _smtpHost = System.Configuration.ConfigurationManager.AppSettings["SmtpHost"];
        private readonly int _smtpPort = int.Parse(System.Configuration.ConfigurationManager.AppSettings["SmtpPort"] ?? "587");
        private readonly string _smtpUser = System.Configuration.ConfigurationManager.AppSettings["SmtpUser"];
        private readonly string _smtpPassword = System.Configuration.ConfigurationManager.AppSettings["SmtpPassword"];

        /// <summary>
        /// メール送信
        /// </summary>
        /// <param name="mailData"></param>
        public void Send(clsSendMailData mailData)
        {
            using var smtp = new SmtpClient(_smtpHost, _smtpPort)
            {
                UseDefaultCredentials = false,   
                Credentials = new NetworkCredential(_smtpUser, _smtpPassword),
                EnableSsl = true
            };

            foreach (var recipient in mailData.mail_to)
            {
                using var message = new MailMessage();

                // message.From = new MailAddress(mailData.mail_from);
                message.From = new MailAddress(_smtpUser);
                message.To.Add(new MailAddress(recipient.mailaddress, recipient.user_name));
                message.Subject = mailData.mail_subject;
                message.Body = mailData.mail_body;

                //if (!string.IsNullOrWhiteSpace(mailData.MailAttachment))
                //{
                //    message.Attachments.Add(
                //        new Attachment(mailData.MailAttachment));
                //}
                try
                {
                    smtp.Send(message);
                }
                catch (Exception ex)
                {
                    ClsLogger.Log(ex.ToString());
                    throw;
                }
            }
        }
    }
}
