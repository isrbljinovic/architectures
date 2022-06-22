using Microsoft.EntityFrameworkCore;
using NLayered.Contracts.Models;

#nullable disable

namespace NLayered.DataLayer.DbContexts
{
    public partial class FirmaContext : DbContext
    {
        public FirmaContext()
        {
        }

        public FirmaContext(DbContextOptions<FirmaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artikl> Artikls { get; set; }
        public virtual DbSet<Dokument> Dokuments { get; set; }
        public virtual DbSet<Drzava> Drzavas { get; set; }
        public virtual DbSet<Mjesto> Mjestos { get; set; }
        public virtual DbSet<Partner> Partners { get; set; }
        public virtual DbSet<Stavka> Stavkas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "C");

            modelBuilder.Entity<Artikl>(entity =>
            {
                entity.HasKey(e => e.IdArtikla)
                    .HasName("Artikl_pkey");

                entity.ToTable("Artikl");

                entity.Property(e => e.IdArtikla).UseIdentityAlwaysColumn();

                entity.Property(e => e.Cijena).HasColumnType("money");
            });

            modelBuilder.Entity<Dokument>(entity =>
            {
                entity.ToTable("Dokument");

                entity.Property(e => e.IdDokumenta).UseIdentityAlwaysColumn();

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.Dokuments)
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Dokument_PartnerId_fkey");
            });

            modelBuilder.Entity<Drzava>(entity =>
            {
                entity.HasKey(e => e.IdDrzave)
                    .HasName("Drzava_pkey");

                entity.ToTable("Drzava");

                entity.Property(e => e.Naziv).IsRequired();
            });

            modelBuilder.Entity<Mjesto>(entity =>
            {
                entity.ToTable("Mjesto");

                entity.Property(e => e.IdMjesto).UseIdentityAlwaysColumn();

                entity.Property(e => e.Naziv).IsRequired();

                entity.Property(e => e.DrzavaId).IsRequired();

                entity.HasOne(d => d.OznakaDrzaveNavigation)
                    .WithMany(p => p.Mjestos)
                    .HasForeignKey(d => d.DrzavaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Mjesto_OznakaDrzave_fkey");
            });

            modelBuilder.Entity<Partner>(entity =>
            {
                entity.ToTable("Partner");

                entity.Property(e => e.IdPartnera).UseIdentityAlwaysColumn();

                entity.HasOne(d => d.SjedisteNavigation)
                    .WithMany(p => p.Partners)
                    .HasForeignKey(d => d.Sjediste)
                    .HasConstraintName("Partner_Sjediste_fkey");
            });

            modelBuilder.Entity<Stavka>(entity =>
            {
                entity.ToTable("Stavka");

                entity.Property(e => e.IdStavke).UseIdentityAlwaysColumn();

                entity.Property(e => e.Kolicina).HasDefaultValueSql("0");

                entity.HasOne(d => d.Dokument)
                    .WithMany(p => p.Stavkas)
                    .HasForeignKey(d => d.DokumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Stavka_DokumentId_fkey");

                entity.HasOne(d => d.SifraArtiklaNavigation)
                    .WithMany(p => p.Stavkas)
                    .HasForeignKey(d => d.ArtiklId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Stavka_SifraArtikla_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
