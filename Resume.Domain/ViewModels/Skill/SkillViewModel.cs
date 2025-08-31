using System.ComponentModel.DataAnnotations;
using Resume.Domain.ViewModels.Common;

namespace Resume.Domain.ViewModels.Skill
{
    public class SkillViewModel : BaseViewModel<long>
    {
        [Display(Name = "عنوان")]
        public string Title { get; set; }


        [Display(Name = "درصد")]
        public string Percent { get; set; }


        [Display(Name = "الویت")]
        public int Order { get; set; }

    }
}
