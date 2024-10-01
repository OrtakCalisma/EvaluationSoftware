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
    public class EFContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=TestDatabase;Trusted_Connection=true;Encrypt=False;TrustServerCertificate=True");

            /*"Server=localhost;Database=TestDatabase;Trusted_Connection=true;Encrypt=False;TrustServerCertificate=True"*/
            // Server=localhost,1434;Database=TestDatabase;User=sa;Password=Password1;TrustServerCertificate=True
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Test> Test { get; set; }
        public DbSet<ATE> Ate { get; set; }
        public DbSet<ITA> Ita { get; set; }
        public DbSet<Faults> Faults { get; set; }
        public DbSet<Logging> Logging { get; set; }
        public DbSet<Solvings> Solving { get; set; }
    }
}
