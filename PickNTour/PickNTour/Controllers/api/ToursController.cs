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
                                    .Where(t => t.StartDate >= DateTime.Now && t.TourAvailability > 0)
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

            if (tourInDb.TourAvailability <= 0)
                return BadRequest("The Tour is fully booked!");


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

        [Authorize(Roles = UserRoles.User)]
        [HttpDelete("{id}")]
        public IActionResult CancelBooking(int id)
        {
            // Find if Booking ID exists in DB
            var bookingInDb = _context.Bookings.Single(b => b.Id == id);

            if (bookingInDb == null)
                return NotFound();

            // Find the Tour that the booking cancellation will affect
            var tourInDb = _context.Tours.Single(t => t.Id == bookingInDb.TourId);

            if (tourInDb == null)
                return NotFound();

            // If Booking Exists, remove entry from DB
            _context.Bookings.Remove(bookingInDb);

            // Free up an available slot on the Tour
            tourInDb.TourAvailability += 1;

            
            

            _context.SaveChanges();


            return Ok();
        }
    }
}