using System.ComponentModel.DataAnnotations;
using Resume.Domain.ViewModels.Common;

namespace Resume.Domain.ViewModels.Portfolio
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
