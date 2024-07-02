using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Api.Models;

public partial class PotionShoppeContext : DbContext
{
    public PotionShoppeContext() { }

    public PotionShoppeContext(DbContextOptions<PotionShoppeContext> options) : base(options) { }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerAccount> CustomerAccounts { get; set; }

    public virtual DbSet<CustomerStatus> CustomerStatuses { get; set; }

    public virtual DbSet<Effect> Effects { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeAccount> EmployeeAccounts { get; set; }

    public virtual DbSet<EmployeePosition> EmployeePositions { get; set; }

    public virtual DbSet<EmployeeStatus> EmployeeStatuses { get; set; }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<IngredientCategory> IngredientCategories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderIngredient> OrderIngredients { get; set; }

    public virtual DbSet<OrderPotion> OrderPotions { get; set; }

    public virtual DbSet<OrderProduct> OrderProducts { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<Potion> Potions { get; set; }

    public virtual DbSet<PotionEffect> PotionEffects { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Receipt> Receipts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        =>
        optionsBuilder.UseSqlServer(
            "Server=localhost;Database=PotionShoppe;User Id=PotionShoppe;Password=PotionPassword1!;Trusted_Connection=False;TrustServerCertificate=True;"
        );

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D857D633FE");

            entity.ToTable("Customer");

            entity.HasIndex(e => e.CustomerStatusId, "IX_Customer_CustomerStatusId");

            entity.Property(e => e.FirstName).HasMaxLength(1024).IsUnicode(false);
            entity.Property(e => e.LastName).HasMaxLength(1024).IsUnicode(false);

            entity
                .HasOne(d => d.CustomerStatus)
                .WithMany(p => p.Customers)
                .HasForeignKey(d => d.CustomerStatusId)
                .HasConstraintName("FK__Customer__Custom__403A8C7D");
        });

        modelBuilder.Entity<CustomerAccount>(entity =>
        {
            entity.HasKey(e => e.CustomerAccountId).HasName("PK__Customer__4212CD8AC8D20F4D");

            entity.ToTable("CustomerAccount");

            entity.HasIndex(e => e.CustomerId, "IX_CustomerAccount_CustomerId");

            entity
                .Property(e => e.Email)
                .HasMaxLength(1024)
                .HasDefaultValueSql("(NULL)")
                .HasComment("");
            entity
                .Property(e => e.RefreshToken)
                .HasMaxLength(1024)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasComment("");
            entity.Property(e => e.TokenExpire).HasComment("");
            entity.Property(e => e.UserName).HasMaxLength(450);

            entity
                .HasOne(d => d.Customer)
                .WithMany(p => p.CustomerAccounts)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__CustomerA__Custo__628FA481");
        });

        modelBuilder.Entity<CustomerStatus>(entity =>
        {
            entity.HasKey(e => e.CustomerStatusId).HasName("PK__Customer__7981F9748147915C");

            entity.ToTable("CustomerStatus");

            entity.Property(e => e.Title).HasMaxLength(1024).IsUnicode(false);
        });

        modelBuilder.Entity<Effect>(entity =>
        {
            entity.HasKey(e => e.EffectId).HasName("PK__Effect__6B859F2348A67585");

            entity.ToTable("Effect");

            entity.Property(e => e.Color).HasMaxLength(32).IsUnicode(false);
            entity.Property(e => e.Description).HasMaxLength(1024).IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(1024).IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04F11D075E280");

            entity.ToTable("Employee");

            entity.HasIndex(e => e.EmployeePositionId, "IX_Employee_EmployeePositionId");

            entity.HasIndex(e => e.EmployeeStatusId, "IX_Employee_EmployeeStatusId");

            entity.Property(e => e.FirstName).HasMaxLength(1024).IsUnicode(false);
            entity.Property(e => e.LastName).HasMaxLength(1024).IsUnicode(false);

            entity
                .HasOne(d => d.EmployeePosition)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.EmployeePositionId)
                .HasConstraintName("FK__Employee__Employ__3B75D760");

            entity
                .HasOne(d => d.EmployeeStatus)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.EmployeeStatusId)
                .HasConstraintName("FK__Employee__Employ__3A81B327");
        });

        modelBuilder.Entity<EmployeeAccount>(entity =>
        {
            entity.HasKey(e => e.EmployeeAccountId).HasName("PK__Employee__32B35D6673E30950");

            entity.ToTable("EmployeeAccount");

            entity.HasIndex(e => e.EmployeeId, "IX_EmployeeAccount_EmployeeId");

            entity
                .Property(e => e.RefreshToken)
                .HasMaxLength(1024)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasComment("");
            entity.Property(e => e.TokenExpire).HasComment("");
            entity.Property(e => e.UserName).HasMaxLength(450);

            entity
                .HasOne(d => d.Employee)
                .WithMany(p => p.EmployeeAccounts)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__EmployeeA__Emplo__656C112C");
        });

        modelBuilder.Entity<EmployeePosition>(entity =>
        {
            entity.HasKey(e => e.EmployeePositionId).HasName("PK__Employee__6FDE90603BFD241C");

            entity.ToTable("EmployeePosition");

            entity.Property(e => e.Title).HasMaxLength(1024).IsUnicode(false);
        });

        modelBuilder.Entity<EmployeeStatus>(entity =>
        {
            entity.HasKey(e => e.EmployeeStatusId).HasName("PK__Employee__3609932C839B699C");

            entity.ToTable("EmployeeStatus");

            entity.Property(e => e.Title).HasMaxLength(1024).IsUnicode(false);
        });

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.HasKey(e => e.IngredientId).HasName("PK__Ingredie__BEAEB25AC1A692C9");

            entity.ToTable("Ingredient");

            entity.Property(e => e.Description).HasMaxLength(1024).IsUnicode(false);
            entity.Property(e => e.Image).HasMaxLength(1024).IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(1024).IsUnicode(false);

            entity
                .HasOne(d => d.Effect)
                .WithMany(p => p.Ingredients)
                .HasForeignKey(d => d.EffectId)
                .HasConstraintName("FK__Ingredien__Effec__4C364F0E");

            entity
                .HasOne(d => d.IngredientCategory)
                .WithMany(p => p.Ingredients)
                .HasForeignKey(d => d.IngredientCategoryId)
                .HasConstraintName("FK__Ingredien__Ingre__4D2A7347");
        });

        modelBuilder.Entity<IngredientCategory>(entity =>
        {
            entity.HasKey(e => e.IngredientCategoryId).HasName("PK__Ingredie__EC1553CAEEC51C67");

            entity.ToTable("IngredientCategory");

            entity.Property(e => e.Title).HasMaxLength(1024).IsUnicode(false);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Order__C3905BCF1519EF42");

            entity.ToTable("Order");

            entity.HasIndex(e => e.CustomerId, "IX_Order_CustomerId");

            entity.HasIndex(e => e.OrderStatusId, "IX_Order_OrderStatusId");

            entity.Property(e => e.OrderNumber).HasMaxLength(1024).IsUnicode(false);

            entity
                .HasOne(d => d.Customer)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Order__CustomerI__4CA06362");

            entity
                .HasOne(d => d.OrderStatus)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderStatusId)
                .HasConstraintName("FK__Order__OrderStat__4D94879B");
        });

        modelBuilder.Entity<OrderIngredient>(entity =>
        {
            entity.HasKey(e => e.OrderIngredientId).HasName("PK__OrderIng__A3146CFAC6FD651F");

            entity.ToTable("OrderIngredient");

            entity
                .HasOne(d => d.Ingredient)
                .WithMany(p => p.OrderIngredients)
                .HasForeignKey(d => d.IngredientId)
                .HasConstraintName("FK__OrderIngr__Ingre__603D47BB");

            entity
                .HasOne(d => d.Order)
                .WithMany(p => p.OrderIngredients)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderIngr__Order__61316BF4");
        });

        modelBuilder.Entity<OrderPotion>(entity =>
        {
            entity.HasKey(e => e.OrderPotionId).HasName("PK__OrderPot__492115795574A6DF");

            entity.ToTable("OrderPotion");

            entity
                .HasOne(d => d.Order)
                .WithMany(p => p.OrderPotions)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderPoti__Order__5D60DB10");

            entity
                .HasOne(d => d.Potion)
                .WithMany(p => p.OrderPotions)
                .HasForeignKey(d => d.PotionId)
                .HasConstraintName("FK__OrderPoti__Potio__5C6CB6D7");
        });

        modelBuilder.Entity<OrderProduct>(entity =>
        {
            entity.HasKey(e => e.OrderProductId).HasName("PK__OrderPro__29B019C2FCE1447D");

            entity.ToTable("OrderProduct");

            entity
                .HasOne(d => d.Order)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderProd__Order__038683F8");

            entity
                .HasOne(d => d.Product)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__OrderProd__Produ__02925FBF");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.HasKey(e => e.OrderStatusId).HasName("PK__OrderSta__BC674CA13BD5CB5D");

            entity.ToTable("OrderStatus");

            entity.Property(e => e.Title).HasMaxLength(1024).IsUnicode(false);
        });

        modelBuilder.Entity<Potion>(entity =>
        {
            entity.HasKey(e => e.PotionId).HasName("PK__Potion__37C41B077B4FA14B");

            entity.ToTable("Potion");

            entity.Property(e => e.Description).HasMaxLength(1024).IsUnicode(false);
            entity.Property(e => e.Image).HasMaxLength(1024).IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(1024).IsUnicode(false);

            entity
                .HasOne(d => d.Employee)
                .WithMany(p => p.Potions)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__Potion__Employee__55BFB948");
        });

        modelBuilder.Entity<PotionEffect>(entity =>
        {
            entity.HasKey(e => e.PotionEffectId).HasName("PK__PotionEf__57036DA88AA1DEF5");

            entity.ToTable("PotionEffect");

            entity
                .HasOne(d => d.Effect)
                .WithMany(p => p.PotionEffects)
                .HasForeignKey(d => d.EffectId)
                .HasConstraintName("FK__PotionEff__Effec__59904A2C");

            entity
                .HasOne(d => d.Potion)
                .WithMany(p => p.PotionEffects)
                .HasForeignKey(d => d.PotionId)
                .HasConstraintName("FK__PotionEff__Potio__589C25F3");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6CD814352D8");

            entity.ToTable("Product");

            entity
                .HasOne(d => d.Ingredient)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.IngredientId)
                .HasConstraintName("FK__Product__Ingredi__7AF13DF7");

            entity
                .HasOne(d => d.Potion)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.PotionId)
                .HasConstraintName("FK__Product__PotionI__7BE56230");
        });

        modelBuilder.Entity<Receipt>(entity =>
        {
            entity.HasKey(e => e.ReceiptId).HasName("PK__Receipt__CC08C420D64391E5");

            entity.ToTable("Receipt");

            entity.Property(e => e.ReceiptNumber).HasMaxLength(1024).IsUnicode(false);

            entity
                .HasOne(d => d.Employee)
                .WithMany(p => p.Receipts)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__Receipt__Employe__51EF2864");

            entity
                .HasOne(d => d.Order)
                .WithMany(p => p.Receipts)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Receipt__OrderId__52E34C9D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
