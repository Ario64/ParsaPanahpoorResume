using AutoMapper;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.CustomerFeedback;
using Resume.Domain.ViewModels.CustomerLogo;

namespace Resume.Application.Profiles;

public class CustomerFeedBackMappingProfile : Profile
{
    public CustomerFeedBackMappingProfile()
    {
        #region Customer Feedback

        CreateMap<CustomerFeedback, CustomerFeedbackViewModel>().ReverseMap();
        CreateMap<CustomerFeedback, CreateCustomerFeedbackViewModel>().ReverseMap();
        CreateMap<CustomerFeedback, CreateCustomerFeedbackViewModel>().ReverseMap();
        CreateMap<CustomerFeedback, EditCustomerFeedbackViewModel>().ReverseMap();
        CreateMap<CustomerFeedback, DeleteCustomerFeedbackViewModel>().ReverseMap();

        #endregion
    }
}