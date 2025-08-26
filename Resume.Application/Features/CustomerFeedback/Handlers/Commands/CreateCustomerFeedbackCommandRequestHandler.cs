using AutoMapper;
using MediatR;
using Resume.Application.Features.CustomerFeedback.Requests.Commands;
using Resume.Application.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.CustomerFeedback.Handlers.Commands;

public class CreateCustomerFeedbackCommandRequestHandler : IRequestHandler<CreateCustomerFeedbackCommandRequest, Unit>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateCustomerFeedbackCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<Unit> Handle(CreateCustomerFeedbackCommandRequest request, CancellationToken cancellationToken)
    {
        var customerFeedback = _mapper.Map<Domain.Entity.CustomerFeedback>(request.CreateCustomerFeedback);
        await _unitOfWork.GenericRepository<Domain.Entity.CustomerFeedback>().Add(customerFeedback);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}