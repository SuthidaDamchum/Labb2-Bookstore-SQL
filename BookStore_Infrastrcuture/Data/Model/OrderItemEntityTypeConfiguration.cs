using BookStore_Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore_Infrastrcuture.Data.Model;

public class OrderItemEntityTypeConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
      
            builder.HasKey(e => new { e.OrderId, e.Isbn13 }).HasName("PK__Order_It__8CF9644F46863B4B");

            builder.ToTable("Order_Items");

            builder.Property(e => e.OrderId).HasColumnName("order_id");
            builder.Property(e => e.Isbn13)
                .HasMaxLength(13)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("isbn13");
            builder.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            builder.Property(e => e.Quantity).HasColumnName("quantity");

            builder.HasOne(d => d.Isbn13Navigation).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.Isbn13)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order_Ite__isbn1__3B40CD36");

            builder.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Order_Ite__order__3A4CA8FD");
    }
}
