using AutoMapper;
using MediatR;
using Resume.Application.Features.Portfolio.Requests.Queries;
using Resume.Application.UnitOfWork;
using Resume.Domain.ViewModels.Pagination;
using Resume.Domain.ViewModels.Portfolio;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.PortfolioCategory.Handlers.Queries;

public class GetPortfolioCategoryListRequestHandler : IRequestHandler<GetPortfolioCategoryListRequest, PagedResult<PortfolioCategoryViewModel>>
{
    #region Constructor

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetPortfolioCategoryListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<PagedResult<PortfolioCategoryViewModel>> Handle(GetPortfolioCategoryListRequest request, CancellationToken cancellationToken)
    {
        var portfolioCategoryList = await _unitOfWork.GenericRepository<Resume.Domain.Entity.PortfolioCategory>()
                                             .GetAllAsync(request.page, request.pageSize, cancellationToken);

        var items = _mapper.Map<IReadOnlyList<PortfolioCategoryViewModel>>(portfolioCategoryList.Items);

        return new PagedResult<PortfolioCategoryViewModel>
        {
            Items = items,
            Page = request.page,
            PageSize = request.pageSize,
            TotalCount = portfolioCategoryList.TotalCount,
            TotalPages = portfolioCategoryList.TotalPages
        };
    }

}
