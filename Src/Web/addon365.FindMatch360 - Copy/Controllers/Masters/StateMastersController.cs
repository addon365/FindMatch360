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
    public class StateMastersController : Controller
    {
        private readonly ilamaiMatrimonyContext _context;

        public StateMastersController(ilamaiMatrimonyContext context)
        {
            _context = context;
        }

        // GET: StateMasters
        public async Task<IActionResult> Index()
        {
            var ilamaiMatrimonyContext = _context.StateMasters.Include(s => s.Country);
            return View(await ilamaiMatrimonyContext.ToListAsync());
        }

        // GET: StateMasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stateMaster = await _context.StateMasters
                .Include(s => s.Country)
                .FirstOrDefaultAsync(m => m.StateMasterId == id);
            if (stateMaster == null)
            {
                return NotFound();
            }

            return View(stateMaster);
        }

        // GET: StateMasters/Create
        public IActionResult Create()
        {
            ViewData["CountryMasters"] = new SelectList(_context.CountryMasters, "CountryMasterId", "CountryName");
            return View();
        }

        // POST: StateMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StateMasterId,StateName,CountryMasterId")] StateMaster stateMaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stateMaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryMasters"] = new SelectList(_context.CountryMasters, "CountryMasterId", "CountryName", stateMaster.CountryMasterId);
            return View(stateMaster);
        }

        // GET: StateMasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stateMaster = await _context.StateMasters.FindAsync(id);
            if (stateMaster == null)
            {
                return NotFound();
            }
            ViewData["CountryMasters"] = new SelectList(_context.CountryMasters, "CountryMasterId", "CountryName", stateMaster.CountryMasterId);
            return View(stateMaster);
        }

        // POST: StateMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StateMasterId,StateName,CountryMasterId")] StateMaster stateMaster)
        {
            if (id != stateMaster.StateMasterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stateMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StateMasterExists(stateMaster.StateMasterId))
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
            ViewData["CountryMasterId"] = new SelectList(_context.CountryMasters, "CountryMasterId", "CountryMasterId", stateMaster.CountryMasterId);
            return View(stateMaster);
        }

        // GET: StateMasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stateMaster = await _context.StateMasters
                .Include(s => s.Country)
                .FirstOrDefaultAsync(m => m.StateMasterId == id);
            if (stateMaster == null)
            {
                return NotFound();
            }

            return View(stateMaster);
        }

        // POST: StateMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stateMaster = await _context.StateMasters.FindAsync(id);
            _context.StateMasters.Remove(stateMaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StateMasterExists(int id)
        {
            return _context.StateMasters.Any(e => e.StateMasterId == id);
        }
    }
}
