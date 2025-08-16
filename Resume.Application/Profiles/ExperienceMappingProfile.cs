using AutoMapper;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.Experience;

namespace Resume.Application.Profiles;
 
public class ExperienceMappingProfile : Profile
{
    public ExperienceMappingProfile()
    {
        #region Experience Profile

        CreateMap<Experience, ExperienceViewModel>().ReverseMap();
        CreateMap<Experience, ExperienceListViewModel>().ReverseMap();
        CreateMap<Experience, CreateExperienceViewModel>().ReverseMap();
        CreateMap<Experience, EditExperienceViewModel>().ReverseMap();
        CreateMap<Experience, DeleteExperienceViewModel>().ReverseMap();

        #endregion
    }
}