using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rent_A_Car_2021.Data;
using Rent_A_Car_2021.Models;
using Rent_A_Car_2021.Models.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Rent_A_Car_2021.Controllers
{
    public class ReserveerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReserveerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reserveer
        public async Task<IActionResult> Index()
        {
            return View(await _context.Factuurregels.ToListAsync());
        }

        // GET: Reserveer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factuurregel = await _context.Factuurregels
                .FirstOrDefaultAsync(m => m.Factuurnummer == id);
            if (factuurregel == null)
            {
                return NotFound();
            }

            return View(factuurregel);
        }

        // GET: Reserveer/Create
        public IActionResult Create()
        {
            var model = new ReserveerVM(_context);
            return View(model);
        }

        // POST: Reserveer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string Kenteken, DateTime Van , int AantalDagen)
        {
            var item = new Factuurregel();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            item.Auto = _context.Autos.FirstOrDefault(a => a.Kenteken == Kenteken);
            item.Begindatum = Van;
            item.Einddatum = Van.AddDays(AantalDagen);
            item.Dagprijs = item.Auto.Dagprijs;
            item.Kenteken = Kenteken;
            if (HttpContext.Session.GetInt32("OrderNumber") == null)
            {
                item.Factuur = new Factuur()
                {
                    Datum = DateTime.Now,
                    Klant = _context.Klanten.FirstOrDefault(k => k.AspNetUserNavigation.Id == userId)
                };
            }
            else
            {
                item.Factuurnummer = (int)HttpContext.Session.GetInt32("OrderNumber");
            }
                await _context.AddAsync(item);
                await _context.SaveChangesAsync();
            HttpContext.Session.SetInt32("OrderNumber", item.Factuur.Factuurnummer);

            var model = new ReserveerVM(_context);
            return View(model);
        }

        // GET: Reserveer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factuurregel = await _context.Factuurregels.FindAsync(id);
            if (factuurregel == null)
            {
                return NotFound();
            }
            return View(factuurregel);
        }

        // POST: Reserveer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Begindatum,Einddatum,Dagprijs,Factuurnummer,Kenteken")] Factuurregel factuurregel)
        {
            if (id != factuurregel.Factuurnummer)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(factuurregel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FactuurregelExists(factuurregel.Factuurnummer))
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
            return View(factuurregel);
        }

        // GET: Reserveer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factuurregel = await _context.Factuurregels
                .FirstOrDefaultAsync(m => m.Factuurnummer == id);
            if (factuurregel == null)
            {
                return NotFound();
            }

            return View(factuurregel);
        }

        // POST: Reserveer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var factuurregel = await _context.Factuurregels.FindAsync(id);
            _context.Factuurregels.Remove(factuurregel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FactuurregelExists(int id)
        {
            return _context.Factuurregels.Any(e => e.Factuurnummer == id);
        }
    }
}
