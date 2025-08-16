using System.ComponentModel.DataAnnotations;
using Resume.Domain.ViewModels.Common;

namespace Resume.Domain.ViewModels.Experience
{
    public class ExperienceViewModel : BaseViewModel<long>
    {
        [Display(Name = "عنوان")]
        public string Title { get; set; }


        [Display(Name = "تاریخ شروع")]
        public string StartDate { get; set; }


        [Display(Name = "تاریخ پایان")]
        public string EndDate { get; set; }


        [Display(Name = "توضیحات")]
        public string Description { get; set; }


        [Display(Name = "الویت")]
        public int Order { get; set; }

    }
}
