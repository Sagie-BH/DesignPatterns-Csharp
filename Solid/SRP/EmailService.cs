using System.Net;
using System.Net.Mail;

namespace SRP.SRP
{
    public static class EmailService
    {
        public static void SendEmail(string recipientName, string email, string emainSubject, string emailBody)
        {
            var fromAddress = new MailAddress("2603sagie@gmail.com", "Sagie BH");
            var toAddress = new MailAddress(email, recipientName);
            const string fromPassword = "nthhdpmnwmdqplct";
            string subject = emainSubject;
            string body = emailBody;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}
