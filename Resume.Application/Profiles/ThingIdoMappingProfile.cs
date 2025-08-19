using AutoMapper;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.ThingIDo;

namespace Resume.Application.Profiles;

public class ThingIdoMappingProfile : Profile
{
    public ThingIdoMappingProfile()
    {
        CreateMap<ThingIDo, ThingIdoViewModel>().ReverseMap();
        CreateMap<ThingIDo, ThingIDoListViewModel>().ReverseMap();
        CreateMap<ThingIDo, CreateThingIDoViewModel>().ReverseMap();
        CreateMap<ThingIDo, EditThingIdoViewModel>().ReverseMap();
        CreateMap<ThingIDo, DeleteThingIdoViewModel>().ReverseMap();
    }
}