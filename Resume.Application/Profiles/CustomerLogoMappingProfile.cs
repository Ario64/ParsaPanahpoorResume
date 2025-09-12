using AutoMapper;
using Resume.Domain.Entity;
using Resume.Application.ViewModels.CustomerLogo;

namespace Resume.Application.Profiles;

public class CustomerLogoMappingProfile : Profile
{
    public CustomerLogoMappingProfile()
    {
        #region Customer Logo Profile

        CreateMap<CustomerLogo, CustomerLogoViewModel>();
        CreateMap<CustomerLogo, CreateCustomerLogoViewModel>().ReverseMap();
        CreateMap<CustomerLogo, EditCustomerLogoViewModel>().ReverseMap();
        CreateMap<CustomerLogo, DeleteCustomerLogoViewModel>().ReverseMap();

        #endregion
    }
}