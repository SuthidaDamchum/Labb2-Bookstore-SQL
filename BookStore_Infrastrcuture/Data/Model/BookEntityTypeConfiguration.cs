using BookStore_Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore_Infrastrcuture.Data.Model;

public class BookEntityTypeConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
     
            builder.HasKey(e => e.Isbn13).HasName("PK__Books__AA00666DB9607A12");

            builder.Property(e => e.Isbn13)
                .HasMaxLength(13)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("isbn13");
            builder.Property(e => e.GenreId).HasColumnName("genre_id");
            builder.Property(e => e.Language)
                .HasMaxLength(20)
                .HasColumnName("language");
            builder.Property(e => e.PageCount).HasColumnName("page_count");
            builder.Property(e => e.Price)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("price");
            builder.Property(e => e.PublicationDate).HasColumnName("publication_date");
            builder.Property(e => e.PublisherId).HasColumnName("publisher_id");
            builder.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");

            builder.HasOne(d => d.Genre).WithMany(p => p.Books)
                .HasForeignKey(d => d.GenreId)
                .HasConstraintName("FK_Books_Genres");

            builder.HasOne(d => d.Publisher).WithMany(p => p.Books)
                .HasForeignKey(d => d.PublisherId)
                .HasConstraintName("FK_Books_Publisher");
    }
}
