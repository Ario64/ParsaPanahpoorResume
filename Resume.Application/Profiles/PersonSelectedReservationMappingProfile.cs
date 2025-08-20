using AutoMapper;
using Resume.Domain.Entity.Reservation;
using Resume.Domain.ViewModels.PersonSelectedReservation;

namespace Resume.Application.Profiles;

public class PersonSelectedReservationMappingProfile : Profile
{
    public PersonSelectedReservationMappingProfile()
    {
        CreateMap<PersonSelectedReservation, PersonSelectedReservationViewModel>().ReverseMap();
        CreateMap<PersonSelectedReservation, PersonSelectedReservationListViewModel>().ReverseMap();
        CreateMap<PersonSelectedReservation, CreatePersonSelectedReservationViewModel>().ReverseMap();
        CreateMap<PersonSelectedReservation, EditPersonSelectedReservationViewModel>().ReverseMap();
        CreateMap<PersonSelectedReservation, DeletePersonSelectedReservationViewModel>().ReverseMap();
    }
}