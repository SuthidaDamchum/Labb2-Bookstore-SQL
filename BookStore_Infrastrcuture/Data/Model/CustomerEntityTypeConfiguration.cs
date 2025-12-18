using BookStore_Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore_Infrastrcuture.Data.Model;

public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
     
            builder.HasKey(e => e.CustomerId).HasName("PK__Customer__CD65CB85B58CA293");

            builder.HasIndex(e => e.Email, "UQ_Customers_Email").IsUnique();

            builder.HasIndex(e => e.Phone, "UQ_Customers_Phone").IsUnique();

            builder.Property(e => e.CustomerId).HasColumnName("customer_id");
            builder.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("address");
            builder.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("city");
            builder.Property(e => e.Country)
                .HasMaxLength(50)
                .HasColumnName("country");
            builder.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            builder.Property(e => e.Firstname)
                .HasMaxLength(50)
                .HasColumnName("firstname");
            builder.Property(e => e.Lastname)
                .HasMaxLength(50)
                .HasColumnName("lastname");
            builder.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            builder.Property(e => e.PostalCode)
                .HasMaxLength(20)
                .HasColumnName("postal_code");
    }
}
