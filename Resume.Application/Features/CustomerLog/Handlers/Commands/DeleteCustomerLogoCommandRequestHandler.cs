using MediatR;
using Resume.Application.Features.CustomerLog.Requests.Commands;
using Resume.Application.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.CustomerLog.Handlers.Commands;

public class DeleteCustomerLogoCommandRequestHandler : IRequestHandler<DeleteCustomerLogoCommandRequest, Unit>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;

    public DeleteCustomerLogoCommandRequestHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    #endregion

    public async Task<Unit> Handle(DeleteCustomerLogoCommandRequest request, CancellationToken cancellationToken)
    {
        var customerLogo = await _unitOfWork.GenericRepository<Domain.Entity.CustomerLogo>().GetAsync(request.Id);
        _unitOfWork.GenericRepository<Domain.Entity.CustomerLogo>().Delete(customerLogo);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
