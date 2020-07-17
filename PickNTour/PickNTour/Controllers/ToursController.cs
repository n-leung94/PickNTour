using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PickNTour.Models;
using PickNTour.Data;
using System.Globalization;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using PickNTour.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;


namespace PickNTour.Controllers
{
    public class ToursController : Controller
    {
        private ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        

        public ToursController (ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = UserRoles.UserTourGuide)]
        public IActionResult Create()
        {
            // Country Picker to Populate Country DDL
            Country countryList = new Country();

            ViewBag.CountryList = countryList.GetCountries();

            var tourModel = new Tour();

            return View("TourForm", tourModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = UserRoles.UserTourGuide)]
        public IActionResult Save(Tour tour)
        {
            if (!ModelState.IsValid)
            {
                var tourModel = new Tour();

                return View("TourForm", tourModel);
            }

            // Set current tour availability to tour capacity as it's brand new.
            tour.TourAvailability = tour.TourCapacity;

            // Get the user incharge of creating the tour and associate it with the new tour
            var currUser = _userManager.GetUserId(HttpContext.User);

            var userInDb = _context.Users.Single(u => u.Id == currUser);

            tour.UserId = currUser;
            tour.User = userInDb;

            _context.Tours.Add(tour);
            _context.SaveChanges();


            return RedirectToAction("Index", "Home");
        }

        public IActionResult CreatedTours()
        {
            return View();
        }
    }
}