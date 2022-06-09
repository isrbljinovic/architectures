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
                entity.ToTable("Dokument");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            });

            modelBuilder.Entity<Stavka>(entity =>
            {
                entity.ToTable("Stavka");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

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
