namespace SabakaStore.Domain.Entities;

public class Cart
{
    public Guid UserId { get; set; }
    public ICollection<Product> ProductsId { get; set; }
}