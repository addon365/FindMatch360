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
    public class LagnamMastersController : Controller
    {
        private readonly ilamaiMatrimonyContext _context;

        public LagnamMastersController(ilamaiMatrimonyContext context)
        {
            _context = context;
        }

        // GET: LagnamMasters
        public async Task<IActionResult> Index()
        {
            return View(await _context.LagnamMasters.ToListAsync());
        }

        // GET: LagnamMasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lagnamMaster = await _context.LagnamMasters
                .FirstOrDefaultAsync(m => m.LagnamMasterId == id);
            if (lagnamMaster == null)
            {
                return NotFound();
            }

            return View(lagnamMaster);
        }

        // GET: LagnamMasters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LagnamMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LagnamMasterId,LagnamName")] LagnamMaster lagnamMaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lagnamMaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lagnamMaster);
        }

        // GET: LagnamMasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lagnamMaster = await _context.LagnamMasters.FindAsync(id);
            if (lagnamMaster == null)
            {
                return NotFound();
            }
            return View(lagnamMaster);
        }

        // POST: LagnamMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LagnamMasterId,LagnamName")] LagnamMaster lagnamMaster)
        {
            if (id != lagnamMaster.LagnamMasterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lagnamMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LagnamMasterExists(lagnamMaster.LagnamMasterId))
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
            return View(lagnamMaster);
        }

        // GET: LagnamMasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lagnamMaster = await _context.LagnamMasters
                .FirstOrDefaultAsync(m => m.LagnamMasterId == id);
            if (lagnamMaster == null)
            {
                return NotFound();
            }

            return View(lagnamMaster);
        }

        // POST: LagnamMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lagnamMaster = await _context.LagnamMasters.FindAsync(id);
            _context.LagnamMasters.Remove(lagnamMaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LagnamMasterExists(int id)
        {
            return _context.LagnamMasters.Any(e => e.LagnamMasterId == id);
        }
    }
}
