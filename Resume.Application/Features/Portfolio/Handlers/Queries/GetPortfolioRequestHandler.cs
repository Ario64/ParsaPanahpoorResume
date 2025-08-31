using AutoMapper;
using MediatR;
using Resume.Application.Features.Portfolio.Requests.Queries;
using Resume.Application.UnitOfWork;
using Resume.Domain.ViewModels.Portfolio;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.PortfolioCategory.Handlers.Queries;

public class GetPortfolioRequestHandler : IRequestHandler<GetPortfolioRequest, PortfolioViewModel>
{
    #region Constructor

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetPortfolioRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<PortfolioViewModel> Handle(GetPortfolioRequest request, CancellationToken cancellationToken)
    {
        var portfolio = await _unitOfWork.GenericRepository<Resume.Domain.Entity.Portfolio>().GetAsync(request.Id, cancellationToken);
        return _mapper.Map<PortfolioViewModel>(portfolio);
    }
}
