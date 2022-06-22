using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ArtikliApi.Models
{
    public partial class ArtikliContext : DbContext
    {
        public ArtikliContext()
        {
        }

        public ArtikliContext(DbContextOptions<ArtikliContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artikl> Artikls { get; set; }

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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
