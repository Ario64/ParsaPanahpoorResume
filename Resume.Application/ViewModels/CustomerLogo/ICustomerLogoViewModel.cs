using System.ComponentModel.DataAnnotations;

namespace Resume.Application.ViewModels.CustomerLogo;

public interface ICustomerLogoViewModel
{
    public string Logo { get; set; }
    public string LogoAlt { get; set; }
    public string Link { get; set; }
    public int Order { get; set; }
}
