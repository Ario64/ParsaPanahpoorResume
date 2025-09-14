using System.ComponentModel.DataAnnotations;

namespace Resume.Application.ViewModels.Experience;

public interface IExperienceViewModel
{
    public string Title { get; set; }

    public string StartDate { get; set; }

    public string EndDate { get; set; }

    public string Description { get; set; }

    public int Order { get; set; }
}
