using AutoMapper;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.CustomerLogo;

namespace Resume.Application.Profiles;

public class CustomerLogoMappingProfile : Profile
{
    public CustomerLogoMappingProfile()
    {
        #region Customer Logo Profile

        CreateMap<CustomerLogo, CustomerLogoViewModel>().ReverseMap();
        CreateMap<CustomerLogo, CustomerLogoListViewModel>().ReverseMap();
        CreateMap<CustomerLogo, CreateCustomerLogoViewModel>().ReverseMap();
        CreateMap<CustomerLogo, EditCustomerLogoViewModel>().ReverseMap();
        CreateMap<CustomerLogo, DeleteCustomerLogoViewModel>().ReverseMap();

        #endregion
    }
}