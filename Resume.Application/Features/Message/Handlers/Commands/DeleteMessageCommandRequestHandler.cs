using MediatR;
using Resume.Application.Exceptions;
using Resume.Application.Features.Message.Requests.Commands;
using Resume.Application.UnitOfWork;
using Resume.Application.ViewModels.Message;
using Resume.Application.ViewModels.Message.Validators;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Message.Handlers.Commands;

public class DeleteMessageCommandRequestHandler : IRequestHandler<DeleteMessageCommandRequest, bool>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;

    public DeleteMessageCommandRequestHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    #endregion

    public async Task<bool> Handle(DeleteMessageCommandRequest request, CancellationToken cancellationToken)
    {
        var validator = new DeleteMessageValidator();
        var validationResult = await validator.ValidateAsync(new DeleteMessageViewModel() { Id = request.Id }, cancellationToken);
        if (validationResult.IsValid == false)
            throw new ValidationException(validationResult);

        var message = await _unitOfWork.GenericRepository<Resume.Domain.Entity.Message>().GetAsync(request.Id, cancellationToken);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.Message>().Delete(message);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
