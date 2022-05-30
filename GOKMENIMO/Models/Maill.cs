using System.Net;
using System.Net.Mail;

namespace GOKMENIMO.Models
{
    public class Mail
    {
        public static void MailSender(string body)
        {
            var fromAddress = new MailAddress("alirizasahin5757@hotmail.com");
            var toAddress = new MailAddress("alirizasahin5757@hotmail.com");
            const string subject = "GÖKMENİMO | Sitenizden Gelen İletişim Formu";
            using (var smtp = new SmtpClient
            {
                Host = "smtp.outlook.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, "aysemelike1")
            })
            {
                using (var message = new MailMessage(fromAddress, toAddress) { Subject = subject, Body = body })
                {
                    smtp.Send(message);
                }
            }
        }
    }
}