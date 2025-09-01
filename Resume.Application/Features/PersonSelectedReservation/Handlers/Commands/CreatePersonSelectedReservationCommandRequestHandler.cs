using AutoMapper;
using MediatR;
using Resume.Application.Features.PersonSelectedReservation.Requests.Commands;
using Resume.Application.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.PersonSelectedReservation.Handlers.Commands;

public class CreatePersonSelectedReservationCommandRequestHandler : IRequestHandler<CreatePersonSelectedReservationCommandRequest, bool>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreatePersonSelectedReservationCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<bool> Handle(CreatePersonSelectedReservationCommandRequest request, CancellationToken cancellationToken)
    {
        var person = _mapper.Map<Resume.Domain.Entity.Reservation.PersonSelectedReservation>(request.CreatePersonSelectedReservation);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.Reservation.PersonSelectedReservation>().Add(person);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
