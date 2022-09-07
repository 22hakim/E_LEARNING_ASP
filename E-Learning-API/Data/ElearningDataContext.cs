using System;
using E_Learning_API.Models;
using E_Learning_API.Models.Enum;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace E_Learning_API.Data;


public class ElearningDataContext : DbContext
{

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseSerialColumns();
        modelBuilder.HasPostgresEnum<Published>();
    }


    public ElearningDataContext(DbContextOptions<ElearningDataContext> options) :base(options)
    {
        NpgsqlConnection.GlobalTypeMapper.MapEnum<Published>();
    }

    public DbSet<Courses> Courses { get; set; }

}

