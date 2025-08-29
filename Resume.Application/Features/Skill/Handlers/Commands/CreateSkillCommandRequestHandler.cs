using AutoMapper;
using MediatR;
using Resume.Application.Features.Skill.Requests.Commands;
using Resume.Application.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Skill.Handlers.Commands;

public class CreateSkillCommandRequestHandler : IRequestHandler<CreateSkillCommandRequest, Unit>
{
    #region Constructor

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateSkillCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<Unit> Handle(CreateSkillCommandRequest request, CancellationToken cancellationToken)
    {
        var skill = _mapper.Map<Resume.Domain.Entity.Skill>(request.CreateSkillViewModel);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.Skill>().Add(skill);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
