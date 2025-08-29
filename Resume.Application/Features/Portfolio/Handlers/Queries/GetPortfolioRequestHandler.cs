using AutoMapper;
using MediatR;
using Resume.Application.Features.Portfolio.Requests.Queries;
using Resume.Application.UnitOfWork;
using Resume.Domain.ViewModels.Portfolio;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Portfolio.Handlers.Queries;

public class GetPortfolioCategoryRequestHandler : IRequestHandler<GetPortfolioCategoryRequest, PortfolioViewModel>
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

    public async Task<PortfolioViewModel> Handle(GetPortfolioCategoryRequest request, CancellationToken cancellationToken)
    {
        var portfolio = await _unitOfWork.GenericRepository<Resume.Domain.Entity.Portfolio>().GetAsync(request.Id, cancellationToken);
        return _mapper.Map<PortfolioViewModel>(portfolio);
    }
}
