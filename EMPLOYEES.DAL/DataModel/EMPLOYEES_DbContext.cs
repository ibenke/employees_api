using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EMPLOYEES.DAL.DataModel
{
    public partial class EMPLOYEES_DbContext : DbContext
    {
        public EMPLOYEES_DbContext()
        {
        }

        public EMPLOYEES_DbContext(DbContextOptions<EMPLOYEES_DbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmployeesIbenke> EmployeesIbenke { get; set; }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=193.198.57.183;Database=EMPLOYEES;User Id=student;Password=student;");
            }
        }
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeesIbenke>(entity =>
            {
                entity.HasKey(e => e.EmpNo);

                entity.ToTable("EMPLOYEES_IBENKE");

                entity.Property(e => e.EmpNo).HasColumnName("EMP_NO");

                entity.Property(e => e.BirthDate)
                    .HasColumnName("BIRTH_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .HasColumnName("FIRST_NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasColumnName("GENDER")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.HireDate)
                    .HasColumnName("HIRE_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.LastName)
                    .HasColumnName("LAST_NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
