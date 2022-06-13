using System;
using Microsoft.EntityFrameworkCore;
using WSEIDziekanat.Models;

namespace WSEIDziekanat;


public sealed class DatabaseContext : DbContext
{
    public DbSet<Announcement> Announcements { get; set; }
    public DbSet<Credentials> Credentials { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Schedule> Schedule { get; set; }
    public DbSet<Student> Students { get; set; }

    public string DbPath { get; }

    public DatabaseContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "wsei_database.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}").EnableSensitiveDataLogging(true);
}