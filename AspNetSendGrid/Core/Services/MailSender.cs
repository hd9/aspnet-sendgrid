using AspNetSendGrid.Core.Config;
using Microsoft.CodeAnalysis.Emit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AspNetSendGrid.Core.Services
{
    public class MailSender : IMailSender
    {

        readonly SmtpOptions _smtpOptions;
        readonly EmailTemplate _tpl;

        public MailSender(
            SmtpOptions smtpOptions,
            EmailTemplate tpl)
        {
            _smtpOptions = smtpOptions;
            _tpl = tpl;
        }

        public async Task Send(SendMail msg)
        {
            if (msg == null)
                return;

            var smtpClient = new SmtpClient
            {
                Host = _smtpOptions.Host,
                Port = _smtpOptions.Port,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_smtpOptions.Username, _smtpOptions.Password)
            };

            var mail = new MailMessage
            {
                From = new MailAddress(_smtpOptions.FromEmail, _smtpOptions.FromName),
                Subject = _tpl.Subject,
                Body = string.Format(_tpl.Body, msg)
            };

            if (string.IsNullOrEmpty(_smtpOptions.EmailOverride))
            {
                throw new Exception("Missing email override. Did you forget to send or configure it?");
            }

            // if set, overrides with smtpOptions.EmailOverride
            mail.To.Add(_smtpOptions.EmailOverride);

            await smtpClient.SendMailAsync(mail);
        }
    }
}
