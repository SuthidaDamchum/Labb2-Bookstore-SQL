using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using BookStore_Domain;
using Microsoft.EntityFrameworkCore;

namespace BookStore_Infrastrcuture.Data.Model;

public partial class BookStoreContext : DbContext
{
    public BookStoreContext()
    {
    }

    public BookStoreContext(DbContextOptions<BookStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookAuthor> BookAuthors { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<OpenOrdersVsInventory> OpenOrdersVsInventories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<TitlesPerAuthor> TitlesPerAuthors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Initial Catalog=LABB1_Bokhandel.Testing;Integrated Security = True;TrustServerCertificate=True;Server SPN=locaohost");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        new AuthorEntityTypeConfiguration().Configure(modelBuilder.Entity<Author>());
        new BookEntityTypeConfiguration().Configure(modelBuilder.Entity<Book>());
        new BookAuthorEntityTypeConfiguration().Configure(modelBuilder.Entity<BookAuthor>());
        new GenreEntityTypeConfiguration().Configure(modelBuilder.Entity<Genre>());
        new InventoryEntityTypeConfiguration().Configure(modelBuilder.Entity<Inventory>());
        new OpenOrdersVsInventoryEntityTypeConfiguration().Configure(modelBuilder.Entity<OpenOrdersVsInventory>());
        new OrderEntityTypeConfiguration().Configure(modelBuilder.Entity<Order>());
        new OrderItemEntityTypeConfiguration().Configure(modelBuilder.Entity<OrderItem>());
        new PublisherEntityTypeConfiguration().Configure(modelBuilder.Entity<Publisher>());
        new TitlesPerAuthorEntityTypeConfiguration().Configure(modelBuilder.Entity<TitlesPerAuthor>());
        new StoreEntityTypeConfiguration().Configure(modelBuilder.Entity<Store>());
        new ReviewEntityTypeConfiguration().Configure(modelBuilder.Entity<Review>());


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
