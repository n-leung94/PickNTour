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

namespace PickNTour.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnToursController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public OwnToursController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }


        [HttpGet]
        public IEnumerable<TourDto> GetAllTours()
        {
            var currUser = _userManager.GetUserId(HttpContext.User);
            var tours = _context.Tours.Where(t => t.UserId.Equals(currUser));
            var tourDto = tours
                .ToList()
                .Select(_mapper.Map<Tour, TourDto>);

            return (tourDto);

            
        }
    }

}
