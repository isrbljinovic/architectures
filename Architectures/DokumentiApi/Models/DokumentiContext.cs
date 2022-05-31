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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "C");

            modelBuilder.Entity<Dokument>(entity =>
            {
                entity.HasKey(e => e.IdPartner)
                    .HasName("Dokument_pkey");

                entity.ToTable("Dokument");

                entity.Property(e => e.IdPartner).ValueGeneratedNever();

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .UseIdentityAlwaysColumn();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
