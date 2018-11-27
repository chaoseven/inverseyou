using MediatR;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace inverseyou.ddd.Events
{
    public class MailHandler : INotificationHandler<MailRequest>
    {
        async Task INotificationHandler<MailRequest>.Handle(MailRequest notification, CancellationToken cancellationToken)
        {
            using (SmtpClient smtpClient = new SmtpClient("smtp.qq.com", 587))
            {
                smtpClient.Credentials = new NetworkCredential("1039383677@qq.com", "pvlsandqmljabfig");
                smtpClient.EnableSsl = true;
                MailMessage message = new MailMessage(from: "1039383677@qq.com", to: "1039383677@qq.com", subject: notification.Subject, body: notification.Body)
                {
                    IsBodyHtml = notification.IsHTMLFormat
                };
                await smtpClient.SendMailAsync(message);
            }
        }
    }
}



























