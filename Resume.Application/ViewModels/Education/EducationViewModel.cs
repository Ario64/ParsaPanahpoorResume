using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic.CompilerServices;
using Resume.Application.ViewModels.Common;

namespace Resume.Application.ViewModels.Education
{
    public class EducationViewModel : BaseViewModel<long>
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
