using AutoMapper;
using MediatR;
using Resume.Application.Features.CustomerLog.Requests.Queries;
using Resume.Application.UnitOfWork;
using Resume.Domain.Entity;
using Resume.Domain.ViewModels.CustomerLogo;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.CustomerLog.Handlers.Queries;

public class GetCustomerFeedbackListRequestHandler : IRequestHandler<GetCustomerLogoListRequest, IReadOnlyList<CustomerLogoViewModel>>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetCustomerFeedbackListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<IReadOnlyList<CustomerLogoViewModel>> Handle(GetCustomerLogoListRequest request, CancellationToken cancellationToken)
    {
        var customerLogoList = await _unitOfWork.GenericRepository<CustomerLogo>()
                                                .GetAllAsync( cancellationToken);

        var customerLogoListViewModel = _mapper.Map<IReadOnlyList<CustomerLogoViewModel>>(customerLogoList);

        return mappedItems;


    }
}