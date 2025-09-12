using AutoMapper;
using MediatR;
using Resume.Application.Features.Portfolio.Requests.Queries;
using Resume.Application.UnitOfWork;
using Resume.Application.ViewModels.Portfolio;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Portfolio.Handlers.Queries;

public class GetPortfolioListRequestHandler : IRequestHandler<GetPortfolioListRequest, IReadOnlyList<PortfolioViewModel>>
{
    #region Constructor

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetPortfolioListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<IReadOnlyList<PortfolioViewModel>> Handle(GetPortfolioListRequest request, CancellationToken cancellationToken)
    {
        var portfolioList = await _unitOfWork.PortfolioRepository
                                             .GatAllPortfolioAsync(cancellationToken);

        var portfolioListViewModel = _mapper.Map<IReadOnlyList<PortfolioViewModel>>(portfolioList);

        return portfolioListViewModel;
    }
}
