using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PruebaDesarrolloJavierCastellon.Models
{
    public partial class TestDBContext : DbContext
    {
        public TestDBContext()
        {
        }

        public TestDBContext(DbContextOptions<TestDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<JecmBranch> JecmBranches { get; set; }
        public virtual DbSet<JecmMoney> JecmMoneys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=ins-dllo-test-01.public.33e082952ab4.database.windows.net,3342;Database=TestDB;User ID=prueba;Password=pruebaconcepto");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");


            modelBuilder.Entity<JecmBranch>(entity =>
            {
                entity.HasKey(e => e.IdBranch)
                    .HasName("PK__jecm_bra__A33E4FC43FF25FEA");

                entity.ToTable("jecm_branch");

                entity.Property(e => e.IdBranch).HasColumnName("idBranch");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Cod).HasColumnName("cod");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Direction)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("direction");

                entity.Property(e => e.Identification)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("identification");

                entity.Property(e => e.MoneyId).HasColumnName("moneyId");

                entity.HasOne(d => d.Money)
                    .WithMany(p => p.JecmBranches)
                    .HasForeignKey(d => d.MoneyId)
                    .HasConstraintName("FK__jecm_bran__money__4C8B54C9");
            });

            modelBuilder.Entity<JecmMoney>(entity =>
            {
                entity.HasKey(e => e.IdMoney)
                    .HasName("PK__jecm_Mon__16451A046CE334B6");

                entity.ToTable("jecm_Money");

                entity.Property(e => e.IdMoney).HasColumnName("idMoney");

                entity.Property(e => e.Abbreviation)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("abbreviation");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Cod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("cod");

                entity.Property(e => e.Country)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("country");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Symbol)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("symbol");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
