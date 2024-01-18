using Microsoft.EntityFrameworkCore;
using Api.Models;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Api.Data;

public partial class PotionShoppeContext : DbContext
{
    private readonly string? connectionString;

    public PotionShoppeContext() { }

    public PotionShoppeContext(DbContextOptions<PotionShoppeContext> options) : base(options)
    {
        foreach (IDbContextOptionsExtension extension in options.Extensions)
        {
            if (extension is SqlServerOptionsExtension)
            {
                connectionString = ((SqlServerOptionsExtension)extension).ConnectionString;
                break;
            }
        }
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Effect> Effects { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeePosition> EmployeePositions { get; set; }

    public virtual DbSet<EmployeeStatus> EmployeeStatuses { get; set; }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderPotion> OrderPotions { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<Potion> Potions { get; set; }

    public virtual DbSet<PotionEffect> PotionEffects { get; set; }

    public virtual DbSet<Receipt> Receipts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        =>
        optionsBuilder.UseSqlServer(connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D81437BBF8");

            entity.ToTable("Customer");

            entity.Property(e => e.Name).HasMaxLength(1).IsUnicode(false);
            entity.Property(e => e.Password).HasMaxLength(1).IsUnicode(false);
            entity.Property(e => e.Username).HasMaxLength(1).IsUnicode(false);
        });

        modelBuilder.Entity<Effect>(entity =>
        {
            entity.HasKey(e => e.EffectId).HasName("PK__Effect__6B859F23DCBA16A7");

            entity.ToTable("Effect");

            entity.Property(e => e.Description).HasMaxLength(1).IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04F11C4A0BEB2");

            entity.ToTable("Employee");

            entity.Property(e => e.Name).HasMaxLength(1).IsUnicode(false);
            entity.Property(e => e.Password).HasMaxLength(1).IsUnicode(false);
            entity.Property(e => e.Username).HasMaxLength(1).IsUnicode(false);

            entity
                .HasOne(d => d.EmployeeStatus)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.EmployeeStatusId)
                .HasConstraintName("FK__Employee__Employ__3A81B327");

            entity
                .HasOne(d => d.Position)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK__Employee__Positi__3B75D760");
        });

        modelBuilder.Entity<EmployeePosition>(entity =>
        {
            entity.HasKey(e => e.EmployeePositionId).HasName("PK__Employee__6FDE9060E62AE4F5");

            entity.ToTable("EmployeePosition");

            entity.Property(e => e.Title).HasMaxLength(1).IsUnicode(false);
        });

        modelBuilder.Entity<EmployeeStatus>(entity =>
        {
            entity.HasKey(e => e.EmployeeStatusId).HasName("PK__Employee__3609932CA01C5C5A");

            entity.ToTable("EmployeeStatus");

            entity.Property(e => e.Title).HasMaxLength(1).IsUnicode(false);
        });

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.HasKey(e => e.IngredientId).HasName("PK__Ingredie__BEAEB25A2D6DDA34");

            entity.ToTable("Ingredient");

            entity.Property(e => e.Description).HasMaxLength(1).IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(1).IsUnicode(false);

            entity
                .HasOne(d => d.Effect)
                .WithMany(p => p.Ingredients)
                .HasForeignKey(d => d.EffectId)
                .HasConstraintName("FK__Ingredien__Effec__4222D4EF");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Order__C3905BCF0C820B78");

            entity.ToTable("Order");

            entity.Property(e => e.OrderNumber).HasMaxLength(1).IsUnicode(false);

            entity
                .HasOne(d => d.Customer)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Order__CustomerI__46E78A0C");

            entity
                .HasOne(d => d.OrderStatus)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderStatusId)
                .HasConstraintName("FK__Order__OrderStat__47DBAE45");
        });

        modelBuilder.Entity<OrderPotion>(entity =>
        {
            entity.HasKey(e => e.OrderPotionId).HasName("PK__OrderPot__49211579B734CC3C");

            entity
                .HasOne(d => d.Order)
                .WithMany(p => p.OrderPotionOrders)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderPoti__Order__5629CD9C");

            entity
                .HasOne(d => d.Potion)
                .WithMany(p => p.OrderPotionPotions)
                .HasForeignKey(d => d.PotionId)
                .HasConstraintName("FK__OrderPoti__Potio__5535A963");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.HasKey(e => e.OrderStatusId).HasName("PK__OrderSta__BC674CA11556BF13");

            entity.ToTable("OrderStatus");

            entity.Property(e => e.Title).HasMaxLength(1).IsUnicode(false);
        });

        modelBuilder.Entity<Potion>(entity =>
        {
            entity.HasKey(e => e.PotionId).HasName("PK__Potion__37C41B073F9866B4");

            entity.ToTable("Potion");

            entity.Property(e => e.Description).HasMaxLength(1).IsUnicode(false);
            entity.Property(e => e.Image).HasMaxLength(1).IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(1).IsUnicode(false);

            entity
                .HasOne(d => d.Employee)
                .WithMany(p => p.Potions)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__Potion__Employee__4E88ABD4");
        });

        modelBuilder.Entity<PotionEffect>(entity =>
        {
            entity.HasKey(e => e.PotionEffectId).HasName("PK__PotionEf__57036DA805751ADE");

            entity.ToTable("PotionEffect");

            entity
                .HasOne(d => d.Effect)
                .WithMany(p => p.PotionEffects)
                .HasForeignKey(d => d.EffectId)
                .HasConstraintName("FK__PotionEff__Effec__52593CB8");

            entity
                .HasOne(d => d.Potion)
                .WithMany(p => p.PotionEffects)
                .HasForeignKey(d => d.PotionId)
                .HasConstraintName("FK__PotionEff__Potio__5165187F");
        });

        modelBuilder.Entity<Receipt>(entity =>
        {
            entity.HasKey(e => e.ReceiptId).HasName("PK__Receipt__CC08C4200E4FC96C");

            entity.ToTable("Receipt");

            entity.Property(e => e.ReceiptNumber).HasMaxLength(1).IsUnicode(false);

            entity
                .HasOne(d => d.Employee)
                .WithMany(p => p.Receipts)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__Receipt__Employe__4AB81AF0");

            entity
                .HasOne(d => d.Order)
                .WithMany(p => p.Receipts)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Receipt__OrderId__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
