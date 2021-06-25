using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using addon365.FindMatch360.Data;
using addon365.FindMatch360.Models;
using addon365.FindMatch360.ViewModels;

namespace addon365.FindMatch360.Controllers
{
    public class ProfileRenewalController : Controller
    {
        private readonly ilamaiMatrimonyContext _context;

        public ProfileRenewalController(ilamaiMatrimonyContext context)
        {
            _context = context;
        }

        // GET: ProfileRenewal
        public async Task<IActionResult> Index()
        {
            var ilamaiMatrimonyContext = _context.ProfileRenewals.Include(p => p.Profile);
            return View(await ilamaiMatrimonyContext.ToListAsync());
        }

        // GET: ProfileRenewal/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profileRenewal = await _context.ProfileRenewals
                .Include(p => p.Profile)
                .FirstOrDefaultAsync(m => m.ProfileRenewalMasterId == id);
            if (profileRenewal == null)
            {
                return NotFound();
            }

            return View(profileRenewal);
        }

        // GET: ProfileRenewal/Create
        public IActionResult Create()
        {
            ViewData["Profiles"] = new SelectList(_context.Profiles, "ProfileMasterId", "Name");
            var renewals = _context.ProfileRenewals;
            ProfileRenewalCreateViewModel model = new ProfileRenewalCreateViewModel();

            if (renewals.Count() == 0)
            {
                model.ProfileRenewalSpecialId = 1;
                model.StartDate = System.DateTime.Now;
            }
            else
            {
                model.ProfileRenewalSpecialId = renewals.Max(a => a.ProfileRenewalSpecialId) + 1;
                model.StartDate = System.DateTime.Now;
            }

            return View(model);
        }

        // POST: ProfileRenewal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfileRenewalSpecialId,CreatedDate,RenewalDate,ProfileId,Amount,StartDate,EndDate")] ProfileRenewalCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                ProfileRenewal profileRenewal = new ProfileRenewal();
                profileRenewal.ProfileRenewalMasterId = Guid.NewGuid();
                profileRenewal.ProfileRenewalSpecialId = model.ProfileRenewalSpecialId;
                profileRenewal.ProfileId = model.ProfileId;
                profileRenewal.Amount = model.Amount;
                profileRenewal.StartDate = model.StartDate;
                profileRenewal.EndDate = model.EndDate;
                _context.Add(profileRenewal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Profiles"] = new SelectList(_context.Profiles, "ProfileMasterId", "Name", model.ProfileId);
            return View(model);
        }

        // GET: ProfileRenewal/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profileRenewal = await _context.ProfileRenewals.FindAsync(id);
            if (profileRenewal == null)
            {
                return NotFound();
            }
            ViewData["ProfileId"] = new SelectList(_context.Profiles, "ProfileMasterId", "ProfileMasterId", profileRenewal.ProfileId);
            return View(profileRenewal);
        }

        // POST: ProfileRenewal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ProfileRenewalMasterId,ProfileRenewalSpecialId,CreatedDate,RenewalDate,ProfileId,Amount,StartDate,EndDate")] ProfileRenewal profileRenewal)
        {
            if (id != profileRenewal.ProfileRenewalMasterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profileRenewal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfileRenewalExists(profileRenewal.ProfileRenewalMasterId))
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
            ViewData["ProfileId"] = new SelectList(_context.Profiles, "ProfileMasterId", "ProfileMasterId", profileRenewal.ProfileId);
            return View(profileRenewal);
        }

        // GET: ProfileRenewal/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profileRenewal = await _context.ProfileRenewals
                .Include(p => p.Profile)
                .FirstOrDefaultAsync(m => m.ProfileRenewalMasterId == id);
            if (profileRenewal == null)
            {
                return NotFound();
            }

            return View(profileRenewal);
        }

        // POST: ProfileRenewal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var profileRenewal = await _context.ProfileRenewals.FindAsync(id);
            _context.ProfileRenewals.Remove(profileRenewal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfileRenewalExists(Guid id)
        {
            return _context.ProfileRenewals.Any(e => e.ProfileRenewalMasterId == id);
        }
    }
}
