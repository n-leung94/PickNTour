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
using PickNTour.ViewModels;
using AutoMapper;


namespace PickNTour.Controllers
{
    public class ToursController : Controller
    {
        private ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        

        public ToursController (ApplicationDbContext context, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = UserRoles.User)]
        public IActionResult AvailableTours()
        {
            return View("availabletoursbeta");
        }

        [Authorize(Roles = UserRoles.User)]
        public IActionResult UpcomingBookings()
        {
            return View();
        }

        [Authorize(Roles = UserRoles.User)]
        public IActionResult BookingHistory()
        {
            return View();
        }




        [Authorize(Roles = UserRoles.UserTourGuide)]
        public IActionResult Create()
        {
            // Country Picker to Populate Country DDL
            Country countryList = new Country();

            ViewBag.CountryList = countryList.GetCountries();

            var tourModel = new TourFormViewModel();

            return View("TourForm", tourModel);
        }

        [Authorize(Roles = UserRoles.UserTourGuide)]
        public IActionResult Edit(int id)
        {
            var tourInDb = _context.Tours.Single(t => t.Id == id);

            // Check if an instance of Tour exists else return 404
            if (tourInDb == null)
                return NotFound();

            // Check if the user ID that created the tour matches session user
            var currUser = _userManager.GetUserId(HttpContext.User);
            if (tourInDb.UserId != currUser)
                return BadRequest();

            // If checks has passed, map into a viewModel and allow editing.
            var viewModel = new TourFormViewModel(tourInDb);
            Country countryList = new Country();
            ViewBag.CountryList = countryList.GetCountries();

            return View("TourForm", viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = UserRoles.UserTourGuide)]
        public IActionResult Save(TourFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var tourModel = new TourFormViewModel();

                return View("TourForm", tourModel);
            }

            var tour = _mapper.Map<TourFormViewModel, Tour>(viewModel);

            // Get the user incharge of creating the tour and associate it with the new tour
            var currUser = _userManager.GetUserId(HttpContext.User);

            var userInDb = _context.Users.Single(u => u.Id == currUser);

            // If the tour came as an ID of 0 it means it was newly created
            if (tour.Id == 0)
            {
                // Set current tour availability to tour capacity as it's brand new.
                tour.TourAvailability = tour.TourCapacity;
                tour.UserId = currUser;
                tour.User = userInDb;

                _context.Tours.Add(tour);
            }

            // Else it means the tour is attempting to be edited by a user.
            else
            {
                // Look up the DB for existing tour
                var tourInDb = _context.Tours.Single(t => t.Id == tour.Id);

                // We need to account for the possibility that the user could increase the Tour Capacity which will affect our Availibility
                if (tour.TourCapacity > tourInDb.TourCapacity)
                {
                    int balance = tour.TourCapacity - tourInDb.TourCapacity;
                    tourInDb.TourAvailability += balance;
                }


                tourInDb.Name = tour.Name;
                tourInDb.Description = tour.Description;
                tourInDb.Country = tour.Country;
                tourInDb.StartLocation = tour.StartLocation;
                tourInDb.EndLocation = tour.EndLocation;
                tourInDb.StartDate = tour.StartDate;
                tourInDb.EndDate = tour.EndDate;
                tourInDb.Price = tour.Price;
                tourInDb.TourCapacity = tour.TourCapacity;


            }
            _context.SaveChanges();


            return RedirectToAction("CreatedTours", "Tours");
        }

        public IActionResult CreatedTours()
        {
            return View();
        }
    }
}