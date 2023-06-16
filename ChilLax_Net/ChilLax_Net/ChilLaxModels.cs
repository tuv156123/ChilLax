using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ChilLax_Net
{
    public partial class ChilLaxModels : DbContext
    {
        public ChilLaxModels()
            : base("name=ChilLaxModels")
        {
        }

        public virtual DbSet<Announcement> Announcement { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<CustomerService> CustomerService { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<FocusDetail> FocusDetail { get; set; }
        public virtual DbSet<FocusSlide> FocusSlide { get; set; }
        public virtual DbSet<Member> Member { get; set; }
        public virtual DbSet<MemberCredential> MemberCredential { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<PointHistory> PointHistory { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductOrder> ProductOrder { get; set; }
        public virtual DbSet<Purchase> Purchase { get; set; }
        public virtual DbSet<PurchaseDetail> PurchaseDetail { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<TarotCard> TarotCard { get; set; }
        public virtual DbSet<TarotOrder> TarotOrder { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>()
                .Property(e => e.member_tel)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Cart)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.CustomerService)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasOptional(e => e.MemberCredential)
                .WithRequired(e => e.Member);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.ProductOrder)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.PointHistory)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.TarotOrder)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Cart)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderDetail)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.PurchaseDetail)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductOrder>()
                .HasMany(e => e.OrderDetail)
                .WithRequired(e => e.ProductOrder)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Purchase>()
                .HasMany(e => e.PurchaseDetail)
                .WithRequired(e => e.Purchase)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Product)
                .WithRequired(e => e.Supplier)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Purchase)
                .WithRequired(e => e.Supplier)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TarotCard>()
                .Property(e => e.tarotCard_type)
                .IsFixedLength();
        }
    }
}
