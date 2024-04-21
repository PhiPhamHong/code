using Core.Business.Entities;
using Core.Business.Entities.CRM;
using Core.Utility;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.Sites.Libraries.Business
{
    public partial class WebCenter
    {
        public partial class Worker
        {
            public partial class One 
            {
                public partial class Send
                {
                    public class Email : SSERPOneSecond.ControlByCompany
                    {
                        protected override int Time => 3600;
                        public static void BuildLogs(int companyId, CompanyConfig config)
                        {
                            //B1: Tìm các email cần gửi trong hôm nay
                            var emails = Core.Business.Entities.CRM.Email.GetEmails(companyId); //tìm các email cần gửi trong hôm nay
                            if (emails.Count == 0)
                                return;
                            //B2 : Tạo log để lát duyệt theo log để gửi
                            foreach (var email in emails)
                            {
                                var log = SendLog.GetByEmailId(companyId, email.EmailId); //xem đã có log chưa
                                if (log != null) continue; // có rồi thì thôi còn chưa thì tạo log và log.detail
                                var customers = Customer.GetCustomers(companyId, email.GroupId, email.SourceId, email.TypeId);
                                if (customers.Count == 0) continue;

                                log = new SendLog
                                {
                                    EmailId = email.EmailId,
                                    CompanyId = companyId,
                                    Type = SendType.Email,
                                    Status = LogStatus.New,
                                    Code = "LOG-" + companyId + "-" + DateTime.Now.ToString("dd/MM/yyyy-hhmmss") + "-EMAIL",
                                    SentDate = DateTime.Now,
                                    EmailMethod = config.EmailMethod,
                                    FromEmail = (config.EmailMethod == EmailMethodSend.SendGrid) ? config.SendGrid_API_Email : (config.EmailMethod == EmailMethodSend.GGMail) ? config.EmailFromId : "",
                                    TotalNeedSend = customers.Count
                                };
                                log.Insert();

                                foreach (var customer in customers)
                                {
                                    var detail = new SendLog.Detail
                                    {
                                        LogId = log.LogId,
                                        CompanyId = companyId,
                                        CustomerId = customer.TeleSaleId,
                                        SentTime = log.SentDate
                                    };
                                    detail.Insert();
                                }
                            }
                        }
                        public static void DoSend(int companyId, CompanyConfig config)
                        {
                            var logs = SendLog.GetToSends(companyId);
                            foreach (var log in logs)
                            {
                                int TotalSend = 0;
                                if(log.SentDate < DateTime.Now) // nếu mà ngày cần gửi nhỏ hơn hiện tại
                                {
                                    //B1: Lọc ra các khách sẽ được gửi mail qua log.Detail
                                    var customers = SendLog.Detail.GetByLogId(companyId, log.LogId); //lấy ở details
                                    //B2: Từ log lấy ra Email cần gửi
                                    var mail = new Core.Business.Entities.CRM.Email { EmailId = log.EmailId };
                                    mail.GetByKey();
                                    foreach (var cus in customers)
                                    {
                                        int num = 1;
                                        var sendOk = false;
                                        var msgError = "";
                                        if(string.IsNullOrEmpty(cus.CusMail))
                                            msgError = "Không có địa chỉ Email";
                                        else
                                        {
                                            try
                                            {
                                                //set các thuộc tính của mail
                                                IEmailProvider emailProvider = null;
                                                switch (config.EmailMethod)
                                                {
                                                    case EmailMethodSend.GGMail: emailProvider = new GmailProvider { ShMailer = PortalContext.NewMailer(config) }; break;
                                                    case EmailMethodSend.SendGrid:
                                                        emailProvider = PortalContext.SendGridProvider(config, sgp =>
                                                        {
                                                            sgp.SendGridMessage.SetFrom(config.SendGrid_API_Email, config.SendGrid_API_Name);
                                                            sgp.SendGridMessage.SetReplyTo(new EmailAddress(config.SendGrid_API_ReplyEmail, config.SendGrid_API_ReplyEmailName));
                                                        }); break;
                                                }
                                                emailProvider.ToEmail(cus.CusMail);
                                                emailProvider.Subject = mail.Title.Replace("{CustomerName}", cus.CusName);
                                                emailProvider.Body = mail.Content.Replace("{CustomerName}", cus.CusName);

                                                sendOk = emailProvider.Send(config.DomainName, ex => msgError = ex.Message); //tiến hành gửi

                                                if (!sendOk)
                                                {
                                                    num++;
                                                    while (num <= config.WhenNeedStopSending)
                                                    {
                                                        if (sendOk = emailProvider.Send(config.DomainName, ex => msgError = ex.Message))
                                                            break;
                                                        num++;
                                                        TotalSend++;
                                                    }
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                msgError = ex.Message;
                                            }
                                        }
                                        TotalSend++;
                                        var status = sendOk == true ? SendStatus.Success : SendStatus.Fail;
                                        SendLog.Detail.UpdateLogDetail(cus.DetailId, status, num, msgError);// cập nhật lại detail sau khi hoàn tất gửi
                                    }
                                    SendLog.UpdateLog(companyId, log.LogId, TotalSend);
                                }
                            }
                        }
                        protected override void Work()
                        {
                            BuildLogs(Worker.CompanyId, Worker.Config);
                            DoSend(Worker.CompanyId, Worker.Config);
                        }
                    }
                }
            }
        }
    }
}
