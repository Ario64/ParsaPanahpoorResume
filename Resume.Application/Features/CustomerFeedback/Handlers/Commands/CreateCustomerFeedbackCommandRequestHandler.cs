using AutoMapper;
using MediatR;
using Resume.Application.Features.CustomerFeedback.Requests.Commands;
using Resume.Application.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.CustomerFeedback.Handlers.Commands;

public class CreateCustomerFeedbackCommandRequestHandler : IRequestHandler<CreateCustomerFeedbackCommandRequest, ulong>
{
    private readonly ICustomerFeedbackService _customerFeedbackService;
    private readonly IMapper _mapper;

    public CreateCustomerFeedbackCommandRequestHandler(ICustomerFeedbackService customerFeedbackService, IMapper mapper)
    {
        _customerFeedbackService = customerFeedbackService;
        _mapper = mapper;
    }

    public async Task<ulong> Handle(CreateCustomerFeedbackCommandRequest request, CancellationToken cancellationToken)
    {
        var customerFeedback = _mapper.Map<Domain.Entity.CustomerFeedback>(request.CreateCustomerFeedback);
        customerFeedback = await _customerFeedbackService.CreateOrEditCustomerFeedback(customerFeedback);
        return customerFeedback.Id;
    }
}