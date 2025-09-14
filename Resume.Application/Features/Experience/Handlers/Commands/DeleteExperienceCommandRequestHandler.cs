using AutoMapper;
using MediatR;
using Resume.Application.Features.Experience.Requests.Commands;
using Resume.Application.UnitOfWork;
using Resume.Application.ViewModels.Experience;
using Resume.Application.ViewModels.Experience.Validators;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Experience.Handlers.Commands;

public class DeleteExperienceCommandRequestHandler : IRequestHandler<DeleteExperienceCommandRequest, Unit>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteExperienceCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<Unit> Handle(DeleteExperienceCommandRequest request, CancellationToken cancellationToken)
    {
        var validator = new DeleteExperienceValidator();
        var validationResult = await validator.ValidateAsync(new DeleteExperienceViewModel() { Id = request.Id }, cancellationToken);
        if (validationResult.IsValid == false)
        {
            throw new Exception();
        }

        var experience = await _unitOfWork.GenericRepository<Resume.Domain.Entity.Experience>().GetAsync(request.Id, cancellationToken);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.Experience>().Delete(experience);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
