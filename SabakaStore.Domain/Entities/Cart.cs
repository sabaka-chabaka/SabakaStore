namespace SabakaStore.Domain.Entities;

public class Cart
{
    public Guid UserId { get; set; }
    public ICollection<Guid> ProductsId { get; set; }
}