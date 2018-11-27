using MediatR;

namespace inverseyou.ddd.Events
{
    public class MailRequest: INotification
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public bool IsHTMLFormat { get; set; }
    }
}
