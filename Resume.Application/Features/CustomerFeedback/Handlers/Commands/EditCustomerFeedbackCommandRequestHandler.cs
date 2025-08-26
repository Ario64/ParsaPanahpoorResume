using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Resume.Application.Features.CustomerFeedback.Requests.Commands;
using Resume.Application.UnitOfWork;

namespace Resume.Application.Features.CustomerFeedback.Handlers.Commands;

public class EditCustomerFeedbackCommandRequestHandler : IRequestHandler<EditCustomerFeedbackCommandRequest, Unit>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EditCustomerFeedbackCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<Unit> Handle(EditCustomerFeedbackCommandRequest request, CancellationToken cancellationToken)
    {
        var customerFeedback = await _unitOfWork.GenericRepository<Domain.Entity.CustomerFeedback>().GetAsync(request.Id, cancellationToken);
        _mapper.Map(request.CustomerFeedbackViewModel, customerFeedback);
        _unitOfWork.GenericRepository<Domain.Entity.CustomerFeedback>().Update(customerFeedback);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}