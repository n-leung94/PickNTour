using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using PickNTour.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using PickNTour.Data;
using PickNTour.Models;
using PickNTour.Dtos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace PickNTour.Controllers.api
{
    [Authorize(Roles = UserRoles.User)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookedToursController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public BookedToursController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<BookingDto> GetUpcomingBookings()
        {
            var currUser = _userManager.GetUserId(HttpContext.User);
            var bookings = _context.Bookings.Where(b => b.UserId.Equals(currUser) && b.Tour.StartDate >= DateTime.Now)
                                            .Include(b => b.Tour)
                                            .Include(b => b.Tour.User);

            var bookingDto = bookings.ToList()
                               .Select(_mapper.Map<Booking, BookingDto>);

            return bookingDto;
                     
        }

        [HttpGet]
        public IEnumerable<BookingDto> GetBookingHistory()
        {
            var currUser = _userManager.GetUserId(HttpContext.User);
            var bookings = _context.Bookings.Where(b => b.UserId.Equals(currUser) && b.Tour.StartDate < DateTime.Now)
                                            .Include(b => b.Tour)
                                            .Include(b => b.Tour.User);

            var bookingDto = bookings.ToList()
                               .Select(_mapper.Map<Booking, BookingDto>);

            return bookingDto;

        }


    }
}