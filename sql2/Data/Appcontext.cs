using System;
using Microsoft.EntityFrameworkCore;
using sql2.Models;

namespace sql2.Data
{
    public class AppDbcontext : DbContext
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options) : base(options)
        {
        }

        public DbSet<items> items { get; set; }
        public DbSet<Category> categories {get;set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
            new Category() {Id = 1 , Name="computer"},
            new Category() {Id = 2 , Name="Mobile"},
            new Category() {Id = 3 , Name="Iphone"},
            new Category() {Id = 4 , Name="Laptop"}
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}

