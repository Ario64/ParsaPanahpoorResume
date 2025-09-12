using System.ComponentModel.DataAnnotations;
using Resume.Application.ViewModels.Common;

namespace Resume.Application.ViewModels.CustomerFeedback
{
    public class CustomerFeedbackViewModel : BaseViewModel<long>
    {
        [Display(Name = "آواتار")]
        public string Avatar { get; set; }


        [Display(Name = "نام")]
        public string Name { get; set; }


        [Display(Name = "توضیحات")]
        public string Description { get; set; }


        [Display(Name = "الویت")]
        public int Order { get; set; }

    }
}
