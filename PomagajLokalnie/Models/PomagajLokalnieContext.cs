using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PomagajLokalnie.Models
{
    public partial class PomagajLokalnieContext : DbContext
    {
        public PomagajLokalnieContext()
        {
        }

        public PomagajLokalnieContext(DbContextOptions<PomagajLokalnieContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        public virtual DbSet<OfferType> OfferTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Voucher> Vouchers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=GRZESIEK\\SQLEXPRESS01;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False; Database=PomagajLokalnie");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_CI_AS");

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.Nip)
                    .HasName("PK__Company__C7DEC3C70066F3DA");

                entity.ToTable("Company");

                entity.Property(e => e.Nip).HasColumnName("NIP");

                entity.Property(e => e.BankAccount).HasMaxLength(50);

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Deleted_At");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Offer>(entity =>
            {
                entity.ToTable("Offer");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Deleted_At");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.OfferType)
                    .WithMany(p => p.Offers)
                    .HasForeignKey(d => d.OfferTypeId)
                    .HasConstraintName("FK__Offer__OfferType__2C3393D0");
            });

            modelBuilder.Entity<OfferType>(entity =>
            {
                entity.ToTable("OfferType");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User_");

                entity.Property(e => e.Login).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Roles).HasMaxLength(20);
            });

            modelBuilder.Entity<Voucher>(entity =>
            {
                entity.ToTable("Voucher");

                entity.Property(e => e.ExpirationDate).HasColumnType("datetime");

                entity.HasOne(d => d.Offer)
                    .WithMany(p => p.Vouchers)
                    .HasForeignKey(d => d.OfferId)
                    .HasConstraintName("FK__Voucher__OfferId__2F10007B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
