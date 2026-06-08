namespace SabakaStore.Domain.Entities;

public class Store
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Guid> ProductsId { get; set; }
}