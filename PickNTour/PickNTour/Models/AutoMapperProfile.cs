using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PickNTour.Dtos;
using PickNTour.Areas.Identity.Data;
using PickNTour.Dtos.AdminDtos;
using PickNTour.ViewModels;

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
            CreateMap<Booking, BookingDto>();
            CreateMap<ApplicationUser, UserQueryDto>();
            CreateMap<Message, ReadMessageDto>();
            CreateMap<TourFormViewModel, Tour>();


            // Admin DTOs
            CreateMap<ApplicationUser, AdminUserQueryDto>();
        }

    }
}
