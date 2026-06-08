using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SabakaStore.Domain.Entities;

namespace SabakaStore.Infrastructure.Persistence.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("orders");

        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(o => o.UserId)
            .HasColumnName("user_id")
            .IsRequired();

        builder.Property(o => o.Quantity)
            .HasColumnName("quantity")
            .IsRequired();

        builder.HasMany(o => o.Products)
            .WithMany()
            .UsingEntity(j => j.ToTable("order_products"));

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}