using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PickNTour.Models;
using PickNTour.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using PickNTour.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using PickNTour.ViewModels;

namespace PickNTour.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _logger = logger;
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            var role = getCurrentUserRole();

            if (role.Equals("user"))
            {
                return View("UserHome");
            }

            return View("PublicHome");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public string getCurrentUserRole()
        {
            var currUser = _userManager.GetUserId(HttpContext.User);

            var userRoles = _context.UserRoles.Where(u => u.UserId == currUser);

            List<string> roles = new List<string>();

            foreach (var role in userRoles)
            {
                var roleName = _context.Roles.SingleOrDefault(r => r.Id.Equals(role.RoleId));
                roles.Add(roleName.Name);
            }

            if (roles.Contains(UserRoles.UserAdmin))
                return ("admin");


            if (roles.Contains(UserRoles.UserTourGuide))
                return ("tourguide");

            if(roles.Contains(UserRoles.User))
                return ("user");

            return "unauthenticated";

                
        }

    }
}
