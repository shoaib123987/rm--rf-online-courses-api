using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Online_Courses.Models;

public partial class OnlineCoursesContext : DbContext
{
    public OnlineCoursesContext()
    {
    }

    public OnlineCoursesContext(DbContextOptions<OnlineCoursesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<About> Abouts { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseVideo> CourseVideos { get; set; }

    public virtual DbSet<Crousel> Crousels { get; set; }

    public virtual DbSet<ExploreSubject> ExploreSubjects { get; set; }

    public virtual DbSet<Register> Registers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<About>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__about__3213E83F9545937E");

            entity.ToTable("about");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AboutImg)
                .IsUnicode(false)
                .HasColumnName("about_img");
            entity.Property(e => e.Head)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("head");
            entity.Property(e => e.Para)
                .IsUnicode(false)
                .HasColumnName("para");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__courses__3213E83F1ACE04EC");

            entity.ToTable("courses");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CourseImg)
                .IsUnicode(false)
                .HasColumnName("course_img");
            entity.Property(e => e.Duration)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("duration");
            entity.Property(e => e.EsId).HasColumnName("es_id");
            entity.Property(e => e.Popular)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("popular");
            entity.Property(e => e.Price)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("price");
            entity.Property(e => e.Subjects)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("subjects");

            entity.HasOne(d => d.Es).WithMany(p => p.Courses)
                .HasForeignKey(d => d.EsId)
                .HasConstraintName("FK__courses__es_id__5EBF139D");
        });

        modelBuilder.Entity<CourseVideo>(entity =>
        {
            entity.HasKey(e => e.CvId).HasName("PK__course_v__C36883E6BD64692F");

            entity.ToTable("course_videos");

            entity.Property(e => e.CvId).HasColumnName("cv_id");
            entity.Property(e => e.Heading)
                .IsUnicode(false)
                .HasColumnName("heading");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Title)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.VideoPath)
                .IsUnicode(false)
                .HasColumnName("video_path");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.CourseVideos)
                .HasForeignKey(d => d.Id)
                .HasConstraintName("FK__course_video__id__6FE99F9F");
        });

        modelBuilder.Entity<Crousel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Crousel__3213E83F0F607055");

            entity.ToTable("Crousel");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Head1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("head1");
            entity.Property(e => e.Head2)
                .IsUnicode(false)
                .HasColumnName("head2");
            entity.Property(e => e.Image)
                .IsUnicode(false)
                .HasColumnName("image");
        });

        modelBuilder.Entity<ExploreSubject>(entity =>
        {
            entity.HasKey(e => e.EsId).HasName("PK__explore___3022FE0125F4DA16");

            entity.ToTable("explore_subject");

            entity.Property(e => e.EsId).HasColumnName("es_id");
            entity.Property(e => e.CImg)
                .IsUnicode(false)
                .HasColumnName("c_img");
            entity.Property(e => e.CName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("c_name");
        });

        modelBuilder.Entity<Register>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Register__3213E83FF9F056F3");

            entity.ToTable("Register");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Profileimg)
                .IsUnicode(false)
                .HasColumnName("profileimg");
            entity.Property(e => e.Qualification)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("qualification");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
