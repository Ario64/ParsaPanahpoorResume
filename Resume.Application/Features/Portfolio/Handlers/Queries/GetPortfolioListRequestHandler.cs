using AutoMapper;
using MediatR;
using Resume.Application.Features.Portfolio.Requests.Queries;
using Resume.Application.UnitOfWork;
using Resume.Domain.ViewModels.Portfolio;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Portfolio.Handlers.Queries;

public class GetPortfolioListRequestHandler : IRequestHandler<GetPortfolioListRequest, PortfolioPageResult>
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

    public async Task<PortfolioPageResult> Handle(GetPortfolioListRequest request, CancellationToken cancellationToken)
    {
        var portfolioList = await _unitOfWork.GenericRepository<Resume.Domain.Entity.Portfolio>()
                                             .GetAllPagedAsync(request.page, request.pageSize, cancellationToken);

        var items = _mapper.Map<IReadOnlyList<PortfolioViewModel>>(portfolioList.Items);

        var categoryList = items.GroupBy(g => new { g.Id, g.PortfolioCategoryName })
                                .Select(g => new PortfolioCategoryViewModel
                                {
                                    Id = g.Key.Id,
                                    Name = g.Key.PortfolioCategoryName,
                                    Title = g.First().PortfolioCategoryName
                                }).ToList();


        return new PortfolioPageResult
        {
            Items = items,
            Page = request.page,
            PageSize = request.pageSize,
            TotalCount = portfolioList.TotalCount,
            TotalPages = portfolioList.TotalPages,
            CategoryList = categoryList
        };
    }
}
