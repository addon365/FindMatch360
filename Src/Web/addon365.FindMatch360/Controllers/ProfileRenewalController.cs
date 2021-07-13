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
using addon365.FindMatch360.Helpers;

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
        public async Task<IActionResult> Index(string sortOrder,
    string currentFilter,
    string searchString,
    string fromDate,
    string toDate,
    int? pageNumber)
        {

            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["FromDate"] = fromDate;
            ViewData["ToDate"] = toDate;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var renewals = _context.ProfileRenewals.Include(p => p.Profile).Select(s => new ProfileRenewalListViewModel()
            {
                ProfileRenewalMasterId = s.ProfileRenewalMasterId,
                ProfileRenewalSpecialId = s.ProfileRenewalSpecialId,
                CreatedDate = s.CreatedDate,
                RenewalDate=s.RenewalDate,
                Name=s.Profile.Name,
                Amount=s.Amount,
                StartDate=s.StartDate,
                EndDate=s.EndDate

            }) ;

            if (fromDate != null && toDate != null)
            {
                DateTime FromD = Convert.ToDateTime(fromDate);
                DateTime ToD = Convert.ToDateTime(toDate);
                if (!String.IsNullOrEmpty(searchString))
                {
                    renewals = renewals.Where(s => s.Name.Contains(searchString) && s.RenewalDate.Date >= FromD.Date && s.RenewalDate.Date <= ToD.Date);
                }
                else
                {
                    renewals = renewals.Where(s => s.RenewalDate.Date >= FromD.Date && s.RenewalDate.Date <= ToD.Date);
                }

            }
            else if (!String.IsNullOrEmpty(searchString))
            {
                renewals = renewals.Where(s => s.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    renewals = renewals.OrderByDescending(s => s.Name);
                    break;
                //case "Date":
                //    students = students.OrderBy(s => s.EnrollmentDate);
                //    break;
                //case "date_desc":
                //    students = students.OrderByDescending(s => s.EnrollmentDate);
                //    break;
                default:
                    renewals = renewals.OrderBy(s => s.Name);
                    break;
            }
            ProfileRenewalIndexViewModel vm = new ProfileRenewalIndexViewModel();

            int pageSize = 3;
            vm.AllRenewals = await PaginatedList<ProfileRenewalListViewModel>.CreateAsync(renewals.AsNoTracking(), pageNumber ?? 1, pageSize);

        
            return View(vm);
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
             
            }
            else
            {
                model.ProfileRenewalSpecialId = renewals.Max(a => a.ProfileRenewalSpecialId) + 1;
              

            }
            model.RenewalDate = System.DateTime.Now;
            model.StartDate = System.DateTime.Now;
            model.EndDate = System.DateTime.Now;

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
