using Microsoft.EntityFrameworkCore;
using PR5webshopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PR5webshopAPI.Data
{
    public class HelloCoreContext: DbContext
    {
        public HelloCoreContext(DbContextOptions<HelloCoreContext> options): base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Order>().ToTable("Orders").Property(o => o.Total).HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<Product>().ToTable("Products").Property(p => p.Price).HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}
