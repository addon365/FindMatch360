using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using addon365.FindMatch360.Data;
using addon365.FindMatch360.Models.Masters;

namespace addon365.FindMatch360.Controllers.Masters
{
    public class CountryMastersController : Controller
    {
        private readonly ilamaiMatrimonyContext _context;

        public CountryMastersController(ilamaiMatrimonyContext context)
        {
            _context = context;
        }

        // GET: CountryMasters
        public async Task<IActionResult> Index()
        {
            return View(await _context.CountryMasters.ToListAsync());
        }

        // GET: CountryMasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var countryMaster = await _context.CountryMasters
                .FirstOrDefaultAsync(m => m.CountryMasterId == id);
            if (countryMaster == null)
            {
                return NotFound();
            }

            return View(countryMaster);
        }

        // GET: CountryMasters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CountryMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CountryMasterId,CountryName")] CountryMaster countryMaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(countryMaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(countryMaster);
        }

        // GET: CountryMasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var countryMaster = await _context.CountryMasters.FindAsync(id);
            if (countryMaster == null)
            {
                return NotFound();
            }
            return View(countryMaster);
        }

        // POST: CountryMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CountryMasterId,CountryName")] CountryMaster countryMaster)
        {
            if (id != countryMaster.CountryMasterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(countryMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountryMasterExists(countryMaster.CountryMasterId))
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
            return View(countryMaster);
        }

        // GET: CountryMasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var countryMaster = await _context.CountryMasters
                .FirstOrDefaultAsync(m => m.CountryMasterId == id);
            if (countryMaster == null)
            {
                return NotFound();
            }

            return View(countryMaster);
        }

        // POST: CountryMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var countryMaster = await _context.CountryMasters.FindAsync(id);
            _context.CountryMasters.Remove(countryMaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CountryMasterExists(int id)
        {
            return _context.CountryMasters.Any(e => e.CountryMasterId == id);
        }
    }
}
