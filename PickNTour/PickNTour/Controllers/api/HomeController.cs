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

    }


}