using AutoMapper;
using MediatR;
using Resume.Application.Features.SocialMedia.Requests.Queries;
using Resume.Application.UnitOfWork;
using Resume.Domain.ViewModels.Pagination;
using Resume.Domain.ViewModels.Skill;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Skill.Handlers.Queries;

public class GetThingIDoListRequestHandler : IRequestHandler<GetThingIDoListRequest, PagedResult<SkillViewModel>>
{
    #region Constructor

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetThingIDoListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<PagedResult<SkillViewModel>> Handle(GetThingIDoListRequest request, CancellationToken cancellationToken)
    {
        var socialMediaList = await _unitOfWork.GenericRepository<Resume.Domain.Entity.SocialMedia>()
                                             .GetAllAsync(request.page, request.pageSize, cancellationToken);

        var items = _mapper.Map<IReadOnlyList<SkillViewModel>>(socialMediaList.Items);

        return new PagedResult<SkillViewModel>
        {
            Items = items,
            Page = request.page,
            PageSize = request.pageSize,
            TotalCount = socialMediaList.TotalCount,
            TotalPages = socialMediaList.TotalPages
        };
    }

}
