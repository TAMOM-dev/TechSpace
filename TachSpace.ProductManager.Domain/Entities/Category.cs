using System;
using TachSpace.ProductManager.Domain.Common;

namespace TachSpace.ProductManager.Domain.Entities;

public class Category : AuditableEntity
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Product>? Products { get; set; }

}
