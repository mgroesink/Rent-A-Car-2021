using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Rent_A_Car_2021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rent_A_Car_2021.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext db,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;

        }

        public void Initialize()
        {

            if (_db.Roles.Count() == 0)
            {
                _roleManager.CreateAsync(new IdentityRole("Customer")).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole("Employee")).GetAwaiter().GetResult();

                _userManager.CreateAsync(new IdentityUser
                {
                    UserName = "zwartj@rentacar.nl",
                    Email = "zwartj@rentacar.nl",
                    EmailConfirmed = true,
                }, "Rent-A-Car!2021").GetAwaiter().GetResult();
                _userManager.CreateAsync(new IdentityUser
                {
                    UserName = "witp@rentacar.nl",
                    Email = "witp@rentacar.nl",
                    EmailConfirmed = true,
                }, "Rent-A-Car!2021").GetAwaiter().GetResult();
                _userManager.CreateAsync(new IdentityUser
                {
                    UserName = "revek@gmail.com",
                    Email = "revek@gmail.com",
                    EmailConfirmed = true,
                }, "Rent-A-Car!2021").GetAwaiter().GetResult();
                _userManager.CreateAsync(new IdentityUser
                {
                    UserName = "wolkj@hotmail.com",
                    Email = "wolkj@hotmail.com",
                    EmailConfirmed = true,
                }, "Rent-A-Car!2021").GetAwaiter().GetResult();
                _userManager.CreateAsync(new IdentityUser
                {
                    UserName = "hermw@kpnmail.nl",
                    Email = "hermw@kpnmail.nl",
                    EmailConfirmed = true,
                }, "Rent-A-Car!2021").GetAwaiter().GetResult();
                _userManager.CreateAsync(new IdentityUser
                {
                    UserName = "mulih@yahoo.com",
                    Email = "mulih@yahoo.com",
                    EmailConfirmed = true,
                }, "Rent-A-Car!2021").GetAwaiter().GetResult();
                _db.Medewerkers.Add(new Medewerker()
                {
                    Medewerkerscode = "ZWA01",
                    Achternaam = "Zwart",
                    Voornaam = "Jan",
                    AspNetUserNavigation = _db.Users.FirstOrDefaultAsync(c => c.UserName == "zwartj@rentacar.nl").GetAwaiter().GetResult()
                });
                _db.Medewerkers.Add(new Medewerker()
                {
                    Medewerkerscode = "WIT01",
                    Achternaam = "Wit",
                    Tussenvoegsels = "de",
                    Voornaam = "Peter",
                    AspNetUserNavigation = _db.Users.FirstOrDefaultAsync(c => c.UserName == "witp@rentacar.nl").GetAwaiter().GetResult()
                });
                _db.Klanten.Add(new Klant()
                {
                    Achternaam = "Wolkers",
                    Voorletters = "J.",
                    Adres = "Tesselsestraat 2",
                    Postcode = "1790WW",
                    Woonplaats = "Den Burg",
                    Klantcode = "WOL179",
                    AspNetUserNavigation = _db.Users.FirstOrDefaultAsync(c => c.UserName == "wolkj@hotmail.com").GetAwaiter().GetResult()
                });
                _db.Klanten.Add(new Klant()
                {
                    Achternaam = "Reve",
                    Tussenvoegsels = "van het",
                    Voorletters = "G.K.",
                    Adres = "Dorpsweg 34/36",
                    Postcode = "8658RR",
                    Woonplaats = "Greonterp",
                    Klantcode = "REV865",
                    AspNetUserNavigation = _db.Users.FirstOrDefaultAsync(c => c.UserName == "revek@gmail.com").GetAwaiter().GetResult()
                });
                _db.Klanten.Add(new Klant()
                {
                    Achternaam = "Hermans",
                    Voorletters = "W.F.",
                    Adres = "Bosweg 18",
                    Postcode = "3461JK",
                    Woonplaats = "Rotterdam",
                    Klantcode = "HER346",
                    AspNetUserNavigation = _db.Users.FirstOrDefaultAsync(c => c.UserName == "hermw@kpnmail.nl").GetAwaiter().GetResult()
                });
                _db.Klanten.Add(new Klant()
                {
                    Achternaam = "Mulisch",
                    Voorletters = "H.",
                    Adres = "Leidsekade 103",
                    Postcode = "1017PP",
                    Woonplaats = "Amsterdam",
                    Klantcode = "MUL101",
                    AspNetUserNavigation = _db.Users.FirstOrDefaultAsync(c => c.UserName == "mulih@yahoo.com").GetAwaiter().GetResult()
                });

                _db.SaveChanges();
                _userManager.AddToRoleAsync(
                    _db.Users.FirstOrDefaultAsync(c => c.UserName == "zwartj@rentacar.nl").GetAwaiter().GetResult(), "Employee"
                    );
                _userManager.AddToRoleAsync(
                    _db.Users.FirstOrDefaultAsync(c => c.UserName == "witp@rentacar.nl").GetAwaiter().GetResult(), "Employee"
                    );
                _userManager.AddToRoleAsync(
                    _db.Users.FirstOrDefaultAsync(c => c.UserName == "revek@gmail.com").GetAwaiter().GetResult(), "Customer"
                    );
                _userManager.AddToRoleAsync(
                    _db.Users.FirstOrDefaultAsync(c => c.UserName == "wolkj@hotmail.com").GetAwaiter().GetResult(), "Customer"
                    );
                _userManager.AddToRoleAsync(
                    _db.Users.FirstOrDefaultAsync(c => c.UserName == "hermw@kpnmail.nl").GetAwaiter().GetResult(), "Customer"
                    );
                _userManager.AddToRoleAsync(
                    _db.Users.FirstOrDefaultAsync(c => c.UserName == "mulih@yahoo.com").GetAwaiter().GetResult(), "Customer"
                    );

            }
        }
    }
}
