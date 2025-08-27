using AutoMapper;
using MediatR;
using Resume.Application.Features.Experience.Requests.Queries;
using Resume.Application.UnitOfWork;
using Resume.Domain.ViewModels.Experience;
using Resume.Domain.ViewModels.Pagination;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Experience.Handlers.Queries;

public class GetExperienceListRequestHandler : IRequestHandler<GetExperienceListRequest, PagedResult<ExperienceViewModel>>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetExperienceListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<PagedResult<ExperienceViewModel>> Handle(GetExperienceListRequest request, CancellationToken cancellationToken)
    {
        var experience = await _unitOfWork.GenericRepository<Resume.Domain.Entity.Experience>()
                                          .GetAllAsync(request.page, request.pageSize, cancellationToken);

        var items = _mapper.Map<IReadOnlyList<ExperienceViewModel>>(experience.Items);

        return new PagedResult<ExperienceViewModel>
        {
            Items = items,
            Page = request.page,
            PageSize = request.pageSize,
            TotalCount = experience.TotalCount,
            TotalPages = experience.TotalPages
        };
    }
}
