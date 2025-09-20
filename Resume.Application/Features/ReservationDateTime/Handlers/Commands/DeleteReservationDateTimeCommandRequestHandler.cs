using MediatR;
using Resume.Application.Exceptions;
using Resume.Application.Features.ReservationDateTime.Requests.Commands;
using Resume.Application.UnitOfWork;
using Resume.Application.ViewModels.ReservationDateTime;
using Resume.Application.ViewModels.ReservationDateTime.Validators;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.ReservationDateTime.Handlers.Commands;

public class DeleteReservationDateTimeCommandRequestHandler : IRequestHandler<DeleteReservationDateTimeCommandRequest, bool>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;

    public DeleteReservationDateTimeCommandRequestHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    #endregion

    public async Task<bool> Handle(DeleteReservationDateTimeCommandRequest request, CancellationToken cancellationToken)
    {
        var validator = new DeleteReservationDateTimeValidator();
        var validationResult = await validator.ValidateAsync(new DeleteReservationDateTimeViewModel() { Id = request.Id}, cancellationToken);
        if (validationResult.IsValid == false)
            throw new ValidationException(validationResult);

        var reservationDateTime = await _unitOfWork.GenericRepository<Resume.Domain.Entity.ReservationDateTime>().GetAsync(request.Id, cancellationToken);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.ReservationDateTime>().Delete(reservationDateTime);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
