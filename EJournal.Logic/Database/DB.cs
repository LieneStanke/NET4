using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EJournal.Logic.Database
{
    public partial class DB : DbContext
    {
        public DB()
        {
        }

        public DB(DbContextOptions<DB> options)
            : base(options)
        {
        }

        public virtual DbSet<Grades> Grades { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Koko\\Desktop\\C#\\EJournalDB.mdf;Integrated Security=True;Connect Timeout=30");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grades>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(150);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SubjectName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.Property(e => e.BirthYear)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Class)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Subjects>(entity =>
            {
                entity.Property(e => e.SubjectName)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
