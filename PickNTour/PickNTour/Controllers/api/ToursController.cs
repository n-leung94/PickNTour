using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PickNTour.Models;
using PickNTour.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using PickNTour.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using PickNTour.Dtos;
using Microsoft.EntityFrameworkCore;

namespace PickNTour.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToursController : ControllerBase
    {
        private ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public ToursController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<PublicTourDto> GetAvailableTours()
        {
            // Return list of tours that hasn't started yet.

            var availableTours = _context.Tours
                                    .Where(t => t.StartDate >= DateTime.Now)
                                    .Include(t => t.User);


            return availableTours
                    .ToList()
                    .Select(_mapper.Map<Tour, PublicTourDto>);

        }

        [Authorize(Roles = UserRoles.User)]
        [HttpPost("{id}")]
        public IActionResult BookTour(int id)
        {
            // Find if the Tour exists in DB
            var tourInDb = _context.Tours.Single(t => t.Id == id);

            if (tourInDb == null)
                return NotFound();


            // If Tour exists, get current user and create a booking.
            var currUser = _userManager.GetUserId(HttpContext.User);

            var booking = new Booking
            {
                TourId = id,
                UserId = currUser,
                DateBooked = DateTime.Now
            };


            tourInDb.TourAvailability -= 1;

            _context.Bookings.Add(booking);


            _context.SaveChanges();


            return Ok();
        }
    }
}