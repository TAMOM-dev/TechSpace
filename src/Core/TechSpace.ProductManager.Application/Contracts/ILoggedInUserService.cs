using System;

namespace TechSpace.ProductManager.Application.Contracts;

public interface ILoggedInUserService
{
    public string UserId { get; }
}
