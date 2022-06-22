using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DokumentiApi.Models
{
    public partial class DokumentiContext : DbContext
    {
        public DokumentiContext()
        {
        }

        public DokumentiContext(DbContextOptions<DokumentiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dokument> Dokuments { get; set; }
        public virtual DbSet<Stavka> Stavkas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "C");

            modelBuilder.Entity<Dokument>(entity =>
            {
                entity.HasKey(e => e.IdDokumenta)
                    .HasName("Dokument_pkey");

                entity.ToTable("Dokument");

                entity.Property(e => e.IdDokumenta).UseIdentityAlwaysColumn();
            });

            modelBuilder.Entity<Stavka>(entity =>
            {
                entity.HasKey(e => e.IdStavke)
                    .HasName("Stavka_pkey");

                entity.ToTable("Stavka");

                entity.Property(e => e.IdStavke).UseIdentityAlwaysColumn();

                entity.HasOne(d => d.Dokument)
                    .WithMany(p => p.Stavkas)
                    .HasForeignKey(d => d.DokumentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("Stavka_DokumentId_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
