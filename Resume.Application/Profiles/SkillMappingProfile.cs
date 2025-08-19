using AutoMapper;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.Skill;

namespace Resume.Application.Profiles;

public class SkillMappingProfile : Profile
{
    public SkillMappingProfile()
    {
        CreateMap<Skill, SkillViewModel>().ReverseMap();
        CreateMap<Skill, CreateSkillViewModel>().ReverseMap();
        CreateMap<Skill, EditSkillViewModel>().ReverseMap();
        CreateMap<Skill, DeleteSkillViewModel>().ReverseMap();
        CreateMap<Skill, SkillListViewModel>().ReverseMap();
    }
}