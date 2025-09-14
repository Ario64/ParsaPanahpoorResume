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

public class DeleteEducationCommandRequestHandler : IRequestHandler<DeleteEducationCommandRequest, bool>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly ICacheServices _cache;

    public DeleteEducationCommandRequestHandler(IUnitOfWork unitOfWork, ICacheServices cache)
    {
        _unitOfWork = unitOfWork;
        _cache = cache;
    }

    #endregion

    public async Task<bool> Handle(DeleteEducationCommandRequest request, CancellationToken cancellationToken)
    {
        var validator = new DeleteEducationValidator();
        var validationResult = await validator.ValidateAsync(new DeleteEducationViewModel() {Id = request.Id }, cancellationToken);
        if (validationResult.IsValid == false)
        {
            throw new Exception();
        }

        var education = await _unitOfWork.GenericRepository<Resume.Domain.Entity.Education>().GetAsync(request.Id);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.Education>().Delete(education);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        //Remove data from redis cache
        await _cache.RemoveByPatternAsync("EducationList-*");

        return true;
    }
}
