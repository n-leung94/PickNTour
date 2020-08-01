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
    [Authorize(Roles = UserRoles.UserTourGuide + "," + UserRoles.UserAdmin + "," + UserRoles.User)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public MessagesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }


        [HttpGet]
        public IEnumerable<ReadMessageDto> GetReceivedMessages ()
        {
            var currUser = _userManager.GetUserId(HttpContext.User);

            var messages = _context.Messages
                .Include(m => m.UserFrom)
                .Where(m => m.UserToId.Equals(currUser));

            var readMessageDto = messages
                .ToList()
                .Select(_mapper.Map<Message, ReadMessageDto>);

            return readMessageDto;


        }

        [HttpPut("{id}")]
        public IActionResult ReadMessage(int id)
        {
            // Check if the request was sent by the original user
            var currUser = _userManager.GetUserId(HttpContext.User);

            var messageInDb = _context.Messages.SingleOrDefault(m => m.Id == id);

            if (messageInDb == null)
                return NotFound();

            if (!messageInDb.UserToId.Equals(currUser))
                return BadRequest();

            // If checks are passed, check to see if there's already an existing timestamp as we only need the earliest.
            if (messageInDb.DateRead != null)
                return Ok();


            // Otherwise we do a one time registration of timestamp read.
            messageInDb.DateRead = DateTime.Now;
            _context.SaveChanges();

            return Ok();


        }


        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var messageInDb = _context.Messages.SingleOrDefault(m => m.Id == id);

            if (messageInDb == null)
                return NotFound();

            _context.Remove(messageInDb);
            _context.SaveChanges();

            return Ok();
        }

    }
}