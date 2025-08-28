using AutoMapper;
using MediatR;
using Resume.Application.Features.PersonSelectedReservation.Requests.Commands;
using Resume.Application.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.PersonSelectedReservation.Handlers.Commands;

public class DeletePersonSelectedReservationCommandRequestHandler : IRequestHandler<DeletePersonSelectedReservationCommandRequest, Unit>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeletePersonSelectedReservationCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<Unit> Handle(DeletePersonSelectedReservationCommandRequest request, CancellationToken cancellationToken)
    {
       var person = await _unitOfWork.GenericRepository<Domain.Entity.Reservation.PersonSelectedReservation>()
                                     .GetAsync(request.Id, cancellationToken);

        _unitOfWork.GenericRepository<Domain.Entity.Reservation.PersonSelectedReservation>().Delete(person);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
