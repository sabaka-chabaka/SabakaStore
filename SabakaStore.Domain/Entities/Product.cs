namespace SabakaStore.Domain.Entities;

public class Product
{
    public Guid Id { get; set; }
    public Guid StoreId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}