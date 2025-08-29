using AutoMapper;
using MediatR;
using Resume.Application.Features.Skill.Requests.Queries;
using Resume.Application.UnitOfWork;
using Resume.Domain.ViewModels.Skill;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Skill.Handlers.Queries;

public class GetSkillRequestHandler : IRequestHandler<GetSkillRequest, SkillViewModel>
{
    #region Constructor

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetSkillRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<SkillViewModel> Handle(GetSkillRequest request, CancellationToken cancellationToken)
    {
        var skill = await _unitOfWork.GenericRepository<Resume.Domain.Entity.Skill>().GetAsync(request.Id, cancellationToken);
        return _mapper.Map<SkillViewModel>(skill);
    }
}
