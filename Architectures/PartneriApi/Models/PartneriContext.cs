using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PartneriApi.Models
{
    public partial class PartneriContext : DbContext
    {
        public PartneriContext()
        {
        }

        public PartneriContext(DbContextOptions<PartneriContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Mjesto> Mjestos { get; set; }
        public virtual DbSet<Partner> Partners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "C");

            modelBuilder.Entity<Mjesto>(entity =>
            {
                entity.ToTable("Mjesto");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Naziv).IsRequired();

                entity.Property(e => e.OznakaDrzava).IsRequired();
            });

            modelBuilder.Entity<Partner>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("Partner_pkey");

                entity.ToTable("Partner");

                entity.Property(e => e.MjestoId).ValueGeneratedNever();

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .UseIdentityAlwaysColumn();

                entity.HasOne(d => d.IdMjestaNavigation)
                    .WithOne(p => p.Partner)
                    .HasForeignKey<Partner>(d => d.MjestoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Partner_MjestoId_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
