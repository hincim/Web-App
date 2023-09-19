using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ShopApp.WebUI.EmailServices
{
    public class SmtpEmailSender : IEmailSender
    {
        private string _password;
        private string _host;
        private int _port;
        private string _username;
        private bool _enableSSL;

        public SmtpEmailSender(string host, int port, bool enableSSL, string userName, string password)
        {
            _host = host;
            _port = port;
            _username = userName;
            _password = password;
            _enableSSL = enableSSL;

        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SmtpClient(_host, _port)
            {
                Credentials = new NetworkCredential(_username, _password),
                EnableSsl = _enableSSL
            };
            return client.SendMailAsync(
                new MailMessage(_username, email, subject, htmlMessage)
                {
                    IsBodyHtml = true
                });
        }
    }
}
