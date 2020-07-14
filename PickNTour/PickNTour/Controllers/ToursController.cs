using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PickNTour.Models;
using PickNTour.Data;
using System.Globalization;

namespace PickNTour.Controllers
{
    public class ToursController : Controller
    {
        private ApplicationDbContext _context;

        public ToursController (ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            // Country Picker to Populate Country DDL
            Country countryList = new Country();

            ViewBag.CountryList = countryList.GetCountries();

            var tourModel = new Tour { 
            
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddHours(2)
            };

            return View("TourForm", tourModel);
        }
    }
}