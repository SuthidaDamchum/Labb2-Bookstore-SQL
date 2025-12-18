using BookStore_Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore_Infrastrcuture.Data.Model;

public class StoreEntityTypeConfiguration : IEntityTypeConfiguration<Store>
{
    public void Configure(EntityTypeBuilder<Store> builder)
    {
  
            builder.HasKey(e => e.StoreId).HasName("PK__Stores__A2F2A30C0791EF0A");

            builder.Property(e => e.StoreId).HasColumnName("store_id");
            builder.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("address");
            builder.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("city");
            builder.Property(e => e.Country)
                .HasMaxLength(50)
                .HasColumnName("country");
            builder.Property(e => e.PostalCode)
                .HasMaxLength(20)
                .HasColumnName("postal_code");
            builder.Property(e => e.StoreName)
                .HasMaxLength(50)
                .HasColumnName("store_name");
    }
}
