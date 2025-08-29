using AutoMapper;
using MediatR;
using Resume.Application.Features.Portfolio.Requests.Queries;
using Resume.Application.UnitOfWork;
using Resume.Domain.ViewModels.Portfolio;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.PortfolioCategory.Handlers.Queries;

public class GetPortfolioCategoryRequestHandler : IRequestHandler<GetPortfolioCategoryRequest, PortfolioCategoryViewModel>
{
    #region Constructor

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetPortfolioCategoryRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<PortfolioCategoryViewModel> Handle(GetPortfolioCategoryRequest request, CancellationToken cancellationToken)
    {
        var portfolioCategory = await _unitOfWork.GenericRepository<Resume.Domain.Entity.PortfolioCategory>().GetAsync(request.Id, cancellationToken);
        return _mapper.Map<PortfolioCategoryViewModel>(portfolioCategory);
    }
}
