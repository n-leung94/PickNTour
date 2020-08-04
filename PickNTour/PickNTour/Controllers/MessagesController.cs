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

        // For users to read their messages and also view the outcome of sending a message based on the routing from Send method.
        [Route("messages/inbox/{result}")]
        [Route("messages/inbox/")]
        public IActionResult Inbox(string result)
        {
            if (!string.IsNullOrWhiteSpace(result))
            {
                var outcomevm = new MessageOutcomeViewModel {outcome = result };               
                return View(outcomevm);
            }


            return View(new MessageOutcomeViewModel { outcome = "" });
        }

        // For users to compose a message, or to compose a message to a pre-filled recipient if they were routed from an action.
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

        // Method to handle incoming send requests from message form that are being sent to a recipient.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Send(SendMessageFormViewModel viewModel)
        {
            var recipientInDb = _context.Users.SingleOrDefault(u => u.UserName == viewModel.UserName);

            if (recipientInDb == null)
                return Redirect("/messages/inbox/notfound");

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

            return Redirect("/messages/inbox/success");
        }
    }
}