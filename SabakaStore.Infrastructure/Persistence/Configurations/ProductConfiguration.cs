using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SabakaStore.Domain.Entities;

namespace SabakaStore.Infrastructure.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("products");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(p => p.StoreId)
            .HasColumnName("store_id")
            .IsRequired();

        builder.Property(p => p.Name)
            .HasColumnName("name")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(p => p.Description)
            .HasColumnName("description")
            .HasMaxLength(2000);

        builder.Property(p => p.Price)
            .HasColumnName("price")
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.HasOne<Store>()
            .WithMany()
            .HasForeignKey(p => p.StoreId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}