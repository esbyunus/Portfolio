using System.Net;
using System.Net.Mail;

namespace Portfolio.Services
{
    public class EmailService
    {
        public static void SendEmail(string senderEmail, string subject, string messageBody)
        {
            var fromAddress = new MailAddress("your-email@gmail.com"); // Gönderen email
            var toAddress = new MailAddress("your-email@gmail.com");   // Alıcı email
            const string fromPassword = "your-app-password";           // Email şifresi

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
                Body = $"Gönderen: {senderEmail}\n\n{messageBody}"
            })
            {
                smtp.Send(message);
            }
        }
    }
} 