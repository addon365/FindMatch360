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
    public class RasiMastersController : Controller
    {
        private readonly ilamaiMatrimonyContext _context;

        public RasiMastersController(ilamaiMatrimonyContext context)
        {
            _context = context;
        }

        // GET: RasiMasters
        public async Task<IActionResult> Index()
        {
            return View(await _context.RasiMasters.ToListAsync());
        }

        // GET: RasiMasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rasiMaster = await _context.RasiMasters
                .FirstOrDefaultAsync(m => m.RasiMasterId == id);
            if (rasiMaster == null)
            {
                return NotFound();
            }

            return View(rasiMaster);
        }

        // GET: RasiMasters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RasiMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RasiMasterId,RasiName")] RasiMaster rasiMaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rasiMaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rasiMaster);
        }

        // GET: RasiMasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rasiMaster = await _context.RasiMasters.FindAsync(id);
            if (rasiMaster == null)
            {
                return NotFound();
            }
            return View(rasiMaster);
        }

        // POST: RasiMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RasiMasterId,RasiName")] RasiMaster rasiMaster)
        {
            if (id != rasiMaster.RasiMasterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rasiMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RasiMasterExists(rasiMaster.RasiMasterId))
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
            return View(rasiMaster);
        }

        // GET: RasiMasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rasiMaster = await _context.RasiMasters
                .FirstOrDefaultAsync(m => m.RasiMasterId == id);
            if (rasiMaster == null)
            {
                return NotFound();
            }

            return View(rasiMaster);
        }

        // POST: RasiMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rasiMaster = await _context.RasiMasters.FindAsync(id);
            _context.RasiMasters.Remove(rasiMaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RasiMasterExists(int id)
        {
            return _context.RasiMasters.Any(e => e.RasiMasterId == id);
        }
    }
}
