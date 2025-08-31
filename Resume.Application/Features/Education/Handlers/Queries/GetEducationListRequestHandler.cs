using AutoMapper;
using MediatR;
using Resume.Application.Features.Education.Requests.Queries;
using Resume.Application.UnitOfWork;
using Resume.Domain.ViewModels.Education;
using Resume.Domain.ViewModels.Pagination;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Education.Handlers.Queries;

public class GetEducationListRequestHandler : IRequestHandler<GetEducationListRequest, PagedResult<EducationViewModel>>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetEducationListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<PagedResult<EducationViewModel>> Handle(GetEducationListRequest request, CancellationToken cancellationToken)
    {
        var educationList = await _unitOfWork.GenericRepository<Resume.Domain.Entity.Education>()
                                       .GetAllAsync(request.page, request.pageSize, cancellationToken);

        var items = _mapper.Map<IReadOnlyList<EducationViewModel>>(educationList.Items);

        return new PagedResult<EducationViewModel>
        {
            Items = items,
            Page = educationList.Page,
            PageSize = educationList.PageSize,
            TotalCount = educationList.TotalCount,
            TotalPages = educationList.TotalPages
        };

    }
}
