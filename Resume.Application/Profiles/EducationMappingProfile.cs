using AutoMapper;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.Education;

namespace Resume.Application.Profiles;

public class EducationMappingProfile :Profile
{
    public EducationMappingProfile()
    {
        #region Education Profile

        CreateMap<Education, EducationViewModel>().ReverseMap();
        CreateMap<Education, EducationListViewModel>().ReverseMap();
        CreateMap<Education, CreateEducationViewModel>().ReverseMap();
        CreateMap<Education, EditEducationViewModel>().ReverseMap();
        CreateMap<Education, DeleteEducationViewModel>().ReverseMap();

        #endregion
    }

}