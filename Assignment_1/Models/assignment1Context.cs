using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Assignment_1.Models
{
    public partial class assignment1Context : DbContext
    {
        public assignment1Context()
        {
        }

        public assignment1Context(DbContextOptions<assignment1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<UserManagement> UserManagements { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=assignment-1;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserManagement>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.ToTable("User_Management");

                entity.HasIndex(e => e.Password, "IX_User_Management")
                    .IsUnique();

                entity.Property(e => e.Username).HasMaxLength(200);

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.AllowNotification).HasColumnName("Allow_Notification");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Company).HasMaxLength(100);

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("First_Name");

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("Last_Name");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .HasColumnName("Middle_Name");

                entity.Property(e => e.Password).HasMaxLength(200);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.ZipCode).HasColumnName("Zip_Code");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
