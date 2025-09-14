namespace Resume.Application.ViewModels.CustomerFeedback;

public interface ICustomerFeedbackViewModel
{
    public string Avatar { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
}
