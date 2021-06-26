using addon365.FindMatch360.Data;
using addon365.FindMatch360.Models;
using addon365.FindMatch360.Models.MatrimonyProfileModels;
using addon365.FindMatch360.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace addon365.FindMatch360.Controllers
{
    //[Authorize(Roles ="Administrator,MatrimonyUser")]
    public class MatrimonyProfilesController : Controller
    {
        private readonly ilamaiMatrimonyContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private bool IsProfileUser,IsCompleteProfile;
        private Profile profile;
        public MatrimonyProfilesController(ilamaiMatrimonyContext context, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            this._userManager = userManager;
            this._httpContextAccessor = httpContextAccessor;
            
            System.Security.Claims.ClaimsPrincipal currentUser = _httpContextAccessor.HttpContext.User;

            IsProfileUser = currentUser.IsInRole("MatrimonyUser");
            
            if(IsProfileUser)
            {
               var data=_context.Profiles.Where(a => a.UserId == _userManager.GetUserId(currentUser));
                profile = null;
               if(data.Any())
                {
                    if(data.Count()==1)
                    {
                        profile = data.FirstOrDefault();
                      
                    }
                }
            }

        }
        private void ValidateProfile()
        {
            
            IsCompleteProfile = true;
            if(IsProfileUser)
            {
               if(profile==null)
                {
                    IsCompleteProfile = false;
                    return;
                }
                if(profile.Name == "")
                {
                    IsCompleteProfile = false;
                }
            }
        }
        // GET: MatrimonyProfiles
        public async Task<IActionResult> Index()
        {
            ValidateProfile();
            if (!IsCompleteProfile)
            {
                return RedirectToAction("UserRegistrationReligionDetails", "home");
            }
            System.Security.Claims.ClaimsPrincipal currentUser = _httpContextAccessor.HttpContext.User;


            return View(await _context.Profiles.Include(s => s.ProfileEducation).Include(s => s.EmployeedIn).Include(s => s.Occupation).Where(x => x.UserId != _userManager.GetUserId(currentUser)).ToListAsync());
        }

        // GET: MatrimonyProfiles/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matrimonyProfile = await _context.Profiles
                .FirstOrDefaultAsync(m => m.ProfileMasterId == id);
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
        [AllowAnonymous]
        public async Task<IActionResult> Edit()
        {
            if (profile==null)
            {
                return NotFound();
            }

            var prof = _context.Profiles.Include(i=>i.Caste).Include(i=>i.SubCaste).Include(i=>i.ProfileEducation).Include(i=>i.Occupation).FirstOrDefault(x=>x.ProfileMasterId== profile.ProfileMasterId);
            if (prof == null)
            {
                return NotFound();
            }
            ProfileUserEditViewModel vm = new ProfileUserEditViewModel();
            vm.Name = prof.Name;
            
            if(prof.Caste!=null)
                vm.CasteName = prof.Caste.CasteName;

            if(prof.SubCaste!=null)
                vm.SubCasteName = prof.SubCaste.SubCasteName;

            if(prof.ProfileEducation!=null)
                vm.EducationName = prof.ProfileEducation.EducationName;
            
            if(prof.Occupation!=null)
                vm.OccupationName = prof.Occupation.OccupationName;

            return View(vm);
          
        }

        // POST: MatrimonyProfiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("MatrimonyProfileId,Name,DateandTimeOfBirth,Place,Color,Height,Nakshatra,Rasi,Lagnam,ChevvaiDosham,BirthNumberinFamily,Brothers,MarriedBrothers,Sisters,MarriedSisters,JobPosition,CompanyAddress,MonthlyRevenue,FatherName,FatherQualification,FatherJob,MotherName,MotherQualification,MotherJob,NativeDistrict,ContactPerson,Address,PhoneNo,MobileNo,EmailId,ExpectedQualification")]Profile matrimonyProfile)
        {
            if (id != matrimonyProfile.ProfileMasterId)
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
                    if (!MatrimonyProfileExists(matrimonyProfile.ProfileMasterId))
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

            var matrimonyProfile = await _context.Profiles
                .FirstOrDefaultAsync(m => m.ProfileMasterId == id);
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
            var matrimonyProfile = await _context.Profiles.FindAsync(id);
            _context.Profiles.Remove(matrimonyProfile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatrimonyProfileExists(Guid id)
        {
            return _context.Profiles.Any(e => e.ProfileMasterId == id);
        }
    }
}
