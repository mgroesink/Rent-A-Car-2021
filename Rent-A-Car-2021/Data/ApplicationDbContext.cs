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
            
            modelBuilder.Entity<Factuurregel>()
                .HasKey(c => new { c.Factuurnummer, c.Kenteken });

            modelBuilder.Entity<Factuur>(b =>
            {
                b.HasKey(e => e.Factuurnummer);
                b.Property(e => e.Factuurnummer).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Auto>()
                .HasData(
                    new Auto("11-ZGH-1", "BMW", "730 (diesel v12)", 85.00m),
                    new Auto("18-YY-GG", "BMW", "323 (benzine)", 85.00m),
                    new Auto("SB-987-B", "BMW", "525 (turbo diesel)", 100.00m),
                    new Auto("32-ZH-XR", "Mercedes", "CLK (benzine)", 120.00m),
                    new Auto("45-RR-76", "Rols Roys", "Silver Shadow", 185.00m),
                    new Auto("1-LGH-99", "Porsche", "911s", 130.00m),
                    new Auto("9-HJK-89", "BMW", "323 (benzine)", 85.00m),
                    new Auto("8-KGB-12", "BMW", "525 (turbo diesel)", 100.00m),
                    new Auto("98-ZKK-3", "BMW", "525 (turbo diesel)", 95.00m),
                    new Auto("3-DLK-45", "Mercedes", "Pullman", 140.00m),
                    new Auto("42-RT-76", "Rols Roys", "Silver Shadow", 185.00m)
                );


        }
    }
}