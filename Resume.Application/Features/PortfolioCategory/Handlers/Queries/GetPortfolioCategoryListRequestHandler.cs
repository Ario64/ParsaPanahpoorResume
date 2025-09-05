using AutoMapper;
using MediatR;
using Resume.Application.Features.PortfolioCategory.Requests.Queries;
using Resume.Application.UnitOfWork;
using Resume.Domain.ViewModels.Portfolio;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.PortfolioCategory.Handlers.Queries;

public class GetPortfolioCategoryListRequestHandler : IRequestHandler<GetPortfolioCategoryListRequest, IReadOnlyList<PortfolioCategoryViewModel>>
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

    public async Task<IReadOnlyList<PortfolioCategoryViewModel>> Handle(GetPortfolioCategoryListRequest request, CancellationToken cancellationToken)
    {
        var portfolioCategoryList = await _unitOfWork.GenericRepository<Resume.Domain.Entity.PortfolioCategory>()
                                             .GetAllAsync( cancellationToken);

        var portfolioCategoryListViewModel = _mapper.Map<IReadOnlyList<PortfolioCategoryViewModel>>(portfolioCategoryList);

        return portfolioCategoryListViewModel;
    }

}
