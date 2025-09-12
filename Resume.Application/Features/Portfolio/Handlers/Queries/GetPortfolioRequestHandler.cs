using AutoMapper;
using MediatR;
using Resume.Application.Features.Portfolio.Requests.Queries;
using Resume.Application.UnitOfWork;
using Resume.Application.ViewModels.Portfolio;
using System.Collections.Generic;
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

        if (request.Id == 0)
        {
            var portfolio =  new PortfolioViewModel();
            var mapedPortfolio = _mapper.Map<PortfolioViewModel>(portfolio);

            var categoryList = await _unitOfWork.GenericRepository<Resume.Domain.Entity.PortfolioCategory>()
                                                .GetAllAsync(cancellationToken);

             mapedPortfolio.PortfolioCategories = _mapper.Map<List<PortfolioCategoryViewModel>>(categoryList);

            return mapedPortfolio;
        }

        var portfolioByKey = await _unitOfWork.GenericRepository<Resume.Domain.Entity.Portfolio>()
                                              .GetAsync(request.Id, cancellationToken);

      var  mappedPortfolio = _mapper.Map<PortfolioViewModel>(portfolioByKey);

        var categories = await _unitOfWork.GenericRepository<Resume.Domain.Entity.PortfolioCategory>()
                                          .GetAllAsync(cancellationToken);

        mappedPortfolio.PortfolioCategories = _mapper.Map<List<PortfolioCategoryViewModel>>(categories);

        return mappedPortfolio;

    }
}
