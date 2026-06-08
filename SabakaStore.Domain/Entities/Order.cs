namespace SabakaStore.Domain.Entities;

public class Order
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public ICollection<Product> Products { get; set; }
    public int Quantity { get; set; }
}