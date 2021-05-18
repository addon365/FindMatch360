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
    public class CasteMastersController : Controller
    {
        private readonly ilamaiMatrimonyContext _context;

        public CasteMastersController(ilamaiMatrimonyContext context)
        {
            _context = context;
        }

        // GET: CasteMasters
        public async Task<IActionResult> Index()
        {
            return View(await _context.CasteMasters.ToListAsync());
        }

        // GET: CasteMasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casteMaster = await _context.CasteMasters
                .FirstOrDefaultAsync(m => m.CasteMasterId == id);
            if (casteMaster == null)
            {
                return NotFound();
            }

            return View(casteMaster);
        }

        // GET: CasteMasters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CasteMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CasteMasterId,CasteName")] CasteMaster casteMaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(casteMaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(casteMaster);
        }

        // GET: CasteMasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casteMaster = await _context.CasteMasters.FindAsync(id);
            if (casteMaster == null)
            {
                return NotFound();
            }
            return View(casteMaster);
        }

        // POST: CasteMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CasteMasterId,CasteName")] CasteMaster casteMaster)
        {
            if (id != casteMaster.CasteMasterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(casteMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CasteMasterExists(casteMaster.CasteMasterId))
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
            return View(casteMaster);
        }

        // GET: CasteMasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casteMaster = await _context.CasteMasters
                .FirstOrDefaultAsync(m => m.CasteMasterId == id);
            if (casteMaster == null)
            {
                return NotFound();
            }

            return View(casteMaster);
        }

        // POST: CasteMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var casteMaster = await _context.CasteMasters.FindAsync(id);
            _context.CasteMasters.Remove(casteMaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CasteMasterExists(int id)
        {
            return _context.CasteMasters.Any(e => e.CasteMasterId == id);
        }
    }
}
