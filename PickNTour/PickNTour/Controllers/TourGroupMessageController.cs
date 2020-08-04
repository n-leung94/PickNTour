using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace PickNTour.Controllers
{
    [Authorize(Roles = UserRoles.UserTourGuide)]
    public class TourGroupMessageController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public TourGroupMessageController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }

        // For tour guides to message their tourgroup based on the tourId
        [Route("tourgroupmessage/compose/{tourId}")]
        public IActionResult MessageTourGroup(int tourId)
        {
            // Check if tour exists in DB
            var tourInDb = _context.Tours.SingleOrDefault(t => t.Id == tourId);

            if (tourInDb == null)
                return NotFound();

            //Check if current user is the owner of the tour
            var currUser = _userManager.GetUserId(HttpContext.User);

            if (!tourInDb.UserId.Equals(currUser))
                return BadRequest();

            // If validation checks pass retrieve all the users that made the booking
            var receivers = _context.Bookings
                .Where(b => b.TourId == tourId)
                .Select(b => b.UserId)
                .Distinct()
                .ToList();

            var viewModel = new MessageTGViewModel
            {
                TourId = tourInDb.Id,
                TourName = tourInDb.Name,
                Participants = receivers,
                Subject = "Re: " + tourInDb.Name
            };


            return View(viewModel);
        }

        // Method to handle the message tour group form that will be sent to all recipients of the tour.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Send (MessageTGViewModel viewModel)
        {
            var currUser = _userManager.GetUserId(HttpContext.User);

            foreach (var participant in viewModel.Participants)
            {               

                var message = new Message
                {
                    UserToId = participant,
                    UserFromId = currUser,
                    DateSent = DateTime.Now,
                    Subject = viewModel.Subject,
                    MessageBody = viewModel.MessageBody
                };

                _context.Messages.Add(message);
            }

            _context.SaveChanges();



            return Redirect("/messages/inbox/success");
        }
    }
}