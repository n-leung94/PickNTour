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

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var allUsers = _context.Users.Where(u => u.LockoutEnd == null).ToList();

            var adminUserDto = allUsers.Select(_mapper.Map<ApplicationUser, AdminUserQueryDto>);

            return Ok(adminUserDto);
        }

        [HttpGet]
        public IActionResult GetLockedoutUsers()
        {
            var lockedoutUsers = _context.Users.Where(u => u.LockoutEnd != null).ToList();
       
            var adminUserDto = lockedoutUsers.Select(_mapper.Map<ApplicationUser, AdminUserQueryDto>);

            return Ok(adminUserDto);
        }

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


        [HttpPut("{userId}/{date}")]
        public IActionResult LockoutUser(string userId, DateTime date)
        {
            var userInDb = _context.Users.SingleOrDefault(u => u.Id.Equals(userId));

            if (userInDb == null)
                return NotFound();

            userInDb.LockoutEnd = date;

            _context.SaveChanges();

            return Ok();

        }

    }
}