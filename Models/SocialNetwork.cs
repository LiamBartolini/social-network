using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace fake_social.Models
{
    public partial class SocialNetwork : DbContext
    {
        public SocialNetwork()
        {
        }

        public SocialNetwork(DbContextOptions<SocialNetwork> options)
            : base(options)
        {
        }

        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<Publish> Publishes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source=SocialNetwork.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Post");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.FkIduser).HasColumnName("FK_IDUser");
            });

            modelBuilder.Entity<Publish>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Publish");

                entity.Property(e => e.FkIdpost).HasColumnName("FK_IDPost");

                entity.Property(e => e.FkIduser).HasColumnName("FK_IDUser");

                entity.HasOne(d => d.FkIdpostNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.FkIdpost)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.FkIduserNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.FkIduser)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
