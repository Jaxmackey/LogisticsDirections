using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DerectionSender.Repositories
{
    class EmailRepository : IEmailRepository
    {

        public string SendEmail(string t, string f, string password, string host, int port, string subject, string body)
        {
            try
            {
                MailAddress to = new MailAddress(t);
                MailAddress from = new MailAddress(f);
                using (var mail = new MailMessage(from, to))
                using (var smtp = new SmtpClient()) {
                    mail.Subject = subject;
                    mail.Body = body;
                    smtp.Host = host;
                    smtp.Port = port;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(
                        f, password);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                    return "success";
                }
            }
            catch (SmtpException ex)
            {
                return ex.Message;
            }  
        }

    }
}
