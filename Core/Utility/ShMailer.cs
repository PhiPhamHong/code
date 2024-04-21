using System.Net.Mail;
using System.Net;
using System.Text;
using System;
using Core.Extensions;
using Core.Utility.Spiders;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace Core.Utility
{
    public class ShMailer
    {
        #region Properties
        public SmtpClient Smtp { set; get; } = new SmtpClient();

        private MailMessage mail = new MailMessage();
        public MailMessage Mail
        {
            set { mail = value; }
            get { return mail; }
        }

        private string emailFrom = "phiph@ksc.com.vn";
        public string EmailFrom
        {
            set { emailFrom = value; }
            get { return emailFrom; }
        }

        private string passwordEmailFrom = "iadmin123!@#";
        public string PasswordEmailFrom
        {
            set { passwordEmailFrom = value; }
            get { return passwordEmailFrom; }
        }

        private string sendBy = "CÔNG TY CỔ PHẦN CÔNG NGHỆ VÀ GIÁO DỤC KSC";
        public string SendBy
        {
            set { sendBy = value; }
            get { return sendBy; }
        }
        #endregion

        public bool Send(string domainResource, Action<Exception> aex = null)
        {
            try
            {
                if(domainResource.IsNotNull())
                {
                    var spider = new Spider { Html = Mail.Body };
                    spider.SelectList("img").ForEach(img =>
                    {
                        var src = img.Attributes["src"].Value;
                        if (src.IndexOf("http://") < 0)
                            img.Attributes["src"].Value = domainResource + src; //AppSettings.RootPath + src;
                    });

                    spider.SelectList("a").ForEach(a =>
                    {
                        var src = a.Attributes["href"].Value;
                        if (src.IndexOf("http://") < 0 && src.IndexOf("https://") < 0)
                            a.Attributes["href"].Value = domainResource + src; //AppSettings.RootPath + src;
                    });

                    Mail.Body = spider.Html;
                }

                Smtp.EnableSsl = true;
                //this.Smtp.Host =  "smtp.gmail.com";
                // https://myaccount.google.com/u/2/lesssecureapps?pageId=none&pli=1
                this.Smtp.UseDefaultCredentials = false;
                Smtp.Credentials = new NetworkCredential(emailFrom, passwordEmailFrom);

                mail.From = new MailAddress(emailFrom, sendBy);
                mail.BodyEncoding = mail.SubjectEncoding = Encoding.UTF8;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;
                Smtp.Send(mail);
                return true;
            }
            catch(Exception ex)
            {
                if (aex != null) aex(ex);
                return false;
            }
        }
    }

    public interface IMailer
    {
        string EmailHost { get; }
        string EmailSendBy { get; }
        int EmailPort { get; }
        string EmailCC { get; }
        string EmailFromId { get; }
        string EmailFromPassword { get; }
    }

    public interface IEmailProvider
    {
        string Subject { set; }
        string Body { set; }
        void ToEmail(string emails);
        void ToEmail(params EmailTo[] emails);
        bool Send(string domain, Action<Exception> aex);
    }

    public class EmailTo
    {
        public string Email { set; get; }
        public string Name { set; get; }
    }

    public class GmailProvider : IEmailProvider
    {
        public ShMailer ShMailer { set; get; }

        public string Subject { set { ShMailer.Mail.Subject = value; } }
        public string Body { set { ShMailer.Mail.Body = value; } }
        public void ToEmail(string emails)
        {
            ShMailer.Mail.To.Add(emails);
        }
        public bool Send(string domain, Action<Exception> aex)
        {
            return ShMailer.Send(domain, aex);
        }

        public void ToEmail(params EmailTo[] emails)
        {
            ShMailer.Mail.To.Add(emails.JoinString(e => e.Email));
        }
    }

    public class SendGridProvider : IEmailProvider
    {
        public SendGridClient SendGridClient { set; get; }
        public SendGridMessage SendGridMessage { set; get; } = new SendGridMessage();

        public string Subject { set { SendGridMessage.SetSubject(value); } }
        public string Body { set; get; } 

        public bool Send(string domain, Action<Exception> aex)
        {
            try
            {
                if (domain.IsNotNull())
                {
                    var spider = new Spider { Html = Body };
                    spider.SelectList("img").ForEach(img =>
                    {
                        var src = img.Attributes["src"].Value;
                        if (src.IndexOf("http://") < 0)
                            img.Attributes["src"].Value = domain + src; //AppSettings.RootPath + src;
                    });

                    spider.SelectList("a").ForEach(a =>
                    {
                        var src = a.Attributes["href"].Value;
                        if (src.IndexOf("http://") < 0 && src.IndexOf("https://") < 0)
                            a.Attributes["href"].Value = domain + src; //AppSettings.RootPath + src;
                    });

                    Body = spider.Html;
                }
                SendGridMessage.AddContent(MimeType.Html, Body);
                var response = SendHelper().Result;
                return response.StatusCode == HttpStatusCode.Accepted;
            }
            catch(Exception ex)
            {
                aex?.Invoke(ex);
                return false;
            }
        }

        protected async Task<Response> SendHelper()
        {
            return (await SendGridClient.SendEmailAsync(SendGridMessage));
        }

        public void ToEmail(string emails)
        {
            SendGridMessage.AddTo(emails);
        }

        public void ToEmail(params EmailTo[] emails)
        {
            emails.ForEach(e => SendGridMessage.AddTo(e.Email, e.Name));
        }
    }
}
