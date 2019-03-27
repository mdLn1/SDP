
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
            

            CreateMap<Performance, TheatrePerformance>().ReverseMap();

            CreateMap<TheatreSeat, SoldTicket>()
                .ForMember(d => d.Id, opt =>
                opt.Ignore())
                .ForMember(d => d.PaidPrice, opt =>
                opt.MapFrom(s => s.Price));
            

            CreateMap<Play, PlayForCreation>();

            CreateMap<Play, PerformanceEdit>().ReverseMap();
                

            CreateMap<BasketTicket, TicketForBasket>()
                .ForMember(d => d.Band, opt =>
                opt.MapFrom(s => s.BookedSeat.Seat.Band))
                .ForMember(d => d.ColumnLetter, opt =>
                opt.MapFrom(s => s.BookedSeat.Seat.ColumnLetter))
                .ForMember(d => d.RowNumber, opt =>
                opt.MapFrom(s => s.BookedSeat.Seat.RowNumber))
                .ForMember(d => d.PerformanceTimeAndDate, opt =>
                opt.MapFrom(s => s.Performance.Date))
                .ForMember(d => d.PlayName, opt =>
                opt.MapFrom(s => s.Performance.Play.Name));

            CreateMap<Order, TicketOrder>()
                .ForMember(d => d.DeliveryMethod, opt =>
                opt.MapFrom(s => s.User.Basket.ShippingMethod));

            CreateMap<SoldTicket, TicketSold>();

            CreateMap<ApplicationUser, TheatreAgencyOrClub>().ReverseMap();
            CreateMap<ApplicationUser, TheatreCustomer>().ReverseMap();
            CreateMap<ApplicationUser, TheatreStaff>().ReverseMap();

        }
    }
}
