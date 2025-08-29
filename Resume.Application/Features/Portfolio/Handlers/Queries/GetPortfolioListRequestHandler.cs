using AutoMapper;
using MediatR;
using Resume.Application.Features.Portfolio.Requests.Queries;
using Resume.Application.UnitOfWork;
using Resume.Domain.ViewModels.Pagination;
using Resume.Domain.ViewModels.Portfolio;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Portfolio.Handlers.Queries;

public class GetPortfolioListRequestHandler : IRequestHandler<GetPortfolioListRequest, PagedResult<PortfolioViewModel>>
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

    public async Task<PagedResult<PortfolioViewModel>> Handle(GetPortfolioListRequest request, CancellationToken cancellationToken)
    {
        var portfolioList = await _unitOfWork.GenericRepository<Resume.Domain.Entity.Portfolio>()
                                             .GetAllAsync(request.page, request.pageSize, cancellationToken);

        var items = _mapper.Map<IReadOnlyList<PortfolioViewModel>>(portfolioList.Items);

        return new PagedResult<PortfolioViewModel>
        {
            Items = items,
            Page = request.page,
            PageSize = request.pageSize,
            TotalCount = portfolioList.TotalCount,
            TotalPages = portfolioList.TotalPages
        };
    }
}
