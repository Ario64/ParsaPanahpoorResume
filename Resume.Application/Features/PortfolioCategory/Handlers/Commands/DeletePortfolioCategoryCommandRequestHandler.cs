using AutoMapper;
using MediatR;
using Resume.Application.Features.Portfolio.Requests.Commands;
using Resume.Application.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.PortfolioCategory.Handlers.Commands;

public class DeleteReservationDateCommandRequestHandler : IRequestHandler<DeletePortfolioCategoryCommandRequest, Unit>
{

    #region Constructor

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteReservationDateCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<Unit> Handle(DeletePortfolioCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var portfolioCategory = await _unitOfWork.GenericRepository<DeleteReservationDateCommandRequestHandler>().GetAsync(request.Id, cancellationToken);
        _unitOfWork.GenericRepository<DeleteReservationDateCommandRequestHandler>().Delete(portfolioCategory);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
