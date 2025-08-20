using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Resume.Application.Features.CustomerFeedback.Requests.Queries;
using Resume.Application.Services.Interfaces;
using Resume.Domain.ViewModels.CustomerFeedback;

namespace Resume.Application.Features.CustomerFeedback.Handlers.Queries;

public class GetCustomerFeedbackListRequestHandler : IRequestHandler<GetCustomerFeedbackListRequest, List<CustomerFeedbackViewModel>>
{
    private readonly ICustomerFeedbackService _customerFeedbackService;
    private readonly IMapper _mapper;

    public GetCustomerFeedbackListRequestHandler(ICustomerFeedbackService customerFeedbackService, IMapper mapper)
    {
        _customerFeedbackService = customerFeedbackService;
        _mapper = mapper;
    }

    public async Task<List<CustomerFeedbackViewModel>> Handle(GetCustomerFeedbackListRequest request, CancellationToken cancellationToken)
    {
        var customerFeedbackList = await _customerFeedbackService.GetCustomerFeedbackForIndex();
       return  _mapper.Map<List<CustomerFeedbackViewModel>>(customerFeedbackList);
    }
}