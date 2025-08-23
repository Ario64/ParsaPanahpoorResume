using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Resume.Application.Features.CustomerFeedback.Requests.Commands;
using Resume.Application.UnitOfWork;
using Resume.Domain.ViewModels.CustomerFeedback;

namespace Resume.Application.Features.CustomerFeedback.Handlers.Commands;

public class DeleteCustomerFeedbackCommandRequestHandler : IRequestHandler<DeleteCustomerFeedbackCommandRequest, Unit>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteCustomerFeedbackCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<Unit> Handle(DeleteCustomerFeedbackCommandRequest request, CancellationToken cancellationToken)
    {
        var customerFeedback = await _unitOfWork.GenericRepository<Domain.Entity.CustomerFeedback>().GetAsync(request.Id);
        _unitOfWork.GenericRepository<Domain.Entity.CustomerFeedback>().Delete(customerFeedback);
        await _unitOfWork.SaveChangesAsync();
        return Unit.Value;
    }
}