using MediatR;
using Resume.Application.Features.Skill.Requests.Commands;
using Resume.Application.UnitOfWork;
using Resume.Application.ViewModels.Skill.Validators;
using Resume.Application.ViewModels.Skill;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Skill.Handlers.Commands;

public class DeleteSkillCommandRequestHandler : IRequestHandler<DeleteSkillCommandRequest, bool>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;

    public DeleteSkillCommandRequestHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    #endregion

    public async Task<bool> Handle(DeleteSkillCommandRequest request, CancellationToken cancellationToken)
    {
        var validator = new DeleteSkillValidator();
        var validationResult = await validator.ValidateAsync(new DeleteSkillViewModel() { Id = request.Id }, cancellationToken);
        if (validationResult.IsValid == false)
        {
            throw new Exception();
        }

        var skill = await _unitOfWork.GenericRepository<Resume.Domain.Entity.Skill>().GetAsync(request.Id, cancellationToken);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.Skill>().Delete(skill);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
