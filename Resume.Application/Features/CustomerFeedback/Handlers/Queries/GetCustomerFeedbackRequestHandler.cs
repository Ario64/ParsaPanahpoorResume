using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Resume.Application.Features.CustomerFeedback.Requests.Queries;
using Resume.Application.Services.Interfaces;
using Resume.Domain.ViewModels.CustomerFeedback;

namespace Resume.Application.Features.CustomerFeedback.Handlers.Queries;

public class GetCustomerFeedbackRequestHandler : IRequestHandler<GetCustomerFeedbackRequest, CustomerFeedbackViewModel>
{
    private readonly ICustomerFeedbackService _customerFeedbackService;
    private readonly IMapper _mapper;

    public GetCustomerFeedbackRequestHandler(ICustomerFeedbackService  customerFeedbackService, IMapper mapper)
    {
        _customerFeedbackService = customerFeedbackService;
        _mapper = mapper;
    }

    public async Task<CustomerFeedbackViewModel> Handle(GetCustomerFeedbackRequest request, CancellationToken cancellationToken)
    {
        var customerFeedback = await _customerFeedbackService.GetCustomerFeedbackById(request.Id);
        return _mapper.Map<CustomerFeedbackViewModel>(customerFeedback);
    }
}