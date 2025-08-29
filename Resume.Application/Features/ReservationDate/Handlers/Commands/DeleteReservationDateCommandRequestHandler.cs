using AutoMapper;
using MediatR;
using Resume.Application.Features.ReservationDate.Requests.Commands;
using Resume.Application.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.ReservationDate.Handlers.Commands;

public class DeleteReservationDateTimeCommandRequestHandler : IRequestHandler<DeleteReservationDateTimeCommandRequest, Unit>
{

    #region Constructor

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteReservationDateTimeCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<Unit> Handle(DeleteReservationDateTimeCommandRequest request, CancellationToken cancellationToken)
    {
        var reservationDate = await _unitOfWork.GenericRepository<Resume.Domain.Entity.ReservationDate>().GetAsync(request.Id, cancellationToken);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.ReservationDate>().Delete(reservationDate);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
