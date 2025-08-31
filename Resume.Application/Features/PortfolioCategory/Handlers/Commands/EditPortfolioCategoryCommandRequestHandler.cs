using AutoMapper;
using MediatR;
using Resume.Application.Features.Portfolio.Requests.Commands;
using Resume.Application.Features.PortfolioCategory.Requests.Commands;
using Resume.Application.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.PortfolioCategory.Handlers.Commands;

public class EditPortfolioCategoryCommandRequestHandler : IRequestHandler<EditPortfolioCategoryCommandRequest, bool>
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

    public async Task<bool> Handle(EditPortfolioCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var portfolioCategory = await _unitOfWork.GenericRepository<Resume.Domain.Entity.PortfolioCategory>().GetAsync(request.Id, cancellationToken);
        _mapper.Map(request.EditPortfolioViewModel, portfolioCategory);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.PortfolioCategory>().Update(portfolioCategory);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
