using addon365.FindMatch360.Data;
using addon365.FindMatch360.Models;
using addon365.FindMatch360.Models.MatrimonyProfileModels;
using addon365.FindMatch360.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.FindMatch360.Services
{
    public class ProfileService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ilamaiMatrimonyContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProfileService(UserManager<ApplicationUser> userManager, ilamaiMatrimonyContext context, IHttpContextAccessor httpContextAccessor)
        {
            this._userManager = userManager;
            this._context = context;
            this._httpContextAccessor = httpContextAccessor;
        }
        public bool IsProfileUser()
        {
            if(GetProfile()!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsCompleteProfile()
        {
            bool IsComplete = true;
            Profile profile = GetProfile();
            if(profile!=null)
            {
                if(profile.Name == null)
                {
                    IsComplete = false;
                }
                if(profile.CasteMasterId==null)
                {
                    IsComplete = false;
                }
            }
            return IsComplete;
        }
        public Profile GetProfile()
        {

            System.Security.Claims.ClaimsPrincipal currentUser = _httpContextAccessor.HttpContext.User;
            var data = _context.MatrimonyProfiles.Where(a => a.UserId == _userManager.GetUserId(currentUser));
            Profile profile = null;

            if (data.Any())
            {
                if (data.Count() == 1)
                {
                    profile = data.FirstOrDefault();
                    return profile;
                }
                else
                {
                    throw new Exception("Two User Found");
                }
            }
            return null;
        }
    }
}
