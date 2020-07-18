using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PickNTour.Dtos;
using PickNTour.Areas.Identity.Data;

namespace PickNTour.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //CreateMap<Model, DTO>();
            CreateMap<Tour, TourDto>();
            CreateMap<ApplicationUser, TourGuideDto>();
            CreateMap<Tour, PublicTourDto>();
        }

    }
}
