using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using addon365.FindMatch360.Data;
using addon365.FindMatch360.Models;
using Microsoft.AspNetCore.Authorization;
using addon365.FindMatch360.Models.MatrimonyProfileModels;

namespace addon365.FindMatch360.Controllers
{
    
    public class MatrimonyProfilesController : Controller
    {
        private readonly ilamaiMatrimonyContext _context;

        public MatrimonyProfilesController(ilamaiMatrimonyContext context)
        {
            _context = context;
        }

        // GET: MatrimonyProfiles
        public async Task<IActionResult> Index()
        {
            return View(await _context.MatrimonyProfiles.ToListAsync());
        }

        // GET: MatrimonyProfiles/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matrimonyProfile = await _context.MatrimonyProfiles
                .FirstOrDefaultAsync(m => m.MatrimonyProfileId == id);
            if (matrimonyProfile == null)
            {
                return NotFound();
            }

            return View(matrimonyProfile);
        }

        // GET: MatrimonyProfiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MatrimonyProfiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MatrimonyProfileId,Name,DateandTimeOfBirth,Place,Color,Height,Nakshatra,Rasi,Lagnam,ChevvaiDosham,BirthNumberinFamily,Brothers,MarriedBrothers,Sisters,MarriedSisters,JobPosition,CompanyAddress,MonthlyRevenue,FatherName,FatherQualification,FatherJob,MotherName,MotherQualification,MotherJob,NativeDistrict,ContactPerson,Address,PhoneNo,MobileNo,EmailId,ExpectedQualification")] Profile matrimonyProfile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(matrimonyProfile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(matrimonyProfile);
        }

        // GET: MatrimonyProfiles/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matrimonyProfile = await _context.MatrimonyProfiles.FindAsync(id);
            if (matrimonyProfile == null)
            {
                return NotFound();
            }
            return View(matrimonyProfile);
        }

        // POST: MatrimonyProfiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("MatrimonyProfileId,Name,DateandTimeOfBirth,Place,Color,Height,Nakshatra,Rasi,Lagnam,ChevvaiDosham,BirthNumberinFamily,Brothers,MarriedBrothers,Sisters,MarriedSisters,JobPosition,CompanyAddress,MonthlyRevenue,FatherName,FatherQualification,FatherJob,MotherName,MotherQualification,MotherJob,NativeDistrict,ContactPerson,Address,PhoneNo,MobileNo,EmailId,ExpectedQualification")]Profile matrimonyProfile)
        {
            if (id != matrimonyProfile.MatrimonyProfileId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matrimonyProfile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatrimonyProfileExists(matrimonyProfile.MatrimonyProfileId))
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
            return View(matrimonyProfile);
        }

        // GET: MatrimonyProfiles/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matrimonyProfile = await _context.MatrimonyProfiles
                .FirstOrDefaultAsync(m => m.MatrimonyProfileId == id);
            if (matrimonyProfile == null)
            {
                return NotFound();
            }

            return View(matrimonyProfile);
        }

        // POST: MatrimonyProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var matrimonyProfile = await _context.MatrimonyProfiles.FindAsync(id);
            _context.MatrimonyProfiles.Remove(matrimonyProfile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatrimonyProfileExists(Guid id)
        {
            return _context.MatrimonyProfiles.Any(e => e.MatrimonyProfileId == id);
        }
    }
}
