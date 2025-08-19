using System.ComponentModel.DataAnnotations;
using Resume.Domain.ViewModels.Common;

namespace Resume.Domain.ViewModels.CustomerLogo
{
    public class CustomerLogoListViewModel : BaseViewModel<ulong>
    {
        [Display(Name = "لوگو")]
        public string Logo { get; set; }


        [Display(Name = "توضیحات لوگو")]
        public string LogoAlt { get; set; }


        [Display(Name = "لینک")]
        public string Link { get; set; }


        [Display(Name = "الویت")]
        public int Order { get; set; }

    }
}
