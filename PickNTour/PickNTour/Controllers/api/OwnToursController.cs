using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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
    [Authorize(Roles = UserRoles.UserTourGuide)]
    [Route("api/[controller]")]
    [ApiController]
    public class OwnToursController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _Mapper;

        public OwnToursController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _Mapper = mapper;
        }


        [HttpGet]
        public IEnumerable<TourDto> GetAllTours()
        {
            var currUser = _userManager.GetUserId(HttpContext.User);
            var tours = _context.Tours.Where(t => t.UserId.Equals(currUser));
            var tourDto = tours
                .ToList()
                .Select(_Mapper.Map<Tour, TourDto>);

            return (tourDto);

        }

        [HttpGet("{tourId}")]
        [Route("tourparticipants/{tourId}")]
        public IActionResult GetTourParticipants(int tourId)
        {
            // First check that the user enquiring the data is the actual owner of the tour
            var currUser = _userManager.GetUserId(HttpContext.User);

            var tourInDb = _context.Tours.SingleOrDefault(t => t.Id == tourId);

            if (tourInDb == null)
                return NotFound();

            if (!tourInDb.UserId.Equals(currUser))
                return BadRequest();


            var participants = _context.Bookings.Include(b => b.User)
                .Where(b => b.TourId == tourId)
                .Select(b => b.User);

            var userQueryDto = participants.ToList()
                               .Select(_Mapper.Map<ApplicationUser, UserQueryDto>);

            return Ok(userQueryDto);

                 
                               
        }
        

        [HttpDelete("{id}")]
        public IActionResult DeleteTour(int id)
        {
            // First, check that such tour exists in the db.
            var tourInDb = _context.Tours.SingleOrDefault(t => t.Id.Equals(id));

            if (tourInDb == null)
                return NotFound();

            // Ensure that the delete request was sent by the original user that created the tour.
            var currUser = _userManager.GetUserId(HttpContext.User);

            if (!tourInDb.UserId.Equals(currUser))
                return BadRequest();

            // Remove any Bookings associated with the tour
            removeBookingsFromTour(id);


            //If all checks pass, delete from the database.
            _context.Tours.Remove(tourInDb);
            _context.SaveChanges();

            // Future Implementation to send out notification to affected users.

            return Ok();


        }

        public void removeBookingsFromTour(int tourId)
        {
            var bookings = _context.Bookings
                .Include(b => b.User)
                .Include(b => b.Tour)
                .Where(b => b.Tour.Id == tourId);

            foreach(var booking in bookings)
            {
                if(booking.Tour.StartDate > DateTime.Now)
                    notifyAffectedUser(booking.UserId, booking.Tour.Name);

                _context.Remove(booking);
            }

            _context.SaveChanges();

        }

        public void notifyAffectedUser(string userId, string affectedTour)
        {
            var currUser = _userManager.GetUserId(HttpContext.User);

            var message = new Message
            {
                UserToId = userId,
                UserFromId = currUser,
                DateSent = DateTime.Now,
                Subject = "[AUTOMESSAGE] Cancellation of Tour: " + affectedTour,
                MessageBody = "Your booking to " + affectedTour + " has been cancelled as the Tour Guide has cancelled the Tour."
            };

            _context.Add(message);
        }
    }

}
