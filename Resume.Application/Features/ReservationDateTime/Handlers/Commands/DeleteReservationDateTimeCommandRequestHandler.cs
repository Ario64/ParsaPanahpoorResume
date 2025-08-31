using MediatR;
using Resume.Application.Features.ReservationDateTime.Requests.Commands;
using Resume.Application.UnitOfWork;
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
        var reservationDateTime = await _unitOfWork.GenericRepository<Resume.Domain.Entity.ReservationDateTime>().GetAsync(request.Id, cancellationToken);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.ReservationDateTime>().Delete(reservationDateTime);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
