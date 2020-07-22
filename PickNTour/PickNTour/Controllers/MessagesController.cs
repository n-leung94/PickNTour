using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using PickNTour.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using PickNTour.ViewModels;
using Microsoft.EntityFrameworkCore;
using PickNTour.Models;
using PickNTour.Data;

namespace PickNTour.Controllers
{
    [Authorize(Roles = UserRoles.UserTourGuide + "," + UserRoles.UserAdmin + "," + UserRoles.User)]
    public class MessagesController : Controller
    {
        private ApplicationDbContext _context { get; set; }
        private UserManager<ApplicationUser> _userManager { get; set; }

        public MessagesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public IActionResult Inbox()
        {
            return View();
        }

        [Route("messages/compose/{UserName}")]
        [Route("messages/compose/")]
        public IActionResult Compose(string UserName)
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                var recipientInDb = _context.Users.Single(u => u.UserName.Equals(UserName));

                var viewModel = new SendMessageFormViewModel
                {
                    UserName = recipientInDb.UserName
                    
                };

                return View(viewModel);
            }
            


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Send(SendMessageFormViewModel viewModel)
        {
            var recipientInDb = _context.Users.SingleOrDefault(u => u.UserName == viewModel.UserName);

            if (recipientInDb == null)
                return NotFound("The Username you are attempting to send a message to, does not exist");

            var currUser = _userManager.GetUserId(HttpContext.User);

            var newMessage = new Message
            {
                UserToId = recipientInDb.Id,
                UserFromId = currUser,
                DateSent = DateTime.Now,
                Subject = viewModel.Subject,
                MessageBody = viewModel.MessageBody
            };

            _context.Add(newMessage);
            _context.SaveChanges();

            return RedirectToAction("Compose", "Messages");
        }
    }
}