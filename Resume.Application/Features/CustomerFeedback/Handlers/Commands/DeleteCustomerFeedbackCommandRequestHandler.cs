using MediatR;
using Resume.Application.Features.CustomerFeedback.Requests.Commands;
using Resume.Application.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.CustomerFeedback.Handlers.Commands;

public class DeleteCustomerFeedbackCommandRequestHandler : IRequestHandler<DeleteCustomerFeedbackCommandRequest, Unit>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;

    public DeleteCustomerFeedbackCommandRequestHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    #endregion

    public async Task<Unit> Handle(DeleteCustomerFeedbackCommandRequest request, CancellationToken cancellationToken)
    {
        var customerFeedback = await _unitOfWork.GenericRepository<Domain.Entity.CustomerFeedback>().GetAsync(request.Id, cancellationToken);
        _unitOfWork.GenericRepository<Domain.Entity.CustomerFeedback>().Delete(customerFeedback);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}