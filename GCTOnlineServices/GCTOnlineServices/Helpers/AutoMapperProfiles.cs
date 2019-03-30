
using AutoMapper;
using GCTOnlineServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GCTOnlineServices.Data;
using GCTOnlineServices.Models.OOPModels;
using GCTOnlineServices.Models.ViewModels;

namespace GCTOnlineServices.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Play, TheatrePlay>()
                .ReverseMap();
            

            CreateMap<ApplicationUser, EditUserDetails>();
            CreateMap<EditUserDetails, ApplicationUser>()
                .ForMember(d => d.Id, opt => opt.Ignore());

            CreateMap<TheatreSeat, SoldTicket>()
                .ForMember(d => d.Id, opt =>
                opt.Ignore())
                .ForMember(d => d.PaidPrice, opt =>
                opt.MapFrom(s => s.Price));
            

            CreateMap<Play, PlayForCreation>();

            CreateMap<Play, EditPlay>().ReverseMap();
            

        }
    }
}
