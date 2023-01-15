using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SoftGenTest.Repository.Models;

namespace SoftGenTest.Repository;

public partial class StudentDbContext : DbContext
{
    public StudentDbContext()
    {
    }

    public StudentDbContext(DbContextOptions<StudentDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<GroupsTb> GroupsTbs { get; set; }

    public virtual DbSet<StudentTbGroupTb> StudentTbGroupTbs { get; set; }

    public virtual DbSet<StudentsTb> StudentsTbs { get; set; }

    public virtual DbSet<TeacherTbGroupTb> TeacherTbGroupTbs { get; set; }

    public virtual DbSet<TeachersTb> TeachersTbs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\local;Initial Catalog=Student;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GroupsTb>(entity =>
        {
            entity.HasKey(e => e.GroupId);

            entity.ToTable("GroupsTb");

            entity.Property(e => e.GroupName).HasMaxLength(50);
        });

        modelBuilder.Entity<StudentTbGroupTb>(entity =>
        {
            entity.ToTable("StudentTbGroupTb");

            entity.HasOne(d => d.Group).WithMany(p => p.StudentTbGroupTbs)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK_StudentTbGroupTb_GroupsTb");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentTbGroupTbs)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_StudentTbGroupTb_StudentsTb");
        });

        modelBuilder.Entity<StudentsTb>(entity =>
        {
            entity.HasKey(e => e.StudentId);

            entity.ToTable("StudentsTb");

            entity.Property(e => e.BirthdayDate).HasColumnType("datetime");
            entity.Property(e => e.Mail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(50);
        });

        modelBuilder.Entity<TeacherTbGroupTb>(entity =>
        {
            entity.ToTable("TeacherTbGroupTb");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.Group).WithMany(p => p.TeacherTbGroupTbs)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK_TeacherTbGroupTb_GroupsTb");

            entity.HasOne(d => d.Teacher).WithMany(p => p.TeacherTbGroupTbs)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK_TeacherTbGroupTb_TeachersTb");
        });

        modelBuilder.Entity<TeachersTb>(entity =>
        {
            entity.HasKey(e => e.TeacherId);

            entity.ToTable("TeachersTb");

            entity.Property(e => e.BirthdayDate).HasColumnType("date");
            entity.Property(e => e.Mail).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
