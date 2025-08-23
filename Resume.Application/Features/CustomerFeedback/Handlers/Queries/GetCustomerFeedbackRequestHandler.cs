using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Resume.Application.Features.CustomerFeedback.Requests.Queries;
using Resume.Application.Services.Interfaces;
using Resume.Application.UnitOfWork;
using Resume.Domain.ViewModels.CustomerFeedback;

namespace Resume.Application.Features.CustomerFeedback.Handlers.Queries;

public class GetCustomerFeedbackRequestHandler : IRequestHandler<GetCustomerFeedbackRequest, CustomerFeedbackViewModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetCustomerFeedbackRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CustomerFeedbackViewModel> Handle(GetCustomerFeedbackRequest request, CancellationToken cancellationToken)
    {
        var customerFeedback = await _unitOfWork.GenericRepository<Domain.Entity.CustomerFeedback>().GetAsync(request.Id);
        return _mapper.Map<CustomerFeedbackViewModel>(customerFeedback);
    }
}