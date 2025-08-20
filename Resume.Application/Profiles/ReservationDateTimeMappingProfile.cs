using AutoMapper;
using Resume.Domain.Entity;
using Resume.Domain.ViewModels.ReservationDateTime;

namespace Resume.Application.Profiles;

public class ReservationDateTimeMappingProfile : Profile
{
    public ReservationDateTimeMappingProfile()
    {
        CreateMap<ReservationDateTime, ReservationDateTimeViewModel>().ReverseMap();
        CreateMap<ReservationDateTime, ReservationDateTimeListViewModel>().ReverseMap();
        CreateMap<ReservationDateTime, CreateReservationDateTimeViewModel>().ReverseMap();
        CreateMap<ReservationDateTime, EditReservationDateTimeViewModel>().ReverseMap();
        CreateMap<ReservationDateTime, DeleteReservationDateTimeViewModel>().ReverseMap();
    }
}