using System;
using E_Learning_API.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_API.Data;


public class ElearningDataContext : DbContext
{

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseSerialColumns();
    }

    public ElearningDataContext(DbContextOptions<ElearningDataContext> options) :base(options)
    {}

    public DbSet<Courses> Courses { get; set; }

}

