using AutoMapper;
using MediatR;
using Resume.Application.Features.Skill.Requests.Queries;
using Resume.Application.UnitOfWork;
using Resume.Domain.ViewModels.Skill;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Skill.Handlers.Queries;

public class GetSkillListRequestHandler : IRequestHandler<GetSkillListRequest, IReadOnlyList<SkillViewModel>>
{
    #region Constructor

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetSkillListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<IReadOnlyList<SkillViewModel>> Handle(GetSkillListRequest request, CancellationToken cancellationToken)
    {
        var skillList = await _unitOfWork.GenericRepository<Resume.Domain.Entity.Skill>()
                                             .GetAllAsync(cancellationToken);

        var skillListViewModel = _mapper.Map<IReadOnlyList<SkillViewModel>>(skillList);

        return skillListViewModel;
    }

}
