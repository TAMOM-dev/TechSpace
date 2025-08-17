using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using TechSpace.ProductManager.Application.Contracts.Infrastructure;
using TechSpace.ProductManager.Application.Models.Mail;

namespace TechSpace.ProductManager.Infrastructure.Mail;

public class EmailService : IEmailService
{
    public EmailSettings _emailSettings { get; }
    public ILogger<EmailService> _logger { get; }

    public EmailService(IOptions<EmailSettings> mailSettings, ILogger<EmailService> logger)
    {
        _emailSettings = mailSettings.Value;
        _logger = logger;
    }
    public async Task<bool> SendEmail(Email email)
    {
        var client = new SendGridClient(_emailSettings.ApiKey);
        var sendGridMessage = MailHelper.CreateSingleEmail(
            new EmailAddress(_emailSettings.FromAddress, _emailSettings.FromName),
            new EmailAddress(email.To),
            email.Subject,
            email.Body,
            email.Body);

        var response = await client.SendEmailAsync(sendGridMessage);

        _logger.LogInformation("Email sent");

        return response.StatusCode == System.Net.HttpStatusCode.Accepted || response.StatusCode == System.Net.HttpStatusCode.OK;

    }
    
}
