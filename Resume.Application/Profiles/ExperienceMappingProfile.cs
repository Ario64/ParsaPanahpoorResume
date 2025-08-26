using AutoMapper;
using Resume.Domain.Entity;
using Resume.Domain.ViewModels.Experience;

namespace Resume.Application.Profiles;
 
public class ExperienceMappingProfile : Profile
{
    public ExperienceMappingProfile()
    {
        #region Experience Profile

        CreateMap<Experience, ExperienceViewModel>();
        CreateMap<Experience, CreateExperienceViewModel>().ReverseMap();
        CreateMap<Experience, EditExperienceViewModel>().ReverseMap();
        CreateMap<Experience, DeleteExperienceViewModel>().ReverseMap();

        #endregion
    }
}