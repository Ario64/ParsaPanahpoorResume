using AutoMapper;
using MediatR;
using Resume.Application.Features.Information.Requests.Queries;
using Resume.Application.UnitOfWork;
using Resume.Domain.ViewModels.Information;
using Resume.Domain.ViewModels.Pagination;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Information.Handlers.Queries;

public class GetInformationListRequestHandler : IRequestHandler<GetInformationListRequest, PagedResult<InformationViewModel>>
{
    #region

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetInformationListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    #endregion

    public async Task<PagedResult<InformationViewModel>> Handle(GetInformationListRequest request, CancellationToken cancellationToken)
    {
        var informationList = await _unitOfWork.GenericRepository<Resume.Domain.Entity.Information>()
                                               .GetAllPagedAsync(request.page, request.pageSize, cancellationToken);

        var items = _mapper.Map<IReadOnlyList<InformationViewModel>>(informationList.Items);

        return new PagedResult<InformationViewModel>
        {
            Items = items,
            Page = request.page,
            PageSize = request.pageSize,
            TotalCount = informationList.TotalCount,
            TotalPages = informationList.TotalPages,
        };

    }
}
