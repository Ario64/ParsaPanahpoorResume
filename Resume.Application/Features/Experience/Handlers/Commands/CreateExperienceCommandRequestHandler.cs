using AutoMapper;
using System;
using MediatR;
using Resume.Application.Features.Experience.Requests.Commands;
using Resume.Application.UnitOfWork;
using Resume.Application.ViewModels.Experience.Validators;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Experience.Handlers.Commands;

public class CreateExperienceCommandRequestHandler : IRequestHandler<CreateExperienceCommandRequest, bool>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateExperienceCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;   
        _mapper = mapper;
    }

    #endregion

    public async Task<bool> Handle(CreateExperienceCommandRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateExperienceValidator();
        var validationResult = await validator.ValidateAsync(request.CreateExperienceViewModel, cancellationToken);
        if (validationResult.IsValid == false) 
        {
            throw new Exception();
        }

        var experinece = _mapper.Map<Resume.Domain.Entity.Experience>(request.CreateExperienceViewModel);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.Experience>().Add(experinece);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
