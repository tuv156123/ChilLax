using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace chilLax_Purchase.Models;

public partial class ChilLaxContext : DbContext
{
    public ChilLaxContext()
    {
    }

    public ChilLaxContext(DbContextOptions<ChilLaxContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Announcement> Announcements { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CustomerService> CustomerServices { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<FocusDetail> FocusDetails { get; set; }

    public virtual DbSet<FocusSlide> FocusSlides { get; set; }

    public virtual DbSet<HomeVideo> HomeVideos { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<MemberCredential> MemberCredentials { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<PointHistory> PointHistories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductOrder> ProductOrders { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    public virtual DbSet<PurchaseDetail> PurchaseDetails { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<TarotCard> TarotCards { get; set; }

    public virtual DbSet<TarotOrder> TarotOrders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ChilLax;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Announcement>(entity =>
        {
            entity.ToTable("Announcement");

            entity.Property(e => e.AnnouncementId).HasColumnName("announcement_id");
            entity.Property(e => e.Announcement1)
                .HasMaxLength(1000)
                .HasColumnName("announcement");
            entity.Property(e => e.BonusForFocus).HasColumnName("bonus_for_focus");
            entity.Property(e => e.BonusForShopping).HasColumnName("bonus_for_shopping");
            entity.Property(e => e.EndDate)
                .HasColumnType("date")
                .HasColumnName("end_date");
            entity.Property(e => e.StartDate)
                .HasColumnType("date")
                .HasColumnName("start_date");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => new { e.MemberId, e.ProductId });

            entity.ToTable("Cart");

            entity.Property(e => e.MemberId).HasColumnName("member_id");
            entity.Property(e => e.ProductId)
                .ValueGeneratedOnAdd()
                .HasColumnName("product_id");
            entity.Property(e => e.CartProductQuantity).HasColumnName("cart_product_quantity");
        });

        modelBuilder.Entity<CustomerService>(entity =>
        {
            entity.HasKey(e => e.CustomerServiceId).HasName("PK_MemberService");

            entity.ToTable("CustomerService");

            entity.Property(e => e.CustomerServiceId)
                .ValueGeneratedNever()
                .HasColumnName("customer_service_id");
            entity.Property(e => e.MemberId)
                .ValueGeneratedOnAdd()
                .HasColumnName("member_ID");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.MessageDatetime)
                .HasColumnType("datetime")
                .HasColumnName("message_datetime");
            entity.Property(e => e.Reply).HasColumnName("reply");
            entity.Property(e => e.ReplyDatetime)
                .HasColumnType("datetime")
                .HasColumnName("reply_datetime");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId);

            entity.ToTable("Employee");

            entity.Property(e => e.EmpId).HasColumnName("emp_id");
            entity.Property(e => e.EmpAccount)
                .HasMaxLength(50)
                .HasColumnName("emp_account");
            entity.Property(e => e.EmpName)
                .HasMaxLength(50)
                .HasColumnName("emp_name");
            entity.Property(e => e.EmpPassword)
                .HasMaxLength(50)
                .HasColumnName("emp_password");
            entity.Property(e => e.EmpPermission).HasColumnName("emp_permission");
        });

        modelBuilder.Entity<FocusDetail>(entity =>
        {
            entity.ToTable("FocusDetail");

            entity.Property(e => e.FocusDetailId).HasColumnName("focus_detail_id");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.EndDatetime)
                .HasColumnType("datetime")
                .HasColumnName("end_datetime");
            entity.Property(e => e.StartDatetime)
                .HasColumnType("datetime")
                .HasColumnName("start_datetime");
        });

        modelBuilder.Entity<FocusSlide>(entity =>
        {
            entity.HasKey(e => e.FocusId).HasName("PK_Focus");

            entity.ToTable("FocusSlide");

            entity.Property(e => e.FocusId).HasColumnName("focus_id");
            entity.Property(e => e.AudioPath).HasColumnName("audio_path");
            entity.Property(e => e.Category)
                .HasMaxLength(100)
                .HasColumnName("category");
            entity.Property(e => e.ImagePath).HasColumnName("image_path");
        });

        modelBuilder.Entity<HomeVideo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("HomeVideo");

            entity.Property(e => e.VideoName)
                .HasMaxLength(200)
                .HasColumnName("video_name");
            entity.Property(e => e.VideoPath).HasColumnName("video_path");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.MemberId).HasName("PK_Members");

            entity.ToTable("Member");

            entity.Property(e => e.MemberId).HasColumnName("member_id");
            entity.Property(e => e.MemberAddress)
                .HasMaxLength(100)
                .HasColumnName("member_address");
            entity.Property(e => e.MemberBirthday)
                .HasColumnType("date")
                .HasColumnName("member_birthday");
            entity.Property(e => e.MemberEmail)
                .HasMaxLength(50)
                .HasColumnName("member_email");
            entity.Property(e => e.MemberJoinTime)
                .HasColumnType("datetime")
                .HasColumnName("member_joinTime");
            entity.Property(e => e.MemberName)
                .HasMaxLength(50)
                .HasColumnName("member_name");
            entity.Property(e => e.MemberPoint).HasColumnName("member_point");
            entity.Property(e => e.MemberSex).HasColumnName("member_sex");
            entity.Property(e => e.MemberTel)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("member_tel");
        });

