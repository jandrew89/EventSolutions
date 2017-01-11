using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Twilio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSolutions.Services
{
    public class MessageService : IMessageService
    {
        public async System.Threading.Tasks.Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("NoReply", "NoReply@cwfapplications.com"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("Plain") { Text = message };

            using (var client = new SmtpClient())
            {
                //await client.ConnectAsync("smtp.live.com", 587, SecureSocketOptions.SslOnConnect).ConfigureAwait(false);
                //client.Authenticate("jc_84moss@hotmail.com", "jc_89moss");
                client.LocalDomain = "cwfworkflow.com.basil.arvixe.com";
                await client.ConnectAsync("cwfworkflow.com.basil.arvixe.com", 26, SecureSocketOptions.None).ConfigureAwait(false);
                client.Authenticate("NoReply@cwfworkflow.com", "_noreply_");
                await client.SendAsync(emailMessage).ConfigureAwait(false);
                await client.DisconnectAsync(true).ConfigureAwait(false);
            }
        }

        public System.Threading.Tasks.Task SendSmsAsync(string number, string message)
        {
            const string accountSid = "AC72e6ba27cfb7d7d0f2129bc194d8a75a";
            const string authToken = "e21df88324a629396bfebbbc38904f41";

            var twilioRestClient = new TwilioRestClient(accountSid, authToken);
            twilioRestClient.SendMessage("12607587161", number, message);

            return System.Threading.Tasks.Task.FromResult(0);
        }
    }
}
