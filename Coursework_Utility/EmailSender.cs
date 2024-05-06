//using Microsoft.AspNetCore.Identity.UI.Services;
//using MimeKit;
//using MailKit.Net.Smtp;
//using Newtonsoft.Json.Linq;
//using System.Net.Mail;

//namespace Coursework_Utility
//{
//    //Майлджет не подтверждает аккаунт(
//    //Через MailKit не разобрался...
//    public class EmailSender
//    {
//        public async Task SendEmailAsync(string email, string subject, string message)
//        {
//            var emailMessage = new MimeMessage();

//            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "myrash228@gmail.com"));
//            emailMessage.To.Add(new MailboxAddress("", email));
//            emailMessage.Subject = subject;
//            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
//            {
//                Text = message
//            };

//            using (var client = new MailKit.Net.Smtp.SmtpClient())
//            {
//                await client.ConnectAsync("smtp.gmail.ru", 465, true);
//                await client.AuthenticateAsync("myrash228@gmail.com", "ccc565ccc");
//                await client.SendAsync(emailMessage);

//                await client.DisconnectAsync(true);
//            }
//        }
//    }
//}
