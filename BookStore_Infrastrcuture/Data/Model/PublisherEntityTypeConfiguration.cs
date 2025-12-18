using BookStore_Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore_Infrastrcuture.Data.Model;

public class PublisherEntityTypeConfiguration : IEntityTypeConfiguration<Publisher>
{
    public void Configure(EntityTypeBuilder<Publisher> builder)
    {
            builder.HasKey(e => e.PublisherId).HasName("PK__Publishe__3263F29DE1B716F9");

            builder.ToTable("Publisher");

            builder.Property(e => e.PublisherId).HasColumnName("publisher_id");
            builder.Property(e => e.Address)
                .HasMaxLength(200)
                .HasColumnName("address");
            builder.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("city");
            builder.Property(e => e.Country)
                .HasMaxLength(50)
                .HasColumnName("country");
            builder.Property(e => e.PublisherName)
                .HasMaxLength(100)
                .HasColumnName("publisher_name");
    }
}
