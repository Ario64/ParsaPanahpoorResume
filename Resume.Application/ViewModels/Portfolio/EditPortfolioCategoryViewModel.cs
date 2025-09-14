using System.ComponentModel.DataAnnotations;
using Resume.Application.ViewModels.Common;

namespace Resume.Application.ViewModels.Portfolio
{
    public class EditPortfolioCategoryViewModel : BaseViewModel<long>, IPortfolioCategoryViewModel
    {
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string Title { get; set; }


        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string Name { get; set; }


        [Display(Name = "الویت")]
        public int Order { get; set; }

    }
}
