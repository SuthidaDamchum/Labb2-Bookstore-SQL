using BookStore_Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore_Infrastrcuture.Data.Model;

public class OpenOrdersVsInventoryEntityTypeConfiguration : IEntityTypeConfiguration<OpenOrdersVsInventory>
{
    public void Configure(EntityTypeBuilder<OpenOrdersVsInventory> builder)
    {
      
            builder
                .HasNoKey()
                .ToView("OpenOrdersVsInventory");

            builder.Property(e => e.InventoryQuantity).HasColumnName("inventory_quantity");
            builder.Property(e => e.Isbn13)
                .HasMaxLength(13)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("isbn13");
            builder.Property(e => e.OrderedNotDelivered).HasColumnName("ordered_not_delivered");
            builder.Property(e => e.RemainingAfterOrders).HasColumnName("remaining_after_orders");
            builder.Property(e => e.StoreName)
                .HasMaxLength(50)
                .HasColumnName("store_name");
            builder.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");
    }
}
