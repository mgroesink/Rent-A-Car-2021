using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rent_A_Car_2021.Data;
using Rent_A_Car_2021.Models;
using Rent_A_Car_2021.Models.ViewModels;

namespace Rent_A_Car_2021.Controllers
{
    public class KlantController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public KlantController(ApplicationDbContext context 
            , UserManager<IdentityUser> userManager
            , RoleManager<IdentityRole> roleManager
            , SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: Klant
        public async Task<IActionResult> Index()
        {
            return View(await _context.Klanten.ToListAsync());
        }

        // GET: Klant/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klant = await _context.Klanten
                .FirstOrDefaultAsync(m => m.Klantcode == id);
            if (klant == null)
            {
                return NotFound();
            }

            return View(klant);
        }

        // GET: Klant/Create
        public IActionResult Create()
        {
            var model = new RegisterCustomer();

            return View();
        }

        // POST: Klant/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Email,Wachtwoord,Wachtwoord2,Voorletters,Tussenvoegsels,Achternaam,Adres,Postcode,Woonplaats")] RegisterCustomer model)
        {
            if (ModelState.IsValid)
            {
                await _userManager.CreateAsync(new IdentityUser(model.Email), model.Wachtwoord);
                var user = _context.Users.FirstOrDefault(u => u.UserName == model.Email);
                user.Email = user.UserName;
                user.NormalizedEmail = user.NormalizedUserName;
                await _userManager.AddToRoleAsync(user , "Customer");
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
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Klant/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klant = await _context.Klanten.FindAsync(id);
            if (klant == null)
            {
                return NotFound();
            }
            return View(klant);
        }

        // POST: Klant/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Klantcode,Voorletters,Tussenvoegsels,Achternaam,Adres,Postcode,Woonplaats")] Klant klant)
        {
            if (id != klant.Klantcode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(klant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlantExists(klant.Klantcode))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(klant);
        }

        // GET: Klant/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klant = await _context.Klanten
                .FirstOrDefaultAsync(m => m.Klantcode == id);
            if (klant == null)
            {
                return NotFound();
            }

            return View(klant);
        }

        // POST: Klant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var klant = await _context.Klanten.FindAsync(id);
            _context.Klanten.Remove(klant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KlantExists(string id)
        {
            return _context.Klanten.Any(e => e.Klantcode == id);
        }
    }
}
