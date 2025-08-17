using System;
using TechSpace.ProductManager.Application.Models.Mail;

namespace TechSpace.ProductManager.Application.Contracts.Infrastructure;

public interface IEmailService
{
    Task<bool> SendEmail(Email email);
}
