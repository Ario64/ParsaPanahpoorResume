using AutoMapper;
using MediatR;
using Resume.Application.Features.Portfolio.Requests.Commands;
using Resume.Application.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.PortfolioCategory.Handlers.Commands;

public class EditPortfolioCategoryCommandRequestHandler : IRequestHandler<EditPortfolioCategoryCommandRequest, Unit>
{
    #region Constructor

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public EditPortfolioCategoryCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<Unit> Handle(EditPortfolioCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var portfolioCategory = await _unitOfWork.GenericRepository<Resume.Domain.Entity.PortfolioCategory>().GetAsync(request.Id, cancellationToken);
        _mapper.Map(request.EditPortfolioViewModel, portfolioCategory);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.PortfolioCategory>().Update(portfolioCategory);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
