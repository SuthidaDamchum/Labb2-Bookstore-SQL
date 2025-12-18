using BookStore_Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore_Infrastrcuture.Data.Model;

public class TitlesPerAuthorEntityTypeConfiguration : IEntityTypeConfiguration<TitlesPerAuthor>
{
    public void Configure(EntityTypeBuilder<TitlesPerAuthor> builder)
    {
      
            builder
                .HasNoKey()
                .ToView("TitlesPerAuthor");

            builder.Property(e => e.Age)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("age");
            builder.Property(e => e.InventoryValue)
                .HasMaxLength(44)
                .IsUnicode(false)
                .HasColumnName("inventory_value");
            builder.Property(e => e.Name)
                .HasMaxLength(101)
                .HasColumnName("name");
            builder.Property(e => e.Titles)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("titles");
 
    }
}
