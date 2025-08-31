using AutoMapper;
using Resume.Domain.Entity;
using Resume.Domain.ViewModels.Skill;

namespace Resume.Application.Profiles;

public class SkillMappingProfile : Profile
{
    public SkillMappingProfile()
    {
        CreateMap<Skill, SkillViewModel>();
        CreateMap<Skill, CreateSkillViewModel>().ReverseMap();
        CreateMap<Skill, EditSkillViewModel>().ReverseMap();
        CreateMap<Skill, DeleteSkillViewModel>().ReverseMap();
    }
}