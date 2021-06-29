using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using addon365.FindMatch360.Data;
using addon365.FindMatch360.Models.Masters;
using addon365.FindMatch360.Helpers;

namespace addon365.FindMatch360.Controllers.Masters
{
    public class CityMastersController : Controller
    {
        private readonly ilamaiMatrimonyContext _context;

        public CityMastersController(ilamaiMatrimonyContext context)
        {
            _context = context;
        }

        // GET: CityMasters
        //public async Task<IActionResult> Index()
        //{

        //    var ilamaiMatrimonyContext = _context.CityMasters.Include(c => c.State);
        //    return View(await ilamaiMatrimonyContext.ToListAsync());
        //}
        public async Task<IActionResult> Index(
    string sortOrder,
    string currentFilter,
    string searchString,
    int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var cities = _context.CityMasters.Include(c => c.State).Select(s=>s);
                           
            if (!String.IsNullOrEmpty(searchString))
            {
                cities = cities.Where(s => s.CityName.Contains(searchString)
                                       || s.State.StateName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    cities = cities.OrderByDescending(s => s.CityName);
                    break;
                //case "Date":
                //    students = students.OrderBy(s => s.EnrollmentDate);
                //    break;
                //case "date_desc":
                //    students = students.OrderByDescending(s => s.EnrollmentDate);
                //    break;
                default:
                    cities = cities.OrderBy(s => s.CityName);
                    break;
            }

            int pageSize = 4;
            return View(await PaginatedList<CityMaster>.CreateAsync(cities.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
        // GET: CityMasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cityMaster = await _context.CityMasters
                .Include(c => c.State)
                .FirstOrDefaultAsync(m => m.CityMasterId == id);
            if (cityMaster == null)
            {
                return NotFound();
            }

            return View(cityMaster);
        }

        // GET: CityMasters/Create
        public IActionResult Create()
        {
            ViewData["StateMasterId"] = new SelectList(_context.StateMasters, "StateMasterId", "StateName");
            return View();
        }

        // POST: CityMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CityMasterId,CityName,StateMasterId")] CityMaster cityMaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cityMaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StateMasterId"] = new SelectList(_context.StateMasters, "StateMasterId", "StateName", cityMaster.StateMasterId);
            return View(cityMaster);
        }

        // GET: CityMasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cityMaster = await _context.CityMasters.FindAsync(id);
            if (cityMaster == null)
            {
                return NotFound();
            }
            ViewData["StateMasterId"] = new SelectList(_context.StateMasters, "StateMasterId", "StateName", cityMaster.StateMasterId);
            return View(cityMaster);
        }

        // POST: CityMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CityMasterId,CityName,StateMasterId")] CityMaster cityMaster)
        {
            if (id != cityMaster.CityMasterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cityMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CityMasterExists(cityMaster.CityMasterId))
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
            ViewData["StateMasterId"] = new SelectList(_context.StateMasters, "StateMasterId", "StateName", cityMaster.StateMasterId);
            return View(cityMaster);
        }

        // GET: CityMasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cityMaster = await _context.CityMasters
                .Include(c => c.State)
                .FirstOrDefaultAsync(m => m.CityMasterId == id);
            if (cityMaster == null)
            {
                return NotFound();
            }

            return View(cityMaster);
        }

        // POST: CityMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cityMaster = await _context.CityMasters.FindAsync(id);
            _context.CityMasters.Remove(cityMaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CityMasterExists(int id)
        {
            return _context.CityMasters.Any(e => e.CityMasterId == id);
        }
    }
}
