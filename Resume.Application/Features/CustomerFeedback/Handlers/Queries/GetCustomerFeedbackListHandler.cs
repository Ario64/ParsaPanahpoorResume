using AutoMapper;
using MediatR;
using Resume.Application.Features.CustomerFeedback.Requests.Queries;
using Resume.Application.UnitOfWork;
using Resume.Domain.ViewModels.CustomerFeedback;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Resume.Domain.ViewModels.Pagination;

namespace Resume.Application.Features.CustomerFeedback.Handlers.Queries;

public class GetCustomerFeedbackListRequestHandler : IRequestHandler<GetCustomerFeedbackListRequest, PagedResult<CustomerFeedbackViewModel>>
{
    #region Constructort

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetCustomerFeedbackListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<PagedResult<CustomerFeedbackViewModel>> Handle(GetCustomerFeedbackListRequest request, CancellationToken cancellationToken)
    {
        var customerFeedbackList = await _unitOfWork.GenericRepository<Domain.Entity.CustomerFeedback>()
                                                               .GetAllAsync(request.page, request.pageSize, cancellationToken);

        var items = _mapper.Map<IReadOnlyList<CustomerFeedbackViewModel>>(customerFeedbackList.Items);

        return new PagedResult<CustomerFeedbackViewModel>()
        {
            Items = items,
            TotalPages = customerFeedbackList.TotalPages,
            PageSize = customerFeedbackList.PageSize,
            TotalCount = customerFeedbackList.TotalCount,
            Page = customerFeedbackList.Page
        };
    }
}