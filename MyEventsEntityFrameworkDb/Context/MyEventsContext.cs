using Microsoft.EntityFrameworkCore;
using MyEventsEntityFrameworkDb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEventsEntityFrameworkDb.Context
{
    internal class MyEventsContext : DbContext
    {
        public DbSet<Categories> Categories { get; set; }
        public DbSet<CategoriesEvents> CategoriesEvents { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<Galleries> Galleries { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Users> Users { get; set; }
        public MyEventsContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyEventsDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
