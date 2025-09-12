using Resume.Application.ViewModels.Education;
using Resume.Application.ViewModels.Experience;
using Resume.Application.ViewModels.Pagination;
using Resume.Application.ViewModels.Skill;
using System.Collections.Generic;

namespace Resume.Application.ViewModels.Page
{
    public class ResumePageViewModel
    {
        public PagedResult<EducationViewModel> Educations { get; set; }
        public IReadOnlyList<ExperienceViewModel> Experiences { get; set; }
        public IReadOnlyList<SkillViewModel> Skills { get; set; }

    }
}
