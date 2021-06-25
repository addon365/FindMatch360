using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using addon365.FindMatch360.Data;
using addon365.FindMatch360.Models.Masters;
using addon365.FindMatch360.ViewModels;

namespace addon365.FindMatch360.Controllers
{
    public class SubCasteMastersController : Controller
    {
        private readonly ilamaiMatrimonyContext _context;

        public SubCasteMastersController(ilamaiMatrimonyContext context)
        {
            _context = context;
        }

        // GET: SubCasteMasters
        public async Task<IActionResult> Index()
        {
            var ilamaiMatrimonyContext = _context.SubCasteMasters.Include(s => s.ParentCaste);
            return View(await ilamaiMatrimonyContext.ToListAsync());
        }

        // GET: SubCasteMasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCasteMaster = await _context.SubCasteMasters
                .Include(s => s.ParentCaste)
                .FirstOrDefaultAsync(m => m.SubCasteMasterId == id);
            if (subCasteMaster == null)
            {
                return NotFound();
            }

            return View(subCasteMaster);
        }

        // GET: SubCasteMasters/Create
        public IActionResult Create()
        {
            SubCasteViewModel subCasteViewModel = new SubCasteViewModel();
            subCasteViewModel.Castes = _context.CasteMasters.ToList();
            //ViewData["Castes"] = new SelectList(_context.CasteMasters, "CasteMasterId", "CasteMasterId");
            return View(subCasteViewModel);
        }

        // POST: SubCasteMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubCasteName,ParentCasteId")] SubCasteViewModel subCasteMaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(new SubCasteMaster(){SubCasteName=subCasteMaster.SubCasteName,CasteMasterId=Convert.ToInt32(subCasteMaster.ParentCasteId)});
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["CasteMasterId"] = new SelectList(_context.CasteMasters, "CasteMasterId", "CasteMasterId", subCasteMaster.ParentCasteId);
            return View(subCasteMaster);
        }

        // GET: SubCasteMasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCasteMaster = await _context.SubCasteMasters.FindAsync(id);
            if (subCasteMaster == null)
            {
                return NotFound();
            }
            ViewData["CasteMasterId"] = new SelectList(_context.CasteMasters, "CasteMasterId", "CasteMasterId", subCasteMaster.CasteMasterId);
            return View(subCasteMaster);
        }

        // POST: SubCasteMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubCasteMasterId,SubCasteName,CasteMasterId")] SubCasteMaster subCasteMaster)
        {
            if (id != subCasteMaster.SubCasteMasterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subCasteMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubCasteMasterExists(subCasteMaster.SubCasteMasterId))
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
            ViewData["CasteMasterId"] = new SelectList(_context.CasteMasters, "CasteMasterId", "CasteMasterId", subCasteMaster.CasteMasterId);
            return View(subCasteMaster);
        }

        // GET: SubCasteMasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCasteMaster = await _context.SubCasteMasters
                .Include(s => s.ParentCaste)
                .FirstOrDefaultAsync(m => m.SubCasteMasterId == id);
            if (subCasteMaster == null)
            {
                return NotFound();
            }

            return View(subCasteMaster);
        }

        // POST: SubCasteMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subCasteMaster = await _context.SubCasteMasters.FindAsync(id);
            _context.SubCasteMasters.Remove(subCasteMaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubCasteMasterExists(int id)
        {
            return _context.SubCasteMasters.Any(e => e.SubCasteMasterId == id);
        }
    }
}
