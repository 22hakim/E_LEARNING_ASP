using System;
using E_Learning_API.Models;
using E_Learning_API.Models.Enum;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace E_Learning_API.Data;


public class ElearningDataContext : IdentityDbContext
{
    public DbSet<Course> Courses { get; set; }

    public DbSet<Assignement> Assignements { get; set; }

    public DbSet<CourseReview> CourseReviews { get; set; }

    public DbSet<CourseUpdate> CourseUpdates { get; set; }

    //public DbSet<Message> Messages { get; set; }

    public DbSet<Tag> Tags { get; set; }

    public DbSet<CourseTag> CourseTags { get; set; }

    public ElearningDataContext(DbContextOptions<ElearningDataContext> options) : base(options)
    {
        NpgsqlConnection.GlobalTypeMapper.MapEnum<Published>();
        NpgsqlConnection.GlobalTypeMapper.MapEnum<CategoryMessage>();
        NpgsqlConnection.GlobalTypeMapper.MapEnum<LevelCourse>();
        NpgsqlConnection.GlobalTypeMapper.MapEnum<RateCourse>();
        NpgsqlConnection.GlobalTypeMapper.MapEnum<StateCourse>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.UseSerialColumns();
        modelBuilder.HasPostgresEnum<Published>();
        modelBuilder.HasPostgresEnum<CategoryMessage>();
        modelBuilder.HasPostgresEnum<LevelCourse>();
        modelBuilder.HasPostgresEnum<RateCourse>();
        modelBuilder.HasPostgresEnum<StateCourse>();
        modelBuilder.Entity<CourseTag>().HasKey(sc => new { sc.CourseId, sc.TagId });
    }

}

