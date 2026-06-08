using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SabakaStore.Domain.Entities;

namespace SabakaStore.Infrastructure.Persistence.Configurations;

public class StoreConfiguration : IEntityTypeConfiguration<Store>
{
    public void Configure(EntityTypeBuilder<Store> builder)
    {
        builder.ToTable("stores");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(s => s.Name)
            .HasColumnName("name")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(s => s.Description)
            .HasColumnName("description")
            .HasMaxLength(2000);

        builder.HasMany(s => s.ProductsId)
            .WithOne()
            .HasForeignKey(p => p.StoreId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}