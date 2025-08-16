using AutoMapper;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.CustomerFeedback;

namespace Resume.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CustomerFeedback,CreateOrEditCustomerFeedbackViewModel>().ReverseMap();
    }
}