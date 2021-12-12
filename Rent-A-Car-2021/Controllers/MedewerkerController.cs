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
    public class MedewerkerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public MedewerkerController(ApplicationDbContext context
            , UserManager<IdentityUser> userManager
            , RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: Medewerker
        public async Task<IActionResult> Index()
        {
            return View(await _context.Medewerkers.ToListAsync());
        }

        // GET: Medewerker/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medewerker = await _context.Medewerkers
                .FirstOrDefaultAsync(m => m.Medewerkerscode == id);
            if (medewerker == null)
            {
                return NotFound();
            }

            return View(medewerker);
        }

        // GET: Medewerker/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medewerker/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Email,Wachtwoord,Wachtwoord2,Medewerkerscode,Voornaam,Tussenvoegsels,Achternaam")] RegisterEmployee model)
        {
            if (ModelState.IsValid)
            {
                await _userManager.CreateAsync(new IdentityUser(model.Email), model.Wachtwoord);
                var user = _context.Users.FirstOrDefault(u => u.UserName == model.Email);
                user.Email = user.UserName;
                user.NormalizedEmail = user.NormalizedUserName;
                await _userManager.AddToRoleAsync(user, "Customer");
                var newEmployee = new Medewerker()
                {
                    Achternaam = model.Achternaam,
                    Medewerkerscode = model.Medewerkerscode,
                    Voornaam = model.Voornaam,
                    Tussenvoegsels = model.Tussenvoegsels,
                    AspNetUserNavigation = user
                };
                _context.Add(newEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Medewerker/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medewerker = await _context.Medewerkers.FindAsync(id);
            if (medewerker == null)
            {
                return NotFound();
            }
            return View(medewerker);
        }

        // POST: Medewerker/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Medewerkerscode,Voornaam,Tussenvoegsels,Achternaam")] Medewerker medewerker)
        {
            if (id != medewerker.Medewerkerscode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medewerker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedewerkerExists(medewerker.Medewerkerscode))
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
            return View(medewerker);
        }

        // GET: Medewerker/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medewerker = await _context.Medewerkers
                .FirstOrDefaultAsync(m => m.Medewerkerscode == id);
            if (medewerker == null)
            {
                return NotFound();
            }

            return View(medewerker);
        }

        // POST: Medewerker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var medewerker = await _context.Medewerkers.FindAsync(id);
            _context.Medewerkers.Remove(medewerker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedewerkerExists(string id)
        {
            return _context.Medewerkers.Any(e => e.Medewerkerscode == id);
        }
    }
}
