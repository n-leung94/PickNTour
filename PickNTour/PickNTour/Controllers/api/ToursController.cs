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
    [Route("api/[controller]")]
    [ApiController]
    public class ToursController : ControllerBase
    {
        private ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public ToursController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<PublicTourDto> GetAvailableTours()
        {
            // Return list of tours that hasn't started yet.
            
            var availableTours =  _context.Tours
                                    .Where(t => t.StartDate >= DateTime.Now)
                                    .Include(t => t.User);

            
            return availableTours                 
                    .ToList()
                    .Select(_mapper.Map<Tour, PublicTourDto>);
                      
        }
    }
}