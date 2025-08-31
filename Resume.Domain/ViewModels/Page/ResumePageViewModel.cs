using Resume.Domain.ViewModels.Education;
using Resume.Domain.ViewModels.Experience;
using Resume.Domain.ViewModels.Pagination;
using Resume.Domain.ViewModels.Skill;

namespace Resume.Domain.ViewModels.Page
{
    public class ResumePageViewModel
    {
        public PagedResult<EducationViewModel> Educations { get; set; }
        public PagedResult<ExperienceViewModel> Experiences { get; set; }
        public PagedResult<SkillViewModel> Skills { get; set; }

    }
}
