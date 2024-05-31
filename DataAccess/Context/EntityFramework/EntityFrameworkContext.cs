using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context.EntityFramework
{
    public class EntityFrameworkContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=TestDatabase;Trusted_Connection=true;Encrypt=False;TrustServerCertificate=True");
        }

        public DbSet<Product> Product { get; set; }
    }
}
