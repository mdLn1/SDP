using AutoMapper;
using GCTProject.Data;
using GCTProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCTProject.HelperExts
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Performance, IndexingPerformances>()
                .ForMember(dest => dest.Date, opt =>
                {
                    opt.MapFrom(src => src.PerformanceDate.ElementAt(0));
                });
        }
    }
}
