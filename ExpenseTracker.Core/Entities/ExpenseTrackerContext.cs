using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Core.Entities;

public partial class ExpenseTrackerDbContext : DbContext
{
    public ExpenseTrackerDbContext()
    {
    }

    public ExpenseTrackerDbContext(DbContextOptions<ExpenseTrackerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CreditCard> CreditCards { get; set; }

    public virtual DbSet<Expense> Expenses { get; set; }

    public virtual DbSet<ExpenseCategory> ExpenseCategories { get; set; }

    public virtual DbSet<ExpenseType> ExpenseTypes { get; set; }

    public virtual DbSet<Family> Families { get; set; }

    public virtual DbSet<UserProfile> UserProfiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=SEFRONE\\\\\\\\SQLEXPRESS01,1433;Initial Catalog=ExpenseTracker;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CreditCard>(entity =>
        {
            entity.HasKey(e => e.CreditCardId).HasName("PK_CreditCard_CreditCardId");

            entity.HasOne(d => d.User).WithMany(p => p.CreditCards).HasConstraintName("FK_CreditCard_UserProfile");
        });

        modelBuilder.Entity<Expense>(entity =>
        {
            entity.HasKey(e => e.ExpenseId).HasName("PK_Expense_ExpenseId");

            entity.HasOne(d => d.CreditCard).WithMany(p => p.Expenses).HasConstraintName("FK_Expense_CreditCard");

            entity.HasOne(d => d.ExpenseCategory).WithMany(p => p.Expenses).HasConstraintName("FK_Expense_Category");

            entity.HasOne(d => d.ExpenseType).WithMany(p => p.Expenses).HasConstraintName("FK_Expense_Type");

            entity.HasOne(d => d.User).WithMany(p => p.Expenses).HasConstraintName("FK_Expense_User");
        });

        modelBuilder.Entity<ExpenseCategory>(entity =>
        {
            entity.HasKey(e => e.ExpenseCategoryId).HasName("PK_ExpenseCategory_ExpenseCategoryId");
        });

        modelBuilder.Entity<ExpenseType>(entity =>
        {
            entity.HasKey(e => e.ExpenseTypeId).HasName("PK_ExpenseType_ExpenseTypeId");
        });

        modelBuilder.Entity<Family>(entity =>
        {
            entity.HasKey(e => e.FamilyId).HasName("PK_Family_FamilyId");
        });

        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_UserProfile_UserId");

            entity.Property(e => e.DisplayName).HasDefaultValue("Guest");

            entity.HasOne(d => d.Family).WithMany(p => p.UserProfiles).HasConstraintName("FK_UserProfile_Family");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
