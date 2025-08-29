using MediatR;
using Resume.Application.Features.Skill.Requests.Commands;
using Resume.Application.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Skill.Handlers.Commands;

public class DeleteSkillCommandRequestHandler : IRequestHandler<DeleteSkillCommandRequest, Unit>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;

    public DeleteSkillCommandRequestHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    #endregion

    public async Task<Unit> Handle(DeleteSkillCommandRequest request, CancellationToken cancellationToken)
    {
        var skill = await _unitOfWork.GenericRepository<Resume.Domain.Entity.Skill>().GetAsync(request.Id, cancellationToken);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.Skill>().Delete(skill);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
