using AutoMapper;
using MediatR;
using Resume.Application.Exceptions;
using Resume.Application.Features.Experience.Requests.Commands;
using Resume.Application.UnitOfWork;
using Resume.Application.ViewModels.Experience.Validators;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Experience.Handlers.Commands;

public class EditExperienceCommandRequestHandler : IRequestHandler<EditExperienceCommandRequest, bool>
{
    #region Constructor

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public EditExperienceCommandRequestHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    #endregion

    public async Task<bool> Handle(EditExperienceCommandRequest request, CancellationToken cancellationToken)
    {
        var validator = new EditExperienceValidator();
        var validationResult = await validator.ValidateAsync(request.EditExperienceViewModel , cancellationToken);
        if (validationResult.IsValid == false)
            throw new ValidationException(validationResult);

        var experience = await _unitOfWork.GenericRepository<Resume.Domain.Entity.Experience>().GetAsync(request.Id, cancellationToken);
        _mapper.Map(request.EditExperienceViewModel, experience);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.Experience>().Update(experience);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
