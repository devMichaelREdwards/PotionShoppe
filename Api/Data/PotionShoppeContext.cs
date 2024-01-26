using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Api.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;

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

    public virtual DbSet<CustomerStatus> CustomerStatuses { get; set; }

    public virtual DbSet<Effect> Effects { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeePosition> EmployeePositions { get; set; }

    public virtual DbSet<EmployeeStatus> EmployeeStatuses { get; set; }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderIngredient> OrderIngredients { get; set; }

    public virtual DbSet<OrderPotion> OrderPotions { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<Potion> Potions { get; set; }

    public virtual DbSet<PotionEffect> PotionEffects { get; set; }

    public virtual DbSet<Receipt> Receipts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlServer(connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D886D2B2B2");

            entity.ToTable("Customer");

            entity.Property(e => e.Name).HasMaxLength(1024).IsUnicode(false);
            entity.Property(e => e.Password).HasMaxLength(1024).IsUnicode(false);
            entity.Property(e => e.Username).HasMaxLength(1024).IsUnicode(false);

            entity
                .HasOne(d => d.CustomerStatus)
                .WithMany(p => p.Customers)
                .HasForeignKey(d => d.CustomerStatusId)
                .HasConstraintName("FK__Customer__Custom__5EBF139D");
        });

        modelBuilder.Entity<CustomerStatus>(entity =>
        {
            entity.HasKey(e => e.CustomerStatusId).HasName("PK__Customer__7981F974F0CD2871");

            entity.ToTable("CustomerStatus");

            entity.Property(e => e.Title).HasMaxLength(1024).IsUnicode(false);
        });

        modelBuilder.Entity<Effect>(entity =>
        {
            entity.HasKey(e => e.EffectId).HasName("PK__Effect__6B859F23B4842032");

            entity.ToTable("Effect");

            entity.Property(e => e.Description).HasMaxLength(1024).IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04F111E192696");

            entity.ToTable("Employee");

            entity.HasIndex(e => e.EmployeePositionId, "IX_Employee_EmployeePositionId");

            entity.HasIndex(e => e.EmployeeStatusId, "IX_Employee_EmployeeStatusId");

            entity.Property(e => e.Name).HasMaxLength(1024).IsUnicode(false);
            entity.Property(e => e.Password).HasMaxLength(1024).IsUnicode(false);
            entity.Property(e => e.Username).HasMaxLength(1024).IsUnicode(false);

            entity
                .HasOne(d => d.EmployeePosition)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.EmployeePositionId)
                .HasConstraintName("FK__Employee__Positi__3B75D760");

            entity
                .HasOne(d => d.EmployeeStatus)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.EmployeeStatusId)
                .HasConstraintName("FK__Employee__Employ__3A81B327");
        });

        modelBuilder.Entity<EmployeePosition>(entity =>
        {
            entity.HasKey(e => e.EmployeePositionId).HasName("PK__Employee__6FDE90608211D274");

            entity.ToTable("EmployeePosition");

            entity.Property(e => e.Title).HasMaxLength(1024).IsUnicode(false);
        });

        modelBuilder.Entity<EmployeeStatus>(entity =>
        {
            entity.HasKey(e => e.EmployeeStatusId).HasName("PK__Employee__3609932CFFE47B28");

            entity.ToTable("EmployeeStatus");

            entity.Property(e => e.Title).HasMaxLength(1024).IsUnicode(false);
        });

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.HasKey(e => e.IngredientId).HasName("PK__Ingredie__BEAEB25AF7375E9D");

            entity.ToTable("Ingredient");

            entity.Property(e => e.Description).HasMaxLength(1024).IsUnicode(false);
            entity.Property(e => e.Image).HasMaxLength(1024).IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(1024).IsUnicode(false);

            entity
                .HasOne(d => d.Effect)
                .WithMany(p => p.Ingredients)
                .HasForeignKey(d => d.EffectId)
                .HasConstraintName("FK__Ingredien__Effec__6FE99F9F");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Order__C3905BCF83ECF446");

            entity.ToTable("Order");

            entity.Property(e => e.OrderNumber).HasMaxLength(1024).IsUnicode(false);

            entity
                .HasOne(d => d.Customer)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Order__CustomerI__619B8048");

            entity
                .HasOne(d => d.OrderStatus)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderStatusId)
                .HasConstraintName("FK__Order__OrderStat__628FA481");
        });

        modelBuilder.Entity<OrderIngredient>(entity =>
        {
            entity.HasKey(e => e.OrderIngredientId).HasName("PK__OrderIng__A3146CFAFE93B5E3");

            entity.ToTable("OrderIngredient");

            entity
                .HasOne(d => d.Ingredient)
                .WithMany(p => p.OrderIngredients)
                .HasForeignKey(d => d.IngredientId)
                .HasConstraintName("FK__OrderIngr__Ingre__06CD04F7");

            entity
                .HasOne(d => d.Order)
                .WithMany(p => p.OrderIngredients)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderIngr__Order__07C12930");
        });

        modelBuilder.Entity<OrderPotion>(entity =>
        {
            entity.HasKey(e => e.OrderPotionId).HasName("PK__OrderPot__49211579A05C96F4");

            entity.ToTable("OrderPotion");

            entity
                .HasOne(d => d.Order)
                .WithMany(p => p.OrderPotions)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderPoti__Order__03F0984C");

            entity
                .HasOne(d => d.Potion)
                .WithMany(p => p.OrderPotions)
                .HasForeignKey(d => d.PotionId)
                .HasConstraintName("FK__OrderPoti__Potio__02FC7413");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.HasKey(e => e.OrderStatusId).HasName("PK__OrderSta__BC674CA10766E817");

            entity.ToTable("OrderStatus");

            entity.Property(e => e.Title).HasMaxLength(1024).IsUnicode(false);
        });

        modelBuilder.Entity<Potion>(entity =>
        {
            entity.HasKey(e => e.PotionId).HasName("PK__Potion__37C41B07D900FFC5");

            entity.ToTable("Potion");

            entity.HasIndex(e => e.EmployeeId, "IX_Potion_EmployeeId");

            entity.Property(e => e.Description).HasMaxLength(1024).IsUnicode(false);
            entity.Property(e => e.Image).HasMaxLength(1024).IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(1024).IsUnicode(false);

            entity
                .HasOne(d => d.Employee)
                .WithMany(p => p.Potions)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__Potion__Employee__4E88ABD4");
        });

        modelBuilder.Entity<PotionEffect>(entity =>
        {
            entity.HasKey(e => e.PotionEffectId).HasName("PK__PotionEf__57036DA83F8897E4");

            entity.ToTable("PotionEffect");

            entity.HasIndex(e => e.EffectId, "IX_PotionEffect_EffectId");

            entity.HasIndex(e => e.PotionId, "IX_PotionEffect_PotionId");

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
            entity.HasKey(e => e.ReceiptId).HasName("PK__Receipt__CC08C420DB8611F0");

            entity.ToTable("Receipt");

            entity.Property(e => e.ReceiptNumber).HasMaxLength(1024).IsUnicode(false);

            entity
                .HasOne(d => d.Employee)
                .WithMany(p => p.Receipts)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__Receipt__Employe__656C112C");

            entity
                .HasOne(d => d.Order)
                .WithMany(p => p.Receipts)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Receipt__OrderId__66603565");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
