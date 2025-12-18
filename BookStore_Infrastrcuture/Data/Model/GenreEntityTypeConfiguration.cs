using BookStore_Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore_Infrastrcuture.Data.Model;

public class GenreEntityTypeConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {

            builder.HasKey(e => e.GenreId).HasName("PK__Genres__18428D427A7E6811");

            builder.Property(e => e.GenreId).HasColumnName("genre_id");
            builder.Property(e => e.GenreName)
                .HasMaxLength(30)
                .HasColumnName("genre_name");
    }
}
