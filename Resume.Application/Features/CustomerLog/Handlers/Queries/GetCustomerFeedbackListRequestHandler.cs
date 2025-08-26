using System.Collections.Generic;
using AutoMapper;
using MediatR;
using Resume.Application.Features.CustomerLog.Requests.Queries;
using Resume.Application.UnitOfWork;
using Resume.Domain.ViewModels.CustomerLogo;
using Resume.Domain.ViewModels.Pagination;
using System.Threading;
using System.Threading.Tasks;
using Resume.Domain.Entity;

namespace Resume.Application.Features.CustomerLog.Handlers.Queries;

public class GetCustomerFeedbackListRequestHandler : IRequestHandler<GetCustomerLogoListRequest, PagedResult<CustomerLogoViewModel>>
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

    public async Task<PagedResult<CustomerLogoViewModel>> Handle(GetCustomerLogoListRequest request, CancellationToken cancellationToken)
    {
        var customerLogoList = await _unitOfWork.GenericRepository<CustomerLogo>()
                                                                      .GetAllAsync(request.pageId, request.pageSize, cancellationToken);

        var mappedItems = _mapper.Map<IReadOnlyList<CustomerLogoViewModel>>(customerLogoList.Items);

        return new PagedResult<CustomerLogoViewModel>
        {
            Items = mappedItems,
            TotalPages = customerLogoList.TotalPages,
            Page = customerLogoList.Page,
            PageSize = customerLogoList.PageSize,
            TotalCount = customerLogoList.TotalCount
        };
    }
}