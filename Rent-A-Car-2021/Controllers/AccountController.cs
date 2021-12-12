using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Rent_A_Car_2021.Data;
using Rent_A_Car_2021.Models;
using Rent_A_Car_2021.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rent_A_Car_2021.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(ApplicationDbContext context
            , UserManager<IdentityUser> userManager
            , RoleManager<IdentityRole> roleManager
            , SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string username , string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == username);
            if(user == null)
            {
                ViewBag.Error = "Inloggen mislukt";
                return View();
            }
            var result =await _signInManager.PasswordSignInAsync(user, password,true,true);
            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = "Inloggen mislukt";
            return View();
        }

        // GET: Klant/Create
        public IActionResult Register()
        {
            var model = new RegisterCustomer();

            return View();
        }

        // POST: Klant/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Email,Wachtwoord,Wachtwoord2,Voorletters,Tussenvoegsels,Achternaam,Adres,Postcode,Woonplaats")] RegisterCustomer model)
        {
            if (ModelState.IsValid)
            {
                await _userManager.CreateAsync(new IdentityUser(model.Email), model.Wachtwoord);
                var user = _context.Users.FirstOrDefault(u => u.UserName == model.Email);
                user.Email = user.UserName;
                user.NormalizedEmail = user.NormalizedUserName;
                await _userManager.AddToRoleAsync(user, "Customer");
                var newCustomer = new Klant()
                {
                    Achternaam = model.Achternaam,
                    Adres = model.Adres,
                    Postcode = model.Postcode.ToUpper(),
                    Klantcode = model.Achternaam.Substring(0, 3).ToUpper() +
                    model.Postcode.Substring(0, 3).ToUpper(),
                    Voorletters = model.Voorletters.ToUpper(),
                    Tussenvoegsels = model.Tussenvoegsels,
                    Woonplaats = model.Woonplaats,
                    AspNetUserNavigation = user
                };
                _context.Add(newCustomer);
                await _context.SaveChangesAsync();
                await _signInManager.CheckPasswordSignInAsync(user, model.Wachtwoord, false);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}
