using Resume.Domain.ViewModels.Education;
using Resume.Domain.ViewModels.Experience;
using Resume.Domain.ViewModels.Pagination;
using Resume.Domain.ViewModels.Skill;
using System.Collections.Generic;

namespace Resume.Domain.ViewModels.Page
{
    public class ResumePageViewModel
    {
        public PagedResult<EducationViewModel> Educations { get; set; }
        public IReadOnlyList<ExperienceViewModel> Experiences { get; set; }
        public IReadOnlyList<SkillViewModel> Skills { get; set; }

    }
}
