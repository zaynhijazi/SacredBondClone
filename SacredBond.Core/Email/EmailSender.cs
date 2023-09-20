using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SacredBond.Common.Configs;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace SacredBond.Core.Email
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<EmailSender> _logger;

        public readonly char ADDRESS_DELIMITER = ';';

        private string? _overrideAddress;

        public EmailSender(IConfiguration configuration, ILogger<EmailSender> logger)
        {

            _configuration = configuration;
            _logger = logger;
            _overrideAddress = configuration[EmailConfigs.Email_OverrideEmailAddress];
        }

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            await SendEmailAsync(
                _configuration[EmailConfigs.SendGrid_Key],
                _configuration[EmailConfigs.SendGrid_FromEmail],
                _configuration[EmailConfigs.SendGrid_FromName],
                subject,
                message,
                toEmail);
        }

        private async Task<bool> SendEmailAsync(
            string apiKey,
            string fromEmail,
            string fromName,
            string subject,
            string message,
            string toEmail)
        {
            var client = new SendGridClient(apiKey);
            string logMessage = toEmail;
            if (!string.IsNullOrEmpty(_overrideAddress))
            {
                logMessage = $"The following email was going to {fromEmail} but it has been overriden to {_overrideAddress}";
                message = logMessage + "</br>" + message;
                toEmail = _overrideAddress;
            }

            var msg = new SendGridMessage()
            {
                From = new EmailAddress(fromEmail, fromName),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message,
            };
            msg.AddTo(toEmail);

            var response = await client.SendEmailAsync(msg);

            _logger.LogInformation(response.IsSuccessStatusCode
                                   ? $"Email {logMessage} queued successfully!"
                                   : $"Failure Email {logMessage}");

            return response.IsSuccessStatusCode;
        }
    }
}
