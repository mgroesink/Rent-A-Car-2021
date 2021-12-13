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

            //modelBuilder.Entity<Auto>()
            //    .HasData(
            //        new Auto("11-ZGH-1", "BMW", "730 (diesel v12)", 85.00m),
            //        new Auto("18-YY-GG", "BMW", "323 (benzine)", 85.00m),
            //        new Auto("SB-987-B", "BMW", "525 (turbo diesel)", 100.00m),
            //        new Auto("32-ZH-XR", "Mercedes", "CLK (benzine)", 120.00m),
            //        new Auto("45-RR-76", "Rols Roys", "Silver Shadow", 185.00m),
            //        new Auto("1-LGH-99", "Porsche", "911s", 130.00m),
            //        new Auto("9-HJK-89", "BMW", "323 (benzine)", 85.00m),
            //        new Auto("8-KGB-12", "BMW", "525 (turbo diesel)", 100.00m),
            //        new Auto("98-ZKK-3", "BMW", "525 (turbo diesel)", 95.00m),
            //        new Auto("3-DLK-45", "Mercedes", "Pullman", 140.00m),
            //        new Auto("42-RT-76", "Rols Roys", "Silver Shadow", 185.00m)
            //    );
            //modelBuilder.Entity<Klant>()
            //    .HasData(
            //    new Klant()
            //    {
            //        Achternaam = "Reve",
            //        Tussenvoegsels = "van het",
            //        Voorletters = "G.K.",
            //        Adres = "Dorpsweg 34/36",
            //        Postcode = "8658RR",
            //        Woonplaats = "Greonterp",
            //        Klantcode = "REV865",
            //        AspNetUserNavigation = new IdentityUser()
            //        {
            //            UserName = "revek@gmail.com",
            //            Email = "zwartj@rentacar.nl",
            //            EmailConfirmed = true,
            //        }
            //    },
            //new Klant()
            //{
            //    Achternaam = "Wolkers",
            //    Voorletters = "J.",
            //    Adres = "Tesselsestraat 2",
            //    Postcode = "1790WW",
            //    Woonplaats = "Den Burg",
            //    Klantcode = "WOL179",
            //    AspNetUserNavigation = Users.FirstOrDefaultAsync(c => c.UserName == "wolkj@hotmail.com").GetAwaiter().GetResult()
            //},
            //new Klant()
            //{
            //    Achternaam = "Hermans",
            //    Voorletters = "W.F.",
            //    Adres = "Bosweg 18",
            //    Postcode = "3461JK",
            //    Woonplaats = "Rotterdam",
            //    Klantcode = "HER346",
            //    AspNetUserNavigation = Users.FirstOrDefaultAsync(c => c.UserName == "hermw@kpnmail.nl").GetAwaiter().GetResult()
            //},
            //new Klant()
            //{
            //    Achternaam = "Mulisch",
            //    Voorletters = "H.",
            //    Adres = "Leidsekade 103",
            //    Postcode = "1017PP",
            //    Woonplaats = "Amsterdam",
            //    Klantcode = "MUL101",
            //    AspNetUserNavigation = Users.FirstOrDefaultAsync(c => c.UserName == "mulih@yahoo.com").GetAwaiter().GetResult()
            //});

            //modelBuilder.Entity<Medewerker>()
            //    .HasData(
            //    new Medewerker()
            //    {
            //        Medewerkerscode = "ZWA01",
            //        Achternaam = "Zwart",
            //        Voornaam = "Jan",
            //        AspNetUserNavigation = Users.FirstOrDefaultAsync(c => c.UserName == "zwartj@rentacar.nl").GetAwaiter().GetResult()
            //    },
            //    new Medewerker()
            //    {
            //        Medewerkerscode = "WIT01",
            //        Achternaam = "Wit",
            //        Tussenvoegsels = "de",
            //        Voornaam = "Peter",
            //        AspNetUserNavigation = Users.FirstOrDefaultAsync(c => c.UserName == "witp@rentacar.nl").GetAwaiter().GetResult()
            //    }

            //);
        }
    }
}