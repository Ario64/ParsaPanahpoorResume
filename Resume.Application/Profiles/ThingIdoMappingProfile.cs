using AutoMapper;
using Resume.Domain.Entity;
using Resume.Application.ViewModels.ThingIDo;

namespace Resume.Application.Profiles;

public class ThingIdoMappingProfile : Profile
{
    public ThingIdoMappingProfile()
    {
        CreateMap<ThingIDo, ThingIdoViewModel>();
        CreateMap<ThingIDo, CreateThingIDoViewModel>().ReverseMap();
        CreateMap<ThingIDo, EditThingIdoViewModel>().ReverseMap();
        CreateMap<ThingIDo, DeleteThingIdoViewModel>().ReverseMap();
    }
}