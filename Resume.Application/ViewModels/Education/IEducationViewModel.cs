using System.ComponentModel.DataAnnotations;

namespace Resume.Application.ViewModels.Education;

public interface IEducationViewModel
{
    public string Title { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
}