        modelBuilder.Entity<MemberCredential>(entity =>
        {
            entity.HasKey(e => e.MemberId);

            entity.ToTable("MemberCredential");

            entity.Property(e => e.MemberId).HasColumnName("member_id");
            entity.Property(e => e.MemberAccount)
                .HasMaxLength(50)
                .HasColumnName("member_account");
            entity.Property(e => e.MemberPassword)
                .HasMaxLength(50)
                .HasColumnName("member_password");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ProductId });

            entity.ToTable("OrderDetail");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.CartProductQuantity).HasColumnName("cart_product_quantity");
        });

        modelBuilder.Entity<PointHistory>(entity =>
        {
            entity.HasKey(e => e.PointDetailId);

            entity.ToTable("PointHistory");

            entity.Property(e => e.PointDetailId)
                .ValueGeneratedNever()
                .HasColumnName("point_detail_id");
            entity.Property(e => e.MemberId).HasColumnName("member_id");
            entity.Property(e => e.ModifiedAmount).HasColumnName("modified_amount");
            entity.Property(e => e.ModifiedSource)
                .HasMaxLength(50)
                .HasColumnName("modified_source");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ProductCategory)
                .HasMaxLength(50)
                .HasColumnName("product_category");
            entity.Property(e => e.ProductDesc).HasColumnName("product_desc");
            entity.Property(e => e.ProductImg)
                .HasMaxLength(50)
                .HasColumnName("product_img");
            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .HasColumnName("product_name");
            entity.Property(e => e.ProductPrice).HasColumnName("product_price");
            entity.Property(e => e.ProductQuantity).HasColumnName("product_quantity");
            entity.Property(e => e.ProductState).HasColumnName("product_state");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
        });

        modelBuilder.Entity<ProductOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK_Order");

            entity.ToTable("ProductOrder");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.MemberId).HasColumnName("member_id");
            entity.Property(e => e.OrderAddress).HasColumnName("order_address");
            entity.Property(e => e.OrderDate)
                .HasColumnType("datetime")
                .HasColumnName("order_date");
            entity.Property(e => e.OrderDelivery).HasColumnName("order_delivery");
            entity.Property(e => e.OrderNote).HasColumnName("order_note");
            entity.Property(e => e.OrderPayment).HasColumnName("order_payment");
            entity.Property(e => e.OrderState)
                .HasMaxLength(500)
                .HasColumnName("order_state");
            entity.Property(e => e.OrderTotalPrice).HasColumnName("order_totalPrice");
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.PurchaseId).HasName("PK_OrderProduct");

            entity.ToTable("Purchase");

            entity.Property(e => e.PurchaseId).HasColumnName("purchase_id");
            entity.Property(e => e.PurchaseDate)
                .HasColumnType("datetime")
                .HasColumnName("purchase_date");
            entity.Property(e => e.PurchaseNote).HasColumnName("purchase_note");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
        });

        modelBuilder.Entity<PurchaseDetail>(entity =>
        {
            entity.HasKey(e => new { e.PurchaseId, e.ProductId }).HasName("PK_OrderProductDetail");

            entity.ToTable("PurchaseDetail");

            entity.Property(e => e.PurchaseId).HasColumnName("purchase_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.PurchasePrice).HasColumnName("purchase_price");
            entity.Property(e => e.PurchaseQuantity).HasColumnName("purchase_quantity");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.ToTable("Supplier");

            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
            entity.Property(e => e.SupplierAddress).HasColumnName("supplier_address");
            entity.Property(e => e.SupplierName)
                .HasMaxLength(500)
                .HasColumnName("supplier_name");
            entity.Property(e => e.SupplierTel)
                .HasMaxLength(50)
                .HasColumnName("supplier_tel");
        });

        modelBuilder.Entity<TarotCard>(entity =>
        {
            entity.ToTable("TarotCard");

            entity.Property(e => e.TarotCardId)
                .ValueGeneratedNever()
                .HasColumnName("tarotCard_id");
            entity.Property(e => e.TarotCardName)
                .HasMaxLength(50)
                .HasColumnName("tarotCard_name");
            entity.Property(e => e.TarotCardType)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("tarotCard_type");
        });

        modelBuilder.Entity<TarotOrder>(entity =>
        {
            entity.ToTable("TarotOrder");

            entity.Property(e => e.TarotOrderId).HasColumnName("tarot_order_id");
            entity.Property(e => e.CardResult)
                .HasMaxLength(50)
                .HasColumnName("card_result");
            entity.Property(e => e.DivinationChat).HasColumnName("divination_chat");
            entity.Property(e => e.MemberId).HasColumnName("member_id");
            entity.Property(e => e.TarotTime)
                .HasColumnType("datetime")
                .HasColumnName("tarot_time");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
