using MediatR;
using Resume.Application.Exceptions;
using Resume.Application.Features.CustomerFeedback.Requests.Commands;
using Resume.Application.ICacheService;
using Resume.Application.UnitOfWork;
using Resume.Application.ViewModels.CustomerFeedback;
using Resume.Application.ViewModels.CustomerFeedback.Validators;
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
        var validator = new DeleteCustomerFeedbackValidator();
        var validationResult = await validator.ValidateAsync(new DeleteCustomerFeedbackViewModel() { Id = request.Id }, cancellationToken);

        if (validationResult.IsValid == false)
            throw new ValidationException(validationResult);
       

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