using AutoMapper;
using MediatR;
using Resume.Application.Features.Portfolio.Requests.Commands;
using Resume.Application.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Portfolio.Handlers.Commands;

public class DeletePortfolioCategoryCommandRequestHandler : IRequestHandler<DeletePortfolioCategoryCommandRequest, Unit>
{

    #region Constructor

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public DeletePortfolioCategoryCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<Unit> Handle(DeletePortfolioCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var portfolio = await _unitOfWork.GenericRepository<DeletePortfolioCategoryCommandRequestHandler>().GetAsync(request.Id, cancellationToken);
        _unitOfWork.GenericRepository<DeletePortfolioCategoryCommandRequestHandler>().Delete(portfolio);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
