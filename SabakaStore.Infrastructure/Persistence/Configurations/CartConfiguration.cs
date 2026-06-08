using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SabakaStore.Domain.Entities;

namespace SabakaStore.Infrastructure.Persistence.Configurations;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.ToTable("carts");

        builder.HasKey(c => c.UserId);

        builder.Property(c => c.UserId)
            .HasColumnName("user_id")
            .ValueGeneratedNever();

        builder.HasOne<User>()
            .WithOne()
            .HasForeignKey<Cart>(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.ProductsId)
            .WithMany()
            .UsingEntity(j => j.ToTable("cart_products"));
    }
}