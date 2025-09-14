namespace Resume.Application.ViewModels.ThingIDo;

public interface IThingIDoViewModel
{
    public string Icon { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public int ColumnLg { get; set; }

    public int Order { get; set; }
}
