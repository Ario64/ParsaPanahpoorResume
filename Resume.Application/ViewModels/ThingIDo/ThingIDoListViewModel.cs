using System.ComponentModel.DataAnnotations;
using Resume.Application.ViewModels.Common;

namespace Resume.Application.ViewModels.ThingIDo
{
    public class ThingIDoListViewModel
    {
        [Display(Name = "آیکون")]
        public string Icon { get; set; }


        [Display(Name = "عنوان")]
        public string Title { get; set; }


        [Display(Name = "توضیحات")]
        public string Description { get; set; }


        [Display(Name = "عرض ستون آیتم")]
        public int ColumnLg { get; set; }


        [Display(Name = "الویت")]
        public int Order { get; set; }
    }
}
