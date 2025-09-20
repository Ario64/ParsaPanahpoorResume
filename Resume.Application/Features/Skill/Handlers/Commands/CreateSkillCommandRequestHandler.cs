using AutoMapper;
using MediatR;
using Resume.Application.Exceptions;
using Resume.Application.Features.Skill.Requests.Commands;
using Resume.Application.UnitOfWork;
using Resume.Application.ViewModels.Skill.Validators;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Skill.Handlers.Commands;

public class CreateSkillCommandRequestHandler : IRequestHandler<CreateSkillCommandRequest, bool>
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

    public async Task<bool> Handle(CreateSkillCommandRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateSkillValidator();
        var validationResult = await validator.ValidateAsync(request.CreateSkillViewModel, cancellationToken);
        if (validationResult.IsValid == false)
            throw new ValidationException(validationResult);

        var skill = _mapper.Map<Resume.Domain.Entity.Skill>(request.CreateSkillViewModel);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.Skill>().Add(skill);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
