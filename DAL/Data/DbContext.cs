﻿using CallForPappersService_DAL.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CallForPappersService_DAL.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Application> Applications { get; set; }
        public DbSet<Activity> Activities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>().HasIndex(a => a.AuthorId);
            modelBuilder.Entity<Application>().HasIndex(a => a.Status);

            modelBuilder.Entity<Application>()
                .Property(x => x.Name).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Application>()
                .Property(x => x.Description).HasMaxLength(300);
            modelBuilder.Entity<Application>()
                .Property(x => x.Outline).HasMaxLength(1000).IsRequired();
            modelBuilder.Entity<Application>()
                .Property(x => x.AuthorId).IsRequired();
            modelBuilder.Entity<Application>()
                .Property(x => x.ActivityId).IsRequired();
        }
    }
}
