using MediatR;
using Resume.Application.Features.CustomerFeedback.Requests.Commands;
using Resume.Application.ICacheService;
using Resume.Application.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.CustomerFeedback.Handlers.Commands;

public class DeleteCustomerFeedbackCommandRequestHandler : IRequestHandler<DeleteCustomerFeedbackCommandRequest, bool>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly ICacheServices _cache;

    public DeleteCustomerFeedbackCommandRequestHandler(IUnitOfWork unitOfWork, ICacheServices cache)
    {
        _unitOfWork = unitOfWork;
        _cache = cache;
    }

    #endregion

    public async Task<bool> Handle(DeleteCustomerFeedbackCommandRequest request, CancellationToken cancellationToken)
    {
        var customerFeedback = await _unitOfWork.GenericRepository<Domain.Entity.CustomerFeedback>()
                                                .GetAsync(request.Id, cancellationToken);

        _unitOfWork.GenericRepository<Domain.Entity.CustomerFeedback>().Delete(customerFeedback);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var cacheKey = $"CustomerFeedback:{request.Id}";

        //Remove data from redis cache
        await _cache.RemoveAsync(cacheKey);

        return true;
    }
}