using BookStore_Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore_Infrastrcuture.Data.Model;

public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
    
            builder.HasKey(e => e.OrderId).HasName("PK__Orders__4659622910AD0AB2");

            builder.Property(e => e.OrderId).HasColumnName("order_id");
            builder.Property(e => e.CustomerId).HasColumnName("customer_id");
            builder.Property(e => e.OrderDatetime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("order_datetime");
            builder.Property(e => e.OrderStatus)
                .HasMaxLength(20)
                .HasDefaultValue("Pending")
                .HasColumnName("order_status");
            builder.Property(e => e.StoreId).HasColumnName("store_id");

            builder.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Customers");

            builder.HasOne(d => d.Store).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__store_id__4BAC3F29");
    }
}
