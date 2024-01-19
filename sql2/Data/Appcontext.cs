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
    }
}

