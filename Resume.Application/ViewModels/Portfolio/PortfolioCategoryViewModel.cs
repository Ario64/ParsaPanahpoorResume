using System.ComponentModel.DataAnnotations;
using Resume.Application.ViewModels.Common;

namespace Resume.Application.ViewModels.Portfolio
{
    public class PortfolioCategoryViewModel : BaseViewModel<long>
    {
        [Display(Name = "عنوان")]
        public string Title { get; set; }


        [Display(Name = "نام")]
        public string Name { get; set; }


        [Display(Name = "الویت")]
        public int Order { get; set; }


    }
}
