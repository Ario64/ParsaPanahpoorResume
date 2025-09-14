using AutoMapper;
using MediatR;
using Resume.Application.Features.Education.Requests.Commands;
using Resume.Application.ICacheService;
using Resume.Application.UnitOfWork;
using Resume.Application.ViewModels.Education;
using Resume.Application.ViewModels.Education.Validators;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Education.Handlers.Commands;

public class EditEducationCommandRequestHandler : IRequestHandler<EditEducationCommandRequest, bool>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ICacheServices _cache;

    public EditEducationCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper, ICacheServices cache)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _cache = cache;
    }

    #endregion

    public async Task<bool> Handle(EditEducationCommandRequest request, CancellationToken cancellationToken)
    {
        var validator = new EditEducationValidator();
        var validationResult = await validator.ValidateAsync(request.EditEducationViewModel, cancellationToken);
        if (validationResult.IsValid == false)
        {
            throw new Exception();
        }

        var education = await _unitOfWork.GenericRepository<Resume.Domain.Entity.Education>()
                                         .GetAsync(request.Id);

        var editedEducation = _mapper.Map(request.EditEducationViewModel, education);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.Education>().Update(editedEducation);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        //Remove list to update it
        await _cache.RemoveByPatternAsync("EducationList-*");

        //Set newly updated data in cache
        var cahceKey = $"Education:{request.Id}";
        var updatedEducation = _mapper.Map<EducationViewModel>(education);
        await _cache.SetAsync<EducationViewModel>(cahceKey, updatedEducation, TimeSpan.FromMinutes(10));

        return true;
    }
}
