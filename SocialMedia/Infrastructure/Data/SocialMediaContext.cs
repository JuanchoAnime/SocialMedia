using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;

namespace SocialMedia.Infrastructure.Data
{
    public partial class SocialMediaContext : DbContext
    {
        public SocialMediaContext() { }

        public SocialMediaContext(DbContextOptions<SocialMediaContext> options)
            : base(options) { }

        public virtual DbSet<Comentary> Comentary { get; set; }

        public virtual DbSet<Publication> Publication { get; set; }

        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Server=LAPTOP-FAU5RKMJ\\SQLEXPRESS;Database=SocialMedia;Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comentary>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                        .HasColumnName("IdComentary")
                        .ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPublicationNavigation)
                    .WithMany(p => p.Comentary)
                    .HasForeignKey(d => d.IdPublication)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comentary_Publication");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Comentary)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comentary_User");
            });

            modelBuilder.Entity<Publication>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                        .HasColumnName("IdPublication");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Publication)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Publication_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                        .HasColumnName("IdUser");

                entity.Property(e => e.Cellphone)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DateNatal).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Names)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
