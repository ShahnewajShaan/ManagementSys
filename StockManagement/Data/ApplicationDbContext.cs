﻿using Microsoft.EntityFrameworkCore;
using StockManagement.Models;

namespace StockManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Catagory> Catagories { get; set; }
    }

}