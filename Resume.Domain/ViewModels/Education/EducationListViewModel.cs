using Resume.Domain.ViewModels.Common;
using System.ComponentModel.DataAnnotations;

namespace Resume.Domain.ViewModels.Education;

public class EducationListViewModel : BaseViewModel<ulong>
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