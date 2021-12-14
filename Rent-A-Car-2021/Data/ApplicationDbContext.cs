using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rent_A_Car_2021.Models;

namespace Rent_A_Car_2021.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Auto> Autos { get; set; }
        public DbSet<Klant> Klanten { get; set; }
        public DbSet<Medewerker> Medewerkers { get; set; }
        public DbSet<Factuur> Facturen { get; set; }
        public DbSet<Factuurregel> Factuurregels { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Factuurregel>(c =>
            {
                c.HasKey(c => c.FactuurID);
                c.Property(c => c.FactuurID).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Factuur>(b =>
            {
                b.HasKey(e => e.Factuurnummer);
                b.Property(e => e.Factuurnummer).ValueGeneratedOnAdd();
            });

        }
    }
}