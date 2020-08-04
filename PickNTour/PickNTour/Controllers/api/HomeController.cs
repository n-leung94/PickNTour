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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }


        // For Authenticated User Home Page
        [HttpGet]
        [Authorize(Roles = UserRoles.User)]
        public IActionResult GetUserStats()
        {
            var currUser = _userManager.GetUserId(HttpContext.User);

            var unreadMessages = _context.Messages
                .Where(m => m.UserToId.Equals(currUser) && m.DateRead == null)
                .Count();

            var upcomingBookings = _context.Bookings
                .Include(m => m.Tour)
                .Where(m => m.UserId.Equals(currUser) && m.Tour.StartDate > DateTime.Now)
                .Count();

            var completedBookings = _context.Bookings
                .Include(m => m.Tour)
                .Where(m => m.UserId.Equals(currUser) && m.Tour.StartDate < DateTime.Now)
                .Count();


            var userStatsDto = new UserStatsDto
            {
                unreadMessages = unreadMessages,
                upcomingBookings = upcomingBookings,
                completedBookings = completedBookings
            };

            return Ok(userStatsDto);

        }

        // For Unauthenticated User Home Page
        [HttpGet]
        public IActionResult GetPublicStats()
        {
            // We will implicitly return the 3 tours that are starting soon

            var latestTours = _context.Tours.Include(t => t.User)
                .Where(t => t.StartDate > DateTime.Now)
                .OrderBy(t => t.StartDate)
                .Take(3);

            var publicTourDto = latestTours.ToList().Select(_mapper.Map<Tour, PublicTourDto>);

            return Ok(publicTourDto);
        }

        // For Tour Guide User Home Page
        [HttpGet]
        [Authorize(Roles = UserRoles.UserTourGuide)]
        public IActionResult GetTourGuideStats()
        {
            var currUser = _userManager.GetUserId(HttpContext.User);

            var unreadMessages = _context.Messages
                .Where(m => m.UserToId.Equals(currUser) && m.DateRead == null)
                .Count();

            var upcomingTours = _context.Tours
                .Where(t => t.UserId.Equals(currUser) && t.StartDate > DateTime.Now)
                .Count();

            var completedTours = _context.Tours.
                Where(t => t.UserId.Equals(currUser) && t.StartDate < DateTime.Now)
                .Count();

            var tourGuideStatsDto = new TourGuideStatsDto
            {
                unreadMessages = unreadMessages,
                upcomingTours = upcomingTours,
                completedTours = completedTours
            };

            return Ok(tourGuideStatsDto);
        }


    }


}