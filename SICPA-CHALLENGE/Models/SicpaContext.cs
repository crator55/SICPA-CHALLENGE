using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SICPA.Models;

public partial class SicpaContext : DbContext
{
    public SicpaContext()
    {
    }

    public SicpaContext(DbContextOptions<SicpaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<DepartmentsEmployee> DepartmentsEmployees { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Enterprise> Enterprises { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=DESKTOP-D6KQSN8;database=Sicpa;Integrated Security=true; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.ToTable("departments");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("description");
            entity.Property(e => e.IdEnterprise).HasColumnName("id_enterprise");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("phone");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.IdEnterpriseNavigation).WithMany(p => p.Departments)
                .HasForeignKey(d => d.IdEnterprise)
                .HasConstraintName("FK_departments_enterprises");
        });

        modelBuilder.Entity<DepartmentsEmployee>(entity =>
        {
            entity.ToTable("departments_employees");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.IdDepartment).HasColumnName("id_department");
            entity.Property(e => e.IdEmployee).HasColumnName("id_employee");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.IdDepartmentNavigation).WithMany(p => p.DepartmentsEmployees)
                .HasForeignKey(d => d.IdDepartment)
                .HasConstraintName("FK_departments");

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.DepartmentsEmployees)
                .HasForeignKey(d => d.IdEmployee)
                .HasConstraintName("FK_employees");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("employees");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Age)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("age");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("email");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.Position)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("position");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Surname)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("surname");
        });

        modelBuilder.Entity<Enterprise>(entity =>
        {
            entity.ToTable("enterprises");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("address");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("phone");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
