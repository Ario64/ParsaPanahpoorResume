using AutoMapper;
using MediatR;
using Resume.Application.Features.Education.Requests.Queries;
using Resume.Application.ICacheService;
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
    private readonly ICacheServices _cache;

    public GetEducationListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper, ICacheServices cache)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _cache = cache; 
    }

    #endregion

    public async Task<PagedResult<EducationViewModel>> Handle(GetEducationListRequest request, CancellationToken cancellationToken)
    {
        var cacheKey = $"EducationList-Page{request.page}-PageSize{request.pageSize}";
        var cachedEducation = await _cache.GetAsync<IReadOnlyList<EducationViewModel>>(cacheKey);

        if(cachedEducation != null)
        {
            return new PagedResult<EducationViewModel>
            {
                Items = cachedEducation,
                Page = request.page,
                PageSize = request.pageSize,
                TotalCount = cachedEducation.Count,
                TotalPages = (int)System.Math.Ceiling(cachedEducation.Count / (double)request.pageSize)
            };
        }

        var educationList = await _unitOfWork.GenericRepository<Resume.Domain.Entity.Education>()
                                       .GetAllPagedAsync(request.page, request.pageSize, cancellationToken);

        var items = _mapper.Map<IReadOnlyList<EducationViewModel>>(educationList.Items);

        if (educationList != null) 
        {
            await _cache.SetAsync(cacheKey, items, System.TimeSpan.FromMinutes(10));
        }

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
