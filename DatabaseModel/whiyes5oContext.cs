using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace web.DatabaseModel
{
    public partial class whiyes5oContext : DbContext
    {
        public whiyes5oContext()
        {
        }

        public whiyes5oContext(DbContextOptions<whiyes5oContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Transaction> Transactions { get; set; } = null!;
        public virtual DbSet<TransactionType> TransactionTypes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=mysql80.r2.websupport.sk;port=3314;user id=whiyes5o;password=Qw7$>rjigR;database=whiyes5o", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.11-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8mb3");

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("transaction");

                entity.HasIndex(e => e.TransactionTypeId, "transaction_type_id");

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(40)
                    .HasColumnName("account_number");

                entity.Property(e => e.Amount)
                    .HasPrecision(8, 2)
                    .HasColumnName("amount");

                entity.Property(e => e.BankCode)
                    .HasMaxLength(10)
                    .HasColumnName("bank_code");

                entity.Property(e => e.IssueDate)
                    .HasColumnType("datetime")
                    .HasColumnName("issue_date");

                entity.Property(e => e.TransactionTypeId).HasColumnName("transaction_type_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.TransactionType)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.TransactionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("transaction_ibfk_1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("transaction_ibfk_2");
            });

            modelBuilder.Entity<TransactionType>(entity =>
            {
                entity.ToTable("transaction_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Salary)
                    .HasPrecision(8, 2)
                    .HasColumnName("salary");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
