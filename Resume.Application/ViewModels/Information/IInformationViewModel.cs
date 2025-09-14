namespace Resume.Application.ViewModels.Information;

public interface IInformationViewModel
{
    public string Avatar { get; set; }

    public string Name { get; set; }

    public string Job { get; set; }

    public string DateOfBirth { get; set; }

    public string Address { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string ResumeFile { get; set; }

    public string MapSrc { get; set; }
}
