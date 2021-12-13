using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rent_A_Car_2021.Data;
using Rent_A_Car_2021.Models;

namespace Rent_A_Car_2021.Controllers
{
    public class FactuurController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FactuurController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Factuur
        public async Task<IActionResult> Index()
        {
            return View(await _context.Facturen.ToListAsync());
        }

        // GET: Factuur/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factuur = await _context.Facturen
                .FirstOrDefaultAsync(m => m.Factuurnummer == id);
            if (factuur == null)
            {
                return NotFound();
            }

            return View(factuur);
        }

        // GET: Factuur/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Factuur/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Factuurnummer,Datum")] Factuur factuur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(factuur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(factuur);
        }

        // GET: Factuur/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factuur = await _context.Facturen.FindAsync(id);
            if (factuur == null)
            {
                return NotFound();
            }
            return View(factuur);
        }

        // POST: Factuur/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Factuurnummer,Datum")] Factuur factuur)
        {
            if (id != factuur.Factuurnummer)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(factuur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FactuurExists(factuur.Factuurnummer))
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
            return View(factuur);
        }

        // GET: Factuur/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factuur = await _context.Facturen
                .FirstOrDefaultAsync(m => m.Factuurnummer == id);
            if (factuur == null)
            {
                return NotFound();
            }

            return View(factuur);
        }

        // POST: Factuur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var factuur = await _context.Facturen.FindAsync(id);
            _context.Facturen.Remove(factuur);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FactuurExists(int id)
        {
            return _context.Facturen.Any(e => e.Factuurnummer == id);
        }
    }
}
