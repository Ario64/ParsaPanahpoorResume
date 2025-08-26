using AutoMapper;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.Information;

namespace Resume.Application.Profiles;

public class InformationMappingProfile : Profile
{
    public InformationMappingProfile()
    {
        #region Information Profile

        CreateMap<Information, InformationViewModel>();
        CreateMap<Information, CreateInformationViewModel>().ReverseMap();
        CreateMap<Information, EditInformationViewModel>().ReverseMap();
        CreateMap<Information, DeleteInformationViewModel>().ReverseMap();

        #endregion
    }

}