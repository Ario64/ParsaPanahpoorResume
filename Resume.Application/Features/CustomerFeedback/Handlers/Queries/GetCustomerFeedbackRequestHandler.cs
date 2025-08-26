using AutoMapper;
using MediatR;
using Resume.Application.Features.CustomerFeedback.Requests.Queries;
using Resume.Application.UnitOfWork;
using Resume.Domain.ViewModels.CustomerFeedback;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.CustomerFeedback.Handlers.Queries;

public class GetCustomerFeedbackRequestHandler : IRequestHandler<GetCustomerFeedbackRequest, CustomerFeedbackViewModel>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetCustomerFeedbackRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<CustomerFeedbackViewModel> Handle(GetCustomerFeedbackRequest request, CancellationToken cancellationToken)
    {
        var customerFeedback = await _unitOfWork.GenericRepository<Domain.Entity.CustomerFeedback>().GetAsync(request.Id, cancellationToken);
        return _mapper.Map<CustomerFeedbackViewModel>(customerFeedback);
    }
}