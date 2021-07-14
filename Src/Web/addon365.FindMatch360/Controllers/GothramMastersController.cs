using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using addon365.FindMatch360.Data;
using addon365.FindMatch360.Models.Masters;

namespace addon365.FindMatch360.Controllers
{
    public class GothramMastersController : Controller
    {
        private readonly ilamaiMatrimonyContext _context;

        public GothramMastersController(ilamaiMatrimonyContext context)
        {
            _context = context;
        }

        // GET: GothramMasters
        public async Task<IActionResult> Index()
        {
            return View(await _context.GothramMasters.ToListAsync());
        }

        // GET: GothramMasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gothramMaster = await _context.GothramMasters
                .FirstOrDefaultAsync(m => m.GothramMasterId == id);
            if (gothramMaster == null)
            {
                return NotFound();
            }

            return View(gothramMaster);
        }

        // GET: GothramMasters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GothramMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GothramMasterId,GothramName")] GothramMaster gothramMaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gothramMaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gothramMaster);
        }

        // GET: GothramMasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gothramMaster = await _context.GothramMasters.FindAsync(id);
            if (gothramMaster == null)
            {
                return NotFound();
            }
            return View(gothramMaster);
        }

        // POST: GothramMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GothramMasterId,GothramName")] GothramMaster gothramMaster)
        {
            if (id != gothramMaster.GothramMasterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gothramMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GothramMasterExists(gothramMaster.GothramMasterId))
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
            return View(gothramMaster);
        }

        // GET: GothramMasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gothramMaster = await _context.GothramMasters
                .FirstOrDefaultAsync(m => m.GothramMasterId == id);
            if (gothramMaster == null)
            {
                return NotFound();
            }

            return View(gothramMaster);
        }

        // POST: GothramMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gothramMaster = await _context.GothramMasters.FindAsync(id);
            _context.GothramMasters.Remove(gothramMaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GothramMasterExists(int id)
        {
            return _context.GothramMasters.Any(e => e.GothramMasterId == id);
        }
    }
}
