using AutoMapper;
using Resume.Application.ViewModels.CustomerFeedback;
using Resume.Domain.Entity;

namespace Resume.Application.Profiles;

public class CustomerFeedBackMappingProfile : Profile
{
    public CustomerFeedBackMappingProfile()
    {
        #region Customer Feedback

        CreateMap<CustomerFeedback, CustomerFeedbackViewModel>();
        CreateMap<CustomerFeedback, CreateCustomerFeedbackViewModel>().ReverseMap();
        CreateMap<CustomerFeedback, EditCustomerFeedbackViewModel>().ReverseMap();
        CreateMap<CustomerFeedback, DeleteCustomerFeedbackViewModel>().ReverseMap();

        #endregion
    }
}