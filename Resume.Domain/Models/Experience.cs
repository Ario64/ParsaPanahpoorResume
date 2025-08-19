using System.ComponentModel.DataAnnotations;
using Resume.Domain.Entity.Common;


namespace Resume.Domain.Models
{
    public class Experience : BaseEntity<ulong>
    {
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string Title { get; set; }


        [Display(Name = "تاریخ شروع")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MinLength(4, ErrorMessage = "{0} نمیتواند کمتر از {1} کاراکتر باشد")]
        [MaxLength(4, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string StartDate { get; set; }


        [Display(Name = "تاریخ پایان")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MinLength(4, ErrorMessage = "{0} نمیتواند کمتر از {1} کاراکتر باشد")]
        [MaxLength(4, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string EndDate { get; set; }


        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(1000, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string Description { get; set; }


        [Display(Name = "الویت")]
        public int Order { get; set; } = 0;


    }
}
