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
    public class StarMastersController : Controller
    {
        private readonly ilamaiMatrimonyContext _context;

        public StarMastersController(ilamaiMatrimonyContext context)
        {
            _context = context;
        }

        // GET: StarMasters
        public async Task<IActionResult> Index()
        {
            return View(await _context.StarMasters.ToListAsync());
        }

        // GET: StarMasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var starMaster = await _context.StarMasters
                .FirstOrDefaultAsync(m => m.StarMasterId == id);
            if (starMaster == null)
            {
                return NotFound();
            }

            return View(starMaster);
        }

        // GET: StarMasters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StarMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StarMasterId,StarName")] StarMaster starMaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(starMaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(starMaster);
        }

        // GET: StarMasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var starMaster = await _context.StarMasters.FindAsync(id);
            if (starMaster == null)
            {
                return NotFound();
            }
            return View(starMaster);
        }

        // POST: StarMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StarMasterId,StarName")] StarMaster starMaster)
        {
            if (id != starMaster.StarMasterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(starMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StarMasterExists(starMaster.StarMasterId))
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
            return View(starMaster);
        }

        // GET: StarMasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var starMaster = await _context.StarMasters
                .FirstOrDefaultAsync(m => m.StarMasterId == id);
            if (starMaster == null)
            {
                return NotFound();
            }

            return View(starMaster);
        }

        // POST: StarMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var starMaster = await _context.StarMasters.FindAsync(id);
            _context.StarMasters.Remove(starMaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StarMasterExists(int id)
        {
            return _context.StarMasters.Any(e => e.StarMasterId == id);
        }
    }
}
