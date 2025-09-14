namespace Resume.Application.ViewModels.Skill;

public interface ISkillViewModel
{
    public string Title { get; set; }

    public string Percent { get; set; }

    public int Order { get; set; }
}
