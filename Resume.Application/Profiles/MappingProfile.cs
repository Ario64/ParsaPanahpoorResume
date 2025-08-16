using AutoMapper;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.CustomerFeedback;

namespace Resume.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region Customer Feedback

        CreateMap<CustomerFeedback, CustomerFeedbackViewModel>().ReverseMap();
        CreateMap<CustomerFeedback, CreateCustomerFeedbackViewModel>().ReverseMap();
        CreateMap<CustomerFeedback, CreateCustomerFeedbackViewModel>().ReverseMap();
        CreateMap<CustomerFeedback, EditCustomerFeedbackViewModel>().ReverseMap();
        CreateMap<CustomerFeedback, DeleteCustomerFeedbackViewModel>().ReverseMap();

        #endregion

        #region Education



        #endregion

    }
}