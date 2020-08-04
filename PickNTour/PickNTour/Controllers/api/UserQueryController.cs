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
    public class UserQueryController : ControllerBase
    {
        private ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserQueryController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // User query for AutoComplete feature when typing a username to send to in Compose Message
        [HttpGet("{query}")]
        public IActionResult QueryUser(string query)
        {

            var users = _context.Users.Where(u => u.UserName.Contains(query));

            var userDto = users.ToList().Select(_mapper.Map<ApplicationUser, UserQueryDto>);

            return Ok(userDto);

        }

    }


}