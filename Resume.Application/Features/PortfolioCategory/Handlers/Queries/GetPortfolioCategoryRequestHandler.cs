using AutoMapper;
using MediatR;
using Resume.Application.Features.PortfolioCategory.Requests.Queries;
using Resume.Application.UnitOfWork;
using Resume.Application.ViewModels.Portfolio;
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
        if(request.Id == 0)
        {
            var newPortfolioCategory = new PortfolioCategoryViewModel();
            return newPortfolioCategory;
        }

        var portfolioCategory = await _unitOfWork.GenericRepository<Resume.Domain.Entity.PortfolioCategory>()
                                                 .GetAsync(request.Id, cancellationToken);

        return _mapper.Map<PortfolioCategoryViewModel>(portfolioCategory);
    }
}
