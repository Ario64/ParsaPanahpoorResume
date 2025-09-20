using AutoMapper;
using MediatR;
using Resume.Application.Exceptions;
using Resume.Application.Features.Skill.Requests.Commands;
using Resume.Application.UnitOfWork;
using Resume.Application.ViewModels.Skill.Validators;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Skill.Handlers.Commands;

public class EditSkillCommandRequestHandler : IRequestHandler<EditSkillCommandRequest, bool>
{
    #region Constructor

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public EditSkillCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<bool> Handle(EditSkillCommandRequest request, CancellationToken cancellationToken)
    {
        var validator = new EditSkillValidator();
        var validationResult = await validator.ValidateAsync(request.EditSkillViewModel, cancellationToken);
        if (validationResult.IsValid == false)
            throw new ValidationException(validationResult);

        var skill = await _unitOfWork.GenericRepository<Resume.Domain.Entity.Skill>().GetAsync(request.Id, cancellationToken);
        _mapper.Map(request.EditSkillViewModel, skill);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.Skill>().Update(skill);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
