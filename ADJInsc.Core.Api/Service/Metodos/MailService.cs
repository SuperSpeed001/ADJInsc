﻿namespace ADJInsc.Core.Api.Service.Metodos
{
    using ADJInsc.Core.Api.Service.Interface;
    using ADJInsc.Core.Api.Service.Settings;
    using MailKit.Net.Smtp;
    using MailKit.Security;
    using Microsoft.Extensions.Options;
    using MimeKit;
    using System.IO;
    using System.Threading.Tasks;

    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;

        public MailService (IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            if (mailRequest.Attachments != null)
            {
                byte[] fileBytes;
                foreach (var file in mailRequest.Attachments)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
            }
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();

            //agregado    *******************
            smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;
            smtp.AuthenticationMechanisms.Remove("XOAUTH2");
            
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, false);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }

    }
}
