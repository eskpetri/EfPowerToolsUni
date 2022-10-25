﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EfPowerToolsUni.Models;
using DateTimeAPI.Converters;

namespace EfPowerToolsUni.Data
{
    public partial class universityContext : DbContext
    {
        public universityContext()
        {
        }

        public universityContext(DbContextOptions<universityContext> options)
            : base(options)
        {
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);

            configurationBuilder.Properties<DateOnly>()
                                .HaveConversion<DateOnlyEFConverter>()
                                .HaveColumnType("date");

            configurationBuilder.Properties<TimeOnly>()
                      .HaveConversion<TimeOnlyEFConverter>()
                      .HaveColumnType("time");
        }

        public virtual DbSet<Administrator> Administrators { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Grade> Grades { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Viewgrade> Viewgrades { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=127.0.0.1;user id=netuser;password=netpass;port=3306;database=university", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8mb3");

            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.HasKey(e => e.Idadministrator)
                    .HasName("PRIMARY");

                entity.ToTable("administrator");

                entity.Property(e => e.Idadministrator)
                    .ValueGeneratedNever()
                    .HasColumnName("idadministrator");

                entity.Property(e => e.Category)
                    .HasMaxLength(2)
                    .HasColumnName("category")
                    .IsFixedLength();

                entity.HasOne(d => d.IdadministratorNavigation)
                    .WithOne(p => p.Administrator)
                    .HasForeignKey<Administrator>(d => d.Idadministrator)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_administrator");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.Idcourse)
                    .HasName("PRIMARY");

                entity.ToTable("course");

                entity.Property(e => e.Idcourse)
                    .ValueGeneratedNever()
                    .HasColumnName("idcourse");

                entity.Property(e => e.Greditpoints).HasColumnName("greditpoints");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.Iddepartment)
                    .HasName("PRIMARY");

                entity.ToTable("department");

                entity.Property(e => e.Iddepartment)
                    .ValueGeneratedNever()
                    .HasColumnName("iddepartment");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.HasKey(e => e.Idgrade)
                    .HasName("PRIMARY");

                entity.ToTable("grade");

                entity.HasIndex(e => e.Idcourse, "cource_grade_idx");

                entity.HasIndex(e => e.Idstudent, "student_grade_idx");

                entity.HasIndex(e => e.Idteacher, "teacher_grade_idx");

                entity.Property(e => e.Idgrade).HasColumnName("idgrade");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Grade1).HasColumnName("grade");

                entity.Property(e => e.Idcourse).HasColumnName("idcourse");

                entity.Property(e => e.Idstudent).HasColumnName("idstudent");

                entity.Property(e => e.Idteacher).HasColumnName("idteacher");

                entity.HasOne(d => d.IdcourseNavigation)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.Idcourse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cource_grade");

                entity.HasOne(d => d.IdstudentNavigation)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.Idstudent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("student_grade");

                entity.HasOne(d => d.IdteacherNavigation)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.Idteacher)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("teacher_grade");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Idstudent)
                    .HasName("PRIMARY");

                entity.ToTable("student");

                entity.Property(e => e.Idstudent)
                    .ValueGeneratedNever()
                    .HasColumnName("idstudent");

                entity.Property(e => e.GraduateDate).HasColumnName("graduate_date");

                entity.Property(e => e.StartDate).HasColumnName("start_date");

                entity.HasOne(d => d.IdstudentNavigation)
                    .WithOne(p => p.Student)
                    .HasForeignKey<Student>(d => d.Idstudent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_student");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(e => e.Idteacher)
                    .HasName("PRIMARY");

                entity.ToTable("teacher");

                entity.HasIndex(e => e.Iddepartment, "department_teacher_idx");

                entity.Property(e => e.Idteacher)
                    .ValueGeneratedNever()
                    .HasColumnName("idteacher");

                entity.Property(e => e.Iddepartment).HasColumnName("iddepartment");

                entity.HasOne(d => d.IddepartmentNavigation)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.Iddepartment)
                    .HasConstraintName("department_teacher");

                entity.HasOne(d => d.IdteacherNavigation)
                    .WithOne(p => p.Teacher)
                    .HasForeignKey<Teacher>(d => d.Idteacher)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_teacher");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Iduser)
                    .HasName("PRIMARY");

                entity.ToTable("user");

                entity.HasIndex(e => e.Username, "username_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Iduser).HasColumnName("iduser");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(45)
                    .HasColumnName("firstname");

                entity.Property(e => e.Identity).HasColumnName("identity");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(45)
                    .HasColumnName("lastname");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(45)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Viewgrade>(entity =>
            {
                // entity.HasNoKey();
                entity.HasKey(e => e.Idgrade)
                .HasName("PRIMARY");

                entity.ToView("viewgrades");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Grade).HasColumnName("grade");

                entity.Property(e => e.Greditpoints).HasColumnName("greditpoints");

                entity.Property(e => e.Idgrade).HasColumnName("idgrade");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.Property(e => e.Student)
                    .HasMaxLength(91)
                    .HasColumnName("student");

                entity.Property(e => e.Studentusername)
                    .HasMaxLength(45)
                    .HasColumnName("studentusername");

                entity.Property(e => e.Teacher)
                    .HasMaxLength(91)
                    .HasColumnName("teacher");

                entity.Property(e => e.Username)
                    .HasMaxLength(45)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}