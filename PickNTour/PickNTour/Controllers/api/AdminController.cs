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
using PickNTour.ViewModels;
using AutoMapper;
using PickNTour.Dtos;
using PickNTour.Dtos.AdminDtos;
using Microsoft.EntityFrameworkCore;

namespace PickNTour.Controllers.api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = UserRoles.UserAdmin)]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public AdminController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }

        // Returns all registered users of the site from DB
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var allUsers = _context.Users.Where(u => u.LockoutEnd == null).ToList();

            var adminUserDto = allUsers.Select(_mapper.Map<ApplicationUser, AdminUserQueryDto>);

            return Ok(adminUserDto);
        }

        // Returns all registered users that has an active lockout in the DB
        [HttpGet]
        public IActionResult GetLockedoutUsers()
        {
            var lockedoutUsers = _context.Users.Where(u => u.LockoutEnd != null).ToList();
       
            var adminUserDto = lockedoutUsers.Select(_mapper.Map<ApplicationUser, AdminUserQueryDto>);

            return Ok(adminUserDto);
        }

        // Releases a lockout of a user based on the userID
        [HttpPut("{userId}")]
        public IActionResult ReleaseLockout(string userId)
        {
            var userInDb = _context.Users.SingleOrDefault(u => u.Id.Equals(userId));

            if (userInDb == null)
                return NotFound();

            userInDb.LockoutEnd = null;

            _context.SaveChanges();

            return Ok();
        }

        // Registers a lockout on a user by ID along with the date time the suspension should last until.
        [HttpPut("{userId}/{date}")]
        public IActionResult LockoutUser(string userId, DateTime date)
        {
            var userInDb = _context.Users.SingleOrDefault(u => u.Id.Equals(userId));            

            if (userInDb == null)
                return NotFound();

            if (date == null)
                return BadRequest("Date and Time for lockout was not specified.");


            userInDb.LockoutEnd = date;

            _context.SaveChanges();

            var userRoles = _context.UserRoles.Where(u => u.UserId == userId);

            List<string> roles = new List<string>();

            foreach (var role in userRoles)
            {
                var roleName = _context.Roles.SingleOrDefault(r => r.Id.Equals(role.RoleId));
                roles.Add(roleName.Name);
            }
            
            if(roles.Contains(UserRoles.UserTourGuide))
                removeToursFromTourGuide(userId);

            if(roles.Contains(UserRoles.User))
                removeBookingFromUser(userId, userInDb.UserName);

            return Ok();

        }

        // Local method that removes all associated tours created by a given Tour Guide based on User ID
        public void removeToursFromTourGuide(string userId)
        {
            // First we get tours created by the Tour Guide that has yet to commence
            var toursInDb = _context.Tours.Where(t => t.UserId.Equals(userId) && t.StartDate > DateTime.Now);


            // We alert all affected users that has a booking with the upcoming tour
            foreach (var tour in toursInDb)
            {
                var tourBookings = _context.Bookings.Where(b => b.TourId == tour.Id);

                foreach(var booking in tourBookings)
                {
                    notifyAffectedUser(booking.UserId, tour.Name);
                    _context.Remove(booking);

                }

                // Remove the Tour once all associated bookings are removed.
                _context.Remove(tour);
            }

            _context.SaveChanges();


            // Finally, get the remaining tours which have already been completed and remove them
            var remainingTours = _context.Tours.Where(t => t.UserId.Equals(userId));
            foreach (var tour in remainingTours)
            {
                var tourBookings = _context.Bookings.Where(b => b.TourId == tour.Id);

                foreach(var booking in tourBookings)
                {
                    _context.Remove(booking);
                }


                _context.Remove(tour);
            }

            _context.SaveChanges();

        }

        // Local method that informs all users of an affected tour due to tour guide lockout via PM if the tour has yet to start.
        public void notifyAffectedUser(string userId, string affectedTour)
        {
            var currAdmin = _userManager.GetUserId(HttpContext.User);

            var message = new Message
            {
                UserToId = userId,
                UserFromId = currAdmin,
                DateSent = DateTime.Now,
                Subject = "Suspension of Tour: " + affectedTour,
                MessageBody = "Your booking to " + affectedTour + " has been cancelled as the Tour Guide has been suspended from the website."
            };

            _context.Add(message);
        }

        // Local method that removes all associated bookings made by a given user based on User ID
        public void removeBookingFromUser(string userId, string userName)
        {
            // Find Upcoming Bookings associated with userId
            var upcomingBookings = _context.Bookings.Include(b => b.Tour).Where(b => b.UserId.Equals(userId) && b.Tour.StartDate > DateTime.Now);

            // For Each Upcoming Bookings, notify affected TourGuide
            foreach (var booking in upcomingBookings)
            {
                notifyAffectedTourGuide(booking.Tour.UserId, userName, booking.Tour.Name);

                // Find the respective upcoming tour and increment availability
                var tour = _context.Tours.SingleOrDefault(t => t.Id == booking.TourId);
                tour.TourAvailability += 1;

                // Delete Booking
                _context.Remove(booking);
            }

            _context.SaveChanges();


            // Find remaining booking history from user and remove it.
            var bookingHistory = _context.Bookings.Where(b => b.UserId.Equals(userId));

            foreach(var booking in bookingHistory)
            {
                _context.Remove(booking);
            }

            _context.SaveChanges();
            


        }

        // Local method that notifies a tour guide if a booking to their upcoming tour has been cancelled due to user lockout
        public void notifyAffectedTourGuide(string userId, string lockedOutUser,string affectedTour)
        {
            var currAdmin = _userManager.GetUserId(HttpContext.User);

            var message = new Message
            {
                UserToId = userId,
                UserFromId = currAdmin,
                DateSent = DateTime.Now,
                Subject = "Removal of Booking for: " + affectedTour,
                MessageBody = "The following Tour Participant " + lockedOutUser + " has been locked out from the site by an administrator and hence, their booking has been removed from the tour."
            };

            _context.Add(message);
        }





    }
}