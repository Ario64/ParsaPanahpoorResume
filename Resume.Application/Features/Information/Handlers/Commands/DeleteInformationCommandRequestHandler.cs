using MediatR;
using Resume.Application.Features.Information.Requests.Commands;
using Resume.Application.UnitOfWork;
using Resume.Application.ViewModels.Information.Validators;
using Resume.Application.ViewModels.Information;
using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;

namespace Resume.Application.Features.Information.Handlers.Commands;

public class DeleteInformationCommandRequestHandler : IRequestHandler<DeleteInformationCommandRequest, bool>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;

    public DeleteInformationCommandRequestHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    #endregion

    public async Task<bool> Handle(DeleteInformationCommandRequest request, CancellationToken cancellationToken)
    {
        var validator = new DeleteInformationValidator();
        var validationResult = await validator.ValidateAsync(new DeleteInformationViewModel() { Id = request.Id }, cancellationToken);
        if (validationResult.IsValid == false)
        {
            throw new Exception();
        }

        var information = await _unitOfWork.GenericRepository<Resume.Domain.Entity.Information>().GetAsync(request.Id, cancellationToken);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.Information>().Delete(information);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
