using System.ComponentModel.DataAnnotations;
using Resume.Application.ViewModels.Common;

namespace Resume.Application.ViewModels.Skill
{
    public class SkillViewModel : BaseViewModel<long>, ISkillViewModel
    {
        [Display(Name = "عنوان")]
        public string Title { get; set; }


        [Display(Name = "درصد")]
        public string Percent { get; set; }


        [Display(Name = "الویت")]
        public int Order { get; set; }

    }
}
